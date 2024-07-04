<template>
  <a-modal
    v-model:visible="modalVisible"
    :title="`${isEddit ? '編集' : 'データソース新規作成'}`"
    :width="`${isEddit ? '750px' : '1050px'}`"
    centered
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <!--    <a-spin :spinning="loading">-->
    <a-form>
      <div class="self_adaption_table form">
        <a-row>
          <a-col v-bind="layout">
            <th :class="classNames">データソースID</th>
            <td>
              <a-form-item v-bind="validateInfos.datasourceid">
                <a-input
                  v-model:value="formData.datasourceid"
                  maxlength="4"
                  :disabled="isEddit"
                  allow-clear
                  @change="
                    formData.datasourceid = replaceText(formData.datasourceid, EnumRegex.半角数字)
                  "
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">データソース名称</th>
            <td>
              <a-form-item v-bind="validateInfos.datasourcenm">
                <a-input v-model:value="formData.datasourcenm" maxlength="30" allow-clear></a-input>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">業務</th>
            <td>
              <a-form-item v-bind="validateInfos.gyoumucd">
                <ai-select v-model:value="formData.gyoumucd" :options="gyoumucdOptions"></ai-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th :class="classNames">メインテーブル</th>
            <td>
              <a-form-item v-bind="validateInfos.maintablealias">
                <a-select
                  v-model:value="formData.maintablealias"
                  :disabled="isEddit"
                  :options="mainTableOptions"
                  :field-names="{ label: 'tablehyojinm', value: 'tablenm' }"
                  allow-clear
                  show-search
                  :filter-option="filterOption"
                  @change="onChangeMaintablealias"
                >
                  <template #option="{ tablenm, tablehyojinm }">
                    {{ tablenm + ' : ' + tablehyojinm }}
                  </template>
                </a-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-if="!isEddit" v-bind="layout">
            <th class="required">大分類</th>
            <td>
              <a-form-item v-bind="validateInfos.daibunrui">
                <a-select
                  v-model:value="formData.daibunrui"
                  :options="daibunruiOptions"
                  class="w-full"
                ></a-select
              ></a-form-item>
            </td>
          </a-col>
          <!-- <a-col v-if="false" v-bind="layout">
              <th>その他テーブル</th>
              <td>
                <a-select
                  v-model:value="formData.jointablelist"
                  mode="multiple"
                  style="width: 100%"
                  :max-tag-text-length="10"
                  :max-tag-count="9"
                  allow-clear
                  :field-names="{ label: 'tablehyojinm', value: 'tablealias' }"
                  :options="jointableOptions"
                >
                  <template #maxTagPlaceholder="omittedValues">
                    <span style="color: red">+ {{ omittedValues.length }} ...</span>
                  </template>
                </a-select>
              </td>
            </a-col> -->
        </a-row>
      </div>
      <div v-if="!isEddit">
        <span>項目一覧</span>
        <!--        :loading="tableLoading"-->
        <vxe-table
          ref="xTableRef"
          :height="300"
          :column-config="{ resizable: true }"
          :row-config="{ keyField: 'itemnm', isCurrent: true, isHover: true }"
          :data="filterTable"
          :sort-config="{ trigger: 'cell' }"
          :checkbox-config="{
            trigger: 'row',
            checkField: 'checked'
          }"
          :empty-render="{ name: 'NotData' }"
          @checkbox-change="selectCheckbox"
          @checkbox-all="selectCheckbox"
        >
          <vxe-column type="checkbox" width="50" />
          <vxe-column field="itemid" title="項目コード" sortable />
          <vxe-column field="itemhyojinm" title="項目名" sortable />
          <vxe-column field="sqlcolumn" title="SQLカラム" sortable />
          <vxe-column field="daibunrui" title="大分類" sortable />
          <vxe-column field="tyubunrui" title="中分類" sortable />
          <vxe-column field="syobunrui" title="小分類" sortable :resizable="false" />
        </vxe-table>
      </div>
    </a-form>
    <!--    </a-spin>-->

    <template #footer>
      <a-button
        :loading="submitLoading"
        style="float: left"
        class="warning-btn"
        :disabled="checkIsDisabledBtn()"
        @click="handleSave"
        >{{ isEddit ? '登録' : '次へ' }}</a-button
      >
      <a-button type="primary" @click="onClickClose">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, reactive, ref, watch, nextTick } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'
import { SaveRequest, TableItemVM, TableVM } from './type'
import { Search, Init, Save } from './service'
import { Save as Save_101 } from '../AWEU00101G/service'
import { PageSatatus, EnumRegex } from '#/Enums'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { layout } from './constants'
import { replaceText } from '@/utils/util'
import { showSaveModal } from '@/utils/modal'
import { GlobalStore } from '@/store'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------

type tableType = (TableItemVM & { checked?: boolean })[]

interface Props {
  visible: boolean
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'update:tableInfo'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
//ローディング
// const loading = ref(false)
// const tableLoading = ref(false)
const submitLoading = ref(false)
//ビューモデル
const editJudge = new Judgement()
const xTableRef = ref<VxeTableInstance>()
const selectedRows = ref<TableItemVM[]>([])
const formData = reactive<SaveRequest & { upddttm?: string; daibunrui: string | null }>({
  datasourceid: '', // データソースID
  datasourcenm: '', // データソース名称
  gyoumucd: '', // 業務
  maintablealias: '', // メインテーブル別名
  jointablelist: [], // その他テーブルリスト
  sqlcolumns: [], // メインテーブルSQLカラム集合
  upddttm: '',
  daibunrui: null
})
const mainTableOptions = ref<TableVM[]>([])
const jointableOptions = ref<TableVM[]>([])
const gyoumucdOptions = ref<DaSelectorModel[]>([])
const daibunruiOptions = ref<DaSelectorModel[]>([])
const tableList = ref<tableType>([])
const isEddit = computed(() => (route.query.datasourceid ? true : false))
const classNames = computed(() => (isEddit.value ? 'bg-readonly' : 'required'))

const checkIsDisabledBtn = () => {
  if (isEddit.value) {
    return false
  } else {
    if (selectedRows.value?.length === 0) {
      return true
    }

    return false
  }
}

const rules = reactive({
  datasourceid: [
    {
      validator: (_rule, value: string) => {
        if (!value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'データソースID '))
        }
        if (!/^\d{4}$/.test(value)) {
          return Promise.reject('データソースIDは4桁の数字です。')
        }
        return Promise.resolve()
      }
    }
  ],
  datasourcenm: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'データソース名称')
    }
  ],
  gyoumucd: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '業務')
    }
  ],
  maintablealias: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'メインテーブル')
    }
  ],
  daibunrui: [
    {
      required: !isEddit.value,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '大分類')
    }
  ]
})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(formData, rules)
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      // loading.value = true
      tableList.value = []
      Init().then((res) => {
        mainTableOptions.value = res.tablelist
        gyoumucdOptions.value = res.selectorlist
        nextTick(() => editJudge.reset())
      })
      // .finally(() => {
      //   loading.value = false
      // })
    }
  }
)

watch(formData, () => editJudge.setEdited(), { deep: true })

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})

const filterTable = computed(() => {
  if (formData.maintablealias && !formData.daibunrui) {
    return tableList.value
  } else {
    return tableList.value.filter((el) => el.daibunrui === formData.daibunrui)
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
const getTableList = () => {
  // tableLoading.value = true
  Search({ tablealias: formData.maintablealias })
    .then((res) => {
      daibunruiOptions.value = res.daibunruilist.map((item) => ({ value: item, label: item }))
      formData.daibunrui = res.daibunruilist[0]
      tableList.value = res.tableitemlist
      jointableOptions.value = res.jointablelist
      setDefaultCheck()
    })
    .finally(() => {
      // tableLoading.value = false
      nextTick(() => editJudge.reset())
    })
}
//メインテーブル
const onChangeMaintablealias = (val) => {
  daibunruiOptions.value = []
  formData.daibunrui = null
  if (val) getTableList()
}

//確認と保存処理
const handleSave = async () => {
  await validate()

  formData.sqlcolumns = selectedRows.value.map((el) => el.sqlcolumn)
  showSaveModal({
    onOk: async () => {
      submitLoading.value = true
      const SaveRequest = isEddit.value ? Save_101 : Save
      try {
        SaveRequest({ ...formData, gyoumu: formData.gyoumucd }).then((res) => {
          message.success(SAVE_OK_INFO.Msg)
          if (!isEddit.value) {
            router.push({
              name: 'AWEU00101G',
              query: {
                status: PageSatatus.Edit,
                maintablealias: formData.maintablealias,
                datasourcenm: formData.datasourcenm,
                datasourceid: formData.datasourceid
              }
            })
          } else {
            emit('update:tableInfo', {
              ...formData,
              gyoumu: formData.gyoumucd,
              upddttm: res.upddttm
            })
          }
          closeModal()
        })
      } catch (error) {}
      submitLoading.value = false
    }
  })
}
//取消処理
const closeModal = () => {
  clearValidate()
  clearTable()
  resetFields()
  modalVisible.value = false
}

const onClickClose = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

// デフォルトチェック設定
const setDefaultCheck = () => {
  selectedRows.value = tableList.value?.filter((item) => item.checked)
}

//tableをキャンセル
function clearTable() {
  const $table = xTableRef.value
  $table?.clearCheckboxRow()
  $table?.clearCurrentRow()
  $table?.clearSort()
  tableList.value = []
  selectedRows.value = []
  daibunruiOptions.value = []
}
//行選択(削除/ダウンロード)
function selectCheckbox() {
  const $table = xTableRef.value
  if ($table) {
    selectedRows.value = $table.getCheckboxRecords()
  }
  editJudge.setEdited()
}

const setFilesValues = (data) => {
  Object.assign(formData, data)
  formData.gyoumucd = data.gyoumu
  nextTick(() => editJudge.reset())
}
function filterOption(input: string, option) {
  return (
    option.tablenm.toLowerCase().includes(input.toLowerCase()) ||
    option.tablehyojinm.toLowerCase().includes(input.toLowerCase())
  )
}
defineExpose({
  setFilesValues
})
</script>
<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}

th {
  width: 180px;
}
</style>
