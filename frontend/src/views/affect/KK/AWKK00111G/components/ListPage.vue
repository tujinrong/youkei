<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 住登外者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>宛名番号</th>
            <td>
              <AtenanoSearch
                ref="atenanoRef"
                v-model:loading="loading"
                :params="searchParams"
                :search-request="SearchList"
                @finish="forwardEdit"
              />
            </td>
          </a-col>
          <a-col v-if="personalnoflg" :md="12" :xl="8" :xxl="6">
            <th>個人番号</th>
            <td>
              <PersonalnoSearch
                ref="personalnoRef"
                v-model:loading="loading"
                v-model:totalCount="totalCount"
                v-model:tableList="tableList"
                :params="searchParams"
                :search-request="SearchList"
                @finish="forwardEdit"
              />
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>氏名</th>
            <td class="mincho">
              <a-input v-model:value="searchParams.name" />
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>カナ氏名</th>
            <td>
              <a-input
                v-model:value="searchParams.kname"
                @change="searchParams.kname = replaceText(searchParams.kname, EnumRegex.カナ氏名)"
              />
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>生年月日</th>
            <td>
              <DateJp
                v-model:value="searchParams.bymd"
                unknown
                style="width: 190px"
                format="YYYY-MM-DD"
                @emit-unknown-date="(v) => (searchParams.bymd = v)"
              />
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>生年月日不詳</th>
            <td>
              <a-checkbox v-model:checked="searchParams.fusyoflg" />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="24" :xl="8" :xxl="8">
            <th>登録者</th>
            <td>
              <ai-select
                v-model:value="searchParams.reguser"
                :options="initData.selectorlist1"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="24" :xl="16" :xxl="16">
            <th>登録日時</th>
            <td>
              <RangeDateTime
                v-model:value1="searchParams.regdatef"
                v-model:value2="searchParams.regdatet"
              />
            </td>
          </a-col>
          <a-col :md="24" :xl="8" :xxl="8">
            <th>更新者</th>
            <td>
              <ai-select
                v-model:value="searchParams.upduser"
                :options="initData.selectorlist2"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="24" :xl="16" :xxl="16">
            <th>更新日時</th>
            <td>
              <RangeDateTime
                v-model:value1="searchParams.upddatef"
                v-model:value2="searchParams.upddatet"
              />
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="8">
            <th>削除フラグ</th>
            <td>
              <ai-select
                v-model:value="searchParams.delflg"
                :options="initData.selectorlist3"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="8">
            <th>業務ID</th>
            <td>
              <ai-select
                v-model:value="searchParams.gyomuid"
                :options="initData.selectorlist4"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="8">
            <th style="width: 170px">独自施策システム等ID</th>
            <td>
              <ai-select
                v-model:value="searchParams.dokujisystemid"
                :options="initData.selectorlist5"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" :disabled="!addFlg || focused" @click="forwardNew"
            >新規</a-button
          >
          <a-button type="primary" :disabled="focused" @click="searchData">検索</a-button>
          <a-button
            type="primary"
            :style="searchDrawerRef?.hasCondition && { filter: 'hue-rotate(60deg)' }"
            @click="searchDrawerRef?.showDrawer({ note: detailSearchNote })"
            >詳細検索
            <span v-if="searchDrawerRef?.hasCondition">☆</span>
          </a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="my-2">
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
        <vxe-table
          class="mt-2"
          :height="tableHeight"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="tableList"
          :empty-render="{ name: 'NotData' }"
          :sort-config="{ trigger: 'cell', remote: true }"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
          @cell-dblclick="({ row }) => forwardEdit(row)"
        >
          <vxe-column field="atenano" title="宛名番号" :params="{ order: 1 }" sortable>
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.atenano }}</a>
            </template>
          </vxe-column>
          <vxe-column field="rirekino" title="履歴番号" width="120" :params="{ order: 2 }" sortable>
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.rirekino }}</a>
            </template>
          </vxe-column>
          <vxe-column field="stopflg" title="削除" width="70" :params="{ order: 3 }" sortable>
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.stopflg }}</a>
            </template>
          </vxe-column>
          <vxe-column field="name" title="氏名" :params="{ order: 4 }" sortable>
            <template #default="{ row }">
              <a @click="forwardEdit(row)">{{ row.name }}</a>
            </template>
          </vxe-column>
          <vxe-column field="kname" title="カナ氏名" :params="{ order: 5 }" sortable></vxe-column>
          <vxe-column
            field="sexhyoki"
            title="性別"
            width="70"
            :params="{ order: 6 }"
            sortable
          ></vxe-column>
          <vxe-column
            field="juminkbn"
            title="住民区分"
            :params="{ order: 7 }"
            sortable
          ></vxe-column>
          <vxe-column field="bymd" title="生年月日" :params="{ order: 8 }" sortable></vxe-column>
          <vxe-column field="adrs" title="住所" :params="{ order: 9 }" sortable></vxe-column>
          <vxe-column
            field="keikoku"
            title="警告内容"
            :params="{ order: 10 }"
            sortable
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
    <DetailSearchDrawer ref="searchDrawerRef" />
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive, toRef, computed } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { InitListResponse, RowVM } from '../type'
import { EnumRegex, PageSatatus } from '#/Enums'
import { InitList, SearchList } from '../service'
import { encryptByRSA } from '@/utils/encrypt/data'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import RangeDateTime from '@/components/Selector/RangeDateTime/index.vue'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'
import { changeTableSort, replaceText } from '@/utils/util'
import { useTableHeight } from '@/utils/hooks'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
//テンプレート参照
const searchDrawerRef = ref<InstanceType<typeof DetailSearchDrawer> | null>(null)
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const personalnoRef = ref<InstanceType<typeof PersonalnoSearch> | null>(null)
//ページャー
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})

const createDefaultParams = () => {
  return {
    atenano: '',
    personalno: '',
    name: '',
    kname: '',
    bymd: '',
    fusyoflg: false,
    reguser: '',
    regdatef: '',
    regdatet: '',
    upduser: '',
    upddatef: '',
    upddatet: '',
    delflg: '',
    gyomuid: '',
    dokujisystemid: ''
  }
}
const searchParams = reactive(createDefaultParams())

const tableList = ref<RowVM[]>([])

const initData = ref<Partial<InitListResponse>>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: []
})

//新规権限フラグ
const addFlg = route.meta.addflg
//個人番号権限フラグ
const personalnoflg = route.meta.personalnoflg

//詳細条件フッター部説明文
const detailSearchNote = `宛名番号、${
  personalnoflg ? '個人番号、' : ''
}氏名、カナ氏名、生年月日、生年月日不詳、登録者、登録日時、更新者、更新日時、削除フラグ、業務ID、独自施策システム等ID`

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) searchData()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

const focused = computed(() => {
  return atenanoRef.value?.focused || personalnoRef.value?.focused
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitList().then((res) => {
    initData.value = res
  })
})
//クリア処理(遷移時)
onBeforeRouteUpdate(() => {
  searchParams.atenano = ''
  searchParams.personalno = ''
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function forwardNew() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.New
    }
  })
}
function forwardEdit(val: RowVM) {
  router.push({
    name: route.name as string,
    query: {
      atenano: val.atenano,
      rirekino: val.rirekino
    }
  })
}

//検索処理
const searchData = async () => {
  const syosailist = await searchDrawerRef.value?.validateDrawer()
  loading.value = true
  try {
    const res = await SearchList({
      ...pageParams,
      ...searchParams,
      syosailist,
      personalno: encryptByRSA(searchParams.personalno)
    })
    if (res.totalpagecount < pageParams.pagenum) {
      pageParams.pagenum = 1
    }
    totalCount.value = res.totalrowcount
    tableList.value = res.kekkalist
    //検索結果1件の場合、詳細画面へ遷移
    if (res.totalrowcount === 1 && res.totalpagecount === 1) {
      forwardEdit(res.kekkalist[0])
    }
  } catch (error) {}
  loading.value = false
}

//クリア
const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  tableList.value = []
  totalCount.value = 0
  pageParams.pagenum = 1
  searchDrawerRef.value?.resetDrawer()
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 120px;
}
</style>
