<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto flex"
  >
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
                <a-input v-model:value="searchParams.BANK_NAME"></a-input>
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
          <a-button class="ml-20" type="primary" @click="forwardNew"
            >新規登録</a-button
          >
          <a-button type="primary" @click="preview1">プレビュー</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card :bordered="false" ref="cardRef">
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
        :height="height - 65"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="bankTableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.BANK_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="BANK_CD"
          title="金融機関"
          min-width="100"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.BANK_CD)">{{ row.BANK_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="BANK_KANA"
          title="金融機関名（ｶﾅ）"
          min-width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="BANK_NAME"
          title="金融機関名（漢字）"
          min-width="400"
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
    <a-card class="flex-1">
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
        :height="height - 500"
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
          min-width="100"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="SITEN_CD"
          title="支店コード"
          min-width="160"
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
          min-width="400"
          sortable
          :params="{ order: 4 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>
      <div v-if="!isSelectBank" class="search-disabled-mask bg-disabled"></div>
    </a-card>
  </div>
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

const sitanTableData = ref<SearchSitenRowVM[]>([])
//表の高さ
const headRef = ref(null)
const previewName = ref('')
const layout = {
  md: 24,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const cardRef = ref()
const { height } = useElementSize(cardRef)
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

//初期化処理

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh == 'delete1') {
    searchAll(true)
  }
  if (to.query.refresh == 'delete2') {
    searchAll2(true)
  }
  if (to.query.refresh == '1') {
    searchAll()
    searchAll2()
  }
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
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

watch(
  () => xTableRef.value?.getCurrentRecord(),
  (val) => {
    currentRow.value = val
    if (sitanTableData.value.length <= 0)
      searchParams2.BANK_CD = currentRow.value?.BANK_CD ?? ''
  }
)

watch(
  () => xTableRef2.value?.getCurrentRecord(),
  (val) => {
    currentRow2.value = val
    searchParams2.BANK_CD = currentRow2.value?.BANK_CD ?? ''
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchBank,
  source: bankTableData,
  params: toRef(() => searchParams),
  // validate,
})
//検索処理2
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
// クリア
async function reset() {
  Object.assign(searchParams, createDefaultParams())
  xTableRef.value?.clearSort()
  bankTableData.value = []
  clear()
}
// クリア2
async function reset2() {
  Object.assign(searchParams2, createDefaultParams2())
  xTableRef2.value?.clearSort()
  clear2()
}

//銀行
async function forwardNew() {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
      editPage: 1,
    },
  })
}
async function forwardEdit(BANK_CD) {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
      editPage: 1,
      BANK_CD: BANK_CD,
    },
  })
}
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

//支店
async function forwardNew2() {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
      editPage: 2,
      BANK_CD:
        sitanTableData.value.length > 0
          ? currentRow2.value?.BANK_CD
          : currentRow.value?.BANK_CD,
    },
  })
}

async function forwardEdit2(BANK_CD, SITEN_CD) {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
      editPage: 2,
      BANK_CD: BANK_CD,
      SITEN_CD: SITEN_CD,
    },
  })
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
