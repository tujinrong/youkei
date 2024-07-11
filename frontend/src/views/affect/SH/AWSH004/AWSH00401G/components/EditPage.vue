<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健（検）診予定管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.14
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="8" :xl="6" :xxl="4">
            <th>年度</th>
            <TD>{{ yearFormatter(nendo) }}</TD>
          </a-col>
          <a-col :md="8" :xl="6" :xxl="5">
            <th>日程番号</th>
            <TD>{{ !isNew && !isCopy ? nitteino : '' }}</TD>
          </a-col>
          <a-col :md="8" :xl="6" :xxl="5">
            <th>登録支所</th>
            <TD>{{ formData.regsisyonm || ss.get(REGSISYO).sisyonm }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="saveData">登録</a-button>
          <a-button type="primary" :disabled="!canDelete" danger @click="deleteData">削除</a-button>
          <a-button type="primary" @click="back2list()">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card class="my-2">
      <div class="self_adaption_table mb-4 max-w-300" :class="canEdit && 'form'">
        <a-row>
          <a-col span="12">
            <th class="required">事業名</th>
            <td>
              <a-form-item v-bind="validateInfos.jigyocdnm">
                <ai-select
                  v-model:value="formData.jigyocdnm"
                  :options="response.selectorlist1"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">実施予定日</th>
            <td>
              <a-form-item v-bind="validateInfos.yoteiymd">
                <DateJp
                  v-model:value="formData.yoteiymd"
                  style="width: 190px"
                  format="YYYY-MM-DD"
                  :hanif="nendo + '-04-01'"
                  :hanit="nendo + 1 + '-03-31'"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">開始時間</th>
            <td>
              <a-form-item v-bind="validateInfos.timef">
                <a-time-picker v-model:value="formData.timef" value-format="HHmm" format="HH:mm" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>終了時間</th>
            <td>
              <a-time-picker
                v-model:value="formData.timet"
                value-format="HHmm"
                format="HH:mm"
                @change="validate('timef')"
              />
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">会場</th>
            <td>
              <a-form-item v-bind="validateInfos.kaijocdnm">
                <ai-select
                  v-model:value="formData.kaijocdnm"
                  :options="response.selectorlist2"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>医療機関</th>
            <td class="flex gap-1">
              <ai-select
                v-model:value="formData.kikancdnm"
                :options="response.selectorlist3"
              ></ai-select>
              <OrganizeButton @select="selectOrganize"></OrganizeButton>
            </td>
          </a-col>
          <a-col span="18">
            <th>担当者</th>
            <td class="flex gap-1">
              <a-select
                v-model:value="formData.staffids"
                mode="multiple"
                class="w-full"
                max-tag-count="responsive"
                allow-clear
                :options="response.selectorlist4"
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
              <a-button class="btn-round" type="primary" @click="modalVisible = true">
                検索
              </a-button>
            </td>
          </a-col>
          <a-col span="6">
            <th class="required">定員</th>
            <td>
              <a-form-item v-bind="validateInfos.teiin">
                <a-input-number
                  v-model:value="formData.teiin"
                  :min="1"
                  :max="9999"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>

      <vxe-table
        :data="tableData"
        :loading="loading_table"
        :height="Math.max(tableHeight, 400)"
        :row-config="{ height: 40, keyField: 'yoyakubunruicd' }"
        :empty-render="{ name: 'NotData' }"
        style="max-width: 800px"
      >
        <vxe-column field="yoyakubunruinm" title="検診名"> </vxe-column>
        <vxe-column
          field="teiin_kensin"
          title="定員"
          :header-class-name="canEdit && formData.jigyocdnm ? 'bg-editable' : 'bg-readonly'"
          :edit-render="{ autofocus: 'input' }"
          width="120px"
        >
          <template #default="{ row }: { row: RowVM }">
            <a-input-number
              v-if="canEdit && formData.jigyocdnm && row.editable"
              v-model:value="row.teiin_kensin"
              :precision="0"
              :min="0"
              :max="formData.teiin ?? 0"
            />
            <span v-else>{{ row.teiin_kensin }}</span>
          </template>
        </vxe-column>
      </vxe-table>
    </a-card>

    <StaffModal v-model:visible="modalVisible" @select="selectStaff" />
  </a-spin>
</template>

<script setup lang="ts">
import { Enum編集区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import {
  DELETE_OK_INFO,
  E001008,
  E003008,
  ITEM_RANGE_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { REGSISYO } from '@/constants/mutation-types'
import { useTableHeight } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { getDateJpText, yearFormatter } from '@/utils/util'
import OrganizeButton from '@/views/affect/AF/AWAF00702D/button.vue'
import { SearchVM as KikanVM } from '@/views/affect/AF/AWAF00702D/type'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'
import { SearchVM as StaffVM } from '@/views/affect/AF/AWAF00704D/type'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watch, watchEffect } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Delete, GetEditYoyaku, InitDetail, Save } from '../service'
import { DetailVM, InitDetailResponse, RowVM } from '../type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const loading_table = ref(false)
const modalVisible = ref(false)
const editJudge = new Judgement(route.name as string)

const nendo = Number(route.query.nendo)
const nitteino = Number(route.query.nitteino)
const isCopy = Boolean(route.query.iscopy)
const isNew = nitteino < 0 || isCopy
const commonParams = {
  nendo,
  editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
  copyflg: isCopy
}
const response = ref<
  Omit<InitDetailResponse, keyof DaResponseBase | 'maininfo' | 'kekkalist' | 'editlist'>
>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  editflg: true,
  upddttm: undefined
})

const formData = reactive<DetailVM>({
  regsisyonm: '',
  jigyocdnm: '',
  yoteiymd: '',
  timef: '',
  timet: '',
  kaijocdnm: '',
  kikancdnm: '',
  staffids: [],
  teiin: undefined
})
const tableData = ref<RowVM[]>([])
//項目の設定
const rules = reactive({
  jigyocdnm: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業名') }],
  yoteiymd: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '実施予定日') }
  ],
  timef: [
    {
      validator: (_rule, value: string) => {
        if (!value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '開始時間'))
        } else {
          if (formData.timet && value > formData.timet) {
            return Promise.reject(ITEM_RANGE_ERROR.Msg.replace('{0}', '時間'))
          }
        }
        return Promise.resolve()
      }
    }
  ],
  kaijocdnm: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '会場') }],
  teiin: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '定員') }]
})
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)
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
watch(formData, () => editJudge.setEdited())

watchEffect(() => {
  if (formData.jigyocdnm) getEditYoyaku()
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const { tableHeight } = useTableHeight(null, -220)
//操作権限フラグ
const canEdit = computed(() => isNew || (route.meta.updflg && response.value.editflg))
const canDelete = computed(() => !isNew && route.meta.delflg && response.value.editflg)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitDetail({
      ...commonParams,
      nitteino: nitteino < 0 ? undefined : nitteino
    })
    response.value = res
    Object.assign(formData, res.maininfo)
    tableData.value = res.kekkalist
  } catch (error) {}
  loading.value = false
  nextTick(() => {
    clearValidate()
    editJudge.reset()
  })
}

//編集可能予約一覧取得処理
async function getEditYoyaku() {
  loading_table.value = true
  try {
    const res = await GetEditYoyaku({ nendo, jigyocd: formData.jigyocdnm.split(' : ')[0] })
    const { editlist } = res
    tableData.value.forEach((el) => {
      el.editable = editlist.some((i) => i.yoyakubunruicd === el.yoyakubunruicd)
    })
  } catch (error) {}
  loading_table.value = false
}

//保存処理
async function saveData() {
  await validate()

  console.log(formData.yoteiymd.substring(4, 6))
  if (
    !(
      Number(route.query.nendo) == Number(formData.yoteiymd.substring(0, 4)) &&
      formData.yoteiymd.substring(5, 7) >= '04'
    ) &&
    !(
      Number(route.query.nendo) + 1 == Number(formData.yoteiymd.substring(0, 4)) &&
      formData.yoteiymd.substring(5, 7) <= '03'
    )
  ) {
    message.error(E003008.Msg.replace('{0}', '年度').replace('{1}', '実施予定日の年度'))
    return
  }

  showSaveModal({
    onOk: async () => {
      const savelist = tableData.value.filter(
        (el) => el.editable && el.teiin_kensin !== null && el.teiin_kensin >= 0
      )
      try {
        await Save({
          ...commonParams,
          nitteino: isNew ? undefined : nitteino,
          maininfo: formData,
          kekkalist: savelist,
          upddttm: response.value.upddttm
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
        await Delete({
          ...commonParams,
          nitteino,
          upddttm: response.value.upddttm as string
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        back2list(true)
      } catch (error) {}
    }
  })
}

//医療機関
function selectOrganize(val: KikanVM) {
  formData.kikancdnm = val.kikancd + ' : ' + val.kikannm
}
//担当者
function selectStaff(val: StaffVM) {
  if (formData.staffids.includes(val.staffid)) {
    message.warning(E001008.Msg.replace('{0}', '担当者'))
  } else {
    formData.staffids.push(val.staffid)
  }
}

function back2list(refresh = false) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: refresh ? { refresh: '1' } : {}
    })
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 110px;
}
</style>
