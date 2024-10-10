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
    <a-card
      :bordered="false"
      class="h-65"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
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
            ><a-button class="ml-20" type="primary" @click="copyData"
              >前期データコピー</a-button
            >
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
            {{ total }}
          </td>
        </tr>
      </table> </a-card
    ><a-card
      class="flex-1 staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
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
        ref="xTableRef"
        class="mt-2"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        height="450px"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['asc', 'desc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => changeData(row)"
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
            <a @click="changeData(row)">{{ row.MEISAI_NO }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME"
          title="農場名"
          width="200"
        >
          <template #default="{ row }">
            <a @click="changeData(row)">{{ row.NOJO_NAME }}</a>
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
        v-bind="{
          editkbn: popupeditkbn,
          row: currentRow,
          NOJO_LIST: editOptions.NOJO_LIST,
          TORI_KBN_LIST: editOptions.TORI_KBN_LIST,
          KEIYAKU_KBN: formData.KEIYAKU_KBN,
          KEIYAKUSYA_NAME: formData.KEIYAKUSYA_NAME,
        }"
        @getTableList="searchAll"
      ></PopUp1012>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import useSearch from '@/hooks/useSearch'
import { Judgement } from '@/utils/judge-edited'
import { reactive, ref, toRef, onMounted, computed } from 'vue'
import { changeTableSort } from '@/utils/util'
import { EnumEditKbn } from '@/enum'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import PopUp1012 from '../Popup/PopUp_1012.vue'
import { Copy, Search } from '../../service/1012/service'
import { SearchRequest, SearchRowVM } from '../../service/1012/type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

const xTableRef = ref<VxeTableInstance>()
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
  KEIYAKU_KBN: 0,
})

const HASU_GOKEI = ref({
  SAIRANKEI_SEIKEI: 0,
  SAIRANKEI_IKUSEIKEI: 0,
  NIKUYOKEI: 0,
  SYUKEI_SEIKEI: 0,
  SYUKEI_IKUSEIKEI: 0,
  UZURA: 0,
  AHIRU: 0,
  KIJI: 0,
  HOROHOROCHO: 0,
  SICHIMENCHO: 0,
  DACHO: 0,
})
const editOptions = reactive<{
  NOJO_LIST: CmCodeNameModel[]
  TORI_KBN_LIST: CmCodeNameModel[]
}>({
  NOJO_LIST: [],
  TORI_KBN_LIST: [],
})
const tableData = ref<SearchRowVM[]>([])
const currentRow = ref<SearchRowVM>()
const popupVisible = ref(false)
const popupeditkbn = ref<EnumEditKbn>(EnumEditKbn.Add)

const editJudge = new Judgement('GJ1010')

const { pageParams, totalCount, searchData } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  tableRef: xTableRef,
  // validate,
})

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  await searchAll()
})

const searchAll = async () => {
  const res = await searchData()
  formData.KEIYAKU_KBN = res.KEIYAKU_KBN
  formData.KEIYAKUSYA_NAME = res.KEIYAKUSYA_NAME
  formData.KI = searchParams.KI
  Object.assign(editOptions, res)
  HASU_GOKEI.value = res.HASU_GOKEI
}
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const total = computed(() => {
  return Object.values(HASU_GOKEI.value).reduce((sum, val) => sum + val, 0)
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const addData = () => {
  popupVisible.value = true
  popupeditkbn.value = EnumEditKbn.Add
}
const changeData = (row) => {
  currentRow.value = row
  popupVisible.value = true
  popupeditkbn.value = EnumEditKbn.Edit
}

const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name })
  })
}

const copyData = async () => {
  await Copy({ ...searchParams, KEIYAKU_KBN: formData.KEIYAKU_KBN })
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
