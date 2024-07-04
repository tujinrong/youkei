<template>
  <a-card :bordered="false">
    <a-form
      :model="queryParams"
      :label-col="{ flex: '80px' }"
      :wapper-col="{ flex: '1' }"
      style="max-width: 1400px"
    >
      <a-row :gutter="[0, 10]">
        <a-col :xs="24" :sm="24" :md="24" :lg="12" :xl="6" :xxl="5">
          <a-form-item label="宛名番号">
            <kojin-no
              v-model:value="queryParams.num"
              style="width: 100%; max-width: 200px"
              @OnSearch="openModal"
            ></kojin-no>
          </a-form-item>
        </a-col>
        <a-col :xs="24" :sm="24" :md="24" :lg="12" :xl="6" :xxl="5">
          <a-form-item label="カナ氏名">
            <a-input v-model:value="queryParams.KanaName" style="width: 100%; max-width: 200px">
            </a-input>
          </a-form-item>
        </a-col>
        <a-col :xs="24" :sm="24" :md="24" :lg="12" :xl="6" :xxl="5">
          <a-form-item label="生年月日">
            <date-jp v-model:value="birthDate" style="width: 100%; max-width: 200px"></date-jp>
          </a-form-item>
        </a-col>
        <a-col :xs="24" :sm="24" :md="24" :lg="12" :xl="6" :xxl="5">
          <a-form-item label="個人番号">
            <a-input
              v-model:value="queryParams.personalNumber"
              style="width: 100%; max-width: 200px"
              show-search
            >
            </a-input>
          </a-form-item>
        </a-col>
      </a-row>
    </a-form>
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button type="primary" @click.prevent="onSubmit">検索</a-button>
        <a-button
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
    <div>
      <a-pagination
        v-model:current="current"
        v-model:page-size="pageSize"
        :total="3"
        show-less-items
        size="small"
        style="float: right; margin-bottom: 10px"
      />
      <a-table
        class="mytable-scrollbar m-t-1"
        :data-source="dataSource"
        :columns="columns1"
        :pagination="false"
        bordered
        :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
        :custom-row="customRow"
        :locale="locale"
        :show-sorter-tooltip="false"
        @resizeColumn="handleResizeColumn"
      >
        <template #bodyCell="{ column, record }">
          <template v-if="column.dataIndex === 'name' || column.dataIndex === 'kanaName'">
            <a @click="openModal(record)">{{ record[column.dataIndex] }}</a>
          </template>
        </template>
      </a-table>
    </div>
  </a-card>
  <detail-search-drawer
    ref="searchDrawerRef"
    :modal-left-list="[1, 2, 3]"
    :modal-right-list="[4, 5, 6]"
    :sex-disable-man="false"
    :sex-disable-both="false"
    :init-date-base="getInitBaseDate()"
  />
</template>

<script lang="ts" setup>
//---------------------------------------------------------------------------
//乳幼児予防接種一覧
//---------------------------------------------------------------------------
import { ref, reactive, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { getDetailSearchData } from './service'
import DateJp from '@/components/Selector/DateJp/index.vue'
import type { Dayjs } from 'dayjs'
import KojinNo from '@/views/affect/AF/AWAF00701D/index.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref<boolean>(false)
const moreResultValue = ref(0)
const oneResultValue = ref(0)
const areaValue = ref(0)
const router = useRouter()
const disBigselect = ref<boolean>(false)
const disMidselect = ref<boolean>(false)
const disabled = ref<boolean>(false)
const isShow = ref<boolean>(true)
const againShow = ref<boolean>(false)
const birthDate = ref<Dayjs>()
const current = ref(1)
const pageSize = ref(10)
const queryParams = reactive<FormState>({
  bigCode: '',
  midCode: '',
  num: '',
  KanaName: '',
  type: '01',
  status: '01',
  state: '01',
  state2: '01'
})
const dataSource = ref([])
const tableList = ref([
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  },
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  },
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  },
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  },
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  },
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  },
  {
    atenano: '00000087208',
    name: '金井　愛乃',
    kanaName: 'カナｲ　アイノ',
    sex: '女',
    birthDate: '',
    address: '○○○区△△△1丁目',
    region: '△△◇△',
    classification: '住民'
  }
])
const locale = ref({
  cancelSort: '降順にソート',
  triggerAsc: 'ソートをキャンセル',
  triggerDesc: '昇順にソート'
})
const columns1 = ref([
  {
    title: '宛名番号',
    dataIndex: 'atenano',
    key: 'atenano',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: '氏名',
    dataIndex: 'name',
    key: 'name',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: 'カナ氏名',
    dataIndex: 'kanaName',
    key: 'kanaName',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: '性別',
    dataIndex: 'sex',
    key: 'sex',

    width: 80,
    resizable: true,
    sorter: true
  },
  {
    title: '生年月日',
    dataIndex: 'birthDate',
    key: 'birthDate',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: '住所',
    dataIndex: 'address',
    key: 'address',
    width: 300,
    resizable: true,
    sorter: true
  },
  {
    title: '行政区',
    dataIndex: 'region',
    key: 'region',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: '住民区分',
    dataIndex: 'classification',
    key: 'classification',
    width: 120,
    resizable: true,
    sorter: true
  }
])
const areaOptions = ref([])
const residentOptions = ref([])
const officeOptions = ref([])
const oneResultOptions = ref([])
const checkedArea = ref([])
const residentValue = ref(0)
const checkedResident = ref([])
const checkedOffice = ref([])
const checkedOneResult = ref([])
const checkedMoreResult = ref([])
const manValue = ref(0)
const womanValue = ref(0)
const dataValue = ref(0)
const codeValue = ref(0)
const officeValue = ref(0)
const mode = ref('default') // default list edit
const searchDrawerRef = ref<any>(null)
const year = ref(new Date().getFullYear())

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  // getInitData(true)
  disabled.value = true
  disMidselect.value = true
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const openModal = (val) => {
  router.push({
    path: 'test000001',
    query: {
      atenano: val.atenano
    }
  })
}
const onSubmit = () => {
  dataSource.value = tableList.value
  console.log(queryParams)
  searchDrawerRef.value.validateDrawer().then(() => {
    console.log('closeDetail')
    searchDrawerRef.value.closeDrawer()
    loading.value = true
  })
}
const resetFields = () => {
  disMidselect.value = true
  disBigselect.value = false
  againShow.value = false
  isShow.value = true
  disabled.value = true
  tableList.value = []

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
  queryParams.num = ''
  queryParams.KanaName = ''
  birthDate.value = undefined
  queryParams.personalNumber = ''
  mode.value = 'default'
  searchDrawerRef.value.resetFields()
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
const customRow = (record, index) => {
  return {
    onDblclick: () => {
      openModal(record)
    }
  }
}

const getInitBaseDate = (): Date => {
  return new Date(year.value - 1, 2, 31)
}
</script>

<style lang="less" scoped>
.ant-table-striped :deep(.table-striped) td {
  background-color: #fafafa;
}

/deep/ .table-name {
  background-color: #ffffe1 !important;
}

/deep/ .bg-editable {
  background-color: #ecf5ff !important;
}
:deep .vxe-table--render-default .vxe-table--body-wrapper.fixed-left--wrapper,
.vxe-table--render-default .vxe-table--footer-wrapper.fixed-left--wrapper,
.vxe-table--render-default .vxe-table--header-wrapper.fixed-left--wrapper {
  border-top: 1px solid #606266 !important;
}

:deep .ant-descriptions-row .ant-descriptions-item-label {
  width: 100px !important;
}
:deep .ant-descriptions-header {
  display: flex;
  align-items: center;
  margin-bottom: 0px;
  background: linear-gradient(#bebaba, white);
  border-top-left-radius: 8px;
  border-top-right-radius: 8px;
  opacity: 0.8;
  margin-top: 20px;
}
</style>
