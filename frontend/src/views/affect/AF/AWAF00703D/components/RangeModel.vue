<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 詳細条件検索(通用項目：範囲)
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
          <RangeInput v-model:value="curVal" :disabled="!curCond" :placeholder="placeholder" />
        </template>
        <template v-if="type === Enum項目区分.数字">
          <RangeInputNumber
            v-model:value="curVal"
            :disabled="!curCond"
            :placeholder="placeholder"
          />
        </template>
        <template v-if="type === Enum項目区分.日付">
          <RangeDate v-model:value="curVal" :disabled="!curCond" :placeholder="placeholder" />
        </template>
        <template v-if="type === Enum項目区分.日付不明">
          <RangeDate
            v-model:value="curVal"
            :disabled="!curCond"
            unknown
            :placeholder="placeholder"
          />
        </template>
        <template v-if="type === Enum項目区分.日時">
          <RangeDateTime2
            v-model:value="curVal"
            :disabled="!curCond"
            class="flex-col items-start!"
          />
        </template>
      </a-form-item>
    </div>
  </a-collapse-panel>
</template>

<script setup lang="ts">
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { computed, nextTick } from 'vue'
import RangeInput from '@/components/Selector/RangeInput/index.vue'
import RangeInputNumber from '@/components/Selector/RangeInputNumber/index.vue'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import { Enum項目区分 } from '#/Enums'
import { ItemVM } from '../type'
import RangeDateTime2 from '@/components/Selector/RangeDateTime/index2.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  type: Enum項目区分
  name: string
  title: string
  placeholder: string
  condition: boolean
  value: ItemVM
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

const curVal = computed({
  get() {
    return props.value || { value1: null, value2: null }
  },
  set(v) {
    emit('update:value', v)
    nextTick(() => {
      emit('validate', props.name)
    })
  }
})
//チェック設定(文字型範囲チェックなし)
const rule = computed(() => {
  return [
    {
      validator: () => {
        if (!curCond.value) {
          return Promise.resolve()
        }
        //必須チェック
        if (
          !curVal.value.value1 &&
          curVal.value.value1 !== 0 &&
          !curVal.value.value2 &&
          curVal.value.value2 !== 0
        ) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', props.title))
        }
        return Promise.resolve()
      },
      trigger: []
    }
  ]
})
</script>
