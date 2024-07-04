<template>
  <a-modal
    :visible="props.visible"
    title="プロシージャ管理"
    width="1300px"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <a-card :bordered="false">
        <a-row>
          <a-col span="16">
            <div class="description-table">
              <table>
                <tbody>
                  <tr>
                    <th style="width: 110px" :style="{ backgroundColor: !isAdd ? '#ffffe1' : '' }">
                      処理種別
                    </th>
                    <td>
                      <span v-if="!isAdd">{{
                        processingtypeOptions?.find((item) => item.value === param.prockbn)?.label
                      }}</span>
                      <ai-select
                        v-else
                        v-model:value="param.prockbn"
                        :options="processingtypeOptions"
                        split-val
                        :allow-clear="false"
                      ></ai-select>
                    </td>
                  </tr>
                  <tr>
                    <th style="width: 130px" :style="{ backgroundColor: !isAdd ? '#ffffe1' : '' }">
                      プロシージャ名
                    </th>
                    <td>
                      <div style="display: flex">
                        <div v-if="isAdd">sp_</div>
                        <span v-if="!isAdd"> {{ param.procnm }}</span>
                        <div v-else>
                          <a-input
                            v-model:value="param.procnm"
                            :maxlength="+param.prockbn == Enum処理種別.更新前処理 ? 90 : 91"
                          ></a-input>
                        </div>
                        <div v-if="isAdd">{{ type }}</div>
                      </div>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </a-col>
          <div style="margin-left: 30px; margin-top: 40px">
            <a-checkbox v-model:checked="isAdd" :disabled="!props.addFlg" @change="handleChange"
              >新規</a-checkbox
            >
            <a-button
              type="primary"
              :disabled="isAdd || (!isAdd && props.addFlg && !props.updFlg && !props.delFlg)"
              style="margin-left: 30px"
              @click="openListModal"
              >選択</a-button
            >
          </div>
        </a-row>
        <div style="height: 400px; border: 1px solid; margin-top: 10px">
          <codemirror
            v-model="param.procsql"
            placeholder=""
            autofocus
            indent-with-tab
            :tab-size="2"
            :extensions="extensions"
            style="height: 100%; width: 100%"
            :disabled="(!props.addFlg && !props.updFlg) || loading"
          />
        </div>
      </a-card>
    </a-spin>
    <template #footer>
      <a-space style="float: left">
        <a-button type="primary" @click="clear"> クリア </a-button>
        <a-button
          type="primary"
          :disabled="!isButtonEnabled || isAdd || !props.updFlg"
          @click="reSearch"
        >
          再読み込み
        </a-button>
        <a-button
          type="warn"
          :disabled="(!props.addFlg && !props.updFlg) || loading"
          @click="saveHandle"
        >
          登録
        </a-button>
        <a-button
          type="primary"
          danger
          :disabled="isAdd || !props.delFlg || !isButtonEnabled"
          @click="deleteProc"
          >削除</a-button
        >
      </a-space>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
    <ProcedureListModal
      v-model:visible="listVisible"
      :prockbn="param.prockbn"
      @get-data="getData"
    />
  </a-modal>
</template>

<script setup lang="ts">
import { nextTick, ref, watch } from 'vue'
import { Codemirror } from 'vue-codemirror'
import { sql, PostgreSQL } from '@codemirror/lang-sql'
import { ProcedureVM } from './type'
import { InitDetail, ReSearch, Save, Delete } from './service'
import { Enum編集区分, Enum処理種別 } from '#/Enums'
import { showConfirmModal, showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import {
  MOVE_CONFIRM,
  SAVE_OK_INFO,
  DELETE_OK_INFO,
  CLEAR_CONFIRM,
  ITEM_REQUIRE_ERROR
} from '@/constants/msg'
import ProcedureListModal from '../AWKK00608D/index.vue'
import { message } from 'ant-design-vue'
import { Judgement } from '@/utils/judge-edited'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  delFlg: boolean
  addFlg: boolean
  updFlg: boolean
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'getData', 'update:isChange', 'updateOptions'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref(false)
const editJudge = new Judgement()
const listVisible = ref(false)
const isButtonEnabled = ref(false)
//ビューモデル
const param = ref<ProcedureVM>({
  procseq: undefined,
  procnm: '',
  prockbn: '',
  procsql: ''
})
const isAdd = ref(true)
const processingtypeOptions = ref<DaSelectorKeyModel[]>([])
const extensions = ref<any[]>([
  sql({
    dialect: PostgreSQL,
    schema: {
      apom: ['user', 'app_user', 'app_user_user']
    }
  })
])
const type = ref('_check')

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//テーブル

watch(
  () => props.visible,
  (val) => {
    if (val) getInitData()
  }
)
watch(
  () => param.value.prockbn,
  (newValue) => {
    type.value = '_' + processingtypeOptions.value?.find((p) => p.value === newValue)?.key
    const length = +newValue == Enum処理種別.更新前処理 ? 90 : 91
    if (param.value.procnm && param.value.procnm.length > length) {
      param.value.procnm = param.value.procnm.slice(0, length)
    }
  }
)
watch(
  () => [param.value.procsql, param.value.procnm],
  () => editJudge.setEdited()
)

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  loading.value = true
  isAdd.value = props.addFlg ? true : false
  isButtonEnabled.value = false
  InitDetail({})
    .then((res) => {
      processingtypeOptions.value = res.processingtypeList
      param.value = res.procedureVM
    })
    .finally(() => {
      loading.value = false
      nextTick(() => editJudge.reset())
    })
}

//登録処理
const saveHandle = () => {
  if (param.value.procnm && param.value.procsql) {
    showSaveModal({
      onOk: async () => {
        await save()
      }
    })
  } else {
    showInfoModal({
      content: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'プロシージャ名と内容')
    })
  }
}
//登録処理
const save = async () => {
  let nm
  if (isAdd.value) {
    nm = 'sp_' + param.value.procnm + type.value
  } else {
    nm = param.value.procnm
  }
  try {
    await Save({
      procedureVM: { ...param.value, procnm: nm },
      editkbn: isAdd.value ? Enum編集区分.新規 : Enum編集区分.変更
    })
    message.success(SAVE_OK_INFO.Msg)
    cleadHandle()
    emit('update:visible', false)
    emit('updateOptions')
  } catch (error) {}
}
//再読み込み処理
const reSearch = () => {
  loading.value = true
  isButtonEnabled.value = true
  ReSearch({ procseq: param.value.procseq })
    .then((res) => {
      param.value = res.procedureVM
    })
    .finally(() => {
      loading.value = false
    })
}
//削除処理
const deleteProc = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({ procseq: param.value.procseq }).then((res) => {
          message.success(DELETE_OK_INFO.Msg)
          cleadHandle()
          emit('update:visible', false)
          emit('updateOptions')
        })
      } catch (error) {}
    }
  })
}

//クリア処理
const clear = () => {
  //確認ダイアログ表示
  showConfirmModal({
    content: CLEAR_CONFIRM.Msg,
    onOk: () => {
      cleadHandle()
    }
  })
}
//クリア処理
const cleadHandle = () => {
  param.value.procnm = ''
  param.value.procseq = undefined
  param.value.procsql = ''
}
//modal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    cleadHandle()
    emit('update:visible', false)
  })
}

////modal開く
const openListModal = () => {
  listVisible.value = true
}

//データ処理
const getData = (data) => {
  param.value.procseq = data.value
  reSearch()
}

//編集モードで新規をチェックする
const handleChange = () => {
  if (isButtonEnabled.value) {
    loading.value = true
    showConfirmModal({
      content: MOVE_CONFIRM.Msg,
      onOk: async () => {
        getInitData()
      },
      onCancel: () => {
        isAdd.value = false
        loading.value = false
      }
    })
  }

  if (!isAdd.value && !isButtonEnabled.value) {
    param.value.procnm = ''
  }
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}
:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
.text-hidden {
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}
</style>
