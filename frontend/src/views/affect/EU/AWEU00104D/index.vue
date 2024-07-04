<template>
  <a-modal
    :visible="props.visible"
    :title="sqlcolumn ? '項目編集' : '項目追加'"
    width="650px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <a-form :model="formData">
      <div class="self_adaption_table" :class="{ form: canEdit }">
        <a-row>
          <a-col v-bind="layout">
            <th class="required">テーブル</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.tablealias">
                <a-select
                  v-model:value="formData.tablealias"
                  :options="tablelistOptions"
                  :filter-option="filterOption"
                  :field-names="{ label: 'tablehyojinm', value: 'tablealias' }"
                  style="width: 100%"
                  allow-clear
                  show-search
                  @change="handleTableChange"
              /></a-form-item>
            </td>
            <TD v-else>{{ formData.tablealias }}</TD>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">項目ID</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.itemid">
                <a-input v-model:value="formData.itemid" allow-clear maxlength="60" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.itemid }}</TD>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">項目名</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.itemhyojinm">
                <a-input v-model:value="formData.itemhyojinm" maxlength="50" allow-clear />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.itemhyojinm }}</TD>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">SQLカラム</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.sqlcolumn">
                <a-textarea
                  v-model:value="formData.sqlcolumn"
                  :auto-size="{ minRows: 3 }"
                  allow-clear
                  maxlength="200"
                  @blur="onBlurSql"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.sqlcolumn }}</TD>
          </a-col>

          <a-col v-bind="layout">
            <th class="bg-readonly">関連テーブル</th>
            <TD>
              {{ formData.kanrentablealias }}
            </TD>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">大分類</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.daibunrui">
                <a-input v-model:value="formData.daibunrui" allow-clear maxlength="50" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.daibunrui }}</TD>
          </a-col>

          <a-col v-bind="layout">
            <th>中分類</th>
            <td v-if="canEdit">
              <a-input v-model:value="formData.tyubunrui" allow-clear maxlength="25" />
            </td>
            <TD v-else>{{ formData.tyubunrui }}</TD>
          </a-col>

          <a-col v-bind="layout">
            <th>小分類</th>
            <td v-if="canEdit">
              <a-input v-model:value="formData.syobunrui" allow-clear maxlength="25" />
            </td>
            <TD v-else>{{ formData.syobunrui }}</TD>
          </a-col>
        </a-row>
      </div>

      <div class="self_adaption_table form">
        <a-row>
          <a-col v-bind="layout">
            <th class="required">使用区分</th>
            <td>
              <a-form-item v-bind="validateInfos.usekbn">
                <a-select
                  v-model:value="formData.usekbn"
                  :options="usekbnOptions"
                  style="width: 100%"
                  allow-clear
                  @change="syukeikbnValidate"
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="isShowSyukeikbn" v-bind="layout">
            <th class="required">集計区分</th>
            <td>
              <a-form-item v-bind="validateInfos.syukeikbn">
                <a-select
                  v-model:value="formData.syukeikbn"
                  :options="syukeikbnOptions"
                  style="width: 100%"
                  allow-clear
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">データタイプ</th>
            <td>
              <a-form-item v-bind="validateInfos.datatype">
                <a-select
                  v-model:value="formData.datatype"
                  :options="dataTypeOptions"
                  style="width: 100%"
                  allow-clear
                ></a-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>
    <template #footer>
      <a-button style="float: left" class="warning-btn" :disabled="!updflg" @click="saveFiled"
        >登録</a-button
      >
      <a-button
        v-show="props.sqlcolumn"
        type="primary"
        danger
        style="float: left"
        :disabled="!updflg"
        @click="delFiled"
        >削除</a-button
      >
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted, watch, computed, nextTick } from 'vue'
import { useRoute } from 'vue-router'
import { SelectProps, message, Form } from 'ant-design-vue'
import { Rule } from 'ant-design-vue/lib/form'
import { Judgement } from '@/utils/judge-edited'
import { Enum使用区分 } from '#/Enums'
import {
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO,
  DELETE_OK_INFO,
  E001009,
  E001008
} from '@/constants/msg'
import { showSaveModal, showDeleteModal, showInfoModal } from '@/utils/modal'
import { Init, Search, Add, Update, Delete } from './service'
import { SaveRequest, TableVM } from './type'
import { layout } from './constants'
import TD from '@/components/Common/TableTD/index.vue'
import { Check } from '../AWEU00204D/service'
import { DatasourceTableVM } from '../AWEU00101G/type'
import { GlobalStore } from '@/store'

type formDataType = SaveRequest & {
  kanrentablealias: string
  upddttm: Date | string
  editflg: boolean
}

interface Props {
  visible: boolean
  sqlcolumn: string
  tableList: DatasourceTableVM[]
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})

const emit = defineEmits(['refresh', 'update:visible'])
const editJudge = new Judgement()

const route = useRoute()
const datasourceid = route.query.datasourceid as string
const updflg = route.meta.updflg //権限フラグ
const useForm = Form.useForm
const tableNamelist = ref<string[]>([])
const formData = reactive<formDataType>(createDefaultModel())

function createDefaultModel(): formDataType {
  return {
    oldsqlcolumn: '',
    datasourceid,
    tablealias: '', // テーブル別名
    itemid: '', // 項目ID
    itemhyojinm: '', // 表示名称
    sqlcolumn: '', //SQLカラム
    kanrentablealias: '', // 関連テーブル
    daibunrui: '', // 大分類
    tyubunrui: '', // 中分類
    syobunrui: '', // 小分類
    usekbn: undefined, //使用区分
    itemkbn: undefined, // 出力項目区分
    syukeikbn: undefined, // 集計項目区分
    datatype: undefined, //データ型
    upddttm: '',
    editflg: true,
    checkflg: false
  }
}
const canEdit = computed(() => formData.editflg)
const isShowSyukeikbn = computed(() =>
  [Enum使用区分.併用, Enum使用区分.集計項目].includes(Number(formData.usekbn))
)
// /^1\d{2}$/
const rules = reactive<Record<string, Rule[]>>({
  itemid: [
    {
      validator: (_rule, value) => {
        if (!value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '項目ID'))
        }
        if (!props.sqlcolumn && !/^(1)\d{2}_/.test(value)) {
          return Promise.reject(
            E001009.Msg.replace('{0}', '１先頭の３桁数字とアンダースコアで始まる名前')
          )
        }
        if (!/^\w+$/.test(value)) {
          return Promise.reject(E001009.Msg.replace('{0}', '半角英数字'))
        }
        return Promise.resolve()
      }
    }
  ],
  itemhyojinm: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '項目名')
    }
  ],
  sqlcolumn: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'SQLカラム')
    }
  ],
  usekbn: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '使用区分')
    }
  ],
  datatype: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'データタイプ')
    }
  ],
  tablealias: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'テーブル') }
  ],
  daibunrui: [
    {
      validator: (_rule, value) => {
        if (canEdit.value && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '大分類'))
        }
        return Promise.resolve()
      }
    }
  ],
  syukeikbn: [
    {
      validator: (_rule, value) => {
        if (isShowSyukeikbn.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '集計区分'))
        }
        return Promise.resolve()
      }
    }
  ]
})
const { validate, validateInfos, resetFields, clearValidate } = useForm(formData, rules)

const usekbnOptions = ref<SelectProps['options']>([])
const syukeikbnOptions = ref<SelectProps['options']>([])
const dataTypeOptions = ref<SelectProps['options']>([])
const tablelistOptions = ref<TableVM[]>([])

onMounted(() => {
  Init({ datasourceid }).then((res) => {
    tablelistOptions.value = res.tablelist.map((item) => ({
      ...item,
      tablehyojinm: item.tablealias + ' : ' + item.tablehyojinm
    }))
    //使用区分
    usekbnOptions.value = res.selectorlist1
    //集計区分
    syukeikbnOptions.value = res.selectorlist2
    //データタイプ
    dataTypeOptions.value = res.selectorlist3
    tableNamelist.value = res.tableNamelist
  })
})

watch(formData, () => editJudge.setEdited(), { deep: true })

watch(
  () => props.visible,
  (newValue) => {
    if (newValue && props.sqlcolumn) {
      Search({ datasourceid, sqlcolumn: props.sqlcolumn })
        .then((res) => {
          Object.assign(formData, {
            ...res,
            usekbn: String(res.usekbn),
            itemkbn: String(res.itemkbn),
            syukeikbn: res.syukeikbn ? String(res.syukeikbn) : null,
            datatype: String(res.datatype)
          })
        })
        .finally(() => {
          nextTick(() => editJudge.reset())
        })
    } else {
      resetFields()
      nextTick(() => editJudge.reset())
    }
  }
)

watch(
  () => formData.tablealias,
  (newValue) => {
    const item = tablelistOptions.value.find((item) => item.tablealias === newValue)
    formData.kanrentablealias = item?.kanrentablealias ?? ''
  }
)

// フィールドmodal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:visible', false)
  })
}

// // フィールド登録
const saveFiled = async () => {
  await validate()

  //項目IDチェック
  if (!props.sqlcolumn) {
    debugger
    if (
      props.tableList
        .flatMap((table) => table.itemlist.map((e) => e.itemid.substring(4)))
        .includes(formData.itemid.substring(4))
    ) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E001008.Msg.replace('{0}', `項目ID`)
      })
      return
    }
  }

  try {
    if (!props.sqlcolumn) {
      await Check({
        sqlcolumn: formData.sqlcolumn
      })
    }
  } catch (error) {
    console.log(error)
    return
  }
  const addOrUpdate = props.sqlcolumn ? Update : Add
  const params = { ...formData, oldsqlcolumn: props.sqlcolumn }
  const saveReq = async (checkflg: boolean) => {
    await addOrUpdate({
      ...params,
      checkflg
    })
  }
  await saveReq(true)
  showSaveModal({
    onOk: async () => {
      try {
        await saveReq(false)
        message.success(SAVE_OK_INFO.Msg)
        emit('update:visible', false)
        resetFields()
        emit('refresh', { expend: true })
      } catch (error) {}
    }
  })
}

// //削除フィールド
const delFiled = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({
          upddttm: formData.upddttm,
          datasourceid,
          sqlcolumn: props.sqlcolumn
        })
        message.success(DELETE_OK_INFO.Msg)
        emit('refresh', { expend: true })
        emit('update:visible', false)
      } catch (error) {}
    }
  })
}

const handleTableChange = () => {
  const item = tablelistOptions.value.find((item) => item.tablealias === formData.tablealias)

  formData.daibunrui = item?.tablehyojinm.split(' : ')[1] ?? ''
}
const syukeikbnValidate = () => {
  nextTick(() => {
    clearValidate()
  })
}
const onBlurSql = () => {
  const resultList: string[] = []
  const tableNamePositions = new Map<string, number>()
  tableNamelist.value.sort((a, b) => b.length - a.length)
  tableNamelist.value.forEach((tableName) => {
    const position = formData.sqlcolumn.indexOf(`${tableName}.`)
    if (position !== -1) {
      resultList.push(tableName)
      tableNamePositions.set(tableName, position)
    }
  })

  resultList.sort((a, b) => tableNamePositions.get(a)! - tableNamePositions.get(b)!)
  formData.kanrentablealias = resultList.join(',')
}

const filterOption = (input: string, option) => {
  return (
    option.tablehyojinm.toLowerCase().includes(input.toLowerCase()) ||
    option.tablealias.toLowerCase().includes(input.toLowerCase())
  )
}
</script>
<style lang="less" src="./index.less" scoped></style>
