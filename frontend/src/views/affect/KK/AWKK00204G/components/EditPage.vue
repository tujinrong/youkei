<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 地区保守(詳細画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false">
    <div class="self_adaption_table" :class="{ form: isNew }">
      <a-row>
        <a-col :md="12" :lg="8" :xxl="7">
          <th class="required">地区区分</th>
          <td v-if="isNew">
            <a-form-item v-bind="validateInfos.tikukbn">
              <ai-select v-model:value="formData.tikukbn" :options="kbnOptions"></ai-select>
            </a-form-item>
          </td>
          <TD v-else>{{ tikukbnStr }}</TD>
        </a-col>
        <a-col :md="12" :lg="8" :xxl="7">
          <th class="required">地区コード</th>
          <td v-if="isNew">
            <a-form-item v-bind="validateInfos.tikucd">
              <a-input
                v-model:value="formData.tikucd"
                maxlength="12"
                allow-clear
                @change="formData.tikucd = replaceText(formData.tikucd, EnumRegex.半角英数)"
              ></a-input>
            </a-form-item>
          </td>
          <TD v-else>{{ route.query.tikucd }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button class="warning-btn" :disabled="!canEdit" @click="submitData">登録</a-button>
        <a-button type="primary" @click="goList">一覧へ</a-button>
      </a-space>
      <close-page></close-page>
    </div>
  </a-card>
  <a-card class="my-2" :loading="loading">
    <a-checkbox v-model:checked="formData.stopflg" class="mb-1" :disabled="!canEdit">
      利用停止
    </a-checkbox>
    <div class="self_adaption_table ml-[1px]" :class="{ form: canEdit }">
      <a-row>
        <a-col :md="24" :lg="16" :xxl="14">
          <th class="required">地区名</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.tikunm">
              <a-input
                v-model:value="formData.tikunm"
                maxlength="100"
                allow-clear
                @change="formData.tikunm = replaceText(formData.tikunm, EnumRegex.全角)"
              ></a-input>
            </a-form-item>
          </td>
          <TD v-else>{{ formData.tikunm }}</TD>
        </a-col>
        <a-col :md="24" :lg="16" :xxl="14">
          <th class="required">地区名(カナ)</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.kanatikunm">
              <a-input
                v-model:value="formData.kanatikunm"
                maxlength="100"
                allow-clear
                @change="formData.kanatikunm = replaceText(formData.kanatikunm, EnumRegex.カナ)"
              ></a-input>
            </a-form-item>
          </td>
          <TD v-else>{{ formData.kanatikunm }}</TD>
        </a-col>
      </a-row>
    </div>
    <h3 class="font-bold mt-2 mb-1">地区担当者</h3>
    <a-space>
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
    <div class="w-full mt-2" :style="{ height: tableHeight }">
      <vxe-table
        height="100%"
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
      </vxe-table>
    </div>
  </a-card>
  <StaffModal v-model:visible="modalVisible" @select="selectStaff" />
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import { computed, onMounted, reactive, ref, watch, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { SaveMainVM, SubInfoVM } from '../type'
import { Form, message } from 'ant-design-vue'
import {
  E001008,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { InitList, Save, SearchDetail, SearchRow } from '../service'
import { getHeight } from '@/utils/height'
import { showSaveModal } from '@/utils/modal'
import { showDeleteModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import { SearchVM } from '@/views/affect/AF/AWAF00704D/type'
import { replaceText } from '@/utils/util'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(true)
const editJudge = new Judgement(route.name as string)

const modalVisible = ref(false)
const isNew = props.status === PageSatatus.New

const formData = reactive<SaveMainVM>({
  tikukbn: '',
  stopflg: false,
  tikucd: '',
  tikunm: '',
  kanatikunm: ''
})

const kbnOptions = ref<DaSelectorModel[]>([])
const tableData = ref<SubInfoVM[]>([])

//項目の設定
const rules = reactive({
  tikukbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '地区区分') }],
  tikucd: [{ required: isNew, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '地区コード') }],
  tikunm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '地区名') }],
  kanatikunm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '地区名(カナ)') }]
})
const { validate, validateInfos } = Form.useForm(formData, rules)

//操作権限フラグ
const canEdit = isNew || route.meta.updflg
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  InitList().then((res) => (kbnOptions.value = res.selectorlist1))
  if (!isNew) {
    try {
      const res = await SearchDetail({
        tikucd: route.query.tikucd as string,
        tikukbn: route.query.tikukbn as string
      })
      Object.assign(formData, res.maininfo)
      formData.tikukbn = route.query.tikukbn as string
      tableData.value = res.stafflist
      nextTick(() => editJudge.reset())
    } catch (error) {}
  }
  loading.value = false
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => getHeight(374))
//地区区分
const tikukbnStr = computed(() => {
  const opt = kbnOptions.value.find((el) => el.value === formData.tikukbn)
  return opt ? opt.value + ' : ' + opt.label : ''
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function submitData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      await Save({
        maininfo: formData,
        stafflist: tableData.value.map((item) => item.staffid),
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
      })
      message.success(SAVE_OK_INFO.Msg)
      router.push({ name: route.name as string, query: { refresh: '1' } })
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
const selectedRow = ref<SubInfoVM | null>(null)

function addRow() {
  modalVisible.value = true
}
async function selectStaff(val: SearchVM) {
  if (tableData.value.map((i) => i.staffid).includes(val.staffid)) {
    message.warning(E001008.Msg.replace('{0}', '事業従事者ID'))
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
//--------------------------------------------------------------------------
</script>

<style scoped lang="less">
.self_adaption_table th {
  width: 130px;
}
</style>
