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
    v-show="detailKbn === FarmManage.Detail"
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto flex"
  >
    <a-card :bordered="false">
      <h1>（GJ3010）互助基金契約者情報変更(增羽)</h1>
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
            </td>
          </a-col>
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
          ><a-button
            class="ml-20"
            type="primary"
            @click="turnExportPage"
            :disabled="!isDataSelected || isEditing"
            >請求書発行
          </a-button>
        </a-space>
        <close-page /></div
    ></a-card>
    <a-card class="flex-1">
      <div class="flex justify-between">
        <h2>1.契約農場別明細 增羽情報(表示)</h2>
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
          title="増羽年月日"
          min-width="160"
          sortable
          formatter="jpDate"
          :params="{ order: 1 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME"
          title="農場名"
          min-width="100"
          sortable
          :params="{ order: 2 }"
          ><template #default="{ row }">
            <a @click="edit()">{{ row.NOJO_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="TORI_KBN_NAME"
          title="鳥の種類"
          min-width="100"
          sortable
          :params="{ order: 3 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="ZO_HASU"
          title="増羽数"
          min-width="100"
          sortable
          :params="{ order: 4 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKU_HASU_MAE"
          title="契約羽数(増羽前)"
          min-width="100"
          sortable
          :params="{ order: 5 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKU_HASU"
          title="契約羽数(増羽後)"
          min-width="100"
          sortable
          :params="{ order: 6 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SYORI_KBN"
          title="処理区分"
          min-width="50"
          sortable
          :params="{ order: 7 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KAISU"
          title="請求回数"
          min-width="100"
          sortable
          :params="{ order: 8 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>

      <h2>2.契豹農場別明細 增羽情報(入力)</h2>
      <a-space :size="20" 　class="mb-2">
        <a-button
          :class="{ 'warning-btn': isEditing }"
          :disabled="!isEditing"
          @click="save"
          >保存</a-button
        ><a-button type="primary" :disabled="!isDataSelected || isEditing"
          >削除</a-button
        >
        <a-button type="primary" :disabled="!isEditing" @click="cancel"
          >キャンセル</a-button
        >
      </a-space>
      <div class="parent-container">
        <div class="self_adaption_table form max-w-300">
          <a-row>
            <a-col span="24">
              <th class="required">農場</th>
              <td>
                <a-form-item v-bind="validateInfos.NOJO_CD">
                  <ai-select
                    v-model:value="formData.NOJO_CD"
                    :options="LIST"
                    split-val
                  ></ai-select>
                </a-form-item>
                <a-button
                  class="ml-2"
                  type="primary"
                  :disabled="!isEditing"
                  @click="addNojo"
                  >農場登録</a-button
                >
              </td>
            </a-col>
            <a-col span="24">
              <read-only thWidth="120" th="農場住所" td="" :hideTd="true" />
              <read-only th="　〒　" :td="nojoData.ADDR_POST" />
              <read-only thWidth="100" th="住所1" :td="nojoData.ADDR_1" />
              <read-only thWidth="100" th="住所2" :td="nojoData.ADDR_2" />
            </a-col>
            <a-col span="24">
              <read-only thWidth="120" th="" :hideTd="true" />
              <read-only thWidth="100" th="住所3" :td="nojoData.ADDR_3" />
              <read-only thWidth="100" th="住所4" :td="nojoData.ADDR_4" />
            </a-col>
            <a-col span="12">
              <th class="required">鳥の種類</th>
              <td>
                <a-form-item v-bind="validateInfos.TORI_KBN">
                  <ai-select
                    v-model:value="formData.TORI_KBN"
                    :options="LIST"
                    class="w-full"
                    split-val
                  ></ai-select>
                </a-form-item>
              </td> </a-col
            ><a-col span="12">
              <th class="required">増羽数</th>
              <td>
                <a-form-item v-bind="validateInfos.ZOGEN_HASU">
                  <a-input-number
                    v-model:value="formData.ZOGEN_HASU"
                    class="w-full"
                    v-bind="{ ...mathNumber }"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <read-only
                thWidth="130"
                th="契豹羽数(増羽前)"
                :td="KEIYAKU_HASU"
              />
              <read-only
                thWidth="130"
                th="契約羽数(増羽後)"
                :td="Number(formData.ZOGEN_HASU) + Number(KEIYAKU_HASU)"
              />
            </a-col>
            <a-col span="12">
              <th class="required">増羽年月日</th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
                  <DateJp v-model:value="formData.KEIYAKU_DATE_FROM"></DateJp>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="12">
              <th class="required">検索方法</th>
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
          class="search-disabled-mask bg-disabled max-w-300"
        ></div>
      </div>
    </a-card>
  </div>
  <NoJoJoHo
    v-if="detailKbn === FarmManage.FarmInfo"
    v-model:detailKbn="detailKbn"
  />
</template>
<script setup lang="ts">
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import NoJoJoHo from '../../../GJ10/GJ1010/modules/Popup/PopUp_1013.vue'
import { onMounted, reactive, ref, toRef, computed } from 'vue'
import useSearch from '@/hooks/useSearch'
import { changeTableSort, mathNumber } from '@/utils/util'
import { useRoute, useRouter } from 'vue-router'
import { PageStatus } from '@/enum'
import { VxeTableInstance } from 'vxe-table'
import { FarmManage } from '@/views/GJ10/GJ1010/constant'
import { SearchRowVM } from '../type'
import { nextTick } from 'process'
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
const detailKbn = ref(FarmManage.Detail)

const createDefaultform = () => {
  return {
    NOJO_CD: undefined,
    TORI_KBN: undefined,
    ZOGEN_HASU: undefined,
    KEIYAKU_DATE_FROM: new Date(),
    SYORI_KBN: 1,
  }
}

const formData = reactive(createDefaultform())
const createDefaultnojo = () => {
  return {
    NOJO_CD: undefined,
    ADDR_POST: '',
    ADDR_1: '',
    ADDR_2: '',
    ADDR_3: '',
    ADDR_4: '',
  }
}
const nojoData = reactive(createDefaultnojo())
const KEIYAKU_HASU = ref(undefined) //契約羽数(増羽前)
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
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
const xTableRef = ref<VxeTableInstance>()
const tableDefault = {
  KI: 2024, // 期
  KEIYAKUSYA_CD: 123456, // 契約者番号
  KEIYAKU_DATE_TO: new Date('2024-12-31'), // 契約年月日To (Date类型)
  NOJO_CD: 101, // 農場コード
  KEIYAKU_KBN: 1, // 契約区分
  TORI_KBN: 2, // 鳥の種類コード
  KEIYAKU_DATE_FROM: new Date('2024-01-01'), // 増羽年月日 (Date类型)
  NOJO_NAME: '亜伊伊伊伊（伊）', // 農場名 (String类型)
  TORI_KBN_NAME: '肉用', // 鳥の種類名 (String类型)
  ZO_HASU: 1573, // 増羽数 (Number类型)
  KEIYAKU_HASU_MAE: 1500, // 契約羽数(増羽前) (Number类型，可选)
  KEIYAKU_HASU: 1600, // 契約羽数(増羽後) (Number类型)
  SYORI_KBN: '入力確定', // 処理区分 (String类型)
  SEIKYU_KAISU: 216, // 請求回数 (Number类型，可选)
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
//農場登録
const addNojo = () => {
  detailKbn.value = FarmManage.FarmInfo
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
  position: relative; /* 确保相对定位 */
}
</style>
