<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者（担当者）保守(一覧画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.11
 * 作成者　　: 高智輝
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>{{ fieldMapping.staffid }}</th>
            <td>
              <ai-select
                v-model:value="searchParams.staffid"
                :options="staffidSelectorList"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>{{ fieldMapping.kikancd }}</th>
            <td>
              <ai-select
                v-model:value="searchParams.kikancd"
                :options="kikanSelectorList"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>{{ fieldMapping.syokusyu }}</th>
            <td>
              <ai-select
                v-model:value="searchParams.syokusyu"
                :options="syokusyunmSelectorList"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>{{ fieldMapping.katudokbn }}</th>
            <td>
              <ai-select
                v-model:value="searchParams.katudokbn"
                :options="katudokbnnmSelectorList"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>{{ fieldMapping.staffsimei }}</th>
            <td>
              <a-input v-model:value="searchParams.staffsimei" maxlength="100"></a-input>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>{{ fieldMapping.kanastaffsimei }}</th>
            <td>
              <a-input v-model:value="searchParams.kanastaffsimei" maxlength="100"></a-input>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="getTableList">検索</a-button>
          <a-button type="primary" :disabled="!exceloutflg" @click="handleExcel">
            EXCEL出力
          </a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <div>
        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="text-end"
        />
        <vxe-table
          class="mt-2"
          :height="tableHeight"
          :header-cell-style="{ backgroundColor: '#ffffe1' }"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="dataSource"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => forwardEdit(row)"
        >
          <vxe-column field="staffid" title="事業従業者ID">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.staffid }}</a>
            </template>
          </vxe-column>
          <vxe-column field="staffsimei" title="事業従事者氏名">
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.staffsimei }}</a>
            </template>
          </vxe-column>
          <vxe-column field="kanastaffsimei" title="事業従事者カナ氏名"></vxe-column>
          <vxe-column field="syokusyunm" title="職種"></vxe-column>
          <vxe-column field="katudokbnnm" title="活動区分"></vxe-column>
          <vxe-column field="stopflg" title="利用状態"></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { PageSatatus } from '#/Enums'
import { InitList, SearchList } from '../service'
import { C003003 } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { StaffRowVM } from '../type'
import { useSearch, useTableHeight } from '@/utils/hooks'
import { getSearchQuery, replaceText } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const fieldMapping = {
  staffid: '事業従事者',
  kikancd: '医療機関',
  syokusyu: '職種',
  katudokbn: '活動区分',
  staffsimei: '事業従事者氏名',
  kanastaffsimei: '事業従事者カナ氏名'
}

const createDefaultParams = () => {
  return {
    staffid: '',
    kikancd: '',
    syokusyu: '',
    katudokbn: '',
    staffsimei: '',
    kanastaffsimei: ''
  }
}
const searchParams = reactive(createDefaultParams())
const staffidSelectorList = ref<DaSelectorModel[]>([])
const kikanSelectorList = ref<DaSelectorModel[]>([])
const syokusyunmSelectorList = ref<DaSelectorModel[]>([])
const katudokbnnmSelectorList = ref<DaSelectorModel[]>([])
const dataSource = ref<StaffRowVM[]>([])

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: dataSource,
  params: toRef(() => searchParams),
  listname: 'kekkaList'
})

//権限フラグ
const exceloutflg = ref(false)
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
    staffidSelectorList.value = res.staffidSelectorList
    kikanSelectorList.value = res.kikanSelectorList
    syokusyunmSelectorList.value = res.syokusyunmSelectorList
    katudokbnnmSelectorList.value = res.katudokbnnmSelectorList
    exceloutflg.value = res.exceloutflg
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
function forwardEdit(val: StaffRowVM) {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      staffid: val.staffid
    }
  })
}

//検索処理
async function getTableList() {
  const res = await searchData()
  //検索結果1件の場合、詳細画面へ遷移
  if (res.totalrowcount === 1 && res.totalpagecount === 1) {
    forwardEdit(res.kekkaList[0])
  }
}

function reset() {
  Object.assign(searchParams, createDefaultParams())
  clear()
}

function handleExcel() {
  showConfirmModal({
    content: C003003.Msg.replace('{0}', '帳票出力'),
    onOk: async () => {
      await router.push({ name: 'AWEU00301G' })
      router.push({
        name: 'AWEU00301G',
        query: {
          rptid: '0008',
          outerSearch: 'true',
          ...getSearchQuery(searchParams, fieldMapping)
        }
      })
    }
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 150px;
}
</style>
