<template>
  <!-- <div id="viewer-host" class="w-full h-full"></div> -->
  <div id="viewerContainer" class="h-full w-full"></div>
</template>
<script setup lang="ts">
import { onMounted, ref, watch, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { ReportViewer, Core } from '@grapecity/activereports'
import '@grapecity/activereports/styles/ar-js-ui.css'
import '@grapecity/activereports/styles/ar-js-viewer.css'
import '@grapecity/activereports-localization'
import { Preview } from '../GJ10/GJ1030/service'
//JSViewer
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.js'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.css'
import '@grapecity/ar-viewer-ja'
import { createViewer } from '@grapecity/ar-viewer-ja'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const channel = new BroadcastChannel('channel_preview')

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  channel.postMessage({ isMounted: true })

  channel.onmessage = async (event) => {
    console.log('event.data:' + event.data)
    await Preview({ ...JSON.parse(event.data) })
    let viewer
    viewer = createViewer({
      element: '#viewerContainer',
      reportService: { url: 'https://localhost:55215/api/reporting' },
    })

    viewer.openReport('AcmeStore.rdlx')
  }
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
</script>
<style lang="scss" scoped></style>
