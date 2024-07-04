<template>
  <a-spin :spinning="loadings.some((el) => el)">
    <a-card ref="headRef">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="12" :xxl="6">
            <th>NO</th>
            <TD>{{ +edano || '' }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>業務</th>
            <TD>{{ gyomu }}</TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :xxl="6">
            <th>宛名番号</th>
            <TD>{{ headInfo.atenano }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>性別</th>
            <TD>{{ headInfo.sex }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>住民区分</th>
            <TD>{{ headInfo.juminkbn }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>生年月日</th>
            <TD>{{ headInfo.bymd }}</TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :xxl="6">
            <th>氏名</th>
            <TD>{{ headInfo.name }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>カナ氏名</th>
            <TD>{{ headInfo.kname }}</TD>
          </a-col>
          <a-col :md="0" :xxl="6">
            <TD></TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>年齢</th>
            <TD>{{ headInfo.age }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>出欠区分</th>
            <TD>{{ headInfo.syukketukbn }}</TD>
          </a-col>
          <a-col :md="0" :xxl="12">
            <TD></TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>年齢計算基準日</th>
            <TD>{{ headInfo.kijunymd }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button
            key="submit"
            style="float: left"
            :disabled="!route.meta.updflg"
            type="warn"
            @click="saveData"
            >登録</a-button
          >
          <a-button type="primary" danger :disabled="!canDelete" @click="handleDel">削除</a-button>
          <a-button type="primary">計算</a-button>
          <a-button type="primary" @click="forwardList">一覧へ</a-button>
        </a-space>
        <a-space>
          <WarnAlert v-show="headInfo.keikoku" />
          <a-button class="ml-a" type="primary" @click="forwardList">閉じる</a-button>
        </a-space>
      </div>
    </a-card>
    <a-card class="mt-2" :style="{ marginBottom: barHeight + 8 + 'px' }">
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
      </a-tabs>
      <div class="self_adaption_table">
        <a-row align="middle">
          <a-col :md="5" :xl="6" :xxl="6">
            <a-checkbox
              v-if="activeKey == Enum申込結果参加者.申込"
              :checked="mosiinputflg"
              :disabled="!(route.meta.updflg && editflg1)"
              @change="onChangeMosiinputflg"
            >
              申込情報入力
            </a-checkbox>
            <a-checkbox
              v-if="activeKey == Enum申込結果参加者.結果"
              :checked="kekkainputflg"
              :disabled="!(route.meta.updflg && editflg2)"
              @change="onChangeKekkainputflg"
            >
              結果情報入力
            </a-checkbox>
          </a-col>
          <a-col :md="8" :xl="8" :xxl="8">
            <th v-show="activeKey == Enum申込結果参加者.結果" :class="canEdit2 && 'bg-editable'">
              地域保健集計区分
            </th>
            <td v-show="activeKey == Enum申込結果参加者.結果">
              <a-form-item>
                <ai-select
                  v-model:value="syukeikbn"
                  :options="props.initdetail?.syukeikbnlist"
                  split-val
                  :disabled="!canEdit2"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col :offset="4" :md="7" :xl="6" :xxl="6">
            <th class="bg-readonly w-25!">登録支所</th>
            <TD>{{ regsisyonm }}</TD>
          </a-col>
        </a-row>
      </div>
      <div
        class="justify-between m-t-1"
        :style="{ height: Math.max(400, tableHeight - barHeight) + 'px' }"
      >
        <RightTable
          v-show="activeKey === Enum申込結果参加者.申込"
          ref="rightTableRef"
          :table-data="mosifreeitemlist"
          :can-edit="canEdit1"
          :grouplist1="mosigrouplist1"
          :grouplist2="mosigrouplist2"
        />
        <RightTable
          v-show="activeKey === Enum申込結果参加者.結果"
          ref="rightTableRef"
          :table-data="kekkafreeitemlist"
          :can-edit="canEdit2"
          :grouplist1="kekkagrouplist1"
          :grouplist2="kekkagrouplist2"
          :syukeikbn="syukeikbn"
        />
      </div>
    </a-card>
    <OperationFooter ref="footerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { Enum申込結果参加者, PageSatatus } from '#/Enums'
import { computed, nextTick, onMounted, ref, watch } from 'vue'
import RightTable from '@/views/affect/KK/AWKK00301G/components/RightTable.vue'
import {
  FreeItemDispInfoVM,
  HeaderInfoVM,
  InitDetailVM,
  SankasyaKekkaInfoVM,
  SankasyaMosikomiInfoVM
} from '../../type'
import { reactive } from 'vue'
import { Judgement } from '@/utils/judge-edited'
import { DeleteSankasya, SaveSankasya, SearchSankasyaDetail } from '../../service'
import { showConfirmModal, showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
import { A000003, C011003, DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { useElementSize } from '@vueuse/core'
import { useTableHeight } from '@/utils/hooks'
import { useRoute } from 'vue-router'

const props = defineProps<{
  initdetail: InitDetailVM | null
  status: PageSatatus
}>()
const emit = defineEmits(['update:status'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const edano = route.query.edano as string
const gyomu = route.query.gyomu as string
const editJudge = new Judgement()

//表の高さ
const footerRef = ref(null)
const { height: barHeight } = useElementSize(footerRef)
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -50)

//フリー項目Ref
const rightTableRef = ref<InstanceType<typeof RightTable> | null>(null)
//選択タブkey
const activeKey = ref<Enum申込結果参加者>(Enum申込結果参加者.申込)
//ローディング
const loadings = ref([true, true])
//登録支所
const regsisyonm = ref('')
const regsisyocd = ref('')

//地域保健集計区分(結果タブのみ)
const syukeikbn = ref('')

//申込フリー項目
const mosiinputflg = ref(false) //入力フラグ
const mosifreeitemlist = ref<FreeItemDispInfoVM[]>([])
const mosigrouplist1 = ref<DaSelectorModel[]>([])
const mosigrouplist2 = ref<DaSelectorModel[]>([])
const editflg1 = ref(true) //支所編集可能フラグ
//結果フリー項目
const kekkainputflg = ref(false)
const kekkafreeitemlist = ref<FreeItemDispInfoVM[]>([])
const kekkagrouplist1 = ref<DaSelectorModel[]>([])
const kekkagrouplist2 = ref<DaSelectorModel[]>([])
const editflg2 = ref(true)

//ヘッダー情報
const headInfo = reactive<HeaderInfoVM>({
  age: '', //年齢
  kijunymd: '', //年齢計算基準日
  syukketukbn: '', //出欠区分
  atenano: '', //宛名番号
  name: '', //氏名
  kname: '', //カナ氏名
  sex: '', //性別（名称）
  bymd: '', //生年月日（和暦表示）
  juminkbn: '', //住民区分（名称）
  keikoku: '' //警告内容
})

const canEdit1 = computed(() => Boolean(route.meta.updflg && editflg1.value && mosiinputflg.value))
const canEdit2 = computed(() => Boolean(route.meta.updflg && editflg2.value && kekkainputflg.value))
const canDelete = computed(() => route.meta.delflg && editflg1.value && editflg2.value)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  //申込タブ初期化
  SearchSankasyaDetail({
    atenano: route.query.atenano as string,
    gyomukbn: gyomu,
    edano: Number(edano),
    mosikomikekkakbn: String(Enum申込結果参加者.申込)
  })
    .then((res) => {
      Object.assign(headInfo, res.headerinfo)
      mosiinputflg.value = res.fixinfo.inputflg
      mosigrouplist1.value = res.grouplist1
      mosigrouplist2.value = res.grouplist2
      mosifreeitemlist.value = res.freeitemlist
      regsisyonm.value = res.fixinfo.regsisyonm
      regsisyocd.value = res.fixinfo.regsisyocd
      editflg1.value = res.editflg
      nextTick(() => editJudge.reset())
      //支援対象者の場合、警告メッセージを表示
      if (res.headerinfo.keikoku) {
        showInfoModal({
          type: 'warning',
          content: A000003.Msg.replace('{0}', res.headerinfo.keikoku)
        })
      }
    })
    .finally(() => (loadings.value[0] = false))

  //結果タブ初期化
  SearchSankasyaDetail({
    atenano: route.query.atenano as string,
    gyomukbn: gyomu,
    edano: Number(edano),
    mosikomikekkakbn: String(Enum申込結果参加者.結果)
  })
    .then((res) => {
      kekkainputflg.value = res.fixinfo.inputflg
      kekkagrouplist1.value = res.grouplist1
      kekkagrouplist2.value = res.grouplist2
      kekkafreeitemlist.value = res.freeitemlist
      syukeikbn.value = res.fixinfo.syukeikbn
      editflg2.value = res.editflg
      nextTick(() => editJudge.reset())
    })
    .finally(() => (loadings.value[1] = false))
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//編集状態監視
watch(
  () => [
    syukeikbn.value,
    mosiinputflg.value,
    kekkainputflg.value,
    mosifreeitemlist.value.map((el) => el.value),
    kekkafreeitemlist.value.map((el) => el.value)
  ],
  () => editJudge.setEdited(),
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
// 一覧へ
const forwardList = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:status', PageSatatus.List)
  })
}

//登録
const saveData = async () => {
  //申込情報
  const mosiInfo = reactive<SankasyaMosikomiInfoVM>({
    inputflg: mosiinputflg.value,
    regsisyocd: regsisyocd.value,
    freeiteminfo: mosifreeitemlist.value.map((el) => ({
      inputtype: el.inputtypekbn,
      item: el.itemcd,
      value: el.value
    }))
  })
  //結果情報
  const kekkaInfo = reactive<SankasyaKekkaInfoVM>({
    inputflg: kekkainputflg.value,
    regsisyocd: regsisyocd.value,
    freeiteminfo: kekkafreeitemlist.value.map((el) => ({
      inputtype: el.inputtypekbn,
      item: el.itemcd,
      value: el.value
    })),
    //地域保健集計区分
    syukeikbn: syukeikbn.value
  })
  const saveReq = async (checkflg: boolean) => {
    await SaveSankasya({
      maininfo: {
        gyomukbn: gyomu,
        edano: Number(edano),
        atenano: headInfo.atenano,
        mosikomiinfo: mosiInfo,
        kekkainfo: kekkaInfo
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
        forwardList()
      })
    }
  })
}

//削除
const handleDel = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await DeleteSankasya({
          atenano: headInfo.atenano,
          edano: Number(edano),
          gyomukbn: gyomu
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        forwardList()
      } catch (error) {}
    }
  })
}

// check off 確認メッセージ
const onChangeMosiinputflg = (e) => {
  if (mosiinputflg.value) {
    showConfirmModal({
      content: C011003.Msg,
      onOk() {
        mosiinputflg.value = e.target.checked
      }
    })
  } else {
    mosiinputflg.value = e.target.checked
  }
}
const onChangeKekkainputflg = (e) => {
  if (kekkainputflg.value) {
    showConfirmModal({
      content: C011003.Msg,
      onOk() {
        kekkainputflg.value = e.target.checked
      }
    })
  } else {
    kekkainputflg.value = e.target.checked
  }
}
</script>

<style scoped lang="less">
th {
  width: 150px;
}
</style>
