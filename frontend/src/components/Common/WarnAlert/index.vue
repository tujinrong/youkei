<template>
  <div class="alert">
    <exclamation-circle-filled color="#faad14" />
    <span class="ml-2 c-red5 font-bold text-base">警告内容あり</span>
  </div>
</template>

<script setup lang="ts">
import { ExclamationCircleFilled } from '@ant-design/icons-vue'
</script>

<style lang="less" scoped>
.alert {
  border: 2px solid #ef4444;
  border-radius: 2px;
  background-color: #f5ff00;
  height: 32px;
  display: flex;
  align-items: center;
  padding: 0 8px;
}
</style>
