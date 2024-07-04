<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    title="並び替え"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    @ok="handleSortOk"
    @cancel="closeModal"
  >
    <div class="description-table readonly max-height-table">
      <table>
        <tbody>
          <tr style="border-bottom: 1px solid">
            <th>検索条件</th>
          </tr>
          <draggable :list="filterData" item-key="sortseq" style="display: contents">
            <template #item="{ element }">
              <tr>
                <td>{{ element.label || element.jyokenlabel }}</td>
              </tr>
            </template>
          </draggable>
        </tbody>
      </table>
    </div>

    <template #footer>
      <a-button style="float: left" type="primary" @click="handleSortOk">設定</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, nextTick, ref, watch } from 'vue'
import { SearchConditionVM } from '../../../type'
import draggable from 'vuedraggable'
import { Judgement } from '@/utils/judge-edited'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  data: SearchConditionVM[]
  visible: boolean
  kensakukbn: number
}>()
const emit = defineEmits(['update:visible', 'update:data'])
const editJudge = new Judgement()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const filterData = ref<SearchConditionVM[]>([])
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      filterData.value = JSON.parse(JSON.stringify(props.data))
      nextTick(() => editJudge.reset())
    }
  }
)
watch(
  () => filterData.value,
  () => {
    editJudge.setEdited()
  },
  { deep: true }
)
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
//確認と保存処理
const handleSortOk = () => {
  filterData.value.forEach((el, index) => {
    el.orderseq = index + (props.kensakukbn == 1 ? 0 : 1000)
  })
  emit('update:data', filterData.value)
  editJudge.reset()
  closeModal()
}

//取消処理
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    nextTick(() => editJudge.reset())
  })
}
</script>
<style scoped>
.max-height-table {
  max-height: 400px;
  overflow-y: auto;
}
</style>
