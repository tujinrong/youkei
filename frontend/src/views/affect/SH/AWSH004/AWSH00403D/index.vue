<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 料金内訳
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.26
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="料金内訳"
    centered
    :mask-closable="false"
    destroy-on-close
  >
    <div class="self_adaption_table mb-4">
      <a-row>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>年度</th>
          <TD>{{ yearFormatter(nendo) }}</TD>
        </a-col>
      </a-row>
      <a-row>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>宛名番号</th>
          <TD>{{ $route.query.atenano }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>氏名</th>
          <TD>{{ userInfo?.name }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>カナ氏名</th>
          <TD>{{ userInfo?.kname }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>性別</th>
          <TD>{{ userInfo?.sex }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>生年月日</th>
          <TD>{{ userInfo?.bymd }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>住民区分</th>
          <TD>{{ userInfo?.juminkbn }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>年齢</th>
          <TD>{{ userInfo?.age }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>年齢計算基準日</th>
          <TD>{{ userInfo?.agekijunymd }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>減免区分(特定)</th>
          <TD>{{ userInfo?.genmenkbn_tokutei }}</TD>
        </a-col>
        <a-col :md="24" :lg="12" :xl="8" :xxl="6">
          <th>減免区分(がん)</th>
          <TD>{{ userInfo?.genmenkbn_gan }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="w-160">
      <div class="text-right">单位：円</div>
      <vxe-table
        :data="tableData"
        :loading="loading"
        :height="270"
        :column-config="{ resizable: true, useKey: true }"
        :row-config="{ isHover: true, useKey: true }"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column field="kensahoho" title="検診種別・検査方法" width="50%"> </vxe-column>
        <vxe-column
          field="jusinkingaku"
          title="受診金額"
          :formatter="formatKingaku"
          type="html"
          header-align="left"
          align="right"
        />
        <vxe-column
          field="kingaku_sityosonhutan"
          title="金額(市区町村負担)"
          :formatter="formatKingaku"
          type="html"
          header-align="left"
          align="right"
        />
      </vxe-table>
    </div>
    <template #footer>
      <a-button type="primary" @click="visible = false">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import { Search } from './service'
import { HeaderVM, RowVM } from './type'
import { VxeColumnPropTypes } from 'vxe-table'
import { yearFormatter } from '@/utils/util'

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const nendo = Number(route.query.nendo)
const visible = ref(false)
const loading = ref(false)
const userInfo = ref<HeaderVM | null>(null)
const tableData = ref<RowVM[]>([])
const props = defineProps<{
  list: {
    jigyocd: string
    nitteino: number
    kensahohocdnm: string
  }[]
}>()
//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
const searchData = async () => {
  loading.value = true
  try {
    const res = await Search({
      atenano: route.query.atenano as string,
      nendo: Number(route.query.nendo),
      kekkalist: props.list
    })
    userInfo.value = res.headerinfo
    tableData.value = res.kekkalist
  } catch (error) {}
  loading.value = false
}

const formatKingaku: VxeColumnPropTypes.Formatter = ({ cellValue }) => {
  if (!cellValue) return ''
  const localeStr = Number(cellValue).toLocaleString()
  return isNaN(cellValue) ? `<span class="c-red5!">${cellValue}</span>` : localeStr
}

const openModal = () => {
  visible.value = true
  searchData()
}

defineExpose({
  open: openModal
})
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
