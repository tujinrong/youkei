<template>
  <div>
    <div class="self_adaption_table form" style="width: 100%">
      <a-row>
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="bg-readonly">帳票グループ名</th>
          <TD>{{ form.rptgroupnm }}</TD>
        </a-col>
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="bg-readonly">業務</th>
          <TD>
            {{ form.gyoumu }}
          </TD>
        </a-col>
      </a-row>
      <a-row>
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="bg-readonly">
            <span>{{
              yosikihouhou == Enum様式作成方法.データソース
                ? 'データソース名称'
                : 'プロシージャ名称'
            }}</span>
          </th>
          <TD>{{ procnmOrDatasourcenm }}</TD>
        </a-col>
        <a-col :md="12" :xl="9" :xxl="6">
          <th>並びシーケンス</th>
          <td>
            <a-input-number v-model:value="form.orderseq" :max="99999" :min="0" class="w-full" />
          </td>
        </a-col>
      </a-row>
    </div>

    <div class="self_adaption_table form" style="width: 100%">
      <a-row class="my-4">
        <a-col :md="8" :xl="8" :xxl="6">
          <th>宛名フラグ</th>
          <td>
            <a-checkbox v-model:checked="form.atenaflg" @change="buttonClear"></a-checkbox>
          </td>
        </a-col>
        <a-col :md="8" :xl="8" :xxl="6">
          <th>妊産婦フラグ</th>
          <td>
            <a-checkbox v-model:checked="form.ninsanpuflg" @change="buttonClear"></a-checkbox>
          </td>
        </a-col>
        <a-col :md="8" :xl="8" :xxl="6">
          <th>抽出パネル表示</th>
          <td>
            <a-checkbox
              v-model:checked="form.tyusyutupanelflg"
              @change="onChangeTyusyutupanelflg"
            ></a-checkbox>
          </td>
        </a-col>
        <a-col v-show="!form.tyusyutupanelflg" :md="8" :xl="8" :xxl="6">
          <th>様式紐づけ条件</th>
          <td>
            <ai-select
              v-model:value="form.yosikihimonm"
              :options="jokenlist"
              split-val
              @change="yosikihimonmChange"
            ></ai-select>
          </td>
        </a-col>
        <a-col span="24">
          <th>固定様式</th>
          <td>
            <a-space class="flex-wrap">
              <a-checkbox v-model:checked="form.addresssealflg" :disabled="!form.atenaflg"
                >アドレスシール</a-checkbox
              >
              <a-checkbox v-model:checked="form.barcodesealflg" :disabled="!form.atenaflg"
                >バーコード</a-checkbox
              >
              <a-checkbox v-model:checked="form.hagakiflg" :disabled="!form.atenaflg"
                >はがき</a-checkbox
              >
              <a-checkbox v-model:checked="form.atenadaityoflg" :disabled="!form.atenaflg"
                >宛名台帳</a-checkbox
              >
              <a-checkbox v-model:checked="form.kensuhyonenreiflg" :disabled="!form.atenaflg"
                >件数表(年齢別)</a-checkbox
              >
              <a-checkbox v-model:checked="form.kensuhyogyoseikuflg" :disabled="!form.atenaflg"
                >件数表(行政区別)</a-checkbox
              >
            </a-space>
          </td>
        </a-col>
      </a-row>
      <a-row v-if="yosikihouhou == Enum様式作成方法.データソース">
        <a-col span="24" style="display: flex; justify-content: flex-end" class="mt-3">
          <a-button type="primary" class="btn-round" @click="handleFixed">固定条件追加</a-button>
        </a-col>
      </a-row>
      <a-row v-if="yosikihouhou == Enum様式作成方法.データソース">
        <a-col span="24">
          <th>固定条件</th>
          <td>
            <a-checkbox-group
              v-model:value="form.jyokenLabels"
              name="checkboxgroup"
              :options="fixedconditionlist"
            />
          </td>
        </a-col>
      </a-row>

      <a-row>
        <a-col span="24">
          <th>帳票説明</th>
          <td>
            <a-input v-model:value="form.rptbiko" maxlength="500" />
          </td>
        </a-col>
      </a-row>

      <div v-if="isSqlOrFunc" class="mt-4">
        <div style="display: flex; justify-content: space-between" class="mb-1">
          <div style="flex: 1; display: flex; align-items: center">
            <span> {{ props.yosikihouhou == Enum様式作成方法.SQL ? 'SQL' : 'プロシージャ' }}</span>
            <div v-if="yosikihouhou == Enum様式作成方法.プロシージャ" class="ml-4">
              <a-input
                v-if="isAdd"
                :value="form.procnm"
                disabled
                :addon-before="ADDON_TEXT"
                style="width: 270px"
              />
              <a-input v-else :value="form.procnm" disabled style="width: 270px" />
            </div>
          </div>
          <a-space>
            <a-button
              shape="round"
              size="small"
              type="primary"
              :style="{ float: 'right' }"
              tabindex="-1"
              :disabled="sqlDisabled"
              @click="
                () => (props.yosikihouhou == Enum様式作成方法.SQL ? formateSql() : formateFunc())
              "
              >編集完了</a-button
            >
          </a-space>
        </div>
        <div style="border: 1px solid">
          <codemirror v-model="form.sql" v-bind="sqlProgamConfig" />
        </div>
      </div>
    </div>
    <SearchModal
      ref="searchModalRef"
      v-model:visible="editVisible"
      v-model:loading="loading"
      :groupid="datasourceid"
      @get-table-data="getFixedOption"
    />
  </div>
</template>

<script setup lang="ts">
import { reactive, watch, nextTick, ref, Ref, watchEffect } from 'vue'
import { useRoute } from 'vue-router'
import { Enum帳票様式, Enum検索条件区分, Enum様式作成方法 } from '#/Enums'
import { Codemirror } from 'vue-codemirror'
import { Judgement } from '@/utils/judge-edited'
import { ReportTabInfoVM } from '../../type'
import { sqlProgamConfig } from './constants'
import { EUCStore, GlobalStore } from '@/store'
import { ParseAndFormatProcedure, ParseAndFormatSql, SearchReportTab } from '../../service'
import TD from '@/components/Common/TableTD/index.vue'
import emitter from '@/utils/event-bus'
import { computed } from 'vue'
import { E064014, I060001, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { message } from 'ant-design-vue'
import { showInfoModal } from '@/utils/modal'
import SearchModal from '@/views/affect/EU/AWEU00106D/index.vue'
import { SearchOtherConditionTab } from '@/views/affect/EU/AWEU00101G/service'

type formType = ReportTabInfoVM & {
  gyoumu: string
  rptnm: string
  rptdatasourceid?: string
  procedure?: string
  datasourceid: string
  datasourcenm: string
  procnm: string
  sql: string
}

const props = defineProps<{
  rptgroupnmOptions: DaSelectorModel[]
  jokenOptions: DaSelectorModel[]
  rptid: string
  yosikihouhou: Enum様式作成方法
  datasourceid: string
  yosikiid: string
  yosikieda: number
  editJudge: Judgement
  kbn: Enum帳票様式 | string
  datasourcenm: string
  procnm: string
  sql: string
  tab4Ref: Ref
}>()
const ADDON_TEXT = 'ft_'
const sqlDisabled = ref(false)
const routes = useRoute()
const isNew = Boolean(routes.query.isNew)
const jokenlist = computed(() => {
  if (props.tab4Ref.value) {
    return props.tab4Ref.value?.getJokenOptions()
  }
  return props.jokenOptions
})
const upddttm = ref()
const route = useRoute()
const editVisible = ref(false)
const loading = ref(false)
const fixedconditionlist = ref<DaSelectorModel[]>([])
const jyokenLabellist = ref<DaSelectorModel[]>([])
const searchModalRef = ref<InstanceType<typeof SearchModal> | null>(null)
function createDefaultForm(): formType {
  return {
    gyoumu: '',
    datasourcenm: '',
    rptgroupnm: '',
    rptgroupid: '',
    rptnm: '',
    rptbiko: '',
    atenaflg: false,
    ninsanpuflg: false,
    addresssealflg: false,
    barcodesealflg: false,
    hagakiflg: false,
    atenadaityoflg: false,
    kensuhyonenreiflg: false,
    kensuhyogyoseikuflg: false,
    yosikihimonm: '',
    datasourceid: '',
    procedure: '',
    procnm: '',
    sql: '',
    orderseq: undefined,
    tyusyutupanelflg: false,
    jyokenLabels: [] // 固定条件
  }
}

const form = reactive<formType>(createDefaultForm())
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const procnmOrDatasourcenm = computed(() => {
  if (props.yosikihouhou == Enum様式作成方法.データソース) {
    return props.datasourcenm
  } else {
    return props.procnm
  }
})
const isSqlOrFunc = computed(
  () =>
    props.yosikihouhou == Enum様式作成方法.SQL ||
    props.yosikihouhou == Enum様式作成方法.プロシージャ
)
//新規プロシージャ
const isAdd = computed(() => {
  return (
    isNew && Number(props.kbn) === Enum帳票様式.帳票 && EUCStore['201_params'].procnm == '新規作成'
  )
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(form, () => props.editJudge.setEdited(), { deep: true })

//編集時formに値を割り当てる
watch(
  () => [props.rptid, props.yosikiid, props.yosikieda, props.datasourceid],
  () => {
    if (isNew && Number(props.kbn) === Enum帳票様式.帳票) return
    if (
      props.rptid &&
      props.yosikiid &&
      (props.yosikihouhou == Enum様式作成方法.プロシージャ || props.datasourceid)
    ) {
      const params = {
        rptid: props.rptid,
        yosikiid: props.yosikiid,
        yosikieda: props.yosikieda,
        datasourceid: props.datasourceid
      }
      // GlobalStore.setLoading(true)
      SearchReportTab(params).then((res) => {
        const jyokenLabels = res.jyokenLabellist
          .filter((item) => {
            return (
              res.rptDetailParam.jyokenLabels.findIndex(
                (child) => String(child.jyokenid) === String(item.value)
              ) > -1
            )
          })
          .map((item) => item.value)
        Object.assign(form, { ...res.rptDetailParam, jyokenLabels: jyokenLabels })
        jyokenLabellist.value = res.jyokenLabellist
        upddttm.value = res.upddttm
        nextTick(() => props.editJudge.reset())
      })
      // .finally(() => GlobalStore.setLoading(false))
    }
  }
)
watch(
  () => props.datasourceid,
  (newValue) => {
    getFixedOption(newValue)
  }
)

watch(
  () => form.yosikihimonm,
  (newValue) => {
    EUCStore['yosikihimonm'] = newValue
  },
  {
    immediate: true
  }
)

watchEffect(() => {
  if (props.yosikihouhou == Enum様式作成方法.プロシージャ && !isAdd.value) {
    form.procnm = props.procnm
    form.sql = props.sql
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//編集完了
const formateFunc = () => {
  // if (EUCStore.defineItems.length > 0) {
  //   message.error(E064014.Msg.replace('{0}', 'プロジェクト行').replace('{1}', 'プロシージャの解析'))
  //   return
  // }
  if (isAdd.value && !form.sql.trim()) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'プロシージャ')
    })
    return
  }
  ParseAndFormatProcedure({
    mainprocedurenm: props.datasourcenm,
    procedurenm:
      props.yosikihouhou == Enum様式作成方法.プロシージャ
        ? form.procnm.startsWith(ADDON_TEXT)
          ? form.procnm
          : ADDON_TEXT + form.procnm
        : '',
    kbn: Number(props.kbn),
    sql: form.sql,
    itemlist: EUCStore.defineItems,
    conditionlist: EUCStore.conditionlist,
    rptid: props.rptid
  }).then((res) => {
    form.procnm = isAdd.value ? res.procedurenm.slice(3) : res.procedurenm
    handleSqlOrFunc(res)
  })
}

const formateSql = () => {
  if (EUCStore.defineItems.length > 0) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E064014.Msg.replace('{0}', 'プロジェクト行').replace('{1}', 'SQLの解析')
    })
    return
  }
  ParseAndFormatSql({
    sql: form.sql,
    itemlist: EUCStore.defineItems,
    conditionlist: EUCStore.conditionlist
  }).then((res) => {
    handleSqlOrFunc(res)
  })
}

const handleSqlOrFunc = (res) => {
  form.sql = res.sql
  emitter.emit(
    'conditionlist',
    res.conditionlist?.map((item) => ({ ...item, canEddit: true }))
  )
  emitter.emit('itemlist', res.itemlist)
  //sqlDisabled.value = true
  message.success(I060001.Msg)
}
//新規時formに値を割り当てる
const setFieldsValue = (data) => {
  Object.assign(form, data)
  form.procnm = data.procnm == '新規作成' ? '' : data.procnm
}

//固定条件
const handleFixed = () => {
  editVisible.value = true
  loading.value = true
  searchModalRef.value?.setEddit({ jyokenkbn: String(Enum検索条件区分.固定条件) })
  setTimeout(() => (loading.value = false), 500)
}
const getFixedOption = (datasourceid = props.datasourceid) => {
  SearchOtherConditionTab({ datasourceid, status: 'fixedCondition' }).then((res) => {
    fixedconditionlist.value = res.fixedconditionlist.map((item) => ({
      label: item.jyokenlabel,
      value: String(item.jyokenid)
    }))
  })
}
const getFieldsValue = () => {
  return {
    ...form,
    datasourceid: form.datasourceid || form.rptdatasourceid,
    datasourcenm: procnmOrDatasourcenm.value,
    procnm:
      props.yosikihouhou == Enum様式作成方法.プロシージャ
        ? form.procnm.startsWith(ADDON_TEXT) || !isAdd.value
          ? form.procnm
          : ADDON_TEXT + form.procnm
        : '',
    sql: form.sql,
    jyokenLabels: (props.yosikieda <= -1 || (isNew && props.kbn == Enum帳票様式.帳票)
      ? fixedconditionlist.value
      : jyokenLabellist.value
    )
      .filter((item) => form.jyokenLabels.findIndex((child) => String(child) === item.value) > -1)
      .map((item) => ({
        jyokenlabel: item.label,
        jyokenid: item.value,
        datasourceid: props.datasourceid
      }))
  }
}
//様式紐付け値
const yosikihimonmChange = () => {
  emitter.emit('escapeValidate')
}
emitter.once('cleanValue', () => {
  form.yosikihimonm = undefined
})

const buttonClear = () => {
  if (!form.atenaflg) {
    const keys = [
      'addresssealflg',
      'barcodesealflg',
      'hagakiflg',
      'atenadaityoflg',
      'kensuhyonenreiflg',
      'kensuhyogyoseikuflg'
    ]
    keys.forEach((key) => (form[key] = false))
  }
}

function onChangeTyusyutupanelflg() {
  form.yosikihimonm = ''
  yosikihimonmChange()
}

defineExpose({
  setFieldsValue,
  getFieldsValue,
  upddttm
})
</script>

<style lang="less" scoped>
th {
  width: 130px;
}

.yosiki {
  :deep(.ant-space-item:nth-child(2)) {
    width: 100%;
  }
}
</style>
