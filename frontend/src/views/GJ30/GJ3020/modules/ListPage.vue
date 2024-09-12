<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約羽数增加入力&請求書作成(增羽)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div
    class="h-full flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto flex"
  >
    <a-card>
      <h1>（GJ3020）互助基金契約者情報変更（契約区分変更）</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col span="8">
            <th class="required">期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="searchParams.KI"
                  :min="0"
                  :max="99"
                  :maxlength="2"
                  class="w-full"
                  @change="getInitData(searchParams.KI, false)"
                ></a-input-number>
              </a-form-item>
            </td> </a-col
        ></a-row>
        <a-row>
          <a-col span="8">
            <th class="required">契約者</th>
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
        <h2>1.契約区分情報(表示)</h2>
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
        :data="tableData"
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
          min-width="160"
          sortable
          formatter="jpDate"
          :params="{ order: 1 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="KEIYAKU_KBN_MAE"
          title="契約区分(変更前)"
          min-width="100"
          sortable
          :params="{ order: 2 }"
        >
          <template #default="{ row }">
            <a @click="edit()">{{ row.KEIYAKU_KBN_MAE }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="KEIYAKU_KBN_ATO"
          title="契約区分(変更後)"
          min-width="100"
          sortable
          :params="{ order: 3 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="SYORI_KBN"
          title="処理状況"
          min-width="100"
          sortable
          :params="{ order: 4 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KAISU"
          title="請求回数"
          min-width="100"
          sortable
          :resizable="false"
          :params="{ order: 5 }"
        >
        </vxe-column>
      </vxe-table> </a-card
    ><a-card class="flex-1">
      <h2>2.契豹区分情報(入力)</h2>
      <a-space :size="20" class="mb-2">
        <a-button class="warning-btn" :disabled="!isEditing" @click="save"
          >保存</a-button
        >
        <a-button type="primary" :disabled="!isEditing" @click="cancel"
          >キャンセル</a-button
        >
        <a-button
          type="primary"
          @click="turnExportPage"
          :disabled="!isDataSelected || isEditing"
          >通知書発行
        </a-button>
      </a-space>
      <div class="parent-container">
        <div class="self_adaption_table form max-w-300">
          <a-row>
            <a-col span="24">
              <th class="required">変更年月日</th>
              <td>
                <a-form-item v-bind="validateInfos1.KEIYAKU_DATE_FROM">
                  <DateJp v-model:value="formData.KEIYAKU_DATE_FROM"></DateJp>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <read-only
                thWidth="220"
                th="契豹区分(変更前)"
                :td="formData.KEIYAKU_KBN_MAE"
              />
              <read-only
                thWidth="220"
                th="契約区分(変更後)"
                :td="formData.KEIYAKU_KBN_ATO"
              />
            </a-col>

            <a-col span="24">
              <th class="required">入力確認有無</th>
              <td>
                <a-radio-group
                  v-model:value="formData.SYORI_KBN"
                  class="ml-2 h-full pt-1"
                >
                  <a-radio :value="1">入力中</a-radio>
                  <a-radio :value="2">入力確認</a-radio>
                </a-radio-group>
              </td>
            </a-col>
          </a-row>
        </div>
        <div
          v-if="!isEditing"
          class="search-disabled-mask bg-disabled max-w-300"
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
import { SearchRowVM } from '../interface/3020/type'
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
const isSearched = ref(false)
const isEditing = ref(false)

const createDefaultform = () => {
  return {
    KEIYAKU_DATE_FROM: new Date(),
    KEIYAKU_KBN_MAE: '',
    KEIYAKU_KBN_ATO: '',
    SYORI_KBN: 1,
    UP_DATE: undefined,
  }
}

const formData = reactive(createDefaultform())
const LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRowVM[]>([])
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
  KEIYAKU_DATE_FROM: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '変更年月日'),
    },
  ],
})
const rules1 = reactive({
  KEIYAKU_DATE_FROM: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '変更年月日'),
    },
  ],
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
const {
  validate: validate1,
  clearValidate: clearValidate1,
  validateInfos: validateInfos1,
} = Form.useForm(formData, rules1)

const xTableRef = ref<VxeTableInstance>()
const tableDefault = {
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: new Date('2024-08-15'),
  /** 契約区分(変更前) */
  KEIYAKU_KBN_MAE: '月額契約',
  /** 契約区分(変更後) */
  KEIYAKU_KBN_ATO: '年間契約',
  /** 処理状況 */
  SYORI_KBN: '処理済み',
  /** 請求回数 */
  SEIKYU_KAISU: 3,
}

const router = useRouter()
const route = useRoute()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isDataSelected = computed(() => {
  return tableData.value.length > 0 && xTableRef.value?.getCurrentRecord()
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
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
  isSearched.value = true
}
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})

//条件クリア
const reset = () => {
  clear()
  clearValidate()
  isSearched.value = false
  isEditing.value = false
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
const save = async () => {
  await validate1()
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
