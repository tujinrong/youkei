<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健（検）診予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.21
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="8">
            <th>年度</th>
            <TD>{{ yearFormatter(nendo) }}</TD>
          </a-col>
          <a-col span="8">
            <th>日程番号</th>
            <TD>{{ nitteino }}</TD>
          </a-col>
          <a-col span="8">
            <th>事業名</th>
            <TD>{{ headerInfo?.jigyonm }}</TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="8">
            <th>実施予定日</th>
            <TD>{{ headerInfo?.yoteiymd }}</TD>
          </a-col>
          <a-col span="8">
            <th>開始時間</th>
            <TD>{{ headerInfo?.timef }}</TD>
          </a-col>
          <a-col span="8">
            <th>終了時間</th>
            <TD>{{ headerInfo?.timet }}</TD>
          </a-col>
          <a-col span="8">
            <th>会場</th>
            <TD>{{ headerInfo?.kaijonm }}</TD>
          </a-col>
          <a-col span="8">
            <th>医療機関</th>
            <TD>{{ headerInfo?.kikannm }}</TD>
          </a-col>
          <a-col span="8">
            <th>担当者一覧</th>
            <TD>{{ headerInfo?.staffnms }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="checkSave">登録</a-button>
          <a-button type="primary" :disabled="!canDelete" danger @click="deleteData">削除</a-button>
          <a-button type="primary" @click="back2detail">一覧へ</a-button>
        </a-space>
        <a-space>
          <WarnAlert />
          <close-page />
        </a-space>
      </div>
    </a-card>

    <a-card class="my-2" :style="{ marginBottom: height + 8 + 'px' }">
      <div class="self_adaption_table mb-12">
        <a-row v-if="yoyakuno > 0">
          <a-col span="8">
            <th>予約番号</th>
            <TD>{{ yoyakuno }}</TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="8">
            <th>宛名番号</th>
            <TD>{{ atenano }}</TD>
          </a-col>
          <a-col span="8">
            <th>氏名</th>
            <TD>{{ formData?.name }}</TD>
          </a-col>
          <a-col span="8">
            <th>カナ氏名</th>
            <TD>{{ formData?.kname }}</TD>
          </a-col>
          <a-col span="8">
            <th>生年月日</th>
            <TD>{{ formData?.bymd }}</TD>
          </a-col>
          <a-col span="8">
            <th>性別</th>
            <TD>{{ formData.sex }}</TD>
          </a-col>
          <a-col span="8">
            <th>住民区分</th>
            <TD>{{ formData?.juminkbn }}</TD>
          </a-col>
          <a-col span="8">
            <th>年齢</th>
            <TD>{{ formData?.age }}</TD>
          </a-col>
          <a-col span="8">
            <th>年齡計算基準日</th>
            <TD>{{ formData?.agekijunymd }}</TD>
          </a-col>
          <a-col span="8">
            <th>課税区分(世帯)</th>
            <TD>{{ formData?.kazeikbn_setai }}</TD>
          </a-col>
          <a-col span="8">
            <th>保険区分</th>
            <TD>{{ formData?.hokenkbn }}</TD>
          </a-col>
          <a-col span="8">
            <th>減免区分(特定)</th>
            <TD>{{ formData?.genmenkbn_tokutei }}</TD>
          </a-col>
          <a-col span="8">
            <th>減免区分(がん)</th>
            <TD>{{ formData?.genmenkbn_gan }}</TD>
          </a-col>
          <a-col span="24">
            <th>住所</th>
            <TD>{{ formData?.adrs }}</TD>
          </a-col>
          <a-col span="24">
            <th :class="canEdit && 'bg-editable'">
              備考
              <div class="show_count_box">{{ `${biko.length ?? 0} / 300` }}</div>
            </th>
            <td v-if="canEdit">
              <a-textarea
                v-model:value="biko"
                :maxlength="300"
                :auto-size="{ minRows: 2 }"
              ></a-textarea>
            </td>
            <td v-else class="textarea">{{ biko }}</td>
          </a-col>
          <a-col span="8">
            <th>受診金額</th>
            <td class="textarea" v-html="formatKingaku(moneyInfo.jusinkingaku)"></td>
          </a-col>
          <a-col span="8">
            <th>金額(市町村負担)</th>
            <td class="textarea" v-html="formatKingaku(moneyInfo.kingaku_sityosonhutan)"></td>
          </a-col>
        </a-row>
        <a-row :style="{ float: 'right' }">
          <a-space>
            <a-button type="primary" class="btn-round" @click="Ref_403?.open">料金内訳</a-button>
            <a-button type="primary" class="btn-round" @click="Ref_404?.open">対象サイン</a-button>
          </a-space>
          <AWSH00403D ref="Ref_403" :list="kekkalist" />
          <AWSH00404D ref="Ref_404" />
        </a-row>
      </div>

      <vxe-table
        ref="xTableRef"
        :data="tableData"
        :height="Math.max(tableHeight, 500)"
        :column-config="{ resizable: true }"
        :edit-config="{
          trigger: 'click',
          mode: 'cell',
          beforeEditMethod({ row }) {
            return Boolean(canEdit && row.editflg && nitteino === row.nitteino)
          }
        }"
        :row-config="{ height: 44 }"
        :mouse-config="{ selected: true }"
        :keyboard-config="{ isTab: true, isEnter: true, enterToTab: true }"
        :empty-render="{ name: 'NotData' }"
        :cell-class-name="setCellClass"
      >
        <vxe-column field="jigyonm" title="検診名" min-width="80">
          <template #default="{ row }: { row: RowVM }">
            <a-button
              v-show="row.btnflg"
              type="primary"
              :disabled="!row.editflg || !canEdit"
              block
              @click="toggle(row, false)"
              >{{ row.jigyonm }}</a-button
            >
            <a-button
              v-show="!row.btnflg"
              :disabled="!row.editflg || !canEdit"
              block
              @click="toggle(row, true)"
              >{{ row.jigyonm }}</a-button
            >
          </template>
        </vxe-column>
        <vxe-column
          field="taikiflg"
          title="待機"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          min-width="70"
          :header-class-name="canEdit ? 'bg-editable' : ''"
        >
          <template #edit="{ row }: { row: RowVM }">
            <a-checkbox v-model:checked="row.taikiflg"></a-checkbox>
          </template>
          <template #default="{ row }: { row: RowVM }">
            <a-checkbox
              :checked="row.taikiflg"
              :disabled="!Boolean(canEdit && row.editflg && nitteino === row.nitteino)"
            />
          </template>
        </vxe-column>
        <vxe-column field="nitteino" title="日程番号" min-width="100" />
        <vxe-column field="yoteiymd" title="実施予定日" min-width="150" formatter="jpDate" />
        <vxe-column field="time" title="時間" min-width="120" />
        <vxe-column
          field="kensahohocdnm"
          title="検査方法"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          min-width="150"
          :header-class-name="canEdit ? 'bg-editable' : ''"
        >
          <template #edit="{ row }: { row: RowVM }">
            <ai-select
              v-model:value="row.kensahohocdnm"
              :options="row.selectorlist"
              @change="onChangeKensahoho(row)"
            ></ai-select>
          </template>
        </vxe-column>
        <vxe-column field="status" title="状態" min-width="100" />
        <vxe-column field="cupon" title="クーポン券" min-width="150" />
        <vxe-column
          field="syokaiuketukeymd"
          title="初回受付日"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          min-width="150"
          formatter="jpDate"
          :header-class-name="canEdit ? 'bg-editable' : ''"
        >
          <template #edit="{ row }: { row: RowVM }">
            <date-jp v-model:value="row.syokaiuketukeymd" format="YYYY-MM-DD"></date-jp>
          </template>
        </vxe-column>
        <vxe-column
          field="henkouketukeymd"
          title="受付変更日"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          min-width="150"
          formatter="jpDate"
          :header-class-name="canEdit ? 'bg-editable' : ''"
        >
          <template #edit="{ row }: { row: RowVM }">
            <date-jp
              v-model:value="row.henkouketukeymd"
              format="YYYY-MM-DD"
              :disabled="!row.syokaiuketukeymd"
            ></date-jp>
          </template>
        </vxe-column>
      </vxe-table>
    </a-card>

    <CheckModal v-model:visible="visible" :ok1="onCheckOK1" :ok2="onCheckOK2" />
    <CheckModal v-model:visible="visible2" :ok1="onCheckOK3" :ok2="onCheckOK4" />

    <OperationFooter ref="footerRef" />
  </a-spin>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { formatExceedText, yearFormatter } from '@/utils/util'
import { useTableHeight } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import { onMounted, reactive, ref, watch, nextTick, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { DetailRowVM, HeaderVM, MoneyVM, PersonVM } from '../type'
import { showDeleteModal, showSaveModal, showConfirmModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
import {
  A024001,
  C021003,
  C021004,
  C021005,
  E024005,
  E024006,
  DELETE_OK_INFO,
  SAVE_OK_INFO
} from '@/constants/msg'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize } from '@vueuse/core'
import DateJp from '@/components/Selector/DateJp/index.vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { Calculate, CheckTeiin, Delete, InitDetail, Save } from '../service'
import { Enum編集区分, Enum対象区分, EnumMsgCtrlKbn } from '#/Enums'
import dayjs from 'dayjs'
import CheckModal from '@/components/Common/CheckModal/index.vue'
import AWSH00403D from '@/views/affect/SH/AWSH004/AWSH00403D/index.vue'
import AWSH00404D from '@/views/affect/SH/AWSH004/AWSH00404D/index.vue'

type RowVM = DetailRowVM & { btnflg: boolean }
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const Ref_403 = ref<InstanceType<typeof AWSH00403D> | null>(null)
const Ref_404 = ref<InstanceType<typeof AWSH00404D> | null>(null)
const emit = defineEmits(['after-close'])
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const visible = ref(false)
const visible2 = ref(false)
const jigyocd = ref('')
const editJudge = new Judgement(route.name as string)

const atenano = route.query.atenano as string
const nendo = Number(route.query.nendo)
const nitteino = Number(route.query.nitteino)
const yoyakuno = Number(route.query.yoyakuno)
const isNew = yoyakuno < 0
const commonParams = {
  nendo,
  nitteino,
  atenano,
  editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
}

const headerInfo = ref<HeaderVM | null>(null)
const moneyInfo = ref<MoneyVM>({
  jusinkingaku: '',
  kingaku_sityosonhutan: ''
})
const formData = reactive<PersonVM>({
  name: '',
  kname: '',
  sex: '',
  juminkbn: '',
  bymd: '',
  adrs: '',
  keikoku: '',
  kazeikbn_setai: '',
  hokenkbn: '',
  genmenkbn_tokutei: '',
  genmenkbn_gan: '',
  age: '',
  agekijunymd: ''
})
const tableData = ref<RowVM[]>([])
const biko = ref('')
let upddttm

//操作権限フラグ
const canEdit = isNew || route.meta.updflg
const canDelete = !isNew && route.meta.delflg
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  initData()
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch([tableData, biko], () => editJudge.setEdited(), { deep: true })
//検査方法が変わった場合、再計算
watch(
  () => tableData.value.map((el) => ({ kensahohocdnm: el.kensahohocdnm, taikiflg: el.taikiflg })),
  () => calc()
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -240)
const footerRef = ref(null)
const { height } = useElementSize(footerRef)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function initData() {
  loading.value = true
  try {
    const res = await InitDetail(commonParams)
    headerInfo.value = res.headerinfo
    moneyInfo.value = res.moneyinfo
    tableData.value = res.kekkalist.map((el) => ({ ...el, btnflg: el.nitteino === nitteino }))
    Object.assign(formData, res.personinfo)
    biko.value = res.biko
    upddttm = res.upddttm
  } catch (error) {}
  loading.value = false
  nextTick(() => editJudge.reset())
}

//定員チェック処理
let checkjigyoList: string[] = [] //待機変更必要検診事業一覧
async function checkSave() {
  if (
    moneyInfo.value.jusinkingaku == '計算エラー' ||
    moneyInfo.value.kingaku_sityosonhutan == '計算エラー'
  ) {
    showConfirmModal({
      content: C021005.Msg,
      onOk: async () => {
        try {
          const res = await CheckTeiin({
            ...commonParams,
            kekkalist: tableData.value
              .filter((el) => el.nitteino === nitteino && !el.taikiflg)
              .map((el) => ({ jigyocd: el.jigyocd, kensahohocdnm: el.kensahohocdnm }))
          })
          if (res.kekkalist.length > 0) {
            checkjigyoList = res.kekkalist
            visible.value = true
          } else {
            await saveData()
          }
        } catch (error) {}
      }
    })
  } else {
    showSaveModal({
      onOk: async () => {
        try {
          const res = await CheckTeiin({
            ...commonParams,
            kekkalist: tableData.value
              .filter((el) => el.nitteino === nitteino && !el.taikiflg)
              .map((el) => ({ jigyocd: el.jigyocd, kensahohocdnm: el.kensahohocdnm }))
          })
          if (res.kekkalist.length > 0) {
            checkjigyoList = res.kekkalist
            visible.value = true
          } else {
            await saveData()
          }
        } catch (error) {}
      }
    })
  }
}

//待機
async function onCheckOK1() {
  tableData.value.forEach((el) => {
    if (checkjigyoList.includes(el.jigyocd)) {
      el.taikiflg = true
    }
  })
  await saveData()
}
//続行
async function onCheckOK2() {
  await saveData()
}
//待機
async function onCheckOK3() {
  tableData.value.forEach((el) => {
    if (el.jigyocd == jigyocd.value && checkjigyoList.includes(el.jigyocd)) {
      el.taikiflg = true
    }
  })
  onCheckOK4()
}
//続行
async function onCheckOK4() {
  tableData.value.forEach((row) => {
    if (row.jigyocd == jigyocd.value) {
      if (row.nitteino && row.nitteino !== nitteino) {
        showConfirmModal({
          content: C021003.Msg,
          onOk: () => {
            row.henkouketukeymd = dayjs().format('YYYY-MM-DD')
            commonSet(row)
          }
        })
      } else {
        row.syokaiuketukeymd = dayjs().format('YYYY-MM-DD')
        commonSet(row)
      }
    }
  })
}
//保存処理
async function saveData() {
  await Save({
    ...commonParams,
    biko: biko.value,
    kekkalist: tableData.value.filter((el) => el.nitteino),
    upddttm
  })
  editJudge.reset()
  message.success(SAVE_OK_INFO.Msg)
  emit('after-close')
  back2detail()
}

//削除処理
function deleteData() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({ nendo, nitteino, atenano, upddttm })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        emit('after-close')
        back2detail()
      } catch (error) {}
    }
  })
}
function getCode(value) {
  return value?.split(' : ')[0]
}
async function onChangeKensahoho(row: RowVM) {
  row.selectorlist.forEach((el) => {
    if (el.value == getCode(row.kensahohocdnm)) {
      if (el.sign != '対象') {
        if (row.yoyakuchk === EnumMsgCtrlKbn.エラー) {
          message.error(E024005.Msg.replace('{0}', el.label))
        } else if (row.yoyakuchk === EnumMsgCtrlKbn.アラート) {
          message.warning(A024001.Msg.replace('{0}', el.label))
        }
      }
      if (!el.flg2) {
        message.error(E024006.Msg.replace('{0}', el.label))
      }
      if (row.nitteino) {
        row.henkouketukeymd = dayjs().format('YYYY-MM-DD')
      } else {
        row.syokaiuketukeymd = dayjs().format('YYYY-MM-DD')
      }
      return
    }
  })
}

//計算処理
const kekkalist = computed(() => {
  return tableData.value
    .filter((el) => el.nitteino && el.kensahohocdnm && !el.taikiflg)
    .map((el) => ({
      jigyocd: el.jigyocd,
      nitteino: el.nitteino as number,
      kensahohocdnm: el.kensahohocdnm
    }))
})

async function calc() {
  const res = await Calculate({
    nendo,
    atenano,
    kekkalist: kekkalist.value
  })
  moneyInfo.value = res.moneyinfo
}

function back2detail() {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: { ...route.query, yoyakuno: '', atenano: '' }
    })
  })
}

//検診名Button
async function toggle(row: RowVM, bool: boolean) {
  jigyocd.value = row.jigyocd
  if (!bool) {
    if (row.status != '') {
      showConfirmModal({
        content: C021004.Msg,
        onOk: () => {
          clearRowData(row)
        }
      })
    } else {
      clearRowData(row)
    }
  } else {
    //定員チェック
    try {
      const res = await CheckTeiin({
        ...commonParams,
        kekkalist: tableData.value
          .filter((el) => !el.taikiflg && el.jigyocd == row.jigyocd)
          .map((el) => ({ jigyocd: el.jigyocd, kensahohocdnm: el.kensahohocdnm }))
      })
      if (res.kekkalist.length > 0) {
        checkjigyoList = res.kekkalist
        visible2.value = true
      } else {
        onCheckOK4()
      }
    } catch (error) {}
  }
}

function clearRowData(row: RowVM) {
  row.btnflg = false
  row.nitteino = undefined
  row.yoteiymd = ''
  row.time = ''
  row.kensahohocdnm = ''
  row.syokaiuketukeymd = ''
  row.henkouketukeymd = ''
}
function commonSet(row: RowVM) {
  row.btnflg = true
  row.nitteino = nitteino
  row.yoteiymd = headerInfo.value?.yoteiymd ?? ''
  row.time = (headerInfo.value?.timef ?? '') + '～' + (headerInfo.value?.timet ?? '')
}

function setCellClass({ row }) {
  if (!row.editflg) {
    return 'bg-#f1f1f1'
  } else if (row.nitteino && row.nitteino !== nitteino) {
    return 'bg-#ffffe1'
  } else {
    return ''
  }
}
//format金額
const formatKingaku = (value) => {
  if (!value) return ''
  const localeStr = Number(value).toLocaleString()
  return isNaN(value) ? `<span class="c-red5!">${value}</span>` : localeStr
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 135px;
}
</style>
