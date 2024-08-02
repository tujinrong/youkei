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
                <span class="mt-1">第</span>
                <a-input-number
                  v-model:value="formData.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  style="width: 120px"
                ></a-input-number>
                <span class="mt-1">期</span>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">対象日(現在)</th>
              <td>
                <DateJp v-model:value="formData.TAISYOBI_YMD" class="w-full" />
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約区分</th>
              <td class="flex">
                <ai-select
                  v-model:value="formData.KEIYAKU_KBN_CD_FM"
                  split-val
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  type="number"
                ></ai-select
                >～<ai-select
                  v-model:value="formData.KEIYAKU_KBN_CD_TO"
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  type="number"
                ></ai-select>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">契約状態</th>
              <td>
                <a-space class="flex-wrap">
                  <a-checkbox v-model:checked="formData.KEIYAKU_JYOKYO_SHINKI"
                    >新規契約者</a-checkbox
                  >
                  <a-checkbox v-model:checked="formData.KEIYAKU_JYOKYO_KEIZOKU"
                    >継続契約者</a-checkbox
                  >
                  <a-checkbox v-model:checked="formData.KEIYAKU_JYOKYO_CHUSHI"
                    >中止者</a-checkbox
                  >
                  <a-checkbox v-model:checked="formData.KEIYAKU_JYOKYO_HAIGYO"
                    >廃業者</a-checkbox
                  >
                </a-space>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事業委託先</th>
              <td class="flex">
                <ai-select
                  v-model:value="formData.ITAKU_CD_FM"
                  :options="ITAKU_CD_NAME_LIST"
                  type="number"
                ></ai-select
                >～<ai-select
                  v-model:value="formData.ITAKU_CD_TO"
                  :options="ITAKU_CD_NAME_LIST"
                  type="number"
                ></ai-select>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者番号</th>
              <td class="flex">
                <ai-select
                  v-model:value="formData.KEIYAKUSYA_CD_FM"
                  :options="KEIYAKUSYA_CD_NAME_LIST"
                  type="number"
                ></ai-select
                >～<ai-select
                  v-model:value="formData.KEIYAKUSYA_CD_TO"
                  :options="KEIYAKUSYA_CD_NAME_LIST"
                  type="number"
                ></ai-select>
              </td>
            </a-col>
          </a-row>
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
import DateJp from '@/components/Selector/DateJp/index.vue'
import { ReportViewer, Core } from '@grapecity/activereports'
import '@grapecity/activereports/styles/ar-js-ui.css'
import '@grapecity/activereports/styles/ar-js-viewer.css'
import '@grapecity/activereports-localization'
import { showInfoModal } from '@/utils/modal'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { PreviewRequest } from './type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()

const createDefaultParams = (): PreviewRequest => {
  return {
    KI: 8,
    TAISYOBI_YMD: new Date().toISOString().split('T')[0],
    KEIYAKU_KBN_CD_FM: undefined,
    KEIYAKU_KBN_CD_TO: undefined,
    KEIYAKU_JYOKYO_SHINKI: true,
    KEIYAKU_JYOKYO_KEIZOKU: true,
    KEIYAKU_JYOKYO_CHUSHI: true,
    KEIYAKU_JYOKYO_HAIGYO: true,
    ITAKU_CD_FM: undefined,
    ITAKU_CD_TO: undefined,
    KEIYAKUSYA_CD_FM: undefined,
    KEIYAKUSYA_CD_TO: undefined,
  } as PreviewRequest
}

const formData = reactive(createDefaultParams())

const KEIYAKU_KBN_CD_NAME_LIST = ref<DaSelectorModel[]>([
  { value: 1, label: '家族' },
  { value: 2, label: '企業' },
  { value: 3, label: '鶏以外' },
])

const ITAKU_CD_NAME_LIST = ref<DaSelectorModel[]>([
  { value: 1, label: '永玉さん' },
  { value: 2, label: '尾三さん' },
  { value: 3, label: '史玉さん' },
])

const KEIYAKUSYA_CD_NAME_LIST = ref<DaSelectorModel[]>([
  { value: 1, label: '田中さん' },
  { value: 2, label: '玉田さん' },
  { value: 3, label: '浅海さん' },
])

const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 12,
}
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function validateSearchParams() {
  let flag = true
  if (!formData.KI) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    })
    flag = false
  } else if (!formData.TAISYOBI_YMD) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
    })
    flag = false
  } else if (
    !formData.KEIYAKU_JYOKYO_SHINKI &&
    !formData.KEIYAKU_JYOKYO_KEIZOKU &&
    !formData.KEIYAKU_JYOKYO_CHUSHI &&
    !formData.KEIYAKU_JYOKYO_HAIGYO
  ) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約状況'),
    })
    flag = false
  }
  return flag
}

const clear = () => {
  Object.assign(formData, createDefaultParams())
}

//プレビューボタンを押す時
function onPreview() {
  const openNew = () => {
    const width = 1600
    const height = 900
    const left = window.screen.width / 2 - width / 2
    const top = window.screen.height / 2 - height / 2
    const features = `width=${width},height=${height},left=${left},top=${top},toolbar=no,menubar=no,location=no,status=no`
    const host = window.location.href.includes('localhost')
      ? 'localhost:9527'
      : '61.213.76.155:65534'

    window.open(`http://${host}/preview`, '_blank', features)
  }
  if (validateSearchParams()) {
    openNew()
    // // フォント記述子の定義
    // const fonts = [
    //   { name: 'ＭＳ ゴシック', source: '/fonts/MSGOTHIC.TTF' },
    //   { name: '游明朝', source: '/fonts/yumin.ttf' },
    //   { name: '游ゴシック', source: '/fonts/yugothib.ttf' },
    //   { name: 'IPAゴシック', source: '/fonts/ipaexg.ttf' },
    //   { name: 'Arial', source: '/fonts/Arial.ttf' },
    //   { name: 'Arial Italic', source: '/fonts/Arialbi.ttf' },
    //   { name: 'Arial Bold', source: '/fonts/Arialbd.ttf' },
    //   { name: 'Arial Bold Italic', source: '/fonts/Arialbi.ttf' },
    //   { name: 'Arial Black', source: '/fonts/Ariblk.ttf' },
    // ]
    // const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
    // viewer.open('/report/keyakusya.rdlx-json')
    // // サイドバーのエクスポート機能を有効化
    // viewer.availableExports = ['pdf', 'xlsx', 'html']
    // // 定義済みのフォント記述子を登録する
    // Core.FontStore.registerFonts(...fonts)
  }
}

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//契約者区分、事業委託先及び契約番号の値が変った時の処理
watch(
  () => [
    formData.KEIYAKU_KBN_CD_FM,
    formData.KEIYAKU_KBN_CD_TO,
    formData.ITAKU_CD_FM,
    formData.ITAKU_CD_TO,
    formData.KEIYAKUSYA_CD_FM,
    formData.KEIYAKUSYA_CD_TO,
  ],
  (
    [
      newKeiyakuKbnCdFm,
      newKeiyakuKbnCdTo,
      newItakuCdFm,
      newItakuCdTo,
      newKeiyakusyaCdFm,
      newKeiyakusyaCdTo,
    ],
    [
      oldKeiyakuKbnCdFm,
      oldKeiyakuKbnCdTo,
      oldItakuCdFm,
      oldItakuCdTo,
      oldKeiyakusyaCdFm,
      oldKeiyakusyaCdTo,
    ]
  ) => {
    if (newKeiyakuKbnCdFm !== oldKeiyakuKbnCdFm) {
      if (newKeiyakuKbnCdFm && !newKeiyakuKbnCdTo) {
        formData.KEIYAKU_KBN_CD_TO = newKeiyakuKbnCdFm
      }
    }
    if (newKeiyakuKbnCdTo !== oldKeiyakuKbnCdTo) {
      if (newKeiyakuKbnCdTo && !newKeiyakuKbnCdFm) {
        formData.KEIYAKU_KBN_CD_FM = newKeiyakuKbnCdTo
      }
    }
    if (newItakuCdFm !== oldItakuCdFm) {
      if (newItakuCdFm && !newItakuCdTo) {
        formData.ITAKU_CD_TO = newItakuCdFm
      }
    }
    if (newItakuCdTo !== oldItakuCdTo) {
      if (newItakuCdTo && !newItakuCdFm) {
        formData.ITAKU_CD_FM = newItakuCdTo
      }
    }
    if (newKeiyakusyaCdFm !== oldKeiyakusyaCdFm) {
      if (newKeiyakusyaCdFm && !newKeiyakusyaCdTo) {
        formData.KEIYAKUSYA_CD_TO = newKeiyakusyaCdFm
      }
    }
    if (newKeiyakusyaCdTo !== oldKeiyakusyaCdTo) {
      if (newKeiyakusyaCdTo && !newKeiyakusyaCdFm) {
        formData.KEIYAKUSYA_CD_FM = newKeiyakusyaCdTo
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
