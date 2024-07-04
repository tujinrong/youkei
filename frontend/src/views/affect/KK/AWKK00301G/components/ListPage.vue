<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>宛名番号</th>
            <td>
              <AtenanoSearch
                ref="atenanoRef"
                v-model:loading="loading"
                :params="searchParams"
                :search-request="SearchList"
                @finish="forwardList2"
              />
            </td>
          </a-col>
          <a-col class="mincho" :md="12" :lg="12" :xl="8" :xxl="6">
            <th>氏名</th>
            <td>
              <a-input v-model:value="searchParams.name" />
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>カナ氏名</th>
            <td>
              <a-input
                v-model:value="searchParams.kname"
                @change="searchParams.kname = replaceText(searchParams.kname, EnumRegex.カナ氏名)"
              />
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>生年月日</th>
            <td>
              <date-jp
                v-model:value="searchParams.bymd"
                unknown
                format="YYYY-MM-DD"
                style="width: 190px"
                @emit-unknown-date="(v) => (searchParams.bymd = v)"
              />
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1">
        <a-space>
          <a-button type="primary" :disabled="atenanoRef?.focused" @click="searchData()"
            >検索</a-button
          >
          <a-button
            type="primary"
            :style="searchDrawerRef?.hasCondition && { filter: 'hue-rotate(60deg)' }"
            @click="searchDrawerRef?.showDrawer({ note: detailSearchNote })"
            >詳細検索
            <span v-if="searchDrawerRef?.hasCondition">☆</span>
          </a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page class="float-right"></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        v-model:total="totalCount"
        :page-size-options="$pagesizes"
        show-less-items
        show-size-changer
        class="text-end"
      />
      <vxe-table
        class="mt-2"
        :height="tableHeight"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{ trigger: 'cell', remote: true }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        @cell-dblclick="({ row }) => forwardList2(row)"
      >
        <vxe-column
          field="atenano"
          :params="{ order: 1 }"
          title="宛名番号"
          width="140"
          min-width="90"
          sortable
        >
          <template #default="{ row }: { row: JyuminListVM }">
            <a @click="forwardList2(row)">{{ row.atenano }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="name"
          :params="{ order: 2 }"
          title="氏名"
          width="120"
          min-width="70"
          sortable
          class-name="mincho"
          header-class-name="mincho"
        >
          <template #default="{ row }: { row: JyuminListVM }">
            <a @click="forwardList2(row)">{{ row.name }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="kname"
          :params="{ order: 3 }"
          title="カナ氏名"
          width="120"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="sex"
          :params="{ order: 4 }"
          title="性別"
          width="60"
          min-width="60"
          sortable
        ></vxe-column>
        <vxe-column
          field="bymd"
          :params="{ order: 5 }"
          title="生年月日"
          width="150"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="adrs"
          :params="{ order: 6 }"
          title="住所"
          min-width="70"
          sortable
        ></vxe-column>
        <vxe-column
          field="gyoseiku"
          :params="{ order: 7 }"
          title="行政区"
          width="150"
          min-width="80"
          sortable
        ></vxe-column>
        <vxe-column
          field="juminkbn"
          :params="{ order: 8 }"
          title="住民区分"
          width="110"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="keikoku"
          :params="{ order: 9 }"
          title="警告内容"
          width="240"
          min-width="90"
          sortable
        ></vxe-column>
      </vxe-table>
    </a-card>
    <DetailSearchDrawer ref="searchDrawerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { EnumRegex, EnumServiceResult, PageSatatus } from '#/Enums'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import { useTableHeight } from '@/utils/hooks'
import { showConfirmModal } from '@/utils/modal'
import { changeTableSort, replaceText } from '@/utils/util'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'
import { reactive, ref, toRef, watch } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { SearchList } from '../service'
import { JyuminListVM } from '../type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const searchDrawerRef = ref<InstanceType<typeof DetailSearchDrawer> | null>(null)
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const createDefaultParams = () => {
  return {
    atenano: '',
    name: '',
    kname: '',
    bymd: ''
  }
}
const searchParams = reactive(createDefaultParams())
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const tableList = ref<JyuminListVM[]>([])
const detailSearchNote = `宛名番号、氏名、カナ氏名、生年月日`

//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
//クリア処理(遷移時)
onBeforeRouteUpdate(() => {
  searchParams.atenano = ''
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) searchData()
})
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
//クリア
const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  tableList.value = []
  pageParams.pagenum = 1
  searchDrawerRef.value?.resetDrawer()
  totalCount.value = 0
}

//遷移処理(編集画面へ)
const forwardList2 = (val: JyuminListVM) => {
  router.push({
    name: route.name as string,
    query: {
      atenano: val.atenano,
      status: PageSatatus.Edit
    }
  })
}

//検索処理
const searchData = () => {
  searchDrawerRef.value?.validateDrawer().then(async (result) => {
    loading.value = true
    SearchList({
      ...pageParams,
      ...searchParams,
      syosailist: result
    })
      .then((res) => {
        if (res.totalpagecount < pageParams.pagenum) {
          pageParams.pagenum = 1
        }
        tableList.value = res.kekkalist
        totalCount.value = res.totalrowcount
        if (res.transflg) forwardList2(res.kekkalist[0])
      })
      .finally(() => (loading.value = false))
  })
}
</script>
<style lang="less" scoped>
.self_adaption_table.form th {
  width: 90px;
}
</style>
