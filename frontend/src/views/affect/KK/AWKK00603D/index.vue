<template>
  <a-modal
    v-model:visible="props.visible"
    title="マッピング設定"
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
        <div>画面項目</div>
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 120px; background-color: #ffffe1">項目No</th>
                <td>
                  {{ formParam.pageitemseq }}
                </td>
              </tr>
              <tr>
                <th style="width: 130px; background-color: #ffffe1">項目名</th>
                <td>
                  <a-form-item name="pageitemnm" style="width: 100%">
                    {{ formParam.pageitemnm }}
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 150px">マッピング区分<span class="request-mark">＊</span></th>
                <td>
                  <a-form-item name="mappingkbn" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.mappingkbn"
                      :options="divisionOptions"
                      split-val
                      @change="divisionChange(false)"
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th style="width: 110px">
                  マッピング方法<span
                    v-if="
                      formParam.mappingkbn &&
                      formParam.mappingkbn === Enumマッピング区分.関数.toString() &&
                      !(formParam.mappingkbn && formParam.mappingkbn?.indexOf('0') < 0)
                    "
                    class="request-mark"
                    >＊</span
                  >
                </th>
                <td>
                  <a-form-item name="mappingmethod" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.mappingmethod"
                      :options="methodOptions"
                      :disabled="
                        !formParam.mappingkbn ||
                        formParam.mappingkbn === Enumマッピング区分.マッピングなし.toString()
                      "
                      split-val
                      @change="methodChange"
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <template
                v-if="
                  formParam.mappingmethod &&
                  formParam.mappingkbn === Enumマッピング区分.関数.toString()
                "
              >
                <template v-for="(item, idx) of hikisuValList" :key="item">
                  <tr>
                    <th style="width: 110px">引数{{ idx + 1 }}</th>
                    <td style="display: flex; align-items: center">
                      <a-form-item style="width: 30%">
                        <ai-select
                          v-model:value="item.hikisutype"
                          :options="hikisukbnList"
                          :disabled="
                            !(
                              formParam.mappingkbn &&
                              formParam.mappingkbn?.indexOf(
                                Enumマッピング区分.マッピングなし.toString()
                              ) < 0
                            )
                          "
                          split-val
                          @change="item.hikisuvalue = ''"
                        ></ai-select>
                      </a-form-item>
                      <a-form-item
                        style="width: 70%"
                        :name="item.hikisutype === '1' ? 'fileitemseq' : ''"
                      >
                        <component
                          :is="item.hikisutype === '2' ? 'a-input' : 'ai-select'"
                          v-model:value="item.hikisuvalue"
                          :options="itemOptions"
                          allow-clear
                          maxlength="100"
                          :disabled="
                            !(
                              formParam.mappingkbn &&
                              formParam.mappingkbn?.indexOf(
                                Enumマッピング区分.マッピングなし.toString()
                              ) < 0
                            )
                          "
                        ></component>
                      </a-form-item>
                    </td>
                  </tr>
                </template>
              </template>
              <template v-else>
                <tr>
                  <th style="width: 110px">
                    ファイル項目<span
                      v-if="
                        formParam.mappingkbn &&
                        formParam.mappingkbn?.indexOf(
                          Enumマッピング区分.マッピングなし.toString()
                        ) < 0
                      "
                      class="request-mark"
                      >＊</span
                    >
                  </th>
                  <td>
                    <a-form-item name="fileitemseq" style="width: 100%">
                      <a-select
                        v-model:value="formParam.fileitemseq"
                        :options="itemOptions"
                        :disabled="
                          !(
                            formParam.mappingkbn &&
                            formParam.mappingkbn?.indexOf(
                              Enumマッピング区分.マッピングなし.toString()
                            ) < 0
                          )
                        "
                      ></a-select>
                    </a-form-item>
                  </td>
                </tr>
              </template>
              <tr>
                <th style="width: 110px">
                  桁数指定<span
                    v-if="
                      formParam.mappingmethod &&
                      formParam.mappingmethod === Enumマッピング方法.桁数指定.toString() &&
                      formParam.mappingkbn &&
                      formParam.mappingkbn.indexOf(Enumマッピング区分.マッピングなし.toString()) < 0
                    "
                    class="request-mark"
                    >＊</span
                  >
                </th>
                <td style="display: flex">
                  <a-form-item name="substrfrom" style="width: 230px"
                    ><a-input
                      v-model:value="formParam.substrfrom"
                      :disabled="
                        !(
                          formParam.mappingmethod != undefined &&
                          formParam.mappingmethod?.indexOf(Enumマッピング方法.桁数指定.toString()) >
                            -1
                        )
                      "
                      type="number"
                      maxlength="3"
                      placeholder="開始桁数"
                  /></a-form-item>
                  <span style="width: 40px; text-align: center">～</span>
                  <a-form-item name="substrto" style="width: 230px">
                    <a-input
                      v-model:value="formParam.substrto"
                      :disabled="
                        !(
                          formParam.mappingmethod != undefined &&
                          formParam.mappingmethod?.indexOf(Enumマッピング方法.桁数指定.toString()) >
                            -1
                        )
                      "
                      type="number"
                      placeholder="終了桁数"
                    ></a-input>
                  </a-form-item>
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

import { SelectProps } from 'ant-design-vue'
import { ref, watch, nextTick } from 'vue'
import { ItemMappingVM, FileIFVM } from '../AWKK00601G/type'
import { InitDetail, InitMappingMethod } from './service'
import { Enum編集区分, Enumマッピング区分, Enumマッピング方法 } from '#/Enums'
import { showConfirmModal, showInfoModal } from '@/utils/modal'
import { CLEAR_CONFIRM, E001010 } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  index: number
  param?: ItemMappingVM
  editkbn: Enum編集区分
  fileitemList?: FileIFVM[]
}

const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'delete', 'update'])
//---------------------------------------------------------------------------
//データ定義(data(ref…))
//---------------------------------------------------------------------------
const formParam = ref<ItemMappingVM>({ pageitemnm: '', pageitemseq: -1 })
const editJudge = new Judgement()

const methodOptions = ref<SelectProps['options']>([])
const transferOptions = ref<SelectProps['options']>([])
const divisionOptions = ref<SelectProps['options']>([])
const itemOptions = ref<SelectProps['options']>([])
//ローディング
const loading = ref(false)
const baseRules = ref({
  pageitemnm: [
    {
      required: true,
      message: ''
    }
  ],
  mappingkbn: [
    {
      required: true,
      message: ''
    }
  ]
})
const rules = ref({
  pageitemnm: [
    {
      required: true,
      message: ''
    }
  ],
  mappingkbn: [
    {
      required: true,
      message: ''
    }
  ]
})
const formRef = ref()
const isinit = ref(true)
const hikisukbnList = ref<SelectProps['options']>([])
const hikisuValList = ref<
  {
    hikisutype: string
    hikisuvalue: string
  }[]
>([])
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      isinit.value = true
      formParam.value = JSON.parse(JSON.stringify(props.param))
      if (formParam.value.mappingkbn === Enumマッピング区分.関数.toString()) {
        hikisuValList.value = []
        let arr = formParam.value.fileitemseq?.split(',')
        let nameArr = formParam.value.fileitemseqName?.split(',')
        arr?.forEach((e, index) => {
          if (e.indexOf("'") > -1) {
            hikisuValList.value.push({ hikisutype: '2', hikisuvalue: e.replaceAll("'", '') })
          } else {
            const newValue = !e.includes(':') ? `${e} : ${nameArr?.[index]}` : e
            hikisuValList.value.push({ hikisutype: '1', hikisuvalue: newValue })
          }
        })
      }
      Init()
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.mappingkbn,
  (newValue) => {
    //フォームチェックのリセット
    rules.value = { ...baseRules.value }

    //マッピング区分が1（関数）
    if (newValue === Enumマッピング区分.関数.toString()) {
      rules.value['mappingmethod'] = [
        {
          required: true,
          message: ''
        }
      ]
      rules.value['fileitemseq'] = [
        {
          validator: async () => {
            let filteredList = hikisuValList.value.filter((item) => item.hikisutype == '1')
            for (let item of filteredList) {
              if (
                !item.hikisuvalue ||
                !itemOptions.value?.find((e) => e.value == item.hikisuvalue.split(' : ')[0])
              ) {
                return Promise.reject()
              } else {
                return Promise.resolve()
              }
            }
            return Promise.resolve()
          }
        }
      ]
    } else {
      hikisuValList.value = []
      rules.value['mappingmethod'] = []
    }
    if (isinit.value) {
      isinit.value = false
    }
    //マッピング区分が2 単一項目移送
    if (newValue === Enumマッピング区分.単一項目移送.toString()) {
      rules.value['fileitemseq'] = [
        {
          required: true,
          message: ''
        }
      ]
    }
  }
)
watch(
  () => formParam.value.mappingmethod,
  (newValue) => {
    //マッピング方法が桁数指定の場合、入力必須
    if (newValue && newValue.indexOf(Enumマッピング方法.桁数指定.toString()) > -1) {
      rules.value['substrfrom'] = [{ validator: validaSubStr }]
      rules.value['substrto'] = [{ validator: validaSubStr }]
    } else {
      nextTick(() => {
        rules.value['substrfrom'] = []
        rules.value['substrto'] = []
        formParam.value.substrfrom = undefined
        formParam.value.substrto = undefined
      })
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.substrfrom,
  (newValue) => {
    if (
      newValue != undefined &&
      newValue != null &&
      formParam.value.mappingmethod != undefined &&
      formParam.value.mappingmethod.indexOf(Enumマッピング方法.宛名番号取得.toString()) > -1
    ) {
      const newLen = Math.min(999, Math.max(1, Math.floor(newValue)))
      formParam.value.substrfrom = newLen
    }
  },
  { deep: true }
)

watch(
  () => formParam.value.substrto,
  (newValue) => {
    if (newValue != undefined && newValue != null) {
      const newLen = Math.min(999, Math.max(0, Math.floor(newValue)))
      formParam.value.substrto = newLen
    }
  },
  { deep: true }
)

watch(formParam, () => editJudge.setEdited(), { deep: true })
//--------------------------------------------------------------------------
//メソッド(methods)
//---------------------------------------------------------------------------
//出力modal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:visible', false)
    formRef.value.clearValidate()
  })
}
//登録処理
const add = () => {
  formRef.value.clearValidate()
  let temparr = hikisuValList.value.map((e) => {
    if (e.hikisutype == '2') {
      let value = ''
      value = "'" + e.hikisuvalue + "'"
      return value
    } else return e.hikisuvalue.split(':')[0].trim()
  })
  formParam.value.fileitemseq = temparr.join(',')
  //引数桁数チェック
  if (formParam.value.fileitemseq && formParam.value.fileitemseq.length > 100) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E001010.Msg.replace('{0}', '引数')
    })
    return
  }
  formRef.value.validate().then(() => {
    formParam.value.mappingkbnName = divisionOptions.value?.find(
      (item) => item.value === formParam.value?.mappingkbn
    )?.label
    formParam.value.mappingmethodName = methodOptions.value?.find(
      (item) => item.value === formParam.value?.mappingmethod
    )?.label
    formParam.value.cdchangekbn = formParam.value?.cdchangekbn
      ? parseInt(formParam.value?.cdchangekbn?.toString()?.split(':')[0]?.trim())
      : -1
    formParam.value.cdchangekbnName = transferOptions.value?.find(
      (item) => item.value === formParam.value?.cdchangekbn + ''
    )?.label

    formParam.value.fileitemseqName =
      temparr
        .map((e) => {
          if (e.indexOf("'") < 0) {
            e = itemOptions.value?.find((item) => item.value === e)?.label
          }
          return e
        })
        .join(',') ?? ''
    emit('update', formParam.value)
    emit('update:visible', false)
  })
}

//マッピング区分処理
const divisionChange = (isFirst) => {
  if (!isFirst) {
    rules.value['fileitemseq'] = []
    formParam.value.mappingmethod = ''
    formParam.value.mappingmethodName = ''
    formParam.value.fileitemseq = ''
    formParam.value.fileitemseqName = ''
    formParam.value.substrfrom = undefined
    formParam.value.substrto = undefined
  }
  loading.value = true
  InitMappingMethod({ mappingkbn: formParam.value.mappingkbn + '' })
    .then((res) => {
      methodOptions.value = res.mappingmethodList
    })
    .finally(() => {
      loading.value = false
    })
}
//マッピング方法処理
const methodChange = () => {
  formParam.value.mappingmethodName = methodOptions.value?.find(
    (item) => item.value === formParam.value?.mappingmethod
  )?.label
  if (
    formParam.value.mappingmethod &&
    formParam.value.mappingmethod.indexOf(Enumマッピング方法.桁数指定.toString()) < 0
  ) {
    let hinsu: string =
      methodOptions.value?.find((e) => e.value == formParam.value.mappingmethod)?.key ?? '0'
    hikisuValList.value = Array.from({ length: +hinsu }, () => ({
      hikisutype: '1',
      hikisuvalue: ''
    }))
  }
}

//クリア処理
const clear = () => {
  showConfirmModal({
    content: CLEAR_CONFIRM.Msg,
    onOk: () => {
      formParam.value.mappingmethod = ''
      formParam.value.mappingkbn = ''
      formParam.value.substrfrom = undefined
      formParam.value.substrto = undefined
      formParam.value.fileitemseq = undefined
      formParam.value.fileitemseqName = ''
    }
  })
}
//初期化処理
const Init = () => {
  loading.value = true
  let list = props.fileitemList
    ? props.fileitemList.map((item) => item.fileitemseq + ',' + item.itemnm)
    : []
  itemOptions.value = props.fileitemList
    ? props.fileitemList.map((item) => {
        return { label: item.itemnm, value: item.fileitemseq + '' }
      })
    : []
  InitDetail({
    mappingkbn: formParam.value.mappingkbn + '',
    fileitemList: list,
    editkbn: props.editkbn
  })
    .then((res) => {
      divisionOptions.value = res.mappingkbnList
      methodOptions.value = res.mappingmethodList
      transferOptions.value = res.fileitemseqList
      hikisukbnList.value = res.hikisukbnList
      if (props.index > -1) {
        divisionChange(true)
      }
    })
    .finally(() => {
      loading.value = false
      nextTick(() => editJudge.reset())
    })
}

const validaSubStr = async () => {
  if (
    formParam.value.mappingmethod &&
    formParam.value.mappingmethod.indexOf(Enumマッピング方法.桁数指定.toString()) > -1
  ) {
    if (!formParam.value.substrfrom || !formParam.value.substrto) {
      return Promise.reject()
    }
    //大小チェック：両方入力ありの場合、開始＜＝終了
    else if (formParam.value.substrfrom > formParam.value.substrto) {
      return Promise.reject()
    } else {
      const length = formParam.value.substrto - formParam.value.substrfrom + 1
      const checkLength = props.fileitemList?.find(
        (item) => item.fileitemseq == Number(formParam.value.fileitemseq)
      )?.len
      //他チェック：ファイルIFタブに設定した総桁数以下
      if (checkLength && checkLength < length) {
        return Promise.reject()
      }
    }
  }
  return Promise.resolve()
}
</script>
<style scoped>
:deep(.ant-form-item-with-help .ant-form-item-explain) {
  display: none;
}

:deep(.ant-form-item) {
  margin-bottom: 0 !important;
}

input:disabled::placeholder {
  color: transparent;
}
</style>
