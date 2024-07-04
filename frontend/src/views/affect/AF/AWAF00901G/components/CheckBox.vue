<template>
  <a-checkbox v-if="flag" checked disabled />
  <span v-else-if="flag === null">―</span>
  <a-checkbox v-else disabled />
</template>

<script setup lang="ts">
const props = defineProps<{
  flag: boolean
}>()
</script>
