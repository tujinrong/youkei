<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 発育曲線
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.05.22
 * 作成者　　: 張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    title="発育曲線"
    width="1200px"
    :closable="true"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="6">
            <th>宛名番号</th>
            <TD>{{ $route.query.atenano }}</TD>
          </a-col>
          <a-col span="6">
            <th>氏名</th>
            <TD>{{ headerinfo?.name }}</TD>
          </a-col>
        </a-row>
      </div>
      <a-card>
        <div
          style="
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 16px;
            width: 1000px;
            height: 750px;
            margin: 0 auto;
            float: left;
          "
        >
          <div>
            <p>体重</p>
            <div
              id="chartDom1"
              style="width: 100%; height: 300px; background-color: lightgrey"
            ></div>
          </div>
          <div>
            <p>身長</p>
            <div
              id="chartDom2"
              style="width: 100%; height: 300px; background-color: lightgrey"
            ></div>
          </div>
          <div>
            <p>頭囲</p>
            <div
              id="chartDom3"
              style="width: 100%; height: 300px; background-color: lightgrey"
            ></div>
          </div>
          <div>
            <p>胸囲</p>
            <div
              id="chartDom4"
              style="width: 100%; height: 300px; background-color: lightgrey"
            ></div>
          </div>
        </div>
        <div
          style="border: 1px solid #000; float: right; padding: 10px; width: 80px; height: 107px"
        >
          <div style="display: flex; align-items: center; margin-bottom: 5px">
            <div style="width: 20px; height: 2px; margin-right: 5px; background-color: red"></div>
            <span>本人</span>
          </div>
          <div style="display: flex; align-items: center; margin-bottom: 5px">
            <div
              style="width: 20px; height: 2px; margin-right: 5px; background-color: Purple"
            ></div>
            <span>P3</span>
          </div>
          <div style="display: flex; align-items: center; margin-bottom: 5px">
            <div style="width: 20px; height: 2px; margin-right: 5px; background-color: green"></div>
            <span>P97</span>
          </div>
        </div>
      </a-card>
    </a-spin>
    <template #footer>
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button @click="saveData">印刷</a-button>
        </a-space>
        <a-space>
          <a-button type="primary" @click="closeModal">閉じる</a-button>
        </a-space>
      </div>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watch, computed, onMounted, nextTick, watchEffect } from 'vue'
import { message, Empty } from 'ant-design-vue'
import type { FormInstance } from 'ant-design-vue'
import { getDateJpText, judgeValidate, getLabelByValue } from '@/utils/util'
import { showSaveModal, showDeleteModal, showConfirmModal } from '@/utils/modal'
import { DELETE_OK_INFO, SAVE_OK_INFO, CLOSE_CONFIRM } from '@/constants/msg'
import { ShowCurve } from './service'
import { HeaderInfoVM, CurveInfoVM, GraphListVM } from './type'
import { VxeTableInstance, VxeTablePropTypes, VXETable } from 'vxe-table'
import TD from '@/components/Common/TableTD/index.vue'
import { Judgement } from '@/utils/judge-edited'
import { Rule } from 'ant-design-vue/lib/form'
import { useRoute, useRouter } from 'vue-router'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { 子_2 } from '../../constant'
import * as echarts from 'echarts'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const visible = ref(false)
//ローディング
const loading = ref(true)
//画面データ編集判断
const editJudge = new Judgement()
//ビューモデル
const headerinfo = ref<HeaderInfoVM>()
const graphlist = ref<GraphListVM[]>([])
let chartDom1
let chartDom2
let chartDom3
let chartDom4
const curve1 = ref<any[]>([])
const curve2 = ref<any[]>([])
const curve3 = ref<any[]>([])
const curve4 = ref<any[]>([])
const p3curve1 = ref<any[]>([])
const p3curve2 = ref<any[]>([])
const p3curve3 = ref<any[]>([])
const p3curve4 = ref<any[]>([])
const p97curve1 = ref<any[]>([])
const p97curve2 = ref<any[]>([])
const p97curve3 = ref<any[]>([])
const p97curve4 = ref<any[]>([])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
// watch(tableList, () => editJudge.setEdited(), { deep: true })
// watch(tableList, () => getTotal(), { deep: true })
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const openModal = async () => {
  visible.value = true
  try {
    await getList()
  } catch (error) {}
}

//検索処理
async function getList() {
  loading.value = true
  ShowCurve({
    atenano: route.query.atenano as string,
    bosikbn: 子_2,
    pagesize: 0,
    pagenum: 0
  }).then((res) => {
    graphlist.value = res.graphlist
    headerinfo.value = res.headerinfo
    nextTick(() => initDiv())
    loading.value = false
  })
}

//保存処理
function saveData() {
  return
  showSaveModal({
    onOk: async () => {
      await Save({
        saveinfo: saveDataList.value,
        checkflg: false
      }).then(() => {
        InIt()
      })
      // router.push({ name: route.name as string, query: { refresh: '1' } })
    }
  })
}

function initDiv() {
  chartDom1 = document.getElementById('chartDom1')
  chartDom2 = document.getElementById('chartDom2')
  chartDom3 = document.getElementById('chartDom3')
  chartDom4 = document.getElementById('chartDom4')
  setData()
}

function setData() {
  const myChart1 = echarts.init(chartDom1)
  const myChart2 = echarts.init(chartDom2)
  const myChart3 = echarts.init(chartDom3)
  const myChart4 = echarts.init(chartDom4)
  setArr()
  myChart1.setOption(option1)
  myChart2.setOption(option2)
  myChart3.setOption(option3)
  myChart4.setOption(option4)
}

function setArr() {
  graphlist.value.forEach((item) => {
    if (item.itemnm === '体重') {
      curve1.value = item.curveinfolist
      p3curve1.value = item.p3curveinfolist
      p97curve1.value = item.p97curveinfolist
    } else if (item.itemnm === '身長') {
      curve2.value = item.curveinfolist
      p3curve2.value = item.p3curveinfolist
      p97curve2.value = item.p97curveinfolist
    } else if (item.itemnm === '頭囲') {
      curve3.value = item.curveinfolist
      p3curve3.value = item.p3curveinfolist
      p97curve3.value = item.p97curveinfolist
    } else if (item.itemnm === '胸囲') {
      curve4.value = item.curveinfolist
      p3curve4.value = item.p3curveinfolist
      p97curve4.value = item.p97curveinfolist
    }
  })
}

const show = (val) => {
  console.log(val)
}
//リセット
function reset() {
  graphlist.value = []
  nextTick(() => editJudge.reset())
}

//体重option   本人   P3(全体3%)のグラフ   P97(全体97%)のグラフ
const option1: echarts.EChartsOption = {
  xAxis: {
    name: '(ヶ月)',
    type: 'category',
    axisTick: {
      alignWithLabel: true
    },
    min: 0,
    max: 12
    //data: ['1', '2', '3', '4', '5', '6', '7']
  },
  yAxis: {
    name: '(kg)',
    min: 0,
    max: 12,
    type: 'value',
    interval: 1
  },
  series: [
    {
      name: '本人',
      data: curve1.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'red'
      },
      showSymbol: false
    },
    {
      name: 'P97',
      data: p97curve1.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'green'
      },
      showSymbol: false
    },
    {
      name: 'P3',
      data: p3curve1.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'Purple'
      },
      showSymbol: false
    }
  ]
}

//身長option   本人   P3(全体3%)のグラフ   P97(全体97%)のグラフ
const option2: echarts.EChartsOption = {
  xAxis: {
    name: '(ヶ月)',
    type: 'category',
    axisTick: {
      alignWithLabel: true
    },
    min: 0,
    max: 12
  },
  yAxis: {
    name: '(cm)',
    min: 25,
    max: 75,
    type: 'value',
    interval: 5
  },
  series: [
    {
      name: '本人',
      data: curve2.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'red'
      },
      showSymbol: false
    },
    {
      name: 'P97',
      data: p97curve2.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'green'
      },
      showSymbol: false
    },
    {
      name: 'P3',
      data: p3curve2.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'Purple'
      },
      showSymbol: false
    }
  ]
}

//頭囲option   本人   P3(全体3%)のグラフ   P97(全体97%)のグラフ
const option3: echarts.EChartsOption = {
  xAxis: {
    name: '(ヶ月)',
    type: 'category',
    axisTick: {
      alignWithLabel: true
    },
    min: 0,
    max: 12
    //data: ['1', '2', '3', '4', '5', '6', '7']
  },
  yAxis: {
    name: '(cm)',
    min: 30,
    max: 52,
    type: 'value',
    interval: 2
  },
  series: [
    {
      name: '本人',
      data: curve3.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'red'
      },
      showSymbol: false
    },
    {
      name: 'P97',
      data: p97curve3.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'green'
      },
      showSymbol: false
    },
    {
      name: 'P3',
      data: p3curve3.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'Purple'
      },
      showSymbol: false
    }
  ]
}

//胸囲option   本人   P3(全体3%)のグラフ   P97(全体97%)のグラフ
const option4: echarts.EChartsOption = {
  xAxis: {
    name: '(ヶ月)',
    type: 'category',
    axisTick: {
      alignWithLabel: true
    },
    min: 0,
    max: 12
    //data: ['1', '2', '3', '4', '5', '6', '7']
  },
  yAxis: {
    name: '(cm)',
    min: 28,
    max: 50,
    type: 'value',
    interval: 2
  },
  series: [
    {
      name: '本人',
      data: curve4.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'red'
      },
      showSymbol: false
    },
    {
      name: 'P97',
      data: p97curve4.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'green'
      },
      showSymbol: false
    },
    {
      name: 'P3',
      data: p3curve4.value,
      type: 'line',
      smooth: true,
      lineStyle: {
        color: 'Purple'
      },
      showSymbol: false
    }
  ]
}

//閉じるボタン(×を含む)
const closeModal = () => {
  reset()
  visible.value = false
}
defineExpose({
  open: openModal
})
</script>
<style src="./index.less" scoped>
._right {
  display: flex;
  justify-content: flex-end; /* 将子元素右对齐 */
}
</style>
