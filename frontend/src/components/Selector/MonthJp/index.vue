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
    ref="inputYearMonth"
    v-model:value="monthV"
    :format="Formatter"
    picker="month"
    class="w-35!"
  />
</template>
<script lang="ts" setup>
import dayjs from 'dayjs'
import { computed, onMounted, ref, watch } from 'vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const props = defineProps<{
  value: any
}>()
const emit = defineEmits(['update:value'])
const inputYearMonth = ref()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const monthV = computed({
  get() {
    return props.value ? dayjs(props.value) : props.value
  },
  set(v) {
    emit('update:value', v ? dayjs(v).format('YYYY-MM') : v)
  },
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const inputDom = inputYearMonth.value.$el.querySelector('.ant-picker-input')
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
  const month = dayjs(value).month() + 1
  let yearName = ''
  let yearNum = 0

  if (year < 1868) {
    const formattedMonth = month < 10 ? `0${month}` : `${month}`
    return `${year}年${formattedMonth}`
  } else if (year <= 1912) {
    yearName = '明治'
    yearNum = year - 1868 + 1
  } else if (year <= 1926) {
    yearName = '大正'
    yearNum = year - 1912 + 1
  } else if (year <= 1989) {
    yearName = '昭和'
    yearNum = year - 1926 + 1
  } else if (year < 2019) {
    yearName = '平成'
    yearNum = year - 1989 + 1
  } else {
    yearName = '令和'
    yearNum = year - 2019 + 1
  }
  const formattedYearNum = yearNum < 10 ? `0${yearNum}` : `${yearNum}`
  const formattedMonth = month < 10 ? `0${month}` : `${month}`
  return `${yearName} ${formattedYearNum}年${formattedMonth}月`
}
</script>

<style lang="scss" scoped></style>
