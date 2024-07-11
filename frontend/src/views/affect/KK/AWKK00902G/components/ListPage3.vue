<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin v-show="!yoyakuno" :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>業務</th>
            <TD>{{ headerInfo?.gyomukbnnm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>日程番号</th>
            <TD>{{ route.query.nitteino }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>事業名</th>
            <TD>{{ headerInfo?.jigyonm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>実施内容</th>
            <TD>{{ headerInfo?.jissinaiyo }}</TD>
          </a-col>
          <a-col v-show="courseno" :md="12" :lg="8" :xxl="6">
            <th>コース番号</th>
            <TD>{{ headerInfo?.courseno }}</TD>
          </a-col>
          <a-col v-show="courseno" :md="12" :lg="8" :xxl="6">
            <th>コース名</th>
            <TD>{{ headerInfo?.coursenm }}</TD>
          </a-col>
          <a-col v-show="courseno" :md="12" :lg="8" :xxl="6">
            <th>回数</th>
            <TD>{{ headerInfo?.kaisu }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>実施予定日</th>
            <TD>{{
              headerInfo?.jissiyoteiymd ? getDateJpText(new Date(headerInfo.jissiyoteiymd)) : ''
            }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>開始時間</th>
            <TD>{{ headerInfo?.tmf }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>終了時間</th>
            <TD>{{ headerInfo?.tmt }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>会場</th>
            <TD>{{ headerInfo?.kaijonm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>医療機関</th>
            <TD>{{ headerInfo?.kikannm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>担当者</th>
            <TD>{{ headerInfo?.staffnms }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex">
        <a-space>
          <a-button type="primary" :disabled="!canDelete" danger @click="deleteData">削除</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="visible = true">新規</a-button>
          <a-button type="primary" @click="back2list">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="mt-2">
      <div class="self_adaption_table mb-2 max-w-200">
        <a-row class="status-bar">
          <a-col span="6">
            <th>状態</th>
            <td class="pl-3.5!" v-html="formatExceedText({ cellValue: detailInfo?.status })"></td>
          </a-col>
          <a-col span="6">
            <th>定員数</th>
            <TD>{{ detailInfo?.teiin }}</TD>
          </a-col>
          <a-col span="6">
            <th>申込人数</th>
            <TD>{{ detailInfo?.moushikominum }}</TD>
          </a-col>
          <a-col span="6">
            <th>待機人数</th>
            <TD>{{ detailInfo?.taikinum }}</TD>
          </a-col>
        </a-row>
      </div>
      <vxe-table
        ref="xTableRef"
        :height="Math.max(tableHeight, 400)"
        :scroll-y="{ enabled: true, oSize: 10 }"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true, keyField: 'yoyakuno' }"
        :data="tableData"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goDetail(row)"
      >
        <vxe-column type="checkbox" width="50"></vxe-column>
        <vxe-column field="yoyakuno" title="予約番号" width="90">
          <template #default="{ row }">
            <a @click="goDetail(row)">{{ row.yoyakuno }}</a>
          </template>
        </vxe-column>
        <vxe-column field="atenano" title="宛名番号" min-width="100"></vxe-column>
        <vxe-column field="name" title="氏名" min-width="100"></vxe-column>
        <vxe-column field="kname" title="カナ氏名" min-width="100"></vxe-column>
        <vxe-column field="sex" title="性別" width="70"></vxe-column>
        <vxe-column field="bymd" title="生年月日" min-width="100"></vxe-column>
        <vxe-column field="age" title="年齢" width="70"></vxe-column>
        <vxe-column field="juminkbn" title="住民区分" min-width="100"></vxe-column>
        <vxe-column field="status" title="待機状態" width="90"></vxe-column>
        <vxe-column field="keikoku" title="警告内容" min-width="100"></vxe-column>
      </vxe-table>
    </a-card>
    <AtenanoModal v-model:visible="visible" @select="selectAtenano" />
  </a-spin>
  <DetailPage v-if="yoyakuno" @after-close="searchData" />
</template>

<script lang="ts" setup>
import TD from '@/components/Common/TableTD/index.vue'
import { DELETE_OK_INFO } from '@/constants/msg'
import { useTableHeight } from '@/utils/hooks'
import { showDeleteModal } from '@/utils/modal'
import { formatExceedText, getDateJpText } from '@/utils/util'
import AtenanoModal from '@/views/affect/AF/AWAF00705D/index.vue'
import { message } from 'ant-design-vue'
import { computed, onMounted, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { DeletePersonList, InitDetailPersonList } from '../service'
import { PersonDetailVM, PersonHeaderVM, PersonRowVM } from '../type'
import { E014004 } from '@/constants/msg'
import DetailPage from './DetailPage.vue'

enum PageStatus {
  List1 = 1,
  List2,
  List3
}
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const visible = ref(false)
const loading = ref(false)
const xTableRef = ref<VxeTableInstance>()
const courseno = route.query.courseno

const headerInfo = ref<PersonHeaderVM>()
const detailInfo = ref<PersonDetailVM>()
const tableData = ref<PersonRowVM[]>([])

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => searchData())

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -4)

//操作権限フラグ
const addFlg = route.meta.addflg
const canDelete = computed(() => {
  const records = xTableRef.value?.getCheckboxRecords()
  return records && records.length > 0 && route.meta.delflg
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitDetailPersonList({
      nitteino: Number(route.query.nitteino)
    })
    headerInfo.value = res.headerinfo
    detailInfo.value = res.detailinfo
    tableData.value = res.kekkalist
  } catch (error) {}
  loading.value = false
}

//削除処理
function deleteData() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      const records: PersonRowVM[] = xTableRef.value?.getCheckboxRecords() ?? []
      try {
        await DeletePersonList({
          locklist: records.map((el) => ({
            nitteino: Number(route.query.nitteino),
            atenano: el.atenano,
            upddttm: el.upddttm
          }))
        })
        message.success(DELETE_OK_INFO.Msg)
        back2list()
      } catch (error) {}
    }
  })
}

//画面遷移
function selectAtenano(val) {
  let hasAtenano = false
  tableData.value.forEach((el) => {
    if (el.atenano == val.atenano) {
      hasAtenano = true
    }
  })
  if (hasAtenano) {
    message.error(E014004.Msg.replace('{0}', '予約').replace('{1}', '新規登録'))
  } else {
    goDetail({ yoyakuno: -1, atenano: val.atenano })
  }
}

function goDetail({ yoyakuno, atenano }) {
  router.push({
    name: route.name as string,
    query: { ...route.query, yoyakuno, atenano }
  })
}
function back2list() {
  if (courseno) {
    router.push({
      name: route.name as string,
      query: {
        ...route.query,
        status: PageStatus.List2
      }
    })
  } else {
    router.push({
      name: route.name as string
    })
  }
}

//詳細画面切り替え---------------------------------------------------------------------
const yoyakuno = ref('')
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00902G') {
      yoyakuno.value = route.query.yoyakuno as string
    }
  },
  { deep: true, immediate: true }
)
//----------------------------------------------------------------------------
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
.self_adaption_table .status-bar th {
  width: 90px !important;
}
</style>
