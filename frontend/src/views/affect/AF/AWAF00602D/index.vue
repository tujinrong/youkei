<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 電子ファイル情報
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.10
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    title="電子ファイル情報"
    width="1200px"
    centered
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <div class="self_adaption_table">
      <a-row>
        <a-col span="6">
          <th>宛名番号</th>
          <TD>{{ $route.query.atenano }}</TD>
        </a-col>
        <a-col span="6">
          <th>氏名</th>
          <TD>{{ userInfo?.name }}</TD>
        </a-col>
        <a-col span="6">
          <th>カナ氏名</th>
          <TD>{{ userInfo?.kname }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">性別</th>
          <TD>{{ userInfo?.sex }}</TD>
        </a-col>
        <a-col span="6">
          <th>住民区分</th>
          <TD>{{ userInfo?.juminkbn }}</TD>
        </a-col>
        <a-col span="6">
          <th>生年月日</th>
          <TD>{{ userInfo?.bymd }}</TD>
        </a-col>
        <a-col span="6">
          <th>年齢</th>
          <TD>{{ userInfo?.age }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">年齢計算基準日</th>
          <TD>{{ userInfo?.agekijunymd }}</TD>
        </a-col>
      </a-row>
    </div>

    <a-collapse v-model:activeKey="activeKey" class="m-t-1">
      <a-collapse-panel
        key="1"
        :header="'ファイルアップロード' + (uploadFormState.docseq > 0 ? '（編集中）' : '')"
        :show-arrow="false"
      >
        <div class="self_adaption_table" :class="{ form: canEdit }">
          <a-row>
            <a-col span="7">
              <th class="w-26! required">事業名</th>
              <td v-if="canEdit">
                <a-form-item v-bind="validateInfos.jigyo">
                  <ai-select v-model:value="uploadFormState.jigyo" :options="titleOptions" />
                </a-form-item>
              </td>
              <TD v-else>{{ uploadFormState.jigyo }}</TD>
            </a-col>
            <a-col span="7">
              <th>タイトル</th>
              <td v-if="canEdit">
                <a-input v-model:value="uploadFormState.title" maxlength="100" allow-clear />
              </td>
              <TD v-else>{{ uploadFormState.title }}</TD>
            </a-col>
            <a-col span="4">
              <th>重要</th>
              <td>
                <a-checkbox
                  v-model:checked="uploadFormState.juyoflg"
                  :disabled="!canEdit"
                  class="px-2"
                ></a-checkbox>
              </td>
            </a-col>
            <a-col span="6">
              <th class="bg-readonly">登録支所</th>
              <TD>{{ uploadFormState.regsisyonm }}</TD>
            </a-col>
            <a-col span="14">
              <th class="w-26! required">ファイル名</th>
              <td v-if="canEdit">
                <a-form-item v-bind="validateInfos.filenm">
                  <a-input v-model:value="uploadFormState.filenm" maxlength="255" />
                </a-form-item>
              </td>
              <TD v-else>{{ uploadFormState.filenm }}</TD>
            </a-col>
            <a-col>
              <a-upload
                v-if="hasAddOrUpd"
                class="m-l-1 pt-1 flex items-center"
                :file-list="fileList"
                accept=".csv,.doc,.jpg,.jpeg,.png,.pdf,.tif,.txt,.xml,.xls,.xlsm,.xlsx,.zip"
                :before-upload="beforeUploadFile"
                @remove="removeFile"
              >
                <a-button v-show="canEdit" type="primary">選択</a-button>
              </a-upload>
            </a-col>
          </a-row>
        </div>
      </a-collapse-panel>
    </a-collapse>
    <a-collapse active-key="2" class="m-t-1">
      <a-collapse-panel key="2" header="ファイルダウンロード/削除" :show-arrow="false">
        <a-spin :spinning="tableLoading">
          <div class="self_adaption_table form mb-2">
            <a-row>
              <a-col span="7">
                <th class="w-25">事業名</th>
                <td class="flex">
                  <ai-select v-model:value="searchParams.jigyocd" :options="fileTypeOptions" />
                </td>
              </a-col>
              <a-col span="7">
                <th class="w-25">タイトル</th>
                <td>
                  <a-input v-model:value="searchParams.title" allow-clear />
                </td>
              </a-col>
              <a-col class="flex items-center">
                <a-button type="primary" class="m-l-1" @click="searchData">検索</a-button>
              </a-col>
            </a-row>
          </div>
          <a-pagination
            class="absolute top-1 right-0"
            :current="searchParams.pagenum"
            :page-size="searchParams.pagesize"
            :total="totalCount"
            :page-size-options="$pagesizes"
            show-less-items
            show-size-changer
            size="small"
            style="float: right"
            @change="changePage"
          />
          <a-row :gutter="10">
            <a-col :lg="16">
              <vxe-table
                ref="xTableRef"
                :height="imgHeight"
                :column-config="{ resizable: true }"
                :row-config="{ keyField: 'docseq', isCurrent: true, isHover: true, height: 36 }"
                :data="tableData"
                :sort-config="{
                  trigger: 'cell',
                  remote: true
                }"
                :checkbox-config="{ trigger: 'row', reserve: true }"
                :empty-render="{ name: 'NotData' }"
                @cell-click="onClickRow"
                @checkbox-change="selectCheckbox"
                @checkbox-all="selectCheckbox"
                @sort-change="(e) => changeTableSort(e, toRef(searchParams, 'orderby'))"
              >
                <vxe-column type="checkbox" width="50" header-class-name="bg-editable"></vxe-column>
                <vxe-column
                  field="imgflg"
                  :params="{ order: 1 }"
                  title="画像"
                  sortable
                  width="70"
                  min-width="60"
                  header-class-name="text-center"
                >
                  <template #default="{ row }">
                    <span>{{ row.imgflg ? '○' : '' }}</span>
                  </template>
                </vxe-column>
                <vxe-column
                  field="title"
                  :params="{ order: 2 }"
                  title="タイトル"
                  sortable
                  min-width="100"
                />
                <vxe-column
                  field="regdttm"
                  :params="{ order: 3 }"
                  title="アッブロード日時"
                  show-header-overflow
                  formatter="jpTimeSimple"
                  width="150"
                  min-width="150"
                  sortable
                />
                <vxe-column
                  field="jigyonm"
                  :params="{ order: 4 }"
                  title="事業名"
                  sortable
                  min-width="90"
                />
                <vxe-column
                  field="filenm"
                  :params="{ order: 5 }"
                  title="ファイル名"
                  sortable
                  min-width="110"
                />
                <vxe-column
                  field="juyoflg"
                  :params="{ order: 6 }"
                  title="重要"
                  sortable
                  width="70"
                  min-width="60"
                  header-class-name="text-center"
                >
                  <template #default="{ row }">
                    <span>{{ row.juyoflg ? '○' : '' }}</span>
                  </template>
                </vxe-column>
                <vxe-column
                  field="regsisyonm"
                  :params="{ order: 7 }"
                  title="登録支所"
                  sortable
                  min-width="90"
                />
              </vxe-table>
            </a-col>
            <a-col :lg="8">
              <a-spin :spinning="previewLoading" wrapper-class-name="preview-spin-wrapper">
                <div
                  class="img-wrapper"
                  :style="{ height: imgHeight + 'px', backgroundImage: `url(${currentImgUrl})` }"
                >
                  <a-image
                    v-if="currentImgUrl"
                    :height="imgHeight"
                    :width="365"
                    :preview="{ src: currentImgUrl }"
                  >
                    <template #previewMask>
                      <div><eye-outlined /> プレビュー</div>
                    </template>
                  </a-image>
                </div>
              </a-spin>
            </a-col>
          </a-row>
        </a-spin>
      </a-collapse-panel>
    </a-collapse>

    <template #footer>
      <a-space style="float: left">
        <a-button
          v-if="hasAddOrUpd"
          type="warn"
          :disabled="!canSave"
          :loading="uploadLoading"
          @click="saveData"
          >登録</a-button
        >
        <a-button type="primary" :disabled="selectedRows.length <= 0" @click="downloadFiles"
          >ダウンロード</a-button
        >
        <a-button
          v-if="kengen.deleteflg"
          type="primary"
          danger
          :disabled="!canDelete"
          @click="deleteRow"
          >削除</a-button
        >
        <a-button type="primary" @click="reset">クリア</a-button>
      </a-space>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { ref, computed, reactive, watch, toRef, nextTick } from 'vue'
import { EyeOutlined } from '@ant-design/icons-vue'
import { Form, message } from 'ant-design-vue'
import {
  DELETE_OK_INFO,
  DOWNLOAD_CONFIRM,
  DOWNLOAD_OK_INFO,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  RESEARCH_CONFIRM,
  UPLOAD_CONFIRM,
  UPLOAD_OK_INFO
} from '@/constants/msg'
import { showConfirmModal, showDeleteModal } from '@/utils/modal'
import { SearchRequest, SaveVM, DeleteRequest, SearchVM } from './type'
import { Delete, Search, Save, Download, Preview, Init } from './service'
import { changeTableSort } from '@/utils/util'
import TD from '@/components/Common/TableTD/index.vue'
import { Enum共通バー番号, Enum名称区分, Enum編集区分 } from '#/Enums'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'
import emitter from '@/utils/event-bus'
import { getBarKengen } from '@/utils/user'
import { ss } from '@/utils/storage'
import { REGSISYO } from '@/constants/mutation-types'

type SearchParams = Omit<SearchRequest, 'atenano'>
interface FormVM extends SaveVM {
  updflg: boolean //個々の更新権限フラグ
  regsisyonm: string
}
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const modalVisible = ref(false)
//ローディング
const tableLoading = ref(false)
const uploadLoading = ref(false)
const previewLoading = ref(false)
//折りたたみパネル
const activeKey = ref(['1'])
//画面データ編集判断
const editJudge = new Judgement()
//ビューモデル
const xTableRef = ref<VxeTableInstance>()
const atenano = route.query.atenano as string
const userInfo = ref<CommonBarHeaderBaseVM | null>(null)
const titleOptions = ref<DaSelectorModel[]>([])
const fileTypeOptions = ref<DaSelectorModel[]>([])
const tableData = ref<SearchVM[]>([])
const uploadFormState = reactive<FormVM>({
  title: '',
  jigyo: '',
  filenm: '',
  juyoflg: false,
  docseq: 0,
  upddttm: null,
  regsisyonm: ss.get(REGSISYO).sisyonm,
  updflg: true
})
const fileList = ref<File[]>([])
const selectedRows = ref<SearchVM[]>([])
const currentImgUrl = ref('')
//ページャー
const totalCount = ref(0)
const searchParams = reactive(createDefaultSearchModel())

//項目の設定
const rules = reactive({
  jigyo: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業名')
    }
  ],
  filenm: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ファイル名')
    }
  ]
})
const useForm = Form.useForm
const { validate, validateInfos, resetFields, clearValidate } = useForm(uploadFormState, rules)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限取得
const kengen = computed(() => getBarKengen(Enum共通バー番号.電子ファイル情報))
//保存権限(登録ボタン)
const canSave = computed(() => {
  return uploadFormState.docseq > 0
    ? kengen.value.updateflg && uploadFormState.updflg
    : kengen.value.addflg && fileList.value.length > 0
})
//変更権限(参照モード)
const canEdit = computed(() => {
  return uploadFormState.docseq > 0
    ? kengen.value.updateflg && uploadFormState.updflg
    : kengen.value.addflg
})
//削除権限(削除ボタン)
const canDelete = computed(() => {
  return (
    kengen.value.deleteflg &&
    selectedRows.value.length > 0 &&
    selectedRows.value.every((row) => row.updflg)
  )
})
//ボタン権限(登録/ファイル選択)：新規と更新の権限がない場合、ボタン非表示
const hasAddOrUpd = computed(() => {
  return kengen.value.addflg || kengen.value.updateflg
})

// 画像高さ
const imgHeight = computed(() => {
  return activeKey.value.includes('1') ? 250 : 360
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//ソート
watch(
  () => searchParams.orderby,
  () => getTableData(searchParams)
)
//更新の場合、アップロード情報を表示
watch(
  () => fileList.value,
  (val) => {
    if (val?.length) {
      const filename = val[0].name
      const lastIndex = filename.lastIndexOf('.')
      uploadFormState.filenm = filename.substring(0, lastIndex)
    } else {
      uploadFormState.filenm = ''
      clearValidate()
    }
  }
)
watch(uploadFormState, () => editJudge.setEdited())

//画像を展示
watch(
  () => xTableRef.value?.getCurrentRecord(),
  async (row) => {
    fileList.value = []
    if (!row) resetFields()
    if (row?.imgflg) {
      previewLoading.value = true
      try {
        const res = await Preview({ docseq: row.docseq, atenano })
        currentImgUrl.value = URL.createObjectURL(res)
      } catch (error) {}
      previewLoading.value = false
    } else {
      currentImgUrl.value = ''
    }
  }
)

//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//検索パラメータ(初期化)
function createDefaultSearchModel(): SearchParams {
  return {
    patternno: route.query.patternno as string,
    title: '',
    jigyocd: '',
    pagesize: 25,
    pagenum: 1,
    orderby: 0
  }
}
//初期化処理
async function openModal() {
  modalVisible.value = true
  xTableRef.value?.clearSort()
  Object.assign(searchParams, createDefaultSearchModel())
  getTableData(searchParams)
  if (!titleOptions.value?.[0]) {
    const res = await Init({ kbn: Enum名称区分.名称, patternno: route.query.patternno as string })
    titleOptions.value = res.selectorlist
    fileTypeOptions.value = [{ value: '', label: 'すべて' }, ...res.selectorlist]
  }
}

//検索処理
function searchData() {
  clearSelected()
  getTableData(searchParams)
}
async function getTableData(params: SearchParams) {
  tableLoading.value = true
  try {
    const res = await Search({ ...params, atenano })
    if (res.totalpagecount < searchParams.pagenum) {
      searchParams.pagenum = 1
    }
    userInfo.value = res.headerinfo
    tableData.value = res.kekkalist
    totalCount.value = res.totalrowcount
  } catch (error) {}
  tableLoading.value = false
}

//プレビュー処理
function onClickRow({ row }: { row: SearchVM }) {
  if (row.docseq === uploadFormState.docseq) {
    const $table = xTableRef.value
    $table?.clearCurrentRow()
    resetFields()
  } else {
    Object.assign(uploadFormState, {
      ...row,
      filenm: row.filenm.slice(0, row.filenm.lastIndexOf('.')) //without suffix
    })
  }
  nextTick(() => {
    editJudge.reset()
  })
}

//ページ変更
const changePage = (newPage, pageSize) => {
  editJudge.judgeIsEdited(async () => {
    searchParams.pagenum = newPage
    searchParams.pagesize = pageSize
    await getTableData(searchParams)
    setTimeout(() => editJudge.reset(), 0)
  }, RESEARCH_CONFIRM.Msg)
}

//---------------------------------------------------------------------------
//保存処理(アップロード)
function beforeUploadFile(file) {
  fileList.value = [file]
  return false
}
function removeFile(file) {
  fileList.value = []
}
async function saveData() {
  await validate()
  showConfirmModal({
    handleDB: true,
    content: UPLOAD_CONFIRM,
    onOk: async () => {
      uploadLoading.value = true
      try {
        await Save({
          atenano,
          files: fileList.value,
          editkbn: uploadFormState.docseq > 0 ? Enum編集区分.変更 : Enum編集区分.新規,
          savevm: uploadFormState,
          filerequired: fileList.value.length > 0
        })
        message.success(UPLOAD_OK_INFO.Msg)
        uploadLoading.value = false
        reset()
        emitter.emit('refreshBar', route.name)
        getTableData(searchParams)
      } catch (error) {
        uploadLoading.value = false
      }
    }
  })
}
//---------------------------------------------------------------------------

//ダウンロード処理
function downloadFiles() {
  showConfirmModal({
    content: DOWNLOAD_CONFIRM,
    onOk: async () => {
      const docseqs = selectedRows.value.map((el) => el.docseq)
      await Download({ atenano, docseqs })
      message.success(DOWNLOAD_OK_INFO.Msg)
    }
  })
}

//削除処理
function deleteRow() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      const deleteParams: DeleteRequest = {
        atenano,
        locklist: selectedRows.value.map((item) => {
          return {
            docseq: item.docseq,
            upddttm: item.upddttm
          }
        })
      }
      await Delete(deleteParams)
      message.success(DELETE_OK_INFO.Msg)
      reset()
      getTableData(searchParams)
    }
  })
}

//選択をキャンセル
function clearSelected() {
  selectedRows.value = []
  const $table = xTableRef.value
  $table?.clearCheckboxRow()
  $table?.clearCheckboxReserve()
  $table?.clearCurrentRow()
}
//行選択(更新/削除/ダウンロード)
function selectCheckbox() {
  const $table = xTableRef.value
  if ($table) {
    const records = $table.getCheckboxRecords()
    const records2 = $table.getCheckboxReserveRecords()
    selectedRows.value = [...records, ...records2]
  }
}

//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    reset()
  })
}
//リセット
function reset() {
  resetFields()
  clearSelected()
  fileList.value = []
  searchParams.pagenum = 1
  nextTick(() => {
    editJudge.reset()
  })
}

defineExpose({
  open: openModal
})
</script>
<style src="./index.less" scoped></style>
