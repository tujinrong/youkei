<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ユーザー登録部署設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    title="ユーザー登録部署設定"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <div class="self_adaption_table m-b-2">
      <a-row>
        <a-col span="12">
          <th class="w-24">ユーザーID</th>
          <td>{{ userid }}</td>
        </a-col>
        <a-col span="12">
          <th class="w-24">ユーザー名</th>
          <td>{{ username }}</td>
        </a-col>
      </a-row>
    </div>
    <vxe-table
      ref="xTableRef"
      height="400"
      :column-config="{ resizable: true }"
      :row-config="{ keyField: 'sisyocd', isHover: true }"
      :checkbox-config="{ checkRowKeys: selectedData?.map((i) => i.sisyocd), trigger: 'row' }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
      @checkbox-change="() => editJudge.setEdited()"
    >
      <vxe-column type="checkbox" width="50"></vxe-column>
      <vxe-column field="sisyocd" title="支所コード"></vxe-column>
      <vxe-column field="sisyonm" title="支所名"></vxe-column>
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
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  userid: string
  username: string
  selectedData: CmSisyoVM[] | null
  sisyolist: CmSisyoVM[]
}>()
const emit = defineEmits(['update:visible', 'update:selectedData'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<CmSisyoVM[]>([])

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
      tableData.value = props.sisyolist
      editJudge.reset()
    }
  }
)

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//登録ボタン(画面データの連動更新処理)
const onOk = () => {
  emit('update:selectedData', xTableRef.value?.getCheckboxRecords())
  modalVisible.value = false
}
//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}
</script>
