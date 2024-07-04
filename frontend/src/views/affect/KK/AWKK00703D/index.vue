<template>
  <a-modal
    v-model:visible="props.visible"
    title="エラー一覧"
    width="900px"
    destroy-on-close
    @cancel="closeModal"
  >
    <div class="description-table">
      <table>
        <tbody>
          <tr>
            <th style="width: 10%; background-color: #ffffe1">行番号</th>
            <td style="width: 10%">{{ rowno }}</td>
            <th style="width: 10%; background-color: #ffffe1">宛名番号</th>
            <td style="width: 30%">{{ atenano }}</td>
            <th style="width: 10%; background-color: #ffffe1">氏名</th>
            <td style="width: 30%">{{ shimei }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <a-spin :spinning="loading">
      <div class="m-t-1 w-full" style="height: 500px">
        <vxe-table
          height="100%"
          :header-cell-style="{ backgroundColor: '#ffffe1' }"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="tableList"
          :sort-config="{
            trigger: 'cell',
            remote: true
          }"
          :empty-render="{ name: 'NotData' }"
        >
          <vxe-column field="itemnm" title="項目名" width="25%" :resizable="true"> </vxe-column>
          <vxe-column field="val" title="項目値" width="20%" :resizable="true"> </vxe-column>
          <vxe-column field="msg" title="エラー内容" width="55%" :resizable="true"></vxe-column>
        </vxe-table>
      </div>
    </a-spin>
    <template #footer>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//エラー一覧
//--------------------------------------------------------------------------
import { ref, watch } from 'vue'
import { InitList } from './service'
import { KimpErrRowVM } from './type'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  impexeid: number
  rowno: number
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
//ローディング
const loading = ref(false)
//ビューモデル
const tableList = ref<KimpErrRowVM[]>([])
const rowno = ref<number>()
const atenano = ref()
const shimei = ref()
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      getTableList()
    }
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------

//検索処理
const getTableList = () => {
  loading.value = true
  InitList({ impexeid: props.impexeid, rowno: props.rowno })
    .then((res) => {
      tableList.value = res.kimpErrList
      rowno.value = res.rowno
      atenano.value = res.atenano
      shimei.value = res.shimei
    })
    .finally(() => {
      loading.value = false
    })
}
//エラー一覧
const closeModal = () => {
  tableList.value = []
  rowno.value = undefined
  atenano.value = undefined
  shimei.value = undefined
  emit('update:visible', false)
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}
:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
.text-hidden {
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}
</style>
