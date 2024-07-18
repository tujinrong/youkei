<script setup lang="ts">
import { reactive } from 'vue'
import { $t } from '@/locales'
import { useAntdForm } from '@/hooks/common/form'
import { useAuthStore } from '@/store/modules/auth'
import { UserOutlined, LockOutlined } from '@ant-design/icons-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'

defineOptions({
  name: 'PwdLogin',
})

const authStore = useAuthStore()
const { formRef, validate } = useAntdForm()

interface FormModel {
  userid: string
  pword: string
}

const model: FormModel = reactive({
  userid: '1',
  pword: '1',
})

const rules = reactive<Record<keyof FormModel, App.Global.FormRule[]>>({
  userid: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace(
        '{0}',
        $t('page.login.common.userNamePlaceholder')
      ),
    },
  ],
  pword: [
    {
      required: true,
      message: `${ITEM_REQUIRE_ERROR.Msg.replace('{0}', $t('page.login.common.passwordPlaceholder'))}`,
    },
  ],
})

async function handleSubmit() {
  await validate()
  await authStore.login(model.userid, model.pword)
}
</script>

<template>
  <AForm ref="formRef" :model="model" :rules="rules">
    <AFormItem name="userid">
      <AInput
        v-model:value="model.userid"
        size="large"
        :placeholder="$t('page.login.common.userNamePlaceholder')"
      >
        <template #prefix>
          <UserOutlined class="c-gray" />
        </template>
      </AInput>
    </AFormItem>
    <AFormItem name="pword">
      <AInputPassword
        v-model:value="model.pword"
        size="large"
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

<style scoped></style>
