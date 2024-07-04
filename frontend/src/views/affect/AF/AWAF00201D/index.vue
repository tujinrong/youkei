<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: パスワード変更
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.02.22
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="800px"
    title="パスワード変更"
    destroy-on-close
    :after-close="afterPassClose"
    :mask-closable="false"
    @cancel="closeModal"
  >
    <a-form ref="editFormRef" :model="passwordChangeForm" :rules="rules" class="form_in_table">
      <div class="description-table">
        <table>
          <tbody>
            <tr>
              <th class="bg-readonly w-[200px] h-[36px]">ユーザーID</th>
              <td class="textarea">{{ passwordChangeForm.userid }}</td>
            </tr>
            <tr>
              <th>旧パスワード<span class="request-mark">＊</span></th>
              <td>
                <a-form-item prop="oldpword">
                  <a-input-password
                    v-model:value="passwordChangeForm.oldpword"
                    @change="noFullAngle"
                  />
                </a-form-item>
              </td>
            </tr>
            <tr>
              <th>新パスワード<span class="request-mark">＊</span></th>
              <td>
                <a-form-item prop="newpword">
                  <a-input-password
                    v-model:value="passwordChangeForm.newpword"
                    :maxlength="maxlength"
                    @change="noFullAngle"
                  />
                </a-form-item>
              </td>
            </tr>
            <tr>
              <th>新パスワード(確認)<span class="request-mark">＊</span></th>
              <td>
                <a-form-item prop="checkpword">
                  <a-input-password v-model:value="passwordChangeForm.checkpword" />
                </a-form-item>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </a-form>

    <template #footer>
      <div class="float-left">
        <a-button key="submit" class="warning-btn" @click="saveData">登録</a-button>
      </div>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, watch, computed } from 'vue'
import { ss } from '@/utils/storage'
import { USER_INFO } from '@/constants/mutation-types'
import { FormInstance, message } from 'ant-design-vue'
import { Init, Save } from './service'
import { Rule } from 'ant-design-vue/lib/form'
import { encryptBySHA256 } from '@/utils/encrypt/data'
import { I000007, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { PasswordFormState } from './type'
import { pwdValidate, validate } from '@/utils/validate'
import { changeFullAngle } from '@/utils/util'
import { showSaveModal } from '@/utils/modal'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const userInfo = ss.get(USER_INFO)
const editFormRef = ref<FormInstance>()
const passwordChangeForm = reactive<PasswordFormState>({
  userid: userInfo.userid,
  oldpword: '',
  newpword: '',
  checkpword: ''
})
const maxlength = ref(50)
const initData = ref<CmPwdInitResponse | null>(null)
//項目の設定
const rules = ref<Record<string, Rule[]>>({
  newpword: [
    {
      validator: validatePassword,
      trigger: ['blur']
    }
  ],
  oldpword: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '旧パスワード'),
      trigger: 'blur'
    }
  ],
  checkpword: [
    {
      validator: validateConfirmPassword,
      trigger: ['blur', 'change']
    }
  ]
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      const res = await Init()
      initData.value = res
    }
  }
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
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//全角のチェック
const noFullAngle = () => {
  passwordChangeForm.oldpword = changeFullAngle(passwordChangeForm.oldpword)
  passwordChangeForm.newpword = changeFullAngle(passwordChangeForm.newpword)
}
//パスワードの一致チェック
async function validateConfirmPassword(_rule: Rule, value: string) {
  await validate({
    is: value === '' || value === null,
    type: 'REQUIRE',
    name: '新パスワード(確認)'
  })
  await validate({
    is: value !== passwordChangeForm.newpword,
    type: 'NOTEQUAL',
    name: '新パスワード'
  })
  return Promise.resolve()
}
//パスワード関連チェック
async function validatePassword(_rule: Rule, value: string) {
  //必須チェック
  await validate({
    is: value === '' || value === null,
    type: 'REQUIRE',
    name: '新パスワード'
  })
  //新旧パスワード不一致のチェック
  await validate({
    is: value === passwordChangeForm.oldpword,
    type: 'EQUAL',
    name: '旧パスワード'
  })
  //パスワードポリシー
  if (!initData.value) return Promise.resolve()
  maxlength.value = initData.value.maxlen ?? 50
  await pwdValidate(initData.value, value)
  return Promise.resolve()
}
//確認と保存処理
const saveData = () => {
  editFormRef.value?.validate().then(async () => {
    const params = {
      oldpword: encryptBySHA256(passwordChangeForm.oldpword, passwordChangeForm.userid),
      newpword: encryptBySHA256(passwordChangeForm.newpword, passwordChangeForm.userid)
    }
    const saveReq = async (checkflg: boolean) => {
      await Save({
        ...params,
        checkflg
      })
    }
    await saveReq(true)
    showSaveModal({
      onOk: async () => {
        await saveReq(false)
        afterPassClose()
        message.success(I000007.Msg)
      }
    })
  })
}
//閉じるボタン(×を含む)
const closeModal = () => {
  modalVisible.value = false
}
//閉じる時のクリア処理
const afterPassClose = () => {
  passwordChangeForm.newpword = ''
  passwordChangeForm.oldpword = ''
  passwordChangeForm.checkpword = ''
  closeModal()
}
</script>
