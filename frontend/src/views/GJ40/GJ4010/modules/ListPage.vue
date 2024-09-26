<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助金申請情報一覧
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.12
 * 作成者　　: 阎格
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card ref="headRef" :bordered="false">
      <h1>（GJ4010）互助金申請情報一覧</h1>
      <div class="self_adaption_table form max-w-400 mt-1">
        <a-row>
          <a-col span="24">
            <th class="required">互助金単価マスタ　参照日</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.TANKA_MST_DATE">
                <DateJp
                  class="max-w-50"
                  v-model:value="formData.TANKA_MST_DATE"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="formData.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  class="w-14"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>認定回数</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.HASSEI_KAISU">
                <range-number v-model:value="formData.HASSEI_KAISU" />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>計算回数</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.KEISAN_KAISU">
                <range-number v-model:value="formData.KEISAN_KAISU" />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>都道府県</th>
            <td>
              <range-select
                v-model:value="formData.KEN_CD"
                :options="KEN_CD_NAME_LIST"
                class="w-90!"
              />
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者番号</th>
            <td>
              <a-input-number
                v-model:value="formData.KEIYASYA_CD"
                :min="1"
                :max="99999"
                :maxlength="5"
                class="w-20"
              ></a-input-number>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約区分</th>
            <td>
              <ai-select
                v-model:value="formData.KEIYAKU_KBN"
                :options="KEIYAKU_KBN_CD_NAME_LIST"
                class="w-37!"
                type="number"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約状況</th>
            <td>
              <ai-select
                v-model:value="formData.KEIYAKU_JYOKYO"
                :options="KEIYAKU_KBN_CD_NAME_LIST"
                class="w-37!"
                type="number"
              ></ai-select>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者名</th>
            <td>
              <div class="flex items-center w-full">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_NAME"
                  class="max-w-115"
                  :maxlength="50"
                  style="width: 80%"
                />
                <span>(部分一致)</span>
              </div>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者名(フリガナ)</th>
            <td>
              <div class="flex items-center w-full">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_KANA"
                  class="max-w-115"
                  :maxlength="50"
                  style="width: 80%"
                />
                <span>(部分一致)</span>
              </div>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>住所</th>
            <td>
              <div class="flex items-center w-full">
                <a-input
                  v-model:value="formData.ADDR"
                  class="w-250"
                  :maxlength="50"
                />
                <span>(部分一致)</span>
              </div>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>電話番号</th>
            <td>
              <div class="flex items-center w-full">
                <a-input
                  v-model:value="formData.ADDR_TEL"
                  class="w-33"
                  :maxlength="50"
                />
                <span>(全一致)</span>
              </div>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.JIMUITAKU_CD">
                <range-select
                  v-model:value="formData.JIMUITAKU_CD"
                  :options="JIMUITAKU_LIST"
                  class="w-250!"
                />
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="my-2 flex justify-between max-w-250">
        <a-space
          ><span>検索方法</span>
          <a-radio-group v-model:value="formData.SEARCH_METHOD">
            <a-radio :value="EnumAndOr.AndCode">すべてを含む(AND)</a-radio>
            <a-radio :value="EnumAndOr.OrCode">いずれかを含む(OR)</a-radio>
          </a-radio-group>
        </a-space>
      </div>
      <div class="my-2 flex">
        <a-space :size="20">
          <a-button type="primary" @click="search">検索</a-button>
          <a-button type="primary" @click="clear">条件クリア</a-button>
          <a-button class="ml-20" type="primary" @click="openGJ4011"
            >経営支援登録</a-button
          >
          <a-button class="ml-20" type="primary" @click="openGJ4013"
            >焼却・埋却登録</a-button
          >
        </a-space>
        <AButton type="primary" class="ml-a" @click="tabStore.removeActiveTab">
          閉じる
        </AButton>
      </div>
    </a-card>
    <a-card :bordered="false" class="flex-1" ref="cardRef">
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
      <vxe-table
        ref="xTableRef"
        class="mt-2"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => openGJ4013(row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYASYA_CD"
          title="契約者番号"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKUSYA_NAME"
          title="契約者名"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR"
          title="住所"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="KEIYAKU_KBN_NAME"
          title="契約区分"
          width="90"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR_TEL1"
          title="電話番号"
          min-width="120"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEN_CD_NAME"
          title="都道府県"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ITAKU_RYAKU"
          title="事務委託先"
          min-width="100"
          sortable
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <Detail1 v-model:visible="GJ4011Visible" :editkbn="GJ4011kbn" />
  <Detail3 v-model:visible="GJ4013Visible" :editkbn="GJ4013kbn" />
</template>
<script setup lang="ts">
import { reactive, ref, toRef } from 'vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import useSearch from '@/hooks/useSearch'
import { useElementSize } from '@vueuse/core'
import { changeTableSort } from '@/utils/util'
import { useRoute, useRouter } from 'vue-router'
import { useTabStore } from '@/store/modules/tab'
import { SearchRequest } from '../type'
import { VxeTableInstance } from 'vxe-table'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Form } from 'ant-design-vue'
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import Detail1 from '@/views/GJ40/GJ4010/modules/Detail/Detail1.vue'
import Detail3 from '@/views/GJ40/GJ4010/modules/Detail/Detail3.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    TANKA_MST_DATE: new Date().toISOString().split('T')[0],
    KI: undefined,
    HASSEI_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEISAN_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEN_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    KEIYASYA_CD: undefined as number | undefined,
    KEIYAKU_KBN: undefined as number | undefined,
    KEIYAKU_JYOKYO: undefined as number | undefined,
    KEIYAKUSYA_KANA: '',
    KEIYAKUSYA_NAME: '',
    ADDR: '',
    ADDR_TEL: '',
    SAGUKU_SEIKYU_KIN: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    JIMUITAKU_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}
const formData = reactive(createDefaultParams())
const rules = reactive({
  TANKA_MST_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
})

const { validate, validateInfos } = Form.useForm(formData, rules)
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()
const cardRef = ref()
const xTableRef = ref<VxeTableInstance>()
const { height } = useElementSize(cardRef)
const KEIYAKU_KBN_CD_NAME_LIST = ref<CmCodeNameModel[]>([
  { CODE: 1, NAME: 'AAAAAAAAAAAAAAAAAAAAA' },
  { CODE: 2, NAME: 'BBBBBBBBBBBBBBBBBBBBB' },
  { CODE: 3, NAME: 'NNNNNNNNNNNNNNNNNNNNN' },
])
const JIMUITAKU_LIST = ref<CmCodeNameModel[]>([])
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRequest[]>([])
const tableDefault = {
  KEIYASYA_CD: '99999',
  KEIYAKUSYA_NAME: 'NNNNNNNNNNNN',
  ADDR: 'NNNNNNNNNNNNNNNNNNNNN',
  KEIYAKU_KBN: '',
  KEIYAKU_KBN_NAME: 'N N N',
  ADDR_TEL1: '999-9999-9999',
  KEN_CD: '',
  KEN_CD_NAME: '99NNN',
  JIMUITAKU_CD: '',
  ITAKU_RYAKU: 'NNNNNNNNNNNNNNNNNNNNN',
}

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => formData),
})

const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}

const GJ4011Visible = ref(false)
const GJ4011kbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const GJ4013Visible = ref(false)
const GJ4013kbn = ref<EnumEditKbn>(EnumEditKbn.Add)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
function search() {
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}
function openGJ4011(row?: any) {
  GJ4011Visible.value = true
}
function openGJ4013(row?: any) {
  GJ4013Visible.value = true
}
</script>
<style lang="scss" scoped>
:deep(th) {
  min-width: 200px;
}
</style>
