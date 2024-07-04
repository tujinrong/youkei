<template>
  <div class="table-area">
    <a-tabs
      id="kensin_tabs"
      :active-key="activeTabKey"
      class="highlight-tabs"
      type="editable-card"
      :hide-add="true"
      :style="{ height: mainHeight }"
      tab-bar-gutter="0"
      tab-position="left"
      @change="tabClick"
    >
      <a-tab-pane key="1" tab="出生時" :closable="false">
        <AWBH00401G_1 ref="tab101Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="2" tab="新生児聴覚検査" :closable="false">
        <AWBH00401G_2 ref="tab102Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="3" tab="健診受診履歴" :closable="false">
        <AWBH00401G_3 ref="tab103Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="4" tab="3～4か月児健診" :closable="false">
        <AWBH00401G_4 ref="tab104Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="5" tab="1歳6か月児健診" :closable="false">
        <AWBH00401G_5 ref="tab105Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="6" tab="3歳児健診" :closable="false">
        <AWBH00401G_6 ref="tab106Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="7" tab="精密健診" :closable="false">
        <AWBH00401G_7 ref="tab107Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="8" tab="未受診者勧奨" :closable="false">
        <AWBH00401G_8 ref="tab108Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
    </a-tabs>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick, watch, toRef } from 'vue'
import { useWindowSize } from '@vueuse/core'
import { getHeight, XXL } from '@/utils/height'
import { useRouter, useRoute } from 'vue-router'
import { DeleteRequest, SaveRequest, FreeItemInfoVM } from '../type'
import AWBH00401G_1 from '../page/AWBH00401G_1/AWBH00401G_1.vue'
import AWBH00401G_2 from '../page/AWBH00401G_2/AWBH00401G_2.vue'
import AWBH00401G_3 from '../page/AWBH00401G_3/AWBH00401G_3.vue'
import AWBH00401G_4 from '../page/AWBH00401G_4/AWBH00401G_4.vue'
import AWBH00401G_5 from '../page/AWBH00401G_5/AWBH00401G_5.vue'
import AWBH00401G_6 from '../page/AWBH00401G_6/AWBH00401G_6.vue'
import AWBH00401G_7 from '../page/AWBH00401G_7/AWBH00401G_7.vue'
import AWBH00401G_8 from '../page/AWBH00401G_8/AWBH00401G_8.vue'
import { _101, _102, _104, _106, _109, _112, _113, _115, 子_2, 履歴回数_0 } from '../constant'

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { width } = useWindowSize()
const route = useRoute()
const mainHeight = computed(() => getHeight(width.value >= XXL ? 295 : 0))
const tab101Ref = ref()
const tab102Ref = ref()
const tab103Ref = ref()
const tab104Ref = ref()
const tab105Ref = ref()
const tab106Ref = ref()
const tab107Ref = ref()
const tab108Ref = ref()
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
}>()
//左側tab(キー)
const activeTabKey = ref('1')
const saveDataList = ref<SaveRequest[]>()
const deleteData = ref<DeleteRequest>({
  bhsyosaimenyucd: '',
  bhsyosaitabcd: '',
  bosikbn: 子_2,
  atenano: route.query.atenano as string,
  kaisu: 履歴回数_0,
  checkflg: false,
  delflg: true
})
const getData = () => {
  saveDataList.value = []
  saveDataList.value.push(tab101Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab102Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab103Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab104Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab105Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab106Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab107Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab108Ref.value?.getData() as SaveRequest)
  return processArray(saveDataList.value)
}

const getCheck = () => {
  return (
    tab101Ref.value?.getCheck() ||
    tab102Ref.value?.getCheck() ||
    tab103Ref.value?.getCheck() ||
    tab104Ref.value?.getCheck() ||
    tab105Ref.value?.getCheck() ||
    tab106Ref.value?.getCheck() ||
    tab107Ref.value?.getCheck() ||
    tab108Ref.value?.getCheck()
  )
}

const getDeleteSelect = () => {
  deleteData.value.bhsyosaimenyucd = ''
  deleteData.value.bhsyosaitabcd = ''
  initDeleteSelect(activeTabKey.value)
  return deleteData.value
}

const initDeleteSelect = (activeTabKey) => {
  let temp
  switch (activeTabKey) {
    case '1':
      deleteData.value.bhsyosaimenyucd = _101
      temp = tab101Ref.value?.selectTab() as string
      break
    case '2':
      deleteData.value.bhsyosaimenyucd = _102
      temp = tab102Ref.value?.selectTab() as string
      break
    case '3':
      deleteData.value.bhsyosaimenyucd = _104
      temp = tab103Ref.value?.selectTab() as string
      break
    case '4':
      deleteData.value.bhsyosaimenyucd = _106
      temp = tab104Ref.value?.selectTab() as string
      break
    case '5':
      deleteData.value.bhsyosaimenyucd = _109
      temp = tab105Ref.value?.selectTab() as string
      break
    case '6':
      deleteData.value.bhsyosaimenyucd = _112
      temp = tab106Ref.value?.selectTab() as string
      break
    case '7':
      deleteData.value.bhsyosaimenyucd = _113
      temp = tab107Ref.value?.selectTab() as string
      break
    case '8':
      deleteData.value.bhsyosaimenyucd = _115
      temp = tab108Ref.value?.selectTab() as string
      break
    default:
      break
  }
  deleteData.value.bhsyosaitabcd = temp
}

function processArray(arr: any[]): SaveRequest[] {
  const result: SaveRequest[] = []

  function process(item: any): void {
    if (Array.isArray(item)) {
      item.forEach(process)
    } else if (item !== null && typeof item === 'object') {
      const saveRequest: SaveRequest = {
        bosikbn: item.bosikbn,
        bhsyosaimenyucd: item.bhsyosaimenyucd,
        bhsyosaitabcd: item.bhsyosaitabcd,
        atenano: item.atenano,
        kaisu: item.kaisu,
        freeiteminfo: [],
        checkflg: false,
        fixiteminfo: []
      }
      result.push(saveRequest)
      if (Array.isArray(item.freeiteminfo)) {
        item.freeiteminfo.forEach((info: FreeItemInfoVM) => {
          saveRequest.freeiteminfo.push({
            inputtype: info.inputtype,
            item: info.item,
            value: info.value
          })
        })
      }
      if (Array.isArray(item.fixiteminfo)) {
        item.fixiteminfo.forEach((info: FreeItemInfoVM) => {
          saveRequest.fixiteminfo.push({
            inputtype: info.inputtype,
            item: info.item,
            value: info.value
          })
        })
      }
    }
  }

  process(arr)
  return result
}

const topage = (v) => {
  tabClick(v)
}

defineExpose({
  getData,
  getCheck,
  getDeleteSelect
})
//tab切替
const tabClick = (e) => {
  activeTabKey.value = e
}
</script>

<style src="../index.less" scoped></style>
