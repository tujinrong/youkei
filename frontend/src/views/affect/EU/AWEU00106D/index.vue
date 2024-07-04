<template>
  <a-modal
    :visible="props.visible"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    width="650px"
    :title="title"
  >
    <!--    <a-spin :spinning="loading">-->
    <a-form ref="formRef" :model="form" :label-col="{ span: 6 }" :wrapper-col="{ span: 24 }">
      <div class="self_adaption_table form">
        <a-row>
          <a-col v-bind="layout">
            <th class="required">条件名</th>
            <td>
              <a-form-item v-bind="validateInfos.jyokenlabel">
                <a-input v-model:value="form.jyokenlabel" allow-clear maxlength="50"></a-input>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="title !== '固定条件'" v-bind="layout">
            <th class="required">条件区分</th>
            <td>
              <a-form-item v-bind="validateInfos.jyokenkbn">
                <a-select
                  v-model:value="form.jyokenkbn"
                  :options="selectorlistOptions"
                  allow-clear
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">大分類</th>
            <td>
              <a-form-item v-bind="validateInfos.daibunrui">
                <a-select
                  v-model:value="form.daibunrui"
                  :options="daibunruiOptions"
                  allow-clear
                  @change="form.sqlcolumn = ''"
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">項目</th>
            <td>
              <a-form-item v-bind="validateInfos.sqlcolumn">
                <a-select
                  v-model:value="form.sqlcolumn"
                  :options="sqlcolumnOptions"
                  :field-names="{ label: 'itemhyojinm', value: 'sqlcolumn' }"
                  style="width: 100%"
                  allow-clear
                  @change="handleChangeSqlcolumn"
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th class="bg-readonly">データタイプ</th>
            <td>
              <a-form-item v-bind="validateInfos.datatype">
                <a-input v-model:value="form.datatype" :disabled="true"></a-input>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th class="required">値</th>
            <td>
              <a-form-item v-bind="validateInfos.syokiti">
                <a-input
                  v-model:value="form.syokiti"
                  type="text"
                  allow-clear
                  maxlength="10"
                  @blur="handleValue"
                ></a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>SQL</th>
            <td>
              <a-textarea
                v-model:value="form.sql"
                :rows="4"
                maxlength="256"
                @change="handleSpace"
              />
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>
    <!--    </a-spin>-->
    <template #footer>
      <a-button
        style="float: left"
        class="warning-btn"
        type="primary"
        :disabled="!updflg"
        @click="saveData"
        >登録</a-button
      >
      <a-button
        v-show="form.jyokenid"
        style="float: left"
        type="primary"
        danger
        :disabled="!updflg"
        @click="del"
        >削除</a-button
      >
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, watch, computed, nextTick } from 'vue'
import { Form } from 'ant-design-vue'
import { message } from 'ant-design-vue'
import {
  DELETE_OK_INFO,
  SAVE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  E064008,
  ITEM_SELECTREQUIRE_ERROR
} from '@/constants/msg'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { ItemDaiBunruiVM } from '@/views/affect/EU/AWEU00106D/type'
import { Init, Add, Delete, Update, GetSql } from '@/views/affect/EU/AWEU00106D/service'
import { layout } from './constants'
import { useRoute } from 'vue-router'
import { GlobalStore } from '@/store'

interface Props {
  groupid: string
  // loading: boolean
  visible: boolean
  title?: string
}

const props = withDefaults(defineProps<Props>(), {
  title: '固定条件追加'
})

const emits = defineEmits(['update:visible', 'update:loading', 'getTableData'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
//ビューモデル
const form = reactive(createDefaultSaveModel())
function createDefaultSaveModel() {
  return {
    jyokenlabel: '', // 条件名
    daibunrui: '', // 大分類
    sqlcolumn: '', // 項目SEQ
    datatype: '', // データタイプ
    syokiti: '', // 値
    jyokenkbn: '', // 検索条件区分
    sql: '', // sql
    jyokenid: '', // id
    upddttm: ''
  }
}

const rules = reactive({
  jyokenlabel: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '条件名') }],
  daibunrui: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '大分類') }],
  sqlcolumn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '項目') }],
  jyokenkbn: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '検索条件区分') }
  ],
  syokiti: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '値')
    }
  ]
})

const { validate, validateInfos, resetFields } = Form.useForm(form, rules)

const itemdaibunruiOptions = ref<ItemDaiBunruiVM[]>([]) // 項目大分類リスト
const selectorlistOptions = ref<DaSelectorModel[]>([]) // 固定検索条件区分

//権限フラグ
const route = useRoute()
const updflg = route.meta.updflg

const daibunruiOptions = computed(() =>
  itemdaibunruiOptions.value.map((item) => ({ label: item.daibunrui, value: item.daibunrui }))
)

const sqlcolumnOptions = computed(
  () => itemdaibunruiOptions.value.find((item) => item.daibunrui === form.daibunrui)?.itemlist || []
)

watch(form, () => editJudge.setEdited())

watch(
  () => props.visible,
  (newValue) => {
    if (newValue && props.groupid) {
      Init({ datasourceid: String(props.groupid) }).then((res) => {
        itemdaibunruiOptions.value = res.itemdaibunruilist ?? []
        selectorlistOptions.value = res.selectorlist.filter((el) => el.label != '様式紐付け') ?? []
        nextTick(() => editJudge.reset())
      })
    } else {
      resetFields()
    }
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//登録処理
const saveData = async () => {
  await validate()
  const params = {
    ...form,
    datasourceid: String(props.groupid),
    jyokenid: Number(form.jyokenid),
    jyokenkbn: Number(form.jyokenkbn)
  }
  const addOrUpdate = form.jyokenid ? Update : Add
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
        editJudge.reset()
        message.success(SAVE_OK_INFO.Msg)
        closeModal()
        emits('getTableData')
        resetFields()
      } catch (error) {}
    }
  })
}

//削除処理
const del = () => {
  showDeleteModal({
    handleDB: true,
    async onOk() {
      try {
        await Delete({
          jyokenid: Number(form.jyokenid),
          upddttm: form.upddttm,
          datasourceid: String(props.groupid),
          jyokenkbn: form.jyokenkbn
        })
        message.success(DELETE_OK_INFO.Msg)
        editJudge.reset()
        closeModal()
        emits('getTableData')
      } catch (error) {}
    }
  })
}

const handleChangeSqlcolumn = () => {
  form.datatype =
    sqlcolumnOptions.value.find((item) => item.sqlcolumn === form.sqlcolumn)?.datatype || ''
  handleValue()
}

const handleValue = () => {
  if (form.sqlcolumn && form.syokiti && !form.sql) {
    GetSql({ sqlcolumn: form.sqlcolumn, value: form.syokiti }).then((res) => {
      form.sql = res.sql
    })
  }
}
//全角スペースは半角スペースヘ変更
const handleSpace = () => {
  form.sql = form.sql.replace(/\u3000/g, '\u0020')
}

//メインmodal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emits('update:visible', false)
  })
}

const setEdditModal = (val) => {
  Object.assign(form, val)
  nextTick(() => editJudge.reset())
}
defineExpose({
  setEddit: setEdditModal
})
</script>

<style scoped lang="less" src="./index.less"></style>
