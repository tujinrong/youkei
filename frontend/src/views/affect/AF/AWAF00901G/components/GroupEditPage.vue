<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー管理(詳細画面：所属)
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
          <a-col span="24">
            <th :class="[isNew ? 'bg-editable' : 'bg-readonly', 'w-36']">
              所属グループID<span v-if="isNew" class="request-mark">＊</span>
            </th>
            <td v-if="isNew">
              <a-form-item name="syozokucd">
                <a-input
                  v-model:value="formData.syozokucd"
                  :maxlength="3"
                  @change="
                    () => {
                      formData.syozokucd = replaceText(formData.syozokucd, EnumRegex.半角英数)
                      editJudge.setEdited()
                    }
                  "
                ></a-input>
              </a-form-item>
            </td>
            <TD v-else>{{ formData.syozokucd }}</TD>
          </a-col>
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
        <a-tab-pane :key="Enum権限Mod.情報" tab="所属グループ情報"></a-tab-pane>
        <a-tab-pane :key="Enum権限Mod.画面" tab="権限（個別画面）"></a-tab-pane>
        <a-tab-pane :key="Enum権限Mod.共通" tab="権限（共通機能）"></a-tab-pane>
        <a-tab-pane :key="Enum権限Mod.EUC" tab="権限（EUC帳票）"></a-tab-pane>
      </a-tabs>
      <GroupInfo
        v-show="activeKey === Enum権限Mod.情報"
        ref="johoRef"
        :is-new="isNew"
        :data="syozokuInfo"
        :sisyolist="allSisyolist"
        :head-ref="headRef"
      />
      <PermissionForScreen
        v-show="activeKey === Enum権限Mod.画面"
        ref="screenRef"
        :data="gamenAuthList"
        set
        :head-ref="headRef"
      />
      <PermissionForCommon
        v-show="activeKey === Enum権限Mod.共通"
        ref="commonRef"
        set
        :data="commonAuthList"
        :head-ref="headRef"
      />
      <PermissionForEUC
        v-show="activeKey === Enum権限Mod.EUC"
        ref="eucRef"
        set
        :data="eucAuthList"
        :head-ref="headRef"
      />
    </a-card>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted, reactive } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import GroupInfo from './GroupInfo.vue'
import PermissionForScreen from './PermissionForScreen.vue'
import PermissionForCommon from './PermissionForCommon.vue'
import PermissionForEUC from './PermissionForEUC.vue'
import { Save, InitDetail } from '../service'
import { EnumRegex, EnumServiceResult, Enumロール区分, Enum権限Mod, Enum編集区分 } from '#/Enums'
import { CmBarVM, GamenVM, KinoLockVM, ReportLockVM, ReportVM, SyozokuInfoVM } from '../type'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { FormInstance, message } from 'ant-design-vue'
import { showSaveModal } from '@/utils/modal'
import emitter from '@/utils/event-bus'
import { KengenStore } from '@/store'
import { replaceText } from '@/utils/util'
import TD from '@/components/Common/TableTD/index.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const headRef = ref()
const loading = ref(false)
const loading_save = ref(false)
const { editJudge } = KengenStore
const isNew = Number(route.query.syozoku) < 0 //新規モード
const activeKey = ref(Enum権限Mod.情報)
//テンプレート参照
const johoRef = ref<InstanceType<typeof GroupInfo> | null>(null)
const screenRef = ref<InstanceType<typeof PermissionForScreen> | null>(null)
const commonRef = ref<InstanceType<typeof PermissionForCommon> | null>(null)
const eucRef = ref<InstanceType<typeof PermissionForEUC> | null>(null)
const formRef = ref<FormInstance>()
//ビューモデル
const formData = reactive({ syozokucd: '' })
const syozokuInfo = ref<SyozokuInfoVM | null>(null)
const gamenAuthList = ref<GamenVM[]>([])
const commonAuthList = ref<CmBarVM[]>([])
const eucAuthList = ref<ReportVM[]>([])
const allSisyolist = ref<CmSisyoVM[]>([])
//排他
let gamenLockList: KinoLockVM[] = []
let commonLockList: KinoLockVM[] = []
let eucLockList: ReportLockVM[] = []
let userLockList: string[] = []

const rules = {
  syozokucd: [{ required: isNew, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '所属グループID') }]
}
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  loading.value = true
  if (!isNew) formData.syozokucd = route.query.syozoku as string
  const res = await InitDetail({
    syozoku: formData.syozokucd,
    roleid: formData.syozokucd,
    rolekbn: Enumロール区分.所属,
    editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
  })
  //クリア処理
  if (res.maininfo2) {
    res.maininfo2.userlist1 ??= []
    res.maininfo2.editsisyolist ??= []
  }

  syozokuInfo.value = res.maininfo2
  gamenAuthList.value = res.kekkalist1
  commonAuthList.value = res.kekkalist2
  eucAuthList.value = res.kekkalist3
  allSisyolist.value = res.sisyolist
  KengenStore.setPnoeditflg(res.pnoeditflg)
  //排他
  gamenLockList = res.kekkalist1
    .filter((item) => item.upddttm)
    .map((item) => ({ kinoid: item.kinoid, upddttm: item.upddttm }))
  commonLockList = res.kekkalist2
    .filter((item) => item.upddttm)
    .map((item) => ({ kinoid: item.kinoid, upddttm: item.upddttm }))
  eucLockList = res.kekkalist3
    .filter((item) => item.upddttm)
    .map((item) => ({ repgroupid: item.repgroupid, upddttm: item.upddttm }))
  userLockList = res.maininfo2?.userlist1.map((user) => user.userid) || []

  loading.value = false
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//保存処理
async function submitData() {
  await formRef.value?.validate()
  const gamenList = screenRef.value?.submit() || []
  const commonList = commonRef.value?.submit() || []
  const eucList = eucRef.value?.submit() || []

  johoRef.value
    ?.validate()
    .then(async (res) => {
      res.userlist1.forEach((item) => {
        item.syozokucd = route.query.syozoku as string
      })
      const params = {
        roleid: formData.syozokucd,
        rolekbn: Enumロール区分.所属,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
        maininfo1: null,
        maininfo2: res,
        authlist1: [...gamenList, ...commonList],
        authlist2: eucList,
        keylist1: [...gamenLockList, ...commonLockList],
        keylist2: eucLockList,
        keylist3: userLockList,
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
