<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.
 * 作成者　　: xxx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :open="modalVisible"
    centered
    title="支店情報一覧"
    width="1000px"
    :body-style="{ height: '600px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="self_adaption_table form mt-1">
      <a-row>
        <a-col span="19">
          <th>支店コード</th>
          <td>
            <a-form-item>
              <a-input
                v-model:value="searchParams2.SITEN_CD"
                :maxlength="3"
                class="max-w-15"
              ></a-input>
            </a-form-item>
          </td>
        </a-col>

        <a-col span="19">
          <th>支店名（ｶﾅ）</th>
          <td>
            <a-form-item>
              <a-input
                v-model:value="searchParams2.SITEN_KANA"
                :maxlength="60"
                class="max-w-full"
              ></a-input>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="19">
          <th>支店名（漢字）</th>
          <td>
            <a-form-item>
              <a-input
                v-model:value="searchParams2.SITEN_NAME"
                :maxlength="30"
                class="max-w-75"
                @input="checkUserNameInput"
              ></a-input>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
    </div>
    <div class="my-2 flex">
      <a-space
        ><span>検索方法</span>
        <a-radio-group v-model:value="searchParams2.SEARCH_METHOD">
          <a-radio :value="EnumAndOr.AndCode">すべてを含む(AND)</a-radio>
          <a-radio :value="EnumAndOr.OrCode">いずれかを含む(OR)</a-radio>
        </a-radio-group></a-space
      >
    </div>
    <div class="flex">
      <a-space :size="20">
        <a-button type="primary" @click="searchAll2()">検索</a-button>
        <a-button type="primary" @click="reset2">条件クリア</a-button>
        <a-button class="ml-10" type="primary" @click="forwardNew2"
          >新規登録</a-button
        >
        <a-button type="primary" @click="preview2">プレビュー</a-button>
      </a-space>
    </div>
    <a-pagination
      v-model:current="pageParams2.PAGE_NUM"
      v-model:page-size="pageParams2.PAGE_SIZE"
      :total="totalCount2"
      :page-size-options="['10', '25', '50', '100']"
      :show-total="(total) => `抽出件数： ${total} 件`"
      show-less-items
      show-size-changer
      class="m-y-1 text-end"
    />
    <vxe-table
      class="mt-2"
      ref="xTableRef2"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="sitanTableData"
      height="370px"
      :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
      :empty-render="{ name: 'NotData' }"
      @cell-dblclick="({ row }) => forwardEdit2(row.BANK_CD, row.SITEN_CD)"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams2, 'ORDER_BY'))"
    >
      <vxe-column
        header-align="center"
        field="BANK_CD"
        title="金融機関"
        width="120"
        align="center"
        sortable
        :params="{ order: 1 }"
        :resizable="true"
      >
      </vxe-column>
      <vxe-column
        header-align="center"
        field="SITEN_CD"
        title="支店コード"
        width="120"
        align="center"
        sortable
        :params="{ order: 2 }"
        :resizable="true"
      >
        <template #default="{ row }">
          <a @click="forwardEdit2(row.BANK_CD, row.SITEN_CD)">{{
            row.SITEN_CD
          }}</a>
        </template>
      </vxe-column>
      <vxe-column
        header-align="center"
        field="SITEN_KANA"
        title="支店名（ｶﾅ）"
        min-width="300"
        sortable
        :params="{ order: 3 }"
        :resizable="false"
      >
      </vxe-column>
      <vxe-column
        header-align="center"
        field="SITEN_NAME"
        title="支店名（漢字）"
        width="300"
        sortable
        :params="{ order: 4 }"
        :resizable="false"
      >
      </vxe-column>
    </vxe-table>
    <EditPage2
      v-model:visible="editVisible2"
      :editkbn="editkbn2"
      :bankcd="bankcd"
      :sitencd="sitencd"
      @getTableList="searchAll2"
    /><template #footer>
      <div class="pt-2 flex justify-end border-t-1">
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template></a-modal
  >
</template>
<script lang="ts" setup>
import { EnumAndOr, EnumEditKbn } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, reactive, ref, toRef, watch } from 'vue'
import {
  changeTableSort,
  convertKanaToHalfWidth,
  convertToHalfNumber,
} from '@/utils/util'
import EditPage2 from './EditPage2.vue'
import { VxeTableInstance } from 'vxe-table'
import { SearchSitenRowVM } from '../service/8050/type'
import { PreviewSiten, SearchSiten } from '../service/8050/service'
import { showInfoModal } from '@/utils/modal'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  bankcd: string
  URL: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
const createDefaultParams2 = () => {
  return {
    BANK_CD: '',
    SITEN_CD: '',
    SITEN_KANA: '',
    SITEN_NAME: '',
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}
const searchParams2 = reactive(createDefaultParams2())
const xTableRef2 = ref<VxeTableInstance>()
const editVisible2 = ref(false)
const sitencd = ref()
const editkbn2 = ref<EnumEditKbn>(EnumEditKbn.Add)
const sitanTableData = ref<SearchSitenRowVM[]>([])
const currentRow2 = ref<SearchSitenRowVM | null>(null)
const rules = reactive({})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  searchParams2,
  rules
)
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

const checkUserNameInput = () => {
  const userInput = searchParams2.SITEN_NAME
  let byteCount = 0
  let result = ''

  for (let i = 0; i < userInput.length; i++) {
    const char = userInput[i]

    if (char.match(/[^\x00-\x7F]/)) {
      byteCount += 2
    } else {
      byteCount += 1
    }

    if (byteCount > 30) {
      break
    }
    result += char
  }
  searchParams2.SITEN_NAME = result
}

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newV) => {
    if (newV) {
      // searchAll2(false)
      searchParams2.BANK_CD = props.bankcd
    }
  }
)

watch(
  () => searchParams2,
  (newVal) => {
    if (newVal) {
      searchParams2.SITEN_CD = convertToHalfNumber(newVal.SITEN_CD)
      searchParams2.SITEN_KANA = convertKanaToHalfWidth(newVal.SITEN_KANA)
    }
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const closeModal = () => {
  resetFields()
  clearValidate()
  reset2()
  sitanTableData.value = []
  modalVisible.value = false
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

//検索処理支店
const {
  pageParams: pageParams2,
  totalCount: totalCount2,
  searchData: searchData2,
  clear: clear2,
} = useSearch({
  service: SearchSiten,
  source: sitanTableData,
  params: toRef(() => searchParams2),
  // validate,
})

const searchAll2 = async (deleteflg: boolean = false) => {
  await searchData2()
  if (sitanTableData.value.length <= 0 && !deleteflg) {
    showInfoModal({
      type: 'warning',
      content: '指定された条件に一致するデータは存在しません。',
    })
  }
  if (xTableRef2.value && sitanTableData.value.length > 0) {
    xTableRef2.value.setCurrentRow(sitanTableData.value[0])
  }
}
async function forwardNew2() {
  editkbn2.value = EnumEditKbn.Add
  editVisible2.value = true
}

async function forwardEdit2(BANK_CD, SITEN_CD) {
  editkbn2.value = EnumEditKbn.Edit
  editVisible2.value = true
  sitencd.value = SITEN_CD
}

// クリア支店
async function reset2() {
  Object.assign(searchParams2, createDefaultParams2())
  xTableRef2.value?.clearSort()
  clear2()
}
//--------------------------------------------------------------------------
//プレビュー
//--------------------------------------------------------------------------

async function preview2() {
  try {
    await PreviewSiten({ ...searchParams2, BANK_CD: props.bankcd })
    const openNew = () => {
      window.open(props.URL, '_blank')
    }
    openNew()
  } catch (error) {}
}

const channel = new BroadcastChannel('channel_preview')
channel.onmessage = (event) => {
  if (event.data.isMounted) {
    channel.postMessage({
      params: JSON.stringify({ ...searchParams2, BANK_CD: props.bankcd }),
      name: 'S80502',
    })
  }
}
</script>

<style lang="scss" scoped>
th {
  min-width: 140px;
}
</style>
