<template>
  <div v-for="(item1, index) in rows" :key="index" class="mb-2">
    <div v-if="item1.title" class="font-bold">{{ item1.title }}</div>
    <a-row>
      <a-col
        v-for="item2 in item1.cols"
        :key="item2.label"
        :span="
          item2.label === '宛名番号' && !personalnoflg
            ? 24
            : item2.label === '個人番号' && !personalnoflg
            ? 0
            : item2.span
        "
        :md="item2.md"
        :xl="item2.xl"
      >
        <!-- 空白 -->
        <div v-if="!item2.label"></div>
        <div v-else-if="item2.label === '個人番号' && !personalnoflg"></div>

        <template v-else>
          <th :class="{ mincho: isMincho(item2.label) }" :style="{ width: item1.th_width + 'px' }">
            {{ item2.label }}
          </th>
          <!-- 在留期間年月日 -->
          <template v-if="item2.label === '在留期間'">
            <th style="width: 40px">年</th>
            <TD>{{ data?.zairyu_year }}</TD>
            <th style="width: 40px">月</th>
            <TD>{{ data?.zairyu_month }}</TD>
            <th style="width: 40px">日</th>
            <TD>{{ data?.zairyu_day }}</TD>
          </template>
          <!-- 個人番号 -->
          <td v-else-if="item2.label === '個人番号'" class="pl-3.5!">
            {{
              isShowPersonNo
                ? decryptByRSA(data?.personalno, privkey)
                : data?.personalno
                ? '✳✳✳✳✳✳'
                : ''
            }}
            <a-button
              type="primary"
              :disabled="!data?.personalno"
              :style="{ float: 'right', filter: isShowPersonNo ? 'hue-rotate(60deg)' : '' }"
              @click="isShowPersonNo = !isShowPersonNo"
              >{{ isShowPersonNo ? '非表示' : '表示' }}</a-button
            >
          </td>
          <!-- 複数 -->
          <TD v-else-if="item2.list">
            <template v-for="el in item2.list" :key="el.field">
              <a-checkbox :checked="data?.[el.field]" disabled />{{ ' ' + el.label }}
            </template>
          </TD>
          <!-- 年度 -->
          <template v-else-if="item2.label.includes('年度')">
            <TD>{{ data?.[item2.field] ? yearFormatter(data[item2.field]) : '' }}</TD>
          </template>
          <!-- 和暦(文字から変換) -->
          <TD v-else :class="{ mincho: isMincho(item2.label) }">
            {{
              REGEX_date.test(data?.[item2.field])
                ? getUnKnownDateJpText(data?.[item2.field])
                : item2.label === '郵便番号'
                ? formatYubin(String(data?.[item2.field] ?? ''))
                : String(data?.[item2.field] ?? '')
            }}
          </TD>
        </template>
      </a-col>
    </a-row>
    <!-- 地区 -->
    <a-row v-if="item1.tikulist">
      <a-col v-for="(el, idx) in data?.tikulist ?? []" :key="idx" span="24">
        <th :style="{ width: item1.th_width + 'px' }">{{ el.tikukbn }}</th>
        <TD class="mincho">{{ el.tiku }}</TD>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import TD from '@/components/Common/TableTD/index.vue'
import { DataAndVM, DetailRow } from '../type'
import { useRoute } from 'vue-router'
import { decryptByRSA } from '@/utils/encrypt/data'
import { formatYubin, getUnKnownDateJpText, yearFormatter } from '@/utils/util'
import { REGEX_date } from '@/constants/constant'

const props = defineProps<{
  rows: DetailRow<DataAndVM>[]
  data: { [key: string]: any } | null
  /**秘密鍵*/
  privkey?: string
}>()

const route = useRoute()
const isShowPersonNo = ref(false)
//個人番号権限フラグ
const personalnoflg = route.meta.personalnoflg

//書体
function isMincho(label: string) {
  return (
    label.indexOf('住所') >= 0 ||
    label.indexOf('氏名') >= 0 ||
    label.indexOf('力ナ') >= 0 ||
    label.indexOf('漢字') >= 0
  )
}
</script>
