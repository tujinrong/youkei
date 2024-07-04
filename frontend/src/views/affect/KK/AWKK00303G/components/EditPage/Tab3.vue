<template>
  <div ref="elRef">
    <div class="relative">
      <a-checkbox
        :checked="formData.inputflg"
        :disabled="!(+edano <= 0 || route.meta.updflg)"
        @change="changeInputflg"
        >参加者情報入力</a-checkbox
      >
      <div class="self_adaption_table form w-100 absolute top-0 left-60">
        <a-row>
          <a-col :span="24">
            <th :class="{ required: canEdit, 'bg-readonly': !canEdit }">事業コード</th>
            <td>
              <a-form-item v-bind="validateInfos.jigyo">
                <ai-select
                  v-model:value="formData.jigyo"
                  :options="initdetail?.jigyolist"
                  :disabled="!canEdit"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
    </div>
    <div class="flex justify-between mt-4">
      <a-space>
        <a-button
          class="btn-round"
          type="primary"
          :disabled="!canEdit"
          @click="handleSeki(Enum出席欠席.出席)"
          >全員出席</a-button
        >
        <a-button
          class="btn-round"
          type="primary"
          :disabled="!canEdit"
          @click="handleSeki(Enum出席欠席.欠席)"
          >全員欠席</a-button
        >
      </a-space>
      <a-space>
        <a-button class="btn-round" type="primary" :disabled="!canEdit" @click="visible = true"
          >行追加</a-button
        >
        <a-button
          class="btn-round"
          type="primary"
          :disabled="!canEdit || !selectedRow"
          @click="deleteRow"
        >
          行削除</a-button
        >
      </a-space>
    </div>

    <vxe-table
      ref="xTableRef"
      class="mt-2"
      :height="isXL ? height - 80 : '300'"
      :loading="tableLoading"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="dataSource"
      :sort-config="{ trigger: 'cell', remote: true }"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="syukketukbn" title="出欠区分">
        <template #default="{ row }">
          <a-switch
            v-model:checked="row.syukketukbn"
            :checked-value="Enum出席欠席.出席"
            :un-checked-value="Enum出席欠席.欠席"
            :disabled="!canEdit"
            checked-children="出席"
            un-checked-children="欠席"
          />
        </template>
      </vxe-column>
      <vxe-column field="atenano" title="宛名番号">
        <template #default="{ row }">
          <a v-if="!row.isnew" @click="forwardDetail(row, PageSatatus.Edit)">{{ row.atenano }}</a>
          <span v-else>{{ row.atenano }}</span>
        </template>
      </vxe-column>
      <vxe-column field="name" title="氏名">
        <template #default="{ row }">
          <a v-if="!row.isnew" @click="forwardDetail(row, PageSatatus.Edit)">{{ row.name }}</a>
          <span v-else>{{ row.name }}</span>
        </template>
      </vxe-column>
      <vxe-column field="kname" title="カナ氏名"></vxe-column>
      <vxe-column field="sex" title="性別"></vxe-column>
      <vxe-column field="bymd" title="生年月日"></vxe-column>
      <vxe-column field="juminkbn" title="住民区分"></vxe-column>
      <vxe-column field="keikoku" title="警告内容"></vxe-column>
    </vxe-table>
    <AtenanoModal v-model:visible="visible" @select="addRow" />
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watchEffect, nextTick } from 'vue'
import { useElementSize, useWindowSize } from '@vueuse/core'
import { Form, message } from 'ant-design-vue'
import { useRoute, useRouter } from 'vue-router'
import { C011003, E001008, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Enum申込結果参加者, PageSatatus } from '#/Enums'
import { SankasyaSaveVM, InitDetailVM, SankasyaListVM } from '../../type'
import { SearchSankasyaList } from '../../service'
import { XL } from '@/utils/height'
import { Judgement } from '@/utils/judge-edited'
import AtenanoModal from '@/views/affect/AF/AWAF00705D/index.vue'
import { showConfirmModal, showDeleteModal } from '@/utils/modal'
import { VxeTableInstance } from 'vxe-table'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
enum Enum出席欠席 {
  出席 = '1',
  欠席 = '2'
}
const props = defineProps<{
  initdetail: InitDetailVM | null
  editJudge: Judgement
  status: PageSatatus
}>()
const emit = defineEmits(['update:status'])

const router = useRouter()
const route = useRoute()
const visible = ref(false)
const edano = route.query.edano as string
const gyomu = route.query.gyomu as string
const tableLoading = ref(false)
const xTableRef = ref<VxeTableInstance>()

const dataSource = ref<SankasyaListVM[]>([])
const selectedRow = ref<SankasyaListVM | null>(null)
const formData = reactive<Omit<SankasyaSaveVM, 'sankasyalist'>>({
  inputflg: false,
  jigyo: ''
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//項目の設定
const rules = computed(() => ({
  jigyo: [
    { required: formData.inputflg, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事業コード') }
  ]
}))
const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)

const { width } = useWindowSize()
const isXL = computed(() => width.value >= XL)
const elRef = ref(null)
const { height } = useElementSize(elRef)

const canEdit = computed(() => Boolean((+edano <= 0 || route.meta.updflg) && formData.inputflg))
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchDetail()
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  selectedRow.value = xTableRef.value?.getCurrentRecord()
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//参加者一覧検索
const searchDetail = () => {
  SearchSankasyaList({
    jigyocd: formData.jigyo,
    gyomukbn: gyomu,
    edano: +edano,
    mosikomikekkakbn: Enum申込結果参加者.参加者.toString()
  }).then((res) => {
    formData.jigyo = res.jigyo
    formData.inputflg = res.inputflg
    dataSource.value = res.sankasyalist
    nextTick(() => props.editJudge.reset())
  })
}
//出席欠席ボータン
const handleSeki = (type: Enum出席欠席) => {
  dataSource.value.forEach((item) => (item.syukketukbn = type))
}
//データセーブ
const getSaveForm = (): SankasyaSaveVM => {
  return {
    ...formData,
    sankasyalist: dataSource.value
  }
}
//一覧へ
const forwardDetail = async (val, status: PageSatatus) => {
  await router.push({
    path: 'AWKK00303G',
    query: { ...route.query, atenano: val.atenano, patternno: gyomu }
  })
  emit('update:status', status)
}

//行削除
const deleteRow = () => {
  showDeleteModal({
    onOk() {
      dataSource.value = dataSource.value.filter((el) => el !== selectedRow.value)
      selectedRow.value = null
      props.editJudge.setEdited()
    }
  })
}
//行追加
const addRow = (val) => {
  const data = {
    ...val,
    syukketukbn: Enum出席欠席.出席.toString(),
    isnew: true
  }
  if (dataSource.value.map((i) => i.atenano).includes(val.atenano)) {
    message.warning(E001008.Msg.replace('{0}', '事業従事者ID'))
    return
  }
  dataSource.value.push(data)
  props.editJudge.setEdited()
}

const changeInputflg = (e) => {
  if (formData.inputflg) {
    showConfirmModal({
      content: C011003.Msg,
      onOk() {
        formData.inputflg = e.target.checked
      }
    })
  } else {
    formData.inputflg = e.target.checked
  }

  clearValidate()
}

defineExpose({
  validate,
  getSaveForm
})
</script>

<style scoped lang="less">
th {
  width: 130px;
}
</style>
