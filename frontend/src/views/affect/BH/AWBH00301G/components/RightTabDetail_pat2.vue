<template>
  <a-spin :spinning="loading">
    <div class="info_detail">
      <a-tabs
        id="kensin_tabs"
        :active-key="activeTabKey"
        class="highlight-tabs"
        type="editable-card"
        :hide-add="false"
        tab-bar-gutter="0"
        tab-position="top"
        @change="tabClick"
        @edit="editTabs"
      >
        <a-tab-pane
          v-for="row in kaisulist"
          :key="row.kaisu"
          :tab="row.kaisu + '回目'"
          :closable="false"
        >
          <RightTab
            ref="tabRef"
            :grouplist1="grouplist1"
            :grouplist2="grouplist2"
            :bhsyosaimenyucd="bhsyosaimenyucd"
            :bhsyosaitabcd="bhsyosaitabcd"
            :bosikbn="bosikbn"
            :kaisu="row.kaisu"
          />
        </a-tab-pane>
      </a-tabs>
    </div>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, nextTick } from 'vue'
import { getHeight } from '@/utils/height'
import RightTab from './RightTab.vue'
import { KaisuInfoVM, TabInfoVM, SaveRequest, DeleteRequest } from '../type'
import {
  _103,
  履歴回数_1,
  _104,
  _105,
  _106,
  _110,
  page_pat1,
  page_pat2,
  登录编号连番_0,
  履歴回数_0,
  枝番_0
} from '../constant'
import { SearchSyosai, Delete } from '../service'
import { useRouter, useRoute } from 'vue-router'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { EnumServiceResult } from '#/Enums'

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
const tabRef = ref<any[]>()
const caseTorokunorenban = ref<number>(登录编号连番_0)
let caseEdano = ref<number>(枝番_0)
let caseKaisu = ref<number>(履歴回数_0)
let caseTorokuno
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  bhsyosaimenyucd: string
  bhsyosaitabcd: string
  bosikbn: string
}>()
const router = useRouter()
const route = useRoute()
const loading = ref<boolean>(false)
const saveDataList = ref<SaveRequest[]>([])
const kaisulist = ref<KaisuInfoVM[]>([])
const maxkaisu = ref<number>(0)
const limitkaisu = ref<number>(10)
//操作権限取得
const updFlg = route.meta.updflg
const addFlg = route.meta.addflg
const delFlg = route.meta.delflg
onMounted(() => {
  caseTorokuno = route.query.torokuno
  getTableList()
})

// 検索処理
async function getTableList() {
  loading.value = true
  kaisulist.value = []
  kaisulist.value.push({ kaisu: 履歴回数_1 })
  SearchSyosai({
    atenano: route.query.atenano as string,
    torokuno: route.query.torokuno as unknown as number,
    bhsyosaimenyucd: props.bhsyosaimenyucd,
    bhsyosaitabcd: props.bhsyosaitabcd,
    bosikbn: props.bosikbn,
    kaisu: 履歴回数_0,
    pagesize: 0,
    pagenum: 0,
    torokunorenban: 登录编号连番_0,
    edano: 枝番_0
  }).then((res) => {
    maxkaisu.value = res.maxkaisu
    if (res.limitkaisu != 0) {
      limitkaisu.value = res.limitkaisu
    }
    if (res.kaisulist.length != 0) {
      kaisulist.value = res.kaisulist
    }
    tabClick(kaisulist.value[0].kaisu)
    loading.value = false
  })
}

//タブボタンクリア処理(削除、新規の判断)
function editTabs(targetKey, action: 'add' | 'remove') {
  if (action === 'add') addTab()
  else if (action === 'remove') return
}

const addTab = () => {
  if ([_105, _110].includes(props.bhsyosaimenyucd)) {
    if ([page_pat1].includes(props.bhsyosaitabcd)) {
      return
    }
  }
  if (kaisulist.value.length >= limitkaisu.value) {
    return
  }
  let newKaisu

  if (kaisulist.value.length === 0) {
    newKaisu = { kaisu: 履歴回数_1 }
  } else {
    newKaisu = { kaisu: kaisulist.value[kaisulist.value.length - 1].kaisu + 1 }
  }
  kaisulist.value.push(newKaisu)
}

const getData = () => {
  saveDataList.value = []
  if (kaisulist.value.length > 0) {
    tabRef.value?.forEach((element) => {
      saveDataList.value.push(element.getData() as SaveRequest)
    })
  } else {
    saveDataList.value.push(tabRef.value?.getData() as SaveRequest)
  }
  return saveDataList.value
}

const getCheck = () => {
  if (kaisulist.value.length > 0) {
    return (
      tabRef.value?.some((element) => {
        return element.getCheck()
      }) ?? false
    )
  } else {
    return tabRef.value?.getCheck() ?? false
  }
}

const initTorokunorenban = (targetKey) => {
  // let temp = kaisulist.value[targetKey- 1].kaisu
  let temp = targetKey
  if ([_103, _104].includes(props.bhsyosaimenyucd)) {
    caseTorokunorenban.value = temp
  } else if ([_105, _106].includes(props.bhsyosaimenyucd)) {
    caseKaisu.value = temp
    if ([page_pat2].includes(props.bhsyosaitabcd)) {
      caseKaisu.value = 履歴回数_0
      caseEdano.value = temp
    }
  } else {
    caseEdano.value = temp
  }
  const deleteData = ref<DeleteRequest>({
    bosikbn: props.bosikbn,
    bhsyosaimenyucd: props.bhsyosaimenyucd,
    bhsyosaitabcd: props.bhsyosaitabcd,
    atenano: route.query.atenano as string,
    kaisu: caseKaisu.value,
    torokunorenban: caseTorokunorenban.value,
    torokuno: caseTorokuno,
    edano: caseEdano.value,
    checkflg: false,
    delflg: false
  })
  return deleteData.value
}

const deleteSelect = () => {
  return activeTabKey.value
}

defineExpose({
  getData,
  getCheck,
  deleteSelect
})

//tab(キー)
const activeTabKey = ref(kaisulist.value[0])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => {
  let screenHeight = window.innerHeight
  let computeHeight = 0
  if (screenHeight >= 800) {
    computeHeight = 500
  } else {
    computeHeight = 250
  }
  return getHeight(computeHeight)
})

//tab切替
const tabClick = (e) => {
  activeTabKey.value = e
}
</script>

<style scoped>
.info_content .right_button {
  text-align: right;
}

.info_content .table_right_button {
  text-align: center;
}

.info_detail2 {
  padding: 10px 30px 0px 40px;
  width: 100%;
}
</style>
<style src="../index.less" scoped></style>
