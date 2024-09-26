<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者別基本情報·農場登録情報 SVデータ作成
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.18
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div
    class="h-full flex-col-stretch gap-12px overflow lt-sm:overflow-auto flex"
  >
    <a-card class="staticWidth"
      ><h1>（GJ7030）互助基金契約者互助金情報検索CSVデ一夕作成</h1>
      <div class="self_adaption_table form mt-1">
        <a-row
          ><a-col span="24"
            ><th class="required">対象期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI" class="w-50!">
                <a-input-number
                  v-model:value="searchParams.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  class="w-14"
                ></a-input-number>
                <span class="align-middle">期</span></a-form-item
              ><a-form-item v-bind="validateInfos.KEISAN_DATE">
                <MonthJp
                  v-model:value="searchParams.KEISAN_DATE"
                />　末　現在</a-form-item
              >
            </td></a-col
          >
          <a-col span="24"
            ><th>都道府県</th>
            <td>
              <a-form-item v-bind="validateInfos.KEN_CD">
                <range-select
                  v-model:value="searchParams.KEN_CD"
                  :options="LIST"
                  class="w-90!"
              /></a-form-item></td
          ></a-col>
          <a-col span="24"
            ><th>契約者番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  class="max-w-250!"
              /></a-form-item></td></a-col
          ><a-col span="24"
            ><th>契約区分</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  class="max-w-78"
              /></a-form-item></td
          ></a-col>
          <a-col span="24"
            ><th>契約状況</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  class="max-w-78"
              /></a-form-item></td></a-col
          ><a-col span="24"
            ><th>事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  class="max-w-250!"
              /></a-form-item></td
          ></a-col>
          <a-col span="24"
            ><th>認定回数</th>
            <td>
              <a-form-item v-bind="validateInfos.HASSEI_KAISU">
                <range-number v-model:value="searchParams.HASSEI_KAISU"
              /></a-form-item></td
          ></a-col>
          <a-col span="24"
            ><th class="required">交付通知書</th>
            <td>
              <a-space :size="40" class="align-middle!">
                <a-checkbox
                  v-model:checked="searchParams.SYORI_JOKYO.HAKKO_ZUMI"
                  >発行済</a-checkbox
                >
                <a-checkbox v-model:checked="searchParams.SYORI_JOKYO.MI_HAKKO"
                  >未発行</a-checkbox
                ></a-space
              >
            </td></a-col
          ><a-col span="24"
            ><th>通知書発行日</th>
            <td>
              <a-form-item
                v-bind="validateInfos.KOFUTUTI_HAKKO_DATE"
                class="max-w-90!"
              >
                <range-date
                  v-model:value="
                    searchParams.KOFUTUTI_HAKKO_DATE
                  " /></a-form-item
              ><span class="w-40 mt-1">(発行済のみ有効)</span>
            </td>
          </a-col>
          <a-col span="24"
            ><th>出力項目選択</th>
            <td>
              <a-radio-group
                v-model:value="searchParams.SYUTURYOKU_KOMOKU_SENTAKU"
              >
                <a-radio :value="1">互助金明細を含む(農場別)</a-radio
                ><a-radio :value="2">含まない（振込金額等のみ）</a-radio>
              </a-radio-group>
            </td></a-col
          ></a-row
        >
      </div>
      <div class="my-2 flex">
        <a-space
          ><span>検索方法</span>
          <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
            <a-radio :value="EnumAndOr.AndCode">すべてを含む(AND)</a-radio>
            <a-radio :value="EnumAndOr.OrCode">いずれかを含む(OR)</a-radio>
          </a-radio-group></a-space
        >
      </div>
      <div class="flex">
        <a-space :size="20">
          <a-button type="primary" @click="search">検索</a-button>
          <a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button class="ml-20" type="primary" @click="">CSV出力</a-button>
        </a-space>
        <close-page /></div></a-card
    ><a-card class="flex-1 staticWidth" ref="cardRef">
      <a-pagination
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="
          (total) => `発行別契約件数： ${total} 件　明細件数：${total} 件`
        "
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        class="mt-2"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="HASSEI_KAISU"
          title="認定回数"
          width="90"
          align="right"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKUSYA_CD"
          title="契約者番号"
          width="100"
          align="right"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        ></vxe-column>

        <vxe-column
          header-align="center"
          field="KEIYAKUSYA_NAME"
          title="契約者名"
          min-width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        ></vxe-column>

        <vxe-column
          header-align="center"
          field="KEIYAKUSYA_KANA"
          title="フリガナ"
          min-width="160"
          sortable
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>

        <vxe-column
          header-align="center"
          field="KEIYAKU_KBN_NAME"
          title="契約区分"
          align="center"
          min-width="120"
          sortable
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEN_CD_NAME"
          title="都道府県"
          min-width="120"
          sortable
          :params="{ order: 5 }"
          :resizable="true"
        ></vxe-column>

        <vxe-column
          header-align="center"
          field="ITAKU_NAME"
          title="事務委託先"
          min-width="160"
          sortable
          :params="{ order: 6 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="FURIKOMI_YOTEI_DATE"
          title="振込予定日"
          min-width="120"
          sortable
          formatter="jpDate"
          :params="{ order: 7 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KOFU_KIN_KEI"
          title="互助交付金"
          min-width="120"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>
<script lang="ts" setup>
import { onMounted, reactive, ref, toRef, watch } from 'vue'
import { EnumAndOr } from '@/enum'
import { VxeTableInstance } from 'vxe-table'
import { SearchRequest, SearchRowVM } from './type'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import useSearch from '@/hooks/useSearch'
import { changeTableSort } from '@/utils/util'
import { useElementSize } from '@vueuse/core'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const xTableRef = ref<VxeTableInstance>()
const createDefaultParams = (): SearchRequest => {
  return {
    KI: undefined, // 対象期
    KEISAN_DATE: undefined, // 対象年月
    KEN_CD: { VALUE_FM: undefined, VALUE_TO: undefined }, // 都道府県
    KEIYAKUSYA_CD: { VALUE_FM: undefined, VALUE_TO: undefined }, // 契約者番号
    KEIYAKU_KBN: { VALUE_FM: undefined, VALUE_TO: undefined }, // 契約区分
    KEIYAKU_JYOKYO: { VALUE_FM: undefined, VALUE_TO: undefined }, // 契約状況
    JIMUITAKU_CD: { VALUE_FM: undefined, VALUE_TO: undefined }, // 事務委託先
    HASSEI_KAISU: { VALUE_FM: undefined, VALUE_TO: undefined }, // 認定回数
    SYORI_JOKYO: {
      HAKKO_ZUMI: true,
      MI_HAKKO: true,
    }, // 交付通知書処理状況
    KOFUTUTI_HAKKO_DATE: { VALUE_FM: undefined, VALUE_TO: undefined }, // 通知書発行日
    SYUTURYOKU_KOMOKU_SENTAKU: 1, // 出力項目選択
    SEARCH_METHOD: EnumAndOr.AndCode, // 検索方法
  }
}
const searchParams = reactive(createDefaultParams())

const LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRowVM[]>([])
const tableDefault = {
  HASSEI_KAISU: 3, // 認定回数
  KEIYAKUSYA_CD: 100123, // 契約者番号
  KEIYAKUSYA_NAME: '山田 太郎', // 契約者名
  KEIYAKUSYA_KANA: 'ヤマダ タロウ', // フリガナ
  KEIYAKU_KBN: 1, // 契約区分コード
  KEIYAKU_KBN_NAME: '基本契約', // 契約区分名
  KEN_CD: 13, // 都道府県コード
  KEN_CD_NAME: '東京都', // 都道府県コード名
  ITAKU_CD: 200456, // 事務委託先コード
  ITAKU_NAME: '株式会社ABC', // 事務委託先名
  FURIKOMI_YOTEI_DATE: new Date('2024-10-01'), // 振込予定日
  KOFU_KIN_KEI: 500000, // 互助交付金
}
const layout = {
  md: 24,
  lg: 24,
  xl: 12,
  xxl: 12,
}
const cardRef = ref()
const { height } = useElementSize(cardRef)
const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKU_DATE_TO: [
    {
      validator: (_rule, value: string) => {
        if (searchParams.KEISAN_DATE && !value) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象年月')
          )
        }
        return Promise.resolve()
      },
    },
  ],
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})
const search = () => {
  tableData.value.push(tableDefault)
}
const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  clear()
  clearValidate()
}
</script>

<style lang="scss" scoped>
th {
  min-width: 195px;
}
</style>
