<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: メニュー並び順設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="500px"
    title="拡張事業メニュー並び順設定"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
    centered
  >
    <CloseModalBtn @click="closeModal" />

    <a-card
      size="small"
      title="受診情報管理"
      :loading="loading"
      :body-style="{ height: '40vh', overflow: 'auto' }"
    >
      <draggable :list="sortData" item-key="kinoid" @end="editJudge.setEdited()">
        <template #item="{ element }: { element: SearchVM }">
          <div class="sort-item">
            {{ element.hyojinm }}
          </div>
        </template>
      </draggable>
    </a-card>

    <template #footer>
      <a-button style="float: left" type="warn" @click="handleSortOk">登録</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, ref, watch } from 'vue'
import draggable from 'vuedraggable'
import { Save, Search } from './service'
import { SearchVM } from './type'
import { message } from 'ant-design-vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
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
const sortData = ref<SearchVM[]>([])

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (visible) => {
    sortData.value = []
    if (visible) {
      loading.value = true
      const res = await Search()
      sortData.value = res.kekkalist
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
        await Save({ kekkalist: sortData.value })
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
.sort-item {
  padding-left: 12px;
  width: 100%;
  height: 33px;
  display: flex;
  align-items: center;
}
.sort-item:hover {
  background: #f5f5f5;
}
</style>
