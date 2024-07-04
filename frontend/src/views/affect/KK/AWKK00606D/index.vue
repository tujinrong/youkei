<template>
  <a-modal
    v-model:visible="props.visible"
    title="取込設定アップロード"
    width="700px"
    destroy-on-close
    @cancel="closeModal"
  >
    <div class="self_adaption_table">
      <a-row>
        <a-col span="18">
          <th class="required">一括取込入力No</th>
          <TD>{{ props.editkbn === Enum編集区分.変更 ? formParam.impno : '' }}</TD>
        </a-col>
        <a-col span="18">
          <th class="required">一括取込入力名</th>
          <TD>{{ props.editkbn === Enum編集区分.変更 ? formParam.impnm : '' }}</TD>
        </a-col>
        <a-col span="18">
          <th class="bg-editable">ファイル</th>
          <TD>{{ formParam.filenm }}</TD>
        </a-col>
        <a-button type="primary" class="mt-1 ml-2" @click="getFile">
          <upload-outlined></upload-outlined>
          参照
        </a-button>
      </a-row>
    </div>

    <template #footer>
      <a-button type="primary" :disabled="!formParam.filenm" style="float: left" @click="upload">
        アップロード
      </a-button>
      <a-button
        key="submit"
        type="primary"
        :disabled="!formParam.error"
        style="float: left"
        @click="errorOutput"
        >エラー出力</a-button
      >
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//チェック仕様画面
//---------------------------------------------------------------------------

import { ref, watch } from 'vue'
import VXETable from '@/vxetable'
import { ExcelUpload, ErrorDownload } from '../AWKK00601G/service'
import { Enum編集区分 } from '#/Enums'
import { showConfirmModal } from '@/utils/modal'
import { C002005, C002006 } from '@/constants/msg'
import TD from '@/components/Common/TableTD/index.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  impno?: string
  impnm?: string
  editkbn: Enum編集区分
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'initData'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const formParam = ref<{
  impno?: string
  impnm?: string
  filenm?: string
  file?: any
  error: string
}>({ impnm: '', impno: '', error: '' })
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      formParam.value.impnm = props.impnm
      formParam.value.impno = props.impno
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------

//modal閉じる
const closeModal = () => {
  formParam.value.impnm = ''
  formParam.value.impno = undefined
  formParam.value.filenm = ''
  formParam.value.file = undefined
  formParam.value.error = ''
  emit('update:visible', false)
}

//アップロード処理
const upload = () => {
  showConfirmModal({
    content: C002005.Msg,
    onOk: async () => {
      await uploadHandle()
    }
  })
}
//ファイルの取得
const getFile = async () => {
  const { file } = await VXETable.readFile({
    types: ['xlsx']
  })
  formParam.value.filenm = file.name
  formParam.value.file = [file]
}
//アップロード処理
const uploadHandle = async () => {
  try {
    await ExcelUpload({
      editkbn: props.editkbn,
      impno: props.impno,
      files: formParam.value.file
    }).then((res) => {
      formParam.value.error = res.errorbytebuffer
      if (!res.errorbytebuffer) {
        emit('initData', res.uploadData, '1')
        closeModal()
      }
    })
  } catch (e) {}
}
//エラー出力処理
const errorOutput = () => {
  ErrorDownload({ errorbytebuffer: formParam.value.error })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
</style>
