<script setup lang="ts">
import { computed } from 'vue'

defineOptions({
  name: 'HeaderBanner',
})
const formattedDate = computed(() => {
  const currentDate = new Date()
  return currentDate.toLocaleDateString('ja-JP', {
    year: 'numeric',
    month: 'long',
    day: 'numeric',
  })
})
</script>

<template>
  <ACard :bordered="false" class="card-wrapper">
    <h1>{{ formattedDate }}現在</h1>
  </ACard>
</template>

<style scoped>
h1 {
  font-size: 24px;
}
</style>
