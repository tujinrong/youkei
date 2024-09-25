<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約羽数增加入力&請求書作成(增羽)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full flex-col-stretch gap-12px flex">
    <a-card>
      <h1>（GJ3030）互助基金契約者情報変更（譲渡）</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="8">
            <th class="required">期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="searchParams.KI"
                  :min="0"
                  :max="99"
                  :maxlength="2"
                  class="w-14"
                  @change="getInitData(searchParams.KI, false)"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="8">
            <th class="required">契約者(譲渡先)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  split-val
                ></ai-select>
              </a-form-item>
            </td> </a-col
        ></a-row>
      </div>
      <div class="flex mt-2">
        <a-space :size="20">
          <a-button type="primary" :disabled="isSearched" @click="search"
            >検索</a-button
          ><a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button
            type="primary"
            class="ml-20"
            :disabled="!isSearched || isEditing"
            @click="add"
            >新規登録</a-button
          ><a-button class="danger-btn" :disabled="!isDataSelected || isEditing"
            >削除</a-button
          >
        </a-space>
        <close-page /></div
    ></a-card>
    <a-card>
      <div class="flex justify-between">
        <h2>1.契約農場別明細 讓渡情報(表示)</h2>
        <a-pagination
          v-model:current="pageParams.PAGE_NUM"
          v-model:page-size="pageParams.PAGE_SIZE"
          :total="totalCount"
          :page-size-options="['10', '25', '50', '100']"
          :show-total="(total) => `抽出件数： ${total} 件`"
          show-less-items
          show-size-changer
          class="m-b-1 text-end"
        />
      </div>
      <vxe-table
        class="my-1"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData1"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => edit()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="center"
          field="KEIYAKU_DATE_FROM"
          title="変更年月日"
          width="200"
          sortable
          formatter="jpDate"
          :params="{ order: 1 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="MOTO_KEIYAKUSYA_NAME"
          title="契約者名(譲渡元)"
          sortable
          :params="{ order: 2 }"
          ><template #default="{ row }">
            <a @click="edit()">{{ row.MOTO_KEIYAKUSYA_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SYORI_KBN"
          title="処理状況"
          width="150"
          sortable
          :params="{ order: 4 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KAISU"
          title="請求回数"
          width="150"
          sortable
          :resizable="false"
          :params="{ order: 5 }"
        >
        </vxe-column>
      </vxe-table> </a-card
    ><a-card class="flex-1">
      <h2>2.契約農場別明細 讓渡元情報(選択)</h2>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="8">
            <th class="required">契約者</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="searchParams2.KEIYAKUSYA_CD"
                  :disabled="!isEditing || isSearched2"
                  :options="LIST"
                  split-val
                ></ai-select>
              </a-form-item></td></a-col
        ></a-row>
      </div>
      <div class="flex mt-2">
        <a-space :size="20" class="mb-2">
          <a-button
            type="primary"
            :disabled="!isEditing || isSearched2"
            @click="search2"
            >検索</a-button
          ><a-button type="primary" :disabled="!isEditing" @click="reset"
            >条件クリア</a-button
          >
        </a-space>
      </div>
      <vxe-table
        class="my-1"
        ref="xTableRef2"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData2"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => edit()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
        ><vxe-column type="checkbox" title="選択" width="100"></vxe-column>
        <vxe-column
          header-align="center"
          field="MOTO_NOJO_NAME"
          title="農場名(譲渡元)"
          width="200"
          sortable
          :params="{ order: 2 }"
          ><template #default="{ row }">
            <a @click="edit()">{{ row.MOTO_NOJO_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR"
          title="農場住所"
          sortable
          :params="{ order: 4 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TORI_KBN_NAME"
          title="鶏の種類"
          width="150"
          sortable
          :params="{ order: 5 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKU_HASU"
          title="契約羽数"
          width="150"
          sortable
          :resizable="false"
          :params="{ order: 5 }"
        >
        </vxe-column>
      </vxe-table>
      <div class="flex my-2">
        <a-space :size="20">
          <a-button
            :class="{ 'warning-btn': isEditing }"
            :disabled="!isEditing"
            @click="save"
            >保存</a-button
          >
          <a-button
            type="primary"
            :disabled="!isEditing || isEditing2"
            @click="cancel"
            >キャンセル</a-button
          >
          <a-button
            class="ml-20"
            type="primary"
            @click="turnExportPage"
            :disabled="!isDataSelected2"
            >通知書発行
          </a-button>
        </a-space>
      </div>
      <div class="parent-container">
        <div class="self_adaption_table form">
          <a-row>
            <a-col :md="12" :lg="12" :xl="8" :xxl="8">
              <th class="required">譲渡年月日</th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
                  <DateJp v-model:value="formData.KEIYAKU_DATE_FROM"></DateJp>
                </a-form-item>
              </td>
            </a-col>
            <a-col :md="12" :lg="12" :xl="8" :xxl="8">
              <th class="required">入力確認有無</th>
              <td>
                <a-radio-group
                  v-model:value="formData.SYORI_KBN"
                  class="ml-2 h-full pt-1"
                >
                  <a-radio :value="1">入力中</a-radio>
                  <a-radio :value="2">入力確定</a-radio>
                </a-radio-group>
              </td>
            </a-col>
          </a-row>
        </div>
        <div
          v-if="!isEditing"
          class="search-disabled-mask bg-disabled w-67%!"
        ></div>
      </div>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { onMounted, reactive, ref, toRef, computed } from 'vue'
import useSearch from '@/hooks/useSearch'
import { changeTableSort, mathNumber } from '@/utils/util'
import { useRoute, useRouter } from 'vue-router'
import { PageStatus } from '@/enum'
import { VxeTableInstance } from 'vxe-table'
import { nextTick } from 'process'
import { KeiyakuJoho, SearchRowVM } from '../interface/3030/type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: -1,
    KEIYAKUSYA_CD: undefined,
  }
}
const searchParams = reactive(createDefaultParams())
const createDefaultParams2 = () => {
  return {
    KEIYAKUSYA_CD: undefined,
  }
}
const searchParams2 = reactive(createDefaultParams2())
const isSearched = ref(false)
const isSearched2 = ref(false)
const isEditing = ref(false)
const isEditing2 = ref(false)
const createDefaultform = () => {
  return {
    KEIYAKU_DATE_FROM: undefined,
    SYORI_KBN: 1,
  }
}
const formData = reactive(createDefaultform())
const LIST = ref<CmCodeNameModel[]>([])
const tableData1 = ref<SearchRowVM[]>([])
const tableData2 = ref<KeiyakuJoho[]>([])
const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKUSYA_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約者'),
    },
  ],
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
const xTableRef = ref<VxeTableInstance>()
const xTableRef2 = ref<VxeTableInstance>()
const tableDefault = {
  KEIYAKU_DATE_FROM: new Date('2024-01-15'), // 変更年月日
  MOTO_KEIYAKUSYA_CD: 111, // 契約者番号(譲渡元)
  MOTO_KEIYAKUSYA_NAME: '田中株式会社', // 契約者名(譲渡元)
  SYORI_KBN: 1, // 処理状況コード
  SYORI_KBN_NAME: '処理中', // 処理状況名
  SEIKYU_KAISU: 3, // 請求回数
}
const tableDefault2 = {
  MOTO_NOJO_CD: 9876,
  KEIYAKU_KBN: 2,
  MOTO_NOJO_NAME: '譲渡元農場',
  ADDR: '東京都中央区1-2-3',
  TORI_KBN: 1,
  TORI_KBN_NAME: 'ブロイラー',
  KEIYAKU_HASU: 5000,
}
const router = useRouter()
const route = useRoute()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isDataSelected = computed(() => {
  return tableData1.value.length > 0 && xTableRef.value?.getCurrentRecord()
})
const isDataSelected2 = computed(() => {
  return tableData2.value.length > 0 && xTableRef2.value?.getCurrentRecord()
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  nextTick(() => clearValidate())
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const getInitData = (KI: number, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
}
//検索処理
function search() {
  tableData1.value.push(tableDefault)
  if (xTableRef.value && tableData1.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData1.value[0])
  }
  isSearched.value = true
}
function search2() {
  tableData2.value.push(tableDefault2)
  if (xTableRef2.value && tableData2.value.length > 0) {
    xTableRef2.value.setCurrentRow(tableData2.value[0])
  }
  isSearched2.value = true
}
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData1,
  params: toRef(() => searchParams),
  validate,
})

//条件クリア
const reset = () => {
  clear()
  clearValidate()
  isSearched.value = false
  isEditing.value = false
  isSearched2.value = false
  isEditing2.value = false
  tableData2.value = []
}
//新規
const add = () => {
  isEditing.value = true
}
//編集
const edit = () => {
  isEditing.value = true
}
//登録
const save = () => {
  isEditing.value = false
}
//キャンセル
const cancel = () => {
  isEditing.value = false
}

//請求書発行
const turnExportPage = () => {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
    },
  })
}
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
.search-disabled-mask {
  position: absolute;
  background-color: #f5f5f5;
  width: 100%;
  height: 100%;
  top: 0;
  z-index: 99;
  opacity: 0.5;
}
.parent-container {
  position: relative;
}
</style>
