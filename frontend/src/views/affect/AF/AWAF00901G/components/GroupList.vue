<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ユーザー管理(一覧画面：所属)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :sm="24" :md="12" :xl="8" :xxl="5">
            <th class="w-26">所属グループ</th>
            <td>
              <ai-select v-model:value="searchParams.syozoku" :options="props.options"></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-row class="flex-1">
          <a-col :md="12" :xl="8" :xxl="5">
            <a-space>
              <a-button type="primary" @click="goGroupAdd">新規</a-button>
              <a-button type="primary" @click="handleSearch">検索</a-button>
              <a-button type="primary" @click="reset">クリア</a-button>
            </a-space>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="5">
            <a-space>
              <a-button type="primary" @click="() => (loginSetVisible = true)"
                >登録部署設定</a-button
              >
            </a-space>
          </a-col>
        </a-row>
        <close-page />
      </div>
    </a-card>

    <a-card class="m-t-1">
      <div>
        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="text-end"
        />
        <div class="m-t-1" :style="{ width: '100%', height: tableHeight }">
          <vxe-table
            height="100%"
            :column-config="{ resizable: true }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="dataList"
            :sort-config="{
              trigger: 'cell',
              remote: true
            }"
            :empty-render="{ name: 'NotData' }"
            @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
            @cell-dblclick="({ row }) => goDetail(row)"
          >
            <vxe-column
              field="syozokucd"
              :params="{ order: 1 }"
              title="所属グループID"
              width="250"
              min-width="160"
              sortable
            >
              <template #default="{ row }">
                <a @click="goDetail(row)">{{ row.syozokucd }}</a>
              </template>
            </vxe-column>
            <vxe-column
              field="syozokunm"
              :params="{ order: 2 }"
              title="所属グループ名"
              min-width="160"
              sortable
            >
              <template #default="{ row }">
                <a @click="goDetail(row)">{{ row.syozokunm }}</a>
              </template>
            </vxe-column>
          </vxe-table>
        </div>
      </div>
    </a-card>
    <SetModal v-model:visible="loginSetVisible" />
  </a-spin>
</template>

<script lang="ts" setup>
import { reactive, ref, computed, toRef, watch, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { changeTableSort } from '@/utils/util'
import { getHeight } from '@/utils/height'
import { SearchListRequest, SyozokuRowVM } from '../type'
import { SearchList } from '../service'
import { Enumロール区分 } from '#/Enums'
import SetModal from '@/views/affect/AF/AWAF00902D/index.vue'
import { useSearch } from '@/utils/hooks'
import emitter from '@/utils/event-bus'

const props = defineProps<{
  options: DaSelectorModel[]
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const searchParams = reactive<Omit<SearchListRequest, keyof CmSearchRequestBase>>({
  syozoku: undefined,
  rolekbn: Enumロール区分.所属
})
const dataList = ref<SyozokuRowVM[]>([])
const loginSetVisible = ref(false)

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: dataList,
  params: toRef(() => searchParams),
  listname: 'kekkalist2'
})
const emit = defineEmits(['initOption'])
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  emitter.once('refreshPermissionList', () => {
    searchParams.syozoku = undefined
    emit('initOption')
    handleSearch(false)
  })
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => getHeight(275))

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function handleSearch(enterDetailPage = true) {
  const res = await searchData()
  //検索結果1件の場合、詳細画面へ遷移
  if (enterDetailPage && res.totalrowcount === 1 && res.totalpagecount === 1) {
    goDetail(res.kekkalist2[0])
    dataList.value = []
  }
}

//画面遷移
const goDetail = (record) => {
  router.push({ name: route.name as string, query: { syozoku: record.syozokucd } })
}
//詳細画面(新規モード：所属)へ遷移
const goGroupAdd = () => {
  router.push({ name: route.name as string, query: { syozoku: '-1' } })
}

function reset() {
  searchParams.syozoku = undefined
  clear()
}
</script>
