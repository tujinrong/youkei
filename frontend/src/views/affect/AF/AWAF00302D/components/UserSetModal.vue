<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.21
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    title="宛先設定"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />

    <vxe-table
      ref="xTableRef"
      height="400"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :row-config="{ keyField: 'userid', isHover: true }"
      :checkbox-config="{ checkRowKeys: selectedData, trigger: 'row' }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
      @checkbox-change="() => editJudge.setEdited()"
    >
      <vxe-column type="checkbox" width="50"></vxe-column>
      <vxe-column field="userid" title="ユーザーID"></vxe-column>
      <vxe-column field="usernm" title="ユーザー名"></vxe-column>
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
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'
import { UserVM } from '../type'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  selectedData: string[]
  userlist: UserVM[]
}>()
const emit = defineEmits(['update:visible', 'select'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<UserVM[]>([])

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
      tableData.value = props.userlist
      editJudge.reset()
    }
  }
)

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//登録ボタン(画面データの連動更新処理)
const onOk = () => {
  const records = xTableRef.value?.getCheckboxRecords() ?? []
  emit(
    'select',
    records.map((el) => el.userid)
  )
  modalVisible.value = false
}
//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}
</script>
