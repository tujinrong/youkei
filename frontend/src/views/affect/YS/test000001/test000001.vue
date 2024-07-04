<template>
  <div v-if="status == PageSatatus.List">
    <kosin-nyu-search />
  </div>
  <div v-else-if="status == PageSatatus.Edit">
    <kosin-nyu-edit />
  </div>
</template>
<script lang="ts">
export default { name: 'MockYSKosinNyu' }
</script>
<script setup lang="ts">
//---------------------------------------------------------------------------
//乳幼児予防接種
//---------------------------------------------------------------------------
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import KosinNyuSearch from './kosin-nyu-search.vue'
import KosinNyuEdit from './kosin-nyu-edit.vue'

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
