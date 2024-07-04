<template>
  <div>
    <div ref="headRef">
      <a-row>
        <a-space>
          <a-button
            type="primary"
            :disabled="!addFlg"
            @click="forwardNext(Enum保健指導業務区分.母子保健)"
          >
            新規（母子保健）
          </a-button>
          <a-button
            type="primary"
            :disabled="!addFlg"
            @click="forwardNext(Enum保健指導業務区分.成人保健)"
          >
            新規（成人保健）
          </a-button>
        </a-space>
      </a-row>
      <a-row class="mt-3">
        <a-col>
          業務<a-select
            v-model:value="filterParams.gyomunm"
            class="ml-2 w-50!"
            :options="gyomuOptions"
          />
        </a-col>
        <a-col class="ml-5">
          事業コード<a-select
            v-model:value="filterParams.jigyonm"
            class="ml-2 w-50!"
            :options="jigyoOptions"
          />
        </a-col>
      </a-row>
    </div>

    <div class="mt-3">
      <vxe-table
        :loading="loading"
        :height="Math.max(tableHeight, 400)"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="filterData"
        :empty-render="{ name: 'NotData' }"
        @cell-click="({ row }) => forwardNext(Enum保健指導業務区分[`${row.gyomunm}`], row.edano)"
      >
        <vxe-column field="gyomunm" title="業務" width="150"> </vxe-column>
        <vxe-column field="jigyonm" title="事業コード" min-width="180"> </vxe-column>
        <vxe-colgroup title="申込情報" align="center">
          <vxe-column field="yoteiymd" title="実施予定日" width="150"> </vxe-column>
          <vxe-column field="yoteitm" title="予定開始時間" width="150"> </vxe-column>
          <vxe-column field="yoteikaijo" title="実施場所" width="150"> </vxe-column>
          <vxe-column field="yoteisya" title="予定者" width="150"> </vxe-column>
        </vxe-colgroup>
        <vxe-colgroup title="結果情報" align="center">
          <vxe-column field="jissiymd" title="実施日" width="150" />
          <vxe-column field="jissitm" title="実施時間" width="150" />
          <vxe-column field="nenrei" title="実施日時点年齢" width="150" />
          <vxe-column field="jissisya" title="実施者" width="150" />
        </vxe-colgroup>
      </vxe-table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Enum保健指導業務区分, PageSatatus } from '#/Enums'
import { A000003 } from '@/constants/msg'
import { useTableFilter, useTableHeight } from '@/utils/hooks'
import { showInfoModal } from '@/utils/modal'
import { table2Opts } from '@/utils/util'
import { onMounted, reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { SearchSetaiDetail } from '../service'
import { SearchPersonDetailRequest, ShidouInfoListVM } from '../type'
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const props = defineProps<{
  params: Omit<SearchPersonDetailRequest, keyof DaRequestBase | 'mosikomikekkakbn'> & {
    status: PageSatatus
  }
}>()
const emit = defineEmits(['emitHeader'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const loading = ref(false)
const router = useRouter()
const route = useRoute()
const atenano = route.query.atenano as string
const gyomuOptions = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const jigyoOptions = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const tableList = ref<ShidouInfoListVM[]>([])

const filterParams = reactive({
  jigyonm: '', //業務
  gyomunm: '' //事業コード
})
const { filterData } = useTableFilter(tableList, filterParams)

const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -154)

const addFlg = route.meta.addflg
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => init(true))

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const init = (showAlert: boolean) => {
  loading.value = true
  SearchSetaiDetail({
    atenano,
    hokensidokbn: props.params.hokensidokbn
  })
    .then((res) => {
      jigyoOptions.value = table2Opts(res.shidouinfolist, 'jigyonm')
      gyomuOptions.value = [
        { label: 'すべて', value: '' },
        ...res.gyomulist.map((item) => ({ label: item.label, value: item.label }))
      ]
      tableList.value = res.shidouinfolist
      emit('emitHeader', res.personalheaderinfo)
      if (res.personalheaderinfo.keikoku && showAlert) {
        showInfoModal({
          type: 'warning',
          content: A000003.Msg.replace('{0}', res.personalheaderinfo.keikoku)
        })
      }
    })
    .finally(() => (loading.value = false))
}

const forwardNext = (gyomukbn: Enum保健指導業務区分, edano = 0) => {
  props.params.status = PageSatatus.Detail
  props.params.gyomukbn = String(gyomukbn)
  props.params.edano = edano
  router.push({
    name: 'AWKK00301G',
    query: {
      ...route.query,
      patternno: String(gyomukbn)
    }
  })
}

defineExpose({ init })
</script>

<style lang="less" scoped></style>
