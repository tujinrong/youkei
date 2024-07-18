<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 共通フォーム(ユーザー)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="user-wrapper">
    <div class="content-box" style="height: 48px">
      <a-dropdown>
        <span class="action ant-dropdown-link user-dropdown-menu">
          <a-button type="primary" shape="circle">{{ nickname[0] }}</a-button>
          <span class="nickname">{{ nickname }}</span>
        </span>
        <template #overlay>
          <a-menu class="user-dropdown-menu-wrapper">
            <a-menu-item @click="showChangePassword">
              <a>
                <LockOutlined />
                <span>パスワード変更</span>
              </a>
            </a-menu-item>
            <!-- <a-menu-item v-if="UserInfo.kanrisyaflg">
              <a href="javascript:;" @click="goAdminPage">
                <UserSwitchOutlined />
                <span>ユーザー管理</span>
              </a>
            </a-menu-item> -->
            <a-menu-divider />
            <a-menu-item>
              <a href="javascript:;" @click="handleLogout">
                <LogoutOutlined />
                <span>ログアウト</span>
              </a>
            </a-menu-item>
          </a-menu>
        </template>
      </a-dropdown>
    </div>
  </div>
  <PasswordChangeModal v-model:visible="passwordVisible" />
</template>

<script lang="ts" setup>
import { ref, watch, onMounted } from 'vue'
import { message } from 'ant-design-vue'
import { useStore } from 'vuex'
import { useRouter } from 'vue-router'
import { useRoute } from 'vue-router'
import {
  SettingOutlined,
  LogoutOutlined,
  LockOutlined,
  HeartOutlined,
  QuestionOutlined,
  HistoryOutlined,
  UserSwitchOutlined
} from '@ant-design/icons-vue'
// import generateAsyncRoutes from '@/router/generate-async-routes'
import emitter from '@/utils/event-bus'
import { ss } from '@/utils/storage'
import { clearUserInfo, getUserInfo } from '@/utils/user'
import { useBoolean } from '@/utils/hooks'
import { getUserMenu } from '@/utils/user'
import { showConfirmModal, showDeleteModal } from '@/utils/modal'
import { PAGE_DATA, REGSISYO, SET_USER_HISTORY, USER_INFO } from '@/constants/mutation-types'
import { C003004, C003005, LOGOUT_CONFIRM, LOGOUT_OK_INFO } from '@/constants/msg'
import PasswordChangeModal from '@/views/affect/AF/AWAF00201D/index.vue'
import HistoryMenu from '@/views/affect/AF/AWAF00202S/index.vue'
import FavoriteModal from '@/views/affect/AF/AWAF00303D/index.vue'
import { showHelp } from '@/views/affect/AF/AWAF00203S'
import { Search } from '@/views/affect/AF/AWAF00202S/service'
import { Update, Init } from '@/views/affect/AF/AWAF00303D/service'
import { Enumお気に入り区分, Enum更新区分 } from '#/Enums'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const store = useStore()

const UserInfo = ss.get(USER_INFO)
const passwordVisible = ref(false)
const historyTipVisible = ref(false)
const nickname = ref(UserInfo.usernm)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
// onMounted(() => searchData())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  const res = await Search()
  //無権限項禁止
  const menu = getUserMenu()
  res.kekkalist.forEach((item) => {
    const finder = menu.find((m) => m.menuid === item.kinoid)
    if (finder) item.disabled = !finder.enabled
    if (item.kinoid === 'AWAF00901G') {
      item.disabled = !getUserInfo().kanrisyaflg
    }
  })

  store.commit(SET_USER_HISTORY, res.kekkalist)
}

//使用履歴
const showHistory = async () => {
  historyTipVisible.value = false
  searchData()
}

//ログアウト
const handleLogout = () => {
  showConfirmModal({
    title: 'ログアウト',
    content: LOGOUT_CONFIRM,
    onOk: () => {
      clearUserInfo()
      ss.remove(PAGE_DATA)
      message.success(LOGOUT_OK_INFO.Msg)
      router.removeRoute('index')
      location.reload()
    }
  })
}

//パスワード変更
const showChangePassword = () => {
  passwordVisible.value = true
}
emitter.once('openPwdChangeModal', () => showChangePassword())

//システム設定
const showSystemSetting = () => {
  store.commit('SET_SETTING_DRAWER', true)
}

//--------------------------------------------------------------------------
//お気に入り
const liked = ref(false)
const currentUrl = ref('')
const kinoid = ref('')
const { bool: modalVisible, setTrue: openModal } = useBoolean()

const showLikeModal = () => {
  if (currentUrl.value === '/home') {
    openModal()
  } else {
    if (liked.value) {
      showDeleteModal({
        handleDB: true,
        title: 'お気に入り',
        content: C003005,
        onOk: () => {
          onChangeCollect(false)
        }
      })
    } else {
      showConfirmModal({
        handleDB: true,
        title: 'お気に入り',
        content: C003004,
        onOk: () => {
          onChangeCollect(true)
        }
      })
    }
  }
}
const onChangeCollect = async (value: boolean) => {
  const updkbn = value ? Enum更新区分.追加 : Enum更新区分.削除
  const { kekkalist } = await Update({ kinoid: kinoid.value, updkbn })
  liked.value = value
  // generateAsyncRoutes(kekkalist)
}
const goAdminPage = () => {
  router.push({ name: 'AWAF00901G' })
}

watch(
  () => route.path,
  async (val) => {
    currentUrl.value = val
    kinoid.value = router.currentRoute.value.name as string
    if (val.trim() === '/home') {
      liked.value = false
    } else {
      // const res = await Init({ kinoid: kinoid.value })
      // liked.value = res.statuskbn === Enumお気に入り区分.あり
    }
  },
  { immediate: true }
)
//--------------------------------------------------------------------------
</script>
<style src="./index.less"></style>
