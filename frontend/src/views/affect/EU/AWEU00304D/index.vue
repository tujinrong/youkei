<template>
  <a-modal
    :visible="props.visible"
    width="900px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    title="警告内容・帳票発行対象外者"
    @cancel="closeModal"
  >
    <a-card>
      <div>警告内容が登録されているが</div>
      <div>成人保健の帳票が発行対象外者です</div>
      <div>出力する場合は、チエックを入れてください。</div>
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :total="totalCount"
        :page-size-options="$pagesizes"
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        ref="tableRef"
        height="400px"
        :column-config="{ resizable: true }"
        :row-config="{ keyField: 'atenano', isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{
          trigger: 'cell',
          remote: true
        }"
        :empty-render="{ name: 'NotData' }"
        :checkbox-config="{ trigger: 'row', reserve: true, showHeader: false }"
        @checkbox-change="selectCheckbox"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      >
        <vxe-column type="checkbox" width="50" header-class-name="bg-editable"></vxe-column>
        <vxe-column
          field="atenano"
          :params="{ order: 1 }"
          title="宛名番号"
          width="180"
          sortable
        ></vxe-column>
        <vxe-column
          field="simei"
          :params="{ order: 2 }"
          title="氏名"
          width="180"
          sortable
          class-name="mincho"
          header-class-name="mincho"
        ></vxe-column>
        <vxe-column
          field="taisyogairiyu"
          :params="{ order: 3 }"
          title="帳票発行対象外者"
          width="150"
          min-width="90"
          sortable
        >
        </vxe-column>
        <vxe-column
          field="keikoku"
          :params="{ order: 4 }"
          title="警告内容"
          width="240"
          min-width="200"
          sortable
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>

    <template #footer>
      <a-button type="warn" style="float: left" :disabled="!isChecked" @click="onOk">確定</a-button>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, toRef, reactive, watch } from 'vue'
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'
import { changeTableSort } from '@/utils/util'
import { showConfirmModal } from '@/utils/modal'
import { WarningContentVM } from './type'
import { KensakuJyokenInitVM } from '../AWEU00301G/type'
import { SearchWarnings, UpdateWarningDetails, UpdateWarnCheckbox } from './service'
import DetailSearchDrawer from '@/views/affect/EU/AWEU00301G/components/DataDetail/components/DetailSearch.vue'
import { C002005 } from '@/constants/msg'
import { computed } from 'vue'
import { GlobalStore } from '@/store'

const props = defineProps<{
  visible: boolean
  rptid: string
  yosikiid: string
  kensakujyokenlist1: KensakuJyokenInitVM[]
  searchDrawerRef: InstanceType<typeof DetailSearchDrawer> | null
  workseq: number
  tyusyutuinfo: TyusyutuVM
}>()

const emit = defineEmits(['update:visible', 'getTableList'])
const editJudge = new Judgement()
const isChecked = computed(() => {
  return updItemList.value.length > 0
})

//ページャー
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const totalCount = ref(0)
//ビューモデル
const tableList = ref<WarningContentVM[]>([])
const tableRef = ref<VxeTableInstance>()

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (val) => {
    if (val) {
      getTableList()
    }
  }
)
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) getTableList()
})
//検索処理
const getTableList = async () => {
  const detailjyokenlist = await props.searchDrawerRef?.validateDrawer()

  SearchWarnings({
    ...pageParams,
    workseq: props.workseq,
    rptid: props.rptid,
    yosikiid: props.yosikiid,
    jyokenlist: props.kensakujyokenlist1,
    detailjyokenlist,
    tyusyutuinfo: props.tyusyutuinfo
  })
    .then((res) => {
      tableList.value = res.kekkalist
      totalCount.value = res.totalrowcount
      if (updItemList.value) {
        updItemList.value.forEach((item1) => {
          tableList.value.forEach((item2) => {
            //一致判断
            if (item1.atenano === item2.atenano) {
              item2.formflg = item1.formflg
            }
          })
        })
      }
      const $table = tableRef.value
      if ($table) {
        $table.setCheckboxRow(
          res.kekkalist.filter((el) => el.formflg),
          true
        )
      }
    })
    .finally(() => {})
}

//閉じるボタン(×を含む)
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    updateOrCancel('cancel')
  })
}
const onOk = async () => {
  showConfirmModal({
    content: C002005,
    async onOk() {
      updateOrCancel()
      editJudge.reset()
    }
  })
}
const updateOrCancel = (status = 'update') => {
  if (tableRef?.value) {
    UpdateWarningDetails({
      ...pageParams,
      workseq: props.workseq,
      warningContents: updItemList.value,
      status
    }).then((_) => {
      tableList.value = []
      totalCount.value = 0
      pageParams.pagenum = 1
      emit('update:visible', false)
      if (status === 'update') {
        emit('getTableList')
      }
      clearSelected()
    })
  }
}

//選択をキャンセル
const selectedRows = ref<WarningContentVM[]>([])
function clearSelected() {
  selectedRows.value = []
  updItemList.value = []
  const $table = tableRef.value
  $table?.clearCheckboxRow()
  $table?.clearCheckboxReserve()
  $table?.clearCurrentRow()
}
//行選択(更新/削除)
const updItemList = ref<WarningContentVM[]>([])
function selectCheckbox(data) {
  editJudge.setEdited()
  if (data.row) {
    UpdateWarnCheckbox({
      ...pageParams,
      workseq: props.workseq,
      status: 'insideUpdate',
      atenano: data.row.atenano,
      formflg: data.checked,
      formflgold: data.row.formflgold
    })

    const findItem = updItemList.value.find((item) => item.atenano === data.row.atenano)
    if (findItem) {
      findItem.formflg = data.checked
    } else {
      updItemList.value.push({ ...data.row, formflg: data.checked })
    }
  }

  const $table = tableRef.value
  if ($table) {
    const records = $table.getCheckboxRecords()
    const records2 = $table.getCheckboxReserveRecords()
    selectedRows.value = [...records, ...records2]
  }
}
</script>
<style scoped lang="less">
:deep(.vxe-header--column.group) {
  padding: 0 !important;
}
</style>
