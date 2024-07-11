<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業コード管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    title="事業コード管理"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
  >
    <CloseModalBtn @click="closeModal" />

    <a-spin :spinning="loading">
      <div class="self_adaption_table mb-4">
        <a-row>
          <a-col span="24">
            <th>画面</th>
            <TD>{{ nm }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="self_adaption_table" :class="{ form: canEdit }">
        <a-row>
          <a-col span="24" class="head-grey">
            <th>共通バー</th>
            <td></td>
          </a-col>
          <a-col span="24">
            <th :class="formData.flg1 && 'bg-readonly'">個人連絡先</th>
            <td v-if="canEdit && !formData.flg1">
              <ai-select v-model:value="formData.cdnm1" :options="options" />
            </td>
            <TD v-else>{{ formData.cdnm1 }}</TD>
          </a-col>
          <a-col span="24">
            <th :class="formData.flg2 && 'bg-readonly'">メモ情報</th>
            <td v-if="canEdit && !formData.flg2">
              <a-select
                v-model:value="formData.cdnmlist2"
                mode="multiple"
                class="w-full"
                :options="options"
                :filter-option="filterOption"
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
            </td>
            <TD v-else>{{ getMultipleLabel(formData.cdnmlist2, options) }}</TD>
          </a-col>
          <a-col span="24">
            <th :class="formData.flg3 && 'bg-readonly'">電子ファイル情報</th>
            <td v-if="canEdit && !formData.flg3">
              <a-select
                v-model:value="formData.cdnmlist3"
                mode="multiple"
                class="w-full"
                :options="options"
                :filter-option="filterOption"
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
            </td>
            <TD v-else>{{ getMultipleLabel(formData.cdnmlist3, options) }}</TD>
          </a-col>
          <a-col span="24">
            <th :class="formData.flg4 && 'bg-readonly'">フォロー管理</th>
            <td v-if="canEdit && !formData.flg4">
              <a-select
                v-model:value="formData.cdnmlist4"
                mode="multiple"
                class="w-full"
                :options="options"
                :filter-option="filterOption"
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
            </td>
            <TD v-else>{{ getMultipleLabel(formData.cdnmlist4, options) }}</TD>
          </a-col>
        </a-row>
      </div>
    </a-spin>

    <template #footer>
      <a-button style="float: left" type="warn" :disabled="!canEdit" @click="handleSortOk"
        >登録</a-button
      >
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, reactive, ref, watch, nextTick } from 'vue'
import { Save, Init } from './service'
import { message } from 'ant-design-vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { SaveVM } from './type'
import { useRoute } from 'vue-router'
import TD from '@/components/Common/TableTD/index.vue'
import { filterOption, getMultipleLabel } from '@/utils/util'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  code: string
}>()
const emit = defineEmits(['update:visible', 'afterSave'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref(false)
const editJudge = new Judgement()
function createDefaultForm(): SaveVM {
  return {
    cdnm1: '',
    cdnmlist2: [],
    cdnmlist3: [],
    cdnmlist4: [],
    flg1: false,
    flg2: false,
    flg3: false,
    flg4: false
  }
}
const formData = reactive<SaveVM>(createDefaultForm())
const nm = ref('')
const options = ref<DaSelectorModel[]>([])
let upddttm1
let upddttm2
let upddttm3
let upddttm4

//操作権限フラグ
const route = useRoute()
const canEdit = route.meta.updflg

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (visible) => {
    if (visible) {
      loading.value = true
      try {
        const res = await Init({ cd: props.code })
        Object.assign(formData, res.detailinfo)
        nm.value = res.nm
        options.value = res.selectorlist
        upddttm1 = res.upddttm1
        upddttm2 = res.upddttm2
        upddttm3 = res.upddttm3
        upddttm4 = res.upddttm4
      } catch (error) {}
      loading.value = false
      nextTick(() => editJudge.reset())
    }
  }
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//画面データ編集判断
watch(formData, () => editJudge.setEdited())
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//保存処理
const handleSortOk = () => {
  showSaveModal({
    onOk: async () => {
      try {
        await Save({
          cd: props.code,
          detailinfo: formData,
          upddttm1,
          upddttm2,
          upddttm3,
          upddttm4
        })
        editJudge.reset()
        closeModal()
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {}
    }
  })
}

//閉じるボタン(×を含む)
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    emit('afterSave')
    // reset
    Object.assign(formData, createDefaultForm())
    nm.value = ''
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 150px;
}
</style>
