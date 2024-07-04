<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between mb-1">
      <div class="text-lg font-bold">個人住民税税額控除情報</div>
      <a-space>
        <SimplePagination :current="current" :count="count" @change="changeCurrent" />
        <a-button type="primary" @click="visible = true">履歴照会</a-button>
      </a-space>
    </div>
    <div class="p-1">
      <div class="self_adaption_table">
        <Column :rows="row_kojo" :data="headerData" />
      </div>
    </div>
    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :page-size-options="$pagesizes"
      :total="totalCount"
      show-less-items
      show-size-changer
      class="text-end my-2"
      @change="searchJuminDetail(current)"
    />
    <vxe-table
      ref="xTableRef"
      :column-config="{ resizable: true }"
      :row-config="{ isHover: true }"
      :data="tableData"
      :sort-config="{ trigger: 'cell', remote: true }"
      :empty-render="{ name: 'NotData' }"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
    >
      <vxe-column
        field="kojonm"
        title="税額・税額控除"
        sortable
        :params="{ order: 1 }"
        min-width="140"
      ></vxe-column>
      <vxe-column
        field="tosi_gyoseikunm"
        title="指定都市_行政区等"
        sortable
        width="25%"
        min-width="160"
        :params="{ order: 2 }"
      ></vxe-column>
      <vxe-column
        field="kojokingaku"
        title="税額控除金額"
        sortable
        width="25%"
        min-width="130"
        formatter="localeNum"
        :params="{ order: 3 }"
      ></vxe-column>
    </vxe-table>
    <ResumeModal
      v-model:visible="visible"
      title="個人住民税税額控除情報履歷"
      :columns="columns_105"
      service="AWKK00105D"
      @select="selectRow"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { onMounted, reactive, ref, toRef, watch } from 'vue'
import Column from './Column.vue'
import SimplePagination from '@/components/Common/SimplePagination/index.vue'
import ResumeModal from '@/views/components/ResumeModal/index.vue'
import { columns as columns_105 } from '@/views/affect/KK/AWKK00105D/content'
import { SearchKojoDetail } from '../service'
import { useRoute } from 'vue-router'
import { KojoHeaderVM, KojoRowVM } from '../type'
import { row_kojo } from '../content'
import { changeTableSort } from '@/utils/util'
import { VxeTableInstance } from 'vxe-table'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const visible = ref(false)
const xTableRef = ref<VxeTableInstance>()
const headerData = ref<KojoHeaderVM | null>(null)
const tableData = ref<KojoRowVM[]>([])
const count = ref(0)
const current = ref(0)

const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const totalCount = ref(0)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchJuminDetail(1)
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => pageParams.orderby,
  () => {
    if (tableData.value.length > 0) searchJuminDetail(current.value)
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const searchJuminDetail = async (rirekinum: number) => {
  loading.value = true
  try {
    const res = await SearchKojoDetail({
      rirekinum,
      atenano: route.query.atenano as string,
      ...pageParams
    })
    headerData.value = res.detailheaderinfo
    tableData.value = res.kekkalist ?? []
    count.value = res.rirekitotal
    current.value = res.rirekinum
    totalCount.value = res.totalrowcount
  } catch (error) {}
  loading.value = false
}

function changeCurrent(val) {
  pageParams.pagenum = 1
  pageParams.orderby = 0
  xTableRef.value?.clearSort()

  current.value = val
  searchJuminDetail(current.value)
}

function selectRow(row) {
  changeCurrent(row.rirekinum)
}
</script>
