<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ロジック共通仕様処理(検診)フリー項目
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div ref="elRef" class="flex flex-col h-full">
    <div class="flex justify-between">
      <a-space>
        <a-select
          v-model:value="kbn1Code"
          class="w-35"
          :options="props.grouplist1"
          :disabled="!(hasList1 || hasList2)"
        >
        </a-select>
        <a-select
          v-model:value="kbn2Code"
          class="w-50"
          :options="props.grouplist2"
          :disabled="!(hasList1 || hasList2)"
        >
        </a-select>
      </a-space>
      <a-space>
        <a-button
          type="primary"
          shape="round"
          :style="{ filter: showErrorFlag ? 'hue-rotate(60deg)' : '' }"
          @click="toggleShowError"
          >{{ showErrorFlag ? '全項目表示☆' : '必須チェックエラー項目表示' }}</a-button
        >
        <a-button type="primary" shape="round" @click="setInitialValue" @keydown="handleTabKey">
          初期値
        </a-button>
      </a-space>
    </div>
    <div class="flex-1 m-t-1">
      <vxe-table
        id="kensin_right_table"
        ref="xTableRef"
        :data="hasMask ? [] : filtertableData"
        :scroll-y="{ enabled: false }"
        :height="(height - 42) * 0.85"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true }"
        :mouse-config="{ selected: true }"
        :edit-config="{
          trigger: 'click',
          mode: 'row',
          beforeEditMethod({ row }: { row: KsFreeItemVM }) {
            if (!props.canEdit1 && row.groupid==EnumKensinKbn.一次) {
              return false
            }
            if (!props.canEdit2 && row.groupid==EnumKensinKbn.精密) {
              return false
            }
            return row.inputflg
          }
        }"
        :keyboard-config="{
          isArrow: true,
          isTab: true,
          isDel: true
          // isEnter: true
        }"
        :empty-render="{ name: 'NotData' }"
        :show-overflow="false"
      >
        <vxe-column
          field="groupid"
          width="5%"
          align="center"
          :class-name="({ row }) => setCellColor(row)"
        >
          <template #default="{ row }: { row: KsFreeItemVM }">
            <span>{{ row.groupid == EnumKensinKbn.一次 ? '一' : '精' }}</span>
          </template>
        </vxe-column>
        <vxe-column
          field="name"
          width="25%"
          title="項目"
          :class-name="({ row }) => setCellColor(row)"
        >
          <template #default="{ row }: { row: KsFreeItemVM }">
            <span>{{ row.itemnm }}</span>
            <span v-if="isHissuMark(row)" class="request-mark">＊</span>
            <div
              v-if="
                [
                  Enum入力タイプ.全角半角文字_全角半角_改行可,
                  Enum入力タイプ.全角文字_全角_改行可
                ].includes(row.inputtypekbn)
              "
              class="show_count_box"
            >
              {{ `${row.value?.length ?? 0} / 1000` }}
            </div>
          </template>
        </vxe-column>
        <vxe-column
          field="value"
          title="値"
          width="60%"
          :show-overflow="false"
          :class-name="getInputColClass"
          header-class-name="bg-editable"
          :edit-render="{
            name: 'CustomEdit',
            props: { optionsDefaultOpen : true },
            events: {
              onChange: () => {},
              onFinish: (row:any) => onFinishInput(row),
            }
          }"
        >
          <template #default="{ row }: { row: KsFreeItemVM }">
            <RenderReadonly :row="row" />
          </template>
        </vxe-column>
        <vxe-column field="judgekbn" title="基準判定" width="10%">
          <template #default="{ row }: { row: KsFreeItemVM }">
            <a-tag
              v-if="row.kijun && getJudgekbn(row.kijun.kijunlist || [], row).level > 0"
              :color="getJudgekbn(row.kijun.kijunlist || [], row).color"
              >{{ getJudgekbn(row.kijun.kijunlist || [], row).text }}</a-tag
            >
          </template>
        </vxe-column>
        <vxe-column title="基準範囲" width="28%">
          <template #default="{ row }: { row: KsFreeItemVM }">
            <span>{{ row.kijun?.kijunvaluehyoki }}</span>
          </template>
        </vxe-column>
        <vxe-column title="要注意" width="28%">
          <template #default="{ row }: { row: KsFreeItemVM }">
            <span>{{ row.kijun?.alertvaluehyoki }}</span>
          </template>
        </vxe-column>
        <vxe-column title="異常" min-width="28%">
          <template #default="{ row }: { row: KsFreeItemVM }">
            <span>{{ row.kijun?.errvaluehyoki }}</span>
          </template>
        </vxe-column>
      </vxe-table>
      <div class="bottom-tip">
        <span class="bottom-tip-title">注　釈</span>
        <span class="bottom-tip-content">{{ currentRowNote }}</span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch, watchEffect } from 'vue'
import { VxeTableInstance } from 'vxe-table'
import { message } from 'ant-design-vue'
import { EnumKensinKbn, EnumMsgCtrlKbn, Enum入力タイプ, Enum画面項目入力 } from '#/Enums'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { useElementSize } from '@vueuse/core'
import { isNumber } from 'xe-utils'
import { KsFreeItemVM } from '../type'
import RenderReadonly from '@/components/Common/VxeRender/RenderReadonly.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  tableData: KsFreeItemVM[]
  hasList1: boolean
  hasList2: boolean
  canEdit1: boolean
  canEdit2: boolean
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  /**検査方法 */
  kensahoho: string
  checkSeiken: (row, oldVal?) => void
}>()

//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const xTableRef = ref<VxeTableInstance>()
const currentRowNote = ref('')

const hasMask = ref(false)
const showErrorFlag = ref(false)
const kbn1Code = ref('')
const kbn2Code = ref('')

const filtertableData = ref<KsFreeItemVM[]>([])

//表の高さ
const elRef = ref(null)
const { height } = useElementSize(elRef)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//初期化
watch(
  () => props.tableData,
  () => {
    kbn1Code.value = ''
    kbn2Code.value = ''
    filtertableData.value = filterByGroup()
    kbn1Code.value = props.grouplist1.find((el) => !el.disabled)?.value || ''
    showErrorFlag.value = false
  }
)
watch(
  () => [kbn1Code.value, kbn2Code.value, props.kensahoho],
  () => {
    filtertableData.value = filterByGroup()
  },
  { immediate: true, deep: true }
)
//連動処理(入力チェックを基にフリー項目の画面制限を変える)
watchEffect(() => {
  if (props.grouplist1.length === 3) {
    props.grouplist1[0].disabled = !(props.hasList1 && props.hasList2)
    props.grouplist1[1].disabled = !props.hasList1
    props.grouplist1[2].disabled = !props.hasList2
    const item = props.grouplist1.find((el) => !el.disabled)
    if (item) {
      kbn1Code.value = item.value as string
      hasMask.value = false
    } else {
      kbn1Code.value = ''
      kbn2Code.value = ''
      hasMask.value = true
    }
  }
})
//備考を取得(項目ごと)
watch(
  () => xTableRef.value?.getCurrentRecord(),
  (val) => (currentRowNote.value = val?.biko)
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期値設定
function setInitialValue() {
  if (!props.hasList1 && !props.hasList2) return
  for (const el of filtertableData.value) {
    if (el.inputflg && !el.value && el.value !== 0 && el.syokiti !== '') {
      if (props.canEdit1 && el.groupid == EnumKensinKbn.一次) {
        el.value = el.syokiti
      }
      if (props.canEdit2 && el.groupid == EnumKensinKbn.精密) {
        el.value = el.syokiti
      }
    }
  }
  onFinishInput()
}
//画面絞り込む(フリー項目)
function filterByGroup() {
  return (
    props.tableData
      //検査方法filter
      .filter((item) => {
        if (item.riyokensahohocds.length > 0) {
          if (item.groupid === EnumKensinKbn.一次 && props.kensahoho) {
            return item.riyokensahohocds.includes(props.kensahoho)
          }
        }
        return true
      })
      //グループfilter
      .filter((item) => {
        if (kbn1Code.value && kbn2Code.value) {
          return String(item.groupid) === kbn1Code.value && item.groupid2 === kbn2Code.value
        } else if (kbn1Code.value) {
          return String(item.groupid) === kbn1Code.value
        } else if (kbn2Code.value) {
          return item.groupid2 === kbn2Code.value
        } else {
          return true
        }
      })
      //必須チェックエラー項目filter
      .filter((item) => (showErrorFlag.value ? isErrorValue(item) : true))
  )
}
//--------------------------------------------------------------------------
//チェック処理
function isErrorValue(item: KsFreeItemVM) {
  return item.msgkbn === EnumMsgCtrlKbn.エラー && item.hissuflg && !item.value && item.value !== 0
}
function isWarnValue(item: KsFreeItemVM) {
  return item.msgkbn === EnumMsgCtrlKbn.アラート && item.hissuflg && !item.value && item.value !== 0
}
function getInputColClass({ row }: { row: KsFreeItemVM }) {
  return isErrorValue(row) ? 'bg-errorcell' : isWarnValue(row) ? 'bg-warncell' : ''
}
//--------------------------------------------------------------------------
//入力終了イベント
function onFinishInput(row?) {
  if (showErrorFlag.value) {
    filtertableData.value = filterByGroup()
  }
  if (row?.komokutokuteikbn) {
    props.checkSeiken(row)
  }
}
//表示処理(エラー項目の絞り込み表示)
function toggleShowError() {
  showErrorFlag.value = !showErrorFlag.value
  filtertableData.value = filterByGroup()
}
//チェック処理(必須チェック)
function validate(): Promise<boolean> {
  return new Promise((resolve, reject) => {
    kbn1Code.value = props.grouplist1.find((el) => !el.disabled)?.value as string
    kbn2Code.value = ''
    const fail = filtertableData.value.find((el) => isErrorValue(el))
    if (fail) {
      message.warning(ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'フリー項目'))
      reject(false)
    } else {
      resolve(true)
    }
  })
}

//基準判定
function getJudgekbn(kijunlist: KijunVM[], row: KsFreeItemVM) {
  let obj = { level: 0, text: '', color: '' }
  if (!row.value && row.value !== 0) return obj
  const value = row.inputkbn === Enum画面項目入力.選択 ? row.value.split(' : ')[0] : row.value

  for (const item of kijunlist) {
    if (item.hanteicd || item.alerthanteicd || item.errhanteicd) {
      // 基準値タイプ:コード
      const hanteicdList = item.hanteicd.split(',')
      const alerthanteicdList = item.alerthanteicd.split(',')
      const errhanteicdList = item.errhanteicd.split(',')
      //正常値範囲内の場合
      if (hanteicdList.includes(value)) {
        if (obj.level <= 1) obj = { level: 1, text: '正常', color: '#87d068' }
      }
      //注意値範囲内の場合
      else if (alerthanteicdList.includes(value)) {
        if (obj.level <= 2) obj = { level: 2, text: '注意', color: '#faad14' }
      }
      //異常値範囲内の場合
      else if (errhanteicdList.includes(value)) {
        obj = { level: 3, text: '異常', color: '#ff4d4f' }
      }
    } else {
      // 基準値タイプ:数値
      //正常値範囲内の場合
      if (value >= formatMin(item.kijunvaluef) && value <= formatMax(item.kijunvaluet)) {
        if (obj.level <= 1) obj = { level: 1, text: '正常', color: '#87d068' }
      }
      //注意値範囲内の場合
      else if (
        (value >= formatMin(item.alertvalue1f) &&
          value <= formatMax(item.alertvalue1t) &&
          (isNumber(item.alertvalue1f) || isNumber(item.alertvalue1t))) ||
        (value >= formatMin(item.alertvalue2f) &&
          value <= formatMax(item.alertvalue2t) &&
          (isNumber(item.alertvalue2f) || isNumber(item.alertvalue2t)))
      ) {
        if (obj.level <= 2) obj = { level: 2, text: '注意', color: '#faad14' }
      }
      //異常値範囲内の場合
      else if (value >= formatMax(item.errvalue2f) || value <= formatMin(item.errvalue1t)) {
        obj = { level: 3, text: '異常', color: '#ff4d4f' }
      }
    }
  }

  return obj
}
//半区間の場合、強制下限値を与える
function formatMin(value) {
  return value === null ? Number.MIN_SAFE_INTEGER : value
}
//半区間の場合、強制上限値を与える
function formatMax(value) {
  return value === null ? Number.MAX_SAFE_INTEGER : value
}
//行の背景色
function setCellColor(row) {
  return (!props.canEdit1 && row.groupid == EnumKensinKbn.一次) ||
    (!props.canEdit2 && row.groupid == EnumKensinKbn.精密) ||
    !row.inputflg
    ? 'bg-readonly'
    : 'bg-editable'
}
//必須マーク
function isHissuMark(row: KsFreeItemVM) {
  if (row.groupid == EnumKensinKbn.一次) {
    return row.hissuflg && row.inputflg && props.canEdit1
  }
  if (row.groupid == EnumKensinKbn.精密) {
    return row.hissuflg && row.inputflg && props.canEdit2
  }
  return false
}
//初期値ボタン:遷移順調整＝＞初期値ボタンからフリー項目一覧の入力欄へ
function handleTabKey(event) {
  if (event.key === 'Tab' && !event.shiftKey) {
    const nextRow = xTableRef.value?.getData(0)
    setTimeout(() => {
      xTableRef.value?.setCurrentRow(nextRow)
      xTableRef.value?.setEditCell(nextRow, 'value')
    }, 0)
  }
}

defineExpose({ validate })
</script>

<style src="../index.less" scoped></style>
