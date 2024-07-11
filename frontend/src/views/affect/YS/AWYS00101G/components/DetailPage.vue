<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 住民記録台帳照会(詳細情報画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card>
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
    </a-tabs>
  </a-card>
  <OperationFooter ref="footerRef" />
</template>

<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { InitDetail } from '../service'
import { A000003 } from '@/constants/msg'
import { showInfoModal } from '@/utils/modal'
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
  try {
    const res = await InitDetail({
      atenano: route.query.atenano as string
    })
    headerInfo.value = res.headerinfo
    if (res.headerinfo.keikoku) {
      showInfoModal({
        type: 'warning',
        content: A000003.Msg.replace('{0}', res.headerinfo.keikoku)
      })
    }
  } catch (error) {}
}

function forwardSetai() {
  router.push({
    name: 'AWYS00101G',
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
