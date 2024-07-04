<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: サブコード新規/編集
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.05.17
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    :title="'汎用サブコード情報' + (isnew ? '新規' : '編集')"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />

    <a-spin :spinning="loading">
      <div class="self_adaption_table" :class="{ form: isnew }">
        <a-row>
          <a-col span="24">
            <th class="required">メインコード</th>
            <td>
              <a-form-item v-bind="validateInfos.hanyomaincd">
                <ai-select
                  v-model:value="formData.hanyomaincd"
                  :options="mainOptions"
                  :disabled="!isnew"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">サブコード</th>
            <td v-if="isnew">
              <a-form-item v-bind="validateInfos.hanyosubcd">
                <a-input-number
                  v-model:value="formData.hanyosubcd"
                  :precision="0"
                  :min="1"
                  class="w-full"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.hanyosubcd }}</TD>
          </a-col>
          <a-col span="24">
            <th class="bg-editable">サブコード名称<span class="request-mark">＊</span></th>
            <td>
              <a-form-item v-bind="validateInfos.hanyosubcdnm">
                <a-input v-model:value="formData.hanyosubcdnm" maxlength="100" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th :class="formData.userryoikikaisicd && 'required'">桁数</th>
            <td v-if="isnew">
              <a-form-item v-bind="validateInfos.keta">
                <a-input-number
                  v-model:value="formData.keta"
                  :precision="0"
                  :min="1"
                  class="w-full"
                  @change="
                    (val) =>
                      val ? validate('userryoikikaisicd') : clearValidate('userryoikikaisicd')
                  "
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.keta }}</TD>
          </a-col>
          <a-col span="24">
            <th>ユーザ領域開始コード</th>
            <td v-if="isnew">
              <a-form-item v-bind="validateInfos.userryoikikaisicd">
                <a-input-number
                  v-model:value="formData.userryoikikaisicd"
                  :precision="0"
                  :min="1"
                  class="w-full"
                  @change="
                    (val) => {
                      if (!val) clearValidate('keta')
                    }
                  "
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.userryoikikaisicd }}</TD>
          </a-col>
        </a-row>
      </div>
    </a-spin>

    <template #footer>
      <a-button
        style="float: left"
        type="warn"
        :disabled="!isnew && !route.meta.updflg"
        @click="handleSave"
        >登録</a-button
      >
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, reactive, ref, watch, nextTick } from 'vue'
import { Form, message } from 'ant-design-vue'
import {
  ITEM_SELECTREQUIRE_ERROR,
  ITEM_REQUIRE_ERROR,
  SAVE_OK_INFO,
  E001010
} from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import TD from '@/components/Common/TableTD/index.vue'
import { InitSubCodeInfo, SaveSubCodeInfo } from '../service'
import { SubCodeInfoVM } from '../type'
import { Enum編集区分 } from '#/Enums'
import { useRoute } from 'vue-router'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  isnew: boolean
  mainCode: string
  subCode: string
}>()
const emit = defineEmits(['update:visible', 'emitSubcdnm'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const editJudge = new Judgement()
function createDefaultForm(): SubCodeInfoVM {
  return {
    hanyomaincd: '',
    hanyosubcd: undefined,
    hanyosubcdnm: '',
    userryoikikaisicd: undefined,
    keta: undefined
  }
}
const formData = reactive(createDefaultForm())
const mainOptions = ref<DaSelectorModel[]>([])

//項目の設定
const rules = computed(() => ({
  hanyomaincd: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'メインコード') }
  ],
  hanyosubcd: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'サブコード') }],
  hanyosubcdnm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'サブコード名称') }
  ],
  keta: [
    {
      required: props.isnew && formData.userryoikikaisicd,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '桁数')
    }
  ],
  userryoikikaisicd: [
    {
      validator: (_rule, value: string) => {
        if (
          props.isnew &&
          formData.keta &&
          formData.userryoikikaisicd &&
          String(value).length > formData.keta
        ) {
          return Promise.reject(E001010.Msg.replace('{0}', String(formData.keta)))
        }
        return Promise.resolve()
      }
    }
  ]
}))
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (visible) => {
    clearValidate()
    if (visible) {
      loading.value = true
      try {
        const res = await InitSubCodeInfo({
          hanyomaincd: props.isnew ? '' : props.mainCode,
          hanyosubcd: props.isnew ? '' : props.subCode
        })
        Object.assign(formData, res.subcdInfoVM)
        mainOptions.value = res.maincdlist
      } catch (error) {}
      loading.value = false
      nextTick(() => editJudge.reset())
    }
  }
)
//画面データ編集判断
watch(formData, () => editJudge.setEdited())
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
//メソッド
//--------------------------------------------------------------------------
//保存処理
const handleSave = async () => {
  await validate()

  showSaveModal({
    onOk: async () => {
      try {
        await SaveSubCodeInfo({
          subcdInfoVM: formData,
          editkbn: props.isnew ? Enum編集区分.新規 : Enum編集区分.変更,
          hanyomaincd: props.mainCode,
          hanyosubcd: props.subCode
        })
        if (!props.isnew) emit('emitSubcdnm', formData.hanyosubcdnm)
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
    Object.assign(formData, createDefaultForm())
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 160px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
