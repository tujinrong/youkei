<template>
  <a-modal
    v-model:visible="props.visible"
    title="登録済プロシージャ一覧"
    width="700px"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <a-card :bordered="false">
        <a-table
          class="m-t-1 ant-table-striped"
          row-key="rptid"
          :data-source="tableList"
          :columns="columns"
          :pagination="false"
          bordered
          :custom-row="customRow"
          row-class-name="ant-table-row-no-hover"
          :show-sorter-tooltip="false"
          :scroll="{ y: 600 }"
          :loading="loading"
        >
        </a-table>
      </a-card>
    </a-spin>
    <template #footer>
      <a-button
        type="primary"
        :loading="loading"
        style="float: left"
        :disabled="!rowSelected"
        @click="selected"
      >
        選択
      </a-button>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//ストアドプロシージャ
//--------------------------------------------------------------------------
import { ref, watch } from 'vue'
import { TableColumnsType } from 'ant-design-vue'
import { InitDetail } from './service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  prockbn: string
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'getData'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const loading = ref(false)
const rowSelected = ref(false)

const columns = ref<TableColumnsType>([
  {
    title: 'プロシージャ名',
    dataIndex: 'label',
    width: 100,
    resizable: true
  }
])
const tableList = ref()
const rowValue = ref()
const customKey = ref('')
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (val) => {
    if (val) getInitData()
  }
)
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  loading.value = true
  let prockbn = props.prockbn.includes(':') ? props.prockbn.split(':')[0].trim() : props.prockbn
  InitDetail({ prockbn: prockbn })
    .then((res) => {
      tableList.value = res.procList
    })
    .finally(() => {
      loading.value = false
    })
}

const customRow = (record, index) => {
  return {
    class:
      record.value === customKey.value ? 'ant-table-row-no-hover-active' : 'ant-table-row-no-hover',
    onClick: (event) => {
      customKey.value = record.value
      rowValue.value = record
      rowSelected.value = true
    },
    onDblclick: (event) => {
      selected()
    }
  }
}

//modal閉じる
const closeModal = () => {
  tableList.value = []
  rowValue.value = null
  customKey.value = ''
  emit('update:visible', false)
  rowSelected.value = false
}
//選択処理
const selected = () => {
  emit('getData', rowValue.value)
  closeModal()
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
z
