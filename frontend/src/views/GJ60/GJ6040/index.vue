<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px">
      <div>
        <h1>（GJ6040）積立金返還金振込データ作成(全銀手順)</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">対象期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI" class="w-50!">
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-14"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">請求・返還回数</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SEIKYU_KAISU">
                  <a-input-number
                    v-model:value="formData.SEIKYU_KAISU"
                    :min="1"
                    :max="99"
                    :maxlength="3"
                    class="w-15"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">振込予定日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.FURIKOMI_YOTEI_DATE">
                  <DateJp
                    v-model:value="formData.FURIKOMI_YOTEI_DATE"
                    class="max-w-50"
                  />
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row class="m-t-1">
            <a-col :span="24">
              <div class="mb-2 header_operation flex justify-between w-full">
                <a-space :size="20">
                  <a-button type="primary" @click="onPreview">実行</a-button>
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
import { reactive, onMounted, onUnmounted } from 'vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { Preview } from './service'
import { PreviewRequest } from './type'
import DateJp from '@/components/Selector/DateJp/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: 8,
    SEIKYU_KAISU: undefined,
    FURIKOMI_YOTEI_DATE: new Date().toISOString().split('T')[0],
  }
}
const formData = reactive(createDefaultParams() as PreviewRequest)
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}

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
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '請求・返還回数'),
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

const clear = () => {
  Object.assign(formData, createDefaultParams())
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
  width: 150px;
}

:deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
