<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 和暦(日付)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-date-picker
    ref="dateRef"
    v-model:value="curVal"
    :format="formatter"
    :disabled-date="disabledDate"
    :allowClear="!notAllowClear"
    style="width: 100%"
    @change="inputText = ''"
  />
</template>

<script setup lang="ts">
import { computed, ref, onMounted, watch, nextTick } from 'vue'
import dayjs from 'dayjs'
import { DatePadZero, getDateJpText, getUnKnownDateJpText } from '@/utils/util'
import { showInfoModal } from '@/utils/modal'
import { E001013 } from '@/constants/msg'
import { ERA_YEARS } from '@/constants/business'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: any
  unknown?: boolean
  hanif?: string
  hanit?: string
  notAllowClear?: boolean
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['update:value', 'change', 'emitUnknownDate'])
const dateRef = ref()
let inputText = ''
const YYYYMMDDRegExp = new RegExp(/^[0-9]{8}$/)
const narrowJPDateRegExp = new RegExp(/^[A-Z1-5][0-9A]{6}$/)
const areaJPDateRegExp = new RegExp(
  /^[0-9]{4}[-/]?[A][1-4][-/]?[0-9]{2}|[0-9]{4}[-/]?[0-9]{2}[-/]?[A][1-3]|[0-9]{4}[-/]?[A][1-4][-/]?[A][1-3]$/
)
const unknownJPDateRegExp = new RegExp(
  /^(0{4}[-/]?[0-9]{2}[-/]?[0-9]{2}|[0-9]{4}[-/]?0{2}[-/]?[0-9]{2}|[0-9]{4}[-/]?[0-9]{2}[-/]?0{2})$/
)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    if (
      props.unknown &&
      (areaJPDateRegExp.test(props.value) ||
        unknownJPDateRegExp.test(props.value) ||
        narrowJPDateRegExp.test(props.value))
    ) {
      return dayjs()
    }
    return props.value ? dayjs(props.value) : props.value
  },
  set(v) {
    emit('update:value', v ? dayjs(v).format('YYYY-MM-DD') : v)
    emit('change', v)
  },
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.unknown,
  (val) => {
    if (!val) {
      inputText = ''
      curVal.value = dayjs()
      nextTick(() => {
        curVal.value = null
      })
    }
  }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
// onMounted(() => {
//   const inputDom = dateRef.value.$el.querySelector('input')
//   if (inputDom) {
//     inputDom.readOnly = false
//     inputDom.addEventListener('input', (e) => {
//       e.target.value = e.target.value.toUpperCase() //大文字
//       inputText = e.target.value
//     })
//     dateRef.value.$el.addEventListener('keydown', (e) => {
//       //Tab/Enter キー
//       if (e.keyCode == 13 || e.keyCode == 9) {
//         //補充年
//         if (new RegExp(/^[0-9A]{1,2}[-\/]?[0-9A]{1,2}$/).test(inputText)) {
//           inputText = dayjs().year() + '/' + inputText
//         }
//         setInputValue(inputText)
//       }
//       //Delete/BackSpace キー
//       if (e.keyCode == 8 || e.keyCode == 46) {
//         setTimeout(() => {
//           if (!e.target.value) curVal.value = null
//         }, 0)
//       }
//     })
//     inputDom.addEventListener('focus', (e) => {
//       e.target.select()
//     })
//   }
// })
onMounted(() => {
  const inputDom = dateRef.value.$el.querySelector('.ant-picker-input')
  if (inputDom) {
    inputDom.addEventListener('keydown', function (event) {
      if (event.key === 'Backspace') {
        event.preventDefault()
      }
    })
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

async function setInputValue(value: string) {
  if (value) {
    const inputStr = DatePadZero(value).replace(/[\/-]/g, '')
    if (YYYYMMDDRegExp.test(inputStr)) {
      const dateVal = dayjs(inputStr, 'YYYYMMDD')
      // 20240215
      if (Number(dateVal.format('YYYYMMDD')) === Number(inputStr)) {
        await judgeLimitDate(dateVal)
        curVal.value = dateVal
        return
      }
      // 00
      if (
        props.unknown &&
        unknownJPDateRegExp.test(inputStr) &&
        Number(inputStr.substring(4, 6)) <= 12 &&
        Number(inputStr.substring(6, 8)) <= 31
      ) {
        curVal.value = dayjs()
        emit('emitUnknownDate', formatUnknownStr(inputStr))
        return
      }
      showErrorModal()
      return
    } else if (props.unknown && areaJPDateRegExp.test(inputStr)) {
      // A
      curVal.value = dayjs()
      emit('emitUnknownDate', formatUnknownStr(inputStr))
      return
    } else if (narrowJPDateRegExp.test(inputStr)) {
      const dateStr = '00' + inputStr.substring(1, 7)
      const firstChar = inputStr.substring(0, 1)
      const dateVal = dayjs(dateStr, 'YYYYMMDD').add(-1900, 'year')
      // 和暦略称で入力 R240215
      if (Number(dateVal.format('YYYYMMDD')) === Number(dateStr)) {
        if (ERA_YEARS.hasOwnProperty(firstChar)) {
          const startYear = ERA_YEARS[firstChar]
          await judgeLimitDate(dateVal.add(startYear - 1, 'year'))
          curVal.value = dateVal.add(startYear - 1, 'year')
        } else {
          showErrorModal()
        }
        return
      }
      // 和暦略称 + A
      if (props.unknown && areaJPDateRegExp.test(dateStr)) {
        curVal.value = dayjs()
        emit('emitUnknownDate', formatUnknownStr(inputStr))
        return
      }
      // 和暦略称 + 00
      if (
        props.unknown &&
        unknownJPDateRegExp.test(dateStr) &&
        Number(dateStr.substring(4, 6)) <= 12 &&
        Number(dateStr.substring(6, 8)) <= 31
      ) {
        curVal.value = dayjs()
        emit('emitUnknownDate', formatUnknownStr(inputStr))
        return
      }
      showErrorModal()
      return
    }
    showErrorModal()
  }
}

function showErrorModal() {
  showInfoModal({
    type: 'error',
    content: E001013,
    onOk() {
      dateRef.value?.focus()
      inputText = ''
    },
  })
}

function formatter(value): string {
  if (
    areaJPDateRegExp.test(props.value) ||
    unknownJPDateRegExp.test(props.value) ||
    narrowJPDateRegExp.test(props.value)
  ) {
    return getUnKnownDateJpText(props.value)
  }

  if (props.unknown) {
    return inputText ? getUnKnownDateJpText(inputText) : getDateJpText(value)
  } else {
    return dayjs(value).isValid() ? getDateJpText(value) : ''
  }
}

function formatUnknownStr(dateStr: string) {
  if (dateStr.length === 7) {
    if (ERA_YEARS.hasOwnProperty(dateStr[0])) {
      const startYear = ERA_YEARS[dateStr[0]]
      const year = startYear + parseInt(dateStr.slice(1, 3)) - 1
      dateStr = dateStr.replace(dateStr.slice(0, 3), String(year))
    }
  }

  const year = dateStr.slice(0, 4)
  const month = dateStr.slice(4, 6)
  const day = dateStr.slice(6)

  return `${year}-${month}-${day}`
}

function disabledDate(current) {
  if (props.hanif && props.hanit) {
    return (
      current &&
      (current > dayjs(props.hanit).endOf('day') ||
        current < dayjs(props.hanif).startOf('day'))
    )
  }
  if (props.hanif) {
    return current && current < dayjs(props.hanif).startOf('day')
  }
  if (props.hanit) {
    return current && current > dayjs(props.hanit).endOf('day')
  }
}

async function judgeLimitDate(val) {
  if (
    props.hanif &&
    props.hanit &&
    (dayjs(val) > dayjs(props.hanit) || dayjs(val) < dayjs(props.hanif))
  ) {
    showErrorModal()
    return Promise.reject()
  }
  if (props.hanif && dayjs(val) < dayjs(props.hanif)) {
    showErrorModal()
    return Promise.reject()
  }
  if (props.hanit && dayjs(val) > dayjs(props.hanit)) {
    showErrorModal()
    return Promise.reject()
  }
  return Promise.resolve()
}
</script>
