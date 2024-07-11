<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 拡張事業・成人検診予約日程事業一覧
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.16
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card class="mb-2">
      <div ref="headRef">
        <h3 class="font-bold">成人健（検）診予約日程事業</h3>
        <div class="self_adaption_table form w-56">
          <a-row>
            <a-col span="24">
              <th class="w-25">年度</th>
              <td>
                <YearJp v-model:value="nendo" />
              </td>
            </a-col>
          </a-row>
        </div>

        <div class="mt-2 flex justify-between">
          <a-space>
            <a-button type="primary" @click="searchData">検索</a-button>
            <a-button type="primary" :disabled="!addFlg" @click="goDetailPage({ jigyocd: -1 })"
              >新規</a-button
            >
            <a-button type="primary" @click="reset">クリア</a-button>
          </a-space>
          <a-space>
            <a-button type="primary" :disabled="!canExtend" @click="extendLastYear"
              >前年度引継ぎ</a-button
            >
            <close-page></close-page>
          </a-space>
        </div>
      </div>
    </a-card>
    <a-card>
      <vxe-table
        :height="tableHeight"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goDetailPage(row)"
      >
        <vxe-column field="jigyocd" title="コード" min-width="110" width="140">
          <template #default="{ row }">
            <a @click="goDetailPage(row)">{{ row.jigyocd }}</a>
          </template>
        </vxe-column>
        <vxe-column field="jigyonm" title="成人健（検）診予約日程事業名" min-width="110">
          <template #default="{ row }">
            <a @click="goDetailPage(row)">{{ row.jigyonm }}</a>
          </template>
        </vxe-column>
        <vxe-column field="ryokinpatternnm" title="料金パターン" min-width="120" width="160" />
        <vxe-column
          field="jigyonaiyo"
          title="検診種別・検査方法名／健診内訳名"
          min-width="200"
          :resizable="false"
        />
      </vxe-table>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
import { useTableHeight } from '@/utils/hooks'
import { computed, ref, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { SaveKensinYoyakuJigyoList, SearchKensinYoyakuJigyoList } from '../service'
import { KensinYoyakuListRowVM } from '../type'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { ss } from '@/utils/storage'
import { GLOBAL_YEAR, MAX_YEAR } from '@/constants/mutation-types'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const tableList = ref<KensinYoyakuListRowVM[]>([])
let _nendo = ss.get(GLOBAL_YEAR)
const nendo = ref(_nendo)
const isSearched = ref(false)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => searchData())
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 20)

const addFlg = route.meta.addflg
const canExtend = computed(() => {
  return (
    tableList.value.length === 0 && ss.get(MAX_YEAR) === nendo.value && addFlg && isSearched.value
  )
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await SearchKensinYoyakuJigyoList({ nendo: nendo.value })
    tableList.value = res.kekkalist
    isSearched.value = true
  } catch (error) {}
  loading.value = false
}

//再検索
function reset() {
  nendo.value = _nendo
  tableList.value = []
  isSearched.value = false
}

//前年度引継ぎ
async function extendLastYear() {
  loading.value = true
  try {
    await SaveKensinYoyakuJigyoList({ nendo: nendo.value })
    searchData()
  } catch (error) {}
  loading.value = false
}

function goDetailPage({ jigyocd }) {
  router.push({
    name: route.name as string,
    query: { ...route.query, jigyocd, nendo: nendo.value }
  })
}

defineExpose({ searchData })
</script>
