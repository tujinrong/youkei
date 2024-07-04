<template>
  <a-card :bordered="false">
    <div class="self_adaption_table form">
      <a-row>
        <a-col :md="8" :xxl="6">
          <th style="width: 110px">業務</th>
          <td>
            <ai-select
              v-model:value="queryParam.gyomukbn"
              :options="businessOptions"
              style="width: 100%"
              allow-clear
            ></ai-select>
          </td>
        </a-col>
        <a-col :md="8" :xxl="6">
          <th style="width: 110px">帳票グループ</th>
          <td>
            <ai-select
              v-model:value="queryParam.rptgroupid"
              :options="sectionOptions"
              style="width: 100%"
              allow-clear
              split-val
            ></ai-select>
          </td>
        </a-col>
        <a-col :md="8" :xxl="6">
          <th style="width: 110px">帳票名</th>
          <td>
            <a-input v-model:value="queryParam.rptnm" style="width: 100%" />
          </td>
        </a-col>
      </a-row>
    </div>

    <div class="m-t-1 flex justify-between">
      <a-space>
        <a-button type="primary" @click="searchData">検索</a-button>
        <a-button type="primary" @click="reset">クリア</a-button>
      </a-space>
      <a-space class="">
        <close-page></close-page>
      </a-space>
    </div>
  </a-card>

  <a-card class="m-t-1">
    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :total="totalCount"
      :page-size-options="$pagesizes"
      show-less-items
      show-size-changer
      class="m-b-1 text-end"
    />
    <div class="mt-2" :style="{ height: tableHeight }">
      <vxe-table
        height="100%"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{
          trigger: 'cell',
          remote: true
        }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        @cell-dblclick="({ row }) => onExecute(row)"
      >
        <vxe-column field="rptid" :params="{ order: 1 }" title="帳票No" width="80" sortable>
          <template #default="{ row }">
            <a @click="onExecute(row)">{{ row.rptid }}</a>
          </template>
        </vxe-column>
        <vxe-column field="rptnm" :params="{ order: 2 }" title="帳票名" min-width="250" sortable>
          <template #default="{ row }">
            <a @click="onExecute(row)">{{ row.rptnm }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="rptgroupnm"
          :params="{ order: 3 }"
          title="帳票グループ"
          min-width="100"
          sortable
        >
        </vxe-column>
        <vxe-column
          field="rptbiko"
          :params="{ order: 4 }"
          title="帳票説明"
          min-width="350"
          sortable
        ></vxe-column>
        <vxe-column
          field="regusernm"
          :params="{ order: 5 }"
          title="作成者"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          field="regdttm"
          :params="{ order: 6 }"
          title="作成日時"
          min-width="210"
          sortable
          formatter="jpTime"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </div>
  </a-card>
</template>

<script setup lang="ts">
import { ref, onMounted, toRef, reactive, watch, computed } from 'vue'
import { useRouter } from 'vue-router'
import { SelectProps } from 'ant-design-vue'
import { getHeight } from '@/utils/height'
import { ReportVM, SearchRequest } from '../type'
import { Search, Init } from '../service'
import { changeTableSort } from '@/utils/util'
import { useSearch } from '@/utils/hooks'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
//ビューモデル
const tableList = ref<ReportVM[]>([])

const createDefaultParams = () => ({
  gyomukbn: '',
  rptgroupid: '',
  rptnm: ''
})
const queryParam = reactive<Omit<SearchRequest, keyof CmSearchRequestBase>>(createDefaultParams())
const businessOptions = ref<SelectProps['options']>([])
const sectionOptions = ref<SelectProps['options']>([])

//表の高さ
const tableHeight = computed(() => getHeight(240))

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableList,
  params: toRef(() => queryParam)
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => getInitData())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  Init().then((res) => {
    businessOptions.value = res.selectorlist1
    sectionOptions.value = res.selectorlist2
  })
}

//画面遷移
const onExecute = (val) => {
  router.push({
    path: 'AWEU00301G',
    query: {
      rptid: val.rptid,
      rptnm: val.rptnm
    }
  })
}

//クリア
function reset() {
  Object.assign(queryParam, createDefaultParams())
  clear()
}
</script>
