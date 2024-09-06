<template>
  <div id="viewerContainer" class="h-full w-full"></div>
</template>
<script setup lang="ts">
import { onMounted, computed } from 'vue'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.js'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.css'
import '@grapecity/ar-viewer-ja'
import { ExportTypes, createViewer } from '@grapecity/ar-viewer-ja'
import dayjs from 'dayjs'
import { reportSettings } from './constant'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const host = window.location.href.includes('localhost')
  ? 'localhost'
  : '61.213.76.155'
const URL = computed(() => {
  return `http://${host}:5109/api/reporting`
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  channel.postMessage({ isMounted: true })
})

let count = 0
const channel = new BroadcastChannel('channel_preview')
channel.onmessage = (event) => {
  if (event.data.params && count === 0) {
    count++
    try {
      let params = [{ name: '1', values: ['2'] }]
      let reportSetting = reportSettings.find((e) => e.name === event.data.name)
      if (reportSetting) {
        let fileName =
          reportSetting.fileName + dayjs(new Date()).format('YYYYMMDDHHmmss')
        let defaultExportSettings = {}
        reportSetting.availableExports.forEach((format) => {
          defaultExportSettings[format.toLowerCase()] = {
            FileName: { value: fileName, visible: true },
          }
        })
        let viewer = createViewer({
          element: '#viewerContainer',
          reportService: { url: URL.value },
          reportParameters: params,
          defaultExportSettings: defaultExportSettings,
          availableExports: reportSetting.availableExports as ExportTypes[],
        })
        let name = event.data.name + '|' + event.data.params
        viewer.openReport(name, params)
      } else {
        console.error('No report setting found for', event.data.name)
      }
    } catch (error) {}
  }
}
</script>
<style lang="scss" scoped></style>
