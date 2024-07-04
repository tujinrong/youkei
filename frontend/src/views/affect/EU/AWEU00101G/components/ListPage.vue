<template>
  <div>
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col v-bind="layout">
            <th>業務</th>
            <td>
              <ai-select
                v-model:value="searchParams.gyoumucd"
                :options="businessOptions"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>データソース名</th>
            <td>
              <a-input v-model:value="searchParams.datasourcenm" :maxlength="30"></a-input>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" @click="searchData">検索</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="openModal">新規</a-button>
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
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="dataSource"
          :sort-config="{ trigger: 'cell', remote: true }"
          :empty-render="{ name: 'NotData' }"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
          @cell-dblclick="({ row }) => openDetail(row)"
        >
          <vxe-column field="datasourceid" :params="{ order: 1 }" title="No" width="100" sortable>
            <template #default="{ row }">
              <a @click="openDetail(row)">{{ row.datasourceid }}</a>
            </template>
          </vxe-column>
          <vxe-column
            field="datasourcenm"
            :params="{ order: 2 }"
            title="データソース名"
            min-width="260"
            sortable
          >
            <template #default="{ row }">
              <a @click="openDetail(row)">{{ row.datasourcenm }}</a>
            </template>
          </vxe-column>

          <vxe-column field="gyoumu" :params="{ order: 3 }" title="業務" min-width="140" sortable>
          </vxe-column>

          <vxe-column
            field="maintablehyojinm"
            :params="{ order: 4 }"
            title="メインテーブル"
            min-width="400"
            sortable
          ></vxe-column>
          <vxe-column
            field="maintablenm"
            :params="{ order: 5 }"
            title="メインテーブル物理名"
            min-width="400"
            sortable
            :resizable="false"
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
    <add-modal ref="addModalRef" v-model:visible="addModalVisible" />
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { changeTableSort } from '@/utils/util'
import emitter from '@/utils/event-bus'
import { useSearch, useTableHeight } from '@/utils/hooks'
import { SearchRequest, SearchVM } from '../type'
import { Init, Search } from '../service'

import AddModal from '@/views/affect/EU/AWEU00102D/index.vue'

const layout = {
  md: 8,
  xxl: 6
}

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const emit = defineEmits(['handleUpdate'])

//テンプレート参照
const addModalRef = ref()
//ビューモデル
const addModalVisible = ref(false)

const createDefaultParams = () => ({
  gyoumucd: '',
  datasourcenm: ''
})

const searchParams = reactive<Omit<SearchRequest, keyof CmSearchRequestBase>>(createDefaultParams())
const businessOptions = ref<DaSelectorModel[]>([])
const dataSource = ref<SearchVM[]>([])
const addFlg = route.meta.addflg

//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: dataSource,
  params: toRef(() => searchParams)
})

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  Init().then((res) => {
    businessOptions.value = res.selectorlist
  })

  emitter.once('refreshEU101List', () => {
    searchData()
  })
})

onBeforeRouteUpdate((to, from) => {
  if (from.query.status) {
    searchData()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//画面遷移
const openDetail = (val: SearchVM) => {
  router.push({
    name: 'AWEU00101G',
    query: {
      datasourceid: val.datasourceid
    }
  })
}

//クリア
function reset() {
  Object.assign(searchParams, createDefaultParams())
  clear()
}

//新規modal表示
const openModal = () => {
  addModalVisible.value = true
}
</script>

<style lang="less" scoped>
th {
  width: 130px;
}
</style>
