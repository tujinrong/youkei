<template>
  <a-modal
    :visible="visible"
    title="確認"
    width="700px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    @cancel="closeOutput"
  >
    <h4>{{ exportMethod }}を出力しますか？</h4>
    <a-row class="description-table">
      <table>
        <tbody>
          <tr>
            <th style="width: 140px">ファイル名<span class="request-mark">＊</span></th>
            <td>
              <a-form-item v-bind="validateInfos.outputfilenm">
                <a-input v-model:value="form.outputfilenm"></a-input>
              </a-form-item>
            </td>
          </tr>
        </tbody>
      </table>
    </a-row>
    <a-row class="ml-12 mt-4 flex items-center">
      <a-checkbox v-model:checked="form.jyokensheetflg" style="width: 200px"
        >条件シート出力</a-checkbox
      >
      <div v-if="isSeal">
        <date-jp v-model:value="outPutInfo.printdate" format="YYYY-MM-DD" class="w-42! ml-2" />
        <span>発行</span>
        <a-input-number
          v-model:value="outPutInfo.startdetailcount"
          :min="1"
          :precision="0"
          class="w-16"
        />
        <span>枚目から</span>
      </div>
    </a-row>
    <a-row class="ml-12 mt-4">
      <a-checkbox
        v-model:checked="form.sqljikkoflg"
        :disabled="!permissionsInfo.updateflg"
        style="width: 200px"
        >更新プロシージャ</a-checkbox
      >
      <a-checkbox
        v-if="!(permissionsInfo.rirekiupdkbn == Enum発行履歴区分.非表示.toString())"
        v-model:checked="form.rirekiupdflg"
        :disabled="!permissionsInfo.hakoflg"
        style="width: 200px"
        >帳票発行履歴更新</a-checkbox
      >
    </a-row>
    <template #footer>
      <a-space class="float-left">
        <a-button type="primary" @click="onPreview">プレビュー</a-button>
        <a-button type="primary" @click="timeVisible = true">バッチ処理</a-button>
        <a-button :loading="loading" type="primary" @click="download">ダウンロード</a-button>
      </a-space>
      <a-button type="primary" @click="closeOutput">閉じる</a-button>
    </template>
  </a-modal>

  <a-modal
    v-model:visible="timeVisible"
    title="バッチ処理"
    width="500px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    @cancel="closeBatch"
  >
    <a-radio-group
      v-model:value="outputTime"
      :options="outputOptions"
      @change="
        () => {
          if (outputTime === BachSettingEnums.指定された時刻) time = ''
        }
      "
    />

    <div v-if="outputTime === BachSettingEnums.指定された時刻">
      <a-row class="description-table mt-3">
        <table>
          <tbody>
            <tr>
              <th style="width: 100px">時間</th>
              <td>
                <DateTime
                  v-model:value="time"
                  :hanif="dayjs().format('YYYY-MM-DD HH:mm:ss')"
                  :hanit="dayjs().format('YYYY-MM-DD') + '23:59:59'"
                />
              </td>
            </tr>
          </tbody>
        </table>
      </a-row>
    </div>
    <template #footer>
      <a-button
        type="primary"
        class="warning-btn"
        style="float: left"
        :disabled="outputTime === BachSettingEnums.指定された時刻 ? !time : false"
        @click="addJob"
        >登録</a-button
      >
      <a-button type="primary" @click="closeBatch">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { EnumReportType } from '#/Enums'
import DateTime from '@/components/Selector/DateTime/index.vue'
import {
  DOWNLOAD_OK_INFO,
  E064010,
  E001010,
  ITEM_REQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import DetailSearchDrawer from '@/views/affect/EU/AWEU00301G/components/DataDetail/components/DetailSearch.vue'
import { message } from 'ant-design-vue'
import { useForm } from 'ant-design-vue/lib/form'
import dayjs from 'dayjs'
import { computed, reactive, ref, watch, watchEffect } from 'vue'
import { YosikiInfo } from '../AWEU00301G/type'
import { outputOptions } from './constants'
import { AddBatchJob, Download } from './service'
import { showSaveModal } from '@/utils/modal'
import { koteiyoshiki } from '../AWEU00301G/components/DataDetail/constants'
import { GlobalStore } from '@/store'
enum BachSettingEnums {
  現在の時刻 = '1',
  指定された時刻 = '2'
}

const props = defineProps<{
  visible: boolean
  exportMethod: string
  workseq: number // ワークシーケンス
  rptid: string // 帳票ID
  yosikiid: string // 様式ID
  jyokenlist: KensakuJyokenVM[] // 検索条件
  outputtype: EnumReportType // 出力方式
  name: string
  memo: string // 検索条件メモ
  permissionsInfo: YosikiInfo
  hakusiflg: boolean // 白纸
  searchDrawerRef: InstanceType<typeof DetailSearchDrawer> | null
  atenaflg: boolean
  selectedatenanolist: string[]
  tyusyutuinfo: TyusyutuVM
}>()
enum Enum発行履歴区分 {
  非表示 = 0,
  表示し_チェックなし,
  表示し_チェック
}
const emit = defineEmits(['update:visible', 'onPreview'])

//ローディング
const loading = ref(false)
const timeVisible = ref(false)
const outputTime = ref(BachSettingEnums.現在の時刻)
const time = ref('')

const createDefaultForm = () => {
  return {
    outputfilenm: '', // 出力名
    rirekiupdflg: false, // 発送履歴テーブル更新
    jyokensheetflg: false, // 条件シート出力
    sqljikkoflg: false // 更新SQL
  }
}

const form = reactive(createDefaultForm())

const rules = computed(() => ({
  outputfilenm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ファイル名') },
    {
      pattern: /^[^<>:"/\\|?*]+$/,
      message: E064010.Msg
    },
    {
      pattern: /^.{0,260}$/,
      message: E001010.Msg.replace('{0}', '260')
    }
  ]
}))

const { validate, validateInfos } = useForm(form, rules)

watch(
  () => [props.name, props.visible],
  ([newValue1]) => {
    const outputName = props.exportMethod.toLocaleLowerCase()
    form.outputfilenm = `${newValue1}_${dayjs().format('YYYYMMDDHHmmss')}.${
      outputName === 'excel' ? 'xlsx' : outputName
    }`
  }
)

const download = async () => {
  const detailjyokenlist = await props.searchDrawerRef?.validateDrawer()
  await validate()
  loading.value = true

  Download({
    ...props,
    ...form,
    detailjyokenlist,
    selectedatenanolist: props.selectedatenanolist,
    outPutInfo: isSeal.value ? outPutInfo : undefined
  })
    .then(() => {
      message.success(DOWNLOAD_OK_INFO.Msg)
    })
    .finally(() => {
      loading.value = false
      closeOutput()
    })
}

const onPreview = async () => {
  const detailjyokenlist = await props.searchDrawerRef?.validateDrawer()

  emit('onPreview', {
    outputtype: EnumReportType[`${props.exportMethod}`],
    detailjyokenlist,
    outPutInfo: isSeal.value ? outPutInfo : undefined,
    ...form
  })

  closeOutput()
}

//出力modal閉じる
const closeOutput = () => {
  emit('update:visible', false)
  Object.assign(form, createDefaultForm())
}

//バッチ処理modal閉じる
const closeBatch = () => {
  timeVisible.value = false
  outputTime.value = BachSettingEnums.現在の時刻
  time.value = ''
}

//バッチ処理
const addJob = async () => {
  const addJobDate =
    outputTime.value === BachSettingEnums.現在の時刻
      ? dayjs().format('YYYY-MM-DD HH:mm:ss')
      : time.value

  // await AddJob({
  //   addJobDate,
  //   rptid: props.rptid ? props.rptid : 0,
  //   outputfilenm: exportName.value,
  //   rirekiflg: isUpdate.value,
  //   conditionlist: EUCStore['301_conditionList'],
  //   sqlconditionlist: EUCStore['301_sqlsearchconditions'],
  //   csvencoding: formatter.value,
  //   selecteddatalist: EUCStore['301_selecteddatalist']
  // } as DownloadAddJobRequest)
  const saveReq = async (checkflg: boolean) => {
    await AddBatchJob({
      ...props,
      ...form,
      outputfilenm: form.outputfilenm.split('.')[0],
      outputtype: EnumReportType[`${props.exportMethod}`],
      detailjyokenlist: [], // todo
      executiontime: addJobDate,
      outPutInfo: isSeal.value ? outPutInfo : undefined,
      checkflg
    })
  }
  await saveReq(true)
  showSaveModal({
    onOk: () => {
      saveReq(false)
      message.success(SAVE_OK_INFO.Msg)
      emit('update:visible', false)
      timeVisible.value = false
    }
  })
}

//発行枚目----------------------------------------------------------------------
const isSeal = computed(() => props.yosikiid === koteiyoshiki.アドレスシール)
const outPutInfo = reactive(createDefaultOutPutInfo())
function createDefaultOutPutInfo(): OutPutInfoVM {
  return {
    printdate: dayjs().format('YYYY-MM-DD'),
    startdetailcount: 1
  }
}
watchEffect(() => {
  if (props.visible) {
    Object.assign(outPutInfo, createDefaultOutPutInfo())
    rirekiupdflgInit(props.permissionsInfo)
  }
})
const rirekiupdflgInit = (permissionsInfo: YosikiInfo) => {
  if (permissionsInfo.rirekiupdkbn) {
    switch (+permissionsInfo.rirekiupdkbn) {
      case Enum発行履歴区分.表示し_チェックなし:
        form.rirekiupdflg = false
        break
      case Enum発行履歴区分.表示し_チェック:
        form.rirekiupdflg = true
        break
      default:
        break
    }
  }
}
//----------------------------------------------------------------------------

defineExpose({ download })
</script>

<style scoped lang="less">
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
