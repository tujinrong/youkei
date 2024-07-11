<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ナビゲーションモード
 * 　　　　　  システム設定
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <setting-item title="ナビゲーションモード">
    <div class="setting-drawer-index-blockChecbox">
      <a-tooltip>
        <template #title>サイドバーナビゲーション</template>
        <div class="setting-drawer-index-item" @click="handleLayout(MenuType.Side)">
          <img src="@/assets/icons/sideMenu.svg" alt="sidemenu" />
          <div v-if="layoutMode === MenuType.Side" class="setting-drawer-index-selectIcon">
            <CheckOutlined />
          </div>
        </div>
      </a-tooltip>

      <a-tooltip>
        <template #title>トップバーのナビゲーション</template>
        <div class="setting-drawer-index-item" @click="handleLayout(MenuType.Top)">
          <img src="@/assets/icons/topMenu.svg" alt="topmenu" />
          <div v-if="layoutMode !== MenuType.Side" class="setting-drawer-index-selectIcon">
            <CheckOutlined />
          </div>
        </div>
      </a-tooltip>
    </div>
  </setting-item>
</template>
<script lang="ts" setup>
import { useStore } from 'vuex'
import { TOGGLE_LAYOUT_MODE, TOGGLE_FIXED_SIDERBAR } from '@/constants/mutation-types'
import { layoutMode } from '@/store/use-site-settings'
import { CheckOutlined } from '@ant-design/icons-vue'
import SettingItem from './setting-item.vue'
import { MenuType } from '#/Enums'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { state, commit } = useStore()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const handleLayout = (mode) => {
  commit(TOGGLE_LAYOUT_MODE, mode)
  handleFixSiderbar()
}
const handleFixSiderbar = () => {
  if (state.app.layoutMode === MenuType.Top) {
    commit(TOGGLE_FIXED_SIDERBAR, false)
  } else {
    commit(TOGGLE_FIXED_SIDERBAR, true)
  }
}
</script>
<style lang="less" scoped></style>
