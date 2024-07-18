<script setup lang="ts">
import { $t } from '@/locales'

defineOptions({
  name: 'GlobalLogo',
})

interface Props {
  /** Whether to show the title */
  showTitle?: boolean
}

withDefaults(defineProps<Props>(), {
  showTitle: true,
})
</script>

<template>
  <RouterLink to="/" class="w-full pl-5 flex items-center nowrap-hidden">
    <SystemLogo class="size-8" />
    <h2
      v-show="showTitle"
      class="pl-8px text-18px text-primary font-bold transition duration-300 ease-in-out"
    >
      {{ $t('system.title') }}
    </h2>
    <span class="pl-1">v1.0</span>
  </RouterLink>
</template>

<style scoped></style>
