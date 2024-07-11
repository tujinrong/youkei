<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 個人照会
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.12
 * 作成者　　: 王
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <div class="self_adaption_table ml-[1px]">
      <div class="font-bold">個人情報</div>
      <a-row>
        <a-col span="12">
          <th>年齢(現在)</th>
          <TD>{{ age }}</TD>
        </a-col>
        <a-col span="12">
          <th>年齢計算基準日</th>
          <TD>{{ agekijunymd }}</TD>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="12">
          <th>年齢(年度末)</th>
          <TD>{{ detailinfo1?.age_nendo }}</TD>
        </a-col>
        <a-col span="12">
          <th>年齢計算基準日</th>
          <TD>{{ detailinfo1?.agekijunymd_nendo }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="self_adaption_table ml-[1px]">
      <div class="font-bold mt4">世帯情報</div>
      <a-row>
        <a-col span="12">
          <th>世帯番号</th>
          <TD>{{ detailinfo1?.setaino }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="mt4"></div>
    <div>
      <vxe-table
        height="300"
        :column-config="{ resizable: true }"
        :row-config="{ isHover: true }"
        :data="detailinfo1?.kekkalist"
        :scroll-y="{ enabled: true, oSize: 10 }"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
        :row-class-name="({ row }) => (row.stopflg ? 'bg-disabled' : '')"
      >
        <vxe-column field="atenano" title="宛名番号" sortable> </vxe-column>
        <vxe-column field="name" title="氏名" sortable> </vxe-column>
        <vxe-column field="kname" title="カナ氏名" sortable> </vxe-column>
        <vxe-column field="zokuhyoki" title="続柄" sortable> </vxe-column>
        <vxe-column field="sex" title="性別" sortable> </vxe-column>
        <vxe-column field="bymd" title="生年月日" sortable> </vxe-column>
        <vxe-column field="juminkbn" title="住民区分" sortable> </vxe-column>
        <vxe-column field="keikoku" title="警告内容" sortable> </vxe-column>
      </vxe-table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Tab1DetailVM } from '../type'
import TD from '@/components/Common/TableTD/index.vue'

const { detailinfo1 } = defineProps<{
  detailinfo1: Tab1DetailVM | null
  age?: string
  agekijunymd?: Date | string
}>()
</script>

<style lang="less" scoped>
th {
  width: 120px;
}
</style>
