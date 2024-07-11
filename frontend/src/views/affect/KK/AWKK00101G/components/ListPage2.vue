<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 住民記録台帳照会(世帯一覧画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :loading="loading">
      <b>世帯情報</b>
      <div class="self_adaption_table">
        <a-row>
          <a-col span="12">
            <th>世帯番号</th>
            <TD>{{ headerInfo?.setaino }}</TD>
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
            <th>課税非課税区分（世帯）</th>
            <TD>{{ headerInfo?.kazeikbn_setai }}</TD>
          </a-col>
          <a-col span="12">
            <th>指定都市_行政区等</th>
            <TD>{{ headerInfo?.tosi_gyoseiku }}</TD>
          </a-col>
          <a-col span="24">
            <th>郵便番号</th>
            <TD>{{ formatYubin(headerInfo?.adrs_yubin) }}</TD>
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
      <div class="m-t-1 header_operation">
        <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
        <ClosePage />
      </div>
    </a-card>
    <a-card class="mt-2" :style="{ marginBottom: height + 8 + 'px' }">
      <b>世帯構成員情報</b>
      <vxe-table
        ref="xTable"
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
        <vxe-column field="age" title="年齢" sortable width="80" min-width="60"></vxe-column>
        <vxe-column field="juminkbn" title="住民区分" sortable min-width="100"></vxe-column>
        <vxe-column field="zokuhyoki" title="続柄" sortable min-width="100"></vxe-column>
        <vxe-column field="hokenkbn" title="保険区分" sortable min-width="100"></vxe-column>
        <vxe-column field="kazeikbn" title="課税区分" sortable min-width="100"></vxe-column>
        <vxe-column field="keikoku" title="警告内容" sortable min-width="100"></vxe-column>
      </vxe-table>
    </a-card>
    <OperationFooter ref="footerRef" :atenano="atenano" />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, nextTick } from 'vue'
import TD from '@/components/Common/TableTD/index.vue'
import { useRoute, useRouter } from 'vue-router'
import { SearchSetaiList } from '../service'
import { Enum住登区分 } from '#/Enums'
import { VxeTableInstance } from 'vxe-table'
import { SetaiHeaderVM, SetaiRowVM } from '../type'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize } from '@vueuse/core'
import { formatYubin } from '@/utils/util'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(false)
const xTable = ref<VxeTableInstance>()
const headerInfo = ref<SetaiHeaderVM | null>(null)
const tableList = ref<SetaiRowVM[]>([])

const footerRef = ref(null)
const { height } = useElementSize(footerRef)

const atenano = (route.query.prevno || route.query.atenano) as string
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  searchData()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function forwardSearch() {
  router.push({
    name: 'AWKK00101G'
  })
}

const forwardDetail = (val) => {
  if (val.jutokbn === Enum住登区分.住登外) {
    router.push({
      name: 'TODO',
      query: {
        atenano: val.atenano
      }
    })
  } else {
    router.push({
      name: 'AWKK00101G',
      query: {
        atenano: val.atenano,
        prevno: route.query.atenano as string
      }
    })
  }
}

const searchData = async () => {
  loading.value = true
  try {
    const res = await SearchSetaiList({ atenano })
    headerInfo.value = res.headerinfo
    tableList.value = res.kekkalist
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
