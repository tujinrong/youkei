<template>
  <a-input-number
    v-if="
      [
        Enum入力タイプ.数値_整数,
        Enum入力タイプ.数値_小数点付き実数,
        Enum入力タイプ.数値_符号付き整数
      ].includes(props.inputtype)
    "
    v-model:value="curVal"
    string-mode
    :precision="props.inputtype === Enum入力タイプ.数値_小数点付き実数 ? undefined : 0"
    class="w-full"
    maxlength="100"
  ></a-input-number>
  <DateJp
    v-else-if="props.inputtype === Enum入力タイプ.日付_年月日"
    v-model:value="curVal"
    style="width: 190px"
    format="YYYY-MM-DD"
  />
  <DateJp
    v-else-if="props.inputtype === Enum入力タイプ.日付_年月日_不詳あり"
    v-model:value="curVal"
    unknown
    style="width: 190px"
    format="YYYY-MM-DD"
    @emit-unknown-date="(v) => (curVal = v)"
  />
  <DateTime
    v-else-if="props.inputtype === Enum入力タイプ.日時_年月日時分秒"
    v-model:value="curVal"
  />
  <a-input v-else disabled></a-input>
</template>

<script lang="ts" setup>
import { computed } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import DateTime from '@/components/Selector/DateTime/index.vue'
import { Enum入力タイプ } from '#/Enums'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: string
  inputtype: Enum入力タイプ
}>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    return props.value
  },
  set(val) {
    emit('update:value', val)
  }
})
</script>
