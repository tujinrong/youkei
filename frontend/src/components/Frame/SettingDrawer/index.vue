<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: システム設定
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="setting-drawer">
    <a-drawer
      width="320"
      placement="right"
      :closable="false"
      :visible="state.app.showSettings"
      @close="onClose"
    >
      <div class="setting-drawer-index-content">
        <theme-color />
        <navigation-mode />
      </div>
      <template #handle>
        <div v-if="state.app.showSettings" class="setting-drawer-index-handle" @click="onClose">
          <CloseOutlined style="color: #fff" />
        </div>
      </template>
    </a-drawer>
  </div>
</template>

<script lang="ts" setup>
import { useStore } from 'vuex'
import { CloseOutlined } from '@ant-design/icons-vue'
import { SET_SETTING_DRAWER } from '@/constants/mutation-types'
import ThemeColor from './components/theme-color.vue'
import NavigationMode from './components/navigation-mode.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { state, commit } = useStore()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const onClose = () => {
  commit(SET_SETTING_DRAWER, false)
}
</script>

<style lang="less" scoped>
@import '@/style/index.less';
.setting-drawer-index-content {
  :deep(.setting-drawer-index-blockChecbox) {
    display: flex;

    .setting-drawer-index-item {
      margin-right: 16px;
      position: relative;
      border-radius: 4px;
      cursor: pointer;

      img {
        width: 48px;
      }

      .setting-drawer-index-selectIcon {
        position: absolute;
        top: 0;
        right: 0;
        width: 100%;
        padding-top: 15px;
        padding-left: 24px;
        height: 100%;
        color: var(--ant-primary-color);
        font-size: 14px;
        font-weight: 700;
      }
    }
  }
}

.setting-drawer-index-handle {
  position: absolute;
  top: 240px;
  background: var(--ant-primary-color);
  width: 48px;
  height: 48px;
  right: 320px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  pointer-events: auto;
  z-index: 1001;
  text-align: center;
  font-size: 16px;
  border-radius: 4px 0 0 4px;

  i {
    color: rgb(255, 255, 255);
    font-size: 20px;
  }
}
</style>
