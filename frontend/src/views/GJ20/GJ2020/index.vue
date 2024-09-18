<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者積立金計算処理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.03
 * 作成者　　: 阎格
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
      <h1>（GJ2020）契約者積立金計算処理</h1>
      <div class="self_adaption_table form max-w-250 mt-1">
        <a-row>
          <a-col span="24">
            <th class="required">処理区分</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SYORI_KBN">
                <a-radio-group v-model:value="formData.SYORI_KBN" class="mt-1">
                  <a-radio :value="0">請求·返還処理</a-radio>
                  <a-radio :value="1"
                  >請求·返還取消処理(取消対象に入金済が存在する場合は、取消不可)</a-radio
                  >
                </a-radio-group>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">対象期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <!--                <span class="!align-middle">第</span>-->
                <a-input-number
                  v-model:value="formData.KI"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  style="width: 100%"
                ></a-input-number>
                <!--                <span class="!align-middle">期</span>-->
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>請求·返還回数</th>
            <td>
              <a-form-item v-bind="validateInfos.SEIKYU_KAISU">
                <div class="flex items-center">
                  <a-input v-model:value="formData.SEIKYU_KAISU" disabled style="width: 50%;" />
                  <span>(入力&表示)</span>
                </div>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <read-only thWidth="80" th="手数料率" :td="formData.TESURYO_KAISU" after="%" />
          </a-col>
          <a-col span="24">
            <th class="required">徵収·返還区分</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.CYOSYU_HENKAN_KBN">
                <a-space class="flex-wrap">
                  <a-checkbox
                    v-for="(label, key) in LABELS"
                    :key="key"
                    v-model:checked="formData.CYOSYU_HENKAN_KBN[key]"
                  >
                    {{ label }}
                  </a-checkbox></a-space
                ></a-form-item
              >
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">請求·返還年月日</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.SEIKYU_DATE">
                <DateJp v-model:value="formData.SEIKYU_DATE" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">納付期限</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.KIGEN_DATE">
                <DateJp v-model:value="formData.KIGEN_DATE" />
              </a-form-item>
            </td>
            <th class="required">振込予定日</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.FURIKOMI_YOTEI_DATE">
                <DateJp v-model:value="formData.FURIKOMI_YOTEI_DATE" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>契約者番号</th>
            <td class="flex">
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="formData.KEIYAKUSYA_CD"
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  class="w-full"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="my-2 flex">
        <a-space :size="20">
          <a-button type="primary" @click="search">検索</a-button>
          <a-button type="primary" @click="clear">キャンセル</a-button>
          <a-button class="ml-20" type="primary" @click="save">実行</a-button>
        </a-space>
        <AButton type="primary" class="ml-a" @click="tabStore.removeActiveTab">
          閉じる
        </AButton>
      </div>
    </a-card>
    <a-card :bordered="false" class="sm:flex-1-hidden" ref="cardRef">
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
        :height="height - 70"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column header-align="center" align="center" field="KI" title="対象期" width="80" sortable> </vxe-column>
        <vxe-column header-align="center" align="center" field="SEIKYU_KAISU" title="回数" width="80" sortable>
        </vxe-column>
        <vxe-column header-align="center" align="center" field="SYORI_DATE" title="処理日" min-width="100" sortable>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_HENKO_KBN"
          title="計算区分"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SEIKYU_DATE"
          title="請求·返還日"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="KIGEN_DATE"
          title="納付期限"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="FURIKOMI_YOTEI_DATE"
          title="振込予定日"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_TAISYO_SYASU"
          title="対象者数"
          width="90"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="TUMITATE_KINGAKU"
          title="積立金等総額"
          min-width="120"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="CYOSYU_KINGAKU"
          title="徵収金額"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="HENKAN_KINGAKU"
          title="返還金額"
          min-width="100"
          sortable
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { reactive, ref, toRef } from 'vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import useSearch from '@/hooks/useSearch'
import { useElementSize } from '@vueuse/core'
import { changeTableSort } from '@/utils/util'
import { useRoute, useRouter } from 'vue-router'
import { useTabStore } from '@/store/modules/tab'
import { SearchRequest, DetailVM } from './type'
import { VxeTableInstance } from 'vxe-table'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Form } from 'ant-design-vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    SYORI_KBN: 0,
    KI: undefined,
    SEIKYU_KAISU: undefined,
    TESURYO_KAISU: undefined,
    SEIKYU_DATE: new Date().toISOString().split('T')[0],
    KIGEN_DATE: new Date().toISOString().split('T')[0],
    FURIKOMI_YOTEI_DATE: new Date().toISOString().split('T')[0],
    CYOSYU_HENKAN_KBN: {
      SHINKI: true,
      KEIZOKU: true,
      CHUSHI: true,
      HAIGYO: true,
    },
    KEIYAKUSYA_CD: undefined,
  }
}
const formData = reactive(createDefaultParams())
const LABELS = {
  SHINKI: '請求(新規)',
  KEIZOKU: '請求兼返還(徵収)',
  CHUSHI: '請求兼返還(返還)',
  HAIGYO: '全額返還',
}
const rules = reactive({
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  CYOSYU_HENKAN_KBN: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '徴収・返還区分')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  SEIKYU_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
    },
  ],
  KIGEN_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
    },
  ],
  FURIKOMI_YOTEI_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
    },
  ],
})

const { validate, validateInfos } = Form.useForm(formData, rules)
const searchParams = reactive(createDefaultParams())
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
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRequest[]>([])
const tableDefault = {
  KI: 8,
  SEIKYU_KAISU: 216,
  KEIYAKU_HENKO_KBN: '新規',
  SEIKYU_DATE: '36/09/04',
  KIGEN_DATE: '36/09/04',
  FURIKOMI_YOTEI_DATE: '36/09/03',
  SYORI_DATE: '36/09/02',
  SEIKYU_TAISYO_SYASU: 1,
  TUMITATE_KINGAKU: 730,
  CYOSYU_KINGAKU: 730,
  HENKAN_KINGAKU: 0,
}

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
})

const layout = {
  md: 24,
  lg: 8,
  xl: 8,
  xxl: 8,
}

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
//実行処理
function save() {
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}
</script>
<style lang="scss" scoped>
:deep(th) {
  min-width: 150px;
}
</style>
