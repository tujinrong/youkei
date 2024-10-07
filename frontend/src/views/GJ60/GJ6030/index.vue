<template>
  <div>
    <a-card :bordered="false" class="h-290px min-h-290px staticWidth">
      <div class="max-w-800px">
        <h1>（GJ6030）各種マスタの次期対応コピー処理</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">マスタ選択</th>
              <td>
                <a-form-item v-bind="validateInfos.MASUTA_SENTAKU">
                  <ai-select
                    v-model:value="formData.MASUTA_SENTAKU"
                    :options="MASUTA_SENTAKU_LIST"
                    split-val
                    class="w-80!"
                  />
                  <!--                  <a-input-number
                    v-model:value="formData.MASUTA_SENTAKU"
                    :min="1"
                    :max="3"
                    class="w-14"
                  />
                  <span class="!align-middle ml-2"
                    >1: 事務委託先マスタコピー処理&nbsp;&nbsp;2:
                    契約者マスタコピー処理&nbsp;&nbsp;3:
                    農場マスタコピー処理</span
                  >-->
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                th="対象期（前期）"
                :td="formData.KI"
                before="第"
                after="期"
              />
              <!--              <th class="required">対象期(前期)</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <span class="!align-middle">第</span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-20"
                    @change="handleKI(false)"
                  />
                  <span class="!align-middle">期</span>
                </a-form-item>
              </td>-->
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                :th="
                  '事務委託先マスタ処理件数（' +
                  String(formData.KI + 1) +
                  '期）'
                "
                :td="formData.JIMUITAKU_KENSU"
              />
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                :th="
                  '契約者マスタ処理件数（' + String(formData.KI + 1) + '期）'
                "
                :td="formData.KEIYAKUSYA_KENSU"
              />
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                :th="'農場マスタ処理件数（' + String(formData.KI + 1) + '期）'"
                :td="formData.NOJO_KENSU"
              />
            </a-col>
          </a-row>
        </div>
      </div>
      <div>
        <a-row class="m-t-1">
          <a-col :span="24">
            <div class="mb-2 header_operation flex justify-between w-full">
              <a-space :size="20">
                <a-button type="primary" @click="onPreview">実行</a-button>
                <a-button type="primary" @click="clear">キャンセル</a-button>
              </a-space>
              <CloseButton />
            </div>
          </a-col>
        </a-row>
      </div>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { reactive, computed, onMounted, onUnmounted, ref } from 'vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { Init, Preview } from './service'
import { PreviewRequest } from './type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: 8,
    MASUTA_SENTAKU: 1,
  }
}
const formData = reactive(createDefaultParams() as PreviewRequest)
const MASUTA_SENTAKU_LIST = ref<CmCodeNameModel[]>([
  { CODE: 1, NAME: '事務委託先マスタコピー処理' },
  { CODE: 2, NAME: '契約者マスタコピー処理' },
  { CODE: 3, NAME: '農場マスタコピー処理' },
])

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
  MASUTA_SENTAKU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'マスタ選択'),
    },
  ],
})

const { validate, validateInfos } = Form.useForm(formData, rules)

const handleKI = (initflg: boolean) => {
  if (!formData.KI && formData.KI !== 0) return
  Init({ KI: formData.KI }).then((res) => {
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
  width: 230px;
}

:deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
