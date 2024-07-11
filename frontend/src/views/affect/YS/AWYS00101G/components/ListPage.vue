<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 予防接種情報管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.05.21
 * 作成者　　: 翔
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
                :value="searchParams.bymd"
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
        :sort-config="{
          trigger: 'cell',
          remote: true
        }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      >
        <vxe-column field="datasts" title="状態" width="60" :resizable="false"></vxe-column>
        <vxe-column
          field="atenano"
          title="宛名番号"
          sortable
          width="140"
          min-width="100"
          :params="{ order: 1 }"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row)">{{ row.atenano }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="name"
          title="氏名"
          sortable
          width="120"
          min-width="70"
          class-name="mincho"
          header-class-name="mincho"
          :params="{ order: 2 }"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row)">{{ row.name }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="kname"
          title="カナ氏名"
          sortable
          width="120"
          min-width="100"
          :params="{ order: 3 }"
        ></vxe-column>
        <vxe-column
          field="sex"
          title="性別"
          sortable
          width="80"
          min-width="60"
          :params="{ order: 4 }"
        ></vxe-column>
        <vxe-column
          field="bymd"
          title="生年月日"
          sortable
          width="150"
          min-width="100"
          :params="{ order: 5 }"
        ></vxe-column>
        <vxe-column
          field="adrs"
          sortable
          title="住所"
          min-width="60"
          :params="{ order: 6 }"
        ></vxe-column>
        <vxe-column
          field="gyoseiku"
          title="行政区"
          sortable
          width="150"
          min-width="100"
          :params="{ order: 7 }"
        ></vxe-column>
        <vxe-column
          field="juminkbn"
          title="住民区分"
          sortable
          width="110"
          min-width="90"
          :params="{ order: 8 }"
        ></vxe-column>
        <vxe-column
          field="keikoku"
          title="警告内容"
          sortable
          :params="{ order: 9 }"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
    <DetailSearchDrawer ref="searchDrawerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, watch, toRef } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { SearchList } from '../service'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'
import { JyuminListVM } from '../type'
import { changeTableSort, replaceText } from '@/utils/util'
import { EnumRegex } from '#/Enums'
import { useTableHeight } from '@/utils/hooks'
import { Save as saveAtenanoHistory } from '@/views/affect/AF/AWAF00701D/service'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(false)
const searchDrawerRef = ref<InstanceType<typeof DetailSearchDrawer> | null>(null)
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const personalnoRef = ref<InstanceType<typeof PersonalnoSearch> | null>(null)

const tableList = ref<JyuminListVM[]>([])
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
const detailSearchNote = `宛名番号、氏名、カナ氏名、生年月日、${personalnoflg ? '個人番号、' : ''}`

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
//遷移処理(編集画面へ)
const forwardEdit = (val: JyuminListVM) => {
  router.push({
    name: route.name as string,
    query: {
      atenano: val.atenano
    }
  })

  saveAtenanoHistory({
    kinoid: route.name as string,
    atenano: val.atenano
  })
}

const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  tableList.value = []
  pageParams.pagenum = 1
  totalCount.value = 0
  searchDrawerRef.value?.resetDrawer()
}

const searchData = async () => {
  searchDrawerRef.value?.validateDrawer().then(async (result) => {
    loading.value = true
    try {
      const res = await SearchList({
        ...pageParams,
        ...searchParams,
        syosailist: result
      })
      if (res.totalpagecount < pageParams.pagenum) {
        pageParams.pagenum = 1
      }
      tableList.value = res.kekkalist
      totalCount.value = res.totalrowcount
      if (res.transflg) forwardEdit(res.kekkalist[0])
    } catch (error) {}
    loading.value = false
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 90px;
}
</style>
