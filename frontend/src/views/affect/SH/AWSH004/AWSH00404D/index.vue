<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 対象サイン
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="対象サイン"
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
      </a-row>
    </div>
    <vxe-table
      :data="tableData"
      :loading="loading"
      :height="330"
      :column-config="{ resizable: true }"
      :row-config="{ isHover: true }"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="kensahoho" title="検診種別・検査方法"> </vxe-column>
      <vxe-column field="sign1" title="仮対象サイン" width="120" />
      <vxe-column field="kijunymd" title="年齢計算基準日" width="140" />
      <vxe-column field="age" title="年齢" width="80" />
      <vxe-column field="kyohiriyu" title="受診拒否理由" width="140" />
      <vxe-column field="sign2" title="対象サイン" width="120" :class-name="setSignClass" />
    </vxe-table>
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
import { RowVM } from './type'
import { yearFormatter } from '@/utils/util'

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const nendo = Number(route.query.nendo)
const visible = ref(false)
const loading = ref(false)
const userInfo = ref<CommonBarHeaderBaseVM | null>(null)
const tableData = ref<RowVM[]>([])
//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
const searchData = async () => {
  loading.value = true
  try {
    const res = await Search({
      atenano: route.query.atenano as string,
      nendo: Number(route.query.nendo),
      nitteino: Number(route.query.nitteino)
    })
    userInfo.value = res.headerinfo
    tableData.value = res.kekkalist
  } catch (error) {}
  loading.value = false
}

const openModal = () => {
  visible.value = true
  searchData()
}

defineExpose({
  open: openModal
})

function setSignClass({ row }) {
  const signs = {
    対象外: 'c-red6',
    対象: 'c-blue6',
    不明: 'c-green6'
  }
  return signs[row.sign2]
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
