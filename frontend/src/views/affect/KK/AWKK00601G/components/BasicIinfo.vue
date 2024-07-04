<template>
  <div class="my-2 min-h-full" :style="{ height: tableHeight }">
    <a-row :gutter="[10, 10]" style="margin-top: 5px">
      <a-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" :xxl="12">
        <a-form
          ref="formRef"
          :label-col="{ span: 4 }"
          :wrapper-col="{ span: 24 }"
          :model="queryParam"
          :rules="rules"
        >
          <div class="description-table">
            <table>
              <tbody>
                <div v-if="props.errorMessages.filetype" class="tooltip">
                  {{ props.errorMessages.filetype }}
                </div>
                <tr>
                  <th style="width: 40px">ファイル形式<span class="request-mark">＊</span></th>
                  <td style="width: 80px" colspan="3">
                    <a-form-item name="filetype" style="width: 100%">
                      <ai-select
                        v-model:value="queryParam.filetype"
                        :options="filetypeOptions"
                        style="width: 100%"
                        split-val
                      ></ai-select>
                    </a-form-item>
                  </td>
                </tr>
                <div v-if="props.errorMessages.fileencode" class="tooltip">
                  {{ props.errorMessages.fileencode }}
                </div>
                <tr>
                  <th style="width: 40px">エンコード<span class="request-mark">＊</span></th>
                  <td style="width: 200px" colspan="3">
                    <a-form-item name="fileencode" style="width: 100%">
                      <ai-select
                        v-model:value="queryParam.fileencode"
                        :options="filenmruOptions"
                        style="width: 100%"
                        split-val
                      />
                    </a-form-item>
                  </td>
                </tr>
                <div v-if="props.errorMessages.filenmrule" class="tooltip">
                  {{ props.errorMessages.filenmrule }}
                </div>
                <tr>
                  <th style="width: 80px">ファイル名称</th>
                  <td style="width: 200px">
                    <a-form-item
                      name="filenmrule"
                      style="width: 100%"
                      :validate-status="props.errorMessages.filenmrule ? 'error' : ''"
                    >
                      <a-input
                        v-model:value="queryParam.filenmrule"
                        maxlength="50"
                        style="width: 100%"
                      ></a-input>
                    </a-form-item>
                  </td>
                  <th style="width: 80px">正規表現</th>
                  <td style="width: 50px">
                    <a-checkbox
                      v-model:checked="queryParam.filenmruleflg"
                      style="width: 100%; margin-left: 10px"
                    ></a-checkbox>
                  </td>
                </tr>
                <div v-if="props.errorMessages.datakbn" class="tooltip">
                  {{ props.errorMessages.datakbn }}
                </div>
                <tr>
                  <th style="width: 40px">データ形式<span class="request-mark">＊</span></th>
                  <td style="width: 80px" colspan="3">
                    <a-form-item name="datakbn" style="width: 100%">
                      <ai-select
                        v-model:value="queryParam.datakbn"
                        :options="datakbnOptions"
                        style="width: 100%"
                        split-val
                      ></ai-select>
                    </a-form-item>
                  </td>
                </tr>
                <div v-if="props.errorMessages.recordlen" class="tooltip">
                  {{ props.errorMessages.recordlen }}
                </div>
                <tr
                  v-if="
                    queryParam.datakbn &&
                    queryParam.datakbn.indexOf(Enumデータ形式.固定長.toString()) > -1
                  "
                >
                  <th style="width: 40px">レコード長<span class="request-mark">＊</span></th>
                  <td style="width: 200px" colspan="3">
                    <a-form-item name="recordlen" style="width: 100%">
                      <a-input
                        v-model:value="queryParam.recordlen"
                        type="number"
                        max="99999999"
                        style="width: 100%"
                      ></a-input>
                    </a-form-item>
                  </td>
                </tr>
                <div v-if="props.errorMessages.quoteskbn" class="tooltip">
                  {{ props.errorMessages.quoteskbn }}
                </div>
                <tr
                  v-if="
                    queryParam.datakbn &&
                    queryParam.datakbn.indexOf(Enumデータ形式.可変長.toString()) > -1
                  "
                >
                  <th style="width: 40px">引用符<span class="request-mark">＊</span></th>
                  <td style="width: 80px" colspan="3">
                    <a-form-item name="quoteskbn" style="width: 100%">
                      <ai-select
                        v-model:value="queryParam.quoteskbn"
                        :options="quoteskbnOptions"
                        style="width: 100%"
                        split-val
                      ></ai-select>
                    </a-form-item>
                  </td>
                </tr>
                <div v-if="props.errorMessages.dividekbn" class="tooltip">
                  {{ props.errorMessages.dividekbn }}
                </div>
                <tr
                  v-if="
                    queryParam.datakbn &&
                    queryParam.datakbn.indexOf(Enumデータ形式.可変長.toString()) > -1
                  "
                >
                  <th style="width: 40px">
                    区切り記号<span
                      v-if="
                        queryParam.datakbn &&
                        queryParam.datakbn.indexOf(Enumデータ形式.可変長.toString()) > -1
                      "
                      class="request-mark"
                      >＊</span
                    >
                  </th>
                  <td style="width: 80px" colspan="3">
                    <a-form-item name="dividekbn" style="width: 100%">
                      <ai-select
                        v-model:value="queryParam.dividekbn"
                        :options="dividekbnOptions"
                        style="width: 100%"
                        split-val
                      ></ai-select>
                    </a-form-item>
                  </td>
                </tr>
                <tr>
                  <th style="width: 40px">ヘッダー行数</th>
                  <td style="width: 200px" colspan="3">
                    <a-input
                      v-model:value="queryParam.headerrows"
                      type="number"
                      max="999"
                      style="width: 100%"
                    ></a-input>
                  </td>
                </tr>
                <tr>
                  <th style="width: 40px">フッター行数</th>
                  <td style="width: 200px" colspan="3">
                    <a-input
                      v-model:value="queryParam.footerrows"
                      type="number"
                      max="999"
                      style="width: 100%"
                    ></a-input>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </a-form>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//基本情報
//--------------------------------------------------------------------------
import { ref, onMounted, watch, reactive, computed, nextTick } from 'vue'
import { getHeight } from '@/utils/height'
import { SelectProps } from 'ant-design-vue'
import { FileInfoVM } from '../type'
import { Enumデータ形式 } from '#/Enums'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  isChange: boolean
  data?: FileInfoVM
  errorMessages: FileInfoVM
  filetypeOptions: SelectProps['options']
  filenmruOptions: SelectProps['options']
  datakbnOptions: SelectProps['options']
  quoteskbnOptions: SelectProps['options']
  dividekbnOptions: SelectProps['options']
}
const props = withDefaults(defineProps<Props>(), {
  isChange: false
})
const emit = defineEmits(['update:isChange', 'getData'])
const tableHeight = computed(() => 'max(' + getHeight(339) + ',400px)')
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const queryParam = ref<FileInfoVM>({
  filetype: '',
  fileencode: '',
  filenmrule: '',
  datakbn: '',
  recordlen: undefined,
  quoteskbn: '',
  dividekbn: '',
  headerrows: undefined,
  footerrows: undefined,
  filenmruleflg: false
})
let compareParam = reactive<FileInfoVM>({
  filetype: '',
  fileencode: '',
  filenmrule: '',
  datakbn: '',
  recordlen: undefined,
  quoteskbn: '',
  dividekbn: '',
  headerrows: undefined,
  footerrows: undefined,
  filenmruleflg: false
})
const rules = ref({})
const normRule = ref({
  datakbn: [
    {
      required: true,
      message: ''
    }
  ],
  fileencode: [
    {
      required: true,
      message: ''
    }
  ],
  filetype: [
    {
      required: true,
      message: ''
    }
  ],
  quoteskbn: [
    {
      required: true,
      message: ''
    }
  ],
  dividekbn: [
    {
      required: true,
      message: ''
    }
  ]
})
const mainRule = ref({
  datakbn: [
    {
      required: true,
      message: ''
    }
  ],
  fileencode: [
    {
      required: true,
      message: ''
    }
  ],
  filetype: [
    {
      required: true,
      message: ''
    }
  ],
  recordlen: [
    {
      required: true,
      message: ''
    }
  ]
})
const formRef = ref()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const isChange2 = computed(() => {
  return JSON.stringify(compareParam) != JSON.stringify(queryParam.value)
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => queryParam.value,
  (newValue) => {
    handleData()
  },
  { deep: true }
)
watch(
  () => queryParam.value.datakbn,
  (newValue) => {
    if (newValue && newValue.indexOf(Enumデータ形式.可変長.toString()) > -1) {
      rules.value = { ...normRule.value }
    } else if (newValue && newValue.indexOf(Enumデータ形式.固定長.toString()) > -1) {
      rules.value = { ...mainRule.value }
    }
    nextTick(() => formRef.value.validate())
  },
  {}
)
watch(
  () => queryParam.value.headerrows,
  (newValue) => {
    queryParam.value.headerrows =
      queryParam.value.headerrows != undefined
        ? Math.min(999, Math.max(0, Math.floor(queryParam.value.headerrows)))
        : undefined
  },
  { deep: true }
)
watch(
  () => queryParam.value.footerrows,
  (newValue) => {
    queryParam.value.footerrows =
      queryParam.value.footerrows != undefined
        ? Math.min(999, Math.max(0, Math.floor(queryParam.value.footerrows)))
        : undefined
  },
  { deep: true }
)
watch(
  () => props.data,
  (newValue) => {
    if (newValue) {
      initData()
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  //
  if (props.data) {
    initData()
  }
  rules.value = { ...normRule.value }
})

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const initData = () => {
  queryParam.value = JSON.parse(JSON.stringify(props.data))
  compareParam = JSON.parse(JSON.stringify(queryParam.value))
}
//データ処理
const handleData = () => {
  emit('update:isChange', isChange2.value)
  emit('getData', 'basicInfo', queryParam.value, isChange2.value)
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}
:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
.text-hidden {
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}

:deep(.ant-form-item-with-help .ant-form-item-explain) {
  display: none;
}
:deep(.ant-form-item) {
  margin-bottom: 0 !important;
}

.tooltip {
  color: #ff4d4f;
  position: fixed;
  left: 0;
  z-index: 1;
  margin-left: 1100px;
}

@media screen and (max-width: 1200px) {
  .tooltip {
    margin-left: 1300px;
  }
}
</style>
