<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>業務</th>
            <TD>{{ headerInfo?.gyomukbnnm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>コース番号</th>
            <TD>{{ route.query.courseno }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>コース名</th>
            <TD>{{ headerInfo?.coursenm }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex">
        <a-space>
          <a-button type="primary" @click="back2list">一覧へ</a-button>
          <a-button type="primary" :disabled="!canEdit || !editflg" @click="handelCopy"
            >１回目申込者コピー登録</a-button
          >
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="mt-2">
      <vxe-table
        ref="xTableRef"
        :height="Math.max(tableHeight, 400)"
        :column-config="{ resizable: true, useKey: true }"
        :row-config="{ isCurrent: true, isHover: true, keyField: 'kaisu', useKey: true }"
        :data="tableData"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goList3(row)"
      >
        <vxe-column field="kaisu" title="回数" min-width="100">
          <template #default="{ row }">
            <a @click="goList3(row)">{{ row.kaisu }}</a>
          </template>
        </vxe-column>
        <vxe-column field="jigyonm" title="事業名" min-width="100"></vxe-column>
        <vxe-column field="jissinaiyo" title="実施内容" min-width="100"></vxe-column>
        <vxe-column
          field="jissiyoteiymd"
          title="実施予定日"
          formatter="jpDate"
          min-width="100"
        ></vxe-column>
        <vxe-column field="tmf" title="開始時間" min-width="100"></vxe-column>
        <vxe-column field="tmt" title="終了時間" min-width="100"></vxe-column>
        <vxe-column field="kaijonm" title="会場" min-width="100"></vxe-column>
        <vxe-column field="kikannm" title="医療機関" min-width="100"></vxe-column>
        <vxe-column field="staffidnms" title="担当者" min-width="100"></vxe-column>
        <vxe-column
          field="status"
          title="状態"
          type="html"
          :formatter="formatExceedText"
          min-width="100"
        ></vxe-column>
        <vxe-column field="ninzu" title="申/定員" min-width="100"></vxe-column>
        <vxe-column field="taikinum" title="待機" min-width="100"></vxe-column>
      </vxe-table>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { useTableHeight } from '@/utils/hooks'
import { formatExceedText } from '@/utils/util'
import { computed, onMounted, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { InitDetailCourseList, Copy } from '../service'
import { CourseRowVM, CourseHeaderVM } from '../type'

enum PageStatus {
  List1 = 1,
  List2,
  List3
}
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(false)
const xTableRef = ref<VxeTableInstance>()

const tableData = ref<CourseRowVM[]>([])
const headerInfo = ref<CourseHeaderVM>()
const editflg = ref(true) //copy

//操作権限フラグ
const canEdit = computed(() => route.meta.addflg)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.courseno) {
    searchData()
  }
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 40)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitDetailCourseList({
      courseno: Number(route.query.courseno)
    })
    tableData.value = res.kekkalist
    headerInfo.value = res.headerinfo
    editflg.value = res.editflg
  } catch (error) {}
  loading.value = false
}

//コピー
async function handelCopy() {
  Copy({ courseno: Number(route.query.courseno) }).then(() => searchData())
}

//画面遷移
function goList3(record: CourseRowVM) {
  router.push({
    name: route.name as string,
    query: {
      nitteino: record.nitteino,
      courseno: route.query.courseno,
      kaisu: record.kaisu, //?
      status: PageStatus.List3
    }
  })
}
function back2list() {
  router.push({
    name: route.name as string
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
