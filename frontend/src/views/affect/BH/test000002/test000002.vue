<template>
  <div v-if="status == PageSatatus.List">
    <kosin-ninsanpu-search />
  </div>
  <div v-else-if="status == PageSatatus.Edit">
    <kosin-ninsanpu-edit />
  </div>
</template>

<script lang="ts">
export default { name: 'MockBHKosinNinsanpu' }
</script>
<script setup lang="ts">
//---------------------------------------------------------------------------
//妊産婦情報管理
//---------------------------------------------------------------------------
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import kosinNinsanpuSearch from './components/kosin-ninsanpu-search.vue'
import kosinNinsanpuEdit from './components/kosin-ninsanpu-edit.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => (route.query?.atenano !== undefined ? PageSatatus.Edit : PageSatatus.List),
  (val) => {
    status.value = val as unknown as PageSatatus
  }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query?.atenano !== undefined) {
    status.value = PageSatatus.Edit
  }
})
</script>
