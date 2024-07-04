<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 成人健（検）診事業詳細検索設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.15
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="1000px"
    title="成人健（検）診項目詳細検索設定"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
  >
    <CloseModalBtn @click="closeModal" />

    <div class="self_adaption_table mb-4">
      <a-row>
        <a-col span="8">
          <th>検診種別コード</th>
          <TD>{{ props.jigyocd }}</TD>
        </a-col>
        <a-col span="10">
          <th>検診種別名</th>
          <TD>{{ header?.jigyonm }}</TD>
        </a-col>
        <a-col span="6">
          <th>略称</th>
          <TD>{{ header?.jigyoshortnm }}</TD>
        </a-col>
      </a-row>
    </div>

    <Table v-model:data="tableData" :loading="loading" :edit-judge="editJudge" />

    <template #footer>
      <a-button style="float: left" type="warn" @click="handleSortOk">登録</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import TD from '@/components/Common/TableTD/index.vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { showSaveModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
import { computed, ref, watch } from 'vue'
import { KensinCommonHeaderVM } from '../AWKK00801G/type'
import { Save, Search } from './service'
import { SearchVM } from './type'
import Table from './table.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  jigyocd: string
  visible: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref(false)
const header = ref<KensinCommonHeaderVM>()
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
        const res = await Search({ jigyocd: props.jigyocd })
        header.value = res.headerinfo
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
        await Save({
          kekkalist: tableData.value,
          jigyocd: props.jigyocd
        })
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
  width: 120px;
}
</style>
