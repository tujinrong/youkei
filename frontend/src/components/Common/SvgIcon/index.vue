<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 画像表示(svg)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <svg :width="width" :height="height" :style="{ color }">
    <use :xlink:href="symbolId" />
  </svg>
</template>

<script lang="ts" setup name="SvgIcon">
import { computed } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps({
  prefix: {
    type: String,
    default: 'icon'
  },
  name: {
    type: String,
    required: true
  },
  color: {
    type: String,
    default: ''
  },
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
const symbolId = computed(() => `#${props.prefix}-${props.name}`)
</script>
