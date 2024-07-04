<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 乳幼児情報一覧
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.05.22
 * 作成者　　: 張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    title="乳幼児情報一覧"
    width="1200px"
    :closable="true"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="6">
            <th>宛名番号</th>
            <TD>{{ $route.query.atenano }}</TD>
          </a-col>
          <a-col span="6">
            <th>氏名</th>
            <TD>{{ headerinfo?.name }}</TD>
          </a-col>
          <a-col span="6">
            <th>カナ氏名</th>
            <TD>{{ headerinfo?.kname }}</TD>
          </a-col>
          <a-col span="6">
            <th style="width: 120px">性別</th>
            <TD>{{ headerinfo?.sexhyoki }}</TD>
          </a-col>
          <a-col span="6">
            <th>住民区分</th>
            <TD>{{ headerinfo?.juminkbnnm }}</TD>
          </a-col>
          <a-col span="6">
            <th>生年月日</th>
            <TD>{{ headerinfo?.bymd }}</TD>
          </a-col>
          <a-col span="6">
            <th>年齢</th>
            <TD>{{ headerinfo?.age }}</TD>
          </a-col>
          <a-col span="6">
            <th style="width: 120px">年齢計算基準日</th>
            <TD>{{ headerinfo?.agekijunymd }}</TD>
          </a-col>
        </a-row>
      </div>
      <a-card class="mt-4">
        <div class="m-t-1 flex justify-between">
          <a-space>
            <a-button type="primary" @click="forwardResultPage">選択</a-button>
          </a-space>
        </div>
        <div class="mt-4" :style="{ height: '410px' }">
          <vxe-table
            ref="xTableRef"
            height="100%"
            :header-cell-style="{ backgroundColor: '#ffffe1' }"
            :mouse-config="{ selected: true }"
            :column-config="{ resizable: true }"
            :sort-config="{ trigger: 'cell' }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="tableList"
            :empty-render="{ name: 'NotData' }"
            @cell-dblclick="({ row }) => forwardResultPage(row)"
            :edit-config="{
              trigger: 'click',
              mode: 'cell',
              showStatus: false
            }"
          >
            <vxe-column field="no" title="No." width="120" min-width="80"> </vxe-column>
            <vxe-column field="atenano" title="宛名番号" min-width="80" />
            <vxe-column field="name" title="氏名" min-width="80" />
            <vxe-column field="kname" title="カナ氏名" min-width="80" />
            <vxe-column field="sexhyoki" title="性別" min-width="80" />
            <vxe-column field="bymd" title="生年月日" min-width="80" />
          </vxe-table>
        </div>
      </a-card>
    </a-spin>
    <template #footer>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watchEffect } from 'vue'
import { SearchJyoseiList } from './service'
import { HeaderInfoVM, ListInfoVM } from './type'
import { VxeTableInstance } from 'vxe-table'
import TD from '@/components/Common/TableTD/index.vue'
import { useRoute, useRouter } from 'vue-router'
import { PageSatatus, Enum保健指導業務区分 } from '#/Enums'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const visible = ref(false)
//ローディング
const loading = ref(true)
//画面データ編集判断
//ビューモデル
const headerinfo = ref<HeaderInfoVM>()
const tableList = ref<ListInfoVM[]>([])
const xTableRef = ref<VxeTableInstance>()
//ビューモデル
const currentRow = ref<ListInfoVM | null>(null)
//現在行
watchEffect(() => {
  currentRow.value = xTableRef.value?.getCurrentRecord()
})

//初期化処理
const openModal = async () => {
  visible.value = true
  try {
    await getList()
  } catch (error) {}
}

//検索処理
async function getList() {
  loading.value = true
  SearchJyoseiList({
    atenano: route.query.atenano as string,
    pagesize: 0,
    pagenum: 0
  }).then((res) => {
    tableList.value = res.kekkalist
    headerinfo.value = res.headerinfo
    if (tableList.value.length === 1) {
      forwardResultPage(tableList.value[0])
    }
    loading.value = false
  })
}

const forwardResultPage = (row: ListInfoVM) => {
  closeModal()
  router.push({
    name: 'AWBH00401G',
    query: {
      status: PageSatatus.Edit,
      atenano: currentRow.value?.atenano
    }
  })
}

const show = (val) => {
  console.log(val)
}
//リセット
function reset() {
  tableList.value = []
}

//閉じるボタン(×を含む)
const closeModal = () => {
  reset()
  visible.value = false
}
defineExpose({
  open: openModal
})
</script>
<style src="./index.less" scoped></style>
