<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 受診拒否設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.07
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    title="受診拒否理由"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
  >
    <CloseModalBtn @click="closeModal" />

    <vxe-table
      :height="400"
      :loading="loading"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="jigyonm" title="検診種別"> </vxe-column>
      <vxe-column
        field="kyohiriyucdnm"
        title="受診拒否理由"
        header-class-name="bg-editable"
        :edit-render="{ autoselect: true }"
        class-name="right-col"
      >
        <template #default="{ row }">
          <ai-select
            v-model:value="row.kyohiriyucdnm"
            :options="selectorlist"
            :get-popup-container="null"
          ></ai-select>
        </template>
      </vxe-column>
    </vxe-table>

    <template #footer>
      <a-button
        style="float: left"
        type="warn"
        :disabled="loading || !route.meta.updflg"
        @click="handleOk"
        >登録</a-button
      >
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, ref, watch } from 'vue'
import { Save, Init } from './service'
import { message } from 'ant-design-vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { InitRowVM } from './type'
import { useRoute } from 'vue-router'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits(['finish', 'update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const editJudge = new Judgement()
const params = {
  nendo: Number(route.query.nendo),
  atenano: route.query.atenano as string
}
const tableData = ref<InitRowVM[]>([])
const selectorlist = ref<DaSelectorModel[]>([])
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (visible) => {
    tableData.value = []
    if (visible) {
      loading.value = true
      try {
        const res = await Init(params)
        selectorlist.value = res.selectorlist
        tableData.value = res.kekkalist
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
const handleOk = () => {
  showSaveModal({
    onOk: async () => {
      try {
        await Save({ ...params, kekkalist: tableData.value.filter((el) => el.kyohiriyucdnm) })
        editJudge.reset()
        message.success(SAVE_OK_INFO.Msg)
        emit('finish')
        closeModal()
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
:deep(.right-col .vxe-cell) {
  padding: 0 2px;
}
</style>
