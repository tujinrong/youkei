<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 閉じるボタン(画面)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-button class="ml-a" type="primary" @click="close">閉じる</a-button>
</template>

<script lang="ts" setup>
import { useStore } from 'vuex'
import { TAB_PAGES_CLOSE } from '@/constants/mutation-types'
import { CLOSE_CONFIRM } from '@/constants/msg'
import { useRoute } from 'vue-router'
import { showConfirmModal } from '@/utils/modal'
import { judgeStore } from '@/store'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { commit } = useStore()
const route = useRoute()
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const close = () => {
  const isEdit = judgeStore[route.name as string]
  if (isEdit) {
    showConfirmModal({
      content: CLOSE_CONFIRM.Msg,
      onOk: async () => {
        commit(TAB_PAGES_CLOSE, true)
        judgeStore[route.name as string] = false
      }
    })
  } else {
    commit(TAB_PAGES_CLOSE, true)
  }
}

defineExpose({ close })
</script>
