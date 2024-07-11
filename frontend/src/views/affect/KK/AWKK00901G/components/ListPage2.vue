<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業予定管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.01
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :xl="8" :xxl="6">
            <th class="required">業務</th>
            <td>
              <a-form-item v-bind="validateInfos.gyomukbn">
                <ai-select
                  v-model:value="searchParams.gyomukbn"
                  :options="opts"
                  split-val
                  @change="onChangeOpt"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :xl="12" :xxl="12">
            <th>実施予定日</th>
            <td>
              <RangeDate
                v-model:value1="searchParams.jissiyoteiymdf"
                v-model:value2="searchParams.jissiyoteiymdt"
              />
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>コース名</th>
            <td>
              <a-input v-model:value="searchParams.coursenm" allow-clear :maxlength="50"></a-input>
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>事業名</th>
            <td>
              <ai-select
                v-model:value="searchParams.jigyocd"
                :options="keyoptions"
                split-val
                @change="onChangeKeyOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>会場</th>
            <td>
              <ai-select
                v-model:value="searchParams.kaijocd"
                :options="options.selectorlist3"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>医療機関</th>
            <td>
              <ai-select
                v-model:value="searchParams.kikancd"
                :options="options.selectorlist4"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>担当者</th>
            <td>
              <ai-select
                v-model:value="searchParams.staffid"
                :options="options.selectorlist5"
                split-val
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" @click="handleSearch">検索</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="goDetail({ courseno: -1 })"
            >新規</a-button
          >
          <a-button
            type="primary"
            :disabled="!updflg || !copyCode"
            @click="goDetail({ courseno: copyCode, iscopy: true })"
            >コースコピー</a-button
          >
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="mt-2">
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :total="totalCount"
        :page-size-options="$pagesizes"
        show-less-itemsw
        show-size-changer
        class="text-end mb-2"
      />
      <vxe-table
        ref="xTableRef"
        :height="Math.max(tableHeight, 400)"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goDetail(row)"
      >
        <vxe-column field="courseno" title="コース番号" width="100">
          <template #default="{ row }">
            <a @click="goDetail(row)">{{ row.courseno }}</a>
          </template>
        </vxe-column>
        <vxe-column field="gyomukbnnm" title="業務"></vxe-column>
        <vxe-column field="coursenm" title="コース名"></vxe-column>
        <vxe-column field="kaisu" title="回数" width="100"></vxe-column>
        <vxe-column field="jissikikan" title="実施期間"></vxe-column>
      </vxe-table>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { reactive, ref, computed, watch, toRef } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { useLinkOption, useTableHeight, useSearch } from '@/utils/hooks'
import { VxeTableInstance } from 'vxe-table'
import RangeDate from '@/components/Selector/RangeDate/index2.vue'
import { CourseRowVM, InitListResponse, SearchCourseListRequest } from '../type'
import { SearchCourseList } from '../service'
import dayjs, { Dayjs } from 'dayjs'
import { ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { Form, message } from 'ant-design-vue'

const props = defineProps<{
  options: Omit<InitListResponse, keyof DaResponseBase>
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const xTableRef = ref<VxeTableInstance>()

const createDefaultParams = (): Omit<SearchCourseListRequest, keyof CmSearchRequestBase> => ({
  gyomukbn: undefined,
  jissiyoteiymdf: dayjs().format('YYYY-MM-DD'),
  jissiyoteiymdt: undefined,
  jigyocd: undefined,
  kaijocd: undefined,
  kikancd: undefined,
  staffid: undefined,
  coursenm: undefined,
  kaisu: undefined
})

const searchParams = reactive(createDefaultParams())
const tableData = ref<CourseRowVM[]>([])
const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchCourseList,
  source: tableData,
  params: toRef(() => searchParams)
})

const rules = reactive({
  gyomukbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '業務') }]
})
const { validate, clearValidate, validateInfos } = Form.useForm(searchParams, rules)

//Options連動(事業名、業務)
const {
  keyoptions,
  options: opts,
  onChangeKeyOpt,
  onChangeOpt,
  resetOpts
} = useLinkOption(
  toRef(() => props.options.selectorlist2),
  toRef(() => props.options.selectorlist1)
)
//権限フラグ
const addFlg = route.meta.addflg
const updflg = route.meta.updflg
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh && from.query.courseno) {
    pageParams.pagenum = 1
    searchData()
  }
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -36)

const copyCode = computed<string>(() => {
  const curRow = xTableRef.value?.getCurrentRecord()
  return curRow?.courseno ?? ''
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function handleSearch() {
  await Promise.all([validate()])
  const res = await searchData()
  //検索結果1件の場合、詳細画面へ遷移
  if (res.totalrowcount === 1 && res.totalpagecount === 1) {
    goDetail(res.kekkalist[0])
  }
}

//画面遷移
const goDetail = ({ courseno, iscopy = false }) => {
  router.push({
    name: route.name as string,
    query: {
      courseno,
      iscopy: iscopy ? '1' : undefined
    }
  })
}

function reset() {
  resetOpts()
  clear()
  Object.assign(searchParams, createDefaultParams())
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 130px;
}
</style>
