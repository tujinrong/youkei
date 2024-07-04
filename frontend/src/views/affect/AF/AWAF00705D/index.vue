<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 個人検索
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.04.02
 * 作成者　　: 韋
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    title="個人検索"
    width="1400px"
    centered
    destroy-on-close
    class="vxe-table--ignore-clear"
  >
    <div class="self_adaption_table form">
      <a-row>
        <a-col :md="12" :lg="8">
          <th>氏名</th>
          <td>
            <a-input v-model:value="searchParams.name" />
          </td>
        </a-col>
        <a-col :md="12" :lg="10">
          <th>カナ氏名</th>
          <td>
            <a-input v-model:value="searchParams.kname" />
          </td>
        </a-col>
        <a-col :md="12" :lg="6">
          <th>生年月日</th>
          <td>
            <DateJp
              v-model:value="searchParams.bymd"
              unknown
              style="width: 190px"
              format="YYYY-MM-DD"
              @emit-unknown-date="(v) => (searchParams.bymd = v)"
            />
          </td>
        </a-col>
        <a-col :md="12" :lg="8">
          <th>性別</th>
          <td>
            <a-select
              v-model:value="searchParams.sex"
              mode="multiple"
              style="width: 100%"
              :options="options1"
            ></a-select>
          </td>
        </a-col>
        <a-col :md="12" :lg="10">
          <th>住民区分</th>
          <td>
            <a-select
              v-model:value="searchParams.juminkbn"
              mode="multiple"
              style="width: 100%"
              :options="options2"
            ></a-select>
          </td>
        </a-col>
        <a-col :md="12" :lg="6">
          <th>保険区分</th>
          <td>
            <ai-select
              v-model:value="searchParams.hokenkbn"
              :options="options3"
              split-val
            ></ai-select>
          </td>
        </a-col>
      </a-row>
    </div>

    <div class="my-2 flex justify-between">
      <a-space>
        <a-button type="primary" @click="searchData">検索</a-button>
        <a-button type="primary" @click="reset">クリア</a-button>
      </a-space>
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :total="totalCount"
        :page-size-options="$pagesizes"
        show-less-items
        show-size-changer
      />
    </div>
    <vxe-table
      ref="xTableRef"
      height="600"
      :loading="loading"
      :column-config="{ resizable: true }"
      :row-config="{ keyField: 'atenano', isCurrent: true, isHover: true }"
      :data="tableData"
      :sort-config="{
        trigger: 'cell',
        remote: true
      }"
      :empty-render="{ name: 'NotData' }"
      @cell-dblclick="selectItem"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
    >
      <vxe-column
        field="atenano"
        :params="{ order: 1 }"
        title="宛名番号"
        sortable
        width="150"
        min-width="100"
      >
      </vxe-column>
      <vxe-column
        field="name"
        :params="{ order: 2 }"
        title="氏名"
        sortable
        min-width="70"
      ></vxe-column>
      <vxe-column
        field="kname"
        :params="{ order: 3 }"
        title="カナ氏名"
        sortable
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="sex"
        :params="{ order: 4 }"
        title="性別"
        sortable
        width="120"
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="bymd"
        :params="{ order: 5 }"
        title="生年月日"
        sortable
        width="160"
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="adrs"
        :params="{ order: 6 }"
        title="住所"
        sortable
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="gyoseiku"
        :params="{ order: 7 }"
        title="行政区"
        sortable
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="juminkbn"
        :params="{ order: 8 }"
        title="住民区分"
        sortable
        width="120"
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="hokenkbn"
        :params="{ order: 9 }"
        title="保険区分"
        sortable
        width="120"
        min-width="100"
      ></vxe-column>
      <vxe-column
        field="keikoku"
        :params="{ order: 10 }"
        title="警告内容"
        sortable
        width="120"
        min-width="100"
      ></vxe-column>
    </vxe-table>
    <template #footer>
      <div class="float-left">
        <a-button type="primary" :disabled="!selectedRow" @click="selectItem">選択</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { changeTableSort } from '@/utils/util'
import { computed, reactive, ref, toRef, watch, watchEffect } from 'vue'
import { VxeTableInstance } from 'vxe-table'
import { Init, Search } from './service'
import { SearchVM } from './type'
import { useSearch } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
  (e: 'select', value: SearchVM): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
//画面区分
const options1 = ref<DaSelectorModel[]>([])
const options2 = ref<DaSelectorModel[]>([])
const options3 = ref<DaSelectorModel[]>([])

const searchParams = reactive(createDefaultParams())
function createDefaultParams() {
  return {
    name: '',
    kname: '',
    bymd: '',
    sex: [],
    juminkbn: [] as string[],
    hokenkbn: ''
  }
}
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchVM[]>([])
const selectedRow = ref<SearchVM | null>(null)

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams)
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (val) => {
    if (val && options1.value.length === 0) {
      const res = await Init()
      searchParams.juminkbn = res.juminkbns
      options1.value = res.sexlist
      options2.value = res.juminkbnlist
      options3.value = res.hokenkbnlist
    }
  }
)
watchEffect(() => {
  selectedRow.value = xTableRef.value?.getCurrentRecord()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//キー項目選択
const selectItem = () => {
  setTimeout(() => {
    if (selectedRow.value) {
      emit('select', selectedRow.value)
      closeModal()
    }
  }, 0)
}

//クリア
const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  clear()
}

//閉じるボタン(×を含む)
const closeModal = () => {
  modalVisible.value = false
}
</script>
<style lang="less" scoped>
.self_adaption_table.form th {
  width: 93px;
}
</style>
