<!------------------------------------------------------------------
 * 業務名称　: 互助防疫システム
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
        style="position: fixed; bottom: 20px; right: 50px; width: 30%"
      />
      <div class="flex">
        <h1>データ更新時間：{{ updTime }}</h1>
        <a-button type="primary" class="ml-2 mt-1" @click="update"
          >更新</a-button
        >
      </div>

      <a-descriptions :column="1" class="mt-2 relative">
        <a-descriptions-item
          label="契約数"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >(新規{{ homeData.KEIYAKUSU_SHINKI }}　継続{{
            homeData.KEIYAKUSU_KEIZOKU
          }})</a-descriptions-item
        >
        <a-descriptions-item
          label="羽数"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >{{ homeData.HASU }} 羽</a-descriptions-item
        >
        <a-descriptions-item
          label="績立金額"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >{{ homeData.TUMITATE_KIN }} 円</a-descriptions-item
        >
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
