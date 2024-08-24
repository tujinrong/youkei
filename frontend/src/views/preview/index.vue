<template>
  <div id="viewerContainer" class="h-full w-full"></div>
</template>
<script setup lang="ts">
import { onMounted, ref, watch, reactive } from 'vue'
import { useRoute } from 'vue-router'
// import { ReportViewer, Core } from '@grapecity/activereports'
// import '@grapecity/activereports/styles/ar-js-ui.css'
// import '@grapecity/activereports/styles/ar-js-viewer.css'
// import '@grapecity/activereports-localization'
// import { Preview } from '../GJ10/GJ1030/service'
//JSViewer
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.js'
import '@grapecity/ar-viewer-ja/dist/jsViewer.min.css'
import '@grapecity/ar-viewer-ja'
import { JSViewer, createViewer } from '@grapecity/ar-viewer-ja'
import { View } from './service'
import { sessionStg } from '@/utils/storage'
import { Preview } from '../GJ10/GJ1030/service'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const channel = new BroadcastChannel('channel_preview')
interface RequestBody {
  SERVICE_NAME: string
  METHOD_NAME: string
  BIZ_REQUEST: {
    DATA: string
  }
}
const parsedData = ref()
let rawData = ''
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  channel.postMessage({ isMounted: true })

  channel.onmessage = (event) => {
    await Preview({ ...JSON.parse(event.data) })
    parsedData.value = JSON.parse(event.data)
    rawData = event.data
    let params = [{ name: '1', values: ['2'] }]
    let viewer = createViewer({
      element: '#viewerContainer',
      reportService: { url: 'http://192.168.1.245:5109/api/reporting' },
      // reportService: { url: 'https://localhost:55215/api/reporting' },
      reportParameters: params,
      defaultExportSettings: {
        pdf: {
          FileName: {
            value: 'Hihihi',
            visible: true,
          },
        },
      },
    })
    let name = rawData + '+AcmeStore.rdlx'
    viewer.openReport(name, params)
    // viewer.openReport('1ddd+AcmeStore.rdlx', params)
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
