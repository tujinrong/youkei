<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 成人健（検）診対象者設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.31
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading2">
    <a-card ref="headRef" :bordered="false" :loading="loading1">
      <div class="self_adaption_table w-56" :class="!isSearched && 'form'">
        <a-row>
          <a-col span="24">
            <th class="w-25">年度</th>
            <td v-show="!isSearched">
              <YearJp v-model:value="nendo" :max="nendo_max" />
            </td>
            <TD v-show="isSearched">{{ yearFormatter(nendo) }}</TD>
          </a-col>
        </a-row>
      </div>

      <div class="mt-2">
        <a-space>
          <a-button v-if="!isSearched" type="primary" @click="searchData">検索</a-button>
          <a-button v-else type="primary" @click="resetSearch">再検索</a-button>
          <a-button class="warning-btn" :disabled="!canSave" @click="saveData">登録</a-button>
          <a-button type="primary" @click="handleMove">検診種別・検査方法追加</a-button>
        </a-space>
        <close-page class="float-right"></close-page>
      </div>
    </a-card>

    <Table
      :table-data="tableData"
      :head-ref="headRef"
      :can-add="canAdd"
      :options="options"
      :disabled="!nendoJudge"
      hide-delete
      @setlastflag="setLastflag"
    />
  </a-spin>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { C021002, RESEARCH_CONFIRM, SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { showConfirmModal, showSaveModal } from '@/utils/modal'
import { yearFormatter } from '@/utils/util'
import { message } from 'ant-design-vue'
import { computed, nextTick, onMounted, provide, ref, watch, watchEffect } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import Table from './components/Table.vue'
import { DoBatch, Init, Save, Search } from './service'
import { ItemVM, LockVM, OptionsVM, RowVM } from './type'
import dayjs from 'dayjs'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const editJudge = new Judgement(route.name as string)
const loading1 = ref(true)
const loading2 = ref(false)
const isSearched = ref(false)
const nendo_max = ref<number>(9999)
const nendo = ref<number>(0)
provide('nendo', nendo)

const xTableRef = ref<VxeTableInstance>()
const tableData = ref<ItemVM[]>([])
const options = ref<OptionsVM>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  selectorlist6: []
})
let locklist: LockVM[] = []

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限フラグ
const canAdd = computed(
  () => nendoJudge.value && isSearched.value && (route.meta.addflg as boolean)
)
const canSave = computed(
  () => nendoJudge.value && isSearched.value && (route.meta.updflg || route.meta.addflg)
)
const nendoJudge = computed(() => {
  if (nendo.value > nendo_max.value - 1) {
    return true
  } else if (
    nendo.value > nendo_max.value - 2 &&
    dayjs().isBefore(dayjs(`${dayjs().year()}-04-01`), 'day')
  ) {
    return true
  }
  return false
})
//表の高さ
const headRef = ref()
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(tableData, () => editJudge.setEdited(), { deep: true })
//現在行
const currentRow = ref<ItemVM | null>(null)
watchEffect(() => {
  currentRow.value = xTableRef.value?.getCurrentRecord()
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  Init().then((res) => {
    options.value = res
    nendo.value = nendo_max.value = res.nendo
    loading1.value = false
    searchData()
  })
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading2.value = true
  try {
    const res = await Search({ nendo: nendo.value })
    tableData.value = res.kekkalist.flatMap((item, index) => {
      return item.rows.map((row) => ({
        ...row,
        jigyocd: item.jigyocd,
        groupNo: index
      }))
    })
    setLastflag()
    locklist = res.locklist ?? []
    isSearched.value = true
  } catch (error) {}
  loading2.value = false
  nextTick(() => editJudge.reset())
}

//再検索
function resetSearch() {
  editJudge.judgeIsEdited(() => {
    isSearched.value = false
    tableData.value = []
    nextTick(() => editJudge.reset())
  }, RESEARCH_CONFIRM.Msg)
}

//保存処理
function saveData() {
  //ItemVM => RowVM
  const kekkalist = tableData.value.reduce((acc: RowVM[], item) => {
    const existingObject = acc.find((obj) => obj.jigyocd === item.jigyocd)
    if (existingObject) {
      existingObject.rows.push({ ...item })
    } else {
      acc.push({
        jigyocd: item.jigyocd,
        rows: [{ ...item }]
      })
    }
    return acc
  }, [])

  showSaveModal({
    onOk: async () => {
      try {
        await Save({ locklist, kekkalist, nendo: nendo.value })
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        resetSearch()
        showConfirmModal({
          content: C021002,
          onOk: () => DoBatch({ nendo: nendo.value })
        })
        nextTick(() => searchData())
      } catch (error) {}
    }
  })
}

//成人健（検）診事業一覧画面に遷移
function handleMove() {
  router.push({
    name: 'AWKK00801G',
    query: { type: '4' } //todo
  })
}

function setLastflag() {
  tableData.value.forEach((item, index) => {
    const nextItem = tableData.value[index + 1]
    item.lastflag = Boolean(!nextItem || nextItem.groupNo !== item.groupNo)
  })
}
</script>

<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
