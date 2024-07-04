<template>
  <a-modal
    v-model:visible="props.addVisible"
    title="項目登録"
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
                <th style="background-color: #ffffe1">テーブル名</th>
                <td>
                  {{ tableName }}
                </td>
              </tr>
              <tr>
                <th style="background-color: #ffffe1">レコード</th>
                <td>
                  {{ formParam.recno }}
                </td>
              </tr>
              <tr>
                <th style="background-color: #ffffe1">フィールド</th>
                <td>
                  {{ formParam.fieldnm }}
                </td>
              </tr>
              <tr>
                <th>処理区分<span class="request-mark">＊</span></th>
                <td>
                  <a-form-item name="syorikbn" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.syorikbn"
                      :options="options.divisionOptions"
                      style="width: 100%"
                      split-val
                      @change="divisionChange()"
                    ></ai-select>
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th>
                  データ元項目<span
                    v-if="formParam.syorikbn === Enum処理区分.画面項目登録.toString()"
                    class="request-mark"
                    >＊</span
                  >
                </th>
                <td>
                  <a-form-item name="pageitemseq" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.pageitemseq"
                      :options="options.pageitemseqOptions"
                      :disabled="formParam.syorikbn !== Enum処理区分.画面項目登録.toString()"
                      split-val
                    />
                  </a-form-item>
                </td>
              </tr>
              <tr>
                <th>
                  固定値
                  <span
                    v-if="formParam.syorikbn === Enum処理区分.固定値登録.toString()"
                    class="request-mark"
                    >＊</span
                  >
                </th>
                <td>
                  <a-form-item name="fixedval" style="width: 100%">
                    <a-input
                      v-model:value="formParam.fixedval"
                      style="width: 100%"
                      :disabled="formParam.syorikbn !== Enum処理区分.固定値登録.toString()"
                      :maxlength="100"
                    ></a-input
                  ></a-form-item>
                </td>
              </tr>
              <tr>
                <th>
                  データ元テーブル名<span
                    v-if="formParam.syorikbn === Enum処理区分.関連テーブルの項目から登録.toString()"
                    class="request-mark"
                    >＊</span
                  >
                </th>
                <td>
                  <a-form-item name="datamototablenm" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.datamototablenm"
                      style="width: 100%"
                      :maxlength="100"
                      split-val
                      :options="props.tableOptions"
                      :disabled="
                        formParam.syorikbn !== Enum処理区分.関連テーブルの項目から登録.toString()
                      "
                      @change="tableCahnge(formParam.datamototablenm)"
                    ></ai-select
                  ></a-form-item>
                </td>
              </tr>
              <tr>
                <th>
                  データ元フィールド<span
                    v-if="formParam.syorikbn === Enum処理区分.関連テーブルの項目から登録.toString()"
                    class="request-mark"
                    >＊</span
                  >
                </th>
                <td>
                  <a-form-item name="datamotofieldnm" style="width: 100%">
                    <ai-select
                      v-model:value="formParam.datamotofieldnm"
                      style="width: 100%"
                      split-val
                      :options="options.datamotofieldOptions"
                      :disabled="
                        formParam.syorikbn !== Enum処理区分.関連テーブルの項目から登録.toString()
                      "
                    ></ai-select
                  ></a-form-item>
                </td>
              </tr>
              <tr>
                <th>採番キー</th>
                <td>
                  <a-form-item name="saibankey" style="width: 100%">
                    <a-select
                      v-model:value="saibankeyList"
                      style="width: 100%"
                      split-val
                      mode="multiple"
                      :options="options.saibankeyOptions"
                      :disabled="formParam.syorikbn !== Enum処理区分.手動採番.toString()"
                      ><template #option="{ label, value }">
                        {{ value + ' : ' + label }}
                      </template></a-select
                    >
                  </a-form-item>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-form>
    </a-spin>
    <template #footer>
      <a-button type="primary" style="float: left" @click="add">設定</a-button>
      <a-button type="primary" style="float: left" @click="clear">クリア</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//項目移送
//---------------------------------------------------------------------------

import { ref, watch, computed, nextTick, reactive } from 'vue'
import { SelectProps } from 'ant-design-vue'
import { InsertDetailVM, PageItemVM } from '../AWKK00601G/type'
import { InitDetail, InitFieldid } from './service'
import { showConfirmModal } from '@/utils/modal'
import { CLEAR_CONFIRM } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { Enum処理区分 } from '#/Enums'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  addVisible: boolean
  index: number
  tableOptions: SelectProps['options']
  param?: InsertDetailVM
  pageitemList?: PageItemVM[]
}
const props = withDefaults(defineProps<Props>(), {
  addVisible: false
})
const emit = defineEmits(['update:addVisible', 'add', 'delete'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const editJudge = new Judgement()
const formParam = ref<InsertDetailVM>({
  tableid: '',
  recno: -1,
  fieldid: '',
  syorikbn: ''
})
//ローディング
const loading = ref(false)
const options = reactive({
  divisionOptions: [] as SelectProps['options'],
  pageitemseqOptions: [] as SelectProps['options'],
  datamotofieldOptions: [] as SelectProps['options'],
  saibankeyOptions: [] as SelectProps['options']
})
const activeKey = ref()
const formRef = ref()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tableName = computed(() => {
  let tableid = formParam.value.tableid
  return props.tableOptions?.find((option) => option.value === tableid)?.label
})

//チェック設定
const rules = computed(() => {
  let commonRules = {
    syorikbn: [
      {
        required: true,
        message: '項目名空白'
      }
    ]
  }

  if (formParam.value.syorikbn === Enum処理区分.画面項目登録.toString()) {
    commonRules['pageitemseq'] = [
      {
        required: true,
        message: 'データ元項目空白'
      }
    ]
  } else {
    commonRules['pageitemseq'] = []
  }

  if (formParam.value.syorikbn === Enum処理区分.固定値登録.toString()) {
    commonRules['fixedval'] = [
      {
        required: true,
        message: '固定値項目空白'
      }
    ]
  } else {
    commonRules['fixedval'] = []
  }
  if (formParam.value.syorikbn === Enum処理区分.関連テーブルの項目から登録.toString()) {
    commonRules['datamototablenm'] = [
      {
        required: true,
        message: ''
      }
    ]
    commonRules['datamotofieldnm'] = [
      {
        required: true,
        message: ''
      }
    ]
  } else {
    commonRules['datamototablenm'] = []
    commonRules['datamotofieldnm'] = []
  }

  return commonRules
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.addVisible,
  (newValue) => {
    if (newValue) {
      formParam.value = JSON.parse(JSON.stringify(props.param))
      init()
      nextTick(() => editJudge.reset())
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.tableid,
  (newValue) => {
    if (newValue) {
      init()
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.syorikbn,
  (newValue) => {
    if (newValue && newValue === Enum処理区分.手動採番.toString()) {
      InitFieldid({ tableid: formParam.value.tableid }).then((res) => {
        options.saibankeyOptions = res.fieldidList
      })
    }
  },
  { deep: true }
)

watch(formParam, () => editJudge.setEdited(), { deep: true })

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const saibankeyList = computed({
  get: () => {
    if (formParam.value.saibankey) {
      return formParam.value.saibankey.split(',')
    }
    return undefined
  },
  set: (value) => {
    if (Array.isArray(value)) {
      formParam.value.saibankey = value.join(',')
    } else if (typeof value === 'string') {
      formParam.value.saibankey = [value].join(',')
    } else {
      formParam.value.saibankey = undefined
    }
  }
})
//--------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//出力modal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    activeKey.value = '条件1'
    emit('update:addVisible', false)
  })
}
//登録処理
const add = () => {
  formRef.value.clearValidate()
  formRef.value.validate().then(() => {
    formParam.value.syorikbnName = options.divisionOptions?.find(
      (item) => item.value === formParam.value?.syorikbn
    )?.label
    formParam.value.pageitemseq = formParam.value?.pageitemseq
      ? parseInt(formParam.value?.pageitemseq?.toString()?.split(':')[0]?.trim())
      : undefined
    formParam.value.itemnm = options.pageitemseqOptions?.find(
      (item) => item.value === formParam.value?.pageitemseq + ''
    )?.label
    formParam.value.datamototableronrinm = props.tableOptions?.find(
      (item) => item.value === formParam.value?.datamototablenm + ''
    )?.label
    formParam.value.datamotofieldronrinm = options.datamotofieldOptions?.find(
      (item) => item.value === formParam.value?.datamotofieldnm + ''
    )?.label
    formParam.value.saibankeyronrinm =
      formParam.value.saibankey != undefined
        ? formParam.value.saibankey
            .split(',')
            .map((saibankey) => {
              const foundOption = options.saibankeyOptions?.find((item) => item.value === saibankey)
              return foundOption ? foundOption.label : ''
            })
            .join(',')
        : undefined
    emit('add', formParam.value)
    emit('update:addVisible', false)
  })
}

//クリア
const clear = () => {
  showConfirmModal({
    content: CLEAR_CONFIRM.Msg,
    onOk: () => {
      formParam.value.syorikbn = ''
      formParam.value.fixedval = ''
      formParam.value.pageitemseq = undefined
      formParam.value.datamototablenm = undefined
      formParam.value.datamotofieldnm = undefined
      formParam.value.saibankey = undefined
    }
  })
}

//初期化処理
const init = () => {
  loading.value = true
  let list = props.pageitemList
    ? props.pageitemList.map((item) => item.pageitemseq + ',' + item.itemnm)
    : []
  InitDetail({
    pageitemList: list
  })
    .then((res) => {
      options.divisionOptions = res.syorikbnList
      options.pageitemseqOptions = res.pageitemseqList
      if (
        formParam.value.pageitemseq != null &&
        options.pageitemseqOptions &&
        !options.pageitemseqOptions.find((e) => e.value == formParam.value.pageitemseq)
      ) {
        formParam.value.pageitemseq = undefined
      }
    })
    .finally(() => {
      loading.value = false
    })
  if (
    formParam.value.syorikbn === Enum処理区分.関連テーブルの項目から登録.toString() &&
    formParam.value.datamototablenm
  ) {
    InitFieldid({ tableid: formParam.value.datamototablenm }).then((res) => {
      options.datamotofieldOptions = res.fieldidList
    })
  }
}

//方法変更処理
const divisionChange = () => {
  formParam.value.pageitemseq = undefined
  formParam.value.fixedval = ''
  formParam.value.datamototablenm = undefined
  formParam.value.datamotofieldnm = undefined
  formParam.value.saibankey = undefined
}

const tableCahnge = (tableid) => {
  formParam.value.datamotofieldnm = ''
  if (tableid) {
    InitFieldid({ tableid }).then((res) => {
      options.datamotofieldOptions = res.fieldidList
    })
  }
}
</script>
<style scoped>
:deep(.ant-form-item-with-help .ant-form-item-explain) {
  display: none;
}
:deep(.ant-form-item) {
  margin-bottom: 0 !important;
}
.description-table th {
  width: 150px;
}
</style>
