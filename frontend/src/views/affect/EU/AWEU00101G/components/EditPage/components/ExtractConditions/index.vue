<template>
  <div>
    <a-button
      class="btn-round"
      type="primary"
      :disabled="!updflg"
      @click="() => ((editVisible = true), (isEdit = false))"
      >新規</a-button
    >
  </div>
  <div class="m-t-1">
    <div class="mb-2" :style="{ height: tableHeight }">
      <!--        :loading="tableLoading"-->
      <vxe-table
        height="100%"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => edit(row)"
      >
        <vxe-column field="jyokenlabel" title="条件名" width="200" sortable>
          <template #default="{ row }">
            <a @click="edit(row)">{{ row.jyokenlabel }}</a>
          </template>
        </vxe-column>
        <vxe-column field="jyokenkbn" title="条件区分" sortable></vxe-column>
        <vxe-column field="sql" title="条件" sortable :resizable="false"></vxe-column>
      </vxe-table>
    </div>
  </div>
  <!--    v-model:loading="loading"-->
  <SearchModal
    ref="searchModalRef"
    v-model:visible="editVisible"
    :groupid="groupid"
    title="その他条件"
    @get-table-data="getTableData"
  />
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { getHeight } from '@/utils/height'
import { FixedConditionVM } from '@/views/affect/EU/AWEU00101G/type'
import { SearchOtherConditionTab } from '@/views/affect/EU/AWEU00101G/service'
import { Search } from '@/views/affect/EU/AWEU00106D/service'

import SearchModal from '@/views/affect/EU/AWEU00106D/index.vue'
import { useRoute } from 'vue-router'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  groupid: string
}
const props = withDefaults(defineProps<Props>(), {})
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
//ローディング
const searchModalRef = ref<InstanceType<typeof SearchModal> | null>(null)
// const loading = ref(false)
// const tableLoading = ref(false)
const tableList = ref<FixedConditionVM[]>([])

//ビューモデル
const editVisible = ref(false)
const isEdit = ref(false)
//表の高さ
const tableHeight = computed(() => getHeight(330))

//権限フラグ
const route = useRoute()
const updflg = route.meta.updflg
//--------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  if (props.groupid) {
    getTableData()
  }
})

//検索処理
const getTableData = () => {
  // tableLoading.value = true
  SearchOtherConditionTab({ datasourceid: String(props.groupid), status: 'other' }).then((res) => {
    tableList.value = res.fixedconditionlist
  })
  // .finally(() => {
  //   tableLoading.value = false
  // })
}

//編集処理
const edit = (val: FixedConditionVM) => {
  // loading.value = true
  Search({ jyokenid: val.jyokenid, datasourceid: String(props.groupid) }).then((res) => {
    searchModalRef.value?.setEddit({
      ...res,
      jyokenid: val.jyokenid,
      sql: val.sql,
      jyokenkbn: String(res.jyokenkbn)
    })
    editVisible.value = true
    isEdit.value = true
  })
  // .finally(() => (loading.value = false))
}
</script>

<style scoped lang="less" src="./index.less"></style>
