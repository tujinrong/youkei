<template>
  <div>
    <a-button
      class="btn-round"
      type="primary"
      :disabled="!updflg"
      @click="() => ((editVisible = true), searchModalRef?.setEddit())"
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
        <vxe-column field="jyokenlabel" title="条件名" min-width="200" sortable>
          <template #default="{ row }">
            <a @click="edit(row)">{{ row.jyokenlabel }}</a>
          </template>
        </vxe-column>
        <vxe-column field="sql" title="SQL条件" min-width="1160" sortable></vxe-column>
        <vxe-column
          field="control"
          title="コントロール"
          min-width="200"
          sortable
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>
    </div>
  </div>
  <!--    v-model:loading="loading"-->
  <SearchModal
    ref="searchModalRef"
    v-model:visible="editVisible"
    :groupid="groupid"
    @get-table-data="getTableData"
  />
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//項目一覧
//---------------------------------------------------------------------------
import { ref, onMounted, computed } from 'vue'
import { getHeight } from '@/utils/height'
import { SearchConditionTab } from '@/views/affect/EU/AWEU00101G/service'
import { ConditionVM } from '@/views/affect/EU/AWEU00101G/type'
import { Search } from '@/views/affect/EU/AWEU00105D/service'
import { Init } from '@/views/affect/EU/AWEU00105D/service'
import { MasterVM } from '@/views/affect/EU/AWEU00105D/type'

import SearchModal from '@/views/affect/EU/AWEU00105D/index.vue'
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
// const loading = ref(false)
// const tableLoading = ref(false)
//テンプレート参照
//ビューモデル
const editVisible = ref(false)

const tableList = ref<ConditionVM[]>([])
const searchModalRef = ref<InstanceType<typeof SearchModal> | null>(null)
const masterlist = ref<MasterVM[]>([])
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
    Init({ datasourceid: String(props.groupid) }).then((res) => {
      masterlist.value = res.masterlist ?? []
    })
  }
})
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------

//検索処理
const getTableData = () => {
  // tableLoading.value = true
  SearchConditionTab({ datasourceid: String(props.groupid) }).then((res) => {
    tableList.value = res.conditionlist
  })
  // .finally(() => {
  //   tableLoading.value = false
  // })
}

//編集処理
const edit = (val: ConditionVM) => {
  // loading.value = true
  Search({ jyokenid: +val.jyokenid, datasourceid: String(props.groupid) }).then((res) => {
    const list = masterlist.value.find((item) => item.mastercd === res.mastercd)?.cdlist ?? []
    const masterparaList = res.masterpara?.split(',') ?? []
    const data = {}
    list.forEach((item, index) => (data[item.columnnm] = masterparaList[index]))

    searchModalRef.value?.setEddit({
      ...res,
      jyokenid: val.jyokenid,
      sql: val.sql,
      controlkbn: String(res.controlkbn),
      ...data
    })
  })
  // .finally(() => (loading.value = false))

  editVisible.value = true
}
</script>

<style scoped lang="less" src="./index.less"></style>
