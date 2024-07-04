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
      <a-tab-pane key="1" tab="妊産婦歯科健診結果" :closable="false">
        <RightTabDetail_pat2
          ref="tab1Ref"
          :grouplist1="grouplist1"
          :grouplist2="grouplist2"
          :bhsyosaimenyucd="_108"
          :bhsyosaitabcd="タブコード_1"
          :bosikbn="母_1"
        />
      </a-tab-pane>
      <a-tab-pane key="2" tab="妊産婦歯科健診費用助成" :closable="false">
        <RightTabDetail_pat2
          ref="tab2Ref"
          :grouplist1="grouplist1"
          :grouplist2="grouplist2"
          :bhsyosaimenyucd="_108"
          :bhsyosaitabcd="タブコード_2"
          :bosikbn="母_1"
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
import RightTabDetail_pat2 from '../../components/RightTabDetail_pat2.vue'
import RightTabDetail from '../../components/RightTabDetail.vue'
import { _108, _109, タブコード_2, 母_1, 履歴回数_0, タブコード_1 } from '../../constant'

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { width } = useWindowSize()
const mainHeight = computed(() => getHeight(width.value >= XXL ? 295 : 0))
const tab1Ref = ref()
const tab2Ref = ref()
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
  saveDataList.value.push(tab2Ref.value?.getData() as SaveRequest)
  return saveDataList.value
}

const getCheck = () => {
  return tab1Ref.value?.getCheck() || tab2Ref.value?.getCheck()
}

const selectTab = () => {
  if (activeTabKey.value === タブコード_1) {
    return タブコード_1
  } else {
    return タブコード_2
  }
}

const deleteSelect = () => {
  if (activeTabKey.value === タブコード_1) {
    return tab1Ref.value?.deleteSelect()
  } else {
    return tab2Ref.value?.deleteSelect()
  }
}

defineExpose({
  getData,
  getCheck,
  selectTab,
  deleteSelect
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
}
</style>
