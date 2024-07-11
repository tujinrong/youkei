<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 保健指導詳細検索設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.15
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="1000px"
    title="保健指導・集団指導項目詳細検索設定"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
  >
    <CloseModalBtn @click="closeModal" />

    <Table v-model:data="tableData" :loading="loading" :edit-judge="editJudge" />

    <template #footer>
      <a-button style="float: left" type="warn" @click="handleSortOk">登録</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { showSaveModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
import { computed, ref, watch } from 'vue'
import { Save, Search } from './service'
import { SearchVM } from '../AWKK00802D/type'
import Table from '../AWKK00802D/table.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref(false)
const editJudge = new Judgement()

const tableData = ref<SearchVM[]>([])
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    tableData.value = []
    if (newValue) {
      loading.value = true
      try {
        const res = await Search()
        tableData.value = res.kekkalist1
      } catch (error) {}
      loading.value = false
    }
  }
)
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
//メソッド
//--------------------------------------------------------------------------

//保存処理
const handleSortOk = () => {
  showSaveModal({
    onOk: async () => {
      try {
        await Save({ kekkalist: tableData.value })
        editJudge.reset()
        closeModal()
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {}
    }
  })
}
//取消処理
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 100px;
}
</style>
