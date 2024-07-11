<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 各種検診対象者保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.07
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>年度<span class="request-mark">＊</span></th>
            <td>
              <YearJp v-model:value="searchParams.nendo" />
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
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
          <a-col v-if="personalnoflg" :md="12" :lg="12" :xl="8" :xxl="6">
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
              <DateJp
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
          <a-button
            type="primary"
            :disabled="atenanoRef?.focused || personalnoRef?.focused"
            @click="searchData()"
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
        :sort-config="{ trigger: 'cell', remote: true }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        @cell-dblclick="({ row }) => forwardEdit(row)"
      >
        <vxe-column
          field="atenano"
          :params="{ order: 1 }"
          title="宛名番号"
          width="170"
          min-width="90"
          sortable
        >
          <template #default="{ row }: { row: PersonRowVM }">
            <a @click="forwardEdit(row)">{{ row.atenano }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="name"
          :params="{ order: 2 }"
          title="氏名"
          width="170"
          min-width="70"
          sortable
          class-name="mincho"
          header-class-name="mincho"
        >
          <template #default="{ row }: { row: PersonRowVM }">
            <a @click="forwardEdit(row)">{{ row.name }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="kname"
          :params="{ order: 3 }"
          title="カナ氏名"
          width="170"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="sex"
          :params="{ order: 4 }"
          title="性別"
          width="70"
          min-width="60"
          sortable
        ></vxe-column>
        <vxe-column
          field="bymd"
          :params="{ order: 5 }"
          title="生年月日"
          width="170"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="juminkbn"
          :params="{ order: 6 }"
          title="住民区分"
          width="130"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="adrs"
          :params="{ order: 7 }"
          title="住所"
          min-width="70"
          sortable
        ></vxe-column>
        <vxe-column
          field="keikoku"
          :params="{ order: 8 }"
          title="警告内容"
          sortable
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
    <DetailSearchDrawer ref="searchDrawerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { EnumRegex, EnumServiceResult } from '#/Enums'
import DateJp from '@/components/Selector/DateJp/index.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { encryptByRSA } from '@/utils/encrypt/data'
import { useTableHeight } from '@/utils/hooks'
import { showConfirmModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { changeTableSort, replaceText } from '@/utils/util'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import { Save as saveAtenanoHistory } from '@/views/affect/AF/AWAF00701D/service'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'
import { reactive, ref, toRef, watch } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { SearchList } from '../service'
import { PersonRowVM } from '../type'

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
//受診者情報一覧
const tableList = ref<PersonRowVM[]>([])
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const createDefaultParams = () => {
  return {
    nendo: ss.get(GLOBAL_YEAR),
    atenano: '',
    personalno: '',
    name: '',
    kname: '',
    bymd: ''
  }
}
const searchParams = reactive(createDefaultParams())
//権限フラグ
const personalnoflg = route.meta.personalnoflg
//詳細条件フッター部説明文
const detailSearchNote = `年度、宛名番号、${
  personalnoflg ? '個人番号、' : ''
}氏名、カナ氏名、生年月日`

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
//クリア処理(遷移時)
onBeforeRouteUpdate(() => {
  searchParams.atenano = ''
  searchParams.personalno = ''
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) searchData()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//遷移処理(編集画面へ)
const forwardEdit = (val?: PersonRowVM) => {
  if (val) {
    router.push({
      name: route.name as string,
      query: {
        atenano: val.atenano,
        nendo: searchParams.nendo
      }
    })
    saveAtenanoHistory({
      kinoid: route.name as string,
      atenano: val.atenano
    })
  } else {
    tableList.value = []
    totalCount.value = 0
  }
}

//クリア
const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  tableList.value = []
  pageParams.pagenum = 1
  searchDrawerRef.value?.resetDrawer()
  totalCount.value = 0
}

//検索処理(宛名番号、個人番号以外の場合)
const searchData = () => {
  searchDrawerRef.value?.validateDrawer().then(async (result) => {
    loading.value = true
    SearchList({
      ...pageParams,
      ...searchParams,
      personalno: encryptByRSA(searchParams.personalno),
      syosailist: result
    })
      .then((res) => {
        if (res.totalpagecount < pageParams.pagenum) {
          pageParams.pagenum = 1
        }
        tableList.value = res.kekkalist
        totalCount.value = res.totalrowcount
        //検索結果1件の場合、詳細画面へ遷移
        if (res.totalrowcount === 1 && res.totalpagecount === 1) {
          forwardEdit(res.kekkalist[0])
        }
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
