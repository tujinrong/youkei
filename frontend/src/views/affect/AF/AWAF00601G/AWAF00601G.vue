<template>
  <a-card :bordered="false" class="mb-2 h-full" :style="{ height: tableHeight + 70 + `px` }">
    <h1>契約者一覧表(連絡用)</h1>
    <div class="self_adaption_table form">
      <a-row>
        <a-col v-bind="layout">
          <th class="required">対象期</th>
          <td>
            第
            <a-input
              v-model:value="formData.a"
              maxlength="3"
              type="number"
              style="width: 120px"
            ></a-input
            >期
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th class="required">対象期(現在)</th>
          <td>
            <a-date-picker v-model:value="formData.b" class="w-full" />
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>契約区分</th>
          <td class="flex">
            <ai-select v-model:value="formData.c" :options="keiyakukbnlist"></ai-select>～<ai-select
              v-model:value="formData.d"
              :options="keiyakukbnlist"
            ></ai-select>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th class="required">契約状態</th>
          <td>
            <a-space class="flex-wrap">
              <a-checkbox v-model:checked="formData.sinkiflg">新規契約者</a-checkbox>
              <a-checkbox v-model:checked="formData.keizokuflg">継続契約者</a-checkbox>
              <a-checkbox v-model:checked="formData.tyusiflg">中止者</a-checkbox>
              <a-checkbox v-model:checked="formData.haigyoflg">廃業者</a-checkbox>
            </a-space>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>事業委託先</th>
          <td class="flex">
            <ai-select v-model:value="formData.c" :options="selectorlist"></ai-select>～<ai-select
              v-model:value="formData.d"
              :options="selectorlist"
            ></ai-select>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>契約者番号</th>
          <td class="flex">
            <a-input v-model:value="formData.c" :xxl="9"></a-input>
            ～
            <a-input v-model:value="formData.d" :xxl="9"></a-input>
          </td> </a-col
      ></a-row>
      <a-row class="m-t-1">
        <a-col :span="24">
          <div class="mb-2 header_operation flex justify-between w-full">
            <a-space :size="20">
              <a-button type="primary" @click="onPreview">プレビュー</a-button>
              <a-button type="primary" @click="clear">クリア</a-button>
            </a-space>
            <close-page />
          </div>
        </a-col>
      </a-row>
    </div>
    <div id="viewer-host" style="height: 650px"></div>
  </a-card>
  <PreviewModal v-model:visible="previewVisible" />
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick, computed } from 'vue'
import dayjs, { Dayjs } from 'dayjs'
import { useRoute, useRouter } from 'vue-router'
import { Judgement } from '@/utils/judge-edited'
import { useTableHeight } from '@/utils/hooks'
import PreviewModal from './components/PreviewModal.vue'
import '@grapecity/activereports/styles/ar-js-ui.css'
import '@grapecity/activereports/styles/ar-js-viewer.css'
import '@grapecity/activereports-localization'
import { ReportViewer, Core, PdfExport } from '@grapecity/activereports'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const editJudge = new Judgement(route.name as string)
const { tableHeight } = useTableHeight()
const createDefaultParams = () => {
  return {
    a: '12',
    b: dayjs('2024-07-02'),
    c: '',
    d: '',
    e: '',
    f: '',
    sinkiflg: true,
    keizokuflg: false,
    tyusiflg: false,
    haigyoflg: false
  }
}
const formData = reactive(createDefaultParams())
const selectorlist = [
  { value: '1', label: '永さん' },
  { value: '2', label: '尾三' },
  { value: '3', label: '史さん' }
]
const keiyakukbnlist = [
  { value: '1', label: '家族' },
  { value: '2', label: '企業' },
  { value: '3', label: '鶏以外' }
]
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 12
}

const previewVisible = ref(false)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => formData,
  () => editJudge.setEdited(),
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const clear = () => {
  Object.assign(formData, createDefaultParams())
}
//preview
function onPreview() {
  //previewVisible.value = true
  const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
  viewer.open('/report/keyakusya.rdlx-json')
}
</script>

<style scoped lang="less">
th {
  width: 130px;
}
h1 {
  font-size: 24px;
}
</style>
