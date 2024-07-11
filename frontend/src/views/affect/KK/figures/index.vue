<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ジェノグラム
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal v-model:visible="memoVisible" width="982px" title="ジェノグラム">
    <div>
      <a-form layout="inline" :model="form">
        <ai-select v-model:value="form.midCode" :options="midOptions" style="width: 90%">
        </ai-select>
        <a-button type="primary" style="margin-left: 10px" @click.prevent="onSubmit">検索</a-button>
      </a-form>
      <a-row class="m-t-1">
        <a-col :lg="18">
          <div class="description-table">
            <table>
              <tbody>
                <tr>
                  <th>
                    更新理由
                    <span class="request-mark">＊</span>
                  </th>
                  <td>
                    <a-input v-model:value="form.date" :disabled="isDisabled" style="width: 100%" />
                  </td>
                  <th>
                    更新者
                    <span class="request-mark">＊</span>
                  </th>
                  <td>
                    <a-input v-model:value="form.name" :disabled="isDisabled" style="width: 100%" />
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </a-col>
        <a-col :lg="6">
          <div class="description-table readonly">
            <table>
              <tbody>
                <tr>
                  <th style="width: 100px; line-height: 32px" class="display-cell">更新日</th>
                  <td></td>
                </tr>
              </tbody>
            </table>
          </div>
        </a-col>
      </a-row>
    </div>
    <div class="figures-box m-t-1">
      <div class="figures-tool">
        <draggable
          v-model="toolDatas"
          ghost-class="ghost"
          :sort="false"
          :force-fallback="true"
          :fallback-class="false"
          :group="{ name: 'figures', pull: 'clone', put: false }"
          drag-class="drag"
          chosen-class="chosen"
          animation="300"
          class="figures-panel"
          @start="onToolStart"
          @end="onToolEnd"
          @change="onToolChange"
        >
          <template #item="{ element, index }">
            <div
              class="figures-item tool-item"
              :data-id="index"
              :data-code="element.templateCode"
              :class="{ active: element.active }"
              @click="activeTool(element)"
            >
              <img :src="basePath + '/figures/' + imgMap[element.templateCode]" />
            </div>
          </template>
        </draggable>
      </div>
      <a-dropdown :trigger="['contextmenu']" @visibleChange="menuVisibleChange">
        <div ref="figuresBoxRef" class="figures-canvas" :class="{ moving: moving }">
          <draggable
            v-model="canvasData"
            ghost-class="ghost"
            :sort="false"
            :group="{ name: 'figures', pull: 'clone', put: false }"
            :force-fallback="true"
            :fallback-class="true"
            drag-class="drag"
            chosen-class="chosen"
            animation="300"
            class="figures-panel"
            @start="onCanvasStart"
            @end="onCanvasEnd"
            @change="onCanvasChange"
          >
            <template #item="{ element, index }">
              <div
                class="figures-item"
                :data-id="index"
                :data-code="element.templateCode"
                :data-color="element.backColor"
                :style="{ background: element.backColor ? '#' + element.backColor : 'none' }"
                @click="activeFigure(element)"
                @mouseover="onCanvasMouseover"
              >
                <img
                  v-if="element.templateCode"
                  :src="basePath + '/figures/' + imgMap[element.templateCode]"
                />
                <div v-if="element.active" class="active-mark"></div>
              </div>
            </template>
          </draggable>
          <comment
            v-for="(item, index) in commentData"
            :key="index"
            :data="item"
            @del="onDel"
          ></comment>
        </div>
        <template #overlay>
          <a-menu
            @click="
              ({ key }) => {
                menuClick(key)
              }
            "
          >
            <a-menu-item key="addComment"> コメントを追加 </a-menu-item>
            <a-menu-item key="changeBackColor">
              <div style="display: flex">
                <span>背景色を変更</span>
              </div>
            </a-menu-item>
            <a-menu-item key="delItem"> アイテムを削除 </a-menu-item>
          </a-menu>
        </template>
      </a-dropdown>
    </div>
    <template #footer>
      <a-button>コビー</a-button>
      <a-button key="submit" :loading="loading">セーブ</a-button>
      <a-button>キャンセル</a-button>
      <a-button>削除</a-button>
      <a-button key="back" type="primary" @click="close">閉じる</a-button>
    </template>
  </a-modal>

  <a-modal
    v-model:visible="colorPickVisible"
    :closable="false"
    :mask="false"
    wrap-class-name="color-picker-modal"
    :style="{ top: pickColorTop + 'px', left: pickColorLeft + 'px' }"
    :footer="null"
    width="276px"
    :wrap-style="{ overflow: 'hidden' }"
  >
    <color-picker-v2
      v-model:pureColor="pickColor"
      is-widget
      format="hex"
      disable-alpha
      @pureColorChange="onPureColorChange"
    ></color-picker-v2>
  </a-modal>
</template>

<script setup>
import { ref, nextTick } from 'vue'
import draggable from 'vuedraggable'
import Comment from './Comment.vue'
import { ColorPicker as ColorPickerV2 } from 'vue3-colorpicker'
import 'vue3-colorpicker/style.css'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps({
  width: {
    type: String,
    default: '20px'
  },
  height: {
    type: String,
    default: '20px'
  }
})

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const memoVisible = ref(false)
const loading = ref(false)
const moving = ref(false)
const figuresBoxRef = ref()
const canvasData = ref([])
const commentData = ref([])
const pickColor = ref('')
const pickColorTop = ref(0)
const colorPickerWidth = 276
const pickColorLeft = ref(650 - (document.body.clientWidth - colorPickerWidth) / 2)
const colorPickVisible = ref(false)
const figuresDatas = [
  {
    figureId: 409,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'None',
    templateCode: 'None',
    syoriYMD: null,
    posX: 3,
    posY: 5,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: '00ff00',
    userId: 0
  },
  {
    figureId: 410,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1002,
    syoriYMD: null,
    posX: 2,
    posY: 3,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: 'ffffff',
    userId: 0
  },
  {
    figureId: 411,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1105,
    syoriYMD: null,
    posX: 3,
    posY: 3,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: 'ffffff',
    userId: 0
  },
  {
    figureId: 412,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1005,
    syoriYMD: null,
    posX: 4,
    posY: 3,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: 'ffffff',
    userId: 0
  },
  {
    figureId: 413,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1201,
    syoriYMD: null,
    posX: 2,
    posY: 4,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: 'ffffff',
    userId: 0
  },
  {
    figureId: 414,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1208,
    syoriYMD: null,
    posX: 3,
    posY: 4,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: 'ffffff',
    userId: 0
  },
  {
    figureId: 415,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1203,
    syoriYMD: null,
    posX: 4,
    posY: 4,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: 'ffffff',
    userId: 0
  },
  {
    figureId: 416,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1002,
    syoriYMD: null,
    posX: 2,
    posY: 5,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: '00ff00',
    userId: 0
  },
  {
    figureId: 417,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Figure',
    templateCode: 1001,
    syoriYMD: null,
    posX: 4,
    posY: 5,
    width: 40,
    height: 40,
    rotationAngle: 0,
    comment: '',
    backColor: '00ff00',
    userId: 0
  },
  {
    figureId: 418,
    kojinNo: 0,
    mapType: 1,
    edaNo: 1,
    figureType: 'Comment',
    templateCode: 1101,
    syoriYMD: null,
    posX: 204,
    posY: 287,
    width: 88,
    height: 22,
    rotationAngle: 0,
    comment: 'コメント',
    backColor: '#ffffff',
    userId: 0
  }
]
const imgMap = ref({
  1001: '1001_女性本人.png',
  1002: '1002_女性.png',
  1003: '1003_女性死亡.png',
  1004: '1004_男性本人.png',
  1005: '1005_男性.png',
  1006: '1006_男性死亡.png',
  1101: '1101_横線.png',
  1102: '1102_縦線.png',
  1103: '1103_ブランク.png',
  1104: '1104_結婚線.png',
  1105: '1105_結婚線T.png',
  1106: '1106_離婚線.png',
  1201: '1201_線１.png',
  1202: '1202_線２.png',
  1203: '1203_線３.png',
  1204: '1204_線４.png',
  1205: '1205_線５.png',
  1206: '1206_線６.png',
  1207: '1207_線７.png',
  1208: '1208_線８.png',
  1209: '1209_線９.png',
  1301: '1301_点線横.png',
  1302: '1302_点線縦.png',
  1303: '1303_ブランク.png',
  1401: '1401_点線１.png',
  1402: '1402_点線２.png',
  1403: '1403_点線３.png',
  1404: '1404_点線４.png',
  1405: '1405_点線５.png',
  1406: '1406_点線６.png',
  1407: '1407_点線７.png',
  1408: '1408_点線８.png',
  1409: '1409_点線９.png'
})
const toolDatas = ref([
  { figureType: 'Figure', templateCode: 1001 },
  { figureType: 'Figure', templateCode: 1002 },
  { figureType: 'Figure', templateCode: 1003 },
  { figureType: 'Figure', templateCode: 1004 },
  { figureType: 'Figure', templateCode: 1005 },
  { figureType: 'Figure', templateCode: 1006 },
  { figureType: 'Figure', templateCode: 1101 },
  { figureType: 'Figure', templateCode: 1102 },
  { figureType: 'Figure', templateCode: 1103 },
  { figureType: 'Figure', templateCode: 1104 },
  { figureType: 'Figure', templateCode: 1105 },
  { figureType: 'Figure', templateCode: 1106 },
  { figureType: 'Figure', templateCode: 1201 },
  { figureType: 'Figure', templateCode: 1202 },
  { figureType: 'Figure', templateCode: 1203 },
  { figureType: 'Figure', templateCode: 1204 },
  { figureType: 'Figure', templateCode: 1205 },
  { figureType: 'Figure', templateCode: 1206 },
  { figureType: 'Figure', templateCode: 1207 },
  { figureType: 'Figure', templateCode: 1208 },
  { figureType: 'Figure', templateCode: 1209 },
  { figureType: 'Figure', templateCode: 1301 },
  { figureType: 'Figure', templateCode: 1302 },
  { figureType: 'Figure', templateCode: 1303 },
  { figureType: 'Figure', templateCode: 1401 },
  { figureType: 'Figure', templateCode: 1402 },
  { figureType: 'Figure', templateCode: 1403 },
  { figureType: 'Figure', templateCode: 1404 },
  { figureType: 'Figure', templateCode: 1405 },
  { figureType: 'Figure', templateCode: 1406 },
  { figureType: 'Figure', templateCode: 1407 },
  { figureType: 'Figure', templateCode: 1408 },
  { figureType: 'Figure', templateCode: 1409 }
])
let selectedItem = null
let dropItem = null
let hoverItem = null
const midOptions = [{ value: '0000', label: '＜新規＞' }]
const form = ref({})
const env = {
  VITE_PUBLIC_PATH: import.meta.env.VITE_PUBLIC_PATH
}
const basePath = ref('')
basePath.value = env.VITE_PUBLIC_PATH === '/' ? '' : env.VITE_PUBLIC_PATH
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const open = () => {
  memoVisible.value = true
  nextTick(() => {
    setData(figuresDatas)
  })
}
const close = () => {
  memoVisible.value = false
}
const initCanvasData = () => {
  canvasData.value = []
  for (let xIndex = 0; xIndex < 16; xIndex++) {
    for (let yIndex = 0; yIndex < 16; yIndex++) {
      canvasData.value.push({
        figureId: 0,
        kojinNo: 0,
        mapType: 1,
        edaNo: 1,
        figureType: 'Figure',
        templateCode: 0,
        syoriYMD: null,
        posX: xIndex,
        posY: yIndex,
        width: 40,
        height: 40,
        rotationAngle: 0,
        comment: '',
        backColor: '#ffffff',
        userId: 0
      })
    }
  }
}

const setData = (datas) => {
  initCanvasData()
  commentData.value = []
  datas.forEach((data) => {
    if (data.figureType == 'Comment') {
      commentData.value.push(data)
    } else {
      const index = Number(data.posX) + Number(data.posY) * 16
      const canvasDataItem = canvasData.value[index]
      if (data.templateCode && data.templateCode != 'None') {
        canvasDataItem.templateCode = data.templateCode
      }
      canvasDataItem.backColor = data.backColor
    }
  })
}

const onToolStart = (e) => {
  const index = Number(e.item.getAttribute('data-id'))
  const toolDataItem = toolDatas.value[index]
  activeTool(toolDataItem)
  selectedItem = {
    type: 'tool',
    templateCode: e.item.getAttribute('data-code')
  }
  moving.value = true
  return true
}
const onToolEnd = (e, e2) => {
  moving.value = false
  if (dropItem) {
    const index = Number(dropItem.index)
    const canvasDataItem = canvasData.value[index]
    canvasDataItem.templateCode = selectedItem.templateCode
    canvasDataItem.backColor = 'ffffff'
    activeFigure(canvasDataItem)
  }
  selectedItem = null
  dropItem = null
  activeTool(null)
  return true
}

const onCanvasStart = (e) => {
  const index = Number(e.item.getAttribute('data-id'))
  const canvasDataItem = canvasData.value[index]
  activeFigure(canvasDataItem)
  selectedItem = {
    type: 'figure',
    index: e.item.getAttribute('data-id'),
    templateCode: e.item.getAttribute('data-code'),
    backColor: e.item.getAttribute('data-color')
  }
  moving.value = true
  return true
}
const onCanvasEnd = (e, e2) => {
  if (dropItem) {
    // clear
    const indexOld = Number(selectedItem.index)
    const canvasDataItemOld = canvasData.value[indexOld]
    canvasDataItemOld.templateCode = 0
    canvasDataItemOld.backColor = 'ffffff'

    const index = Number(dropItem.index)
    const canvasDataItem = canvasData.value[index]
    if (
      selectedItem.templateCode &&
      selectedItem.templateCode != 'None' &&
      selectedItem.templateCode != '0'
    ) {
      canvasDataItem.templateCode = selectedItem.templateCode
    } else {
      canvasDataItem.templateCode = 0
    }
    canvasDataItem.backColor = selectedItem.backColor ? selectedItem.backColor : 'ffffff'
    activeFigure(canvasDataItem)
  }
  selectedItem = null
  moving.value = false
  dropItem = null
  return true
}

const onToolChange = (e, e2) => {
  return true
}
const onCanvasChange = (e, e2) => {
  return true
}

const activeTool = (item) => {
  toolDatas.value.forEach((data) => {
    data.active = false
  })
  if (item) {
    item.active = true
  }
}

const activeFigure = (item) => {
  canvasData.value.forEach((data) => {
    data.active = false
  })
  if (item) {
    item.active = true
  }
}

const onMove = (e, originalEvent) => {
  //ドッキング不可
  if (e.relatedContext.element.disabledPark == true) return false

  return true
}

const onCanvasMouseover = (e) => {
  if (selectedItem) {
    console.log('id:' + e.target.getAttribute('data-id'))
    if (!e.target.getAttribute('data-id')) {
      // debugger
    }
    dropItem = {
      type: 'figure',
      index: e.target.getAttribute('data-id')
    }
  }
  hoverItem = {
    type: 'figure',
    index: e.target.getAttribute('data-id')
  }
  return true
}

const menuVisibleChange = (visible) => {
  if (visible) {
    if (hoverItem) {
      const index = Number(hoverItem.index)
      const canvasDataItem = canvasData.value[index]
      activeFigure(canvasDataItem)
    }
  }
}

const openColorPicker = () => {
  if (hoverItem) {
    const itemDom = figuresBoxRef.value.querySelector('[data-id="' + hoverItem.index + '"]')
    if (itemDom) {
      let left = itemDom.getClientRects()[0].left + 50
      let top = itemDom.getClientRects()[0].top - 100
      pickColorTop.value = top
      pickColorLeft.value = left - (document.body.clientWidth - colorPickerWidth) / 2
    }
  }

  colorPickVisible.value = true
}

const delItem = () => {
  if (hoverItem) {
    const index = Number(hoverItem.index)
    const canvasDataItem = canvasData.value[index]
    canvasDataItem.backColor = 'ffffff'
    canvasDataItem.templateCode = 0
  }
}

const addComment = () => {
  if (hoverItem) {
    const data = JSON.parse(JSON.stringify(hoverItem))
    const itemDom = figuresBoxRef.value.querySelector('[data-id="' + hoverItem.index + '"]')
    if (itemDom) {
      let left = itemDom.offsetLeft + 10
      let top = itemDom.offsetTop + 48
      data.posX = left
      data.posY = top
    }
    data.figureType = 'Comment'
    data.comment = ''
    data.setFocus = true
    commentData.value.push(data)
  }
}

const menuClick = (key) => {
  if (hoverItem) {
    const index = Number(hoverItem.index)
    const canvasDataItem = canvasData.value[index]
    activeFigure(canvasDataItem)
  }
  if (key == 'changeBackColor') {
    openColorPicker()
  } else if (key == 'addComment') {
    addComment()
  } else if (key == 'delItem') {
    delItem()
  }
}

const getPopupContainer = (trigger) => {
  return trigger.parentElement
}

const onPureColorChange = () => {
  pickColor.value
  if (hoverItem) {
    const index = Number(hoverItem.index)
    const canvasDataItem = canvasData.value[index]
    canvasDataItem.backColor = pickColor.value.replace('#', '')
    activeFigure(null)
  }
  colorPickVisible.value = false
}

const onDel = (data) => {
  data.isDel = true
}

defineExpose({
  open
})
</script>
<style lang="less" scoped>
.figures-box {
  display: flex;

  .figures-tool {
    width: 146px;
    border: 1px solid #ccc;
    margin-right: 10px;
  }
  .figures-canvas {
    flex: 1;
    border: 1px solid #ccc;
    max-height: 530px;
    overflow: auto;
    position: relative;
  }

  .figures-panel {
    display: flex;
    flex-wrap: wrap;
  }

  .figures-item {
    width: 48px;
    height: 48px;
    border: 1px solid #dcdffc;
    position: relative;

    &:hover {
      background-color: #b2e1ff !important;
    }

    &.active {
      background-color: #7fceff !important;
    }

    &.drag {
      background-color: #ffffff;
    }

    &.tool-item {
      border: 1px solid #ccc;
    }

    img {
      width: 100%;
      height: 100%;
      pointer-events: none;
    }

    .active-mark {
      position: absolute;
      pointer-events: none;
      width: 100%;
      height: 100%;
      top: 0;
      left: 0;
      background-color: #75caff;
      opacity: 0.5;
    }
  }

  .color-pick-box {
    display: none;
    position: absolute;
  }

  .moving {
    .comment-box {
      pointer-events: none;
    }
  }
}

.color-picker-modal {
  .ant-modal-content {
    width: fit-content;

    .ant-modal-body {
      width: fit-content;
      padding: 0;
    }
  }
}
</style>
