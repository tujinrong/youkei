<template>
  <a-modal
    v-model:visible="props.visible"
    title="ファイルアップロード"
    :closable="false"
    :maskClosable="false"
    width="700px"
    destroy-on-close
    @cancel="closeModal"
  >
    <AprogerssUpd
      :pvisible="pvisible"
      :percent="percent"
      :content="content"
      :contentarray="contentarray"
    ></AprogerssUpd>
    <div style="display: flex">
      <a-form
        ref="formRef"
        :label-col="{ span: 4 }"
        :wrapper-col="{ span: 18 }"
        :model="formParam"
        style="width: 600px"
      >
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 130px; background-color: #ffffe1">一括取込入力No</th>
                <td>
                  {{ formParam.impno }}
                </td>
              </tr>
              <tr>
                <th style="width: 130px; background-color: #ffffe1">一括取込入力名</th>
                <td>
                  {{ formParam.impnm }}
                </td>
              </tr>
              <tr>
                <th style="width: 130px">ファイル</th>
                <td>
                  {{ formParam.filenm }}
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-form>
      <a-button type="primary" style="margin-top: 65px; margin-left: 10px" @click="getFile">
        <upload-outlined></upload-outlined>
        参照
      </a-button>
    </div>

    <template #footer>
      <a-button
        key="submit"
        type="primary"
        :loading="loading"
        :disabled="!formParam.filenm"
        @click="onExecute"
        style="float: left"
        class="warning-btn"
        >実行</a-button
      >
      <a-button
        key="submit"
        type="primary"
        :loading="loading"
        :disabled="!formParam.errorbytebuffer"
        style="float: left"
        @click="downloadError"
        >エラーリスト</a-button
      >
      <a-button key="back" type="primary" :loading="loading" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//チェック仕様画面
//---------------------------------------------------------------------------

import { ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VXETable } from 'vxe-table'
import { UPLOAD_CONFIRM } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { KimpRowVM } from '../AWKK00701G/type'
import { ErrorDownload, ExcelUploadCheck } from './service'
import AprogerssUpd from '@/views/affect/KK/AWKK00701G/components/Progress.vue'
import { ProgressHandle } from '../AWKK00701G/service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  param?: KimpRowVM
  impexid?: number
  impno: string
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'add', 'delete'])
//---------------------------------------------------------------------------
//データ定義(data(ref…))
//---------------------------------------------------------------------------
const route = useRoute()
const formParam = ref<{
  impno: number
  impnm: string
  gyoumukbn?: string
  memo?: string
  impkbn?: string
  filenm?: string
  file?: any
  errorbytebuffer?: string
}>({ impnm: '', impno: -1 })
const router = useRouter()
//ローディング
const loading = ref(false)
const percent = ref(0)
const content = ref('')
const pvisible = ref(false)
const contentarray = ref(['ファイルチェック', 'マッピングチェック', '画面項目チェック'])
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      formParam.value = JSON.parse(JSON.stringify(props.param))
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド(methods)
//---------------------------------------------------------------------------
//出力modal閉じる
const closeModal = () => {
  emit('update:visible', false)
}
//画面遷移
const onExecute = (val: KimpRowVM) => {
  showConfirmModal({
    content: UPLOAD_CONFIRM.Msg,
    onOk: async () => {
      loading.value = true
      formParam.value.errorbytebuffer = undefined
      pvisible.value = true
      content.value = 'ファイルチェック'
      percent.value = 0
      let datestr = Date.now().toString()
      try {
        ExcelUploadCheck({
          impexeid: props.impexid,
          impno: props.impno,
          files: formParam.value.file,
          processKey: datestr
        })
          .then((uploadres) => {
            if (uploadres.errorbytebuffer) {
              formParam.value.errorbytebuffer = uploadres.errorbytebuffer
              pvisible.value = false
            } else {
              setTimeout(() => {
                pvisible.value = false
                router.push({
                  path: route.name as string,
                  query: {
                    impno: props.impno,
                    impexeid: uploadres.impexeid,
                    status: '1',
                    mode: '2'
                  }
                })
              }, 500)
            }
          })
          .catch(() => {
            pvisible.value = false
          })
        checkProgress(datestr)
      } catch (error) {
        pvisible.value = false
      } finally {
        loading.value = false
      }
    }
  })
}

//プログレスバーをチェックします
const checkProgress = async (datestr) => {
  while (pvisible.value) {
    const res = await ProgressHandle({ processKey: datestr })
    content.value = res.processnm
    percent.value = res.value
    if (
      formParam.value.errorbytebuffer ||
      (content.value === '画面項目チェック' && percent.value === 100)
    ) {
      break
    }
    await new Promise((resolve) => setTimeout(resolve, 100))
  }
}

//ファイルの取得
const getFile = async () => {
  const { file } = await VXETable.readFile({
    types: ['csv', 'txt']
  })
  formParam.value.filenm = file.name
  formParam.value.file = [file]
}
//エラーリスト
const downloadError = () => {
  loading.value = true
  ErrorDownload({ errorbytebuffer: formParam.value.errorbytebuffer! }).finally(() => {
    loading.value = false
  })
}
</script>
