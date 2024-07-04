<template>
  <a-modal v-model:visible="contactVisible" width="600px" title="Hib·小児用肺炎球菌について">
    <a-checkbox v-model:checked="checked" style="float: left"
      >内容更新(閉じるときチェックされている場合、内容が更新されます。)</a-checkbox
    >
    <a-card>
      <div class="content">
        <div><bulb-outlined style="margin-left: 0" />Hibの入力について</div>
        <div>
          <p>接種開始が7か月未満場合</p>
          <span>1回目、2回目、3回目、追加に入力</span>
        </div>
        <div>
          <p>接種開始が7か月以上1歳未満の場合</p>
          <span>1回目、2回目追加入力</span>
        </div>
        <div>
          <p>接種開始が1歳以上の場合</p>
          <span>追加に入力</span>
        </div>
      </div>
      <div class="content">
        <div><bulb-outlined style="margin-left: 0" />小児用肺炎球菌(7価)の入力について</div>
        <div>
          <p>接種開始が7か月未満場合</p>
          <span>1回目、2回目、3回目、追加に入力</span>
        </div>
        <div>
          <p>接種開始が7か月以上1歳未満の場合</p>
          <span>1回目、2回目追加入力</span>
        </div>
        <div>
          <p>接種開始が1歳以上2歳未満の場合</p>
          <span>1回目、追加に入力</span>
        </div>
        <div>
          <p>接種開始が2歳以上の場合</p>
          <span>追加に入力</span>
        </div>
      </div>
    </a-card>
    <template #footer>
      <a-checkbox v-model:checked="checked2" style="float: left"
        >現在のユーザーでログインした場合、次回からこの画面を開かない。</a-checkbox
      >
      <a-button key="back" type="primary" @click="contactClose">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup>
//---------------------------------------------------------------------------
//Hib·小児用肺炎球菌について
//---------------------------------------------------------------------------
import { ref } from 'vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const contactVisible = ref(false)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//Show
function open() {
  contactVisible.value = true
}
//閉じる
const contactClose = () => {
  contactVisible.value = false
}
defineExpose({
  open
})
</script>
<style lang="less" scoped>
.content div {
  margin-bottom: 10px;
}
.content p {
  margin: 10px 0 0 10px;
}
.content span {
  margin-left: 20px;
}
</style>
