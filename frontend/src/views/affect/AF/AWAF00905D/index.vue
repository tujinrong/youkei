<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 所属グループユーザー設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    centered
    width="1150px"
    title="所属グループユーザー設定"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
    @ok="onOk"
  >
    <CloseModalBtn @click="closeModal" />
    <div class="self_adaption_table m-b-2">
      <a-row>
        <a-col span="24">
          <th class="w-60">所属グループ名</th>
          <td>{{ syozokunm }}</td>
        </a-col>
      </a-row>
    </div>
    <vxe-table
      ref="xTableRef"
      height="500"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :row-config="{ isHover: true }"
      :data="tableData"
      :sort-config="{ trigger: 'cell' }"
      :empty-render="{ name: 'NotData' }"
      :row-class-name="({ row }) => (!row.editflg ? 'bg-disabled' : '')"
      @cell-click="onClickCell"
    >
      <vxe-column field="userid" title="ユーザーID" min-width="120" sortable> </vxe-column>
      <vxe-column field="usernm" title="ユーザー名" min-width="120" sortable> </vxe-column>
      <vxe-column field="yukoymdf" title="有効年月日（開始）" min-width="160" sortable></vxe-column>
      <vxe-column field="yukoymdt" title="有効年月日（終了）" min-width="160" sortable></vxe-column>
      <vxe-column field="status" title="状態" min-width="70" width="100" sortable></vxe-column>
      <vxe-column field="syozokunm" title="所属グループ" min-width="120" sortable>
        <template #default="{ row }: { row: VM }">
          <span>{{ row.setflg ? props.syozokunm : row.editflg ? '' : row.syozokunm }}</span>
        </template>
      </vxe-column>
      <vxe-column
        field="set"
        title="設定"
        header-class-name="bg-editable"
        min-width="70"
        :resizable="false"
      >
        <template #default="{ row }: { row: VM }">
          <a-checkbox
            v-model:checked="row.setflg"
            :disabled="!row.editflg"
            @change="() => editJudge.setEdited()"
          ></a-checkbox>
        </template>
      </vxe-column>
    </vxe-table>
    <template #footer>
      <div style="float: left">
        <a-button type="primary" @click="onOk">登録</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import { UserRowVM, UserDetailVM } from '../AWAF00901G/type'
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'

interface VM extends UserDetailVM {
  setflg: boolean
}
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  syozokunm: string
  selectedData: UserRowVM[]
  alluserData: UserDetailVM[]
}>()

const emit = defineEmits(['update:visible', 'update:selectedData'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tableData = ref<VM[]>([])
const xTableRef = ref<VxeTableInstance>()
const editJudge = new Judgement()

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
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (val) => {
    if (val) {
      tableData.value = props.alluserData.map((item) => {
        const setflg = props.selectedData.some((el) => el.userid === item.userid)
        return { ...item, setflg }
      })
      editJudge.reset()
    }
  }
)
//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//登録ボタン(画面データの連動更新処理)
function onOk() {
  emit(
    'update:selectedData',
    tableData.value.filter((item) => item.setflg).map((i) => ({ ...i, syozokunm: props.syozokunm }))
  )
  modalVisible.value = false
}
//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}
//行選択
function onClickCell({ row }) {
  if (row.editflg) row.setflg = !row.setflg
}
</script>

<style lang="less" scoped>
:deep(.vxe-header--gutter.col--gutter) {
  background-color: #ecf5ff;
}
</style>
