<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false" :loading="loading_head">
      <div v-if="isSearchPage" class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>年度</th>
            <td>
              <a-form-item v-bind="validateInfos.nendo">
                <year-jp
                  v-model:value="searchParams.nendo"
                  @change="changeYear(searchParams.nendo)"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th class="required">検診種別</th>
            <td>
              <a-form-item v-bind="validateInfos.kensin_jigyocd">
                <ai-select
                  v-model:value="searchParams.kensin_jigyocd"
                  :options="kensin_jigyocdOptions"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th class="required">料金パターン</th>
            <td>
              <a-form-item v-bind="validateInfos.ryokinpattern">
                <ai-select
                  v-model:value="searchParams.ryokinpattern"
                  :options="ryokinpatternOptions"
                  style="width: 100%"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
      <div v-else class="self_adaption_table">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>年度</th>
            <TD>{{ yearFormatter(searchParams.nendo) }}</TD>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th class="required">検診種別</th>
            <TD>{{ searchParams.kensin_jigyocd }}</TD>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th class="required">料金パターン</th>
            <TD>{{ searchParams.ryokinpattern }}</TD>
          </a-col>
        </a-row>
      </div>

      <div class="m-t-1">
        <a-space>
          <a-button
            v-if="isSearchPage"
            :disabled="
              !(searchParams.nendo && searchParams.kensin_jigyocd && searchParams.ryokinpattern)
            "
            type="primary"
            @click="getTableList"
            >検索</a-button
          >
          <a-button v-else type="primary" @click="resetSearch">再検索</a-button>
          <a-button
            class="warning-btn"
            :disabled="isSearchPage ? true : hasPermission ? false : true"
            @click="submitData"
            >登録</a-button
          >
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page class="float-right"></close-page>
      </div>

      <div class="mt-3">
        <a-button type="primary" :disabled="zenNenFlg" @click="continuationPreviousYear"
          >前年度引継ぎ</a-button
        >
      </div>
    </a-card>
    <a-card :bordered="false" class="mt-2">
      <a-space>
        <a-button class="btn-round" type="primary" :disabled="!canCreate" @click="addRow"
          >行追加</a-button
        >
        <a-button class="btn-round" type="primary" :disabled="!canDelete" @click="deleteRow"
          >行削除</a-button
        >
      </a-space>
      <div class="mt-2" :style="{ height: tableHeight }">
        <vxe-table
          ref="xTableRef"
          :column-config="{ resizable: true }"
          :header-cell-class-name="updFlg || addFlg || delFlg ? 'bg-editable' : 'bg-readonly'"
          :mouse-config="{ selected: true }"
          :row-config="{ isCurrent: true, height: 42 }"
          :keyboard-config="{
            isTab: true,
            isEdit: true,
            isEnter: true,
            enterToTab: true
          }"
          :data="tableList"
          :edit-rules="tableRules"
          :empty-render="{ name: 'NotData' }"
          :height="tableHeight"
          :edit-config="{
            trigger: 'click',
            mode: 'cell',
            showStatus: false
          }"
          :valid-config="{ showMessage: false }"
        >
          <vxe-column
            field="kensahohocd"
            :edit-render="{ autofocus: 'input' }"
            :class-name="
              ({ row }) =>
                row.kensahohocd === '0' ? 'bg-disabled' : !row.kensahohocd ? 'bg-errorcell' : ''
            "
          >
            <template #header>検査方法<span class="request-mark">＊</span></template>
            <template #edit="{ row }">
              <a-form-item>
                <ai-select
                  v-show="!(row.kensahohocd === '0')"
                  v-model:value="row.kensahohocd"
                  :options="kensahohocdOptions"
                  :disabled="row.kensahohocd === '0'"
                  split-val
                ></ai-select>
              </a-form-item>
            </template>
            <template #default="{ row }">
              {{
                row.kensahohocd === '0'
                  ? ''
                  : row.kensahohocd
                  ? row.kensahohocd +
                    (getLabelByValue(row.kensahohocd, kensahohocdOptions)
                      ? ' : ' + getLabelByValue(row.kensahohocd, kensahohocdOptions)
                      : '')
                  : ''
              }}
            </template>
          </vxe-column>
          <vxe-column
            field="genmenkbncd"
            :edit-render="{ autofocus: 'input' }"
            :class-name="({ row }) => (!row.genmenkbncd ? 'bg-errorcell' : '')"
          >
            <template #header>減免区分<span class="request-mark">＊</span></template>
            <template #edit="{ row }">
              <ai-select
                v-model:value="row.genmenkbncd"
                :options="genmenkbncdOptions"
                split-val
              ></ai-select>
            </template>
            <template #default="{ row }">
              {{
                row.genmenkbncd
                  ? row.genmenkbncd +
                    (getLabelByValue(row.genmenkbncd, genmenkbncdOptions)
                      ? ' : ' + getLabelByValue(row.genmenkbncd, genmenkbncdOptions)
                      : '')
                  : ''
              }}
            </template>
          </vxe-column>
          <vxe-column
            field="sex"
            :edit-render="{ autofocus: 'input' }"
            :class-name="({ row }) => (row.sex.length <= 0 ? 'bg-errorcell' : '')"
          >
            <template #header>性別<span class="request-mark">＊</span></template>
            <template #edit="{ row }">
              <a-select
                v-model:value="row.sex"
                :options="sexOptions"
                style="width: 100%"
                mode="multiple"
                max-tag-count="responsive"
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template></a-select
              >
            </template>
            <template #default="{ row }">
              {{ getMultipleLabel(row.sex, sexOptions) }}
            </template>
          </vxe-column>
          <vxe-column
            field="agehani"
            :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            :class-name="({ row }) => (validateAge(row.agehani) === true ? '' : 'bg-errorcell')"
          >
            <template #header>年齢範囲<span class="request-mark">＊</span></template>
            <template #edit="{ row }">
              <a-input
                v-model:value="row.agehani"
                maxlength="100"
                @change="() => (row.agehani = formatRangeNumFull2Half(row.agehani))"
              />
            </template>
          </vxe-column>
          <vxe-column
            field="jusinkingaku"
            :edit-render="{ autofocus: 'input', autoselect: true }"
            formatter="localeNum"
            :class-name="({ row }) => (row.jusinkingaku === null ? 'bg-errorcell' : '')"
          >
            <template #header>受診金額<span class="request-mark">＊</span></template>
            <template #edit="{ row }">
              <a-input-number
                v-model:value="row.jusinkingaku"
                class="w-full"
                :precision="0"
                :min="0"
                :max="99999"
              />
            </template>
          </vxe-column>
          <vxe-column
            field="kingaku_sityosonhutan"
            title="金額（市区町村負担）"
            formatter="localeNum"
            :edit-render="{ autofocus: 'input', autoselect: true }"
          >
            <template #edit="{ row }">
              <a-input-number
                v-model:value="row.kingaku_sityosonhutan"
                class="w-full"
                :precision="0"
                :min="0"
                :max="99999"
            /></template>
          </vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watch, nextTick, watchEffect } from 'vue'
import { Form, message } from 'ant-design-vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance, VxeTablePropTypes } from 'vxe-table'
import { Rule } from 'ant-design-vue/lib/form'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { useTableHeight } from '@/utils/hooks'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import {
  yearFormatter,
  getLabelByValue,
  formatRangeNumFull2Half,
  getMultipleLabel
} from '@/utils/util'
import { Judgement } from '@/utils/judge-edited'
import TD from '@/components/Common/TableTD/index.vue'
import { RowVM, LockVM } from '../type'
import { InitList, SearchList, Save, SearchNendo, SearchHikitsudugi } from '../service'

const useForm = Form.useForm
const route = useRoute()
const loading = ref<boolean>(false)
const loading_head = ref<boolean>(true)
const xTableRef = ref<VxeTableInstance>()
const editJudge = new Judgement(route.name as string)
let nendoInit = ref(0)
const createDefaultParams = () => {
  return {
    nendo: 0, //年度
    kensin_jigyocd: '', // 検診種別
    ryokinpattern: '' // 料金パターン
  }
}
const searchParams = reactive(createDefaultParams())

const zenNenFlg = ref<boolean>(true)

const rules = reactive<Record<string, Rule[]>>({
  nendo: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年度')
    }
  ],
  kensin_jigyocd: [
    { required: true, message: `${ITEM_REQUIRE_ERROR.Msg.replace('{0}', '検診種別')}` }
  ],
  ryokinpattern: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '料金パターン')
    }
  ]
})
const isSearchPage = ref(true)

//項目の設定
const tableRules = ref({
  kensahohocd: [{ required: true }], // 検査方法
  genmenkbncd: [{ required: true }], //減免区分
  sex: [{ required: true }], //　性別
  agehani: [
    { required: true },
    {
      validator({ cellValue }) {
        return validateAge(cellValue)
      }
    }
  ], // 年齢範囲
  jusinkingaku: [{ required: true }] // 受診金額
} as VxeTablePropTypes.EditRules)
const { validate, validateInfos, clearValidate } = useForm(searchParams, rules)

//年齢範囲check
function validateAge(value) {
  if (!value) {
    return new Error()
  } else if (!/^(0|[1-9]\d*)(-(0|[1-9]\d*))?(,(0|[1-9]\d*)(-(0|[1-9]\d*))?)*$/.test(value)) {
    return new Error()
  } else {
    // -の数値比較
    const parts = value.split(',')
    for (const part of parts) {
      if (part.includes('-')) {
        const [start, end] = part.split('-')
        if (Number(start) > Number(end)) {
          return new Error()
        }
      }
    }
    return true
  }
}
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

const tableList = ref<RowVM[]>([])
const lockList = ref<LockVM[]>([])
//ビューモデル
const currentRow = ref<RowVM | null>(null)
//操作権限フラグ
const addFlg = route.meta.addflg as boolean
const delFlg = route.meta.delflg as boolean
const updFlg = route.meta.updflg as boolean

//現在行
watchEffect(() => {
  currentRow.value = xTableRef.value?.getCurrentRecord()
})
//有無任意権限
const hasPermission = computed(() => {
  return updFlg || addFlg
})
const kensin_jigyocdOptions = ref<DaSelectorModel[]>([]) // 成人健(検)診事業名Options
const ryokinpatternOptions = ref<DaSelectorModel[]>([]) // 料金パターンOptions
const kensahohocdOptions = ref<DaSelectorModel[]>([]) // 検査方法Options
const genmenkbncdOptions = ref<DaSelectorModel[]>([]) // 減免区分Options
const sexOptions = ref<DaSelectorModel[]>([]) // 性別Options
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(tableList, () => editJudge.setEdited(), { deep: true })
onMounted(() => {
  InitList()
    .then((res) => {
      searchParams.nendo = res.nendo
      nendoInit.value = res.nendo
    })
    .then(() => {
      SearchNendo(searchParams).then((res) => {
        kensin_jigyocdOptions.value = res.selectorlist1
        ryokinpatternOptions.value = res.selectorlist2
        zenNenFlg.value = !res.hikitsudugiflg
      })
    })
    .finally(() => (loading_head.value = false))
})

// 検索処理
async function getTableList() {
  loading.value = true
  try {
    const res = await SearchList({ ...searchParams })
    tableList.value = res.kekkalist.map((item) => ({
      ...item,
      sex: item.sex.split(',')
    }))
    lockList.value = res.locklist
    kensahohocdOptions.value = res.selectorlist3
    genmenkbncdOptions.value = res.selectorlist4
    sexOptions.value = res.selectorlist5
    isSearchPage.value = false
  } catch (error) {}
  nextTick(() => editJudge.reset())
  loading.value = false
}

//再検索
function resetSearch() {
  isSearchPage.value = true
  nextTick(() => {
    tableList.value = []
    lockList.value = []
    changeYear(searchParams.nendo)
    editJudge.reset()
  })
}

async function submitData() {
  await validate()
  const tableData = xTableRef.value?.getTableData().tableData ?? []
  const $table = xTableRef.value
  const errMap = await $table?.validate(true)
  if (errMap) {
    return Promise.reject()
  }

  showSaveModal({
    onOk: async () => {
      const savelist = tableData.map((item) => ({
        ...item,
        sex: item.sex.join(','),
        kensin_jigyocd: getKey(item.kensin_jigyocd),
        ryokinpattern: getKey(item.ryokinpattern),
        kensahohocd: getKey(item.kensahohocd),
        genmenkbncd: getKey(item.genmenkbncd)
      }))
      try {
        await Save({
          nendo: searchParams.nendo,
          kensin_jigyocd: searchParams.kensin_jigyocd,
          ryokinpattern: searchParams.ryokinpattern,
          savelist,
          locklist: lockList.value
        })
        message.success(SAVE_OK_INFO.Msg)
        getTableList()
      } catch (error) {}
    }
  })
}

// 前年度引継ぎ
async function continuationPreviousYear() {
  showSaveModal({
    onOk: async () => {
      try {
        await SearchHikitsudugi({
          nendo: searchParams.nendo
        })
        zenNenFlg.value = true
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {}
    }
  })
}

function reset() {
  isSearchPage.value = true
  nextTick(() => {
    searchParams.kensin_jigyocd = ''
    searchParams.ryokinpattern = ''
    tableList.value = []
    searchParams.nendo = nendoInit.value
    changeYear(searchParams.nendo)
    editJudge.reset()
  })
}

// 年度変更
async function changeYear(value) {
  searchParams.nendo = value
  loading.value = true
  try {
    await SearchNendo(searchParams).then((res) => {
      kensin_jigyocdOptions.value = res.selectorlist1
      ryokinpatternOptions.value = res.selectorlist2
      searchParams.kensin_jigyocd = ''
      searchParams.ryokinpattern = ''
      zenNenFlg.value = !res.hikitsudugiflg
    })
  } catch (error) {}
  editJudge.reset()
  loading.value = false
  clearValidate()
}

//行追加フラグ取得
const canCreate = computed(() => {
  //追加権限があって、最終行が必須チェックをクリアの場合(編集画面)、行追加可能
  return updFlg && !isSearchPage.value
})

//行削除フラグ取得
const canDelete = computed(() => {
  //削除権限がある場合、行削除可能
  if (delFlg) return Boolean(currentRow.value)
  //削除権限がない場合、新規データのみ削除可能
  return Boolean(currentRow.value && !currentRow.value.upddttm)
})

//行追加
const addRow = () => {
  tableList.value.push({
    kensahohocd: '',
    genmenkbncd: '',
    sex: [],
    agehani: '',
    jusinkingaku: 0,
    kingaku_sityosonhutan: 0,
    upddttm: '',
    kensin_jigyocd: searchParams.kensin_jigyocd,
    ryokinpattern: searchParams.ryokinpattern
  })
}

//行削除
const deleteRow = () => {
  showDeleteModal({
    onOk() {
      const $table = xTableRef.value
      if ($table) {
        const currentIndex = $table.getRowIndex(currentRow.value)
        tableList.value.splice(currentIndex, 1)
      }
    }
  })
}

function getKey(val) {
  return val.split(' : ')[0]
}
</script>
<style lang="less" scoped>
th {
  width: 130px;
}

td {
  width: 260px;
}

:deep(.ant-form-item) {
  margin: 0;
}
:deep(.vxe-header--column .vxe-cell--required-icon) {
  display: none;
}
</style>
