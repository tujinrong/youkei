<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 詳細条件検索(通用項目)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.05.10
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-collapse-panel :show-arrow="false">
    <template #header>
      <span>{{ title + (curCond ? '（条件あり）' : '') }}</span>
    </template>
    <div>
      <div class="flex justify-between">
        <a-radio-group v-model:value="curCond">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
      </div>
      <a-form-item :name="name" class="m-t-1 m-b-1" :rules="rule">
        <template v-if="type === Enum項目区分.文字">
          <a-textarea
            :value="value?.value1"
            :disabled="!curCond"
            :placeholder="placeholder"
            allow-clear
            :auto-size="{ minRows: 1 }"
            @input="(e) => emit('update:value', { value1: e.target.value })"
          />
        </template>
        <template v-if="type === Enum項目区分.数字">
          <a-input-number
            :value="value?.value1"
            :disabled="!curCond"
            :placeholder="placeholder"
            string-mode
            style="width: 100%"
            @change="(v) => emit('update:value', { value1: v })"
          />
        </template>
        <template v-if="type === Enum項目区分.日付">
          <date-jp
            :value="value?.value1"
            :disabled="!curCond"
            :placeholder="placeholder"
            style="width: 190px"
            @change="changeDate"
          />
        </template>
        <template v-if="type === Enum項目区分.日付不明">
          <date-jp
            :value="value?.value1"
            unknown
            :disabled="!curCond"
            :placeholder="placeholder"
            style="width: 190px"
            @change="changeDate"
            @emit-unknown-date="emitUnknownDate"
          />
        </template>
        <template v-if="type === Enum項目区分.日時">
          <DateTime
            :value="value?.value1"
            :disabled="!curCond"
            @change="(v) => emit('update:value', { value1: v })"
          />
        </template>
      </a-form-item>
    </div>
  </a-collapse-panel>
</template>

<script setup lang="ts">
import { Enum項目区分 } from '#/Enums'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { computed, nextTick } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import dayjs from 'dayjs'
import DateTime from '@/components/Selector/DateTime/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  type: Enum項目区分
  name: string
  title: string
  placeholder: string
  condition: boolean
  value?: { value1: any }
}>()
const emit = defineEmits(['update:value', 'update:condition', 'validate'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curCond = computed({
  get() {
    return props.condition
  },
  set(v) {
    emit('update:condition', v)
    nextTick(() => {
      emit('validate', props.name)
    })
  }
})
//必須チェック設定
const rule = computed(() => {
  return [
    {
      validator: (_, value) => {
        if (curCond.value && !value?.value1 && value?.value1 !== 0) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', props.title))
        }
        return Promise.resolve()
      },
      trigger: ['change']
    }
  ]
})
//日付の場合
function changeDate(v) {
  emit('update:value', { value1: v ? dayjs(v).format('YYYY-MM-DD') : '' })
  emit('validate', props.name)
}
//日付不明含むの場合
function emitUnknownDate(v) {
  if (props.value) {
    emit('update:value', { value1: v })
  }
}
</script>
