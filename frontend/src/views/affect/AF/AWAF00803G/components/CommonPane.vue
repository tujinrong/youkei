vxe-column
<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログ情報管理(詳細画面：共通タブ)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="">
    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :total="totalCount"
      :page-size-options="$pagesizes"
      show-less-items
      show-size-changer
      class="mb-2 text-end"
    />
    <vxe-table
      :height="tableHeight"
      :loading="loading"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList"
      :sort-config="{
        trigger: 'cell',
        remote: true
      }"
      :empty-render="{ name: 'NotData' }"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      @cell-click="onClickCell"
    >
      <vxe-column
        v-for="(item, index) in column"
        :key="item.field"
        v-bind="item"
        :params="{ order: index + 1 }"
        sortable
      >
        <template #default="{ row }">
          <span
            v-if="item.field === 'filenm'"
            class="underline cursor-pointer c-blue-7"
            @click.stop="downloadFile(row.gaibulogseq)"
            >{{ row.filenm }}</span
          >
          <span v-else>{{ row[item.field] }}</span>
        </template>
      </vxe-column>
    </vxe-table>
    <a-modal
      v-model:visible="modalVisible"
      width="800px"
      :title="modalTitle"
      destroy-on-close
      centered
    >
      <div class="whitespace-pre-wrap h-[50vh] overflow-y-auto">
        {{ isJSONString(modalContent) }}
      </div>
      <template #footer>
        <a-button type="primary" @click="() => (modalVisible = false)">閉じる</a-button>
      </template>
    </a-modal>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, toRef, onMounted, watch, computed } from 'vue'
import { useRoute } from 'vue-router'
import { message } from 'ant-design-vue'
import { VxeColumnProps } from 'vxe-table'
import { changeTableSort } from '@/utils/util'
import { showConfirmModal } from '@/utils/modal'
import { DOWNLOAD_CONFIRM, DOWNLOAD_OK_INFO } from '@/constants/msg'
import {
  SearchBatchDetail,
  SearchTusinDetail,
  SearchGaibuDetail,
  SearchDBDetail,
  SearchColumnDetail,
  SearchAtenaDetail
} from '../service'
import { SearchCommonRequest } from '../type'
import { EnumLogTab } from '../constant'
import { Download } from '@/views/affect/AF/AWAF00301G/service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
type RequestFunc = (val: SearchCommonRequest) => Promise<any>
const props = defineProps<{
  outHeight: number
  type: EnumLogTab
  column: VxeColumnProps
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
//ページ データ
const tableList = ref<any[]>([])
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})

let SearchRequest: RequestFunc
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  switch (props.type) {
    case EnumLogTab.通信:
      SearchRequest = SearchTusinDetail
      break
    case EnumLogTab.バッチ:
      SearchRequest = SearchBatchDetail
      break
    case EnumLogTab.連携:
      SearchRequest = SearchGaibuDetail
      break
    case EnumLogTab.DB:
      SearchRequest = SearchDBDetail
      break
    case EnumLogTab.項目値:
      SearchRequest = SearchColumnDetail
      break
    case EnumLogTab.宛名:
      SearchRequest = SearchAtenaDetail
      break
    default:
      SearchRequest = () => Promise.reject()
      break
  }
  searchData(SearchRequest)
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) searchData(SearchRequest)
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => props.outHeight - 110)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData(func: RequestFunc) {
  loading.value = true
  try {
    const res = await func({
      ...pageParams,
      sessionseq: Number(route.query.sessionseq)
    })
    tableList.value = res.kekkalist
    totalCount.value = res.totalrowcount
  } catch (error) {}
  loading.value = false
}

//ダウンロード処理
const downloadFile = (gaibulogseq: number) => {
  showConfirmModal({
    content: DOWNLOAD_CONFIRM,
    onOk: async () => {
      await Download({ gaibulogseq })
      message.success(DOWNLOAD_OK_INFO.Msg)
    }
  })
}

//--------------------------------------------------------------------------------------------------
//詳細ダイアログボックス(リクエスト、レスポンス、SQL、API連携データ)
const modalVisible = ref(false)
const modalTitle = ref('')
const modalContent = ref('')
function onClickCell({ row, column }) {
  if (['request', 'response', 'sql', 'apidata'].includes(column.field) && row[column.field]) {
    modalTitle.value = column.title
    modalContent.value = row[column.field]
    modalVisible.value = true
  }
}
function isJSONString(str: string) {
  try {
    const result = JSON.parse(str)
    return JSON.stringify(result, null, 2)
  } catch (error) {
    return str
  }
}
//--------------------------------------------------------------------------------------------------
</script>

<style lang="less" scoped></style>
