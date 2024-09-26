<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者積立金等入金・返還入力
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.10
 * 作成者　　: 阎格
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <h1>（GJ2090）契約者積立金等入金・返還入力</h1>
      <div class="self_adaption_table form max-w-400 mt-1">
        <a-row>
          <a-col
            v-bind="{
              md: 24,
              lg: 24,
              xl: 24,
              xxl: 6,
            }"
          >
            <th class="required">対象期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="formData.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  class="w-14!"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
          <a-col
            v-bind="{
              md: 24,
              lg: 24,
              xl: 24,
              xxl: 8,
            }"
          >
            <th>請求·返還回数</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SEIKYU_KAISU">
                <range-number v-model:value="formData.SEIKYU_KAISU" unit="回"
              /></a-form-item>
            </td>
          </a-col>
          <a-col
            v-bind="{
              md: 24,
              lg: 24,
              xl: 24,
              xxl: 10,
            }"
          >
            <th>入金日・振込日</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SEIKYU_DATE">
                <DateJp v-model:value="formData.SEIKYU_DATE" class="max-w-50" />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>都道府県</th>
            <td>
              <range-select
                class="w-90!"
                v-model:value="formData.KEN_CD"
                :options="KEN_CD_NAME_LIST"
              />
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.JIMUITAKU_CD">
                <ai-select
                  v-model:value="formData.JIMUITAKU_CD"
                  :option="JIMUITAKU_LIST"
                  split-val
                  class="max-w-115"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者番号</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="formData.KEIYAKUSYA_CD"
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  class="max-w-115"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者名(カナ)</th>
            <td>
              <a-input
                v-model:value="formData.KEIYAKUSYA_NAME"
                class="w-130"
                :maxlength="50"
              ></a-input>
              <span class="w-40">（部分一致）</span>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>契約者名(漢字)</th>
            <td>
              <a-input
                v-model:value="formData.KEIYAKUSYA_KANA"
                class="w-130"
                :maxlength="50"
              ></a-input>
              <span class="w-40">（部分一致）</span>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>請求·返還回数(入金金額)</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SAGUKU_SEIKYU_KIN">
                <range-number
                  v-model:value="formData.SAGUKU_SEIKYU_KIN"
                  unit="円"
              /></a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">納付方法</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SEIKYU_HENKAN_KBN">
                <a-radio-group
                  v-model:value="formData.SEIKYU_HENKAN_KBN"
                  class="mt-1"
                >
                  <a-radio :value="1">入金</a-radio>
                  <a-radio :value="2">返還</a-radio>
                </a-radio-group>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">処理状況</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SYORI_JOKYO_KBN">
                <a-radio-group
                  v-model:value="formData.SYORI_JOKYO_KBN"
                  class="mt-1"
                >
                  <a-radio :value="1">全て</a-radio>
                  <a-radio :value="2">未入金・未返還分</a-radio>
                  <a-radio :value="3">入金・返還済分</a-radio>
                </a-radio-group>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-bind="layout">
            <th>入金・返還日</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.NYUKIN_DATE">
                <range-date
                  v-model:value="formData.NYUKIN_DATE"
                  class="w-full"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>入金日・振込日</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SEIKYU_DATE">
                <DateJp v-model:value="formData.SEIKYU_DATE" class="max-w-50" />
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
          <a-button class="ml-20" type="primary" @click="openGJ2091"
            >入金確認</a-button
          >
        </a-space>
        <AButton type="primary" class="ml-a" @click="tabStore.removeActiveTab">
          閉じる
        </AButton>
      </div>
    </a-card>
    <a-card :bordered="false" class="flex-1 staticWidth" ref="cardRef">
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
        @cell-dblclick="({ row }) => openGJ2092(row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKUSYA_CD"
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
          field="KEIYAKUSYA_KANA"
          title="フリガナ"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SYORI_JOKYO_KBN_NAME"
          title="処理状況"
          width="90"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SEIKYU_HENKAN_KBN_NAME"
          title="請求・返還"
          min-width="120"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SEIKYU_DATE"
          title="請求・返還日"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="NYUKIN_DATE"
          title="入金・振込日"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KIN"
          title="請求金額"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KIN"
          title="返還金額"
          min-width="100"
          sortable
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <Detail1 v-model:visible="GJ2091Visible" :editkbn="GJ2091kbn" />
  <Detail2 v-model:visible="GJ2092Visible" :editkbn="GJ2092kbn" />
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
import Detail1 from '@/views/GJ20/GJ2090/modules/Detail/Detail1.vue'
import Detail2 from '@/views/GJ20/GJ2090/modules/Detail/Detail2.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    SYORI_KBN: 0,
    KI: undefined,
    SEIKYU_KAISU: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEN_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    JIMUITAKU_CD: undefined as number | undefined,
    KEIYAKUSYA_CD: undefined as number | undefined,
    KEIYAKUSYA_KANA: '',
    KEIYAKUSYA_NAME: '',
    SAGUKU_SEIKYU_KIN: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    SEIKYU_HENKAN_KBN: 1,
    SYORI_JOKYO_KBN: 2,
    NYUKIN_DATE: {
      VALUE_FM: undefined as Date | undefined,
      VALUE_TO: undefined as Date | undefined,
    },
    SEARCH_METHOD: EnumAndOr.AndCode,
    SEIKYU_DATE: '',
  }
}
const formData = reactive(createDefaultParams())
const rules = reactive({
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
  KI: 8,
  SEIKYU_KAISU: 216,
  TUMITATE_KBN: 1003,
  KEIYAKUSYA_CD: 1,
  KEIYAKUSYA_NAME: 'AAAAAAAAAAAAAAAAAAAAA',
  KEIYAKUSYA_KANA: 'NNNNNNNNNNNNNNNNNNNNN',
  SYORI_JOKYO_KBN: 1,
  SYORI_JOKYO_KBN_NAME: '一部入金',
  SEIKYU_HENKAN_KBN: 1,
  SEIKYU_HENKAN_KBN_NAME: '一部請求',
  SEIKYU_DATE: '平成36/09/03',
  NYUKIN_DATE: '平成36/09/03',
  SEIKYU_KIN: 1,
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

const GJ2091Visible = ref(false)
const GJ2091kbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const GJ2092Visible = ref(false)
const GJ2092kbn = ref<EnumEditKbn>(EnumEditKbn.Add)

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
function openGJ2091(row?: any) {
  GJ2091Visible.value = true
}
function openGJ2092(row?: any) {
  GJ2092Visible.value = true
}
</script>
<style lang="scss" scoped>
:deep(th) {
  min-width: 180px;
}
</style>
