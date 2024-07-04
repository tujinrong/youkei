<template>
  <div style="height: 450px; width: 1000px" class="mt-3">
    <div class="description-table">
      <table style="border-top: 1px solid #c0c4cc">
        <tbody>
          <tr>
            <th style="width: 200px">{{ title }}</th>
            <td>
              <a-input
                :value="titleValue"
                :maxlength="10"
                @change="(e) => emit('update:titleValue', e.target.value)"
              />
            </td>
          </tr>
          <tr v-if="title2">
            <th style="width: 200px">{{ title2 }}</th>
            <td>
              <a-input
                :value="titleValue2"
                :maxlength="10"
                @change="(e) => emit('update:titleValue2', e.target.value)"
              />
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="description-table mt-3">
      <table style="border-top: 1px solid #c0c4cc">
        <tbody>
          <tr :style="{ height: title2 ? '372px' : '409px' }">
            <th style="width: 200px">{{ contentTitle }}</th>
            <td class="reference">
              <a-button type="primary" class="reference-btn" @click="uploadExcel">参照</a-button>
              <a-image
                v-if="imgData"
                draggable="false"
                style="width: 120px; height: 120px"
                alt="{{contentTitle}}"
                :src="
                  props.imgData.startsWith('data')
                    ? props.imgData
                    : `data:image/png;base64,${props.imgData}`
                "
              >
                <template #previewMask>
                  <div><eye-outlined /> プレビュー</div>
                </template>
              </a-image>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { EyeOutlined } from '@ant-design/icons-vue'
import VXETable from '@/vxetable'
import { watch } from 'vue'
import { Judgement } from '@/utils/judge-edited'
const props = defineProps<{
  title: string
  title2?: string
  titleValue?: string
  titleValue2?: string
  imgData: string
  contentTitle: string
  editJudge: Judgement
}>()

const emit = defineEmits(['update:imgData', 'update:titleValue', 'update:titleValue2'])

//アップロード処理
const uploadExcel = async () => {
  const { file } = await VXETable.readFile({
    types: ['jpg', 'jpeg', 'png']
  })

  getUrlBase64((window.URL || window.webkitURL).createObjectURL(file)).then((res) => {
    emit('update:imgData', res)
  })
}

function getUrlBase64(url) {
  return new Promise((resolve, reject) => {
    let canvas: HTMLCanvasElement | null = document.createElement('canvas')
    const ctx = canvas.getContext('2d')
    let img: HTMLImageElement | null = new Image()
    img.crossOrigin = 'Anonymous'
    img.src = url
    img.onload = function () {
      if (canvas && img) {
        canvas.height = img.height
        canvas.width = img.width
        ctx?.drawImage(img, 0, 0, img.width, img.height)
        const dataURL = canvas.toDataURL('image/png', 1)
        resolve(dataURL)
        canvas = null
        img = null
      }
    }
    img.onerror = function () {
      reject(new Error('Could not load image at ' + url))
    }
  })
}
watch(
  () => [props.titleValue, props.titleValue2, props.imgData],
  () => {
    props.editJudge.setEdited()
  },
  { deep: true }
)
</script>

<style scoped lang="less">
.reference {
  position: relative;
}

.reference-btn {
  position: absolute;
  right: 0;
  top: 0;
}
</style>
