<template>
  <div class="min-h-fit min-h-500px flex-col-stretch gap-12px flex">
    <a-card ref="headRef" :bordered="false">
      <h1>（GJ8050）金融機関一覧</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col v-bind="layout">
            <th>金融機関コード</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams.BANK_CD"
                  :maxlength="4"
                  class="max-w-35"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>金融機関名（ｶﾅ）</th>
            <td>
              <a-form-item>
                <a-input v-model:value="searchParams.BANK_KANA"></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>金融機関名（漢字）</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams.BANK_NAME"
                  class="max-w-180"
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
      <div class="flex">
        <a-space :size="20">
          <a-button type="primary" @click="searchAll()">検索</a-button>
          <a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button class="ml-20" type="primary" @click="forwardNew1"
            >新規登録</a-button
          >
          <a-button type="primary" @click="preview1">プレビュー</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card :bordered="false" ref="cardRef1">
      <a-pagination
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="(total) => `抽出件数： ${total} 件`"
        show-less-items
        show-size-changer
        class="m-b-1 text-end" />
      <vxe-table
        class="mt-2"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :height="height1 - 70"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="bankTableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit1(row.BANK_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="BANK_CD"
          title="金融機関"
          width="150"
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
          width="300"
          sortable
          :params="{ order: 3 }"
          :resizable="false"
        ></vxe-column> </vxe-table
    ></a-card>
    <a-card>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col v-bind="layout">
            <th>支店コード</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams2.SITEN_CD"
                  :maxlength="3"
                  class="max-w-35"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th>支店名（ｶﾅ）</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams2.SITEN_KANA"
                  :maxlength="20"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>支店名（漢字）</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams2.SITEN_NAME"
                  :maxlength="20"
                  class="max-w-180"
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
          <a-button class="ml-20" type="primary" @click="forwardNew2"
            >新規登録</a-button
          >
          <a-button type="primary" @click="preview2">プレビュー</a-button>
        </a-space>
      </div>
      <div v-if="!isSelectBank" class="search-disabled-mask bg-disabled"></div
    ></a-card>
    <a-card ref="cardRef2" class="mb-2">
      <a-pagination
        v-model:current="pageParams2.PAGE_NUM"
        v-model:page-size="pageParams2.PAGE_SIZE"
        :total="totalCount2"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="(total) => `抽出件数： ${total} 件`"
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        class="mt-2"
        ref="xTableRef2"
        :column-config="{ resizable: true }"
        :height="height2 - 70"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="sitanTableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit2(row.BANK_CD, row.SITEN_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams2, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="BANK_CD"
          title="金融機関"
          width="150"
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
          width="130"
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
          min-width="400"
          sortable
          :params="{ order: 3 }"
          :resizable="false"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="SITEN_NAME"
          title="支店名（漢字）"
          width="400"
          sortable
          :params="{ order: 4 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>
      <div v-if="!isSelectBank" class="search-disabled-mask bg-disabled"></div>
    </a-card>
  </div>
  <EditPage
    v-model:visible="editVisible1"
    :editkbn="editkbn1"
    :bankcd="bankcd"
    @getTableList="searchAll"
  />
  <EditPage2
    v-model:visible="editVisible2"
    :editkbn="editkbn2"
    :bankcd="bankcd"
    :sitencd="sitencd"
    @getTableList="searchAll2"
  />
</template>

<script lang="ts" setup>
import {
  ref,
  reactive,
  toRef,
  watch,
  onMounted,
  computed,
  nextTick,
  onUnmounted,
} from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { changeTableSort } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'
import { VxeTableInstance } from 'vxe-pc-ui'
import { SearchBankRowVM, SearchSitenRowVM } from '../service/8050/type'
import {
  PreviewBank,
  PreviewSiten,
  SearchBank,
  SearchSiten,
} from '../service/8050/service'
import { showInfoModal } from '@/utils/modal'
import EditPage from './EditPage.vue'
import EditPage2 from './EditPage2.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()

const xTableRef = ref<VxeTableInstance>()
const xTableRef2 = ref<VxeTableInstance>()

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
const editVisible1 = ref(false)
const editkbn1 = ref<EnumEditKbn>(EnumEditKbn.Add)
const editVisible2 = ref(false)
const bankcd = ref()
const sitencd = ref()
const editkbn2 = ref<EnumEditKbn>(EnumEditKbn.Add)
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
const cardRef1 = ref()
const { height: height1 } = useElementSize(cardRef1)
const cardRef2 = ref()
const { height: height2 } = useElementSize(cardRef2)
const currentRow = ref<SearchBankRowVM | null>(null)
const currentRow2 = ref<SearchSitenRowVM | null>(null)
const host = window.location.href.includes('localhost')
  ? 'localhost:9527'
  : '61.213.76.155:65534'
const URL = computed(() => {
  return `http://${host}/preview`
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isSelectBank = computed(() => currentRow.value !== null)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

watch(
  () => xTableRef.value?.getCurrentRecord(),
  (val) => {
    currentRow.value = val
    searchParams2.BANK_CD = currentRow.value?.BANK_CD ?? ''
    if (sitanTableData.value.length <= 0) {
      bankcd.value = currentRow.value?.BANK_CD ?? ''
    }
  }
)

watch(
  () => xTableRef2.value?.getCurrentRecord(),
  (val) => {
    currentRow2.value = val
    // searchParams2.BANK_CD = currentRow2.value?.BANK_CD ?? ''
    bankcd.value = currentRow2.value?.BANK_CD ?? ''
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//銀行

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchBank,
  source: bankTableData,
  params: toRef(() => searchParams),
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
  if (xTableRef.value && bankTableData.value.length > 0) {
    xTableRef.value.setCurrentRow(bankTableData.value[0])
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
  reset2()
}

//支店

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
  bankcd.value = currentRow2.value?.BANK_CD ?? bankcd.value
  editkbn2.value = EnumEditKbn.Add
  editVisible2.value = true
}

async function forwardEdit2(BANK_CD, SITEN_CD) {
  editkbn2.value = EnumEditKbn.Edit
  editVisible2.value = true
  bankcd.value = BANK_CD
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
async function preview1() {
  try {
    previewName.value = 'S80501'
    await PreviewBank({ ...searchParams })
    const openNew = () => {
      window.open(URL.value, '_blank')
    }
    openNew()
  } catch (error) {}
}
async function preview2() {
  try {
    previewName.value = 'S80502'
    await PreviewSiten({ ...searchParams2 })
    const openNew = () => {
      window.open(URL.value, '_blank')
    }
    openNew()
  } catch (error) {}
}

const channel = new BroadcastChannel('channel_preview')
channel.onmessage = (event) => {
  if (event.data.isMounted) {
    channel.postMessage({
      params:
        previewName.value === 'S80501'
          ? JSON.stringify(searchParams)
          : JSON.stringify(searchParams2),
      name: previewName.value,
    })
  }
}
onUnmounted(() => {
  previewName.value = ''
  channel.close()
})
</script>

<style lang="scss" scoped>
th {
  min-width: 140px;
}

:deep(.ant-form-item) {
  margin-bottom: 0;
  width: 100%;
}

.search-disabled-mask {
  position: absolute;
  background-color: #f5f5f5;
  width: 100%;
  height: 100%;
  top: 0;
  z-index: 99;
  opacity: 0.5;
}
</style>
../service/8050/service../service/8050/type
