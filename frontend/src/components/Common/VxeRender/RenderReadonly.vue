<template>
  <span v-if="row.inputkbn === Enum画面項目入力.選択">
    {{ row.value?.split(' : ')[1] }}
  </span>
  <span v-else-if="row.inputkbn === Enum画面項目入力.選択_検索">
    {{ getLabelByValue(row.value, row.cdlist) }}
  </span>
  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日付_年月日">
    {{ row.value && getDateJpText(new Date(row.value)) }}
  </span>
  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日付_年月日_不詳あり">
    {{ row.value && getUnKnownDateJpText(row.value) }}
  </span>
  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日時_年月日時分秒">
    {{ row.value && getDateHmsJpText(new Date(row.value)) }}
  </span>
  <span v-else> {{ row.value }}</span>
</template>

<script setup lang="ts">
import {
  getDateHmsJpText,
  getDateJpText,
  getLabelByValue,
  getUnKnownDateJpText
} from '@/utils/util'
import { Enum入力タイプ, Enum画面項目入力 } from '#/Enums'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  row: FixFreeItemBaseVM
}>()
</script>
