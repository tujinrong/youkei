<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col v-if="nendoflg" :md="12" :lg="8" :xl="8" :xxl="4">
            <th class="required">年度</th>
            <td>
              <year-jp v-model:value="searchParams.nendo" />
            </td>
          </a-col>
          <a-col :md="nendoflg ? 12 : 12" :lg="nendoflg ? 8 : 12" :xl="nendoflg ? 8 : 12" :xxl="6">
            <th>抽出対象</th>
            <td>
              <ai-select
                v-model:value="searchParams.tyusyututaisyo"
                :options="tyusyututaisyoList"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="nendoflg ? 24 : 12" :lg="nendoflg ? 8 : 12" :xl="nendoflg ? 8 : 12" :xxl="6">
            <th>抽出内容</th>
            <td>
              <a-input v-model:value="searchParams.tyusyutunaiyo" allow-clear />
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="24" :xxl="8">
            <th>登録日</th>
            <td>
              <RangeDate2
                v-model:value1="searchParams.regdttmf"
                v-model:value2="searchParams.regdttmt"
              />
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1">
        <a-space>
          <a-button type="primary" @click="Search">検索</a-button>
          <a-button
            type="primary"
            :disabled="!route.meta.addflg"
            @click="showModal(Enum抽出モード.全体抽出)"
            >全体抽出</a-button
          >
          <a-button
            type="primary"
            :disabled="!route.meta.addflg"
            @click="showModal(Enum抽出モード.個別抽出)"
            >個別抽出</a-button
          >
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page class="float-right"></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <a-tabs v-model:activeKey.number="tabActiveKey" type="card">
        <a-tab-pane :key="TABKEYENUMS.全体抽出" tab="全体抽出"> </a-tab-pane>
        <a-tab-pane :key="TABKEYENUMS.個別抽出" tab="個別抽出"> </a-tab-pane>
      </a-tabs>
      <Tab1
        v-show="tabActiveKey === TABKEYENUMS.全体抽出"
        ref="tab1Ref"
        v-bind="{ tableList1, tableHeight, nendoflg }"
        v-model:page-params="pageParams1"
        v-model:total-count="totalCount"
      />
      <Tab2
        v-show="tabActiveKey === TABKEYENUMS.個別抽出"
        ref="tab2Ref"
        v-bind="{ tableList2, tableHeight, nendoflg }"
        v-model:page-params="pageParams2"
        v-model:total-count="totalrowcount2"
      />
    </a-card>
  </a-spin>
  <Modal v-model:visible="visible" v-bind="{ tyusyukbn }" />
</template>
<script setup lang="ts">
import { ref, reactive, onMounted, watch } from 'vue'
import { RowVM } from '../type'
import Modal from '@/views/affect/KK/AWKK01302D/index.vue'
import { Enum抽出モード, PageSatatus } from '#/Enums'
import { InitList, SearchList } from '../service'
import RangeDateTime from '@/components/Selector/RangeDateTime/index.vue'
import useTableHeight from '@/utils/hooks/useTableHeight'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { ss } from '@/utils/storage'
import RangeDate2 from '@/components/Selector/RangeDate/index2.vue'
import Tab1 from './Tab1.vue'
import Tab2 from './Tab2.vue'
import { useRoute, useRouter } from 'vue-router'
enum TABKEYENUMS {
  全体抽出 = 1,
  個別抽出
}
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const visible = ref(false)
const tyusyukbn = ref<Enum抽出モード>()
const nendoflg = ref(false)
const tabActiveKey = ref(TABKEYENUMS.全体抽出)
const createDefaultParams = () => {
  return {
    nendo: ss.get(GLOBAL_YEAR), //年度
    tyusyututaisyo: '', //抽出対象コード
    tyusyutunaiyo: '', //抽出内容
    regdttmf: '', //抽出日（開始）
    regdttmt: '' //抽出日（終了）
  }
}
const searchParams = reactive(createDefaultParams())
const tyusyututaisyoList = ref<DaSelectorModel[]>([])

const loading = ref(false)
//全体抽出tab
const totalCount = ref(0)
const pageParams1 = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const tableList1 = ref<RowVM[]>([])
//個別抽出tab
const totalrowcount2 = ref(0)
const pageParams2 = reactive({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const tableList2 = ref<RowVM[]>([])

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  //一覧画面初期化
  InitList().then((res) => {
    nendoflg.value = res.nendoflg
    tyusyututaisyoList.value = res.selectorlist
  })
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams1, () => {
  if (tableList1.value.length > 0 || totalCount.value > 0) Search()
})
watch(pageParams2, () => {
  if (tableList2.value.length > 0 || totalrowcount2.value > 0) Search()
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -45)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//クーポン券画面
const showModal = (kbn: Enum抽出モード) => {
  tyusyukbn.value = kbn
  visible.value = true
}

//検索
const Search = async () => {
  loading.value = true
  try {
    const res = await SearchList({
      ...pageParams1,
      ...searchParams,
      pagesize2: pageParams2.pagesize,
      pagenum2: pageParams2.pagenum,
      orderby2: pageParams2.orderby
    })
    tableList1.value = res.kekkalist1
    tableList2.value = res.kekkalist2
    totalrowcount2.value = res.totalrowcount2
    totalCount.value = res.totalrowcount
    loading.value = false
  } catch (error) {
    loading.value = false
  }
}
//クリア
const clear = () => {
  tableList1.value = []
  tableList2.value = []
  totalCount.value = 0
  totalrowcount2.value = 0
  pageParams1.pagenum = 1
  pageParams2.pagenum = 1
}
//クリア
const reset = () => {
  clear()
  Object.assign(searchParams, createDefaultParams())
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 100px;
}
</style>
