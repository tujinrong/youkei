<template>
  <a-modal
    v-model:visible="modalVisible"
    width="660px"
    title="CSV出力"
    destroy-on-close
    :mask-closable="false"
    :closable="false"
  >
    <div>
      <a-checkbox v-model:checked="csvflgs.mainflg">メインログ</a-checkbox>
      <a-checkbox v-model:checked="csvflgs.tusinflg">通信</a-checkbox>
      <a-checkbox v-model:checked="csvflgs.batchflg">バッチ</a-checkbox>
      <a-checkbox v-model:checked="csvflgs.gaibuflg">連携</a-checkbox>
      <a-checkbox v-model:checked="csvflgs.dbflg"> DB操作</a-checkbox>
      <a-checkbox v-model:checked="csvflgs.columnflg">項目値変更</a-checkbox>
      <a-checkbox v-model:checked="csvflgs.atenaflg">宛名番号</a-checkbox>
    </div>
    <template #footer>
      <a-button type="primary" class="float-left" :loading="csvLoading" @click="handleCsvOut"
        >ダウンロード</a-button
      >
      <a-button type="primary" @click="cancelCsvOut">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, computed } from 'vue'
import { Output } from '../service'
import { ArEnumEncoding } from '#/Enums'
import { message } from 'ant-design-vue'
import { cancelRequest } from '@/utils/http/common-service'
import { DOWNLOAD_OK_INFO } from '@/constants/msg'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  searchParams: any
}>()
const emit = defineEmits(['update:visible'])

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const csvLoading = ref(false)
const csvflgs = reactive({
  mainflg: false,
  tusinflg: false,
  batchflg: false,
  gaibuflg: false,
  dbflg: false,
  columnflg: false,
  atenaflg: false
})

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
async function handleCsvOut() {
  csvLoading.value = true
  try {
    await Output({
      ...props.searchParams,
      ...csvflgs,
      csvencoding: ArEnumEncoding.UTF8
    })
    message.success(DOWNLOAD_OK_INFO.Msg)
  } catch (error) {}
  modalVisible.value = false
  csvLoading.value = false
}
function cancelCsvOut() {
  cancelRequest()
  modalVisible.value = false
  csvLoading.value = false
}
</script>

<style scoped></style>
