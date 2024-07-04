<template>
  <div v-if="show" ref="boxRef" :style="{ top: y + 'px', left: x + 'px' }" class="comment-box">
    <div class="input-box">
      <div class="input-mark">
        {{ comment }}
      </div>
      <input ref="inputRef" v-model="comment" class="comment-input" />
    </div>
    <a-button danger shape="circle" size="small" class="del-btn" @click="onDel">x</a-button>
  </div>
</template>

<script setup>
import { defineComponent, computed, ref, onMounted } from 'vue'
import useMove from './use-move'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps({
  data: {
    type: Object,
    default: () => {
      return {}
    }
  }
})
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['del'])
const loading = ref(false)
const boxRef = ref()
const inputRef = ref()
const width = ref(0)
const height = ref(0)
const x = ref(0)
const y = ref(0)
const comment = ref('')

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const show = computed(() => {
  return !props.data.isDel
})

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  setData()
  if (props.data.setFocus) {
    setTimeout(() => {
      inputRef.value.focus()
    }, 100)
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const setData = () => {
  width.value = props.data.width
  height.value = props.data.height
  x.value = props.data.posX
  y.value = props.data.posY
  comment.value = props.data.comment
  useMove(boxRef.value, () => {
    x.value = Number(boxRef.value.style.left.replace('px'))
    y.value = Number(boxRef.value.style.top.replace('px'))
  })
}

const handleKeyDown = (e) => {
  if (e.keyCode === 13) {
    e.preventDefault()
  }
}

const onDel = () => {
  emit('del', props.data)
}
</script>
<style lang="less" scoped>
.comment-box {
  min-width: 80px;
  min-height: 24px;
  width: fit-content;
  border: 1px dashed transparent;

  .del-btn {
    min-width: 18px;
    height: 18px;
    padding: 0;
    line-height: 10px;
    position: absolute;
    right: -9px;
    top: -9px;
    display: none;
  }

  &:hover {
    border: 1px dashed #999;
    .del-btn {
      display: block;
    }
  }

  .editable_div {
    white-space: nowrap;
    overflow-x: hidden;
    display: inline-block;
    font-size: 12px;
    color: #b63f41;
    background-color: #ffffff;
    padding: 2px 8px 2px 4px;
    max-width: 100%;
  }

  .input-box {
    .input-mark {
      opacity: 0;
    }
    .comment-input {
      padding: 0;
      background-color: transparent;
      border: none;
      width: 100%;
      position: absolute;
      outline: none;
      top: 0;
      &:focus {
        border: 1px dashed #999;
        outline: none;
      }
    }
  }
}
</style>
