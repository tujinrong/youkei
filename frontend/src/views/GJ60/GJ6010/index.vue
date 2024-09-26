<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px staticWidth">
      <div class="max-w-800px">
        <h1>（GJ6010）生産者積立金返還金計算処理</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">処理選択</th>
              <td>
                <a-form-item v-bind="validateInfos.SYORI_SENTAKU">
                  <ai-select
                    v-model:value="formData.SYORI_SENTAKU"
                    :options="SYORI_SENTAKU_LIST"
                    split-val
                    class="w-80!"
                  />
                  <!--                  <a-input-number-->
                  <!--                    v-model:value="formData.SYORI_SENTAKU"-->
                  <!--                    :min="1"-->
                  <!--                    :max="3"-->
                  <!--                    class="w-20"-->
                  <!--                  />-->
                  <!--                  <span class="!align-middle ml-2">1: 積立金納付額取込処理&nbsp;&nbsp;2: 互助金交付額取込&nbsp;&nbsp;3: 繰越額算定処理</span>-->
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
              <th class="required">１:前期積立金納付額取込処理</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SYORI_TYPE">
                  <a-radio-group v-model:value="formData.SYORI_TYPE">
                    <a-radio :value="1">取込処理（未処理）</a-radio>
                    <a-radio :value="2"
                      >取込処理済（{{ formData.ZENKI_TUMITATE_DATE }}）</a-radio
                    >
                    <a-radio :value="3">処理キャンセル</a-radio>
                  </a-radio-group>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">２:前期互助金交付額取込処理</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SYORI_TYPE">
                  <a-radio-group v-model:value="formData.SYORI_TYPE">
                    <a-radio :value="1">取込処理（未処理）</a-radio>
                    <a-radio :value="2"
                      >取込処理済（{{ formData.ZENKI_KOFU_DATE }}）</a-radio
                    >
                    <a-radio :value="3">処理キャンセル</a-radio>
                  </a-radio-group>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">３:前期積立金繰越額算定処理</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SYORI_TYPE">
                  <a-radio-group v-model:value="formData.SYORI_TYPE">
                    <a-radio :value="1">取込処理（未処理）</a-radio>
                    <a-radio :value="2"
                      >取込処理済（{{ formData.HENKAN_KEISAN_DATE }}）</a-radio
                    >
                    <a-radio :value="3">処理キャンセル</a-radio>
                  </a-radio-group>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                th="前期積立金返還人数"
                :td="formData.ZENKI_HENKAN_NINSU"
                after="（人）"
              />
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                th="前期積立金返還金合計"
                :td="formData.ZENKI_HENKAN_GOKEI"
                after="（円）"
              />
            </a-col>
            <a-col v-bind="layout">
              <read-only
                thWidth="230"
                th="前期積立金返還率"
                :td="formData.ZENKI_HENKAN_RITU"
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
    KI: 8,
    SYORI_SENTAKU: 1,
    SYORI_TYPE: 2,
    ZENKI_TUMITATE_DATE: '令和06/09/02',
    ZENKI_KOFU_DATE: '令和06/09/02',
    HENKAN_KEISAN_DATE: '令和06/09/02',
  }
}
const formData = reactive(createDefaultParams() as PreviewRequest)
const SYORI_SENTAKU_LIST = ref<CmCodeNameModel[]>([
  { CODE: 1, NAME: '積立金納付額取込処理' },
  { CODE: 2, NAME: '互助金交付額取込' },
  { CODE: 3, NAME: '繰越額算定処理' },
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
  SYORI_SENTAKU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '処理選択'),
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
