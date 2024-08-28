<!------------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 互助基金契約者マスタ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.27
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card v-show="detailKbn === DetailStatus.Detail1" :bordered="false">
    <h1>(GJ1012)互助基金契約者マスタメンテナンス(契約情報入力)</h1>
    <div class="self_adaption_table form">
      <b>第{{ formData.KI ?? 8 }}期</b>
      <h2 class="text-lg font-bold">1.契約農場別明細情報(表示)</h2>
      <a-row>
        <a-col span="10">
          <read-only thWidth="100" th="契約者" :td="formData.KEIYAKUSYA_NAME" />
        </a-col>
      </a-row>
      <div class="my-2 header_operation flex justify-between w-full">
        <a-space :size="20">
          <a-button type="primary" :disabled="isEdit" @click="addData"
            >新規</a-button
          >
          <a-button type="primary" :disabled="isEdit" @click="changeData"
            >変更</a-button
          >
          <a-button type="primary" @click="goList">一覧</a-button>
        </a-space>
      </div>
    </div>
    <a-pagination
      v-model:current="pageParams.PAGE_NUM"
      v-model:page-size="pageParams.PAGE_SIZE"
      :total="totalCount"
      :page-size-options="['10', '25', '50', '100']"
      :show-total="(total) => `件数： ${total} `"
      show-less-items
      show-size-changer
      class="m-b-1 text-end"
    />
    <vxe-table
      ref="tableRef"
      class="mt-2"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableData"
      :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
      :empty-render="{ name: 'NotData' }"
      @cell-dblclick="({ row }) => goForward(PageStatus.Edit, row)"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
    >
      <vxe-column field="MEISAI_NO" title="明細番号" width="100">
        <template #default="{ row }">
          <a @click="goForward(PageStatus.Edit, row)">{{ row.MEISAI_NO }}</a>
        </template>
      </vxe-column>
      <vxe-column field="NOJO_NAME" title="農場名" width="200">
        <template #default="{ row }">
          <a @click="goForward(PageStatus.Edit, row)">{{ row.NOJO_NAME }}</a>
        </template>
      </vxe-column>
      <vxe-column field="NOJO_ADDR" title="農場住所" min-width="200">
      </vxe-column>
      <vxe-column
        field="TORISYURUI"
        title="鳥の種類"
        min-width="120"
      ></vxe-column>
      <vxe-column
        field="KEIYAKUHASU"
        title="契約羽数"
        min-width="120"
      ></vxe-column>
      <vxe-column
        field="BIKO"
        title="備考"
        min-width="200"
        :resizable="false"
      ></vxe-column>
    </vxe-table>
    <table v-if="devicePixelRatio <= 1.5" class="my-2 table-fixed">
      <tr>
        <th class="!w-10">鶏の種類</th>
        <th>採卵鶏(成鷄)</th>
        <th colspan="1">採卵鶏(育成鶏)</th>
        <th rowspan="1">肉用鶏</th>
        <th>種鶏(成鶏)</th>
        <th>種鶏(育成鶏)</th>
      </tr>
      <tr>
        <th>契約羽数合計</th>
        <td>600</td>
        <td>300</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
      </tr>
      <tr>
        <th>うずら</th>
        <th>あひる</th>
        <th>きじ</th>
        <th>ほろほろ鳥</th>
        <th>七面鳥</th>
        <th>だちょう</th>
        <th>合計</th>
      </tr>
      <tr>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>900</td>
      </tr>
    </table>
    <table v-if="devicePixelRatio > 1.5" class="my-2 table-fixed">
      <tr>
        <th>鶏の種類</th>
        <th>採卵鶏(成鷄)</th>
        <th colspan="1">採卵鶏(育成鶏)</th>
        <th rowspan="1">肉用鶏</th>
      </tr>
      <tr>
        <th>契約羽数合計</th>
        <td>600</td>
        <td>300</td>
        <td>0</td>
      </tr>
      <tr>
        <th>種鶏(成鶏)</th>
        <th>種鶏(育成鶏)</th>
        <th>うずら</th>
        <th>あひる</th>
      </tr>
      <tr>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
      </tr>
      <tr>
        <th>きじ</th>
        <th>ほろほろ鳥</th>
        <th>七面鳥</th>
        <th>だちょう</th>
        <th>合計</th>
      </tr>
      <tr>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>900</td>
      </tr>
    </table>
    <h2>2.契約農場別登録明細情報(入力)</h2>
    <a-space :size="20" class="mb-2">
      <a-button type="primary" :disabled="!isEdit">前期データコピー</a-button
      ><a-button type="primary" :disabled="!isEdit" @click="saveData"
        >保存</a-button
      >
      <a-button type="primary" :disabled="!isEdit" @click="reset"
        >クリア</a-button
      ></a-space
    >
    <div class="self_adaption_table form max-w-300">
      <a-row>
        <a-col span="24">
          <th class="required">明細番号</th>
          <td>
            <a-form-item v-bind="validateInfos.MEISAI_NO">
              <a-input-number
                v-model:value="formData.MEISAI_NO"
                :min="0"
                :max="999"
                :maxlength="3"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">農場</th>
          <td>
            <a-form-item v-bind="validateInfos.NOJO_CD">
              <ai-select
                v-model:value="formData.NOJO_CD"
                :options="NOJO_CD_CD_NAME_LIST"
                split-val
                :disabled="!isEdit"
              ></ai-select>
            </a-form-item>
            <a-button
              class="ml-2"
              type="primary"
              :disabled="!isEdit"
              @click="addNoJo"
              >農場登録</a-button
            >
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <read-only thWidth="110" th="住所" td="" :hideTd="true" />
          <read-only th="　〒　" :td="formData.ADDR_POST" />
          <read-only thWidth="100" th="住所1" :td="formData.ADDR_1" />
          <read-only thWidth="100" th="住所2" :td="formData.ADDR_2" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <read-only
            thWidth="110"
            th=""
            :hideTd="true"
            :td="formData.ADDR_POST"
          />
          <read-only thWidth="100" th="住所3" :td="formData.ADDR_3" />
          <read-only thWidth="100" th="住所4" :td="formData.ADDR_4" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="12">
          <th class="required">鶏の種類</th>
          <td>
            <a-form-item v-bind="validateInfos.KEI_SYURUI">
              <ai-select
                v-model:value="formData.KEI_SYURUI"
                :options="KEI_SYURUI_CD_NAME_LIST"
                class="w-full"
                split-val
                :disabled="!isEdit"
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="12">
          <th class="required">契約羽数</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_HASU">
              <a-input-number
                v-model:value="formData.KEIYAKU_HASU"
                :disabled="!isEdit"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="12">
          <th class="required">契約年月日</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_YMD_FM">
              <DateJp
                v-model:value="formData.KEIYAKU_YMD_FM"
                :disabled="!isEdit"
              /> </a-form-item
            ><span>～</span>
            <DateJp v-model:value="formData.KEIYAKU_YMD_TO" disabled />
          </td>
        </a-col>
        <a-col class="flex-1">
          <td class="flex items-center">
            <span> (契約日を入力する二とで单価を取得します)</span>
          </td></a-col
        >
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">備考</th>
          <td>
            <a-input
              v-model:value="formData.BIKO"
              :disabled="!isEdit"
            ></a-input>
          </td>
        </a-col>
      </a-row>
    </div>
  </a-card>
  <Detail2
    v-if="detailKbn === DetailStatus.Detail2"
    v-model:detailKbn="detailKbn"
  />
</template>
<script setup lang="ts">
import useSearch from '@/hooks/useSearch'
import { Judgement } from '@/utils/judge-edited'
import { reactive, ref, toRef, computed } from 'vue'
import { DetailRowVM } from '../../type'
import Detail2 from './Detail2.vue'
import { changeTableSort } from '@/utils/util'
import { PageStatus } from '@/enum'
import { Form } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { useRoute, useRouter } from 'vue-router'
import { DetailStatus } from '../../constant'
import { VxeTableInstance } from 'vxe-table'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const detailKbn = ref(DetailStatus.Detail1)
const formData = reactive({
  KI: undefined as number | undefined,
  KEIYAKUSYA_NAME: '',
  NOJO_CD: undefined as number | undefined,
  NOJO_NAME: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  MEISAI_NO: undefined as number | undefined,
  KEI_SYURUI: undefined as number | undefined,
  KEIYAKU_HASU: undefined as number | undefined,
  KEIYAKU_YMD_FM: undefined as Date | undefined,
  KEIYAKU_YMD_TO: undefined as Date | undefined,
  BIKO: '',
})
const tableData = ref<DetailRowVM[]>([
  {
    MEISAI_NO: 0,
    NOJO_NAME: '(宇)宇宇イイアイ-',
    NOJO_ADDR: '北海道亜宇亜亜亜宇亜宇亜亜亜宇亜宇亜亜亜',
    TORISYURUI: '揉卵成鶏',
    KEIYAKUHASU: '111',
    BIKO: '',
  },
])
const isEdit = ref(false)
const editJudge = new Judgement('GJ1010')
const { pageParams, totalCount } = useSearch({
  service: undefined,
  source: tableData,
})
const NOJO_CD_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const KEI_SYURUI_CD_NAME_LIST = ref<CmCodeNameModel[]>([])

const tableRef = ref<VxeTableInstance>()
const devicePixelRatio = ref(window.devicePixelRatio)
const rules = reactive({
  MEISAI_NO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '明細番号'),
    },
  ],
})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

window.addEventListener('resize', function () {
  devicePixelRatio.value = window.devicePixelRatio
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const addData = () => {
  isEdit.value = true
}
const changeData = () => {
  const a = tableRef.value?.getCurrentRecord()
  isEdit.value = true
}
const saveData = () => {
  isEdit.value = false
}
const reset = () => {
  isEdit.value = false
}
function goForward(status: PageStatus, row?: any) {}

const goList = () => {
  editJudge.judgeIsEdited(() => {
    resetFields()
    router.push({ name: route.name })
  })
}
const addNoJo = () => {
  detailKbn.value = DetailStatus.Detail2
}
</script>
<style lang="scss" scoped>
th {
  min-width: 110px;
}

tr th {
  text-align: center;
  border: 1px solid rgb(190, 190, 190);
  font-weight: 100;
  width: 0.8rem !important;
}
tr td {
  text-align: right;
  border: 1px solid rgb(190, 190, 190);
  width: 0.8rem !important;
}
</style>
