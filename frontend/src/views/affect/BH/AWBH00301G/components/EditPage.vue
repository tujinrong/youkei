<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 妊産婦情報管理-詳細画面
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.01
 * 作成者　　: gaof
 * 変更履歴　:
 * ---------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>宛名番号</th>
            <TD>{{ route.query.atenano }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>氏名</th>
            <TD class="mincho">{{ userInfo.name }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>カナ氏名</th>
            <TD>{{ userInfo.kname }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>性別</th>
            <TD>{{ userInfo.sex }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>生年月日</th>
            <TD>{{ userInfo.bymd }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>住民区分</th>
            <TD>{{ userInfo.juminkbn }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>年齢</th>
            <TD>{{ userInfo.age }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>年齢計算基準日</th>
            <TD>{{ userInfo.kijunymd }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button v-if="updFlg" type="warn" :disabled="!updFlg" @click="saveData">登録</a-button>
          <a-button v-if="delFlg" type="primary" :disabled="!delFlg" danger @click="deleteData"
            >削除</a-button
          >
          <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
          <a-button type="primary" @click="Ref_303?.open">乳幼児情報</a-button>
        </a-space>
        <a-space>
          <WarnAlert v-if="userInfo.keikoku" />
          <close-page />
        </a-space>
      </div>
    </a-card>
    <a-card class="my-2" :loading="loading" :style="{ marginBottom: height + 8 + 'px' }">
      <div class="self_adaption_table">
        <a-row class="graduation_number">
          <a-col :md="12" :xl="8" :xxl="6">
            <th>登録番号</th>
            <TD>
              {{ route.query.torokuno }}
            </TD>
          </a-col>
        </a-row>
      </div>
      <TableArea
        ref="TableAreaRef"
        :grouplist1="grouplist1"
        :grouplist2="grouplist2"
        :torokuno="route.query.torokuno as unknown as number"
      />
    </a-card>
    <OperationFooter ref="footerRef" />
    <AWBH00303D ref="Ref_303" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { cancelRequest } from '@/utils/http/common-service'
import { useElementSize } from '@vueuse/core'
import { HeaderInfoVM, SaveRequest, DeleteRequest, SaveData } from '../type'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import { A000003, CLOSE_CONFIRM } from '@/constants/msg'
import { judgeStore } from '@/store/index'
import { showConfirmModal, showSaveModal, showDeleteModal } from '@/utils/modal'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import TableArea from './TableArea.vue'
import { SearchDetail, Delete, Save } from '../service'
import { 母_1 } from '../constant'
import AWBH00303D from '../page/AWBH00303D/index.vue'
import { message } from 'ant-design-vue'
import emitter from '@/utils/event-bus'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const loading_cal = ref(false)
const TableAreaRef = ref()
const grouplist1 = ref<DaSelectorModel[]>([])
const grouplist2 = ref<DaSelectorModel[]>([])

const saveDataList = ref<SaveRequest[]>([])
const initDeleteData = ref<DeleteRequest>()
//ヘッダー情報
const userInfo = ref<HeaderInfoVM>({
  atenano: '',
  name: '',
  kname: '',
  sex: '',
  bymd: '',
  juminkbn: '',
  age: '',
  kijunymd: '',
  keikoku: ''
})

//操作権限取得
const updFlg = route.meta.updflg
const addFlg = route.meta.addflg
const delFlg = route.meta.delflg
//秘密キー
const privkey = ref('')
const Ref_303 = ref<InstanceType<typeof AWBH00303D> | null>(null)
const footerRef = ref(null)
const { height } = useElementSize(footerRef)
const tab1Ref = ref()
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  InIt()
})

//検索処理(宛名番号、個人番号以外の場合)
async function InIt() {
  loading.value = true
  SearchDetail({
    atenano: route.query.atenano as string,
    torokuno: route.query.torokuno as unknown as number,
    bosikbn: 母_1,
    pagesize: 0,
    pagenum: 0
  }).then((res) => {
    userInfo.value = res.headerinfo
    grouplist1.value = res.grouplist1
    grouplist2.value = res.grouplist2
    loading.value = false
  })
}

function getData() {
  saveDataList.value = TableAreaRef.value?.getData() as SaveRequest[]
}

const checkData = (): boolean => {
  return TableAreaRef.value?.getCheck() as boolean
}

//削除処理(削除ボタン：全ての回目)
function deleteData() {
  let temp = TableAreaRef.value?.getDeleteSelect() as DeleteRequest
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      loading.value = true
      try {
        await Delete(temp)
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
      loading.value = false
    }
  })
}

//保存処理
const saveData = async () => {
  getData()
  if (checkData()) {
    return
  }
  const saveReq = async (checkflg: boolean) => {
    await Save({
      saveinfo: saveDataList.value,
      checkflg
    })
  }
  await saveReq(true)
  showSaveModal({
    onOk: async () => {
      loading.value = true
      try {
        await saveReq(false)
        message.success(SAVE_OK_INFO.Msg)
        emitter.emit('changeStatus', route.query.atenano)
        loading.value = false
      } catch (error) {
        loading.value = false
      }
    }
  })
}

const toPage = () => {
  Ref_303.value?.open
}

//遷移処理(一覧へ)
function forwardSearch() {
  function back() {
    cancelRequest()
    router.push({
      name: route.name as string
    })
  }

  if (!judgeStore[route.name as string]) {
    back()
  } else {
    showConfirmModal({
      content: CLOSE_CONFIRM.Msg,
      onOk: async () => {
        back()
      }
    })
  }
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 110px;
}

.self_adaption_table .graduation_number {
  margin-bottom: 10px;
}

.self_adaption_table .graduation_number .graduation_number_select {
  width: 100%;
}
</style>
