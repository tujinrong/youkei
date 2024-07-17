<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ホーム
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.02.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="home flex">
    <!-- <h1 class="title">ようこそ</h1> -->
    <a-button type="primary" @click="open">jump</a-button>
  </div>
</template>

<script lang="ts" setup>
function open() {
  const width = 800
  const height = 600
  const left = window.screen.width / 2 - width / 2
  const top = window.screen.height / 2 - height / 2
  const features = `width=${width},height=${height},left=${left},top=${top},toolbar=yes,menubar=yes,location=yes,status=yes`
  window.open('http://localhost:3000/home', '_blank', features)
}
</script>

<style lang="less" scoped>
.home {
  display: flex;
  justify-content: center;
  height: 100vh;
  background-color: white;
  //background-image: url('./logo.jpg');
  background-size: cover;
  background-position: center;
}

.title {
  color: #ffa500;
  font-size: 3rem;
  text-align: center;
}
</style>
