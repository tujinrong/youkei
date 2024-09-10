<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: ホーム
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.07.24
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :bordered="false" class="mb-2 h-full">
      <img
        src="/chicken.png"
        alt="Image"
        style="
          position: fixed;
          bottom: 20px;
          right: 50px;
          width: 20%;
          opacity: 0.5;
        "
      />
      <h1>(GJ0020)契約情報</h1>
      <div class="flex mt-2 max-w-150 justify-between">
        <h2>{{ updTime }}現在</h2>
        <a-button type="primary" class="mt-1" @click="update">再表示</a-button>
      </div>

      <a-descriptions
        :column="1"
        class="mt-2 max-w-150"
        bordered
        size="small"
        :style="{ borderWidth: '2px', borderColor: '#d9d9d9' }"
      >
        <a-descriptions-item
          label="契約数"
          :content-style="{ fontSize: '15px', textAlign: 'end' }"
          :label-style="{ fontSize: '15px' }"
          ><CountTo
            :endValue="homeData.KEIYAKUSU_SHINKI"
            prefix="新規" /><CountTo
            :endValue="homeData.KEIYAKUSU_KEIZOKU"
            prefix="　継続"
        /></a-descriptions-item>
        <a-descriptions-item
          label="羽数"
          :content-style="{
            fontSize: '15px',
            textAlign: 'end',
            borderTop: '2px solid #d9d9d9',
            borderBottom: '2px solid #d9d9d9',
          }"
          :label-style="{
            fontSize: '15px',
            borderTop: '2px solid #d9d9d9',
            borderBottom: '2px solid #d9d9d9',
          }"
          ><CountTo :endValue="homeData.HASU" suffix=" 羽" />
        </a-descriptions-item>
        <a-descriptions-item
          label="積立金額"
          :content-style="{ fontSize: '15px', textAlign: 'end' }"
          :label-style="{ fontSize: '15px' }"
          ><CountTo :endValue="homeData.TUMITATE_KIN" suffix=" 円" />
        </a-descriptions-item>
      </a-descriptions>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { onMounted, reactive, ref } from 'vue'
import { Init } from './service'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const updTime = ref('')
const homeData = reactive({
  KEIYAKUSU_SHINKI: undefined as number | undefined,
  KEIYAKUSU_KEIZOKU: undefined as number | undefined,
  HASU: undefined as number | undefined,
  TUMITATE_KIN: undefined as number | undefined,
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  update()
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const update = () => {
  const currentDate = new Date()
  const datePart = currentDate.toLocaleDateString('ja-JP', {
    year: 'numeric',
    month: 'long',
    day: 'numeric',
  })
  const timePart = currentDate.toLocaleTimeString('ja-JP', {
    hour: 'numeric',
    minute: 'numeric',
    second: 'numeric',
  })
  updTime.value = `${datePart}${timePart}`
  Init().then((res) => {
    Object.assign(homeData, res)
  })
}
</script>
<style lang="scss" scoped></style>
