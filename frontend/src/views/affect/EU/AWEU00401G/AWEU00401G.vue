<template>
  <div>
    <a-card :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :xxl="6">
            <th>帳票グループ</th>
            <td>
              <ai-select
                v-model:value="searchParams.rptgroupid"
                :options="groupsOptions"
                style="width: 100%"
                allow-clear
                split-val
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" @click="searchData">検索</a-button>
          <a-button type="primary" :disabled="!canAdd" @click="handleAdd">新規</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="m-t-1">
      <div>
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
            :data="dataSource"
            :empty-render="{ name: 'NotData' }"
            @cell-dblclick="({ row }) => handleEddit(row)"
          >
            <vxe-column field="rptgroupnm" title="帳票グループ" width="300">
              <template #default="{ row }">
                <a @click="handleEddit(row)">{{ row.rptgroupnm }}</a>
              </template>
            </vxe-column>
            <vxe-colgroup title="共通バー" align="center">
              <vxe-column field="kojinrenrakusakicd" title="個人連絡先" min-width="150">
              </vxe-column>

              <vxe-column field="memocd" title="メモ情報" min-width="360"></vxe-column>

              <vxe-column
                field="electronfilecd"
                title="電子ファイル情報"
                min-width="360"
              ></vxe-column>
              <vxe-column
                field="followmanage"
                title="フォロー管理"
                min-width="360"
                :resizable="false"
              ></vxe-column>
            </vxe-colgroup>
          </vxe-table>
          <div style="clear: both"></div>
        </div>
      </div>
    </a-card>
    <AddModal
      v-model:visible="visible"
      :editkbn="editkbn"
      :row-detail="rowDetail"
      @get-table-list="searchData"
      @init-data="initData"
    ></AddModal>
  </div>
</template>

<script lang="ts" setup>
import { ref, reactive, toRef, onMounted, computed } from 'vue'
import { getHeight } from '@/utils/height'
import { Init, Search } from './service'
import { SearchVM } from './type'
import AddModal from '../AWEU00402D/index.vue'
import { useSearch } from '@/utils/hooks'
import { Enum編集区分 } from '#/Enums'
import { useRoute } from 'vue-router'

//ローディング
const dataSource = ref<SearchVM[]>([])
const searchParams = reactive<{ rptgroupid?: string }>({
  rptgroupid: ''
})

const visible = ref<boolean>(false)

const groupsOptions = ref<{ label: string; value: string }[]>([])
const rowDetail = ref<Partial<SearchVM>>({})
const editkbn = ref<Enum編集区分>(Enum編集区分.新規)
//表の高さ
const tableHeight = computed(() => getHeight(240))

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: dataSource,
  params: toRef(() => searchParams)
})

//操作権限フラグ
const route = useRoute()
const canAdd = route.meta.addflg

onMounted(() => {
  initData()
})

const initData = () => {
  //searchParams.rptgroupid = undefined
  Init().then((res) => {
    groupsOptions.value = res.groupList
  })
}

const handleAdd = () => {
  editkbn.value = Enum編集区分.新規
  rowDetail.value = {}
  visible.value = true
}

const handleEddit = (row) => {
  editkbn.value = Enum編集区分.変更
  rowDetail.value = row
  visible.value = true
}

//クリア
function reset() {
  searchParams.rptgroupid = undefined
  clear()
}
</script>

<style lang="less" scoped></style>
