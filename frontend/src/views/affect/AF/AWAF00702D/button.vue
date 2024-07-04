<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 医療機関検索
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-button type="primary" shape="round" :disabled="disabled" @click="openModal"> 検索 </a-button>
  <Modal
    v-model:visible="visible"
    :jigyocds="jigyocds"
    :has-stop-flg="hasStopFlg"
    @select="onSelect"
  />
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { SearchVM } from './type'
import Modal from './index.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  /**実施事業 */
  jigyocds?: string
  /**使用停止sql */
  hasStopFlg?: boolean
  disabled?: boolean
}>()
const emit = defineEmits<{
  (e: 'select', value: SearchVM): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const visible = ref(false)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const openModal = () => {
  visible.value = true
}
const onSelect = (value) => {
  emit('select', value)
}
defineExpose({
  openModal
})
</script>
