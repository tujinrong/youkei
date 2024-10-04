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
    <a-card :bordered="false" class="h-65">
      <h1>（GJ1012）互助基金契約者マスタメンテナンス（契約情報入力）</h1>
      <div class="self_adaption_table form">
        <b>第{{ formData.KI ?? 8 }}期</b>
        <h2>1.契約農場別明細情報(表示)</h2>
        <div class="max-w-100">
          <a-row>
            <a-col span="24">
              <read-only
                thWidth="100"
                th="契約者"
                :td="formData.KEIYAKUSYA_NAME"
              />
            </a-col>
            <a-col span="10"></a-col>
          </a-row>
        </div>
        <div class="my-2 flex justify-between">
          <a-space :size="20">
            <a-button type="primary" @click="addData">新規登録</a-button
            ><a-button class="ml-20" type="primary">前期データコピー</a-button>
          </a-space>
          <a-button type="primary" @click="goList">一覧へ</a-button>
        </div>
      </div>
      <table class="my-2 w-200">
        <tr>
          <th class="!w-10">鶏の種類</th>
          <th>採卵鶏(成鷄)</th>
          <th colspan="1">採卵鶏(育成鶏)</th>
          <th rowspan="1">肉用鶏</th>
          <th>種鶏(成鶏)</th>
          <th>種鶏(育成鶏)</th>
          <th>うずら</th>
          <th>あひる</th>
          <th>きじ</th>
          <th>ほろほろ鳥</th>
          <th>七面鳥</th>
          <th>だちょう</th>
          <th>合計</th>
        </tr>
        <tr>
          <th>契約羽数合計</th>
          <td>{{ HASU_GOKEI.SAIRANKEI_SEIKEI }}</td>
          <td>{{ HASU_GOKEI.SAIRANKEI_IKUSEIKEI }}</td>
          <td>{{ HASU_GOKEI.NIKUYOKEI }}</td>
          <td>{{ HASU_GOKEI.SYUKEI_SEIKEI }}</td>
          <td>{{ HASU_GOKEI.SYUKEI_IKUSEIKEI }}</td>
          <td>{{ HASU_GOKEI.UZURA }}</td>
          <td>{{ HASU_GOKEI.AHIRU }}</td>
          <td>{{ HASU_GOKEI.KIJI }}</td>
          <td>{{ HASU_GOKEI.HOROHOROCHO }}</td>
          <td>{{ HASU_GOKEI.SICHIMENCHO }}</td>
          <td>{{ HASU_GOKEI.DACHO }}</td>
          <td>
            {{ HASU_GOKEI.TOTAL || 0 }}
          </td>
        </tr>
      </table> </a-card
    ><a-card class="flex-1 staticWidth">
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
        height="450px"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => changeData()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="right"
          field="MEISAI_NO"
          title="明細番号"
          width="100"
        >
          <template #default="{ row }">
            <a @click="changeData()">{{ row.MEISAI_NO }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME"
          title="農場名"
          width="200"
        >
          <template #default="{ row }">
            <a @click="changeData()">{{ row.NOJO_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_ADDR"
          title="農場住所"
          min-width="200"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="TORI_KBN_NAME"
          title="鳥の種類"
          min-width="120"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKU_HASU"
          title="契約羽数"
          min-width="120"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="BIKO"
          title="備考"
          min-width="200"
          :resizable="false"
        ></vxe-column>
      </vxe-table>

      <PopUp1012
        v-model:visible="popupVisible"
        :editkbn="popupeditkbn"
      ></PopUp1012>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import useSearch from '@/hooks/useSearch'
import { Judgement } from '@/utils/judge-edited'
import { reactive, ref, toRef, computed, onMounted } from 'vue'
import { DetailRowVM } from '../../type'
import { changeTableSort } from '@/utils/util'
import { EnumEditKbn, PageStatus } from '@/enum'
import { Form } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { useRoute, useRouter } from 'vue-router'
import { FarmManage } from '../../constant'
import { VxeTableInstance } from 'vxe-table'
import PopUp1012 from '../Popup/PopUp_1012.vue'
import { Search } from '../../service/1012/service'
import { SearchRequest } from '../../service/1012/type'
import { search } from '@/views/GJ30/GJ3030/interface/3030/service'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const createDefaultParams = (): SearchRequest => {
  return {
    KI: Number(route.query.KI),
    KEIYAKUSYA_CD: Number(route.query.KEIYAKUSYA_CD),
  } as SearchRequest
}

const searchParams = reactive(createDefaultParams())

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

const HASU_GOKEI = ref({
  SAIRANKEI_SEIKEI: undefined,
  SAIRANKEI_IKUSEIKEI: undefined,
  NIKUYOKEI: undefined,
  SYUKEI_SEIKEI: undefined,
  SYUKEI_IKUSEIKEI: undefined,
  UZURA: undefined,
  AHIRU: undefined,
  KIJI: undefined,
  HOROHOROCHO: undefined,
  SICHIMENCHO: undefined,
  DACHO: undefined,
  TOTAL: undefined,
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

const popupVisible = ref(false)
const popupeditkbn = ref<EnumEditKbn>(EnumEditKbn.Add)

const editJudge = new Judgement('GJ1010')
// const { pageParams, totalCount } = useSearch({
//   service: undefined,
//   source: tableData,
// })

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  // validate,
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

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  await searchAll()
  // const res = await Search({
  //   KI: Number(route.query.KI),
  //   KEIYAKUSYA_CD: Number(route.query.KEIYAKUSYA_CD),
  // })
  // console.log(res)
})

const searchAll = async () => {
  tableData.value = []
  const res = await searchData()
  HASU_GOKEI.value = res.HASU_GOKEI
  if (tableRef.value && tableData.value.length > 0) {
    tableRef.value.setCurrentRow(tableData.value[0])
  }
}
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
  popupVisible.value = true
  popupeditkbn.value = EnumEditKbn.Add
}
const changeData = () => {
  popupVisible.value = true
  popupeditkbn.value = EnumEditKbn.Edit
}
const deleteData = () => {}
const saveData = () => {}
const reset = () => {}
function goForward(status: PageStatus, row?: any) {}

const goList = () => {
  editJudge.judgeIsEdited(() => {
    resetFields()
    router.push({ name: route.name })
  })
}
</script>
<style lang="scss" scoped>
th {
  min-width: 110px; //絶対変えられない
}

tr th {
  text-align: center;
  border: 1px solid rgb(190, 190, 190);
  background-color: #ffffe1;
  font-weight: 100;
  width: 0.8rem !important;
}
tr td {
  text-align: right;
  border: 1px solid rgb(190, 190, 190);
  width: 0.8rem !important;
}
</style>
