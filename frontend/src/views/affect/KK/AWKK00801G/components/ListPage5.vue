<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 拡張事業・保健・集団指導項目
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" class="mb-2">
      <h3 class="font-bold">保健指導・集団指導項目</h3>

      <div class="self_adaption_table mb-2" :class="!isSearched && 'form'">
        <a-row>
          <a-col :sm="12" :xxl="6">
            <th class="required">指導区分</th>
            <td v-if="!isSearched">
              <a-form-item v-bind="validateInfos.sidokbn">
                <ai-select
                  v-model:value="sidoParams.sidokbn"
                  :options="options.selectorlist1"
                  type="number"
                  @change="sidoParams.itemyotokbn = undefined"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ Enum指導区分[sidoParams.sidokbn as Enum指導区分] }}</TD>
          </a-col>
          <a-col :sm="12" :xxl="6">
            <th class="required">業務区分</th>
            <td v-if="!isSearched">
              <a-form-item v-bind="validateInfos.gyomukbn">
                <ai-select
                  v-model:value="sidoParams.gyomukbn"
                  :options="options.selectorlist2"
                  split-val
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ getLabelByValue(sidoParams.gyomukbn, options.selectorlist2) }}</TD>
          </a-col>
          <a-col :sm="12" :xxl="6">
            <th class="required">申込結果</th>
            <td v-if="!isSearched">
              <a-form-item v-bind="validateInfos.mosikomikekkakbn">
                <ai-select
                  v-model:value="sidoParams.mosikomikekkakbn"
                  :options="options.selectorlist3"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ Enum申込結果[sidoParams.mosikomikekkakbn as Enum申込結果] }}</TD>
          </a-col>
          <a-col v-show="sidoParams.sidokbn == Enum指導区分.集団指導" :sm="12" :xxl="6">
            <th class="required">項目用途区分</th>
            <td v-if="!isSearched">
              <a-form-item v-bind="validateInfos.itemyotokbn">
                <ai-select
                  v-model:value="sidoParams.itemyotokbn"
                  :options="options.selectorlist4"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ Enum項目用途区分[sidoParams.itemyotokbn as Enum項目用途区分] }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="flex justify-between">
        <a-space>
          <a-button v-if="!isSearched" type="primary" :disabled="!canSearch" @click="searchData"
            >検索</a-button
          >
          <a-button v-else type="primary" @click="resetSearch">再検索</a-button>
          <a-button type="primary" :disabled="!canCreate" @click="goDetail({ itemcd: -1 })"
            >新規</a-button
          >
          <a-button
            type="primary"
            :disabled="!canCopy"
            @click="goDetail({ itemcd: copyCode, iscopy: true })"
            >コピー</a-button
          >
        </a-space>
        <a-space>
          <a-button
            type="primary"
            :disabled="!isSearched || !route.meta.updflg"
            @click="sortVisible = true"
            >並び順設定</a-button
          >
          <a-button
            type="primary"
            :disabled="sidoParams.sidokbn == Enum指導区分.集団指導 || !route.meta.updflg"
            @click="sortVisible2 = true"
            >詳細検索設定</a-button
          >
          <close-page></close-page>
        </a-space>
      </div>
    </a-card>
    <a-card>
      <h4 class="font-bold">保健指導・集団指導項目設定</h4>
      <vxe-table
        ref="xTableRef"
        :height="Math.max(tableHeight, 300)"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="result.kekkalist"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="
          ({ row }) => {
            if (row.itemkbn === Enumフリー項目区分区分.市区町村独自項目) goDetail(row)
          }
        "
      >
        <vxe-column field="itemcd" title="保健指導項目コード" min-width="110">
          <template #default="{ row }: { row: ItemListRowBaseVM }">
            <a
              v-if="row.itemkbn === Enumフリー項目区分区分.市区町村独自項目"
              @click="goDetail(row)"
              >{{ row.itemcd }}</a
            >
            <span v-else>{{ row.itemcd }}</span>
          </template>
        </vxe-column>
        <vxe-column field="itemnm" title="保健指導項目名" min-width="110">
          <template #default="{ row }">
            <a
              v-if="row.itemkbn === Enumフリー項目区分区分.市区町村独自項目"
              @click="goDetail(row)"
              >{{ row.itemnm }}</a
            >
            <span v-else>{{ row.itemnm }}</span>
          </template>
        </vxe-column>
        <vxe-column field="kakutyokbn" title="拡張領域使用" min-width="110" />
        <vxe-column field="pkgdokujikbnnm" title="PKG標準・独自区分" min-width="110" />
        <vxe-column field="inputtypekbnnm" title="タイプ" min-width="110" />
        <vxe-column field="groupnm" title="グループID" min-width="110" :resizable="false" />
      </vxe-table>
      <div class="mt-1 text-end">{{ result.kensucnt }}</div>
    </a-card>
    <DetailSortModal v-model:visible="sortVisible2" />
    <ProjectSortModal
      v-model:visible="sortVisible"
      :params="(sidoParams as SidoCommonRequest)"
      @after-save="searchData"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { Enum指導区分, Enum申込結果, Enum項目用途区分, Enumフリー項目区分区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import { ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { useTableHeight } from '@/utils/hooks'
import { getLabelByValue } from '@/utils/util'
import DetailSortModal from '@/views/affect/KK/AWKK00806D/index.vue'
import ProjectSortModal from '@/views/affect/KK/AWKK00807D/index.vue'
import { Form } from 'ant-design-vue'
import { computed, onMounted, ref } from 'vue'
import { LocationQueryRaw, useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { InitSidoItemList, SearchSidoItemList } from '../service'
import { sidoParams } from '../store'
import {
  InitSidoItemListResponse,
  ItemListRowBaseVM,
  SearchSidoItemListResponse,
  SidoCommonRequest
} from '../type'

type OptionsVM = Omit<InitSidoItemListResponse, keyof DaResponseBase>
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const xTableRef = ref<VxeTableInstance>()

const isSearched = ref(false)
const sortVisible = ref(false)
const sortVisible2 = ref(false)

const options = ref<OptionsVM>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: []
})

const result = ref<Omit<SearchSidoItemListResponse, keyof DaResponseBase>>({
  halfflg: false,
  dayflg: false,
  fullflg: false,
  cdflg: false,
  buttonflg: false,
  kekkalist: [],
  kensucnt: '　'
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitSidoItemList().then((res) => (options.value = res))
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -16)

//項目の設定
const rules = computed(() => ({
  sidokbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '指導区分') }],
  gyomukbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '業務区分') }],
  mosikomikekkakbn: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '申込結果') }
  ],
  itemyotokbn: [
    {
      required: sidoParams.sidokbn == Enum指導区分.集団指導,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '項目用途区分')
    }
  ]
}))
const { validate, validateInfos } = Form.useForm(sidoParams, rules)

//コピー
const copyCode = computed<string>(() => {
  const curRow = xTableRef.value?.getCurrentRecord()
  if (curRow && curRow.itemcd && curRow.itemkbn === Enumフリー項目区分区分.市区町村独自項目) {
    return curRow.itemcd
  }
  return ''
})
//検索権限
const canSearch = computed(() => {
  const { sidokbn, gyomukbn, mosikomikekkakbn, itemyotokbn } = sidoParams
  return (
    sidokbn && gyomukbn && mosikomikekkakbn && (sidokbn !== Enum指導区分.集団指導 || itemyotokbn)
  )
})
//新規権限
const canCreate = computed(() => result.value.buttonflg && isSearched.value && route.meta.addflg)
//コピー権限
const canCopy = computed(
  () => result.value.buttonflg && isSearched.value && copyCode.value && route.meta.addflg
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  await validate()
  loading.value = true
  try {
    const res = await SearchSidoItemList(sidoParams as SidoCommonRequest)
    result.value = res
    isSearched.value = true
  } catch (error) {}
  loading.value = false
}

function goDetail({ itemcd, iscopy = false }) {
  const query = iscopy ? { ...route.query, itemcd, iscopy } : { ...route.query, itemcd }
  router.push({
    name: route.name as string,
    query: query as LocationQueryRaw
  })
}

//再検索
function resetSearch() {
  isSearched.value = false
  result.value.kekkalist = []
}

//タイプ入力上限値フラグ
const limitflgs = computed(() => {
  const { halfflg, dayflg, fullflg, cdflg } = result.value
  return { halfflg, dayflg, fullflg, cdflg }
})

defineExpose({ searchData, limitflgs })
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
