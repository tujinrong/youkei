<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（日付）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.05.19
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center flex-wrap" style="gap: 8px">
    <div class="flex items-center">
      <date-jp
        style="width: 170px"
        :value="value.value1"
        :disabled="disabled"
        :hanit="value.value2"
        :placeholder="placeholder"
        @change="changeDate1"
      />
      <span>～</span>
      <date-jp
        style="width: 170px"
        :value="value.value2"
        :disabled="disabled"
        :hanif="value.value1"
        :placeholder="placeholder"
        @change="changeDate2"
      />
    </div>

    <div v-if="unknown">
      <a-checkbox :checked="value.yearflg" :disabled="disabled" @change="changeUnknownYear"
        >不明年</a-checkbox
      >
      <a-checkbox :checked="value.monthflg" :disabled="disabled" @change="changeUnknownMonth"
        >不明月</a-checkbox
      >
      <a-checkbox :checked="value.dayflg" :disabled="disabled" @change="changeUnknownDay"
        >不明日</a-checkbox
      >
    </div>
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
import dayjs from 'dayjs'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface ValueVM {
  /** 値(開始) */
  value1: string | number | null
  /** 値(終了) */
  value2: string | number | null
  /** 年(不詳) */
  yearflg?: boolean
  /** 月(不詳) */
  monthflg?: boolean
  /** 日(不詳) */
  dayflg?: boolean
}
interface Props {
  value: ValueVM
  disabled?: boolean
  unknown?: boolean
  placeholder?: string
}
const props = defineProps<Props>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//期日の範囲を選択
const changeDate1 = (value) => {
  const dateStr = dayjs.isDayjs(value) ? dayjs(value).format('YYYY-MM-DD') : value
  emit('update:value', { ...props.value, value1: dateStr })
  formItemContext.onFieldChange()
}
const changeDate2 = (value) => {
  const dateStr = dayjs.isDayjs(value) ? dayjs(value).format('YYYY-MM-DD') : value
  emit('update:value', { ...props.value, value2: dateStr })
  formItemContext.onFieldChange()
}

//不明年月日checkbox
const changeUnknownYear = (value) => {
  emit('update:value', { ...props.value, yearflg: value.target.checked })
}
const changeUnknownMonth = (value) => {
  emit('update:value', { ...props.value, monthflg: value.target.checked })
}
const changeUnknownDay = (value) => {
  emit('update:value', { ...props.value, dayflg: value.target.checked })
}
</script>
