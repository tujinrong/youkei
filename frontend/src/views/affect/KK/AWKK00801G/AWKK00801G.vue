<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 拡張事業・拡張運用情報保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.26
 * 作成者　　: 王
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-if="!query.type">
    <a-card>
      <h3 class="font-bold">拡張事業·拡張運用管理</h3>
      <div class="self_adaption_table form">
        <a-row gutter="24">
          <a-col :span="9">
            <th class="w-24">業務</th>
            <td>
              <ai-select
                v-model:value="form.gyomu"
                :options="options"
                @change="onChangeOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :span="15">
            <th class="w-24">種類</th>
            <td>
              <ai-select
                v-model:value="form.syurui"
                :options="keyoptions"
                split-val
                @change="onChangeKeyOpt"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="mt-4 w-full flex justify-between">
        <a-button type="primary" :disabled="!form.syurui" @click="onOk">選択</a-button>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <div class="flex comment">
        <span class="comment-title bg-readonly w-24">説明</span>
        <span class="comment-content flex-1" :style="{ height: bodyHeight - 100 + 'px' }">{{
          comment
        }}</span>
      </div>
    </a-card>
  </div>

  <!-- 成人健（検）診予約日程事業 -->
  <div v-if="query.type === '1'">
    <ListPage3 v-show="!query.jigyocd" ref="listPage3Ref" />
    <DetailPage3 v-if="query.jigyocd" @after-save="listPage3Ref?.searchData" />
  </div>
  <!-- その他予約日程事業・保健指導事業 -->
  <div v-if="query.type === '2'">
    <ListPage4 />
  </div>
  <!-- 保健指導・集団指導項目 -->
  <div v-if="query.type === '3'">
    <ListPage5 v-show="!query.itemcd" ref="listPage5Ref" />
    <DetailPage5
      v-if="query.itemcd"
      :limitflgs="listPage5Ref?.limitflgs!"
      @after-save="listPage5Ref?.searchData"
    />
  </div>
  <!-- 成人健（検）診事業 -->
  <div v-if="query.type === '4'">
    <ListPage v-show="!query.jigyocd" ref="listPageRef" />
    <DetailPage v-if="query.jigyocd && !query.isItem" @after-save="listPageRef?.afterSave" />
    <ListPage2 v-if="query.jigyocd && query.isItem" />
  </div>
</template>

<script setup lang="ts">
import { Enum名称区分 } from '#/Enums'
import { editStore1 } from '@/store'
import { useLinkOption, useTableHeight } from '@/utils/hooks'
import { computed, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import DetailPage from './components/DetailPage/index.vue'
import DetailPage3 from './components/DetailPage3.vue'
import DetailPage5 from './components/DetailPage5.vue'
import ListPage from './components/ListPage.vue'
import ListPage2 from './components/ListPage2.vue'
import ListPage3 from './components/ListPage3.vue'
import ListPage4 from './components/ListPage4.vue'
import ListPage5 from './components/ListPage5.vue'
import { InitChoice } from './service'
import { DaSelectorKeyModel2 } from './type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const query = ref<any>({})
const { editJudge } = editStore1
const listPageRef = ref<InstanceType<typeof ListPage> | null>(null)
const listPage3Ref = ref<InstanceType<typeof ListPage3> | null>(null)
const listPage5Ref = ref<InstanceType<typeof ListPage5> | null>(null)
const form = reactive({
  gyomu: null,
  syurui: null
})
const { bodyHeight } = useTableHeight()
const options1 = ref<DaSelectorModel[]>([])
const options2 = ref<DaSelectorKeyModel2[]>([])
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(options2, options1)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  query.value = route.query

  const res = await InitChoice({
    kbn1: Enum名称区分.名称,
    kbn2: Enum名称区分.名称
  })
  options1.value = res.selectorlist1
  options2.value = res.selectorlist2
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00801G') {
      query.value = route.query
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const comment = computed(() => {
  return options2.value.find((el) => el.value === form.syurui)?.comment
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const onOk = () => {
  router.push({
    name: 'AWKK00801G',
    query: { type: form.syurui }
  })
}
</script>

<style lang="less" scoped>
.comment {
  border: 1px solid #606266;
  &-title {
    padding: 8px 4px;
    border-right: 1px solid #dddddd;
  }
  &-content {
    padding: 8px;
    white-space: pre-wrap;
    word-wrap: break-word;
    overflow-y: auto;
  }
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
:deep(.ant-select-multiple) {
  width: 100%;
}
</style>
