<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ログイン
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.02.22
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="main">
    <a-form id="formLogin" class="mt-10" :model="form" @submit="handleSubmit">
      <a-form-item v-bind="validateInfos.userid">
        <a-input
          v-model:value="form.userid"
          size="large"
          type="text"
          placeholder="ユーザーID"
          style="ime-mode: disabled"
          @change="noFullAngle"
        >
          <template #prefix>
            <UserOutlined class="c-gray" />
          </template>
        </a-input>
      </a-form-item>

      <a-form-item v-bind="validateInfos.pword">
        <a-input-password
          v-model:value="form.pword"
          size="large"
          placeholder="パスワード"
          style="ime-mode: disabled"
          @change="noFullAngle"
        >
          <template #prefix>
            <LockOutlined class="c-gray" />
          </template>
        </a-input-password>
      </a-form-item>
      <a-form-item class="mt-8">
        <a-button
          size="large"
          type="primary"
          html-type="submit"
          class="w-full"
          :loading="loading"
          :disabled="loading"
          >ログイン</a-button
        >
      </a-form-item>
    </a-form>
    <a-modal
      v-model:visible="instVisible"
      width="500px"
      title="支所選択"
      :mask-closable="false"
      destroy-on-close
      @ok="onOk"
      @cancel="onCancel"
    >
      <vxe-table
        height="400"
        :column-config="{ resizable: true }"
        :row-config="{ keyField: 'sisyocd', isCurrent: true, isHover: true }"
        :keyboard-config="{
          isArrow: true,
          isTab: true
        }"
        :data="sisyolList"
        :empty-render="{ name: 'NotData' }"
        @current-change="clickRow"
        @cell-dblclick="onDbclickCell"
      >
        <vxe-column field="sisyocd" title="支所コード"></vxe-column>
        <vxe-column field="sisyonm" title="支所名"></vxe-column>
      </vxe-table>
      <template #footer>
        <a-button type="primary" :disabled="!selectedSisyo" @click="onOk">選択</a-button>
      </template>
    </a-modal>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue'
import { Form } from 'ant-design-vue'
import { useRouter } from 'vue-router'
import { LoginRequest } from './type'
import { Login,Login2 } from './service'
import { ss } from '@/utils/storage'
import {
  ACCESS_TOKEN,
  ATENANO_LEN,
  KIKANCD_LEN,
  USER_INFO,
  MAX_YEAR,
  REGSISYO
} from '@/constants/mutation-types'
import { notification } from 'ant-design-vue'
import { Router } from 'vue-router'
import generateAsyncRoutes from '@/router/generate-async-routes'
import { LOGIN_OK_INFO, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { TIMER_ONE_M } from '@/constants/constant'
import { Rule } from 'ant-design-vue/lib/form'
import { Init } from '../AWAF00301G/service'
import { changeFullAngle } from '@/utils/util'
import { UserOutlined, LockOutlined } from '@ant-design/icons-vue'
import { Enumログイン区分, Enum名称区分 } from '#/Enums'
import { showPsdExpiredModal } from '@/utils/modal'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const useForm = Form.useForm
const router = useRouter()
const instVisible = ref(false)
const loading = ref(false)

const form = reactive<LoginRequest>({
  userid: '',
  pword: '',
  kbn: Enumログイン区分.一回目 //一回目：ユーザー認証及び登録支所一覧を取得
})
const rules = reactive<Record<string, Rule[]>>({
  userid: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザーID')
    }
  ],
  pword: [{ required: true, message: `${ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'パスワード')}` }]
})
const { validate, validateInfos } = useForm(form, rules)

const sisyolList = ref<CmSisyoVM[]>([])
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//フォームの提出
const handleSubmit = async (e: Event) => {
  e.preventDefault()
  loading.value = true
  try {
    await validate(['userid', 'pword'])
    await Login(form).then((res) => {
      if (res.sisyolist.length <= 1) {
        selectedSisyo.value = res.sisyolist[0]
        onOk()
        return
      }
      sisyolList.value = res.sisyolist
      instVisible.value = true
    })
  } catch (error) {
    loading.value = false
  }
}

//全角のチェック
const noFullAngle = () => {
  form.userid = form.userid && changeFullAngle(form.userid)
  form.pword = form.pword && changeFullAngle(form.pword)
}

//ログイン成功のメッセージ表示
const loginSuccess = async (res, router: Router, expiredMessage) => {
  //トークン設定、ユーザー情報設定
  if (res.token) {
    ss.set(ACCESS_TOKEN, res.token)
    ss.set(USER_INFO, res)
  }
  //システム変数保存
  await Init({ kbn: Enum名称区分.名称 }).then((res) => {
    ss.set(MAX_YEAR, res.nendo)
    ss.set(ATENANO_LEN, res.atenanolen)
    ss.set(KIKANCD_LEN, res.kikancdlen)
  })
  //ルーター設定
  await generateAsyncRoutes()
  const { query } = router.currentRoute.value
  //元のページ戻ります
  if (query.redirect) {
    await router.push({ path: query.redirect as string })
  } else {
    await router.push({ path: '/' })
  }

  notification.success({
    message: LOGIN_OK_INFO.Msg
  })
  //パスワード有効期限チェック必要、かつ、パスワードの有効期限の残り日数が期限切れ通知範囲以内
  //上記の条件を満足する場合、確認メッセージを表示
  if (expiredMessage) {
    setTimeout(() => {
      showPsdExpiredModal(expiredMessage)
    }, TIMER_ONE_M)
  }
}

const selectedSisyo = ref<CmSisyoVM | null>(null)
//行選択(行をクリック)
function clickRow({ row }) {
  selectedSisyo.value = row
}
//行をダブルクリック
function onDbclickCell({ row }) {
  selectedSisyo.value = row
  onOk()
}
//選択ボタン
const onOk = async () => {
  ss.set(REGSISYO, selectedSisyo.value ?? { sisyocd: '', sisyonm: '' })
  instVisible.value = false
  try {
    const res = await Login2({
      userid: form.userid,
      pword: form.pword,
      regsisyo: selectedSisyo.value?.sisyocd,
      kbn: Enumログイン区分.二回目 //登録支所を選択し、再びユーザー認証し、システムに入る
    })
    const userInfoRes = { token: res.token, ...res.userinfo }
    loginSuccess(userInfoRes, router, res.pwdmsgflg && res.message)
  } catch (error) {
    loading.value = false
  }
}
const onCancel = () => {
  loading.value = false
}
</script>
