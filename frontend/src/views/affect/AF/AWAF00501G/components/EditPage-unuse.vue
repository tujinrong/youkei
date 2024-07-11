<template>
  <a-card ref="headRef" :bordered="false" class="mb-2" :style="{ height: tableHeight + 50 + `px` }">
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button type="primary">プレビュー</a-button>
        <a-button type="primary" @click="cancel">キャンセル</a-button>
        <a-button type="primary" @click="goList">一覧へ</a-button>
      </a-space>
    </div>
    <div>
      <a-row :gutter="8">
        <a-col :span="12">
          <div class="m-t-1 self_adaption_table form">
            <a-row>
              <a-col v-bind="layout">
                <th class="required">対象期</th>
                <td>
                  第
                  <a-input
                    v-model:value="formData.a"
                    maxlength="3"
                    type="number"
                    style="width: 120px"
                  ></a-input
                  >期
                </td>
              </a-col>
            </a-row>
            <a-row>
              <a-col v-bind="layout">
                <th class="required">対象期(現在)</th>
                <td>
                  <a-date-picker v-model:value="formData.b" style="width: 200" />
                </td>
              </a-col>
            </a-row>
            <a-row>
              <a-col v-bind="layout">
                <th>契約区分</th>
                <td class="flex">
                  <ai-select v-model:value="formData.c" :options="selectorlist"></ai-select
                  >～<ai-select v-model:value="formData.d" :options="selectorlist"></ai-select>
                </td>
              </a-col>
            </a-row>
            <a-row>
              <a-col v-bind="layout">
                <th class="required">契約状態</th>
                <td>
                  <a-space class="flex-wrap">
                    <a-checkbox v-model:checked="formData.sinkiflg">新規契約者</a-checkbox>
                    <a-checkbox v-model:checked="formData.keizokuflg">継続契約者</a-checkbox>
                    <a-checkbox v-model:checked="formData.tyusiflg">中止者</a-checkbox>
                    <a-checkbox v-model:checked="formData.haigyoflg">廃業者</a-checkbox>
                  </a-space>
                </td>
              </a-col>
            </a-row>
            <a-row>
              <a-col v-bind="layout">
                <th>事業委託先</th>
                <td class="flex">
                  <ai-select v-model:value="formData.c" :options="selectorlist"></ai-select
                  >～<ai-select v-model:value="formData.d" :options="selectorlist"></ai-select>
                </td>
              </a-col>
            </a-row>
            <a-row>
              <a-col v-bind="layout">
                <th>契約者番号</th>
                <td class="flex">
                  <a-input v-model:value="formData.c" :options="selectorlist" :xxl="9"></a-input>
                  ～
                  <a-input v-model:value="formData.d" :xxl="9"></a-input>
                </td>
              </a-col>
            </a-row></div
        ></a-col>
      </a-row>
    </div>
  </a-card>
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Judgement } from '@/utils/judge-edited'
import { useTableHeight } from '@/utils/hooks'
import { DELETE_OK_INFO } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
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
const editJudge = new Judgement(route.name as string)
const isNew = props.status === PageSatatus.New
const { tableHeight } = useTableHeight()
const createDefaultParams = () => {
  return {
    a: '',
    b: '',
    c: '',
    d: '',
    e: '',
    f: '',
    sinkiflg: false,
    keizokuflg: false,
    tyusiflg: false,
    haigyoflg: false
  }
}
const formData = reactive(createDefaultParams())
const selectorlist = [
  { value: '1', label: '永さん' },
  { value: '2', label: '尾三' },
  { value: '3', label: '史さん' }
]
const layout = {
  md: 24,
  lg: 24,
  xxl: 18
}
const headRef = ref(null)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

onMounted(async () => {
  editJudge.addEvent()
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//画面遷移
const goList = () => {
  showConfirmModal({
    content: '終了します、よろしいですか？',
    onOk: router.push({ name: route.name as string })
  })
}

const cancel = () => {
  Object.assign(formData, createDefaultParams())
}
</script>

<style scoped lang="less">
th {
  width: 130px;
}
</style>
