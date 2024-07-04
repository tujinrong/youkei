<script setup lang="ts" name="CheckSelector">
import { CheckboxValueType } from 'ant-design-vue/es/checkbox/interface'
import { reactive, ref, watch } from 'vue'
import { optionInter } from './type'
const props = defineProps({
  checkboxValueProp: {
    type: Array<CheckboxValueType>,
    required: true
  },
  optionsProp: {
    type: Array<optionInter>,
    default: []
  },
  isColumn: {
    type: Boolean,
    default: false
  },
  needAllCheck: {
    type: Boolean,
    default: false
  }
})

const emit = defineEmits(['update:checkbox-value-prop'])

const checkboxValue = ref<CheckboxValueType[]>([])
const labelForShow = ref<Array<string | number>>([])

const state = reactive({
  indeterminate: true,
  checkAll: false
})

// すべての選択肢の値の配列を取得する
const getAllValueArrow = () => {
  return props.optionsProp.map((el) => {
    return el.value
  })
}

// すべて選択します
const onCheckAllChange = (e: any) => {
  if (e.target.checked) {
    checkboxValue.value = getAllValueArrow()
    handleChange(checkboxValue.value)
    Object.assign(state, {
      indeterminate: false
    })
  } else {
    checkboxValue.value = []
    handleChange(checkboxValue.value)
    Object.assign(state, {
      indeterminate: true
    })
  }
}

// 複数ボックスを選択する場合
const handleChange = (val: CheckboxValueType[]) => {
  // ソート順
  val.sort((a, b) => {
    return (a as number) - (b as number)
  })
  // クリア
  labelForShow.value = []
  // 表示項目をループする
  val.forEach((val) => {
    const { label } = props.optionsProp.find((el) => el.value === val) as optionInter
    labelForShow.value.push(label)
  })
  emit('update:checkbox-value-prop', checkboxValue.value)
}

// 選択されたアイテムを削除する場合
const onDeleteItem = (val: any) => {
  const item = props.optionsProp.find((el) => el.label === val) as optionInter
  const i = checkboxValue.value.findIndex((el) => el === item.value)
  checkboxValue.value.splice(i, 1)
  handleChange(checkboxValue.value)
}

// イベントを監視する
watch(
  () => props.checkboxValueProp,
  (val) => {
    console.log(val)
    checkboxValue.value = val
    handleChange(checkboxValue.value)
  },
  { immediate: true }
)

// イベントを監視する
watch(
  () => checkboxValue.value,
  (val) => {
    state.indeterminate = !!val.length && val.length < props.optionsProp.length
    state.checkAll = val.length === props.optionsProp.length
  },
  { immediate: true }
)
</script>

<template>
  <a-select
    v-model:value="labelForShow"
    mode="multiple"
    style="width: 400px"
    allow-clear
    @deselect="onDeleteItem"
  >
    <template #dropdownRender>
      <div v-if="needAllCheck">
        <a-checkbox
          v-model:checked="state.checkAll"
          :indeterminate="state.indeterminate"
          @change="onCheckAllChange"
        >
          すべて
        </a-checkbox>
        <a-divider style="margin: 4px" />
      </div>
      <a-checkbox-group
        v-model:value="checkboxValue"
        style="width: 100%"
        :class="[isColumn ? 'checkbox-column' : '']"
        @mousedown.prevent
        @change="handleChange"
      >
        <template v-for="item in optionsProp" :key="item.value">
          <a-checkbox :value="item.value">{{ item.label }}</a-checkbox>
        </template>
      </a-checkbox-group>
    </template>
  </a-select>
</template>

<style scoped lang="scss">
.ant-checkbox-wrapper {
  margin-left: 8px !important;
}
.checkbox-column {
  display: flex;
  flex-direction: column;
}
</style>
