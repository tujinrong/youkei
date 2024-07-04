<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ロジック共通仕様処理(検診)フリー項目
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div ref="elRef" class="flex flex-col h-full">
    <a-row class="flex justify-between">
      <a-col :md="7" :xxl="12" class="flex">
        <a-select
          v-model:value="kbn1Code"
          class="w-full mr-2"
          :options="grouplistComputed1"
          :disabled="!canEdit"
        >
        </a-select>
        <a-select
          v-model:value="kbn2Code"
          class="w-full"
          :options="grouplistComputed2"
          :disabled="!canEdit"
        >
        </a-select>
      </a-col>
      <a-space>
        <a-button
          type="primary"
          shape="round"
          :style="{ filter: showErrorFlag ? 'hue-rotate(60deg)' : '' }"
          :disabled="!canEdit"
          @click="toggleShowError"
          >{{ showErrorFlag ? '全項目表示☆' : '必須チェックエラー項目表示' }}</a-button
        >
        <a-button
          type="primary"
          shape="round"
          :disabled="!canEdit"
          @click="setInitialValue"
          @keydown="handleTabKey"
        >
          初期値
        </a-button>
      </a-space>
    </a-row>
    <div class="flex-1 m-t-1">
      <vxe-table
        id="kensin_right_table"
        ref="xTableRef"
        :data="hasMask ? [] : filtertableData"
        :scroll-y="{ enabled: false }"
        :height="(height - 45) * 0.85"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true }"
        :mouse-config="{ selected: true }"
        :edit-config="{
          trigger: 'click',
          mode: 'row',
          beforeEditMethod({ row }: { row: FreeItemDispInfoVM }) {
            return props.canEdit && row.inputflg
          }}"
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
          field="itemkbn"
          width="50"
          align="center"
          :class-name="({ row }) => setCellColor(row)"
          show-overflow
        />
        <vxe-column
          field="name"
          width="25%"
          title="項目"
          :class-name="({ row }) => setCellColor(row)"
        >
          <template #default="{ row }: { row: FreeItemDispInfoVM }">
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
          :show-overflow="false"
          :class-name="getInputColClass"
          header-class-name="bg-editable"
          :edit-render="{
            name: 'CustomEdit',
            props: { optionsDefaultOpen: true },
            events: {
              onChange: () => {},
              onFinish: () => onFinishInput()
            }
          }"
        >
          <template #default="{ row }: { row: FreeItemDispInfoVM }">
            <RenderReadonly :row="row" />
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
import { EnumMsgCtrlKbn, Enum入力タイプ } from '#/Enums'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { useElementSize } from '@vueuse/core'
import { message } from 'ant-design-vue'
import { computed, ref, watch } from 'vue'
import { VxeTableInstance } from 'vxe-table'
import { FreeItemDispInfoVM } from '../type'
import RenderReadonly from '@/components/Common/VxeRender/RenderReadonly.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  tableData: FreeItemDispInfoVM[]
  canEdit: boolean
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  syukeikbn?: string
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

const filtertableData = ref<FreeItemDispInfoVM[]>([])

//表の高さ
const elRef = ref(null)
const { height } = useElementSize(elRef)

const grouplistComputed1 = computed(() => [
  { value: '', label: 'すべて', disabled: false },
  ...props.grouplist1
])
const grouplistComputed2 = computed(() => [
  { value: '', label: 'すべて', disabled: false },
  ...props.grouplist2
])
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
    showErrorFlag.value = false
  }
)
watch(
  () => [kbn1Code.value, kbn2Code.value, props.syukeikbn],
  () => {
    filtertableData.value = filterByGroup()
  },
  { immediate: true, deep: true }
)
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
  for (const el of filtertableData.value) {
    if (el.inputflg && !el.value && el.value !== 0 && el.syokiti !== '') {
      el.value = el.syokiti
    }
  }
  onFinishInput()
}
//画面絞り込む(フリー項目)
function filterByGroup() {
  return (
    props.tableData
      //利用地域保健集計区分filter
      .filter((item) => {
        if (item.syukeikbn) {
          if (props.syukeikbn) {
            return item.syukeikbn.includes(props.syukeikbn.split(' : ')[0])
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
function isErrorValue(item: FreeItemDispInfoVM) {
  return item.msgkbn === EnumMsgCtrlKbn.エラー && item.hissuflg && !item.value && item.value !== 0
}
function isWarnValue(item: FreeItemDispInfoVM) {
  return item.msgkbn === EnumMsgCtrlKbn.アラート && item.hissuflg && !item.value && item.value !== 0
}
function getInputColClass({ row }: { row: FreeItemDispInfoVM }) {
  if (!props.canEdit) return ''
  return isErrorValue(row) ? 'bg-errorcell' : isWarnValue(row) ? 'bg-warncell' : ''
}
//--------------------------------------------------------------------------
//入力終了イベント
function onFinishInput() {
  if (showErrorFlag.value) {
    filtertableData.value = filterByGroup()
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
    kbn1Code.value = ''
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

//行の背景色
function setCellColor(row) {
  return !props.canEdit || !row.inputflg ? 'bg-readonly' : 'bg-editable'
}
//必須マーク
function isHissuMark(row: FreeItemDispInfoVM) {
  return row.hissuflg && row.inputflg && props.canEdit
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
