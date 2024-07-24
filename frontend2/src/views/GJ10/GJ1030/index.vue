<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px">
      <div>
        <h1>契約者一覧表(連絡用)</h1>

        <a-descriptions
          bordered
          :column="{ xxl: 2, xl: 2, lg: 2, md: 1, sm: 1, xs: 1 }"
          size="small"
          class="my-2"
        >
          <a-descriptions-item label="対象期">
            <div class="flex items-center gap-1">
              第
              <a-input-number
                v-model:value="formData.taisyoki1"
                :maxlength="3"
                style="width: 120px"
              ></a-input-number>
              期
            </div>
          </a-descriptions-item>
          <a-descriptions-item label="対象期(現在)"
            ><DateJp v-model:value="formData.taisyoki2"
          /></a-descriptions-item>
          <a-descriptions-item label="契約区分">
            <div class="flex items-center">
              <a-select
                v-model:value="formData.keiyakukbn1"
                :options="keiyakukbnlist"
                class="flex-1"
              ></a-select
              >～<a-select
                v-model:value="formData.keiyakukbn2"
                :options="keiyakukbnlist"
                class="flex-1"
              ></a-select>
            </div>
          </a-descriptions-item>
          <a-descriptions-item label="契約状態">
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
            </a-space></a-descriptions-item
          >
          <a-descriptions-item label="事業委託先">
            <div class="flex items-center min-w-60">
              <a-select
                v-model:value="formData.itakusaki1"
                :options="selectorlist"
                class="flex-1"
              ></a-select
              >～<a-select
                v-model:value="formData.itakusaki2"
                :options="selectorlist"
                class="flex-1"
              ></a-select>
            </div>
          </a-descriptions-item>
          <a-descriptions-item label="契約者番号">
            <td class="flex items-center">
              <a-input v-model:value="formData.bango1"></a-input>
              ～
              <a-input v-model:value="formData.bango2"></a-input></td
          ></a-descriptions-item>
        </a-descriptions>

        <div class="my-2 flex justify-between">
          <a-space :size="20">
            <a-button type="primary" @click="onPreview">プレビュー</a-button>
            <a-button type="primary" @click="cancel">キャンセル</a-button>
          </a-space>
          <AButton
            type="primary"
            class="ml-a"
            @click="tabStore.removeActiveTab"
          >
            閉じる
          </AButton>
        </div>
      </div>

      <div id="viewer-host" class="flex-1"></div>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useTabStore } from '@/store/modules/tab'
import dayjs from 'dayjs'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { ReportViewer, Core, PdfExport } from '@grapecity/activereports'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()
const createDefaultParams = () => {
  return {
    taisyoki1: '12',
    taisyoki2: dayjs('2024-07-02'),
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
const previewVisible = ref(false)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//
const cancel = () => {
  Object.assign(formData, createDefaultParams())
}
//preview
function onPreview() {
  //previewVisible.value = true
  const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
  viewer.open('/report/keyakusya.rdlx-json')
}
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
