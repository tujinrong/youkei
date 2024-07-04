<!-- eslint-disable vue/no-parsing-error -->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>宛名番号</th>
            <TD>{{ atenano }}</TD>
          </a-col>

          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>氏名</th>
            <TD>{{ headerInfo?.name }}</TD>
          </a-col>

          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>カナ氏名</th>
            <TD>{{ headerInfo?.kname }}</TD>
          </a-col>

          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>性別</th>
            <TD>{{ headerInfo?.sex }}</TD>
          </a-col>

          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>生年月日</th>
            <TD>{{ headerInfo?.bymd }}</TD>
          </a-col>

          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>住民区分</th>
            <TD>{{ headerInfo?.juminkbn }}</TD>
          </a-col>

          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>年齢</th>
            <TD>{{ headerInfo?.age }}</TD>
          </a-col>
          <a-col span="6" :sm="12" :xl="12" :xxl="6">
            <th>年齢計算基準日</th>
            <TD>{{ headerInfo?.agekijunymd }}</TD>
          </a-col>
        </a-row>
        <div class="m-t-1 flex justify-between">
          <a-space>
            <a-button
              v-if="addFlg || updFlg"
              key="submit"
              style="float: left"
              type="warn"
              @click="onSubmit"
              >登録</a-button
            >
            <a-button type="primary" @click="forwardSearch">一覧へ</a-button>
          </a-space>
          <a-space>
            <WarnAlert />
            <ClosePage />
          </a-space>
        </div>
      </div>
    </a-card>
    <a-card :bordered="false" class="mt-3">
      <a-row>
        <a-select
          v-model:value="filterParams.gyomukbnnm"
          style="width: 150px"
          :options="selectorlist"
        ></a-select>
      </a-row>
      <a-row class="mt-2">
        <a-space class="mb-2">
          <a-button type="primary" class="btn-round" @click="() => handleTaisyogaikbn(false)"
            >すべて発行対象</a-button
          >
          <a-button type="primary" class="btn-round" @click="() => handleTaisyogaikbn2(true)"
            >すべて発行対象外</a-button
          >
        </a-space>
      </a-row>
      <vxe-table
        ref="xTableRef"
        :height="tableHeight - 50 - height"
        :loading="loading"
        :column-config="{ resizable: true }"
        :row-config="{ keyField: 'atenano', isCurrent: true, isHover: true }"
        :data="filterData"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column
          header-class-name="bg-editable"
          field="taisyogaikbn"
          title="対象外者区分"
          width="160"
          min-width="100"
        >
          <template #default="{ row }">
            <a-switch
              v-if="addFlg || updFlg"
              v-model:checked="row.taisyogaikbn"
              checked-children="発行対象外"
              un-checked-children="発行対象"
              @change="(value) => handleChange(value, row)"
            />
          </template>
        </vxe-column>
        <vxe-column field="gyomukbnnm" title="業務" width="160" min-width="100"> </vxe-column>
        <vxe-colgroup title="帳票グループ">
          <vxe-column field="rptgroupid" :resizable="false" header-class-name="group">
            <template #header> </template>
            <template #default="{ row }">{{ row.rptgroupid }}</template>
          </vxe-column>
          <vxe-column field="rptgroupnm" :resizable="false" header-class-name="group"
            ><template #header></template>
            <template #default="{ row }">{{ row.rptgroupnm }}</template>
          </vxe-column>
        </vxe-colgroup>

        <vxe-column
          :header-class-name="isEditable ? 'bg-editable' : ''"
          field="uketukeymd"
          title="受付日"
          width="215"
          min-width="150"
          :class-name="({ row }) => (row.taisyogaikbn && !row.uketukeymd ? 'bg-errorcell' : '')"
        >
          <template #header>
            受付日<span v-show="isEditable" class="request-mark">＊</span>
          </template>
          <template #default="{ row }">
            <date-jp
              v-model:value="row.uketukeymd"
              unknown
              format="YYYY-MM-DD"
              style="width: 190px"
              :disabled="!row.taisyogaikbn"
            />
          </template>
        </vxe-column>
        <vxe-column
          :header-class-name="isEditable ? 'bg-editable' : ''"
          field="taisyogairiyu"
          title="対象外理由"
          width="500"
          min-width="200"
          :show-overflow="false"
        >
          <template #default="{ row }">
            <a-textarea
              v-model:value="row.taisyogairiyu"
              :disabled="!row.taisyogaikbn"
              :maxlength="1000"
              :auto-size="{ minRows: 2 }"
            ></a-textarea>
            <div class="show_count_box">
              {{ `${row.taisyogairiyu?.length ?? 0} / 1000` }}
            </div>
          </template>
        </vxe-column>
      </vxe-table>
    </a-card>
    <OperationFooter ref="footerRef" :atenano="atenano" />
  </a-spin>
</template>
<script setup lang="ts">
import { ref, onMounted, computed, reactive, watch } from 'vue'
import { useRoute, useRouter, onBeforeRouteUpdate } from 'vue-router'
import { message, Form } from 'ant-design-vue'
import { useElementSize } from '@vueuse/core'
import { InitVM } from '../type'
import { Init, Save } from '../service'
import { Enum名称区分 } from '#/Enums'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal, showDeleteModal } from '@/utils/modal'
import { useBoolean, useTableHeight, useTableFilter } from '@/utils/hooks'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { table2Opts } from '@/utils/util'
import emitter from '@/utils/event-bus'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { Judgement } from '@/utils/judge-edited'
import dayjs from 'dayjs'
import { VxeTableInstance } from 'vxe-table'

const route = useRoute()
const router = useRouter()
const updFlg = route.meta.updflg
const addFlg = route.meta.addflg
const atenano = route.query.atenano as string
const editJudge = new Judgement(route.name as string)
const loading = ref<boolean>(false)
const xTableRef = ref<VxeTableInstance>()

//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)
const footerRef = ref(null)
const { height } = useElementSize(footerRef)

const filterParams = reactive({
  gyomukbnnm: ''
})

const headerInfo = ref<GamenHeaderBaseVM>()
const selectorlist = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const kekkalist = ref<InitVM[]>([])
let { filterData } = useTableFilter(kekkalist, filterParams)

const isEditable = computed(() => {
  if (kekkalist.value.length === 0) return false
  return kekkalist.value.some((item) => item.taisyogaikbn)
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(kekkalist, () => editJudge.setEdited(), { deep: true })
onMounted(() => {
  editJudge.addEvent()
  if (atenano) {
    loading.value = true
    Init({ atenano, kbn: Enum名称区分.名称 })
      .then((res) => {
        headerInfo.value = res.headerinfo
        selectorlist.value = table2Opts(res.kekkalist, 'gyomukbnnm')
        kekkalist.value = res.kekkalist
      })
      .finally(() => {
        editJudge.reset()
        loading.value = false
      })
  }
})

const handleTaisyogaikbn = (flag: boolean) => {
  filterData.value.forEach((item) => {
    item.taisyogaikbn = flag
    item.uketukeymd = ''
  })
}

const handleTaisyogaikbn2 = (flag: boolean) => {
  filterData.value.forEach((item) => {
    if (item.taisyogaikbn === false) {
      item.taisyogaikbn = flag
      item.uketukeymd = dayjs().format('YYYY-MM-DD')
    }
  })
}

const onSubmit = () => {
  const tableData: InitVM[] = xTableRef.value?.getTableData().tableData ?? []

  const filterList = tableData.filter((item) => item.taisyogaikbn && !item.uketukeymd)

  if (filterList.length > 0) {
    return
  }

  const tableList = tableData.filter((item) => item.taisyogaikbn && item.uketukeymd)

  const savelist = tableList.map((item) => ({
    uketukeymd: item.uketukeymd,
    taisyogairiyu: item.taisyogairiyu,
    rptgroupid: item.rptgroupid,
    upddttm: item.upddttm
  }))

  const locklist = tableData
    .filter((item) => item.upddttm)
    .map((item) => ({
      rptgroupid: item.rptgroupid,
      upddttm: item.upddttm
    }))

  showSaveModal({
    onOk: async () => {
      Save({ atenano, savelist, locklist }).then(() => {
        message.success(SAVE_OK_INFO.Msg)
        emitter.emit('changeStatus', atenano)
        editJudge.reset()
        forwardSearch()
      })
    }
  })
}

const forwardSearch = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  })
}

const handleChange = (value, row) => {
  if (value === false) {
    row.uketukeymd = ''
  } else {
    row.uketukeymd = dayjs().format('YYYY-MM-DD')
  }
}
</script>

<style lang="less" scoped>
th {
  width: 180px;
}

:deep(.vxe-header--column.group) {
  padding: 0 !important;
}
</style>
