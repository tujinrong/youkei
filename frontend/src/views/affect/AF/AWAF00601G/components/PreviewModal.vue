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
    <div id="viewer-host"></div>
    <template #footer>
      <a-button type="primary" @click="closeModel">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { PreviewRequest } from '@/views/affect/EU/AWEU00303D/type'
import { computed, nextTick, ref, watch } from 'vue'
import { Viewer as JSViewer } from '@grapecity/activereports-vue'
import '@grapecity/activereports/styles/ar-js-ui.css'
import '@grapecity/activereports/styles/ar-js-viewer.css'
import '@grapecity/activereports-localization'
import { ReportViewer, Core, PdfExport } from '@grapecity/activereports'
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
const modalWidth = ref('1000px')
const modalClass = ref('custom-modal')
const categories = ref([
  {
    categoryId: 1,
    categoryName: 'Beverages',
    checked: true
  },
  {
    categoryId: 2,
    categoryName: 'Condiments',
    checked: false
  },
  {
    categoryId: 3,
    categoryName: 'Confections',
    checked: false
  },
  {
    categoryId: 4,
    categoryName: 'Dairy Products',
    checked: false
  },
  {
    categoryId: 5,
    categoryName: 'Grains/Cereals',
    checked: false
  },
  {
    categoryId: 6,
    categoryName: 'Meat/Poultry',
    checked: false
  },
  {
    categoryId: 7,
    categoryName: 'Produce',
    checked: false
  },
  {
    categoryId: 8,
    categoryName: 'Seafood',
    checked: false
  }
])
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

const categoryIds = computed(() =>
  categories.value.filter((cat) => cat.checked).map((cat) => cat.categoryId)
)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (visible) => {
    if (visible) {
      await nextTick()
      const viewer = new ReportViewer.Viewer('#viewer-host', { language: 'ja' })
      viewer.open('/report/keyakusya.rdlx-json', {
        ReportParams: [
          {
            Name: 'CategoryId',
            Value: categoryIds.value
          }
        ]
      })
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
#viewer-host {
  width: 100%;
  height: 600px;
}
</style>
