<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <a-tabs v-model:activeKey="activeKey" type="card" size="large" class="card-container">
      <a-tab-pane key="1" tab="ユーザー">
        <UserList
          :options1="userOptions"
          :options2="groupOptions2"
          @go-group="activeKey = '2'"
          @init-option="initOption()"
        />
      </a-tab-pane>
      <a-tab-pane key="2" tab="グループ">
        <GroupList :options="groupOptions2" @init-option="initOption()" />
      </a-tab-pane>
    </a-tabs>
  </div>
  <div v-if="status === PageSatatus.Edit || status === PageSatatus.New">
    <UserEditPage v-if="activeKey === '1'" :options="groupOptions2" />
    <GroupEditPage v-if="activeKey === '2'" />
  </div>
</template>

<script setup lang="ts">
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import UserEditPage from './components/UserEditPage.vue'
import UserList from './components/UserList.vue'
import GroupEditPage from './components/GroupEditPage.vue'
import GroupList from './components/GroupList.vue'
import { InitList } from './service'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
const activeKey = ref('1')
const userOptions = ref<DaSelectorKeyModel[]>([])
const groupOptions2 = ref<DaSelectorModel[]>([])
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  initOption()
  if (route.query.syozoku) activeKey.value = '2'
  if (route.query.userid || route.query.syozoku) {
    if (Number(route.query.userid) < 0 || Number(route.query.syozoku) < 0) {
      status.value = PageSatatus.New
    } else {
      status.value = PageSatatus.Edit
    }
  }
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWAF00901G') {
      if (route.query.userid || route.query.syozoku) {
        if (Number(route.query.userid) < 0 || Number(route.query.syozoku) < 0) {
          status.value = PageSatatus.New
        } else {
          status.value = PageSatatus.Edit
        }
      } else {
        status.value = PageSatatus.List
      }
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const initOption = () => {
  InitList().then((res) => {
    userOptions.value = res.selectorlist1
    groupOptions2.value = res.selectorlist2
  })
}
</script>

<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}

:deep(.card-container .ant-tabs-nav) {
  margin: -1px !important;
}
</style>
