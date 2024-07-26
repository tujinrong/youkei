<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px">
      <div>
        <h1>契約者一覧表(連絡用)</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">対象期</th>
              <td>
                第
                <a-input-number
                  v-model:value="formData.taisyoki1"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  style="width: 120px"
                ></a-input-number>
                期
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">対象日(現在)</th>
              <td>
                <DateJp v-model:value="formData.taisyoki2" class="w-full" />
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約区分</th>
              <td class="flex">
                <ai-select
                  v-model:value="formData.keiyakukbn1"
                  split-val
                  :options="keiyakukbnlist"
                ></ai-select
                >～<ai-select
                  v-model:value="formData.keiyakukbn2"
                  :options="keiyakukbnlist"
                ></ai-select>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">契約状態</th>
              <td>
                <a-space class="flex-wrap">
                  <a-checkbox v-model:checked="formData.sinkiflg"
                    >新規契約者</a-checkbox
                  >
                  <a-checkbox v-model:checked="formData.keizokuflg"
                    >継続契約者</a-checkbox
                  >
                  <a-checkbox v-model:checked="formData.tyusiflg"
                    >中止者</a-checkbox
                  >
                  <a-checkbox v-model:checked="formData.haigyoflg"
                    >廃業者</a-checkbox
                  >
                </a-space>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事業委託先</th>
              <td class="flex">
                <ai-select
                  v-model:value="formData.itakusaki1"
                  :options="selectorlist"
                ></ai-select
                >～<ai-select
                  v-model:value="formData.itakusaki2"
                  :options="selectorlist"
                ></ai-select>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者番号</th>
              <td class="flex">
                <a-input v-model:value="formData.bango1" :xxl="9"></a-input>
                ～
                <a-input v-model:value="formData.bango2" :xxl="9"></a-input>
              </td> </a-col
          ></a-row>
          <a-row class="m-t-1">
            <a-col :span="24">
              <div class="mb-2 header_operation flex justify-between w-full">
                <a-space :size="20">
                  <a-button type="primary" @click="onPreview"
                    >プレビュー</a-button
                  >
                  <a-button type="primary" @click="clear">クリア</a-button>
                </a-space>
                <close-page />
              </div>
            </a-col>
          </a-row>
        </div>
      </div>
      <div id="viewer-host" class="flex-1"></div>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useTabStore } from '@/store/modules/tab'
import dayjs from 'dayjs'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { ReportViewer, Core, PdfExport } from '@grapecity/activereports'
import '@grapecity/activereports/styles/ar-js-ui.css'
import '@grapecity/activereports/styles/ar-js-viewer.css'
import '@grapecity/activereports-localization'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()
const createDefaultParams = () => {
  return {
    taisyoki1: '12',
    taisyoki2: dayjs(new Date().toISOString().split('T')[0]),
    keiyakukbn1: '',
    keiyakukbn2: '',
    itakusaki1: '',
    itakusaki2: '',
    bango1: '',
    bango2: '',
    sinkiflg: true,
    keizokuflg: true,
    tyusiflg: true,
    haigyoflg: true,
  }
}
const formData = reactive(createDefaultParams())
const selectorlist = [
  { value: '1', label: '永さん' },
  { value: '2', label: '尾三' },
  { value: '3', label: '史さん' },
]
const keiyakukbnlist = [
  { value: '1', label: '家族' },
  { value: '2', label: '企業' },
  { value: '3', label: '鶏以外' },
]
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 12,
}
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//
const clear = () => {
  Object.assign(formData, createDefaultParams())
}
//preview
function onPreview() {
  // フォント記述子の定義
  const fonts = [
    { name: 'ＭＳ ゴシック', source: '/fonts/MSGOTHIC.TTF' },
    { name: '游明朝', source: '/fonts/yumin.ttf' },
    { name: '游ゴシック', source: '/fonts/yugothib.ttf' },
    { name: 'IPAゴシック', source: '/fonts/ipaexg.ttf' },
  ]
  const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
  viewer.open('/report/keyakusya.rdlx-json')
  // サイドバーのエクスポート機能を有効化
  viewer.availableExports = ['pdf', 'xlsx', 'html']
  // 定義済みのフォント記述子を登録する
  Core.FontStore.registerFonts(...fonts)
}

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [formData.keiyakukbn1, formData.keiyakukbn2],
  ([newKeiyakukbn1, newKeiyakukbn2], [oldKeiyakukbn1, oldKeiyakukbn2]) => {
    if (newKeiyakukbn1 !== oldKeiyakukbn1) {
      if (newKeiyakukbn1 && !newKeiyakukbn2) {
        formData.keiyakukbn2 = newKeiyakukbn1
      }
    }

    if (newKeiyakukbn2 !== oldKeiyakukbn2) {
      if (newKeiyakukbn2 && !newKeiyakukbn1) {
        formData.keiyakukbn1 = newKeiyakukbn2
      }
    }
  }
)

watch(
  () => [formData.itakusaki1, formData.itakusaki2],
  ([newItakusaki1, newItakusaki2], [oldItakusaki1, oldItakusaki2]) => {
    if (newItakusaki1 !== oldItakusaki1) {
      if (newItakusaki1 && !newItakusaki2) {
        formData.itakusaki2 = newItakusaki1
      }
    }

    if (newItakusaki2 !== oldItakusaki2) {
      if (newItakusaki2 && !newItakusaki1) {
        formData.itakusaki1 = newItakusaki2
      }
    }
  }
)
</script>

<style scoped lang="scss">
th {
  width: 130px;
}
h1 {
  font-size: 24px;
}
:deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
