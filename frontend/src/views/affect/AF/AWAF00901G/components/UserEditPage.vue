<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ユーザー管理(詳細画面：ユーザー)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card ref="headRef" :bordered="false">
      <a-form ref="formRef" :model="formData" :rules="rules">
        <div class="self_adaption_table">
          <a-row>
            <a-col span="24">
              <th :class="[isNew ? 'bg-editable' : 'bg-readonly', 'w-32']">
                ユーザーID<span v-if="isNew" class="request-mark">＊</span>
              </th>
              <td v-if="isNew">
                <a-form-item name="userid">
                  <a-input
                    v-model:value="formData.userid"
                    :maxlength="10"
                    @change="
                      () => {
                        formData.userid = replaceText(formData.userid, EnumRegex.半角英数)
                        editJudge.setEdited()
                      }
                    "
                  ></a-input>
                </a-form-item>
              </td>
              <TD v-else>{{ route.query.userid }}</TD>
            </a-col>
            <a-col span="24">
              <th class="w-32 bg-editable">所属グループ</th>
              <td>
                <a-form-item name="syozoku">
                  <ai-select
                    v-model:value="formData.syozoku"
                    :options="props.options"
                    @change="onChangeSyozoku"
                  />
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
      </a-form>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button class="warning-btn" :loading="loading_save" @click="submitData">登録</a-button>
          <a-button type="primary" @click="goList">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="my-2" :loading="loading">
      <a-tabs v-model:activeKey="activeKey" type="card">
        <a-tab-pane :key="Enum権限Mod.情報" tab="ユーザー情報"> </a-tab-pane>
        <a-tab-pane :key="Enum権限Mod.画面" tab="権限（個別画面）"></a-tab-pane>
        <a-tab-pane :key="Enum権限Mod.共通" tab="権限（共通機能）"></a-tab-pane>
        <a-tab-pane :key="Enum権限Mod.EUC" tab="権限（EUC帳票）"></a-tab-pane>
        <template #rightExtra>
          <a-checkbox v-model:checked="userSetChecked" :disabled="!formData.syozoku">
            ユーザー個別に設定
          </a-checkbox>
        </template>
      </a-tabs>

      <UserInfo
        v-show="activeKey === Enum権限Mod.情報"
        ref="johoRef"
        :set="userSetChecked"
        :is-new="isNew"
        :data="userInfo"
        :sisyolist="allSisyolist"
        :group-auth="groupAuth"
        :userid="formData.userid"
      />
      <PermissionForScreen
        v-show="activeKey === Enum権限Mod.画面"
        ref="screenRef"
        :set="userSetChecked"
        :data="gamenAuthList"
        :fixed-data="gamenGroupList"
        has-extend
        :head-ref="headRef"
      />
      <PermissionForCommon
        v-show="activeKey === Enum権限Mod.共通"
        ref="commonRef"
        :set="userSetChecked"
        :data="commonAuthList"
        :fixed-data="commonGroupList"
        has-extend
        :head-ref="headRef"
      />
      <PermissionForEUC
        v-show="activeKey === Enum権限Mod.EUC"
        ref="eucRef"
        :set="userSetChecked"
        :data="eucAuthList"
        :fixed-data="eucGroupList"
        has-extend
        :head-ref="headRef"
      />
      <div class="m-t-1">
        ※ユーザー個別に設定した項目は<span class="c-red5">赤字</span
        >で表示されます。この項目は所属グループで変更しても更新されません。
      </div>
    </a-card>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted, reactive, readonly, DeepReadonly } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import UserInfo from './UserInfo.vue'
import PermissionForScreen from './PermissionForScreen.vue'
import PermissionForCommon from './PermissionForCommon.vue'
import PermissionForEUC from './PermissionForEUC.vue'
import { InitDetail, Save, SearchDetail } from '../service'
import { EnumServiceResult, Enumロール区分, Enum権限Mod, Enum編集区分 } from '#/Enums'
import {
  CmBarVM,
  GamenVM,
  KinoLockVM,
  ReportLockVM,
  ReportVM,
  RoleAuthBaseVM,
  UserInfoVM
} from '../type'
import { FormInstance, message } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import emitter from '@/utils/event-bus'
import { encryptBySHA256 } from '@/utils/encrypt/data'
import { KengenStore } from '@/store'
import { replaceText } from '@/utils/util'
import { EnumRegex } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'

const props = defineProps<{
  options: DaSelectorModel[]
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const headRef = ref()
const loading = ref(false)
const loading_save = ref(false)
const { editJudge } = KengenStore
const isNew = Number(route.query.userid) < 0 //新規モード
const activeKey = ref(Enum権限Mod.情報)
//テンプレート参照
const johoRef = ref<InstanceType<typeof UserInfo> | null>(null)
const screenRef = ref<InstanceType<typeof PermissionForScreen> | null>(null)
const commonRef = ref<InstanceType<typeof PermissionForCommon> | null>(null)
const eucRef = ref<InstanceType<typeof PermissionForEUC> | null>(null)
const formRef = ref<FormInstance>()
//ビューモデル
const userSetChecked = ref(true)
const formData = reactive({ userid: '', syozoku: '' })
const userInfo = ref<UserInfoVM | null>(null)
const gamenAuthList = ref<GamenVM[]>([])
const commonAuthList = ref<CmBarVM[]>([])
const eucAuthList = ref<ReportVM[]>([])
const allSisyolist = ref<CmSisyoVM[]>([])
//所属の権限
const gamenGroupList = ref<GamenVM[]>([])
const commonGroupList = ref<CmBarVM[]>([])
const eucGroupList = ref<ReportVM[]>([])
//排他
let gamenLockList: KinoLockVM[] = []
let commonLockList: KinoLockVM[] = []
let eucLockList: ReportLockVM[] = []

const rules = {
  userid: [{ required: isNew, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザーID') }]
}

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  loading.value = true
  //データを格納
  formData.userid = isNew ? '' : String(route.query.userid)
  formData.syozoku =
    props.options.find((opt) => opt.value === (route.query.syozokucd as string))?.value ?? ''
  if (formData.syozoku) await getGroupDetail()

  const res = await InitDetail({
    syozoku: isNew ? '' : (route.query.syozokucd as string),
    roleid: isNew ? '' : (route.query.userid as string),
    rolekbn: Enumロール区分.ユーザー,
    editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
  })
  //権限データ(所属)
  res.kekkalist4 ??= []
  res.kekkalist5 ??= []
  res.kekkalist6 ??= []

  userSetChecked.value = isNew || Boolean(res.maininfo1?.authsetflg)
  userInfo.value = res.maininfo1
  gamenAuthList.value = res.kekkalist4
  commonAuthList.value = res.kekkalist5
  eucAuthList.value = res.kekkalist6
  allSisyolist.value = res.sisyolist
  KengenStore.setPnoeditflg(res.pnoeditflg)
  //排他
  gamenLockList = res.kekkalist4
    .filter((item) => item.upddttm)
    .map((item) => ({ kinoid: item.kinoid, upddttm: item.upddttm }))
  commonLockList = res.kekkalist5
    .filter((item) => item.upddttm)
    .map((item) => ({ kinoid: item.kinoid, upddttm: item.upddttm }))
  eucLockList = res.kekkalist6
    .filter((item) => item.upddttm)
    .map((item) => ({ repgroupid: item.repgroupid, upddttm: item.upddttm }))

  loading.value = false
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
let groupAuth: DeepReadonly<RoleAuthBaseVM>
//所属の権限
async function getGroupDetail() {
  const res = await SearchDetail({ syozoku: formData.syozoku })
  gamenGroupList.value = res.kekkalist1
  commonGroupList.value = res.kekkalist2
  eucGroupList.value = res.kekkalist3
  groupAuth = readonly(res.authvm)
}
//所属変更処理
async function onChangeSyozoku(val?: string) {
  editJudge.setEdited()
  if (val) await getGroupDetail()
  emitter.emit('afterChangeSyzoku', val)
  if (val === undefined) {
    userSetChecked.value = true
  }
}
//登録処理
async function submitData() {
  await formRef.value?.validate()
  const gamenList = screenRef.value?.submit() || []
  const commonList = commonRef.value?.submit() || []
  const eucList = eucRef.value?.submit() || []

  johoRef.value
    ?.validate()
    .then(async (res) => {
      if (res.pword) {
        res.pword = encryptBySHA256(res.pword, formData.userid)
      }
      const params = {
        roleid: formData.userid,
        rolekbn: Enumロール区分.ユーザー,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
        maininfo1: { ...res, authsetflg: userSetChecked.value },
        maininfo2: null,
        authlist1: [...gamenList, ...commonList],
        authlist2: eucList,
        keylist1: [...gamenLockList, ...commonLockList],
        keylist2: eucLockList,
        keylist3: [],
        checkflg: false
      }

      const saveReq = async () => {
        await Save(params)
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        emitter.emit('refreshPermissionList')
        goList()
      }

      loading_save.value = true
      await Save({ ...params, checkflg: true }, async (response: DaResponseBase) => {
        if (response.returncode === EnumServiceResult.ServiceAlert) {
          await saveReq()
        }
      }).finally(() => (loading_save.value = false))

      showSaveModal({
        onOk: async () => {
          try {
            await saveReq()
          } catch (error) {}
        }
      })
    })
    .catch(() => {
      activeKey.value = Enum権限Mod.情報
    })
}

//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  })
}
</script>
