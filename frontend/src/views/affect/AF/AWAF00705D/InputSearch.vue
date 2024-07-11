<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 個人検索Button
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-input-search
    :id="'event-tab-stop-' + Math.floor(Math.random() * 900000)"
    ref="inputSearchRef"
    v-model:value="curVal"
    :disabled="disabled"
    :maxlength="atenanoLength"
    style="width: 190px"
    v-bind="$attrs"
    @change="(e) => (curVal = replaceText(e.target.value, EnumRegex.半角数字))"
    @blur="$emit('blur')"
    @search="searchByEvent"
  >
    <template #enterButton>
      <a-button class="px-10px" :disabled="disabled"> <search-outlined /></a-button>
    </template>
  </a-input-search>
  <Modal v-model:visible="visible" @select="onSelect" />
</template>

<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'
import Modal from './index.vue'
import { SearchOutlined } from '@ant-design/icons-vue'
import { replaceText } from '@/utils/util'
import { EnumRegex } from '#/Enums'
import { ss } from '@/utils/storage'
import { ATENANO_LEN } from '@/constants/mutation-types'
import { useEventListener } from '@vueuse/core'
import { nextTick } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value?: string
  disabled?: boolean
}>()
const emit = defineEmits<{
  (e: 'update:value', value?: string): void
  (e: 'search', atenano: string): void
  (e: 'blur'): void
  (e: 'change', val): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const visible = ref(false)
const inputSearchRef = ref()
const atenanoLength = ss.get(ATENANO_LEN)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const inputDom = inputSearchRef.value.$el.querySelector('input')
  useEventListener(inputDom, 'blur', (e: FocusEvent) => {
    if (e.sourceCapabilities) {
      nextTick(() => {
        if (props.value) emit('search', props.value)
      })
    }
  })
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    return props.value
  },
  set(val) {
    emit('update:value', val)
    emit('change', val)
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//入力検索処理
async function searchByEvent(v, e) {
  if (e.type === 'keydown' && ['Enter', 'NumpadEnter'].includes(e.code)) {
    nextTick(() => {
      if (props.value) emit('search', props.value)
    })
  } else if (e.type === 'click') {
    visible.value = true
  }
}

const onSelect = (val) => {
  curVal.value = val.atenano
  emit('search', val.atenano)
}
</script>
