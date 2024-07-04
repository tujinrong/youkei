<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 範囲選択（日付）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.09.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <date-jp
      v-model:value="value1"
      style="width: 170px"
      :disabled="disabled"
      :hanit="value2"
      :placeholder="placeholder"
    />
    <span>～</span>
    <date-jp
      v-model:value="value2"
      style="width: 170px"
      :disabled="disabled"
      :hanif="value1"
      :placeholder="placeholder"
    />
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
import dayjs from 'dayjs'
import { computed } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  value: string
  disabled?: boolean
  placeholder?: string
}
const props = defineProps<Props>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const value1 = computed({
  get() {
    return props.value ? props.value.split(',')[0] : ''
  },
  set(val) {
    emit('update:value', dateStr(val) + ',' + dateStr(value2.value))
    if (!val && !value2.value) emit('update:value', '')
    formItemContext.onFieldChange()
  }
})
const value2 = computed({
  get() {
    return props.value ? props.value.split(',')[1] : ''
  },
  set(val) {
    emit('update:value', dateStr(value1.value) + ',' + dateStr(val))
    if (!val && !value1.value) emit('update:value', '')
    formItemContext.onFieldChange()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function dateStr(val) {
  return dayjs.isDayjs(val) ? dayjs(val).format('YYYY-MM-DD') : val ?? ''
}
</script>
