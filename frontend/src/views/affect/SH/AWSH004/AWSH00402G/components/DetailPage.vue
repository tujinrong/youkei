<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健（検）診予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.21
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin v-show="!yoyakuno" :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="8">
            <th>年度</th>
            <TD>{{ yearFormatter(nendo) }}</TD>
          </a-col>
          <a-col span="8">
            <th>日程番号</th>
            <TD>{{ nitteino }}</TD>
          </a-col>
          <a-col span="8">
            <th>事業名</th>
            <TD>{{ headerInfo?.jigyonm }}</TD>
          </a-col>
          <a-col span="8">
            <th>実施予定日</th>
            <TD>{{ headerInfo?.yoteiymd ? getDateJpText(new Date(headerInfo.yoteiymd)) : '' }}</TD>
          </a-col>
          <a-col span="8">
            <th>開始時間</th>
            <TD>{{ headerInfo?.timef }}</TD>
          </a-col>
          <a-col span="8">
            <th>終了時間</th>
            <TD>{{ headerInfo?.timet }}</TD>
          </a-col>
          <a-col span="8">
            <th>会場</th>
            <TD>{{ headerInfo?.kaijonm }}</TD>
          </a-col>
          <a-col span="8">
            <th>医療機関</th>
            <TD>{{ headerInfo?.kikannm }}</TD>
          </a-col>
          <a-col span="8">
            <th>担当者一覧</th>
            <TD>{{ headerInfo?.staffnms }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="primary" :disabled="!addFlg" @click="visible = true">新規</a-button>
          <a-button type="primary" @click="back2list">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="my-2">
      <vxe-table
        :min-height="180"
        :data="tableData1"
        :show-header="false"
        :empty-render="{ name: 'NotData' }"
        :cell-class-name="setCellClassName"
      >
        <vxe-column v-for="item in columns1" :key="item.field" v-bind="item"></vxe-column>
      </vxe-table>

      <vxe-table
        class="mt-4"
        :data="kekkaList2"
        :height="Math.max(tableHeight, 300)"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goEdit(row)"
      >
        <vxe-column
          v-if="columns2.length > 0"
          field="yoyakuno"
          title="予約番号"
          width="100"
          fixed="left"
        >
          <template #default="{ row }">
            <a @click="goEdit(row)">{{ row.yoyakuno }}</a>
          </template>
        </vxe-column>
        <vxe-column
          v-for="item in columns2.slice(1)"
          :key="item.key"
          :field="item.key"
          :title="item.title"
          min-width="150"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </a-spin>
  <EditPage v-if="yoyakuno" @after-close="searchData" />
  <AtenanoModal v-model:visible="visible" @select="selectAtenano" />
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { useTableHeight } from '@/utils/hooks'
import { formatExceedText, yearFormatter } from '@/utils/util'
import { onMounted, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { InitDetailPersonList } from '../service'
import { HeaderVM, RowVM } from '../type'
import { getDateJpText } from '@/utils/util'
import { VxeColumnProps } from 'vxe-table'
import EditPage from './EditPage.vue'
import AtenanoModal from '@/views/affect/AF/AWAF00705D/index.vue'
import { message } from 'ant-design-vue'
import { E014004 } from '@/constants/msg'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const visible = ref(false)
const nendo = Number(route.query.nendo)
const nitteino = Number(route.query.nitteino)
const headerInfo = ref<HeaderVM | null>(null)

const kekkaList2 = ref<StrObj[]>([])
const columns2 = ref<ColumnInfoVM[]>([])
//操作権限フラグ
const addFlg = route.meta.addflg
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  searchData()
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -158)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitDetailPersonList({ nitteino, nendo })
    headerInfo.value = res.headerinfo
    //予約情報結果
    kekkaList1.value = res.kekkalist1
    reverseTable()
    //予約者情報結果
    columns2.value = res.columnInfos
    kekkaList2.value = res.kekkalist2.map((el) => {
      const data = {}
      el.forEach((i) => (data[i.key] = i.value))
      return data
    })
  } catch (error) {}
  loading.value = false
}

function back2list() {
  router.push({
    name: route.name as string
  })
}

function goEdit({ yoyakuno, atenano }) {
  router.push({
    name: route.name as string,
    query: { nitteino, nendo, yoyakuno, atenano }
  })
}

function selectAtenano(val) {
  let hasAtenano = false
  kekkaList2.value.forEach((el) => {
    if (el.atenano == val.atenano) {
      hasAtenano = true
    }
  })
  if (hasAtenano) {
    message.error(E014004.Msg.replace('{0}', '予約').replace('{1}', '新規登録'))
  } else {
    goEdit({ yoyakuno: -1, atenano: val.atenano })
  }
}

//予約情報Table-------------------------------------------------------------------------
const tableData1 = ref<StrObj[]>([])
const columns1 = ref<VxeColumnProps[]>([])
const kekkaList1 = ref<RowVM[]>([])
const fixColumns: { field: keyof RowVM; title: string }[] = [
  { field: 'title', title: '' },
  { field: 'status', title: '状態' },
  { field: 'teiin', title: '定員数' },
  { field: 'moshikominum', title: '申込人数' },
  { field: 'taikinum', title: '待機人数' }
]
function reverseTable() {
  const buildData = fixColumns.map((column) => {
    const item: StrObj = { col0: column.title }
    kekkaList1.value.forEach((row, index) => {
      item[`col${index + 1}`] = row[column.field]
    })
    return item
  })
  const buildColumns: VxeColumnProps[] = [
    { field: 'col0', fixed: 'left', width: 100 } //第一列
  ]
  kekkaList1.value.forEach((_item, index) => {
    buildColumns.push({
      field: `col${index + 1}`,
      minWidth: 100,
      type: 'html',
      formatter: formatExceedText
    })
  })
  columns1.value = buildColumns
  tableData1.value = buildData
}
function setCellClassName({ columnIndex, rowIndex }) {
  const cellclass: string[] = []
  if (columnIndex === 0) {
    cellclass.push('bg-readonly', 'br-grey')
  }
  if (rowIndex <= 1) {
    cellclass.push('bg-readonly', 'bb-grey')
  }
  return cellclass.join(' ')
}

//----------------------------------------------------------------------------

//詳細画面切り替え---------------------------------------------------------------------
const yoyakuno = ref('')
onMounted(() => {
  yoyakuno.value = route.query.yoyakuno as string
})
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWSH00402G') {
      yoyakuno.value = route.query.yoyakuno as string
    }
  },
  { deep: true }
)
//----------------------------------------------------------------------------
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 110px;
}
</style>
