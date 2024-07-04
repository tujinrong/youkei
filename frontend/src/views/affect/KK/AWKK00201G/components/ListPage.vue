<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業実施報告書（日報）管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.6
 * 作成者　　: CNC張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>{{ fieldMapping.kikancd }}</th>
            <td>
              <ai-select v-model:value="searchParams.kikancd" :options="selectorlist1"></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>{{ fieldMapping.hokenkikancd }}</th>
            <td>
              <ai-select
                v-model:value="searchParams.hokenkikancd"
                :options="selectorlist2"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>{{ fieldMapping.kikannm }}</th>
            <td>
              <a-input v-model:value="searchParams.kikannm"></a-input>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>{{ fieldMapping.kanakikannm }}</th>
            <td>
              <a-input
                v-model:value="searchParams.kanakikannm"
                @change="
                  searchParams.kanakikannm = replaceText(searchParams.kanakikannm, EnumRegex.カナ)
                "
              ></a-input>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>{{ fieldMapping.adrs }}</th>
            <td>
              <a-input v-model:value="searchParams.adrs"></a-input>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="getTableList">検索</a-button>
          <a-button type="primary" :disabled="!exceloutflg" @click="handleExcel">
            EXCEL出力
          </a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <div>
        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="text-end"
        />
        <div class="mt-2">
          <vxe-table
            :height="tableHeight"
            :header-cell-style="{ backgroundColor: '#ffffe1' }"
            :column-config="{ resizable: true }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="dataSource"
            :empty-render="{ name: 'NotData' }"
            @cell-dblclick="({ row }) => forwardEdit(row)"
          >
            <vxe-column field="kikancd" title="医療機関コード">
              <template #default="{ row }">
                <a @click="forwardEdit(row)">{{ row.kikancd }}</a>
              </template>
            </vxe-column>
            <vxe-column field="hokenkikancd" title="保険医療機関コード">
              <template #default="{ row }">
                <a @click="forwardEdit(row)">{{ row.hokenkikancd }}</a>
              </template>
            </vxe-column>
            <vxe-column field="kikannm" title="医療機関名"></vxe-column>
            <vxe-column field="kanakikannm" title="医療機関名(カナ)"></vxe-column>
            <vxe-column field="tel" title="電話番号"></vxe-column>
            <vxe-column field="yubin" title="郵便番号"></vxe-column>
            <vxe-column field="adrs" title="住所"></vxe-column>
            <vxe-column field="stopflg" title="利用状態" width="30%"></vxe-column>
          </vxe-table>
        </div>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, reactive, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { RowVM } from '../type'
import { PageSatatus, EnumRegex } from '#/Enums'
import { InitList, SearchList } from '../service'
import { C003003 } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { useSearch, useTableHeight } from '@/utils/hooks'
import { getSearchQuery, replaceText } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const fieldMapping = {
  kikancd: '医療機関コード',
  hokenkikancd: '保険医療機関コード',
  kikannm: '医療機関名',
  kanakikannm: '医療機関名カナ',
  adrs: '住所'
}

const createDefaultParams = () => {
  return {
    kikancd: '',
    hokenkikancd: '',
    kikannm: '',
    kanakikannm: '',
    adrs: ''
  }
}

const searchParams = reactive(createDefaultParams())
const selectorlist1 = ref<DaSelectorModel[]>([])
const selectorlist2 = ref<DaSelectorModel[]>([])
const dataSource = ref<RowVM[]>([])

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: dataSource,
  params: toRef(() => searchParams)
})

//権限フラグ
const exceloutflg = ref(false)
const addFlg = route.meta.addflg

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  init()
})
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    reset()
    init()
    getTableList()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function init() {
  selectorlist1.value = []
  selectorlist2.value = []
  InitList().then((res) => {
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
    exceloutflg.value = res.exceloutflg
  })
}

function forwardNew() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.New
    }
  })
}
function forwardEdit(val: RowVM) {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      kikancd: val.kikancd
    }
  })
}

//検索処理
async function getTableList() {
  const res = await searchData()
  //検索結果1件の場合、詳細画面へ遷移
  if (res.totalrowcount === 1 && res.totalpagecount === 1) {
    forwardEdit(res.kekkalist[0])
  }
}

function reset() {
  Object.assign(searchParams, createDefaultParams())
  clear()
}

function handleExcel() {
  showConfirmModal({
    content: C003003.Msg.replace('{0}', '帳票出力'),
    onOk: async () => {
      await router.push({ name: 'AWEU00301G' })
      router.push({
        name: 'AWEU00301G',
        query: {
          rptid: '0006',
          outerSearch: 'true',
          ...getSearchQuery(searchParams, fieldMapping)
        }
      })
    }
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 150px;
}
</style>
