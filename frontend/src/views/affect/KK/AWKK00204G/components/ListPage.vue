<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 地区保守(一覧画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.27
 * 作成者　　: 王
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="8" :xxl="6">
            <th style="width: 130px">地区区分</th>
            <td>
              <ai-select
                v-model:value="searchParams.tikukbn"
                :options="options"
                @change="onChangeOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th style="width: 130px">地区コード</th>
            <td>
              <ai-select
                v-model:value="searchParams.tiku"
                :options="keyoptions"
                @change="onChangeKeyOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th style="width: 130px">地区担当者</th>
            <td>
              <ai-select v-model:value="searchParams.staff" :options="selectorlist3"></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" @click="searchData">検索</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="resetFields">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="my-2">
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
        >
          <vxe-column field="tikukbnnm" title="地区区分"></vxe-column>

          <vxe-column field="tikucd" title="地区コード" width="150">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.tikucd }}</a>
            </template>
          </vxe-column>
          <vxe-column field="tikunm" title="地区名">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.tikunm }}</a>
            </template>
          </vxe-column>
          <vxe-column field="kanatikunm" title="地区名(カナ)"></vxe-column>
          <vxe-column field="staffnm" title="地区担当者"></vxe-column>
          <vxe-column field="stopflg" title="利用状態" width="100"></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { RowVM } from '../type'
import { PageSatatus } from '#/Enums'
import { InitList, SearchList } from '../service'
import { useLinkOption, useTableHeight, useSearch } from '@/utils/hooks'
import { OUTPUT_EXCEL_CONFIRM } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const createDefaultParams = () => {
  return {
    tikukbn: '',
    tiku: '',
    staff: ''
  }
}
const searchParams = reactive(createDefaultParams())
const selectorlist1 = ref<DaSelectorModel[]>([])
const selectorlist2 = ref<DaSelectorKeyModel[]>([])
const selectorlist3 = ref<DaSelectorModel[]>([])
const exceloutflg = ref(false)
const dataSource = ref<RowVM[]>([])
//Options連動
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(
  selectorlist2,
  selectorlist1
)

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: dataSource,
  params: toRef(() => searchParams)
})

//新规権限フラグ
const addFlg = route.meta.addflg

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
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
    selectorlist3.value = res.selectorlist3
    exceloutflg.value = res.exceloutflg
  })
})

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    searchData()
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
function forwardEdit(val: RowVM) {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      tikucd: val.tikucd,
      tikukbn: val.tikukbn
    }
  })
}

const resetFields = () => {
  Object.assign(searchParams, createDefaultParams())
  clear()
}
</script>

<style lang="less" scoped></style>
