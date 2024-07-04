<template>
  <div>
    <b>{{ title }}</b>
    <div class="self_adaption_table">
      <a-row>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>宛名番号</th>
          <TD>{{ headerInfo?.atenano }}</TD>
        </a-col>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>性別</th>
          <TD>{{ headerInfo?.sex }}</TD>
        </a-col>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>住民区分</th>
          <TD>{{ headerInfo?.juminkbn }}</TD>
        </a-col>

        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>生年月日</th>
          <TD>{{ headerInfo?.bymd }}</TD>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>氏名</th>
          <TD>{{ headerInfo?.name }}</TD>
        </a-col>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>年齢</th>
          <TD class="mincho">{{ headerInfo?.age }}</TD>
        </a-col>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>カナ氏名</th>
          <TD>{{ headerInfo?.kname }}</TD>
        </a-col>
        <a-col span="6" :sm="12" :xl="12" :xxl="6">
          <th>年齢計算基準日</th>
          <TD>{{ headerInfo?.kijunymd }}</TD>
        </a-col>
      </a-row>
    </div>
  </div>
</template>

<script setup lang="ts">
import { PersonalHeaderInfoVM } from '../type'
const props = defineProps<{
  headerInfo: PersonalHeaderInfoVM | null
  title?: string
}>()
</script>

<style scoped lang="less">
th {
  width: 180px;
}
</style>
