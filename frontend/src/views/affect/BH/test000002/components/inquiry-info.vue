<template>
  <a-modal v-model:visible="infoShow" title="対象者情報照会" width="1200px">
    <a-row :gutter="10" style="margin-top: -14px">
      <a-col :lg="10" class="tables">
        <a-collapse active-key="1" accordion class="m-t-1">
          <a-collapse-panel key="1" header="住民記録情報" :show-arrow="false">
            <div :style="{ height: subHeightsubHeight, overflow: 'auto' }">
              <div class="description-table m-t-1 readonly">
                <table>
                  <tbody>
                    <tr>
                      <th style="width: 80px">氏名</th>
                      <td colspan="3">金井　愛乃</td>
                    </tr>
                    <tr>
                      <th>年齢</th>
                      <td colspan="3">
                        20歳 5か月 13日(令和04年12月13日現在)<br />
                        18歳 (令和03年03月31日現在)
                      </td>
                    </tr>
                    <tr>
                      <th>保険</th>
                      <td colspan="3"></td>
                    </tr>
                    <tr>
                      <th>世帯課税</th>
                      <td colspan="3">課税</td>
                    </tr>
                    <tr>
                      <th>行政区</th>
                      <td colspan="3">0040 △△◇△</td>
                    </tr>
                    <tr>
                      <th>住所</th>
                      <td colspan="3">○○区△△△１丁目２番３号</td>
                    </tr>
                    <tr>
                      <th>電話番号</th>
                      <td colspan="3">111-1111</td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <h4 class="m-t-1">世代構成</h4>
              <div
                class="out-border-table-box font-mini-table tables"
                :style="{ height: collapseHeight, overflow: 'auto' }"
              >
                <a-table
                  class="ant-table-striped"
                  :data-source="operationList1"
                  :columns="columns2"
                  bordered
                  :pagination="false"
                  :scroll="{ y: tableHeight }"
                  :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
                  :locale="locale"
                  :show-sorter-tooltip="false"
                >
                </a-table>
              </div>
            </div>
          </a-collapse-panel>
        </a-collapse>
      </a-col>
      <a-col :lg="14">
        <!--table-->
        <a-collapse active-key="1" accordion class="m-t-1">
          <a-collapse-panel key="1" header="母子手帳·健診情報" :show-arrow="false">
            <div
              class="out-border-table-box font-mini-table tables"
              :style="{ height: collapseHeight, overflow: 'auto' }"
            >
              <a-table
                class="ant-table-striped"
                :data-source="operationList2"
                :columns="columns3"
                :pagination="false"
                bordered
                :scroll="{ y: 130 }"
                :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
                :locale="locale"
                :show-sorter-tooltip="false"
              >
              </a-table>
              <a-tabs
                v-model:activeKey="collapseModel.activeKey"
                class="m-t-1"
                @change="
                  (key) => {
                    collapseModelChange(collapseModel, key)
                  }
                "
              >
                <a-tab-pane key="1" tab="妊婦健診情報">
                  <a-table
                    class="ant-table-striped"
                    :data-source="operationList"
                    :columns="columns1"
                    :pagination="false"
                    bordered
                    :scroll="{ y: 280 }"
                    :locale="locale"
                    :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
                    :show-sorter-tooltip="false"
                  >
                  </a-table
                ></a-tab-pane>
                <a-tab-pane key="2" tab="要管理内容">
                  <a-table
                    class="ant-table-striped"
                    :data-source="operationList"
                    :columns="columns4"
                    :pagination="false"
                    bordered
                    :scroll="{ y: 280 }"
                    :locale="locale"
                    :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
                    :show-sorter-tooltip="false"
                  >
                  </a-table>
                </a-tab-pane>
              </a-tabs>
            </div>
          </a-collapse-panel>
        </a-collapse>
      </a-col>
    </a-row>
    <template #footer>
      <a-button type="primary" style="margin-left: 10px" @click="infoClose">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup>
import { ref } from 'vue'
import { collapseModelChange } from '@/utils/util'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const infoShow = ref(false)
const loading = ref(false)
const formState = ref({})
const operationList1 = ref([
  {
    num: '00000086986',
    name: '金井　直太郎',
    relation: '世帯主',
    residence: '住民'
  },
  {
    num: '00000086987',
    name: '金井　愛矢',
    relation: '妻',
    residence: '住民'
  },
  {
    num: '00000087208',
    name: '金井　愛乃',
    relation: '子',
    residence: '住民'
  },
  {
    num: '00000093958',
    name: '金井　愛乃',
    relation: '子',
    residence: '住民'
  },
  {
    num: '00000095138',
    name: '金井　大地',
    relation: '父',
    residence: '除票'
  }
])

const columns2 = [
  {
    title: '宛名番号',
    dataIndex: 'num',
    key: 'num',
    width: 110,
    sorter: true
  },
  {
    title: '氏名',
    dataIndex: 'name',
    key: 'name',
    sorter: true
  },
  {
    title: '続柄',
    dataIndex: 'relation',
    key: 'relation',
    width: 80,
    sorter: true
  },
  {
    title: '住民区分',
    dataIndex: 'residence',
    key: 'residence',
    width: 90,
    sorter: true
  }
]
const columns1 = [
  {
    title: '健診回数',
    dataIndex: 'num',
    key: 'num',
    width: 130,
    sorter: true
  },
  {
    title: '健診年月日',
    dataIndex: 'date',
    key: 'date',
    width: 130,
    sorter: true
  },
  {
    title: '判定',
    dataIndex: 'type',
    key: 'type',
    sorter: true
  },
  {
    title: '備考',
    dataIndex: 'remarks',
    key: 'remarks',
    sorter: true
  }
]
const operationList = ref([
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' },
  { num: '', type: '', date: '' }
])
const columns4 = [
  {
    title: '内容',
    dataIndex: 'content',
    key: 'content',
    sorter: true
  },
  {
    title: 'フォロー方法',
    dataIndex: 'type',
    key: 'type',
    width: 120,
    sorter: true
  },
  {
    title: 'フォロー予定年月日',
    dataIndex: 'date',
    key: 'date',
    width: 160,
    sorter: true
  },
  {
    title: 'フォロー完了年月日',
    dataIndex: 'enddate',
    key: 'enddate',
    width: 160,
    sorter: true
  },
  {
    title: '備考',
    dataIndex: 'remarks',
    key: 'remarks',
    sorter: true
  }
]

//母子手帳·健診情報title
const columns3 = [
  {
    title: '手帳番号',
    dataIndex: 'num',
    key: 'num',
    width: 130,
    sorter: true
  },
  {
    title: '発行区分',
    dataIndex: 'type',
    key: 'type',
    width: 130,
    sorter: true
  },
  {
    title: '発行年月日',
    dataIndex: 'date',
    key: 'date',
    sorter: true
  }
]

//母子手帳·健診情報data
const operationList2 = ref([
  { num: '平成24-438-1', type: '普通', date: '平成28年03月21日' },
  { num: '平成28-132-1', type: '普通', date: '平成26年07月07日' },
  { num: '', type: '', date: '' }
])
const collapseModel = ref({
  activeKey: '1',
  activeKeyBackup: '1'
})
const locale = ref({
  cancelSort: '降順にソート',
  triggerAsc: 'ソートをキャンセル',
  triggerDesc: '昇順にソート'
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//Show
const open = () => {
  infoShow.value = true
}

//閉じる
const infoClose = () => {
  infoShow.value = false
}
defineExpose({
  open
})
</script>
<style lang="less" scoped>
.header-description-table th {
  height: 36.5px !important;
}
.header-description-table td {
  height: 36.5px !important;
}
.ant-table-striped :deep(.table-striped) td {
  background-color: #fafafa;
}
/deep/ .ant-table-thead > tr > th {
  text-align: center !important;
}
/deep/ .ant-collapse {
  border: 1px solid #606266 !important;
}
/deep/ .tables .ant-table-cell-scrollbar {
  display: none !important;
}
/deep/ .ant-table-container {
  border: 1px solid #606266 !important;
}
/deep/ .ant-table.ant-table-middle .ant-table-tbody > tr > td {
  height: 36.5px !important;
}
</style>
