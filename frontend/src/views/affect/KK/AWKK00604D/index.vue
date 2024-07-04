<template>
  <a-modal v-model:visible="modalVisible" title="項目定義" width="1400px" destroy-on-close>
    <CloseModalBtn @click="closeModal" />
    <a-spin :spinning="loading">
      <a-form
        ref="formRef"
        :label-col="{ span: 4 }"
        :wrapper-col="{ span: 24 }"
        :model="formParam"
        :rules="rules"
      >
        <div style="display: flex">
          <div style="width: 700px">
            <div>基本情報</div>
            <div class="description-table">
              <table>
                <tbody>
                  <tr>
                    <th style="width: 150px; background-color: #ffffe1">項目No</th>
                    <td>
                      {{ formParam.pageitemseq }}
                    </td>
                    <th style="width: 130px">項目名<span class="request-mark">＊</span></th>
                    <td>
                      <a-form-item name="itemnm" style="width: 100%">
                        <a-input
                          v-model:value="formParam.itemnm"
                          maxlength="100"
                          style="width: 100%"
                        ></a-input>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th
                      :style="{
                        width: '180px',
                        backgroundColor:
                          editkbn === Enum編集区分.変更 && index > -1 ? '#ffffe1' : ''
                      }"
                    >
                      ワークテープルカラム名<span
                        v-if="editkbn === Enum編集区分.新規 || index < 0"
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td v-if="editkbn === Enum編集区分.変更 && index > -1">
                      {{ formParam.wktablecolnm }}
                    </td>
                    <td v-else colspan="4">
                      <a-form-item name="wktablecolnm" style="width: 100%">
                        <a-input
                          v-model:value="formParam.wktablecolnm"
                          maxlength="100"
                          style="width: 100%"
                        ></a-input>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 160px">項目特定区分</th>
                    <td colspan="4">
                      <a-form-item
                        name="itemkbn"
                        :validate-status="formParam.itemkbnError"
                        style="width: 100%"
                      >
                        <ai-select
                          v-model:value="formParam.itemkbn"
                          :options="options.itemkbnList"
                          style="width: 100%"
                          split-val
                        ></ai-select>
                        <div v-if="formParam.itemkbnError == 'error'" style="color: red">
                          {{ formParam.itemkbnHelp }}
                        </div>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px">入力区分<span class="request-mark">＊</span></th>
                    <td colspan="4">
                      <a-form-item name="inputkbn" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.inputkbn"
                          :options="options.inputkbnList"
                          style="width: 100%"
                          split-val
                          @change="inputDivisionChange(false)"
                        ></ai-select>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px">入力方法<span class="request-mark">＊</span></th>
                    <td colspan="4">
                      <a-form-item name="inputtype" style="width: 100%"
                        ><ai-select
                          v-model:value="formParam.inputtype"
                          :options="options.inputtypeList"
                          style="width: 100%"
                          split-val
                          @change="tableChange(formParam.inputtype, 1, false)"
                        ></ai-select
                      ></a-form-item>
                    </td>
                  </tr>
                  <template
                    v-if="formParam.inputtype && formParam.inputkbn == Enum入力区分.関数.toString()"
                  >
                    <template v-for="(item, idx) of hikisuValList" :key="item">
                      <tr>
                        <th style="width: 130px">引数{{ idx + 1 }}</th>
                        <td colspan="4">
                          <div class="flex w-full">
                            <a-form-item style="flex: 3">
                              <ai-select
                                v-model:value="item.hikisutype"
                                :options="options.hikisukbnList"
                                split-val
                                @change="item.hikisuvalue = ''"
                              >
                              </ai-select>
                            </a-form-item>
                            <a-form-item
                              style="flex: 7"
                              :name="item.hikisutype === '1' ? 'hikisu' : ''"
                            >
                              <component
                                :is="item.hikisutype === '2' ? 'a-input' : 'ai-select'"
                                v-model:value="item.hikisuvalue"
                                style="width: 100%"
                                maxlength="100"
                                :options="options.itemOptions"
                                allow-clear
                              ></component>
                            </a-form-item>
                          </div>
                        </td>
                      </tr>
                    </template>
                  </template>
                  <tr>
                    <th style="width: 160px">
                      実施事業<span
                        v-if="
                          formParam.inputtype &&
                          [
                            Enum入力方法.医療機関,
                            Enum入力方法.事業従事者,
                            Enum入力方法.検診実施機関
                          ].includes(+formParam.inputtype)
                        "
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td colspan="4">
                      <a-form-item name="jigyocd" style="width: 100%">
                        <a-select
                          v-model:value="jigyocdList"
                          :options="options.jigyocdList"
                          style="width: 100%"
                          mode="multiple"
                          :disabled="
                            !(
                              formParam.inputtype &&
                              [
                                Enum入力方法.医療機関,
                                Enum入力方法.事業従事者,
                                Enum入力方法.検診実施機関
                              ].includes(+formParam.inputtype)
                            )
                          "
                          ><template #option="{ label, value }">
                            {{ value + ' : ' + label }}
                          </template></a-select
                        >
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px">桁数<span class="request-mark">＊</span></th>
                    <td>
                      <div
                        v-if="
                          formParam.inputtype &&
                          formParam.inputkbn &&
                          formParam.inputkbn === Enum入力区分.テキスト.toString() &&
                          formParam.inputtype === Enum入力方法.数値_小数点付き実数.toString()
                        "
                        style="display: flex; width: 100%"
                      >
                        <a-form-item name="len" style="width: 50%">
                          <a-input v-model:value="formParam.len" type="number" max="99999999" />
                        </a-form-item>
                        <a-form-item name="len2" style="width: 50%">
                          <a-input
                            v-model:value="formParam.len2"
                            type="number"
                            max="99999999"
                          ></a-input>
                        </a-form-item>
                      </div>
                      <a-form-item v-else name="len" style="width: 100%">
                        <a-input
                          v-model:value="formParam.len"
                          type="number"
                          max="99999999"
                          style="width: 100%"
                        ></a-input>
                      </a-form-item>
                    </td>
                    <th style="width: 130px">幅<span class="request-mark">＊</span></th>
                    <td>
                      <a-form-item name="width" style="width: 100%">
                        <a-input
                          v-model:value="formParam.width"
                          type="number"
                          max="999"
                          style="width: 100%"
                        ></a-input
                      ></a-form-item>
                    </td>
                  </tr>
                  <tr
                    v-if="
                      formParam.inputtype &&
                      (formParam.inputtype === Enum入力方法.半角文字_半角数字.toString() ||
                        formParam.inputtype === Enum入力方法.半角文字_半角英数字.toString() ||
                        formParam.inputtype === Enum入力方法.宛名番号.toString())
                    "
                  >
                    <th style="width: 130px">フォーマット</th>
                    <td colspan="4">
                      <ai-select
                        v-model:value="formParam.format"
                        :options="options.formatList"
                        style="width: 100%"
                        split-val
                      ></ai-select>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px">必須<span class="request-mark">＊</span></th>
                    <td>
                      <a-form-item name="requiredflg" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.requiredflg"
                          :options="options.requiredflgList"
                          style="width: 100%"
                          split-val
                        ></ai-select
                      ></a-form-item>
                    </td>
                    <th style="width: 130px">一意</th>
                    <td>
                      <a-form-item name="uniqueflg" style="width: 100%">
                        <a-checkbox v-model:checked="formParam.uniqueflg" />
                      </a-form-item>
                    </td>
                  </tr>

                  <tr>
                    <th style="width: 130px">表示入力設定<span class="request-mark">＊</span></th>
                    <td>
                      <a-form-item name="dispinputkbn" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.dispinputkbn"
                          :options="options.dispinputkbnList"
                          style="width: 100%"
                          split-val
                        ></ai-select>
                      </a-form-item>
                    </td>
                    <th style="width: 130px">並び順</th>
                    <td>
                      <a-input
                        v-model:value="formParam.sortno"
                        type="number"
                        max="999"
                        style="width: 100%"
                      ></a-input>
                    </td>
                  </tr>
                  <tr
                    v-if="
                      formParam.inputtype &&
                      (formParam.inputtype === Enum入力方法.半角文字_年.toString() ||
                        formParam.inputtype === Enum入力方法.半角文字_年_不詳あり.toString())
                    "
                  ></tr>
                  <tr>
                    <th style="width: 130px">
                      年度チェック<span
                        v-if="
                          formParam.inputkbn === Enum入力区分.テキスト.toString() &&
                          formParam.inputtype &&
                          [
                            Enum入力方法.半角文字_年,
                            Enum入力方法.半角文字_年_不詳あり,
                            Enum入力方法.半角文字_年月,
                            Enum入力方法.半角文字_年月_不詳あり,
                            Enum入力方法.日付_年月日,
                            Enum入力方法.日付_年月日_不詳あり,
                            Enum入力方法.日時_年月日時分秒
                          ].includes(+formParam.inputtype)
                        "
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td>
                      <a-form-item name="yearchkflg" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.yearchkflg"
                          :options="options.yearchkflgList"
                          style="width: 100%"
                          split-val
                          :disabled="
                            !(
                              formParam.inputkbn === Enum入力区分.テキスト.toString() &&
                              formParam.inputtype &&
                              [
                                Enum入力方法.半角文字_年,
                                Enum入力方法.半角文字_年_不詳あり,
                                Enum入力方法.半角文字_年月,
                                Enum入力方法.半角文字_年月_不詳あり,
                                Enum入力方法.日付_年月日,
                                Enum入力方法.日付_年月日_不詳あり,
                                Enum入力方法.日時_年月日時分秒
                              ].includes(+formParam.inputtype)
                            )
                          "
                        ></ai-select
                      ></a-form-item>
                    </td>
                    <th style="width: 130px">年度</th>
                    <td>
                      <a-checkbox
                        v-model:checked="formParam.nendoflg"
                        :disabled="
                          !(
                            formParam.inputkbn === Enum入力区分.テキスト.toString() &&
                            formParam.inputtype &&
                            [Enum入力方法.半角文字_年, Enum入力方法.半角文字_年_不詳あり].includes(
                              +formParam.inputtype
                            ) &&
                            formParam.yearchkflg &&
                            formParam.yearchkflg !== Enumエラーレベル.無視.toString()
                          )
                        "
                      ></a-checkbox>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px">正規表現</th>
                    <td colspan="4">
                      <a-form-item :validate-status="formParam.seikiError" style="width: 100%">
                        <a-input
                          v-model:value="formParam.seiki"
                          maxlength="100"
                          style="width: 100%"
                        ></a-input>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr v-if="isInputValid">
                    <th style="width: 130px">最小値</th>
                    <td colspan="4">
                      <a-input-number
                        v-model:value="formParam.minval"
                        style="width: 100%"
                        :maxlength="20"
                      ></a-input-number>
                    </td>
                  </tr>
                  <tr v-if="isInputValid">
                    <th style="width: 130px">最大値</th>
                    <td colspan="4">
                      <a-input-number
                        v-model:value="formParam.maxval"
                        style="width: 100%"
                        :maxlength="20"
                      ></a-input-number>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px">固定值</th>
                    <td>
                      <a-input
                        v-model:value="formParam.fixedval"
                        style="width: 100%"
                        :maxlength="100"
                      ></a-input>
                    </td>
                    <th style="width: 130px">初期値</th>
                    <td>
                      <a-input
                        v-model:value="formParam.defaultval"
                        style="width: 100%"
                        :maxlength="100"
                      ></a-input>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div style="width: 690px; margin-left: 10px">
            <div
              v-if="formParam.inputkbn && formParam.inputkbn === Enum入力区分.マスタ参照.toString()"
            >
              マスタ参照
            </div>
            <div
              v-if="formParam.inputkbn && formParam.inputkbn === Enum入力区分.マスタ参照.toString()"
              class="description-table"
            >
              <table>
                <tbody>
                  <tr>
                    <th style="width: 160px">
                      参照元フィールド<span class="request-mark">＊</span>
                    </th>
                    <td>
                      <a-form-item name="fromfieldid" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.fromfieldid"
                          :options="options.fromfieldidList"
                          style="width: 100%"
                          split-val
                        ></ai-select
                      ></a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">参照元項目<span class="request-mark">＊</span></th>
                    <td>
                      <a-form-item name="fromitemseq" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.fromitemseq"
                          :options="options.fromitemseqList"
                          style="width: 100%"
                          split-val
                        ></ai-select>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">
                      取得先フィールド<span class="request-mark">＊</span>
                    </th>
                    <td>
                      <a-form-item name="targetfieldid" style="width: 100%"
                        ><ai-select
                          v-model:value="formParam.targetfieldid"
                          :options="options.targetfieldidList"
                          style="width: 100%"
                          split-val
                        ></ai-select
                      ></a-form-item>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div>マスタ存在</div>
            <div class="description-table">
              <table>
                <tbody>
                  <tr>
                    <th style="width: 160px">マスタテーブル</th>
                    <td>
                      <a-form-item name="msttable" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.msttable"
                          :options="options.msttableList"
                          style="width: 100%"
                          split-val
                          @change="tableChange(formParam.msttable, 2, false)"
                        ></ai-select
                      ></a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">条件Sql</th>
                    <td>
                      <a-form-item name="mstjyoken" style="width: 100%">
                        <a-input
                          v-model:value="formParam.mstjyoken"
                          style="width: 100%"
                          :maxlength="50"
                        ></a-input>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">
                      項目<span v-if="formParam.msttable" class="request-mark">＊</span>
                    </th>
                    <td>
                      <a-form-item name="mstfield" style="width: 100%"
                        ><ai-select
                          v-model:value="formParam.mstfield"
                          :options="options.mstfieldList"
                          style="width: 100%"
                          split-val
                        ></ai-select
                      ></a-form-item>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div>条件必須</div>
            <div class="description-table">
              <table>
                <tbody>
                  <tr>
                    <th style="width: 160px">
                      エラーレベル<span
                        v-if="
                          formParam.requiredflg &&
                          formParam.requiredflg === Enumエラーレベル.無視.toString()
                        "
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td>
                      <a-form-item name="jherrlelkbn" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.jherrlelkbn"
                          :options="options.jherrlelkbnList"
                          style="width: 100%"
                          split-val
                          :disabled="formParam.requiredflg !== Enumエラーレベル.無視.toString()"
                          @change="jherrlelkbnChange()"
                        ></ai-select>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">
                      条件項目<span
                        v-if="formParam.jherrlelkbn && formParam.jherrlelkbn.indexOf('0') < 0"
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td>
                      <a-form-item name="jhitemseq" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.jhitemseq"
                          :options="options.jhitemseqList"
                          style="width: 100%"
                          split-val
                          :disabled="formParam.requiredflg !== Enumエラーレベル.無視.toString()"
                        ></ai-select>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">
                      演算子<span
                        v-if="
                          formParam.jherrlelkbn &&
                          formParam.jherrlelkbn.indexOf(Enumエラーレベル.無視.toString()) < 0
                        "
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td>
                      <a-form-item name="jhenzan" style="width: 100%">
                        <ai-select
                          v-model:value="formParam.jhenzan"
                          :options="options.jhenzanList"
                          style="width: 100%"
                          split-val
                          :disabled="formParam.requiredflg !== Enumエラーレベル.無視.toString()"
                        ></ai-select>
                      </a-form-item>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 140px">
                      値<span
                        v-if="
                          formParam.jherrlelkbn &&
                          formParam.jherrlelkbn.indexOf(Enumエラーレベル.無視.toString()) < 0 &&
                          formParam.jhenzan &&
                          formParam.jhenzan.indexOf(Enum演算子.is_null.toString()) < 0 &&
                          formParam.jhenzan.indexOf(Enum演算子.is_not_null.toString()) < 0
                        "
                        class="request-mark"
                        >＊</span
                      >
                    </th>
                    <td>
                      <a-form-item name="jhval" style="width: 100%">
                        <a-input
                          v-model:value="formParam.jhval"
                          style="width: 100%"
                          :maxlength="50"
                          :disabled="formParam.requiredflg !== Enumエラーレベル.無視.toString()"
                        ></a-input>
                      </a-form-item>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
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
        @click="deleteCode"
        >削除</a-button
      >
      <a-button key="submit" type="primary" :loading="loading" style="float: left" @click="clear"
        >クリア</a-button
      >
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//チェック仕様画面
//---------------------------------------------------------------------------

import { ref, watch, reactive, computed } from 'vue'
import { Modal, SelectProps } from 'ant-design-vue'
import { PageItemVM } from '../AWKK00601G/type'
import { InitDetail, InitFieldid, InitInputType } from './service'
import { Enum編集区分, Enum入力方法, Enum入力区分, Enumエラーレベル, Enum演算子 } from '#/Enums'
import { showDeleteModal, showConfirmModal, showInfoModal } from '@/utils/modal'
import { CLOSE_CONFIRM, CLEAR_CONFIRM, E001008, E001010 } from '@/constants/msg'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  addVisible: boolean
  index: number
  param?: PageItemVM
  gyoumukbn: string
  impno?: string
  pageitemList?: PageItemVM[]
  editkbn: Enum編集区分
  isFileImport: boolean
  changekbnList: SelectProps['options']
}
const props = withDefaults(defineProps<Props>(), {
  addVisible: false
})
const emit = defineEmits(['update:addVisible', 'add', 'delete'])
//---------------------------------------------------------------------------
//データ定義(data(ref…))
//---------------------------------------------------------------------------
const formRef = ref()
const formParam = ref<PageItemVM>({
  pageitemseq: 0,
  itemnm: '',
  wktablecolnm: '',
  mstjyoken: '',
  inputkbn: '',
  jherrlelkbn: '',
  jherrlelkbnName: ''
})
let compareParam = reactive<PageItemVM>({
  pageitemseq: 0,
  itemnm: '',
  wktablecolnm: '',
  mstjyoken: '',
  inputkbn: '',
  jherrlelkbn: '',
  jherrlelkbnName: ''
})
const baseFormParam = ref<PageItemVM>({
  pageitemseq: 0,
  itemnm: '',
  wktablecolnm: '',
  mstjyoken: '',
  inputkbn: '',
  jherrlelkbn: '',
  jherrlelkbnName: ''
})
//ローディング
const loading = ref(false)
const options = reactive({
  /** 【必須】のドロップダウンリスト */
  requiredflgList: [] as SelectProps['options'],
  /** 【年度チェック】のドロップダウンリスト */
  yearchkflgList: [] as SelectProps['options'],
  /** 【入力方法】のドロップダウンリスト */
  inputtypeList: [] as SelectProps['options'],
  /** 【表示入力設定】のドロップダウンリスト */
  dispinputkbnList: [] as SelectProps['options'],
  /** 【入力区分】のドロップダウンリスト */
  inputkbnList: [] as SelectProps['options'],
  /** 【フォーマット】のドロップダウンリスト */
  formatList: [] as SelectProps['options'],
  /** 【参照元フィールド】のドロップダウンリスト */
  fromfieldidList: [] as SelectProps['options'],
  /** 【取得先フィールド】のドロップダウンリスト */
  targetfieldidList: [] as SelectProps['options'],
  /** 【マスタチェックテーブル】のドロップダウンリスト */
  msttableList: [] as SelectProps['options'],
  /** 【マスタチェック項目】のドロップダウンリスト */
  mstfieldList: [] as SelectProps['options'],
  /** 【条件必須項目】のドロップダウンリスト */
  jhitemseqList: [] as SelectProps['options'],
  /** 【条件必須演算子】のドロップダウンリスト */
  jhenzanList: [] as SelectProps['options'],
  /** 【参照元項目】のドロップダウンリスト */
  fromitemseqList: [] as SelectProps['options'],
  /** 【条件必須エラーレベル区分】のドロップダウンリスト */
  jherrlelkbnList: [] as SelectProps['options'],
  /** 【実施事業】のドロップダウンリスト */
  jigyocdList: [] as SelectProps['options'],
  /** 【項目特定区分】のドロップダウンリスト */
  itemkbnList: [] as SelectProps['options'],
  /** 【画面項目】のドロップダウンリスト */
  itemOptions: [] as SelectProps['options'],
  /** 【引数区分】のドロップダウンリスト */
  hikisukbnList: [] as SelectProps['options']
})
const hikisuValList = ref<
  {
    hikisutype: string
    hikisuvalue: string
  }[]
>([])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const isChange = computed(() => {
  return JSON.stringify(compareParam) != JSON.stringify(formParam.value)
})
const isInputValid = computed(() => {
  return (
    formParam.value.inputkbn &&
    formParam.value.inputkbn === Enum入力区分.テキスト.toString() &&
    formParam.value.inputtype &&
    (formParam.value.inputtype == Enum入力方法.数値_整数.toString() ||
      formParam.value.inputtype == Enum入力方法.数値_小数点付き実数.toString() ||
      formParam.value.inputtype == Enum入力方法.数値_符号付き整数.toString())
  )
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.addVisible,
  (newValue) => {
    if (newValue) {
      formParam.value = JSON.parse(JSON.stringify(props.param))
      if (!formParam.value.fromitemseq) {
        formParam.value.fromitemseq = ''
      } else {
        formParam.value.fromitemseq += ''
      }
      if (!formParam.value.jhitemseq) {
        formParam.value.jhitemseq = ''
      } else {
        formParam.value.jhitemseq += ''
      }
      if (formParam.value.inputkbn == Enum入力区分.関数.toString()) {
        hikisuValList.value = []
        let arr = formParam.value.hikisu?.split(',')
        let nameArr = formParam.value.hikisuName?.split(',')
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
  () => formParam.value.inputtype,
  (val) => {
    if (!formParam.value.inputtype) {
      options.fromfieldidList = []
      options.targetfieldidList = []
      formParam.value.fromfieldid = ''
      formParam.value.targetfieldid = ''
      jigyocdList.value = []
    }
  }
)
watch(
  () => formParam.value.msttable,
  (val) => {
    if (!formParam.value.msttable) {
      formParam.value.mstjyoken = ''
      formParam.value.mstfield = ''
      options.mstfieldList = []
    }
  }
)

watch(
  () => formParam.value.len,
  (newValue) => {
    if (formParam.value.len != undefined) {
      const newLen = Math.min(999, Math.max(0, Math.floor(formParam.value.len)))
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
watch(
  () => formParam.value.width,
  (newValue) => {
    if (formParam.value.width != undefined) {
      const newLen = Math.min(999, Math.max(0, Math.floor(formParam.value.width)))
      formParam.value.width = newLen
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.sortno,
  (newValue) => {
    if (formParam.value.sortno != undefined) {
      const newLen = Math.min(999, Math.max(0, Math.floor(formParam.value.sortno)))
      formParam.value.sortno = newLen
    }
  },
  { deep: true }
)
watch(
  () => formParam.value.requiredflg,
  (val) => {
    //必須フラグが0（無視）以外
    if (val !== Enumエラーレベル.無視.toString()) {
      formParam.value.jherrlelkbn = undefined
      formParam.value.jhitemseq = undefined
      formParam.value.jhenzan = undefined
      formParam.value.jhval = undefined
    } else {
      formParam.value.jherrlelkbn = Enumエラーレベル.無視.toString()
    }
  }
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const jigyocdList = computed({
  get: () => {
    if (formParam.value.jigyocd) {
      return formParam.value.jigyocd.split(',')
    }
    return undefined
  },
  set: (value) => {
    if (Array.isArray(value)) {
      formParam.value.jigyocd = value.join(',')
    } else if (typeof value === 'string') {
      formParam.value.jigyocd = [value].join(',')
    } else {
      formParam.value.jigyocd = undefined
    }
  }
})
const modalVisible = computed({
  get() {
    return props.addVisible
  },
  set(val) {
    emit('update:addVisible', val)
  }
})

//ルール
const rules = computed(() => {
  let inputkbnRule = {}
  let msttablenRule = {}
  let jherrlelkbnRule = {}

  const normRule = {
    itemnm: [
      {
        required: true,
        message: '項目名空白'
      }
    ],
    inputkbn: [
      {
        required: true,
        message: '入力区分空白'
      }
    ],
    inputtype: [
      {
        required: true,
        message: '入力方法空白'
      }
    ],
    width: [
      {
        required: true,
        message: '幅空白'
      }
    ],
    len: [
      {
        required: true,
        message: '幅空白'
      }
    ],
    len2: [
      {
        required:
          formParam.value.inputkbn === Enum入力区分.テキスト.toString() &&
          formParam.value.inputtype === Enum入力方法.数値_小数点付き実数.toString(),
        message: '幅空白'
      }
    ],
    requiredflg: [
      {
        required: true,
        message: '必須空白'
      }
    ],
    yearchkflg: [
      {
        required:
          formParam.value.inputkbn === Enum入力区分.テキスト.toString() &&
          formParam.value.inputtype &&
          [
            Enum入力方法.半角文字_年,
            Enum入力方法.半角文字_年_不詳あり,
            Enum入力方法.半角文字_年月,
            Enum入力方法.半角文字_年月_不詳あり,
            Enum入力方法.日付_年月日,
            Enum入力方法.日付_年月日_不詳あり,
            Enum入力方法.日時_年月日時分秒
          ].includes(+formParam.value.inputtype),
        message: '年度空白'
      }
    ],
    dispinputkbn: [
      {
        required: true,
        message: '表示入力設定空白'
      }
    ],
    wktablecolnm: [
      {
        required: true,
        message: 'ワークテープルカラム名空白'
      },
      {
        validator: (rule, value, callback) => {
          const itemNames = props.pageitemList?.map((item) => item.itemnm)
          if (itemNames?.includes(value)) {
            callback(new Error(E001008.Msg.replace('{0}', 'ワークテープルカラム名')))
          } else {
            callback()
          }
        }
      }
    ],
    jigyocd: [
      {
        required:
          formParam.value.inputtype &&
          (formParam.value.inputtype === Enum入力方法.事業従事者.toString() ||
            formParam.value.inputtype === Enum入力方法.医療機関.toString()),
        message: '実施事業空白'
      }
    ],
    jherrlelkbn: [
      {
        required: formParam.value.requiredflg === Enumエラーレベル.無視.toString(),
        message: '条件必須エラーレベル空白'
      }
    ],
    jhval: [
      {
        required:
          formParam.value.jhenzan !== Enum演算子.is_null.toString() &&
          formParam.value.jhenzan !== Enum演算子.is_not_null.toString() &&
          formParam.value.jherrlelkbn &&
          formParam.value.jherrlelkbn.indexOf(Enumエラーレベル.無視.toString()) < 0,
        message: ''
      }
    ],
    hikisu: [
      {
        validator: async () => {
          let filteredList = hikisuValList.value.filter((item) => item.hikisutype == '1')
          for (let item of filteredList) {
            if (
              !item.hikisuvalue ||
              !options.itemOptions?.find((e) => e.value == item.hikisuvalue.split(' : ')[0])
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
  }

  if (formParam.value.inputkbn === Enum入力区分.マスタ参照.toString()) {
    //入力区分が4（マスタ参照）
    inputkbnRule = {
      fromfieldid: [
        {
          required: true,
          message: ''
        }
      ],
      fromitemseq: [
        {
          required: true,
          message: ''
        }
      ],
      targetfieldid: [
        {
          required: true,
          message: ''
        }
      ]
    }
  }

  if (formParam.value.msttable) {
    //マスタテーブルが選択された
    msttablenRule = {
      mstfield: [
        {
          required: true,
          message: ''
        }
      ]
    }
  }

  if (
    formParam.value.jherrlelkbn &&
    formParam.value.jherrlelkbn.indexOf(Enumエラーレベル.無視.toString()) < 0
  ) {
    //エラーレベルが0（無視）以外
    jherrlelkbnRule = {
      jhitemseq: [
        {
          required: true,
          message: ''
        }
      ],
      jhenzan: [
        {
          required: true,
          message: ''
        }
      ]
    }
  }
  return { ...normRule, ...inputkbnRule, ...msttablenRule, ...jherrlelkbnRule }
})
//--------------------------------------------------------------------------
//メソッド(methods)
//---------------------------------------------------------------------------
//出力modal閉じる
const closeModal = () => {
  if (isChange.value) {
    showConfirmModal({
      content: CLOSE_CONFIRM.Msg,
      onOk: () => {
        formParam.value = JSON.parse(JSON.stringify(baseFormParam))
        formRef.value.clearValidate()
        modalVisible.value = false
      }
    })
  } else {
    formParam.value = JSON.parse(JSON.stringify(baseFormParam))
    formRef.value.clearValidate()
    modalVisible.value = false
  }
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
  formParam.value.hikisu = temparr.join(',')
  //引数桁数チェック
  if (formParam.value.hikisu && formParam.value.hikisu.length > 200) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E001010.Msg.replace('{0}', '引数')
    })
    return
  }
  formRef.value.validate().then(() => {
    //正規表現 check
    formParam.value.seikiError = ''
    if (formParam.value.seiki != null && formParam.value.seiki != '') {
      try {
        new RegExp(formParam.value.seiki)
      } catch (e) {
        formParam.value.seikiError = 'error'
        return
      }
    }

    //項目特定区分 check
    formParam.value.itemkbnError = ''
    formParam.value.itemkbnHelp = ''
    let itemkbn = formParam.value?.itemkbn?.split(':')[0]?.trim()
    if (itemkbn) {
      let itemkbnList = props.pageitemList?.find(
        (t) => t.pageitemseq != formParam.value?.pageitemseq && t.itemkbn == itemkbn
      )
      if (itemkbnList) {
        formParam.value.itemkbnError = 'error'
        formParam.value.itemkbnHelp = E001008.Msg.replace('{0}', itemkbnList.itemkbnName + '')
        return
      }
    }

    formParam.value.inputkbnName = options.inputkbnList?.find(
      (item) => item.value === formParam.value?.inputkbn
    )?.label
    formParam.value.inputtypeName = options.inputtypeList?.find(
      (item) => item.value === formParam.value?.inputtype
    )?.label
    formParam.value.hikisuName = temparr
      .map((e) => {
        if (e.indexOf("'") < 0) {
          e = options.itemOptions?.find((item) => item.value === e)?.label
        }
        return e
      })
      .join(',')
    formParam.value.formatName = options.formatList?.find(
      (item) => item.value === formParam.value?.format
    )?.label
    formParam.value.requiredflgName = options.requiredflgList?.find(
      (item) => item.value === formParam.value?.requiredflg
    )?.label
    formParam.value.yearchkflgName = options.yearchkflgList?.find(
      (item) => item.value === formParam.value?.yearchkflg
    )?.label
    formParam.value.dispinputkbnName = options.dispinputkbnList?.find(
      (item) => item.value === formParam.value?.dispinputkbn
    )?.label
    formParam.value.fromitemseq = formParam.value?.fromitemseq
      ? parseInt(formParam.value?.fromitemseq?.toString()?.split(':')[0]?.trim())
      : undefined
    formParam.value.fromitemseqName = options.fromitemseqList?.find(
      (item) => item.value === formParam.value?.fromitemseq + ''
    )?.label
    formParam.value.fromfieldidName = options.fromfieldidList?.find(
      (item) => item.value === formParam.value?.fromfieldid
    )?.label
    formParam.value.targetfieldidName = options.targetfieldidList?.find(
      (item) => item.value === formParam.value?.targetfieldid
    )?.label
    formParam.value.msttableName = options.msttableList?.find(
      (item) => item.value === formParam.value?.msttable
    )?.label
    formParam.value.mstfieldName = options.mstfieldList?.find(
      (item) => item.value === formParam.value?.mstfield
    )?.label
    formParam.value.jhitemseq = formParam.value?.jhitemseq
      ? parseInt(formParam.value?.jhitemseq?.toString()?.split(':')[0]?.trim())
      : undefined
    formParam.value.jhitemseqName = options.jhitemseqList?.find(
      (item) => item.value === formParam.value?.jhitemseq + ''
    )?.label
    formParam.value.jherrlelkbnName = options.jherrlelkbnList?.find(
      (item) => item.value === formParam.value?.jherrlelkbn + ''
    )?.label
    formParam.value.jhenzanName = options.jhenzanList?.find(
      (item) => item.value === formParam.value?.jhenzan + ''
    )?.label
    formParam.value.jigyocdName =
      formParam.value.jigyocd != undefined
        ? formParam.value.jigyocd
            .split(',')
            .map((jigyocd) => {
              const foundOption = options.jigyocdList?.find((item) => item.value === jigyocd)
              return foundOption ? foundOption.label : ''
            })
            .join(',')
        : undefined
    formParam.value.itemkbnName = options.itemkbnList?.find(
      (item) => item.value === formParam.value?.itemkbn + ''
    )?.label
    emit('update:addVisible', false)
    emit('add', formParam.value)
    formRef.value.clearValidate()
  })
}
//削除処理
const deleteCode = () => {
  showDeleteModal({
    onOk: async () => {
      emit('delete', formParam.value)
      formRef.value.clearValidate()
      emit('update:addVisible', false)
    }
  })
}

//エラーレベル処理
const jherrlelkbnChange = () => {
  if (
    formParam.value.jherrlelkbn &&
    formParam.value.jherrlelkbn != undefined &&
    formParam.value.jherrlelkbn === Enumエラーレベル.無視.toString()
  ) {
    formParam.value.jhitemseq = undefined
    formParam.value.jhenzan = undefined
    formParam.value.jhval = undefined
  }
}
//メソッドの選択処理
const inputDivisionChange = async (isFirst) => {
  loading.value = true
  await InitInputType({
    gyoumukbn: props.gyoumukbn,
    impno: props.impno,
    inputkbn: formParam.value.inputkbn
  })
    .then((res) => {
      if (!isFirst) {
        formParam.value.inputtype = undefined

        if (formParam.value.inputkbn !== Enum入力区分.マスタ参照.toString()) {
          formParam.value.fromfieldid = ''
          formParam.value.targetfieldid = ''
          formParam.value.fromitemseq = ''
        }
      }
      // コード系ドロップダウンリストを取得
      if (formParam.value.inputkbn === Enum入力区分.コード系.toString()) {
        options.inputtypeList = props.changekbnList
      } else {
        options.inputtypeList = res.inputtypeList
      }
      if (formParam.value?.inputtype) {
        tableChange(formParam.value.inputtype, 1, isFirst)
      }
    })
    .finally(() => {
      loading.value = false
    })
}
//ドロップダウン初期化(フィールド)
const tableChange = (tableid, type, isFirst) => {
  if (tableid != undefined) {
    let inputtype = tableid.split(':')[0].trim()
    if (type == 1 && !isFirst) {
      //方法変更処理
      formParam.value.len2 = undefined
      formParam.value.format = undefined
      //【事業コード】ドロップダウン初期化処理
      if (
        !(
          inputtype === Enum入力方法.医療機関.toString() &&
          inputtype === Enum入力方法.事業従事者.toString()
        )
      ) {
        jigyocdList.value = []
      }
      if (
        formParam.value.inputkbn === Enum入力区分.テキスト.toString() &&
        inputtype === Enum入力方法.日付_年月日.toString()
      ) {
        formParam.value.yearchkflg = Enumエラーレベル.無視.toString()
      }
    }
    //最大値 最小値
    if (
      !isFirst &&
      formParam.value.maxval != '' &&
      (formParam.value.inputkbn !== Enum入力区分.テキスト.toString() ||
        (inputtype !== Enum入力方法.数値_整数.toString() &&
          inputtype !== Enum入力方法.数値_小数点付き実数.toString() &&
          inputtype !== Enum入力方法.数値_符号付き整数.toString()))
    ) {
      formParam.value.maxval = undefined
      formParam.value.minval = undefined
    }
    if (formParam.value.inputkbn === Enum入力区分.マスタ参照.toString() || type === 2) {
      loading.value = true
      InitFieldid({ tableid: tableid.split(':')[0].trim() })
        .then((res) => {
          //参照元フィールド 取得先フィールド
          if (type == 1) {
            options.fromfieldidList = res.fieldidList
            options.targetfieldidList = res.fieldidList
            if (!isFirst) {
              formParam.value.fromfieldid = ''
              formParam.value.targetfieldid = ''
            }
          }
          //項目
          else {
            options.mstfieldList = res.fieldidList
            if (!isFirst) {
              formParam.value.mstfield = ''
            }
          }
        })
        .finally(() => {
          loading.value = false
        })
    }
  }
  if (!isFirst) {
    let hinsu: string =
      options.inputtypeList?.find((e) => e.value == formParam.value.inputtype)?.key ?? '0'
    hikisuValList.value = Array.from({ length: +hinsu }, () => ({
      hikisutype: '1',
      hikisuvalue: ''
    }))
  }
}

/** 初期化処理 */
const Init = async () => {
  loading.value = true
  let list = props.pageitemList
    ? props.pageitemList.map((item) => item.pageitemseq + ',' + item.itemnm)
    : []

  InitDetail({
    pageitemseq: formParam.value.pageitemseq,
    gyoumukbn: props.gyoumukbn,
    impno: props.impno,
    inputkbn: formParam.value.inputkbn,
    inputtype: formParam.value.inputtype,
    msttable: formParam.value.msttable,
    editkbn: props.editkbn,
    pageitemList: list
  })
    .then(async (res) => {
      Object.assign(options, res)
      options.itemOptions = res.fromitemseqList
      //他の画面項目を選択する箇所に選択された場合、空白にする
      if (!options.fromitemseqList?.find((f) => f.value === formParam.value.fromitemseq)) {
        formParam.value.fromitemseq = ''
      }
      //他の画面項目を選択する箇所に選択された場合、空白にする
      if (!options.jhitemseqList?.find((t) => t.value === formParam.value.jhitemseq)) {
        formParam.value.jhitemseq = ''
      }
      if (
        options.mstfieldList &&
        !options.mstfieldList.find((m) => m.value === formParam.value.mstfield)
      ) {
        formParam.value.mstfield = ''
      }
      await inputDivisionChange(true)
      compareParam = JSON.parse(JSON.stringify(formParam.value))
    })
    .finally(() => {
      loading.value = false
    })
}

//クリア
const clear = () => {
  showConfirmModal({
    content: CLEAR_CONFIRM.Msg,
    onOk: () => {
      formParam.value.itemnm = ''
      formParam.value.requiredflg = undefined
      formParam.value.msttable = ''
      formParam.value.mstjyoken = ''
      formParam.value.mstfield = ''
      formParam.value.inputtype = ''
      formParam.value.targetfieldid = ''
      formParam.value.mstfield = ''
      formParam.value.mstjyoken = ''
      formParam.value.msttable = ''
      formParam.value.seiki = ''
      formParam.value.minval = ''
      formParam.value.maxval = ''
      formParam.value.inputtype = ''
      formParam.value.len = undefined
      formParam.value.len2 = undefined
      formParam.value.format = ''
      formParam.value.requiredflg = ''
      formParam.value.inputkbn = ''
      formParam.value.defaultval = ''
      formParam.value.width = undefined
      formParam.value.nendoflg = undefined
      formParam.value.uniqueflg = false
      formParam.value.dispinputkbn = ''
      formParam.value.dispinputkbnName = ''
      formParam.value.jhenzan = ''
      formParam.value.jhenzanName = ''
      formParam.value.jherrlelkbn = ''
      formParam.value.jherrlelkbnName = ''
      formParam.value.jhitemseq = ''
      formParam.value.jhitemseqName = ''
      formParam.value.jhval = ''
      formParam.value.fromitemseq = ''
      formParam.value.fromitemseqName = ''
      formParam.value.sortno = undefined
      formParam.value.fromfieldid = ''
      formParam.value.fromfieldidName = ''
      formParam.value.targetfieldid = ''
      formParam.value.targetfieldidName = ''
      formParam.value.jigyocd = ''
      formParam.value.jigyocdName = ''
      formParam.value.itemkbn = ''
      formParam.value.seikiError = ''
      formParam.value.itemkbnError = ''
      formParam.value.itemkbnHelp = ''
    }
  })
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
