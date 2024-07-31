<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
      <h1>互助基金契約者マスタ一覧</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col v-bind="layout">
            <th class="required">期</th>
            <td>
              <a-input-number
                v-model:value="searchParams.KI"
                :min="1"
                :max="99"
                :maxlength="2"
                class="w-full"
              ></a-input-number>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>都道府県</th>
            <td>
              <ai-select
                v-model:value="searchParams.KEN_CD1"
                :options="KEN_CD_NAME_LIST"
                class="w-full"
                type="number"
              ></ai-select
              >～<ai-select
                v-model:value="searchParams.KEN_CD2"
                :options="KEN_CD_NAME_LIST"
                class="w-full"
                type="number"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者番号</th>
            <td>
              <a-input-number
                v-model:value="searchParams.KEIYAKUSYA_CD"
                :min="0"
                class="w-full"
              ></a-input-number>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約区分</th>
            <td>
              <ai-select
                v-model:value="searchParams.KEIYAKU_KBN"
                :options="KEIYAKU_KBN_CD_NAME_LIST"
                class="w-full"
                type="number"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約状況</th>
            <td>
              <ai-select
                v-model:value="searchParams.KEIYAKU_JYOKYO"
                :options="KEIYAKU_KBN_CD_NAME_LIST"
                class="w-full"
                type="number"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者名</th>
            <td>
              <a-input
                v-model:value="searchParams.KEIYAKUSYA_NAME"
                class="w-full"
              ></a-input>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者名(フリガナ)</th>
            <td>
              <a-input
                v-model:value="searchParams.KEIYAKUSYA_KANA"
                class="w-full"
              ></a-input>
            </td> </a-col
        ></a-row>
        <a-row
          ><a-col v-bind="layout">
            <th>住所</th>
            <td>
              <a-input
                v-model:value="searchParams.ADDR"
                class="w-full"
              ></a-input>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>電話番号</th>
            <td>
              <a-input
                v-model:value="searchParams.ADDR_TEL"
                class="w-full"
              ></a-input>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>事務委託先</th>
            <td>
              <ai-select
                v-model:value="searchParams.JIMUITAKU_CD1"
                :options="KEN_CD_NAME_LIST"
                class="w-full"
                type="number"
              ></ai-select
              >～<ai-select
                v-model:value="searchParams.JIMUITAKU_CD2"
                :options="KEN_CD_NAME_LIST"
                class="w-full"
                type="number"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="my-2 flex">
        <a-space
          ><span>検索方法</span>
          <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
            <a-radio :value="EnumAndOr.And">すべてを含む(AND)</a-radio>
            <a-radio :value="EnumAndOr.Or">いずれかを含む(OR)</a-radio>
          </a-radio-group></a-space
        >
      </div>
      <div class="flex">
        <a-space>
          <a-button type="primary" @click="search">検索</a-button>
          <a-button type="primary" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="clear">クリア</a-button>
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
        :height="height - 70"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      >
        <vxe-column
          field="KEIYAKUSYA_CD"
          title="契約者番号"
          width="100"
          sortable
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row)">{{ row.KEIYAKUSYA_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="KEIYAKUSYA_NAME"
          title="契約者名"
          width="200"
          sortable
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row)">{{ row.KEIYAKUSYA_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="KEIYAKUSYA_KANA"
          title="フリガナ"
          min-width="200"
          sortable
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row)">{{ row.KEIYAKUSYA_KANA }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="KEIYAKU_KBN"
          title="契約区分"
          min-width="120"
          sortable
        ></vxe-column>
        <vxe-column
          field="KEIYAKU_JYOKYO"
          title="契約状況"
          min-width="120"
          sortable
        ></vxe-column>
        <vxe-column
          field="ADDR_TEL"
          title="電話番号"
          min-width="200"
          sortable
        ></vxe-column>
        <vxe-column
          field="KEN_CD1"
          title="都道府県"
          min-width="150"
          sortable
        ></vxe-column>
        <vxe-column
          field="JIMUITAKU_CD1"
          title="事務委託先"
          min-width="200"
          sortable
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { EnumAndOr, PageSatatus } from '@/enum'
import { reactive, ref, toRef } from 'vue'
import { KEN_CD_NAME_LIST } from '@/views/GJ80/GJ8090/constant'
import { showInfoModal } from '@/utils/modal'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import useSearch from '@/hooks/useSearch'
import { useElementSize } from '@vueuse/core'
import { changeTableSort } from '@/utils/util'
import { useRoute, useRouter } from 'vue-router'
import { useTabStore } from '@/store/modules/tab'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: 8,
    KEN_CD1: '',
    KEN_CD2: '',
    KEIYAKUSYA_CD: '',
    KEIYAKU_KBN: '',
    KEIYAKU_JYOKYO: '',
    KEIYAKUSYA_NAME: '',
    KEIYAKUSYA_KANA: '',
    ADDR: '',
    ADDR_TEL: '',
    JIMUITAKU_CD1: '',
    JIMUITAKU_CD2: '',
    SEARCH_METHOD: EnumAndOr.And,
  }
}
const searchParams = reactive(createDefaultParams())
const layout = {
  md: 12,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()
const cardRef = ref()
const { height } = useElementSize(cardRef)
const KEIYAKU_KBN_CD_NAME_LIST = ref<DaSelectorModel[]>([
  { value: 1, label: '家族' },
  { value: 2, label: '企業' },
  { value: 3, label: '鶏以外' },
])
const tableData = ref<any>([])
const tableDefault = {
  KEIYAKUSYA_CD: '1003',
  KEIYAKUSYA_NAME: '亜伊伊伊伊伊伊伊亜伊',
  KEIYAKUSYA_KANA: 'ｲｲｱｱｱｲｱｲｱｲｱｱｱｲｱｱｲｱｱｱｲｱｱｱ',
  KEIYAKU_KBN: '企業',
  KEIYAKU_JYOKYO: '継続',
  ADDR_TEL: '1111-21-1121',
  KEN_CD1: '1北海道',
  JIMUITAKU_CD1: '（宇）宇亜宇伊亜宇伊',
}
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//検索処理
function search() {
  if (!searchParams.KI) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期'),
    })
    return
  }
  tableData.value.push(tableDefault)
}

function forwardEdit(row) {
  if (!searchParams.KI) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期'),
    })
    return
  } else {
    router.push({
      name: route.name as string,
      query: {
        status: PageSatatus.Edit,
      },
    })
  }
}
function forwardNew() {
  if (!searchParams.KI) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期'),
    })
    return
  } else {
    router.push({
      name: route.name as string,
      query: {
        status: PageSatatus.New,
      },
    })
  }
}
</script>
<style lang="scss" scoped>
:deep(th) {
  min-width: 100px;
}
h1 {
  font-size: 24px;
}
</style>
