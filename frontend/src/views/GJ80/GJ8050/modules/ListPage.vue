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
          <a-button type="primary" @click="searchAll">検索</a-button>
          <a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button class="ml-20" type="primary" @click="forwardNew"
            >新規登録</a-button
          >
          <a-button type="primary">プレビュー</a-button>
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
        :height="height - 356"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.BANK_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
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
          field="BANK_KANA"
          title="金融機関名（ｶﾅ）"
          min-width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.BANK_CD)">{{ row.BANK_KANA }}</a>
          </template>
        </vxe-column>
        <vxe-column
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
          <a-button type="primary" @click="searchAll2">検索</a-button>
          <a-button type="primary" @click="reset2">条件クリア</a-button>
          <a-button class="ml-20" type="primary" @click="forwardNew2"
            >新規登録</a-button
          >
          <a-button type="primary">プレビュー</a-button>
        </a-space>
      </div>
      <div v-if="!isSelectBank" class="search-disabled-mask bg-disabled"></div
    ></a-card>
    <a-card class="flex-1">
      <a-pagination
        v-model:current="pageParams2.PAGE_NUM"
        v-model:page-size="pageParams2.PAGE_SIZE"
        :total="totalCount"
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
        :data="tableData2"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit2(row.BANK_CD, row.SITEN_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams2, 'ORDER_BY'))"
      >
        <vxe-column
          field="BANK_CD"
          title="金融機関"
          min-width="100"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit2(row.BANK_CD, row.SITEN_CD)">{{
              row.SITEN_CD
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
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
          field="SITEN_KANA"
          title="支店名（ｶﾅ）"
          min-width="400"
          sortable
          :params="{ order: 3 }"
          :resizable="false"
        >
          <template #default="{ row }">
            <a @click="forwardEdit2(row.BANK_CD, row.SITEN_CD)">{{
              row.SITEN_KANA
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
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
import { ref, reactive, toRef, watch, onMounted, computed, nextTick } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { changeTableSort } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'
import { VxeTableInstance } from 'vxe-pc-ui'
import { Row } from 'ant-design-vue'
import { rowProps } from 'ant-design-vue/es/grid/Row'
import { SearchBankRowVM } from '../type'

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
    BANK_CD: undefined,
    BANK_KANA: undefined,
    BANK_NAME: undefined,
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}
const searchParams = reactive(createDefaultParams())

const keyList = reactive({
  BANK_CD: undefined,
})
// const KEIYAKUSYA_CD_NAME_LIST = ref<CodeNameModel[]>([])

// const tableData = []

const tableData = ref<SearchBankRowVM[]>([])

const createDefaultParams2 = () => {
  return {
    BANK_CD: undefined,
    SITEN_CD: undefined,
    SITEN_KANA: undefined,
    SITEN_NAME: undefined,
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}

const searchParams2 = reactive(createDefaultParams2())

const tableData2 = [
  {
    BANK_CD: '0001',
    SITEN_CD: '001',

    SITEN_KANA: 'トウキョウ',
    SITEN_NAME: '東京営業部',
  },
  {
    BANK_CD: '0001',
    SITEN_CD: '004',
    SITEN_KANA: 'マルノウチチュウオウ',
    SITEN_NAME: '丸の内中央',
  },
  {
    BANK_CD: '0001',
    SITEN_CD: '005',

    SITEN_KANA: 'マルノウチ',
    SITEN_NAME: '丸の内',
  },
  {
    BANK_CD: '0001',
    SITEN_CD: '009',

    SITEN_KANA: 'カンダエキマエ',
    SITEN_NAME: '神田駅前',
  },
  {
    BANK_CD: '0001',
    SITEN_CD: '013',

    SITEN_KANA: 'チョウソンカイカン',
    SITEN_NAME: '町村会館',
  },
  {
    BANK_CD: '0001',
    SITEN_CD: '015',

    SITEN_KANA: 'ツキヂ',
    SITEN_NAME: '築地',
  },
]

//表の高さ
const headRef = ref(null)
const layout = {
  md: 24,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const cardRef = ref()
const { height } = useElementSize(cardRef)
const currentRow = ref<SearchBankRowVM | null>(null)
const isSelectBank = computed(() => currentRow.value !== null)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
// onMounted(() => {
//   getInitData(searchParams.KI, true)
// })
watch(
  () => xTableRef.value?.getCurrentRecord(),
  (val) => {
    currentRow.value = val
  }
)

//初期化処理

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.PAGE_NUM = 1
    pageParams2.PAGE_NUM = 1
    searchAll()
    searchAll2()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
  // validate,
})

const exampleData = [
  {
    BANK_CD: '0001',
    BANK_KANA: 'ミジホ',
    BANK_NAME: 'みずほ',
  },
  {
    BANK_CD: '0005',
    BANK_KANA: 'ミツビシUFJ',
    BANK_NAME: '三菱UFJ',
  },
  {
    BANK_CD: '0009',
    BANK_KANA: 'ミツイスミトモ',
    BANK_NAME: '三井住友',
  },
  {
    BANK_CD: '0010',
    BANK_KANA: 'リンナ',
    BANK_NAME: 'りんな',
  },
  {
    BANK_CD: '0017',
    BANK_KANA: 'サイタマリンナ',
    BANK_NAME: '埼玉りんな',
  },
  {
    BANK_CD: '0033',
    BANK_KANA: 'ペイペイ',
    BANK_NAME: 'PayPay',
  },
]

const searchAll = async () => {
  tableData.value = exampleData

  // const res = await searchData()
  // keyList.KI = res.KI
  // keyList.KEIYAKUSYA_CD = res.KEIYAKUSYA_CD
  // keyList.KEIYAKUSYA_NAME =
  //   KEIYAKUSYA_CD_NAME_LIST.value.find((el) => el.CODE === res.KEIYAKUSYA_CD)
  //     ?.NAME || ''
}

// クリア
async function reset() {
  searchParams.BANK_CD = undefined
  searchParams.BANK_KANA = undefined
  searchParams.BANK_NAME = undefined
  searchParams.SEARCH_METHOD = EnumAndOr.AndCode
  xTableRef.value?.clearSort()
  tableData.value = []

  clear()
}

async function forwardNew() {
  // await validate()
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
      editPage: 1,
    },
  })
}

async function forwardEdit(BANK_CD) {
  // await validate()
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
      editPage: 1,
      BANK_CD: BANK_CD,
    },
  })
}

//検索処理2
const {
  pageParams: pageParams2,
  totalCount: totalCount2,
  searchData: searchData2,
  clear: clear2,
} = useSearch({
  service: undefined,
  source: tableData2,
  params: toRef(() => searchParams2),
  // validate,
})

const searchAll2 = async () => {
  const res = await searchData2()

  // keyList.KI = res.KI
  // keyList.KEIYAKUSYA_CD = res.KEIYAKUSYA_CD
  // keyList.KEIYAKUSYA_NAME =
  //   KEIYAKUSYA_CD_NAME_LIST.value.find((el) => el.CODE === res.KEIYAKUSYA_CD)
  //     ?.NAME || ''
}

// クリア2
async function reset2() {
  searchParams2.BANK_CD = undefined
  searchParams2.SITEN_CD = undefined
  searchParams2.SITEN_KANA = undefined
  searchParams2.SITEN_NAME = undefined
  searchParams2.SEARCH_METHOD = EnumAndOr.AndCode
  xTableRef2.value?.clearSort()
  clear2()
}

async function forwardNew2() {
  keyList.BANK_CD = '001'
  // await validate()
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
      editPage: 2,
      BANK_CD: keyList.BANK_CD,
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
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
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
