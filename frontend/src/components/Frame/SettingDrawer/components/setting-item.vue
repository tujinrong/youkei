<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 共通モデル(行単位)
 * 　　　　　  システム設定
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="setting-drawer-index-item">
    <h3 class="setting-drawer-index-title">{{ title }}</h3>
    <slot></slot>
    <a-divider v-if="divider" />
  </div>
</template>

<script lang="ts" setup>
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps({
  title: {
    type: String,
    default: ''
  },
  divider: {
    type: Boolean,
    default: true
  }
})
</script>

<style lang="less" scoped>
.setting-drawer-index-item {
  margin-bottom: 24px;

  .setting-drawer-index-title {
    font-size: 14px;
    color: rgba(0, 0, 0, 0.85);
    line-height: 22px;
    margin-bottom: 12px;
  }
}
</style>
