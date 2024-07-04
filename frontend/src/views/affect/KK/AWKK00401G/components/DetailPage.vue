<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: フォロー管理(詳細画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.28
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :bordered="false">
      <Header ref="headRef" :data="header" :show-sisyo="showSisyo" :regsisyo="regsisyo" />
      <div class="flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit || loading" @click="saveData">登録</a-button>
          <a-button type="primary" danger :disabled="!canDelete" @click="handleDelete"
            >削除</a-button
          >
          <a-button type="primary" @click="editJudge.judgeIsEdited(() => back2ResultPage())"
            >一覧へ</a-button
          >
        </a-space>
        <a-space>
          <WarnAlert v-if="header?.keikoku" />
          <ClosePage />
        </a-space>
      </div>
    </a-card>
    <a-card
      class="my-2"
      :loading="loading"
      :style="{ minHeight: tableHeight - barHeight + 'px', marginBottom: barHeight + 8 + 'px' }"
    >
      <DetailPageCtx
        v-bind="{ isNew, loading1, canEdit, formData, options, validateInfos, setLastResult }"
      />
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, reactive, computed, nextTick, watch, inject } from 'vue'
import { useRoute } from 'vue-router'
import {
  DeleteFollowDetail,
  InitFollowDetail,
  SaveFollowDetail,
  SearchFollowDetail,
  SearchFollowDetailPreKekka
} from '../service'
import { FollowDetailVM, InitFollowDetailResponse } from '../type'
import { Enum編集区分, PageSatatus } from '#/Enums'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { DELETE_OK_INFO, ITEM_SELECTREQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import Header from './header.vue'
import DetailPageCtx from './DetailPageCtx.vue'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
  header: GamenHeaderBase2VM | null
  follownaiyoedano: number
  edano: number
  copyflg: boolean
  editJudge: Judgement
  regsisyo: string
  showSisyo: boolean
}>()
const emit = defineEmits(['back'])
const barHeight = inject<number>('barHeight', 0)
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const atenano = route.query.atenano as string
const loading = ref(true)

const formData = reactive<FollowDetailVM>({
  atenano,
  follownaiyoedano: props.follownaiyoedano,
  haakukeiro: '',
  haakujigyocd: '',
  follownaiyo: '',
  followjigyocd: '',
  edano: 0,
  sinkiEdano: 0,
  updflg: false,
  //予定情報
  yoteiinputflg: false,
  followhoho_yotei: '',
  followyoteiymd: '',
  followtm_yotei: '',
  followkaijocd_yotei: '',
  followstaffid_yotei: '',
  followriyu: '',
  //結果情報
  kekkainputflg: false,
  followhoho: '',
  followjissiymd: '',
  followtm: '',
  followkaijocd: '',
  followstaffid: '',
  followkekka: ''
})

const options = ref<
  Omit<InitFollowDetailResponse, 'followdetailvm' | 'showflg' | 'regsisyo' | keyof DaResponseBase>
>({
  followjigyoList: [],
  followhoho_yoteiList: [],
  followkaijocd_yoteiList: [],
  followhohoList: [],
  followkaijocdList: [],
  followstaffidList: [],
  followstaffid_yoteiList: [],
  zenkaisetflg: false
})

//項目の設定
const rules = reactive({
  followjigyocd: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'フォロー事業') }
  ]
})
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)

//操作権限
const isNew = props.status === PageSatatus.New
const updFlg = route.meta.updflg as boolean
const delFlg = route.meta.delflg as boolean
const canEdit = computed(() => isNew || (updFlg && formData.updflg))
const canDelete = computed(() => !props.copyflg && !isNew && delFlg && formData.updflg)

const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 6)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  await init()
  if (!isNew || (isNew && props.copyflg)) {
    searchData()
  } else {
    loading.value = false
  }
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => props.editJudge.setEdited())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
async function init() {
  const res = await InitFollowDetail({
    atenano,
    follownaiyoedano: props.follownaiyoedano,
    copyflg: props.copyflg,
    editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
  })
  options.value = res

  if (isNew) {
    Object.assign(formData, res.followdetailvm)
    nextTick(() => {
      clearValidate()
      props.editJudge.reset()
    })
  }
}

//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await SearchFollowDetail({
      atenano,
      follownaiyoedano: props.follownaiyoedano,
      edano: props.edano
    })
    Object.assign(formData, res.followdetailvm)
    options.value.zenkaisetflg = res.zenkaisetflg
  } catch (error) {}
  loading.value = false
  nextTick(() => props.editJudge.reset())
}

//前回結果情報セット
const loading1 = ref(false)
async function setLastResult() {
  loading1.value = true
  try {
    const res = await SearchFollowDetailPreKekka({
      atenano,
      follownaiyoedano: props.follownaiyoedano,
      edano: isNew ? formData.sinkiEdano : props.edano
    })
    Object.assign(formData, res)
    options.value.zenkaisetflg = res.zenkaisetflg
  } catch (error) {}
  loading1.value = false
}

//保存処理
async function saveData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      try {
        await SaveFollowDetail({
          followdetailvm: formData,
          yoteiinputflg: formData.yoteiinputflg,
          kekkainputflg: formData.kekkainputflg,
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
        })
        message.success(SAVE_OK_INFO.Msg)
        back2ResultPage(true)
      } catch (error) {}
    }
  })
}

//削除処理
function handleDelete() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await DeleteFollowDetail({
          atenano,
          follownaiyoedano: props.follownaiyoedano,
          edano: props.edano,
          upddttmyotei: formData.upddttmyotei,
          upddttmkekka: formData.upddttmkekka
        })
        message.success(DELETE_OK_INFO.Msg)
        back2ResultPage(true)
      } catch (error) {}
    }
  })
}

function back2ResultPage(refresh?) {
  emit('back', { refresh })
}
</script>
