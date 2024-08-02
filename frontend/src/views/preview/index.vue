<template>
  <div id="viewer-host" class="w-full h-full"></div>
</template>
<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { ReportViewer, Core } from '@grapecity/activereports'
import '@grapecity/activereports/styles/ar-js-ui.css'
import '@grapecity/activereports/styles/ar-js-viewer.css'
import '@grapecity/activereports-localization'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  // フォント記述子の定義
  const fonts = [
    { name: 'ＭＳ ゴシック', source: '/fonts/MSGOTHIC.TTF' },
    { name: '游明朝', source: '/fonts/yumin.ttf' },
    { name: '游ゴシック', source: '/fonts/yugothib.ttf' },
    { name: 'IPAゴシック', source: '/fonts/ipaexg.ttf' },
    { name: 'Arial', source: '/fonts/Arial.ttf' },
    { name: 'Arial Italic', source: '/fonts/Arialbi.ttf' },
    { name: 'Arial Bold', source: '/fonts/Arialbd.ttf' },
    { name: 'Arial Bold Italic', source: '/fonts/Arialbi.ttf' },
    { name: 'Arial Black', source: '/fonts/Ariblk.ttf' },
  ]
  const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
  viewer.open('/report/keyakusya.rdlx-json')
  // サイドバーのエクスポート機能を有効化
  viewer.availableExports = ['pdf', 'xlsx', 'html']
  // 定義済みのフォント記述子を登録する
  Core.FontStore.registerFonts(...fonts)
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
</script>
<style lang="less" scoped></style>
