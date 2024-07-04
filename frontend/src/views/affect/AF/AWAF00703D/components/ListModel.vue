<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 詳細条件検索(一覧選択)
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
    <a-row>
      <a-col :span="6">
        <a-radio-group v-model:value="curCond">
          <a-radio class="radioOption" :value="false">条件なし</a-radio>
          <a-radio class="radioOption" :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-button class="m-t-2" :disabled="!curCond" type="primary" @click="onCheckAll(true)"
          >全選択</a-button
        >
        <a-button class="m-t-1" :disabled="!curCond" type="primary" @click="onCheckAll(false)"
          >全解除</a-button
        >
      </a-col>
      <a-col :span="18">
        <a-select
          :value="null"
          show-search
          style="width: 100%"
          class="m-b-1"
          :disabled="!curCond"
          :filter-option="filterOption"
          :options="options"
          @change="selectSearchOption"
        >
          <template #placeholder><search-outlined /> 検索</template>
          <template #option="{ value, label }">
            <span>{{ value + ' : ' + label }}&nbsp;&nbsp;</span>
            <check-outlined v-if="curVal.includes(value)" class="c-blue" />
          </template>
        </a-select>
        <a-form-item :name="name" :rules="rule">
          <a-card style="overflow: auto; height: 200px">
            <a-checkbox-group
              v-model:value="curVal"
              :disabled="!curCond"
              :options="
                options.map((item) => ({ value: item.value, label: item.value + ':' + item.label }))
              "
            />
          </a-card>
        </a-form-item>
      </a-col>
    </a-row>
  </a-collapse-panel>
</template>

<script setup lang="ts">
import { ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { computed, nextTick } from 'vue'
import { SearchOutlined, CheckOutlined } from '@ant-design/icons-vue'
import { filterOption } from '@/utils/util'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  name: string
  title: string
  condition: boolean
  options: DaSelectorModel[]
  value: string[]
}>()
const emit = defineEmits(['update:value', 'update:condition', 'validate'])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    return props.value || []
  },
  set(v) {
    emit('update:value', v)
  }
})
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
      required: props.condition,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', props.title),
      trigger: ['change']
    }
  ]
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//チェック処理：最低１つを選択
function onCheckAll(bool) {
  const arr = props.options.map((item) => item.value)
  emit('update:value', bool ? arr : [])
  emit('validate', props.name)
}

//選択処理
const selectSearchOption = (val) => {
  if (curVal.value.includes(val)) {
    curVal.value = curVal.value.filter((v) => v !== val)
  } else {
    curVal.value = [...curVal.value, val]
  }
  emit('validate', props.name)
}
</script>

<style lang="less" scoped>
.radioOption {
  height: 30px;
}
</style>
