<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 妊産婦情報管理-妊婦健診結果
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.04
 * 作成者　　: gaof
 * 変更履歴　:
 * ---------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <div class="info_detail">
      <div class="self_adaption_table" style="padding-bottom: 6px">
        <a-row>
          <a-col :md="12" :xl="8" :xxl="8">
            <th style="width: 40%; text-align: center">登録番号連番</th>
            <td>
              <a-select v-model:value="selectedTab" class="select_style" :options="divList">
              </a-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <a-row>
        <a-col :md="24" :xl="24" :xxl="24">
          <div v-for="item in kaisulist" :key="String(item.kaisu)">
            <RightTab
              v-if="selectedTab === String(item.kaisu)"
              :key="String(item.kaisu)"
              ref="tabRef"
              :grouplist1="grouplist1"
              :grouplist2="grouplist2"
              :bhsyosaimenyucd="bhsyosaimenyucd"
              :bhsyosaitabcd="bhsyosaitabcd"
              :bosikbn="bosikbn"
              :kaisu="item.kaisu"
            />
          </div>
        </a-col>
      </a-row>
    </div>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, watch } from 'vue'
import { getHeight } from '@/utils/height'
import RightTab from './RightTab.vue'
import { KaisuInfoVM, TabInfoVM, SaveRequest, FreeItemDispInfoVM } from '../type'
import { 登录编号连番_0, 履歴回数_0, 枝番_0 } from '../constant'
import { SearchSyosai } from '../service'
import { useRouter, useRoute } from 'vue-router'
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
const tabRef = ref<any[]>()
const selectedTab = ref('')
const divList = ref<DaSelectorModel[]>([])
const kaisulist = ref<KaisuInfoVM[]>([])
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
// const kaisulist = ref<KaisuInfoVM[]>([])
onMounted(() => {
  getTableList()
})

// 検索処理
async function getTableList() {
  loading.value = true
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
    kaisulist.value = res.kaisulist
    divList.value = kaisulist.value.map((item) => ({
      value: item.kaisu.toString(),
      label: item.kaisu.toString()
    }))
    selectedTab.value = String(kaisulist.value[0].kaisu)
    loading.value = false
  })
}

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

const deleteSelect = () => {
  return selectedTab.value
}

defineExpose({
  getData,
  getCheck,
  deleteSelect
})

//tab(キー)
const activeTabKey = ref('1')

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

/* 自定义样式 */
.custom-tabs .ant-tabs-tab {
  /* 样式定义 */
  background-color: #1890ff !important;
  /* 将标签按钮样式修改成按钮样式 */
  display: inline-block;
  padding: 8px 16px;
  background-color: #1890ff; /* 按钮背景色 */
  color: #fff; /* 文字颜色 */
  border-radius: 20px; /* 圆形按钮 */
  cursor: pointer; /* 鼠标样式 */
  transition: background-color 0.3s; /* 过渡动画 */
}

.custom-tabs .ant-tabs-tab:hover {
  /* 鼠标悬停样式 */
  background-color: #40a9ff; /* 按钮悬停背景色 */
}

.custom-tabs .ant-tabs-tab-active {
  /* 激活状态下的标签按钮样式 */
  background-color: #096dd9; /* 激活按钮背景色 */
}

.custom-tabs .ant-tabs-tab-disabled {
  /* 禁用状态下的标签按钮样式 */
  opacity: 0.5; /* 设置透明度 */
}
</style>
<style src="../index.less" scoped></style>
