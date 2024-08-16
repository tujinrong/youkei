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
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD">
                  <range-select
                    v-model:value="formData.KEIYAKU_KBN_CD"
                    :options="KEIYAKU_KBN_CD_NAME_LIST"
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
              <th>事業委託先</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.ITAKU_CD">
                  <range-select
                    v-model:value="formData.ITAKU_CD"
                    :options="ITAKU_CD_NAME_LIST"
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
import { Form } from 'ant-design-vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: 8,
    TAISYOBI_YMD: new Date().toISOString().split('T')[0],
    KEIYAKU_KBN_CD: {
      FROM: undefined,
      TO: undefined,
    },
    KEIYAKU_JYOKYO: {
      SHINKI: true,
      KEIZOKU: true,
      CHUSHI: true,
      HAIGYO: true,
    },
    ITAKU_CD: {
      FROM: undefined,
      TO: undefined,
    },
    KEIYAKUSYA_CD: {
      FROM: undefined,
      TO: undefined,
    },
  }
}
const formData = reactive(createDefaultParams())

const KEIYAKU_JYOKYO_LABELS = {
  SHINKI: '新規契約者',
  KEIZOKU: '継続契約者',
  CHUSHI: '中止者',
  HAIGYO: '廃業者',
}

const KEIYAKU_KBN_CD_NAME_LIST = ref<CodeNameModel[]>([
  { CODE: 1, NAME: '家族' },
  { CODE: 2, NAME: '企業' },
  { CODE: 3, NAME: '鶏以外' },
])

const ITAKU_CD_NAME_LIST = ref<CodeNameModel[]>([
  { CODE: 1, NAME: '永玉さん' },
  { CODE: 2, NAME: '尾三さん' },
  { CODE: 3, NAME: '史玉さん' },
])

const KEIYAKUSYA_CD_NAME_LIST = ref<CodeNameModel[]>([
  { CODE: 1, NAME: '田中さん' },
  { CODE: 2, NAME: '玉田さん' },
  { CODE: 3, NAME: '浅海さん' },
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
  KEIYAKU_KBN_CD: [
    {
      validator: (
        _rule,
        value: {
          FROM
          TO
        }
      ) => {
        const result = rangeCheck(value.FROM, value.TO, '契約区分')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  ITAKU_CD: [
    {
      validator: (
        _rule,
        value: {
          FROM
          TO
        }
      ) => {
        const result = rangeCheck(value.FROM, value.TO, '事業委託先')
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
          FROM
          TO
        }
      ) => {
        const result = rangeCheck(value.FROM, value.TO, '契約者番号')
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

const clear = () => {
  Object.assign(formData, createDefaultParams())
}

//プレビューボタンを押す時
async function onPreview() {
  await validate()
  const openNew = () => {
    window.open(URL.value, '_blank')
  }
  openNew()
}

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

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
