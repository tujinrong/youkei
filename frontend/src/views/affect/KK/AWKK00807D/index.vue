<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 保健指導・集団指導項目並び順設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.24
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="700px"
    title="保健指導·集団指導項目"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
    centered
  >
    <CloseModalBtn @click="closeModal" />

    <div class="self_adaption_table mb-4">
      <a-row>
        <a-col span="8">
          <th>指導区分</th>
          <TD>{{ header?.sidokbnnm }}</TD>
        </a-col>
        <a-col span="8">
          <th>業務区分</th>
          <TD>{{ header?.gyomukbnnm }}</TD>
        </a-col>
        <a-col span="8">
          <th>申込結果</th>
          <TD>{{ header?.mosikomikekkakbnnm }}</TD>
        </a-col>
        <a-col v-if="params.sidokbn === Enum指導区分.集団指導" span="16">
          <th>項目用途区分</th>
          <TD>{{ header?.itemyotokbnnm }}</TD>
        </a-col>
      </a-row>
    </div>
    <h4 class="font-bold">保健指導・集団指導項目並び順設定</h4>
    <a-card
      size="small"
      title="保健指導・集団指導項目"
      :loading="loading"
      :body-style="{ height: '40vh', overflow: 'auto' }"
    >
      <draggable :list="sortData" item-key="itemcd" @end="editJudge.setEdited()">
        <template #item="{ element }: { element: SearchVM }">
          <div class="sort-item">
            {{ element.itemnm }}
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
import { SearchVM } from '../AWKK00805D/type'
import { SidoCommonHeaderVM, SidoCommonRequest } from '../AWKK00801G/type'
import { message } from 'ant-design-vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { Enum指導区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  params: SidoCommonRequest
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
  (e: 'afterSave'): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref(false)
const editJudge = new Judgement()
const header = ref<SidoCommonHeaderVM>()
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
      try {
        const res = await Search(props.params)
        sortData.value = res.kekkalist
        header.value = res.headerinfo
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
        await Save({ ...props.params, kekkalist: sortData.value })
        editJudge.reset()
        closeModal()
        message.success(SAVE_OK_INFO.Msg)
        emit('afterSave')
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
  min-height: 33px;
  display: flex;
  align-items: center;
}
.sort-item:hover {
  background: #f5f5f5;
}
.self_adaption_table th {
  width: 110px;
}
</style>
