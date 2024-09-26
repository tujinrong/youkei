<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px staticWidth">
      <div class="max-w-1150px">
        <h1>（GJ2080）生産者積立金等請求・返還一覧表（処理確定・未処理）</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">対象期</th>
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
                  ></a-input-number>
                  <span class="!align-middle"> 期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">請求回数</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SEIKYU_KAISU">
                  <range-number
                    v-model:value="formData.SEIKYU_KAISU"
                    :options="KEIYAKU_KBN_CD_NAME_LIST"
                    width="65"
                    :maxLength="3"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">請求・返還日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SEIKYU_DATE">
                  <range-date
                    v-model:value="formData.SEIKYU_DATE"
                    class="w-full"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">入金・振込日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.NYUKIN_DATE">
                  <range-date
                    v-model:value="formData.NYUKIN_DATE"
                    class="w-full"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>契約区分</th>
              <td class="flex">
                <a-form-item
                  v-bind="validateInfos.KEIYAKU_KBN"
                  style="width: 40%"
                >
                  <range-select
                    v-model:value="formData.KEIYAKU_KBN"
                    :options="KEIYAKU_KBN_CD_NAME_LIST"
                    class="max-w-78"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">請求・返還区分</th>
              <td>
                <a-form-item v-bind="validateInfos.SEIKYU_HENKAN_KBN">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in SEIKYU_HENKAN_KBN_LABELS"
                      :key="key"
                      class="w-35"
                      v-model:checked="formData.SEIKYU_HENKAN_KBN[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">入金・振込状況</th>
              <td>
                <a-form-item v-bind="validateInfos.SYORI_JYOKYO_KBN">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in SYORI_JYOKYO_KBN_LABELS"
                      :key="key"
                      class="w-35"
                      v-model:checked="formData.SYORI_JYOKYO_KBN[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事務委託先</th>
              <td class="flex">
                <a-form-item
                  v-bind="validateInfos.JIMUITAKU_CD"
                  class="max-w-full!"
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
                  class="max-w-full!"
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
                <a-button type="primary">EXCEL出力</a-button>
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

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: -1,
    SEIKYU_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    SEIKYU_DATE: {
      VALUE_FM: undefined as Date | undefined,
      VALUE_TO: undefined as Date | undefined,
    },
    NYUKIN_DATE: {
      VALUE_FM: undefined as Date | undefined,
      VALUE_TO: undefined as Date | undefined,
    },
    KEIYAKU_KBN: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    SEIKYU_HENKAN_KBN: {
      SEIKYU_SHINKI: true,
      ICHIBU_SEIKYU: true,
      ICHIBU_HENKAN: true,
      ZENGAKU_HENKAN: true,
    },
    SYORI_JYOKYO_KBN: {
      NYUKIN_FURIKOMI_ZUMI: true,
      MI_NYUKIN_FURIKOMI: true,
      ICHIBU_NYUKIN: true,
    },
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
const SEIKYU_HENKAN_KBN_LABELS = {
  SEIKYU_SHINKI: '請求(新規)',
  ICHIBU_SEIKYU: '一部請求',
  ICHIBU_HENKAN: '一部返還',
  ZENGAKU_HENKAN: '全額返還',
}
const SYORI_JYOKYO_KBN_LABELS = {
  NYUKIN_FURIKOMI_ZUMI: '入金・振込済',
  MI_NYUKIN_FURIKOMI: '未入金・未振込',
  ICHIBU_NYUKIN: '一部入金',
}

const KEIYAKU_KBN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])

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
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '請求回数')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  SEIKYU_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '請求・返還日'),
    },
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(
          value.VALUE_FM,
          value.VALUE_TO,
          '請求・返還日'
        )
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  NYUKIN_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '入金・振込日'),
    },
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(
          value.VALUE_FM,
          value.VALUE_TO,
          '入金・振込日'
        )
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  KEIYAKU_KBN: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '契約区分')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  SEIKYU_HENKAN_KBN: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '請求・返還区分')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  SYORI_JYOKYO_KBN: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '入金・振込状況')
          )
        }
        return Promise.resolve()
      },
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
  //     formData.KEIYAKU_KBN = clearFromToValue
  //     formData.JIMUITAKU_CD = clearFromToValue
  //     formData.KEIYAKUSYA_CD = clearFromToValue
  //   }
  //   if (initflg) formData.KI = res.KI //対象期
  //   if (initflg) KEIYAKU_KBN_CD_NAME_LIST.value = res.KEIYAKU_KBN_CD_NAME_LIST //契約区分

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
