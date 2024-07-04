<template>
  <div>
    <a-card :bordered="false">
      <!--      <a-spin :spinning="loading">-->
      <div class="self_adaption_table ml-[1px]" :class="{ form: canEdit }">
        <a-row>
          <a-col :md="12" :xl="9" :xxl="6">
            <th
              :class="
                isNew && Number(formParam.kbn) == Enum帳票様式.帳票 ? 'required' : 'bg-readonly'
              "
            >
              帳票ID
            </th>
            <td v-if="isNew && Number(formParam.kbn) == Enum帳票様式.帳票">
              <a-form-item v-bind="validateInfos.rptid">
                <a-input v-model:value="formParam.rptid" :maxlength="4"
              /></a-form-item>
            </td>
            <TD v-else>{{ formParam.rptid }} </TD>
          </a-col>
          <a-col :md="12" :xl="9" :xxl="6">
            <th :class="Number(formParam.kbn) == Enum帳票様式.帳票 ? 'required' : 'bg-readonly'">
              帳票名
            </th>
            <td v-if="Number(formParam.kbn) == Enum帳票様式.帳票">
              <a-form-item v-bind="validateInfos.rptnm">
                <a-input v-model:value="formParam.rptnm" maxlength="50"
              /></a-form-item>
            </td>
            <TD v-else>{{ formParam.rptnm }} </TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :xl="9" :xxl="6">
            <th :class="!isNew ? 'bg-readonly' : 'required'">様式ID</th>
            <TD v-if="!isNew">{{ formParam.yosikiid }}</TD>
            <td v-else>
              <a-form-item v-bind="validateInfos.yosikiid">
                <a-input v-model:value="formParam.yosikiid" :maxlength="4" />
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :xl="9" :xxl="6">
            <th class="required">様式名</th>
            <td>
              <a-form-item v-bind="validateInfos.yosikinm">
                <a-input v-model:value="formParam.yosikinm" maxlength="50" />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-show="false" span="6">
            <th class="bg-readonly">様式枝番</th>
            <TD>{{ formParam.yosikieda }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="flex justify-between m-t-1">
        <a-space>
          <a-button
            type="primary"
            class="warning-btn"
            :disabled="!canEdit"
            :loading="sumbitLoading"
            @click="handleSave"
            >登録</a-button
          >
          <a-button type="primary" :disabled="!canDelete" danger @click="handleDel">削除</a-button>
          <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
        </a-space>
        <close-page></close-page>
      </div>
      <!--      </a-spin>-->
    </a-card>
    <!--    <a-card ref="contentRef" class="mt-2" :loading="loading">-->
    <a-card ref="contentRef" class="mt-2">
      <a-tabs v-model:activeKey.number="tabActiveKey" type="card" @tab-click="onclickTab">
        <a-tab-pane :key="TABKEYENUMS.帳票設定" tab="帳票設定"> </a-tab-pane>
        <a-tab-pane :key="TABKEYENUMS.様式設定" tab="様式設定"> </a-tab-pane>
        <a-tab-pane :key="TABKEYENUMS.項目定義" tab="項目定義"> </a-tab-pane>
        <a-tab-pane :key="TABKEYENUMS.検索条件" tab="検索条件"> </a-tab-pane>
        <a-tab-pane :key="TABKEYENUMS.Excelマッピング" tab="Excelマッピング"> </a-tab-pane>
      </a-tabs>

      <Tab1
        v-show="tabActiveKey === TABKEYENUMS.帳票設定"
        ref="tab1Ref"
        v-bind="{
          ...formParam,
          rptgroupnmOptions,
          jokenOptions,
          editJudge,
          tab4Ref: toRef(tab4Ref)
        }"
      />
      <Tab2
        v-show="tabActiveKey === TABKEYENUMS.様式設定"
        ref="tab2Ref"
        v-bind="{
          ...formParam,
          naigaikbnOptions,
          settinglistOptions,
          editJudge,
          kacdList,
          kakaricdList,
          himozukevalueList,
          completions,
          tab1Ref: toRef(tab1Ref),
          tab4Ref: toRef(tab4Ref)
        }"
      />
      <Tab3
        v-show="tabActiveKey === TABKEYENUMS.項目定義"
        ref="tab3Ref"
        v-bind="{
          ...formParam,
          yosikikbn: Number(formParam.yosikikbn),
          editJudge,
          tab1Ref: toRef(tab1Ref),
          tab2Ref: toRef(tab2Ref)
        }"
      />
      <Tab4
        v-show="tabActiveKey === TABKEYENUMS.検索条件"
        ref="tab4Ref"
        v-bind="{
          ...formParam,
          editJudge,
          selectorlist4,
          tab1Ref: toRef(tab1Ref)
        }"
      />
      <Tab5
        v-show="tabActiveKey === TABKEYENUMS.Excelマッピング"
        ref="tab5Ref"
        v-bind="{
          ...formParam,
          kbn: Number(formParam.kbn),
          yosikikbn: Number(formParam.yosikikbn),
          editJudge,
          tabActiveKey,
          tab2Ref: toRef(tab2Ref),
          tab3Ref: toRef(tab3Ref)
        }"
      />
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted, onUnmounted, computed, watch, toRef } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { message, Form } from 'ant-design-vue'
import { showSaveModal, showDeleteModal, showInfoModal } from '@/utils/modal'
import {
  SAVE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  DELETE_OK_INFO,
  ITEM_SELECTREQUIRE_ERROR,
  E001008,
  E004006,
  E064012,
  E064013,
  E001009,
  A060001,
  E064017,
  ITEM_ILLEGAL_ERROR,
  E064015,
  C001010,
  E064016
} from '@/constants/msg'
import {
  Enum帳票様式,
  Enum様式作成方法,
  Enum様式種別,
  Enum編集区分,
  Enum行列固定,
  Enum集計区分,
  PageSatatus,
  Enum様式種別詳細,
  Enum出力項目区分,
  Enum並び替え
} from '#/Enums'
import {
  SearchVM,
  SearchConditionVM,
  ExcelMappingVM,
  YosikiTabInfoVM,
  ReportTabInfoVM,
  SortLineParam
} from '../type'
import { InitDetail, SaveProject, Delete } from '../service'
import { EUCStore } from '@/store'
import { Judgement } from '@/utils/judge-edited'

import TD from '@/components/Common/TableTD/index.vue'
import Tab1 from './Tab1/index.vue'
import Tab2 from './Tab2/index.vue'
import Tab3 from './Tab3/index.vue'
import Tab4 from './Tab4/index.vue'
import Tab5 from './Tab5/index.vue'

const props = defineProps<{
  selector2Options: DaSelectorModel[]
}>()

const deleteMsg =
  '帳票を削除すると、その下の別様式が削除されます。 削除するかどうかもう一度ご確認ください。'

enum TABKEYENUMS {
  帳票設定 = 1,
  様式設定,
  項目定義,
  検索条件,
  Excelマッピング
}

const editJudge = new Judgement('AWEU00201G')
const route = useRoute()
const router = useRouter()
const useForm = Form.useForm
//操作権限フラグ
const isNew = Boolean(route.query.isNew)
const canEdit = isNew || (route.meta.updflg as boolean)
const canDelete = !isNew && (route.meta.delflg as boolean)

const tab1Ref = ref<InstanceType<typeof Tab1> | null>(null) // 帳票設定
const tab2Ref = ref<InstanceType<typeof Tab2> | null>(null) // 様式設定
const tab3Ref = ref<InstanceType<typeof Tab3> | null>(null) // 項目定義
const tab4Ref = ref<InstanceType<typeof Tab4> | null>(null) // 検索条件
const tab5Ref = ref<InstanceType<typeof Tab5> | null>(null) // Excelマッピング

//ローディング
// const loading = ref(false)
const sumbitLoading = ref(false)

//ビューモデル
const tabActiveKey = ref(TABKEYENUMS.帳票設定)
type Extras = {
  yosikihouhou: Enum様式作成方法
  datasourceid?: string
  procedure: string
  sql: string
  procnm: string | undefined
  datasourcenm: string | undefined
  rptdatasourceid: string
}
const formParam: SearchVM & Extras = reactive({
  //SearchVM
  gyoumu: '',
  rptgroupnm: '',
  rptid: '',
  rptnm: '',
  yosikiid: '',
  yosikinm: '',
  kbn: '',
  yosikiideda: '',
  yosikidenm: '',
  yosikisyubetu: '',
  //Extras
  yosikikbn: '',
  yosikihouhou: Enum様式作成方法.データソース,
  datasourceid: '',
  procedure: '',
  sql: '',
  procnm: '',
  datasourcenm: '',
  yosikieda: 0,
  rptdatasourceid: ''
})

const rptgroupnmOptions = ref<DaSelectorModel[]>(props.selector2Options) // 帳票グループOptions
const naigaikbnOptions = ref<DaSelectorModel[]>([]) // 内外区分Options
const settinglistOptions = ref<DaSelectorModel[]>([]) // 問い合わせ内容
const kacdList = ref<DaSelectorModel[]>([])
const kakaricdList = ref<DaSelectorModel[]>([])
const selectorlist4 = ref<DaSelectorModel[]>([])
const jokenOptions = ref<DaSelectorModel[]>([])
const himozukevalueList = ref<SearchConditionVM[]>([])
//プロシージャ提示（固定）
const completions = ref<{ label: string; type: string }[]>([])
const rules = reactive({
  rptid: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票ID')
    }
  ],
  rptnm: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票名')
    }
  ],
  yosikiid: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '様式ID')
    },
    {
      min: 4,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', `4文字で`)
    },
    {
      pattern: /^\d+$/,
      message: E001009.Msg.replace('{0}', '半角数字')
    }
  ],
  yosikinm: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '様式名')
    }
  ]
})

const { validate, validateInfos } = useForm(formParam, rules)

onMounted(() => {
  editJudge.addEvent()
  const params = EUCStore['201_params']
  if (params) {
    tab1Ref.value?.setFieldsValue(params)
    tab2Ref.value?.setFieldsValue(params)
    Object.assign(formParam, params)
    if (isNew && Number(formParam.kbn) === Enum帳票様式.帳票) {
      formParam.yosikiid = '0001'
    }
  } else {
    goToList()
    return
  }
  InitDetail({
    rptid: formParam.rptid,
    yosikiid: formParam.yosikiid,
    datasourceid: (route.query.datasourceid as string) || formParam.datasourceid,
    yosikihouhou: params.yosikihouhou ?? '',
    kbn: Number(formParam.kbn),
    procnm: formParam.procnm == '新規作成' ? '' : formParam.procnm,
    editkbn: route.query.isNew ? Enum編集区分.新規 : Enum編集区分.変更
  }).then((res) => {
    naigaikbnOptions.value = res.selectorlist3
    settinglistOptions.value = res.settinglist
    kacdList.value = res.kacdList
    kakaricdList.value = res.kakaricdList
    selectorlist4.value = res.selectorlist4
    jokenOptions.value = res.selectorlist
    himozukevalueList.value = res.himozukevalueList
    completions.value = res.parameterList.map((e) => ({
      label: `@${e}`,
      type: 'variable'
    }))
    formParam.datasourcenm = res.datasourcenm ?? ''
    formParam.datasourceid = res.datasourceid
    formParam.procnm = res.procnm
    formParam.yosikihouhou = res.yosikihouhou
    formParam.sql = res.sql
  })
})

onUnmounted(() => {
  EUCStore.clear()
})

watch(
  () => [formParam.yosikiid, formParam.yosikinm, formParam.rptnm],
  () => editJudge.setEdited()
)

const handleSave = async () => {
  await validate()
  //プロシージャ帳票 プロシージャ必須
  if (
    !tab1Ref.value?.getFieldsValue().sql.trim() &&
    formParam.yosikihouhou == Enum様式作成方法.プロシージャ
  ) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'プロシージャ')
    })
    tabActiveKey.value = TABKEYENUMS.帳票設定
    return Promise.reject()
  }

  const { excelflg, pdfflg, otherflg, meisaiflg, yosikisyubetu, yosikikbn, meisaikoteikbn } =
    tab2Ref.value?.getFieldsValue() as unknown as YosikiTabInfoVM
  if ((excelflg || pdfflg) && !EUCStore.excel) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E064012.Msg
    })
    tabActiveKey.value = TABKEYENUMS.Excelマッピング
    return Promise.reject()
  }

  if ([excelflg, pdfflg, otherflg].every((item) => !item)) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '出力形式')
    })
    tabActiveKey.value = TABKEYENUMS.様式設定
    return Promise.reject()
  }

  const allItems = tab3Ref.value?.getFieldsValue().definitionValue ?? []
  //tab3Ref空項目をチェックする
  if (allItems.length === 0) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E064015.Msg.replace('{0}', '項目定義に少なくとも1つの項目')
    })
    tabActiveKey.value = TABKEYENUMS.項目定義
    return Promise.reject()
  }
  if (+formParam.yosikikbn === Enum様式種別詳細.クロス集計) {
    if (!allItems.some((el) => el.crosskbn === Enum集計区分.GroupBy横)) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E064015.Msg.replace('{0}', '項目定義列に少なくとも1つの項目')
      })
      tabActiveKey.value = TABKEYENUMS.項目定義
      return Promise.reject()
    }
    if (!allItems.some((el) => el.crosskbn === Enum集計区分.GroupBy縦)) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E064015.Msg.replace('{0}', '項目定義行に少なくとも1つの項目')
      })
      tabActiveKey.value = TABKEYENUMS.項目定義
      return Promise.reject()
    }
    if (!allItems.some((el) => el.crosskbn === Enum集計区分.集計)) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E064016.Msg
      })
      tabActiveKey.value = TABKEYENUMS.項目定義
      return Promise.reject()
    }
  }

  //tab3Ref並び替えチェック
  if (
    +formParam.yosikisyubetu !== Enum様式種別.集計表 &&
    !allItems.some((el) => el.orderkbn !== Enum並び替え.無し)
  ) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E064015.Msg.replace('{0}', '並び替え')
    })
    tabActiveKey.value = TABKEYENUMS.項目定義
    return Promise.reject()
  }
  //tab3Ref出力flgチェック
  // const errorMessage = (type) =>
  //   A060001.Msg.replace('{0}', `項目定義の${type}`).replace('{1}', '様式設定')
  // if (+formParam.yosikikbn !== Enum様式種別詳細.クロス集計) {
  //   if (
  //     pdfflg || excelflg
  //       ? !allItems.some((item) => item.reportoutputflg === (pdfflg || excelflg))
  //       : allItems.some((item) => item.reportoutputflg)
  //   ) {
  //     showInfoModal({
  //       type: 'error',
  //       title: 'エラー',
  //       content: errorMessage('帳票出力形式')
  //     })
  //     tabActiveKey.value = TABKEYENUMS.項目定義
  //     return Promise.reject()
  //   }

  //   if (
  //     otherflg
  //       ? !allItems.some((item) => item.csvoutputflg === otherflg)
  //       : allItems.some((item) => item.csvoutputflg)
  //   ) {
  //     showInfoModal({
  //       type: 'error',
  //       title: 'エラー',
  //       content: errorMessage('CSV出力形式')
  //     })
  //     tabActiveKey.value = TABKEYENUMS.項目定義
  //     return Promise.reject()
  //   }
  // }

  //tab3Ref重複項目IDをチェックする
  const yosikiitemIds = allItems.map((item) => item.yosikiitemid)
  const uniqueYosikiitemIds = new Set(yosikiitemIds)
  if (uniqueYosikiitemIds.size !== yosikiitemIds.length) {
    const duplicateYosikiitemId = yosikiitemIds.find(
      (id, index) => yosikiitemIds.indexOf(id) !== index
    )
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E001008.Msg.replace('{0}', '項目ID: ' + duplicateYosikiitemId)
    })
    tabActiveKey.value = TABKEYENUMS.項目定義
    return Promise.reject()
  }
  //宛名フラグがtrueの場合、項目定義に宛名番号を含む
  if (tab1Ref.value) {
    const { atenaflg } = tab1Ref.value.getFieldsValue()
    if (atenaflg && !allItems.some((item) => item.itemkbn == Enum出力項目区分.宛名番号)) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E064017.Msg
      })
      tabActiveKey.value = TABKEYENUMS.項目定義
      return Promise.reject()
    }
    //AIplus 2024-06-25 SHOU ADD Start
    //Enum様式種別.カスタマイズの場合、宛名チェックボックス選択が必要
    if (+formParam.yosikisyubetu == Enum様式種別.カスタマイズ && !atenaflg) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E064015.Msg.replace('{0}', '宛名フラグ')
      })
      tabActiveKey.value = TABKEYENUMS.帳票設定
      return Promise.reject()
    }
    //AIplus 2024-06-25 SHOU ADD End
  }

  const promises = [tab2Ref.value?.validate()]
  Promise.allSettled(promises).then(async (res) => {
    const isAllSucess = res.every((item) => item.status === 'fulfilled')
    if (isAllSucess) {
      await tab5Ref.value?.changExcel()
      // tab5 定義項目がすべての選択
      let list = EUCStore.defineItems
        .filter((e) => e.reportoutputflg)
        .map((el) => '**' + el.reportitemnm)
      let cellValues = new Set<string>()

      const specProjectList = tab5Ref.value?.specProjectList ?? []
      const makprojectList = tab5Ref.value?.makprojectList ?? []

      if (tab5Ref.value?.setForm.celldatas) {
        for (const sheet of tab5Ref.value.setForm.celldatas) {
          for (const cell of sheet) {
            cellValues.add(String(cell.value))
            //クロス集計場合、項目一覧位置チェック
            if (+yosikikbn == Enum様式種別詳細.クロス集計 && tab3Ref.value) {
              if (
                (cell.rowindex < tab3Ref.value?.colCount ||
                  cell.columnindex < tab3Ref.value?.rowCount) &&
                [...makprojectList.map((e) => (e = '**' + e))].includes(String(cell.value))
              ) {
                showInfoModal({
                  type: 'error',
                  title: 'エラー',
                  content: E064015.Msg.replace('{0}', 'セルをクリックして正しい箇所')
                })
                tabActiveKey.value = TABKEYENUMS.Excelマッピング
                return
              }
            }
          }
        }
      }
      //Excelマッピング項目選択チェック(少なくとも1つの項目)
      const hasflg1 = list.findIndex((item) => cellValues.has(item))
      if (list.length > 0 && hasflg1 < 0) {
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: '出力する帳票項目はテンプレートに設定されていません。'
        })
        tabActiveKey.value = TABKEYENUMS.Excelマッピング
        return
      }

      //検索条件以外チェック
      const nmList = tab4Ref.value?.bottomItemList.map((e) => e.jyokenlabel) ?? []
      const defineCsvItems =
        excelflg || pdfflg
          ? Array.from(cellValues)
              .filter((cell) => /^(\*\*)/.test(cell))
              .map((e) => e.replace(/^\*\*/, ''))
          : allItems.map((e) => (e.csvoutputflg ? e.reportitemnm : ''))
      if (checkKensakuiga(defineCsvItems, nmList)) return
      //Excelマッピング項目チェック
      const extraItems = Array.from(cellValues).filter(
        (item) =>
          item.includes('**') &&
          ![...list, ...specProjectList.map((e) => (e = '**' + e))].includes(item) &&
          (pdfflg || excelflg)
      )
      if (extraItems.length > 0) {
        const missingItemsString = extraItems[0].replace(/^\*\*/, '')
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: E004006.Msg.replace('{0}', `${missingItemsString}という項目`).replace(
            '{1}',
            `項目一覧と特殊項目`
          )
        })
        tabActiveKey.value = TABKEYENUMS.Excelマッピング
        return
      }
      const saveReq = async (checkflg: boolean) => {
        sumbitLoading.value = true
        await SaveProject({
          ...formParam,
          upddttm: tab1Ref.value?.upddttm,
          kbn: Number(formParam.kbn),
          rptDetailParam: tab1Ref.value?.getFieldsValue() as unknown as ReportTabInfoVM,
          procnm: tab1Ref.value?.getFieldsValue().procnm,
          sql: tab1Ref.value?.getFieldsValue().sql,
          styleDetailParam: tab2Ref.value?.getFieldsValue() as unknown as YosikiTabInfoVM,
          definitionValue: tab3Ref.value?.getFieldsValue().definitionValue ?? [],
          rptConditionList: tab4Ref.value?.getFieldsValue() ?? [],
          excelData: [
            {
              ...tab5Ref.value?.setForm,
              templatefiledata: '',
              loopmaxrow: tab5Ref.value?.setForm.loopmaxrow
            } as ExcelMappingVM
          ],
          files: EUCStore.excel ? [EUCStore.excel] : [],
          updflag: !isNew,
          filerequired: !(!excelflg && !pdfflg && otherflg),
          yosikihouhou: formParam.yosikihouhou || Enum様式作成方法.データソース,
          checkflg
        }).finally(() => (sumbitLoading.value = false))
      }
      await saveReq(true)
      showSaveModal({
        onOk: async () => {
          try {
            await saveReq(false)
            message.success(SAVE_OK_INFO.Msg)
            goToList()
          } catch (error) {}
        }
      })
    } else {
      const errIndex = res.findIndex((item) => item.status === 'rejected')
      if (errIndex > -1) {
        tabActiveKey.value = errIndex + 2
      }
    }
  })
}

const handleDel = () => {
  showDeleteModal({
    handleDB: true,
    content: Number(formParam.kbn) == Enum帳票様式.帳票 ? deleteMsg : '',
    onOk: async () => {
      try {
        await Delete({
          rptid: formParam.rptid,
          yosikiid: formParam.yosikiid,
          yosikieda: formParam.yosikieda
        })
        message.success(DELETE_OK_INFO.Msg)
        goToList()
      } catch (error) {}
    }
  })
}

const goToList = () => {
  router.push({
    path: 'AWEU00201G',
    query: {
      status: PageSatatus.List
    }
  })
}

const forwardSearch = () => {
  if (isNew) editJudge.setEdited()
  editJudge.judgeIsEdited(() => {
    router.push({ path: 'AWEU00201G' })
  }, C001010.Msg)
}

function onclickTab(key) {
  if (key === TABKEYENUMS.Excelマッピング) {
    tab5Ref.value?.init(!editJudge.isPageEdited())
  }
}
const checkKensakuiga = (makprojectList: any, nmList: string[]) => {
  let flg = false
  if (
    (makprojectList.includes('発行日') || makprojectList.includes('発行日（和暦）')) &&
    !nmList.includes('発行日')
  ) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E004006.Msg.replace('{0}', '発行日という項目').replace('{1}', '検索条件以外項目')
    })
    tabActiveKey.value = TABKEYENUMS.検索条件
    flg = true
    return flg
  }
  if (
    (makprojectList.includes('基準日') || makprojectList.includes('基準日（和暦）')) &&
    !nmList.includes('基準日')
  ) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E004006.Msg.replace('{0}', '基準日という項目').replace('{1}', '検索条件以外項目')
    })
    tabActiveKey.value = TABKEYENUMS.検索条件
    flg = true
  }
  return flg
}
</script>

<style lang="less" scoped>
:deep(.ant-input[disabled]) {
  color: rgba(0, 0, 0, 0.85) !important;
}

:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
.ant-form-item {
  width: 100%;
  margin-bottom: 0px;
}
th {
  width: 150px;
}
</style>
