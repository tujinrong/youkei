<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px flex">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <h1>（GJ8050）金融機関一覧</h1>
      <div class="self_adaption_table form mt-1">
        <div class="max-w-750px">
          <a-row>
            <a-col v-bind="layout">
              <th>金融機関コード</th>
              <td>
                <a-form-item v-bind="validateInfos.BANK_CD">
                  <a-input
                    v-model:value="searchParams.BANK_CD"
                    :maxlength="4"
                    class="max-w-15"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>金融機関名（ｶﾅ）</th>
              <td>
                <a-form-item>
                  <a-input
                    v-model:value="searchParams.BANK_KANA"
                    :maxlength="60"
                    class="max-w-full"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>金融機関名（漢字）</th>
              <td>
                <a-form-item>
                  <a-input
                    v-fullwidth-limit
                    v-model:value="searchParams.BANK_NAME"
                    :maxlength="30"
                    class="max-w-75"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
        <div class="my-2 flex">
          <a-space
            ><span>検索方法</span>
            <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
              <a-radio :value="EnumAndOr.AndCode">すべてを含む(AND)</a-radio>
              <a-radio :value="EnumAndOr.OrCode">いずれかを含む(OR)</a-radio>
            </a-radio-group></a-space
          >
        </div>
      </div>
      <div class="flex">
        <a-space :size="20">
          <a-button type="primary" @click="searchAll()">検索</a-button>
          <a-button type="primary" @click="reset">キャンセル</a-button>
          <a-button class="ml-10" type="primary" @click="forwardNew1"
            >新規登録</a-button
          >
          <a-button type="primary" @click="preview1">プレビュー</a-button>
        </a-space>
        <EndButton />
      </div>
    </a-card>
    <a-card :bordered="false" ref="cardRef1" class="staticWidth flex-1">
      <a-pagination
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="(total) => `抽出件数： ${total} 件`"
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        class="mt-2"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="bankTableData"
        height="480px"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit1(row.BANK_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="BANK_CD"
          title="金融機関コード"
          width="120"
          align="center"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit1(row.BANK_CD)">{{ row.BANK_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="BANK_KANA"
          title="金融機関名（ｶﾅ）"
          min-width="400"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="BANK_NAME"
          title="金融機関名（漢字）"
          width="350"
          sortable
          :params="{ order: 3 }"
        ></vxe-column>
        <vxe-column
          header-align="center"
          title="支店情報"
          min-width="120"
          align="center"
          ><template #default="{ row }">
            <a @click="showSiten(row.BANK_CD)"><span>支店情報</span></a>
          </template></vxe-column
        >
      </vxe-table></a-card
    >
  </div>
  <EditPage
    v-model:visible="editVisible1"
    :editkbn="editkbn1"
    :bankcd="bankcd"
    @getTableList="searchAll"
  />
  <ListPage2 v-model:visible="list2Visible" :bankcd="bankcd" :URL="URL" />
</template>

<script lang="ts" setup>
import { ref, reactive, toRef, computed, onUnmounted, watch } from 'vue'
import { EnumAndOr, EnumEditKbn } from '@/enum'
import useSearch from '@/hooks/useSearch'
import {
  changeTableSort,
  convertKanaToHalfWidth,
  convertToHalfWidthProhibitLetter,
  openNew,
} from '@/utils/util'
import { VxeTableInstance } from 'vxe-pc-ui'
import { SearchBankRowVM, SearchSitenRowVM } from '../service/8050/type'
import { PreviewBank, SearchBank } from '../service/8050/service'
import { showInfoModal } from '@/utils/modal'
import EditPage from './EditPage.vue'
import ListPage2 from './ListPage2.vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { encryptByBase64 as encrypt } from '@/utils/encrypt/data'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const xTableRef = ref<VxeTableInstance>()

const createDefaultParams = () => {
  return {
    BANK_CD: '',
    BANK_KANA: '',
    BANK_NAME: '',
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}
const searchParams = reactive(createDefaultParams())

const bankTableData = ref<SearchBankRowVM[]>([])

const rules = reactive({
  BANK_CD: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '金融機関コード'),
    },
  ],
})
const { validateInfos } = Form.useForm(searchParams, rules)

const editVisible1 = ref(false)
const list2Visible = ref(false)
const editkbn1 = ref<EnumEditKbn>(EnumEditKbn.Add)
const sitencd = ref()
const sitanTableData = ref<SearchSitenRowVM[]>([])
//表の高さ
const headRef = ref(null)
const previewName = ref('')
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const bankcd = ref('')
const currentRow = ref<SearchBankRowVM | null>(null)
const host = window.location.href.includes('localhost')
  ? 'localhost:9527'
  : '61.213.76.155:65534'
const URL = computed(() => {
  return `http://${host}/preview`
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isSelected = computed(() => {
  if (xTableRef) return xTableRef.value?.getCurrentRecord()
  return false
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//銀行

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchBank,
  source: bankTableData,
  params: toRef(() => searchParams),
  tableRef: xTableRef,
  // validate,
})

const searchAll = async (deleteflg: boolean = false) => {
  await searchData()
  if (bankTableData.value.length <= 0 && !deleteflg) {
    showInfoModal({
      type: 'warning',
      content: '指定された条件に一致するデータは存在しません。',
    })
  }
}
async function forwardNew1() {
  editkbn1.value = EnumEditKbn.Add
  editVisible1.value = true
}
async function forwardEdit1(BANK_CD) {
  editkbn1.value = EnumEditKbn.Edit
  editVisible1.value = true
  bankcd.value = BANK_CD
}
// クリア
async function reset() {
  Object.assign(searchParams, createDefaultParams())
  xTableRef.value?.clearSort()
  clear()
}
const showSiten = (BANKCD: string) => {
  list2Visible.value = true
  bankcd.value = BANKCD
}
//--------------------------------------------------------------------------
//プレビュー
//--------------------------------------------------------------------------
async function preview1() {
  try {
    previewName.value = 'S80501'
    await PreviewBank({ ...searchParams })
    openNew(searchParams, previewName.value)
  } catch (error) {}
}
onUnmounted(() => {
  previewName.value = ''
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
/**金融機関コード */
watch(
  () => searchParams.BANK_CD,
  (newVal) => {
    if (newVal) {
      searchParams.BANK_CD = convertToHalfWidthProhibitLetter(newVal)
    }
  },
  { deep: true }
)

/**金融機関名（ｶﾅ） */
watch(
  () => searchParams.BANK_KANA,
  (newVal) => {
    if (newVal) {
      searchParams.BANK_KANA = convertKanaToHalfWidth(newVal)
    }
  },
  { deep: true }
)
</script>

<style lang="scss" scoped>
th {
  min-width: 140px;
}
</style>
