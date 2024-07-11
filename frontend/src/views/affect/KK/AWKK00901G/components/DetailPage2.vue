<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業予定管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.01
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :xxl="6">
            <th :class="canEdit && isNew ? 'required' : 'bg-readonly'">業務</th>
            <td v-if="canEdit && isNew">
              <a-form-item v-bind="validateInfos.gyomukbn">
                <ai-select
                  v-model:value="headerInfo.gyomukbn"
                  :options="options"
                  split-val
                  @change="onChangeGyomu"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ options.find((opt) => opt.value === headerInfo.gyomukbn)?.label }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th class="bg-readonly">登録支所</th>
            <TD>{{ headerInfo.regsisyonm || ss.get(REGSISYO).sisyonm }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th class="bg-readonly">コース番号</th>
            <TD v-if="!isNew && !isCopy">{{ courseno }}</TD>
            <TD v-else></TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th :class="canEdit ? 'required' : 'bg-readonly'">コース名</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.coursenm">
                <a-input v-model:value="headerInfo.coursenm" allow-clear :maxlength="100"></a-input>
              </a-form-item>
            </td>
            <TD v-else>{{ headerInfo.coursenm }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit || tableData.length === 0" @click="saveData"
            >登録</a-button
          >
          <a-button type="primary" :disabled="!canDelete" danger @click="deleteData">削除</a-button>
          <a-button type="primary" @click="back2list()">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="my-2" :style="{ minHeight: tableHeight + 'px' }" :loading="loading">
      <a-space class="mb-2">
        <a-button class="btn-round" type="primary" :disabled="!canEdit" @click="addRow()"
          >行追加</a-button
        >
        <a-button
          class="btn-round"
          type="primary"
          :disabled="!canDeleteRow"
          @click="handleDeleteRow"
          >行削除</a-button
        >
        <a-button
          class="btn-round"
          type="primary"
          :disabled="!canEdit || !currentRow"
          @click="copyRow"
          >行コピー</a-button
        >
      </a-space>
      <vxe-table
        ref="xTableRef"
        :height="tableHeight - 65"
        :data="tableData"
        :column-config="{ resizable: true }"
        :mouse-config="{ selected: true }"
        :edit-rules="rules"
        :row-config="{ isCurrent: true, height: 48 }"
        :keyboard-config="{
          isTab: true,
          isEdit: true,
          isEnter: true,
          enterToTab: true
        }"
        :edit-config="{
          trigger: 'click',
          mode: 'cell',
          showStatus: false,
          beforeEditMethod({ row, column }) {
            if (!row.editflg && column.field === 'jigyocdnm') {
              return false
            } else {
              return canEdit as unknown as boolean
            }
          }
        }"
        :valid-config="{ showMessage: false }"
        :empty-render="{ name: 'NotData' }"
        :cell-class-name="({ row, column }) => setCellClass(row, column.field)"
        @edit-closed="tableData = getTableData()"
      >
        <vxe-column
          field="nitteino"
          title="日程番号"
          width="100"
          min-width="100"
          header-class-name="bg-readonly"
        ></vxe-column>
        <vxe-column
          field="kaisu"
          title="回数"
          width="80"
          min-width="80"
          header-class-name="bg-readonly"
        ></vxe-column>
        <vxe-column
          field="jigyocdnm"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          :class-name="({ row }) => (!row.jigyocdnm ? 'bg-errorcell' : '')"
          min-width="100"
        >
          <template #header>
            <span :class="canEdit && 'required'">事業名</span>
          </template>
          <template #edit="{ row }: { row: CourseDetailVM }">
            <ai-select v-model:value="row.jigyocdnm" :options="keyoptions"></ai-select>
          </template>
        </vxe-column>
        <vxe-column
          field="jissinaiyo"
          title="実施内容"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          min-width="100"
        >
          <template #edit="{ row }: { row: CourseDetailVM }">
            <a-textarea
              v-model:value="row.jissinaiyo"
              :maxlength="100"
              :auto-size="{ minRows: 1 }"
              type="text"
              show-count
              class="my-2"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="jissiyoteiymd"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          :class-name="({ row }) => (!row.jissiyoteiymd ? 'bg-errorcell' : '')"
          width="150"
          min-width="150"
        >
          <template #header>
            <span :class="canEdit && 'required'">実施予定日</span>
          </template>
          <template #edit="{ row }: { row: CourseDetailVM }">
            <DateJp v-model:value="row.jissiyoteiymd" format="YYYY-MM-DD" />
          </template>
          <template #default="{ row }: { row: CourseDetailVM }">
            {{ row.jissiyoteiymd ? getDateJpText(new Date(row.jissiyoteiymd)) : '' }}
          </template>
        </vxe-column>
        <vxe-column
          field="tmf"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          :class-name="({ row }) => (!row.tmf ? 'bg-errorcell' : '')"
          width="120"
          min-width="120"
        >
          <template #header>
            <span :class="canEdit && 'required'">開始時間</span>
          </template>
          <template #edit="{ row }: { row: CourseDetailVM }">
            <a-time-picker v-model:value="row.tmf" value-format="HHmm" format="HH:mm" />
          </template>
          <template #default="{ row }: { row: CourseDetailVM }">
            {{ formatTime(row.tmf) }}
          </template>
        </vxe-column>
        <vxe-column
          field="tmt"
          title="終了時間"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          width="120"
          min-width="120"
        >
          <template #edit="{ row }: { row: CourseDetailVM }">
            <a-time-picker
              v-model:value="row.tmt"
              value-format="HHmm"
              format="HH:mm"
              @change="validate('tmf')"
            />
          </template>
          <template #default="{ row }: { row: CourseDetailVM }">
            {{ formatTime(row.tmt) }}
          </template>
        </vxe-column>
        <vxe-column
          field="kaijocdnm"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          :class-name="({ row }) => (!row.kaijocdnm ? 'bg-errorcell' : '')"
          min-width="100"
        >
          <template #header>
            <span :class="canEdit && 'required'">会場</span>
          </template>
          <template #edit="{ row }: { row: CourseDetailVM }">
            <ai-select v-model:value="row.kaijocdnm" :options="response.selectorlist3"></ai-select>
          </template>
        </vxe-column>
        <vxe-column
          field="kikancdnm"
          title="医療機関"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          min-width="100"
        >
          <template #edit="{ row }: { row: CourseDetailVM }">
            <td class="flex gap-1">
              <ai-select
                v-model:value="row.kikancdnm"
                :options="response.selectorlist4"
              ></ai-select>
              <OrganizeButton @select="selectOrganize"></OrganizeButton>
            </td>
          </template>
        </vxe-column>
        <vxe-column
          field="staffids"
          title="担当者"
          :edit-render="{ autofocus: '.ant-select-selection-search-input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          min-width="100"
        >
          <template #edit="{ row }: { row: CourseDetailVM }">
            <td class="flex gap-1">
              <a-select
                v-model:value="row.staffids"
                mode="multiple"
                max-tag-count="responsive"
                :options="response.selectorlist5"
                class="w-full"
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
              <a-button class="btn-round" type="primary" @click="modalVisible = true">
                検索
              </a-button>
            </td>
          </template>
          <template #default="{ row }: { row: CourseDetailVM }">
            {{ getMultipleLabel(row.staffids, response.selectorlist5) }}
          </template>
        </vxe-column>
        <vxe-column
          field="teiin"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          :header-class-name="canEdit ? 'bg-editable' : ''"
          :class-name="({ row }) => (!row.teiin ? 'bg-errorcell' : '')"
          width="100"
          min-width="100"
        >
          <template #header>
            <span :class="canEdit && 'required'">定員</span>
          </template>
          <template #edit="{ row }: { row: CourseDetailVM }">
            <a-input-number
              v-model:value="row.teiin"
              :min="1"
              :max="9999"
              class="w-full"
            ></a-input-number>
          </template>
        </vxe-column>
      </vxe-table>
    </a-card>
    <StaffModal v-model:visible="modalVisible" @select="selectStaff" />
  </div>
</template>

<script setup lang="ts">
import { Enum編集区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import {
  DELETE_OK_INFO,
  E001008,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { REGSISYO } from '@/constants/mutation-types'
import { useLinkOption, useTable, useTableHeight } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { formatTime, getDateJpText, getMultipleLabel } from '@/utils/util'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, toRef, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { CourseDetailVM, CourseHeaderVM, InitCourseDetailResponse } from '../type'
import { DeleteCourse, InitDetailCourse, SaveCourse } from '../service'
import OrganizeButton from '@/views/affect/AF/AWAF00702D/button.vue'
import { SearchVM as KikanVM } from '@/views/affect/AF/AWAF00702D/type'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'
import { SearchVM as StaffVM } from '@/views/affect/AF/AWAF00704D/type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const editJudge = new Judgement(route.name as string)
const modalVisible = ref(false)
const courseno = Number(route.query.courseno)
const isCopy = Boolean(route.query.iscopy)
const isNew = courseno < 0 || isCopy

const response = ref<
  Omit<InitCourseDetailResponse, keyof DaResponseBase | 'headerinfo' | 'detailinfo'>
>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  editflg: true,
  upddttm: undefined
})
const headerInfo = reactive<CourseHeaderVM>({
  gyomukbn: '',
  regsisyonm: '',
  coursenm: ''
})
const tableData = ref<CourseDetailVM[]>([])

//項目の設定
const rules = ref({
  gyomukbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '業務') }],
  coursenm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'コース名') }],
  jigyocdnm: [{ required: true }],
  jissiyoteiymd: [{ required: true }],
  tmf: [{ required: true }],
  kaijocdnm: [{ required: true }],
  teiin: [{ required: true }]
})
const { validate, clearValidate, validateInfos } = Form.useForm(headerInfo, rules)

//Options連動(事業名、業務)
const { keyoptions, options, onChangeOpt } = useLinkOption(
  toRef(() => response.value.selectorlist2),
  toRef(() => response.value.selectorlist1),
  undefined,
  toRef(headerInfo, 'gyomukbn')
)
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  editJudge.addEvent()
  searchData()
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch([headerInfo, tableData], () => editJudge.setEdited(), { deep: true })

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 65)
//操作権限フラグ
const canEdit = computed(() => isNew || (route.meta.updflg && response.value.editflg))
//削除フラグ取得
const canDelete = computed(() => !isNew && route.meta.delflg && response.value.editflg)
//行削除フラグ取得
const canDeleteRow = computed(() => currentRow.value && canEdit.value && currentRow.value.editflg)

//行追加項目
const insertObj = computed(() => {
  const lastItem = tableData.value.at(-1)
  return {
    nitteino: null,
    kaisu: lastItem ? lastItem.kaisu + 1 : 1,
    staffids: [],
    editflg: true
  }
})

const xTableRef = ref<VxeTableInstance>()
const { deleteRow, addRow, currentRow, getTableData } = useTable(
  xTableRef,
  'jigyocdnm',
  'teiin',
  insertObj
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitDetailCourse({
      editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
      copyflg: isCopy,
      courseno: courseno < 0 ? undefined : courseno
    })
    response.value = res
    tableData.value = res.detailinfo
    Object.assign(headerInfo, res.headerinfo)
    //set業務
    headerInfo.gyomukbn =
      res.selectorlist2.find((el) => el.value === res.detailinfo[0]?.jigyocdnm.split(' : ')[0])
        ?.key ?? ''
  } catch (error) {}
  loading.value = false
  setTimeout(() => {
    clearValidate()
    editJudge.reset()
  }, 0)
}

//保存処理
async function saveData() {
  await validate()
  const errMap = await xTableRef.value?.validate(true)
  if (errMap) return Promise.reject()

  for (const row of tableData.value) {
    if (hasRepeatedRow(row)) {
      return
    }
  }

  showSaveModal({
    onOk: async () => {
      try {
        await SaveCourse({
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
          courseno: isNew ? undefined : courseno,
          detailinfo: tableData.value,
          upddttm: response.value.upddttm,
          coursenm: headerInfo.coursenm
        })
        editJudge.reset()
        message.success(SAVE_OK_INFO.Msg)
        back2list(true)
      } catch (error) {}
    }
  })
}

//削除処理
function deleteData() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await DeleteCourse({
          courseno,
          upddttm: response.value.upddttm as string
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        back2list(true)
      } catch (error) {}
    }
  })
}

//行コピー
const copyRow = async () => {
  const $table = xTableRef.value
  if ($table && currentRow.value) {
    const { row } = await $table.insertAt(
      {
        ...currentRow.value,
        nitteino: null,
        kaisu: insertObj.value.kaisu,
        editflg: true,
        _X_ROW_KEY: undefined
      },
      -1
    )
    $table.setCurrentRow(row)
    $table.setEditCell(row, 'jigyocdnm')
  }
}
//行削除
async function handleDeleteRow() {
  await deleteRow()
  tableData.value = getTableData()
}

function back2list(refresh = false) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: refresh ? { refresh: '1' } : {}
    })
  })
}

//業務 : clear table's 事業名
function onChangeGyomu(val, opt) {
  onChangeOpt(val, opt)
  tableData.value.forEach((row) => {
    if (row.editflg) row.jigyocdnm = ''
  })
}

//行重複チェック(事業名、実施予定日、開始時間、会場 all same)-------------------------
const hasRepeatedRow = (row) => {
  const tableData = getTableData()
  const duplicateData = tableData.filter((item) => {
    return (
      item.jigyocdnm === row.jigyocdnm &&
      item.jissiyoteiymd === row.jissiyoteiymd &&
      item.tmf === row.tmf &&
      item.kaijocdnm === row.kaijocdnm
    )
  })
  return duplicateData.length > 1
}
function setCellClass(row, field: string) {
  return ['jigyocdnm', 'jissiyoteiymd', 'tmf', 'kaijocdnm'].includes(field) && hasRepeatedRow(row)
    ? 'bg-errorcell'
    : ''
}

//医療機関
function selectOrganize(val: KikanVM) {
  currentRow.value.kikancdnm = val.kikancd + ' : ' + val.kikannm
}
//担当者
function selectStaff(val: StaffVM) {
  if (currentRow.value.staffids.includes(val.staffid)) {
    message.warning(E001008.Msg.replace('{0}', '担当者'))
  } else {
    currentRow.value.staffids.push(val.staffid)
  }
}
//----------------------------------------------------------------------------------------
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
:deep(.vxe-header--column .vxe-cell--required-icon) {
  display: none;
}
.required::after {
  content: '＊';
  color: #ff0000;
}
</style>
