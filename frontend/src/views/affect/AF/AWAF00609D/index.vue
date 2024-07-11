<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: フォロー管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="フォロー管理"
    centered
    :mask-closable="false"
    :closable="false"
    destroy-on-close
    :footer="null"
  >
    <CloseModalBtn class="close-btn" @click="clickClose" />
    <div class="h-190">
      <ListPage2
        v-if="status === PageSatatus.List"
        ref="listPage"
        v-model:header="header"
        v-model:status="status"
        v-model:follownaiyoedano="follownaiyoedano"
      />
      <ResultPage
        v-if="status !== PageSatatus.List"
        ref="resultPage"
        v-model:status="status"
        :header="header"
        :follownaiyoedano="follownaiyoedano"
        @forward-list="forwardList"
      />
    </div>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, nextTick } from 'vue'
import ListPage2 from './components/ListPage2.vue'
import ResultPage from './components/ResultPage.vue'
import { PageSatatus } from '#/Enums'

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const visible = ref(false)
const status = ref(PageSatatus.List)
const follownaiyoedano = ref(-1)
const header = ref<CommonBarHeaderBase3VM | null>(null)
const resultPage = ref<InstanceType<typeof ResultPage> | null>(null)
const listPage = ref<InstanceType<typeof ListPage2> | null>(null)

//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
function openModal() {
  visible.value = true
}

function forwardList(no?: number) {
  status.value = PageSatatus.List
  if (no) {
    nextTick(() => {
      listPage.value?.forwardResultPage({ follownaiyoedano: no })
    })
  }
}

function clickClose() {
  if (resultPage.value) {
    resultPage.value.editJudge.judgeIsEdited(() => {
      visible.value = false
      status.value = PageSatatus.List
    })
  } else {
    visible.value = false
    status.value = PageSatatus.List
  }
}

defineExpose({
  open: openModal
})
</script>
<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
