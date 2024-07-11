<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 各種事業コード設定（共通バー）
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card>
    <close-page class="float-right"></close-page>

    <vxe-table
      class="mt-10"
      :loading="loading"
      :height="tableHeight"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
      :cell-class-name="cellClassName"
      @cell-dblclick="({ row }) => showModal(row.cd)"
    >
      <vxe-column title="画面" min-width="100">
        <template #default="{ row }: { row: RowVM }">
          <a @click="showModal(row.cd)">{{ row.nm }}</a>
        </template>
      </vxe-column>
      <vxe-colgroup title="共通バー" align="center">
        <vxe-column field="cdnm1" title="個人連絡先" min-width="100" />
        <vxe-column field="cdnm2" title="メモ情報" min-width="100" />
        <vxe-column field="cdnm3" title="電子ファイル情報" min-width="100" />
        <vxe-column field="cdnm4" title="フォロー管理" min-width="100" :resizable="false" />
      </vxe-colgroup>
    </vxe-table>

    <DetailModal v-model:visible="visible" :code="currentCode" @after-save="searchData" />
  </a-card>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useTableHeight } from '@/utils/hooks'
import { Search } from './service'
import { RowVM } from './type'
import { VxeTablePropTypes } from 'vxe-table'
import DetailModal from '../AWAF00805D/index.vue'
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref(false)
const visible = ref(false)
const tableData = ref<RowVM[]>([])
const currentCode = ref('')
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { tableHeight } = useTableHeight(null, 8)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => searchData())
//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await Search()
    tableData.value = res.kekkalist
  } catch (error) {}
  loading.value = false
}

const cellClassName: VxeTablePropTypes.CellClassName<RowVM> = ({ row, column }) => {
  if (
    (column.field === 'cdnm1' && row.flg1) ||
    (column.field === 'cdnm2' && row.flg2) ||
    (column.field === 'cdnm3' && row.flg3) ||
    (column.field === 'cdnm4' && row.flg4)
  ) {
    return 'bg-disabled'
  }
  return null
}

function showModal(code: string) {
  currentCode.value = code
  visible.value = true
}
</script>
