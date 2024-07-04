<template>
  <a-modal
    :visible="props.visible"
    style="width: 700px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    :title="Enum編集区分[editkbn]"
  >
    <div class="self_adaption_table" :class="{ form: canEdit }">
      <a-form :model="formData">
        <a-row>
          <a-col v-if="props.editkbn == Enum編集区分.変更" span="24">
            <th class="bg-readonly">帳票グループID</th>
            <TD>
              {{ props.rowDetail.rptgroupid }}
            </TD>
          </a-col>
          <a-col span="24">
            <th class="required">帳票グループ</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.rptgroupnm">
                <a-input v-model:value="formData.rptgroupnm" :maxlength="50"
              /></a-form-item>
            </td>
            <TD v-else>{{ formData.rptgroupnm }}</TD>
          </a-col>
        </a-row>

        <a-row>
          <a-col span="24" class="head-grey mt-3">
            <th>共通バー</th>
            <td></td>
          </a-col>
          <a-col span="24">
            <th>個人連絡先</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.kojinrenrakusakicd"
                :options="renrakusakicdsOptions"
                style="width: 100%"
                allow-clear
                split-val
              ></ai-select>
            </td>
            <TD v-else>{{ formData.kojinrenrakusakicd }}</TD>
          </a-col>
          <a-col span="24">
            <th>メモ情報</th>
            <td v-if="canEdit">
              <a-select
                v-model:value="formData.memocd"
                mode="multiple"
                :options="memocdsOptions"
                style="width: 100%"
                allow-clear
              ></a-select>
            </td>
            <TD v-else>{{ getMultipleLabel(formData.memocd, memocdsOptions) }}</TD>
          </a-col>
          <a-col span="24">
            <th>電子ファイル情報</th>
            <td v-if="canEdit">
              <a-select
                v-model:value="formData.electronfilecd"
                :options="electronfilecdsOptions"
                mode="multiple"
                style="width: 100%"
                allow-clear
              ></a-select>
            </td>
            <TD v-else>{{ getMultipleLabel(formData.electronfilecd, electronfilecdsOptions) }}</TD>
          </a-col>
          <a-col span="24">
            <th>フォロー管理</th>
            <td v-if="canEdit">
              <a-select
                v-model:value="formData.followmanage"
                mode="multiple"
                style="width: 100%"
                :options="followmanagesOptions"
                allow-clear
              ></a-select>
            </td>
            <TD v-else>{{ getMultipleLabel(formData.followmanage, followmanagesOptions) }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">業務区分</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.gyomukbn">
                <ai-select
                  v-model:value="formData.gyomukbn"
                  :options="gyomukbnList"
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
            <TD v-else>{{ formData.gyomukbn }}</TD>
          </a-col>
          <a-col span="24">
            <th>並び順</th>
            <td v-if="canEdit">
              <a-input-number
                v-model:value="formData.orderseq"
                :max="32767"
                :min="0"
                class="w-full"
              />
            </td>
            <TD v-else>{{ formData.orderseq }}</TD>
          </a-col>
        </a-row>
      </a-form>
    </div>
    <template #footer>
      <a-button type="warn" style="float: left" :disabled="!canEdit" @click="saveData"
        >登録</a-button
      >
      <a-button type="primary" danger style="float: left" :disabled="!canDelete" @click="handleDel"
        >削除</a-button
      >
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watch, reactive, nextTick, computed } from 'vue'
import { Form, message } from 'ant-design-vue'
import { SearchVM } from '../AWEU00401G/type'
import { InitDetailInfo, Save, Delete } from './service'
import { EnumServiceResult, Enum編集区分 } from '#/Enums'
import { SAVE_OK_INFO, DELETE_OK_INFO, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { useRoute } from 'vue-router'
import { getMultipleLabel } from '@/utils/util'
import { GlobalStore } from '@/store'
const props = defineProps<{
  visible: boolean
  editkbn: Enum編集区分
  rowDetail: Partial<SearchVM>
}>()

const emit = defineEmits(['update:visible', 'getTableList', 'initData'])
const editJudge = new Judgement()
//ビューモデル
type DefaultSaveModel = {
  rptgroupnm: string
  gyomukbn: string
  kojinrenrakusakicd: string
  memocd: string[]
  electronfilecd: string[]
  followmanage: string[]
  orderseq: number | undefined
  upddttm: Date
}
function createDefaultForm() {
  return {
    rptgroupnm: '',
    gyomukbn: '',
    kojinrenrakusakicd: '',
    memocd: [],
    electronfilecd: [],
    followmanage: [],
    orderseq: undefined,
    upddttm: new Date()
  }
}
const formData = reactive<DefaultSaveModel>(createDefaultForm())

const rules = reactive({
  rptgroupnm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票グループ') }],
  gyomukbn: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '業務区分') }]
})
const { validate, validateInfos, resetFields, clearValidate } = Form.useForm(formData, rules)
const memocdsOptions = ref<DaSelectorModel[]>([])
const electronfilecdsOptions = ref<DaSelectorModel[]>([])
const followmanagesOptions = ref<DaSelectorModel[]>([])
const renrakusakicdsOptions = ref<DaSelectorModel[]>([])
const gyomukbnList = ref<DaSelectorModel[]>([])

//操作権限フラグ
const route = useRoute()
const canEdit = computed(() =>
  props.editkbn == Enum編集区分.新規 ? route.meta.addflg : route.meta.updflg
)
const canDelete = computed(() => props.editkbn == Enum編集区分.変更 && route.meta.delflg)

watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      initData()
    }
  }
)
watch(formData, () => editJudge.setEdited())

//初期化
const initData = async () => {
  const data = {
    editkbn: props.editkbn,
    rptgroupid: props.rowDetail.rptgroupid
  }
  try {
    const res = await InitDetailInfo(data, (response: DaResponseBase) => {
      if (response.returncode === EnumServiceResult.InterruptionError) {
        editJudge.reset()
        closeModal()
      }
    })
    formData.rptgroupnm = res.rptgroupnm
    formData.gyomukbn = res.gyomukbn
    formData.kojinrenrakusakicd = res.kojinrenrakusakicd
    formData.orderseq = res.orderseq == 0 ? undefined : res.orderseq
    formData.upddttm = res.upddttm
    formData.memocd = res.memocd?.split(',').filter(Boolean) ?? []
    formData.electronfilecd = res.electronfilecd?.split(',').filter(Boolean) ?? []
    formData.followmanage = res.followmanage?.split(',').filter(Boolean) ?? []
    memocdsOptions.value = res.memocds
    electronfilecdsOptions.value = res.electronfilecds
    followmanagesOptions.value = res.followmanages
    renrakusakicdsOptions.value = res.renrakusakicds
    gyomukbnList.value = res.gyomukbnList
    nextTick(() => {
      editJudge.reset()
      clearValidate()
    })
  } catch (error) {}
}

//閉じるボタン(×を含む)
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    Object.assign(formData, createDefaultForm())
    emit('update:visible', false)
    resetFields()
  })
  nextTick(() => clearValidate())
}

const saveData = async () => {
  await validate()
  showSaveModal({
    onOk: async () => {
      try {
        await Save({
          editkbn: props.editkbn,
          upddttm: formData.upddttm,
          rptgroupid: props.rowDetail.rptgroupid,
          rptgroupnm: formData.rptgroupnm,
          kojinrenrakusakicd: formData.kojinrenrakusakicd,
          memocd: formData.memocd?.join(','),
          electronfilecd: formData.electronfilecd?.join(','),
          followmanage: formData.followmanage?.join(','),
          gyomukbn: formData.gyomukbn,
          orderseq: formData.orderseq
        })
        message.success(SAVE_OK_INFO.Msg)
        emit('getTableList')
        emit('initData')
        emit('update:visible', false)
      } catch (error) {}
    }
  })
}

const handleDel = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({
          rptgroupid: props.rowDetail.rptgroupid as string,
          upddttm: formData.upddttm
        })
        message.success(DELETE_OK_INFO.Msg)
        emit('update:visible', false)
        emit('getTableList')
        emit('initData')
      } catch (error) {}
    }
  })
}
</script>
<style scoped lang="less">
th {
  width: 150px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
