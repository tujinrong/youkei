<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 選択（日付時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.09.11
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex">
    <date-jp
      v-model:value="date"
      :disabled="disabled"
      :hanif="hanif"
      :hanit="hanit"
      style="width: 165px"
      class="rounded-r-none"
      @change="onChangeDate"
    />
    <a-time-picker
      :value="time"
      :disabled="timeDisabled"
      value-format="HH:mm:ss"
      :disabled-hours="disabledHours"
      :disabled-minutes="disabledMinutes"
      :disabled-seconds="disabledSeconds"
      class="rounded-l-none"
      style="width: 115px"
      @change="onChangeTime"
    />
  </div>
</template>

<script setup lang="ts">
import dayjs, { Dayjs } from 'dayjs'
import { ref, watchEffect, computed } from 'vue'
import DateJp from '../DateJp/index.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: string | null
  /**左範囲値 */
  hanif?: string
  /**右範囲値 */
  hanit?: string
  /**終了値です */
  isEnd?: boolean
  disabled?: boolean
}>()
const emit = defineEmits(['update:value', 'change'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const date = ref<string | null>(null)
const time = ref<string | null>(null)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  if (props.value) {
    date.value = props.value.split(' ')[0]
    time.value = props.value.split(' ')[1]
  } else {
    date.value = null
    time.value = null
  }
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const timeDisabled = computed(() => Boolean(!date.value) || props.disabled)
//左右の範囲は同じ日
const isSameRangeDate = computed(() => {
  if (!props.hanif && !props.hanit) return false
  return dayjs(props.value).isSame(dayjs(props.hanif || props.hanit), 'day')
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onChangeDate(dateVal: Dayjs | null) {
  const dateStr = dayjs.isDayjs(dateVal) ? dayjs(dateVal).format('YYYY-MM-DD') : dateVal
  //on the same day, set the both initial time
  if (dayjs(dateVal).isSame(dayjs(props.hanif || props.hanit), 'day')) {
    //右
    if (
      props.hanif &&
      dayjs(dateStr + ' ' + (time.value ?? '00:00:00')).isBefore(dayjs(props.hanif))
    ) {
      time.value = dayjs(props.hanif).format('HH:mm:ss')
    }
    //左
    if (props.hanit && dayjs(dateStr + ' ' + time.value).isAfter(dayjs(props.hanit))) {
      time.value = dayjs(props.hanit).format('HH:mm:ss')
    }
  }
  const val = dateVal ? dateStr + ' ' + (props.isEnd ? '23:59:59' : time.value ?? '00:00:00') : null
  emit('update:value', val)
  emit('change', val)
}
function onChangeTime(timeStr: string | null) {
  //on the same day, limit both time
  if (isSameRangeDate.value) {
    //右
    if (props.hanif && dayjs(date.value + ' ' + timeStr).isBefore(dayjs(props.hanif))) {
      timeStr = time.value
    }
    //左
    if (props.hanit && dayjs(date.value + ' ' + timeStr).isAfter(dayjs(props.hanit))) {
      timeStr = time.value
    }
  }

  //on the same day, set the initial time
  if (!timeStr && props.hanif && isSameRangeDate.value && !props.isEnd) {
    timeStr = dayjs(props.hanif).format('HH:mm:ss')
  }

  time.value = timeStr || (props.isEnd ? '23:59:59' : '00:00:00')
  const val = date.value + ' ' + time.value

  emit('update:value', val)
  emit('change', val)
}

//time range limit-------------------------------------------------------------------------------------------
function range(start: number, end: number) {
  return Array.from({ length: end - start + 1 }, (_, index) => start + index)
}
const sameHanif = computed(
  () => props.hanif && dayjs(props.value).isSame(dayjs(props.hanif), 'day')
)
const sameHanit = computed(
  () => props.hanit && dayjs(props.value).isSame(dayjs(props.hanit), 'day')
)
const disabledHours = () => {
  if (!isSameRangeDate.value) return
  if (sameHanif.value && sameHanit.value) {
    return [...range(0, dayjs(props.hanif).hour() - 1), ...range(dayjs(props.hanit).hour() + 1, 24)]
  }
  if (sameHanif.value) {
    return range(0, dayjs(props.hanif).hour() - 1)
  }
  if (sameHanit.value) {
    return range(dayjs(props.hanit).hour() + 1, 24)
  }
  return
}
const disabledMinutes = (selectedHour) => {
  if (!isSameRangeDate.value) return

  const before = () => {
    if (selectedHour === dayjs(props.hanif).hour()) {
      return range(0, dayjs(props.hanif).minute() - 1)
    } else {
      return []
    }
  }
  const after = () => {
    if (selectedHour === dayjs(props.hanit).hour()) {
      return range(dayjs(props.hanit).minute() + 1, 60)
    } else {
      return []
    }
  }

  if (sameHanif.value && sameHanit.value) {
    return [...before(), ...after()]
  }
  if (sameHanif.value) {
    return before()
  }
  if (sameHanit.value) {
    return after()
  }
  return
}
const disabledSeconds = (selectedHour, selectedMinute) => {
  if (!isSameRangeDate.value) return

  const before = () => {
    if (
      selectedHour === dayjs(props.hanif).hour() &&
      selectedMinute === dayjs(props.hanif).minute()
    ) {
      return range(0, dayjs(props.hanif).second() - 1)
    } else {
      return []
    }
  }
  const after = () => {
    if (
      selectedHour === dayjs(props.hanit).hour() &&
      selectedMinute === dayjs(props.hanit).minute()
    ) {
      return range(dayjs(props.hanit).second() + 1, 60)
    } else {
      return []
    }
  }

  if (sameHanif.value && sameHanit.value) {
    return [...before(), ...after()]
  }
  if (sameHanif.value) {
    return before()
  }
  if (sameHanit.value) {
    return after()
  }
  return
}
</script>
