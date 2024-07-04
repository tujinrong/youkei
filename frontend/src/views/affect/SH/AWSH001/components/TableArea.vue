<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ロジック共通仕様処理(検診)回数タブ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-tabs
      id="kensin_tabs"
      :active-key="activeTabKey"
      class="highlight-tabs"
      :hide-add="!canCreate"
      type="editable-card"
      @edit="editTabs"
      @tab-click="clickTab"
    >
      <template #rightExtra>
        <a-space class="mb-2">
          <a-tag>一次登録支所：{{ data.regsisyonm1 }}</a-tag>
          <a-tag v-if="showflg1">精密登録支所：{{ data.regsisyonm2 }}</a-tag>
        </a-space>
      </template>
      <a-tab-pane
        v-for="pane in panes"
        :key="pane.key"
        :tab="pane.title"
        :closable="pane.closable"
      />
    </a-tabs>
    <a-row :gutter="[8, 8]" :style="{ height: mainHeight }" class="area-overflow">
      <a-col :md="24" :xl="24" :xxl="8" class="h-full">
        <a-form class="flex flex-col h-full">
          <div class="m-b-1 flex">
            <a-descriptions v-if="showflg2" bordered size="small">
              <a-descriptions-item
                label="クーポン番号"
                :label-style="{ padding: '2px 6px', backgroundColor: '#ffffe1' }"
                :content-style="{
                  padding: '2px 6px',
                  'min-width': '118px',
                  width: 'auto',
                  borderRight: 'none'
                }"
              >
                <span>{{ coupon }}</span>
              </a-descriptions-item>
            </a-descriptions>
            <a-button type="primary" shape="round" class="ml-auto" @click="setInitialValue"
              >初期値</a-button
            >
          </div>
          <div class="left-table">
            <vxe-table
              :class="['m-b-1', { 'mask-noselect': !hasList1 }]"
              :show-header="false"
              :data="itemlist1"
              :column-config="{ resizable: true }"
              :empty-render="{ name: 'NotData' }"
              :span-method="mergeFirstColumn"
            >
              <vxe-column
                width="35"
                :class-name="() => [canEdit1 ? 'bg-editable' : 'bg-readonly', 'vertical-text']"
              >
                <template #default="{ rowIndex }">
                  <template v-if="rowIndex === 0">
                    <a-checkbox
                      v-if="canEdit1"
                      :checked="hasList1"
                      @change="(e) => changeflg(e, 1)"
                    ></a-checkbox>
                    <span>一次検診</span>
                  </template>
                </template>
              </vxe-column>
              <vxe-column
                field="itemnm"
                width="130"
                :show-overflow="false"
                :class-name="
                  ({ row }) =>
                    !canEdit1 || row.itemcd === 'jissiage1' || row.itemcd === 'jissiage2'
                      ? 'bg-readonly'
                      : 'bg-editable'
                "
              >
                <template #default="{ row }">
                  {{ row.itemnm }}
                  <span v-if="canEdit1 && row.hissuflg" class="request-mark"> ＊ </span>
                  <div
                    v-if="
                      [
                        Enum入力タイプ.全角半角文字_全角半角_改行可,
                        Enum入力タイプ.全角文字_全角_改行可
                      ].includes(row.inputtypekbn)
                    "
                    class="show_count_box"
                  >
                    {{ `${row.value?.length ?? 0} / 1000` }}
                  </div>
                </template>
              </vxe-column>
              <vxe-column
                field="value"
                :show-overflow="false"
                :cell-render="{
                      name: 'CustomCell',
                      props: {
                        validateInfos: validateInfos1,
                        readonly: !canEdit1,
                        alertMsgid: msgids.alertmsgid
                      },
                      events: { onChange: (row:any, oldVal) => onChangeValue(row, EnumKensinKbn.一次, oldVal)}
                    }"
              >
              </vxe-column>
            </vxe-table>
            <vxe-table
              v-if="showflg1"
              :class="{ 'mask-noselect': !hasList2 }"
              :show-header="false"
              :data="itemlist2"
              :column-config="{ resizable: true }"
              :empty-render="{ name: 'NotData' }"
              :span-method="mergeFirstColumn"
            >
              <vxe-column
                width="35"
                :class-name="() => [canEdit2 ? 'bg-editable' : 'bg-readonly', 'vertical-text']"
              >
                <template #default="{ rowIndex }">
                  <template v-if="rowIndex === 0">
                    <a-checkbox
                      v-if="canEdit2"
                      :checked="hasList2"
                      @change="(e) => changeflg(e, 2)"
                    ></a-checkbox>
                    <span>精密検査</span>
                  </template>
                </template>
              </vxe-column>
              <vxe-column
                field="itemnm"
                width="130"
                :show-overflow="false"
                :class-name="
                  ({ row }) =>
                    !canEdit2 || row.itemcd === 'jissiage1' || row.itemcd === 'jissiage2'
                      ? 'bg-readonly'
                      : 'bg-editable'
                "
              >
                <template #default="{ row }">
                  {{ row.itemnm }}
                  <span v-if="canEdit1 && row.hissuflg" class="request-mark"> ＊ </span>
                  <div
                    v-if="
                      [
                        Enum入力タイプ.全角半角文字_全角半角_改行可,
                        Enum入力タイプ.全角文字_全角_改行可
                      ].includes(row.inputtypekbn)
                    "
                    class="show_count_box"
                  >
                    {{ `${row.value?.length ?? 0} / 1000` }}
                  </div>
                </template>
              </vxe-column>
              <vxe-column
                field="value"
                :show-overflow="false"
                :cell-render="{
                      name: 'CustomCell',
                      props: {
                        validateInfos: validateInfos2,
                        readonly: !canEdit2,
                        alertMsgid: msgids.alertmsgid
                      },
                      events: { onChange: (row:any) => onChangeValue(row,EnumKensinKbn.精密) }
                    }"
              >
              </vxe-column>
            </vxe-table>
          </div>
        </a-form>
      </a-col>
      <a-col :md="24" :xl="24" :xxl="16" class="h-full">
        <RightTable
          ref="rightTableRef"
          :table-data="itemlist3"
          :has-list1="hasList1"
          :has-list2="hasList2"
          :can-edit1="canEdit1"
          :can-edit2="canEdit2"
          :grouplist1="props.grouplist1"
          :grouplist2="props.grouplist2"
          :kensahoho="kensahoho"
          :check-seiken="checkSeikenDisabled"
        />
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick, watch, toRef } from 'vue'
import { Form, message } from 'ant-design-vue'
import { useWindowSize } from '@vueuse/core'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { getHeight, XXL } from '@/utils/height'
import { validateByInputtype } from '@/utils/validate'
import { Judgement } from '@/utils/judge-edited'
import { showConfirmModal, showDeleteModal, showSaveModal } from '@/utils/modal'
import emitter from '@/utils/event-bus'
import { mergeFirstColumn } from '@/utils/util'
import { DELETE_OK_INFO, SAVE_OK_INFO, A000004, C001019 } from '@/constants/msg'
import RightTable from './RightTable.vue'
import {
  Enum入力タイプ,
  EnumKensinKbn,
  Enum遷移区分,
  Enum削除区分,
  EnumServiceResult
} from '#/Enums'
import { GlobalStore, ProgramStore } from '@/store'
import { fixItemlist1, fixItemlist2 } from '../constant'
import { Save, Delete, GetKijun, InitDetail, GetAge, SeiKenEditCheck, Calculate } from '../service'
import {
  CommonResponse,
  KsFixItemVM,
  KsFreeItemVM,
  KsLockVM,
  KsTimeSearchVM,
  KsTimeUpdateVM,
  SaveRequest
} from '../type'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  tablesData: KsTimeSearchVM
  keylist: KsLockVM[]
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  addflg: boolean
  delflg: boolean
  editflg1: boolean
  editflg2: boolean
  showflg1: boolean
  showflg2: boolean
  showflg3: boolean
  msgids: { errormsgid: string; alertmsgid: string }
  coupon: string
}>()
const emit = defineEmits<{
  (e: 'changeTab', kensinkaisu?: number): void
  (e: 'update:tablesData', value: KsTimeSearchVM): void
  (e: 'update:keylist', value: KsLockVM[]): void
  (e: 'update:editflg1', value: boolean): void
  (e: 'update:editflg2', value: boolean): void
}>()
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const editJudge = new Judgement(route.name as string)
const rightTableRef = ref<InstanceType<typeof RightTable> | null>(null)
//入力フラグ(一次)
const hasList1 = ref(false)
//入力フラグ(精密)
const hasList2 = ref(false)
//回目(キー)
const activeTabKey = ref('')
//検診結果
const data = toRef(props, 'tablesData')
const itemlist1 = ref<KsFixItemVM[]>([]) //一次固定
const itemlist2 = ref<KsFixItemVM[]>([]) //精密固定
const itemlist3 = ref<KsFreeItemVM[]>([]) //フリー
//固定項目チェックモード
const model1 = reactive<{ [key: string]: unknown }>({})
const model2 = reactive<{ [key: string]: unknown }>({})
const rules1 = reactive<{ [key: string]: unknown }>({})
const rules2 = reactive<{ [key: string]: unknown }>({})
const {
  clearValidate: clearValidate1,
  validate: validate1,
  validateInfos: validateInfos1
} = Form.useForm(model1, rules1)
const {
  clearValidate: clearValidate2,
  validate: validate2,
  validateInfos: validateInfos2
} = Form.useForm(model2, rules2)
//共通パラメータ
const commonParams = {
  nendo: Number(route.query.nendo),
  atenano: route.query.atenano as string
}
//一覧状態更新用(編集対象)
let processedObj: Omit<CommonResponse, keyof DaResponseBase> = {
  atenano: '',
  statuslist: []
}

//操作権限取得
const addFlg = route.meta.addflg
const updFlg = route.meta.updflg
const delFlg = route.meta.delflg

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  editJudge.addEvent()
  //遷移順調整のため、不要な要素を削除
  const elements = document
    .getElementById('kensin_tabs')
    ?.getElementsByClassName('ant-tabs-content-holder')
  elements?.[0].parentNode?.removeChild(elements[0])
})
onBeforeRouteUpdate(async (to, from) => {
  editJudge.reset()
  //データ転送(一覧状態のため)
  emitter.emit('changeKensinStatus', { curid: ProgramStore.id, processedObj })
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { width } = useWindowSize()
const mainHeight = computed(() => (width.value >= XXL ? getHeight(330) : 'auto'))

//タブ生成(名称)
const panes = computed(() => {
  const panelist = props.keylist.map((item, index) => {
    return {
      title: `${index + 1}回目`,
      key: String(index + 1),
      closable:
        ((delFlg && props.editflg1 && props.editflg2) || !item.kensinkaisu) &&
        activeTabKey.value === String(index + 1)
    }
  })
  if (panelist.length === 0) {
    panelist.push({ title: '1回目', key: '1', closable: true })
  }
  return panelist
})
//新規権限(「＋」ボタン)
const canCreate = computed(() => {
  return addFlg && panes.value.length < 10 && props.addflg && data.value.kensinkaisu
})
//編集権限(一次)
const canEdit1 = computed(() => (updFlg || !data.value.kensinkaisu) && props.editflg1)
//編集権限(精密)
const canEdit2 = computed(() => (updFlg || !data.value.kensinkaisu) && props.editflg2)
//削除権限(削除ボタン:全ての回目)
const canDeleteAll = computed(() => delFlg && props.keylist.length > 0 && props.delflg)
//編集権限(登録ボタン：新規、変更、削除)
const canSaveData = computed(() => {
  if (canEdit1.value && canEdit2.value) {
    return hasList1.value || hasList2.value
  } else if (canEdit1.value) {
    return hasList1.value
  } else if (canEdit2.value) {
    return hasList2.value
  }
  return false
})

//一次/精密データの混合(検査方法により、itemlist3フリー項目、itemlist1/itemlist2固定項目を削除)
const list1data = computed(() => {
  const free1data = itemlist3.value
    .filter((item) => item.groupid == EnumKensinKbn.一次)
    .filter((item) => {
      if (item.riyokensahohocds.length > 0 && kensahoho.value) {
        return item.riyokensahohocds.includes(kensahoho.value)
      }
      return true
    })
  return hasList1.value ? [...itemlist1.value.slice(fixItemlist1.length), ...free1data] : []
})
const list2data = computed(() => {
  const free2data = itemlist3.value.filter((item) => item.groupid == EnumKensinKbn.精密)
  return hasList2.value ? [...itemlist2.value.slice(fixItemlist2.length), ...free2data] : []
})

//検査方法 for filter itemlist3
const kensahoho = computed<string>(() => {
  return itemlist1.value.find((el) => el.itemcd === 'kensahoho1')?.value?.split(' : ')[0] ?? ''
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//回目を切り替える時
watchEffect(() => {
  if (data.value) {
    hasList1.value = Boolean(data.value.upddttm1)
    hasList2.value = Boolean(data.value.upddttm2)
    if (props.showflg1 === false) hasList2.value = false
    itemlist1.value = data.value.itemlist1
    itemlist2.value = data.value.itemlist2
    itemlist3.value = data.value.itemlist3
    //チェック設定(固定項目)
    for (const el of itemlist1.value) {
      rules1[el.itemcd] = [
        { validator: (_, value) => validateByInputtype(value, el, props.msgids.errormsgid) }
      ]
    }
    for (const el of itemlist2.value) {
      rules2[el.itemcd] = [
        { validator: (_, value) => validateByInputtype(value, el, props.msgids.errormsgid) }
      ]
    }
    nextTick(() => {
      clearValidate1()
      clearValidate2()
      editJudge.reset()
    })
  }
})

//初期表示の回目
watch(
  () => props.keylist,
  (newVal, oldVal) => {
    if (oldVal.length === 0) {
      activeTabKey.value = String(newVal.length || 1)
    }
  }
)

//固定項目値変更処理
watchEffect(() => {
  for (const el of itemlist1.value) {
    model1[el.itemcd] = el.value
  }
  for (const el of itemlist2.value) {
    model2[el.itemcd] = el.value
  }
})

//実施日範囲制限設定
watch(
  () => [itemlist1.value[0]?.value, itemlist2.value[0]?.value],
  () => {
    itemlist1.value[0].hanit = itemlist2.value[0].value
    itemlist2.value[0].hanif = itemlist1.value[0].value
  }
)

//修正フラグ設定(現タブのデータが修正されたかどうか)
watch(
  () => [
    itemlist1.value.map((item) => item.value),
    itemlist2.value.map((item) => item.value),
    itemlist3.value.map((item) => item.value)
  ],
  () => editJudge.setEdited()
)

//チェック範囲設定(入力チェックがない場合、チェックを行わない)
watchEffect(() => {
  if (!hasList1.value) {
    clearValidate1()
    for (const el of itemlist1.value) {
      el.warntextflg = false
    }
  }
  if (!hasList2.value) {
    clearValidate2()
    for (const el of itemlist2.value) {
      el.warntextflg = false
    }
  }
})

//実施日取得(基準値のため)
watch(
  () => [itemlist1.value[0]?.value, itemlist2.value[0]?.value],
  ([jissiymd1, jissiymd2]) => {
    if (!hasList1.value && !hasList2.value) return
    if (!jissiymd1 && !jissiymd2) return
    GetKijun({
      jissiymd1: hasList1.value ? jissiymd1 : '',
      jissiymd2: hasList2.value ? jissiymd2 : '',
      kensahoho1: itemlist1.value.find((el) => el.itemcd === 'kensahoho1')?.value ?? '',
      freeitemlist: itemlist3.value
        .filter((el) => {
          if (!jissiymd2) return el.groupid === EnumKensinKbn.一次
          if (!jissiymd1) return el.groupid === EnumKensinKbn.精密
          return true
        })
        .map((el) => ({ groupid: el.groupid, itemcd: el.itemcd })),
      ...commonParams
    }).then((res) => {
      itemlist3.value.forEach((el) => {
        el.kijun = res.kekkalist.find((item) => item.itemcd === el.itemcd)
      })
    })
  },
  { immediate: true }
)

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//追加処理(タブごと)
async function addTab() {
  editJudge.judgeIsEdited(async () => {
    GlobalStore.setLoading(true)
    const res = await InitDetail({
      nendo: Number(route.query.nendo),
      atenano: route.query.atenano as string,
      kbn: Enum遷移区分.タブ追加
    })
    GlobalStore.setLoading(false)

    res.kekka.itemlist1 = [...JSON.parse(JSON.stringify(fixItemlist1)), ...res.kekka.itemlist1]
    res.kekka.itemlist2 = [...JSON.parse(JSON.stringify(fixItemlist2)), ...res.kekka.itemlist2]

    emit('update:tablesData', res.kekka)
    emit('update:keylist', [...props.keylist, {}])
    nextTick(() => {
      activeTabKey.value = String(props.keylist.length)
      emit('update:editflg1', true)
      emit('update:editflg2', true)
      setTimeout(() => {
        editJudge.setEdited()
      }, 0)
    })
  })
}
//削除処理(タブごと)
function removeTab() {
  const isOld = Boolean(data.value.kensinkaisu)
  showDeleteModal({
    handleDB: isOld,
    async onOk() {
      //削除既存の回目
      if (isOld) {
        const res = await Delete({
          kensinkaisu: data.value.kensinkaisu,
          locklist: props.keylist,
          delkbn: Enum削除区分.単一削除,
          ...commonParams
        })
        processedObj = res
        message.success(DELETE_OK_INFO.Msg)
        router.push({ name: route.name as string })
        return
      }
      //削除新規の回目
      if (activeTabKey.value === '1') {
        router.push({ name: route.name as string })
        return
      }
      emit('changeTab', +activeTabKey.value - 1)
      activeTabKey.value = String(+activeTabKey.value - 1)
    }
  })
}
//削除処理(全ての回目)
function deleteAll() {
  showDeleteModal({
    handleDB: true,
    async onOk() {
      const res = await Delete({
        locklist: props.keylist,
        delkbn: Enum削除区分.全削除,
        ...commonParams
      })
      message.success(DELETE_OK_INFO.Msg)
      processedObj = res
      router.push({ name: route.name as string })
    }
  })
}
//タブボタンクリア処理(削除、新規の判断)
function editTabs(targetKey, action: 'add' | 'remove') {
  if (action === 'add') addTab()
  if (action === 'remove') removeTab()
}
//タブ切り替え処理
function clickTab(val) {
  if (activeTabKey.value === val) return
  editJudge.judgeIsEdited(async () => {
    const tab = props.keylist[+val - 1]
    emit('changeTab', tab.kensinkaisu)
    activeTabKey.value = val
  })
}

//初期値設定(固定項目)
function setInitialValue() {
  if (canEdit1.value && hasList1.value) {
    for (const el of itemlist1.value) {
      if (!el.value && el.value !== 0 && el.syokiti !== '') el.value = el.syokiti
    }
  }
  if (canEdit2.value && hasList2.value) {
    for (const el of itemlist2.value) {
      if (!el.value && el.value !== 0 && el.syokiti !== '') el.value = el.syokiti
    }
  }
}

//チェック処理(固定項目)
async function allValidate() {
  try {
    if (hasList1.value && hasList2.value) {
      await Promise.all([validate1(), validate2()])
    } else if (hasList1.value) {
      await validate1()
    } else if (hasList2.value) {
      await validate2()
    }
  } catch (error) {
    return Promise.reject()
  }
  await rightTableRef.value?.validate()
}

//保存処理
async function submitData() {
  if (hasList1.value) {
    for (const el of itemlist1.value) {
      el.warntextflg = true
    }
  }
  if (hasList2.value) {
    for (const el of itemlist2.value) {
      el.warntextflg = true
    }
  }
  await allValidate()

  const currentChapter: KsTimeUpdateVM & { itemlist3: undefined } = {
    ...data.value,
    jissiymd1: hasList1.value ? itemlist1.value[0].value : null,
    jissiymd2: hasList2.value ? itemlist2.value[0].value : null,
    jissiage1: hasList1.value ? itemlist1.value[1].value : null,
    jissiage2: hasList2.value ? itemlist2.value[1].value : null,
    kensahoho1: hasList1.value && props.showflg3 ? itemlist1.value[2].value : null,
    kekkalist: kekkalist.value,
    itemlist1: list1data.value.map((el) => {
      return {
        kensinkaisu: el.kensinkaisu,
        itemcd: el.itemcd,
        value: el.value,
        fusyoflg: el.fusyoflg,
        inputtypekbn: el.inputtypekbn
      }
    }),
    itemlist2: list2data.value.map((el) => {
      return {
        kensinkaisu: el.kensinkaisu,
        itemcd: el.itemcd,
        value: el.value,
        fusyoflg: el.fusyoflg,
        inputtypekbn: el.inputtypekbn
      }
    }),
    itemlist3: undefined
  }

  let hasUnknown = false
  for (const item of [...currentChapter.itemlist1, ...currentChapter.itemlist2]) {
    //不詳日付チェック
    if (
      [
        Enum入力タイプ.日付_年月日_不詳あり,
        Enum入力タイプ.半角文字_年_不詳あり,
        Enum入力タイプ.半角文字_年月_不詳あり
      ].includes(item.inputtypekbn)
    ) {
      if (item.value && item.value.match(/-00|0000|A/)) {
        item.fusyoflg = true
        hasUnknown = true
      } else {
        item.fusyoflg = false
      }
    } else {
      item.fusyoflg = null
    }
    //replace ''
    if (item.value === '') item.value = null
  }

  const params: SaveRequest = {
    ...commonParams,
    kekka: currentChapter,
    kensinkaisu: data.value.kensinkaisu ?? +activeTabKey.value,
    editflg1: canEdit1.value ? hasList1.value : null,
    editflg2: canEdit2.value ? hasList2.value : null,
    dataflg1: canEdit1.value ? hasList1.value : Boolean(data.value.upddttm1),
    dataflg2: canEdit2.value ? hasList2.value : Boolean(data.value.upddttm2),
    checkflg: false
  }

  const saveReq = async () => {
    const res = await Save(params)
    message.success(SAVE_OK_INFO.Msg)
    router.push({ name: route.name as string })
    return Promise.resolve(res)
  }

  await Save({ ...params, checkflg: true }, async (response: DaResponseBase) => {
    if (response.returncode === EnumServiceResult.ServiceAlert) {
      processedObj = await saveReq()
    }
  })

  const save = async () => {
    showSaveModal({
      onOk: async () => {
        try {
          processedObj = await saveReq()
        } catch (error) {}
      }
    })
  }

  //不詳がある場合、アラートメッセージを表示
  if (hasUnknown) {
    showConfirmModal({
      content: A000004.Msg,
      onOk: () => save()
    })
  } else {
    save()
  }
}

//value変動
async function onChangeValue(row: KsFixItemVM, type: EnumKensinKbn, oldVal?) {
  row.warntextflg = true
  //実施年齢取得
  if (row.itemcd === 'jissiymd1' || row.itemcd === 'jissiymd2') {
    const findItem = (type === EnumKensinKbn.一次 ? itemlist1.value : itemlist2.value).find(
      (el) => el.itemcd === (type === EnumKensinKbn.一次 ? 'jissiage1' : 'jissiage2')
    )
    if (findItem) {
      if (row.value) {
        const res = await GetAge({ atenano: commonParams.atenano, jissiymd: row.value })
        findItem.value = res.jissiage
      } else {
        findItem.value = null
      }
    }
  }
  //精密検診チェック
  if (type === EnumKensinKbn.一次) checkSeikenDisabled(row, oldVal)
}

//精密検診チェック処理------------------------------------------------------
const kekkalist = computed(() => {
  return [...itemlist1.value, ...itemlist3.value]
    .filter((el) => el.komokutokuteikbn)
    .map((el) => ({ itemcd: el.itemcd, value: el.value }))
})
async function checkSeikenDisabled(row, oldVal?) {
  const dataflg2 = canEdit2.value ? hasList2.value : Boolean(data.value.upddttm2)
  if (props.showflg1 && row.komokutokuteikbn && dataflg2) {
    GlobalStore.setLoading(true)
    await SeiKenEditCheck(
      {
        kekkalist: kekkalist.value,
        oldlist: kekkalist.value.map((item) => {
          if (item.itemcd === row.itemcd) {
            return { ...item, value: oldVal }
          }
          return item
        }),
        dataflg1: canEdit1.value ? hasList1.value : Boolean(data.value.upddttm1),
        dataflg2
      },
      (res) => {
        if (res.returncode == EnumServiceResult.ServiceAlert) {
        } else {
          row.value = oldVal
        }
        GlobalStore.setLoading(false)
      },
      (res) => {
        if (res.returncode == EnumServiceResult.ServiceAlert) {
          row.value = oldVal
        } else {
        }
        GlobalStore.setLoading(false)
      }
    )
    GlobalStore.setLoading(false)
  }
}

//------------------------------------------------------------------------

//計算処理
async function calculate() {
  const kekkalist = [...list1data.value, ...list2data.value].map((el) => ({
    itemcd: el.itemcd,
    value: el.value
  }))
  try {
    const res = await Calculate({ kekkalist })
    const itemList = [...itemlist1.value, ...itemlist2.value, ...itemlist3.value]
    const itemMap = new Map(itemList.map((el) => [el.itemcd, el]))
    res.kekkalist.forEach((item) => {
      const findItem = itemMap.get(item.itemcd)
      if (findItem) findItem.value = item.value
    })
  } catch (error) {}
}
const changeflg = (e, kbn) => {
  const changeInputflg = async (e, hasList, kbn?) => {
    if (hasList.value) {
      showConfirmModal({
        content: C001019.Msg,
        onOk() {
          hasList.value = e.target.checked
        }
      })
    } else if (kbn) {
      // 精密検査チェック押下
      GlobalStore.setLoading(true)
      await SeiKenEditCheck(
        {
          kekkalist: kekkalist.value,
          dataflg1: canEdit1.value ? hasList1.value : Boolean(data.value.upddttm1),
          dataflg2: canEdit2.value ? hasList2.value : Boolean(data.value.upddttm2)
        },
        (res) => {
          if (res.returncode == EnumServiceResult.ServiceAlert) {
            hasList.value = e.target.checked
          }
          GlobalStore.setLoading(false)
        },
        () => {
          GlobalStore.setLoading(false)
        }
      )
      hasList.value = e.target.checked
      GlobalStore.setLoading(false)
    } else {
      hasList.value = e.target.checked
    }
  }
  if (kbn === 1) changeInputflg(e, hasList1)
  else changeInputflg(e, hasList2, kbn)
}

defineExpose({
  submit: submitData,
  deleteAll,
  calculate,
  canDeleteAll,
  canSaveData
})
</script>

<style src="../index.less" scoped></style>
