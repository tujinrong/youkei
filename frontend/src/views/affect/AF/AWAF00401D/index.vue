<template>
  <a-modal
    v-model:visible="modalVisible"
    title="CSV出力"
    :closable="false"
    :mask-closable="false"
    :destroy-on-close="true"
    width="600px"
  >
    <h4>CSVを出力しますか？</h4>

    <div class="self_adaption_table form">
      <a-row class="mb-4">
        <a-col :span="24">
          <th class="required">ファイル名</th>
          <td>
            <a-form-item v-bind="validateInfos.exportName">
              <a-input v-model:value="formData.exportName" allow-clear></a-input>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row class="items-center mb-4">
        <a-col :span="16">
          <th class="required">出力パターン</th>
          <td>
            <a-form-item v-bind="validateInfos.a">
              <a-select
                v-model:value="formData.a"
                :options="[]"
                allow-clear
                show-search
                :filter-option="filterOption"
                class="w-full"
              />
            </a-form-item>
          </td>
        </a-col>
        <a-button type="primary" class="ml-2" @click="csvVisible = true">CSV出力項目</a-button>
      </a-row>
      <a-row class="mb-4">
        <a-col :span="16">
          <th class="required">ヘッダー</th>
          <td>
            <a-form-item v-bind="validateInfos.b">
              <ai-select v-model:value="formData.b" :options="[]"></ai-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col :span="16">
          <th class="required">文字コード</th>
          <td>
            <a-form-item v-bind="validateInfos.c">
              <ai-select v-model:value="formData.c" :options="[]"></ai-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col :span="16">
          <th class="required">引用符</th>
          <td>
            <a-form-item v-bind="validateInfos.d">
              <a-select v-model:value="formData.d" :options="formatterOptions"></a-select>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col :span="16">
          <th class="required">発送履更新</th>
          <td>
            <a-form-item v-bind="validateInfos.e">
              <a-select
                v-model:value="formData.e"
                :options="[]"
                allow-clear
                show-search
                :filter-option="filterOption"
                class="w-full"
              />
            </a-form-item>
          </td>
        </a-col>
      </a-row>
    </div>

    <template #footer>
      <a-button type="primary" style="float: left" @click="download">ダウンロード</a-button>
      <a-button type="primary" @click="closeOutput">閉じる</a-button>
    </template>
  </a-modal>
  <!-- todo:reportid -->
  <CsvModal v-model:visible="csvVisible" :reportid="666" />
</template>

<script setup lang="ts">
import { computed, reactive, ref, watch } from 'vue'
import { Form, SelectProps, message } from 'ant-design-vue'
import CsvModal from '@/views/affect/AF/AWAF00402D/index.vue'
import {
  DOWNLOAD_CONFIRM,
  DOWNLOAD_OK_INFO,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR
} from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { ArEnumEncoding } from '#/Enums'
import { filterOption } from '@/utils/util'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------

const props = defineProps<{
  visible: boolean
  rptid?: number
  filename?: string
}>()
const emit = defineEmits(['update:visible', 'onPreview'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
//表示判断
const csvVisible = ref(false)
//ビューモデル
const formatterOptions = ref<SelectProps['options']>([
  { label: 'UTF8', value: ArEnumEncoding.UTF8 },
  { label: 'Shift-JIS', value: ArEnumEncoding.Shift_jis },
  { label: 'UNICODE', value: ArEnumEncoding.Unicode }
])
function createDefaultForm() {
  return {
    exportName: '',
    a: '',
    b: '',
    c: '',
    d: '',
    e: ''
  }
}
const formData = reactive(createDefaultForm())

//項目の設定
const rules = reactive({
  exportName: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ファイル名') }],
  a: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '出力パターン') }],
  b: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'ヘッダー') }],
  c: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '文字コード') }],
  d: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '引用符') }],
  e: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '発送履更新') }]
})
const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      clearValidate()
      // exportName.value = props.filename ?? ''
    }
  }
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
//---------------------------------------------------------------------------
//ダウンロード処理
const download = async () => {
  await validate()
  showConfirmModal({
    content: DOWNLOAD_CONFIRM,
    onOk: async () => {
      //todo
      message.success(DOWNLOAD_OK_INFO.Msg)
    }
  })
}

//出力modal閉じる
const closeOutput = () => {
  emit('update:visible', false)
  Object.assign(formData, createDefaultForm())
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
