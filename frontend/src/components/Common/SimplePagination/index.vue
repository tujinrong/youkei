<template>
  <ul class="ant-pagination ant-pagination-simple">
    <li
      :class="
        current <= 1 || disabled
          ? 'ant-pagination-prev ant-pagination-disabled'
          : 'ant-pagination-prev'
      "
      tabindex="0"
    >
      <button
        class="ant-pagination-item-link"
        type="button"
        tabindex="-1"
        :disabled="current <= 1 || disabled"
        @click="onPrev"
      >
        <span role="img" class="anticon anticon-left">
          <svg
            focusable="false"
            class=""
            data-icon="left"
            width="1em"
            height="1em"
            fill="currentColor"
            viewBox="64 64 896 896"
          >
            <path
              d="M724 218.3V141c0-6.7-7.7-10.4-12.9-6.3L260.3 486.8a31.86 31.86 0 000 50.3l450.8 352.1c5.3 4.1 12.9.4 12.9-6.3v-77.3c0-4.9-2.3-9.6-6.1-12.6l-360-281 360-281.1c3.8-3 6.1-7.7 6.1-12.6z"
            />
          </svg>
        </span>
      </button>
    </li>
    <li class="ant-pagination-simple-pager">
      <a-input
        v-model:value="inputValue"
        class="w-14"
        :disabled="disabled"
        @blur="onBlurOrEnter"
        @press-enter="onBlurOrEnter"
      />
      <span class="ant-pagination-slash">/</span>{{ count }}
    </li>
    <li
      :class="
        current === count || disabled
          ? 'ant-pagination-prev ant-pagination-disabled'
          : 'ant-pagination-prev'
      "
      tabindex="0"
    >
      <button
        class="ant-pagination-item-link"
        type="button"
        tabindex="-1"
        :disabled="current === count || disabled"
        @click="onNext"
      >
        <span role="img" class="anticon anticon-right">
          <svg
            focusable="false"
            class=""
            data-icon="right"
            width="1em"
            height="1em"
            fill="currentColor"
            viewBox="64 64 896 896"
          >
            <path
              d="M765.7 486.8L314.9 134.7A7.97 7.97 0 00302 141v77.3c0 4.9 2.3 9.6 6.1 12.6l360 281.1-360 281.1c-3.9 3-6.1 7.7-6.1 12.6V883c0 6.7 7.7 10.4 12.9 6.3l450.8-352.1a31.96 31.96 0 000-50.4z"
            />
          </svg>
        </span>
      </button>
    </li>
  </ul>
</template>

<script setup lang="ts">
import { ref, watchEffect } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  count: number
  current: number
  disabled?: boolean
}>()
const emit = defineEmits(['change'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const inputValue = ref(props.current + '')

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  inputValue.value = props.current.toString()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onBlurOrEnter(e) {
  if (
    +e.target.value &&
    +e.target.value <= props.count &&
    e.target.value !== props.current.toString() //前の値とは違い
  ) {
    emit('change', +inputValue.value)
  } else {
    inputValue.value = props.current.toString()
  }
}
function onPrev() {
  const str = (+inputValue.value - 1).toString()
  emit('change', +str)
}

function onNext() {
  const str = (+inputValue.value + 1).toString()
  emit('change', +str)
}
</script>
