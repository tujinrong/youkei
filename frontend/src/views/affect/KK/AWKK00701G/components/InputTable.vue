<template>
  <a-spin :spinning="loading">
    <a-card ref="headerRef" :bordered="false">
      <div v-if="tabMode === '2'" class="flex justify-between">
        <a-space>
          <a-button type="primary" @click="addTable">行追加</a-button>
          <a-button :disabled="checkedList.length == 0" type="primary" @click="deleteTable"
            >行削除</a-button
          >
        </a-space>
      </div>
      <div v-else>
        <a-row>
          <a-col :md="24" :xxl="12">
            <div v-if="normalCnt || infoCnt || warnCnt || errCnt">
              正常：{{ props.normalCnt }}件　情報：{{ props.infoCnt }}件　警告：{{
                props.warnCnt
              }}件　エラー：{{ props.errCnt }}件
            </div>
          </a-col>
          <a-col :md="24" :xxl="12">
            <a-pagination
              v-model:current="localCurrentPage"
              v-model:page-size="pageSize"
              :total="totalCount"
              :show-size-changer="true"
              :page-size-options="$pagesizes"
              style="float: right"
              @change="pageChange"
            />
          </a-col>
        </a-row>
      </div>
    </a-card>

    <div tabindex="8">
      <vxe-table
        ref="xTableRef"
        :height="tableHeight"
        :data="tableList"
        :column-config="{ resizable: true }"
        :header-cell-class-name="'bg-editable'"
        :mouse-config="{ selected: true }"
        :row-config="{ isCurrent: true, height: 36 }"
        :keyboard-config="{
          isTab: true,
          isEdit: true
        }"
        :edit-config="{
          trigger: 'click',
          mode: 'cell',
          showStatus: false,
          beforeEditMethod({ row, column }) {
            return true
          }
        }"
        :valid-config="{ showMessage: false }"
        :empty-render="{ name: 'NotData' }"
        @cell-click="onClickCell"
      >
        <vxe-column width="100" field="rowno" header-class-name="table-name" fixed="left">
          <template #header>{{ tabMode == '1' ? '行番号' : 'No' }}</template>
          <template #edit="scope">
            <a-textarea
              v-model:value="scope.row.no"
              :maxlength="5"
              :auto-size="{ minRows: 1 }"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column width="110" field="errMsg" header-class-name="table-name" fixed="left">
          <template #header> エラー内容 </template>
          <template #default="{ row, rowIndex }">
            <a v-if="row.errMsg == 'エラー表示'" @click="goErrorItem(rowIndex)">エラー表示</a>
            <span v-else>{{ row.errMsg }}</span>
          </template>
        </vxe-column>
        <vxe-column
          v-for="(column, index) in columns"
          :key="index"
          :field="column.pageitemseq + ''"
          :width="
            column.inputkbn === Enum入力区分.マスタ参照.toString() &&
            column.inputtype === Enum入力方法.宛名番号.toString()
              ? column.width == null
                ? 200
                : column.width + 50
              : column.width
          "
          :header-class-name="
            allTargetitemseq.includes(column.pageitemseq + '') ||
            column.dispinputkbn === Enum表示入力設定.表示.toString() ||
            column.inputkbn == Enum入力区分.マスタ参照.toString()
              ? 'table-name'
              : ''
          "
          :class-name="({ rowIndex }) => getInputColClass(column.pageitemseq, rowIndex, column)"
          :edit-render="
            allTargetitemseq.includes(column.pageitemseq + '') ||
            column.dispinputkbn === Enum表示入力設定.表示.toString() ||
            column.inputkbn == Enum入力区分.マスタ参照.toString()
              ? undefined
              : { autofocus: 'input,textarea', autoselect: true, name: 'Importer' }
          "
        >
          <template #header
            >{{ column.itemnm }}
            <span v-if="['1', '2', '3'].includes(column.requiredflg!)" class="request-mark"
              >＊</span
            >
          </template>
          <template #default="{ row }">
            <span
              v-if="
                [
                  Enum入力区分.コード系.toString(),
                  Enum入力区分.プルダウンリスト.toString(),
                  Enum入力区分.プルダウン_画面検索.toString()
                ].includes(column.inputkbn)
              "
            >
              {{ getInputkbnText(row[column.pageitemseq + ''], column) }}
            </span>
            <span v-else-if="column.inputtype === Enum入力方法.日付_年月日 + ''">
              {{
                row[column.pageitemseq + ''] &&
                getDateJpText(new Date(row[column.pageitemseq + '']))
              }}
            </span>
            <span v-else-if="column.inputtype === Enum入力方法.日付_年月日_不詳あり + ''">
              {{
                row[column.pageitemseq + ''] && getUnKnownDateJpText(row[column.pageitemseq + ''])
              }}
            </span>
            <span v-else-if="column.inputtype === Enum入力方法.日時_年月日時分秒 + ''">
              {{
                row[column.pageitemseq + ''] &&
                getUnKnownDateJpText(row[column.pageitemseq + ''].split(' ')[0]) +
                  ' ' +
                  row[column.pageitemseq + ''].split(' ')[1]
              }}
            </span>
            <span v-else-if="column.inputtype === Enum入力方法.半角文字_時刻 + ''">
              {{ row[column.pageitemseq + ''] && getJikanText(row[column.pageitemseq + '']) }}
            </span>
            <span
              v-else-if="
                column.inputtype === Enum入力方法.全角文字_全角_改行可 + '' ||
                column.inputtype === Enum入力方法.全角半角文字_全角半角_改行可 + ''
              "
            >
              <div v-html="formattedHtmlText(row[column.pageitemseq + ''])"></div>
            </span>
            <span v-else> {{ row[column.pageitemseq + ''] }}</span>
          </template>
          <template
            v-if="
              column.dispinputkbn === Enum表示入力設定.入力.toString() &&
              column.inputkbn != Enum入力区分.マスタ参照.toString()
            "
            #edit="{ row, rowIndex }"
          >
            <RenderTextOne
              v-if="column.inputkbn === Enum入力区分.テキスト.toString() && ![
                    Enum入力方法.日付_年月日.toString(),Enum入力方法.日付_年月日_不詳あり.toString()
                    ,Enum入力方法.日時_年月日時分秒.toString(),Enum入力方法.数値_小数点付き実数.toString(),
                    Enum入力方法.数値_符号付き整数.toString(),
					          Enum入力方法.数値_整数.toString()
                    ].includes(column.inputtype!)"
              :row="{
                    ...row,
                    inputtypekbn: parseInt(column.inputtype!),
                    keta1: column.len,
                    value: getTextValue(column,row[column.pageitemseq + '']),
                    rows: 1
                  }"
              :events="{
                onChange: (data) => setData(data, column, rowIndex),
                onFinish: (data) => formatData(data, column, rowIndex)
              }"
            />
            <RenderDateOne
              v-else-if="
                    column.inputkbn === Enum入力区分.テキスト.toString() &&[
                    Enum入力方法.日付_年月日.toString(),Enum入力方法.日時_年月日時分秒.toString(),Enum入力方法.日付_年月日_不詳あり.toString()
                    ].includes(column.inputtype!)"
              :row="{
                    ...row,
                    inputtypekbn: parseInt(column.inputtype!) ,
                    keta1: column.width,
                    hanif:minDate,
                    hanit:maxDate,
                    value: row[column.pageitemseq + '']
                  }"
              :events="{
                onChange: (data) => setData(data, column, rowIndex),
                onFinish: (data) => blur(column, rowIndex)
              }"
            ></RenderDateOne>
            <RenderNumOne
              v-else-if="
                    column.inputkbn === Enum入力区分.テキスト.toString() &&[
                    Enum入力方法.数値_小数点付き実数.toString(),
                    Enum入力方法.数値_符号付き整数.toString(),
					Enum入力方法.数値_整数.toString()
                    ].includes(column.inputtype!)"
              :row="{
                    ...row,
                    inputtypekbn: parseInt(column.inputtype!) ,
                    keta1: column.len,
                    keta2:column.len2,
                    hanif:Enum入力方法.数値_整数.toString() ===column.inputtype?0:'',
                    hanit:Enum入力方法.数値_整数.toString() ===column.inputtype?Math.pow(10, column.len)-1:'',
                    value: row[column.pageitemseq + '']
                  }"
              :events="{
                onChange: (data) => setNumData(data, column, rowIndex),
                onFinish: (data) => blur(column, rowIndex)
              }"
            ></RenderNumOne>
            <RenderSelectOne
              v-else-if="
                column.inputkbn === Enum入力区分.コード系.toString() ||
                column.inputkbn === Enum入力区分.プルダウンリスト.toString()
              "
              :row="{
                ...row,
                cdlist:
                  column.pageitemseq.toString().indexOf('_before') > -1
                    ? getOldOptions(column.inputtype)
                    : getOptions(column.inputkbn, column.inputtype),
                value: row[column.pageitemseq + '']
              }"
              :events="{
                onChange: (data) => setData(data, column, rowIndex),
                onFinish: (data) => blur(column, rowIndex)
              }"
              :defaultOpen="true"
            ></RenderSelectOne>
            <InputSearch
              v-else-if="
                column.inputkbn === Enum入力区分.画面検索.toString() &&
                column.inputtype === Enum入力方法.宛名番号.toString()
              "
              v-model:value="row[column.pageitemseq + '']"
              @click="medcialSet(rowIndex, column.pageitemseq)"
              @search="openEdit($event, column, rowIndex)"
              @blur="formatData(row[column.pageitemseq + ''], column, rowIndex)"
            ></InputSearch>
            <RenderSearchOne
              v-else-if="
                column.inputkbn === Enum入力区分.プルダウン_画面検索.toString() &&
                [
                  Enum入力方法.医療機関,
                  Enum入力方法.事業従事者,
                  Enum入力方法.検診実施機関
                ].includes(Number(column.inputtype))
              "
              :row="{
                    ...row,
                    cdlist:
                     getOptions(column.inputkbn, column.inputtype),
                    inputtypekbn: parseInt(column.inputtype!) ,
                    value: row[column.pageitemseq + ''],
                    jigyocds:column.jigyocd
                  }"
              :events="{
                onFinish: (data) => setKikanData(data, column, rowIndex),
                onChange: (data) => setData(data, column, rowIndex)
              }"
            /><a-input
              v-else-if="column.inputkbn === Enum入力区分.関数.toString()"
              v-model:value="row[column.pageitemseq + '']"
            />
          </template>
          <template
            v-else-if="
              column.dispinputkbn === Enum表示入力設定.表示.toString() ||
              column.inputkbn != Enum入力区分.マスタ参照.toString() ||
              allTargetitemseq.includes(column.pageitemseq + '')
            "
            #edit="{ row }"
            >{{ row[column.pageitemseq + ''] }}</template
          >
        </vxe-column>
      </vxe-table>
    </div>
  </a-spin>
  <ErrorModal v-model:visible="errorVisible" :impexeid="impexeid!" :rowno="rowno" />
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//データ入力
//--------------------------------------------------------------------------
import { ref, onMounted, computed, watch, nextTick } from 'vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import InputSearch from '@/views/affect/AF/AWAF00705D/InputSearch.vue'
import ErrorModal from '../../AWKK00703D/index.vue'
import { showDeleteModal } from '@/utils/modal'
import { GetTargetItemValue, DoSpecialPageItem, DoKansu } from '../service'
import {
  Enum入力区分,
  Enum入力方法,
  Enum項目特定区分,
  Enum表示入力設定,
  Enum取込区分
} from '#/Enums'
import dayjs from 'dayjs'
import {
  KimpDetailRowVM,
  PageItemHeaderModel,
  CodeTrans,
  PageItemBodyModel,
  Selector
} from '../type'
import { getDateJpText, getUnKnownDateJpText } from '@/utils/util'
import {
  RenderTextOne,
  RenderNumOne,
  RenderDateOne,
  RenderSelectOne,
  RenderSearchOne
} from '@/components/Common/VxeRender/importer'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  dataList: KimpDetailRowVM[]
  dataColumn: PageItemHeaderModel[]
  newOptions: any
  oldOptions: any
  pullDownOptions: Selector[]
  errCnt?: number
  infoCnt?: number
  warnCnt?: number
  normalCnt?: number
  impkbn: string
  headerHeight: number
  tabMode: string
  maxDate: string
  minDate: string
  impexeid?: number
  selectedList?: any[]
  totalCount: number
  maxRowNo?: number
  oldCodeVal: any
  currentPage?: number
  selectedCell: any
}
const props = withDefaults(defineProps<Props>(), {
  visible: false,
  currentPage: 0
})
const emit = defineEmits([
  'update:dataList',
  'update:selecedList',
  'update:oldCodeVal',
  'update:selectedCell',
  'pageChange',
  'reloadOriginalEditList'
])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const route = useRoute()
//ページャー
const pageSize = ref(25)
const oldPageSize = ref(25)
const addIndex = ref(0)
//ローディング
const loading = ref(false)
const errorVisible = ref(false)
//ビューモデル
const tableList = ref<any[]>([])
const isAdd = ref(false)
const impno = ref('')
const currentIndex = ref(-1)
const checkedList = ref<any[]>([])
//テンプレート参照
const xTableRef = ref<VxeTableInstance>()
const headerRef = ref()
const columns = ref<PageItemHeaderModel[]>([])
const selectOptions = ref<any>({})
const oldSelectOptions = ref<any>({})
const oldcodeRalation = ref<{ name?: string; val?: string }>({})
const allTargetitemseq = ref<string[]>([])
const currentTargetitemseq = ref('')
const checkField = ref<{ name: string; value: string | number }[]>([])
const originalList = ref<KimpDetailRowVM[]>([])
const rowno = ref()
const initErrorMap = ref<{ pageitemseq?: boolean }>({})
const initErrorClassMap = ref<{ pageitemseq?: string }>({})
const localCurrentPage = ref(props.currentPage)
const kansuList = ref<
  {
    pageitemseq: string | number
    inputtype: string | undefined
    hikisus: string[]
  }[]
>([])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => {
  const { tableHeight: height } = useTableHeight(headerRef.value, -60)
  return Math.max(height.value - (props.headerHeight ? props.headerHeight : 0), 400)
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => tableList.value,
  (newValue) => {
    handleTableToList(false)
  },
  { deep: true }
)
watch(
  () => props.dataColumn,
  (newValue) => {
    getTableList()
  },
  { deep: true }
)
watch(
  () => xTableRef.value?.getCurrentRecord(),
  (newValue) => {
    if (newValue) {
      checkedList.value = [newValue]
    } else {
      checkedList.value = []
    }
  },
  { deep: true }
)
watch(
  () => checkedList.value,
  (newValue) => {
    emit('update:selecedList', newValue)
  },
  { deep: true }
)
watch(
  () => props.maxRowNo,
  (newValue) => {
    addIndex.value = 0
  },
  { deep: true }
)
watch(
  () => props.currentPage,
  (newValue) => {
    localCurrentPage.value = newValue
  }
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
  getTableList()
}

//検索処理
const getTableList = () => {
  loading.value = true
  let codeTrans: CodeTrans[] = []
  originalList.value = JSON.parse(JSON.stringify(props.dataList))
  let dataList = JSON.parse(JSON.stringify(props.dataList))
  columns.value =
    props.dataColumn && props.dataColumn.length > 0
      ? props.dataColumn.filter((item) => item.dispinputkbn != Enum表示入力設定.非表示.toString())
      : []
  kansuList.value = columns.value
    .filter((e) => +e.inputkbn === Enum入力区分.関数)
    .map((e) => {
      return {
        pageitemseq: e.pageitemseq,
        inputtype: e.inputtype,
        hikisus: e.hikisu ? e.hikisu.split(',').filter((item) => !item.includes("'")) : []
      }
    })
  //一括入力状況のコード変換処理
  if (props.impkbn === Enum取込区分.ファイル取込.toString()) {
    let columnIndex = 0
    columns.value.forEach((p) => {
      //ファイル取込、コード系
      if (
        props.impkbn === Enum取込区分.ファイル取込.toString() &&
        p.inputkbn == Enum入力区分.コード系.toString()
      ) {
        const trans: CodeTrans = {
          index: columnIndex,
          pageitemseq: p.pageitemseq,
          itemnm: p.itemnm + '旧コード',
          val: '',
          width: p.width,
          inputkbn: p.inputkbn,
          inputtype: p.inputtype,
          len: p.len
        }
        codeTrans.push(trans)
      }
      if (p.targetitemseq) {
        allTargetitemseq.value.push(p.targetitemseq)
      }
      //必須入力
      if (p.requiredflg) {
        checkField.value.push({ name: p.itemnm, value: p.pageitemseq })
      }
      columnIndex++
    })
    if (codeTrans.length > 0) {
      dataList.forEach((d) => {
        codeTrans.forEach((c) => {
          const item = d.pageItemBodyList.find((p) => p.pageitemseq === c.pageitemseq)
          if (item) {
            const val = item.val.split(',')
            let oldCodeVal = ''
            if (val.length > 1) {
              //コード
              item.val = val[1]
              //旧コード
              oldCodeVal = val[0]
            } else {
              //コード
              item.val = val[0]
            }
            const addData: PageItemBodyModel = {
              val: oldCodeVal,
              pageitemseq: c.pageitemseq + '_before',
              errflg: false,
              dataseq: -1,
              errkbn: '0'
            }
            d.pageItemBodyList.push(addData)
          }
        })
      })
      codeTrans.forEach((c) => {
        const addColumn: PageItemHeaderModel = {
          pageitemseq: c.pageitemseq + '_before',
          itemnm: c.itemnm,
          inputkbn: c.inputkbn,
          width: c.width,
          inputtype: c.inputtype,
          dispinputkbn: Enum表示入力設定.入力.toString(),
          len: c.len
        }
        oldcodeRalation.value[addColumn.pageitemseq] = {
          name: addColumn.pageitemseq,
          val: c.pageitemseq + ''
        }
        //旧コードヘッダーの挿入位置
        const index = columns.value.findIndex((col) => col.pageitemseq === c.pageitemseq)
        columns.value.splice(index, 0, addColumn)
      })
    }
  }
  //データ列伝行
  initTableVal(dataList)
  selectOptions.value = props.newOptions
  oldSelectOptions.value = props.oldOptions
  isAdd.value = false
  loading.value = false
}

//データ列伝行
const initTableVal = (list: KimpDetailRowVM[]) => {
  let dataList: any[] = []
  let oldCodeVal = {}
  initErrorMap.value = {}
  initErrorClassMap.value = {}
  if (!list) {
    tableList.value = []
  } else {
    let index = 0
    list.forEach((d) => {
      let data = {
        rowno: d.rowno,
        errMsg: d.errMsg
      }

      d.pageItemBodyList.forEach((p) => {
        data[p.pageitemseq] = p.val
        //初期化エラー状態の割り当て
        let pageitemseq = d.rowno + '_' + p.pageitemseq
        initErrorMap.value[pageitemseq] = p.errflg
        initErrorClassMap.value[pageitemseq] =
          p.errkbn === '3' ? 'bg-errorcell' : p.errkbn === '2' ? 'bg-warncell' : ''
        if (typeof p.pageitemseq === 'string' && p.pageitemseq.indexOf('before') > -1) {
          if (!oldCodeVal[index]) {
            oldCodeVal[index] = {}
          }
          oldCodeVal[index][p.pageitemseq] = p.val
        }
      })
      dataList.push(data)
      index++
    })
    tableList.value = dataList
  }
  emit('update:oldCodeVal', oldCodeVal)
  xTableRef.value?.reloadData(tableList.value)
  handleTableToList(true)
}
//初期値処理
const initVal = () => {
  props.dataColumn.forEach((c) => {
    tableList.value.forEach((t) => {
      let val = t[c.pageitemseq]
      if (!val) {
        val = c.defaultval
      }
      t[c.pageitemseq] = val
    })
  })
}
//データ行の列移動
const handleTableToList = (isReloadOriginal) => {
  let index = 0
  let oldCodeVal = {}
  tableList.value.forEach((t) => {
    for (let key in t) {
      if (key.indexOf('before') < 0) {
        const data = originalList.value[index].pageItemBodyList.find(
          (item) => item.pageitemseq == parseInt(key)
        )
        if (data) {
          data.val = t[key]
        }
      } else {
        if (!oldCodeVal[index]) {
          oldCodeVal[index] = {}
        }
        oldCodeVal[index][key.replace('_before', '')] = t[key]
      }
    }
    index++
  })
  emit('update:oldCodeVal', oldCodeVal)
  emit('update:dataList', originalList.value)
  //再ロードするかどうかOriginalEditList
  if (isReloadOriginal) {
    emit('reloadOriginalEditList')
  }
}

//宛名検索履歴後処理の選択
const openEdit = (atenano, column, rowIndex) => {
  //table値の設定
  if (column.targetitemseq && column.targetitemseq.length > 0) {
    setTargetItemValue(atenano, column.pageitemseq, rowIndex)
  }
  //項目特定区分
  if (
    column.itemkbn &&
    [
      Enum項目特定区分.実施日_一次_申込.toString(),
      Enum項目特定区分.実施日_精密_結果.toString(),
      Enum項目特定区分.生年月日.toString()
    ].includes(column.itemkbn)
  ) {
    setSpecialPageItem(atenano, column.pageitemseq, rowIndex)
  }
}
//table値の設定
const setTargetItemValue = (val, pageitemseq, rowIndex) => {
  loading.value = true
  GetTargetItemValue({ impno: impno.value, val: val, pageitemseq: pageitemseq })
    .then((res) => {
      res.targetItemValueList.forEach((t) => {
        tableList.value[rowIndex][t[0]] = t[1]
      })
    })
    .finally(() => {
      loading.value = false
    })
}
//項目特定区分設定
const setSpecialPageItem = (val, pageitemseq, rowIndex) => {
  loading.value = true
  let detailRowVM = originalList.value[rowIndex]
  DoSpecialPageItem({ impno: impno.value, pageitemseq: pageitemseq, detailRowVM })
    .then((res) => {
      res.targetItemValueList.forEach((t) => {
        tableList.value[rowIndex][t[0]] = t[1]
      })
    })
    .finally(() => {
      loading.value = false
    })
}
//削除処理
const deleteTable = () => {
  showDeleteModal({
    onOk: () => {
      const newList = tableList.value.slice()
      const originalData = originalList.value.slice()
      checkedList.value.forEach((item) => {
        const index = newList.indexOf(item)
        newList.splice(index, 1)
        originalData.splice(index, 1)
      })
      let indexNum = props.maxRowNo ? props.maxRowNo : 0
      let rowNum = 0
      newList.forEach((item) => {
        const index = newList.indexOf(item)
        item.rowno = indexNum + rowNum + 1
        originalData[index].rowno = item.rowno
        rowNum++
      })
      addIndex.value = rowNum
      tableList.value = newList
      originalList.value = originalData
      checkedList.value = []
    }
  })
}

//行追加処理
const addTable = () => {
  let index = props.maxRowNo! + addIndex.value
  let newList = tableList.value.slice()
  const originalData = originalList.value.slice()
  const data = { rowno: index + 1, errMsg: '' }
  let PageItemBodyList: PageItemBodyModel[] = []

  for (let i = 0; i < props.dataColumn.length; i++) {
    const body: PageItemBodyModel = {
      val: props.dataColumn[i].fixedval ?? '',
      pageitemseq: parseInt(props.dataColumn[i].pageitemseq.toString()),
      dataseq: 1,
      errflg: false,
      errkbn: '0'
    }
    data[props.dataColumn[i].pageitemseq.toString()] = props.dataColumn[i].fixedval ?? ''
    PageItemBodyList.push(body)
  }

  let codeTrans: CodeTrans[] = []
  //一括入力状況のコード変換処理
  if (props.impkbn === Enum取込区分.ファイル取込.toString()) {
    let columnIndex = 0
    columns.value.forEach((p) => {
      //ファイル取込、コード系
      if (
        props.impkbn === Enum取込区分.ファイル取込.toString() &&
        p.inputkbn == Enum入力区分.コード系.toString()
      ) {
        const trans: CodeTrans = {
          index: columnIndex,
          pageitemseq: p.pageitemseq,
          itemnm: p.itemnm + '旧コード',
          val: '',
          width: p.width,
          inputkbn: p.inputkbn,
          inputtype: p.inputtype,
          len: p.len
        }
        codeTrans.push(trans)
      }
      columnIndex++
    })
    if (codeTrans.length > 0) {
      codeTrans.forEach((c) => {
        const item = PageItemBodyList.find((p) => p.pageitemseq === c.pageitemseq)
        if (item) {
          data[c.pageitemseq + '_before'] = ''
        }
      })
    }
  }
  newList.push(data)
  originalData.push({ rowno: index + 1, errMsg: '', pageItemBodyList: PageItemBodyList })
  originalList.value = originalData
  tableList.value = newList
  addIndex.value += 1
}

const goErrorItem = (rowIndex) => {
  rowno.value = tableList.value[rowIndex].rowno
  errorVisible.value = true
}
//オプション
const getOptions = (inputkbn, kbcd) => {
  if (inputkbn == Enum入力区分.コード系.toString()) {
    //新しいコードのドロップダウンオプション
    return selectOptions.value ? selectOptions.value[parseInt(kbcd)] : []
  } else if (
    [
      Enum入力区分.プルダウンリスト.toString(),
      Enum入力区分.プルダウン_画面検索.toString()
    ].includes(inputkbn)
  ) {
    //入力区分が5（プルダウンリスト）と7（プルダウン_画面検索）のドロップダウンオプション
    return props.pullDownOptions ? props.pullDownOptions[kbcd] : []
  } else {
    return []
  }
}
//旧コードのドロップダウン・オプション
const getOldOptions = (kbcd) => {
  return oldSelectOptions.value ? oldSelectOptions.value[parseInt(kbcd)] : []
}
//宛名検索履歴
const medcialSet = (index, pageitemseq) => {
  currentIndex.value = index
  currentTargetitemseq.value = pageitemseq
}

//チェック処理
const getInputColClass: any = (dataId, dataIndex, column: PageItemHeaderModel) => {
  let pageitemseq = tableList.value[dataIndex].rowno + '_' + dataId
  //初期化エラー状態に応じた背景色の表示
  if (initErrorMap.value[pageitemseq]) {
    return initErrorClassMap.value[pageitemseq]
  }
  return ''
}
const setNumData = (data, column, dataIndex) => {
  setData(data, column, dataIndex)
}
//代入処理
const setData = (data, column, dataIndex) => {
  const dataId = column.pageitemseq
  let pageitemseq = tableList.value[dataIndex].rowno + '_' + dataId
  //初期化エラー状態の削除
  if (initErrorMap.value[pageitemseq]) {
    delete initErrorMap.value[pageitemseq]
    delete initErrorClassMap.value[pageitemseq]
  }
  let dataValue = data.value
  //旧コード判定
  if (oldcodeRalation.value[dataId + ''] && dataValue) {
    const newCodeId = oldcodeRalation.value[dataId + ''].val
    //新コードの値取得
    const inputtype = parseInt(column.inputtype)
    const options = oldSelectOptions.value[inputtype]?.find((l) => {
      return l.value === dataValue.split(':')[0].trim()
    })
    const newOptions = selectOptions.value[inputtype]?.find((l) => {
      return l.value === options?.key.split(':')[0].trim()
    })
    tableList.value[dataIndex][newCodeId] = options?.key + ' : ' + newOptions?.label
  }
  tableList.value[dataIndex][dataId + ''] = dataValue

  nextTick(() => {
    //table値の設定
    if (column.targetitemseq && column.targetitemseq.length > 0) {
      setTargetItemValue(dataValue, column.pageitemseq, dataIndex)
    }
    //項目特定区分
    if (
      column.itemkbn &&
      [
        Enum項目特定区分.実施日_一次_申込.toString(),
        Enum項目特定区分.実施日_精密_結果.toString(),
        Enum項目特定区分.生年月日.toString()
      ].includes(column.itemkbn)
    ) {
      setSpecialPageItem(dataValue, column.pageitemseq, dataIndex)
    }

    //フォロー特殊処理
    const specialItemKbns = [
      Enum項目特定区分.宛名番号.toString(),
      Enum項目特定区分.把握経路.toString(),
      Enum項目特定区分.把握事業.toString(),
      Enum項目特定区分.把握日.toString()
    ]

    if (column.itemkbn && specialItemKbns.includes(column.itemkbn)) {
      const items = specialItemKbns.map((kbn) => columns.value.find((e) => e.itemkbn === kbn))

      const allItemsExist = items.every(
        (item) => item && tableList.value[dataIndex][item.pageitemseq + '']
      )

      if (allItemsExist) {
        setSpecialPageItem(dataValue, column.pageitemseq, dataIndex)
      }
    }
  })
}

const setKikanData = (data, column, dataIndex) => {
  //項目特定区分
  if (
    data.value &&
    column.itemkbn &&
    [
      Enum項目特定区分.医療機関コード.toString(),
      Enum項目特定区分.検診実施機関番号.toString()
    ].includes(column.itemkbn)
  ) {
    setSpecialPageItem(data.value, column.pageitemseq, dataIndex)
    blur(column, dataIndex)
  }
}
//入力制御
const formatData = (data, column: PageItemHeaderModel, dataIndex) => {
  const dataId = column.pageitemseq
  let dataValue =
    column.inputkbn === Enum入力区分.画面検索.toString() &&
    column.inputtype === Enum入力方法.宛名番号.toString()
      ? data
      : data.value
  //0埋め変換
  if (dataValue != '' && column.format) {
    if (dataValue.length < column.len) {
      let zero = ''
      if (typeof dataValue === 'string') {
        for (let i = dataValue.length; i < column.len; i++) {
          zero += '0'
        }
      }
      //左
      if (column.format === '1') {
        dataValue = zero + dataValue
      }
      //右
      else {
        dataValue += zero
      }
    }
  }
  if (
    column.inputkbn == Enum入力区分.テキスト.toString() &&
    column.inputtype == Enum入力方法.半角文字_時刻.toString()
  ) {
    if (dataValue.indexOf(':') > -1) {
      dataValue = dataValue.replace(/:/g, '')
    }
  }
  tableList.value[dataIndex][dataId + ''] = dataValue
  blur(column, dataIndex)
}
const setCurrentRow = (rowno) => {
  const row = tableList.value.find((item) => item.rowno === rowno)
  xTableRef.value?.setCurrentRow(row)
  setTimeout(() => {
    xTableRef.value?.scrollToRow(row)
  }, 300)
}
//
const pageChange = (index: number, size: number) => {
  xTableRef.value?.scrollTo(0, 0)
  if (oldPageSize.value != size) {
    localCurrentPage.value = 1
  } else {
    localCurrentPage.value = index
  }
  pageSize.value = size
  oldPageSize.value = size
  localCurrentPage.value = index
  emit('pageChange', localCurrentPage.value, pageSize.value)
  checkedList.value = []
}
const getInputkbnText = (val, column) => {
  if (!val) {
    return ''
  }
  if (val.indexOf(' : ') > -1) {
    return val
  } else {
    let retText = val + ' : '
    let options
    if (column.pageitemseq.toString().indexOf('_before') > -1) {
      options = getOldOptions(column.inputtype)
    } else {
      options = getOptions(column.inputkbn, column.inputtype)
    }
    if (options) {
      let itemOpt = options.find((item) => item.value === val)
      if (itemOpt) {
        let itemText = itemOpt.label
        retText += itemText
      } else {
        return val
      }
    } else {
      return val
    }
    return retText
  }
  return val
}

//テキストhtml処理
const formattedHtmlText = (text) => {
  return text.replace(/\n/g, '<br>')
}

const setPageInfo = (index, size) => {
  pageSize.value = size
  oldPageSize.value = size
}

//コピー処理
function onClickCell({ row, column }) {
  emit('update:selectedCell', { row, column })
}

//列に選ばれたのデータをコピー
function copyCell(selectedCell) {
  if (selectedCell) {
    const { row, column } = selectedCell
    tableList.value.forEach((item) => {
      if (item[column.property] == undefined || item[column.property] == '') {
        item[column.property] = row[column.property]
        let indices = columns.value[column.property - 1].targetitemseq
        if (indices) {
          indices.split(',').forEach((e) => {
            item[+e] = row[+e]
          })
        }
      }
    })
  }
}
const blur = (column, rowIndex) => {
  if (kansuList.value.length > 0) {
    let kansuitem = kansuList.value.find((e) => e.hikisus.includes(column.pageitemseq + ''))
    if (kansuitem) {
      onKansuBlur(rowIndex, kansuitem.pageitemseq, kansuitem.inputtype)
    }
  }
}

const onKansuBlur = (rowIndex, pageitemseq, inputtype) => {
  let detailRowVM = originalList.value[rowIndex]
  DoKansu({
    impno: impno.value,
    inputhoho: inputtype,
    pageitemseq,
    detailRowVM
  }).then((res) => {
    res.kansuValueList.forEach((e) => {
      tableList.value[rowIndex][e[0]] = e[1]
    })
  })
}

//半角文字_時刻の変換
const getJikanText = (val: string) => {
  if (val.length === 4 && val.indexOf(':') < 0) {
    return val.slice(0, 2) + ':' + val.slice(2)
  }
  return val
}

const getTextValue = (column, val: string) => {
  return column.inputtype === Enum入力方法.半角文字_時刻.toString() &&
    val &&
    val.indexOf(':') < 0 &&
    val.length == 4
    ? val.slice(0, 2) + ':' + val.slice(2)
    : val
}
defineExpose({
  setCurrentRow,
  initVal,
  setPageInfo,
  copyCell
})
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

.vxe-body--column .vxe-cell .ant-form-item {
  margin: 0px;
}
:deep(.vxe-table--render-default.border--full .vxe-table--header-wrapper) {
  border-bottom: 0px solid #606266;
}
:deep(.vxe-table--render-default .vxe-body--row.row--current) {
  td {
    & > div {
      & > span :not(.request-mark) {
        color: #00000073;
      }
    }
  }
}
</style>
