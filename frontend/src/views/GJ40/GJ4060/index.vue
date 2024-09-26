<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px staticWidth">
      <div class="max-w-800px">
        <h1>（GJ4060）互助金交付金融融機関別振込明細表</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">出力区分</th>
              <td>
                <a-form-item v-bind="validateInfos.SYUTURYOKU_KBN">
                  <a-radio-group
                    v-model:value="formData.SYUTURYOKU_KBN"
                    class="mt-1"
                  >
                    <a-radio :value="1">初回発行</a-radio>
                    <a-radio :value="2">修正発行</a-radio>
                  </a-radio-group>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">対象データ</th>
              <td>
                <a-form-item v-bind="validateInfos.TAISYO_DATA">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in TAISYO_DATA_LABELS"
                      :key="key"
                      v-model:checked="formData.TAISYO_DATA[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
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
                    class="w-14"
                  />
                  <span class="!align-middle">期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">認定回数</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.HASSEI_KAISU">
                  <range-number
                    v-model:value="formData.HASSEI_KAISU"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="max-w-34"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">計算回数</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEISAN_KAISU">
                  <range-number
                    v-model:value="formData.KEISAN_KAISU"
                    :min="1"
                    :max="999"
                    :maxlength="3"
                    class="max-w-36"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">振込予定日</th>
              <td class="flex items-center">
                <a-form-item v-bind="validateInfos.FURIKOMI_YOTEI_DATE">
                  <DateJp
                    class="max-w-50"
                    v-model:value="formData.FURIKOMI_YOTEI_DATE"
                  />
                  <span>(振込明細表に印字する日を入力)</span>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
      </div>
      <div>
        <a-row class="m-t-1">
          <a-col :span="24">
            <div class="mb-2 header_operation flex justify-between w-full">
              <a-space :size="20">
                <a-button type="primary" @click="onPreview"
                  >プレビュー</a-button
                >
                <a-button type="primary" @click="clear">キャンセル</a-button>
              </a-space>
              <close-page />
            </div>
          </a-col>
        </a-row>
      </div>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, computed, onMounted, onUnmounted } from 'vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { Init, Preview } from './service'
import { PreviewRequest } from './type'
import DateJp from '@/components/Selector/DateJp/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    SYUTURYOKU_KBN: 1,
    /**対象データ */
    TAISYO_DATA: {
      ITIBU_HENKAN: false,
      ZENGAKU_HENKAN: false,
      GOJYOKIN_SHIHARAI: false,
    },
    KI: 8,
    HASSEI_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEISAN_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    FURIKOMI_YOTEI_DATE: undefined as Date | undefined,
  }
}
const formData = reactive(createDefaultParams() as PreviewRequest)
const clearFromToValue = {
  VALUE_FM: undefined,
  VALUE_TO: undefined,
}

const TAISYO_DATA_LABELS = {
  ITIBU_HENKAN: '一部返還（積立金）',
  ZENGAKU_HENKAN: '全額返還（未継続者）',
  GOJYOKIN_SHIHARAI: '互助金支払（返還と同時は不可）',
}

const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const host = window.location.href.includes('localhost')
  ? 'localhost:9527'
  : '61.213.76.155:65534'
const URL = computed(() => {
  return `http://${host}/preview`
})

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  // handleKI(true)
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const rules = reactive({
  SYUTURYOKU_KBN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '出力区分'),
    },
  ],
  TAISYO_DATA: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象データ'),
    },
  ],
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  HASSEI_KAISU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '認定回数'),
    },
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '認定回数')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  KEISAN_KAISU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '計算回数'),
    },
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '計算回数')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  FURIKOMI_YOTEI_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '振込予定日'),
    },
  ],
})

const { validate, validateInfos } = Form.useForm(formData, rules)

const rangeCheck = (from: number, to: number, itemName: string) => {
  let result = { flag: true, content: '' }
  if (from && !to) {
    result.flag = false
    result.content = ITEM_REQUIRE_ERROR.Msg.replace('{0}', itemName + 'To')
  }
  if (!from && to) {
    result.flag = false
    result.content = ITEM_REQUIRE_ERROR.Msg.replace('{0}', itemName + 'From')
  }
  if (from > to) {
    result.flag = false
    result.content = '指定された' + itemName + 'の範囲が正しくありません。'
  }
  return result
}

const handleKI = (initflg: boolean) => {
  if (!formData.KI && formData.KI !== 0) return
  Init({ KI: formData.KI }).then((res) => {
    if (!initflg) {
      formData.KEIYAKU_KBN = clearFromToValue
      formData.JIMUITAKU_CD = clearFromToValue
      formData.KEIYAKUSYA_CD = clearFromToValue
    }
    if (initflg) formData.KI = res.KI //対象期
  })
}
const clear = () => {
  Object.assign(formData, createDefaultParams())
  handleKI(true)
}

//プレビューボタンを押す時
async function onPreview() {
  await validate()
  try {
    await Preview({ ...formData })
    const openNew = () => {
      window.open(URL.value, '_blank')
    }
    openNew()
  } catch (error) {}
}

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//-----------------------------------------------------
const channel = new BroadcastChannel('channel_preview')
channel.onmessage = (event) => {
  if (event.data.isMounted) {
    channel.postMessage({ params: JSON.stringify(formData) })
  }
}
onUnmounted(() => {
  channel.close()
})
//-----------------------------------------------------
</script>

<style scoped lang="scss">
th {
  width: 140px;
}

:deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
