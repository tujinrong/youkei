<template>
  <a-modal
    v-model:visible="modalVisible"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    centered
    :width="modalWidth"
    :wrap-class-name="modalClass"
  >
    <template #title>
      <div style="display: flex; justify-content: space-between; align-items: center">
        <span>プレビュー</span>
      </div>
    </template>

    <div id="viewercontainer" ref="viewerContainer" w-200 h-200></div>

    <template #footer>
      <a-button type="primary" @click="closeModel">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { PreviewRequest } from '@/views/affect/EU/AWEU00303D/type'
import { computed, nextTick, ref, watch } from 'vue'
import { data } from '../constant'
import { ReportViewer, Core, PdfExport } from '@grapecity/activereports'
// import { Viewer as ReportViewer } from '@grapecity/activereports-vue'
// import '@grapecity/activereports/styles/ar-js-viewer.css'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  params?: PreviewRequest
}>()
const viewerContainer = ref(null)
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const viewercontainerHeight = ref('750px')
const modalWidth = ref('1000px')
const modalClass = ref('custom-modal')

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (visible) => {
    if (visible) {
      await nextTick()
      const viewer = new ReportViewer.Viewer('#viewercontainer', { language: 'ja' })
      // const viewer = new ReportViewer(viewerContainer.value, { language: 'ja' });
      // viewer.open('/MarketSnapshot.rdlx-json');
      viewer.open('public/MarketSnapshot.rdlx-json').catch((e) => {
        console.log(e)
      })
      // viewerContainer.value.viewer.open('/MarketSnapshot.rdlx-json', { language: 'ja' })

      // fetch('/1.rdlx-json')
      //   .then((response) => response.json())
      //   .then((report) => {
      //     viewer.open(report)
      //   })

      // const parameters = [
      //   { Name: 'レポートパラメータ1', Value: ['値1'] },
      //   { Name: 'レポートパラメータ2', Value: ['値2'] }
      // ]
      // viewer.open('/youke.rdlx-json', { ReportParams: parameters })
    }
  }
)

//
const closeModel = () => {
  modalVisible.value = false
}
</script>
<style lang="less">
.full-modal {
  .ant-modal {
    max-width: 100%;
    top: 0;
    padding-bottom: 0;
    margin: 0;
  }
  .ant-modal-content {
    display: flex;
    flex-direction: column;
    height: calc(100vh);
  }
  .ant-modal-body {
    flex: 1;
  }
}
.custom-modal .ant-modal-body {
  padding: 0 !important;
}
</style>
