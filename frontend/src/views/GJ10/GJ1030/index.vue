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
                <a-form-item v-bind="validateInfos.KI">
                  <span class="!align-middle">第</span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    style="width: 120px"
                  ></a-input-number>
                  <span class="!align-middle">期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">対象日(現在)</th>
              <td>
                <a-form-item v-bind="validateInfos.TAISYOBI_YMD">
                  <DateJp
                    v-model:value="formData.TAISYOBI_YMD"
                    class="w-full"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約区分</th>
              <td class="flex">
                <!-- <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD_FM"> -->
                <ai-select
                  v-model:value="formData.KEIYAKU_KBN_CD_FM"
                  split-val
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  type="number"
                ></ai-select>
                <!-- </a-form-item> -->
                ～
                <!-- <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD_TO"> -->
                <ai-select
                  v-model:value="formData.KEIYAKU_KBN_CD_TO"
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  type="number"
                ></ai-select>
                <!-- </a-form-item> -->
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">契約状況</th>
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
                ></ai-select>
                ～
                <ai-select
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
                ></ai-select>
                ～
                <ai-select
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
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, watch, computed, onUnmounted } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { showInfoModal } from '@/utils/modal'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { PreviewRequest } from './type'
import { Form } from 'ant-design-vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
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
const host = window.location.href.includes('localhost')
  ? 'localhost:9527'
  : '61.213.76.155:65534'
const URL = computed(() => {
  return `http://${host}/preview`
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const rules = reactive({
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  TAISYOBI_YMD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
    },
  ],
})

const { validate, validateInfos } = Form.useForm(formData, rules)

function validateSearchParams() {
  let flag = true
  if (
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

  if (flag == true) {
    flag = validateRequiredItemAndRange(
      formData.KEIYAKU_KBN_CD_FM,
      formData.KEIYAKU_KBN_CD_TO,
      '契約区分'
    )
  }
  if (flag == true) {
    flag = validateRequiredItemAndRange(
      formData.ITAKU_CD_FM,
      formData.ITAKU_CD_TO,
      '事務委託先'
    )
  }
  if (flag == true) {
    flag = validateRequiredItemAndRange(
      formData.KEIYAKUSYA_CD_FM,
      formData.KEIYAKUSYA_CD_TO,
      '契約者番号'
    )
  }

  return flag
}

const validateRequiredItemAndRange = (
  from: number | undefined,
  to: number | undefined,
  itemName: string
) => {
  let flag = true
  if (from && !to) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', itemName + 'To'),
    })
    flag = false
  } else if (!from && to) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', itemName + 'From'),
    })
    flag = false
  } else if (from && to) {
    if (from > to) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: '指定された' + itemName + 'の範囲が正しくありません。',
      })
      flag = false
    }
  }
  return flag
}

const clear = () => {
  Object.assign(formData, createDefaultParams())
}

//プレビューボタンを押す時
async function onPreview() {
  const openNew = () => {
    window.open(URL.value, '_blank')
  }
  await validate()
  if (validateSearchParams()) {
    openNew()
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

//-----------------------------------------------------
const channel = new BroadcastChannel('channel_preview')
channel.onmessage = (event) => {
  if (event.data.isMounted) {
    channel.postMessage({ xxx: 'Hello, World!' })
  }
}
onUnmounted(() => {
  channel.close()
})
//-----------------------------------------------------
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
:deep(.ant-form-item) {
  margin-bottom: 0;
  width: 100%;
}
</style>
