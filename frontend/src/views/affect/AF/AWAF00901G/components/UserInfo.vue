<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー管理(詳細画面：ユーザー　ユーザー情報)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="m1" style="max-width: 800px">
    <a-checkbox v-if="!isNew" v-model:checked="formData.stopflg" class="mb-1"> 停止 </a-checkbox>
    <a-form ref="formRef" :model="formData" :rules="rules">
      <div class="self_adaption_table form">
        <a-row>
          <a-col span="24" class="head-grey">
            <th>ユーザー情報</th>
            <td></td>
          </a-col>
          <a-col span="24">
            <th>ユーザー名<span class="request-mark">＊</span></th>
            <td>
              <a-form-item name="usernm">
                <a-input
                  v-model:value="formData.usernm"
                  :maxlength="50"
                  @change="formData.usernm = replaceText(formData.usernm, EnumRegex.全角)"
                ></a-input>
                <!-- <ai-input v-model:value="formData.usernm" :regex="EnumRegex.全角" :maxlength="50" /> -->
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>パスワード<span v-if="props.isNew" class="request-mark">＊</span></th>
            <td>
              <a-form-item name="pword">
                <a-input-password
                  v-model:value="formData.pword"
                  :maxlength="maxlength"
                  @change="formData.pword = changeFullAngle(formData.pword)"
                ></a-input-password>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>パスワード確認<span v-if="props.isNew" class="request-mark">＊</span></th>
            <td>
              <a-form-item name="checkpword">
                <a-input-password v-model:value="formData.checkpword"></a-input-password>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>アカウント有効年月日<span class="request-mark">＊</span></th>
            <td>
              <a-form-item name="daterange">
                <RangeDate v-model:value="formData.daterange" />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-if="!props.isNew" span="24">
            <th class="bg-readonly">ログインエラー回数</th>
            <td class="flex pl-3.5!">
              <span class="flex-1">{{ formData.errorkaisu }}</span>
              <a-button type="primary" class="w-18" @click="() => (formData.errorkaisu = 0)"
                >クリア</a-button
              >
            </td>
          </a-col>
          <a-col span="24">
            <th>登録部署</th>
            <td class="flex">
              <a-select
                :value="formData.regsisyolist.map((i) => i.sisyocd)"
                mode="multiple"
                class="flex-1"
                :options="sisyolist"
                :field-names="{ label: 'sisyonm', value: 'sisyocd' }"
                :filter-option="filterOption"
                @change="changeRegsisyo"
              >
                <template #option="{ sisyonm, sisyocd }">
                  {{ sisyocd + ' : ' + sisyonm }}
                </template>
              </a-select>
              <a-button type="primary" class="ml1 w-18" @click="() => (setVisible = true)"
                >設定</a-button
              >
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="self_adaption_table form m-t-2">
        <a-row>
          <a-col span="20" class="head-grey">
            <th>ユーザー権限</th>
            <td></td>
          </a-col>
          <a-col v-if="props.set" span="4">
            <th class="br-grey text-center!">継承可能</th>
          </a-col>
          <a-col span="20">
            <th :class="getClassObj('kanrisyakeisyoflg')">
              管理者<span
                v-if="!getClassObj('kanrisyakeisyoflg')['bg-readonly']"
                class="request-mark"
                >＊</span
              >
            </th>
            <TD>
              <div>
                <span v-if="!set && formData.syozoku">{{
                  formData.kanrisyaflg ? '権限あり' : '権限なし'
                }}</span>
                <a-radio-group v-else v-model:value="formData.kanrisyaflg" name="kanrisyaflg">
                  <a-radio :value="true">権限あり</a-radio>
                  <a-radio :value="false">権限なし</a-radio>
                </a-radio-group>
              </div>
            </TD>
          </a-col>
          <a-col v-if="props.set" span="4">
            <td class="text-center">
              <a-checkbox v-model:checked="formData.kanrisyakeisyoflg"></a-checkbox>
            </td>
          </a-col>
          <a-col v-if="pnoeditflg" span="20">
            <th :class="getClassObj('pnoeditkeisyoflg')">
              個人番号操作付与者<span
                v-if="!getClassObj('pnoeditkeisyoflg')['bg-readonly']"
                class="request-mark"
                >＊</span
              >
            </th>
            <TD>
              <div>
                <span v-if="(!set && formData.syozoku) || !pnoeditflg || !formData.kanrisyaflg">{{
                  formData.pnoeditflg ? '権限あり' : '権限なし'
                }}</span>
                <a-radio-group v-else v-model:value="formData.pnoeditflg" name="pnoeditflg">
                  <a-radio :value="true">権限あり</a-radio>
                  <a-radio :value="false">権限なし</a-radio>
                </a-radio-group>
              </div>
            </TD>
          </a-col>
          <a-col v-if="props.set && pnoeditflg" span="4">
            <td class="text-center">
              <a-checkbox
                v-model:checked="formData.pnoeditkeisyoflg"
                :disabled="!pnoeditflg"
              ></a-checkbox>
            </td>
          </a-col>
          <a-col span="20">
            <th :class="getClassObj('alertviewkeisyoflg')">
              警告参照区分<span
                v-if="!getClassObj('alertviewkeisyoflg')['bg-readonly']"
                class="request-mark"
                >＊</span
              >
            </th>
            <TD>
              <div>
                <span v-if="!set && formData.syozoku">{{
                  formData.alertviewflg ? '参照可能' : '参照不可'
                }}</span>
                <a-radio-group v-else v-model:value="formData.alertviewflg" name="alertviewflg">
                  <a-radio :value="true">参照可能</a-radio>
                  <a-radio :value="false">参照不可</a-radio>
                </a-radio-group>
              </div>
            </TD>
          </a-col>
          <a-col v-if="props.set" span="4">
            <td class="text-center">
              <a-checkbox v-model:checked="formData.alertviewkeisyoflg"></a-checkbox>
            </td>
          </a-col>
          <a-col span="20">
            <th :class="getClassObj('authsisyokeisyoflg')">登録部署別更新権限</th>
            <td>
              <span v-if="!set && formData.syozoku">{{
                formData.editsisyolist?.map((i) => i.sisyonm).join('；')
              }}</span>
              <div v-else class="flex">
                <a-select
                  :value="formData.editsisyolist.map((i) => i.sisyocd)"
                  mode="multiple"
                  style="width: 100%"
                  :options="sisyolist"
                  :field-names="{ label: 'sisyonm', value: 'sisyocd' }"
                  :filter-option="filterOption"
                  @change="changeEditsisyo"
                >
                  <template #option="{ sisyonm, sisyocd }">
                    {{ sisyocd + ' : ' + sisyonm }}
                  </template>
                </a-select>
                <a-button type="primary" class="ml1" @click="() => (updVisible = true)"
                  >設定</a-button
                >
              </div>
            </td>
          </a-col>
          <a-col v-if="props.set" span="4">
            <td class="text-center">
              <a-checkbox v-model:checked="formData.authsisyokeisyoflg"></a-checkbox>
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>

    <LoginSetModal
      v-model:visible="setVisible"
      v-model:selected-data="formData.regsisyolist"
      :username="formData.usernm"
      :userid="props.userid"
      :sisyolist="sisyolist"
    />
    <LoginUpdModal
      v-model:visible="updVisible"
      v-model:selected-data="formData.editsisyolist"
      :sisyolist="sisyolist"
    />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, reactive, onUnmounted, watch, DeepReadonly, onBeforeMount } from 'vue'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import LoginSetModal from '@/views/affect/AF/AWAF00903D/index.vue'
import LoginUpdModal from '@/views/affect/AF/AWAF00904D/index.vue'
import { FormInstance } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { pwdValidate, validate } from '@/utils/validate'
import { RoleAuthBaseVM, UserInfoVM } from '../type'
import emitter from '@/utils/event-bus'
import { Init as GetPsdRules } from '../../AWAF00201D/service'
import { changeFullAngle, replaceText } from '@/utils/util'
import { KengenStore } from '@/store'
import { EnumRegex } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface VM extends UserInfoVM {
  daterange: { value1: string; value2: string }
  pword: string
  checkpword?: string
}
const props = defineProps<{
  set: boolean
  isNew: boolean
  userid: string
  data: UserInfoVM | null
  sisyolist: CmSisyoVM[]
  groupAuth: DeepReadonly<RoleAuthBaseVM>
}>()

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { editJudge, pnoeditflg } = KengenStore
const setVisible = ref(false)
const updVisible = ref(false)
const passwordRules = ref<CmPwdInitResponse | null>(null) //パスワードポリシー
const maxlength = ref(50)

const formRef = ref<FormInstance>()
const formData = reactive<VM>({
  syozoku: '',
  stopflg: false,
  usernm: '',
  pword: '',
  checkpword: '',
  daterange: { value1: '', value2: '' },
  yukoymdf: '',
  yukoymdt: '',
  errorkaisu: 0,
  regsisyolist: [],
  editsisyolist: [],
  kanrisyaflg: false,
  kanrisyakeisyoflg: true,
  pnoeditflg: false,
  pnoeditkeisyoflg: true,
  alertviewflg: false,
  alertviewkeisyoflg: true,
  authsisyokeisyoflg: true,
  upddttm: null,
  authsetflg: false
})

const rules = {
  usernm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザー名') }],
  pword: [
    {
      validator: validatePassword,
      trigger: ['blur']
    }
  ],
  checkpword: [
    {
      validator: async (_rule, value: string) => {
        await validate({
          is: props.isNew && !value,
          type: 'REQUIRE',
          name: 'パスワード確認'
        })
        await validate({
          is: Boolean(formData.pword && value !== formData.pword),
          type: 'NOTEQUAL',
          name: 'パスワード'
        })
        return Promise.resolve()
      },
      trigger: ['blur', 'change']
    }
  ],
  daterange: [
    {
      validator: async (_, value) => {
        await validate({
          is: !value.value1 || !value.value2,
          type: 'REQUIRE',
          name: 'アカウント有効年月日'
        })
        return Promise.resolve()
      }
    }
  ]
}

//パスワード関連チェック
async function validatePassword(_rule, value: string) {
  //必須チェック
  if (props.isNew) {
    await validate({
      is: !value,
      type: 'REQUIRE',
      name: 'パスワード'
    })
  }
  //パスワードポリシー
  if (!passwordRules.value) return Promise.resolve()
  maxlength.value = passwordRules.value.maxlen ?? 50
  await pwdValidate(passwordRules.value, value)
  return Promise.resolve()
}

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onBeforeMount(async () => {
  if (props.data) {
    //初期化
    !props.isNew && Object.assign(formData, props.data)
    formData.daterange = { value1: props.data.yukoymdf, value2: props.data.yukoymdt }
  }
})
onMounted(async () => {
  if (props.data) {
    //パスワードポリシー
    const res = await GetPsdRules()
    passwordRules.value = res
    //所属グループ変更後
    emitter.on('afterChangeSyzoku', async (syozoku) => {
      formData.syozoku = syozoku as string
      if (syozoku === undefined) {
        resetKeisyoflg()
      }
      if (!props.set && syozoku) {
        setPermission()
      }
    })
  }
  editJudge.reset()
})
onUnmounted(() => {
  emitter.clearKey('afterChangeSyzoku')
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.set,
  (set) => {
    editJudge.setEdited()
    resetKeisyoflg()
    setPermission()
    if (set && !pnoeditflg && props.data) formData.pnoeditflg = props.data.pnoeditflg
  }
)

watch(formData, () => {
  editJudge.setEdited()
  if (!formData.kanrisyaflg && pnoeditflg) formData.pnoeditflg = false
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//継承可能フラグリセット
function resetKeisyoflg() {
  formData.alertviewkeisyoflg = true
  formData.pnoeditkeisyoflg = true
  formData.kanrisyakeisyoflg = true
  formData.authsisyokeisyoflg = true
}
//設定ユーザー権限
function setPermission() {
  formData.alertviewflg = props.groupAuth.alertviewflg
  formData.pnoeditflg = props.groupAuth.pnoeditflg
  formData.kanrisyaflg = props.groupAuth.kanrisyaflg
  formData.editsisyolist = JSON.parse(JSON.stringify(props.groupAuth.editsisyolist))
}

//登録部署
function changeRegsisyo(val, opt) {
  formData.regsisyolist = opt
}
//登録部署別更新権限
function changeEditsisyo(val, opt) {
  formData.editsisyolist = opt
}
//ドロップダウンリスト検索
function filterOption(input: string, option: CmSisyoVM) {
  return (
    option.sisyonm.toLowerCase().includes(input.toLowerCase()) ||
    option.sisyocd.toLowerCase().includes(input.toLowerCase())
  )
}

//ユーザー権限画面表示仕様変換
function getClassObj(flg: string) {
  return {
    'c-red': !formData[flg] && props.set,
    'bg-readonly':
      (formData.syozoku && !props.set) ||
      ((!pnoeditflg || !formData.kanrisyaflg) && flg === 'pnoeditkeisyoflg')
  }
}
//入力チェック
async function validateForm() {
  try {
    await formRef.value?.validate()
    const saveData = {
      ...formData,
      yukoymdf: formData.daterange.value1,
      yukoymdt: formData.daterange.value2,
      checkpword: undefined
    }
    return Promise.resolve(saveData)
  } catch (error) {
    return Promise.reject(error)
  }
}

defineExpose({
  validate: validateForm
})
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 210px;
}
.c-red {
  color: rgba(248, 113, 113) !important;
}
</style>
