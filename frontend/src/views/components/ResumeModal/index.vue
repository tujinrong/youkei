<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 履歷照会
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="1300px"
    :title="title"
    destroy-on-close
    :mask-closable="false"
    centered
    @ok="onOk"
  >
    <div class="self_adaption_table mb-3">
      <a-row>
        <a-col span="6">
          <th style="width: 100px">宛名番号</th>
          <TD>{{ props.atenano || route.query.atenano }}</TD>
        </a-col>
      </a-row>
    </div>
    <vxe-table
      ref="xTableRef"
      height="500"
      :loading="loading"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableData"
      :sort-config="{ trigger: 'cell' }"
      :empty-render="{ name: 'NotData' }"
      @current-change="clickRow"
      @cell-dblclick="onDbclickCell"
    >
      <vxe-column
        v-for="col in columns"
        :key="col.field"
        v-bind="col"
        sortable
        :sort-type="sortType(col.field)"
      />
    </vxe-table>
    <template #footer>
      <div style="float: left">
        <a-button type="primary" :disabled="!selectedRow || disabledSelect" @click="onOk"
          >選択</a-button
        >
      </div>
      <a-button type="primary" @click="modalVisible = false">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, watch, ref } from 'vue'
import { useRoute } from 'vue-router'
import { Search } from './service'
import { decryptByRSA } from '@/utils/encrypt/data'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  title: string
  visible: boolean
  columns: { title: string; field: string; width: string }[]
  service: string
  atenano?: string
  disabledSelect?: boolean
}>()
const emit = defineEmits(['update:visible', 'select'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const privkey = ref('')
const tableData = ref<any[]>([])
const selectedRow = ref<any>(null)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (val) => {
    selectedRow.value = null
    tableData.value = []
    if (val) searchData()
  }
)

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const searchData = async () => {
  loading.value = true
  const res = await Search(props.service, {
    atenano: props.atenano || (route.query.atenano as string)
  })
  if (res.rsaprivatekey) privkey.value = res.rsaprivatekey
  tableData.value = res.kekkalist.map((item) => {
    return {
      ...item,
      personalno: item.personalno
        ? decryptByRSA(item.personalno as string, privkey.value)
        : undefined
    }
  })
  loading.value = false
}

//行選択(行をクリック)
function clickRow({ row }) {
  selectedRow.value = row
}
//行をダブルクリック
function onDbclickCell({ row }) {
  if (props.disabledSelect) return
  selectedRow.value = row
  onOk()
}
//選択ボタン
function onOk() {
  modalVisible.value = false
  emit('select', selectedRow.value)
}

function sortType(field: string) {
  const fields = ['saisinflg', 'saisin']
  return fields.includes(field) ? 'string' : 'auto'
}
</script>
