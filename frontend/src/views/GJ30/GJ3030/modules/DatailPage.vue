<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約農場別明細 讓渡元情報(選択)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.24
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="契約農場別明細 讓渡元情報(選択)"
    width="800px"
    :body-style="{ minHeight: '450px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form mt-1">
      <a-row>
        <a-col span="15">
          <th class="required">契約者</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
              <ai-select
                v-model:value="searchParams2.KEIYAKUSYA_CD"
                :disabled="isSearched2"
                :options="LIST"
                class="max-w-150"
                split-val
              ></ai-select>
            </a-form-item></td
        ></a-col>
        <a-col>
          <div class="flex ml-5">
            <a-space :size="20" class="mb-2">
              <a-button type="primary" @click="search2">検索</a-button
              ><a-button type="primary" @click="reset">条件クリア</a-button>
            </a-space>
          </div>
        </a-col></a-row
      >
    </div>
    <vxe-table
      class="my-1"
      ref="xTableRef2"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableData2"
      height="310px"
      :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
      :empty-render="{ name: 'NotData' }"
      @cell-dblclick="({ row }) => edit()"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      ><vxe-column type="checkbox" title="選択" width="100"></vxe-column>
      <vxe-column
        header-align="center"
        field="MOTO_NOJO_NAME"
        title="農場名(譲渡元)"
        width="200"
        sortable
        :params="{ order: 2 }"
        ><template #default="{ row }">
          <a @click="edit()">{{ row.MOTO_NOJO_NAME }}</a>
        </template>
      </vxe-column>
      <vxe-column
        header-align="center"
        field="ADDR"
        title="農場住所"
        sortable
        :params="{ order: 4 }"
      >
      </vxe-column>
      <vxe-column
        header-align="center"
        field="TORI_KBN_NAME"
        title="鶏の種類"
        width="150"
        sortable
        :params="{ order: 5 }"
      >
      </vxe-column>
      <vxe-column
        header-align="center"
        align="right"
        field="KEIYAKU_HASU"
        title="契約羽数"
        width="150"
        sortable
        :resizable="false"
        :params="{ order: 5 }"
      >
      </vxe-column>
    </vxe-table>

    <div class="edit_table form">
      <a-row>
        <a-col span="24">
          <th class="required">譲渡年月日</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
              <DateJp v-model:value="formData.KEIYAKU_DATE_FROM"></DateJp>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">入力確認有無</th>
          <td>
            <a-radio-group
              v-model:value="formData.SYORI_KBN"
              class="ml-2 h-full pt-1"
            >
              <a-radio :value="1">入力中</a-radio>
              <a-radio :value="2">入力確定</a-radio>
            </a-radio-group>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20" class="mb-2">
          <a-button class="warning-btn" @click="saveData">保存</a-button
          ><a-button class="danger-btn" :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
          <a-button type="primary">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { EnumEditKbn, PageStatus } from '@/enum'
import { Form, message } from 'ant-design-vue'
import { reactive, nextTick, onMounted, ref, watch, computed, toRef } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { changeTableSort } from '@/utils/util'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { KeiyakuJoho } from '../interface/3030/type'
import { VxeTableInstance } from 'vxe-table'
import useSearch from '@/hooks/useSearch'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])

const editJudge = new Judgement()
const createDefaultParams2 = () => {
  return {
    KEIYAKUSYA_CD: undefined,
  }
}
const searchParams2 = reactive(createDefaultParams2())
const LIST = ref<CmCodeNameModel[]>([])
const xTableRef2 = ref<VxeTableInstance>()
const createDefaultnojo = () => {
  return {
    NOJO_CD: undefined,
    ADDR_POST: '',
    ADDR_1: '',
    ADDR_2: '',
    ADDR_3: '',
    ADDR_4: '',
  }
}
const createDefaultform = () => {
  return {
    KEIYAKU_DATE_FROM: undefined,
    SYORI_KBN: 1,
  }
}
const formData = reactive(createDefaultform())
const isSearched2 = ref(false)
const tableData2 = ref<KeiyakuJoho[]>([])
const tableDefault2 = {
  MOTO_NOJO_CD: 9876,
  KEIYAKU_KBN: 2,
  MOTO_NOJO_NAME: '譲渡元農場',
  ADDR: '東京都中央区1-2-3',
  TORI_KBN: 1,
  TORI_KBN_NAME: 'ブロイラー',
  KEIYAKU_HASU: 5000,
}
const isEditing2 = ref(false)
const rules = reactive({})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  },
})
const isDataSelected2 = computed(() => {
  return tableData2.value.length > 0 && xTableRef2.value?.getCurrentRecord()
})
const isNew = computed(() => (props.editkbn === EnumEditKbn.Add ? true : false))
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      // InitDetail()
      // SearchDetail()
      nextTick(() => editJudge.reset())
    }
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  searchParams2,
  rules
)
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData2,
  params: toRef(() => searchParams2),
})
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

const closeModal = () => {
  resetFields
  tableData2.value = []
  emit('update:visible', false)
}

const saveData = async () => {
  if (!editJudge.isPageEdited()) {
    showInfoModal({
      content: '変更したデータはありません。',
    })
  } else {
    showSaveModal({
      content: SAVE_CONFIRM.Msg,
      onOk: async () => {
        try {
          closeModal()
          message.success(SAVE_OK_INFO.Msg)
        } catch (error) {}
      },
    })
  }
}
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    content: DELETE_CONFIRM.Msg,
    onOk: async () => {
      try {
        // await Delete({
        //   KI: formData.KI,
        //   KEIYAKUSYA_CD: formData.KEIYAKUSYA_CD,
        //   NOJO_CD: formData.NOJO_CD,
        //   UP_DATE: upddttm,
        //   EDIT_KBN: EnumEditKbn.Edit,
        // })
        closeModal()
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
function search2() {
  tableData2.value.push(tableDefault2)
  if (xTableRef2.value && tableData2.value.length > 0) {
    xTableRef2.value.setCurrentRow(tableData2.value[0])
  }
  isSearched2.value = true
}
//条件クリア
const reset = () => {
  isSearched2.value = false
  isEditing2.value = false
  tableData2.value = []
}
const edit = () => {
  isEditing2.value = true
}
</script>
<style lang="scss" scoped>
th {
  width: 150px;
}
.thleft {
  :deep(th) {
    text-align: right;
  }
}
</style>
