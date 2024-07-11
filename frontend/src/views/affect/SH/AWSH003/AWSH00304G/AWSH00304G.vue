<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 成人健（検）診対象者設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.31
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table w-56">
        <a-row>
          <a-col span="24">
            <th class="w-25">年度</th>
            <TD>{{ nendo ? yearFormatter(nendo) : '' }}</TD>
          </a-col>
        </a-row>
      </div>

      <div class="mt-2">
        <a-space>
          <a-button class="warning-btn" :disabled="!addFlg || disabled_save" @click="saveData"
            >登録</a-button
          >
          <a-button type="primary" @click="handleMove">検診種別・検査方法追加</a-button>
        </a-space>
        <close-page ref="closePageRef" class="float-right"></close-page>
      </div>

      <a-space class="mt-2">
        <div class="self_adaption_table form w-100">
          <a-row>
            <a-col span="24">
              <th class="w-35">対象サイン引継ぎ</th>
              <td>
                <ai-select
                  v-model:value="formData.hikitugikbn"
                  :options="options.selectorlist8"
                  split-val
                />
              </td>
            </a-col>
          </a-row>
        </div>
        <a-button type="primary" :disabled="!addFlg" @click="searchData">前年度引継ぎ</a-button>
      </a-space>
    </a-card>

    <Table
      :table-data="tableData"
      :head-ref="headRef"
      :can-add="addFlg"
      :options="options"
      @setlastflag="setLastflag"
    />
  </a-spin>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { C021001, C021002, SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { showConfirmModal, showSaveModal } from '@/utils/modal'
import { yearFormatter } from '@/utils/util'
import Table from '@/views/affect/SH/AWSH003/AWSH00301G/components/Table.vue'
import { ItemVM, LockVM, RowVM } from '@/views/affect/SH/AWSH003/AWSH00301G/type'
import { InitResponse } from './type'
import { message } from 'ant-design-vue'
import { nextTick, onMounted, provide, ref, watch, watchEffect, reactive } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { DoBatch, Init, Save, Search } from './service'

type OptionsVM = Omit<InitResponse, keyof DaResponseBase | 'nendo'>
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const closePageRef = ref()
const editJudge = new Judgement(route.name as string)
const loading = ref(false)
const nendo = ref(0)
provide('nendo', nendo)

const xTableRef = ref<VxeTableInstance>()
const tableData = ref<ItemVM[]>([])
const options = ref<OptionsVM>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  selectorlist6: [],
  selectorlist8: []
})
let locklist: LockVM[] = []
const formData = reactive({
  hikitugikbn: ''
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限フラグ
const addFlg = route.meta.addflg as boolean
const disabled_save = ref(false)
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
    nendo.value = res.nendo
  })

  showConfirmModal({
    content: C021001,
    onCancel() {
      closePageRef.value?.close()
    }
  })
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await Search({ nendo: nendo.value })
    tableData.value = res.kekkalist.flatMap((item, index) => {
      return item.rows.map((row) => ({
        ...row,
        jigyocd: item.jigyocd,
        groupNo: index,
        newflg: true
      }))
    })
    locklist = res.locklist
    setLastflag()
  } catch (error) {}
  loading.value = false
  nextTick(() => editJudge.reset())
}

//保存処理
async function saveData() {
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
        await Save({
          ...formData,
          kekkalist,
          locklist,
          nendo: nendo.value
        })
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        disabled_save.value = true
        showConfirmModal({
          content: C021002,
          onOk: () => DoBatch({ nendo: nendo.value })
        })
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
