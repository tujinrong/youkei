<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（日付時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.09.11
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <date-time :value="value1 ?? null" :hanit="value2" @change="onChange1" />
    <span>～</span>
    <date-time :value="value2 ?? null" :hanif="value1" is-end @change="onChange2" />
  </div>
</template>

<script setup lang="ts">
import DateTime from '../DateTime/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value1?: string
  value2?: string
}>()
const emit = defineEmits(['update:value1', 'update:value2'])

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onChange1(value) {
  emit('update:value1', value)
}
function onChange2(value) {
  emit('update:value2', value)
}
</script>
