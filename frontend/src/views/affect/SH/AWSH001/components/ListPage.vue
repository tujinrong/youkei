vxe-column
<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ロジック共通仕様処理(検診)一覧画面
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
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
                :search-request="Search"
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
                :search-request="Search"
                @finish="forwardEdit"
                @clear="clearflg = true"
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
        <vxe-column field="status" title="状態" width="60" :resizable="false"></vxe-column>
        <vxe-column
          field="atenano"
          :params="{ order: 1 }"
          title="宛名番号"
          width="140"
          min-width="90"
          sortable
        >
          <template #default="{ row }: { row: KsRowVM }">
            <a @click="forwardEdit(row)">{{ row.atenano }}</a>
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
          <template #default="{ row }: { row: KsRowVM }">
            <a @click="forwardEdit(row)">{{ row.name }}</a>
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
          field="jissiymd1"
          :params="{ order: 9 }"
          title="受診年月日"
          width="150"
          min-width="110"
          sortable
          formatter="jpDate"
        ></vxe-column>
        <vxe-column
          v-if="showflg1"
          field="jissiymd2"
          :params="{ order: 10 }"
          title="精密検査受診日"
          width="150"
          min-width="140"
          sortable
          formatter="jpDate"
        ></vxe-column>
        <vxe-column
          field="keikoku"
          :params="{ order: 11 }"
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
import { EnumKensinStsType, EnumRegex, EnumServiceResult } from '#/Enums'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { A000005 } from '@/constants/msg'
import { GLOBAL_YEAR, MAX_YEAR } from '@/constants/mutation-types'
import { ProgramStore } from '@/store'
import { encryptByRSA } from '@/utils/encrypt/data'
import emitter from '@/utils/event-bus'
import { useTableHeight } from '@/utils/hooks'
import { showConfirmModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { changeTableSort, replaceText } from '@/utils/util'
import { Save as saveAtenanoHistory } from '@/views/affect/AF/AWAF00701D/service'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'
import { message } from 'ant-design-vue'
import { nextTick, onMounted, reactive, ref, toRef, watch } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { InitList, Search } from '../service'
import { KsRowVM } from '../type'

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
const tableList = ref<KsRowVM[]>([])
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
const createFlg = route.meta.addflg
// 表示フラグ(精密)
const showflg1 = ref(true)
//クリアフラグ(個人番号)：詳細画面から一覧画面へ戻す時
let clearflg = false
//詳細条件フッター部説明文
const detailSearchNote = `年度、宛名番号、${
  personalnoflg ? '個人番号、' : ''
}氏名、カナ氏名、生年月日`

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  nextTick(() => {
    InitList({ nendo: searchParams.nendo }).then((res) => {
      showflg1.value = res.showflg1
    })
    //状態変更(明細情報)
    const kinoid = ProgramStore.id
    emitter.on('changeKensinStatus', (obj: any) => {
      const { curid, processedObj } = obj
      if (curid !== kinoid) return
      for (const sts of processedObj.statuslist ?? []) {
        const findItem = tableList.value.find(
          (el) => el.kensinkaisu === sts.kensinkaisubefore && el.atenano === processedObj.atenano
        )
        if (findItem) {
          findItem.kensinkaisu = sts.kensinkaisuafter
          findItem.status = EnumKensinStsType[sts.statuskbn]
        }
      }
    })
  })
})
//クリア処理(遷移時)
onBeforeRouteUpdate(() => {
  searchParams.atenano = ''
  searchParams.personalno = ''

  if (clearflg) {
    reset()
    clearflg = false
  }
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
const forwardEdit = (val: KsRowVM) => {
  if (!createFlg && !val.jissiymd1 && !val.jissiymd2) {
    message.warn(A000005.Msg)
    return
  }

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
const searchData = (queryflg = false) => {
  searchDrawerRef.value?.validateDrawer().then(async (result) => {
    loading.value = true
    Search(
      {
        ...pageParams,
        ...searchParams,
        personalno: encryptByRSA(searchParams.personalno),
        queryflg,
        syosailist: result
      }
      // () => searchData(true)
    )
      .then((res) => {
        if (res.totalpagecount < pageParams.pagenum) {
          pageParams.pagenum = 1
        }
        tableList.value = res.kekkalist
        totalCount.value = res.totalrowcount
        if (res.transflg) forwardEdit(res.kekkalist[0])
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
