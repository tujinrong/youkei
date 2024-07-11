<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業実施報告書（日報）管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>{{ fieldMapping.kaijocd }}</th>
            <td>
              <ai-select v-model:value="searchParams.kaijocd" :options="selectorlist1"></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="searchData">検索</a-button>
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
          class="text-end mb-2"
        />
        <vxe-table
          :height="tableHeight"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="dataSource"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => forwardEdit(row)"
        >
          <vxe-column field="kaijocd" title="会場コード">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.kaijocd }}</a>
            </template>
          </vxe-column>
          <vxe-column field="kaijonm" title="会場名">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.kaijonm }}</a>
            </template>
          </vxe-column>
          <vxe-column field="kanakaijonm" title="会場名（カナ）"></vxe-column>
          <vxe-column field="kaijorenrakusaki" title="会場連絡先"></vxe-column>
          <vxe-column field="adrskatagaki" title="住所方書" width="30%"></vxe-column>
          <vxe-column field="stopflg" title="利用状態" width="10%"></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { RowVM } from '../type'
import { PageSatatus } from '#/Enums'
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
  kaijocd: '会場コード'
}

const createDefaultParams = () => ({ kaijocd: '' })
const searchParams = reactive(createDefaultParams())
const selectorlist1 = ref<DaSelectorModel[]>([])
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
onMounted(() => init())

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    reset()
    init()
    searchData()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function init() {
  InitList().then((res) => {
    selectorlist1.value = res.selectorlist1
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
      kaijocd: val.kaijocd
    }
  })
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
          rptid: '0007',
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
  width: 120px;
}
</style>
