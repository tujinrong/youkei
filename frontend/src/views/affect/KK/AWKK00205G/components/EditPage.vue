<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 基準値保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.1.16
 * 作成者　　: 張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false">
    <div class="self_adaption_table mb-2">
      <a-row>
        <a-col :md="12" :xxl="6">
          <th>業務</th>
          <TD>{{ initData.gyomukbnnm }}</TD>
        </a-col>
        <a-col :md="12" :xxl="6">
          <th>事業</th>
          <TD>{{ initData.kijunjigyonm }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button class="warning-btn" :disabled="!canEdit" @click="submitData">登録</a-button>
        <a-button type="primary" :disabled="!canDelete" danger @click="handleDelete">削除</a-button>
        <a-button type="primary" @click="goList">一覧へ</a-button>
      </a-space>
      <close-page></close-page>
    </div>
  </a-card>
  <a-card class="my-2 min-h-full" :loading="loading" :style="{ height: tableHeight }">
    <a-card>
      <a-row :gutter="8">
        <a-col :span="10">
          <div class="self_adaption_table" :class="{ form: isNew }">
            <a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th class="required">項目名称</th>
                <td v-if="isNew">
                  <a-form-item v-bind="validateInfos.itemnm">
                    <ai-select
                      v-model:value="formData.itemnm"
                      :options="selectorlist1"
                      show-search
                      allow-clear
                      @change="changeItem(formData.itemnm)"
                    >
                    </ai-select>
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.itemnm }}</TD>
              </a-col>
            </a-row>
          </div>
          <div class="self_adaption_table mb-2">
            <a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th>単位</th>
                <TD v-if="isNotNull(formData.freemstinfo.tani)">{{ formData.freemstinfo.tani }}</TD>
                <td v-else></td>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th>入力フラグ</th>
                <TD v-if="isNotNull(formData.freemstinfo.inputflgstr)">{{
                  formData.freemstinfo.inputflgstr ? '入力する' : '入力しない'
                }}</TD>
                <td v-else></td>
              </a-col> </a-row
            ><a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th>表示年度</th>
                <TD
                  v-if="
                    isNotNull(formData.freemstinfo.hyojinendof) ||
                    isNotNull(formData.freemstinfo.hyojinendot)
                  "
                >
                  {{ yearFormatter(Number(formData.freemstinfo.hyojinendof)) }}
                  ～
                  {{ yearFormatter(Number(formData.freemstinfo.hyojinendot)) }}</TD
                >
                <td v-else></td>
              </a-col>
            </a-row>
          </div>
        </a-col>
      </a-row>
    </a-card>
    <a-card>
      <a-row :gutter="8">
        <a-col :span="18">
          <div class="self_adaption_table" :class="{ form: canEdit }">
            <a-row>
              <a-col :md="18" :lg="16" :xxl="14">
                <th v-if="formData.ageflg" class="required">年齢範囲</th>
                <th v-else>年齢範囲</th>
                <td v-if="canEdit" class="flex items-center">
                  <a-radio-group
                    v-model:value="formData.ageflg"
                    class="flex gap-10"
                    :options="options"
                    @change="changeAgeRido(formData.ageflg)"
                  />
                </td>
                <td v-if="canEdit">
                  <div style="width: 40%; float: left">
                    <a-form-item v-bind="formData.ageflg ? validateInfos.agef : ''">
                      <a-input-number
                        v-model:value="formData.agef"
                        maxlength="3"
                        :min="0"
                        :max="100"
                        :disabled="!formData.ageflg"
                        style="width: 100%"
                        allow-clear
                      />
                    </a-form-item>
                  </div>
                  <div class="text-center" style="width: 20%; float: left">～</div>
                  <div style="width: 40%; float: left">
                    <a-form-item v-bind="formData.ageflg ? validateInfos.aget : ''">
                      <a-input-number
                        v-model:value="formData.aget"
                        maxlength="3"
                        :min="0"
                        :max="100"
                        style="width: 100%"
                        :disabled="!formData.ageflg"
                        allow-clear
                      />
                    </a-form-item>
                  </div>
                  <span v-if="formData.agef > formData.aget" class="error-message"
                    >年齢範囲の範用が不正です</span
                  >
                </td>
                <TD v-else>{{ formData.agef }}～{{ formData.aget }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="18" :lg="16" :xxl="14">
                <th v-if="formData.sexflg" class="required">性別</th>
                <th v-else>性別</th>
                <td v-if="canEdit" class="flex items-center">
                  <a-radio-group
                    v-model:value="formData.sexflg"
                    class="flex gap-10"
                    :options="options"
                    @change="changeSexRido(formData.sexflg)"
                  />
                </td>
                <td v-if="canEdit">
                  <a-form-item v-bind="formData.sexflg ? validateInfos.sex : []">
                    <ai-select
                      v-model:value="formData.sex"
                      style="width: 100%"
                      :disabled="!formData.sexflg"
                      :options="selectorlist2"
                      split-val
                      :allow-clear="false"
                    >
                    </ai-select>
                  </a-form-item>
                </td>
                <TD v-else>{{
                  formData.sex === '0' ? 'すべて' : formData.sex === '1' ? '男' : '女'
                }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="18" :lg="16" :xxl="14">
                <th class="required">有効年月日</th>

                <td v-if="canEdit" style="overflow: hidden">
                  <a-form-item v-bind="validateInfos.daterange">
                    <RangeDate v-model:value="formData.daterange" />
                  </a-form-item>
                </td>
                <TD v-else
                  >{{ getDateJpText(new Date(formData.yukoymdf)) }}～{{
                    getDateJpText(new Date(formData.yukoymdt))
                  }}</TD
                >
              </a-col>
            </a-row>
          </div>
        </a-col>
      </a-row>
    </a-card>
    <a-card>
      <h3 class="font-bold mt-2 mb-1">数値設定</h3>
      <a-row :gutter="8">
        <a-col :span="16">
          <div class="self_adaption_table_now" :class="{ form: canEdit }">
            <table>
              <tr>
                <th>異常値1</th>
                <th>注意値1</th>
                <th v-if="isNumber()" class="required">基準値</th>
                <th v-else>基準値<span style="color: red">＊</span></th>
                <th>注意値2</th>
                <th>異常値2</th>
              </tr>
              <tr>
                <td v-if="canEdit" style="background-color: #ffffe1">
                  <div style="width: 65%; float: left">
                    <a-input-number
                      v-model:value="formData.mainnumsetinfo.errvalue1t"
                      maxlength="10"
                      :disabled="isNumber()"
                      style="width: 100%"
                      allow-clear
                    />
                  </div>
                  <div class="td_div">以下</div>
                </td>
                <TD v-else style="background-color: #ffffe1" height="25em">{{
                  formData.mainnumsetinfo.errvalue1t
                }}</TD>
                <td v-if="canEdit" style="background-color: #ffffe1">
                  <div style="width: 45%; float: left">
                    <a-input-number
                      v-model:value="formData.mainnumsetinfo.alertvalue1f"
                      maxlength="10"
                      :disabled="isNumber()"
                      style="width: 100%"
                      allow-clear
                    />
                  </div>
                  <div class="td_div2">～</div>
                  <div style="width: 45%; float: left">
                    <a-input-number
                      v-model:value="formData.mainnumsetinfo.alertvalue1t"
                      maxlength="10"
                      :disabled="isNumber()"
                      style="width: 100%"
                      allow-clear
                    />
                  </div>
                </td>
                <TD v-else style="background-color: #ffffe1" height="25em"
                  >{{ formData.mainnumsetinfo.alertvalue1f }}～{{
                    formData.mainnumsetinfo.alertvalue1t
                  }}</TD
                >
                <td v-if="canEdit" style="background-color: #ffffe1">
                  <div style="width: 45%; float: left">
                    <a-form-item v-bind="validateInfos.kijunvaluef">
                      <a-input-number
                        v-model:value="formData.mainnumsetinfo.kijunvaluef"
                        maxlength="10"
                        :disabled="isNumber()"
                        style="width: 100%"
                        allow-clear
                        @change="checkkijunvaluef()"
                      />
                    </a-form-item>
                  </div>
                  <div class="td_div2">～</div>
                  <div style="width: 45%; float: left">
                    <a-form-item v-bind="validateInfos.kijunvaluet">
                      <a-input-number
                        v-model:value="formData.mainnumsetinfo.kijunvaluet"
                        maxlength="10"
                        :disabled="isNumber()"
                        style="width: 100%"
                        allow-clear
                        @change="checkkijunvaluet()"
                      />
                    </a-form-item>
                  </div>
                </td>
                <TD v-else style="background-color: #ffffe1" height="25em"
                  >{{ formData.mainnumsetinfo.kijunvaluef }}～{{
                    formData.mainnumsetinfo.kijunvaluet
                  }}</TD
                >
                <td v-if="canEdit" style="background-color: #ffffe1">
                  <div style="width: 45%; float: left">
                    <a-input-number
                      v-model:value="formData.mainnumsetinfo.alertvalue2f"
                      maxlength="10"
                      :disabled="isNumber()"
                      style="width: 100%"
                      allow-clear
                    />
                  </div>
                  <div class="td_div2">～</div>
                  <div style="width: 45%; float: left">
                    <a-input-number
                      v-model:value="formData.mainnumsetinfo.alertvalue2t"
                      maxlength="10"
                      :disabled="isNumber()"
                      style="width: 100%"
                      allow-clear
                    />
                  </div>
                </td>
                <TD v-else style="background-color: #ffffe1" height="25em"
                  >{{ formData.mainnumsetinfo.alertvalue2f }}～{{
                    formData.mainnumsetinfo.alertvalue2t
                  }}</TD
                >
                <td v-if="canEdit" style="background-color: #ffffe1">
                  <div style="width: 65%; float: left">
                    <a-input-number
                      v-model:value="formData.mainnumsetinfo.errvalue2f"
                      maxlength="10"
                      :disabled="isNumber()"
                      class="w-full"
                      allow-clear
                      style="text-align: right"
                    />
                  </div>
                  <div class="td_div">以上</div>
                </td>
                <TD v-else style="background-color: #ffffe1" height="25em">{{
                  formData.mainnumsetinfo.errvalue2f
                }}</TD>
              </tr>
            </table>
          </div>
        </a-col>
      </a-row>
    </a-card>
    <a-card>
      <h3 class="font-bold mt-2 mb-1">コード設定</h3>
      <a-row :gutter="8">
        <a-col :span="16">
          <div class="self_adaption_table_now" :class="{ form: canEdit }">
            <table>
              <tr>
                <th v-if="isCode()" class="required">基準値</th>
                <th v-else>基準値<span style="color: red">＊</span></th>
                <th>注意値</th>
                <th>異常値</th>
              </tr>
              <tr>
                <td v-if="canEdit" style="vertical-align: top">
                  <a-form-item v-bind="validateInfos.hanteicdlist">
                    <a-select
                      v-model:value="formData.maincodesetinfo.hanteicdlist"
                      style="width: 360px"
                      :options="selectorlist3"
                      class="flex-1"
                      mode="multiple"
                      allow-clear
                      :disabled="isCode()"
                      @change="checkCodeList()"
                    >
                      <template #option="{ label, value }">
                        {{ value + ' : ' + label }}
                      </template>
                    </a-select>
                  </a-form-item>
                </td>
                <TD v-else style="height: 2em">{{
                  formData.maincodesetinfo.hanteicdlist.length > 0
                    ? formData.maincodesetinfo.hanteicdlist
                    : ''
                }}</TD>
                <td v-if="canEdit" style="vertical-align: top">
                  <a-select
                    v-model:value="formData.maincodesetinfo.alerthanteicdlist"
                    :options="selectorlist3"
                    style="width: 360px"
                    class="w-full"
                    mode="multiple"
                    allow-clear
                    :disabled="isCode()"
                  >
                    <template #option="{ label, value }">
                      {{ value + ' : ' + label }}
                    </template>
                  </a-select>
                </td>
                <TD v-else>{{
                  formData.maincodesetinfo.alerthanteicdlist.length > 0
                    ? formData.maincodesetinfo.alerthanteicdlist
                    : ''
                }}</TD>
                <td v-if="canEdit" style="vertical-align: top">
                  <a-select
                    v-model:value="formData.maincodesetinfo.errhanteicdlist"
                    :options="selectorlist3"
                    style="width: 360px"
                    class="w-full"
                    mode="multiple"
                    allow-clear
                    :disabled="isCode()"
                  >
                    <template #option="{ label, value }">
                      {{ value + ' : ' + label }}
                    </template>
                  </a-select>
                </td>
                <TD v-else>{{
                  formData.maincodesetinfo.errhanteicdlist.length > 0
                    ? formData.maincodesetinfo.errhanteicdlist
                    : ''
                }}</TD>
              </tr>
            </table>
          </div>
        </a-col>
      </a-row>
    </a-card>
    <a-card class="my-2 min-h-full">
      <h3 class="font-bold mt-2 mb-1">表記設定</h3>
      <a-row :gutter="8">
        <a-col :span="10">
          <div class="self_adaption_table" :class="{ form: canEdit }">
            <a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th>基準値表記</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.kijunvaluehyoki">
                    <a-input
                      v-model:value="formData.kijunvaluehyoki"
                      maxlength="100"
                      allow-clear
                      @change="
                        formData.kijunvaluehyoki = replaceText(
                          formData.kijunvaluehyoki,
                          EnumRegex.全角半角
                        )
                      "
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.kijunvaluehyoki }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th>注意値表記</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.alertvaluehyoki">
                    <a-input
                      v-model:value="formData.alertvaluehyoki"
                      maxlength="100"
                      allow-clear
                      @change="
                        formData.alertvaluehyoki = replaceText(
                          formData.alertvaluehyoki,
                          EnumRegex.全角半角
                        )
                      "
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.alertvaluehyoki }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="16" :xxl="18">
                <th>異常値表記</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.errvaluehyoki">
                    <a-input
                      v-model:value="formData.errvaluehyoki"
                      maxlength="100"
                      allow-clear
                      @change="
                        formData.errvaluehyoki = replaceText(
                          formData.errvaluehyoki,
                          EnumRegex.全角半角
                        )
                      "
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.errvaluehyoki }}</TD>
              </a-col>
            </a-row>
          </div>
        </a-col>
      </a-row>
    </a-card>
  </a-card>
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import {
  onMounted,
  reactive,
  ref,
  watch,
  nextTick,
  computed,
  onBeforeMount,
  onUnmounted
} from 'vue'
import { getHeight } from '@/utils/height'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import {
  ITEM_REQUIRE_ERROR,
  SAVE_OK_INFO,
  DELETE_OK_INFO,
  E001008,
  ITEM_RANGE_ERROR
} from '@/constants/msg'
import { InitDetail, Save, Delete, GetFreeMstInfo } from '../service'
import { showSaveModal, showDeleteModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { replaceText, getDateJpText, yearFormatter } from '@/utils/util'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import {
  MainNumsetInfoVM,
  MainCodesetInfoSaveVM,
  FreeMstInfoVM,
  SaveMainVM,
  InitData,
  InitDetailRequest
} from '../type'
import TD from '@/components/Common/TableTD/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface VM extends SaveMainVM {
  daterange: { value1: string; value2: string }
  agerange: { value1: number; value2: number }
  hanteicdlist: string[]
  kijunvaluef: string
  kijunvaluet: string
  itemnm: string
  itemcd: string
  placeholder: string
}
const props = defineProps<{
  data: SaveMainVM | null
  // number: MainNumsetInfoVM | null
  isNew: boolean
  status: PageSatatus
}>()
const options = [
  { label: '指定なし', value: false },
  { label: '指定あり', value: true }
]
let upddttm
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(true)
const editJudge = new Judgement(route.name as string)
const isNew = props.status === PageSatatus.New
const canDelete = computed(() => !isNew && canEdit)
const tableHeight = computed(() => getHeight(154))
/** 項目名称変更情報(詳細画面) */
const initDataParmas = reactive<InitDetailRequest>({
  gyomukbn: '',
  kijunjigyocd: '',
  edano: '',
  editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
  itemcd: ''
})
/** 項目名称変更情報(詳細画面) */
const freemstinfo = reactive<FreeMstInfoVM>({
  tani: '',
  inputflgstr: '',
  hyojinendof: '',
  hyojinendot: '',
  numcdflg: true,
  selectorlist3: []
})
/** 基準値保守保存情報(詳細画面) */
const mainnumsetinfo = reactive<MainNumsetInfoVM>({
  /** 異常値1 */
  errvalue1t: '',
  /** 注意値1（開始） */
  alertvalue1f: '',
  /** 注意値1（終了） */
  alertvalue1t: '',
  /** 基準値1（開始） */
  kijunvaluef: '',
  /** 基準値1（終了） */
  kijunvaluet: '',
  /** 注意値2（開始） */
  alertvalue2f: '',
  /** 注意値2（終了） */
  alertvalue2t: '',
  /** 異常値2 */
  errvalue2f: ''
})
/** 基準値保守コード設定情報(詳細画面) */
const maincodesetinfo = reactive<MainCodesetInfoSaveVM>({
  /** 基準値（コード） */
  hanteicdlist: [],
  /** 注意値（コード） */
  alerthanteicdlist: [],
  /** 異常値（コード） */
  errhanteicdlist: []
})
const formData = reactive<VM>({
  ageflg: true,
  agef: '',
  aget: '',
  sexflg: true,
  sex: '',
  daterange: { value1: '', value2: '' },
  agerange: { value1: 0, value2: 0 },
  yukoymdf: '',
  yukoymdt: '',
  placeholder: '',
  kijunvaluehyoki: '',
  alertvaluehyoki: '',
  errvaluehyoki: '',
  maincodesetinfo: maincodesetinfo,
  mainnumsetinfo: mainnumsetinfo,
  freemstinfo: freemstinfo,
  itemnm: '',
  itemcd: '',
  hanteicdlist: [],
  kijunvaluef: '',
  kijunvaluet: '',
  upddttm: upddttm
})
//ドロップダウンリスト(項目名称)
const selectorlist1 = ref<DaSelectorModel[]>([])
//ドロップダウンリスト(性別)
const selectorlist2 = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
//ドロップダウンリスト(基準値（コード）注意値（コード）異常値（コード）)
const selectorlist3 = ref<DaSelectorModel[]>([])
const initData = reactive<InitData>({
  itemnm: '',
  gyomukbnnm: '',
  kijunjigyonm: '',
  saveinfo: formData,
  freemstinfo: freemstinfo
})
//項目の設定
const rules = reactive({
  agef: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年齢範囲'),
      validator: (rule, value) => {
        if (!formData.ageflg) {
          return Promise.resolve()
        }
        if (!value) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年齢範囲')))
        }
        return Promise.resolve()
      }
    }
  ],
  aget: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年齢範囲'),
      validator: (rule, value) => {
        if (!formData.ageflg) {
          return Promise.resolve()
        }
        if (!value) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年齢範囲')))
        }
        return Promise.resolve()
      }
    }
  ],
  sex: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '性別'),
      validator: (rule, value) => {
        if (!formData.sexflg) {
          return Promise.resolve()
        }
        if (!value) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '性別')))
        }
        return Promise.resolve()
      }
    }
  ],
  daterange: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '有効年月日範囲'),
      validator: (rule, value) => {
        chackData()
        if (!formData.yukoymdt) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '有効年月日範囲')))
        }
        if (!formData.yukoymdf) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '有効年月日範囲')))
        }
        return Promise.resolve()
      }
    }
  ],
  itemnm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '項目名称') }],
  kijunvaluef: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準値'),
      validator: (rule, value) => {
        if (!formData.itemnm) {
          return Promise.resolve()
        }
        if (!formData.freemstinfo.numcdflg) {
          return Promise.resolve()
        }
        if (!formData.mainnumsetinfo.kijunvaluef) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準値')))
        }
        return Promise.resolve()
      }
    }
  ],
  kijunvaluet: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準値'),
      validator: (rule, value) => {
        if (!formData.itemnm) {
          return Promise.resolve()
        }
        if (!formData.freemstinfo.numcdflg) {
          return Promise.resolve()
        }
        if (!formData.mainnumsetinfo.kijunvaluet) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準値')))
        }
        return Promise.resolve()
      }
    }
  ],
  hanteicdlist: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準値'),
      validator: (rule, value) => {
        if (!formData.itemnm) {
          return Promise.resolve()
        }
        if (formData.freemstinfo.numcdflg) {
          return Promise.resolve()
        }
        if (formData.maincodesetinfo.hanteicdlist.length < 1) {
          return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '基準値')))
        }
        return Promise.resolve()
      }
    }
  ]
})
const { validate, validateInfos } = Form.useForm(formData, rules)
//操作権限フラグ
const canEdit = isNew || route.meta.updflg
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onBeforeMount(async () => {
  if (props.data) {
    //初期化
    !props.isNew && Object.assign(formData, props.data)
    formData.daterange = { value1: props.data.yukoymdf, value2: props.data.yukoymdt }
  }
  let temp1 = route.query.gyomukbn as string
  let temp2 = route.query.kijunjigyocd as string
  let parts1 = temp1.split(':')
  let parts2 = temp2.split(':')
  initDataParmas.gyomukbn = parts1[0].trim()
  initData.gyomukbnnm = parts1[1].trim()
  initDataParmas.kijunjigyocd = parts2[0].trim()
  initData.kijunjigyonm = parts2[1].trim()
  initDataParmas.itemcd = route.query.itemcd as string
  initDataParmas.edano = route.query.edano as string
})
onMounted(async () => {
  editJudge.addEvent()
  loading.value = true
  try {
    if (isNew) {
      const res = await InitDetail({
        gyomukbn: initDataParmas.gyomukbn,
        kijunjigyocd: initDataParmas.kijunjigyocd,
        itemcd: initDataParmas.itemcd,
        edano: initDataParmas.edano,
        editkbn: Enum編集区分.新規
      })
      selectorlist1.value = res.selectorlist1
      selectorlist2.value = [...selectorlist2.value, ...res.selectorlist2]
      selectorlist3.value = res.saveinfo.freemstinfo.selectorlist3
    } else {
      initData.itemnm = route.query.itemcd + ':' + route.query.itemnm
      const res = await InitDetail({
        gyomukbn: initDataParmas.gyomukbn,
        kijunjigyocd: initDataParmas.kijunjigyocd,
        itemcd: initDataParmas.itemcd,
        edano: initDataParmas.edano,
        editkbn: Enum編集区分.変更
      })
      formData.daterange = { value1: res.saveinfo.yukoymdf, value2: res.saveinfo.yukoymdt }
      selectorlist1.value = res.selectorlist1
      upddttm = res.saveinfo.upddttm
      Object.assign(formData, JSON.parse(JSON.stringify(res.saveinfo)))
      formData.itemnm = route.query.itemnm as string
      selectorlist2.value = [...selectorlist2.value, ...res.selectorlist2]
      if (formData.sex === '0') {
        formData.sex = ''
      }
      await changeItem(initDataParmas.itemcd)
    }
  } catch (error) {}
  loading.value = false
  nextTick(() => editJudge.reset())
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function submitData() {
  await validate()
  if (formData.freemstinfo.numcdflg) {
    if (changeAllNumber()) {
      message.error(ITEM_RANGE_ERROR.Msg.replace('{0}', '数値設定'))
      return
    }
  } else {
    if (changeList()) {
      message.error(E001008.Msg.replace('{0}', 'コード設定'))
      return
    }
  }
  if (formData.ageflg) {
    if (formData.agef > formData.aget) {
      return
    }
  }
  try {
    showSaveModal({
      onOk: async () => {
        await Save({
          saveinfo: formData,
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
          gyomukbn: initDataParmas.gyomukbn,
          kijunjigyocd: initDataParmas.kijunjigyocd,
          itemcd: initDataParmas.itemcd,
          edano: initDataParmas.edano
        })
        message.success(SAVE_OK_INFO.Msg)
        router.push({ name: route.name as string, query: { refresh: '1' } })
      }
    })
  } catch (error) {}
}
//削除処理
async function handleDelete() {
  showDeleteModal({
    onOk: async () => {
      await Delete({
        gyomukbn: initDataParmas.gyomukbn,
        kijunjigyocd: initDataParmas.kijunjigyocd,
        itemcd: initDataParmas.itemcd,
        edano: initDataParmas.edano,
        upddttm: upddttm
      })
      message.success(DELETE_OK_INFO.Msg)
      router.push({ name: route.name as string, query: { refresh: '1' } })
    }
  })
}

//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string, query: { refresh: '1' } })
  })
}
//method
const show = (value) => {
  console.log(value)
}
const chackData = () => {
  formData.yukoymdf = formData.daterange.value1
  formData.yukoymdt = formData.daterange.value2
}
async function changeItem(val) {
  loading.value = true
  if (!val) {
    clearCode()
    clearNumber()
    clearFre()
    loading.value = false
    return
  }
  if (isNew) {
    clearCode()
    clearNumber()
    clearFre()
  }
  changeKijunValue()
  let parts = val.split(':')
  let itemcd = parts[0].trim()
  const res = await GetFreeMstInfo({
    gyomukbncd: initDataParmas.gyomukbn,
    kijunjigyocd: initDataParmas.kijunjigyocd,
    itemcd: itemcd,
    edano: initDataParmas.edano
  })
  initDataParmas.itemcd = itemcd
  if (!isNotNull(res.freemstinfo)) {
    return
  }
  formData.freemstinfo = res.freemstinfo
  selectorlist3.value = res.freemstinfo.selectorlist3
  checkAll()
  loading.value = false
}
const changeList = () => {
  const combinedArray = [
    ...formData.maincodesetinfo.hanteicdlist,
    ...formData.maincodesetinfo.alerthanteicdlist,
    ...formData.maincodesetinfo.errhanteicdlist
  ]
  const set = new Set(combinedArray)
  return combinedArray.length !== set.size
}
const changeKijunValue = (): boolean => {
  if (isNumber()) {
    return false
  }
  if (
    mainnumsetinfo.kijunvaluef === ''
      ? true
      : typeof mainnumsetinfo.kijunvaluef === 'undefined'
      ? true
      : false && mainnumsetinfo.kijunvaluet === ''
      ? true
      : typeof mainnumsetinfo.kijunvaluet === 'undefined'
      ? true
      : false
  ) {
    return true
  } else {
    return false
  }
}
const changeAllNumber = (): boolean => {
  if (
    rangeNumber(
      formData.mainnumsetinfo.errvalue1t,
      formData.mainnumsetinfo.alertvalue1f,
      formData.mainnumsetinfo.alertvalue1t,
      formData.mainnumsetinfo.kijunvaluef,
      formData.mainnumsetinfo.kijunvaluet,
      formData.mainnumsetinfo.alertvalue2f,
      formData.mainnumsetinfo.alertvalue2t,
      formData.mainnumsetinfo.errvalue2f
    )
  ) {
    return false
  } else {
    return true
  }
}
const rangeNumber = (
  val1: string,
  val2: string,
  val3: string,
  val4: string,
  val5: string,
  val6: string,
  val7: string,
  val8: string
): boolean => {
  const values = [val1, val2, val3, val4, val5, val6, val7, val8]
  const temp: string[] = []
  for (let i = 0; i < values.length; i++) {
    if (isNotNull(values[i])) {
      temp.push(values[i])
    }
  }
  let flag = false
  for (let i = 0; i < temp.length - 1; i++) {
    if (temp[i] >= temp[i + 1]) {
      flag = true
      break
    }
  }
  return !flag
}
const isNotNull = (val): boolean => {
  return val !== undefined && val !== '' && val !== null && val !== 'null' && val !== 'undefined'
}
const isCanEdit = (): boolean => {
  if (!isNotNull(formData.itemnm)) {
    return true
  }
  return formData.freemstinfo.numcdflg
}
const isNumber = (): boolean => {
  if (!isNotNull(formData.itemnm)) {
    return true
  }
  return !formData.freemstinfo.numcdflg
}
const isCode = (): boolean => {
  if (!isNotNull(formData.itemnm)) {
    return true
  }
  return formData.freemstinfo.numcdflg
}
const clearNumber = () => {
  formData.mainnumsetinfo.errvalue1t = ''
  formData.mainnumsetinfo.alertvalue1f = ''
  formData.mainnumsetinfo.alertvalue1t = ''
  formData.mainnumsetinfo.kijunvaluef = ''
  formData.mainnumsetinfo.kijunvaluet = ''
  formData.mainnumsetinfo.alertvalue2f = ''
  formData.mainnumsetinfo.alertvalue2t = ''
  formData.mainnumsetinfo.errvalue2f = ''
}
const clearCode = () => {
  formData.maincodesetinfo.hanteicdlist = []
  formData.maincodesetinfo.alerthanteicdlist = []
  formData.maincodesetinfo.errhanteicdlist = []
}
const clearFre = () => {
  formData.freemstinfo.tani = ''
  formData.freemstinfo.inputflgstr = ''
  formData.freemstinfo.hyojinendof = ''
  formData.freemstinfo.hyojinendot = ''
  formData.freemstinfo.selectorlist3 = []
}
const changeAgeRido = (flg) => {
  if (flg === false) {
    formData.agef = ''
    formData.aget = ''
  }
}
const changeSexRido = (flg) => {
  if (flg === false) {
    formData.sex = ''
  }
}
const checkAll = () => {
  checkCodeList()
  checkkijunvaluef()
  checkkijunvaluet()
}
const checkCodeList = () => {
  // if (formData.maincodesetinfo.hanteicdlist.length === 0) {
  //   return
  // }
  validate('hanteicdlist')
}
const checkkijunvaluef = () => {
  // if (!formData.mainnumsetinfo.kijunvaluef) {
  //   return
  // }
  validate('kijunvaluef')
}
const checkkijunvaluet = () => {
  // if (!formData.mainnumsetinfo.kijunvaluet) {
  //   return
  // }
  validate('kijunvaluet')
}
</script>

<style scoped lang="less">
.div_border {
  border: 1px solid #000;
}
.td_parent {
  display: flex;
}
.td_div {
  text-align: center;
  background-color: #ffffe1;
  float: left;
  width: 35%;
  padding-top: 3%;
}
.td_div2 {
  text-align: center;
  background-color: #ffffe1;
  float: left;
  width: 10%;
  padding-top: 3%;
}
.error-message {
  color: red;
}
.self_adaption_table th {
  width: 160px;
}
.self_adaption_table td {
  width: 160px;
}
.self_adaption_table_now {
  table-layout: auto;
  width: 65em;
}
.self_adaption_table_now th {
  width: 70em;
  background-color: #ecf5ff;
  font-weight: normal;
  text-align: left;
  border: #000 1px solid;
}
.self_adaption_table_now td {
  border: #000 1px solid;
}

.hidden-element {
  visibility: hidden;
  position: absolute;
  left: -9999px;
}
</style>
