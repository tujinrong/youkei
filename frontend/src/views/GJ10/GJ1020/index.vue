<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者情報変更
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px lt-sm:overflow-auto">
    <a-card :bordered="false">
      <h1>（GJ1020）互助基金契約者情報変更（移動）</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col v-bind="layout">
            <th class="required">期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="searchParams.KI"
                  :min="0"
                  :max="99"
                  :maxlength="2"
                  :disabled="isSearched"
                  class="w-20"
                  @change="getInitData(searchParams.KI, false)"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">契約者</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="KEIYAKUSYA_CD_NAME_LIST"
                  split-val
                  class="max-w-150"
                  :disabled="isSearched"
                ></ai-select>
              </a-form-item>
            </td> </a-col
        ></a-row>
      </div>
      <div class="flex mt-2">
        <a-space :size="20">
          <a-button type="primary" @click="search" :disabled="isSearched"
            >検索</a-button
          >
          <a-button
            type="primary"
            :disabled="!isSearched || isEditing"
            @click="add"
            >新規登録</a-button
          >
          <a-button type="primary" @click="reset">条件クリア</a-button>
        </a-space>
        <close-page />
      </div> </a-card
    ><a-card
      ><h2>1.契約農場別明細 移動情報(表示)</h2>
      <div class="flex justify-between">
        <a-pagination
          v-model:current="pageParams.PAGE_NUM"
          v-model:page-size="pageParams.PAGE_SIZE"
          :total="totalCount"
          :page-size-options="['10', '25', '50', '100']"
          :show-total="(total) => `抽出件数： ${total} 件`"
          show-less-items
          show-size-changer
          class="ml-a"
        />
      </div>
      <vxe-table
        class="my-1"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :height="168"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => edit()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="KEIYAKU_DATE_FROM"
          title="移動開始日"
          min-width="150px"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
          :formatter="({ cellValue }) => getDateJpText(new Date(cellValue))"
          ><template #default="{ row }">
            <a @click="edit()">{{
              getDateJpText(new Date(row.KEIYAKU_DATE_FROM))
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TORI_KBN"
          title="鳥の種類"
          min-width="120px"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="IDO_HASU"
          title="移動羽数"
          min-width="120px"
          sortable
          align="right"
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME_MOTO"
          title="農場名(移動元)"
          sortable
          width="333px"
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_HASU_MOTO_ATO"
          title="契約羽数(移動元)"
          min-width="150px"
          align="right"
          sortable
          :params="{ order: 5 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME_SAKI"
          title="農場名(移動先)"
          width="333px"
          sortable
          :params="{ order: 6 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_HASU_SAKI_ATO"
          title="契約羽数(移動先)"
          min-width="150px"
          align="right"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="SYORI_KBN_NAME"
          title="処理区分"
          min-width="120px"
          sortable
          :params="{ order: 8 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>

      <h2>2.契約農場別明細 移動情報(入力)</h2>
      <a-space :size="20" 　class="mb-2">
        <a-button
          :class="{ 'warning-btn': isEditing }"
          :disabled="!isEditing"
          @click="save"
          >登録</a-button
        >
        <a-button type="primary" :disabled="!isEditing" @click="cancel"
          >キャンセル</a-button
        >
      </a-space>
      <div class="parent-container">
        <div class="self_adaption_table form w-full">
          <a-row>
            <a-col span="24">
              <th class="required">鶏の種類</th>
              <td>
                <a-form-item v-bind="validateInfos.TORI_KBN">
                  <ai-select
                    v-model:value="formData.TORI_KBN"
                    :options="LIST"
                    class="max-w-50"
                    split-val
                  ></ai-select>
                  <span>
                    (1:採卵鶏「成鶏」、2:採卵鶏「育成鶏」、3:肉用鶏、4:種鶏「成鶏」、5:種鶏「育成鶏」、6:うずら、7:あひる、8:きじ、9:ほろほろ鳥、10:七面鳥、11:だちょう)</span
                  >
                </a-form-item>
              </td> </a-col
            ><a-col span="24">
              <th class="required">移動羽数</th>
              <td>
                <a-form-item v-bind="validateInfos.IDO_HASU">
                  <a-input-number
                    v-model:value="formData.IDO_HASU"
                    v-bind="{ ...mathNumber }"
                    class="w-30"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">農場(移動元)</th>
              <td>
                <a-form-item v-bind="validateInfos.NOJO_CD_MOTO">
                  <ai-select
                    v-model:value="formData.NOJO_CD_MOTO"
                    :options="LIST"
                    class="max-w-250"
                    split-val
                  ></ai-select>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <read-only thWidth="120" th="農場住所" td="" :hideTd="true" />
              <read-only th="　〒　" :td="nojoAddr_moto.ADDR_POST" />
              <read-only thWidth="100" th="住所1" :td="nojoAddr_moto.ADDR_1" />
              <read-only thWidth="100" th="住所2" :td="nojoAddr_moto.ADDR_2" />
            </a-col>
            <a-col span="24">
              <read-only thWidth="120" th="" :hideTd="true" />
              <read-only thWidth="100" th="住所3" :td="nojoAddr_moto.ADDR_3" />
              <read-only thWidth="100" th="住所4" :td="nojoAddr_moto.ADDR_4" />
            </a-col>

            <a-col span="24">
              <read-only
                thWidth="220"
                th="契約羽数(移動前)"
                :td="formData.KEIYAKU_HASU_MOTO_MAE"
              />
              <read-only
                thWidth="220"
                th="契約羽数(移動後)"
                :td="formData.KEIYAKU_HASU_MOTO_ATO"
              />
            </a-col>
            <a-col span="24">
              <th class="required">農場(移動先)</th>
              <td>
                <a-form-item v-bind="validateInfos.NOJO_CD_SAKI">
                  <ai-select
                    v-model:value="formData.NOJO_CD_SAKI"
                    :options="LIST"
                    class="max-w-250"
                    split-val
                  ></ai-select>
                </a-form-item>
                <a-button class="ml-2" type="primary">農場登録</a-button>
              </td>
            </a-col>
            <a-col span="24">
              <read-only thWidth="120" th="農場住所" td="" :hideTd="true" />
              <read-only th="　〒　" :td="nojoAddr_saki.ADDR_POST" />
              <read-only thWidth="100" th="住所1" :td="nojoAddr_saki.ADDR_1" />
              <read-only thWidth="100" th="住所2" :td="nojoAddr_saki.ADDR_2" />
            </a-col>
            <a-col span="24">
              <read-only thWidth="120" th="" :hideTd="true" />
              <read-only thWidth="100" th="住所3" :td="nojoAddr_saki.ADDR_3" />
              <read-only thWidth="100" th="住所4" :td="nojoAddr_saki.ADDR_4" />
            </a-col>

            <a-col span="24">
              <read-only
                thWidth="220"
                th="契約羽数(移動前)"
                :td="formData.KEIYAKU_HASU_SAKI_MAE"
              />
              <read-only
                thWidth="220"
                th="契約羽数(移動後)"
                :td="formData.KEIYAKU_HASU_SAKI_ATO"
              />
            </a-col>
            <a-col span="24">
              <th class="required">移動年月日</th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
                  <DateJp
                    v-model:value="formData.KEIYAKU_DATE_FROM"
                    class="max-w-50"
                  ></DateJp>
                </a-form-item>
              </td>
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
          class="search-disabled-mask bg-disabled w-full"
        ></div>
      </div>
    </a-card>
  </div>
</template>
<script lang="ts" setup>
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { onMounted, reactive, ref, toRef } from 'vue'
import { NojoAddrVM, SearchRequest, SearchRowVM } from './type'
import useSearch from '@/hooks/useSearch'
import { changeTableSort, mathNumber } from '@/utils/util'
import { Search } from './service'
import { getDateJpText } from '@/utils/util'
import { VxeTableInstance } from 'vxe-table'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = (): Omit<
  SearchRequest,
  keyof CmSearchRequestBase
> => {
  return {
    KI: -1,
    KEIYAKUSYA_CD: undefined,
  }
}
const searchParams = reactive(createDefaultParams())
const createDefaultform = () => {
  return {
    KI: undefined, // 期
    KEIYAKUSYA_CD: undefined, // 契約者番号
    TORI_KBN: undefined, // 鶏の種類コード
    IDO_HASU: undefined, // 移動羽数
    NOJO_CD_MOTO: undefined, // 農場コード(移動元)
    KEIYAKU_HASU_MOTO_MAE: undefined, // 農場(移動元)　契約羽数(移動前)
    KEIYAKU_HASU_MOTO_ATO: undefined, // 農場(移動元)　契約羽数(移動後)
    NOJO_CD_SAKI: undefined, // 農場コード(移動先)
    KEIYAKU_HASU_SAKI_MAE: undefined, // 農場(移動先)　契約羽数(移動前)
    KEIYAKU_HASU_SAKI_ATO: undefined, // 農場(移動先)　契約羽数(移動後)
    KEIYAKU_DATE_FROM: null, // 移動年月日
    SYORI_KBN: 1, // 入力確認有無
    UP_DATE: null, // データ更新日
  }
}
const formData = reactive(createDefaultform())
const nojoAddr_moto = reactive<NojoAddrVM>({
  NOJO_CD: undefined,
  NOJO_NAME: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
})
const nojoAddr_saki = reactive<NojoAddrVM>({
  NOJO_CD: undefined,
  NOJO_NAME: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
})
const LIST = ref<CmCodeNameModel[]>([])
const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchRowVM[]>([])
const tableDefault = {
  KEIYAKU_DATE_FROM: new Date('2024-01-15'),
  TORI_KBN: 1,
  TORI_KBN_NAME: '鶏の種類A',
  IDO_HASU: 1000,
  NOJO_CD_MOTO: 101,
  NOJO_NAME_MOTO: '農場A',
  KEIYAKU_HASU_MOTO_ATO: 500,
  NOJO_CD_SAKI: 102,
  NOJO_NAME_SAKI: '農場B',
  KEIYAKU_HASU_SAKI_ATO: 500,
  SYORI_KBN_NAME: '処理区分A',
}

const isEditing = ref(false)
const isSearched = ref(false)
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKUSYA_CD: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約者'),
    },
  ],
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
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
//初期化処理
const getInitData = (KI: number, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
}
//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})
function search() {
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
  isSearched.value = true
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
//条件クリア
const reset = () => {
  clear()
  clearValidate()
  isSearched.value = false
  isEditing.value = false
}
//
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
</style>
