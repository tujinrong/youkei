<template>
  <!-- <div id="viewer-host" class="w-full h-full"></div> -->
  <div id="viewerContainer" class="h-full w-full"></div>
</template>
<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
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
channel.onmessage = (event) => {
  const data = JSON.parse(event.data)
  console.log(data)
}
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  channel.postMessage({ isMounted: true })

  //ReportViewer

  // // フォント記述子の定義
  // const fonts = [
  //   { name: 'ＭＳ ゴシック', source: '/fonts/MSGOTHIC.TTF' },
  //   { name: '游明朝', source: '/fonts/yumin.ttf' },
  //   { name: '游ゴシック', source: '/fonts/yugothib.ttf' },
  //   { name: 'IPAゴシック', source: '/fonts/ipaexg.ttf' },
  //   { name: 'Arial', source: '/fonts/Arial.ttf' },
  //   { name: 'Arial Italic', source: '/fonts/Arialbi.ttf' },
  //   { name: 'Arial Bold', source: '/fonts/Arialbd.ttf' },
  //   { name: 'Arial Bold Italic', source: '/fonts/Arialbi.ttf' },
  //   { name: 'Arial Black', source: '/fonts/Ariblk.ttf' },
  // ]
  // const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
  // viewer.open('/report/keiyakusya.rdlx-json')
  // // サイドバーのエクスポート機能を有効化
  // viewer.availableExports = ['pdf', 'xlsx', 'html']
  // // 定義済みのフォント記述子を登録する
  // Core.FontStore.registerFonts(...fonts)

  //JSViewer
  // await Preview
  let viewer
  viewer = createViewer({
    element: '#viewerContainer',
    reportService: { url: 'https://localhost:55215/api/reporting' },
  })

  viewer.openReport('AcmeStore.rdlx')
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
</script>
<style lang="scss" scoped></style>
