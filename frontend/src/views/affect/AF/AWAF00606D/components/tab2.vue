<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 個人照会
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.12
 * 作成者　　: 王
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="p-[1px]">
    <div class="self_adaption_table">
      <div class="font-bold mt4"></div>
      <a-row>
        <a-col span="12">
          <th style="width: 200px">課税非課税区分（世帯）</th>
          <TD>{{ detailinfo2?.kazeikbn_setai }}</TD>
        </a-col>
        <a-col span="12">
          <th style="width: 200px">保険区分</th>
          <TD>{{ detailinfo2?.hokenkbn }}</TD>
        </a-col>
      </a-row>
    </div>

    <div class="self_adaption_table">
      <div class="font-bold mt4">個人住民税</div>
      <a-row>
        <a-col span="12">
          <th style="width: 200px">課税非課税区分</th>
          <TD>{{ detailinfo2?.kazeikbn }}</TD>
        </a-col>
      </a-row>
    </div>

    <div class="self_adaption_table">
      <div class="font-bold mt4">国民健康保険</div>
      <a-row>
        <a-col span="6">
          <th style="width: 140px">国保記号番号</th>
          <TD>{{ detailinfo2?.kokuho_kigono }}</TD>
        </a-col>
        <a-col span="2">
          <th style="width: 50px">枝番</th>
          <TD>{{ detailinfo2?.kokuho_edano }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">国保資格取得年月日</th>
          <TD>{{ detailinfo2?.kokuho_sikakusyutokuymd }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">国保資格喪失年月日</th>
          <TD>{{ detailinfo2?.kokuho_sikakusosituymd }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="self_adaption_table">
      <div class="font-bold mt4">後期高齢支援</div>
      <a-row>
        <a-col span="8">
          <th style="width: 140px">被保険者番号</th>
          <TD>{{ detailinfo2?.hihokensyano1 }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">被保険者資格取得年月日</th>
          <TD>{{ detailinfo2?.hiho_sikakusyutokuymd }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">被保険者資格喪失年月日</th>
          <TD>{{ detailinfo2?.hiho_sikakusosituymd }}</TD>
        </a-col>
      </a-row>
    </div>

    <div class="self_adaption_table">
      <div class="font-bold mt4">生活保護</div>
      <a-row>
        <a-col span="6">
          <th style="width: 140px">生活保護開始年月日</th>
          <TD>{{ detailinfo2?.seihoymdf }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 100px">停止年月日</th>
          <TD>{{ detailinfo2?.teisiymd }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">停止解除年月日</th>
          <TD>{{ detailinfo2?.teisikaijoymd }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 105px">廃止年月日</th>
          <TD>{{ detailinfo2?.haisiymd }}</TD>
        </a-col>
      </a-row>
    </div>

    <div class="self_adaption_table">
      <div class="font-bold mt4">介護保険</div>
      <a-row>
        <a-col span="8">
          <th style="width: 200px">要介護状態区分コード</th>
          <TD>{{ detailinfo2?.yokaigojotaikbnnm }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">被保険者番号</th>
          <TD>{{ detailinfo2?.hihokensyano2 }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">要介護認定日</th>
          <TD>{{ detailinfo2?.yokaigoninteiymd }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">要介護認定有効期間開始日</th>
          <TD>{{ detailinfo2?.yokaigoyukoymdf }}</TD>
        </a-col>
        <a-col span="8">
          <th style="width: 200px">要介護認定有効期間終了日</th>
          <TD>{{ detailinfo2?.yokaigoyukoymdt }}</TD>
        </a-col>
      </a-row>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Tab2DetailVM } from '../type'
import TD from '@/components/Common/TableTD/index.vue'

const { detailinfo2 } = defineProps<{
  detailinfo2: Tab2DetailVM | null
}>()
</script>

<style scoped></style>
