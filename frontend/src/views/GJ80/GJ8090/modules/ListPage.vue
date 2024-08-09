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
              <a-form-item v-bind="validateInfos.KI">
                <a-input
                  v-model:value="searchParams.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  type="number"
                  class="w-full"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">契約者</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="KEIYAKUSYA_CD_NAME_LIST"
                  style="width: 100%"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>農場番号</th>
            <td>
              <a-form-item>
                <a-input-number
                  v-model:value="searchParams.NOJO_CD"
                  :min="0"
                  :max="999"
                  :maxlength="3"
                  class="w-full"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>農場名</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams.NOJO_NAME"
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
          <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
            <a-radio :value="EnumAndOr.And">すべてを含む(AND)</a-radio>
            <a-radio :value="EnumAndOr.Or">いずれかを含む(OR)</a-radio>
          </a-radio-group></a-space
        >
      </div>
      <div class="flex">
        <a-space>
          <a-button type="primary" @click="searchData">検索</a-button>
          <a-button type="primary" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page />
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
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.NOJO_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column field="noujyocd" title="農場番号" width="200" sortable>
          <template #default="{ row }">
            <a @click="forwardEdit(row.NOJO_CD)">{{ row.NOJO_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column field="noujyomei" title="農場名" min-width="400" sortable>
          <template #default="{ row }">
            <a @click="forwardEdit(row.NOJO_CD)">{{ row.NOJO_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="ADDR"
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
import { ref, reactive, toRef, watch, onMounted } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { EnumAndOr, PageSatatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { changeTableSort, convertToFullWidth } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'
import { KeiyakuNojoSearchVM, SearchRequest } from '@/views/GJ80/GJ8090/type'
import { Init, Search } from '../service'
import { Form } from 'ant-design-vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()

const createDefaultParams = (): SearchRequest => {
  return {
    KI: undefined,
    KEIYAKUSYA_CD: undefined,
    NOJO_CD: undefined,
    NOJO_NAME: undefined,
    SEARCH_METHOD: EnumAndOr.And,
  } as SearchRequest
}
const searchParams = reactive(createDefaultParams())
const KEIYAKUSYA_CD_NAME_LIST = ref<CodeNameModel[]>([])
const tableData = ref<KeiyakuNojoSearchVM[]>([])

//表の高さ
const headRef = ref(null)
const layout = {
  md: 12,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const cardRef = ref()
const { height } = useElementSize(cardRef)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKUSYA_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約者'),
    },
  ],
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData(searchParams.KI)
})

//初期化処理
const getInitData = (KI?) => {
  Init({ KI: KI }).then((res) => {
    // TODO
    if (KI) {
      searchParams.KI = KI
    } else {
      searchParams.KI = res.KI
    }
    KEIYAKUSYA_CD_NAME_LIST.value = res.KEIYAKUSYA_CD_NAME_LIST
  })
}

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

async function forwardNew() {
  await validate()
  router.push({
    name: route.name,
    query: {
      status: PageSatatus.New,
      KI: searchParams.KI,
      KEIYAKUSYA_CD: searchParams.KEIYAKUSYA_CD,
    },
  })
}
async function forwardEdit(NOJO_CD) {
  await validate()
  router.push({
    name: route.name,
    query: {
      status: PageSatatus.Edit,
      KI: searchParams.KI,
      KEIYAKUSYA_CD: searchParams.KEIYAKUSYA_CD,
      NOJO_CD: NOJO_CD,
    },
  })
}

//クリア処理
function reset() {
  Object.assign(searchParams, createDefaultParams())
  searchParams.KI = 8
  tableData.value = []
}

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => searchParams.NOJO_NAME,
  (newVal) => {
    if (newVal) {
      searchParams.NOJO_NAME = convertToFullWidth(newVal)
    }
  }
)

watch(
  () => searchParams.KI,
  (newVal) => {
    if (newVal) {
      getInitData(newVal)
      searchParams.KEIYAKUSYA_CD = undefined
      tableData.value = []
    }
  }
)

watch(
  () => searchParams.KEIYAKUSYA_CD,
  (newVal) => {
    if (newVal && tableData.value.length > 0) {
      tableData.value = []
    }
  }
)
</script>

<style lang="scss" scoped>
:deep(th) {
  min-width: 100px;
}
h1 {
  font-size: 24px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
  width: 100%;
}
</style>
