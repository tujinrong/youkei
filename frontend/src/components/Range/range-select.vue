<!------------------------------------------------------------------
 * 業務名称　:
 * 機能概要　: 範囲選択（プルダウンリスト）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.08
 * 作成者　　: 高
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center w-full">
    <ai-select
      style="width: calc(50% - 14px / 2)"
      :value="value.VALUE_FM"
      :options="options"
      split-val
      :type="type"
      :disabled="disabled"
      @change="change1"
    />
    <span>～</span>
    <ai-select
      style="width: calc(50% - 14px / 2)"
      :value="value.VALUE_TO"
      :options="options"
      split-val
      :disabled="disabled"
      @change="change2"
    />
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------

const props = withDefaults(
  defineProps<{
    value: {
      VALUE_FM: string | number | undefined
      VALUE_TO: string | number | undefined
    }
    options: CmCodeNameModel[]
    disabled?: boolean
    type?: 'string' | 'number'
  }>(),
  {
    type: 'number',
  }
)

const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function change1(val) {
  emit('update:value', {
    VALUE_FM: val ? (props.type === 'number' ? Number(val) : val) : undefined,
    VALUE_TO: props.value.VALUE_TO
      ? props.type === 'number'
        ? Number(props.value.VALUE_TO)
        : props.value.VALUE_TO
      : val
        ? props.type === 'number'
          ? Number(val)
          : val
        : undefined,
  })
  formItemContext.onFieldChange()
}

function change2(val) {
  emit('update:value', {
    VALUE_FM: props.value.VALUE_FM
      ? props.type === 'number'
        ? Number(props.value.VALUE_FM)
        : props.value.VALUE_FM
      : val
        ? props.type === 'number'
          ? Number(val)
          : val
        : undefined,
    VALUE_TO: val ? (props.type === 'number' ? Number(val) : val) : undefined,
  })
  formItemContext.onFieldChange()
}
</script>
