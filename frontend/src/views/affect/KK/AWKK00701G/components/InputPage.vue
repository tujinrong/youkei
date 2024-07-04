<template>
  <a-spin :spinning="loading">
    <a-card ref="headerRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row :gutter="[0, 10]">
          <a-col :xs="24" :sm="12" :md="10" :lg="6" :xl="6" :xxl="4">
            <th>業務</th>
            <TD>{{ gyoumukbnnm }}</TD>
          </a-col>
          <a-col :xs="24" :sm="22" :md="20" :lg="14" :xl="8" :xxl="6">
            <th>{{ impnmText }}</th>
            <TD>{{ impnm }}</TD></a-col
          ><a-col v-if="yeardispflg" :xs="24" :sm="12" :md="10" :lg="8" :xl="6" :xxl="4">
            <th style="background-color: #ecf5ff">年度</th>
            <td>
              <year-jp
                v-model:value="queryParam.nendo"
                :max="queryParam.nendomax"
                style="width: 100%"
              ></year-jp>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex justify-between" style="align-items: flex-start">
        <a-space wrap>
          <a-button type="primary" @click="checkData">チェック</a-button>
          <a-button type="primary" @click.prevent="save()">登録実行</a-button>
          <a-button type="primary" @click="tempSave()">仮保存</a-button>
          <a-button v-if="activeKey === 'A'" type="primary" danger @click="deleteData()"
            >削除</a-button
          >
          <a-button type="primary" @click.prevent="goBack()">一覧へ</a-button>
          <a-button type="primary" @click="goErrorList">エラー一覧</a-button>
          <a-button type="primary" @click="initVal()">初期値</a-button>
          <a-button type="primary" @click="copyColumn">一括コピー</a-button>
        </a-space>
        <a-space class="">
          <close-page style="width: 100%"></close-page>
        </a-space>
      </div>
    </a-card>

    <a-card class="m-t-1">
      <a-tabs v-model:activeKey="activeKey" type="card">
        <a-tab-pane key="A" tab="編集" :disabled="pageMode != '2'">
          <InputTable
            ref="editTable"
            v-model:data-list="editList"
            v-model:impkbn="impkbn"
            v-model:err-cnt="editErrcnt"
            v-model:info-cnt="editInfoCnt"
            v-model:normal-cnt="editNormalCnt"
            v-model:warn-cnt="editWarnCnt"
            v-model:max-date="maxDate"
            v-model:min-date="minDate"
            v-model:impexeid="impexeid"
            v-model:seleced-list="addSelecetedList"
            v-model:total-count="totalCount"
            v-model:old-code-val="editOldCodeVal"
            v-model:currentPage="currentPage"
            v-model:selected-cell="selectedCell"
            :data-column="columns"
            :new-options="selectOptions"
            :old-options="oldSelectOptions"
            :pull-down-options="pullDownOptions"
            :header-height="height"
            tab-mode="1"
            @page-change="getTableListBeforeCheck"
            @reload-original-edit-list="reloadOriginalEditList"
          ></InputTable>
        </a-tab-pane>
        <a-tab-pane key="B" tab="新規">
          <InputTable
            ref="addTable"
            v-model:data-list="addList"
            v-model:impkbn="impkbn"
            v-model:max-date="maxDate"
            v-model:min-date="minDate"
            v-model:total-count="totalCount"
            v-model:max-row-no="rownoMax"
            v-model:old-code-val="addOldCodeVal"
            v-model:selected-cell="selectedCell"
            :new-options="selectOptions"
            :old-options="oldSelectOptions"
            :pull-down-options="pullDownOptions"
            :header-height="height"
            :data-column="columns"
            tab-mode="2"
          ></InputTable>
        </a-tab-pane>
      </a-tabs>
    </a-card>
  </a-spin>
  <ErrorListModal
    v-model:visible="errorListVisible"
    v-model:currentRowIndex="currentRowIndex"
    :impexeid="impexeid"
  >
  </ErrorListModal>
  <AprogerssUpd
    :pvisible="pvisible"
    :percent="percent"
    :content="content"
    :contentarray="contentarray"
  ></AprogerssUpd>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//データ入力
//--------------------------------------------------------------------------
import { ref, reactive, onMounted, computed, watch, nextTick } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { message } from 'ant-design-vue'
import { useElementSize } from '@vueuse/core'
import ErrorListModal from '../../AWKK00704D/index.vue'
import InputTable from './InputTable.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { showDeleteModal, showConfirmModal, showInfoModal } from '@/utils/modal'
import {
  A000008,
  C001010,
  C001013,
  C001014,
  C001015,
  C001016,
  C001017,
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  I000010,
  I000012,
  ITEM_REQUIRE_ERROR,
  J000001
} from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { CheckDetail, Save, InitDetail, SaveWork, DeleteEdit, ProgressHandle } from '../service'
import { EnumServiceResult, Enum編集区分, Enum取込区分 } from '#/Enums'
import { KimpDetailRowVM, Selector, KeySelector, PageItemHeaderModel } from '../type'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { ss } from '@/utils/storage'
import AprogerssUpd from '@/views/affect/KK/AWKK00701G/components/Progress.vue'
import TD from '@/components/Common/TableTD/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  tabActiveKey: string
}
const props = withDefaults(defineProps<Props>(), {
  tabActiveKey: ''
})
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
//ページャー
const currentPage = ref(1)
const pageSize = ref(25)
const oldPageSize = ref(25)
const totalCount = ref(0)
//ローディング
const loading = ref(false)
const errorListVisible = ref(false)
//ビューモデル
const tableList = ref<any[]>([])

const queryParam = reactive({
  nendo: ss.get(GLOBAL_YEAR),
  nendomax: undefined
})
const pageMode = ref()
const impno = ref('')
const impexeid = ref(-1)
//明細部の高さの計算
const headerRef = ref(null)
const editTable = ref()
const addTable = ref()
const { height } = useElementSize(headerRef)
const editJudge = new Judgement(route.name as string)
const editErrcnt = ref(0)
const editInfoCnt = ref(0)
const editNormalCnt = ref(0)
const editWarnCnt = ref(0)
const columns = ref<PageItemHeaderModel[]>([])
const selectOptions = ref<KeySelector[]>([])
const oldSelectOptions = ref<KeySelector[]>([])
const pullDownOptions = ref<Selector[]>([])
const impkbn = ref('')
const yeardispflg = ref(false)
const checkField = ref<{ name: string; value: string | number }[]>([])
const activeKey = ref('')
const editList = ref<KimpDetailRowVM[]>([])
const originalEditList = ref<KimpDetailRowVM[]>([])
const addSelecetedList = ref([])
const addList = ref<KimpDetailRowVM[]>([])
const minDate = ref<string>('')
const maxDate = ref<string>('')
const upddttm = ref<Date>()
const currentRowIndex = ref(-1)
const rownoMax = ref(0)
const addOldCodeVal = ref<any>()
const editOldCodeVal = ref<any>()
const isTriggered = ref(false)
const gyoumukbnnm = ref('')
const impnm = ref('')
const percent = ref(0)
const content = ref('')
const pvisible = ref(false)
const contentarray = ref<string[]>([])
const contentShow = ref<string[]>(['画面項目チェック', '登録実行', '仮保存'])
const selectedCell = ref({})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

const impnmText = computed(() => {
  if (impkbn.value) {
    return impkbn.value === Enum取込区分.ファイル取込.toString() ? '一括取込内容' : '一括入力内容'
  }
  return ''
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => queryParam.nendo,
  (newValue) => {
    minDate.value = newValue + 0 + '-' + '04' + '-' + '01'
    maxDate.value = newValue + 1 + '-' + '03' + '-' + '31'
  },
  { deep: true }
)
watch(
  () => editList.value,
  (newValue) => {
    judagePageEdit()
  },
  { deep: true }
)
watch(
  () => addList.value,
  (newValue) => {
    judagePageEdit()
  },
  { deep: true }
)
watch(
  () => currentRowIndex.value,
  (newValue) => {
    setCurrentRow()
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
})

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  impno.value = route.query.impno as string
  impexeid.value = parseInt(route.query.impexeid as string)
  pageMode.value = route.query.mode as string
  if (!yeardispflg.value) {
    queryParam.nendo = ''
  }
  getTableList(1, 25, true)
}

//検索処理check
const getTableListBeforeCheck = (index, size) => {
  if (editJudge.isPageEdited()) {
    tempSavePage(index, size)
    //return false
  } else {
    getTableList(index, size)
  }
}

//検索処理
const getTableList = (index, size, initflg = false) => {
  // pageLoading.value = true
  if (oldPageSize.value != size) {
    currentPage.value = 1
  } else {
    currentPage.value = index
  }
  pageSize.value = size
  oldPageSize.value = size
  currentPage.value = index
  if (pageMode.value == '2') {
    activeKey.value = 'A'
  } else {
    activeKey.value = 'B'
  }
  loading.value = true
  InitDetail({
    editkbn: pageMode.value === '2' ? Enum編集区分.変更 : Enum編集区分.新規,
    impexeid: impexeid.value,
    impno: impno.value,
    nendo: queryParam.nendo,
    pagenum: currentPage.value,
    pagesize: pageSize.value,
    rowNo: isTriggered.value ? currentRowIndex.value : 0
  })
    .then((res) => {
      if (pageMode.value == '2' && (res.detailList == null || res.detailList.length <= 0)) {
        editJudge.reset()
        router.push({
          path: route.name as string,
          query: {
            tabActiveKey: props.tabActiveKey == '' ? 'B' : props.tabActiveKey
          }
        })
        return
      }

      editList.value = res.detailList
      originalEditList.value = JSON.parse(JSON.stringify(res.detailList))
      editErrcnt.value = res.errCnt
      editNormalCnt.value = res.normalCnt
      editWarnCnt.value = res.warnCnt
      editInfoCnt.value = res.infoCnt
      rownoMax.value = res.rownoMax
      upddttm.value = res.upddttm
      impkbn.value = res.impkbn
      gyoumukbnnm.value = res.gyoumukbnnm
      impnm.value = res.impnm
      yeardispflg.value = res.yeardispflg
      selectOptions.value = res.cdchangeSelectorDic
      oldSelectOptions.value = res.cdchangeOldSelectorDic
      pullDownOptions.value = res.selectorDic
      columns.value = res.pageItemHeaderList
      totalCount.value = res.totalrowcount
      impexeid.value = res.impexeid
      currentPage.value = res.pagenum
      if (yeardispflg.value && initflg) {
        queryParam.nendo = res.nendo === '' ? ss.get(GLOBAL_YEAR) : res.nendo
        queryParam.nendomax = res.nendomax
      }
      if (isTriggered.value) {
        nextTick(() => {
          editTable.value.setCurrentRow(currentRowIndex.value)
        })
      }
    })
    .finally(() => {
      loading.value = false
      isTriggered.value = false
    })
}

//初期値処理
const initVal = () => {
  //新規list空にすることはできません
  if (pageMode.value == '1' && (addList.value == null || addList.value.length <= 0)) {
    showInfoModal({ content: A000008.Msg })
    return
  }

  if (activeKey.value === 'A') {
    editTable.value.initVal()
  } else {
    addTable.value.initVal()
  }
}
//データ行の列移動
const handleTableToList = () => {
  let dataList: KimpDetailRowVM[] = []
  let i = 0
  if (editList.value && editList.value.length > 0) {
    editList.value.forEach((e) => {
      e.pageItemBodyList.forEach((p) => {
        const isExistOldCode = editOldCodeVal.value[i + '']?.hasOwnProperty(p.pageitemseq)
        //変換コードの有無
        if (isExistOldCode) {
          const oldVal = editOldCodeVal.value[i + ''][p.pageitemseq]
          const val = p.val ? p.val.split(':')[0].trim() : undefined
          if (oldVal) {
            p.val = oldVal.split(':')[0].trim() + ',' + (val ? val : '')
          } else {
            if (val) {
              p.val = ',' + val
            } else {
              p.val = val
            }
          }
        }
      })
      i++
    })
  }

  //ファイル取込
  if (impkbn.value === Enum取込区分.ファイル取込.toString()) {
    i = 0
    addList.value.forEach((e) => {
      e.pageItemBodyList.forEach((p) => {
        const isExistOldCode = addOldCodeVal.value[i + '']?.hasOwnProperty(p.pageitemseq)
        //変換コードの有無
        if (isExistOldCode) {
          const oldVal = addOldCodeVal.value[i + ''][p.pageitemseq]
          const val = p.val ? p.val.split(':')[0].trim() : undefined
          if (oldVal) {
            p.val = oldVal.split(':')[0].trim() + ',' + (val ? val : '')
          } else {
            if (val) {
              p.val = ',' + val
            } else {
              p.val = val
            }
          }
        }
      })
      i++
    })
  }
  if (editList.value && editList.value.length > 0) {
    dataList = dataList.concat(editList.value)
  }
  if (addList.value && addList.value.length > 0) {
    dataList = dataList.concat(addList.value)
  }
  return dataList
}

//登録実行処理
const save = () => {
  //新規list空にすることはできません
  if (pageMode.value == '1' && (addList.value == null || addList.value.length <= 0)) {
    showInfoModal({ content: A000008.Msg })
    return
  }

  showConfirmModal({
    content: C001014.Msg,
    onOk: async () => {
      loading.value = true
      content.value = '画面項目チェック'
      percent.value = 0
      contentarray.value = ['画面項目チェック']
      let datestr = Date.now().toString()
      const dataList = handleTableToList()
      try {
        pvisible.value = true
        const [checkRes, proRes] = await Promise.all([
          CheckDetail({
            editkbn: pageMode.value === '2' ? Enum編集区分.変更 : Enum編集区分.新規,
            impexeid: impexeid.value,
            impno: impno.value,
            upddttm: upddttm.value,
            detailList: dataList,
            nendo: queryParam.nendo,
            processKey: datestr
          }),
          checkProgress(datestr)
        ])
        if (checkRes.returncode == EnumServiceResult.OK) {
          pvisible.value = false
          editErrcnt.value = checkRes.errCnt
          editInfoCnt.value = checkRes.infoCnt
          editNormalCnt.value = checkRes.normalCnt
          editWarnCnt.value = checkRes.warnCnt
          impexeid.value = checkRes.impexeid
          showConfirmModal({
            content: C001015.Msg.replace('{0}', checkRes.normalCnt + '')
              .replace('{1}', checkRes.infoCnt + '')
              .replace('{2}', checkRes.warnCnt + '')
              .replace('{3}', checkRes.errCnt + ''),
            async onOk() {
              content.value = '登録実行'
              percent.value = 0
              contentarray.value = ['登録実行']
              datestr = Date.now().toString()
              try {
                pvisible.value = true
                const [saveRes] = await Promise.all([
                  Save({
                    detailList: dataList,
                    impexeid: impexeid.value,
                    impno: impno.value,
                    upddttm: upddttm.value,
                    editkbn: pageMode.value === '2' ? Enum編集区分.変更 : Enum編集区分.新規,
                    nendo: queryParam.nendo,
                    processKey: datestr
                  }),
                  checkProgress(datestr)
                ])
                if (saveRes.returncode == EnumServiceResult.OK) {
                  setTimeout(() => {
                    pvisible.value = false
                    showInfoModal({
                      content: J000001.Msg.replace(
                        '{0}',
                        checkRes.normalCnt + checkRes.infoCnt + checkRes.warnCnt + ''
                      ),
                      onOk: () => {
                        editJudge.reset()
                        router.push({
                          path: route.name as string,
                          query: {
                            gyoumukbn: route.query.gyoumukbn as string,
                            impkbn: route.query.impkbn as string,
                            tabActiveKey: 'C'
                          }
                        })
                      }
                    })
                  }, 1000)
                } else {
                  changeMode()
                  loading.value = false
                }
              } catch (error) {
                pvisible.value = false
                Promise.reject()
                changeMode()
                loading.value = false
              }
            },
            onCancel: () => {
              changeMode()
              loading.value = false
            }
          })
        }
      } catch (error) {
        pvisible.value = false
        Promise.reject()
        loading.value = false
      }
    }
  })
}
//一覧
const goBack = () => {
  if (editJudge.isPageEdited()) {
    showConfirmModal({
      content: C001010.Msg,
      onOk: () => {
        editJudge.reset()
        router.push({
          path: route.name as string,
          query: {
            gyoumukbn: route.query.gyoumukbn as string,
            impkbn: route.query.impkbn as string,
            tabActiveKey: props.tabActiveKey == '' ? 'C' : props.tabActiveKey
          }
        })
      }
    })
  } else {
    editJudge.reset()
    router.push({
      path: route.name as string,
      query: {
        gyoumukbn: route.query.gyoumukbn as string,
        impkbn: route.query.impkbn as string,
        tabActiveKey: props.tabActiveKey == '' ? 'C' : props.tabActiveKey
      }
    })
  }
}
const goErrorList = () => {
  //新規list空にすることはできません
  if (pageMode.value == '1' && (addList.value == null || addList.value.length <= 0)) {
    showInfoModal({ content: A000008.Msg })
    return
  }

  errorListVisible.value = true
}
//仮保存処理
const tempSave = () => {
  tempSavePage(null, null)
}
const tempSavePage = (index, size) => {
  //新規list空にすることはできません
  if (pageMode.value == '1' && (addList.value == null || addList.value.length <= 0)) {
    showInfoModal({ content: A000008.Msg })
    return
  }

  showConfirmModal({
    content: C001016.Msg,
    onOk: async () => {
      if (!checkMustInput()) {
        return
      }
      loading.value = true
      const dataList = handleTableToList()
      let datestr = Date.now().toString()
      SaveWork({
        detailList: dataList,
        impexeid: impexeid.value,
        impno: impno.value,
        upddttm: upddttm.value,
        editkbn: pageMode.value === '2' ? Enum編集区分.変更 : Enum編集区分.新規,
        nendo: queryParam.nendo,
        processKey: datestr
      })
        .then((saveRes) => {
          if (EnumServiceResult.OK === saveRes.returncode) {
            if (impkbn.value === Enum取込区分.一括入力.toString() && pageMode.value === '1')
              pvisible.value = false
            message.success(I000012.Msg)
            impexeid.value = saveRes.impexeid
            if (index) {
              currentPage.value = index
              pageSize.value = size
            }
            changeMode()
          } else {
            if (index) {
              editTable.value.setPageInfo(currentPage.value, pageSize.value)
            }
            pvisible.value = false
            loading.value = false
          }
        })
        .catch(() => {
          pvisible.value = false
          loading.value = false
        })
      if (impkbn.value === Enum取込区分.一括入力.toString() && pageMode.value === '1') {
        content.value = '仮保存'
        percent.value = 0
        contentarray.value = ['仮保存']
        pvisible.value = true
        checkProgress(datestr)
      }
    },
    onCancel: () => {
      if (index) {
        currentPage.value = index
        pageSize.value = size
        changeMode()
      }
      loading.value = false
    }
  })
}
//削除処理
const deleteData = () => {
  if (addSelecetedList.value == null || addSelecetedList.value.length <= 0) {
    showInfoModal({ content: A000008.Msg })
    return
  }

  showDeleteModal({
    handleDB: true,
    content:
      editList.value.length - addSelecetedList.value.length === 0
        ? C001017.Msg
        : DELETE_CONFIRM.Msg,
    onOk: async () => {
      loading.value = true
      const rowno: number[] = addSelecetedList.value.map((item: any) => item.rowno)
      try {
        const deleteRes = await DeleteEdit({
          impexeid: impexeid.value,
          rownoList: rowno,
          upddttm: upddttm.value!
        })
        if (EnumServiceResult.OK === deleteRes.returncode) {
          message.success(DELETE_OK_INFO.Msg)
          getTableList(currentPage.value, pageSize.value)
        } else {
          loading.value = false
        }
      } catch (error) {
        Promise.reject()
        loading.value = false
      }
    },
    onCancel: () => {
      loading.value = false
    }
  })
}

//チェック処理
const checkData = () => {
  //新規list空にすることはできません
  if (pageMode.value == '1' && (addList.value == null || addList.value.length <= 0)) {
    showInfoModal({ content: A000008.Msg })
    return
  }

  showConfirmModal({
    content: C001013.Msg,
    onOk: async () => {
      loading.value = true
      content.value = '画面項目チェック'
      percent.value = 0
      contentarray.value = ['画面項目チェック']
      const dataList = handleTableToList()
      let datestr = Date.now().toString()
      try {
        pvisible.value = true
        const [checkRes, proRes] = await Promise.all([
          CheckDetail({
            editkbn: pageMode.value === '2' ? Enum編集区分.変更 : Enum編集区分.新規,
            impexeid: impexeid.value,
            impno: impno.value,
            detailList: dataList,
            upddttm: upddttm.value,
            nendo: queryParam.nendo,
            processKey: datestr
          }),
          checkProgress(datestr)
        ])
        if (EnumServiceResult.OK == checkRes.returncode) {
          pvisible.value = false
          message.success(I000010.Msg)
          editErrcnt.value = checkRes.errCnt
          editInfoCnt.value = checkRes.infoCnt
          editNormalCnt.value = checkRes.normalCnt
          editWarnCnt.value = checkRes.warnCnt
          upddttm.value = checkRes.upddttm
          impexeid.value = checkRes.impexeid
          changeMode()
        } else {
          loading.value = false
        }
      } catch (error) {
        pvisible.value = false
        Promise.reject()
        loading.value = false
      }
    },
    onCancel: () => {
      loading.value = false
    }
  })
}
//必須チェック
const checkMustInput = () => {
  let result = true
  tableList.value.forEach((c) => {
    for (let i = 0; i < checkField.value.length; i++) {
      //必須チェック
      if (!c[checkField.value[i].value]) {
        result = false
        message.error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', checkField.value[i].name))
        break
      }
    }
  })
  return result
}
//ページが編集されているかどうか
const judagePageEdit = () => {
  const isEditPageEdit = JSON.stringify(editList.value) != JSON.stringify(originalEditList.value)
  if (addList.value.length > 0 || isEditPageEdit) {
    editJudge.setEdited()
  } else {
    editJudge.reset()
  }
}
//
const setCurrentRow = () => {
  let rownoList = editList.value.map((item) => item.rowno)
  if (rownoList.indexOf(currentRowIndex.value) < 0) {
    isTriggered.value = true
    activeKey.value = 'A'
    getTableList(currentPage.value, pageSize.value)
  } else {
    editTable.value.setCurrentRow(currentRowIndex.value)
  }
}
//編集モードに変更
const changeMode = () => {
  pageMode.value = '2'
  activeKey.value = 'A'
  addList.value = []
  getTableList(currentPage.value, pageSize.value)
}
//さいかじゅうoriginalEditList
const reloadOriginalEditList = () => {
  originalEditList.value = JSON.parse(JSON.stringify(editList.value))
}

//プログレスバーをチェックします
const checkProgress = async (datestr) => {
  while (pvisible.value) {
    const res = await ProgressHandle({ processKey: datestr })
    content.value = res.processnm
    percent.value = res.value
    if (contentShow.value.includes(content.value) && percent.value === 100) {
      break
    }
    await new Promise((resolve) => setTimeout(resolve, 500))
  }
}

//現在の列にデータをコピーします
const copyColumn = () => {
  if (activeKey.value === 'A') editTable.value.copyCell(selectedCell.value)
  else addTable.value.copyCell(selectedCell.value)
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}

:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}

.text-hidden {
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}

/deep/ .table-name {
  background-color: #ffffe1 !important;
}

.flex-1 :deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: end;
}

.self_adaption_table th {
  width: 100px;
}
</style>
