<template>
  <a-modal
    :visible="props.visible"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    width="650px"
    :title="kensakuigai ? '検索条件以外項目' : '検索条件'"
  >
    <!--    <a-spin :spinning="loading">-->
    <a-form ref="formRef" :model="form">
      <div class="self_adaption_table form">
        <a-row>
          <a-col span="24">
            <th class="required">条件名</th>
            <td>
              <a-form-item v-bind="validateInfos.jyokenlabel">
                <a-input
                  v-model:value="form.jyokenlabel"
                  maxlength="50"
                  allow-clear
                  :disabled="form.shiyoFlg"
                  @blur="onBlurLabel"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="!isSql && !kensakuigai" span="24">
            <th class="required">大分類</th>
            <td>
              <a-form-item v-bind="validateInfos.daibunrui">
                <a-select
                  v-model:value="form.daibunrui"
                  :options="daibunruiOptions"
                  allow-clear
                  @change="handleDaibunrui"
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="!isSql && !kensakuigai" span="24">
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
          <a-col span="24">
            <th
              :class="[{ required: isSql || kensakuigai, 'bg-readonly': !isSql && !kensakuigai }]"
            >
              データタイプ
            </th>
            <td>
              <a-form-item v-bind="validateInfos.datatype">
                <ai-select
                  v-model:value="form.datatype"
                  :options="selectorlist1"
                  split-val
                  :disabled="!isSql && !kensakuigai"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>

          <a-col span="24">
            <th class="required">コントロール</th>
            <td>
              <a-form-item v-bind="validateInfos.controlkbn">
                <ai-select
                  v-model:value="form.controlkbn"
                  :options="controlOptions"
                  split-val
                  @change="onChangeControlkbn"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="Number(form.controlkbn) === Enumコントロール.年度" span="24">
            <th class="required">タイプ</th>
            <td>
              <a-form-item v-bind="validateInfos.toshi">
                <a-select
                  v-model:value="toshi"
                  :options="toshiOptions"
                  :field-names="{ label: 'nm', value: 'key' }"
                  style="width: 100%"
                  allow-clear
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <template
            v-if="
              [Enumコントロール.選択, Enumコントロール.複数選択].includes(Number(form.controlkbn))
            "
          >
            <a-col span="24">
              <th class="required">参照元</th>
              <td>
                <a-form-item v-bind="validateInfos.mastercd">
                  <a-select
                    v-model:value="form.mastercd"
                    style="width: 100%"
                    allow-clear
                    :options="masterlist"
                    :field-names="{ label: 'masterhyojinm', value: 'mastercd' }"
                    @change="onChangeMastercd"
                  ></a-select>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-if="form.mastercd == '999'" span="24">
              <th class="required">参照元SQL</th>
              <td>
                <a-form-item v-bind="validateInfos.sansyomotosql">
                  <a-textarea v-model:value="form.sansyomotosql" :rows="4" maxlength="256" />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-for="(item, index) in curCdlist" :key="item.columncomment" span="24">
              <th class="required">{{ item.columncomment }}</th>
              <td>
                <a-form-item v-bind="validateInfos[item.columnnm]">
                  <ai-select
                    v-if="Number(item.codetype) === CodeTypeEnum.選択"
                    v-model:value="form[item.columnnm]"
                    split-val
                    :options="
                      index > 0
                        ? item.selectorlist?.filter(
                            (i) => i.key === form[curCdlist[index - 1].columnnm]
                          )
                        : item.selectorlist
                    "
                    @change="clearNextSelectValue(index)"
                  ></ai-select>
                  <a-input v-else v-model:value="form[item.columnnm]" />
                </a-form-item>
              </td>
            </a-col>
          </template>
          <a-col
            v-if="Number(form.controlkbn) === Enumコントロール.文字入力 && !kensakuigai"
            span="24"
          >
            <th :class="{ required: Number(form.controlkbn) === Enumコントロール.文字入力 }">
              検索区分
            </th>
            <td>
              <a-form-item v-bind="validateInfos.aimaikbn">
                <ai-select
                  v-model:value="form.aimaikbn"
                  split-val
                  :options="aimaikbnLsit"
                  @change="onChangeAimaikbn"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>
              初期値{{
                [
                  Enumコントロール.数値範囲,
                  Enumコントロール.文字範囲,
                  Enumコントロール.日付範囲,
                  Enumコントロール.時間範囲
                ].includes(Number(form.controlkbn))
                  ? '（開始）'
                  : ''
              }}
            </th>
            <td
              v-if="
                [
                  Enumコントロール.日付範囲,
                  Enumコントロール.選択,
                  Enumコントロール.日付入力
                ].includes(Number(form.controlkbn))
              "
            >
              <ai-select
                v-model:value="form.syokiti"
                split-val
                allow-clear
                :options="syokitiSelectlist"
              ></ai-select>
            </td>
            <td v-else>
              <a-form-item v-bind="validateInfos.syokiti">
                <a-input v-model:value="form.syokiti" allow-clear></a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col v-if="!isSql && !kensakuigai" span="24">
            <th class="required">SQL</th>
            <td>
              <a-form-item v-bind="validateInfos.sql">
                <a-textarea v-model:value="form.sql" :rows="4" maxlength="256"
              /></a-form-item>
            </td>
          </a-col>
          <a-col v-if="isSql || kensakuigai" span="24">
            <th :class="isSql && !kensakuigai ? 'bg-readonly' : ''">変数名</th>
            <td>
              <a-input v-model:value="form.variables" :disabled="isSql && !kensakuigai" />
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>
    <!--    </a-spin>-->
    <template #footer>
      <a-button v-if="isSql || rptid" style="float: left" type="primary" @click="saveData">
        確定
      </a-button>
      <a-button v-else style="float: left" type="warn" :disabled="!updflg" @click="saveData">
        登録
      </a-button>
      <a-button
        v-show="routes.query.datasourceid && form.jyokenid"
        style="float: left"
        type="primary"
        danger
        :disabled="!updflg"
        @click="del"
        >削除</a-button
      >
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, watch, computed, nextTick, watchEffect } from 'vue'
import { useRoute } from 'vue-router'
import { ItemDaiBunruiVM } from '@/views/affect/EU/AWEU00105D/type'
import { Form, message } from 'ant-design-vue'
import { DefaultOptionType } from 'ant-design-vue/lib/select'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import {
  Enumコントロール,
  CodeTypeEnum,
  EnumDataType,
  Enum検索区分,
  Enum検索条件区分
} from '#/Enums'
import {
  DELETE_OK_INFO,
  SAVE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  E002003,
  E001010
} from '@/constants/msg'
import {
  Init,
  Add,
  Delete,
  Update,
  GetSql,
  SearchJokenDetail
} from '@/views/affect/EU/AWEU00105D/service'
import { InitConditionTab, CheckDataType } from '@/views/affect/EU/AWEU00201G/service'
import { MasterVM } from './type'
import { GlobalStore } from '@/store'

const props = defineProps<{
  visible: boolean
  groupid: string
  // loading: boolean
  rptid?: string // 帳票ID
  isSql?: boolean
  isEdit?: boolean
  itemLabel?: any[]
  kensakukbn?: number
  sqlAddJyoken?: Enum追加条件区分
}>()

const emits = defineEmits(['update:visible', 'update:loading', 'getTableData', 'emitItem'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const routes = useRoute()
const editJudge = new Judgement()
//ビューモデル
const form = reactive(createDefaultSaveModel())
function createDefaultSaveModel() {
  return {
    jyokenlabel: '', // 条件名
    daibunrui: '', // 大分類
    sqlcolumn: '', // SQLカラム
    datatype: '', // データタイプ
    controlkbn: '', // コントロール区分
    sql: '', // sql
    syokiti: '', //初期値
    jyokenid: '',
    mastercd: '',
    variables: '', // 変数名
    upddttm: '',
    shiyoFlg: false,
    //201
    masterpara: '',
    nendohanikbn: '',
    toshi: '',
    jyokenkbn: '',
    datasourceid: '',
    aimaikbn: '',
    sansyomotosql: ''
  }
}
enum Enum追加条件区分 {
  固定条件 = 1,
  追加条件
}
const controlOptions = ref<DefaultOptionType[]>([])
const itemdaibunruiOptions = ref<ItemDaiBunruiVM[]>([])
const masterlist = ref<Omit<MasterVM, 'manualflg'>[]>([])
const selectorlist1 = ref<DaSelectorModel[]>([])
const syokitiSelectlist = ref<DaSelectorModel[]>([])
const toshiOptions = ref<{ nmmaincd: string; nmsubcd: number; nmcd: string; nm: string }[]>([])
const aimaikbnLsit = ref<DaSelectorModel[]>([])
//権限フラグ
const route = useRoute()
const updflg = route.meta.updflg
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const daibunruiOptions = computed(() =>
  itemdaibunruiOptions.value.map((item) => ({ label: item.daibunrui, value: item.daibunrui }))
)
const kensakuigai = computed(() => props.kensakukbn === 2)
const sqlcolumnOptions = computed(
  () => itemdaibunruiOptions.value.find((item) => item.daibunrui === form.daibunrui)?.itemlist || []
)

const toshi = computed({
  get() {
    if (form.masterpara && form.nendohanikbn) {
      const el = toshiOptions.value.find((el) => el.nmcd == form.nendohanikbn)
      return el ? el.nm : ''
    } else {
      return ''
    }
  },
  set(val) {
    form.masterpara = val ? val.split(',')[0].replace('-', ',') : ''
    form.nendohanikbn = val ? val.split(',')[1] : ''
  }
})
const curCdlist = computed(() => {
  return masterlist.value.find((item) => item.mastercd === form.mastercd)?.cdlist ?? []
})
const rules = computed(() => {
  const staticRules = {
    jyokenlabel: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '条件名') }],
    daibunrui: [
      {
        required: !props.isSql && !kensakuigai.value,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '大分類')
      }
    ],
    sqlcolumn: [
      {
        required: !props.isSql && !kensakuigai.value,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '項目')
      }
    ],
    datatype: [
      {
        required: true,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'データタイプ')
      }
    ],
    controlkbn: [
      {
        required: true,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'コントロール')
      }
    ],
    toshi: [
      {
        required: +form.controlkbn === Enumコントロール.年度,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'タイプ')
      }
    ],
    mastercd: [
      {
        required: [Enumコントロール.選択, Enumコントロール.複数選択].includes(+form.controlkbn),
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '参照元')
      }
    ],
    aimaikbn: [
      {
        required: +form.controlkbn === Enumコントロール.文字入力 && !kensakuigai.value,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '検索区分')
      }
    ],
    sansyomotosql: [
      {
        required: form.mastercd == '999',
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '参照元SQL')
      }
    ],
    syokiti: [
      {
        validator: (_rule, value) => {
          if (
            ![Enumコントロール.日付範囲, Enumコントロール.選択, Enumコントロール.日付入力].includes(
              Number(form.controlkbn)
            ) &&
            value &&
            value.length > 20
          ) {
            return Promise.reject(E001010.Msg.replace('{0}', '20'))
          }
          return Promise.resolve()
        }
      }
    ],
    sql: [
      {
        required: !props.isSql && !kensakuigai.value,
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'SQL')
      }
    ]
  }
  const dynamicRules = {}
  for (let i = 0; i < curCdlist.value.length; i++) {
    const item = curCdlist.value[i]
    dynamicRules[item.columnnm] = [
      {
        required: true,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', item.columncomment)
      }
    ]
  }
  return { ...staticRules, ...dynamicRules }
})
const { validate, validateInfos, resetFields } = Form.useForm(form, rules)
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(form, () => editJudge.setEdited())
watch(toshi, (val) => (form.toshi = val))

watch(
  () => props.visible,
  async (newValue) => {
    if (!newValue) {
      Object.assign(form, createDefaultSaveModel())
    }

    if (newValue) {
      Init({ datasourceid: String(props.groupid) }).then((res) => {
        aimaikbnLsit.value = res.kensakukbnlist
        itemdaibunruiOptions.value = res.itemdaibunruilist ?? []
        toshiOptions.value =
          res.toshilist.map((el) => {
            return { ...el, key: el.nmmaincd + '-' + el.nmsubcd + ',' + el.nmcd }
          }) ?? []
      })
      nextTick(() => editJudge.reset())
    }
  }
)

watch(
  () => form.controlkbn,
  async () => {
    if ([Enumコントロール.日付範囲, Enumコントロール.日付入力].includes(Number(form.controlkbn))) {
      const controlkbn = Number(form.controlkbn)
      const searchParams = {
        controlkbn,
        mastercd: '',
        masterpara: ''
      }
      const res = await SearchJokenDetail(searchParams)
      syokitiSelectlist.value = res.selectlist ?? []
    }
  },
  { deep: true }
)
watch(
  () => form.mastercd,
  async (newMastercd) => {
    if (Number(form.controlkbn) === Enumコントロール.選択) {
      if (!form.mastercd) return
      watchEffect(async () => {
        const controlkbn = Number(form.controlkbn)
        const masterpara =
          masterlist.value
            .find((item) => item.mastercd === form.mastercd)
            ?.cdlist.map((item) => form[item.columnnm])
            .join(',') ?? ''
        if (masterpara.split(',')[0] && !masterpara.split(',')[1]) return
        const searchParams = {
          controlkbn,
          mastercd: form.mastercd,
          masterpara
        }
        const res = await SearchJokenDetail(searchParams)
        syokitiSelectlist.value = res.selectlist ?? []
      })
    }
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//変数名
function onBlurLabel() {
  if (
    (props.isSql && props.sqlAddJyoken === Enum追加条件区分.追加条件 && !kensakuigai.value) ||
    kensakuigai.value
  ) {
    form.variables = '@' + form.jyokenlabel
  }
}

//確定処理
const saveData = async () => {
  await validate()
  try {
    await CheckDataType({
      datatype: +form.datatype,
      controlkbn: +form.controlkbn,
      syokiti: form.syokiti,
      sqlcolumn: form.sql
    })
  } catch (error) {
    return
  }
  const list = masterlist.value.find((item) => item.mastercd === form.mastercd)?.cdlist ?? []
  const masterpara = list.map((item) => form[item.columnnm])
  const foundItem = itemdaibunruiOptions.value
    .flatMap((el) => el.itemlist)
    .find((item) => item.sqlcolumn == form.sqlcolumn)

  const params = {
    ...form,
    datasourceid: props.isSql || props.rptid ? form.datasourceid : String(props.groupid),
    controlkbn: Number(form.controlkbn),
    jyokenid: Number(form.jyokenid),
    rptid: props.rptid,
    mastercd: +form.controlkbn === Enumコントロール.年度 ? '111' : form.mastercd,
    masterpara: +form.controlkbn === Enumコントロール.年度 ? form.masterpara : masterpara.join(','),
    nendohanikbn: +form.controlkbn === Enumコントロール.年度 ? form.nendohanikbn : '',
    variables:
      props.isSql || kensakuigai.value ? form.variables : foundItem ? foundItem.itemid : null
  }
  //201検索条件-----------------------
  if (props.isSql || props.rptid) {
    if (
      props.itemLabel &&
      props.itemLabel.some(
        (el) => el.jyokenlabel == params.jyokenlabel && el.jyokenid != params.jyokenid
      )
    ) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E002003.Msg.replace('{0}', '検索条件名')
      })
      return
    }
    emits('emitItem', params, props.kensakukbn)
    editJudge.reset()
    closeModal()
    resetFields()
    return
  }
  //----------------------------------

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
          jyokenkbn: String(Enum検索条件区分.通常条件)
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
    sqlcolumnOptions.value
      .find((item) => item.sqlcolumn === form.sqlcolumn)
      ?.datatype.split(' : ')[0] || ''
  form.controlkbn = ''
  setSql()
}

const onChangeControlkbn = () => {
  form.mastercd = ''
  setSql()
  toshi.value = ''
  form.syokiti = ''
  form.aimaikbn = ''
  syokitiSelectlist.value = []
  if (+form.controlkbn === Enumコントロール.選択) {
    const item = itemdaibunruiOptions.value
      .find((el) => el.daibunrui === form.daibunrui)
      ?.itemlist.find((item) => item.sqlcolumn === form.sqlcolumn)
    form.mastercd = item?.mastercd ?? ''
    const list = masterlist.value.find((item) => item.mastercd === form.mastercd)?.cdlist ?? []
    list.forEach((el, index) => {
      form[el.columnnm] = item?.masterpara?.split(',')[index]
    })
  }
}

const setSql = () => {
  if (!props.isSql && form.sqlcolumn && form.controlkbn) {
    GetSql({ sqlcolumn: form.sqlcolumn, controlkbn: Number(form.controlkbn) }).then((res) => {
      form.sql = res.sql
    })
  }
}

const handleDaibunrui = () => {
  Object.assign(form, {
    sqlcolumn: '',
    datatype: '',
    controlkbn: '',
    sql: ''
  })
}

const clearNextSelectValue = (index) => {
  for (let i = index + 1; i < curCdlist.value.length; i++) {
    form[curCdlist.value[i].columnnm] = ''
  }
  form.syokiti = ''
  syokitiSelectlist.value = []
}

const onChangeMastercd = () => {
  masterlist.value
    .find((item) => item.mastercd === form.mastercd)
    ?.cdlist.forEach((item) => (form[item.columnnm] = ''))
  form.syokiti = ''
  form.sansyomotosql = ''
  syokitiSelectlist.value = []
}
const onChangeAimaikbn = () => {
  if (form.sqlcolumn && +form.controlkbn == Enumコントロール.文字入力) {
    form.sql = [Enum検索区分.部分一致_中間一致, Enum検索区分.部分一致_前方一致].includes(
      +form.aimaikbn
    )
      ? form.sql.replace(/=/g, 'LIKE')
      : form.sql.replace(/like/gi, '=')
  }
}
//メインmodal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emits('update:visible', false)
    resetForm()
    Object.assign(form, createDefaultSaveModel())
    resetFields()
    nextTick(() => editJudge.reset())
  })
}
function resetForm() {
  const defaultModel = createDefaultSaveModel()
  for (const key in form) {
    if (key in defaultModel) {
      form[key] = defaultModel[key]
    } else {
      delete form[key]
    }
  }
}

const setEdditModal = (val?) => {
  Object.assign(form, val)
  InitConditionTab().then((res) => {
    selectorlist1.value = res.selectorlist1 ?? []
    controlOptions.value = res.selectorlist2 ?? []
    masterlist.value = res.masterlist
    const masterparaArr = form.masterpara.split(',')
    curCdlist.value.forEach((el, index) => {
      form[el.columnnm] = masterparaArr[index]
    })
    nextTick(() => editJudge.reset())
  })
}
defineExpose({
  setEddit: setEdditModal
})
</script>

<style scoped lang="less" src="./index.less"></style>
