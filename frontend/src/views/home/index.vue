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
      <div class="flex">
        <h1>{{ formattedDate }}現在</h1>
        <a-button type="primary" class="ml-2 mt-1" @click="Init">更新</a-button>
      </div>

      <a-descriptions :column="1" class="mt-2">
        <a-descriptions-item
          label="契約数"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >(新規{{ homeData.SHINKI }}　継続{{
            homeData.KEI
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
          >{{ homeData.TUMI }} 円</a-descriptions-item
        >
      </a-descriptions>
      <img
        src="/logo.png"
        alt="Image"
        style="
          position: absolute;
          bottom: 20px;
          right: 50px;
          width: 30%;
          height: 50%;
        "
      />
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { computed, onMounted, reactive } from 'vue'
import { Init } from './service'
const formattedDate = computed(() => {
  const currentDate = new Date()
  return currentDate.toLocaleDateString('ja-JP', {
    year: 'numeric',
    month: 'long',
    day: 'numeric',
  })
})

const homeData = reactive({
  SHINKI: undefined as number | undefined,
  KEI: undefined as number | undefined,
  HASU: undefined as number | undefined,
  TUMI: undefined as number | undefined,
})

onMounted(() => {
  Init().then((res) => {
    Object.assign(homeData, res)
  })
})
</script>
<style lang="scss" scoped></style>
