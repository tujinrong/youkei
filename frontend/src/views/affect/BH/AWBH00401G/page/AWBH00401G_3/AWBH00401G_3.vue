<template>
  <div class="table-area-detail">
    <a-tabs
      id="kensin_tabs"
      :active-key="activeTabKey"
      class="highlight-tabs"
      type="editable-card"
      :hide-add="true"
      :style="{ height: mainHeight }"
      tab-bar-gutter="0"
      tab-position="top"
      @change="tabClick"
    >
      <a-tab-pane key="1" tab="健診履歴" :closable="false">
        <RightTabDetail
          ref="tab1Ref"
          :grouplist1="grouplist1"
          :grouplist2="grouplist2"
          :bhsyosaimenyucd="_112"
          :bhsyosaitabcd="タブコード_1"
          :bosikbn="子_2"
          :kaisu="履歴回数_0"
        />
      </a-tab-pane>
    </a-tabs>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick, watch, toRef } from 'vue'
import { useWindowSize } from '@vueuse/core'
import { FreeItemDispInfoVM, SaveRequest, FreeItemInfoVM } from '../../type'
import { getHeight, XXL } from '@/utils/height'
import RightTabDetail from '../../components/RightTabDetail.vue'
import RightTabDetail_pat2 from '../../components/RightTabDetail_pat2.vue'
import { _103, _112, 子_2, 履歴回数_0, タブコード_1, タブコード_2 } from '../../constant'

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { width } = useWindowSize()
const mainHeight = computed(() => getHeight(width.value >= XXL ? 295 : 0))

const tab1Ref = ref()
//左側tab(キー)
const activeTabKey = ref('1')
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
}>()
const saveDataList = ref<SaveRequest[]>([])

const getData = () => {
  saveDataList.value = []
  saveDataList.value.push(tab1Ref.value?.getData() as SaveRequest)
  return saveDataList.value
}

const getCheck = () => {
  return tab1Ref.value?.getCheck()
}

const selectTab = () => {
  return activeTabKey.value
}

defineExpose({
  getData,
  getCheck,
  selectTab
})
//tab切替
const tabClick = (e, t) => {
  activeTabKey.value = e
}
</script>

<style lang="less" scoped>
:deep(.highlight-tabs .ant-tabs-tab) {
  border-radius: 0px !important;
  width: 180px;
}

:deep(.highlight-tabs .ant-tabs-tab-active) {
  background-color: #ffffe1 !important;
}

:deep(.highlight-tabs .ant-tabs-tab-active div) {
  color: var(--vxe-primary-color) !important;
  font-weight: normal;
}

:deep(.highlight-tabs .ant-tabs-nav-list) {
  margin-bottom: 0px;
}

:deep(.ant-tabs > .ant-tabs-nav .ant-tabs-nav-wrap) {
  border-bottom: 1px solid #606266;
  width: 205px;
}

:deep(.ant-tabs-nav-list) {
  .ant-tabs-tab {
    width: 205px;
  }
}
</style>
