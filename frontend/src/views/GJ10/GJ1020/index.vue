<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者情報変更
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card :bordered="false">
      <h1>(GJ1020)互助基金契約者情報変更（移動）</h1>
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
                  class="w-full"
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
                ></ai-select>
              </a-form-item>
            </td> </a-col
        ></a-row>
      </div>
      <div class="flex mt-2">
        <a-space>
          <a-button type="primary">検索</a-button>
          <a-button type="primary">新規</a-button>
          <a-button type="primary">条件クリア</a-button>
        </a-space>
        <close-page />
      </div> </a-card
    ><a-card>
      <div class="flex justify-between">
        <h2>1.契約農場別明細 移動情報(表示)</h2>
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
        :height="168"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          field="NOJO_CD"
          title="移動開始日"
          min-width="160"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          field="NOJO_NAME"
          title="鳥の種類"
          min-width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          field="ADDR"
          title="移動羽数"
          min-width="160"
          sortable
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="NOJO_NAME"
          title="農場名(移動元)"
          min-width="160"
          sortable
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="NOJO_NAME"
          title="契約羽数(移動元)"
          min-width="160"
          sortable
          :params="{ order: 5 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="NOJO_NAME"
          title="農場名(移動先)"
          min-width="160"
          sortable
          :params="{ order: 6 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="NOJO_NAME"
          title="契約羽数(移動先)"
          min-width="160"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          field="NOJO_NAME"
          title="処理区分"
          min-width="160"
          sortable
          :params="{ order: 8 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>
      <h2>2.契豹農場別明細 移動情報(入力)</h2>
      <a-space :size="20" 　class="mb-2">
        <a-button class="warning-btn">登録</a-button>
        <a-button type="primary">キャンセル</a-button>
      </a-space>
      <div class="self_adaption_table form max-w-300">
        <a-row>
          <a-col span="12">
            <th class="required">鶏の種類</th>
            <td>
              <a-form-item v-bind="validateInfos.a">
                <ai-select
                  v-model:value="formData.a"
                  :options="LIST"
                  class="w-full"
                  split-val
                ></ai-select>
              </a-form-item>
            </td> </a-col
          ><a-col span="12">
            <th class="required">移動羽数</th>
            <td>
              <a-form-item v-bind="validateInfos.a">
                <a-input></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">農場(移動元)</th>
            <td>
              <a-form-item v-bind="validateInfos.NOJO_CD">
                <ai-select
                  v-model:value="formData.a"
                  :options="LIST"
                  split-val
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <read-only thWidth="120" th="農場住所" td="" :hideTd="true" />
            <read-only th="　〒　" :td="formData.a" />
            <read-only thWidth="100" th="住所1" :td="formData.a" />
            <read-only thWidth="100" th="住所2" :td="formData.a" />
          </a-col>
          <a-col span="24">
            <read-only thWidth="120" th="" :hideTd="true" :td="formData.a" />
            <read-only thWidth="100" th="住所3" :td="formData.a" />
            <read-only thWidth="100" th="住所4" :td="formData.a" />
          </a-col>
          <a-col span="24">
            <read-only thWidth="220" th="契豹羽数(移動前)" :td="formData.a" />
            <read-only thWidth="220" th="契約羽数(移動後)" :td="formData.a" />
          </a-col>
          <a-col span="24">
            <th class="required">農場(移動先)</th>
            <td>
              <a-form-item v-bind="validateInfos.NOJO_CD">
                <ai-select
                  v-model:value="formData.a"
                  :options="LIST"
                  split-val
                ></ai-select>
              </a-form-item>
              <a-button class="ml-2" type="primary">農場登録</a-button>
            </td>
          </a-col>
          <a-col span="24">
            <read-only thWidth="120" th="農場住所" td="" :hideTd="true" />
            <read-only th="　〒　" :td="formData.a" />
            <read-only thWidth="100" th="住所1" :td="formData.a" />
            <read-only thWidth="100" th="住所2" :td="formData.a" />
          </a-col>
          <a-col span="24">
            <read-only thWidth="120" th="" :hideTd="true" :td="formData.a" />
            <read-only thWidth="100" th="住所3" :td="formData.a" />
            <read-only thWidth="100" th="住所4" :td="formData.a" />
          </a-col>
          <a-col span="24">
            <read-only thWidth="220" th="契豹羽数(移動前)" :td="formData.a" />
            <read-only thWidth="220" th="契約羽数(移動後)" :td="formData.a" />
          </a-col>
          <a-col span="12">
            <th class="required">移動年月日</th>
            <td>
              <a-form-item v-bind="validateInfos.a">
                <DateJp v-model:value="formData.c"></DateJp>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">入力確認有無</th>
            <td>
              <a-radio-group
                v-model:value="formData.b"
                class="ml-2 h-full pt-1"
              >
                <a-radio :value="1">有</a-radio>
                <a-radio :value="2">無</a-radio>
              </a-radio-group>
            </td>
          </a-col>
        </a-row>
      </div>
    </a-card>
  </div>
</template>
<script lang="ts" setup>
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { onMounted, reactive, ref, toRef } from 'vue'
import { SearchRequest } from '../type'
import useSearch from '@/hooks/useSearch'
import { changeTableSort } from '@/utils/util'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = (): SearchRequest => {
  return {
    KI: -1,
    KEIYAKUSYA_CD: undefined,
  } as SearchRequest
}
const searchParams = reactive(createDefaultParams())
const createDefaultform = () => {
  return {
    a: '',
    b: '',
    c: '',
  }
}
const formData = reactive(createDefaultform())
const LIST = ref<CmCodeNameModel[]>([])
const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const tableData = ref([])

const layout = {
  md: 12,
  lg: 12,
  xl: 12,
  xxl: 6,
}
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
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
</style>
