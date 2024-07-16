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

        <a-button
          type="primary"
          :icon="isFullScreen ? h(ShrinkOutlined) : h(ArrowsAltOutlined)"
          @click="handleFullScreen"
        ></a-button>
      </div>
    </template>

    <div id="viewercontainer" :style="{ height: viewercontainerHeight, width: '100%' }"></div>

    <template #footer>
      <a-button type="primary" @click="closeModel">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { Preview } from '@/views/affect/EU/AWEU00303D/service'
import { PreviewRequest } from '@/views/affect/EU/AWEU00303D/type'
import { computed, nextTick, ref, watch } from 'vue'
import CellReport from 'public/cellreport/cellreport.viewer.11.0.1.js'
import { h } from 'vue'
import { ArrowsAltOutlined, ShrinkOutlined } from '@ant-design/icons-vue'
import { GlobalStore } from '@/store'
import { data } from '../constant'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  params?: PreviewRequest
}>()
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const viewer = ref()
const viewercontainerHeight = ref('750px')
const modalWidth = ref('1000px')
const modalClass = ref('custom-modal')
const isFullScreen = ref(false)
const handleFullScreen = () => {
  if (isFullScreen.value) {
    viewercontainerHeight.value = '750px'
    modalWidth.value = '1000px'
    modalClass.value = 'custom-modal'
  } else {
    // 自動的に高さを調整
    viewercontainerHeight.value = `${window.innerHeight - 120}px`
    modalWidth.value = '100%'
    modalClass.value = 'full-modal custom-modal'
  }
  isFullScreen.value = !isFullScreen.value
}
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
      debugger
      await nextTick()
      viewer.value = new CellReport.CellReport.Viewer('viewercontainer')
      const resolve = function () {
        viewer.value.setPageZoom(-1)
      }
      //ビューファイル取得 bas64
      viewer.value.reportPriview(data, resolve, '')
    }
  }
)

//
const closeModel = () => {
  modalVisible.value = false
  handleFullScreen()
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
