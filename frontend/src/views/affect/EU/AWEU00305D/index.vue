<template>
  <a-modal
    :visible="props.visible"
    title="出力履歴"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    width="1200px"
  >
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
      height="500"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :row-config="{ isHover: true, isCurrent: true }"
      :data="resumeList"
      :sort-config="{ trigger: 'cell', remote: true }"
      :empty-render="{ name: 'NotData' }"
      @cell-click="({ row }) => (currentRow = row)"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
    >
      <vxe-column
        field="regdttm"
        title="登録日時"
        formatter="jpTimeSimple"
        :params="{ order: 1 }"
        width="150"
        sortable
      >
      </vxe-column>
      <vxe-column field="regusernm" title="登録者" :params="{ order: 2 }" min-width="120" sortable>
      </vxe-column>
      <vxe-column
        field="jyotai"
        title="実行状態"
        min-width="90"
        :params="{ order: 3 }"
        sortable
      ></vxe-column>
      <vxe-column
        field="syoridttmf"
        title="実行日時"
        formatter="jpTimeSimple"
        :params="{ order: 4 }"
        width="150"
        sortable
      ></vxe-column>
      <vxe-column
        field="outputkbn"
        title="出力方式"
        :params="{ order: 5 }"
        min-width="60"
        ortable
      ></vxe-column>
      <vxe-column
        field="num"
        title="総件数"
        min-width="50"
        :params="{ order: 6 }"
        sortable
      ></vxe-column>
      <vxe-column
        field="jyoken"
        title="検索条件"
        :params="{ order: 7 }"
        min-width="130"
        sortable
      ></vxe-column>
      <vxe-column
        field="memo"
        title="検索条件メモ"
        :params="{ order: 8 }"
        min-width="130"
        sortable
      ></vxe-column>
      <vxe-column
        field="rirekiseq"
        title="結果ファイル"
        :params="{ order: 9 }"
        min-width="100"
        sortable
        :resizable="false"
      >
        <template #default="{ row }">
          <span
            class="underline cursor-pointer c-blue-7"
            @click.stop="downloadFile(row.rirekiseq)"
            >{{ row.fileflg ? '結果フアイル' : '' }}</span
          >
        </template>
      </vxe-column>
    </vxe-table>
    <template #footer>
      <a-button
        style="float: left"
        type="primary"
        :disabled="!props.isSearch || !currentRow"
        @click="handleSetting"
        >条件設定
      </a-button>
      <a-button
        style="float: left"
        type="primary"
        :disabled="!currentRow"
        @click="() => (detailVisible = true)"
        >条件詳細
      </a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>

  <DetailModal v-model:visible="detailVisible" v-bind="{ currentRow }" />
</template>

<script setup lang="ts">
import { reactive, ref, watch } from 'vue'
import { Download, Search } from './service'
import { KensakuJyokenInitVM } from '../AWEU00301G/type'
import { RirekiVM } from './type'
import { Enumコントロール, Enum帳票様式 } from '#/Enums'
import DetailModal from './components/DetailModal/index.vue'
import { showConfirmModal } from '@/utils/modal'
import { DOWNLOAD_CONFIRM, DOWNLOAD_OK_INFO } from '@/constants/msg'
import { message } from 'ant-design-vue'
import { changeTableSort } from '@/utils/util'
import { toRef } from 'vue'
import { GlobalStore } from '@/store'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  rptid: string // 帳票ID
  yosikiid: string // 様式ID
  kensakujyokenlist1: KensakuJyokenInitVM[]
  isSearch: boolean
}>()
const emit = defineEmits(['update:visible'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const detailVisible = ref(false)
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const resumeList = ref<RirekiVM[]>([])
const currentRow = ref<RirekiVM | null>(null)
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      getHistoryList()
    }
  }
)

watch(pageParams, () => {
  if (resumeList.value.length > 0 || totalCount.value > 0) getHistoryList()
})
//--------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------

//出力履歴検索処理
const getHistoryList = async () => {
  try {
    const res = await Search({ ...props, ...pageParams })
    resumeList.value = res.kekkalist
    totalCount.value = res.totalrowcount
  } catch (error) {}
}

const handleSetting = () => {
  if (currentRow.value) {
    currentRow.value.jyokenlist.forEach((item) => {
      const finder = props.kensakujyokenlist1.find((el) => el.jyokenlabel === item.jyokenlabel)
      if (finder) {
        if (finder.controlkbn === Enumコントロール.複数選択) {
          finder.value = item.value?.split(',') ?? []
        } else if (finder.controlkbn === Enumコントロール.論理値 && item.value) {
          finder.value = JSON.parse(item.value.toLocaleLowerCase())
        } else {
          finder.value = item.value
        }
      }
    })
    emit('update:visible', false)
  }
}

const closeModal = () => {
  emit('update:visible', false)
  currentRow.value = null
}

//ダウンロード処理
const downloadFile = (rirekiseq: number) => {
  showConfirmModal({
    content: DOWNLOAD_CONFIRM,
    onOk: async () => {
      try {
        await Download({ rirekiseq })
        message.success(DOWNLOAD_OK_INFO.Msg)
      } catch (error) {}
    }
  })
}
</script>
