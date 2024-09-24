<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者マスタ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.27
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :visible="detailKbn === FarmManage.FarmInfo"
    centered
    title="（GJ1013）互助基金契約者マスタメンテナンス(農場情報入力)"
    width="1000px"
    :body-style="{ height: '800px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="self_adaption_table form">
      <b>第{{ formData.KI ?? 8 }}期</b>
      <h2>1.農場情報(表示)</h2>
      <a-row>
        <a-col span="8"
          ><read-only
            th="契約者"
            th-width="110"
            :td="formData.KEIYAKUSYA_NAME"
          ></read-only>
        </a-col>
      </a-row>
    </div>
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
        field="NOJO_CD"
        title="農場コード"
        width="110"
        align="right"
        sortable
        :params="{ order: 1 }"
        :resizable="true"
      >
      </vxe-column>
      <vxe-column
        header-align="center"
        field="NOJO_NAME"
        title="農場名"
        width="240"
        min-width="160"
        sortable
        :params="{ order: 2 }"
        :resizable="true"
      >
      </vxe-column>
      <vxe-column
        header-align="center"
        field="ADDR"
        title="農場住所"
        sortable
        :params="{ order: 3 }"
        :resizable="false"
      ></vxe-column>
    </vxe-table>
    <h2>2.農場登録情報(入力)</h2>

    <div class="self_adaption_table form">
      <a-row class="mb-2"><a-col span="24"> </a-col></a-row>
      <a-row>
        <a-col span="24">
          <th class="required">農場番号</th>
          <td>
            <a-form-item v-bind="validateInfos.NOJO_CD">
              <a-input-number
                v-model:value="formData.NOJO_CD"
                :min="0"
                :max="999"
                :maxlength="3"
                class="w-15"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">農場名</th>
          <td>
            <a-form-item v-bind="validateInfos.NOJO_NAME">
              <a-input
                v-model:value="formData.NOJO_NAME"
                :maxlength="20"
                class="w-150"
              ></a-input>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">都道府県</th>
          <td>
            <a-form-item v-bind="validateInfos.KEN_CD">
              <ai-select
                v-model:value="formData.KEN_CD"
                :options="KEN_CD_NAME_LIST"
                class="max-w-50"
                split-val
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">住所</th>
          <td class="flex-col">
            <a-form-item v-bind="validateInfos.ADDR_POST">
              <PostCode v-model:value="formData.ADDR_POST">
                <a-input
                  v-model:value="formData.ADDR_1"
                  disabled
                  class="!w-33"
                ></a-input
              ></PostCode>
            </a-form-item>
            <a-form-item v-bind="validateInfos.ADDR_2">
              <a-input
                v-model:value="formData.ADDR_2"
                :maxlength="15"
                class="w-80"
              ></a-input>
            </a-form-item>
            <a-input
              v-model:value="formData.ADDR_3"
              :maxlength="15"
              class="w-80"
              @change="validate('ADDR_4')"
            ></a-input>
            <a-form-item v-bind="validateInfos.ADDR_4">
              <a-input
                v-model:value="formData.ADDR_4"
                :maxlength="20"
                class="w-110"
              ></a-input>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
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
                class="w-15"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script lang="ts" setup>
import { onMounted, reactive, ref, watch, toRef } from 'vue'
import { NoJoRowVM } from '../../type'
import { changeTableSort } from '@/utils/util'
import useSearch from '@/hooks/useSearch'
import { Form } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { useRoute, useRouter } from 'vue-router'
import { Judgement } from '@/utils/judge-edited'
import { FarmManage } from '../../constant'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const editJudge = new Judgement('GJ1013')
const formData = reactive({
  KI: undefined as number | undefined,
  KEIYAKUSYA_NAME: '',
  NOJO_NAME: '',
  NOJO_CD: undefined as number | undefined,
  KEN_CD: undefined as number | undefined,
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
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<NoJoRowVM[]>([])
const { pageParams } = useSearch({
  service: undefined,
  source: tableData,
})
const rules = reactive({
  NOJO_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場番号'),
    },
  ],
  NOJO_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場名称'),
    },
  ],
  KEN_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '都道府県'),
    },
  ],
  ADDR_POST: [
    {
      validator: async (_rule, value: string) => {
        if (!value) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号')
          )
        } else if (value.replace(/[^0-9]/g, '').length < 7) {
          return Promise.reject(
            // ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '郵便番号')
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  ADDR_2: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '住所２'),
    },
  ],
  MEISAI_NO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '明細番号'),
    },
  ],
  ADDR_4: [
    {
      validator: async (_rule, value: string) => {
        if (value && !formData.ADDR_3) {
          return Promise.reject('前の住所入力欄が未入力です。')
        }
        return Promise.resolve()
      },
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

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => formData,
  () => editJudge.setEdited()
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const detailKbn = defineModel<FarmManage>('detailKbn')

const goList = () => {
  editJudge.judgeIsEdited(() => {
    resetFields()
    detailKbn.value = FarmManage.Detail
  })
}
const saveData = () => {}
</script>

<style lang="scss" scoped>
th {
  min-width: 110px;
}
</style>
