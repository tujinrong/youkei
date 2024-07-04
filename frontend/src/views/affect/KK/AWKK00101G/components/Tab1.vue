<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between mb-1">
      <div class="text-lg font-bold">住民情報</div>
      <a-space>
        <SimplePagination :current="current" :count="count" @change="changeCurrent" />
        <a-button type="primary" @click="visible = true">履歴照会</a-button>
      </a-space>
    </div>
    <div class="p-1">
      <div class="self_adaption_table">
        <!-- 外国人 -->
        <Column
          v-if="data?.juminsyubetu === Enum住民種別.外国人住民"
          :rows="row_joho2"
          :data="data"
          :privkey="privkey"
        />
        <!-- 日本人  -->
        <Column v-else :rows="row_joho1" :data="data" :privkey="privkey" />
      </div>
    </div>
    <ResumeModal
      v-model:visible="visible"
      title="住民情報個人履歷"
      :columns="columns_102"
      service="AWKK00102D"
      @select="selectRow"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import Column from './Column.vue'
import SimplePagination from '@/components/Common/SimplePagination/index.vue'
import ResumeModal from '@/views/components/ResumeModal/index.vue'
import { columns as columns_102 } from '@/views/affect/KK/AWKK00102D/content'
import { SearchJuminDetail } from '../service'
import { useRoute } from 'vue-router'
import { JuminVM } from '../type'
import { row_joho1, row_joho2 } from '../content'
import { Enum住民種別 } from '#/Enums'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const visible = ref(false)
const data = ref<JuminVM | null>(null)
const privkey = ref('')

const count = ref(0)
const current = ref(0)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchJuminDetail(1)
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const searchJuminDetail = async (rirekinum: number) => {
  loading.value = true
  try {
    const res = await SearchJuminDetail({
      rirekinum,
      atenano: route.query.atenano as string
    })
    if (res.rsaprivatekey) privkey.value = res.rsaprivatekey

    data.value = res.detailinfo
    count.value = res.rirekitotal
    current.value = res.rirekinum
  } catch (error) {}
  loading.value = false
}

function changeCurrent(val) {
  // const oldCur = current.value
  current.value = val
  searchJuminDetail(current.value)
}

function selectRow(row) {
  changeCurrent(row.rirekinum)
}
</script>
