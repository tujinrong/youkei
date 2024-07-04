<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ロゴ
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="logo">
    <router-link :to="{ name: 'AWAF00301G' }">
      <svg-icon name="logo" />
      <h1 v-if="showTitle">{{ title }}</h1>
    </router-link>
  </div>
</template>

<script lang="ts" setup>
import SvgIcon from '@/components/Common/SvgIcon/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps({
  title: {
    type: String,
    default: 'AFFECT',
    required: false
  },
  showTitle: {
    type: Boolean,
    default: true,
    required: false
  }
})
</script>
