<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業実施報告書（日報）管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false">
    <div class="self_adaption_table">
      <a-row>
        <a-col :md="12" :xl="6">
          <th>事業報告書番号</th>
          <TD>{{ header.hokokusyono || '' }}</TD>
        </a-col>
        <a-col :md="12" :xl="6">
          <th>更新日時</th>
          <TD>{{ header.upddttm ? getDateHmsJpText(new Date(header.upddttm)) : '' }}</TD>
        </a-col>
        <a-col :md="12" :xl="6">
          <th>更新者</th>
          <TD>{{ header.updusernm }}</TD>
        </a-col>
        <a-col :md="12" :xl="6">
          <th>登録支所</th>
          <TD>{{ header.regsisyo }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button type="primary" :disabled="!exceloutflg" @click="handleExcel">EXCEL出力</a-button>
        <a-button
          class="warning-btn"
          :disabled="!canEdit"
          :loading="loading_save"
          @click="submitData"
          >登録</a-button
        >
        <a-button type="primary" danger :disabled="!canDelete" @click="handleDelete">削除</a-button>
        <a-button type="primary" @click="goList">一覧へ</a-button>
      </a-space>
      <close-page></close-page>
    </div>
  </a-card>
  <a-card class="my-2" :loading="GlobalStore.loading">
    <div :class="[canEdit && 'form', 'self_adaption_table']">
      <a-row>
        <a-col span="12">
          <th class="required">事業コード</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.jigyo">
              <ai-select v-model:value="formData.jigyo" :options="selectorlist5"></ai-select>
            </a-form-item>
          </td>
          <TD v-else>{{ formData.jigyo }}</TD>
        </a-col>
        <a-col span="12">
          <th class="required">会場コード</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.kaijo">
              <ai-select v-model:value="formData.kaijo" :options="selectorlist4"></ai-select>
            </a-form-item>
          </td>
          <TD v-else>{{ formData.kaijo }}</TD>
        </a-col>
        <a-col span="12">
          <th class="required">実施日</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.jissiymd">
              <date-jp v-model:value="formData.jissiymd" style="width: 190px" format="YYYY-MM-DD" />
            </a-form-item>
          </td>
          <TD v-else>{{ formData.jissiymd ? getDateJpText(new Date(formData.jissiymd)) : '' }}</TD>
        </a-col>
        <a-col span="12">
          <th>時間範囲</th>
          <td v-if="canEdit">
            <RangeTime v-model:value1="formData.timef" v-model:value2="formData.timet" />
          </td>
          <TD v-else>{{ formatTime(formData.timef) + '～' + formatTime(formData.timet) }}</TD>
        </a-col>
        <a-col span="24">
          <th class="flex justify-between">
            <span>実施人数(人)</span>
            <span>男性</span>
          </th>
          <th style="width: 76px">延べ人数</th>
          <td v-if="canEdit">
            <a-input-number
              v-model:value="formData.mantotalnum"
              class="w-full"
              :min="0"
              :max="9999"
            />
          </td>
          <TD v-else>{{ formData.mantotalnum }}</TD>
          <th style="width: 75px">実人数</th>
          <td v-if="canEdit">
            <a-input-number v-model:value="formData.mannum" class="w-full" :min="0" :max="9999" />
          </td>
          <TD v-else>{{ formData.mannum }}</TD>
        </a-col>
        <a-col span="24">
          <th style="border-top: none">
            <div class="text-end">女性</div>
          </th>
          <th style="width: 76px">延べ人数</th>
          <td v-if="canEdit">
            <a-input-number
              v-model:value="formData.womantotalnum"
              class="w-full"
              :min="0"
              :max="9999"
            />
          </td>
          <TD v-else>{{ formData.womantotalnum }}</TD>
          <th style="width: 75px">実人数</th>
          <td v-if="canEdit">
            <a-input-number v-model:value="formData.womannum" class="w-full" :min="0" :max="9999" />
          </td>
          <TD v-else>{{ formData.womannum }}</TD>
        </a-col>
        <a-col span="24">
          <th style="border-top: none">
            <div class="text-end">不明</div>
          </th>
          <th style="width: 76px">延べ人数</th>
          <td v-if="canEdit">
            <a-input-number
              v-model:value="formData.fumeitotalnum"
              class="w-full"
              :min="0"
              :max="9999"
            />
          </td>
          <TD v-else>{{ formData.fumeitotalnum }}</TD>
          <th style="width: 75px">実人数</th>
          <td v-if="canEdit">
            <a-input-number v-model:value="formData.fumeinum" class="w-full" :min="0" :max="9999" />
          </td>
          <TD v-else>{{ formData.fumeinum }}</TD>
        </a-col>
        <a-col span="24">
          <th>出席者数（人）</th>
          <td v-if="canEdit">
            <a-input-number
              v-model:value="formData.syussekisya"
              class="w-full"
              :min="0"
              :max="99999"
            />
          </td>
          <TD v-else>{{ formData.syussekisya }}</TD>
        </a-col>
        <a-col span="24">
          <th>
            事業目的
            <div class="show_count_box">
              {{ `${formData.jigyomokuteki?.length ?? 0} / 1000` }}
            </div>
          </th>
          <td v-if="canEdit">
            <a-textarea
              v-model:value="formData.jigyomokuteki"
              :maxlength="1000"
              :auto-size="{ minRows: 2 }"
            />
          </td>
          <td v-else class="textarea">{{ formData.jigyomokuteki }}</td>
        </a-col>
        <a-col span="24">
          <th>
            実施内容
            <div class="show_count_box">
              {{ `${formData.jissinaiyo?.length ?? 0} / 1000` }}
            </div>
          </th>
          <td v-if="canEdit">
            <a-textarea
              v-model:value="formData.jissinaiyo"
              :maxlength="1000"
              :auto-size="{ minRows: 2 }"
            />
          </td>
          <td v-else class="textarea">{{ formData.jissinaiyo }}</td>
        </a-col>
        <a-col span="24">
          <th>
            媒体
            <div class="show_count_box">
              {{ `${formData.baitai?.length ?? 0} / 200` }}
            </div>
          </th>
          <td v-if="canEdit">
            <a-textarea
              v-model:value="formData.baitai"
              :maxlength="200"
              :auto-size="{ minRows: 2 }"
            />
          </td>
          <td v-else class="textarea">{{ formData.baitai }}</td>
        </a-col>
        <a-col span="24">
          <th>
            配布資料
            <div class="show_count_box">
              {{ `${formData.haifusiryo?.length ?? 0} / 1000` }}
            </div>
          </th>
          <td v-if="canEdit">
            <a-textarea
              v-model:value="formData.haifusiryo"
              :maxlength="1000"
              :auto-size="{ minRows: 2 }"
            />
          </td>
          <td v-else class="textarea">{{ formData.haifusiryo }}</td>
        </a-col>
        <a-col span="24">
          <th>
            コメント
            <div class="show_count_box">
              {{ `${formData.comment?.length ?? 0} / 1000` }}
            </div>
          </th>
          <td v-if="canEdit">
            <a-textarea
              v-model:value="formData.comment"
              :maxlength="1000"
              :auto-size="{ minRows: 2 }"
            />
          </td>
          <td v-else class="textarea">{{ formData.comment }}</td>
        </a-col>
        <a-col span="24">
          <th>
            反省点
            <div class="show_count_box">
              {{ `${formData.hanseipoint?.length ?? 0} / 1000` }}
            </div>
          </th>
          <td v-if="canEdit">
            <a-textarea
              v-model:value="formData.hanseipoint"
              :maxlength="1000"
              :auto-size="{ minRows: 2 }"
            />
          </td>
          <td v-else class="textarea">{{ formData.hanseipoint }}</td>
        </a-col>
      </a-row>
    </div>
    <h3 class="font-bold mt-2 mb-1">従事者</h3>
    <a-space class="mb-2">
      <a-button class="btn-round" type="primary" :disabled="!canEdit" @click="addRow"
        >行追加</a-button
      >
      <a-button
        class="btn-round"
        type="primary"
        :disabled="!Boolean(selectedRow) || !canEdit"
        @click="deleteRow"
        >行削除</a-button
      >
    </a-space>
    <vxe-table
      :scroll-y="{ enabled: true, oSize: 10 }"
      :data="tableData"
      :column-config="{ resizable: true }"
      :row-config="{ keyField: 'staffid', isCurrent: true, isHover: true }"
      :sort-config="{ trigger: 'cell' }"
      :empty-render="{ name: 'NotData' }"
      @cell-click="({ row }) => (selectedRow = row)"
    >
      <vxe-column field="staffid" title="事業従事者ID" sortable></vxe-column>
      <vxe-column field="staffsimei" title="事業従事者氏名" sortable> </vxe-column>
      <vxe-column field="kanastaffsimei" title="事業従事者カナ氏名" sortable></vxe-column>
      <vxe-column field="syokusyu" title="職種" sortable></vxe-column>
      <vxe-column field="katudokbn" title="活動区分" sortable></vxe-column>
      <vxe-column field="stopflg" title="利用状態" sortable></vxe-column>
    </vxe-table>
  </a-card>
  <StaffModal v-model:visible="modalVisible" @select="selectStaff" />
</template>

<script setup lang="ts">
import { EnumServiceResult, PageSatatus } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { JissihokokusyoVM, StaffVM } from '../type'
import { Form, message } from 'ant-design-vue'
import {
  E001008,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO,
  DELETE_OK_INFO
} from '@/constants/msg'
import { Delete, Save, InitDetail, SearchDetail, SearchRow } from '../service'
import { showSaveModal } from '@/utils/modal'
import { showDeleteModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { SearchVM } from '@/views/affect/AF/AWAF00704D/type'
import { getDateHmsJpText, getDateJpText, formatTime } from '@/utils/util'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import RangeTime from '@/components/Selector/RangeTime/index.vue'
import { GlobalStore } from '@/store'
import { C003003 } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { getSearchQuery } from '@/utils/util'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
  selectorlist4: DaSelectorModel[]
  selectorlist5: DaSelectorModel[]
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const editJudge = new Judgement(route.name as string)
const modalVisible = ref(false)
const loading_save = ref(false)
const isNew = props.status === PageSatatus.New

const header = reactive({
  hokokusyono: 0,
  upddttm: '',
  updusernm: '',
  regsisyo: ''
})
const formData = reactive<JissihokokusyoVM>({
  jigyo: '',
  kaijo: '',
  jissiymd: '',
  timef: '',
  timet: '',
  mantotalnum: 0,
  womantotalnum: 0,
  fumeitotalnum: 0,
  mannum: 0,
  womannum: 0,
  fumeinum: 0,
  syussekisya: 0
})
const tableData = ref<StaffVM[]>([])

//項目の設定
const rules = reactive({
  jigyo: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業コード') }],
  kaijo: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '会場コード') }],
  jissiymd: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '実施日') }]
})
const { validate, validateInfos } = Form.useForm(formData, rules)

//操作権限フラグ
const exceloutflg = ref(false)
const canEdit = isNew || route.meta.updflg
const canDelete = !isNew && route.meta.delflg

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  GlobalStore.setLoading(true)
  try {
    if (isNew) {
      const res = await InitDetail()
    } else {
      const res = await SearchDetail({
        hokokusyono: isNew ? null : Number(route.query.hokokusyono)
      })
      Object.assign(formData, res.jissihokokusyo ?? {})
      header.hokokusyono = res.hokokusyono
      header.upddttm = res.upddttm as string
      header.updusernm = res.updusernm as string
      header.regsisyo = res.regsisyo as string
      tableData.value = res.stafflist
      exceloutflg.value = res.exceloutflg
    }
    nextTick(() => editJudge.reset())
  } catch (error) {}
  GlobalStore.setLoading(false)
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//保存処理
async function submitData() {
  await validate()

  const params = {
    jissihokokusyo: formData,
    staffids: tableData.value.map((v) => v.staffid),
    hokokusyono: header.hokokusyono,
    upddttm: header.upddttm,
    checkflg: false
  }

  const saveReq = async () => {
    await Save(params)
    message.success(SAVE_OK_INFO.Msg)
    router.push({ name: route.name as string, query: { refresh: '1' } })
  }

  loading_save.value = true
  await Save({ ...params, checkflg: true }, async (response: DaResponseBase) => {
    if (response.returncode === EnumServiceResult.ServiceAlert) {
      await saveReq()
    }
  }).finally(() => (loading_save.value = false))

  showSaveModal({
    onOk: async () => {
      try {
        await saveReq()
      } catch (error) {}
    }
  })
}

//削除処理
async function handleDelete() {
  showDeleteModal({
    onOk: async () => {
      try {
        await Delete({
          hokokusyono: Number(route.query.hokokusyono),
          upddttm: header.upddttm
        })
        message.success(DELETE_OK_INFO.Msg)
        router.push({ name: route.name as string, query: { refresh: '1' } })
      } catch (error) {}
    }
  })
}

//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  })
}

//--------------------------------------------------------------------------
//地区担当者
const selectedRow = ref<StaffVM | null>(null)

function addRow() {
  modalVisible.value = true
}
async function selectStaff(val: SearchVM) {
  if (tableData.value.map((i) => i.staffid).includes(val.staffid)) {
    message.warning(E001008.Msg.replace('{0}', '事業従事者ID'))
    return
  }

  if (tableData.value.length >= 10) {
    message.warning(E001008.Msg.replace('{0}', '従事者情報の件数が最大10件です'))
    return
  }

  const res = await SearchRow({ staffid: val.staffid })
  tableData.value = [...tableData.value, res.staffinfo].sort((a, b) => +a.staffid - +b.staffid)
  editJudge.setEdited()
}
function deleteRow() {
  showDeleteModal({
    onOk() {
      tableData.value = tableData.value.filter((el) => el !== selectedRow.value)
      selectedRow.value = null
      editJudge.setEdited()
    }
  })
}

const fieldMapping = {
  kaijo: '会場コード',
  jigyo: '事業コード'
}
function handleExcel() {
  showConfirmModal({
    content: C003003.Msg.replace('{0}', '帳票出力'),
    onOk: async () => {
      await router.push({ name: 'AWEU00301G' })
      router.push({
        name: 'AWEU00301G',
        query: {
          rptid: '0023',
          outerSearch: 'true',
          事業報告書番号: header.hokokusyono,
          '実施日（開始）': formData.jissiymd,
          '実施日（終了）': formData.jissiymd,
          ...getSearchQuery(formData, fieldMapping)
        }
      })
    }
  })
}
//--------------------------------------------------------------------------
</script>

<style scoped lang="less">
.self_adaption_table th {
  width: 150px;
}
</style>
