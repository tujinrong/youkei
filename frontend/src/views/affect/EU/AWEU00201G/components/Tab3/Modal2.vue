<template>
  <a-modal
    v-model:visible="modalVisible"
    title="項目詳細"
    width="800px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <div class="self_adaption_table form">
      <a-row>
        <a-col span="24">
          <th class="bg-readonly">集計区分</th>
          <td class="textarea">
            {{ initCrosskbnName() }}
          </td></a-col
        >
        <a-col v-if="formData.crosskbn !== Enum集計区分.集計" span="24">
          <th class="required">レベル</th>
          <td>
            <a-form-item v-bind="validateInfos.level">
              <a-input-number v-model:value="formData.level" :max="3" :min="1" class="w-full" />
            </a-form-item>
          </td>
        </a-col>
        <a-col v-if="isDataDrProc" span="24">
          <th class="required">大分類</th>
          <td>
            <a-form-item v-bind="validateInfos.daibunrui">
              <a-select
                v-model:value="formData.daibunrui"
                :options="options_bunrui"
                :field-names="{ label: 'daibunrui', value: 'daibunrui' }"
                show-search
                :filter-option="filterOption"
                style="width: 100%"
                allow-clear
                @change="clearRestData"
              ></a-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col v-if="isDataDrProc" span="24">
          <th class="required">項目</th>
          <td>
            <a-form-item v-bind="validateInfos.yosikiitemid">
              <ai-select
                v-model:value="formData.yosikiitemid"
                :options="yosikiList"
                split-val
                allow-clear
                @change="onChangeItem"
              >
              </ai-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col
          v-if="
            yosikihouhou == Enum様式作成方法.プロシージャ && formData.crosskbn == Enum集計区分.集計
          "
          span="24"
        >
          <th class="required">項目区分</th>
          <td>
            <a-form-item v-bind="validateInfos.itemkbn">
              <ai-select
                v-model:value="formData.itemkbn"
                :options="transferToEnumOptions(options.selectorlist2)"
                split-val
                style="width: 100%"
                allow-clear
              ></ai-select
            ></a-form-item>
          </td>
        </a-col>
        <a-col
          v-if="
            yosikihouhou == Enum様式作成方法.プロシージャ && formData.crosskbn == Enum集計区分.集計
          "
          span="24"
        >
          <th
            :class="{
              required:
                yosikihouhou == Enum様式作成方法.プロシージャ &&
                formData.crosskbn == Enum集計区分.集計
            }"
          >
            集計方法
          </th>
          <td>
            <a-form-item v-bind="validateInfos.crosshoho">
              <a-select
                v-model:value="formData.crosshoho"
                :options="syukeikbnList"
                style="width: 100%"
                allow-clear
                @change="onChange"
              ></a-select
            ></a-form-item></td
        ></a-col>
        <a-col span="24">
          <th class="required">帳票項目名</th>
          <td>
            <a-form-item v-bind="validateInfos.reportitemnm">
              <div class="flex items-center gap-1">
                <a-input v-model:value="formData.reportitemnm" maxlength="50" />
              </div>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="bg-readonly">SQLカラム</th>
          <td class="textarea">
            {{ formData.sqlcolumn }}
          </td>
        </a-col>

        <template v-if="formData.crosskbn !== Enum集計区分.集計">
          <a-col span="24">
            <th
              :class="{
                required: crosskbn === Enum集計区分.GroupBy横 || crosskbn === Enum集計区分.GroupBy縦
              }"
            >
              コード区分
            </th>
            <td>
              <a-form-item v-bind="validateInfos.mastercd">
                <a-select
                  v-model:value="formData.mastercd"
                  :options="masteropts"
                  :field-names="{ label: 'masterhyojinm', value: 'mastercd' }"
                  style="width: 100%"
                  allow-clear
                  @change="onChangeMastercd"
                ></a-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col v-if="formData.mastercd === ''" span="24">
            <th
              :class="{
                required: crosskbn === Enum集計区分.GroupBy横 || crosskbn === Enum集計区分.GroupBy縦
              }"
            >
              コード名称
            </th>

            <td>
              <a-form-item v-for="item in jsonlist" :key="item">
                <div class="flex mb-1">
                  <a-input-group compact>
                    <a-input v-model:value="item.value" placeholder="値" style="width: 50%" />
                    <a-input v-model:value="item.label" placeholder="名称" style="width: 50%" />
                  </a-input-group>
                  <MinusCircleOutlined
                    v-if="jsonlist.length > 1"
                    class="dynamic-delete-button"
                    @click="removeDomain(item)"
                  />
                </div>
              </a-form-item>

              <a-button type="dashed" class="w-full" @click="addDomain">
                <PlusOutlined />
              </a-button>
            </td>
          </a-col>

          <a-col v-for="(item, index) in curCdlist" :key="item.columncomment" span="24">
            <th
              :class="{
                required: crosskbn === Enum集計区分.GroupBy横 || crosskbn === Enum集計区分.GroupBy縦
              }"
            >
              {{ item.columncomment }}
            </th>
            <td>
              <a-form-item v-bind="validateInfos[item.columnnm]">
                <ai-select
                  v-if="Number(item.codetype) === CodeTypeEnum.選択"
                  v-model:value="formData[item.columnnm]"
                  split-val
                  :options="
                    index > 0
                      ? item.selectorlist?.filter(
                          (i) => i.key === formData[curCdlist[index - 1].columnnm]
                        )
                      : item.selectorlist
                  "
                  @change="clearNextSelectValue(index)"
                ></ai-select>
                <a-input v-else v-model:value="formData[item.columnnm]"
              /></a-form-item>
            </td>
          </a-col>

          <a-col span="24">
            <th>小計</th>
            <td>
              <ai-select
                v-model:value="formData.kbn1"
                :options="options.selectorlist5"
                type="number"
              ></ai-select>
            </td>
          </a-col>
        </template>
      </a-row>
    </div>

    <template #footer>
      <a-space class="float-left">
        <a-button type="primary" @click="saveItem">確定</a-button>
        <a-button type="primary" danger :disabled="isNewItem" @click="deleteItem">削除</a-button>
      </a-space>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, ref, watch, reactive, nextTick, Ref } from 'vue'
import { message, Form } from 'ant-design-vue'
import {
  Enum並び替え,
  Enum出力項目区分,
  Enum集計区分,
  CodeTypeEnum,
  Enum様式作成方法,
  Enumコントロール,
  Enum集計項目区分,
  Enum小計区分
} from '#/Enums'
import { showDeleteModal, showInfoModal } from '@/utils/modal'
import { E001008, ITEM_SELECTREQUIRE_ERROR, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { ReportItemDetailVM } from '../../type'
import { InitResponse, MasterVM } from '@/views/affect/EU/AWEU00205D/type'
import { SearchStatistic } from '@/views/affect/EU/AWEU00204D/service'
import { BunruiItemVM } from '../../../AWEU00204D/type'
import { EUCStore, GlobalStore } from '@/store'
import { Judgement } from '@/utils/judge-edited'
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons-vue'
import { SearchJokenDetail } from '../../service'
import emitter from '@/utils/event-bus'
//---------------------------------------------------------------------------
//属性 標準項目
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  tableIndex: number
  tableList: ReportItemDetailVM[]
  otherTableList: ReportItemDetailVM[]
  options: Omit<InitResponse, keyof DaResponseBase>
  datasourceid: string
  itemids: string[]
  crosskbn: Enum集計区分
  yosikihouhou: Enum様式作成方法
  masteropts: MasterVM[]
  tab1Ref: Ref
  tab2Ref: Ref
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const editJudge = new Judgement()
const emit = defineEmits(['update:visible', 'update:tableList'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

function createDefaultForm() {
  return {
    kbn1: undefined,
    keyvaluepairsjson: undefined,
    mastercd: undefined,
    level: undefined,
    yosikiitemid: '',
    reportitemnm: '',
    csvitemnm: '',
    sqlcolumn: '',
    tablealias: '',
    orderkbn: Enum並び替え.無し,
    reportoutputflg: false,
    csvoutputflg: false,
    headerflg: false,
    kaipageflg: false,
    itemkbn: Enum出力項目区分.普通項目,
    crosskbn: undefined,
    daibunrui: undefined,
    crosshoho: '2'
  }
}
const formData = reactive<ReportItemDetailVM & { crosshoho: string }>(createDefaultForm())
const ADDON_TEXT = 'ft_'
const options_bunrui = ref<BunruiItemVM[]>([])
const syukeikbnList = ref<DaSelectorModel[]>([])
const oldsyukeikbnList = ref<DaSelectorModel[]>([])
//手入力コード名称
const jsonlist = ref<{ value: string; label: string }[]>([{ value: '', label: '' }])
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

watch(
  () => props.visible,
  async (newValue) => {
    if (newValue && props.tableIndex > -1) {
      const childItem = props.tableList[props.tableIndex]
      const list =
        props.masteropts.find((item) => item.mastercd === childItem.mastercd)?.cdlist ?? []
      const masterparaList = childItem.masterpara?.split(',') ?? []
      const data = {}
      list.forEach((item, index) => (data[item.columnnm] = masterparaList[index]))
      Object.assign(formData, { ...childItem, ...data })
    } else {
      formData.crosskbn = props.crosskbn
      formData.level =
        props.tableList.length > 0
          ? Math.max(...props.tableList.map((item) => item.level || 0)) + 1
          : 1
    }
    //分類リスト
    if (newValue) {
      let { procnm, sql } = props.tab1Ref.value.getFieldsValue()
      procnm = String(procnm).endsWith(ADDON_TEXT) ? '' : procnm
      const { bunruilist, syukeikbnlist } = await SearchStatistic({
        datasourceid: props.datasourceid,
        crosskbn: props.crosskbn,
        itemids: props.itemids,
        itemid: formData.yosikiitemid,
        procnm: procnm,
        sql: sql
      })
      options_bunrui.value = bunruilist
      oldsyukeikbnList.value = syukeikbnlist
      if (formData.daibunrui) {
        syukeikbnList.value =
          formData.daibunrui == '文字項目'
            ? oldsyukeikbnList.value.filter((e) => +e.value != Enum集計項目区分.Sum)
            : oldsyukeikbnList.value
      } else syukeikbnList.value = []
    }
    //手入力コード名称
    if (newValue && formData.keyvaluepairsjson) {
      formData.mastercd = ''
      jsonlist.value = formData.keyvaluepairsjson
        .split(';')
        .map((pair) => pair.trim().split(':'))
        .map(([value, label]) => ({ value, label }))
    }

    nextTick(() => {
      clearValidate()
      editJudge.reset()
    })
  }
)

//大分類
watch(
  () => formData.daibunrui,
  () => {
    if (formData.daibunrui == '文字項目') {
      syukeikbnList.value = oldsyukeikbnList.value.filter((e) => +e.value != Enum集計項目区分.Sum)
    } else {
      syukeikbnList.value = oldsyukeikbnList.value
    }
  }
)

watch(
  () => formData,
  () => {
    editJudge.setEdited()
  },
  { deep: true }
)

//並びシーケンス
watch(
  () => formData.orderkbn,
  () => {
    if (formData.orderkbn !== Enum並び替え.無し) {
      formData.orderseq = maxSortSeq.value + 1
    } else {
      formData.orderseq = undefined
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
const isNewItem = computed(
  () => props.tableIndex === -1 || props.tableIndex >= props.tableList.length
)
//最大ソート値
const maxSortSeq = computed(() => {
  if (props.tableList.length === 0) return 0
  const maxItem = props.tableList.reduce((max, cur) => {
    return Number(cur.orderseq) > Number(max.orderseq) ? cur : max
  })
  return maxItem.orderseq ?? 0
})

const curCdlist = computed(() => {
  return props.masteropts.find((item) => item.mastercd === formData.mastercd)?.cdlist ?? []
})
const rules = computed(() => {
  const staticRules = {
    level: [
      {
        required: props.crosskbn !== Enum集計区分.集計,
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'レベル')
      }
    ],
    daibunrui: [
      {
        required: true,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '大分類')
      }
    ],
    yosikiitemid: [
      {
        required: true,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '項目')
      }
    ],
    reportitemnm: [
      {
        required: true,
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票項目名')
      }
    ],
    mastercd: [
      {
        required:
          (props.crosskbn === Enum集計区分.GroupBy横 ||
            props.crosskbn === Enum集計区分.GroupBy縦) &&
          !(formData.mastercd === ''),
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'コード区分')
      }
    ],
    itemkbn: [
      {
        required: true,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '項目区分')
      }
    ],
    crosshoho: [
      {
        required:
          props.yosikihouhou == Enum様式作成方法.プロシージャ &&
          props.crosskbn == Enum集計区分.集計,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '集計方法')
      }
    ]
  }

  const dynamicRules = {}
  for (let i = 0; i < curCdlist.value.length; i++) {
    const item = curCdlist.value[i]
    dynamicRules[item.columnnm] = [
      {
        required:
          props.crosskbn === Enum集計区分.GroupBy横 || props.crosskbn === Enum集計区分.GroupBy縦,
        message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', item.columncomment)
      }
    ]
  }

  return { ...staticRules, ...dynamicRules }
})
const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)
const options_item = computed(
  () => options_bunrui.value?.find((opt) => opt.daibunrui === formData.daibunrui)?.itemlist ?? []
)
//項目ドロップリスト
const yosikiList = computed<DaSelectorModel[]>(
  () =>
    options_bunrui.value
      ?.find((opt) => opt.daibunrui === formData.daibunrui)
      ?.itemlist.map((item) => ({
        label: item.reportitemnm,
        value: item.yosikiitemid
      })) ?? []
)
const isDataDrProc = computed(() => {
  return [Enum様式作成方法.データソース, Enum様式作成方法.プロシージャ].includes(
    +props.yosikihouhou
  )
})
//集計方法
const syukeihoho = computed(() => {
  return options_item.value.find((item) => item.yosikiitemid === formData.yosikiitemid)?.syukeihoho
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//項目詳細削除
const deleteItem = () => {
  showDeleteModal({
    async onOk() {
      const array = JSON.parse(JSON.stringify(props.tableList))
      array.splice(props.tableIndex, 1)
      await processTableList(array, props.crosskbn)
      emit('update:tableList', array)
      editJudge.reset()
      closeModal()
    }
  })
}

//項目詳細登録処理
const saveItem = async () => {
  await validate()
  //コード名称必須、重複チェック
  if (formData.mastercd === '' && formData.crosskbn !== Enum集計区分.集計) {
    const arr = jsonlist.value.map((el) => el.value)
    if (arr.some((el) => !el)) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'コード名称の値')
      })
      return
    }
    if (new Set(arr).size !== arr.length) {
      showInfoModal({
        type: 'error',
        title: 'エラー',
        content: E001008.Msg.replace('{0}', 'コード名称の値')
      })
      return
    }
  }

  // 重複チェック
  if (checkDuplicate('level', 'レベル')) return
  if (checkDuplicate('yosikiitemid', '帳票項目ID')) return
  if (checkDuplicate('reportitemnm', '帳票項目名', true)) return

  // formDataのデータを整理し、更新または追加用に準備する
  const list = props.masteropts.find((item) => item.mastercd === formData.mastercd)?.cdlist ?? []
  const masterpara = list.map((item) => formData[item.columnnm])

  // 新しい項目を準備するか、データを更新する
  const newItemOrUpdatedItem = {
    ...formData,
    masterpara: masterpara.join(','),
    keyvaluepairsjson:
      formData.mastercd === ''
        ? jsonlist.value.map((item) => `${item.value}:${item.label}`).join('; ')
        : undefined,
    syukeihoho: syukeihoho.value
  }
  // 現在のtableListをコピーして変更する
  const updatedTableList = [...props.tableList]

  if (isNewItem.value) {
    // 新しい項目を追加する
    updatedTableList.push(newItemOrUpdatedItem)
  } else {
    // 既存の項目を更新する
    updatedTableList.splice(props.tableIndex, 1, newItemOrUpdatedItem)
  }
  // 親コンポーネントにデータの更新
  updatedTableList.sort((a, b) => {
    if (typeof a.level === 'undefined') return -1
    if (typeof b.level === 'undefined') return 1
    return a.level - b.level
  })
  //（行/列）個数
  await processTableList(updatedTableList, props.crosskbn)

  emit('update:tableList', updatedTableList)
  editJudge.reset()
  closeModal()
}

//項目詳細閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    Object.assign(formData, createDefaultForm())
    jsonlist.value = [{ value: '', label: '' }]
    emit('update:visible', false)
    nextTick(() => editJudge.reset())
  })
}

//コード名称
const removeDomain = (item) => {
  let index = jsonlist.value.indexOf(item)
  if (index !== -1) {
    jsonlist.value.splice(index, 1)
  }
}
const addDomain = () => {
  jsonlist.value.push({
    value: '',
    label: ''
  })
}

const onChangeItem = (_val) => {
  const opt = options_item.value.find((el) => el.yosikiitemid === _val)
  const newData = { ...opt, level: formData.level }
  Object.assign(formData, newData)
  if (!_val) {
    formData.reportitemnm = ''
    formData.sqlcolumn = ''
  }
  //帳票項目名
  addSuffix(syukeihoho.value || formData.crosshoho)
  //SQLカラム
  formData.sqlcolumn = getUpperSqlcolumn(syukeihoho.value, formData.sqlcolumn)
  //手入力
  jsonlist.value = [{ value: '', label: '' }]
  //コード区分自動入力
  const item = options_item.value.find((item) => item.yosikiitemid == formData.yosikiitemid)
  formData.mastercd = item?.mastercd
  const list = props.masteropts.find((item) => item.mastercd === formData.mastercd)?.cdlist ?? []
  list.forEach((el, index) => {
    formData[el.columnnm] = item?.masterpara?.split(',')[index]
  })

  if (props.yosikihouhou == Enum様式作成方法.プロシージャ) {
    onChange()
  }
  nextTick(() => clearValidate())
}

const onChangeMastercd = () => {
  jsonlist.value = [{ value: '', label: '' }]
  props.masteropts
    .find((item) => item.mastercd === formData.mastercd)
    ?.cdlist.forEach((item) => (formData[item.columnnm] = ''))
}

const getUpperSqlcolumn = (val, sqlcolumn: string) => {
  if (formData.crosskbn !== Enum集計区分.集計) return sqlcolumn
  if (Number(val) === Enum集計項目区分.Count) {
    if (!/^COUNT\(/i.test(sqlcolumn)) {
      return `COUNT(${sqlcolumn})`
    }
  } else if (Number(val) === Enum集計項目区分.Sum) {
    if (!/^SUM\(/i.test(sqlcolumn)) {
      return `SUM(${sqlcolumn})`
    }
  }
  return sqlcolumn
}

const checkDuplicate = (fieldcd, fieldnm, allflg?) => {
  const index = props.tableList.findIndex(
    (item, index) => item[fieldcd] === formData[fieldcd] && index !== props.tableIndex
  )
  if (index >= 0) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E001008.Msg.replace('{0}', fieldnm)
    })
    return true
  }
  if (
    allflg &&
    props.otherTableList.findIndex((item) => item[fieldcd] === formData[fieldcd]) >= 0
  ) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E001008.Msg.replace('{0}', fieldnm)
    })
    return true
  }
  return false
}
//帳票項目名初期値
const addSuffix = (val) => {
  if (formData.crosskbn !== Enum集計区分.集計) return
  let suffix = ''
  if (Number(val) == Enum集計項目区分.Count) {
    suffix = 'の件数'
  } else if (Number(val) == Enum集計項目区分.Sum) {
    suffix = 'の合計'
  }
  const suffixes = ['の件数', 'の合計']
  for (let suffix of suffixes) {
    if (formData.reportitemnm.endsWith(suffix)) {
      formData.reportitemnm = formData.reportitemnm.slice(0, -suffix.length)
    }
  }
  if (formData.crosskbn === Enum集計区分.集計) {
    formData.reportitemnm += formData.reportitemnm ? suffix : ''
  }
}
const clearRestData = () => {
  if (formData.crosskbn !== Enum集計区分.集計) {
    Object.assign(formData, {
      ...createDefaultForm(),
      level: formData.level,
      daibunrui: formData.daibunrui,
      crosskbn: props.crosskbn
    })
  } else {
    formData.reportitemnm = ''
    formData.yosikiitemid = ''
    formData.sqlcolumn = ''
  }
  nextTick(() => clearValidate())
}

const clearNextSelectValue = (index) => {
  for (let i = index + 1; i < curCdlist.value.length; i++) {
    formData[curCdlist.value[i].columnnm] = ''
  }
}

function transferToEnumOptions(opts: DaSelectorModel[]) {
  return opts.map((opt) => ({ label: opt.label, value: parseInt(opt.value) }))
}

//集計区分名称初期表示
const initCrosskbnName = () => {
  const value = transferToEnumOptions(props.options.selectorlist1)?.find(
    (e) => e.value == formData.crosskbn
  )?.value
  return value === Enum集計区分.GroupBy縦 ? '行' : value === Enum集計区分.GroupBy横 ? '列' : 'Σ値'
}

//集計方法
const onChange = () => {
  if (formData.crosskbn == Enum集計区分.集計)
    formData.sqlcolumn = getUpperSqlcolumn(formData.crosshoho, formData.sqlcolumn)
  addSuffix(formData.crosshoho)
}

const filterOption = (input: string, option) => {
  return option.daibunrui.toLowerCase().includes(input.toLowerCase())
}
//行列個数
async function processTableList(updatedTableList: any[], kbn: Enum集計区分) {
  let totalCount = 1
  if (kbn !== Enum集計区分.集計) {
    const counts: { count: number; syoukei: number }[] = []
    const promises = updatedTableList.map(async (el) => {
      if (el.mastercd) {
        const res = await SearchJokenDetail({
          controlkbn: Enumコントロール.選択,
          mastercd: el.mastercd,
          masterpara: el.masterpara
        })
        const currentCount = res.masterCount
        counts.push({ count: currentCount, syoukei: el.kbn1 ? 1 : 0 })
      } else {
        const currentCount = el.keyvaluepairsjson?.split(';').length ?? 1
        counts.push({ count: currentCount, syoukei: el.kbn1 ? 1 : 0 })
      }
    })
    await Promise.all(promises)
    const productOfCounts = counts.slice(1).reduce((acc, item) => {
      return acc * (item.count + item.syoukei)
    }, 1)
    totalCount = counts[0]?.count * productOfCounts + counts[0]?.syoukei
  }
  emitter.emit('rowOrColCount', { count: totalCount, kbn: kbn })
}
</script>
<style lang="less" scoped>
.ant-form-item {
  width: 100%;
  margin-bottom: 0px;
}
.self_adaption_table th {
  width: 150px;
}
.dynamic-delete-button {
  cursor: pointer;
  position: relative;
  top: 4px;
  font-size: 24px;
  color: #999;
  transition: all 0.3s;
  margin: 0 4px;
}
.dynamic-delete-button:hover {
  color: #777;
}
</style>
