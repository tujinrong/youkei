<template>
  <div id="viewerContainer" class="h-full w-full"></div>
</template>
<script setup lang="ts">
import { onMounted, computed } from 'vue'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.js'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.css'
import '@grapecity/ar-viewer-ja'
import { createViewer } from '@grapecity/ar-viewer-ja'
import { sessionStg } from '@/utils/storage'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const host = window.location.href.includes('localhost')
  ? '192.168.1.65'
  : '61.213.76.155'
const URL = computed(() => {
  return `http://${host}:5109/api/reporting`
})
const getCurrentFormattedTime = () => {
  const now = new Date()
  const year = now.getFullYear().toString()
  const month = (now.getMonth() + 1).toString().padStart(2, '0')
  const day = now.getDate().toString().padStart(2, '0')
  const hours = now.getHours().toString().padStart(2, '0')
  const minutes = now.getMinutes().toString().padStart(2, '0')
  const seconds = now.getSeconds().toString().padStart(2, '0')

  return year + month + day + hours + minutes + seconds
}
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
      let viewer = createViewer({
        element: '#viewerContainer',
        reportService: { url: URL.value },
        // reportService: { url: 'http://:192.168.1.245/api/reporting ' },
        reportParameters: params,
        defaultExportSettings: {
          pdf: {
            FileName: {
              value:
                'GJ1030家庭防疫互助基金契約者一覧表(連絡用)_' +
                getCurrentFormattedTime(),
              visible: true,
            },
          },
          xls: {
            FileName: {
              value:
                'GJ1030家庭防疫互助基金契約者一覧表(連絡用)_' +
                getCurrentFormattedTime(),
              visible: true,
            },
          },
          xlsx: {
            FileName: {
              value:
                'GJ1030家庭防疫互助基金契約者一覧表(連絡用)_' +
                getCurrentFormattedTime(),
              visible: true,
            },
          },
        },
        availableExports: ['Pdf', 'Xls', 'Xlsx'],
      })
      // let token = sessionStg.get('token')
      let name = 'GJ1030|' + event.data.params
      viewer.openReport(name, params)
    } catch (error) {}
  }
}
</script>
<style lang="scss" scoped></style>
