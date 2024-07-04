<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 成人健（検）診対象者設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.31
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-modal
      v-model:visible="modalVisible"
      width="1000px"
      title="健（検）診対象者設定"
      :destroy-on-close="true"
      :closable="false"
      :mask-closable="false"
    >
      <CloseModalBtn @click="closeModal" />
      <div class="self_adaption_table w-56 mb-4">
        <a-row>
          <a-col span="24">
            <th class="w-25!">年度</th>
            <TD>{{ yearFormatter(nendo) }}</TD>
          </a-col>
        </a-row>
      </div>

      <div class="self_adaption_table" :class="{ form: canEdit && !row }">
        <a-row>
          <a-col span="14">
            <th class="required">検診種別</th>
            <td v-if="canEdit && !row">
              <a-form-item v-bind="validateInfos.jigyocd">
                <ai-select
                  v-model:value="formData.jigyocd"
                  :options="opts"
                  split-val
                  @change="onChangeOpt"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ getLabelByValue(formData.jigyocd, options.selectorlist1) }}</TD>
          </a-col>
          <a-col span="14">
            <th :class="keyoptions.length > 0 && 'required'">検査方法／内訳</th>
            <td v-if="canEdit && !row">
              <a-form-item v-bind="validateInfos.kensahohocd">
                <ai-select
                  v-model:value="formData.kensahohocd"
                  :options="keyoptions"
                  @change="onChangeKeyOpt"
                />
              </a-form-item>
            </td>
            <TD v-else>{{
              getLabelByValue(formData.kensahohocd, options.selectorlist2, formData.jigyocd)
            }}</TD>
          </a-col>
        </a-row>
      </div>

      <h3 class="font-bold mt-4">健（検）診対象者条件設定</h3>
      <div class="self_adaption_table" :class="{ form: canEdit }">
        <a-row>
          <a-col span="10">
            <th>性別</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.sex"
                :options="sexOptions"
                split-val
                :allow-clear="false"
              />
            </td>
            <TD v-else>{{ getLabelByValue(formData.sex, options.selectorlist3) || 'すべて' }}</TD>
          </a-col>
          <a-col span="20">
            <th class="required">年齢</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.age">
                <a-input v-model:value="formData.age" :maxlength="50" @change="onChangeAge" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.age }}</TD>
          </a-col>
          <a-col span="10">
            <th class="required">年齢計算基準日区分</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.kijunkbn">
                <ai-select
                  v-model:value="formData.kijunkbn"
                  :options="options.selectorlist4"
                  split-val
                  @change="clearValidate('kijunymd')"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ getLabelByValue(formData.kijunkbn, options.selectorlist4) }}</TD>
          </a-col>
          <a-col span="10">
            <th :class="kijunymdIsRequire && 'required'">基準日</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.kijunymd">
                <DateJp
                  v-model:value="formData.kijunymd"
                  class="w-full"
                  format="YYYY-MM-DD"
                  :disabled="!kijunymdIsRequire"
                />
              </a-form-item>
            </td>
            <TD v-else>{{
              formData.kijunymd ? getDateJpText(new Date(formData.kijunymd)) : ''
            }}</TD>
          </a-col>
          <a-col span="10">
            <th>保険区分</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.hokenkbn"
                :options="options.selectorlist5"
                split-val
              />
            </td>
            <TD v-else>{{ getLabelByValue(formData.hokenkbn, options.selectorlist5) }}</TD>
          </a-col>
          <a-col span="20">
            <th>特殊</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.tokusyu"
                :options="options.selectorlist6"
                split-val
              />
            </td>
            <TD v-else>{{ getLabelByValue(formData.tokusyu, options.selectorlist6) }}</TD>
          </a-col>
          <a-col span="24">
            <th>SQL</th>
            <td>
              <a-checkbox v-model:checked="sqlEditing" :disabled="!canEdit">SQL文編集</a-checkbox>
            </td>
          </a-col>
          <a-col span="24">
            <th style="border-top: none">　</th>
            <td v-if="canEdit">
              <a-textarea
                v-model:value="formData.sql"
                :auto-size="{ minRows: 5 }"
                :maxlength="2000"
                :disabled="!sqlEditing"
              ></a-textarea>
            </td>
            <td v-else class="textarea">{{ formData.sql }}</td>
          </a-col>
        </a-row>
      </div>

      <template #footer>
        <a-button type="primary" class="float-left" :disabled="!canEdit" @click="handleSet"
          >設定</a-button
        >
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </template>
    </a-modal>
  </div>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { ITEM_ILLEGAL_ERROR, ITEM_REQUIRE_ERROR, ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import {
  getDateJpText,
  getLabelByValue,
  yearFormatter,
  formatRangeNumFull2Half
} from '@/utils/util'
import { Form, message } from 'ant-design-vue'
import { computed, inject, nextTick, reactive, ref, toRef, watch } from 'vue'
import { useRoute } from 'vue-router'
import { ItemVM, OptionsVM } from '../type'
import { Enum年齢基準日区分 } from '#/Enums'
import { useLinkOption } from '@/utils/hooks'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  tableData: ItemVM[]
  row: ItemVM | null
  options: OptionsVM
  disabled?: boolean
}>()
const emit = defineEmits<{
  setRow: [row: ItemVM]
  'update:visible': [visible: boolean]
}>()
const nendo = inject<number>('nendo', 0)
const selectorlist1 = ref<DaSelectorModel[]>([])
const selectorlist2 = ref<DaSelectorKeyModel[]>([])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const editJudge = new Judgement()

const createDefaultForm = (): ItemVM => ({
  jigyocd: '',
  kensahohocd: undefined,
  sex: '',
  age: '',
  kijunkbn: '',
  kijunymd: '',
  hokenkbn: '',
  tokusyu: '',
  sql: ''
})
const formData = reactive<ItemVM>(createDefaultForm())

const sqlEditing = ref(false)

//ドロップダウンリスト連動処理
const {
  keyoptions,
  options: opts,
  onChangeKeyOpt,
  onChangeOpt
} = useLinkOption(
  selectorlist2,
  selectorlist1,
  toRef(formData, 'kensahohocd'),
  toRef(formData, 'jigyocd')
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

//性別一覧
const sexOptions = computed(() => {
  return [{ label: 'すべて', value: '' }, ...props.options.selectorlist3]
})

//操作権限フラグ
const canEdit = computed(() => (route.meta.updflg && !props.disabled) || !props.row)

//年齢基準日区分が「指定日」の場合、年齢計算基準日必須入力
const kijunymdIsRequire = computed(() => formData.kijunkbn === String(Enum年齢基準日区分.指定日))
//項目の設定
const rules = computed(() => ({
  jigyocd: [
    { required: !props.row, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '検診種別') }
  ],
  kensahohocd: [
    {
      required: !props.row && keyoptions.value.length > 0,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '検査方法／内訳')
    }
  ],
  age: [
    {
      validator: (_, value) => {
        if (!value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年齢'))
        } else if (!/^(0|[1-9]\d*)(-(0|[1-9]\d*))?(,(0|[1-9]\d*)(-(0|[1-9]\d*))?)*$/.test(value)) {
          return Promise.reject(ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '年齢'))
        } else {
          // -の数値比較
          const parts = value.split(',')
          for (const part of parts) {
            if (part.includes('-')) {
              const [start, end] = part.split('-')
              if (Number(start) > Number(end)) {
                return Promise.reject(ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '年齢'))
              }
            }
          }
          return Promise.resolve()
        }
      }
    }
  ],
  kijunkbn: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '年齢計算基準日区分') }
  ],
  kijunymd: [
    {
      required: kijunymdIsRequire.value,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準日')
    }
  ],
  yoyakuchk: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '予約画面エラーチェック')
    }
  ],
  kensinchk: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '健（検）診画面エラーチェック')
    }
  ]
}))
const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())
watch(
  () => props.visible,
  (visible) => {
    if (visible) {
      selectorlist1.value = [...props.options.selectorlist1]
      selectorlist2.value = [...props.options.selectorlist2]
      Object.assign(formData, createDefaultForm())
      if (props.row) {
        Object.assign(formData, props.row)
      }
      nextTick(() => {
        clearValidate()
        editJudge.reset()
      })
    }
  }
)

watch(
  () => formData.jigyocd,
  () => validate('kensahohocd')
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//自動変換
function onChangeAge(e) {
  formData.age = formatRangeNumFull2Half(e.target.value)
}

//設定
async function handleSet() {
  await validate()
  //检查方法重複チェック
  const kensahohocd = formData.kensahohocd?.split(' : ')[0]

  const groupList = props.tableData.filter((item) => item.jigyocd === formData.jigyocd)
  const methodList = groupList.map((el) => el.kensahohocd)
  if (methodList.includes(kensahohocd) && kensahohocd !== props.row?.kensahohocd) {
    message.error('同一事業で同一名称の検査方法は1つしか登録できま') //todo:msg
    return
  }
  // if jigyocd is new => groupNo + 1
  const last_groupNo = props.tableData.at(-1)?.groupNo ?? -1
  const groupNo = groupList.length > 0 ? groupList[0].groupNo : last_groupNo + 1
  emit('setRow', {
    ...formData,
    kensahohocd,
    kijunymd: kijunymdIsRequire.value ? formData.kijunymd : '',
    groupNo
  })
  editJudge.reset()
  closeModal()
}

//取消処理
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    sqlEditing.value = false
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 170px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
