<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :xl="12" :xxl="6">
            <th>業務</th>
            <td>
              <ai-select
                v-model:value="searchParams.gyomu"
                :options="initdetail.gyomulist ?? []"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="12" :xxl="6">
            <th>事業コード</th>
            <td>
              <ai-select
                v-model:value="searchParams.jigyo"
                :options="initdetail.jigyolist ?? []"
              ></ai-select></td
          ></a-col>
          <a-col :md="12" :xl="12" :xxl="6">
            <th>予定者/実施者</th>
            <td>
              <ai-select
                v-model:value="searchParams.tantosya"
                :options="
                  initdetail.stafflist?.map((item) => {
                    return {
                      label: item.staffsimei,
                      value: item.staffid
                    }
                  }) ?? []
                "
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="12" :xxl="6">
            <th>実施場所</th>
            <td>
              <ai-select
                v-model:value="searchParams.jissibasyo"
                :options="initdetail.kaijolist ?? []"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="12" :xxl="12">
            <th>予定日</th>
            <td>
              <RangeDate
                v-model:value1="searchParams.yoteiymdf"
                v-model:value2="searchParams.yoteiymdt"
              />
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="12" :xxl="12">
            <th>コース</th>
            <td>
              <ai-select
                v-model:value="searchParams.course"
                :options="initdetail.courselist ?? []"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="12" :xxl="12">
            <th>実施日</th>
            <td>
              <RangeDate
                v-model:value1="searchParams.jissiymdf"
                v-model:value2="searchParams.jissiymdt"
              />
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="12" :xxl="12">
            <th>コース名</th>
            <td>
              <a-input v-model:value="searchParams.coursenm" />
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="12" :xxl="12">
            <th>宛名番号</th>
            <td>
              <a-space>
                <AtenanoSearch
                  ref="atenanoRef"
                  v-model:loading="loading"
                  :params="searchParams"
                  :search-request="SearchList"
                  show-button
                  @finish="forwardList2"
                />
              </a-space>
            </td>
          </a-col>
        </a-row>
      </div>
      <div>
        <a-space class="m-t-1">
          <a-button type="primary" :disabled="atenanoRef?.focused" @click="handleSearch">
            検索
          </a-button>
          <a-button
            type="primary"
            :disabled="!addflg"
            @click="forwardList2({ edano: 0, gyomukbn: Enum保健指導業務区分.母子保健 })"
          >
            新規（母子保健）
          </a-button>
          <a-button
            type="primary"
            :disabled="!addflg"
            @click="forwardList2({ edano: 0, gyomukbn: Enum保健指導業務区分.母子保健 })"
          >
            新規（成人保健）
          </a-button>
          <a-button type="primary">予約・コース取得</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page class="float-right m-t-1"></close-page>
      </div>
    </a-card>
    <a-card class="my-2">
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
        :height="Math.max(tableHeight, 400)"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{ trigger: 'cell', remote: true }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        @cell-click="({ row }) => forwardList2(row)"
      >
        <vxe-column field="edano" title="NO" width="60"></vxe-column>
        <vxe-column
          field="gyomu"
          :params="{ order: 1 }"
          title="業務"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="jigyocd"
          :params="{ order: 2 }"
          title="事業コード"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-colgroup title="申込" align="center">
          <vxe-column
            field="yoteiymd"
            :params="{ order: 3 }"
            title="実施予定日"
            min-width="134"
            sortable
          ></vxe-column>
          <vxe-column
            field="yotetmf"
            :params="{ order: 4 }"
            title="予定開始時間"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="yotebasyo"
            :params="{ order: 5 }"
            title="実施場所"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="yoteisya"
            :params="{ order: 6 }"
            title="予定者"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="nitteno"
            :params="{ order: 7 }"
            title="日程番号"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="nittesyosaino"
            :params="{ order: 8 }"
            title="日程詳細番号"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="coursenm"
            :params="{ order: 9 }"
            title="コース名"
            min-width="90"
            sortable
          ></vxe-column>
        </vxe-colgroup>
        <vxe-colgroup title="結果" align="center">
          <vxe-column
            field="jissiymd"
            :params="{ order: 10 }"
            title="実施日"
            min-width="134"
            sortable
          ></vxe-column>
          <vxe-column
            field="jissitm"
            :params="{ order: 11 }"
            title="実施時間"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="jissibasyo"
            :params="{ order: 12 }"
            title="実施場所"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="jissisya"
            :params="{ order: 13 }"
            title="実施者"
            min-width="90"
            sortable
          ></vxe-column>
        </vxe-colgroup>
      </vxe-table>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
import { PageSatatus, Enum保健指導業務区分 } from '#/Enums'
import RangeDate from '@/components/Selector/RangeDate/index2.vue'
import { useSearch, useTableHeight } from '@/utils/hooks'
import { changeTableSort } from '@/utils/util'
import { onMounted, reactive, ref, toRef } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { InitDetail, SearchList } from '../../service'
import { InitDetailVM, SearchListRequest, SyudanListVM } from '../../type'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const createDefaultParams = (): Omit<SearchListRequest, keyof CmSearchRequestBase> => {
  return {
    gyomu: '',
    jigyo: '',
    tantosya: '',
    jissibasyo: '',
    yoteiymdf: '',
    yoteiymdt: '',
    jissiymdf: '',
    jissiymdt: '',
    course: '',
    coursenm: '',
    atenano: ''
  }
}
const searchParams = reactive(createDefaultParams())
const tableList = ref<SyudanListVM[]>([])
const initdetail = ref<Partial<InitDetailVM>>({})

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: tableList,
  params: toRef(() => searchParams)
})

const addflg = route.meta.addflg

//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitDetail().then((res) => {
    initdetail.value = res.initdetail
  })
})

onBeforeRouteUpdate((to) => {
  searchParams.atenano = ''
  if (to.query.refresh) {
    pageParams.pagenum = 1
    searchData()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
const handleSearch = () => {
  searchData().then((res) => {
    //検索結果1件の場合、詳細画面へ遷移
    if (res.totalrowcount === 1 && res.totalpagecount === 1) {
      forwardList2(res.kekkalist[0])
    }
  })
}

//遷移処理(編集画面へ)
const forwardList2 = (val) => {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      edano: val.edano,
      gyomu: val.gyomukbn,
      patternno: val.gyomukbn
    }
  })
}

const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  clear()
}
</script>

<style lang="less" scoped>
th {
  width: 120px;
}
</style>
