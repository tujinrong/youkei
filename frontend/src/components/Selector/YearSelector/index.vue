<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 和暦(月)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.09.04
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-date-picker
    ref="inputYear"
    v-model:value="yearV"
    :format="Formatter"
    picker="year"
  />
</template>
<script lang="ts" setup>
import dayjs, { Dayjs } from 'dayjs'
import { computed, onMounted, ref, watch } from 'vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const props = withDefaults(
  defineProps<{
    value: number
  }>(),
  {
    value: 2021,
  }
)
const emit = defineEmits(['update:value'])
const inputYear = ref()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const yearV = computed({
  get() {
    if (!props.value) {
      return ''
    }
    return props.value
      ? dayjs(new Date(props.value, 1, 1))
      : String(props.value)
  },
  set(v) {
    emit('update:value', dayjs(v).year() ?? v)
  },
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const inputDom = inputYear.value.$el.querySelector('.ant-picker-input')
  if (inputDom) {
    inputDom.addEventListener('keydown', function (event) {
      if (event.key === 'Backspace') {
        event.preventDefault()
      }
    })
  }
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

/**和暦取得(年月) */
const Formatter = (value: Date): string => {
  const year = dayjs(value).year()

  let yearName = ''
  let yearNum = 0
  if (year < 1868) {
    return `${year}年`
  } else if (year <= 1912) {
    yearName = '明治'
    yearNum = year - 1868 + 1
  } else if (year <= 1926) {
    yearName = '大正'
    yearNum = year - 1912 + 1
  } else if (year <= 1989) {
    yearName = '昭和'
    yearNum = year - 1926 + 1
  } else if (year <= 2018) {
    yearName = '平成'
    yearNum = year - 1989 + 1
  } else {
    if (year && value) {
      yearName = '令和'
      yearNum = year - 2019 + 1
    } else {
      return ''
    }
  }
  const formattedYearNum = yearNum < 10 ? `0${yearNum}` : `${yearNum}`
  return `${yearName}${formattedYearNum}年度`
}
</script>

<style lang="scss" scoped></style>
