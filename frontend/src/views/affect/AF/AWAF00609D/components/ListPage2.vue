<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: フォロー管理(内容画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.28
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <div :bordered="false">
      <Header :data="header" />
      <div class="absolute right-6 top-40">
        <WarnAlert v-if="header?.keikoku" />
      </div>
    </div>
    <a-card class="mt-4">
      <div class="font-bold mb-1">フォロー内容情報一覧</div>
      <div class="flex mb-2 justify-between">
        <a-button type="primary" :disabled="!canAdd" @click="forwardResultPage">新規</a-button>
        <div class="ml-2 flex flex-wrap gap-2">
          <div class="flex-1 flex items-center">
            <span class="w-15">把握経路</span>
            <a-select
              v-model:value="filterParams.haakukeiro"
              :options="haakukeiroList"
              class="w-26 ml-1"
            />
          </div>
          <div class="flex-1 flex items-center">
            <span class="w-15">把握事業</span>
            <a-select
              v-model:value="filterParams.haakujigyocd"
              :options="haakujigyoList"
              class="w-26 ml-1"
            />
          </div>
          <div class="flex-1 flex items-center">
            <span class="w-22">フォロー状況</span>
            <a-select
              v-model:value="filterParams.followstatus"
              :options="followstatusList"
              class="w-26 ml-1"
            />
          </div>
          <div class="flex-1 flex items-center">
            <span class="w-22">フォロー事業</span>
            <a-select
              v-model:value="filterParams.followjigyocd"
              :options="followjigyoList"
              class="w-26 ml-1"
            />
          </div>
        </div>
      </div>
      <vxe-table
        :height="510"
        :loading="loading"
        :data="filterData"
        :scroll-y="{ enabled: true, oSize: 10 }"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :empty-render="{ name: 'NotData' }"
        :sort-config="{ trigger: 'cell' }"
        @cell-dblclick="({ row }) => forwardResultPage(row)"
      >
        <vxe-column
          field="follownaiyoedano"
          title="フォロー内容枝番"
          width="120"
          min-width="80"
          sortable
        >
          <template #default="{ row }">
            <a @click="forwardResultPage(row)">{{ row.follownaiyoedano }}</a>
          </template>
        </vxe-column>
        <vxe-column field="haakukeiro" title="把握経路" width="100" min-width="60" sortable />
        <vxe-column field="haakujigyocd" title="把握事業" min-width="100" sortable />
        <vxe-column field="follownaiyo" title="フォロー内容" min-width="100" sortable />
        <vxe-column field="followstatus" title="フォロー状況" min-width="100" sortable />
        <vxe-column field="followjigyocd" title="フォロー事業" min-width="100" sortable />
        <vxe-colgroup title="フォロー予定情報" align="center">
          <vxe-column field="followyoteiymd" title="予定日" min-width="80" sortable></vxe-column>
          <vxe-column
            field="followtm_yotei"
            title="時間"
            min-width="80"
            formatter="splitTime"
            sortable
          ></vxe-column>
          <vxe-column field="followkaijocd_yotei" title="会場" min-width="80" sortable />
          <vxe-column field="followstaffid_yotei" title="担当者" min-width="80" sortable />
        </vxe-colgroup>
        <vxe-colgroup title="フォロー結果情報" align="center">
          <vxe-column field="followjissiymd" title="実施日" min-width="80" sortable></vxe-column>
          <vxe-column
            field="followtm"
            title="時間"
            min-width="80"
            formatter="splitTime"
            sortable
          ></vxe-column>
          <vxe-column field="followkaijocd" title="会場" min-width="80" sortable></vxe-column>
          <vxe-column field="followstaffid" title="担当者" min-width="80" sortable />
        </vxe-colgroup>
      </vxe-table>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { Enum共通バー番号, PageSatatus } from '#/Enums'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { useTableFilter } from '@/utils/hooks'
import { getBarKengen } from '@/utils/user'
import { table2Opts } from '@/utils/util'
import { RowFollowContentVM } from '@/views/affect/KK/AWKK00401G/type'
import { computed, onMounted, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'
import { SearchFollowNaiyoList } from '../service'
import Header from './Header.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  header: CommonBarHeaderBase3VM | null
}>()
const emit = defineEmits(['update:header', 'update:status', 'update:follownaiyoedano'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const tableList = ref<RowFollowContentVM[]>([])

//新规権限フラグ
const kengen = computed(() => getBarKengen(Enum共通バー番号.フォロー管理))
const canAdd = computed(() => kengen.value.addflg)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  searchData()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const forwardResultPage = (val) => {
  emit('update:follownaiyoedano', val.follownaiyoedano ?? -1)
  emit('update:status', PageSatatus.Edit)
}

const searchData = async () => {
  loading.value = true
  try {
    const res = await SearchFollowNaiyoList({
      atenano: route.query.atenano as string,
      patternno: route.query.patternno as string
    })
    emit('update:header', res.headerinfo)
    tableList.value = res.kekkalist

    haakukeiroList.value = table2Opts(res.kekkalist, 'haakukeiro')
    haakujigyoList.value = table2Opts(res.kekkalist, 'haakujigyocd')
    followstatusList.value = table2Opts(res.kekkalist, 'followstatus')
    followjigyoList.value = table2Opts(res.kekkalist, 'followjigyocd')
  } catch (error) {}
  loading.value = false
}

//フィルター----------------------------------------------------------------------------------
const filterParams = reactive({
  haakukeiro: '', //把握経路
  haakujigyocd: '', //把握事業
  followstatus: '', //フォロー状況
  followjigyocd: '' //フォロー事業
})
const haakukeiroList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const haakujigyoList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const followstatusList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const followjigyoList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])

const { filterData } = useTableFilter(tableList, filterParams)
//----------------------------------------------------------------------------------

defineExpose({ forwardResultPage })
</script>
