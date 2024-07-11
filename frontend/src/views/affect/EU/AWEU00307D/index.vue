<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: CSV出力項目
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="900px"
    title="CSV出力項目"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    centered
  >
    <div v-if="!data">
      <div class="self_adaption_table form mb-4">
        <a-row class="items-center">
          <a-col :span="11">
            <th>出力パターン</th>
            <td>
              <a-select
                v-model:value="outputptnno"
                :options="options"
                allow-clear
                show-search
                :filter-option="filterOption"
                class="w-full"
              />
            </td>
          </a-col>
          <a-button type="primary" class="ml-2" :disabled="!outputptnno" @click="searchData"
            >検索</a-button
          >
          <a-button
            type="primary"
            class="ml-2"
            @click="
              () => {
                isNew = true
                searchData()
              }
            "
            >新規</a-button
          >
        </a-row>
      </div>
    </div>
    <div v-else>
      <div class="self_adaption_table form mb-4">
        <a-row class="items-center">
          <a-col :span="11">
            <th class="required">出力パターン名</th>
            <td>
              <a-form-item v-bind="validateInfos.outputptnnm">
                <a-input v-model:value="formData.outputptnnm"></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-button type="primary" class="ml-2" @click="backToSearch">再検索</a-button>
        </a-row>
      </div>
    </div>
    <Transfer
      v-if="showTransfer"
      v-model:keys="targetKeys"
      :source="data ?? []"
      :titles="['出力可能項目', '出力項目']"
      :disabled="transferDisabled"
    />
    <template #footer>
      <a-space style="float: left">
        <a-button type="warn" :disabled="!canSave" @click="onOk">登録</a-button>
        <a-button type="primary" danger :disabled="!canDelete" @click="onDelete">削除</a-button>
      </a-space>

      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import Transfer from '@/components/Common/Transfer/index.vue'
import { Form, message } from 'ant-design-vue'
import {
  DELETE_OK_INFO,
  E064004,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  RESEARCH_CONFIRM,
  SAVE_OK_INFO
} from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { Delete, Init, Save, Search } from './service'
import { filterOption } from '@/utils/util'
import { GlobalStore } from '@/store'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface SourceData {
  key: string
  title: string
}
const props = defineProps<{
  visible: boolean
  rptid: string
  yosikiid: string
  csvpattern: string
}>()
const emit = defineEmits(['update:visible', 'initData'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
const isNew = ref(false)
const transferDisabled = ref(true)
const options = ref<DaSelectorModel[]>([])
const targetKeys = ref<string[]>([])
const data = ref<SourceData[] | null>(null)
const outputptnno = ref('')
const formData = reactive({ outputptnnm: '' })
let upddttm

//項目の設定
const rules = reactive({
  outputptnnm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '出力パターン名') }
  ]
})
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)

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

//操作権限
const canSave = computed(() => Boolean(data.value))
const canDelete = computed(() => Boolean(data.value) && !isNew.value)
const showTransfer = ref(true)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (val) => {
    if (val) {
      getOptions()
      outputptnno.value = props.csvpattern
      if (outputptnno.value) searchData()
    }
  }
)

watch(targetKeys, () => editJudge.setEdited())
//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function getOptions() {
  const res = await Init({ rptid: props.rptid, yosikiid: props.yosikiid })
  options.value = res.selectorlist
}

//検索処理
async function searchData() {
  const res = await Search({
    rptid: props.rptid,
    yosikiid: props.yosikiid,
    outputptnno: isNew.value ? undefined : +outputptnno.value
  })
  data.value =
    res.kekkalist1?.map((el) => ({
      key: String(el.reportitemid),
      title: el.reportitemnm
    })) ?? []
  targetKeys.value = res.kekkalist2?.map((el) => String(el)) ?? []
  formData.outputptnnm = res.outputptnnm
  upddttm = res.upddttm
  transferDisabled.value = false

  nextTick(() => {
    clearValidate()
    editJudge.reset()
  })
}

//登録処理
async function onOk() {
  await validate()
  if (targetKeys.value.length === 0) {
    showInfoModal({
      type: 'info',
      content: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '出力する項目')
    })
    return
  }
  showSaveModal({
    onOk: async () => {
      await Save({
        rptid: props.rptid,
        yosikiid: props.yosikiid,
        outputptnno: isNew.value ? undefined : +outputptnno.value,
        outputptnnm: formData.outputptnnm,
        kekkalist: targetKeys.value.map((el) => String(el)),
        upddttm
      })
      reset()
      message.success(SAVE_OK_INFO.Msg)
      getOptions()
      emit('initData')
      closeModalFroTouroku()
    }
  })
}
//削除処理
function onDelete() {
  if (options.value.length === 1) {
    showInfoModal({
      type: 'info',
      content: E064004
    })
    return
  }
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({
          rptid: props.rptid,
          yosikiid: props.yosikiid,
          outputptnno: +outputptnno.value,
          upddttm
        })
        reset()
        message.success(DELETE_OK_INFO.Msg)
        getOptions()
        emit('initData')
        closeModal()
      } catch (error) {}
    }
  })
}

//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    reset()
  })
}

const closeModalFroTouroku = () => {
  editJudge.reset()
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    reset()
  })
}

//再検索
const backToSearch = () => {
  editJudge.judgeIsEdited(() => {
    showTransfer.value = false
    nextTick(() => (showTransfer.value = true))
    reset()
  }, RESEARCH_CONFIRM.Msg)
}

//リセット
function reset() {
  transferDisabled.value = true
  data.value = null
  isNew.value = false
  outputptnno.value = ''
  formData.outputptnnm = ''
  targetKeys.value = []
  nextTick(() => editJudge.reset())
}
</script>

<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
