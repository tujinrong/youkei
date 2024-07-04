<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票発行履歴管理(詳細画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.22
 * 作成者　　: 千秋
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false">
    <div class="self_adaption_table" :class="{ form: isNew }"></div>
  </a-card>
  <a-card class="my-2" :loading="loading">
    <div class="self_adaption_table" :class="{ form: true }"></div>
  </a-card>
  <StaffModal v-model:visible="modalVisible" />
</template>

<script setup lang="ts">
import { Enum編集区分, PageSatatus } from '#/Enums'
import { onMounted, ref, watch, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Judgement } from '@/utils/judge-edited'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'

// const canDelete = computed(() => !isNew && canEdit)
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(true)
const editJudge = new Judgement(route.name as string)
const modalVisible = ref(false)
const isNew = props.status === PageSatatus.New

//操作権限フラグ
const canEdit = isNew || route.meta.updflg
const canDelete = route.meta.delflg

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  loading.value = true
  try {
    if (!isNew) {
    }
  } catch (error) {}
  nextTick(() => editJudge.reset())
  loading.value = false
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
</script>

<style scoped lang="less">
.self_adaption_table th {
  width: 130px;
}
:deep(.ant-form-item-extra) {
  color: #faad14;
}

.td-padding {
  padding: 0 !important;
}

.check-colume {
  display: flex;
  flex-direction: column;
}
</style>
