<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 閉じるボタン(画面)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-button class="ml-a" type="primary" @click="close">閉じる</a-button>
</template>

<script lang="ts" setup>
import { useRouteStore } from '@/store/modules/route'
import { useTabStore } from '@/store/modules/tab'
import { showConfirmModal } from '@/utils/modal'
import { RouteKey } from '@elegant-router/types'
import { useRoute } from 'vue-router'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tabStore = useTabStore()
const route = useRoute()
const routeStore = useRouteStore()
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const close = async () => {
  showConfirmModal({
    content: '終了しました、よろしいですか？',
    onOk: async () => {
      tabStore.removeActiveTab()
      routeStore.reCacheRoutesByKey(route.name as RouteKey)
    },
  })
}

defineExpose({ close })
</script>
