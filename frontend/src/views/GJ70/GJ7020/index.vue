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
    <a-card
      ><h1>（GJ7020）互助基金契約者積立金情報検索CSVデ一夕作成</h1>
      <div class="self_adaption_table form mt-1">
        <a-row
          ><a-col span="12"
            ><th class="required">対象期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="searchParams.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  class="w-14"
                ></a-input-number>
                <span class="align-middle">期</span></a-form-item
              >
            </td></a-col
          >
          <a-col span="12"
            ><th>契約日未入力者を除く</th>
            <td>
              <a-checkbox
                v-model:checked="searchParams.KEIYAKU_DATE_NOZOKU_FLG"
              ></a-checkbox></td
          ></a-col>
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
              /></a-form-item></td></a-col
          ><a-col span="24"
            ><th>契約区分</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  class="w-130!"
              /></a-form-item></td
          ></a-col>
          <a-col span="24"
            ><th>契約状況</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
                  class="w-130!"
              /></a-form-item></td></a-col
          ><a-col span="24"
            ><th>事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <range-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="LIST"
              /></a-form-item></td
          ></a-col>
          <a-col span="24"
            ><th class="required">契約変更</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKU_HENKO_KBN">
                <a-space class="flex-wrap" :size="40">
                  <a-checkbox
                    v-for="(label, key, index) in KEIYAKU_HENKO_KBN_LABELS"
                    :key="key"
                    v-model:checked="searchParams.KEIYAKU_HENKO_KBN[key]"
                    :class="
                      devicePixelRatio > 1.25
                        ? ''
                        : index === 0
                          ? 'w-60!'
                          : 'w-35!'
                    "
                  >
                    {{ label }}
                  </a-checkbox></a-space
                ></a-form-item
              >
            </td></a-col
          >
          <a-col span="24"
            ><th class="required">請求・返還区分</th>
            <td>
              <a-form-item v-bind="validateInfos.SEIKYU_HENKAN_KBN">
                <a-space class="flex-wrap" :size="40">
                  <a-checkbox
                    v-for="(label, key, index) in SEIKYU_HENKAN_KBN_LABELS"
                    :key="key"
                    v-model:checked="searchParams.SEIKYU_HENKAN_KBN[key]"
                    :class="
                      devicePixelRatio > 1.25
                        ? ''
                        : index === 0
                          ? 'w-60!'
                          : 'w-35!'
                    "
                  >
                    {{ label }}
                  </a-checkbox></a-space
                ></a-form-item
              >
            </td></a-col
          >
          <a-col span="24"
            ><th class="required">入金・振込状況</th>
            <td>
              <a-form-item v-bind="validateInfos.SYORI_JOKYO_KBN">
                <a-space class="flex-wrap" :size="40">
                  <a-checkbox
                    v-for="(label, key, index) in SYORI_JOKYO_KBN_LABELS"
                    :key="key"
                    v-model:checked="searchParams.SYORI_JOKYO_KBN[key]"
                    :class="
                      devicePixelRatio > 1.25
                        ? ''
                        : index === 0
                          ? 'w-60!'
                          : 'w-35!'
                    "
                  >
                    {{ label }}
                  </a-checkbox></a-space
                ></a-form-item
              >
            </td></a-col
          ><a-col span="24"
            ><th>請求・返還日</th>
            <td>
              <a-form-item v-bind="validateInfos.SEIKYU_DATE">
                <range-date v-model:value="searchParams.SEIKYU_DATE"
              /></a-form-item>
            </td>
          </a-col>
          <a-col span="24"
            ><th>入金・振込日</th>
            <td>
              <a-form-item v-bind="validateInfos.NYUKIN_DATE">
                <range-date v-model:value="searchParams.NYUKIN_DATE"
              /></a-form-item>
            </td>
          </a-col>
          <a-col span="24"
            ><th>出力項目選択</th>
            <td>
              <a-radio-group
                v-model:value="searchParams.SYUTURYOKU_KOMOKU_SENTAKU"
              >
                <a-radio :value="1">積立金ペース(鶏の種類別)</a-radio
                ><a-radio :value="2">請求ペース(鶏の種類別)</a-radio>
                <a-radio :value="3">請求ペース(合計)</a-radio>
              </a-radio-group>
            </td></a-col
          >
        </a-row>
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
    ><a-card class="flex-1" ref="cardRef">
      <a-pagination
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="(total) => `契約件数： ${total} 件　明細件数：${total} 件`"
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
          align="center"
          field="KEIYAKU_KBN_NAME"
          title="契約区分"
          min-width="120"
          sortable
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="KEN_CD_NAME"
          title="都道府県"
          min-width="160"
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
          align="right"
          field="SEIKYU_KAISU"
          title="回数"
          min-width="50"
          sortable
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SEIKYU_DATE"
          title="請求・返還日"
          formatter="jpDate"
          min-width="120"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="KEIYAKU_HENKO_KBN_NAME"
          title="契約変更"
          min-width="120"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SEIKYU_HENKAN_KBN_NAME"
          title="請求・返還区分"
          min-width="120"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KIN"
          title="請求・返還金額"
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
    KEIYAKU_DATE_NOZOKU_FLG: true,
    KI: undefined,
    KEN_CD: { VALUE_FM: undefined, VALUE_TO: undefined },
    KEIYAKUSYA_CD: { VALUE_FM: undefined, VALUE_TO: undefined },
    KEIYAKU_KBN: { VALUE_FM: undefined, VALUE_TO: undefined },
    KEIYAKU_JYOKYO: { VALUE_FM: undefined, VALUE_TO: undefined },
    JIMUITAKU_CD: { VALUE_FM: undefined, VALUE_TO: undefined },
    KEIYAKU_HENKO_KBN: {
      SYOKI_KEIYAKU: true,
      ZOHA: true,
      KEIYAKU_KBN_HENKO: true,
      JOTO: true,
      IDO: true,
    },
    SEIKYU_HENKAN_KBN: {
      SEIKYU_SHINKI: true,
      ICHIBU_SEIKYU: true,
      ICHIBU_HENKAN: true,
      ZENGAKU_HENKAN: true,
    },
    SYORI_JOKYO_KBN: {
      NYUKIN_FURIKOMI_ZUMI: true,
      MI_NYUKIN_FURIKOMI: true,
      ICHIBU_NYUKIN: true,
    },
    SEIKYU_DATE: { VALUE_FM: undefined, VALUE_TO: undefined },
    NYUKIN_DATE: { VALUE_FM: undefined, VALUE_TO: undefined },
    SYUTURYOKU_KOMOKU_SENTAKU: 1,
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}
const searchParams = reactive(createDefaultParams())
const LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRowVM[]>([])
const tableDefault = {
  KEIYAKUSYA_CD: 123456, // 契約者番号
  KEIYAKUSYA_NAME: '山田太郎', // 契約者名
  KEIYAKU_KBN: 1, // 契約区分コード
  KEIYAKU_KBN_NAME: '新規契約', // 契約区分名
  KEN_CD: 13, // 都道府県コード
  KEN_CD_NAME: '東京都', // 都道府県コード名
  ITAKU_CD: 200, // 事務委託先コード
  ITAKU_NAME: '株式会社ABC', // 事務委託先名
  SEIKYU_KAISU: 3, // 回数
  SEIKYU_DATE: new Date('2024-09-01'), // 請求・返還日
  KEIYAKU_HENKO_KBN: 2, // 契約変更コード
  KEIYAKU_HENKO_KBN_NAME: '増補', // 契約変更名
  SEIKYU_HENKAN_KBN: 1, // 請求・返還区分コード
  SEIKYU_HENKAN_KBN_NAME: '新規請求', // 請求・返還区分名
  SEIKYU_KIN: 50000, // 請求・返還金額
}
const KEIYAKU_HENKO_KBN_LABELS = {
  SYOKI_KEIYAKU: '初期契約(継続、非継続、新規)',
  ZOHA: '増羽',
  KEIYAKU_KBN_HENKO: '契約区分変更',
  JOTO: '譲渡',
  IDO: '移動',
}
const SEIKYU_HENKAN_KBN_LABELS = {
  SEIKYU_SHINKI: '請求(新規)',
  ICHIBU_SEIKYU: '一部請求',
  ICHIBU_HENKAN: '一部返還',
  ZENGAKU_HENKAN: '全額返還',
}
const SYORI_JOKYO_KBN_LABELS = {
  NYUKIN_FURIKOMI_ZUMI: '入金・振込済',
  MI_NYUKIN_FURIKOMI: '未入金・未振込',
  ICHIBU_NYUKIN: '一部入金',
}

const devicePixelRatio = ref(window.devicePixelRatio)
const cardRef = ref()
const { height } = useElementSize(cardRef)
const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKU_DATE_TO: [
    {
      validator: (_rule, value: string) => {
        if (searchParams.KEIYAKU_DATE_NOZOKU_FLG && !value) {
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
watch(
  () => searchParams.KEIYAKU_DATE_NOZOKU_FLG,
  () => {
    searchParams.KEIYAKU_DATE_TO = undefined
  }
)
window.addEventListener('resize', function () {
  devicePixelRatio.value = window.devicePixelRatio
})
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
