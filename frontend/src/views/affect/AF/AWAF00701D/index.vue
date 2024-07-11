<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 宛名検索履歴
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-input-search
      ref="inputSearchRef"
      v-model:value="curVal"
      :disabled="disabled"
      :maxlength="atenanoLength"
      style="width: 190px"
      @change="(e) => (curVal = replaceText(e.target.value, EnumRegex.半角数字))"
      @focus="$emit('focus')"
      @blur="$emit('blur')"
      @search="searchByEvent"
    >
      <template #enterButton>
        <a-button :disabled="disabled" class="px-10px"> <history-outlined /></a-button>
      </template>
    </a-input-search>
    <a-modal v-model:visible="visible" title="宛名検索履歴" width="800px" centered destroy-on-close>
      <div>
        <div class="m-b-1 flex justify-end">
          <a-pagination
            v-model:current="pageParams.pagenum"
            v-model:page-size="pageParams.pagesize"
            :total="totalCount"
            :page-size-options="$pagesizes"
            show-less-items
            show-size-changer
          />
        </div>
        <vxe-table
          ref="xTableRef"
          height="500"
          :loading="loading"
          :column-config="{ resizable: true }"
          :row-config="{ keyField: 'atenano', isCurrent: true, isHover: true }"
          :data="tableData"
          :sort-config="{
            trigger: 'cell',
            remote: true
          }"
          :empty-render="{ name: 'NotData' }"
          @current-change="clickRow"
          @cell-dblclick="onDbclickCell"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        >
          <vxe-column
            field="atenano"
            :params="{ order: 1 }"
            title="宛名番号"
            sortable
            min-width="100"
          >
            <template #default="{ row }">
              <a @click="onClickLinks(row)">{{ row.atenano }}</a>
            </template>
          </vxe-column>
          <vxe-column field="name" :params="{ order: 2 }" title="氏名" sortable min-width="70">
            <template #default="{ row }">
              <a @click="onClickLinks(row)">{{ row.name }}</a>
            </template>
          </vxe-column>
          <vxe-column
            field="kname"
            :params="{ order: 3 }"
            title="カナ氏名"
            sortable
            min-width="100"
          >
          </vxe-column>
          <vxe-column
            field="bymd"
            :params="{ order: 4 }"
            title="生年月日"
            sortable
            min-width="100"
          />
          <vxe-column field="sex" :params="{ order: 5 }" title="性別" sortable min-width="70">
            <template #default="{ row }">
              <span :style="{ color: sexColorMap[row.sex] }">{{ row.sex }}</span>
            </template>
          </vxe-column>
        </vxe-table>
      </div>
      <template #footer>
        <div class="float-left">
          <a-button key="back" type="primary" :disabled="!selectedRow" @click="selectItem"
            >選択</a-button
          >
        </div>
        <a-button key="submit" type="primary" @click="closeModal">閉じる</a-button>
      </template>
    </a-modal>
  </div>
</template>

<script lang="ts" setup>
import { ref, computed, toRef, onMounted, nextTick } from 'vue'
import { HistoryOutlined } from '@ant-design/icons-vue'
import { Save, Search } from './service'
import { useRoute } from 'vue-router'
import { SearchVM } from './type'
import { changeTableSort, replaceText } from '@/utils/util'
import { sexColorMap } from '@/constants/constant'
import { ss } from '@/utils/storage'
import { ATENANO_LEN } from '@/constants/mutation-types'
import { useEventListener } from '@vueuse/core'
import { VxeTableInstance } from 'vxe-table'
import { EnumRegex } from '#/Enums'
import { useSearch } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value?: string
  disabled?: boolean
}>()
interface Emits {
  (e: 'update:value', value?: string): void
  (e: 'search', value: Partial<SearchVM>): void
  (e: 'blur'): void
  (e: 'focus'): void
}
const emit = defineEmits<Emits>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const visible = ref(false)
//ローディング

//ページャー
//ビューモデル
const xTableRef = ref<VxeTableInstance>()
const inputSearchRef = ref()
const tableData = ref<SearchVM[]>([])
const selectedRow = ref<Partial<SearchVM> | null>(null)
const atenanoLength = ss.get(ATENANO_LEN)

const { loading, pageParams, totalCount, searchData } = useSearch({
  service: Search,
  source: tableData,
  params: null
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const inputDom = inputSearchRef.value.$el.querySelector('input')
  useEventListener(inputDom, 'blur', (e: FocusEvent) => {
    if (e.sourceCapabilities) {
      searchByEnterAndBlur()
    }
  })
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    return props.value
  },
  set(val) {
    emit('update:value', val)
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//保存処理(選択)
function selectItem() {
  visible.value = false
  if (selectedRow.value?.atenano) {
    curVal.value = selectedRow.value.atenano
    emit('search', selectedRow.value)
    Save({
      kinoid: route.name as string,
      atenano: selectedRow.value.atenano
    })
  }
}
//入力検索処理
async function searchByEvent(_v, e) {
  if (e.type === 'keydown' && ['Enter', 'NumpadEnter'].includes(e.code)) {
    searchByEnterAndBlur()
  } else if (e.type === 'click') {
    selectedRow.value = null
    pageParams.pagenum = 1
    pageParams.pagesize = 100
    pageParams.orderby = 0
    visible.value = true
    xTableRef.value?.clearSort()
    searchData()
  }
}
async function searchByEnterAndBlur() {
  if (!curVal.value) return
  curVal.value = curVal.value.padStart(atenanoLength, '0')
  nextTick(() => {
    selectedRow.value = { atenano: curVal.value }
    selectItem()
  })
}

//キー項目選択
function onClickLinks(value) {
  selectedRow.value = value
  selectItem()
}
//行選択(行をクリック)
function clickRow({ row }) {
  selectedRow.value = row
}
//行をダブルクリック
function onDbclickCell({ row }) {
  selectedRow.value = row
  selectItem()
}

//閉じるボタン(×を含む)
function closeModal() {
  visible.value = false
}
</script>
