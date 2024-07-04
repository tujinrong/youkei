<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: App初期化
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-config-provider :locale="localeValues" component-size="middle">
    <router-view />
  </a-config-provider>
</template>

<script lang="ts" setup name="App">
import localeValues from 'ant-design-vue/es/locale/ja_JP'
import dayjs from 'dayjs'
import 'dayjs/locale/ja'
dayjs.locale('ja')
</script>

<style></style>
