<template>
  <div class="info_detail">
    <a-tabs
      id="kensin_tabs"
      :active-key="activeTabKey"
      class="highlight-tabs"
      type="editable-card"
      :hide-add="true"
      tab-bar-gutter="0"
      tab-position="top"
      @change="tabClick"
    >
      <!-- <a-tab-pane v-for="row in tablist" :key="row.tabcd" :closable="false">
        <template #tab>
          <span>
            <android-outlined />
            {{ row.tabname }}
          </span>
        </template>
        <RightTabDetail
          ref="tabRef"
          :grouplist1="grouplist1"
          :grouplist2="grouplist2"
          :bhsyosaimenyucd="bhsyosaimenyucd"
          :bhsyosaitabcd="bhsyosaitabcd"
          :bosikbn="bosikbn"
          :kaisu="parseInt(row.tabcd)"
          :caselist="caselist"
        />
      </a-tab-pane>
      <template v-for="row in tablist">
        <a-button type="primary">{{ row.tabname }}</a-button>
      </template> -->
      <a-tab-pane v-for="row in tablist" :key="row.tabcd" :tab="row.tabname" :closable="false">
        <RightTabDetail
          ref="tabRef"
          :grouplist1="grouplist1"
          :grouplist2="grouplist2"
          :bhsyosaimenyucd="bhsyosaimenyucd"
          :bhsyosaitabcd="bhsyosaitabcd"
          :bosikbn="bosikbn"
          :kaisu="parseInt(row.tabcd)"
          :caselist="caselist"
        />
      </a-tab-pane>
    </a-tabs>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick, watch, toRef } from 'vue'
import RightTabDetail from './RightTabDetail.vue'
import { KaisuInfoVM, TabInfoVM, SaveRequest, FreeItemDispInfoVM } from '../type'
import { _101, _104, 母_1, 履歴回数_1, タブコード_1 } from '../constant'

const tabRef = ref<any[]>()
const caselist = ref<FreeItemDispInfoVM[]>([])
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  kaisulist: KaisuInfoVM[]
  bhsyosaimenyucd: string
  bhsyosaitabcd: string
  bosikbn: string
  tablist: TabInfoVM[]
}>()
const saveDataList = ref<SaveRequest[]>([])

const getData = () => {
  saveDataList.value = []
  tabRef.value?.forEach((element) => {
    saveDataList.value.push(element.getData() as SaveRequest)
  })
  return saveDataList.value
}

const getCheck = () => {
  return (
    tabRef.value?.some((element) => {
      return element.getCheck()
    }) ?? false
  )
}

function getCaseList() {
  caselist.value = []
  let temp = tabRef.value?.[0]
  caselist.value = temp.getCaseList()
}

defineExpose({
  getData,
  getCheck
})
//左側tab(キー)
const activeTabKey = ref('1')

//tab切替
const tabClick = (e, t) => {
  getCaseList()
  activeTabKey.value = e
}
</script>

<style scoped>
:deep(.ant-tabs-content-holder) {
  margin-top: -11px;
}
</style>
<style src="../index.less" scoped></style>
