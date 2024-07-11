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
          <a-col :md="8" :xxl="6">
            <th :class="canEdit && isNew ? 'required' : 'bg-readonly'">業務</th>
            <td v-if="canEdit && isNew">
              <a-form-item v-bind="validateInfos2.gyomukbn">
                <ai-select
                  v-model:value="headerInfo.gyomukbn"
                  :options="options"
                  split-val
                  @change="onChangeOpt"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ options.find((opt) => opt.value === headerInfo.gyomukbn)?.label }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th class="bg-readonly">登録支所</th>
            <TD>{{ headerInfo.regsisyonm || ss.get(REGSISYO).sisyonm }}</TD>
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
    <a-card class="my-2" :style="{ minHeight: tableHeight + 'px' }" :loading="loading">
      <div class="self_adaption_table max-w-200" :class="canEdit && 'form'">
        <a-row>
          <a-col v-if="!isNew && !isCopy" span="12">
            <th class="bg-readonly">日程番号</th>
            <TD>{{ nitteino }}</TD>
          </a-col>
          <a-col span="24">
            <th :class="isNew || formData.editflg ? 'required' : 'bg-readonly'">事業名</th>
            <td v-if="canEdit && (isNew || formData.editflg)">
              <a-form-item v-bind="validateInfos.jigyocdnm">
                <ai-select v-model:value="formData.jigyocdnm" :options="keyoptions"></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jigyocdnm }}</TD>
          </a-col>
          <a-col span="24">
            <th>実施内容</th>
            <td>
              <a-form-item v-bind="validateInfos.jissinaiyo">
                <a-textarea
                  v-model:value="formData.jissinaiyo"
                  :auto-size="{ minRows: 2 }"
                  :maxlength="100"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">実施予定日</th>
            <td>
              <a-form-item v-bind="validateInfos.jissiyoteiymd">
                <DateJp
                  v-model:value="formData.jissiyoteiymd"
                  style="width: 190px"
                  format="YYYY-MM-DD"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">開始時間</th>
            <td>
              <a-form-item v-bind="validateInfos.tmf">
                <a-time-picker v-model:value="formData.tmf" value-format="HHmm" format="HH:mm" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>終了時間</th>
            <td>
              <a-time-picker
                v-model:value="formData.tmt"
                value-format="HHmm"
                format="HH:mm"
                @change="validate('tmf')"
              />
            </td>
          </a-col>

          <a-col span="24">
            <th class="required">会場</th>
            <td>
              <a-form-item v-bind="validateInfos.kaijocdnm">
                <ai-select
                  v-model:value="formData.kaijocdnm"
                  :options="response.selectorlist3"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>医療機関</th>
            <td class="flex gap-1">
              <ai-select
                v-model:value="formData.kikancdnm"
                :options="response.selectorlist4"
              ></ai-select>
              <OrganizeButton @select="selectOrganize"></OrganizeButton>
            </td>
          </a-col>
          <a-col span="24">
            <th>担当者</th>
            <td class="flex gap-1">
              <a-select
                v-model:value="formData.staffids"
                mode="multiple"
                class="w-full"
                max-tag-count="responsive"
                allow-clear
                :options="response.selectorlist5"
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
          <a-col span="12">
            <th class="required">定員(全体)</th>
            <td>
              <a-form-item v-bind="validateInfos.teiin">
                <a-input-number
                  v-model:value="formData.teiin"
                  :min="1"
                  :max="9999"
                  class="w-full"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
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
  ITEM_RANGE_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { REGSISYO } from '@/constants/mutation-types'
import { useLinkOption, useTableHeight } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { getDateJpText } from '@/utils/util'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, toRef, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { InitNitteiDetailResponse, NitteiDetailVM, NitteiHeaderVM } from '../type'
import { DeleteNittei, InitDetailNittei, SaveNittei } from '../service'
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
const nitteino = Number(route.query.nitteino)
const isCopy = Boolean(route.query.iscopy)
const isNew = nitteino < 0 || isCopy
const response = ref<
  Omit<InitNitteiDetailResponse, keyof DaResponseBase | 'headerinfo' | 'detailinfo'>
>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  editflg: true,
  upddttm: undefined
})
const headerInfo = reactive<NitteiHeaderVM>({
  gyomukbn: '',
  regsisyonm: ''
})
const formData = reactive<NitteiDetailVM>({
  jigyocdnm: '',
  jissinaiyo: '',
  jissiyoteiymd: '',
  tmf: '',
  tmt: '',
  kaijocdnm: '',
  kikancdnm: '',
  staffids: [],
  teiin: undefined,
  editflg: true
})
//項目の設定
const rules = reactive({
  gyomukbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '業務') }],
  jigyocdnm: [
    {
      required: formData.editflg,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業名')
    }
  ],
  jissiyoteiymd: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '実施予定日') }
  ],
  tmf: [
    {
      validator: (_rule, value: string) => {
        if (!value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '開始時間'))
        } else {
          if (formData.tmt && value > formData.tmt) {
            return Promise.reject(ITEM_RANGE_ERROR.Msg.replace('{0}', '時間 '))
          }
        }
        return Promise.resolve()
      }
    }
  ],
  kaijocdnm: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '会場') }],
  teiin: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '定員(全体)') }]
})
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)
const {
  validate: validate2,
  clearValidate: clearValidate2,
  validateInfos: validateInfos2
} = Form.useForm(headerInfo, rules)

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
watch([formData, headerInfo], () => editJudge.setEdited())

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 65)
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
    const res = await InitDetailNittei({
      editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
      copyflg: isCopy,
      nitteino: nitteino < 0 ? undefined : nitteino
    })
    response.value = res
    Object.assign(formData, res.detailinfo)
    headerInfo.regsisyonm = res.headerinfo.regsisyonm
    //set業務
    headerInfo.gyomukbn =
      res.selectorlist2.find((el) => el.value === res.detailinfo.jigyocdnm.split(' : ')[0])?.key ??
      ''
  } catch (error) {}
  loading.value = false
  nextTick(() => {
    clearValidate()
    clearValidate2()
    editJudge.reset()
  })
}

//保存処理
async function saveData() {
  await Promise.all([validate(), validate2()])
  showSaveModal({
    onOk: async () => {
      try {
        await SaveNittei({
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
          nitteino: isNew ? undefined : nitteino,
          detailinfo: formData,
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
        await DeleteNittei({
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

function back2list(refresh = false) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: refresh ? { refresh: '1' } : {}
    })
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
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
