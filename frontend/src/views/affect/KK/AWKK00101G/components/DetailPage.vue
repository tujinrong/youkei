<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 住民記録台帳照会(詳細情報画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :loading="loading">
    <div class="self_adaption_table mb-2">
      <a-row>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>宛名番号</th>
          <TD>{{ route.query.atenano }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>氏名</th>
          <TD>{{ headerInfo?.name }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>カナ氏名</th>
          <TD>{{ headerInfo?.kname }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>性別</th>
          <TD>{{ headerInfo?.sex }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>生年月日</th>
          <TD>{{ headerInfo?.bymd }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>住民区分</th>
          <TD>{{ headerInfo?.juminkbn }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>課税非課税区分（世帯）</th>
          <TD>{{ headerInfo?.kazeikbn_setai }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>保険区分</th>
          <TD>{{ headerInfo?.hokenkbn }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>年齢</th>
          <TD>{{ headerInfo?.age }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>年齡計算基準日</th>
          <TD>{{ headerInfo?.agekijunymd }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 flex justify-between">
      <a-button type="primary" @click="forwardSetai">一覧へ</a-button>
      <a-space>
        <WarnAlert v-if="headerInfo?.keikoku" />
        <ClosePage />
      </a-space>
    </div>
  </a-card>
  <a-card class="mt-2" :style="{ marginBottom: height + 8 + 'px' }">
    <a-tabs v-model:activeKey="activeKey" type="card">
      <a-tab-pane key="1" tab="住基"><Tab1 /></a-tab-pane>
      <a-tab-pane key="2" tab="課税・納税義務者"><Tab2 /></a-tab-pane>
      <a-tab-pane key="3" tab="税額控除"><Tab3 /></a-tab-pane>
      <a-tab-pane key="4" tab="国保">
        <TabCommon
          title="国保資格情報"
          service="AWKK00106D"
          :detail-rows="row_kokuho"
          :search-request="SearchKokuhoDetail"
          :modal-columns="columns_106"
      /></a-tab-pane>
      <a-tab-pane key="5" tab="後期">
        <TabCommon
          title="被保険者情報"
          service="AWKK00107D"
          :detail-rows="row_koki"
          :search-request="SearchKokiDetail"
          :modal-columns="columns_107"
      /></a-tab-pane>
      <a-tab-pane key="6" tab="生保">
        <TabCommon
          title="生活保護情報"
          service="AWKK00108D"
          :detail-rows="row_seiho"
          :search-request="SearchSeihoDetail"
          :modal-columns="columns_108"
      /></a-tab-pane>
      <a-tab-pane key="7" tab="介護">
        <TabCommon
          title="被保険者情報"
          service="AWKK00109D"
          :detail-rows="row_kaigo"
          :search-request="SearchKaigoDetail"
          :modal-columns="columns_109"
      /></a-tab-pane>
      <a-tab-pane key="8" tab="福祉">
        <TabCommon
          title="身体障害者手帳情報"
          service="AWKK00110D"
          :detail-rows="row_syogai"
          :search-request="SearchSyogaiDetail"
          :modal-columns="columns_110"
      /></a-tab-pane>
    </a-tabs>
  </a-card>
  <OperationFooter ref="footerRef" />
</template>

<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { InitDetail } from '../service'
import { PersonHeaderVM } from '../type'
import { A000003 } from '@/constants/msg'
import { showInfoModal } from '@/utils/modal'
import TD from '@/components/Common/TableTD/index.vue'
import Tab1 from './Tab1.vue'
import Tab2 from './Tab2.vue'
import Tab3 from './Tab3.vue'
import TabCommon from './TabCommon.vue'
import { columns as columns_106 } from '@/views/affect/KK/AWKK00106D/content'
import { columns as columns_107 } from '@/views/affect/KK/AWKK00107D/content'
import { columns as columns_108 } from '@/views/affect/KK/AWKK00108D/content'
import { columns as columns_109 } from '@/views/affect/KK/AWKK00109D/content'
import { columns as columns_110 } from '@/views/affect/KK/AWKK00110D/content'
import {
  SearchKokuhoDetail,
  SearchKokiDetail,
  SearchSeihoDetail,
  SearchKaigoDetail,
  SearchSyogaiDetail
} from '../service'
import { row_kokuho, row_koki, row_seiho, row_kaigo, row_syogai } from '../content'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize } from '@vueuse/core'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const activeKey = ref('1')
const headerInfo = ref<PersonHeaderVM | null>(null)

const footerRef = ref(null)
const { height } = useElementSize(footerRef)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getHeaderInfo()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const getHeaderInfo = async () => {
  loading.value = true
  const res = await InitDetail({
    atenano: route.query.atenano as string
  })
  headerInfo.value = res.headerinfo
  loading.value = false
  if (res.headerinfo.keikoku) {
    showInfoModal({
      type: 'warning',
      content: A000003.Msg.replace('{0}', res.headerinfo.keikoku)
    })
  }
}

function forwardSetai() {
  router.push({
    name: 'AWKK00101G',
    query: {
      atenano: route.query.prevno
    }
  })
}
</script>

<style scoped>
th {
  width: 185px;
}
</style>
