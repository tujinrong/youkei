<template>
  <div v-show="params.status === PageSatatus.List">
    <a-card :bordered="false">
      <CommonHeader :header-info="headerInfo" />

      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
        </a-space>
        <a-space>
          <WarnAlert v-if="headerInfo?.keikoku" />
          <ClosePage />
        </a-space>
      </div>
    </a-card>
    <a-card :bordered="false" class="mt-3">
      <a-tabs v-model:activeKey="params.hokensidokbn" type="card">
        <a-tab-pane :key="String(Enum指導区分.訪問指導)" :tab="Enum指導区分[Enum指導区分.訪問指導]">
          <TabComs ref="tab1Ref" :params="params" @emit-header="(val) => (headerInfo = val)" />
        </a-tab-pane>
        <a-tab-pane
          :key="String(Enum指導区分.個別指導)"
          :params="params"
          :tab="Enum指導区分[Enum指導区分.個別指導]"
        >
          <TabComs ref="tab2Ref" :params="params" />
        </a-tab-pane>
      </a-tabs>
    </a-card>
  </div>
  <div v-if="params.status !== PageSatatus.List">
    <EditPage2 :params="params" @refresh="handleRefresh" />
  </div>
</template>

<script setup lang="ts">
import { Enum指導区分, PageSatatus } from '#/Enums'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { PersonalHeaderInfoVM, SearchPersonDetailRequest } from '../type'
import CommonHeader from './CommonHeader.vue'
import EditPage2 from './EditPage2.vue'
import TabComs from './TabComs.vue'
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const headerInfo = ref<PersonalHeaderInfoVM | null>(null)
const tab1Ref = ref<InstanceType<typeof TabComs> | null>(null)
const tab2Ref = ref<InstanceType<typeof TabComs> | null>(null)

const params = ref<
  Omit<SearchPersonDetailRequest, keyof DaRequestBase | 'mosikomikekkakbn'> & {
    status: PageSatatus
  }
>({
  atenano: route.query.atenano as string,
  hokensidokbn: String(Enum指導区分.訪問指導), //Enum指導区分
  gyomukbn: '',
  edano: 0,
  status: PageSatatus.List
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//遷移処理(一覧へ)
function forwardSearch() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      atenano: route.query.prevno as string
    }
  })
}

function handleRefresh() {
  if (+params.value.hokensidokbn === Enum指導区分.訪問指導) {
    tab1Ref.value?.init(false)
  } else {
    tab2Ref.value?.init(false)
  }
}
</script>
