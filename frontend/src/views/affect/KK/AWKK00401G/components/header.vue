<template>
  <div class="self_adaption_table mb-2">
    <a-row>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>宛名番号</th>
        <TD>{{ $route.query.atenano }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>氏名</th>
        <TD>{{ data?.name }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>カナ氏名</th>
        <TD>{{ data?.kname }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th style="width: 120px">性別</th>
        <TD>{{ data?.sex }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>住民区分</th>
        <TD>{{ data?.juminkbn }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>生年月日</th>
        <TD>{{ data?.bymd }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>年齢</th>
        <TD>{{ data?.age }}</TD>
      </a-col>
      <a-col :md="12" :xl="6" :xxl="6">
        <th>年齢計算基準日</th>
        <TD>{{ data?.agekijunymd }}</TD>
      </a-col>
      <a-col :md="12" :xl="12" :xxl="12">
        <th>住所</th>
        <TD>{{ data?.adrs }}</TD>
      </a-col>
      <a-col v-show="data?.personalno" :md="12" :xl="6" :xxl="6">
        <th>個人番号</th>
        <TD>{{ data?.personalno }}</TD>
      </a-col>
      <a-col v-show="showSisyo" :md="12" :xl="6" :xxl="6">
        <th>登録支所</th>
        <TD>{{ regsisyo }}</TD>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  data: GamenHeaderBase2VM | null
  showSisyo?: boolean
  regsisyo?: string
}>()
</script>

<style lang="less" scoped>
th {
  width: 120px;
}
</style>
