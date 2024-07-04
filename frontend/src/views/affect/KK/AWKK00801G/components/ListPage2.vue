<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 拡張事業・成人健（検）診項目一覧
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card class="mb-2">
    <h3 class="font-bold">成人健（検）診事業</h3>
    <div class="self_adaption_table mb-4">
      <a-row>
        <a-col span="8">
          <th>検診種別コード</th>
          <TD>{{ $route.query.jigyocd }}</TD>
        </a-col>
        <a-col span="10">
          <th>検診種別名</th>
          <TD>{{ header?.jigyonm }}</TD>
        </a-col>
        <a-col span="6">
          <th>略称</th>
          <TD>{{ header?.jigyoshortnm }}</TD>
        </a-col>
      </a-row>
    </div>

    <div v-show="!itemcd">
      <div class="flex justify-between">
        <a-space>
          <a-button
            type="primary"
            :disabled="!addFlg || !buttonflg"
            @click="goDetail({ itemcd: -1 })"
            >新規</a-button
          >
          <a-button
            type="primary"
            :disabled="!addFlg || !buttonflg || !copyCode"
            @click="goDetail({ itemcd: copyCode, iscopy: true })"
            >コピー</a-button
          >
          <a-button type="primary" @click="goback">一覧へ</a-button>
        </a-space>
        <a-space>
          <a-button type="primary" :disabled="!updFlg" @click="sortVisible = true"
            >並び順設定</a-button
          >
          <a-button type="primary" :disabled="!updFlg" @click="sortVisible2 = true"
            >詳細検索設定</a-button
          >
          <close-page></close-page>
        </a-space>
      </div>

      <h4 class="font-bold mt-4">成人健（検）診項目設定</h4>
      <a-tabs v-model:activeKey="activeKey" type="card">
        <a-tab-pane key="L" tab="左項目">
          <vxe-table
            ref="xTableRef_L"
            :loading="loading"
            :height="Math.max(tableHeight, 300)"
            :column-config="{ resizable: true }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="tableData_L"
            :empty-render="{ name: 'NotData' }"
            @cell-dblclick="
              ({ row }) => row.itemkbn === Enumフリー項目区分区分.市区町村独自項目 && goDetail(row)
            "
          >
            <vxe-column field="itemcd" title="項目コード" min-width="110">
              <template #default="{ row }: { row: KensinItemListRowVM }">
                <a
                  v-if="row.itemkbn === Enumフリー項目区分区分.市区町村独自項目"
                  @click="goDetail(row)"
                  >{{ row.itemcd }}</a
                >
                <span v-else>{{ row.itemcd }}</span>
              </template>
            </vxe-column>
            <vxe-column field="itemnm" title="項目名" min-width="110">
              <template #default="{ row }: { row: KensinItemListRowVM }">
                <a
                  v-if="row.itemkbn === Enumフリー項目区分区分.市区町村独自項目"
                  @click="goDetail(row)"
                  >{{ row.itemnm }}</a
                >
                <span v-else>{{ row.itemnm }}</span>
              </template>
            </vxe-column>
            <vxe-column field="kakutyokbn" title="拡張領域使用" min-width="110" />
            <vxe-column field="pkgdokujikbnnm" title="PKG標準・独自区分" min-width="110" />
            <vxe-column field="inputtypekbnnm" title="タイプ" min-width="110" />
            <vxe-column field="riyokensahohonms" title="検査方法／内訳名" min-width="110" />
            <vxe-column field="groupnm" title="グループID" min-width="110" :resizable="false" />
          </vxe-table>
        </a-tab-pane>
        <a-tab-pane key="R" tab="右項目">
          <vxe-table
            ref="xTableRef_R"
            :loading="loading"
            :height="Math.max(tableHeight, 300)"
            :column-config="{ resizable: true }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="tableData_R"
            :empty-render="{ name: 'NotData' }"
            @cell-dblclick="({ row }) => row.pkgdokujikbn === '市区町村独自項目' && goDetail(row)"
          >
            <vxe-column field="itemcd" title="項目コード" min-width="110">
              <template #default="{ row }: { row: KensinItemListRowVM }">
                <span v-if="row.pkgdokujikbn === Enum事業区分.基本事業">{{ row.itemcd }}</span>
                <a v-else @click="goDetail(row)">{{ row.itemcd }}</a>
              </template>
            </vxe-column>
            <vxe-column field="itemnm" title="項目名" min-width="110">
              <template #default="{ row }: { row: KensinItemListRowVM }">
                <span v-if="row.pkgdokujikbn === Enum事業区分.基本事業">{{ row.itemnm }}</span>
                <a v-else @click="goDetail(row)">{{ row.itemnm }}</a>
              </template>
            </vxe-column>
            <vxe-column field="kakutyokbn" title="拡張領域使用" min-width="110" />
            <vxe-column field="pkgdokujikbnnm" title="PKG標準・独自区分" min-width="110" />
            <vxe-column field="inputtypekbnnm" title="タイプ" min-width="110" />
            <vxe-column field="riyokensahohonms" title="検査方法／内訳名" min-width="110" />
            <vxe-column field="groupnm" title="グループID" min-width="110" :resizable="false" />
          </vxe-table>
        </a-tab-pane>
      </a-tabs>
      <div class="mt-1 text-end">{{ kensucnt1 }}</div>
      <div class="text-end">{{ kensucnt2 }}</div>

      <DetailSortModal v-model:visible="sortVisible2" :jigyocd="jigyocd" />
      <ProjectSortModal v-model:visible="sortVisible" :jigyocd="jigyocd" @after-save="searchData" />
    </div>

    <DetailPage2 v-if="itemcd" :limitflgs="limitflgs" @after-save="searchData" />
  </a-card>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { useTableHeight } from '@/utils/hooks'
import DetailSortModal from '@/views/affect/KK/AWKK00802D/index.vue'
import ProjectSortModal from '@/views/affect/KK/AWKK00805D/index.vue'
import { computed, onMounted, ref, watch } from 'vue'
import { LocationQueryRaw, useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { InitKensinItemList } from '../service'
import { KensinCommonHeaderVM, KensinItemListRowVM } from '../type'
import DetailPage2 from './DetailPage2/index.vue'
import { Enum事業区分, Enumフリー項目区分区分 } from '#/Enums'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const jigyocd = route.query.jigyocd as string
const tableData_L = ref<KensinItemListRowVM[]>([])
const tableData_R = ref<KensinItemListRowVM[]>([])
const header = ref<KensinCommonHeaderVM>()
const sortVisible = ref(false)
const sortVisible2 = ref(false)
const activeKey = ref('L')
const buttonflg = ref(false) //ボタン制御フラグ(新規・コピー)
//入力件数カウント
const kensucnt1 = ref('　')
const kensucnt2 = ref('　')

const limitflgs = ref({
  halfflg1: false,
  dayflg1: false,
  fullflg1: false,
  cdflg1: false,
  halfflg2: false,
  dayflg2: false,
  fullflg2: false,
  cdflg2: false
})

const addFlg = route.meta.addflg
const updFlg = route.meta.updflg
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchData()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const { tableHeight } = useTableHeight(null, -210)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitKensinItemList({ jigyocd })
    tableData_L.value = res.kekkalist.filter((el) => el.haitiflg)
    tableData_R.value = res.kekkalist.filter((el) => !el.haitiflg)
    buttonflg.value = res.buttonflg
    header.value = res.headerinfo
    kensucnt1.value = res.kensuichijicnt
    kensucnt2.value = res.kensuseimitsucnt
    const { halfflg1, dayflg1, fullflg1, cdflg1, halfflg2, dayflg2, fullflg2, cdflg2 } = res
    limitflgs.value = { halfflg1, dayflg1, fullflg1, cdflg1, halfflg2, dayflg2, fullflg2, cdflg2 }
  } catch (error) {}
  loading.value = false
}

function goDetail({ itemcd, iscopy = false }) {
  const query = iscopy ? { ...route.query, itemcd, iscopy } : { ...route.query, itemcd }
  router.push({
    name: route.name as string,
    query: query as unknown as LocationQueryRaw
  })
}

function goback() {
  router.push({
    name: route.name as string,
    query: { type: route.query.type }
  })
}

//コピー
const xTableRef_L = ref<VxeTableInstance>()
const xTableRef_R = ref<VxeTableInstance>()
const copyCode = computed<string>(() => {
  const curRow =
    activeKey.value === 'L'
      ? xTableRef_L.value?.getCurrentRecord()
      : xTableRef_R.value?.getCurrentRecord()
  return curRow?.itemcd ?? ''
})

//詳細画面切り替え---------------------------------------------------------------------
const itemcd = ref('')
onMounted(() => {
  itemcd.value = route.query.itemcd as string
})
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00801G') {
      itemcd.value = route.query.itemcd as string
    }
  },
  { deep: true }
)
//----------------------------------------------------------------------------
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
