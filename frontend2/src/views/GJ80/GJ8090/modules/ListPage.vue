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
                v-model:value="searchParams.KI"
                class="w-full"
              ></a-input-number>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">契約者</th>
            <td>
              <ai-select
                v-model:value="searchParams.KEIYAKUSYA_CD"
                :options="options1"
                style="width: 100%"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>農場番号</th>
            <td>
              <a-input v-model:value="searchParams.NOJO_CD"></a-input>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>農場名</th>
            <td>
              <a-input v-model:value="searchParams.NOJO_NAME"></a-input>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="my-2 flex">
        <a-space
          ><span>検索方法</span>
          <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
            <a-radio :value="EnumAndOr.And">すべてを含む</a-radio>
            <a-radio :value="EnumAndOr.Or">いずれかを含む</a-radio>
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
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
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
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
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
import {EnumAndOr, PageSatatus} from '@/enum'
import useSearch from '@/hooks/useSearch'
import { showInfoModal } from '@/utils/modal'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { changeTableSort } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'
import { Search } from '@/views/GJ80/GJ8090/service'
import {KeiyakuNojoSearchVM} from "@/views/GJ80/GJ8090/type";

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()



const createDefaultParams = () => {
  return {
    KI: 8,
    KEIYAKUSYA_CD: undefined,
    NOJO_CD: undefined,
    NOJO_NAME: '',
    SEARCH_METHOD: EnumAndOr.And,
  }
}
const searchParams = reactive(createDefaultParams())

const tableDefault = (): KeiyakuNojoSearchVM[] => {
  return [
    {
      NOJO_CD: 10001,
      NOJO_NAME: '東京都千代田区農場',
      ADDR: '〒100-0001 東京都千代田区千代田1-1',
    },
    {
      NOJO_CD: 10002,
      NOJO_NAME: '大阪府大阪市北区農場',
      ADDR: '〒530-0001 大阪府大阪市北区梅田3丁目1-1',
    },
    {
      NOJO_CD: 10003,
      NOJO_NAME: '京都府京都市下農場',
      ADDR: '〒600-8216 京都府京都市下京区東塩小路町901',
    },
    {
      NOJO_CD: 10004,
      NOJO_NAME: '福岡県福岡市博多区農場',
      ADDR: '〒812-0011 福岡県福岡市博多区博多駅前3丁目2-1',
    },
  ]
}

const tableData = ref<KeiyakuNojoSearchVM[]>([])

//表の高さ
const headRef = ref(null)
const layout = {
  md: 12,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
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
