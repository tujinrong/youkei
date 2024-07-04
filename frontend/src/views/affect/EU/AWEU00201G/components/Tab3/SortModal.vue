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
            <th>項目ID</th>
            <th>項目名</th>
            <th class="w-24">区分</th>
          </tr>
          <tr v-if="filterData.length === 0">
            <td colspan="3">
              <a-empty :image="Empty.PRESENTED_IMAGE_SIMPLE" />
            </td>
          </tr>
          <draggable v-else :list="filterData" item-key="orderseq" style="display: contents">
            <template #item="{ element }">
              <tr>
                <td>{{ element.yosikiitemid }}</td>
                <td>{{ element.reportitemnm }}</td>
                <td>{{ Enum並び替え[element.orderkbn] }}</td>
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
import { Ref, computed, ref, watch, nextTick } from 'vue'
import { Enum並び替え } from '#/Enums'
import { Empty } from 'ant-design-vue'
import draggable from 'vuedraggable'
import { ReportItemDetailVM } from '../../type'
import emitter from '@/utils/event-bus'
import { Judgement } from '@/utils/judge-edited'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  data: ReportItemDetailVM[]
  visible: boolean
  rptid: string
  yosikiid: string
}>()
const emit = defineEmits(['update:visible'])
const editJudge = new Judgement()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const filterData = ref<ReportItemDetailVM[]>([])
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      console.log('dd')
      filterData.value = props.data
        .filter((el) => el.orderkbn !== Enum並び替え.無し)
        .sort((a, b) => Number(a.orderkbnseq) - Number(b.orderkbnseq))
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
    el.orderkbnseq = index + 1
  })
  const result = filterData.value.map((el) => {
    return {
      reportitemid: el.yosikiitemid,
      descflg: el.orderkbn === Enum並び替え.降順,
      pageflg: false
    }
  })
  emitter.emit('sortsublist', result)
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
