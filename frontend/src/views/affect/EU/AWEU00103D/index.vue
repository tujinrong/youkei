<template>
  <a-modal
    :visible="props.visible"
    title="項目選択"
    width="1050px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    @cancel="closeFreeItem"
  >
    <!--    <a-spin :spinning="loading">-->
    <div class="self_adaption_table form">
      <a-row>
        <a-col v-bind="layout">
          <th>大分類</th>
          <td>
            <a-select
              v-model:value="freeForm.daibunrui"
              :options="daibunruiOptions"
              style="width: 100%"
              allow-clear
              show-search
              :filter-option="filterOption"
              :field-names="{ label: 'tablenm', value: 'tablenm' }"
              @change="(val) => handleSelect(val, 分類_Enums.大分類)"
              ><template #option="{ tablealias, tablenm }">
                {{ tablealias + ' : ' + tablenm }}
              </template></a-select
            >
          </td>
        </a-col>

        <a-col v-bind="layout">
          <th>中分類</th>
          <td>
            <a-select
              v-model:value="freeForm.tyubunrui"
              :options="tyubunruiOptions"
              show-search
              :filter-option="filterOption"
              :field-names="{ label: 'tablenm', value: 'tablenm' }"
              style="width: 100%"
              allow-clear
              @change="(val) => handleSelect(val, 分類_Enums.中分類)"
              ><template #option="{ tablealias, tablenm }">
                {{ tablealias + ' : ' + tablenm }}
              </template></a-select
            >
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>小分類</th>
          <td>
            <a-select
              v-model:value="freeForm.syobunrui"
              :options="syobunruiOptions"
              show-search
              :filter-option="filterOption"
              :field-names="{ label: 'tablenm', value: 'tablenm' }"
              allow-clear
              style="width: 100%"
              @change="(val) => handleSelect(val, 分類_Enums.小分類)"
              ><template #option="{ tablealias, tablenm }">
                {{ tablealias + ' : ' + tablenm }}
              </template></a-select
            >
          </td>
        </a-col>
      </a-row>
    </div>
    <vxe-table
      ref="xTableRef"
      height="400"
      class="mt-2"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :sort-config="{ trigger: 'cell' }"
      :row-config="{ keyField: 'itemid', isHover: true }"
      :checkbox-config="{ trigger: 'row' }"
      :data="tableitemlist"
      :empty-render="{ name: 'NotData' }"
      @checkbox-change="onTableChange"
    >
      <vxe-column type="checkbox" width="50"></vxe-column>
      <vxe-column field="itemid" title="項目コード" sortable></vxe-column>
      <vxe-column field="itemhyojinm" title="項目名" sortable></vxe-column>
      <vxe-column field="sqlcolumn" title="SQLカラム" sortable></vxe-column>
      <vxe-column field="daibunrui" title="大分類" sortable></vxe-column>
      <vxe-column field="tyubunrui" title="中分類" sortable></vxe-column>
      <vxe-column field="syobunrui" title="小分類" sortable :resizable="false"></vxe-column>
    </vxe-table>
    <!--    </a-spin>-->
    <template #footer>
      <div style="float: left">
        <a-button class="warning-btn" @click="saveFreeItem">登録</a-button>
      </div>
      <a-button type="primary" @click="closeFreeItem">閉じる</a-button>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
//---------------------------------------------------------------------------
//フリー項目設定
//---------------------------------------------------------------------------
import { message } from 'ant-design-vue'
import { watch, ref, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { A000008, SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { TableItemVM, SearchRequest, TableVM } from './type'
import { Search, Save } from './service'
import { showInfoModal, showSaveModal } from '@/utils/modal'
import { GlobalStore } from '@/store'

const layout = {
  xs: 24,
  sm: 24,
  md: 24,
  xxl: 24
}

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
enum 分類_Enums {
  大分類 = 1,
  中分類,
  小分類
}

interface Props {
  visible: boolean
  tableIndex: number
  form: any
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'refresh'])
const route = useRoute()
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
//ローディング
const editJudge = new Judgement()
// const loading = ref(false)
//ビューモデル
const xTableRef = ref<VxeTableInstance>()

const tableitemlist = ref<TableItemVM[]>()
const daibunruiOptions = ref<TableVM[]>([]) // 大分類Options
const tyubunruiOptions = ref<TableVM[]>([]) //  中分類Options
const syobunruiOptions = ref<TableVM[]>([]) // 小分類Options

const createDefaultForm = (): SearchRequest => ({
  datasourceid: route.query.datasourceid as string, // データソースID
  daibunrui: '', // 大分類
  tyubunrui: '', // 中分類
  syobunrui: '' //小分類
})
const freeForm = reactive(createDefaultForm())

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      const list = await initData()
      daibunruiOptions.value = list
    }
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化
const initData = async () => {
  // loading.value = true
  const saveParams = {
    datasourceid: freeForm.datasourceid,
    daibunrui: freeForm.daibunrui,
    tyubunrui: freeForm.tyubunrui,
    syobunrui: freeForm.syobunrui
  }
  const res = await Search(saveParams)
  // loading.value = false
  tableitemlist.value = res.tableitemlist
  return res.nextbunruilist
}

const handleSelect = async (val, type: 分類_Enums) => {
  if (type === 分類_Enums.大分類) {
    freeForm.tyubunrui = freeForm.syobunrui = undefined
    tyubunruiOptions.value = syobunruiOptions.value = []
  } else if (type === 分類_Enums.中分類) {
    freeForm.syobunrui = undefined
    syobunruiOptions.value = []
  }

  let list = await initData()

  if (type === 分類_Enums.大分類 && val) {
    tyubunruiOptions.value = list
  }
  if (type === 分類_Enums.中分類 && val) {
    syobunruiOptions.value = list
  }
}

//フリーmodal閉じる
const closeFreeItem = () => {
  editJudge.judgeIsEdited(() => {
    tableitemlist.value = []
    daibunruiOptions.value = []
    tyubunruiOptions.value = []
    syobunruiOptions.value = []
    Object.assign(freeForm, createDefaultForm())
    emit('update:visible', false)
  })
}
//登録フリー項目
const saveFreeItem = async () => {
  const records = xTableRef.value?.getCheckboxRecords()
  if (!records || records.length === 0) {
    showInfoModal({
      type: 'warning',
      content: A000008.Msg
    })
  } else {
    const saveReq = async (checkflg: boolean) => {
      await Save({
        ...freeForm,
        sqlcolumns: records.map((item) => item.sqlcolumn),
        checkflg
      })
    }
    await saveReq(true)
    showSaveModal({
      onOk: async () => {
        // loading.value = true
        saveReq(false).then(() => {
          tableitemlist.value = []
          daibunruiOptions.value = []
          tyubunruiOptions.value = []
          syobunruiOptions.value = []
          Object.assign(freeForm, createDefaultForm())
          emit('refresh')
          emit('update:visible', false)
          message.success(SAVE_OK_INFO.Msg)
        })
        // .finally(() => {
        //   loading.value = false
        // })
      }
    })
  }
}
function filterOption(input: string, option) {
  return (
    option.tablenm.toLowerCase().includes(input.toLowerCase()) ||
    option.tablealias.toLowerCase().includes(input.toLowerCase())
  )
}
const onTableChange = () => {
  editJudge.setEdited()
}
</script>
<style scoped lang="less" src="./index.less"></style>
