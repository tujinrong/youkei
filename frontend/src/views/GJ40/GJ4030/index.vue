<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助交付金計算処理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.19
 * 作成者　　: 阎格
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <div class="max-w-800px">
        <h1>（GJ4030）互助交付金計算処理</h1>
        <div class="self_adaption_table form mt-1">
          <a-row>
            <a-col span="24">
              <th class="required">処理区分</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.SYORI_KBN">
                  <a-radio-group
                    v-model:value="formData.SYORI_KBN"
                    class="mt-1"
                  >
                    <a-radio :value="1">計算処理</a-radio>
                    <a-radio :value="2"
                      >計算取消処理(取消対象に補填金支払済が存在する場合は、取消不可)</a-radio
                    >
                  </a-radio-group>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">対象期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI" class="w-50!">
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-14"
                  />
                  <span class="!align-middle">(表示&入力)</span>
                </a-form-item>
                <a-form-item v-bind="validateInfos.HASSEI_KAISU">
                  <span class="!align-middle">認定回数</span>
                  <a-input-number
                    v-model:value="formData.HASSEI_KAISU"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-14"
                  />
                  <span class="!align-middle">(表示&入力)</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>計算回数</th>
              <td>
                <a-form-item v-bind="validateInfos.HASSEI_KAISU">
                  <div class="flex items-center">
                    <a-input-number
                      v-model:value="formData.HASSEI_KAISU"
                      :min="1"
                      :max="99"
                      :maxlength="2"
                      class="w-14"
                      :disabled="formData.SYORI_KBN === 1"
                    />
                    <span>(表示&入力)</span>
                  </div>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">振込予定日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.FURIKOMI_YOTEI_DATE">
                  <DateJp
                    class="max-w-50"
                    v-model:value="formData.FURIKOMI_YOTEI_DATE"
                  />
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
                    class="max-w-115"
                    type="number"
                  ></ai-select>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
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
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="center"
          field="KI"
          title="対象期"
          width="80"
          sortable
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="HASSEI_KAISU"
          title="認定回数"
          min-width="90"
          sortable
        />
        <vxe-column
          header-align="center"
          align="center"
          field="KEISAN_KAISU"
          title="計算回数"
          min-width="90"
          sortable
        />
        <vxe-column
          header-align="center"
          align="center"
          field="SYORI_DATE"
          title="処理日"
          min-width="100"
          sortable
        />
        <vxe-column
          header-align="center"
          align="center"
          field="FURI_YOTEI_DATE"
          title="振込予定日"
          min-width="100"
          sortable
        />
        <vxe-column
          header-align="center"
          align="right"
          field="TAISYO_SYASU"
          title="対象者数"
          min-width="90"
          sortable
        />
        <vxe-column
          header-align="center"
          align="right"
          field="KEIEI_KINGAKU"
          title="経営支援金額"
          min-width="100"
          sortable
        >
          <template #default="{ row }">
            {{ Intl.NumberFormat().format(row.KEIEI_KINGAKU) }}
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SYOKYAKU_KINGAKU"
          title="焼却・埋却金額"
          min-width="100"
          sortable
        >
          <template #default="{ row }">
            {{ Intl.NumberFormat().format(row.SYOKYAKU_KINGAKU) }}
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KOFU_KINGAKU"
          title="合計交付金額"
          min-width="100"
          sortable
        >
          <template #default="{ row }">
            {{ Intl.NumberFormat().format(row.KOFU_KINGAKU) }}
          </template>
        </vxe-column>
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
    SYORI_KBN: 1,
    KI: undefined,
    HASSEI_KAISU: undefined,
    KEISAN_KAISU: undefined,
    FURIKOMI_YOTEI_DATE: new Date().toISOString().split('T')[0],
    KEIYAKUSYA_CD: undefined,
  }
}
const formData = reactive(createDefaultParams())
const rules = reactive({
  SYORI_KBN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '処理区分'),
    },
  ],
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  FURIKOMI_YOTEI_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '振込予定日'),
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
const tableData = ref<SearchRequest[]>([])
const tableDefault = {
  KI: 8,
  HASSEI_KAISU: 3,
  KEISAN_KAISU: 1,
  SYORI_DATE: '35/03/13',
  FURI_YOTEI_DATE: '35/03/16',
  TAISYO_SYASU: 2,
  KEIEI_KINGAKU: 193128909,
  SYOKYAKU_KINGAKU: 0,
  KOFU_KINGAKU: 193128909,
}

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
})

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
  min-width: 120px;
}
</style>
