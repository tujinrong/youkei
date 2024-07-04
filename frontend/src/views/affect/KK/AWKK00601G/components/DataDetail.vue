<template>
  <a-card ref="headRef" :bordered="false">
    <a-form ref="formRef" :model="queryParam" :rules="rules">
      <div class="self_adaption_table form max-w-360">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="5">
            <th class="required">業務</th>
            <td>
              <a-form-item name="gyoumukbn">
                <ai-select
                  v-model:value="queryParam.gyoumukbn"
                  :options="options.gyoumukbnList"
                  :disabled="!isEditing"
                  split-val
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="5">
            <th class="bg-readonly">一括取込入力No</th>
            <TD>{{ queryParam.impno }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="8">
            <th class="required">一括取込入力名</th>
            <td>
              <a-form-item name="impnm">
                <a-input v-model:value="queryParam.impnm" maxlength="50" />
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th :class="{ required: !impno, 'bg-readonly': impno }">
              <span>一括取込入力区分</span>
            </th>
            <td v-if="!impno">
              <a-form-item name="impkbn">
                <ai-select
                  v-model:value="queryParam.impkbn"
                  :options="options.impkbnList"
                  :disabled="!isEditing"
                  split-val
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{
              options.impkbnList?.find((item) => item.value === queryParam.impkbn)?.label
            }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="5">
            <th>年度表示</th>
            <td>
              <a-checkbox
                v-model:checked="queryParam.yeardispflg"
                style="margin-left: 10px"
                @change="nendoHani"
              ></a-checkbox>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="5">
            <th class="required">登録区分</th>
            <td>
              <a-form-item name="regupdkbn">
                <ai-select
                  v-model:value="queryParam.regupdkbn"
                  :options="options.regupdkbnList"
                  :disabled="!isEditing"
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="4">
            <th class="required">並び順</th>
            <td>
              <a-form-item name="orderseq">
                <a-input-number
                  v-model:value="queryParam.orderseq"
                  style="width: 100%"
                  :min="1"
                  maxlength="4"
                  @blur="CheckOrder"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="24" :lg="16" :xxl="10">
            <th>説明</th>
            <td>
              <a-input v-model:value="queryParam.memo" maxlength="100" />
            </td>
          </a-col>
          <a-col :span="10">
            <th :class="{ required: queryParam.yeardispflg }">年度範囲</th>
            <td>
              <a-form-item style="width: 100%" name="nendohanikbn">
                <ai-select
                  v-model:value="queryParam.nendohanikbn"
                  :options="options.nendohanikbnList"
                  :disabled="!queryParam.yeardispflg"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col :span="14">
            <th class="required">テーブル</th>
            <td>
              <a-form-item style="width: 100%" name="tableidList">
                <a-select
                  v-model:value="queryParam.tableidList"
                  mode="multiple"
                  :options="options.headtableidList"
                  :disabled="!isEditing"
                  style="width: 100%"
                  @blur="judageParentTable"
                ></a-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>
    <div class="m-t-1 flex justify-between">
      <a-space>
        <a-button
          type="primary"
          class="warning-btn"
          :disabled="tabActiveKey != 'G' || (!addFlg && !updFlg)"
          @click.prevent="saveHandle()"
          >登録</a-button
        >
        <a-button
          v-if="route.query.impno"
          type="primary"
          danger
          :disabled="!delFlg"
          @click.prevent="deleteHandle()"
          >削除</a-button
        >
        <a-button type="primary" @click.prevent="goBack()">一覧へ</a-button>
        <a-button type="primary" :disabled="!isEditing" @click="() => (cVisible = true)"
          >変換区分管理</a-button
        >
      </a-space>
      <a-space class="">
        <close-page></close-page>
      </a-space>
    </div>
  </a-card>
  <a-card class="m-t-1">
    <a-tabs
      v-model:activeKey="tabActiveKey"
      destroy-inactive-tab-pane
      type="card"
      @change="tabClick"
    >
      <a-tab-pane v-if="isTabVisible('A')" key="A" :closable="false" :disabled="isTabDisabled('A')">
        <BasicIinfo
          ref="basicInfoRef"
          v-model:isChange="isChange"
          :data="allData.basicInfo"
          :error-messages="errorMessages"
          :datakbn-options="options.datakbnList"
          :dividekbn-options="options.dividekbnList"
          :filenmru-options="options.filenmruleList"
          :filetype-options="options.filetypeList"
          :quoteskbn-options="options.quoteskbnList"
          @get-data="getData"
        ></BasicIinfo>
        <template #tab>
          <span>基本情報</span>
        </template>
      </a-tab-pane>

      <a-tab-pane v-if="isTabVisible('B')" key="B" :closable="false" :disabled="isTabDisabled('B')">
        <FileInterface
          ref="fileInterfaceRef"
          v-model:isChange="isChange"
          :head-ref="toRef(headRef)"
          :border-warning="borderWarning"
          :data="allData.fileInterface"
          :impno="impno"
          @get-data="getData"
        ></FileInterface>
        <template #tab>
          <span>ファイルI/F</span>
        </template>
      </a-tab-pane>

      <a-tab-pane v-if="isTabVisible('C')" key="C" :closable="false" :disabled="isTabDisabled('C')">
        <ProjectDefine
          ref="projectDefineRef"
          v-model:isChange="isChange"
          v-model:isFileImport="isFileImport"
          :data="allData.projectDefine"
          :head-ref="toRef(headRef)"
          :impno="queryParam.impno"
          :gyoumukbn="queryParam.gyoumukbn"
          :editkbn="editkbn"
          :mapping-setting="allData.mappingSetting"
          :changekbn-list="options.changekbnList"
          :error-class-map="errorClassMap"
          @get-data="getData"
        ></ProjectDefine>
        <template #tab>
          <span>項目定義</span>
        </template>
      </a-tab-pane>

      <a-tab-pane v-if="isTabVisible('D')" key="D" :closable="false" :disabled="isTabDisabled('D')">
        <CodeTransfer
          ref="codeTransferRef"
          v-model:isChange="isChange"
          :head-ref="toRef(headRef)"
          :border-warning="borderWarning"
          :data="allData.codeTransfer"
          :gyoumukbn="queryParam.gyoumukbn"
          :impno="queryParam.impno"
          :options="options.changekbnList"
          :change-code-main-list="allData.changeCodeMainList"
          @get-data="getData"
        ></CodeTransfer>
        <template #tab>
          <span>変換コード</span>
        </template>
      </a-tab-pane>

      <a-tab-pane v-if="isTabVisible('E')" key="E" :closable="false" :disabled="isTabDisabled('E')">
        <MappingSetting
          ref="mappingSettingRef"
          v-model:isChange="isChange"
          :data="allData.mappingSetting"
          :impno="impno"
          :editkbn="editkbn"
          :head-ref="toRef(headRef)"
          :fileitem-list="allData.fileInterface"
          @get-data="getData"
        ></MappingSetting>
        <template #tab>
          <span>マッピング設定</span>
        </template>
      </a-tab-pane>

      <a-tab-pane v-if="isTabVisible('F')" key="F" :closable="false" :disabled="isTabDisabled('F')">
        <ProjectTransfer
          ref="projectTransferRef"
          v-model:isChange="isChange"
          :head-ref="toRef(headRef)"
          :regupdkbn="queryParam.regupdkbn"
          :data="allData.projectTransfer"
          :seleted-tableid-list="queryParam.tableidList"
          :original-table-options="options.headtableidList"
          :pageitem-list="allData.projectDefine"
          @get-data="getData"
        ></ProjectTransfer>
        <template #tab>
          <span>登録仕様</span>
        </template>
      </a-tab-pane>

      <a-tab-pane v-if="isTabVisible('G')" key="G" :closable="false" :disabled="isTabDisabled('G')">
        <Procedure
          ref="procedureRef"
          v-model:isChange="isChange"
          :data="allData.procedure"
          :procchk-options="options.procchkList"
          :procbefore-options="options.procbeforeList"
          :procafter-options="options.procafterList"
          :upd-flg="updFlg"
          :add-flg="addFlg"
          :del-flg="delFlg"
          @get-data="getData"
        ></Procedure>
        <template #tab>
          <span>ストアドプロシージャ</span>
        </template>
      </a-tab-pane>
    </a-tabs>
  </a-card>
  <CdPageModal
    v-model:visible="cVisible"
    v-model:isChange="isChange"
    :impno="queryParam.impno"
    :data="allData.changeCodeMainList"
    @upd-options="updOptions"
    @get-data="getData"
  ></CdPageModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//ファイル取込
//--------------------------------------------------------------------------
import { ref, onMounted, reactive, watch, toRef, computed, onUnmounted, nextTick } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { SelectProps, message } from 'ant-design-vue'
import BasicIinfo from './BasicIinfo.vue'
import FileInterface from './FileInterface.vue'
import CodeTransfer from './CodeTransfer.vue'
import MappingSetting from './MappingSetting.vue'
import ProjectDefine from './ProjectDefine.vue'
import ProjectTransfer from './ProjectTransfer.vue'
import Procedure from './Procedure.vue'
import { InitDetail, Delete, Save, CheckOrderSeq } from '../service'
import {
  HeaderVM,
  AllData,
  InitDetailResponse,
  AllDataChange,
  FileInfoVM,
  UploadData
} from '../type'
import {
  Enum編集区分,
  EnumServiceResult,
  Enumデータ形式,
  Enum入力区分,
  Enumマッピング区分,
  Enumマッピング方法,
  Enum入力方法,
  Enumエラーレベル,
  Enum演算子,
  Enum処理区分,
  Enum年度範囲区分,
  Enum登録区分
} from '#/Enums'
import {
  C001010,
  DELETE_OK_INFO,
  E001009,
  E003005,
  ITEM_ILLEGAL_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { showConfirmModal, showSaveModal, showDeleteModal, showInfoModal } from '@/utils/modal'
import {
  ITEM_REQUIRE_ERROR,
  ITEM_NOTEQUAL_ERROR,
  E001008,
  E004006,
  ITEM_SELECTREQUIRE_ERROR,
  E003006
} from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { Enum取込区分 } from '#/Enums'
import UAParser from 'ua-parser-js'
import TD from '@/components/Common/TableTD/index.vue'
import CdPageModal from '../../AWKK00609D/index.vue'
import { ImporterStore } from '@/store'
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const headRef = ref(null)
const isChange = ref(false)
const isFileImport = ref(false)
const updFlg = route.meta.updflg as boolean
const addFlg = route.meta.addflg as boolean
const delFlg = route.meta.delflg as boolean
const editJudge = new Judgement(route.name as string)
const isContentChange = ref(false)

const borderWarning = ref(false)
const cVisible = ref(false)
const isUpload = ref(false)
//ビューモデル
const queryParam = ref<HeaderVM>({
  impno: undefined,
  impnm: '',
  gyoumukbn: '',
  memo: '',
  regupdkbn: '',
  impkbn: '',
  yeardispflg: false,
  tableidList: [],
  procafter: '',
  procbefore: '',
  procchk: '',
  orderseq: 0,
  nendohanikbn: ''
})
let compareParam = reactive<HeaderVM>({
  impno: undefined,
  impnm: '',
  gyoumukbn: '',
  memo: '',
  regupdkbn: '',
  impkbn: '',
  yeardispflg: false,
  tableidList: [],
  procafter: '',
  procbefore: '',
  procchk: '',
  orderseq: 0,
  nendohanikbn: ''
})

const options = reactive({
  /** 【年度表示フラグ】のドロップダウンリスト */
  yeardispflgList: [] as SelectProps['options'],
  /** 【一括取込入力区分】のドロップダウンリスト */
  impkbnList: [] as SelectProps['options'],
  /** 【登録区分】のドロップダウンリスト */
  regupdkbnList: [] as SelectProps['options'],
  /** 【テーブル】のドロップダウンリスト */
  headtableidList: [] as DaSelectorKeyModel[],
  /** 【ファイル形式】のドロップダウンリスト */
  filetypeList: [] as SelectProps['options'],
  /** 【エンコード】のドロップダウンリスト */
  filenmruleList: [] as SelectProps['options'],
  /** 【データ形式】のドロップダウンリスト */
  datakbnList: [] as SelectProps['options'],
  /** 【引用符存在区分】のドロップダウンリスト */
  quoteskbnList: [] as SelectProps['options'],
  /** 【区切り記号】のドロップダウンリスト */
  dividekbnList: [] as SelectProps['options'],
  /** 【業務区分】のドロップダウンリスト */
  gyoumukbnList: [] as SelectProps['options'],
  /** 【変換区分】のドロップダウンリスト */
  changekbnList: [] as SelectProps['options'],
  trasnferOptions: [] as DaSelectorKeyModel[],
  /** 【チェック用】のドロップダウンリスト */
  procchkList: [] as SelectProps['options'],
  /** 【更新前処理】のドロップダウンリスト */
  procbeforeList: [] as SelectProps['options'],
  /** 【更新後処理】のドロップダウンリスト */
  procafterList: [] as SelectProps['options'],
  /** 【年度範囲】のドロップダウンリスト */
  nendohanikbnList: [] as SelectProps['options']
})
const errorClassMap = ref({})
const oldTabKey = ref('A')
const tabActiveKey = ref('')
const allData = ref<AllData>({
  projectDefine: [],
  procedure: {
    procafter: '',
    procbefore: '',
    procchk: ''
  }
})

const impno = ref<string | undefined>()
const upddttm = ref()
const editkbn = ref<Enum編集区分>(Enum編集区分.新規)
const formRef = ref()
const basicInfoRef = ref()
const fileInterfaceRef = ref()
const codeTransferRef = ref()
const mappingSettingRef = ref()
const projectDefineRef = ref()
const projectTransferRef = ref()
const procedureRef = ref()

const allDataChange = reactive<AllDataChange>({
  basicInfo: false,
  fileInterface: false,
  codeTransfer: false,
  mappingSetting: false,
  projectDefine: false,
  projectTransfer: false,
  procedure: false
})
let errorMessages = reactive<FileInfoVM>({
  filetype: '',
  fileencode: '',
  filenmrule: '',
  datakbn: '',
  recordlen: undefined,
  quoteskbn: '',
  dividekbn: '',
  headerrows: undefined,
  footerrows: undefined,
  filenmruleflg: false
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//一括取込入力区分
watch(
  () => queryParam.value.impkbn,
  () => {
    tabActiveKey.value = visibleTabs.value[0]
    oldTabKey.value = visibleTabs.value[0]
  }
)

watch(
  () => queryParam.value,
  () => {
    const isEdit = JSON.stringify(compareParam) != JSON.stringify(queryParam.value)
    if (isEdit) {
      editJudge.setEdited()
      isContentChange.value = true
    }
  },
  { deep: true }
)

watch(
  () => isChange.value,
  (val) => {
    if (val) {
      isContentChange.value = true
      editJudge.setEdited()
    }
  }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
})

onUnmounted(() => {
  ImporterStore.setUploadData(null)
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//ルール
const rules = computed(() => {
  return {
    gyoumukbn: [
      {
        required: true,
        message: ''
      }
    ],
    impnm: [
      {
        required: true,
        message: ''
      }
    ],
    impkbn: [
      {
        required: true,
        message: ''
      }
    ],
    regupdkbn: [
      {
        required: true,
        message: ''
      }
    ],
    orderseq: [
      {
        required: true,
        message: ''
      }
    ],
    nendohanikbn: [
      {
        required: queryParam.value.yeardispflg,
        message: ''
      }
    ],
    tableidList: [
      {
        required: true,
        message: ''
      }
    ]
  }
})
///可視化タブ
const visibleTabs = computed(() => {
  const tabs = ['A', 'B', 'C', 'D', 'E', 'F', 'G']
  return tabs.filter((tab) => isTabVisible(tab))
})
//ヘッダー項目
const isEditing = computed(() => visibleTabs.value[0] === tabActiveKey.value)
//タブ可視化判断
const isTabVisible = (key: string) => {
  // if (queryParam.value.regupdkbn === Enum登録区分.プロシージャ.toString()) {
  //   if (key === 'F') {
  //     return false
  //   }
  // }
  if (
    !queryParam.value.impkbn ||
    queryParam.value.impkbn === Enum取込区分.ファイル取込.toString()
  ) {
    return true
  } else if (queryParam.value.impkbn === Enum取込区分.一括入力.toString()) {
    return key === 'C' || key === 'F' || key === 'G'
  }

  //その他
  return true
}
//タブ非活性化判断
const isTabDisabled = (key) => {
  const currentIndex = visibleTabs.value.indexOf(tabActiveKey.value)
  const tabIndex = visibleTabs.value.indexOf(key)

  return !(
    tabIndex === currentIndex ||
    tabIndex === currentIndex + 1 ||
    tabIndex === currentIndex - 1
  )
}
//tab切替
const tabClick = (e) => {
  //重置
  borderWarning.value = false

  const currentIndex = visibleTabs.value.indexOf(oldTabKey.value)
  const newIndex = visibleTabs.value.indexOf(e)
  const isAdjacent = newIndex === currentIndex + 1 || newIndex === currentIndex - 1
  if (newIndex === currentIndex - 1) {
    oldTabKey.value = e
    isChange.value = false
  }
  let canSwitch = true
  if (newIndex === currentIndex + 1) {
    canSwitch = judageParentTable()
    if (canSwitch && validationMethods[oldTabKey.value]) {
      canSwitch = validationMethods[oldTabKey.value]()
    }
  }
  //現在のデータが変化しているか
  if (isChange.value) {
    tabActiveKey.value = oldTabKey.value
    //正しい経路で切り替え可能
    if (isAdjacent && canSwitch) {
      tabActiveKey.value = e
      oldTabKey.value = e
      isChange.value = false
    }
  } else {
    if (isAdjacent && canSwitch) {
      oldTabKey.value = e
    } else {
      tabActiveKey.value = oldTabKey.value
    }
  }
}
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------

//初期化処理
const getInitData = () => {
  impno.value = route.query.impno as string
  const insertFlg = route.query.impno ? true : false
  isUpload.value = (route.query.isUpload as string) ? true : false
  editkbn.value = insertFlg ? Enum編集区分.変更 : Enum編集区分.新規
  InitDetail({
    impno: impno.value,
    editkbn: editkbn.value,
    isUpload: isUpload.value,
    uploadData: ImporterStore.uploadData as UploadData
  }).then((res) => {
    initData(res)
    isFileImport.value = route.query.isFileImport ? true : false
  })
}
//データ初期化
const initData = (res: InitDetailResponse) => {
  queryParam.value = res.hearderData
  if (!queryParam.value.tableidList) {
    queryParam.value.tableidList = []
  }
  tabActiveKey.value = visibleTabs.value[0]
  oldTabKey.value = visibleTabs.value[0]
  compareParam = JSON.parse(JSON.stringify(queryParam.value))
  Object.assign(options, res)
  upddttm.value = res.upddttm
  initTabData(res)
}
//各タブデータ初期化
const initTabData = (uploadData: UploadData) => {
  allData.value.basicInfo = uploadData.fileinfoData
  allData.value.fileInterface = uploadData.fileifList
  allData.value.mappingSetting = uploadData.itemmappingList
  allData.value.codeTransfer = uploadData.codechangeList
  allData.value.projectDefine = uploadData.pageitemList
  allData.value.projectTransfer = uploadData.insertList
  allData.value.changeCodeMainList = uploadData.changeCodeMainList
  if (uploadData.hearderData) {
    allData.value.procedure = {
      procchk: uploadData.hearderData.procchk,
      procbefore: uploadData.hearderData.procbefore,
      procafter: uploadData.hearderData.procafter
    }
  }
}
//一覧へ
const goBack = () => {
  if (isContentChange.value || isFileImport.value) {
    showConfirmModal({
      content: C001010.Msg,
      onOk() {
        router.push({
          path: route.name as string
        })
        editJudge.reset()
      }
    })
  } else {
    router.push({
      path: route.name as string
    })
  }
}
//登録処理
const saveHandle = () => {
  formRef.value.clearValidate()
  let canSave = judageParentTable()
  if (canSave) {
    //check tab data
    visibleTabs.value.every((tab) => {
      const validate = validationMethods[tab]
      return validate ? validate() : true
    })
  }

  if (canSave) {
    formRef.value.validate().then(() => {
      showSaveModal({
        onOk: async () => {
          try {
            const res = await Save({
              hearderData: { ...queryParam.value, ...allData.value.procedure },
              fileinfoData: allData.value.basicInfo,
              fileifList: allData.value.fileInterface,
              codechangeList: allData.value.codeTransfer,
              itemmappingList: allData.value.mappingSetting,
              pageitemList: allData.value.projectDefine,
              insertList: allData.value.projectTransfer,
              changeCodeMainList: allData.value.changeCodeMainList!,
              editkbn: editkbn.value,
              upddttm: upddttm.value
            })
            if (res.returncode === EnumServiceResult.OK) {
              message.success(SAVE_OK_INFO.Msg)
              router.push({
                path: route.name as string
              })
            }
          } catch (error) {}
        }
      })
    })
  }
}
//削除処理
const deleteHandle = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        const res = await Delete({ impno: impno.value, upddttm: upddttm.value })
        if (res.returncode === EnumServiceResult.OK) {
          message.success(DELETE_OK_INFO.Msg)
          router.push({
            path: route.name as string
          })
        }
      } catch (error) {}
    }
  })
}
//各タブデータ取得処理
const getData = (type, data, isChange) => {
  allData.value[type] = data
  allDataChange[type] = isChange
}
/** 業務内唯一チェック処理 */
const CheckOrder = () => {
  if (queryParam.value.orderseq) {
    CheckOrderSeq({
      impkbn: queryParam.value.impkbn,
      impno: queryParam.value.impno,
      gyoumukbn: queryParam.value.gyoumukbn,
      orderseq: queryParam.value.orderseq
    })
  }
}
//ヘッダー情報検証フォーム処理
const headerValidate = () => {
  formRef.value.clearValidate()
  formRef.value.validate()
  const queryCheckField = [
    { name: '業務', value: 'gyoumukbn' },
    { name: '一括取込入力名', value: 'impnm' },
    { name: '一括取込入力区分', value: 'impkbn' },
    { name: '登録区分', value: 'regupdkbn' }
  ]
  for (let i = 0; i < queryCheckField.length; i++) {
    //必須チェック
    if (!queryParam.value[queryCheckField[i].value]) {
      return false
    }
  }
  if (queryParam.value.tableidList.length == 0) {
    return false
  }
  return true
}
//基本情報検証フォーム処理
const basicInfoValidate = () => {
  errorMessages = reactive<FileInfoVM>({
    filetype: '',
    fileencode: '',
    filenmrule: '',
    datakbn: '',
    recordlen: undefined,
    quoteskbn: '',
    dividekbn: '',
    headerrows: undefined,
    footerrows: undefined,
    filenmruleflg: false
  })
  let result = true
  //ヘッダー情報検証フォーム処理
  result = headerValidate()
  if (!result) {
    return result
  }
  let checkField = [
    { name: 'ファイル形式', value: 'filetype' },
    { name: 'エンコード', value: 'fileencode' },
    { name: 'データ形式', value: 'datakbn' }
  ]
  if (
    allData.value.basicInfo?.datakbn &&
    allData.value.basicInfo.datakbn.indexOf(Enumデータ形式.可変長.toString()) > -1
  ) {
    checkField.push({ name: '引用符', value: 'quoteskbn' })
    checkField.push({ name: '区切り記号', value: 'dividekbn' })
  } else {
    checkField.push({ name: 'レコード長', value: 'recordlen' })
  }

  if (allData.value.basicInfo!.filenmruleflg == false) {
    const os = new UAParser().getOS().name
    let regex
    if (os === 'Windows') {
      regex = /^[^<>:"/\\|?*\x00-\x1F]*[^<>:"/\\|?*\x00-\x1F .]$/
    } else if (['Mac OS', 'iOS'].includes(os)) {
      regex = /^[^:]*[^:\x00]$/
    } else if (['Linux', 'Unix', 'Android'].includes(os)) {
      regex = /^[^/]*[^/\x00]$/
    } else {
      regex = /^[a-zA-Z0-9_]+$/
    }

    if (
      allData.value.basicInfo!.filenmrule != '' &&
      !regex.test(allData.value.basicInfo!.filenmrule)
    ) {
      result = false
      errorMessages.filenmrule = ITEM_ILLEGAL_ERROR.Msg.replace('{0}', 'ファイル名称')
    } else {
      result = true
    }
  } else {
    if (allData.value.basicInfo!.filenmrule == null || allData.value.basicInfo!.filenmrule == '') {
      errorMessages.filenmrule = ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ファイル名称')
      result = false
    } else {
      try {
        new RegExp(allData.value.basicInfo!.filenmrule)
      } catch (e) {
        errorMessages.filenmrule = ITEM_ILLEGAL_ERROR.Msg.replace('{0}', 'ファイル名称(正規表現)')
        result = false
      }
    }
  }

  for (let i = 0; i < checkField.length; i++) {
    //必須チェック
    if (!allData.value.basicInfo![checkField[i].value]) {
      result = false
      errorMessages[checkField[i].value] = ITEM_REQUIRE_ERROR.Msg.replace('{0}', checkField[i].name)
    }
  }

  return result
}
//ファイルI/F検証フォーム処理
const fileInterfaceValidate = () => {
  let result = true
  if (allData.value.fileInterface!.length > 0) {
    const checkField = [
      { name: '項目名称', value: 'itemnm' },
      { name: 'データ型', value: 'datatype' },
      { name: '桁数', value: 'len' }
    ]
    let len = 0
    for (let item of allData.value.fileInterface!) {
      for (let i = 0; i < checkField.length; i++) {
        // 必須チェック
        if (!item[checkField[i].value]) {
          result = false
          borderWarning.value = true
          showInfoModal({
            type: 'error',
            title: 'エラー',
            content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須項目')
          })
          return result
        }
      }
      if (!item.len2) {
        len += item.len as number
      } else {
        len += (item.len as number) + 1 + item.len2
      }
    }

    //基本情報.データ形式が2（固定長）
    //基本情報.レコード長＝各項目桁数合計
    if (
      allData.value.basicInfo!.datakbn.indexOf(Enumデータ形式.固定長.toString()) > -1 &&
      len != allData.value.basicInfo?.recordlen
    ) {
      result = false
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: ITEM_NOTEQUAL_ERROR.Msg.replace(
          '{0}',
          '各項目桁数合計は基本情報.レコード長(' + allData.value.basicInfo?.recordlen + ')'
        )
      })
    }
  } else {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ファイルIF')
    })
    result = false
  }
  return result
}
//変換コード検証フォーム処理
const codeTransferValidate = () => {
  let result = true
  if (allData.value.codeTransfer && allData.value.codeTransfer.length > 0) {
    const checkField = [
      { name: 'ファイルコード', value: 'oldcode' },
      { name: 'システムコード', value: 'newcode' }
    ]
    allData.value.codeTransfer.forEach((item) => {
      let code = {}
      for (let c of item.codechangedetailList) {
        for (let i = 0; i < checkField.length; i++) {
          // 必須チェック
          if (!c[checkField[i].value]) {
            result = false
            borderWarning.value = true
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須項目')
            })
            return
          }

          //システムコードのドロップダウンリストチェック
          //todo
        }
        // 重複チェック
        if (code[c.oldcode]) {
          result = false
          showInfoModal({
            type: 'error',
            title: 'エラー',
            content: E001008.Msg.replace('{0}', 'ファイルコード')
          })
          return
        } else {
          code[c.oldcode] = c.oldcode
        }
      }
    })
  }
  if (allData.value.projectDefine) {
    for (const item of allData.value.projectDefine) {
      if (
        item.inputkbn.indexOf(Enum入力区分.コード系.toString()) > -1 &&
        !allData.value.codeTransfer?.some((e) =>
          e.codechangedetailList.find((detail) => detail.cdchangekbn?.toString() === item.inputtype)
        )
      ) {
        result = false
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', item.inputtypeName! + '明細')
        })
        break
      }
    }
  }

  return result
}
//マッピング設定検証フォーム処理
const mappingSettingValidate = () => {
  let result = true
  if (allData.value.mappingSetting && allData.value.mappingSetting.length > 0) {
    allData.value.mappingSetting.forEach((item) => {
      let checkField = [
        { name: '項目名称', value: 'pageitemnm' },
        { name: 'マッピング区分', value: 'mappingkbn' }
      ]
      //マッピング区分が1（関数）
      if (item.mappingkbn && item.mappingkbn?.indexOf(Enumマッピング区分.関数.toString()) > -1) {
        checkField.push({ name: 'マッピング方法', value: 'mappingmethod' })
      }
      //マッピング区分が0（マッピングなし）以外
      if (
        item.mappingkbn &&
        item.mappingkbn?.indexOf(Enumマッピング区分.マッピングなし.toString()) < 0
      ) {
        checkField.push({ name: 'ファイル項目', value: 'fileitemseq' })
      }
      //マッピング方法が桁数指定の場合、入力必須
      if (
        item.mappingmethod &&
        item.mappingmethod?.indexOf(Enumマッピング方法.桁数指定.toString()) > -1
      ) {
        checkField.push({ name: '桁数指定（開始）', value: 'substrfrom' })
        checkField.push({ name: '桁数指定（終了）', value: 'substrto' })
      }
      for (let i = 0; i < checkField.length; i++) {
        //必須チェック
        if (!item[checkField[i].value]) {
          result = false
          showInfoModal({
            type: 'error',
            title: 'エラー',
            content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', checkField[i].name)
          })
          break
        }
        if (
          checkField[i].value == 'fileitemseq' &&
          item['fileitemseq'] != undefined &&
          item['fileitemseqName'] != undefined
        ) {
          let fileName = item['fileitemseqName'].split(',')
          let strInput = item['fileitemseq']
          let strArray = typeof strInput === 'string' ? strInput.split(',') : ''
          for (let j = 0; j < strArray.length; j++) {
            if (
              !allData.value.fileInterface
                ?.map((obj) => obj.fileitemseq)
                .includes(parseInt(strArray[j])) &&
              strArray[j].indexOf("'") < 0
            ) {
              result = false
              showInfoModal({
                type: 'error',
                title: 'エラー',
                content: E004006.Msg.replace(
                  '{0}',
                  fileName.length > j ? fileName[j] : checkField[i].name
                ).replace('{1}', checkField[i].name)
              })
              break
            }
          }
        }

        //桁数指定（開始）
        if (checkField[i].value == 'substrfrom') {
          let tempValue = item['substrfrom'] != undefined ? item['substrfrom'] : 0
          if (tempValue < 1) {
            let fileName = item['fileitemseqName']
            result = false
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: E003006.Msg.replace('{0}', fileName + 'に桁数指定')
            })
            break
          }
        }

        //桁数指定（終了）
        if (checkField[i].value == 'substrto') {
          let tempValue = item['substrto'] != undefined ? item['substrto'] : 0
          let strInput = item['fileitemseq']
          let strArray = typeof strInput === 'string' ? strInput : ''
          let targetFile = allData.value.fileInterface?.find(
            (f) => f.fileitemseq === parseInt(strArray)
          )
          if (targetFile == null) {
            continue
          }
          let targetLen = targetFile.len != undefined ? targetFile.len : 0
          if (tempValue > targetLen) {
            let fileName = item['fileitemseqName']
            result = false
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: E003006.Msg.replace('{0}', fileName + 'に桁数指定')
            })
            break
          }
        }
      }
    })
  } else {
    result = false
  }
  return result
}
//項目定義検証フォーム処理
const projectDefineValidate = () => {
  let result = true
  if (queryParam.value.impkbn === Enum取込区分.一括入力.toString()) {
    //ヘッダー情報検証フォーム処理
    result = headerValidate()
    if (!result) {
      return result
    }
  }
  if (allData.value.projectDefine && allData.value.projectDefine.length > 0) {
    let itemkbnCheckMap = {} //項目特定区分check
    allData.value.projectDefine.forEach((item) => {
      let checkField = [
        { name: '項目名', value: 'itemnm' },
        { name: 'ワークテープルカラム名', value: 'wktablecolnm' },
        { name: '入力区分', value: 'inputkbn' },
        { name: '入力方法', value: 'inputtype' },
        { name: '桁数', value: 'len' },
        { name: '幅', value: 'width' },
        { name: '必須', value: 'requiredflg' },
        { name: '表示入力設定', value: 'dispinputkbn' }
      ]
      //入力区分が4（マスタ参照）
      if (item.inputkbn.indexOf(Enum入力区分.マスタ参照.toString()) > -1) {
        checkField.push({ name: '参照元フィールド', value: 'fromfieldid' })
        checkField.push({ name: '参照元項目', value: 'fromitemseq' })
        checkField.push({ name: '取得先フィールド', value: 'targetfieldid' })
      }
      //マスタテーブルが選択された
      if (item.msttable) {
        checkField.push({ name: 'マスタ存在-項目', value: 'mstfield' })
      }
      //入力方法が医療機関、従事者のみ入力必須
      if (
        item.inputtype &&
        (item.inputtype?.indexOf(Enum入力方法.医療機関.toString()) > -1 ||
          item.inputtype?.indexOf(Enum入力方法.事業従事者.toString()) > -1)
      ) {
        checkField.push({ name: '実施事業', value: 'jigyocd' })
      }
      //必須が0（無視）
      if (item.requiredflg === Enumエラーレベル.無視.toString()) {
        checkField.push({ name: 'エラーレベル', value: 'jherrlelkbn' })
      }
      //エラーレベルが0（無視）以外
      if (item.jherrlelkbn && item.jherrlelkbn !== Enumエラーレベル.無視.toString()) {
        checkField.push({ name: '条件必須-項目', value: 'jhitemseq' })
        checkField.push({ name: '条件必須-演算子', value: 'jhenzan' })
        //演算子がbetween,not between
        if (
          item.jhenzan!.indexOf(Enum演算子.between.toString()) > -1 ||
          item.jhenzan!.indexOf(Enum演算子.not_between.toString()) > -1
        ) {
          if (!item.jhval || item.jhval?.indexOf(',') < 0) {
            result = false
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: E001009.Msg.replace('{0}', '条件値をカンマ区切り')
            })
          }
        }
        //演算子がis null,is not null以外
        if (
          item.jhenzan!.indexOf(Enum演算子.is_null.toString()) < 0 &&
          item.jhenzan!.indexOf(Enum演算子.is_not_null.toString()) < 0
        ) {
          checkField.push({ name: '条件必須-値', value: 'jhval' })
        }
      }
      //必須チェック
      for (let i = 0; i < checkField.length; i++) {
        if (!item[checkField[i].value]) {
          result = false
          showInfoModal({
            type: 'error',
            title: 'エラー',
            content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', checkField[i].name)
          })
          break
        }
      }
      //コード系-入力方法存在チェック
      if (
        item.inputkbn.indexOf(Enum入力区分.コード系.toString()) > -1 &&
        !allData.value.changeCodeMainList?.find((e) => e.codehenkankbn === +item.inputtype!)
      ) {
        result = false
        errorClassMap.value[item.pageitemseq] = 'warning'
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: E004006.Msg.replace(
            '{0}',
            `${item.itemnm}の入力方法(${item.inputtypeName})`
          ).replace('{1}', '変換区分')
        })
      }
      //マスタ参照-参照元項目存在チェック
      if (
        item.inputkbn.indexOf(Enum入力区分.マスタ参照.toString()) > -1 &&
        !allData.value.projectDefine?.find((f) => f.pageitemseq === item.fromitemseq)
      ) {
        result = false
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: E004006.Msg.replace('{0}', item.fromitemseqName!).replace('{1}', '画面項目')
        })
      }
      //関数-引数画面項目存在チェック
      if (item.inputkbn === Enum入力区分.関数.toString()) {
        let pageitemseqs = item.hikisuName?.split(',').filter((e) => !e.includes("'")) ?? []
        let projectDefinePageitemseqsSet = new Set(
          allData.value.projectDefine?.map((f) => f.itemnm.toString()) ?? []
        )
        let notInProjectDefine = pageitemseqs.filter(
          (seq) => !projectDefinePageitemseqsSet.has(seq)
        )
        if (notInProjectDefine.length > 0) {
          result = false
          showInfoModal({
            type: 'error',
            title: 'エラー',
            content: E004006.Msg.replace('{0}', notInProjectDefine[0]).replace('{1}', '項目定義')
          })
        }
      }
      //条件必須-条件項目存在チェック
      if (
        item.jherrlelkbn &&
        item.jherrlelkbn !== Enumエラーレベル.無視.toString() &&
        !allData.value.projectDefine?.find((f) => f.pageitemseq === item.jhitemseq)
      ) {
        result = false
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: E004006.Msg.replace('{0}', item.fromitemseqName!).replace('{1}', '画面項目')
        })
      }

      //項目特定区分 check
      if (item.itemkbn) {
        let findList = allData.value.projectDefine?.filter((t) => t.itemkbn == item.itemkbn)
        if (findList && findList.length > 1) {
          result = false
          itemkbnCheckMap[item.itemkbn] = item.itemkbnName
        }
      }
    })

    //項目特定区分errorModal
    let itemkbnErrorMsg = ''
    for (let i in itemkbnCheckMap) {
      let item = itemkbnCheckMap[i]
      itemkbnErrorMsg += '、' + item
    }
    if (itemkbnErrorMsg.length > 0) {
      itemkbnErrorMsg = itemkbnErrorMsg.substring(1)
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E001008.Msg.replace('{0}', '項目特定区分【' + itemkbnErrorMsg + '】')
      })
    }
  } else {
    result = false
  }
  return result
}
//検証フォーム処理
const projectTransferValidate = () => {
  let result = true
  if (allData.value.projectTransfer && allData.value.projectTransfer.length > 0) {
    allData.value.projectTransfer.forEach((item) => {
      item.insertdetailList.forEach((insert) => {
        let checkField = [{ name: '処理区分', value: 'syorikbn' }]
        if (insert.syorikbn === Enum処理区分.画面項目登録.toString()) {
          checkField.push({ name: 'データ元項目', value: 'pageitemseq' })
          //マスタ参照-参照元項目/マスタ存在-項目存在チェック
          if (!allData.value.projectDefine?.find((p) => p.pageitemseq === insert.pageitemseq)) {
            result = false
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: E004006.Msg.replace('{0}', insert.itemnm!).replace('{1}', '画面項目')
            })
          }
        }
        if (insert.syorikbn.indexOf(Enum処理区分.関連テーブルの項目から登録.toString()) > -1) {
          checkField.push({ name: 'データ元テーブル', value: 'datamototableronrinm' })
          if (
            insert.datamototablenm &&
            !queryParam.value.tableidList.includes(insert.datamototablenm)
          ) {
            result = false
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: E003005.Msg.replace('{0}', insert.datamototableronrinm!)
            })
          }
        }
        //必須チェック
        for (let i = 0; i < checkField.length; i++) {
          if (!insert[checkField[i].value]) {
            result = false
            showInfoModal({
              type: 'error',
              title: 'エラー',
              content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', checkField[i].name)
            })

            break
          }
        }
      })
    })
  } else {
    result = false
  }
  return result
}
//親テーブル必須チェック
const judageParentTable = () => {
  let isParentSelected = true
  let parentid = ''
  queryParam.value.tableidList.forEach((t) => {
    const selectTable = options.headtableidList.find((to) => to.value === t)
    if (selectTable?.key) {
      const parentTable = selectTable.key.split(',')
      parentTable.forEach((p) => {
        if (parentid.indexOf(p) < 0) {
          parentid += p + ','
        }
      })
    }
  })
  if (parentid) {
    //選択されたテーブルの親テーブルが存在する場合、親テーブル選択必須
    let isAllUndefined = parentid
      .substring(0, parentid.length - 1)
      .split(',')
      .every((p) => {
        const f = queryParam.value.tableidList.find((t) => t === p)
        if (!f) {
          return true
        }
        return false
      })

    if (isAllUndefined) {
      isParentSelected = false
      parentid
        .substring(0, parentid.length - 1)
        .split(',')
        .forEach((p) => {
          showInfoModal({
            type: 'error',
            title: 'エラー',
            content: ITEM_SELECTREQUIRE_ERROR.Msg.replace(
              '{0}',
              options.headtableidList!.find((t) => t.value == p)!.label
            )
          })
        })
    }
  }
  return isParentSelected
}
//検証フォーム処理
const validationMethods = {
  A: basicInfoValidate,
  B: fileInterfaceValidate,
  C: projectDefineValidate,
  D: codeTransferValidate,
  E: mappingSettingValidate,
  F: projectTransferValidate,
  G: () => true
}
//【変換区分】のドロップダウンリスト更新
const updOptions = (data) => {
  options.changekbnList = data.map((item) => ({
    label: item.henkankbnnm,
    value: item.codehenkankbn.toString()
  }))
}
//年度範囲処理
const nendoHani = () => {
  queryParam.value.nendohanikbn = queryParam.value.yeardispflg
    ? Enum年度範囲区分.メニュー引き継ぐ_コントロールマスタ年度.toString()
    : ''
}
</script>
<style scoped>
:deep(.ant-tabs-card > .ant-tabs-nav .ant-tabs-tab) {
  border-radius: 5px;
}
:deep(.ant-form-item-with-help .ant-form-item-explain) {
  display: none;
}
:deep(.ant-form-item) {
  margin-bottom: 0 !important;
}
.self_adaption_table th {
  width: 150px;
  white-space: nowrap;
}
</style>
