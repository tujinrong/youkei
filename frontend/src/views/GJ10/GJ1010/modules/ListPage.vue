<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者マスタ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.27
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <div class="max-w-1150px">
        <h1>（GJ1010）互助基金契約者マスタ一覧</h1>
        <div class="self_adaption_table form mt-1">
          <a-row>
            <a-col span="12">
              <th class="required">期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <a-input-number
                    v-model:value="searchParams.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-14"
                  ></a-input-number
                ></a-form-item>
              </td> </a-col
            ><a-col span="12">
              <th>未継続・未契約者を除く</th>
              <td>
                <a-checkbox
                  v-model:checked="searchParams.NOZOKU_FLG"
                ></a-checkbox>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>都道府県</th>
              <td>
                <range-select
                  v-model:value="searchParams.KEN_CD"
                  :options="KEN_LIST"
                  class="w-90!"
                />
              </td>
            </a-col>

            <a-col v-bind="layout">
              <th>契約者番号</th>
              <td>
                <a-input-number
                  v-model:value="searchParams.KEIYAKUSYA_CD"
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
                  v-model:value="searchParams.KEIYAKU_KBN"
                  :options="KEIYAKU_KBN_LIST"
                  class="w-37!"
                  type="number"
                ></ai-select>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約状況</th>
              <td>
                <ai-select
                  v-model:value="searchParams.KEIYAKU_JYOKYO"
                  :options="KEIYAKU_JYOKYO_LIST"
                  class="w-37!"
                  type="number"
                ></ai-select>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者名</th>
              <td>
                <a-input
                  v-model:value="searchParams.KEIYAKUSYA_NAME"
                  :maxlength="25"
                  class="w-130"
                ></a-input>
                <span class="w-40!">(部分一致)</span>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者名(フリガナ)</th>
              <td>
                <a-input
                  v-model:value="searchParams.KEIYAKUSYA_KANA"
                  :maxlength="50"
                  class="w-130"
                ></a-input>
                <span class="w-40!">(部分一致)</span>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>住所</th>
              <td>
                <a-input
                  v-model:value="searchParams.ADDR"
                  class="w-250"
                  :maxlength="54"
                ></a-input>
                <span class="w-65!">(部分一致)</span>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>電話番号</th>
              <td>
                <a-input
                  v-model:value="searchParams.ADDR_TEL1"
                  class="w-33"
                  :maxlength="14"
                  @input="handleTel"
                ></a-input>
                <span>(全一致)</span>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事務委託先</th>
              <td>
                <range-select
                  v-model:value="searchParams.JIMUITAKU_CD"
                  :options="ITAKU_LIST"
                />
              </td>
            </a-col>
          </a-row>
        </div>
        <div class="my-2 flex justify-between max-w-250">
          <a-space
            ><span>検索方法<span style="color: red">＊</span></span>
            <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
              <a-radio :value="EnumAndOr.AndCode">すべてを含む(AND)</a-radio>
              <a-radio :value="EnumAndOr.OrCode">いずれかを含む(OR)</a-radio>
            </a-radio-group>
          </a-space>
        </div>
      </div>
      <div class="flex">
        <a-space :size="20">
          <a-button type="primary" @click="searchAll">検索</a-button>
          <a-button type="primary" @click="clear">条件クリア</a-button>
          <a-button class="ml-40%" type="primary" @click="forwardAdd"
            >新規登録</a-button
          >
          <a-button
            class="ml-50%"
            type="primary"
            :disabled="!isDataSelected"
            @click="
              goForward(
                PageStatus.Detail,
                xTableRef?.getCurrentRecord() ?? null
              )
            "
            >契約情報登録</a-button
          >
        </a-space>
        <AButton type="primary" class="ml-a" @click="tabStore.removeActiveTab">
          閉じる
        </AButton>
      </div>
    </a-card>
    <a-card :bordered="false" class="flex-1 staticWidth">
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
        height="200px"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.KEIYAKUSYA_CD)"
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
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.KEIYAKUSYA_CD)">{{
              row.KEIYAKUSYA_CD
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKUSYA_NAME"
          title="契約者名"
          width="200"
          sortable
          :params="{ order: 2 }"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.KEIYAKUSYA_CD)">{{
              row.KEIYAKUSYA_NAME
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKUSYA_KANA"
          title="フリガナ"
          min-width="250"
          sortable
          :params="{ order: 3 }"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.KEIYAKUSYA_CD)">{{
              row.KEIYAKUSYA_KANA
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_KBN_NAME"
          title="契約区分"
          min-width="120"
          align="center"
          sortable
          :params="{ order: 4 }"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_JYOKYO_NAME"
          title="契約状況"
          min-width="120"
          align="center"
          sortable
          :params="{ order: 5 }"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR_TEL1"
          title="電話番号"
          min-width="150"
          sortable
          :params="{ order: 6 }"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEN_CD_NAME"
          title="都道府県"
          min-width="150"
          sortable
          :params="{ order: 7 }"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ITAKU_RYAKU"
          title="事務委託先"
          min-width="200"
          sortable
          :params="{ order: 8 }"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage
    v-model:visible="editVisible"
    :editkbn="editkbn"
    :params="searchParams"
    :keys="keyList"
  />
</template>
<script setup lang="ts">
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import { computed, reactive, ref, toRef, nextTick, onMounted } from 'vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import useSearch from '@/hooks/useSearch'
import { changeTableSort } from '@/utils/util'
import { Form } from 'ant-design-vue'
import { useRoute, useRouter } from 'vue-router'
import { useTabStore } from '@/store/modules/tab'
import { SearchRequest, SearchRowVM } from '../service/1010/type'
import { VxeTableInstance } from 'vxe-table'

import EditPage from './Popup/PopUp_1011.vue'
import { Init, Search } from '../service/1010/service'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = (): SearchRequest => {
  return {
    KI: -1,
    KEN_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    NOZOKU_FLG: true,
    KEIYAKUSYA_CD: undefined,
    KEIYAKU_KBN: undefined,
    KEIYAKU_JYOKYO: undefined,
    KEIYAKUSYA_NAME: '',
    KEIYAKUSYA_KANA: '',
    ADDR: '',
    ADDR_TEL1: '',
    JIMUITAKU_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    SEARCH_METHOD: EnumAndOr.AndCode,
  } as SearchRequest
}
const searchParams = reactive(createDefaultParams())
const keyList = reactive({
  KI: undefined,
  KEIYAKUSYA_CD: undefined,
})
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const router = useRouter()
const route = useRoute()
const tabStore = useTabStore()
const xTableRef = ref<VxeTableInstance>()

const KEN_LIST = ref<CmCodeNameModel[]>([])
const KEIYAKU_KBN_LIST = ref<CmCodeNameModel[]>([])
const KEIYAKU_JYOKYO_LIST = ref<CmCodeNameModel[]>([])
const ITAKU_LIST = ref<CmCodeNameModel[]>([])

const tableData = ref<SearchRowVM[]>([])

const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
})
const isDataSelected = computed(() => {
  return tableData.value.length > 0 && xTableRef.value?.getCurrentRecord()
})

const rules = reactive({
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期'),
    },
  ],
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData(searchParams.KI, true)
})

//初期化処理
const getInitData = (KI: number, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
  Init({ KI: KI, EDIT_KBN: EnumEditKbn.Add }).then((res) => {
    if (initflg) searchParams.KI = res.KI
    KEN_LIST.value = res.KEN_LIST
    KEIYAKU_KBN_LIST.value = res.KEIYAKU_KBN_LIST
    KEIYAKU_JYOKYO_LIST.value = res.KEIYAKU_JYOKYO_LIST
    ITAKU_LIST.value = res.ITAKU_LIST
    nextTick(() => clearValidate())
  })
}

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)

//検索処理

const searchAll = async () => {
  tableData.value = []
  const res = await searchData()
  keyList.KI = res.KI

  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}

function goForward(status: PageStatus, row?: any) {
  keyList.KEIYAKUSYA_CD = row.KEIYAKUSYA_CD
  router.push({
    name: route.name,
    query: {
      status: status,
      KI: keyList.KI,
      KEIYAKUSYA_CD: keyList.KEIYAKUSYA_CD,
    },
  })
}
async function forwardAdd() {
  await validate()
  editVisible.value = true
  editkbn.value = EnumEditKbn.Add
}

async function forwardEdit(KEIYAKUSYA_CD) {
  await validate()
  editVisible.value = true
  editkbn.value = EnumEditKbn.Edit
  keyList.KEIYAKUSYA_CD = KEIYAKUSYA_CD
}

function handleTel() {}
</script>
<style lang="scss" scoped>
:deep(th) {
  min-width: 165px;
}
</style>
