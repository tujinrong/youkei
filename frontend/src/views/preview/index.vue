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
import { random } from 'lodash-es'
import { useRoute } from 'vue-router'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const host = window.location.href.includes('localhost')
  ? 'localhost'
  : '61.213.76.155'
const URL = computed(() => {
  return `http://${host}:5109/api/reporting`
})
const route = useRoute()
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.SEARCH_METHOD) {
    route.query.SEARCH_METHOD = Number(route.query.SEARCH_METHOD) as any
  }
  const { name: name1, ...parameter } = route.query as any
  console.log('route', route.query)
  try {
    let params = [{ name: '1', values: ['2'] }]
    let reportSetting = reportSettings.find((e) => e.name === name1)
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
      let name = name1 + '|' + JSON.stringify(parameter)
      viewer.openReport(name, params)
    } else {
      console.error('No report setting found for', name1)
    }
  } catch (error) {}
})
</script>
<style lang="scss" scoped></style>
