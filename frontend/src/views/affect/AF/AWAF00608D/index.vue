<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 送付先管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.14
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="送付先管理"
    centered
    :mask-closable="false"
    :closable="false"
    destroy-on-close
    :footer="null"
  >
    <a-spin :spinning="loading">
      <b>住民情報</b>
      <div class="self_adaption_table mb-2">
        <a-row>
          <a-col span="6">
            <th>宛名番号</th>
            <TD>{{ $route.query.atenano }}</TD>
          </a-col>
          <a-col span="6">
            <th>氏名</th>
            <TD>{{ header?.name }}</TD>
          </a-col>
          <a-col span="6">
            <th>カナ氏名</th>
            <TD>{{ header?.kname }}</TD>
          </a-col>
          <a-col span="6">
            <th style="width: 120px">性別</th>
            <TD>{{ header?.sex }}</TD>
          </a-col>
          <a-col span="6">
            <th>住民区分</th>
            <TD>{{ header?.juminkbn }}</TD>
          </a-col>
          <a-col span="6">
            <th>生年月日</th>
            <TD>{{ header?.bymd }}</TD>
          </a-col>
          <a-col span="6">
            <th>年齢</th>
            <TD>{{ header?.age }}</TD>
          </a-col>
          <a-col span="6">
            <th style="width: 120px">年齢計算基準日</th>
            <TD>{{ header?.agekijunymd }}</TD>
          </a-col>
          <a-col span="6">
            <th>郵便番号</th>
            <TD>{{ header?.adrs_yubin }}</TD>
          </a-col>
          <a-col span="12">
            <th>住所</th>
            <TD>{{ header?.adrs }}</TD>
          </a-col>
          <a-col v-if="status !== PageSatatus.List && detailRef?.showSisyo" span="6">
            <th style="width: 120px">登録支所</th>
            <TD>{{ detailRef?.regsisyo }}</TD>
          </a-col>
        </a-row>
      </div>
      <div v-show="status === PageSatatus.List">
        <CloseModalBtn class="close-btn" @click="closeModal" />

        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="m-b-1 text-end"
        />
        <vxe-table
          height="391"
          :column-config="{ resizable: true }"
          :row-config="{ isHover: true }"
          :data="tableData"
          :sort-config="{ trigger: 'cell', remote: true }"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => handleEdit(row.riyomokutekicd)"
        >
          <vxe-column title="利用目的">
            <template #default="{ row }">
              <a @click="handleEdit(row.riyomokutekicd)">{{ row.riyomokutekinm }}</a>
            </template>
          </vxe-column>
          <vxe-column field="torokujiyu" title="登録事由" />
          <vxe-column field="sofusaki_yubin" title="送付先郵便番号" />
          <vxe-column field="sofusaki_adrs" title="送付先住所" />
          <vxe-column field="sofusaki_simei" title="送付先氏名" />
        </vxe-table>
      </div>

      <Detail
        v-if="status !== PageSatatus.List"
        ref="detailRef"
        v-model:status="status"
        :riyomokuteki="riyomokuteki"
        @refresh="getData"
        @close="closeModal"
      />

      <div v-if="status === PageSatatus.List" class="bottom-bar">
        <a-space>
          <a-button type="primary" :disabled="!canAdd" @click="handleAdd">新規</a-button>
          <a-button type="primary" :disabled="!exceloutflg" @click="handleExcel"
            >EXCEL出力</a-button
          >
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </a-spin>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, reactive, ref, watch } from 'vue'
import TD from '@/components/Common/TableTD/index.vue'
import { Enum共通バー番号, PageSatatus } from '#/Enums'
import Detail from './components/Detail.vue'
import { getBarKengen } from '@/utils/user'
import { InitList } from './service'
import { PersonHeaderVM, RowVM } from './type'
import { useRoute } from 'vue-router'
import { showInfoModal } from '@/utils/modal'
import { DATA_NOTEXIST_ERROR } from '@/constants/msg'
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const visible = ref(false)
const loading = ref(false)
const detailRef = ref<InstanceType<typeof Detail> | null>(null)
const header = ref<PersonHeaderVM | null>(null)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1
})
const totalCount = ref(0)
const tableData = ref<RowVM[]>([])
const status = ref(PageSatatus.List)
const riyomokuteki = ref('')
const exceloutflg = ref(false)
const sinkiflg = ref(false)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableData.value.length > 0 || totalCount.value > 0) getData()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限取得
const kengen = computed(() => getBarKengen(Enum共通バー番号.送付先管理))
const canAdd = computed(() => kengen.value.addflg)

//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//初期化処理
function openModal() {
  visible.value = true
  getData()
}

async function getData() {
  loading.value = true
  try {
    const res = await InitList({ atenano: route.query.atenano as string, ...pageParams })
    header.value = res.headerinfo
    exceloutflg.value = res.exceloutflg
    sinkiflg.value = res.sinkiflg
    if (res.totalpagecount < pageParams.pagenum) {
      pageParams.pagenum = 1
    }
    tableData.value = res.kekkalist
    totalCount.value = res.totalrowcount
  } catch (error) {}
  loading.value = false
}

function handleAdd() {
  if (!sinkiflg.value) {
    showInfoModal({
      type: 'warning',
      content: DATA_NOTEXIST_ERROR.Msg.replace('{0}', '未使用利用目的').replace('{1}', '新規')
    })
    return
  }
  riyomokuteki.value = ''
  status.value = PageSatatus.New
}
function handleEdit(val: string) {
  riyomokuteki.value = val
  status.value = PageSatatus.Edit
}
function handleExcel() {
  //
}

//リセット
function reset() {
  tableData.value = []
  header.value = null
  totalCount.value = 0
  pageParams.pagenum = 1
  riyomokuteki.value = ''
  status.value = PageSatatus.List
}

//閉じるボタン(×を含む)
function closeModal() {
  visible.value = false
  reset()
}

defineExpose({
  open: openModal
})
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 90px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}

:deep(.close-btn) {
  position: absolute;
  top: -80px;
  right: -24px;
}

:deep(.bottom-bar) {
  display: flex;
  justify-content: space-between;
  margin: 24px -24px -24px -24px;
  padding: 10px 16px;
  border-top: 1px solid #f0f0f0;
}
</style>
