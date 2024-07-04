<template>
  <a-card :bordered="false" style="margin-top: -5px">
    <a-form layout="inline" :model="queryParams" style="display: block">
      <div>
        <a-form-item label="年&emsp;&emsp;度" style="margin-top: 10px">
          <year-jp v-model:value="date" style="width: 220px"></year-jp>
        </a-form-item>
        <a-form-item class="secend-cell">
          <a-tabs v-model:activeKey="activeKey1" @change="tabChange">
            <a-tab-pane key="1" tab="新規交付"></a-tab-pane>
            <a-tab-pane key="2" tab="修正"></a-tab-pane>
          </a-tabs>
        </a-form-item>
      </div>
      <div v-if="activeKey1 == '1'">
        <a-form-item label="区&emsp;&emsp;分" style="margin-top: 10px">
          <ai-select
            v-model:value="queryParams.newDelivery"
            style="width: 220px"
            :options="newDeliveryOptions"
          ></ai-select>
        </a-form-item>
      </div>
      <div style="">
        <a-form-item label="手帳番号" style="margin-top: 10px">
          <a-input
            v-model:value="queryParams.notebookNumber1"
            style="width: 151px"
            :disabled="!checkedType"
          >
          </a-input>
          <span style="line-height: 30px"> —</span>
          <a-input
            v-model:value="queryParams.notebookNumber2"
            style="width: 40px; margin-left: 10px"
            :disabled="!checkedType"
          >
          </a-input>
        </a-form-item>
        <a-form-item v-if="activeKey1 == '2'" label="宛名番号" class="secend-cell">
          <kojin-no
            v-model:value="queryParams.organizationNo"
            style="width: 220px"
            :disabled="!checkedType"
            @OnSearch="openEdit"
          ></kojin-no>
        </a-form-item>
        <a-form-item v-if="activeKey1 == '2'" label="個人番号" class="last-cell">
          <a-input
            v-model:value="queryParams.personalNumber"
            style="width: 220px"
            :disabled="!checkedType"
          >
          </a-input>
        </a-form-item>
      </div>
      <div v-if="activeKey1 == '2'">
        <a-form-item label="氏&emsp;&emsp;名" style="margin-top: 10px">
          <a-input v-model:value="queryParams.name" :disabled="!checkedType" style="width: 220px">
          </a-input>
        </a-form-item>
        <a-form-item label="カナ氏名" class="secend-cell">
          <a-input
            v-model:value="queryParams.kanaName"
            :disabled="!checkedType"
            style="width: 220px"
          >
          </a-input>
        </a-form-item>
        <a-form-item label="生年月日" class="last-cell">
          <date-jp v-model:value="birthDate" style="width: 220px"></date-jp>
        </a-form-item>
      </div>
    </a-form>
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button v-if="activeKey1 == '1'" type="primary" @click="addRowEvent">新規</a-button>
        <a-button v-if="activeKey1 == '2'" type="primary" @click.prevent="onSubmit">検索</a-button>
        <a-button
          v-if="activeKey1 == '2'"
          type="primary"
          :style="searchDrawerRef?.hasCondition() ? { filter: 'hue-rotate(60deg)' } : {}"
          @click="openDetail"
          >詳細検索<spin v-if="searchDrawerRef?.hasCondition()">☆</spin></a-button
        >
        <a-button type="primary" @click="resetFields">クリア</a-button>
      </a-space>

      <close-page></close-page>
    </div>
  </a-card>
  <a-card class="m-t-1">
    <a-pagination
      v-model:current="current"
      v-model:page-size="pageSize"
      :total="3"
      show-less-items
      size="small"
      style="float: right; margin-bottom: 10px"
    />
    <a-table
      class="m-t-1 ant-table-striped"
      :data-source="newtableList"
      :columns="columns1"
      bordered
      :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
      :custom-row="customRow"
      :locale="locale"
      :show-sorter-tooltip="false"
    >
      <template #bodyCell="{ column, record, index }">
        <template v-if="column.dataIndex === 'motherName'">
          <a @click="openEdit(record)">{{ record[column.dataIndex] }}</a>
        </template>
        <template v-if="column.dataIndex === 'sort'">
          <span>{{ index + 1 }}</span>
        </template>
        <template v-if="column.dataIndex === 'gender'">
          <span v-if="record.gender == '1'" style="color: #0000ff">男</span>
          <span v-if="record.gender == '2'" style="color: #ff0000">女</span>
        </template>
      </template>
    </a-table>
  </a-card>
  <detail-search-drawer
    ref="searchDrawerRef"
    :modal-left-list="[1, 2, 3, 7]"
    :modal-right-list="[8, 9, 10, 11]"
    :sex-disable-man="false"
    :sex-disable-both="false"
    :init-date-base="getInitBaseDate()"
  />
</template>

<script lang="ts" setup>
//--------------------------------------------------------------------------
//妊産婦情報管理一覧
//--------------------------------------------------------------------------
import { ref, reactive } from 'vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { useRouter } from 'vue-router'
import { getDetailSearchData } from '@/views/affect/YS/test000001/service'
import DateJp from '@/components/Selector/DateJp/index.vue'
import type { Dayjs } from 'dayjs'
import KojinNo from '@/views/affect/AF/AWAF00701D/index.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const birthDate = ref<Dayjs>()
const againShow = ref<boolean>(false)
const checkedType = ref<boolean>(true)
const router = useRouter()
const date = ref<number>(2022)
const current = ref(1)
const pageSize = ref(10)
const locale = ref({
  cancelSort: '降順にソート',
  triggerAsc: 'ソートをキャンセル',
  triggerDesc: '昇順にソート'
})
const queryParams = reactive<FormState>({
  notebookNumber1: '',
  notebookNumber2: '',
  organizationNo: '',
  kanaName: '',
  bigCode: '',
  midCode: '',
  newDelivery: null,
  visit: null,
  healthcare: null,
  Promoter: null,
  notice: null,
  disability: null,
  childbirth: null,
  insurance: null,
  oneself: null,
  category: null,
  place: null
})
const newDeliveryOptions = [
  { value: '1', label: '普通' },
  { value: '2', label: '転入' }
]
const tableList = ref([
  {
    code: '1',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '住民',
    order: '',
    childrenName: '川合 高大',
    gender: '1',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '2',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '除票',
    order: '',
    childrenName: '川合 高大',
    gender: '2',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '3',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '住民',
    order: '',
    childrenName: '川合 高大',
    gender: '1',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '4',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '除票',
    order: '',
    childrenName: '川合 高大',
    gender: '2',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '5',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '住民',
    order: '',
    childrenName: '川合 高大',
    gender: '1',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '6',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '除票',
    order: '',
    childrenName: '川合 高大',
    gender: '2',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '7',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '住民',
    order: '',
    childrenName: '川合 高大',
    gender: '1',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '8',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '除票',
    order: '',
    childrenName: '川合 高大',
    gender: '2',
    childrenDate: '平成14年09月22日'
  },
  {
    code: '9',
    manualNo: '平成14-19-1',
    motherName: '金山 有美',
    motherDate: '昭和51年05月10日',
    pregnantDeclarationDate: '平成17年4月02日',
    weeks: '15週数',
    childbirthDate: '平成17年10月02日',
    address: '○○区△△△1丁目',
    residentType: '住民',
    order: '',
    childrenName: '川合 高大',
    gender: '1',
    childrenDate: '平成14年09月22日'
  }
])
const newtableList = ref([])
const columns1 = [
  {
    title: '手帳番号',
    dataIndex: 'manualNo',
    key: 'manualNo',
    width: 100,
    sorter: true
  },
  {
    title: '母',

    children: [
      {
        title: '宛名番号',
        dataIndex: 'code',
        key: 'code',
        width: 100,
        sorter: (a, b) => a.code - b.code
      },
      {
        title: '氏名',
        dataIndex: 'motherName',
        key: 'motherName',
        width: 100,
        sorter: true
      },
      {
        title: '生年月日',
        dataIndex: 'motherDate',
        key: 'motherDate',
        width: 150,
        sorter: true
      },
      {
        title: '妊娠届出日',
        dataIndex: 'pregnantDeclarationDate',
        key: 'pregnantDeclarationDate',
        width: 150,
        sorter: true
      },
      {
        title: '週数',
        dataIndex: 'weeks',
        key: 'weeks',
        width: 80,
        sorter: true
      },
      {
        title: '分娩予定日',
        dataIndex: 'childbirthDate',
        key: 'childbirthDate',
        width: 150,
        sorter: true
      },
      {
        title: '住所',
        dataIndex: 'address',
        key: 'address',
        sorter: true
      },
      {
        title: '住民区分',
        dataIndex: 'residentType',
        key: 'residentType',
        width: 100,
        sorter: true
      }
    ]
  },
  {
    title: '子',

    children: [
      {
        title: '出生顺位',
        dataIndex: 'order',
        key: 'order',
        width: 100,
        sorter: true
      },
      {
        title: '氏名',
        dataIndex: 'childrenName',
        key: 'childrenName',
        width: 100,
        sorter: true
      },
      {
        title: '性別',
        dataIndex: 'gender',
        key: 'gender',
        width: 70,
        sorter: true
      },
      {
        title: '生年月日',
        dataIndex: 'childrenDate',
        key: 'childrenDate',
        width: 150,
        sorter: true
      }
    ]
  }
]
const areaOptions = ref([])
const residentOptions = ref([])
const officeOptions = ref([])
const oneResultOptions = ref([])
const checkedArea = ref([])
const residentValue = ref(0)
const loading = ref<boolean>(false)
const areaValue = ref(0)
const moreResultValue = ref(0)
const oneResultValue = ref(0)
const manValue = ref(0)
const womanValue = ref(0)
const dataValue = ref(0)
const codeValue = ref(0)
const officeValue = ref(0)
const checkedMoreResult = ref([])
const checkedOneResult = ref([])
const checkedOffice = ref([])
const checkedResident = ref([])
const activeKey1 = ref('2')
const searchDrawerRef = ref<any>(null)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const onSubmit = () => {
  if (!checkedType.value) {
    let val = {
      code: 1
    }
    router.push({
      path: 'test000002',
      query: {
        code: val.code
      }
    })
  } else {
    searchDrawerRef.value.validateDrawer().then(() => {
      console.log('closeDetail')
      searchDrawerRef.value.closeDrawer()
      loading.value = true
    })
    newtableList.value = tableList.value
  }
}
const openEdit = (val) => {
  if (val.gender) {
    val.code = val.gender
  }
  router.push({
    path: 'test000002',
    query: {
      code: val.code
    }
  })
}
const customRow = (record, index) => {
  return {
    onDblclick: () => {
      openEdit(record)
    }
  }
}

const openDetail = () => {
  loading.value = true
  searchDrawerRef.value.showDrawer()
  getDetailSearchData(null).then((res: any) => {
    loading.value = false
    areaOptions.value = res.data.areaOptions
    residentOptions.value = res.data.residentOptions
    officeOptions.value = res.data.officeOptions
    oneResultOptions.value = res.data.oneResultOptions
  })
}
const resetFields = () => {
  againShow.value = false

  areaValue.value = 0
  residentValue.value = 0
  oneResultValue.value = 0
  womanValue.value = 0
  manValue.value = 0
  dataValue.value = 0
  codeValue.value = 0
  officeValue.value = 0
  moreResultValue.value = 0

  checkedArea.value = []
  checkedResident.value = []
  checkedOffice.value = []
  checkedOneResult.value = []
  checkedMoreResult.value = []

  queryParams.bigCode = ''
  queryParams.midCode = ''
  queryParams.newDelivery = ''
  queryParams.notebookNumber1 = ''
  queryParams.notebookNumber2 = ''
  queryParams.organizationNo = ''
  queryParams.personalNumber = ''
  queryParams.name = ''
  queryParams.kanaName = ''
  birthDate.value = undefined
  searchDrawerRef.value.resetFields()
}

const tabChange = (activeKey) => {
  if (activeKey == '2') {
    queryParams.notebookNumber2 = ''
  }
  if (activeKey == '1') {
    queryParams.notebookNumber2 = '1'
  }
}

const addRowEvent = () => {
  router.push({
    path: 'test000002',
    query: {
      code: ''
    }
  })
}

const getInitBaseDate = (): Date => {
  return new Date(date.value - 1, 2, 31)
}
</script>

<style lang="less" scoped>
.header-description-table th {
  height: 36.5px !important;
}
.header-description-table td {
  height: 36.5px !important;
}
.mask-height {
  height: calc(100vh - 304px);
}
.guidanceBgcolor {
  background-color: #e6f7ff;
}
.guidance {
  margin-top: -1px;
}
.ant-table-striped :deep(.table-striped) td {
  background-color: #fafafa;
}
.btn-mag {
  margin: 0;
}
/deep/ .ant-table-pagination {
  display: none !important;
}
.last-cell {
  margin-left: 25px;
  margin-top: 10px;
  @media screen and(max-width:1260px) {
    margin-left: 0;
  }
}

.secend-cell {
  margin-left: 25px;
  margin-top: 10px;
  @media screen and(max-width:1020px) {
    margin-left: 0;
  }
}
</style>
