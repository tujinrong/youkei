<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 警告情報照会
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.25
 * 作成者　　: 
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="警告情報"
    centered
    :mask-closable="false"
    destroy-on-close
  >
    <div class="self_adaption_table">
      <a-row>
        <a-col span="6">
          <th>宛名番号</th>
          <td>{{ route.query?.atenano }}</td>
        </a-col>
      </a-row>
    </div>
    <div class="font-bold mt4">支援措置対象者情報</div>
    <vxe-table
      :loading="loading"
      height="500"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList"
      :sort-config="{ trigger: 'cell' }"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="rirekino" title="履歴番号" width="160" min-width="100" sortable>
      </vxe-column>
      <vxe-column field="siensotiymdf" title="支援措置開始年月日" min-width="170" sortable>
      </vxe-column>
      <vxe-column field="siensotiymdt" title="支援措置終了年月日" min-width="170" sortable>
      </vxe-column>
      <vxe-column field="siensotikbn" title="支援措置区分" min-width="130" sortable> </vxe-column>
      <vxe-column field="upddttm" title="更新日時" width="240" min-width="100" sortable>
      </vxe-column>
      <vxe-column field="saisinflg" title="最新" min-width="60" sortable sort-type="string">
      </vxe-column>
    </vxe-table>
    <template #footer>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import { Search } from './service'
import { SearchVM } from './type'

const route = useRoute()

const loading = ref(false)
const visible = ref(false)
const tableList = ref<SearchVM[]>([])

//初期化処理
const openModal = async () => {
  visible.value = true
  loading.value = true
  try {
    const res = await Search({ atenano: route.query.atenano as string })
    tableList.value = res.kekkalist
  } catch (error) {}
  loading.value = false
}

const closeModal = () => {
  visible.value = false
  tableList.value = []
}

defineExpose({
  open: openModal
})
</script>

<style scoped></style>
