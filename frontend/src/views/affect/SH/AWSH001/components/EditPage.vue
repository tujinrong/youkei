<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ロジック共通仕様処理(検診)詳細画面
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>年度</th>
            <TD>{{ yearFormatter(Number(route.query.nendo)) }}</TD>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="4">
            <th>宛名番号</th>
            <TD>{{ route.query.atenano }}</TD>
          </a-col>
          <a-col v-if="personalnoFlg" :md="12" :xl="8" :xxl="4">
            <th>個人番号</th>
            <TD>{{ userInfo.personalno ? decryptByRSA(userInfo.personalno, privkey) : '' }}</TD>
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
            <TD>{{ userInfo.sexhyoki }}</TD>
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
            <th>年齡計算基準日</th>
            <TD>{{ userInfo.agekijunymd }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button
            v-if="addFlg || updFlg"
            type="warn"
            :disabled="TableAreaRef ? !TableAreaRef.canSaveData : false"
            :loading="loading_save"
            @click="saveData"
            >登録</a-button
          >
          <a-button
            v-if="delFlg"
            type="primary"
            danger
            :disabled="TableAreaRef ? !TableAreaRef.canDeleteAll : false"
            @click="deleteData"
            >削除</a-button
          >
          <a-button
            type="primary"
            :loading="loading_cal"
            :disabled="TableAreaRef ? !TableAreaRef.canSaveData : false"
            @click="calculate"
            >計算</a-button
          >
          <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
        </a-space>
        <a-space>
          <WarnAlert v-if="userInfo.keikoku" />
          <close-page />
        </a-space>
      </div>
    </a-card>
    <a-card
      class="my-2"
      :loading="loading && !tablesData"
      :style="{ marginBottom: height + 8 + 'px' }"
    >
      <TableArea
        ref="TableAreaRef"
        v-model:tables-data="tablesData"
        v-model:keylist="keylist"
        v-model:editflg1="editflg1"
        v-model:editflg2="editflg2"
        v-bind="{
          addflg,
          delflg,
          showflg1,
          showflg2,
          showflg3,
          grouplist1,
          grouplist2,
          msgids,
          coupon
        }"
        @change-tab="getTablesData"
      />
    </a-card>
    <OperationFooter ref="footerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { judgeStore } from '@/store/index'
import { A000003, CLOSE_CONFIRM, J024001 } from '@/constants/msg'
import { Enum遷移区分 } from '#/Enums'
import { yearFormatter } from '@/utils/util'
import { showConfirmModal, showInfoModal } from '@/utils/modal'
import { cancelRequest } from '@/utils/http/common-service'
import { decryptByRSA } from '@/utils/encrypt/data'
import { useElementSize } from '@vueuse/core'
import TableArea from './TableArea.vue'
import TD from '@/components/Common/TableTD/index.vue'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { fixItemlist1, fixItemlist2 } from '../constant'
import { KsFixItemVM, KsHeaderVM, KsLockVM, KsTimeSearchVM } from '../type'
import { InitDetail } from '../service'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const loading_save = ref(false)
const loading_cal = ref(false)
const TableAreaRef = ref<InstanceType<typeof TableArea> | null>(null)
//ヘッダー情報
const userInfo = ref<KsHeaderVM>({
  name: '',
  kname: '',
  sexhyoki: '',
  bymd: '',
  juminkbn: '',
  age: '',
  agekijunymd: '',
  personalno: '',
  keikoku: '',
  kensinkibosyasyosaiflg: true
})
//明細情報(回目ごと)
const tablesData = ref<KsTimeSearchVM>({
  itemlist1: [],
  itemlist2: [],
  itemlist3: []
})
const keylist = ref<KsLockVM[]>([])
const grouplist1 = ref<DaSelectorModel[]>([])
const grouplist2 = ref<DaSelectorModel[]>([])
const msgids = ref({ errormsgid: '', alertmsgid: '' })
const coupon = ref()

//操作権限取得
const addflg = ref(false)
const delflg = ref(false)
const editflg1 = ref(true)
const editflg2 = ref(true)
const showflg1 = ref(true)
const showflg2 = ref(false)
const showflg3 = ref(false)
const personalnoFlg = route.meta.personalnoflg
const updFlg = route.meta.updflg
const addFlg = route.meta.addflg
const delFlg = route.meta.delflg
//秘密キー
const privkey = ref('')

const footerRef = ref(null)
const { height } = useElementSize(footerRef)

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
//警告処理
onMounted(async () => {
  await getTablesData()
  //健（検）診予約希望者、データがない
  if (!userInfo.value.kensinkibosyasyosaiflg) {
    showInfoModal({
      content: J024001.Msg
    })
  }
  //支援対象者の場合、警告メッセージを表示
  if (userInfo.value.keikoku) {
    showInfoModal({
      type: 'warning',
      content: A000003.Msg.replace('{0}', userInfo.value.keikoku)
    })
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検診結果取得(回目ごと)
async function getTablesData(kensinkaisu?: number) {
  loading.value = true
  await InitDetail({
    nendo: Number(route.query.nendo),
    atenano: route.query.atenano as string,
    kbn: Enum遷移区分.初期化,
    kensinkaisu
  })
    .then((res) => {
      if (res.rsaprivatekey) privkey.value = res.rsaprivatekey
      userInfo.value = res.headerinfo
      keylist.value = res.keylist
      const arr = res.grouplist1.map((el) => ({ ...el, disabled: false }))
      grouplist1.value = [{ value: '', label: 'すべて', disabled: false }, ...arr]
      grouplist2.value = [{ value: '', label: 'すべて' }, ...res.grouplist2]
      addflg.value = res.addflg
      delflg.value = res.delflg
      editflg1.value = res.editflg1
      editflg2.value = res.editflg2
      showflg1.value = res.showflg1
      showflg2.value = res.showflg2
      showflg3.value = res.showflg3
      coupon.value = res.coupon
      msgids.value = { errormsgid: res.errormsgid, alertmsgid: res.alertmsgid }

      fixItemlist1[2].cdlist = res.selectorlist //検査方法 選択リスト
      const fixlist1 = fixItemlist1.map((el) => {
        return { ...el, value: res.kekka[el.itemcd as string] }
      })
      if (!res.showflg3) fixlist1.splice(2, 1) //検査方法 表示

      const fixlist2 = fixItemlist2.map((el) => {
        return { ...el, value: res.kekka[el.itemcd as string] }
      })
      res.kekka.itemlist1 = [...(fixlist1 as KsFixItemVM[]), ...res.kekka.itemlist1]
      res.kekka.itemlist2 = [...(fixlist2 as KsFixItemVM[]), ...res.kekka.itemlist2]

      tablesData.value = res.kekka
      return Promise.resolve()
    })
    .catch(() => {
      forwardSearch()
      return Promise.reject()
    })
    .finally(() => {
      loading.value = false
    })
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

//削除処理(削除ボタン：全ての回目)
function deleteData() {
  TableAreaRef.value?.deleteAll()
}
//保存処理
async function saveData() {
  loading_save.value = true
  try {
    await TableAreaRef.value?.submit()
  } catch (error) {}
  loading_save.value = false
}
//計算処理
async function calculate() {
  loading_cal.value = true
  await TableAreaRef.value?.calculate()
  loading_cal.value = false
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
</style>
