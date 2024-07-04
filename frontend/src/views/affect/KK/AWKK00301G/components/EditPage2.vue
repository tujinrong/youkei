<template>
  <a-spin :spinning="loadings.some((el) => el)">
    <div>
      <a-card ref="headRef" :bordered="false">
        <CommonHeader :header-info="headerInfo" />
        <div class="mt-2 flex justify-between">
          <a-space>
            <a-button
              key="submit"
              style="float: left"
              type="warn"
              :disabled="!(isNew || updFlg)"
              @click="onSubmit"
              >登録</a-button
            >
            <a-button type="primary" danger :disabled="!delFlg || isNew" @click="onDelete"
              >削除</a-button
            >
            <a-button type="primary" :loading="loading_cal" @click="onCalculate">計算</a-button>
            <a-button type="primary" @click="forwardList">一覧へ</a-button>
          </a-space>
          <a-space>
            <WarnAlert v-if="headerInfo?.keikoku" />
            <ClosePage />
          </a-space>
        </div>
      </a-card>
      <a-card
        :bordered="false"
        :loading="loadings[0]"
        class="mt-2"
        :style="{ marginBottom: barHeight + 8 + 'px' }"
      >
        <div class="self_adaption_table">
          <a-row>
            <a-col span="4" :sm="8" :xl="6" :xxl="4">
              <th>保健指導区分</th>
              <TD> {{ Enum指導区分[params.hokensidokbn] }}</TD>
            </a-col>
            <a-col span="4" :sm="8" :xl="6" :xxl="4">
              <th>業務</th>
              <TD>
                {{
                  Object.keys(Enum保健指導業務区分).find(
                    (k) =>
                      Enum保健指導業務区分[k as keyof typeof Enum保健指導業務区分] ===
                      params.gyomukbn
                  )
                }}</TD
              >
            </a-col>
          </a-row>
        </div>
        <a-card :bordered="false" class="mt-1 m-l--2.5">
          <a-tabs v-model:activeKey="activeKey" type="card">
            <a-tab-pane :key="Enum申込結果.申込" :tab="Enum申込結果[Enum申込結果.申込]">
            </a-tab-pane>
            <a-tab-pane :key="Enum申込結果.結果" :tab="Enum申込結果[Enum申込結果.結果]">
            </a-tab-pane>
          </a-tabs>
        </a-card>
        <Tab1
          v-show="activeKey === Enum申込結果.申込"
          ref="tabRef1"
          v-model:loading="loadings[1]"
          :initdetail="initdetail"
          :params="params"
          :style="{ height: isXL ? Math.max(400, tableHeight - barHeight) + 'px' : 'auto' }"
          :edit-judge="editJudge"
          @emit-headerinfo="(val) => (headerInfo = val)"
        />
        <Tab2
          v-show="activeKey === Enum申込結果.結果"
          ref="tabRef2"
          v-model:loading="loadings[2]"
          :initdetail="initdetail"
          :params="params"
          :tab1-ref="toRef(tabRef1)"
          :style="{ height: isXL ? Math.max(400, tableHeight - barHeight) + 'px' : 'auto' }"
          :edit-judge="editJudge"
        />
      </a-card>
    </div>
    <OperationFooter ref="footerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { Enum保健指導業務区分, Enum指導区分, Enum申込結果, PageSatatus } from '#/Enums'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { XL } from '@/utils/height'
import { useTableHeight } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize, useWindowSize } from '@vueuse/core'
import { message } from 'ant-design-vue'
import { computed, onMounted, ref, toRef } from 'vue'
import { Delete, InitDetail, Save } from '../service'
import {
  InitDetailVM,
  KekkaInfoVM,
  MosikomiInfoVM,
  PersonalHeaderInfoVM,
  SearchPersonDetailRequest
} from '../type'
import CommonHeader from './CommonHeader.vue'
import Tab1 from './Tab1.vue'
import Tab2 from './Tab2.vue'
import { useRoute } from 'vue-router'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  params: Omit<SearchPersonDetailRequest, keyof DaRequestBase | 'mosikomikekkakbn'> & {
    status: PageSatatus
  }
}>()
const emit = defineEmits(['refresh'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const route = useRoute()
const loadings = ref([true, true, true])
const editJudge = new Judgement(route.name as string)
const activeKey = ref<Enum申込結果>(Enum申込結果.申込)
const tabRef1 = ref<InstanceType<typeof Tab1> | null>(null)
const tabRef2 = ref<InstanceType<typeof Tab2> | null>(null)

const headerInfo = ref<PersonalHeaderInfoVM | null>(null)
const initdetail = ref<InitDetailVM | null>(null)

//操作権限
const isNew = props.params.edano <= 0
const updFlg = route.meta.updflg as boolean
const delFlg = route.meta.delflg as boolean
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()

  try {
    const res = await InitDetail()
    initdetail.value = res.initdetail
  } catch (error) {}
  loadings.value[0] = false
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const footerRef = ref(null)
const { height: barHeight } = useElementSize(footerRef)
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -62)
const { width } = useWindowSize()
const isXL = computed(() => width.value >= XL)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//保存処理
const onSubmit = async () => {
  const promises = [tabRef1.value?.validate(), tabRef2.value?.validate()]

  Promise.allSettled(promises).then(async (res) => {
    const isAllSucess = res.every((item) => item.status === 'fulfilled')
    if (isAllSucess) {
      const mosikomiinfo = tabRef1.value?.getSaveForm() as MosikomiInfoVM
      const kekkainfo = tabRef2.value?.getSaveForm() as KekkaInfoVM
      const saveReq = async (checkflg: boolean) => {
        await Save({
          maininfo: {
            ...props.params,
            mosikomiinfo,
            kekkainfo
          },
          checkflg
        })
      }
      await saveReq(true)
      showSaveModal({
        onOk: async () => {
          saveReq(false).then(() => {
            emit('refresh')
            editJudge.reset()
            message.success(SAVE_OK_INFO.Msg)
            forwardList()
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
//削除処理
const onDelete = () => {
  showDeleteModal({
    async onOk() {
      try {
        await Delete(props.params)
        emit('refresh')
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        forwardList()
      } catch (error) {}
    }
  })
}

function forwardList() {
  editJudge.judgeIsEdited(() => {
    props.params.status = PageSatatus.List
  })
}

//計算処理
const loading_cal = ref(false)
async function onCalculate() {
  loading_cal.value = true
  // await TableAreaRef.value?.calculate()
  loading_cal.value = false
}
</script>

<style lang="less" scoped>
th {
  width: 100px;
}
</style>
