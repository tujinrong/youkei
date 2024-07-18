<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
      <h1>契約者農場一覧</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col v-bind="layout">
            <th class="required">期</th>
            <td>
              <a-input-number
                v-model:value="searchParams.ki"
                class="w-full"
              ></a-input-number>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">契約者</th>
            <td>
              <a-select
                v-model:value="searchParams.keiyakusya"
                :options="options1"
                style="width: 100%"
              ></a-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>農場番号</th>
            <td>
              <a-input v-model:value="searchParams.noujyobango"></a-input>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>農場名</th>
            <td>
              <a-input v-model:value="searchParams.noujyomei"></a-input>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="my-2 flex">
        <a-space
          ><span>検索方法</span>
          <a-radio-group v-model:value="jyoken">
            <a-radio :value="false">すべてを含む</a-radio>
            <a-radio :value="true">いずれかを含む</a-radio>
          </a-radio-group></a-space
        >
      </div>
      <div class="flex">
        <a-space>
          <a-button type="primary" @click="search">検索</a-button>
          <a-button type="primary" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <AButton type="primary" class="ml-a" @click="tabStore.removeActiveTab">
          閉じる
        </AButton>
      </div>
    </a-card>
    <a-card :bordered="false" class="sm:flex-1-hidden" ref="cardRef">
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        class="mt-2"
        :column-config="{ resizable: true }"
        :height="height - 64"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="forwardEdit()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      >
        <vxe-column field="noujyocd" title="農場番号" width="200" sortable>
          <template #default="{ row }">
            <a @click="forwardEdit()">{{ row.noujyocd }}</a>
          </template>
        </vxe-column>
        <vxe-column field="noujyomei" title="農場名" min-width="400" sortable>
          <template #default="{ row }">
            <a @click="forwardEdit()">{{ row.noujyomei }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="jyusyo"
          title="農場住所"
          min-width="700"
          sortable
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>

<script lang="ts" setup>
import { ref, reactive, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { PageSatatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { showInfoModal } from '@/utils/modal'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { changeTableSort } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()

const jyoken = ref<boolean>(false)

const createDefaultParams = () => {
  return {
    ki: '',
    keiyakusya: '',
    noujyobango: '',
    noujyomei: '',
  }
}
const searchParams = reactive(createDefaultParams())

const tableDefault = (): RowData[] => {
  return [
    {
      noujyocd: 10001,
      noujyomei: '東京都千代田区農場',
      jyusyo: '〒100-0001 東京都千代田区千代田1-1',
    },
    {
      noujyocd: 10002,
      noujyomei: '大阪府大阪市北区農場',
      jyusyo: '〒530-0001 大阪府大阪市北区梅田3丁目1-1',
    },
    {
      noujyocd: 10003,
      noujyomei: '京都府京都市下農場',
      jyusyo: '〒600-8216 京都府京都市下京区東塩小路町901',
    },
    {
      noujyocd: 10004,
      noujyomei: '福岡県福岡市博多区農場',
      jyusyo: '〒812-0011 福岡県福岡市博多区博多駅前3丁目2-1',
    },
  ]
}
type RowData = {
  noujyocd: number
  noujyomei: string
  jyusyo: string
}
const tableData = ref<RowData[]>([])

//表の高さ
const headRef = ref(null)
const layout = {
  md: 12,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
})
const options1 = ref<DaSelectorModel[]>([
  { value: '1', label: '永玉田中' },
  { value: '2', label: '尾三玉田' },
  { value: '3', label: '史玉浅海' },
])

const cardRef = ref()
const { height } = useElementSize(cardRef)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function forwardNew() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.New,
    },
  })
}
function forwardEdit() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
    },
  })
}

//検索処理
function search() {
  if (Object.values(searchParams).every((value) => !value)) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須検索条件'),
    })
    return
  }
  tableData.value = tableDefault()
}

//クリア処理
function reset() {
  Object.assign(searchParams, createDefaultParams())
  tableData.value = []
}
</script>

<style lang="scss" scoped>
th {
  min-width: 100px;
}
h1 {
  font-size: 24px;
}
</style>
