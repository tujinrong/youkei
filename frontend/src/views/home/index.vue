<template>
  <div>
    <a-card :bordered="false" class="mb-2 h-full">
      <div class="flex">
        <h1>{{ formattedDate }}現在</h1>
        <a-button type="primary" class="ml-2 mt-1" @click="Init" disabled
          >更新</a-button
        >
      </div>

      <a-descriptions :column="1" class="mt-2">
        <a-descriptions-item
          label="契約数"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >新規{{ homeData.keiyakusinki }}　継続{{
            homeData.keiyakusukeiyaku
          }}</a-descriptions-item
        >
        <a-descriptions-item
          label="羽数"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >{{ homeData.hasu }} 羽</a-descriptions-item
        >
        <a-descriptions-item
          label="績立金額"
          :content-style="{ fontSize: '24px' }"
          :label-style="{ fontSize: '24px' }"
          >{{ homeData.sekitatukinngaku }} 円</a-descriptions-item
        >
      </a-descriptions>
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
  keiyakusinki: undefined as number | undefined,
  keiyakusukeiyaku: undefined as number | undefined,
  hasu: undefined as number | undefined,
  sekitatukinngaku: undefined as number | undefined,
})

onMounted(() => {
  // Init()
})
</script>
<style lang="scss" scoped></style>
