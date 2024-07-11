<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: バッチスケジュール(一覧画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.22
 * 作成者　　: 千秋
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="tableLoading">
    <a-card :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th style="width: 130px">処理区分</th>
            <td>
              <ai-select v-model:value="searchParams.kbn" :options="syorikbnList"></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th style="width: 130px">業務区分</th>
            <td>
              <ai-select v-model:value="searchParams.gyomukbn" :options="gyomukbnList"></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th style="width: 130px">タスク</th>
            <td>
              <ai-select v-model:value="searchParams.tasknm" :options="tasknmList"></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th style="width: 130px">処理結果</th>
            <td>
              <ai-select
                v-model:value="searchParams.statuscd"
                :options="statusnmList"
                split-val
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" @click="getTableList">検索</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" :disabled="!batchtaskid" @click="batchExecute">実行</a-button>
          <a-button type="primary" @click="resetFields">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="my-2" :style="{ height: tableHeight }">
      <div>
        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="text-end mb-2"
        />
        <vxe-table
          :height="tableHeight"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="dataSource"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => forwardEdit(row)"
          @cell-click="clickRow"
        >
          <vxe-column field="taskid" title="タスクID" width="150">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.taskid }}</a>
            </template>
          </vxe-column>
          <vxe-column field="tasknm" title="タスク名" width="150">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.tasknm }}</a>
            </template>
          </vxe-column>
          <vxe-column field="syorikbn" title="処理区分" width="150"></vxe-column>
          <vxe-column field="gyomukbn" title="業務区分" width="130"></vxe-column>
          <vxe-column field="jikkohindo" title="頻度" width="100"></vxe-column>
          <vxe-column field="hindosyosai" title="頻度詳細" width="300"></vxe-column>
          <vxe-column field="jikaijikkodttmt" title="次回処理日時" width="210"></vxe-column>
          <vxe-column field="syoridttmt" title="処理日時（開始）" width="210"></vxe-column>
          <vxe-column field="statuscd" title="処理結果" width="100" min-width="100">
            <template #default="{ row }">
              <span :style="{ color: operationStatusMap[String(row.colorkbn)] }">{{
                row.statuscd
              }}</span>
            </template>
          </vxe-column>
          <vxe-column field="jotai" title="状態" width="100"></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { RowVM } from '../type'
import { PageSatatus } from '#/Enums'
import { InitList, SearchList, Execute } from '../service'
import { useTableHeight } from '@/utils/hooks'
import { showConfirmModal } from '@/utils/modal'
import { operationStatusMap } from '@/constants/constant'
import { C021002 } from '@/constants/msg'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tableLoading = ref(false)
//ページャー
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1
})
const createDefaultParams = () => {
  return {
    kbn: '',
    gyomukbn: '',
    tasknm: '',
    statuscd: ''
  }
}
const searchParams = reactive(createDefaultParams())
const syorikbnList = ref<DaSelectorModel[]>([])
const gyomukbnList = ref<DaSelectorModel[]>([])
const tasknmList = ref<DaSelectorModel[]>([])
const statusnmList = ref<DaSelectorModel[]>([])
const dataSource = ref<RowVM[]>([])
const batchtaskid = ref()
const batchjotai = ref()

//Options連動

//新规権限フラグ
const addFlg = route.meta.addflg

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (dataSource.value.length > 0 || totalCount.value > 0) getTableList()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitList().then((res) => {
    syorikbnList.value = res.selectorlist1
    gyomukbnList.value = res.selectorlist2
    tasknmList.value = res.selectorlist3
    statusnmList.value = res.selectorlist4
  })
})

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    getTableList()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function forwardNew() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.New
    }
  })
}
const batchExecute = () => {
  showConfirmModal({
    content: C021002,
    onOk: () => {
      Execute({
        taskid: batchtaskid.value
      }).then(() => {
        getTableList()
      })
    }
  })
}

function forwardEdit(val: RowVM) {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      taskid: val.taskid,
      tasknm: val.tasknm
    }
  })
}

//タスクIDを取得する。
const clickRow = ({ row }) => {
  batchtaskid.value = row.taskid
}

//検索処理
const getTableList = () => {
  tableLoading.value = true
  SearchList({ ...pageParams, ...searchParams })
    .then((res) => {
      totalCount.value = res.totalrowcount
      dataSource.value = res.kekkalist
    })
    .finally(() => {
      tableLoading.value = false
      batchtaskid.value = null
    })
}

const resetFields = () => {
  Object.assign(searchParams, createDefaultParams())
  dataSource.value = []
  totalCount.value = 0
  pageParams.pagenum = 1
  batchtaskid.value = null
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
