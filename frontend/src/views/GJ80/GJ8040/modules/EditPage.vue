<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="（GJ8041）使用者マスタメンテナンス"
    width="800px"
    :body-style="{ height: '450px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
    ><div class="modal-container">
      <div class="edit_table form w-150">
        <a-form>
          <a-row>
            <a-col span="24">
              <th class="required">ユーザーID</th>
              <td>
                <a-form-item v-bind="validateInfos.USER_ID">
                  <a-input
                    v-model:value="formData.USER_ID"
                    :maxlength="10"
                    :disabled="!isNew"
                    class="w-30!"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">ユーザー名</th>
              <td>
                <a-form-item v-bind="validateInfos.USER_NAME">
                  <a-input
                    v-model:value="formData.USER_NAME"
                    :maxlength="20"
                    class="w-60!"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">パスワード</th>
              <td>
                <a-form-item v-bind="validateInfos.PASS">
                  <a-input
                    v-model:value="formData.PASS"
                    :maxlength="20"
                    class="w-60!"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row class="mt-1">
            <a-col span="13">
              <read-only-pop
                th="　パスワード有効期限"
                th-width="150"
                :td="getDateJpText(formData.PASS_KIGEN_DATE)"
              ></read-only-pop>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="13">
              <read-only-pop
                th="　パスワード変更日"
                th-width="150"
                :td="getDateJpText(formData.PASS_UP_DATE)"
              ></read-only-pop>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">使用区分</th>
              <td>
                <a-form-item v-bind="validateInfos.SIYO_KBN">
                  <ai-select
                    v-model:value="formData.SIYO_KBN"
                    :options="SIYO_KBN_LIST"
                    split-val
                    class="max-w-50"
                  ></ai-select
                ></a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th>使用停止日</th>
              <td>
                <DateJp
                  v-model:value="formData.TEISI_DATE"
                  :disabled="isNew"
                  class="max-w-50!"
                />
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th>使用停止理由</th>
              <td>
                <a-input
                  v-model:value="formData.TEISI_RIYU"
                  :disabled="!formData.TEISI_DATE"
                />
              </td>
            </a-col>
          </a-row>
        </a-form>
      </div>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData"> 保存 </a-button>
          <a-button class="danger-btn" :disabled="isNew" @click="deleteData">
            削除
          </a-button>
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template></a-modal
  >
</template>
<script setup lang="ts">
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { EnumEditKbn, PageStatus } from '@/enum'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Delete, InitDetail, Save } from '../service'
import { Judgement } from '@/utils/judge-edited'
import { getDateJpText } from '@/utils/util'
import { SearchRowVM } from '../type'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
  userData?: SearchRowVM
}>()
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const editJudge = new Judgement('GJ8040')
let upddttm
const formData = reactive({
  USER_ID: '',
  USER_NAME: '',
  PASS: '',
  PASS_KIGEN_DATE: new Date(),
  PASS_UP_DATE: new Date(),
  SIYO_KBN: undefined,
  TEISI_DATE: new Date(),
  TEISI_RIYU: '',
})

const SIYO_KBN_LIST = ref<CmCodeNameModel[]>([{ CODE: 30, NAME: 'オペレータ' }])
const rules = reactive({
  USER_ID: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザーID'),
    },
  ],
  USER_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザー名'),
    },
  ],
  PASS: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'パスワード'),
    },
    {
      min: 6,
      message: 'パスリ-ドは6桁以上指定してください。',
    },
  ],
  SIYO_KBN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '使用区分'),
    },
  ],
})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  },
})
const isNew = computed(() => (props.editkbn === EnumEditKbn.Add ? true : false))
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      if (!isNew.value) {
        if (props.userData) {
          Object.assign(formData, props.userData)
        }
      }
      // InitDetail({
      //   USER_ID: formData.USER_ID,
      //   EDIT_KBN: isNew.value ? EnumEditKbn.Add : EnumEditKbn.Edit,
      // })
      //   .then((res) => {
      //     SIYO_KBN_LIST.value = res.SIYO_KBN_LIST
      //     if (!isNew.value) {
      //       Object.assign(formData, res.CODE_VM)
      //       upddttm = res.CODE_VM.UP_DATE
      //     }
      //     nextTick(() => editJudge.reset())
      //   })
      //   .catch((error) => {
      //     router.push({ name: route.name, query: { refresh: '1' } })
      //   })
      nextTick(() => editJudge.reset())
    }
  }
)
watch(formData, () => editJudge.setEdited())
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    resetFields()
    clearValidate()
    modalVisible.value = false
  })
}
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

//登録処理
const saveData = async () => {
  await validate()
  // showSaveModal({
  //   content: SAVE_CONFIRM.Msg,
  //   onOk: async () => {
  //     try {
  //       await Save({
  //         CODE_VM: {
  //           ...formData,
  //           UP_DATE: isNew.value ? undefined : upddttm,
  //         },
  //         EDIT_KBN: isNew.value ? EnumEditKbn.Add : EnumEditKbn.Edit,
  //       })
  //       router.push({ name: route.name, query: { refresh: '1' } })
  //       message.success(SAVE_OK_INFO.Msg)
  //     } catch (error) {}
  //   },
  // })
}

//削除処理
const deleteData = () => {
  // showDeleteModal({
  //   handleDB: true,
  //   content: DELETE_CONFIRM.Msg,
  //   onOk: async () => {
  //     try {
  //       await Delete({
  //         USER_ID: formData.USER_ID,
  //         UP_DATE: upddttm,
  //         EDIT_KBN: EnumEditKbn.Edit,
  //       })
  //       router.push({ name: route.name, query: { refresh: '1' } })
  //       message.success(DELETE_OK_INFO.Msg)
  //     } catch (error) {}
  //   },
  // })
}
</script>
<style lang="scss" scoped>
th {
  width: 150px;
}
.modal-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  width: 100%;
}
</style>
