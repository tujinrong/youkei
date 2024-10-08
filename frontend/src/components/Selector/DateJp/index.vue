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
    :format="[formatter(curVal), 'YYYY-MM-DD', 'YYYY/MM/DD']"
    :disabled-date="disabledDate"
    :allowClear="!notAllowClear"
    class="w-42!"
    @change="inputText = ''"
  />
</template>

<script setup lang="ts">
import { computed, ref, onMounted, watch, nextTick } from 'vue'
import dayjs from 'dayjs'
import { DatePadZero, getUnKnownDateJpText } from '@/utils/util'
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
onMounted(() => {
  const inputDom = dateRef.value.$el.querySelector('input')
  if (inputDom) {
    // 元号を置換するための関数
    function replaceEra(value) {
      // 元号のマッピング（全角・半角、アルファベットにも対応）
      const eraMapping = {
        '1': '明治',
        '１': '明治',
        m: '明治',
        ｍ: '明治',
        '2': '大正',
        '２': '大正',
        t: '大正',
        ｔ: '大正',
        '3': '昭和',
        '３': '昭和',
        s: '昭和',
        ｓ: '昭和',
        '4': '平成',
        '４': '平成',
        h: '平成',
        ｈ: '平成',
        '5': '令和',
        '５': '令和',
        r: '令和',
        ｒ: '令和',
      }

      // 入力の最初の文字を元号に変換
      const era = eraMapping[value[0].toLowerCase()]

      // 元号が存在する場合は置換、存在しない場合はそのまま返す
      return era
        ? { value: era + value.slice(1), replaced: true }
        : { value, replaced: false }
    }

    // input要素を編集可能にする
    inputDom.readOnly = false

    // ユーザーが直接入力したときの処理
    inputDom.addEventListener('input', (e) => {
      if (!e.isComposing) {
        // 日本語入力中でない場合にのみ実行
        let value = e.target.value // 現在の入力値
        let cursorPosition = e.target.selectionStart // 現在のカーソル位置を保存

        // 元号を置換する
        let { value: newValue, replaced } = replaceEra(value)

        // 置換後の値を大文字にしてセット
        e.target.value = newValue.toUpperCase()

        // もし元号が置換されたら、カーソルを元号の後に移動
        if (replaced) {
          e.target.setSelectionRange(2, 2) // 2文字目の後にカーソルを移動
        } else {
          // 置換されなかった場合、元のカーソル位置を保持
          e.target.setSelectionRange(cursorPosition, cursorPosition)
        }
      }
      inputText = e.target.value // 入力されたテキストを保持
    })

    // 日本語入力が確定されたときの処理
    inputDom.addEventListener('compositionend', (e) => {
      let value = e.target.value // 現在の入力値
      let cursorPosition = e.target.selectionStart // 現在のカーソル位置を保存

      // 元号を置換する
      let { value: newValue, replaced } = replaceEra(value)

      // 置換後の値を大文字にしてセット
      e.target.value = newValue.toUpperCase()

      // もし元号が置換されたら、カーソルを元号の後に移動
      if (replaced) {
        e.target.setSelectionRange(2, 2) // 2文字目の後にカーソルを移動
      } else {
        // 置換されなかった場合、元のカーソル位置を保持
        e.target.setSelectionRange(cursorPosition, cursorPosition)
      }
      inputText = e.target.value // 入力されたテキストを保持
    })

    dateRef.value.$el.addEventListener('keydown', (e) => {
      //Tab/Enter キー
      if (e.keyCode == 13 || e.keyCode == 9) {
        //補充年
        if (new RegExp(/^[0-9A]{1,2}[-\/]?[0-9A]{1,2}$/).test(inputText)) {
          inputText = dayjs().year() + '/' + inputText
        }
        setInputValue(inputText)
      }
      //Delete/BackSpace キー
      if (e.keyCode == 8 || e.keyCode == 46) {
        setTimeout(() => {
          if (!e.target.value) curVal.value = null
        }, 0)
      }
    })
    // inputDom.addEventListener('focus', (e) => {
    //   e.target.select()
    // })
  }
})
onMounted(() => {
  // const inputDom = dateRef.value.$el.querySelector('.ant-picker-input')
  // if (inputDom) {
  //   inputDom.addEventListener('keydown', function (event) {
  //     if (event.key === 'Backspace') {
  //       event.preventDefault()
  //     }
  //   })
  // }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

async function setInputValue(value: string) {
  debugger
  let parseDate = parseJapaneseDate(value)
  if (value) {
    const inputStr = DatePadZero(parseDate).replace(/[\/-]/g, '')
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
    return inputText
      ? getUnKnownDateJpText(inputText)
      : getDateJpAddSpace(value)
  } else {
    return dayjs(value).isValid() ? getDateJpAddSpace(value) : ''
  }
}
function parseJapaneseDate(japaneseDateStr) {
  try {
    // 各元号の開始日と終了日を定義（令和には終了日はなし）
    const eraMapping = {
      明治: { start: new Date(1868, 9, 23), end: new Date(1912, 7, 29) }, // 明治: 1868年10月23日 - 1912年7月29日
      大正: { start: new Date(1912, 7, 30), end: new Date(1926, 11, 24) }, // 大正: 1912年7月30日 - 1926年12月24日
      昭和: { start: new Date(1926, 11, 25), end: new Date(1989, 0, 7) }, // 昭和: 1926年12月25日 - 1989年1月7日
      平成: { start: new Date(1989, 0, 8), end: new Date(2019, 3, 30) }, // 平成: 1989年1月8日 - 2019年4月30日
      令和: { start: new Date(2019, 4, 1), end: null }, // 令和: 2019年5月1日 - 現在
    }

    // 年号名、年、月、日を抽出
    const eraMatch = japaneseDateStr.match(/(明治|大正|昭和|平成|令和)/)
    const yearMatch = japaneseDateStr.match(/(\d{1,2})年/)
    const monthMatch = japaneseDateStr.match(/(\d{1,2})月/)
    const dayMatch = japaneseDateStr.match(/(\d{1,2})日/)

    // 日付のフォーマットが正しいか確認
    if (!eraMatch || !yearMatch || !monthMatch || !dayMatch) {
      throw new Error('日付のフォーマットが無効です') // フォーマットが無効の場合
    }

    // 元号名と日付情報を抽出
    const eraName = eraMatch[0] // 元号名
    const eraYear = parseInt(yearMatch[1], 10) // 和暦の年を整数に変換
    const month = parseInt(monthMatch[1], 10) - 1 // JavaScriptのDateは0始まりの月
    const day = parseInt(dayMatch[1], 10)

    // 元号に対応する期間を取得
    const era = eraMapping[eraName]
    if (!era) {
      throw new Error('不明な元号です')
    }

    // 元号の開始年に基づき、西暦年を計算
    const westernYear = era.start.getFullYear() + eraYear - 1

    // 入力された日付を西暦に変換してDateオブジェクトを作成
    const inputDate = new Date(westernYear, month, day)

    // 入力日が元号の期間内にあるか確認
    if (inputDate < era.start || (era.end && inputDate > era.end)) {
      throw new Error(`${eraName}の期間外の日付です`) // 日付が元号の範囲外の場合
    }

    // 月と日をフォーマット
    const formattedMonth = String(month + 1).padStart(2, '0')
    const formattedDay = String(day).padStart(2, '0')

    // 西暦日付のフォーマットを作成
    const formattedDate = `${westernYear}-${formattedMonth}-${formattedDay}`
    return formattedDate // フォーマットされた日付を返す
  } catch (error) {
    return null // エラーが発生した場合はnullを返す
  }
}

function getDateJpAddSpace(value: Date | string | undefined) {
  if (value) {
    try {
      const date = new Date(value)
      return (
        new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
          era: 'long',
          year: '2-digit',
          month: '2-digit',
          day: '2-digit',
        })
          .format(date)
          .replace(/(明治|大正|昭和|平成|令和)(?=\S)/g, '$1 ')
          .replace(/\//, '年')
          .replace(/\//, '月') + '日'
      )
    } catch (error) {
      console.error(error)
      return '無効日付'
    }
  } else {
    return ''
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
