<template>
  <AForm ref="formRef" :model="model" :rules="rules">
    <AFormItem name="USER_ID">
      <AInput
        id="USER_ID"
        v-model:value="model.USER_ID"
        size="large"
        :maxlength="10"
        :placeholder="$t('page.login.common.userNamePlaceholder')"
        @input="handleInput"
      >
        <template #prefix>
          <UserOutlined class="c-gray" />
        </template>
      </AInput>
    </AFormItem>
    <AFormItem name="PASS">
      <AInputPassword
        v-model:value="model.PASS"
        size="large"
        :maxlength="20"
        :placeholder="$t('page.login.common.passwordPlaceholder')"
      >
        <template #prefix>
          <LockOutlined class="c-gray" />
        </template>
      </AInputPassword>
    </AFormItem>
    <AButton
      type="primary"
      block
      size="large"
      shape="round"
      class="w-full mt-6"
      :loading="authStore.loginLoading"
      @click="handleSubmit"
    >
      {{ $t('page.login.common.confirm') }}
    </AButton>
  </AForm>
</template>

<script setup lang="ts">
import { onMounted, reactive } from 'vue'
import { $t } from '@/locales'
import { useAntdForm } from '@/hooks/common/form'
import { useAuthStore } from '@/store/modules/auth'
import { convertToHalfWidth } from '@/utils/util'
import { UserOutlined, LockOutlined } from '@ant-design/icons-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'

defineOptions({
  name: 'PwdLogin',
})

const authStore = useAuthStore()
const { formRef, validate } = useAntdForm()

interface FormModel {
  USER_ID: string
  PASS: string
}

const model: FormModel = reactive({
  USER_ID: '',
  PASS: '',
})

const rules = reactive<Record<keyof FormModel, App.Global.FormRule[]>>({
  USER_ID: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace(
        '{0}',
        $t('page.login.common.userNamePlaceholder')
      ),
      transform: (val) => val?.trim(),
    },
  ],
  PASS: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace(
        '{0}',
        $t('page.login.common.passwordPlaceholder')
      ),
      transform: (val) => val?.trim(),
    },
  ],
})

onMounted(() => {
  const userid = document.getElementById('USER_ID')
  if (userid) userid.focus()
})

const handleInput = () => {
  model.USER_ID = convertToHalfWidth(model.USER_ID)
  model.PASS = convertToHalfWidth(model.PASS)
}

async function handleSubmit() {
  await validate()
  await authStore.login(model.USER_ID, model.PASS)
}
</script>

<style scoped></style>
