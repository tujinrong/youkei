<template>
  <div class="flex relative" :class="loading && 'cover'">
    <div style="flex: 1">
      <a-tabs
        v-model:activeKey="activeKey"
        size="small"
        :tab-bar-style="{ height: '28px', 'font-weight': '700' }"
      >
        <a-tab-pane :key="ITEMENUMS.項目一覽" tab="項目一覽" :style="{ height: collapseHeight }">
          <ProjectCard :project-list="makprojectList" @setexceltext="setExcelText"></ProjectCard>
        </a-tab-pane>
        <a-tab-pane :key="ITEMENUMS.特殊項目" tab="特殊項目" :style="{ height: collapseHeight }">
          <ProjectCard :project-list="specProjectList" @setexceltext="setExcelText"></ProjectCard>
        </a-tab-pane>
      </a-tabs>
    </div>
    <div class="mt-3 ml-2" style="flex: 5">
      <div class="flex justify-between">
        <b>Excelテンプレート</b>
        <a-space class="mb-1">
          <a-button
            class="small-btn"
            type="primary"
            :disabled="!canUploadOrDownload"
            @click="uploadExcel"
            >アップロード</a-button
          >
          <a-button
            class="small-btn"
            type="primary"
            :disabled="!canUploadOrDownload"
            @click="downloadExcel"
            >ダウンロード</a-button
          >
        </a-space>
      </div>
      <div
        class="flex flex-col"
        style="border: 1px solid #606266"
        :style="{ height: collapseHeight }"
      >
        <a-form ref="formRef" class="mb-1" :model="setForm">
          <a-tabs v-model:activeKey="activeKey_tabs" type="card">
            <a-tab-pane key="1" tab="用紙">
              <div class="self_adaption_table form mb1 ml1">
                <a-row>
                  <a-col :span="6">
                    <th>サイズ</th>
                    <td>
                      <a-select
                        v-model:value="setForm.pagesize"
                        style="width: 100%"
                        :options="sizeOptions"
                      />
                    </td>
                  </a-col>
                  <a-col :span="6">
                    <th>方向</th>
                    <td>
                      <a-select
                        v-model:value="setForm.landscape"
                        style="width: 100%"
                        :options="landscapeOptions"
                      />
                    </td>
                  </a-col>
                  <a-col :span="6">
                    <th>行</th>
                    <td>
                      <a-input-number
                        v-model:value="blueRow"
                        class="w-full"
                        :min="maxRow"
                        :max="999"
                        @change="setForm.endrow = blueRow"
                      />
                    </td>
                  </a-col>
                  <a-col :span="6">
                    <th>列</th>
                    <td>
                      <a-input-number
                        v-model:value="blueCol"
                        class="w-full"
                        :min="maxCol"
                        :max="999"
                        @change="setForm.endcol = blueCol"
                      />
                    </td>
                  </a-col>
                </a-row>
              </div>
            </a-tab-pane>
            <a-tab-pane key="2" tab="明細" :disabled="!setForm.rowdetailflg">
              <div class="self_adaption_table form mb1 ml1">
                <a-row>
                  <a-col :span="8">
                    <th
                      :class="
                        props.yosikikbn === Enum様式種別詳細.クロス集計 && rowcolCanchange
                          ? 'bg-readonly'
                          : ''
                      "
                    >
                      開始行
                    </th>
                    <TD v-if="props.yosikikbn === Enum様式種別詳細.クロス集計 && rowcolCanchange">{{
                      setForm.startrow
                    }}</TD>
                    <td v-else>
                      <a-input-number
                        v-model:value="setForm.startrow"
                        :min="1"
                        style="width: 100%"
                      />
                    </td>
                  </a-col>
                  <a-col :span="8">
                    <th
                      :class="
                        rowcolCanchange || props.yosikikbn === Enum様式種別詳細.クロス集計
                          ? 'bg-readonly'
                          : ''
                      "
                    >
                      繰り返し
                    </th>
                    <td v-if="!rowcolCanchange && props.yosikikbn !== Enum様式種別詳細.クロス集計">
                      <a-input-number v-model:value="setForm.loopmaxrow" :min="1" class="w-full" />
                    </td>
                    <TD v-else-if="props.yosikikbn === Enum様式種別詳細.クロス集計">{{
                      setForm.loopmaxrow
                    }}</TD>
                    <TD v-else></TD>
                  </a-col>
                  <a-col :span="8">
                    <th>明細内行数</th>
                    <td>
                      <a-input-number
                        v-model:value="setForm.looprow"
                        :min="1"
                        style="width: 100%"
                      />
                    </td>
                  </a-col>
                </a-row>
              </div>
            </a-tab-pane>
            <a-tab-pane key="3" tab="横方向" :disabled="!setForm.coldetailflg">
              <div class="self_adaption_table form mb1 ml1">
                <a-row>
                  <a-col :span="8">
                    <th
                      :class="
                        props.yosikikbn === Enum様式種別詳細.クロス集計 && rowcolCanchange
                          ? 'bg-readonly'
                          : ''
                      "
                    >
                      開始列
                    </th>
                    <TD v-if="props.yosikikbn === Enum様式種別詳細.クロス集計 && rowcolCanchange">{{
                      setForm.startcol
                    }}</TD>
                    <td v-else>
                      <a-input-number
                        v-model:value="setForm.startcol"
                        :min="1"
                        style="width: 100%"
                      />
                    </td>
                  </a-col>
                  <a-col :span="8">
                    <th
                      :class="
                        rowcolCanchange || props.yosikikbn === Enum様式種別詳細.クロス集計
                          ? 'bg-readonly'
                          : ''
                      "
                    >
                      繰り返し
                    </th>
                    <td v-if="!rowcolCanchange && props.yosikikbn !== Enum様式種別詳細.クロス集計">
                      <a-input-number v-model:value="setForm.loopmaxcol" :min="1" class="w-full" />
                    </td>
                    <TD v-else-if="props.yosikikbn === Enum様式種別詳細.クロス集計">{{
                      setForm.loopmaxcol
                    }}</TD>
                    <TD v-else></TD>
                  </a-col>
                  <a-col :span="8">
                    <th>明細内列数</th>
                    <td>
                      <a-input-number
                        v-model:value="setForm.loopcol"
                        :min="1"
                        style="width: 100%"
                      />
                    </td>
                  </a-col>
                </a-row>
              </div>
            </a-tab-pane>
          </a-tabs>
        </a-form>
        <div
          id="luckysheet"
          :style="{ height: formHeight && sheetHeight, width: formHeight && '100%' }"
        />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import {
  Enumページサイズ,
  Enum内外区分,
  Enum明細有無,
  Enum様式作成方法,
  Enum様式種別,
  Enum様式種別詳細,
  Enum行列固定,
  Enum集計区分
} from '#/Enums'
import { A060003, DOWNLOAD_OK_INFO, E064015, ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { EUCStore, GlobalStore } from '@/store'
import { getHeight } from '@/utils/height'
import { Base64toBlob } from '@/utils/util'
import VXETable from '@/vxetable'
import { useElementSize } from '@vueuse/core'
import { message } from 'ant-design-vue'
import LuckyExcel from 'public/luckyexcel/dist/luckyexcel.esm'
import { Judgement } from '@/utils/judge-edited'
import { computed, nextTick, onMounted, onUnmounted, Ref, ref, watch, watchEffect } from 'vue'
import { DownloadExcelTemplate, SearchExcelMappingTab, InitSpecialItems } from '../../service'
import { ExcelMappingVM, YosikiTabInfoVM } from '../../type'
import ProjectCard from './ProjectCard.vue'
import { sheetCreateConfig, sizeOptions, landscapeOptions } from './constant'
import { useRoute } from 'vue-router'
import emitter from '@/utils/event-bus'
import { showInfoModal } from '@/utils/modal'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  /** 様式種別 */
  yosikisyubetu: Enum様式種別 | string
  /** 帳票ID */
  rptid: string
  /** 様式ID */
  yosikiid: string
  /** 様式枝番 */
  yosikieda: number
  /** 様式種別詳細 */
  yosikikbn: Enum様式種別詳細
  editJudge: Judgement
  tab2Ref: Ref
  tab3Ref: Ref
  tabActiveKey: TABKEYENUMS
  yosikihouhou: Enum様式作成方法
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
enum TABKEYENUMS {
  帳票設定 = 1,
  様式設定,
  項目定義,
  検索条件,
  Excelマッピング
}
enum ITEMENUMS {
  項目一覽 = 1,
  特殊項目
}
const activeKey = ref(ITEMENUMS.項目一覽)
const activeKey_tabs = ref('1')
const luckysheet = window.luckysheet
const jsonData = ref<any>({})
const maxRow = ref(0)
const maxCol = ref(0)
const blueRow = ref(0)
const blueCol = ref(0)
const setForm = ref<Omit<ExcelMappingVM, keyof DaResponseBase>>({
  templatefilenm: '',
  templatefiledata: '',
  endrow: 0,
  endcol: 0,
  pagesize: Enumページサイズ.A4,
  landscape: false,
  startrow: 1,
  loopmaxcol: 0,
  looprow: 1,
  startcol: 1,
  loopmaxrow: 0,
  loopcol: 1,
  celldatas: [],
  coldetailflg: false,
  rowdetailflg: false
})

interface SpecParams {
  koinnmflg: boolean
  koinpicflg: boolean
  meisaikoteikbn: string
  meisaiflg: boolean
  bottomItemList: string[]
}
const specParams = ref<SpecParams>({
  koinnmflg: false,
  koinpicflg: false,
  meisaikoteikbn: '',
  meisaiflg: false,
  bottomItemList: []
})
const fileList = ref<File[]>([])
//特殊項目
const specProjectList = ref<string[]>([])
//---------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const formRef = ref()
const formHeight = useElementSize(formRef).height
const sheetHeight = computed(() => getHeight(324 + formHeight.value))
const collapseHeight = computed(() => getHeight(318))
//項目一覽
const makprojectList = computed<string[]>(() =>
  EUCStore.defineItems.filter((e) => e.reportoutputflg).map((el) => el.reportitemnm)
)

//行列Disabled
const disabled_rowandcol = computed(() => {
  return (
    [Enum様式種別詳細.クロス集計, Enum様式種別詳細.一覧表].includes(props.yosikikbn) &&
    rowcolCanchange.value
  )
})
//繰り返しDisabled
const rowcolCanchange = computed(() => EUCStore['meisaikoteikbn'] == Enum行列固定.可変)
const canUploadOrDownload = computed(() => {
  if (props.tab2Ref.value) {
    const { excelflg, pdfflg } = props.tab2Ref.value.getFieldsValue()
    return excelflg || pdfflg
  }
  return true
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  if (
    (setForm.value.startrow && setForm.value.loopmaxrow && setForm.value.looprow) ||
    (setForm.value.startcol && setForm.value.loopmaxcol && setForm.value.loopcol)
  ) {
    setBorder()
  }
})
watch([blueCol, blueRow], ([col, row]) => {
  if (col && row) setBorder()
})

watch(
  () => [setForm.value, fileList.value],
  () => props.editJudge.setEdited(),
  { deep: true }
)
watch(
  () => setForm.value.loopmaxrow,
  (newValue) => {
    //入力可能場合のみ
    if (
      !rowcolCanchange.value &&
      props.yosikikbn !== Enum様式種別詳細.クロス集計 &&
      newValue &&
      luckysheet.getluckysheetfile() != null
    ) {
      const { startrow, endrow } = setForm.value
      const start_row = startrow ?? 1
      const end_row = +props.yosikisyubetu === Enum様式種別.一覧表 ? endrow : maxRow.value
      if (newValue + start_row - 1 > endrow) {
        //最大繰り返し(用紙行 - 明細開始行 + 1)
        nextTick(() => {
          setForm.value.loopmaxrow = end_row - start_row + 1
          //message.warning(A060003.Msg.replace('{0}', String(newValue)))
        })
      }
    }
  }
)

watch(
  () => props.tabActiveKey,
  (newVal) => {
    if (newVal === TABKEYENUMS.Excelマッピング) {
      specParams.value = {
        koinnmflg: EUCStore['koinnmflg'],
        koinpicflg: EUCStore['koinpicflg'],
        meisaikoteikbn: EUCStore['meisaikoteikbn'],
        meisaiflg: EUCStore['meisaiflg'],
        bottomItemList: EUCStore['bottomItemList'].map((el) => el.label || el.jyokenlabel)
      }
      specProjectList.value = fixSpecProjectList(specProjectList.value, specParams.value)
    }
  }
)

watch(
  () => [props.yosikisyubetu, props.yosikihouhou, EUCStore['naigaikbn']],
  ([newYosikisyubetu, newYosikihouhou]) => {
    if (!newYosikisyubetu || !newYosikihouhou) {
      return
    }
    const isPageReport = +newYosikisyubetu === Enum様式種別.台帳
    const isDataSource = +newYosikihouhou === Enum様式作成方法.データソース
    const IsCross = +props.yosikikbn === Enum様式種別詳細.クロス集計
    const naigaikbn = EUCStore['naigaikbn']
    InitSpecialItems({ isPageReport, IsCross, isDataSource, naigaikbn }).then((res) => {
      specProjectList.value = res.specialitemlist
    })
  }
)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  nextTick(() => init(true))
})
//初期化処理
let initCount = -1
const init = async (resetflg: boolean) => {
  if (initCount > 0 || !props.rptid) return
  initCount += 1
  GlobalStore.setLoading(true)
  loading.value = true
  // AIplus 2024-06-25 SHOU ADD Start
  // 新規が下記仕様種別詳細の場合、明細がある、行（列）固定区分が固定を設定する
  if (
    Boolean(route.query.isNew) &&
    (props.yosikikbn === Enum様式種別詳細.はがき ||
      props.yosikikbn === Enum様式種別詳細.アドレスシール ||
      props.yosikikbn === Enum様式種別詳細.バーコードシール)
  ) {
    //明細
    EUCStore['meisaiflg'] = true
    //行（列）固定区分
    EUCStore['meisaikoteikbn'] = Enum行列固定.固定
  }
  // AIplus 2024-06-25 SHOU ADD End
  try {
    const res = await SearchExcelMappingTab({
      rptid: props.rptid,
      yosikiid: props.yosikiid,
      yosikieda: props.yosikieda,
      yosikikbn: props.yosikikbn,
      meisaiflg: EUCStore['meisaiflg'],
      meisaikoteikbn: EUCStore['meisaikoteikbn'],
      excelStatus: Boolean(route.query.isNew)
    })
    const { loopmaxrow, loopmaxcol, ...rest } = res.excelmappingdata
    if (props.yosikikbn === Enum様式種別詳細.クロス集計) {
      if (!props.editJudge.isPageEdited()) {
        setForm.value = res.excelmappingdata
      } else {
        setForm.value = {
          ...rest,
          loopmaxrow: setForm.value.loopmaxrow,
          loopmaxcol: setForm.value.loopmaxcol
        }
      }
    } else {
      setForm.value = res.excelmappingdata
    }
  } catch (error) {
    loading.value = false
    GlobalStore.setLoading(false)
  }
  //excelロード base64 to blob
  if (setForm.value.templatefiledata) {
    const excelBlob = Base64toBlob(setForm.value.templatefiledata)
    const file = new File([excelBlob], 'template.xlsx', { type: excelBlob.type })
    fileList.value = [file]
    transformExcelToLucky(file, resetflg)
  } else {
    loading.value = false
    GlobalStore.setLoading(false)
  }
  if (resetflg) nextTick(() => props.editJudge.reset())
}

onUnmounted(() => luckysheet.destroy())

//エクセルデータ変換
const transformExcelToLucky = (file, resetflg) => {
  LuckyExcel.transformExcelToLucky(
    file,
    function (exportJson, luckysheetfile) {
      if (exportJson.sheets == null || exportJson.sheets.length == 0) {
        message.warning(
          ITEM_SELECTREQUIRE_ERROR.Msg.replace(
            '{0}',
            'ファイルインポート失敗しました、xlsxファイル'
          )
        )
        return
      }
      jsonData.value = exportJson

      luckysheet.create({
        ...sheetCreateConfig,
        data: exportJson.sheets,
        title: exportJson.info.name,
        hook: {
          cellMousedown,
          workbookCreateAfter: () => workbookCreateAfter(resetflg)
        }
      })
    },
    function (err) {
      loading.value = false
      GlobalStore.setLoading(false)
    }
  )
}

//ダウンロード処理
const downloadExcel = async () => {
  const celldatas = await getCellDatas()
  await DownloadExcelTemplate({
    celldatas,
    files: fileList.value
  })
  message.success(DOWNLOAD_OK_INFO.Msg)
}
//アップロード処理
const uploadExcel = async () => {
  const { file } = await VXETable.readFile({
    types: ['xlsx']
  })
  fileList.value = [file]
  bdMap.clear()
  luckysheet.destroy()
  setForm.value.endrow = setForm.value.endcol = 0
  transformExcelToLucky(file, false)
  nextTick(() => props.editJudge.setEdited())
}

//テキスト置換処理------------------------------------------------
const excelText = ref('')
const setExcelText = (text: string) => {
  excelText.value = text
}
document.onmousedown = function (event) {
  if (excelText.value) {
    let byClass = (document.getElementsByClassName('luckysheet-cell-sheettable')[0] as HTMLElement)
      .style
    byClass.cursor = ''
    let body = document.getElementsByTagName('body')[0].style
    body.cursor = ''
    excelText.value = ''
  }
}
const cellMousedown = (cell, postion) => {
  if (excelText.value) {
    if (
      props.yosikikbn === Enum様式種別詳細.クロス集計 &&
      makprojectList.value.includes(excelText.value.replace(/^\*\*/, ''))
    ) {
      if (postion.r < props.tab3Ref.value.colCount || postion.c < props.tab3Ref.value.rowCount) {
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: E064015.Msg.replace('{0}', 'セルをクリックして正しい箇所')
        })
        return
      } else {
        setForm.value.startrow = postion.r + 1
        setForm.value.startcol = postion.c + 1
        setForm.value.celldatas.forEach((el) => {
          el.forEach((cell) => {
            if (String(cell.value) == excelText.value) {
              luckysheet.setCellValue(cell.rowindex, cell.columnindex, { v: '', tb: 0 })
            }
          })
        })
      }
    }
    luckysheet.setCellValue(postion.r, postion.c, { v: excelText.value, tb: 1 })
    nextTick(() => {
      changExcel()
      props.editJudge.setEdited()
    })
  }
}

//--------------------------------------------------------------

//ワークブック処理
const workbookCreateAfter = (resetflg) => {
  loading.value = false
  GlobalStore.setLoading(false)
  setForm.value.templatefilenm = luckysheet.getSheet().name

  //画面テンプレート設定
  const data = luckysheet.getSheet().data
  maxRow.value = data.length
  maxCol.value = data[0]?.length ?? 0
  luckysheet.insertRow(maxRow.value, { number: 100 })
  luckysheet.insertColumn(maxCol.value, { number: 100 })
  blueRow.value = setForm.value.endrow || maxRow.value
  blueCol.value = setForm.value.endcol || maxCol.value
  setBorder()

  luckysheet.setRangeShow('A1:A1')
  luckysheet.scroll({ targetRow: 0 })

  //画面テンプレートファイル変換
  nextTick(async () => {
    await changExcel()
    if (resetflg) props.editJudge.reset()
  })
}

const bdMap = new Map()
function setBorder() {
  if (luckysheet.getluckysheetfile() == null) return
  const {
    startrow = 1,
    loopmaxrow = 0,
    looprow = 0,
    startcol = 1,
    loopcol = 0,
    loopmaxcol = 0
  } = setForm.value
  if (!luckysheet.getSheet().config.borderInfo) {
    luckysheet.getSheet().config.borderInfo = []
  }
  const bdInfos = luckysheet.getSheet().config.borderInfo
  const sheetName = luckysheet.getSheet().name
  if (!bdMap.get(sheetName)) {
    bdMap.set(sheetName, structuredClone(bdInfos))
  }
  luckysheet.getSheet().config.borderInfo = structuredClone(bdMap.get(sheetName))

  if (setForm.value.rowdetailflg) {
    // Dotted line (row)
    for (let j = 1; j < loopmaxrow; j++) {
      const START = setForm.value.coldetailflg ? startcol - 1 : 0
      const COUNT = setForm.value.coldetailflg
        ? Math.min(startcol + loopmaxcol * loopcol - 2, blueCol.value - 1)
        : blueCol.value - 1

      for (let i = START; i <= COUNT; i++) {
        const rowNo = startrow - 2 + looprow * j

        const finder = luckysheet
          .getSheet()
          .config.borderInfo.find((el) => el.value.row_index === rowNo && el.value.col_index === i)
        if (finder) {
          finder.value.b = {
            style: 4,
            color: '#ff393c'
          }
        } else {
          luckysheet.getSheet().config.borderInfo.push({
            rangeType: 'cell',
            value: {
              row_index: Math.min(rowNo, blueRow.value - 1),
              col_index: i,
              b: {
                style: 4,
                color: '#ff393c'
              }
            }
          })
        }

        const finderNext = luckysheet
          .getSheet()
          .config.borderInfo.find(
            (el) => el.value.row_index === rowNo + 1 && el.value.col_index === i
          )
        if (finderNext) {
          finderNext.value.t = {
            style: 4,
            color: '#ff393c'
          }
        }
      }
    }

    // Dotted line (column)
    // if (setForm.value.coldetailflg) {
    //   for (let j = 1; j <= loopmaxcol; j++) {
    //     const COUNT = Math.min(startrow + loopmaxrow * looprow - 2, blueRow.value - 1)

    //     for (let i = startrow - 1; i <= COUNT; i++) {
    //       const colNo = startcol - 2 + loopcol * j

    //       const finderNext = luckysheet
    //         .getSheet()
    //         .config.borderInfo.find(
    //           (el) => el.value.col_index === colNo + 1 && el.value.row_index === i
    //         )
    //       if (finderNext) {
    //         finderNext.value.l = {
    //           style: 4,
    //           color: '#ff393c'
    //         }
    //       }
    //     }
    //   }
    // }

    // Dotted line (column)
    if (setForm.value.coldetailflg) {
      for (let k = 1; k <= loopmaxcol; k++) {
        luckysheet.getSheet().config.borderInfo.push({
          rangeType: 'range',
          borderType: 'border-right',
          style: 4,
          color: '#ff393c',
          range: [
            {
              row: [
                Math.max(0, startrow - 1),
                Math.min(startrow + loopmaxrow * looprow - 2, blueRow.value - 1)
              ],
              column: [
                Math.max(startcol - 1),
                Math.min(startcol + k * loopcol - 2, blueCol.value - 1)
              ]
            }
          ]
        })
      }
    }

    // Red range line
    luckysheet.getSheet().config.borderInfo.push({
      rangeType: 'range',
      borderType: 'border-outside',
      style: 8,
      color: '#ff393c',
      range: [
        {
          row: [
            Math.max(0, startrow - 1),
            Math.min(startrow + loopmaxrow * looprow - 2, blueRow.value - 1)
          ],
          column: setForm.value.coldetailflg
            ? [startcol - 1, Math.min(startcol + loopmaxcol * loopcol - 2, blueCol.value - 1)]
            : [0, blueCol.value - 1]
        }
      ]
    })

    if (props.yosikikbn === Enum様式種別詳細.クロス集計 && loopmaxrow > 0 && loopmaxcol > 0) {
      luckysheet.getSheet().config.borderInfo.push({
        rangeType: 'range',
        borderType: 'border-outside',
        style: 8,
        color: '#ff393c',
        range: [
          {
            row: [
              Math.max(0, startrow - 1 - props.tab3Ref.value.colCount),
              Math.min(startrow + loopmaxrow * looprow - 2, blueRow.value - 1)
            ],
            column: setForm.value.coldetailflg
              ? [
                  Math.max(0, startcol - 1 - props.tab3Ref.value.rowCount),
                  Math.min(startcol + loopmaxcol * loopcol - 2, blueCol.value - 1)
                ]
              : [0, blueCol.value - 1]
          }
        ]
      })
      luckysheet.getSheet().config.borderInfo.push({
        rangeType: 'range',
        borderType: 'border-outside',
        style: 8,
        color: '#ff393c',
        range: [
          {
            row: [
              Math.max(0, startrow - 1 - props.tab3Ref.value.colCount),
              Math.max(0, startrow - 2)
            ],
            column: setForm.value.coldetailflg
              ? [
                  Math.max(0, startcol - 1 - props.tab3Ref.value.rowCount),
                  Math.min(startcol - 2, blueCol.value - 1)
                ]
              : [0, blueCol.value - 1]
          }
        ]
      })
    }
  }

  // Blue range line
  luckysheet.getSheet().config.borderInfo.push({
    rangeType: 'range',
    borderType: 'border-outside',
    style: 8,
    color: '#0000d0',
    range: [
      {
        row: [0, Math.max(blueRow.value - 1, maxRow.value - 1)],
        column: [0, Math.max(blueCol.value - 1, maxCol.value - 1)]
      }
    ]
  })
  if (rowcolCanchange.value && props.yosikikbn !== Enum様式種別詳細.クロス集計) {
    // setForm.value.loopmaxrow = Math.max(blueRow.value, maxRow.value)
    setForm.value.loopmaxrow = setForm.value.loopmaxcol = 1
  }
  luckysheet.refresh()
}

//テンプレート変更からアップデート情報作成
async function changExcel() {
  if (luckysheet.getluckysheetfile() && jsonData.value.sheets) {
    setForm.value.celldatas = await getCellDatas()

    setForm.value.endrow = blueRow.value
    setForm.value.endcol = blueCol.value

    EUCStore.setExcel(fileList.value[0])
    return Promise.resolve()
  }
}

//項目略称行列
async function getCellDatas() {
  if (luckysheet.getluckysheetfile() == null) return []
  const array = luckysheet.getAllSheets().map((sheet) => {
    return sheet.celldata
      .map((el) => {
        const val = luckysheet.getCellValue(el.r, el.c, { order: sheet.order })
        if (val) {
          return { rowindex: el.r, columnindex: el.c, value: val }
        }
        return []
      })
      .flat()
  })
  await new Promise((resolve) => setTimeout(resolve, 0))
  return array
}
//特殊項目リスト
function fixSpecProjectList(specialItems: string[], specParams: SpecParams) {
  // 削除
  const removeItems = (items: string[], ...values: string[]) =>
    items.filter((item) => !values.includes(item))

  // 追加
  const addItemsIfNotExist = (items: string[], ...values: string[]) => {
    values.forEach((value) => {
      if (!items.includes(value)) {
        items.push(value)
      }
    })
    return items
  }

  // 更新
  const updateItems = (condition: boolean, items: string[], values: string[]) =>
    condition ? addItemsIfNotExist(items, ...values) : removeItems(items, ...values)

  // 判断条件
  const isTaiChou = +props.yosikisyubetu === Enum様式種別.台帳
  const meisaiflg = EUCStore['meisaiflg'] as boolean

  const suffix = '（和暦）'
  const bottomList =
    props.yosikikbn === Enum様式種別詳細.クロス集計
      ? ['発行日', '基準日'].filter((item) => specParams.bottomItemList.includes(item))
      : []
  const bottomItemListAdd = [...bottomList, ...bottomList.map((item) => item + suffix)]

  const updateConditions = [
    // {
    //   condition:
    //     specParams.koinnmflg && isTaiChou && props.yosikikbn === Enum様式種別詳細.クロス集計,
    //   values: ['問い合わせ先', '課名', '係名']
    // },
    {
      condition: props.yosikikbn === Enum様式種別詳細.クロス集計,
      values: ['代表者', '市町村コード', '自治体名', '県名', '市長']
    },
    {
      condition: specParams.koinpicflg && isTaiChou,
      values: ['公印']
    },
    {
      condition:
        (!rowcolCanchange.value && +props.yosikisyubetu === Enum様式種別.一覧表) ||
        (isTaiChou && meisaiflg && !rowcolCanchange.value),
      values: ['ページ番号', '総ページ数', 'データ件数', 'ページ番号/総ページ数']
    },
    {
      condition: true,
      values: bottomItemListAdd
    }
  ]
  // 検索以外条件
  specialItems = removeItems(specialItems, '発行日', '発行日（和暦）', '基準日', '基準日（和暦）')

  updateConditions.forEach(({ condition, values }) => {
    specialItems = updateItems(condition, specialItems, values)
  })

  return specialItems
}
emitter.once('rowOrColCount', (data) => {
  if (data.kbn === Enum集計区分.GroupBy縦) setForm.value.loopmaxrow = data.count
  if (data.kbn === Enum集計区分.GroupBy横) setForm.value.loopmaxcol = data.count
})

defineExpose({ changExcel, init, setForm, specProjectList, makprojectList })
</script>
<style lang="less" src="./index.less" scoped></style>
