<template>
  <a-card class="h-full">
    <h1>（GJ3011）互助基金契約者情報变更(增羽) 請求書発行</h1>
    <div class="self_adaption_table form mt-1 max-w-300">
      <b>第{{ searchParams.KI }}期</b>

      <a-row
        ><a-col :span="24"
          ><read-only
            th="契約者"
            th-width="100"
            :td="KEIYAKUSYA"
          ></read-only></a-col
      ></a-row>
      <a-row
        ><a-col :span="24"
          ><th>出力区分</th>
          <td>
            <a-radio-group v-model:value="searchParams.syuturyoku" class="mt-1">
              <a-radio :value="1">仮発行</a-radio>
              <a-radio :value="2">初回発行</a-radio>
              <a-radio :value="3">再発行(初回と同内容)</a-radio>
              <a-radio :value="4"
                >修正発行(納付期限、発行日、発行番号変更可能)</a-radio
              >
              <a-radio :value="5">請求書取消</a-radio>
            </a-radio-group>
          </td></a-col
        ></a-row
      >
      <a-col :span="24"
        ><th class="required">納付期限</th>
        <td>
          <DateJp
            v-model:value="searchParams.a"
            class="max-w-50"
          ></DateJp></td></a-col
      ><a-col :span="24"
        ><th class="required">発行日</th>
        <td>
          <DateJp v-model:value="searchParams.a" class="max-w-50"></DateJp></td
      ></a-col>
      <a-row
        ><a-col :span="24"
          ><th class="required">発信番号</th>
          <td>
            <span class="min-w-10 mt-1">日鶏</span>
            <a-input
              v-model:value="searchParams.a"
              class="max-w-20"
              :maxlength="2"
            ></a-input
            ><span class="min-w-10 mt-1">発 第</span
            ><a-input
              v-model:value="searchParams.a"
              class="max-w-30"
              :maxlength="4"
            ></a-input
            ><span class="min-w-10 mt-1">号</span>
          </td></a-col
        ></a-row
      >
      <a-row class="m-t-2">
        <a-col :span="24">
          <div class="mb-2 header_operation flex justify-between w-full">
            <a-space :size="20">
              <a-button type="primary">プレビュー</a-button>
              <a-button type="primary" :disabled="searchParams.syuturyoku !== 5"
                >請求書取消</a-button
              >
              <a-button type="primary">クリア</a-button>
            </a-space>
            <a-button class="ml-a" type="primary" @click="goList"
              >一覧</a-button
            >
          </div>
        </a-col>
      </a-row>
    </div>
  </a-card>
</template>
<script lang="ts" setup>
import { PageStatus } from '@/enum'
import { onMounted, reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: -1,
    KEIYAKUSYA_CD: undefined,
    syuturyoku: 1,
    a: undefined,
  }
}
const searchParams = reactive(createDefaultParams())
const KEIYAKUSYA = ref('')
const router = useRouter()
const route = useRoute()
const props = defineProps<{
  status: PageStatus
}>()
const isNew = props.status === PageStatus.New
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  router.push({ name: route.name })
}
</script>

<style lang="scss" scoped>
th {
  width: 100px;
}
</style>
