<template>
  <a-modal
    :visible="props.visible"
    title="確認"
    width="700px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    @cancel="closeOutput"
  >
    <h4>CSVを出力しますか？</h4>
    <div class="self_adaption_table form">
      <a-row>
        <a-col span="15">
          <th class="required">ファイル名</th>
          <td>
            <a-form-item v-bind="validateInfos.outputfilenm">
              <a-input v-model:value="form.outputfilenm"></a-input>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="9">
          <th>文字コード</th>
          <td>
            <a-select
              v-model:value="formatterValue"
              :options="formatterOptions"
              class="w-full"
            ></a-select>
          </td>
        </a-col>
      </a-row>
      <a-row class="ml-12 mt-4">
        <a-col span="24" class="flex items-center">
          <a-checkbox v-model:checked="form.csvoutputheader" style="width: 180px"
            >ヘッダータグー出力
          </a-checkbox>
          <div class="flex items-center gap-2 ml-12">
            囲み文字
            <a-select
              v-model:value="form.csvquotation"
              style="width: 250px"
              :options="[
                { label: 'ダブルコーテーション', value: 1 },
                { label: 'シングルコーテーション', value: 2 },
                { label: '混在パターン', value: 3 }
              ]"
            ></a-select>
          </div>
        </a-col>
      </a-row>
      <a-row class="ml-12 mt-4">
        <a-col>
          <a-checkbox v-model:checked="form.sqljikkoflg" :disabled="!permissionsInfo.updateflg"
            >更新プロシージャ</a-checkbox
          >
        </a-col>
        <a-col
          v-if="!(permissionsInfo.rirekiupdkbn == Enum発行履歴区分.非表示.toString())"
          class="ml-21"
        >
          <a-checkbox v-model:checked="form.rirekiupdflg" :disabled="!permissionsInfo.hakoflg"
            >帳票発行履歴更新</a-checkbox
          >
        </a-col>
      </a-row>
      <a-row class="mt-4">
        <a-col span="24" class="flexitems-center">
          <span>パターン</span>
          <a-select
            v-model:value="form.csvpattern"
            :options="csvDataOptions"
            allow-clear
            class="flex-1 ml-2"
          ></a-select>
          <a-button type="primary" @click="onPreview">参照 </a-button>
        </a-col>
      </a-row>
    </div>

    <template #footer>
      <a-button :loading="loading" type="primary" class="float-left" @click="download"
        >ダウンロード</a-button
      >
      <a-button type="primary" @click="closeOutput">閉じる</a-button>
    </template>
  </a-modal>

  <CSVAddModal
    v-model:visible="csvAddVis"
    v-bind="{
      rptid: props.rptid,
      yosikiid: props.yosikiid,
      csvpattern: form.csvpattern
    }"
    @init-data="initData"
  />
</template>

<script setup lang="ts">
import { ArEnumEncoding2 } from '#/Enums'
import { DOWNLOAD_OK_INFO, E001010, E064010, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import DetailSearchDrawer from '@/views/affect/EU/AWEU00301G/components/DataDetail/components/DetailSearch.vue'
import CSVAddModal from '@/views/affect/EU/AWEU00307D/index.vue'
import { Form, message } from 'ant-design-vue'
import dayjs from 'dayjs'
import { computed, reactive, ref, watch } from 'vue'
import { YosikiInfo } from '../AWEU00301G/type'
import { formatterOptions } from './constants'
import { DetailInit, Download } from './service'
import { DownloadRequest } from './type'
import { GlobalStore } from '@/store'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  workseq: number
  rptid: string // 帳票ID
  yosikiid: string // 様式ID
  jyokenlist: KensakuJyokenVM[] // 検索条件
  selecteddatalist: object[] | null // 選択したデータ
  name: string
  memo: string // 検索条件メモ
  permissionsInfo: YosikiInfo
  searchDrawerRef: InstanceType<typeof DetailSearchDrawer> | null
  tyusyutuinfo: TyusyutuVM
}
enum Enum発行履歴区分 {
  非表示 = 0,
  表示し_チェックなし,
  表示し_チェック
}
const formatterValue = ref(ArEnumEncoding2.SHIFT_JIS)
const props = withDefaults(defineProps<Props>(), {
  visible: false
})

const emit = defineEmits(['update:visible'])

const useForm = Form.useForm

//ローディング
const loading = ref(false)
const csvDataOptions = ref<DaSelectorModel[]>([])
const csvAddVis = ref<boolean>(false)

const form = reactive<
  Omit<DownloadRequest, 'workseq' | 'rptid' | 'yosikiid' | 'jyokenlist' | 'memo' | 'tyusyutuinfo'>
>({
  outputfilenm: '', // 出力名
  csvencoding: ArEnumEncoding2.SHIFT_JIS, // 文字セット
  csvbom: false, // bom
  csvoutputheader: true, // CSV出力ヘッダータグ
  csvquotation: false, // CSV出力ダブルクォーテーション
  csvpattern: '', // CSV出力パターン
  sqljikkoflg: false, // 更新SQL
  hakusiflg: false,
  jyokensheetflg: false,
  rirekiupdflg: false
})

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
const { validate, validateInfos, resetFields } = useForm(form, rules)

watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      initData()
    }
  }
)

const initData = () => {
  rirekiupdflgInit(props.permissionsInfo)
  DetailInit({ rptid: props.rptid, yosikiid: props.yosikiid }).then((res) => {
    csvDataOptions.value = res.csvdroplist
    form.csvpattern = res.csvdroplist.map((el) => el.value).includes(String(res.outputptnno))
      ? String(res.outputptnno)
      : ''
  })
}

watch(
  () => [props.name, props.visible],
  ([newValue]) => (form.outputfilenm = `${newValue}_${dayjs().format('YYYYMMDDHHmmss')}.csv`)
)

const onPreview = () => {
  csvAddVis.value = true
}

const download = async () => {
  const detailjyokenlist = await props.searchDrawerRef?.validateDrawer()

  await validate()

  loading.value = true

  //プルダウンリストを選択した後の価の処理
  switch (formatterValue.value) {
    case ArEnumEncoding2.SHIFT_JIS:
      form.csvencoding = 0
      form.csvbom = false
      break
    case ArEnumEncoding2.UTF8:
      form.csvencoding = 1
      form.csvbom = true
      break
    case ArEnumEncoding2.UTF8 + 1:
      form.csvencoding = 1
      form.csvbom = false
      break
    case ArEnumEncoding2.UTF16_LE + 1:
      form.csvencoding = 2
      form.csvbom = true
      break
    case ArEnumEncoding2.UTF16_LE + 2:
      form.csvencoding = 2
      form.csvbom = false
      break
    case ArEnumEncoding2.UTF16_BE + 2:
      form.csvencoding = 3
      form.csvbom = true
      break
    case ArEnumEncoding2.UTF16_BE + 3:
      form.csvencoding = 3
      form.csvbom = false
      break
    default:
      return
  }

  Download({
    ...props,
    ...form,
    outputfilenm: form.outputfilenm.split('.')[0],
    selecteddatalist: props.selecteddatalist,
    detailjyokenlist
  })
    .then(() => {
      message.success(DOWNLOAD_OK_INFO.Msg)
    })
    .finally(() => {
      loading.value = false
      closeOutput()
    })
}
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
//出力modal閉じる
const closeOutput = () => {
  emit('update:visible', false)
  resetFields()
}
</script>

<style lang="less" scoped>
th {
  width: 100px;
}

:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
