<template>
  <ai-select
    v-if="type == Enumコントロール.選択"
    v-model:value="curVal"
    :options="options"
    split-val
    :get-popup-container="null"
    :disabled="disabled"
    @change="onChangeSelect"
  />
  <a-select
    v-if="type == Enumコントロール.複数選択"
    :value="curVal || []"
    mode="multiple"
    :options="options"
    style="width: 100%"
    :disabled="disabled"
    @change="(val) => (curVal = val)"
  >
    <template #option="{ label, value }">
      {{ value + ' : ' + label }}
    </template>
  </a-select>
  <RangeNumberStr
    v-if="type == Enumコントロール.数値範囲"
    v-model:value="curVal"
    style="width: 100%"
  />
  <RangeInputStr
    v-if="type == Enumコントロール.文字範囲"
    v-model:value="curVal"
    style="width: 100%"
  />
  <RangeDateStr
    v-if="type == Enumコントロール.日付範囲 && datatype == Enum文字暦法区分.和暦"
    v-model:value="curVal"
    style="width: 100%"
  />
  <a-range-picker
    v-if="type == Enumコントロール.日付範囲 && datatype == Enum文字暦法区分.西暦"
    v-model:value="curVal"
    style="width: 100%"
    separator="～"
  />
  <RangeTime2 v-if="type == Enumコントロール.時間範囲" v-model:value="curVal" style="width: 100%" />
  <a-input-number
    v-if="type == Enumコントロール.数値入力"
    v-model:value="curVal"
    :disabled="disabled"
    style="width: 100%"
  />
  <a-input v-if="type == Enumコントロール.文字入力" v-model:value="curVal" :disabled="disabled" />
  <date-jp
    v-if="type == Enumコントロール.日付入力 && datatype == Enum文字暦法区分.和暦"
    v-model:value="curVal"
    format="YYYY-MM-DD"
    :disabled="disabled"
    style="width: 100%"
  />
  <a-date-picker
    v-if="type == Enumコントロール.日付入力 && datatype == Enum文字暦法区分.西暦"
    v-model:value="curVal"
    style="width: 100%"
    :disabled="disabled"
  />
  <a-time-picker
    v-if="type == Enumコントロール.時間入力"
    v-model:value="curVal"
    value-format="HHmm"
    format="HH:mm"
    style="width: 100%"
    :disabled="disabled"
  />

  <a-select
    v-if="type == Enumコントロール.論理値"
    v-model:value="curVal"
    :options="[
      {
        label: '該当',
        value: true
      },
      {
        label: '非該当',
        value: false
      }
    ]"
    allow-clear
    style="width: 100%"
    :disabled="disabled"
  ></a-select>

  <YearJp
    v-if="type == Enumコントロール.年度"
    v-model:value="curVal"
    :max="Number(max)"
    style="min-width: 120px"
    :disabled="disabled"
  ></YearJp>
  <InputSearch
    v-if="type == Enumコントロール.宛名入力"
    v-model:value="curVal"
    style="width: 100%"
    :disabled="disabled"
  ></InputSearch>
</template>

<script setup lang="ts">
import { Enumコントロール, Enum文字暦法区分 } from '#/Enums'
import { computed } from 'vue'
import RangeDateStr from '@/components/Selector/RangeDateStr/index.vue'
import RangeInputStr from '@/components/Selector/RangeInputStr/index.vue'
import RangeNumberStr from '@/components/Selector/RangeNumberStr/index.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import RangeTime2 from '@/components/Selector/RangeTime/index2.vue'
import InputSearch from '@/views/affect/AF/AWAF00705D/InputSearch.vue'
import { GetTargetItemValue } from '@/views/affect/EU/AWEU00301G/service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------

interface Props {
  type: Enumコントロール
  value?: string
  max?: string
  options?: DaSelectorModel[]
  datatype?: Enum文字暦法区分
  disabled?: boolean
  ids?: {
    rptid: string
    jyokenlabel: string
    targetitemseq?: string
  }
}

const props = withDefaults(defineProps<Props>(), {
  value: undefined,
  options: () => [],
  datatype: Enum文字暦法区分.和暦,
  max: undefined,
  min: undefined,
  ids: undefined
})

const emit = defineEmits(['update:value', 'setOptions'])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    return props.value ?? ''
  },
  set(val) {
    emit('update:value', val)
  }
})

async function onChangeSelect(val) {
  if (props.ids?.targetitemseq) {
    const { targetItemValueList } = await GetTargetItemValue({
      val,
      rptid: props.ids.rptid,
      jyokenlabel: props.ids.jyokenlabel,
      targetitemseq: props.ids.targetitemseq
    })
    emit('setOptions', targetItemValueList)
  }
}
</script>
