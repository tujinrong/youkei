<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　:住登外者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :loading="loading">
    <div class="self_adaption_table mb-2">
      <a-row>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>宛名番号</th>
          <TD>{{ headerInfo?.atenano }}</TD>
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
          <TD>{{ headerInfo?.juminkbnnm }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>年齢</th>
          <TD>{{ headerInfo?.age }}</TD>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <th>年齡計算基準日</th>
          <TD>{{ headerInfo?.agekijunymd }}</TD>
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
          <th>削除</th>
          <TD>{{ headerInfo?.stop }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 flex justify-between">
      <a-space>
        <a-button type="primary" :disabled="!canIdo" @click="tab1Ref?.handleIdo">異動</a-button>
        <a-button type="warn" :disabled="!canEdit" @click="tab1Ref?.saveData">登録</a-button>
        <a-button type="primary" :disabled="!canDelete" danger @click="tab1Ref?.handleDelete"
          >削除</a-button
        >
        <a-button type="primary" @click="forwardList">一覧へ</a-button>
      </a-space>
      <a-space>
        <WarnAlert v-if="headerInfo?.keikoku" />
        <ClosePage />
      </a-space>
    </div>
  </a-card>
  <a-card class="mt-2" :style="{ marginBottom: height + 8 + 'px' }">
    <a-tabs v-model:activeKey="activeKey" type="card">
      <a-tab-pane key="1" tab="基本情報等">
        <Tab1 ref="tab1Ref" v-model:ido="ido" :judge="editJudge" />
      </a-tab-pane>
      <a-tab-pane key="2" tab="課税・納税義務者"><Tab2 /></a-tab-pane>
      <a-tab-pane key="3" tab="税額控除"><Tab3 /></a-tab-pane>
      <a-tab-pane key="4" tab="国保">
        <TabCommon
          title="国保資格情報"
          service="AWKK00106D"
          :detail-rows="row_kokuho"
          :search-request="SearchKokuhoDetail"
          :modal-columns="columns_106"
        />
      </a-tab-pane>
      <a-tab-pane key="5" tab="後期">
        <TabCommon
          title="被保険者情報"
          service="AWKK00107D"
          :detail-rows="row_koki"
          :search-request="SearchKokiDetail"
          :modal-columns="columns_107"
        />
      </a-tab-pane>
      <a-tab-pane key="6" tab="生保">
        <TabCommon
          title="生活保護情報"
          service="AWKK00108D"
          :detail-rows="row_seiho"
          :search-request="SearchSeihoDetail"
          :modal-columns="columns_108"
        />
      </a-tab-pane>
      <a-tab-pane key="7" tab="介護">
        <TabCommon
          title="被保険者情報"
          service="AWKK00109D"
          :detail-rows="row_kaigo"
          :search-request="SearchKaigoDetail"
          :modal-columns="columns_109"
        />
      </a-tab-pane>
      <a-tab-pane key="8" tab="福祉">
        <TabCommon
          title="身体障害者手帳情報"
          service="AWKK00110D"
          :detail-rows="row_syogai"
          :search-request="SearchSyogaiDetail"
          :modal-columns="columns_110"
        />
      </a-tab-pane>
    </a-tabs>
  </a-card>
  <OperationFooter v-if="!isNew" ref="footerRef" />
</template>

<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router'
import { onMounted, ref, computed } from 'vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize } from '@vueuse/core'
import Tab1 from './Tab1.vue'
import Tab2 from '@/views/affect/KK/AWKK00101G/components/Tab2.vue'
import Tab3 from '@/views/affect/KK/AWKK00101G/components/Tab3.vue'

import { PageSatatus } from '#/Enums'
import { BaseInfoVM } from '../type'
import { Judgement } from '@/utils/judge-edited'
import { C001010 } from '@/constants/msg'
import { columns as columns_106 } from '@/views/affect/KK/AWKK00106D/content'
import { columns as columns_107 } from '@/views/affect/KK/AWKK00107D/content'
import { columns as columns_108 } from '@/views/affect/KK/AWKK00108D/content'
import { columns as columns_109 } from '@/views/affect/KK/AWKK00109D/content'
import { columns as columns_110 } from '@/views/affect/KK/AWKK00110D/content'
import {
  row_kokuho,
  row_koki,
  row_seiho,
  row_kaigo,
  row_syogai
} from '@/views/affect/KK/AWKK00101G/content'
import {
  SearchKokuhoDetail,
  SearchKokiDetail,
  SearchSeihoDetail,
  SearchKaigoDetail,
  SearchSyogaiDetail
} from '@/views/affect/KK/AWKK00101G/service'
import TabCommon from '@/views/affect/KK/AWKK00101G/components/TabCommon.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const activeKey = ref('1')
const editJudge = new Judgement(route.name as string)
const tab1Ref = ref<InstanceType<typeof Tab1> | null>(null)
const footerRef = ref(null)
const { height } = useElementSize(footerRef)
const headerInfo = computed<BaseInfoVM | undefined>(() => tab1Ref.value?.headerInfo)
//異動
const ido = ref(false)
//操作権限
const isNew = Number(route.query.status) === PageSatatus.New
const updFlg = route.meta.updflg as boolean
const delFlg = route.meta.delflg as boolean
const canEdit = computed(() => (isNew || updFlg) && ido.value)
const canDelete = computed(() => !isNew && delFlg && ido.value)
const canIdo = computed(() => route.query.atenano && updFlg && !ido.value)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (!route.query.atenano) ido.value = true
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function forwardList() {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  }, C001010.Msg)
}
</script>

<style scoped>
th {
  width: 185px;
}
</style>
