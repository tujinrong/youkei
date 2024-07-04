<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ユーザー管理(一覧画面：ユーザー)
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
            <th class="w-26">ユーザー</th>
            <td>
              <ai-select
                v-model:value="searchParams.user"
                :options="keyoptions"
                @change="onChangeKeyOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :sm="24" :md="12" :xl="8" :xxl="5">
            <th class="w-26">所属グループ</th>
            <td>
              <ai-select
                v-model:value="searchParams.syozoku"
                :options="options"
                @change="onChangeOpt"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-row class="flex-1">
          <a-col :md="12" :xl="8" :xxl="5">
            <a-space>
              <a-button type="primary" @click="goUserAdd">新規</a-button>
              <a-button type="primary" @click="handleSearch">検索</a-button>
              <a-button type="primary" @click="reset">クリア</a-button>
            </a-space>
          </a-col>
          <a-col :md="12" :xl="8" :xxl="5">
            <a-space>
              <a-button type="primary" @click="goGroupAdd">所属新規</a-button>
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
          show-less-itemsw
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
              field="userid"
              :params="{ order: 1 }"
              title="ユーザーID"
              sortable
              min-width="150"
            >
              <template #default="{ row }">
                <a @click="goDetail(row)">{{ row.userid }}</a>
              </template>
            </vxe-column>
            <vxe-column
              field="usernm"
              :params="{ order: 2 }"
              title="ユーザー名"
              sortable
              min-width="150"
            >
              <template #default="{ row }">
                <a @click="goDetail(row)">{{ row.usernm }}</a>
              </template>
            </vxe-column>
            <vxe-column
              field="syozokunm"
              :params="{ order: 3 }"
              title="所属グループ"
              sortable
              min-width="150"
            ></vxe-column>
            <vxe-column
              field="yukoymdf"
              :params="{ order: 4 }"
              title="有効年月日（開始）"
              sortable
              min-width="160"
            ></vxe-column>
            <vxe-column
              field="yukoymdt"
              :params="{ order: 5 }"
              title="有効年月日（終了）"
              sortable
              min-width="160"
            ></vxe-column>
            <vxe-column
              field="status"
              :params="{ order: 6 }"
              title="状態"
              min-width="150"
            ></vxe-column>
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
import { SearchListRequest, UserRowVM } from '../type'
import { SearchList } from '../service'
import SetModal from '@/views/affect/AF/AWAF00902D/index.vue'
import { Enumロール区分 } from '#/Enums'
import emitter from '@/utils/event-bus'
import { useLinkOption, useSearch } from '@/utils/hooks'

const props = defineProps<{
  options1: DaSelectorKeyModel[]
  options2: DaSelectorModel[]
}>()
const emit = defineEmits(['goGroup', 'initOption'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()

const createDefaultParams = (): Omit<SearchListRequest, keyof CmSearchRequestBase> => ({
  user: undefined,
  syozoku: undefined,
  rolekbn: Enumロール区分.ユーザー
})
const searchParams = reactive(createDefaultParams())

const dataList = ref<UserRowVM[]>([])
const loginSetVisible = ref(false)

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: dataList,
  params: toRef(() => searchParams),
  listname: 'kekkalist1'
})

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  emitter.once('refreshPermissionList', () => {
    emit('initOption')
    handleSearch(false)
  })
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => getHeight(275))

//ドロップダウンリスト連動処理
const userOptions = computed(() => props.options1)
const syozokuOptions = computed(() => props.options2)
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(
  userOptions,
  syozokuOptions
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function handleSearch(enterDetailPage = true) {
  const res = await searchData()
  //検索結果1件の場合、詳細画面へ遷移
  if (enterDetailPage && res.totalrowcount === 1 && res.totalpagecount === 1) {
    goDetail(res.kekkalist1[0])
    dataList.value = []
  }
}

//画面遷移
const goDetail = (record?: UserRowVM) => {
  router.push({
    name: route.name as string,
    query: {
      userid: record?.userid,
      syozokunm: record?.syozokunm,
      syozokucd: record?.syozokucd
    }
  })
}
//詳細画面(新規モード：ユーザー)へ遷移
const goUserAdd = () => {
  router.push({ name: route.name as string, query: { userid: '-1' } })
}
//詳細画面(新規モード：所属)へ遷移
const goGroupAdd = () => {
  emit('goGroup')
  router.push({ name: route.name as string, query: { syozoku: '-1' } })
}

function reset() {
  Object.assign(searchParams, createDefaultParams())
  clear()
}
</script>
