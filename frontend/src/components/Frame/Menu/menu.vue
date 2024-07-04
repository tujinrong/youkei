<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: メニュー(トップサイド兼用：共通モデル)
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-menu
    v-model:open-keys="openKeys"
    :mode="mode"
    theme="dark"
    :selected-keys="selectedKeys"
    class="SysMenu"
    @select="onSelect"
  >
    <template v-for="m in menu" :key="m.path">
      <render-sub-menu v-if="!m.hidden" :menu="m" />
    </template>
  </a-menu>
</template>
<script lang="ts" setup>
import { onMounted, watch, ref } from 'vue'
import { useRouter } from 'vue-router'
import RenderSubMenu from './render-sub-menu.vue'
import { Router } from '@/router/types'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  menu: Router[]
  mode?: string
  collapsed?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  mode: 'inline',
  collapsed: false
})

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = router.currentRoute
const openKeys = ref<string[]>([])
const selectedKeys = ref<string[]>([])
const cachedOpenKeys = ref<string[]>([])

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.collapsed,
  (val) => {
    if (val) {
      cachedOpenKeys.value = openKeys.value.concat()
    } else {
      openKeys.value = cachedOpenKeys.value
    }
  }
)

watch(
  () => route.value,
  (val) => updateMenu()
)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  updateMenu()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面クリック
const onSelect = ({ item, key, selectedKeys: selectedKeysParams }) => {
  selectedKeys.value = selectedKeysParams
}
//メニュー選択状態更新
const updateMenu = () => {
  const routes = route.value.matched.concat()
  const { hidden } = route.value.meta
  if (routes.length >= 3 && hidden) {
    routes.pop()
    selectedKeys.value = [routes[routes.length - 1].path]
  } else {
    selectedKeys.value = [routes.pop()!.path]
  }
  const openKeysArr: any = []
  if (props.mode === 'inline') {
    routes.forEach((item) => {
      openKeysArr.push(item.path)
    })
  }
  props.collapsed ? (cachedOpenKeys.value = openKeysArr) : (openKeys.value = openKeysArr)
}
</script>
