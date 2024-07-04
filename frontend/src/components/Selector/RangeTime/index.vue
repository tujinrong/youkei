<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 範囲選択（時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.12.07
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <a-time-picker
      :value="value1"
      :value-format="valueFormat"
      :format="FORMAT[valueFormat]"
      :disabled="disabled"
      @change="onChange1"
    />
    <span>～</span>
    <a-time-picker
      :value="value2"
      :value-format="valueFormat"
      :format="FORMAT[valueFormat]"
      :disabled="disabled"
      @change="onChange2"
    />
  </div>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  value1: string | null
  value2: string | null
  disabled: boolean
  valueFormat: 'HHmm' | 'HH' | 'mm'
}
const props = withDefaults(defineProps<Props>(), {
  value1: null,
  value2: null,
  disabled: false,
  valueFormat: 'HHmm'
})

const emit = defineEmits(['update:value1', 'update:value2'])

const FORMAT = {
  HHmm: 'HH:mm',
  HH: 'HH時',
  mm: 'mm分'
}
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onChange1(value) {
  //ヌル値
  if (!value) {
    emit('update:value1', null)
    //同じ時刻ではいけません
    // } else if (value === props.value2) {
    //   emit('update:value1', props.value1)
    //大きさの順番を入れ替えます
  } else if (props.value2 && value > props.value2) {
    emit('update:value2', value)
    emit('update:value1', props.value2)
  } else {
    emit('update:value1', value)
  }
}
function onChange2(value) {
  if (!value) {
    emit('update:value2', null)
    // } else if (value === props.value1) {
    //   emit('update:value2', props.value2)
  } else if (props.value1 && value < props.value1) {
    emit('update:value1', value)
    emit('update:value2', props.value1)
  } else {
    emit('update:value2', value)
  }
}
</script>
