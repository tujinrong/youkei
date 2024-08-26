<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <div class="self_adaption_table form max-w-160 flex-1">
      <a-row>
        <a-col span="24">
          <th class="required">適用開始日</th>
          <td>
            <DateJp v-model:value="formData.TAX_DATE_FROM" />
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">適用終了日</th>
          <td>
            <a-form-item>
              <DateJp v-model:value="formData.TAX_DATE_TO" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">消費税率（%）</th>
          <td>
            <a-form-item>
              <a-input v-model:value="formData.TAX_RITU" :maxlength="30" />
            </a-form-item>
          </td> </a-col
      ></a-row>
    </div>
    <div class="my-2 max-w-160 flex justify-between">
      <a-button class="warning-btn" @click="save">保存</a-button>
      <a-button type="primary" @click="goList">一覧へ</a-button>
    </div>
  </a-card>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { nextTick, onMounted, reactive } from 'vue'
import { useRoute, useRouter } from 'vue-router'

const route = useRoute()
const router = useRouter()
const editJudge = new Judgement()
const formData = reactive({
  TAX_DATE_FROM: undefined,
  TAX_DATE_TO: undefined,
  TAX_RITU: undefined,
})

onMounted(() => {
  Object.assign(formData, route.query)
  nextTick(() => editJudge.reset())
})

const save = () => {}

const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name })
  })
}
</script>
<style lang="scss" scoped>
th {
  width: 160px;
}
</style>
