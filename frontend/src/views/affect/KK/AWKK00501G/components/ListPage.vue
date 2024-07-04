<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業実施報告書（日報）管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="24" :xxl="12">
            <th>実施日時範囲</th>
            <td>
              <RangeDateStr v-model:value="searchParams.jissiymdtTime" />
            </td>
          </a-col>
          <a-col :span="12">
            <th>会場</th>
            <td>
              <ai-select v-model:value="searchParams.kaijo" :options="selectorlist1"></ai-select>
            </td>
          </a-col>
          <a-col :span="12">
            <th>事業</th>
            <td>
              <ai-select
                v-model:value="searchParams.jigyo"
                :options="options_jigyo"
                style="width: 100%"
              ></ai-select>
            </td>
          </a-col>
          <a-col :span="12">
            <th>従事者</th>
            <td>
              <ai-select
                v-model:value="searchParams.staff"
                :options="options_staff"
                style="width: 100%"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="getTableList">検索</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
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
          :sort-config="{ trigger: 'cell', remote: true }"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
          @cell-dblclick="({ row }) => forwardEdit(row)"
        >
          <vxe-column field="hokokusyono" title="事業報告書番号" :params="{ order: 1 }" sortable>
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.hokokusyono }}</a>
            </template>
          </vxe-column>
          <vxe-column field="jissiymd" title="実施日" :params="{ order: 2 }" sortable></vxe-column>
          <vxe-column field="jissitime" title="時間" :params="{ order: 3 }" sortable></vxe-column>
          <vxe-column field="kaijonm" title="会場" :params="{ order: 4 }" sortable></vxe-column>
          <vxe-column field="jigyonm" title="事業" :params="{ order: 5 }" sortable></vxe-column>
          <vxe-column field="staffnm" title="従事者" :params="{ order: 6 }" sortable></vxe-column>
          <vxe-column field="upddttm" title="更新日時" :params="{ order: 7 }" sortable></vxe-column>
          <vxe-column field="updusernm" title="更新者" :params="{ order: 8 }" sortable></vxe-column>
          <vxe-column
            field="regsisyo"
            title="登録支所"
            :params="{ order: 9 }"
            sortable
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, watch, reactive, toRef, watchEffect } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { RowVM, StaffJigyocdVM } from '../type'
import { PageSatatus } from '#/Enums'
import { SearchList } from '../service'
import RangeDateStr from '@/components/Selector/RangeDateStr/index.vue'
import { useSearch, useTableHeight } from '@/utils/hooks'
import { changeTableSort } from '@/utils/util'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  selectorlist1: DaSelectorModel[]
  selectorlist2: DaSelectorModel[]
  selectorlist3: StaffJigyocdVM[]
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const createDefaultParams = () => {
  return {
    // jissiymdttmf: '',
    // jissiymdttmt: '',
    jissiymdtTime: '',
    kaijo: '',
    jigyo: '',
    staff: ''
  }
}
const searchParams = reactive(createDefaultParams())
const dataSource = ref<RowVM[]>([])

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: dataSource,
  params: toRef(() => ({
    ...searchParams,
    jissiymdf: searchParams.jissiymdtTime.split(',')[0],
    jissiymdt: searchParams.jissiymdtTime.split(',')[1]
  }))
})

//新规権限フラグ
const addFlg = route.meta.addflg

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    getTableList()
  }
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

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
      hokokusyono: val.hokokusyono
    }
  })
}

//検索処理
const getTableList = () => {
  searchData().then((res) => {
    //検索結果1件の場合、詳細画面へ遷移
    if (res.totalrowcount === 1 && res.totalpagecount === 1) {
      forwardEdit(res.kekkalist[0])
    }
  })
}

const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  clear()
}

//Options連動--------------------------------------------------------------------------
const options_jigyo = ref<DaSelectorModel[]>([])
const options_staff = ref<StaffJigyocdVM[]>([])

watchEffect(() => {
  options_jigyo.value = props.selectorlist2 ?? []
  options_staff.value = props.selectorlist3 ?? []
})

// function onChangeJigyo(val, opt: DaSelectorModel) {
//   options_staff.value = val
//     ? props.selectorlist3.filter((i) => i.jigyocds.includes(opt.value))
//     : props.selectorlist3
// }

// function onChangeStaff(val, opt: StaffJigyocdVM) {
//   options_jigyo.value = val
//     ? props.selectorlist2.filter((i) => opt.jigyocds.includes(i.value))
//     : props.selectorlist2
// }
//--------------------------------------------------------------------------
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 120px;
}
</style>
