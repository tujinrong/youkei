<template>
  <div>
    <a-card
      :bordered="false"
      class="h-330px min-h-330px staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
      <div class="max-w-1150px">
        <h1>（GJ1030）契約者一覧表（連絡用）</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
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
                    class="w-14"
                    @change="handleKI(false)"
                  ></a-input-number>
                  <span class="!align-middle"> 期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">対象日(現在)</th>
              <td>
                <a-form-item v-bind="validateInfos.TAISYOBI_YMD">
                  <DateJp
                    v-model:value="formData.TAISYOBI_YMD"
                    class="max-w-50"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約区分</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD">
                  <range-select
                    v-model:value="formData.KEIYAKU_KBN_CD"
                    :options="KEIYAKU_KBN_CD_NAME_LIST"
                    class="max-w-78"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">契約状況</th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_JYOKYO">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in KEIYAKU_JYOKYO_LABELS"
                      :key="key"
                      v-model:checked="formData.KEIYAKU_JYOKYO[key]"
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
                <a-form-item v-bind="validateInfos.ITAKU_CD">
                  <range-select
                    v-model:value="formData.ITAKU_CD"
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
import { reactive, ref, watch, computed, onMounted, onUnmounted } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { Init, Preview } from './service'
import { PreviewRequest } from './type'
import { openNew } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: 8,
    TAISYOBI_YMD: new Date().toISOString().split('T')[0],
    KEIYAKU_KBN_CD: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEIYAKU_JYOKYO: {
      SHINKI: true,
      KEIZOKU: true,
      CHUSHI: true,
      HAIGYO: true,
    },
    ITAKU_CD: {
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
const KEIYAKU_JYOKYO_LABELS = {
  SHINKI: '新規契約者',
  KEIZOKU: '継続契約者',
  CHUSHI: '中止者',
  HAIGYO: '廃業者',
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
  handleKI(true)
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
  KEIYAKU_KBN_CD: [
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
  KEIYAKU_JYOKYO: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約状況')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  ITAKU_CD: [
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
  TAISYOBI_YMD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
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
      formData.KEIYAKU_KBN_CD = clearFromToValue
      formData.ITAKU_CD = clearFromToValue
      formData.KEIYAKUSYA_CD = clearFromToValue
    }
    if (initflg) {
      formData.KI = res.KI //対象期
      KEIYAKU_KBN_CD_NAME_LIST.value = res.KEIYAKU_KBN_CD_NAME_LIST //契約区分
    }
    ITAKU_CD_NAME_LIST.value = res.ITAKU_CD_NAME_LIST //事務委託先
    KEIYAKUSYA_CD_NAME_LIST.value = res.KEIYAKUSYA_CD_NAME_LIST //契約者番号
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
    openNew(formData, 'S1030')
  } catch (error) {}
}

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

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
