<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（日付）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.02.21
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <date-jp style="width: 170px" :value="value1" :hanit="value2" @change="onChange1" />
    <span>～</span>
    <date-jp style="width: 170px" :value="value2" :hanif="value1" @change="onChange2" />
  </div>
</template>

<script setup lang="ts">
import DateJp from '../DateJp/index.vue'
import dayjs from 'dayjs'

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
const onChange1 = (value) => {
  const dateStr = dayjs.isDayjs(value) ? dayjs(value).format('YYYY-MM-DD') : value
  emit('update:value1', dateStr)
}
const onChange2 = (value) => {
  const dateStr = dayjs.isDayjs(value) ? dayjs(value).format('YYYY-MM-DD') : value
  emit('update:value2', dateStr)
}
</script>
