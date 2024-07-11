<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 拡張事業・成人健（検）診事業一覧
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card>
    <div ref="headRef">
      <h3 class="font-bold">成人健（検）診事業</h3>
      <div class="my-2 flex justify-between">
        <a-button
          type="primary"
          :disabled="!insertflg || !addFlg"
          @click="goDetailPage({ jigyocd: -1 })"
          >新規</a-button
        >
        <a-space>
          <a-button type="primary" :disabled="!updFlg" @click="visible1 = true"
            >メニュー並び順設定</a-button
          >
          <close-page></close-page>
        </a-space>
      </div>
    </div>
    <vxe-table
      :loading="loading"
      :height="tableHeight"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList"
      :empty-render="{ name: 'NotData' }"
      @cell-dblclick="({ row }) => goDetailPage(row)"
    >
      <vxe-column field="jigyocd" title="検診種別コード" min-width="100">
        <template #default="{ row }: { row: KensinListRowVM }">
          <a @click="goDetailPage(row)">{{ row.jigyocd }}</a>
        </template>
      </vxe-column>
      <vxe-column field="jigyonm" title="検診種別名" width="45%">
        <template #default="{ row }: { row: KensinListRowVM }">
          <a @click="goDetailPage(row)">{{ row.jigyonm }}</a>
        </template>
      </vxe-column>
      <vxe-column field="jigyokbnnm" title="基本／市区町村拡張事業" min-width="110" />
      <vxe-column field="seikenjissikbnnm" title="精密検査" min-width="100" />
      <vxe-column title="フリー項目" align="center" min-width="100">
        <template #default="{ row }">
          <a-button class="btn-round" type="primary" @click="goItemListPage(row)">設定</a-button>
        </template>
      </vxe-column>
      <vxe-column title="関連事業コード" align="center" min-width="100" :resizable="false">
        <template #default="{ row }">
          <a-button class="btn-round" type="primary" @click="openJigyoModal(row.kinoid)"
            >設定</a-button
          >
        </template>
      </vxe-column>
    </vxe-table>
    <div class="mt-1 text-end">{{ kensucnt }}</div>

    <MenuSortModal v-model:visible="visible1" />
    <JigyoModal v-model:visible="visible2" :code="currentCode" />
  </a-card>
</template>

<script setup lang="ts">
import { useTableHeight } from '@/utils/hooks'
import MenuSortModal from '@/views/affect/KK/AWKK00804D/index.vue'
import { onMounted, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { InitKensinJigyoList } from '../service'
import { KensinListRowVM } from '../type'
import JigyoModal from '@/views/affect/AF/AWAF00805D/index.vue'
import { showConfirmModal } from '@/utils/modal'
import { C011002 } from '@/constants/msg'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const tableList = ref<KensinListRowVM[]>([])
const visible1 = ref(false)
const visible2 = ref(false)
const insertflg = ref(false) //新規フラグ
const kensucnt = ref('　') //入力件数カウント
const currentCode = ref('') //事業コード

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
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 14)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitKensinJigyoList()
    tableList.value = res.kekkalist
    kensucnt.value = res.kensucnt
    insertflg.value = res.insertflg
  } catch (error) {}
  loading.value = false
}

function goDetailPage({ jigyocd }) {
  router.push({
    name: route.name as string,
    query: { ...route.query, jigyocd }
  })
}
//フリー項目設定Page
function goItemListPage({ jigyocd }) {
  router.push({
    name: route.name as string,
    query: { ...route.query, jigyocd, isItem: '1' }
  })
}

//関連事業コード設定Modal
function openJigyoModal(code) {
  currentCode.value = code
  visible2.value = true
}
async function afterSave(code) {
  await searchData()
  if (code) {
    showConfirmModal({
      content: C011002,
      onOk: () => {
        openJigyoModal(code)
      }
    })
  }
}

defineExpose({ afterSave })
</script>
