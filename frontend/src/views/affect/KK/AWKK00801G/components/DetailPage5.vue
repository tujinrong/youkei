<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 拡張事業・保健・集団指導項目詳細
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef">
      <div class="self_adaption_table mb-4">
        <a-row>
          <a-col :sm="12" :xxl="6">
            <th>指導区分</th>
            <TD>{{ header?.sidokbnnm }}</TD>
          </a-col>
          <a-col :sm="12" :xxl="6">
            <th>業務区分</th>
            <TD>{{ header?.gyomukbnnm }}</TD>
          </a-col>
          <a-col :sm="12" :xxl="6">
            <th>申込結果</th>
            <TD>{{ header?.mosikomikekkakbnnm }}</TD>
          </a-col>
          <a-col v-if="sidoParams.sidokbn == Enum指導区分.集団指導" :sm="12" :xxl="6">
            <th>項目用途区分</th>
            <TD>{{ header?.itemyotokbnnm }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="saveData">登録</a-button>
          <a-button type="primary" :disabled="!canDelete" danger @click="deleteData">削除</a-button>
          <a-button type="primary" @click="back2list(C001010.Msg)">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="my-2" :style="{ 'min-height': tableHeight + 'px' }">
      <h4 class="font-bold">フリー項目設定</h4>
      <div class="self_adaption_table" :class="{ form: canEdit }">
        <a-row>
          <a-col :md="17" :xl="14">
            <th>設定項目</th>
            <TD :class="canEdit ? 'bg-editable' : 'bg-readonly'">設定值</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD class="bg-readonly">補足説明</TD></a-col>

          <a-col :md="17" :xl="14">
            <th class="bg-readonly">項目コード</th>
            <TD>{{ form.itemcd }}</TD>
          </a-col>
          <a-col :md="7" :xl="10">
            <TD
              >自動採番（先頭3001固定＋指導区分・業務区分・申込結果{{
                header?.itemyotokbnnm ? '・用途区分' : ''
              }}ごとの連番＋001）</TD
            >
          </a-col>

          <a-col :md="17" :xl="14">
            <th class="required">項目名</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.itemnm">
                <a-input v-model:value="form.itemnm" :maxlength="100"></a-input>
              </a-form-item>
            </td>
            <TD v-else class="p-0!">{{ form.itemnm }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>項目名を入力してください</TD></a-col>

          <a-col :md="17" :xl="14" :class="!isNew && 'readonly'">
            <th>グループID</th>
            <td v-if="isNew">
              <ai-select v-model:value="form.group" :options="options.selectorlist1"></ai-select>
            </td>
            <TD v-else>{{ form.group }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>フリー項目の左フィルタの分類を指定してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>グループID2</th>
            <td v-if="canEdit">
              <ai-select v-model:value="form.group2" :options="options.selectorlist2"></ai-select>
            </td>
            <TD v-else>{{ form.group2 }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>フリー項目の右フィルタの分類を指定してください</TD></a-col>

          <a-col :md="17" :xl="14" :class="!isNew && 'readonly'">
            <th class="required">入力タイプ</th>
            <td v-if="isNew">
              <a-form-item v-bind="validateInfos.inputtype">
                <ai-select
                  v-model:value="form.inputtype"
                  :options="options.selectorlist4"
                  @change="onChangeInputtype"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ form.inputtype }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>入力タイプを選択してください</TD></a-col>

          <a-col :md="17" :xl="14" :class="!isNew && 'readonly'">
            <th>コード</th>
            <td v-if="isNew">
              <ai-select
                v-model:value="form.codejoken1"
                :options="options.selectorlist5"
                :disabled="!options.selectorlist5?.length"
                class="w-1/3!"
                @change="onChangeCodejoken1"
              ></ai-select>
              <ai-select
                v-model:value="form.codejoken2"
                :options="options.selectorlist6"
                :disabled="!options.selectorlist6?.length"
                class="w-1/3!"
                @change="onChangeCodejoken2"
              ></ai-select>
              <ai-select
                v-model:value="form.codejoken3"
                :options="options.selectorlist7"
                :disabled="!options.selectorlist7?.length"
                class="w-1/3!"
              ></ai-select>
            </td>
            <td v-else class="textarea">
              {{ [form.codejoken1, form.codejoken2, form.codejoken3].filter(Boolean).join(' , ') }}
            </td>
          </a-col>
          <a-col :md="7" :xl="10">
            <TD>入力タイプがコードのとき、汎用マスタにコードを追加してください</TD>
          </a-col>

          <a-col :md="17" :xl="14">
            <th>入力桁</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.keta">
                <a-input
                  v-model:value="form.keta"
                  :maxlength="10"
                  :disabled="
                    ![
                      Enum入力タイプ.数値_整数,
                      Enum入力タイプ.数値_小数点付き実数,
                      Enum入力タイプ.数値_符号付き整数,
                      Enum入力タイプ.半角文字_半角数字,
                      Enum入力タイプ.半角文字_半角英数字,
                      Enum入力タイプ.全角文字_全角_改行不可
                    ].includes(Number(form.inputtype?.split(' : ')?.[0]))
                  "
                  @change="replaceKeta"
                ></a-input>
              </a-form-item>
            </td>
            <TD v-else>{{ form.keta }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"
            ><TD
              >例1）10桁の場合：10、
              例2）「2:数値（小数点付き実数）」で、整数部5桁、小数部2桁:　5,2</TD
            ></a-col
          >

          <a-col :md="17" :xl="14">
            <th>必須フラグ</th>
            <td>
              <a-checkbox v-model:checked="form.hissuflg" :disabled="!canEdit" class="ml-2" />
            </td>
          </a-col>
          <a-col :md="7" :xl="10"><TD>必須項目の場合、チェックを付与</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>入力範囲（開始）</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.hanif">
                <InputRange v-model:value="form.hanif" :inputtype="+getCode(form.inputtype)" />
              </a-form-item>
            </td>
            <TD v-else>{{ form.hanif }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>入力範囲（開始）を指定してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>入力範囲（終了）</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.hanit">
                <InputRange v-model:value="form.hanit" :inputtype="+getCode(form.inputtype)" />
              </a-form-item>
            </td>
            <TD v-else>{{ form.hanit }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>入力範囲（終了）を指定してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>入力フラグ</th>
            <td>
              <a-checkbox v-model:checked="form.inputflg" :disabled="!canEdit" class="ml-2" />
            </td>
          </a-col>
          <a-col :md="7" :xl="10">
            <TD>入力項目の場合、チェックを付与（表示項目の場合、チェックしないでください）</TD>
          </a-col>

          <a-col :md="17" :xl="14" :class="!isNew && 'readonly'">
            <th class="required">メッセージ区分</th>
            <td v-if="isNew">
              <a-form-item v-bind="validateInfos.msgkbn">
                <ai-select v-model:value="form.msgkbn" :options="options.selectorlist3"></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ form.msgkbn }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"
            ><TD>入力値がエラーの場合、メッセージの区分を選択してください</TD></a-col
          >

          <a-col :md="17" :xl="14">
            <th>単位</th>
            <td v-if="canEdit">
              <a-input v-model:value="form.tani" :maxlength="100"></a-input>
            </td>
            <TD v-else>{{ form.tani }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>単位を入力してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>初期値</th>
            <td v-if="canEdit">
              <a-textarea v-model:value="form.syokiti" :maxlength="1000" auto-size></a-textarea>
            </td>
            <td v-else class="textarea">{{ form.syokiti }}</td>
          </a-col>
          <a-col :md="7" :xl="10"><TD>初期値を入力してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>項目特定区分</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="form.komokutokuteikbn"
                :options="options.selectorlist9"
              ></ai-select>
            </td>
            <TD v-else>{{ form.komokutokuteikbn }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>特定の項目である場合、選択してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>利用地域保健集計区分</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.syukeikbns">
                <a-select
                  v-model:value="form.syukeikbns"
                  mode="multiple"
                  :filter-option="filterOption"
                  :options="options.selectorlist8"
                  :disabled="sidoParams.mosikomikekkakbn == Enum申込結果.申込"
                >
                  <template #option="{ label, value }">
                    {{ value + ' : ' + label }}
                  </template>
                </a-select>
              </a-form-item>
            </td>
            <TD v-else>{{ form.syukeikbns.join('、') }}</TD>
          </a-col>
          <a-col :md="7" :xl="10"><TD>利用地域保健集計区分を入力してください</TD></a-col>

          <a-col :md="17" :xl="14">
            <th>備考</th>
            <td v-if="canEdit">
              <a-textarea v-model:value="form.biko" :maxlength="1000" auto-size></a-textarea>
            </td>
            <td v-else class="textarea">{{ form.biko }}</td>
          </a-col>
          <a-col :md="7" :xl="10"><TD>備考を入力してください</TD></a-col>
        </a-row>
      </div>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
import { Enum入力タイプ, Enum指導区分, Enum申込結果, Enum編集区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import {
  C001010,
  DELETE_OK_INFO,
  ITEM_ILLEGAL_ERROR,
  ITEM_RANGE_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { editStore1 } from '@/store'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { filterOption } from '@/utils/util'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import {
  DeleteSidoItemDetail,
  GetCodejokenList,
  InitSidoItemDetail,
  SaveSidoItemDetail
} from '../service'
import { sidoParams } from '../store'
import {
  InitSidoItemDetailResponse,
  SidoCommonHeaderVM,
  SidoCommonRequest,
  SidoItemDetailVM
} from '../type'
import dayjs from 'dayjs'
import InputRange from './DetailPage2/InputRange.vue'
import { useTableHeight } from '@/utils/hooks'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
type OptionsVM = Omit<
  InitSidoItemDetailResponse,
  keyof DaResponseBase | 'headerinfo' | 'detailinfo'
>
const props = defineProps<{
  /**タイプ入力上限値フラグ */
  limitflgs: {
    halfflg: boolean
    dayflg: boolean
    fullflg: boolean
    cdflg: boolean
  }
}>()

const emit = defineEmits(['afterSave'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const itemCd = String(route.query.itemcd)
const isCopy = Boolean(route.query.iscopy)
const isNew = Number(itemCd) < 0 || isCopy
const { editJudge } = editStore1

const header = ref<SidoCommonHeaderVM>()
const form = reactive<SidoItemDetailVM>({
  syukeikbns: [],
  itemnm: '',
  inputtype: '',
  hissuflg: false,
  hanif: '',
  hanit: '',
  inputflg: false,
  msgkbn: '',
  tani: '',
  syokiti: '',
  komokutokuteikbn: '',
  biko: ''
})

const options = ref<OptionsVM>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  selectorlist6: [],
  selectorlist7: [],
  selectorlist8: [],
  selectorlist9: []
})
//項目の設定
const rules = computed(() => ({
  itemnm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '項目名') }],
  inputtype: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '入力タイプ') }
  ],
  keta: [
    {
      pattern:
        form.inputtype?.split(' : ')?.[0] === String(Enum入力タイプ.数値_小数点付き実数)
          ? /^(?!0)\d+,(?!0)\d+$/
          : /^[1-9][0-9]*$/,
      message: ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '入力桁')
    }
  ],
  msgkbn: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'メッセージ区分') }
  ],
  hanif: [
    {
      validator: (_rule, value: number) => {
        if (value && form.hanit) {
          if (
            ([
              Enum入力タイプ.数値_整数,
              Enum入力タイプ.数値_小数点付き実数,
              Enum入力タイプ.数値_符号付き整数
            ].includes(+getCode(form.inputtype)) &&
              value > +form.hanit) ||
            ([(Enum入力タイプ.日付_年月日, Enum入力タイプ.日時_年月日時分秒)].includes(
              +getCode(form.inputtype)
            ) &&
              dayjs(value) > dayjs(form.hanit))
          ) {
            return Promise.reject(ITEM_RANGE_ERROR.Msg.replace('{0}', '入力範囲（開始）'))
          }
        }
        return Promise.resolve()
      }
    }
  ],
  hanit: [
    {
      validator: (_rule, value: number) => {
        if (value && form.hanif) {
          if (
            ([
              Enum入力タイプ.数値_整数,
              Enum入力タイプ.数値_小数点付き実数,
              Enum入力タイプ.数値_符号付き整数
            ].includes(+getCode(form.inputtype)) &&
              value < +form.hanif) ||
            ([(Enum入力タイプ.日付_年月日, Enum入力タイプ.日時_年月日時分秒)].includes(
              +getCode(form.inputtype)
            ) &&
              dayjs(value) < dayjs(form.hanif))
          ) {
            return Promise.reject(ITEM_RANGE_ERROR.Msg.replace('{0}', '入力範囲（終了）'))
          }
        }
        return Promise.resolve()
      }
    }
  ]
}))
const { validate, validateInfos, clearValidate } = Form.useForm(form, rules)

//操作権限フラグ
const canEdit = isNew || route.meta.updflg
const canDelete = !isNew && route.meta.delflg

let upddttm

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (!sidoParams.sidokbn) {
    back2list()
    return
  }
  searchData()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 64)

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(form, () => editJudge.setEdited())
//入力範囲check
watch(
  () => [form.hanif, form.hanit],
  () => validate(['hanif', 'hanit'])
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function getCode(value) {
  return value?.split(' : ')[0]
}
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitSidoItemDetail({
      ...(sidoParams as SidoCommonRequest),
      itemcd: isNew && !isCopy ? undefined : itemCd,
      editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
      copyflg: isCopy,
      ...props.limitflgs
    })
    header.value = res.headerinfo
    options.value = res
    res.detailinfo.syukeikbns ??= []
    Object.assign(form, res.detailinfo)
    upddttm = res.upddttm
  } catch (error) {}
  nextTick(() => {
    editJudge.reset()
    clearValidate()
  })
  loading.value = false
}

async function saveData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      try {
        await SaveSidoItemDetail({
          ...(sidoParams as SidoCommonRequest),
          itemcd: isNew ? '' : itemCd,
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
          detailinfo: form,
          upddttm
        })
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        emit('afterSave')
        back2list()
      } catch (error) {}
    }
  })
}
//削除処理
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await DeleteSidoItemDetail({
          ...(sidoParams as SidoCommonRequest),
          itemcd: itemCd,
          upddttm
        })
        message.success(DELETE_OK_INFO.Msg)
        editJudge.reset()
        emit('afterSave')
        back2list()
      } catch (error) {}
    }
  })
}

//入力タイプ変化時
async function onChangeInputtype(val) {
  form.hanif = form.hanit = form.keta = ''
  form.codejoken1 = form.codejoken2 = form.codejoken3 = undefined
  options.value.selectorlist5 = []
  options.value.selectorlist6 = []
  options.value.selectorlist7 = []
  if (val) {
    const res = await GetCodejokenList({
      inputtype: +getCode(val)
    })
    Object.assign(options.value, res)
  }
}
//コード条件1変化時
async function onChangeCodejoken1(val) {
  form.codejoken2 = form.codejoken3 = undefined
  const res = await GetCodejokenList({
    inputtype: +getCode(form.inputtype),
    codejoken1: val
  })
  Object.assign(options.value, res)
}
//コード条件2変化時
async function onChangeCodejoken2(val) {
  form.codejoken3 = undefined
  const res = await GetCodejokenList({
    inputtype: +getCode(form.inputtype),
    codejoken1: form.codejoken1,
    codejoken2: val
  })
  Object.assign(options.value, res)
}

function back2list(msg?) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: { ...route.query, itemcd: undefined, iscopy: undefined }
    })
  }, msg)
}

//入力桁
function replaceKeta() {
  if (form.inputtype?.split(' : ')?.[0] === String(Enum入力タイプ.数値_小数点付き実数)) {
    form.keta = form.keta?.replace(/[^0-9,]/g, '')
  } else {
    form.keta = form.keta?.replace(/[^0-9]/g, '')
  }
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 160px;
  border-right: 1px solid #606266 !important;
}

.ant-col.readonly {
  th {
    background-color: #ffffe1 !important;
  }
  .required::after {
    display: none;
  }
}
</style>
