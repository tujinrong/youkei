<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 閉じる(終了)ボタン(画面)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-button class="ml-a" type="primary" @click="close">閉じる</a-button>
</template>

<script lang="ts" setup>
import { JUDGE_CONFIRM, END_CONFIRM } from '@/constants/msg'
import { useRouteStore } from '@/store/modules/route'
import { useTabStore } from '@/store/modules/tab'
import { Judgement } from '@/utils/judge-edited'
import { showConfirmModal } from '@/utils/modal'
import { RouteKey } from '@elegant-router/types'
import { useRoute } from 'vue-router'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tabStore = useTabStore()
const route = useRoute()
const routeStore = useRouteStore()
const props = defineProps<{
  editJudge: Judgement
}>()
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const close = async () => {
  if (props.editJudge.isPageEdited()) {
    showConfirmModal({
      content: JUDGE_CONFIRM,
      onOk: async () => {
        tabStore.removeActiveTab()
        routeStore.reCacheRoutesByKey(route.name as RouteKey)
      },
    })
  } else {
    showConfirmModal({
      content: END_CONFIRM,
      onOk: async () => {
        tabStore.removeActiveTab()
        routeStore.reCacheRoutesByKey(route.name as RouteKey)
      },
    })
  }
}

defineExpose({ close })
</script>
