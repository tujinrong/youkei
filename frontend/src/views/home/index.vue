<script setup lang="ts">
import HeaderBanner from './modules/header-banner.vue'
import CardData from './modules/card-data.vue'

import { onMounted } from 'vue'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.js'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.css'
import '@grapecity/ar-viewer-ja'
import { createViewer } from '@grapecity/ar-viewer-ja'

// let viewer
// onMounted(() => {
//   viewer = createViewer({
//     element: '#viewerContainer',
//   })
//   viewer.openReport('/report/3.rdlx')
// })
</script>

<template>
  <!-- <ASpace direction="vertical" :size="16">
    <HeaderBanner />
    <CardData class="h-185" />
  </ASpace> -->

  <div id="viewerContainer" class="h-full w-full"></div>
</template>

<style scoped></style>
