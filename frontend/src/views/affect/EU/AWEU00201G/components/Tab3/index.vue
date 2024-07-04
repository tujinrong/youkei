<template>
  <div>
    <div v-if="isOneTable">
      <a-space>
        <a-button class="btn-round" type="primary" @click="handleAdd">項目追加</a-button>
        <a-button
          class="btn-round"
          type="primary"
          :disabled="yosikikbn == Enum様式種別詳細.単純集計表"
          @click="sortVisible = true"
          >並び替え</a-button
        >
        <a-button
          type="primary"
          danger
          :disabled="isDisabledDel"
          class="btn-round"
          @click="handleDel"
          >削除</a-button
        >
      </a-space>
      <!--      :loading="loading"-->
      <vxe-table
        ref="xTableRef"
        class="mt-2"
        :height="tableHeight"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true, keyField: 'yosikiitemid' }"
        :data="reportitemlist"
        :empty-render="{ name: 'NotData' }"
        :scroll-y="{ enabled: true, oSize: 10 }"
      >
        <vxe-column type="checkbox" width="50"></vxe-column>
        <vxe-column field="yosikiitemid" title="項目ID"></vxe-column>
        <vxe-column field="reportitemnm" title="項目名">
          <template #default="{ row }">
            <a @click="openModal1(false)">{{ row.reportitemnm }}</a>
          </template>
        </vxe-column>
        <vxe-column field="csvitemnm" title="CSV項目名称"></vxe-column>
        <vxe-column field="sqlcolumn" title="SQLカラム"></vxe-column>
        <vxe-column
          :visible="props.yosikikbn === Enum様式種別詳細.単純集計表"
          field="crosskbn"
          title="集計区分"
        >
          <template #default="{ row }">
            <span>{{ Enum集計区分2[`${row.crosskbn}`] }}</span>
          </template>
        </vxe-column>
        <vxe-column title="出力区分">
          <template #default="{ row }">
            <span>{{ getOutputKbn(row) }}</span>
          </template>
        </vxe-column>

        <vxe-column field="orderkbn" title="並び替え" formatter="sort"></vxe-column>
        <vxe-column field="sort" title="操作" width="200" :resizable="false">
          <template #default="{ row, rowIndex }">
            <a-button
              type="primary"
              :disabled="rowIndex === 0"
              @click="goUpOrDown(row, rowIndex, 'UP')"
            >
              <template #icon><ArrowUpOutlined /></template>
            </a-button>
            <a-button
              type="primary"
              :disabled="rowIndex === reportitemlist.length - 1"
              class="m-l-1"
              @click="goUpOrDown(row, rowIndex, 'DOWN')"
            >
              <template #icon><ArrowDownOutlined /></template>
            </a-button>
            <a-button type="primary" class="m-l-1" @click="openModal1(true)">
              <template #icon> <CopyOutlined /></template>
            </a-button>
          </template> </vxe-column
      ></vxe-table>
    </div>

    <div v-else>
      <a-space>
        <span class="font-bold text-lg">行</span>
        <a-button
          type="primary"
          :disabled="reportitemlist1.length > 2"
          @click="() => handleRowColValueAdd(1)"
          >項目追加</a-button
        >
      </a-space>
      <!--        :loading="loading"-->
      <vxe-table
        ref="xTableRef1"
        class="mt-2"
        :height="tableHeight / 3 - 30"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true, keyField: 'yosikiitemid' }"
        :data="reportitemlist1"
        :empty-render="{ name: 'NotData' }"
        :scroll-y="{ enabled: true, oSize: 10 }"
        @cell-click="tableNo = 1"
      >
        <vxe-column field="yosikiitemid" title="項目ID" min-width="200"></vxe-column>
        <vxe-column field="reportitemnm" title="項目名" min-width="200">
          <template #default="{ row }">
            <a @click="openModal2(1)">{{ row.reportitemnm }}</a>
          </template>
        </vxe-column>
        <vxe-column field="sqlcolumn" title="SQLカラム" min-width="400"></vxe-column>
        <vxe-column field="keyvaluepairsjson" title="コード・名称" min-width="300">
          <template #default="{ row }">
            <span>{{ getCodeName(row) }}</span>
          </template>
        </vxe-column>
        <vxe-column field="kbn1" title="小計" width="200" :resizable="false"
          ><template #default="{ row }">
            <span>{{ options.selectorlist5.find((item) => item.value == row.kbn1)?.label }}</span>
          </template></vxe-column
        >
      </vxe-table>

      <a-space class="mt-2">
        <span class="font-bold text-lg">列</span>
        <a-button
          type="primary"
          :disabled="reportitemlist2.length > 2"
          @click="() => handleRowColValueAdd(2)"
          >項目追加</a-button
        >
      </a-space>
      <!--              :loading="loading"-->
      <vxe-table
        ref="xTableRef2"
        class="mt-2"
        :height="tableHeight / 3 - 30"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true, keyField: 'yosikiitemid' }"
        :data="reportitemlist2"
        :empty-render="{ name: 'NotData' }"
        :scroll-y="{ enabled: true, oSize: 10 }"
        @cell-click="tableNo = 2"
      >
        <vxe-column field="yosikiitemid" title="項目ID" min-width="200"></vxe-column>
        <vxe-column field="reportitemnm" title="項目名" min-width="200">
          <template #default="{ row }">
            <a @click="openModal2(2)">{{ row.reportitemnm }}</a>
          </template>
        </vxe-column>
        <vxe-column field="sqlcolumn" title="SQLカラム" min-width="400"></vxe-column>
        <vxe-column field="keyvaluepairsjson" title="コード・名称" min-width="300">
          <template #default="{ row }">
            <span>{{ getCodeName(row) }}</span>
          </template>
        </vxe-column>
        <vxe-column field="kbn1" title="小計" width="200" :resizable="false"
          ><template #default="{ row }">
            <span>{{ options.selectorlist5.find((item) => item.value == row.kbn1)?.label }}</span>
          </template></vxe-column
        >
      </vxe-table>

      <a-space class="mt-2">
        <span class="font-bold text-lg">Σ値</span>
        <a-button
          type="primary"
          :disabled="reportitemlist3.length > 0"
          @click="() => handleRowColValueAdd(3)"
          >項目追加</a-button
        >
      </a-space>
      <!--        :loading="loading"-->
      <vxe-table
        ref="xTableRef3"
        class="mt-2"
        :height="tableHeight / 3 - 30"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="reportitemlist3"
        :empty-render="{ name: 'NotData' }"
        :scroll-y="{ enabled: true, oSize: 10 }"
        @cell-click="tableNo = 3"
      >
        <vxe-column field="yosikiitemid" title="項目ID" min-width="266"></vxe-column>
        <vxe-column field="reportitemnm" title="項目名" min-width="266">
          <template #default="{ row }">
            <a @click="openModal2(3)">{{ row.reportitemnm }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="sqlcolumn"
          title="SQLカラム"
          min-width="1033"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </div>

    <a-drawer
      v-model:visible="standardVisible"
      title="項目追加"
      placement="left"
      width="400px"
      :mask-closable="true"
      class="drawer_title_reverse"
      destroy-on-close
    >
      <a-spin :spinning="standarLoading">
        <a-button type="primary" class="btn-round mb-2" @click="addItem">追加</a-button>
        <a-tree v-model:checkedKeys="checkedKeys" checkable :tree-data="treeData"></a-tree>
      </a-spin>
    </a-drawer>

    <Modal1
      v-model:visible="visible1"
      v-model:table-list="reportitemlist"
      :table-index="currentIndex"
      :options="options"
      v-bind="{
        ...flags,
        yosikihouhou
      }"
      :yosikikbn="yosikikbn"
    />
    <Modal2
      ref="Modal2Ref"
      v-model:visible="visible2"
      v-model:table-list="lists[tableNo].value"
      :other-table-list="
        lists.filter((e, index) => index !== tableNo && index !== 0).flatMap((e) => e.value)
      "
      :table-index="currentIndex"
      :options="options"
      :datasourceid="props.rptdatasourceid || props.datasourceid"
      :itemids="itemids"
      :crosskbn="crossNo"
      :yosikihouhou="props.yosikihouhou"
      :masteropts="masterOpts"
      :tab1-ref="toRef(tab1Ref)"
      :tab2-ref="toRef(tab2Ref)"
    />

    <SortModal
      v-model:visible="sortVisible"
      :data="reportitemlist"
      :rptid="rptid"
      :yosikiid="yosikiid"
    ></SortModal>
  </div>
</template>

<script setup lang="ts">
import { toRef } from 'vue'
import {
  Enum様式種別詳細,
  Enum集計区分,
  Enum様式作成方法,
  Enum帳票様式,
  Enum並び替え,
  Enum編集区分
} from '#/Enums'
import { useRoute } from 'vue-router'
import { EUCStore } from '@/store'
import emitter from '@/utils/event-bus'
import { useTableHeight } from '@/utils/hooks'
import { ItemTreeNode } from '@/views/affect/EU/AWEU00107D/type'
import { SearchNormalTree, SearchStatisticTree } from '@/views/affect/EU/AWEU00204D/service'
import { ItemVM } from '@/views/affect/EU/AWEU00204D/type'
import { Init, InitMaster } from '@/views/affect/EU/AWEU00205D/service'
import { InitResponse, MasterVM } from '@/views/affect/EU/AWEU00205D/type'
import { TreeProps } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watchEffect, watch, Ref } from 'vue'
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'
import { SearchItemsTab } from '../../service'
import { ReportItemDetailVM, SortLineParam } from '../../type'
import Modal1 from './Modal1.vue'
import Modal2 from './Modal2.vue'
import SortModal from './SortModal.vue'
import { ArrowDownOutlined, ArrowUpOutlined, CopyOutlined } from '@ant-design/icons-vue'
import { SortSubVM } from '../../../AWEU00306D/type'
import { showDeleteModal, showInfoModal } from '@/utils/modal'
import { includes } from 'xe-utils'
const props = defineProps<{
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**様式枝番 */
  yosikieda: number
  /**データソースID */
  datasourceid: string
  /**帳票データソースID */
  rptdatasourceid: string
  /**様式種別詳細 */
  yosikikbn: Enum様式種別詳細
  /**様式作成方法 */
  yosikihouhou: Enum様式作成方法
  editJudge: Judgement
  kbn: Enum帳票様式 | string
  tab1Ref: Ref
  tab2Ref: Ref
}>()

/** GroupBy,集計 */
enum Enum集計区分2 {
  GroupBy = 1,
  集計 = 3
}
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const routes = useRoute()
const isNew = Boolean(routes.query.isNew)
// const loading = ref(false)

const flags = reactive<{
  excelflg: boolean
  otherflg: boolean
  pdfflg: boolean
  copyflg: boolean
}>({
  excelflg: true,
  otherflg: true,
  pdfflg: true,
  copyflg: false
})
const sortVisible = ref(false)
const visible1 = ref(false)
const visible2 = ref(false)
const sortDetailParam = ref<SortLineParam>({ sortptnno: 1, sortsublist: [] })
const reportitemlist = ref<ReportItemDetailVM[]>([])
const reportitemlist1 = ref<ReportItemDetailVM[]>([]) //行
const reportitemlist2 = ref<ReportItemDetailVM[]>([]) //列
const reportitemlist3 = ref<ReportItemDetailVM[]>([]) //Σ値
const Modal2Ref = ref<InstanceType<typeof Modal2> | null>(null)
const currentIndex = ref(-1)
const lists = reactive([reportitemlist, reportitemlist1, reportitemlist2, reportitemlist3])
const options = ref<Omit<InitResponse, keyof DaResponseBase>>({
  selectorlist1: [], // 集計区分
  selectorlist2: [], // 出力項目区分
  selectorlist3: [], // 並び替え
  selectorlist4: [], // コード区分
  selectorlist5: [] // 小計区分
})
const masterOpts = ref<MasterVM[]>([])
onMounted(async () => {
  Init().then((res) => (options.value = res))
  if (isNew) return
  nextTick(() => searchData())
})

onMounted(() => {
  emitter.once('itemlist', (data: ReportItemDetailVM[]) => {
    //出力区分初期値
    data.forEach((el) => {
      el.csvoutputflg = flags.otherflg
      el.reportoutputflg = flags.excelflg || flags.pdfflg
    })
    reportitemlist.value = data
  })
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//非クロス集計の場合
const isOneTable = computed(() => props.yosikikbn !== Enum様式種別詳細.クロス集計)
//集計区分
const crossNo = computed(() => {
  const list = [Enum集計区分.GroupBy縦, Enum集計区分.GroupBy横, Enum集計区分.集計]
  return list[tableNo.value - 1]
})

const { tableHeight } = useTableHeight(null, -180)
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  if (isOneTable.value) {
    EUCStore.setDefineItems(reportitemlist.value)
  } else {
    if (props.yosikikbn === Enum様式種別詳細.クロス集計) {
      EUCStore.setDefineItems(reportitemlist3.value)
      InitMaster().then((res) => {
        masterOpts.value = res.masterlist
      })
    } else {
      EUCStore.setDefineItems([
        ...reportitemlist1.value,
        ...reportitemlist2.value,
        ...reportitemlist3.value
      ])
    }
  }
})

watch(
  () => props.yosikihouhou,
  (newValue) => {
    if (newValue != null && !isNew) {
      searchData()
    }
  }
)

watch(reportitemlist, () => props.editJudge.setEdited(), { deep: true })

//出力区分初始值
watch(
  () => {
    if (props.tab2Ref.value) {
      const { excelflg, pdfflg, otherflg } = props.tab2Ref.value.getFieldsValue()
      return { excelflg, pdfflg, otherflg }
    }
    return {}
  },
  (newValues, oldValues) => {
    if (
      props.tab2Ref.value &&
      isOneTable.value &&
      ((newValues.excelflg || newValues.pdfflg) !== (oldValues.excelflg || oldValues.pdfflg) ||
        newValues.otherflg !== oldValues.otherflg)
    ) {
      const { excelflg, pdfflg, otherflg } = newValues
      flags.excelflg = excelflg
      flags.pdfflg = pdfflg
      flags.otherflg = otherflg
      reportitemlist.value.forEach((el) => {
        el.reportoutputflg = excelflg || pdfflg
        el.csvoutputflg = otherflg
      })
    }
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function searchData() {
  if (props.rptid) {
    const params = {
      rptid: props.rptid,
      yosikiid: props.yosikiid,
      yosikieda: props.yosikieda,
      kbn: Number(props.kbn),
      procnm: props.tab1Ref.value.getFieldsValue().procnm ?? '',
      sql: props.tab1Ref.value.getFieldsValue().sql ?? '',
      editkbn: Enum編集区分.変更,
      yosikihouhou: props.yosikihouhou
    }
    const res = await SearchItemsTab(params)
    if (isOneTable.value) {
      reportitemlist.value = res.reportitemlist
      sortDetailParam.value.sortsublist = res.reportitemlist
        .filter((el) => el.orderkbn !== Enum並び替え.無し)
        .sort((a, b) => Number(a.orderkbnseq) - Number(b.orderkbnseq))
        .map((el) => {
          return {
            reportitemid: el.yosikiitemid,
            descflg: el.orderkbn === Enum並び替え.降順,
            pageflg: false
          }
        })
    } else if (res.reportitemlist) {
      reportitemlist1.value = res.reportitemlist.filter(
        (el) => el.crosskbn === Enum集計区分.GroupBy縦
      )
      reportitemlist2.value = res.reportitemlist.filter(
        (el) => el.crosskbn == Enum集計区分.GroupBy横
      )
      reportitemlist3.value = res.reportitemlist.filter((el) => el.crosskbn == Enum集計区分.集計)
    }
    // loading.value = false
    nextTick(() => props.editJudge.reset())
  }
}

//項目追加処理---------------------------------------------------------------------------------------
const standarLoading = ref(false)
const standardVisible = ref(false)
const treeData = ref<ItemTreeNode<ItemVM>[]>([])
const checkedKeys = ref<string[]>([])
const tableNo = ref(0)
const itemids = ref<string[]>([])
const handleRowColValueAdd = (no: 1 | 2 | 3) => {
  currentIndex.value = -1
  visible2.value = true
  tableNo.value = no
}

const handleAdd = () => {
  if (props.yosikihouhou == Enum様式作成方法.SQL) {
    currentIndex.value = -1
    visible1.value = true
  } else {
    openStandard(0)
  }
}

const openStandard = async (no: number) => {
  tableNo.value = no
  standardVisible.value = true
  standarLoading.value = true
  treeData.value = []
  checkedKeys.value = []
  itemids.value = (
    isOneTable.value
      ? reportitemlist.value
      : [...reportitemlist1.value, ...reportitemlist2.value, ...reportitemlist3.value]
  ).map((el) => el.yosikiitemid)
  const { procnm, sql } = props.tab1Ref.value.getFieldsValue()
  if (procnm === 'ft_') {
    standarLoading.value = false
    return
  }
  try {
    const res = await ([
      Enum様式種別詳細.一覧表,
      Enum様式種別詳細.台帳,
      Enum様式種別詳細.経年表,
      // AIplus 2024-06-24 SHOU ADD Start
      Enum様式種別詳細.はがき,
      Enum様式種別詳細.アドレスシール,
      Enum様式種別詳細.バーコードシール,
      Enum様式種別詳細.宛名台帳
      // AIplus 2024-06-24 SHOU ADD End
    ].includes(props.yosikikbn)
      ? SearchNormalTree({
          datasourceid: props.rptdatasourceid || props.datasourceid,
          itemids: itemids.value,
          procnm: procnm,
          sql: sql
        })
      : SearchStatisticTree({
          datasourceid: props.rptdatasourceid || props.datasourceid,
          itemids: itemids.value,
          crosskbn: (tableNo.value as Enum集計区分) || undefined,
          procnm: procnm,
          sql: sql
        }))

    //集計区分初期値
    if (props.yosikikbn === Enum様式種別詳細.単純集計表) {
      res.itemtree.map((el) => {
        el.value.crosskbn = Enum集計区分.GroupBy縦
        el.value.reportitemnm =
          el.value.reportitemnm === '項目集計' ? 'Group項目' : el.value.reportitemnm
      })
    }
    treeData.value = handleStandard(res.itemtree) ?? []
  } catch (error) {}
  standarLoading.value = false
}

let key = 1
const handleStandard = (data: ItemTreeNode<ItemVM>[]) => {
  let treeData = [] as TreeProps['treeData']
  data.forEach((item) => {
    //出力flg初期値
    item.value.csvoutputflg = flags.otherflg
    item.value.reportoutputflg = flags.excelflg || flags.pdfflg

    let children: any[] = []
    if (item.children) {
      children = handleStandard(item.children)
    }

    treeData?.push({
      key: JSON.stringify({ ...item.value, key }),
      title: item.value.reportitemnm,
      children: children,
      disableCheckbox: !item.value.isleaf && item.children.length === 0
    })
    key += 1
  })
  return treeData as unknown as ItemTreeNode<ItemVM>[]
}

async function addItem() {
  const result = checkedKeys.value.map((item) => JSON.parse(item)).filter((item) => item.isleaf)
  lists[tableNo.value].value.push(...result)
  standardVisible.value = false
}
//--------------------------------------------------------------------------------------------------
//編集Modal
const xTableRef = ref<VxeTableInstance>()
const xTableRef1 = ref<VxeTableInstance>()
const xTableRef2 = ref<VxeTableInstance>()
const xTableRef3 = ref<VxeTableInstance>()
function openModal1(copyflg) {
  flags.copyflg = copyflg
  const $table = xTableRef.value
  if ($table) {
    setTimeout(() => {
      currentIndex.value = $table.getRowIndex($table.getCurrentRecord())
      visible1.value = true
    }, 0)
  }
}
function openModal2(no: 1 | 2 | 3) {
  const $table = no === 1 ? xTableRef1.value : no === 2 ? xTableRef2.value : xTableRef3.value
  if ($table) {
    setTimeout(() => {
      currentIndex.value = $table.getRowIndex($table.getCurrentRecord())
      visible2.value = true
    }, 0)
  }
}
//出力区分表示
function getOutputKbn(row) {
  if (row.reportoutputflg && !row.csvoutputflg) {
    return '帳票出力'
  } else if (!row.reportoutputflg && row.csvoutputflg) {
    return 'CSV出力'
  } else if (row.reportoutputflg && row.csvoutputflg) {
    return '帳票出力 / CSV出力'
  } else {
    return ''
  }
}

//コード・名称
function getCodeName(row) {
  if (row.keyvaluepairsjson && !row.mastercd) {
    return row.keyvaluepairsjson
  }
  if (row.mastercd) {
    const nm = masterOpts.value.find((el) => el.mastercd === row.mastercd)?.masterhyojinm
    const para = row.masterpara ? `(${row.masterpara?.replace(',', '-')})` : ''
    return nm + para
  }
  return ''
}

emitter.once('sortsublist', (data: SortSubVM[]) => {
  sortDetailParam.value.sortsublist = data
})

const getFieldsValue = () => {
  return {
    definitionValue: isOneTable.value
      ? reportitemlist.value
      : [...reportitemlist1.value, ...reportitemlist2.value, ...reportitemlist3.value]
  }
}

const rowCount = computed(() => reportitemlist1.value.length)
const colCount = computed(() => reportitemlist2.value.length)

//並び順
const goUpOrDown = (row, index: number, type: 'UP' | 'DOWN') => {
  const newArr = JSON.parse(JSON.stringify(reportitemlist.value))
  const targetIndex = type === 'UP' ? index - 1 : index + 1

  if (targetIndex < 0 || targetIndex >= newArr.length) {
    return
  }
  //交換
  ;[newArr[index], newArr[targetIndex]] = [newArr[targetIndex], newArr[index]]
  ;[newArr[index].orderseq, newArr[targetIndex].orderseq] = [
    newArr[targetIndex].orderseq,
    newArr[index].orderseq
  ]

  reportitemlist.value = newArr

  props.editJudge.setEdited()
  setTimeout(() => {
    xTableRef.value?.setCurrentRow(row)
  }, 0)
}

defineExpose({ getFieldsValue, rowCount, colCount })
const isDisabledDel = computed(() => {
  let params: any[] = []
  params = params.concat(xTableRef.value?.getCheckboxRecords())
  return params.length === 0
})

// 削除
const handleDel = async () => {
  if (reportitemlist.value.length > 0) {
    showDeleteModal({
      onOk() {
        if (xTableRef.value) {
          const xx = xTableRef.value.getCheckboxRecords().map((el) => el.yosikiitemid)
          reportitemlist.value = reportitemlist.value.filter(
            (item) => !xx.includes(item.yosikiitemid)
          )
        }
      }
    })
  }
}
</script>
