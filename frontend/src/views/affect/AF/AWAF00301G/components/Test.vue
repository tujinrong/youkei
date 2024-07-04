<template>
  QAマニュアル
  <div class="flex flex-col gap-4">
    <div id="main1" style="width: 600px; height: 400px"></div>
    <a-button @click="open">open</a-button>
    <a-input v-model:value="xxx" />
    <span>&#x100001; &#x100308;</span>
    <a-button @click="ApiTest">ApiTest</a-button>
    <div>
      <CheckboxSelect v-model:value="value" :options="monthOptions" full-select class="w-90!" />
      <CheckboxSelect v-model:value="value" :options="options10" class="w-90!" />

      <!-- 日 -->
      <a-select v-model:value="value" mode="multiple" max-tag-count="responsive" class="w-70">
        <template #dropdownRender>
          <a-checkbox-group
            v-model:value="value"
            :options="options10"
            class="m-2"
            @mousedown="(e) => e.preventDefault()"
          />
        </template>
      </a-select>
      {{ value }}
    </div>
    <div>
      コード : 名称<ai-select v-model:value="select1" :options="options1" class="w-40!"></ai-select>
      {{ JSON.stringify(select1) }}
    </div>
    <div>
      コード<ai-select
        v-model:value="select2"
        :options="options1"
        split-val
        class="w-40!"
      ></ai-select>
      {{ JSON.stringify(select2) }}
    </div>
    <div>
      Number/Enum<ai-select
        v-model:value="select3"
        :options="options1"
        type="number"
        class="w-40!"
      ></ai-select>
      {{ JSON.stringify(select3) }}
    </div>

    <div>
      <DateJp
        v-model:value="date"
        unknown
        style="width: 190px"
        format="YYYY-MM-DD"
        @emit-unknown-date="(v) => (date = v)"
      />
      {{ date }}
    </div>
    <div>
      <DateTime v-model:value="time" hanif="2024-07-02 01:30:05" hanit="2024-07-02 02:40:10" />
      {{ time }}
    </div>
    <div>
      <RangeTime v-model:value1="rangetime2.value1" v-model:value2="rangetime2.value2" />
      {{ rangetime2 }}
    </div>
    <div>
      <RangeTime2 v-model:value="rangetime3" symbol="～" />
      {{ rangetime3 }}
    </div>
    <div>
      <RangeDateTime v-model:value1="rangetime.value1" v-model:value2="rangetime.value2" />
      <RangeDateTime2 v-model:value="rangetime" />
      {{ rangetime }}
    </div>
    <div>
      <RangeDateStr v-model:value="rangedatestr" />
      {{ rangedatestr }}
    </div>
    <div>
      <RangeDate2 v-model:value1="rangedate.value1" v-model:value2="rangedate.value2" />
      <RangeDate v-model:value="rangedate" unknown />
      {{ rangedate }}
    </div>
    <div class="w-100">
      <RangeInputNumber v-model:value="rangenumber" />
      {{ JSON.stringify(rangenumber) }}
    </div>
    <div class="w-100">
      <RangeNumberStr v-model:value="rangenumberstr" :precision="1" />
      {{ JSON.stringify(rangenumberstr) }}
    </div>
    <div>
      <PostCode v-model:value="postcode">
        <a-button type="primary">xx</a-button>
      </PostCode>
      {{ postcode }}
    </div>
    <div flex>
      <SimplePagination :current="current" :count="10" @change="(val) => (current = val)" />
      {{ 'current：' + current }}
    </div>
    <div>
      Regex test:
      <ai-input v-model:value="text" :regex="EnumRegex.半角数字" maxlength="12" />
    </div>
    <a-divider orientation="left">Hook</a-divider>

    <div>useDelayedAction: {{ x }}</div>
    <div>
      useMulOptsLimit:
      <a-select v-model:value="value2" class="w-50" :options="mulOpts" mode="multiple"></a-select>
    </div>
    <div>
      useLinkOption:
      <ai-select
        v-model:value="formData.adrs_sikucd"
        :options="options"
        class="w-60!"
        @change="onChangeOpt"
      />
      <ai-select
        v-model:value="formData.adrs_tyoazacd"
        :options="keyoptions"
        class="w-60!"
        @change="onChangeKeyOpt"
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import DateTime from '@/components/Selector/DateTime/index.vue'
import RangeTime from '@/components/Selector/RangeTime/index.vue'
import RangeTime2 from '@/components/Selector/RangeTime/index2.vue'
import RangeDateTime from '@/components/Selector/RangeDateTime/index.vue'
import RangeDateTime2 from '@/components/Selector/RangeDateTime/index2.vue'
import RangeDateStr from '@/components/Selector/RangeDateStr/index.vue'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import RangeDate2 from '@/components/Selector/RangeDate/index2.vue'
import RangeInputNumber from '@/components/Selector/RangeInputNumber/index.vue'
import RangeNumberStr from '@/components/Selector/RangeNumberStr/index.vue'
import CheckboxSelect from '@/components/Selector/CheckboxSelect/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import PostCode from '@/components/Selector/PostCode/index.vue'
import SimplePagination from '@/components/Common/SimplePagination/index.vue'
import { ref, watch, reactive, toRef, onMounted } from 'vue'
import { monthOptions } from '@/constants/constant'
import { api } from '@/utils/http/common-service'
import { EnumRegex } from '#/Enums'
import { useDelayedAction, useMulOptsLimit, useLinkOption } from '@/utils/hooks'
import { replaceText } from '@/utils/util'
import * as echarts from 'echarts'

const current = ref(2)
const text = ref('aa,bb')
const text2 = ref('11,22')
const value = ref<string[]>(['7'])
const select1 = ref()
const select2 = ref()
const select3 = ref()
const time = ref('')
const date = ref('0000A1A3')
const rangetime = ref({
  value1: '2024-02-15 12:12:12',
  value2: '2024-02-18 18:18:18'
})
const rangetime2 = ref({
  value1: '1212',
  value2: '1818'
})
const rangetime3 = ref('0027～')
const rangedate = ref({
  value1: '2024-02-15',
  value2: '2024-02-18'
})
const rangedatestr = ref('2024-02-15,2024-02-18')
const rangenumber = ref({
  value1: '1',
  value2: '2'
})
const rangenumberstr = ref('1,2')

const postcode = ref('123-4567')

const options1 = ref([
  {
    label: 'label1',
    value: '1'
  },
  {
    label: 'label2',
    value: '2'
  }
])

const options10 = ref([
  {
    label: '1',
    value: '1'
  },
  {
    label: '2',
    value: '2'
  },
  {
    label: '3',
    value: '3'
  },
  {
    label: '4',
    value: '4'
  },
  {
    label: '5',
    value: '5'
  },
  {
    label: '6',
    value: '6'
  },
  {
    label: '7',
    value: '7'
  },
  {
    label: '8',
    value: '8'
  },
  {
    label: '9',
    value: '9'
  },
  {
    label: '10',
    value: '10'
  },
  {
    label: '11',
    value: '11'
  },
  {
    label: '12',
    value: '12'
  },
  {
    label: '最終',
    value: 'xx'
  }
])

//Hook---------------------------
//
const x = ref(0)
useDelayedAction(() => {
  x.value++
}, 2000)
//
const value2 = ref<string[]>(['3', '5'])
const { mulOpts } = useMulOptsLimit(value2, options10, 2)
//
const formData = reactive({
  adrs_tyoazacd: '',
  adrs_sikucd: 'key1'
})
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(
  ref([
    {
      key: 'key1',
      value: 'aa',
      label: 'key1-aa'
    },
    {
      key: 'key2',
      value: 'bb',
      label: 'key2-bb'
    },
    {
      key: 'key2',
      value: 'cc',
      label: 'key2-cc'
    },
    {
      key: '',
      value: 'dd',
      label: 'both'
    }
  ]),
  ref([
    {
      value: 'key1',
      label: 'Key1'
    },
    {
      value: 'key2',
      label: 'Key2'
    }
  ]),
  toRef(formData, 'adrs_tyoazacd'),
  toRef(formData, 'adrs_sikucd')
)
//-------------------------------

watch(value, (val) => {
  // console.log('val: ', val)
})

function ApiTest() {
  const servicename = 'AWSH00304G'
  const methodname = 'Save'
  const params = { xxx: xxx.value }

  return api(servicename, methodname, params)
}

//Echarts
const option: echarts.EChartsOption = {
  xAxis: {
    type: 'category',
    data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
  },
  yAxis: {
    type: 'value'
  },
  series: [
    {
      data: [820, 932, 901, 934, 1290, 1330, 1320],
      type: 'line',
      smooth: true
    }
  ]
}
onMounted(() => {
  const chartDom = document.getElementById('main1')
  const myChart = echarts.init(chartDom)
  myChart.setOption(option)
})

function open() {
  const features = 'width=800,height=600'
  window.open('http://localhost:3000/home', '_blank', features)
}
const xxx = ref('')
</script>

<style lang="less" scoped></style>
