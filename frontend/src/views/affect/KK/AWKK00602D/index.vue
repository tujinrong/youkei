<template>
  <a-modal
    v-model:visible="props.visible"
    title="ファイルI/F"
    width="700px"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <a-form
        ref="formRef"
        :label-col="{ span: 4 }"
        :wrapper-col="{ span: 24 }"
        :model="formParam"
        :rules="rules"
      >
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 120px; background-color: #ffffe1">項目No</th>
                <td>
                  {{ formParam.fileitemseq }}
                </td>
              </tr>
              <tr>
                <th style="width: 110px">項目名<span class="request-mark">＊</span></th>
                <td>
                  <a-form-item name="itemnm" style="width: 100%">
                    <a-input
                      v-model:value="formParam.itemnm"
                      style="width: 100%"
                      maxlength="100"
                    ></a-input>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">キー(参照)</th>
                <td>
                  <a-checkbox v-model:checked="formParam.keyflg"></a-checkbox>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">必須(参照)</th>
                <td>
                  <a-checkbox v-model:checked="formParam.requiredflg"></a-checkbox>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">データ型<span class="request-mark">＊</span></th>
                <td>
                  <a-form-item name="datatype" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.datatype"
                      :options="typeOptions"
                      style="width: 100%"
                      split-val
                      @change="dataTypeChange()"
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">桁数<span class="request-mark">＊</span></th>
                <td>
                  <div>
                    <div
                      v-if="
                        formParam.datatype &&
                        formParam.datatype === Enum入力方法.数値_小数点付き実数.toString()
                      "
                      style="display: flex; width: 100%"
                    >
                      <a-form-item name="len" style="width: 260px">
                        <a-input v-model:value="formParam.len" type="number" />
                      </a-form-item>
                      <a-form-item name="len2" style="width: 260px">
                        <a-input v-model:value="formParam.len2" type="number" />
                      </a-form-item>
                    </div>
                    <a-form-item v-else name="len">
                      <a-input
                        v-model:value="formParam.len"
                        style="width: 100%"
                        type="number"
                      ></a-input>
                    </a-form-item>
                  </div>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">フォーマット</th>
                <td>
                  <a-form-item
                    name="format"
                    style="width: 100%"
                    :rules="[
                      {
                        required:
                          formParam.datatype &&
                          (formParam.datatype === Enum入力方法.半角文字_年.toString() ||
                            formParam.datatype === Enum入力方法.半角文字_年_不詳あり.toString() ||
                            formParam.datatype === Enum入力方法.半角文字_年月.toString() ||
                            formParam.datatype === Enum入力方法.半角文字_年月_不詳あり.toString() ||
                            formParam.datatype === Enum入力方法.日付_年月日.toString() ||
                            formParam.datatype === Enum入力方法.日付_年月日_不詳あり.toString() ||
                            formParam.datatype === Enum入力方法.日時_年月日時分秒.toString()),
                        message: ''
                      }
                    ]"
                  >
                    <ai-select
                      v-model:value="formParam.format"
                      :options="formatOptions"
                      style="width: 100%"
                      :disabled="
                        formParam.datatype &&
                        formParam.datatype != Enum入力方法.半角文字_年.toString() &&
                        formParam.datatype != Enum入力方法.半角文字_年_不詳あり.toString() &&
                        formParam.datatype != Enum入力方法.半角文字_年月.toString() &&
                        formParam.datatype != Enum入力方法.半角文字_年月_不詳あり.toString() &&
                        formParam.datatype != Enum入力方法.日付_年月日.toString() &&
                        formParam.datatype != Enum入力方法.日付_年月日_不詳あり.toString() &&
                        formParam.datatype != Enum入力方法.日時_年月日時分秒.toString()
                      "
                      split-val
                      @change="formatChange()"
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 160px">フォーマットチェック</th>
                <td>
                  <a-form-item
                    name="fmtcheck"
                    style="width: 100%"
                    :rules="[
                      {
                        required: formParam.format && formParam.format === '99',
                        message: ''
                      }
                    ]"
                  >
                    <ai-select
                      v-model:value="formParam.fmtcheck"
                      :options="fmtCheckOptions"
                      style="width: 100%"
                      :disabled="
                        formParam.format == undefined || formParam.format.indexOf('99') != 0
                      "
                      split-val
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 150px">フォーマット変換</th>
                <td>
                  <a-form-item
                    name="fmtchange"
                    style="width: 100%"
                    :rules="[
                      {
                        required: !(
                          formParam.format == undefined || formParam.format.indexOf('99') != 0
                        ),
                        message: ''
                      }
                    ]"
                  >
                    <ai-select
                      v-model:value="formParam.fmtchange"
                      :options="fmtChangeOptions"
                      style="width: 100%"
                      :disabled="
                        formParam.format == undefined || formParam.format.indexOf('99') != 0
                      "
                      split-val
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">備考</th>
                <td>
                  <a-input
                    v-model:value="formParam.memo"
                    style="width: 100%"
                    :maxlength="30"
                  ></a-input>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-form>
    </a-spin>
    <template #footer>
      <a-button key="submit" type="primary" :loading="loading" style="float: left" @click="add"
        >設定</a-button
      >
      <a-button
        v-if="props.index > -1"
        key="submit"
        type="primary"
        danger
        :loading="loading"
        style="float: left"
        @click="deleteItem"
        >削除</a-button
      >
      <a-button key="submit" type="primary" :loading="loading" style="float: left" @click="clear"
        >クリア</a-button
      >
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
      <div style="clear: both"></div>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//マッピング設定Modal
//---------------------------------------------------------------------------

import { Modal, SelectProps } from 'ant-design-vue'
import { ref, watch, reactive, computed } from 'vue'
import { FileIFVM } from '../AWKK00601G/type'
import { InitDetail, InitFormatList } from './service'
import { showDeleteModal, showConfirmModal } from '@/utils/modal'
import { CLOSE_CONFIRM, CLEAR_CONFIRM } from '@/constants/msg'
import { Enum入力方法 } from '#/Enums'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  index: number
  param?: FileIFVM
  impno?: string
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'delete', 'update'])
//---------------------------------------------------------------------------
//データ定義(data(ref…))
//---------------------------------------------------------------------------
const formParam = ref<FileIFVM>({ fileitemseq: -1, itemnm: '' })
let compareParam = reactive<FileIFVM>({ fileitemseq: -1, itemnm: '' })
const typeOptions = ref<SelectProps['options']>()
const formatOptions = ref<SelectProps['options']>()
const fmtCheckOptions = ref<SelectProps['options']>()
const fmtChangeOptions = ref<SelectProps['options']>()
//ローディング
const loading = ref(false)
const formRef = ref()
const rules = ref({
  itemnm: [
    {
      required: true,
      message: ''
    }
  ],
  datatype: [
    {
      required: true,
      message: ''
    }
  ],
  len: [
    {
      required: true,
      message: ''
    }
  ]
})
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const isChange = computed(() => {
  return JSON.stringify(compareParam) != JSON.stringify(formParam.value)
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      formParam.value = JSON.parse(JSON.stringify(props.param))
      compareParam = JSON.parse(JSON.stringify(props.param))
      init()
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.datatype,
  (newValue) => {
    if (newValue && newValue === Enum入力方法.数値_小数点付き実数.toString()) {
      rules.value['len2'] = [
        {
          required: true,
          message: ''
        }
      ]
    } else {
      rules.value['len2'] = []
    }

    if (newValue) {
      InitFormatList({
        datatype: newValue
      }).then((res) => {
        formatOptions.value = res.formatList
      })
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.len,
  (newValue) => {
    if (formParam.value.len !== undefined) {
      const newLen = Math.min(999, Math.max(1, Math.floor(formParam.value.len)))
      formParam.value.len = newLen
    }
  },
  { deep: true }
)

watch(
  () => formParam.value.len2,
  (newValue) => {
    if (formParam.value.len2 != undefined) {
      const newLen = Math.min(999, Math.max(0, Math.floor(formParam.value.len2)))
      formParam.value.len2 = newLen
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド(methods)
//---------------------------------------------------------------------------
//出力modal閉じる
const closeModal = () => {
  if (isChange.value) {
    showConfirmModal({
      content: CLOSE_CONFIRM.Msg,
      onOk: () => {
        formRef.value.clearValidate()
        emit('update:visible', false)
      }
    })
  } else {
    formRef.value.clearValidate()
    emit('update:visible', false)
  }
}
//登録処理
const add = () => {
  formRef.value.clearValidate()
  formRef.value.validate().then(() => {
    formParam.value.datatypeName = typeOptions.value?.find(
      (item) => item.value === formParam.value?.datatype
    )?.label
    formParam.value.formatName = formatOptions.value?.find(
      (item) => item.value === formParam.value?.format
    )?.label
    formParam.value.fmtcheckName = fmtCheckOptions.value?.find(
      (item) => item.value === formParam.value?.fmtcheck
    )?.label
    formParam.value.fmtchangeName = fmtChangeOptions.value?.find(
      (item) => item.value === formParam.value?.fmtchange
    )?.label
    emit('update', formParam.value)
    formRef.value.clearValidate()
    emit('update:visible', false)
  })
}
//クリア処理
const clear = () => {
  showConfirmModal({
    content: CLEAR_CONFIRM.Msg,
    onOk: () => {
      formParam.value.keyflg = undefined
      formParam.value.requiredflg = undefined
      formParam.value.format = ''
      formParam.value.fmtcheck = ''
      formParam.value.fmtchange = ''
      formParam.value.datatype = ''
      formParam.value.len = undefined
      formParam.value.memo = ''
      formParam.value.itemnm = ''
    }
  })
}

//初期化処理
const init = () => {
  loading.value = true
  InitDetail({})
    .then((res) => {
      typeOptions.value = res.datatypeList
      fmtCheckOptions.value = res.fmtcheckList
      fmtChangeOptions.value = res.fmtchangeList
    })
    .finally(() => {
      loading.value = false
    })
}
//削除処理
const deleteItem = () => {
  showDeleteModal({
    onOk: async () => {
      emit('delete', formParam.value)
      formRef.value.clearValidate()
      emit('update:visible', false)
    }
  })
}
//データ型変更処理
const dataTypeChange = () => {
  formParam.value.len2 = undefined
  formParam.value.format = undefined
  formParam.value.formatName = undefined
  formParam.value.fmtcheck = undefined
  formParam.value.fmtcheckName = undefined
  formParam.value.fmtchange = undefined
  formParam.value.fmtchangeName = undefined
}
//フォーマット変更処理
const formatChange = () => {
  formParam.value.fmtcheck = undefined
  formParam.value.fmtcheckName = undefined
  formParam.value.fmtchange = undefined
  formParam.value.fmtchangeName = undefined
}
</script>
<style scoped>
:deep(.ant-form-item-with-help .ant-form-item-explain) {
  display: none;
}

:deep(.ant-form-item) {
  margin-bottom: 0 !important;
}
</style>
