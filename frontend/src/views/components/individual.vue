<template>
  <a-modal v-model:visible="individualVisible" width="1000px" title="個人検索">
    <div class="top-panel">
      <a-spin :spinning="loading">
        <a-row :gutter="10">
          <a-col :lg="3">【検索条件】</a-col>
          <a-col :lg="19">
            <a-form layout="inline" :model="formState" :label-col="labelCol">
              <a-form-item label="カナ氏名">
                <a-input v-model:value="formState.KanaName" style="width: 194px"> </a-input>
              </a-form-item>
              <a-form-item label="生年月日" style="margin-left: 30px">
                <date-jp v-model:value="formState.birthDate" style="width: 270px"></date-jp>
              </a-form-item>
              <a-form-item label="性&emsp;&emsp;別" style="margin-top: 10px">
                <ai-select
                  v-model:value="formState.sex"
                  :options="sexOptions"
                  style="width: 194px"
                ></ai-select>
              </a-form-item>
              <a-form-item style="margin-top: 10px; margin-left: 30px" label="住民区分">
                <a-checkbox v-model:checked="formState.checked1">住民のみ</a-checkbox>
                <a-checkbox v-model:checked="formState.checked2">国保のみ</a-checkbox>
                <a-checkbox v-model:checked="formState.checked3">後期のみ</a-checkbox>
              </a-form-item>
            </a-form>
          </a-col>
        </a-row>
        <a-row style="margin-top: 5px">
          <a-col :lg="2">
            <a-button type="primary" style="float: right" @click="onSearch()">検索</a-button>
          </a-col>
        </a-row>
      </a-spin>
    </div>
    <a-card class="m-t-1" :style="{ height: '511px' }">
      <a-pagination
        v-model:current="current"
        v-model:page-size="pageSize"
        :total="total"
        show-less-items
        size="small"
        style="float: right; margin-bottom: 10px"
        :custom-row="customRow"
        @change="onSearch()"
      />
      <a-table
        bordered
        class="ant-table-striped b-1-solid-dark header-border"
        size="small"
        :data-source="dataList1"
        :columns="columns1"
        :pagination="false"
        :custom-row="customRow"
        :scroll="{ y: 400 }"
        :locale="locale"
        :show-sorter-tooltip="false"
        @resizeColumn="handleResizeColumn"
      >
      </a-table>
    </a-card>

    <template #footer>
      <a-button key="submit" :loading="loading" :disabled="!hasSelected" @click="handleOk"
        >選択</a-button
      >
      <a-button key="back" type="primary" @click="individualClose">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const individualVisible = ref(false)
const loading = ref(false)
const current = ref(1)
const pageSize = ref(10)
const total = ref(0)
const formState = ref({
  phone: '',
  phone1: '',
  phone2: '',
  email1: '',
  email2: '',
  fax: '',
  num: '',
  kanaName: '',
  name: '',
  birthDate: '',
  address: '',
  relation: ''
})

const sexOptions = ref([
  { value: '1', label: '男性·女性' },
  { value: '2', label: '男性のみ' },
  { value: '3', label: '女性のみ' }
])
const dataList1 = ref([
  {
    num: '00000087201',
    name: '金井　愛乃',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '平成14年06月30日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '住民'
  },
  {
    num: '00000087202',
    name: '金井　葵',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '大正11年08月15日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '除票'
  },
  {
    num: '00000087203',
    name: '金井　蒼波',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '昭和57年01月14日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '除票'
  },
  {
    num: '00000087204',
    name: '金井　青葉',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '平成11年01月16日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '除票'
  },
  {
    num: '00000087205',
    name: '金井　亜賀沙',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '昭和41年12月10日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '住民'
  },
  {
    num: '00000087206',
    name: '金井　亞可音',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '昭和07年02月06日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '住民'
  },
  {
    num: '00000087207',
    name: '金井　晶乃',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '昭和32年09月08日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '除票'
  },
  {
    num: '00000087208',
    name: '金井　亜紀乃',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '昭和59年07月01日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '住民'
  },
  {
    num: '00000087209',
    name: '金井　愛希穂',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '昭和53年01月16日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '住民'
  },
  {
    num: '00000087210',
    name: '金井　爽帆',
    kananame: 'カナイ　アイノ',
    sex: '女',
    birthday: '平成08年04月30日',
    address: 'OΟ区ΔΔΔ1丁2番3号',
    district: 'ΔΔOΟ',
    class: '除票'
  }
])
const columns1 = ref([
  {
    title: '宛名番号',
    dataIndex: 'num',
    key: 'num',
    sorter: true
  },
  {
    title: '氏名',
    dataIndex: 'name',
    key: 'name',
    sorter: true
  },
  {
    title: 'カナ氏名',
    dataIndex: 'kananame',
    key: 'kananame',
    sorter: true
  },
  {
    title: '性別',
    dataIndex: 'sex',
    key: 'sex',
    width: 60,
    sorter: true
  },
  {
    title: '生年月日',
    dataIndex: 'birthday',
    key: 'birthday',
    width: 135,
    sorter: true
  },
  {
    title: '住所',
    dataIndex: 'address',
    key: 'address',
    width: 150,
    sorter: true
  },
  {
    title: '行政区',
    dataIndex: 'district',
    key: 'district',
    sorter: true
  },
  {
    title: '住民区分',
    dataIndex: 'class',
    key: 'class',
    sorter: true
  }
])

const locale = ref({
  cancelSort: '降順にソート',
  triggerAsc: 'ソートをキャンセル',
  triggerDesc: '昇順にソート'
})

const selectedRowKeys = ref([])

const emit = defineEmits(['select'])
const type = ref()

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const hasSelected = computed(() => selectedRowKeys.value.length > 0)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  current.value = 1
  pageSize.value = 10
  total.value = 0
  dataList1.value = []
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//Show
const open = (sexType) => {
  individualVisible.value = true
  type.value = sexType
}

//close
const closeModal = () => {
  individualVisible.value = false
}

//登録
const handleOk = () => {
  select(selectedRowKeys.value[0])
  individualVisible.value = false
}

//閉じる
const individualClose = () => {
  individualVisible.value = false
}

//rowスタイル、イベントをクリック
const customRow = (record, index) => {
  return {
    style: {
      color: record.num === selectedRowKeys.value[0]?.num ? '#FFFFFF' : '',
      'background-color': record.num == selectedRowKeys.value[0]?.num ? '#096dd9' : ''
    },
    onDblclick: () => {
      select(record)
      closeModal()
    },
    onclick() {
      selectedRowKeys.value = [record]
    }
  }
}

//行の高さ
const handleResizeColumn = (w, col) => {
  col.width = w
}

//イベントの選択
const select = (record) => {
  emit('select', record, type.value)
}

//イベントの検索
const onSearch = () => {
  loading.value = true
  setTimeout(() => {
    dataList1.value = []
    for (
      let i = current.value * pageSize.value - pageSize.value;
      i < current.value * pageSize.value;
      i++
    ) {
      dataList1.value.push({
        num: '00000087' + i,
        name: i % 2 == 0 ? '金井　愛希穂' : '金井　太郎',
        kananame: 'カナイ　アイノ',
        sex: i % 2 == 0 ? '女' : '男',
        birthday: '昭和53年01月16日',
        address: 'OΟ区ΔΔΔ1丁2番3号' + i,
        district: 'ΔΔOΟ',
        class: '住民'
      })
    }
    total.value = 100
    loading.value = false
  }, 1000)
}

defineExpose({
  open
})
</script>
<style lang="less" scoped></style>
