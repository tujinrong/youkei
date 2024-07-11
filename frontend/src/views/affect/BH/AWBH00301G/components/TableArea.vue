<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 妊産婦情報管理-table
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.01
 * 作成者　　: gaof
 * 変更履歴　:
 * ---------------------------------------------------------------->
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
      <a-tab-pane v-if="true" key="1" tab="妊娠届出情報" :closable="false">
        <AWBH00301G_1 ref="tab101Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="2" tab="母子健康手帳交付情報" :closable="false">
        <AWBH00301G_3 ref="tab103Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="3" tab="出産の状態に係る情報" :closable="false">
        <AWBH00301G_4 ref="tab104Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="4" tab="妊婦健診結果" :closable="false">
        <AWBH00301G_5 ref="tab105Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="5" tab="妊婦精健結果" :closable="false">
        <AWBH00301G_7 ref="tab107Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="6" tab="妊産婦歯科健診結果" :closable="false">
        <AWBH00301G_8 ref="tab108Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="7" tab="妊産婦歯科精健結果" :closable="false">
        <AWBH00301G_9 ref="tab109Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="8" tab="産婦健診結果" :closable="false">
        <AWBH00301G_10
          ref="tab110Ref"
          :grouplist1="grouplist1"
          :grouplist2="grouplist2"
          :topage="topage"
        />
      </a-tab-pane>
      <a-tab-pane key="9" tab="産婦精密健診結果" :closable="false">
        <AWBH00301G_12 ref="tab112Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
      <a-tab-pane key="10" tab="産後ケア事業情報" :closable="false">
        <AWBH00301G_13 ref="tab113Ref" :grouplist1="grouplist1" :grouplist2="grouplist2" />
      </a-tab-pane>
    </a-tabs>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick, watch, toRef } from 'vue'
import { useWindowSize } from '@vueuse/core'
import { getHeight, XXL } from '@/utils/height'
import RightTabList from './RightTabList.vue'
import { DeleteRequest, SaveRequest, FreeItemInfoVM, JyoseiListInfoVM } from '../type'
import { useRouter, useRoute } from 'vue-router'
import {
  母_1,
  履歴回数_0,
  枝番_0,
  登录编号连番_0,
  page_pat2,
  _101,
  _103,
  _104,
  _105,
  _107,
  _108,
  _109,
  _110,
  _112,
  _113
} from '../constant'
import AWBH00301G_1 from '../page/AWBH00301G_1/AWBH00301G_1.vue'
import AWBH00301G_3 from '../page/AWBH00301G_3/AWBH00301G_3.vue'
import AWBH00301G_4 from '../page/AWBH00301G_4/AWBH00301G_4.vue'
import AWBH00301G_5 from '../page/AWBH00301G_5/AWBH00301G_5.vue'
import AWBH00301G_7 from '../page/AWBH00301G_7/AWBH00301G_7.vue'
import AWBH00301G_8 from '../page/AWBH00301G_8/AWBH00301G_8.vue'
import AWBH00301G_9 from '../page/AWBH00301G_9/AWBH00301G_9.vue'
import AWBH00301G_10 from '../page/AWBH00301G_10/AWBH00301G_10.vue'
import AWBH00301G_12 from '../page/AWBH00301G_12/AWBH00301G_12.vue'
import AWBH00301G_13 from '../page/AWBH00301G_13/AWBH00301G_13.vue'

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { width } = useWindowSize()
const route = useRoute()
const mainHeight = computed(() => getHeight(width.value >= XXL ? 295 : 0))
const tab101Ref = ref()
const tab103Ref = ref()
const tab104Ref = ref()
const tab105Ref = ref()
const tab107Ref = ref()
const tab108Ref = ref()
const tab109Ref = ref()
const tab110Ref = ref()
const tab112Ref = ref()
const tab113Ref = ref()
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  torokuno: number
}>()
//左側tab(キー)
const activeTabKey = ref('1')
const saveDataList = ref<SaveRequest[]>()
const deleteData = ref<DeleteRequest>({
  bhsyosaimenyucd: '',
  bhsyosaitabcd: '',
  bosikbn: 母_1,
  atenano: route.query.atenano as string,
  torokuno: route.query.torokuno as unknown as number,
  kaisu: 履歴回数_0,
  torokunorenban: 登录编号连番_0,
  edano: 枝番_0,
  checkflg: false,
  delflg: true
})

const getData = () => {
  saveDataList.value = []
  saveDataList.value.push(tab101Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab103Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab104Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab105Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab107Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab108Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab109Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab110Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab112Ref.value?.getData() as SaveRequest)
  saveDataList.value.push(tab113Ref.value?.getData() as SaveRequest)
  // console.log(processArray(saveDataList.value))
  return processArray(saveDataList.value)
}

const getCheck = () => {
  return (
    tab101Ref.value?.getCheck() ||
    tab103Ref.value?.getCheck() ||
    tab104Ref.value?.getCheck() ||
    tab105Ref.value?.getCheck() ||
    tab107Ref.value?.getCheck() ||
    tab108Ref.value?.getCheck() ||
    tab109Ref.value?.getCheck() ||
    tab110Ref.value?.getCheck() ||
    tab112Ref.value?.getCheck() ||
    tab113Ref.value?.getCheck()
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
  let kaisu = 履歴回数_0
  switch (activeTabKey) {
    case '1':
      deleteData.value.bhsyosaimenyucd = _101
      temp = tab101Ref.value?.selectTab() as string
      break
    case '2':
      deleteData.value.bhsyosaimenyucd = _103
      temp = tab103Ref.value?.selectTab() as string
      kaisu = tab103Ref.value?.deleteSelect() as number
      deleteData.value.torokunorenban = kaisu
      deleteData.value.delflg = false
      break
    case '3':
      deleteData.value.bhsyosaimenyucd = _104
      temp = tab104Ref.value?.selectTab() as string
      kaisu = tab104Ref.value?.deleteSelect() as number
      deleteData.value.torokunorenban = kaisu
      deleteData.value.delflg = false
      break
    case '4':
      deleteData.value.bhsyosaimenyucd = _105
      temp = tab105Ref.value?.selectTab() as string
      kaisu = tab105Ref.value?.deleteSelect() as number
      deleteData.value.kaisu = kaisu
      if (temp === page_pat2) {
        deleteData.value.kaisu = 履歴回数_0
        deleteData.value.edano = kaisu
      }
      deleteData.value.delflg = false
      break
    case '5':
      deleteData.value.bhsyosaimenyucd = _107
      temp = tab107Ref.value?.selectTab() as string
      kaisu = tab107Ref.value?.deleteSelect() as number
      deleteData.value.edano = kaisu
      deleteData.value.delflg = false
      break
    case '6':
      deleteData.value.bhsyosaimenyucd = _108
      temp = tab108Ref.value?.selectTab() as string
      kaisu = tab108Ref.value?.deleteSelect() as number
      deleteData.value.edano = kaisu
      deleteData.value.delflg = false
      break
    case '7':
      deleteData.value.bhsyosaimenyucd = _109
      temp = tab109Ref.value?.selectTab() as string
      kaisu = tab109Ref.value?.deleteSelect() as number
      deleteData.value.edano = kaisu
      deleteData.value.delflg = false
      break
    case '8':
      deleteData.value.bhsyosaimenyucd = _110
      temp = tab110Ref.value?.selectTab() as string
      kaisu = tab110Ref.value?.deleteSelect() as number
      deleteData.value.edano = kaisu
      deleteData.value.delflg = false
      break
    case '9':
      deleteData.value.bhsyosaimenyucd = _112
      temp = tab112Ref.value?.selectTab() as string
      kaisu = tab112Ref.value?.deleteSelect() as number
      deleteData.value.edano = kaisu
      deleteData.value.delflg = false
      break
    case '10':
      deleteData.value.bhsyosaimenyucd = _113
      temp = tab113Ref.value?.selectTab() as string
      kaisu = tab113Ref.value?.deleteSelect() as number
      deleteData.value.edano = kaisu
      deleteData.value.delflg = false
      break
    default:
      break
  }
  deleteData.value.bhsyosaitabcd = temp
}

// データのフォーマット
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
        checkflg: item.checkFlg,
        torokunorenban: item.torokunorenban,
        torokuno: props.torokuno,
        edano: item.edano,
        fixiteminfo: [],
        jyoseilistinfo: []
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
      if (Array.isArray(item.jyoseilistinfo)) {
        item.jyoseilistinfo.forEach((info: JyoseiListInfoVM) => {
          saveRequest.jyoseilistinfo.push({
            no: info.no,
            joseikensyurui: splitValue(info.joseikensyurui),
            jusinymd: info.jusinymd,
            siharaikingaku: info.siharaikingaku,
            joseikingaku: info.joseikingaku,
            joseikingakugendogaku: info.joseikingakugendogaku
          })
        })
      }
    }
  }

  process(arr)
  return result
}

function splitValue(val) {
  let temp = val
  temp = String(temp)
  if (temp.includes(' : ')) {
    return temp.split(' : ')[0].trim()
  } else {
    return val
  }
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
