<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 個人照会
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.12
 * 作成者　　: 王
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="個人照会"
    centered
    :mask-closable="false"
    destroy-on-close
  >
    <a-spin :spinning="loading">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="6">
            <th>宛名番号</th>
            <TD>{{ $route.query.atenano }}</TD>
          </a-col>
          <a-col span="6">
            <th>氏名</th>
            <TD>{{ userInfo?.name }}</TD>
          </a-col>
          <a-col span="6">
            <th>カナ氏名</th>
            <TD>{{ userInfo?.kname }}</TD>
          </a-col>
          <a-col span="6">
            <th>性別</th>
            <TD>{{ userInfo?.sex }}</TD>
          </a-col>
          <a-col span="6">
            <th>生年月日</th>
            <TD>{{ userInfo?.bymd }}</TD>
          </a-col>
          <a-col span="6">
            <th>住民区分</th>
            <TD>{{ userInfo?.juminkbn }}</TD>
          </a-col>
          <a-col span="6">
            <th>行政区</th>
            <TD>{{ userInfo?.gyoseiku }}</TD>
          </a-col>
        </a-row>
      </div>

      <a-tabs v-model:activeKey="activeKey_type" size="small" class="mt-2 h-137">
        <a-tab-pane key="1" tab="住民情報その他">
          <Tab1
            :detailinfo1="detailinfo1"
            :age="userInfo?.age"
            :agekijunymd="userInfo?.agekijunymd"
          />
        </a-tab-pane>
        <a-tab-pane key="2" tab="課税・保険・介護情報">
          <Tab2 :detailinfo2="detailinfo2" />
        </a-tab-pane>
        <template v-if="userInfo?.keikoku" #rightExtra>
          <WarnAlert />
        </template>
      </a-tabs>
    </a-spin>
    <template #footer>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import { Search } from './service'
import { Tab1DetailVM, HeaderVM, Tab2DetailVM } from './type'
import TD from '@/components/Common/TableTD/index.vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import Tab1 from './components/tab1.vue'
import Tab2 from './components/tab2.vue'

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()

const userInfo = ref<HeaderVM | null>(null)

// 住民情報その他
const detailinfo1 = ref<Tab1DetailVM | null>(null)
//  課税・保険・介護情報
const detailinfo2 = ref<Tab2DetailVM | null>(null)
const visible = ref(false)
const loading = ref(false)
const activeKey_type = ref('1')

//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
const getDetail = () => {
  loading.value = true
  Search({ atenano: route.query.atenano as string })
    .then((res) => {
      userInfo.value = res.headerinfo
      detailinfo1.value = res.detailinfo1
      detailinfo2.value = res.detailinfo2
    })
    .finally(() => (loading.value = false))
}

const openModal = () => {
  visible.value = true
  getDetail()
}

const closeModal = () => {
  visible.value = false
}

defineExpose({
  open: openModal
})
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 100px;
}
</style>
