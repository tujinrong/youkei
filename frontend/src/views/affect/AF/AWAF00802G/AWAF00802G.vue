<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: コントロール情報保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div v-if="isSearchPage" class="self_adaption_table form">
        <a-row>
          <a-col :sm="12" :xl="8" :xxl="6">
            <th class="w-26">メインコード</th>
            <td>
              <ai-select v-model:value="queryParams.mainCode" :options="mainOptions"></ai-select>
            </td>
          </a-col>
          <a-col :sm="12" :xl="8" :xxl="6">
            <th class="w-26">サブコード</th>
            <td>
              <ai-select
                v-model:value="queryParams.subCode"
                :options="subOptions"
                :disabled="!queryParams.mainCode"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div v-else class="self_adaption_table">
        <a-row>
          <a-col :sm="8" :xxl="6">
            <th class="w-26">メインコード</th>
            <TD>{{ queryParams.mainCode }}</TD>
          </a-col>
          <a-col :sm="8" :xxl="6">
            <th class="w-26">サブコード</th>
            <TD>{{ queryParams.subCode }}</TD>
          </a-col>
          <a-col :sm="8" :xxl="12">
            <th class="w-26">説明</th>
            <TD>{{ biko }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button
            v-if="isSearchPage"
            :disabled="!(queryParams.mainCode && queryParams.subCode)"
            type="primary"
            @click="handleSearch"
            >検索</a-button
          >
          <a-button v-else type="primary" @click="backToSearch">再検索</a-button>
          <a-button type="primary" :disabled="exceloutDisabled" @click="outputCsv"
            >CSV出力</a-button
          >
          <a-button class="warning-btn" :disabled="isSearchPage || !editFlg" @click="saveData"
            >登録</a-button
          >
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card class="m-t-1">
      <a-form>
        <div :style="{ height: tableHeight }">
          <vxe-table
            ref="xTableRef"
            :data="tableList"
            height="100%"
            :column-config="{ resizable: true }"
            :edit-config="{
              trigger: 'click',
              mode: 'cell',
              beforeEditMethod() {
                return editFlg
              }
            }"
            :edit-rules="_rules"
            :row-config="{ isCurrent: true, height: 48 }"
            :mouse-config="{ selected: true }"
            :keyboard-config="{
              isArrow: true,
              isTab: true,
              isDel: true,
              isEnter: true
            }"
            :empty-render="{ name: 'NotData' }"
            @edit-closed="onCloseCellEdit"
          >
            <vxe-column field="ctrlcd" title="コード" min-width="80" width="150"></vxe-column>
            <vxe-column field="itemnm" title="名称" min-width="150"></vxe-column>
            <vxe-column
              field="value"
              title="値"
              :show-overflow="false"
              :header-class-name="editFlg ? 'bg-editable' : 'bg-readonly'"
              :class-name="({ row }) => (validator(row.value, row, true) as string)"
              :edit-render="{
                name: 'CustomEdit2',
                props: { validateInfos }
              }"
              min-width="150"
            >
              <template #default="{ row }: { row: SearchVM }">
                <span v-if="row.datatype === EnumDataType.フラグ">
                  {{ row.value === '1' ? 'TRUE' : 'FALSE' }}
                </span>
                <span v-else-if="row.datatype === EnumDataType.日付 && row.value">
                  {{
                    row.rangeflg
                      ? getRangeDateJpText(row.value as ValueVM)
                      : getDateJpText(new Date(row.value as string))
                  }}
                </span>
                <span v-else>
                  {{
                    row.rangeflg ? getRangeValueText(row.value as ValueVM) : row.value ?? ''
                  }}</span
                >
              </template>
            </vxe-column>
            <vxe-column
              field="biko"
              title="備考"
              :header-class-name="editFlg ? 'bg-editable' : 'bg-readonly'"
              :edit-render="{ autofocus: '.ant-input', autoselect: true }"
              min-width="150"
            >
              <template #edit="{ row }">
                <a-textarea
                  v-model:value="row.biko"
                  :auto-size="{ minRows: 1 }"
                  :maxlength="200"
                  show-count
                  class="my-2"
                ></a-textarea>
              </template>
            </vxe-column>
          </vxe-table>
        </div>
      </a-form>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted, computed, watch, nextTick, watchEffect } from 'vue'
import { Form, message } from 'ant-design-vue'
import { useRouter, useRoute } from 'vue-router'
import { VxeTableInstance, VxeTablePropTypes } from 'vxe-table'
import {
  ITEM_RANGE_ERROR,
  ITEM_REQUIRE_ERROR,
  C003003,
  RESEARCH_CONFIRM,
  SAVE_OK_INFO,
  C003006
} from '@/constants/msg'
import { showConfirmModal, showSaveModal } from '@/utils/modal'
import { getHeight } from '@/utils/height'
import { Judgement } from '@/utils/judge-edited'
import { getDateJpText } from '@/utils/util'
import { Enum名称区分, EnumDataType } from '#/Enums'
import { Save, Search, InitMainCode, InitSubCode } from './service'
import { SearchVM, ValueVM } from './type'
import dayjs from 'dayjs'
import TD from '@/components/Common/TableTD/index.vue'
import { getSearchQuery } from '@/utils/util'

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const fieldMapping = {
  mainCode: 'メインコード',
  subCode: 'サブコード'
}
const route = useRoute()
const editJudge = new Judgement(route.name as string)
const loading = ref(false)
//テンプレート参照
const xTableRef = ref<VxeTableInstance>()
//ビューモデル
const isSearchPage = ref(true)
const exceloutDisabled = ref(true)
const queryParams = reactive<{
  mainCode: string | null
  subCode: string | null
}>({
  mainCode: null,
  subCode: null
})
const mainOptions = ref<DaSelectorModel[]>([])
const subOptions = ref<DaSelectorModel[]>([])
const tableList = ref<SearchVM[]>([])
const biko = ref('') //説明
let rawDataJson = ''
//操作権限フラグ
const editFlg = route.meta.updflg as boolean

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//明細部の高さの計算
const tableHeight = computed(() => getHeight(200))

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//メインコード変更処理
watch(
  () => queryParams.mainCode,
  async (val) => {
    if (!val) return
    const ctrlmaincd = val.split(' : ')[0]
    const res = await InitSubCode({ ctrlmaincd, kbn: Enum名称区分.名称 })
    subOptions.value = res.selectorlist
    queryParams.subCode = null
  }
)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getSearchMainCd()
  editJudge.addEvent()
})

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const getSearchMainCd = async () => {
  const res = await InitMainCode({ kbn: Enum名称区分.名称 })
  mainOptions.value = res.selectorlist
  exceloutDisabled.value = !res.exceloutflg
}

//検索処理
const handleSearch = async () => {
  loading.value = true
  try {
    const res = await Search({
      ctrlmaincd: queryParams.mainCode as string,
      ctrlsubcd: queryParams.subCode as string
    })
    loading.value = false
    isSearchPage.value = false
    tableList.value = res.kekkalist
    biko.value = res.biko

    nextTick(() => {
      rawDataJson = JSON.stringify(tableList.value)
    })
  } catch (error) {
    loading.value = false
  }
}

//保存処理
const saveData = async () => {
  const $table = xTableRef.value
  $table?.setCurrentRow(null)
  await $table?.validate(true)
  await validate()

  showSaveModal({
    onOk: async () => {
      return Save({
        savelist: getTableData(),
        ctrlmaincd: queryParams.mainCode as string,
        ctrlsubcd: queryParams.subCode as string
      }).then(() => {
        message.success(SAVE_OK_INFO.Msg)
        resetFields()
      })
    }
  })
}

//再検索
const backToSearch = () => {
  if (editJudge.isPageEdited()) {
    showConfirmModal({
      content: RESEARCH_CONFIRM,
      onOk: () => resetFields()
    })
  } else {
    resetFields()
  }
}
//クリア処理
const resetFields = () => {
  loading.value = false
  queryParams.mainCode = null
  queryParams.subCode = null
  isSearchPage.value = true
  tableList.value = []
  editJudge.reset()
}

//画面データ取得
const getTableData = () => {
  const tableData = xTableRef.value?.getTableData().tableData || []
  return tableData
}

function onCloseCellEdit() {
  if (JSON.stringify(getTableData()) !== rawDataJson) {
    editJudge.setEdited()
  }
}

//Csv出力
function outputCsv() {
  showConfirmModal({
    content: editJudge.isPageEdited()
      ? C003006.Msg.replace('{0}', '帳票出力')
      : C003003.Msg.replace('{0}', '帳票出力'),
    onOk: async () => {
      await router.push({ name: 'AWEU00301G' })
      router.push({
        name: 'AWEU00301G',
        query: {
          rptid: '0105',
          outerSearch: 'true',
          ...getSearchQuery(queryParams, fieldMapping)
        }
      })
    }
  })
}

//範囲表示(日付:和暦)
const getRangeDateJpText = (value: ValueVM) => {
  const srt1 = value.value1 && getDateJpText(new Date(value.value1))
  const srt2 = value.value2 && getDateJpText(new Date(value.value2))
  return (srt1 ?? '') + (srt1 || srt2 ? ' ～ ' : '') + (srt2 ?? '')
}
//範囲表示(日付以外)
const getRangeValueText = (value: ValueVM) => {
  return (value.value1 ?? '') + (value.value1 || value.value2 ? ' ～ ' : '') + (value.value2 ?? '')
}

//-------------------------------------------------------------------------------------------------
//チェック処理
const model = reactive<{ [key: string]: unknown }>({})
const rules = reactive<{ [key: string]: unknown }>({})
const { validate, validateInfos } = Form.useForm(model, rules)
const _rules = ref<VxeTablePropTypes.EditRules<SearchVM>>({
  value: [{ validator: ({ row, cellValue }) => validator(cellValue, row) as Promise<void> }]
})
watchEffect(() => {
  for (const row of tableList.value) {
    model[row.ctrlcd] = row.value
    rules[row.ctrlcd] = [{ validator: (_, value) => validator(value, row) }]
  }
})
function validator(value, row: SearchVM, cellbg?: boolean) {
  //時間の範囲チェック
  if (
    row.rangeflg &&
    value.value1 &&
    value.value2 &&
    row.datatype === EnumDataType.時間 &&
    dayjs(value.value1, 'HH:mm:ss') > dayjs(value.value2, 'HH:mm:ss')
  ) {
    return cellbg ? 'bg-errorcell' : Promise.reject(ITEM_RANGE_ERROR.Msg.replace('{0}', '値'))
  }
  //必須チェック
  if (
    (row.rangeflg && !value.value1 && !value.value2) ||
    (!row.rangeflg && !value && value !== 0)
  ) {
    return cellbg ? 'bg-errorcell' : Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '値'))
  }
  return Promise.resolve()
}
//-------------------------------------------------------------------------------------------------
</script>

<style src="./index.less" scoped />
