<template>
  <div>
    <a-card :bordered="false" class="h-440px min-h-440px staticWidth">
      <div class="max-w-1150px">
        <h1>
          （GJ2050）家畜防疫互助基金積立金等請求書兼返還金通知書（一部返還）
        </h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col span="24">
              <th>出力区分</th>
              <td>
                <a-form-item v-bind="validateInfos.SYUTURYOKU_KBN">
                  <a-radio-group
                    v-model:value="formData.SYUTURYOKU_KBN"
                    class="mt-1"
                  >
                    <a-radio :value="1">仮発行</a-radio>
                    <a-radio :value="2">初回発行</a-radio>
                    <a-radio :value="3">再発行(初回と同内容)</a-radio>
                    <a-radio :value="4">
                      修正発行(納付期限、発行日、発信番号変更可能)
                    </a-radio>
                  </a-radio-group>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <span class="!align-middle">第 </span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-14!"
                    @change="handleKI(false)"
                  />
                  <span class="!align-middle"> 期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">請求(返還)回数</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SEIKYU_KAISU">
                  <a-input-number
                    v-model:value="formData.SEIKYU_KAISU"
                    :min="0"
                    :max="999"
                    :maxlength="3"
                    class="w-15"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">請求年月日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SEIKYU_DATE">
                  <DateJp v-model:value="formData.SEIKYU_DATE" disabled />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">納付期限</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.NOFUKIGEN_DATE">
                  <DateJp
                    v-model:value="formData.NOFUKIGEN_DATE"
                    :disabled="
                      formData.SYUTURYOKU_KBN === 1 ||
                      formData.SYUTURYOKU_KBN === 3
                    "
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">発行日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SEIKYU_HAKKO_DATE">
                  <DateJp
                    v-model:value="formData.SEIKYU_HAKKO_DATE"
                    :disabled="
                      formData.SYUTURYOKU_KBN === 1 ||
                      formData.SYUTURYOKU_KBN === 3
                    "
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">発信番号</th>
              <td>
                <a-form-item v-bind="validateInfos.KI" class="w-35!">
                  <span class="!align-middle">日鶏 </span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="0"
                    :max="99"
                    :maxlength="2"
                    :disabled="
                      formData.SYUTURYOKU_KBN === 1 ||
                      formData.SYUTURYOKU_KBN === 3
                    "
                    class="w-14!"
                  />
                  <span class="!align-middle"> 発</span>
                </a-form-item>
                <a-form-item v-bind="validateInfos.KI" class="w-50!">
                  <span class="!align-middle">第 </span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="0"
                    :max="9999"
                    :maxlength="4"
                    :disabled="
                      formData.SYUTURYOKU_KBN === 1 ||
                      formData.SYUTURYOKU_KBN === 3
                    "
                    class="w-17!"
                  />

                  <span class="!align-middle"> 号</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事務委託先</th>
              <td class="flex">
                <a-form-item
                  v-bind="validateInfos.JIMUITAKU_CD"
                  class="w-full!"
                >
                  <range-select
                    v-model:value="formData.JIMUITAKU_CD"
                    :options="ITAKU_CD_NAME_LIST"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者番号</th>
              <td class="flex">
                <a-form-item
                  v-bind="validateInfos.KEIYAKUSYA_CD"
                  class="w-full!"
                >
                  <range-select
                    v-model:value="formData.KEIYAKUSYA_CD"
                    :options="KEIYAKUSYA_CD_NAME_LIST"
                /></a-form-item>
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
              <EndButton />
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
    KI: 8,
    SEIKYU_KAISU: undefined,
    SEIKYU_DATE: new Date().toISOString().split('T')[0],
    NOFUKIGEN_DATE: new Date().toISOString().split('T')[0],
    SEIKYU_HAKKO_DATE: new Date().toISOString().split('T')[0],
    SYUTURYOKU_KBN: 1,
    JIMUITAKU_CD: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEIYAKUSYA_CD: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
  }
}
const formData = reactive(createDefaultParams() as PreviewRequest)
const clearFromToValue = {
  VALUE_FM: undefined,
  VALUE_TO: undefined,
}

const ITAKU_CD_NAME_LIST = ref<CmCodeNameModel[]>([])

const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([])

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
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  SEIKYU_KAISU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '請求回数'),
    },
  ],
  SEIKYU_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '請求・返還日'),
    },
  ],
  JIMUITAKU_CD: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '事務委託先')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  KEIYAKUSYA_CD: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '契約者番号')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
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
  // Init({ KI: formData.KI }).then((res) => {
  //   if (!initflg) {
  //     formData.JIMUITAKU_CD = clearFromToValue
  //     formData.KEIYAKUSYA_CD = clearFromToValue
  //   }
  //   if (initflg) formData.KI = res.KI //対象期

  //   ITAKU_CD_NAME_LIST.value = res.ITAKU_CD_NAME_LIST //事務委託先
  //   KEIYAKUSYA_CD_NAME_LIST.value = res.KEIYAKUSYA_CD_NAME_LIST //契約者番号
  // })
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
  width: 130px;
}

:deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
