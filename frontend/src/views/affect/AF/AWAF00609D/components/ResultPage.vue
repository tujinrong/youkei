<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: フォロー管理(結果画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.28
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <div>
      <Header :data="header" :show-sisyo="showSisyo" :regsisyo="regsisyo" />
      <div class="flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="loading || !canEdit" @click="saveData">登録</a-button>
          <a-button type="primary" danger :disabled="loading || !canDelete" @click="handleDelete"
            >削除</a-button
          >
          <a-button type="primary" @click="editJudge.judgeIsEdited(() => forwardList())"
            >一覧へ</a-button
          >
        </a-space>
        <WarnAlert v-if="header?.keikoku" />
      </div>
    </div>

    <a-card class="mt-4" :loading="loading">
      <b>フォロー内容情報</b>
      <div class="self_adaption_table mb-4" :class="{ form: canEdit }">
        <a-row>
          <a-col span="12">
            <th class="bg-readonly">フォロー内容枝番</th>
            <TD>{{ isNew ? '' : formData.follownaiyoedano }}</TD>
          </a-col>
          <a-col span="12">
            <th>把握経路</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.haakukeiro" :options="haakukeiroList" />
            </td>
            <TD v-else>{{ formData.haakukeiro }}</TD>
          </a-col>
          <a-col span="12">
            <th>把握事業</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.haakujigyocd" :options="haakujigyoList" />
            </td>
            <TD v-else>{{ formData.haakujigyocd }}</TD>
          </a-col>
          <a-col span="12">
            <th class="required">フォロー状況</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.followstatus">
                <ai-select v-model:value="formData.followstatus" :options="followstatusList"
              /></a-form-item>
            </td>
            <TD v-else>{{ formData.followstatus }}</TD>
          </a-col>
          <a-col span="24">
            <th>
              フォロー内容
              <div class="show_count_box">
                {{ `${formData.follownaiyo?.length ?? 0} / 200` }}
              </div>
            </th>
            <td v-if="canEdit">
              <a-textarea
                v-model:value="formData.follownaiyo"
                maxlength="200"
                :auto-size="{ minRows: 2 }"
              />
            </td>
            <td v-else class="textarea">{{ formData.follownaiyo }}</td>
          </a-col>
        </a-row>
      </div>

      <div class="font-bold">フォロー予定結果情報一覧</div>
      <div class="flex justify-between mb-2">
        <a-space>
          <a-button type="primary" :disabled="isNew || !kengen.addflg" @click="forwardDetail"
            >新規</a-button
          >
          <a-button
            type="primary"
            :disabled="isNew || (!kengen.addflg && !kengen.updateflg) || edano <= 0"
            @click="clickCopyBtn"
            >コピー</a-button
          >
        </a-space>
        <a-space>
          <div>
            フォロー事業
            <a-select
              v-model:value="filterParams.followjigyocd"
              :options="followjigyoList"
              class="w-40"
            />
          </div>
          <div>
            担当
            <a-select
              v-model:value="filterParams.followstaffid"
              :options="followstaffidList"
              class="w-40"
            />
          </div>
        </a-space>
      </div>
      <vxe-table
        ref="xTableRef"
        :height="303"
        :data="filterData"
        :scroll-y="{ enabled: true, oSize: 10 }"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :empty-render="{ name: 'NotData' }"
        :sort-config="{ trigger: 'cell' }"
        @cell-dblclick="({ row }) => forwardDetail(row)"
      >
        <vxe-column field="followjigyocd" title="フォロー事業" sortable width="160" min-width="100">
          <template #default="{ row }">
            <a @click="forwardDetail(row)">{{ row.followjigyocd }}</a>
          </template>
        </vxe-column>
        <vxe-colgroup title="フォロー予定情報" align="center">
          <vxe-column field="followhoho_yotei" title="方法" sortable width="160" min-width="100" />
          <vxe-column field="followyoteiymd" title="予定日" sortable min-width="100"></vxe-column>
          <vxe-column
            field="followtm_yotei"
            title="時間"
            min-width="100"
            formatter="splitTime"
            sortable
          ></vxe-column>
          <vxe-column field="followkaijocd_yotei" title="会場" sortable min-width="100" />
          <vxe-column field="followstaffid_yotei" title="担当者" sortable min-width="100" />
        </vxe-colgroup>
        <vxe-colgroup title="フォロー結果情報" align="center">
          <vxe-column field="followhoho" title="方法" sortable width="160" min-width="100" />
          <vxe-column field="followjissiymd" title="実施日" sortable min-width="100"></vxe-column>
          <vxe-column
            field="followtm"
            title="時間"
            min-width="100"
            formatter="splitTime"
            sortable
          ></vxe-column>
          <vxe-column field="followkaijocd" title="会場" sortable min-width="100"></vxe-column>
          <vxe-column field="followstaffid" title="担当者" sortable min-width="100" />
        </vxe-colgroup>
      </vxe-table>
    </a-card>
  </div>
  <DetailPage
    v-if="status !== PageSatatus.List"
    v-bind="{
      status,
      follownaiyoedano,
      header,
      edano,
      copyflg,
      editJudge,
      regsisyo,
      showSisyo
    }"
    @back="resetDetail"
  />
</template>

<script setup lang="ts">
import { Enum共通バー番号, Enum編集区分, PageSatatus } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { DELETE_OK_INFO, ITEM_SELECTREQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { useTableFilter } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { getBarKengen } from '@/utils/user'
import { table2Opts } from '@/utils/util'
import { RowFollowKekkaVM } from '@/views/affect/KK/AWKK00401G/type'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { DeleteFollowNaiyo, InitFollowNaiyo, SaveFollowNaiyo, SearchFollowNaiyo } from '../service'
import DetailPage from './DetailPage.vue'
import Header from './Header.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  header: CommonBarHeaderBase3VM | null
  follownaiyoedano: number
}>()
const emit = defineEmits(['forwardList'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const editJudge = new Judgement()
const atenano = route.query.atenano as string
const tableList = ref<RowFollowKekkaVM[]>([])
const loading = ref(false)
const regsisyo = ref('')
const showSisyo = ref(false)

const formData = reactive<RowFollowKekkaVM>({
  atenano,
  follownaiyoedano: 0,
  haakukeiro: '',
  haakujigyocd: '',
  followstatus: '',
  edano: 0,
  followjigyocd: '',
  followhoho_yotei: '',
  followyoteiymd: '',
  followtm_yotei: '',
  followkaijocd_yotei: '',
  followstaffid_yotei: '',
  followriyu: '',
  followhoho: '',
  followjissiymd: '',
  followtm: '',
  followkaijocd: '',
  followstaffid: '',
  followkekka: '',
  updflg: true
})

const haakukeiroList = ref<DaSelectorModel[]>([])
const haakujigyoList = ref<DaSelectorModel[]>([])
const followstatusList = ref<DaSelectorModel[]>([])

//項目の設定
const rules = reactive({
  followstatus: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'フォロー状況') }
  ]
})
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)

//操作権限取得
const isNew = props.follownaiyoedano === -1
const kengen = computed(() => getBarKengen(Enum共通バー番号.フォロー管理))
const canEdit = computed(() => isNew || (kengen.value.updateflg && formData.updflg))
const canDelete = computed(() => !isNew && kengen.value.deleteflg)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  init()
  if (!isNew) searchList()
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//初期化処理
function init() {
  InitFollowNaiyo({ atenano }).then((res) => {
    if (isNew) {
      regsisyo.value = res.regsisyo
      showSisyo.value = res.showflg
    }
    haakukeiroList.value = res.haakukeiroList
    haakujigyoList.value = res.haakujigyoList
    followstatusList.value = res.followstatusList
    if (isNew) {
      formData.follownaiyoedano = res.follownaiyoedano
      nextTick(() => editJudge.reset())
    }
  })
}

function forwardList(no?: number) {
  emit('forwardList', no)
}

//検索処理
const searchList = async () => {
  loading.value = true
  try {
    const res = await SearchFollowNaiyo({ atenano, follownaiyoedano: props.follownaiyoedano })

    regsisyo.value = res.regsisyo
    showSisyo.value = res.showflg

    tableList.value = res.kekkalist.filter((el) => el.followjigyocd !== '')
    Object.assign(formData, res.followkekkavm)

    followstaffidList.value = table2Opts(res.kekkalist, 'followstaffid')
    followjigyoList.value = table2Opts(res.kekkalist, 'followjigyocd')
  } catch (error) {}
  loading.value = false
  nextTick(() => {
    clearValidate()
    editJudge.reset()
  })
}

//保存処理
const saveData = async () => {
  await validate()
  showSaveModal({
    onOk: async () => {
      await SaveFollowNaiyo({
        rowfollowkekka: formData,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
      })
      message.success(SAVE_OK_INFO.Msg)
      forwardList(formData.follownaiyoedano)
      nextTick(() => editJudge.reset())
    }
  })
}

//削除処理
function handleDelete() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      await DeleteFollowNaiyo({
        atenano,
        follownaiyoedano: formData.follownaiyoedano,
        upddttm: formData.upddttm ?? ''
      })
      message.success(DELETE_OK_INFO.Msg)
      forwardList()
    }
  })
}

//詳細画面-------------------------------------------------
const status = ref(PageSatatus.List)
const copyflg = ref(false)

const xTableRef = ref<VxeTableInstance>()
const edano = computed<number>(() => {
  const curRow = xTableRef.value?.getCurrentRecord()
  return curRow?.edano ?? 0
})

//コピーをクリック
function clickCopyBtn() {
  copyflg.value = true
  const curRow = xTableRef.value?.getCurrentRecord()
  forwardDetail(curRow)
}

function forwardDetail(val: { edano: number }) {
  if (val.edano) {
    xTableRef.value?.setCurrentRow(val)
    status.value = copyflg.value ? PageSatatus.New : PageSatatus.Edit
  } else {
    status.value = PageSatatus.New
    xTableRef.value?.clearCurrentRow()
  }
}

function resetDetail({ refresh }) {
  status.value = PageSatatus.List
  copyflg.value = false
  if (refresh) searchList()
}
//--------------------------------------------------------

//フィルター----------------------------------------------------------------------------------
const filterParams = reactive({
  followjigyocd: '', //フォロー事業
  followstaffid: '' //担当
})
const followstaffidList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const followjigyoList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])

const { filterData } = useTableFilter(tableList, filterParams)
//----------------------------------------------------------------------------------

defineExpose({ editJudge })
</script>

<style lang="less" scoped>
th {
  width: 135px;
}
</style>
