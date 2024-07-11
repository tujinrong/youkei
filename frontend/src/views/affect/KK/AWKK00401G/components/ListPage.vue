<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: フォロー管理(管理画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.28
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
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
                :search-request="SearchFollowList"
                @finish="forwardList2"
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
                :search-request="SearchFollowList"
                @finish="forwardList2"
              />
            </td>
          </a-col>
          <a-col :md="12" :lg="12" :xl="8" :xxl="6">
            <th>氏名</th>
            <td class="mincho">
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
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button
            type="primary"
            :disabled="atenanoRef?.focused || personalnoRef?.focused"
            @click="searchData"
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
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="my-2">
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :page-size-options="$pagesizes"
        :total="totalCount"
        show-less-items
        show-size-changer
        class="text-end mb-2"
      />
      <vxe-table
        :height="tableHeight"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :empty-render="{ name: 'NotData' }"
        :sort-config="{ trigger: 'cell', remote: true }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        @cell-dblclick="({ row }) => forwardList2(row)"
      >
        <vxe-column
          field="atenano"
          title="宛名番号"
          width="160"
          min-width="100"
          :params="{ order: 1 }"
          sortable
        >
          <template #default="{ row }">
            <a @click="forwardList2(row)">{{ row.atenano }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="name"
          title="氏名"
          width="160"
          min-width="60"
          class-name="mincho"
          header-class-name="mincho"
          :params="{ order: 2 }"
          sortable
        >
          <template #default="{ row }">
            <a @click="forwardList2(row)">{{ row.name }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="kname"
          title="カナ氏名"
          width="160"
          min-width="100"
          :params="{ order: 3 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="sex"
          title="性別"
          width="80"
          min-width="60"
          :params="{ order: 4 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="juminkbn"
          title="住民区分"
          width="160"
          min-width="100"
          :params="{ order: 5 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="bymd"
          title="生年月日"
          width="160"
          min-width="100"
          :params="{ order: 6 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="adrs"
          title="住所"
          min-width="60"
          :params="{ order: 7 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="followyoteiymd"
          title="フォロー予定日"
          width="180"
          min-width="100"
          :params="{ order: 8 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="followjissiymd"
          title="フォロー実施日"
          width="180"
          min-width="100"
          :params="{ order: 9 }"
          sortable
        ></vxe-column>
        <vxe-column
          field="keikoku"
          title="警告内容"
          width="180"
          min-width="100"
          :params="{ order: 10 }"
          sortable
        ></vxe-column>
      </vxe-table>
    </a-card>
    <DetailSearchDrawer ref="searchDrawerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, watch, toRef } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { SearchFollowList } from '../service'
import { changeTableSort, replaceText } from '@/utils/util'
import { EnumRegex } from '#/Enums'
import { useTableHeight } from '@/utils/hooks'
import { RowFollowVM } from '../type'
import DateJp from '@/components/Selector/DateJp/index.vue'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(false)
const searchDrawerRef = ref<InstanceType<typeof DetailSearchDrawer> | null>(null)
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const personalnoRef = ref<InstanceType<typeof PersonalnoSearch> | null>(null)

const tableList = ref<RowFollowVM[]>([])
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const totalCount = ref(0)

const createDefaultParams = () => {
  return {
    atenano: '',
    name: '',
    kname: '',
    bymd: '',
    personalno: ''
  }
}
const searchParams = reactive(createDefaultParams())

//個人番号権限フラグ
const personalnoflg = route.meta.personalnoflg
//詳細条件フッター部説明文
const detailSearchNote = `宛名番号、${personalnoflg ? '個人番号、' : ''}氏名、カナ氏名、生年月日`

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
//クリア処理(遷移時)
onBeforeRouteUpdate(() => {
  searchParams.atenano = ''
  searchParams.personalno = ''
})

//--------------------------------------------------------------------------
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

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
const searchData = async () => {
  searchDrawerRef.value?.validateDrawer().then(async (result) => {
    loading.value = true
    try {
      const res = await SearchFollowList({
        ...pageParams,
        ...searchParams,
        syosailist: result
      })
      totalCount.value = res.totalrowcount
      tableList.value = res.kekkalist
      //検索結果1件の場合、詳細画面へ遷移
      if (res.totalrowcount === 1 && res.totalpagecount === 1) {
        forwardList2(res.kekkalist[0])
      }
    } catch (error) {}
    loading.value = false
  })
}

function forwardList2(val) {
  router.push({
    name: route.name as string,
    query: {
      atenano: val.atenano
    }
  })
}
//クリア
function reset() {
  Object.assign(searchParams, createDefaultParams())
  tableList.value = []
  pageParams.pagenum = 1
  totalCount.value = 0
  searchDrawerRef.value?.resetDrawer()
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 90px;
}
</style>
