vxe-column
<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログ情報管理(一覧画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :xxl="6">
            <th>ログ区分</th>
            <td>
              <ai-select
                v-model:value="searchParams.logkbn"
                :options="options1"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>処理結果</th>
            <td>
              <ai-select v-model:value="searchParams.status" :options="options2"></ai-select>
            </td>
          </a-col>
          <a-col :md="24" :xxl="12">
            <th style="width: 150px">処理時刻</th>
            <td>
              <RangeDateTime
                v-model:value1="searchParams.syoridttmf"
                v-model:value2="searchParams.syoridttmt"
              />
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>機能</th>
            <td>
              <ai-select
                v-model:value="searchParams.service"
                :options="options"
                @change="onChangeOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>処理</th>
            <td>
              <ai-select
                v-model:value="searchParams.method"
                :options="keyoptions"
                @change="onChangeKeyOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th style="width: 150px">操作者</th>
            <td>
              <ai-select v-model:value="searchParams.user" :options="options5"></ai-select>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :xl="8" :xxl="6">
            <th>宛名番号</th>
            <td>
              <AtenaNo v-model:value="searchParams.atenano" />
            </td>
          </a-col>
          <a-col v-if="personalnoflg" :md="8" :xxl="6">
            <th>個人番号</th>
            <td>
              <a-input
                v-model:value="searchParams.personalno"
                :maxlength="12"
                @blur="
                  searchParams.personalno = searchParams.personalno
                    ? searchParams.personalno.padStart(12, '0')
                    : ''
                "
              />
            </td>
          </a-col>
          <a-col v-if="personalnoflg" :md="8" :xxl="6">
            <th style="width: 150px">個人番号操作区分</th>
            <td>
              <a-checkbox v-model:checked="searchParams.pnokbn" class="ml-2" />
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1">
        <a-space>
          <a-button type="primary" @click="searchData">検索</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
          <a-button type="primary" :disabled="!csvoutflg" @click="csvVisivle = true"
            >CSV出力</a-button
          >
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
        class="text-end mb-2"
      />
      <vxe-table
        :height="tableHeight"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{ trigger: 'cell', remote: true }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        @cell-dblclick="({ row }) => goDetail(row)"
      >
        <vxe-column
          field="sessionseq"
          :params="{ order: 1 }"
          title="セッションシーケンス"
          min-width="110"
          sortable
        >
          <template #default="{ row }">
            <a @click="goDetail(row)">{{ row.sessionseq }}</a>
          </template>
        </vxe-column>
        <vxe-colgroup title="ログ区分" align="center">
          <vxe-column field="existflg1" title="通信" min-width="55" />
          <vxe-column field="existflg2" title="バッチ" min-width="70" />
          <vxe-column field="existflg3" title="連携" min-width="55" />
        </vxe-colgroup>
        <vxe-colgroup title="種類" align="center">
          <vxe-column field="existflg4" title="DB" min-width="55" />
          <vxe-column field="existflg5" title="項目値" min-width="70" />
          <vxe-column field="existflg6" title="宛名" min-width="55" />
        </vxe-colgroup>
        <vxe-column
          field="syoridttmf"
          :params="{ order: 2 }"
          title="処理日時（開始）"
          width="190"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="syoridttmt"
          :params="{ order: 3 }"
          title="処理日時（終了）"
          width="190"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="syoritime"
          :params="{ order: 4 }"
          title="処理時間"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="kinoid"
          :params="{ order: 5 }"
          title="機能ID"
          min-width="100"
          width="120"
          sortable
        ></vxe-column>
        <vxe-column
          field="servicenm"
          :params="{ order: 6 }"
          title="機能名"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="methodnm"
          :params="{ order: 7 }"
          title="処理名"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="usernm"
          :params="{ order: 8 }"
          title="操作者"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          v-if="personalnoflg"
          field="pnoflg"
          :params="{ order: 9 }"
          title="個人番号操作状況"
          min-width="90"
          sortable
        ></vxe-column>
        <vxe-column
          field="msgflg"
          :params="{ order: 10 }"
          title="メッセージ操作状況"
          min-width="100"
          sortable
        ></vxe-column>
        <vxe-column
          field="status"
          :params="{ order: 11 }"
          title="処理結果"
          min-width="85"
          sortable
        ></vxe-column>
      </vxe-table>
    </a-card>
    <CsvModal v-model:visible="csvVisivle" :search-params="searchParams" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, toRef, watch, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { changeTableSort } from '@/utils/util'
import { encryptByRSA } from '@/utils/encrypt/data'
import { useLinkOption, useTableHeight } from '@/utils/hooks'
import { InitList, SearchList } from '../service'
import { RowVM } from '../type'
import AtenaNo from '@/views/affect/AF/AWAF00701D/index.vue'
import RangeDateTime from '@/components/Selector/RangeDateTime/index.vue'
import CsvModal from './CsvModal.vue'
import { useSearch } from '@/utils/hooks'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tableList = ref<RowVM[]>([])
const searchParams = reactive(createDefaultParams())
function createDefaultParams() {
  return {
    logkbn: undefined,
    status: undefined,
    syoridttmf: undefined,
    syoridttmt: undefined,
    service: undefined,
    method: undefined,
    user: undefined,
    atenano: '',
    personalno: '',
    pnokbn: false
  }
}
const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: tableList,
  params: toRef(() => ({
    ...searchParams,
    personalno: encryptByRSA(searchParams.personalno)
  }))
})
//ドロップダウンリスト
const options1 = ref<DaSelectorModel[]>([]) //ログ区分
const options2 = ref<DaSelectorModel[]>([]) //処理結果
const options3 = ref<DaSelectorModel[]>([]) //機能
const options4 = ref<DaSelectorKeyModel[]>([]) //処理
const options5 = ref<DaSelectorModel[]>([]) //操作者
//個人番号権限フラグ
const personalnoflg = route.meta.personalnoflg
//CSV出力
const csvoutflg = ref(false)
const csvVisivle = ref(false)
//ドロップダウンリストの連動(機能=>処理)
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(options4, options3)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  const res = await InitList()
  options1.value = res.selectorlist1
  options2.value = res.selectorlist2
  options3.value = res.selectorlist3
  options4.value = res.selectorlist4
  options5.value = res.selectorlist5
  csvoutflg.value = res.csvoutflg
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

//クリア
function reset() {
  Object.assign(searchParams, createDefaultParams())
  clear()
}

//ジャンプ ページ
function goDetail({ sessionseq }) {
  router.push({
    name: route.name as string,
    query: { sessionseq }
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 90px;
}
</style>
