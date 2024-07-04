<template>
  <div class="tool-row">
    <div class="tool-row-left">
      <a-space>
        <ai-select
          v-model:value="tabOtherForm.way"
          :options="wayOptions"
          style="width: 220px"
        ></ai-select>
        <ai-select
          v-model:value="tabOtherForm.item"
          :options="itemOptions"
          style="width: 220px; margin-left: 10px"
        ></ai-select>
      </a-space>
    </div>
    <div class="tool-row-right">
      <a-space>
        <a-button type="primary" :disabled="isDisabled">エラーチェック(必須項目)</a-button>
        <a-button type="primary" :disabled="isDisabled">初期値</a-button>
      </a-space>
    </div>
  </div>

  <div class="cell-height-65">
    <vxe-table
      border
      :data="otherInfoData"
      class="m-t-1"
      :column-config="{ resizable: true }"
      :edit-config="{ trigger: 'click', mode: 'cell' }"
      :cell-style="vxecellStyle"
      :header-cell-class-name="headerCellClassName"
    >
      <!-- <vxe-column type="seq" width="60"></vxe-column>-->
      <vxe-column field="code" title="" width="40"></vxe-column>
      <vxe-column field="name" title="項　目" width="400"></vxe-column>
      <vxe-column
        field="input"
        title="入　力"
        :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
      >
        <template #default="{ row }">
          <span v-if="row.type === '01'">{{ formatInput(row.input) }}</span>
          <span v-else>{{ row.input }}</span>
        </template>
        <template #edit="{ row }">
          <div v-if="row.type === '01'">
            <ai-select
              v-model:value="row.input"
              :options="inputOption"
              @change="inputChanged(row)"
            ></ai-select>
          </div>
          <div v-else>
            <vxe-input v-model="row.input" type="text"></vxe-input>
          </div>
        </template>
      </vxe-column>
    </vxe-table>
  </div>

  <div class="m-t-1">
    <a-descriptions bordered title="" size="small">
      <a-descriptions-item
        label="注　釈"
        :label-style="{
          width: '5% !important',
          padding: '5px',
          'background-color': '#ffffe1',
          'vertical-align': 'baseline'
        }"
        :content-style="{
          width: '100% !important',
          height: '80px !important',
          'vertical-align': 'baseline'
        }"
      ></a-descriptions-item>
    </a-descriptions>
  </div>
</template>
<!--その他情報-->
<script lang="ts" setup>
import { computed, reactive, ref } from 'vue'
import { layoutMode, multiTab } from '@/store/use-site-settings'
import config from '@/config/default-settings'
import { VxeTablePropTypes } from 'vxe-table'
import { MenuType } from '#/Enums'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tabOtherForm = reactive<FormState>({
  way: '01',
  item: '01'
})

const wayOptions = [
  { value: '01', label: 'すべて' },
  { value: '02', label: '一次検診' },
  { value: '03', label: '精密検査' }
]

const itemOptions = [
  { value: '01', label: 'すべて' },
  { value: '02', label: 'PHR関連項目' },
  { value: '03', label: 'その他' }
]

const tableData1 = ref([
  { cd: '1', content: '所見なし' },
  { cd: '2', content: '所見あり' },
  { cd: '', content: '' },
  { cd: '', content: '' }
])

const otherInfoData = ref([
  {
    id: 10001,
    code: '風',
    name: '風しん抗体検査:実施方法',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10002,
    code: '風',
    name: '風しん抗体検査:検査法',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10003,
    code: '風',
    name: '風しん抗体検査:抗体価数値',
    input:
      'あいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえお',
    contents: '',
    type: '02'
  },
  {
    id: 10004,
    code: '風',
    name: '風しん抗体検査:抗体価(ICA法)',
    input: '',
    contents: '',
    type: '02'
  },
  {
    id: 10005,
    code: '風',
    name: '風しん抗体検査:判定結果',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10006,
    code: '風',
    name: '風しん抗体検査:梗査実施日',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10007,
    code: '風',
    name: '風しん抗体検査:検査結果判定日',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10008,
    code: '風',
    name: '風しん抗体検査:実施機関',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10009,
    code: '風',
    name: '風しん抗体快査:実施機関所在地',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10010,
    code: '風',
    name: '風しん抗体検査:担当医師(検査実施者)',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10011,
    code: '風',
    name: '風しん抗体検査:担当医師(検査結果判定者)',
    input: '',
    contents: '',
    type: '01'
  },
  {
    id: 10012,
    code: '風',
    name: '風しん抗体検査:検査番号',
    input: '',
    contents: ''
  },
  {
    id: 10013,
    code: '風',
    name: '風しん抗体検査:備考',
    input: '',
    contents: '',
    type: '01'
  }
])
const inputOption = ref([
  { label: '赤血球凝集抑制法(HI法)', value: '01' },
  { label: '酵素免疫法(EIA法)', value: '02' },
  { label: 'ラテックス免役比濁法(LTI法)', value: '03' },
  { label: '堂光酵索免疫法(ELFA法)', value: '04' },
  { label: '化学発光酵素免疫法(CLEIA法)', value: '05' }
])

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const filterbigOption = (input: string, option: any) => {
  return option.key.label.indexOf(input) >= 0 || option.value.indexOf(input) >= 0
}

const vxecellStyle = ({ row, column, columnIndex }) => {
  let rowstyle = {
    background: '',
    borderRight: '',
    borderBottom: ''
  }
  let flag =
    (column.title == '項　目' && columnIndex == '1') || (column.title == '' && columnIndex == '0')
  if (flag) {
    rowstyle.background = '#f8f8f9'
    rowstyle.borderRight = '1px solid #e8eaec'
    rowstyle.borderBottom = '1px solid #e8eaec'
  }
  return rowstyle
}
const subTableHeight = computed(() => {
  let h = 650
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})

const inputChanged = (val) => {
  inputOption.value.forEach((item) => {
    if (val.input === item.value) {
      val.contents = item.label
    }
  })
  return val
}
const headerCellClassName: VxeTablePropTypes.HeaderCellClassName = ({ column }) => {
  if (column.field === 'name') {
    return 'table-name'
  }
  if (column.field === 'input') {
    return 'bg-editable'
  }
  return null
}
const formatInput = (value: any) => {
  if (value === '01') {
    return '01:赤血球凝集抑制法(HI法)'
  }
  if (value === '02') {
    return '02:酵素免疫法(EIA法)'
  }
  if (value === '03') {
    return '03:ラテックス免役比濁法(LTI法)'
  }
  if (value === '04') {
    return '04:堂光酵索免疫法(ELFA法)'
  }
  if (value === '05') {
    return '05:化学発光酵素免疫法(CLEIA法)'
  }
  return ''
}
</script>

<style scoped>
/deep/ .table-name {
  background-color: #ffffe1 !important;
}
/deep/ .bg-editable {
  background-color: #ecf5ff !important;
}
</style>
