<template>
  <a-spin :spinning="loading">
    <a-tabs v-model:activeKey="curTabActiveKey" class="my-tab-style">
      <a-tab-pane key="A" :closable="false">
        <DataList v-bind="param"></DataList>
        <template #tab>
          <span :style="{ opacity: tabValue === '1' ? 0.5 : '' }">取込設定一覧</span>
        </template>
      </a-tab-pane>
      <a-tab-pane key="B" :closable="false">
        <UnprocessedDataList v-bind="param"></UnprocessedDataList>
        <template #tab>
          <span :style="{ opacity: tabValue === '2' ? 0.5 : '' }">未処理一覧</span>
        </template>
      </a-tab-pane>
      <a-tab-pane key="C" :closable="false">
        <History v-bind="param"></History>
        <template #tab>
          <span :style="{ opacity: tabValue === '2' ? 0.5 : '' }">取込履歴</span>
        </template>
      </a-tab-pane>
    </a-tabs>
  </a-spin>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//一覧へ
//--------------------------------------------------------------------------
import { ref, onMounted, computed, reactive } from 'vue'
import DataList from './DataList.vue'
import History from './History.vue'
import UnprocessedDataList from './UnprocessedDataList.vue'
import { InitKimpList } from '../service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  tabActiveKey: string
}
const props = withDefaults(defineProps<Props>(), {
  tabActiveKey: 'A'
})
const emit = defineEmits(['update:tabActiveKey'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
//ローディング
const loading = ref(false)
const tabValue = ref()
const param = reactive({
  gyoumukbn: '',
  impkbn: ''
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curTabActiveKey = computed({
  get() {
    return props.tabActiveKey
  },
  set(val) {
    emit('update:tabActiveKey', val)
  }
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
})
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------

//初期化処理
const getInitData = async () => {
  loading.value = true
  const res = await InitKimpList()
  param.gyoumukbn = res.gyoumukbn
  param.impkbn = res.impkbn
  loading.value = false
}
</script>
<style scoped lang="less">
:deep(.ant-tabs-nav) {
  background-color: #fff;
  padding: 0 10px;
}
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

#app {
  .ant-tabs-top > :deep(.ant-tabs-nav) {
    margin: 0px;
  }
}
</style>
