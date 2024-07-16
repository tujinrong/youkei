<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ログイン画面用
 * 　　　　　  共通レイアウト
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div id="userLayout" :class="['user-layout-wrapper']">
    <div class="user-container">
      <div class="user-layout-lang"></div>
      <div class="user-layout-content">
        <div class="top" style="margin-top: 120px">
          <div class="header">
            <div>
              <img src="~@/assets/icons/logo.svg" class="logo" alt="logo" />
              <span class="title">養鶏-互助防疫システム</span>
            </div>
          </div>
        </div>
        <router-view />
        <div class="footer">
          <div class="copyright">
            Copyright &copy;&nbsp;{{ new Date().getFullYear() }} 養鶏-互助防疫
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, onBeforeUnmount } from 'vue'
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  document.body.classList.add('userLayout')
})
onBeforeUnmount(() => {
  document.body.classList.remove('userLayout')
})
</script>

<style src="./user-layout.less" scoped></style>
