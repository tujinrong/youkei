<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px staticWidth">
      <div>
        <h1>（GJ4020）互助金申請情報入力チェックリスト</h1>
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
                    class="w-14"
                    @change="handleKI(false)"
                  ></a-input-number>
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
                    :options="KEIYAKU_KBN_CD_NAME_LIST"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約区分</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN">
                  <range-select
                    v-model:value="formData.KEIYAKU_KBN"
                    :options="KEIYAKU_KBN_CD_NAME_LIST"
                    class="max-w-78"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">互助金の種類</th>
              <td>
                <a-form-item v-bind="validateInfos.GOJYOKIN_SYURUI">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in GOJYOKIN_SYURUI_LABELS"
                      :key="key"
                      v-model:checked="formData.GOJYOKIN_SYURUI[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">入力状況</th>
              <td>
                <a-form-item v-bind="validateInfos.NYURYOKU_JYOKYO">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in NYURYOKU_JYOKYO_LABELS"
                      :key="key"
                      v-model:checked="formData.NYURYOKU_JYOKYO[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">家伝法違反減額率</th>
              <td>
                <a-form-item v-bind="validateInfos.GENGAKU_RITU">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in GENGAKU_RITU_LABELS"
                      :key="key"
                      v-model:checked="formData.GENGAKU_RITU[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>都道府県</th>
              <td>
                <a-form-item v-bind="validateInfos.KEN_CD">
                  <range-select
                    v-model:value="formData.KEN_CD"
                    :options="KEN_CD_NAME_LIST"
                    class="w-90!"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事務委託先</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.JIMUITAKU_CD">
                  <range-select
                    v-model:value="formData.JIMUITAKU_CD"
                    :options="ITAKU_CD_NAME_LIST"
                    class="max-w-250!"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者番号</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                  <range-select
                    v-model:value="formData.KEIYAKUSYA_CD"
                    :options="KEIYAKUSYA_CD_NAME_LIST"
                    class="max-w-250!"
                /></a-form-item>
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
                  <a-button type="primary" @click="clear">キャンセル</a-button>
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
    HASSEI_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEIYAKU_KBN: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    GOJYOKIN_SYURUI: {
      KEIEISIEN: true,
      SYOKYAKU: true,
    },
    NYURYOKU_JYOKYO: {
      NYURYOKU_TYU: true,
      SHINSATSU_TYU: true,
      KOFU_KAKUTEI: true,
    },
    GENGAKU_RITU: {
      SETTEI_ARI: true,
      SETTEI_NASI: true,
    },
    KEN_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
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
const GOJYOKIN_SYURUI_LABELS = {
  KEIEISIEN: '経営支援互助金',
  SYOKYAKU: '焼却・埋却互助金',
}
const NYURYOKU_JYOKYO_LABELS = {
  NYURYOKU_TYU: '入力中',
  SHINSATSU_TYU: '審査中',
  KOFU_KAKUTEI: '交付確定',
}
const GENGAKU_RITU_LABELS = {
  SETTEI_ARI: '設定あり',
  SETTEI_NASI: '設定なし',
}
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])

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
  GOJYOKIN_SYURUI: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '互助金の種類')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  NYURYOKU_JYOKYO: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '入力状況')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  GENGAKU_RITU: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '家伝法違反減額率')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  KEN_CD: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '都道府県')
        if (!result.flag) return Promise.reject(result.content)
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

  //   KEN_CD_NAME_LIST.value = res.KEN_CD_NAME_LIST //事務委託先
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
  width: 140px;
}

:deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
