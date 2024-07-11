<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ベース
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <transition name="showHeader">
    <div v-if="visible" class="header-animat">
      <a-layout-header
        v-if="visible"
        :class="[
          fixedHeader && 'ant-header-fixedHeader',
          sidebarOpened ? 'ant-header-side-opened' : 'ant-header-side-closed'
        ]"
        :style="{ padding: '0' }"
      >
        <div v-if="mode === MenuType.Side" class="header">
          <span @click="toggle">
            <MenuUnfoldOutlined v-if="collapsed" class="trigger" />
            <MenuFoldOutlined v-else class="trigger" />
          </span>
          <multi-tab v-if="multiTab"></multi-tab>
          <user-menu />
        </div>
        <div v-else :class="['top-nav-header-index', 'dark']">
          <div class="header-index-wide">
            <div class="header-index-left">
              <logo class="top-nav-header" />
              <s-menu mode="horizontal" :menu="menus" />
            </div>
            <div class="header-index-right">
              <user-menu />
            </div>
          </div>
        </div>
      </a-layout-header>
    </div>
  </transition>
</template>

<script lang="ts" setup>
import UserMenu from '../UserMenu/index.vue'
import SMenu from '../Menu/menu.vue'
import Logo from '../Logo/index.vue'
import MultiTab from '@/components/Frame/MultiTab/index.vue'
import { ref } from 'vue'
import { MenuFoldOutlined, MenuUnfoldOutlined } from '@ant-design/icons-vue'
import { sidebarOpened, fixedHeader, multiTab } from '@/store/use-site-settings'
import { MenuType } from '#/Enums'
import { Router } from '@/router/types'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  mode: string
  menus: Router[]
  collapsed?: boolean
}
const props = withDefaults(defineProps<Props>(), {
  mode: MenuType.Side
})
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['toggle'])
const visible = ref(true)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const toggle = () => {
  emit('toggle')
}
</script>

<style lang="less">
@import '@/style/index.less';

.header-animat {
  position: relative;
  z-index: @ant-global-header-zindex;
}
.showHeader-enter-active {
  transition: all 0.25s ease;
}
.showHeader-leave-active {
  transition: all 0.5s ease;
}
.showHeader-enter,
.showHeader-leave-to {
  opacity: 0;
}
</style>
