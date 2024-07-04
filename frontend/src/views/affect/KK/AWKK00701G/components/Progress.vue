<template>
  <a-modal
    z-index="1001"
    title="進捗"
    :visible="props.pvisible"
    v-bind="$attrs"
    :footer="null"
    :closable="false"
    destroy-on-close
  >
    <div v-for="(item, index) in $props.contentarray" :key="item" style="display: inline-block">
      <span :class="{ highlight: item === props.content }">{{ item }}</span>
      <span v-if="index < $props.contentarray.length - 1 && index > -1"
        ><DoubleRightOutlined
      /></span>
    </div>
    <LoadingOutlined />
    <a-progress :percent="props.percent" class="progress" v-bind="$attrs"> </a-progress
  ></a-modal>
</template>

<script setup lang="ts">
import { LoadingOutlined } from '@ant-design/icons-vue'
import { DoubleRightOutlined } from '@ant-design/icons-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  percent: number
  content: string
  pvisible: boolean
  contentarray: string[]
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['stop'])
</script>
<style scoped>
.progress {
  width: 90%;
  margin-top: 0;
  padding-top: 0;
  margin-bottom: 1em;
}
.ant-progress-bg {
  height: 16px;
}
span {
  margin-right: 10px;
}
.highlight {
  color: #1890ff;
}
</style>
