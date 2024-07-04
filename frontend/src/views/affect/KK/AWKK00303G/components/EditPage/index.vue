<template>
  <a-spin :spinning="loading">
    <div v-show="status === PageSatatus.List">
      <a-card ref="headRef" :bordered="false">
        <div class="self_adaption_table">
          <a-row>
            <a-col v-bind="{ sm: 12, xxl: 6 }">
              <th>NO</th>
              <TD>{{ +edano || '' }}</TD>
            </a-col>
            <a-col v-bind="{ sm: 12, xxl: 6 }">
              <th>業務</th>
              <TD>{{ initdetail?.gyomulist.find((el) => el.value === gyomu)?.label }}</TD>
            </a-col>
          </a-row>
        </div>
        <div class="m-t-1">
          <a-space>
            <a-button
              key="submit"
              style="float: left"
              type="warn"
              :disabled="!(isNew || updFlg)"
              @click="handleSave"
              >登録</a-button
            >
            <a-button type="primary" danger :disabled="!delFlg || isNew" @click="handleDel"
              >削除</a-button
            >
            <a-button type="primary" @click="forwardSearch()">一覧へ</a-button>
          </a-space>
          <close-page class="float-right"></close-page>
        </div>
      </a-card>
      <a-card class="mt-2">
        <a-tabs v-model:activeKey="activeKey" type="card">
          <a-tab-pane
            :key="Enum申込結果参加者.申込"
            :tab="Enum申込結果参加者[Enum申込結果参加者.申込]"
          >
          </a-tab-pane>
          <a-tab-pane
            :key="Enum申込結果参加者.結果"
            :tab="Enum申込結果参加者[Enum申込結果参加者.結果]"
          >
          </a-tab-pane>
          <a-tab-pane
            :key="Enum申込結果参加者.参加者"
            :tab="Enum申込結果参加者[Enum申込結果参加者.参加者]"
          ></a-tab-pane>
        </a-tabs>
        <Tab1
          v-show="activeKey === Enum申込結果参加者.申込"
          ref="tab1Ref"
          :initdetail="initdetail"
          :style="{ height: isXL ? Math.max(400, tableHeight) + 'px' : 'auto' }"
          :edit-judge="editJudge"
          @move-tab2="activeKey = Enum申込結果参加者.結果"
        />
        <Tab2
          v-show="activeKey === Enum申込結果参加者.結果"
          ref="tab2Ref"
          :initdetail="initdetail"
          :tab1-ref="toRef(tab1Ref)"
          :style="{ height: isXL ? Math.max(400, tableHeight) + 'px' : 'auto' }"
          :edit-judge="editJudge"
        />
        <Tab3
          v-show="activeKey === Enum申込結果参加者.参加者"
          ref="tab3Ref"
          v-model:status="status"
          :initdetail="initdetail"
          :style="{ height: isXL ? Math.max(400, tableHeight) + 'px' : 'auto' }"
          :edit-judge="editJudge"
        />
      </a-card>
    </div>
    <div v-if="status !== PageSatatus.List">
      <Tab3Detail v-model:status="status" :initdetail="initdetail" />
    </div>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, toRef } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { message } from 'ant-design-vue'
import { Enum申込結果参加者, PageSatatus } from '#/Enums'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { InitDetail, Save, Delete } from '../../service'
import { InitDetailVM, MosikomiSaveVM, KekkaSaveVM, SankasyaSaveVM } from '../../type'
import Tab1 from './Tab1.vue'
import Tab2 from './Tab2.vue'
import Tab3 from './Tab3.vue'
import Tab3Detail from './Tab3Detail.vue'
import { Judgement } from '@/utils/judge-edited'
import { useWindowSize } from '@vueuse/core'
import { useTableHeight } from '@/utils/hooks'
import { XL } from '@/utils/height'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(true)
const edano = route.query.edano as string
const gyomu = route.query.gyomu as string
const editJudge = new Judgement(route.name as string)
const tab1Ref = ref<InstanceType<typeof Tab1> | null>(null) // 申込
const tab2Ref = ref<InstanceType<typeof Tab2> | null>(null) // 結果
const tab3Ref = ref<InstanceType<typeof Tab3> | null>(null) // 参加者

const status = ref<PageSatatus>(PageSatatus.List)
const activeKey = ref<Enum申込結果参加者>(Enum申込結果参加者.申込)
const initdetail = ref<InitDetailVM | null>(null)

const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -2)
const { width } = useWindowSize()
const isXL = computed(() => width.value >= XL)

//操作権限
const isNew = +edano <= 0
const updFlg = route.meta.updflg as boolean
const delFlg = route.meta.delflg as boolean

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  editJudge.addEvent()

  InitDetail()
    .then((res) => (initdetail.value = res.initdetail))
    .finally(() => (loading.value = false))
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//登録
const handleSave = async () => {
  const promises = [tab1Ref.value?.validate(), tab2Ref.value?.validate(), tab3Ref.value?.validate()]

  Promise.allSettled(promises).then(async (res) => {
    const isAllSucess = res.every((item) => item.status === 'fulfilled')
    if (isAllSucess) {
      const mosikomiinfo = tab1Ref.value?.getSaveForm() as MosikomiSaveVM
      const kekkainfo = tab2Ref.value?.getSaveForm() as KekkaSaveVM
      const sankasyainfo = tab3Ref.value?.getSaveForm() as SankasyaSaveVM
      const saveReq = async (checkflg: boolean) => {
        await Save({
          maininfo: {
            gyomukbn: gyomu,
            edano: Number(edano),
            mosikomiinfo,
            kekkainfo,
            sankasyainfo
          },
          checkflg
        })
      }
      await saveReq(true)
      showSaveModal({
        onOk: async () => {
          saveReq(false).then(() => {
            editJudge.reset()
            message.success(SAVE_OK_INFO.Msg)
            forwardSearch(true)
          })
        }
      })
    } else {
      const errIndex = res.findIndex((item) => item.status === 'rejected')
      if (errIndex > -1) {
        activeKey.value = errIndex + 1
      }
    }
  })
}

//削除
const handleDel = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({
          gyomukbn: gyomu,
          edano: Number(edano)
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        forwardSearch(true)
      } catch (error) {}
    }
  })
}

//遷移処理(一覧へ)
const forwardSearch = (refresh?) => {
  editJudge.judgeIsEdited(() => {
    router.push({ path: 'AWKK00303G', query: { refresh } })
  })
}
</script>

<style scoped lang="less">
th {
  width: 150px;
}
</style>
