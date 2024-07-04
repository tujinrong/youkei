<template>
  <a-spin :spinning="loading">
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
        <a-tab-pane key="1" tab="出産の状態に係る情報" :closable="false">
          <RightTabDetail_pat3
            ref="tab1Ref"
            :grouplist1="grouplist1"
            :grouplist2="grouplist2"
            :bhsyosaimenyucd="_104"
            :bhsyosaitabcd="タブコード_1"
            :bosikbn="母_1"
          />
        </a-tab-pane>
      </a-tabs>
    </div>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick, watch, toRef } from 'vue'
import { useWindowSize } from '@vueuse/core'
import { getHeight, XXL } from '@/utils/height'
import RightTabDetail_pat3 from '../../components/RightTabDetail_pat3.vue'
import { SaveRequest, KaisuInfoVM, TabInfoVM } from '../../type'
import { _104, 履歴回数_1, 母_1, タブコード_1 } from '../../constant'
import { SearchSyosai } from '../../service'
import { useRouter, useRoute } from 'vue-router'
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { width } = useWindowSize()
const mainHeight = computed(() => getHeight(width.value >= XXL ? 295 : 0))
const tab1Ref = ref()
const route = useRoute()
const loading = ref<boolean>(false)
const kaisulist = ref<KaisuInfoVM[]>([])
const tablist = ref<TabInfoVM[]>([])
let maxkaisu = 0
const saveDataList = ref<SaveRequest[]>([])
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
}>()
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
const getData = () => {
  saveDataList.value = []
  saveDataList.value.push(tab1Ref.value?.getData() as SaveRequest)
  return saveDataList.value
}

const getCheck = () => {
  return tab1Ref.value?.getCheck()
}

const selectTab = () => {
  return タブコード_1
}

const deleteSelect = () => {
  return tab1Ref.value?.deleteSelect()
}

defineExpose({
  getData,
  getCheck,
  selectTab,
  deleteSelect
})
//左側tab(キー)
const activeTabKey = ref('1')

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
