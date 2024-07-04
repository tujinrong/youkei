<template>
  <div style="border: 1px solid #606266; overflow-y: auto" class="h-full">
    <div v-for="item in props.projectList" :key="item">
      <a-button
        class="btn"
        style="
          width: 100%;
          border-top: none;
          border-left: none;
          border-right: none;
          text-align: left;
        "
        @click="copyText(item)"
      >
        <template #icon>
          <SvgIcon name="color-text" class="m-r-1 icon-style" />
        </template>
        {{ item }}
      </a-button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { message } from 'ant-design-vue'
import SvgIcon from '@/components/Common/SvgIcon/index.vue'
import { I060002 } from '@/constants/msg'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  projectList: string[]
}>()
const emit = defineEmits(['setexceltext'])
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
const copyText = (item: string) => {
  emit('setexceltext', '**' + item)
  //message.success(I060002.Msg)
  let byClass = document.getElementsByClassName('luckysheet-cell-sheettable')[0].style
  byClass.cursor = 'crosshair'
  let body = document.getElementsByTagName('body')[0].style
  body.cursor = 'crosshair'
}
</script>

<style lang="less" scoped>
.btn:hover,
.btn:focus {
  border-color: #1890ff;
  background: #1890ff;
  color: #ffffff;
}
</style>
