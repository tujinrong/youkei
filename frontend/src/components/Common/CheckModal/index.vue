<template>
  <a-modal
    v-model:visible="modalVisible"
    :footer="null"
    :closable="false"
    :mask-closable="false"
    :width="416"
    destroy-on-close
  >
    <div class="ant-modal-confirm-body-wrapper mx-2 mt-2">
      <div class="ant-modal-confirm-body">
        <span
          role="img"
          aria-label="question-circle"
          class="anticon anticon-question-circle"
          style="color: rgb(0, 176, 80)"
          ><QuestionCircleOutlined /></span
        ><span class="ant-modal-confirm-title">確認</span>
        <div class="ant-modal-confirm-content whitespace-pre">{{ C011004.Msg }}</div>
      </div>
      <div class="flex mt-6 gap-4 justify-center">
        <a-button type="warn" :loading="loading1" @click="clickOk1">待 機</a-button>
        <a-button type="warn" :loading="loading2" @click="clickOk2">続 行</a-button>
        <a-button @click="clickClose">キャンセル</a-button>
      </div>
    </div>
  </a-modal>
</template>

<script setup lang="ts">
import { C011004 } from '@/constants/msg'
import { computed, ref } from 'vue'
import { QuestionCircleOutlined } from '@ant-design/icons-vue'
import { cancelRequest } from '@/utils/http/common-service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  ok1: () => Promise<void>
  ok2: () => Promise<void>
}>()
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading1 = ref(false)
const loading2 = ref(false)
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

async function clickOk1() {
  loading1.value = true
  try {
    await props.ok1()
    modalVisible.value = false
  } catch (error) {}
  loading1.value = false
}
async function clickOk2() {
  loading2.value = true
  try {
    await props.ok2()
    modalVisible.value = false
  } catch (error) {}
  loading2.value = false
}

function clickClose() {
  modalVisible.value = false
  cancelRequest()
}
</script>
