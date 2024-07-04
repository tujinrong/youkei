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
      <div :style="{ height: tableHeight }">
        <vxe-table
          class="mt-2"
          height="100%"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="tableList"
          :sort-config="{ trigger: 'cell', remote: true }"
          :empty-render="{ name: 'NotData' }"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
          @cell-dblclick="({ row }) => forwardEdit(row)"
        >
          <vxe-column field="datasts" title="状態" width="80" :resizable="false"></vxe-column>
          <vxe-column
            field="atenano"
            :params="{ order: 1 }"
            title="宛名番号"
            width="203"
            min-width="90"
            sortable
          >
            <template #default="{ row }: { row: NinsanpuListVM }">
              <a @click="forwardEdit(row)">{{ row.atenano }}</a>
            </template>
          </vxe-column>
          <vxe-column
            field="name"
            :params="{ order: 2 }"
            title="氏名"
            width="150"
            min-width="70"
            sortable
            class-name="mincho"
            header-class-name="mincho"
          >
            <template #default="{ row }: { row: NinsanpuListVM }">
              <a @click="forwardEdit(row)">{{ row.name }}</a>
            </template>
          </vxe-column>
          <vxe-column
            field="kname"
            :params="{ order: 3 }"
            title="カナ氏名"
            width="225"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="sex"
            :params="{ order: 4 }"
            title="性別"
            width="80"
            min-width="60"
            sortable
          ></vxe-column>
          <vxe-column
            field="bymd"
            :params="{ order: 5 }"
            title="生年月日"
            width="272"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="gyoseiku"
            :params="{ order: 6 }"
            title="行政区"
            width="110"
            min-width="80"
            sortable
          ></vxe-column>
          <vxe-column
            field="juminkbn"
            :params="{ order: 7 }"
            title="住民区分"
            width="110"
            min-width="90"
            sortable
          ></vxe-column>
          <vxe-column
            field="syosai"
            title="出　生　時|新生児聴覚|健診受診歴|3～4月健診|1歳6月健診|3歳児 健診|精密の健診|未受診者奨"
            min-width="90"
          ></vxe-column>
          <vxe-column
            field="keikoku"
            :params="{ order: 9 }"
            title="警告内容"
            width="220"
            min-width="90"
            sortable
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>

    <DetailSearchDrawer ref="searchDrawerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, toRef, watch, onMounted, computed } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { message } from 'ant-design-vue'
import { A000005, E004006 } from '@/constants/msg'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import { encryptByRSA } from '@/utils/encrypt/data'
import { changeTableSort, replaceText } from '@/utils/util'
import { Save as saveAtenanoHistory } from '@/views/affect/AF/AWAF00701D/service'
import { showConfirmModal } from '@/utils/modal'
import { SearchList } from '../service'
import DetailSearchDrawer from '@/views/affect/AF/AWAF00703D/index.vue'
import { EnumServiceResult, EnumKensinStsType, EnumRegex } from '#/Enums'
import { getHeight } from '@/utils/height'
import { NinsanpuListVM } from '../type'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import emitter from '@/utils/event-bus'

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
const tableList = ref<NinsanpuListVM[]>([])
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
const detailSearchNote = `宛名番号、${personalnoflg ? '個人番号、' : ''}氏名、カナ氏名、生年月日`

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const tableHeight = computed(() => getHeight(235))
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) searchData()
})

onMounted(() => {
  emitter.on('changeStatus', (atenano: any) => {
    const findItem = tableList.value.find((el) => el.atenano === atenano)
    if (findItem) {
      findItem.datasts = EnumKensinStsType[2]
    }
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

//検索処理(宛名番号、個人番号以外の場合)
async function searchData() {
  searchDrawerRef.value?.validateDrawer().then(async (result) => {
    loading.value = true
    SearchList({
      ...pageParams,
      ...searchParams,
      personalno: encryptByRSA(searchParams.personalno),
      syosailist: result
    })
      .then((res) => {
        loading.value = false
        if (res.totalpagecount < pageParams.pagenum) {
          pageParams.pagenum = 1
        }
        tableList.value = res.kekkalist
        totalCount.value = res.totalrowcount
        // if (res.transflg) forwardEdit(res.kekkalist[0])
      })
      .catch((err) => {
        loading.value = false
      })
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

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//遷移処理(編集画面へ)
const forwardEdit = (val: NinsanpuListVM) => {
  if (!createFlg) {
    message.warn(A000005.Msg)
    return
  }

  router.push({
    name: route.name as string,
    query: {
      atenano: val.atenano,
      patternno: route.query.patternno as string
    }
  })

  saveAtenanoHistory({
    kinoid: route.name as string,
    atenano: val.atenano
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 100px;
}

:deep(.vxe-table--header) {
  .vxe-cell {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
  }
}
</style>
