<template>
  <div>
    <a-card ref="headRef" :bordered="false" :loading="loading">
      <b>世帯情報</b>
      <div class="self_adaption_table">
        <a-row>
          <a-col span="12">
            <th>世帯番号</th>
            <TD>{{ headerInfo?.atenano }}</TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th>世帯主カナ氏名</th>
            <TD>{{ headerInfo?.kname }}</TD>
          </a-col>
          <a-col span="12">
            <th>世帯主氏名</th>
            <TD>{{ headerInfo?.name }}</TD>
          </a-col>
          <a-col span="12">
            <th>郵便番号</th>
            <TD>{{ headerInfo?.adrs_yubin }}</TD>
          </a-col>
          <a-col span="12">
            <th>指定都市_行政区等</th>
            <TD>{{ headerInfo?.tosi_gyoseiku }}</TD>
          </a-col>
          <a-col span="24">
            <th>住所</th>
            <TD class="mincho">{{ headerInfo?.adrs }}</TD>
          </a-col>
          <a-col v-for="(item, index) in headerInfo?.tikulist ?? []" :key="index" span="24">
            <th>{{ item.tikukbn }}</th>
            <TD class="mincho">{{ item.tiku }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex justify-between">
        <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
        <ClosePage />
      </div>
    </a-card>
    <a-card class="mt-2">
      <div class="flex justify-between mb-2">
        <b>世帯構成員情報</b>
      </div>
      <vxe-table
        ref="xTable"
        :height="Math.max(tableHeight, 400)"
        :loading="loading"
        :column-config="{ resizable: true }"
        :row-config="{ keyField: 'atenano', isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardDetail(row)"
      >
        <vxe-column field="atenano" title="宛名番号" sortable width="160" min-width="100">
          <template #default="{ row }">
            <a @click="forwardDetail(row)">{{ row.atenano }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="name"
          title="氏名"
          sortable
          width="160"
          min-width="100"
          class-name="mincho"
          header-class-name="mincho"
        >
          <template #default="{ row }">
            <a @click="forwardDetail(row)">{{ row.name }}</a>
          </template>
        </vxe-column>
        <vxe-column field="kname" title="カナ氏名" sortable min-width="100"></vxe-column>
        <vxe-column field="sex" title="性別" sortable width="80" min-width="60"></vxe-column>
        <vxe-column field="bymd" title="生年月日" sortable min-width="100"></vxe-column>
        <vxe-column field="juminkbn" title="住民区分" sortable min-width="100"></vxe-column>
        <vxe-column field="zokuhyoki" title="続柄" sortable min-width="100"></vxe-column>
        <vxe-column field="homonyoteiymd" title="訪問予定日" sortable min-width="100"></vxe-column>
        <vxe-column field="homonjissiymd" title="訪問実施日" sortable min-width="100"></vxe-column>
        <vxe-column
          field="kobetuyoteiymd"
          title="個別指導予定日"
          sortable
          min-width="100"
        ></vxe-column>

        <vxe-column
          field="kobetujissiymd"
          title="個別指導実施日"
          sortable
          min-width="100"
        ></vxe-column>
        <vxe-column field="keikoku" title="警告内容" sortable min-width="100"></vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { PageSatatus } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import { useTableHeight } from '@/utils/hooks'
import { nextTick, onMounted, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { SearchDetail } from '../service'
import { SetaiBaseInfoVM, SetaiListVM, SetaiTikuListVM } from '../type'
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const loading = ref(false)
const router = useRouter()
const route = useRoute()
const headerInfo = ref<(SetaiBaseInfoVM & { tikulist: SetaiTikuListVM[] }) | null>(null)
const xTable = ref<VxeTableInstance>()
const tableList = ref<SetaiListVM[]>([])
const atenano = (route.query.prevno || route.query.atenano) as string

//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 10)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  searchData()
})
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
//遷移処理(一覧へ)
function forwardSearch() {
  router.push({
    name: route.name as string
  })
}

const forwardDetail = (val) => {
  router.push({
    name: 'AWKK00301G',
    query: {
      atenano: val.atenano,
      prevno: route.query.atenano as string,
      status: PageSatatus.Detail
    }
  })
}

const searchData = async () => {
  loading.value = true
  try {
    const res = await SearchDetail({ atenano })
    headerInfo.value = {
      ...res.setaibaseinfo,
      tikulist: res.setaitikulist
    }
    tableList.value = res.setailist
  } catch (error) {}
  loading.value = false

  nextTick(() => {
    const row = xTable.value?.getRowById(atenano)
    xTable.value?.setCurrentRow(row)
  })
}
</script>
<style lang="less" scoped>
th {
  width: 180px;
}
</style>
