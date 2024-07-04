<!--suppress ALL -->
<template>
  <a-modal
    :visible="props.visible"
    width="1050px"
    title="公印設定"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <a-tabs
      v-model:activeKey="activeKey"
      :tab-bar-style="{ margin: 0, paddingLeft: '16px', paddingTop: '1px' }"
    >
      <a-tab-pane :key="ACTIVEKEYENUM['市区町村長名・公印設定']" tab="市区町村長名・公印設定">
      </a-tab-pane>
      <a-tab-pane :key="ACTIVEKEYENUM['職務代理者名・公印設定']" tab="職務代理者名・公印設定">
      </a-tab-pane>
      <a-tab-pane :key="ACTIVEKEYENUM.印字設定" tab="印字設定"> </a-tab-pane>
      <a-tab-pane :key="ACTIVEKEYENUM.問い合わせ先設定" tab="問い合わせ先設定"> </a-tab-pane>
    </a-tabs>

    <Koin
      v-if="activeKey === ACTIVEKEYENUM['市区町村長名・公印設定']"
      v-model:imgData="sonchokoindata"
      v-model:titleValue="soncho!.sonchomei"
      :edit-judge="editJudge"
      title="市区町村長名"
      content-title="市区町村長公印"
    />

    <Koin
      v-if="activeKey === ACTIVEKEYENUM['職務代理者名・公印設定']"
      v-model:imgData="dairishakoindata"
      v-model:titleValue="dairisha.dairimei"
      v-model:titleValue2="dairisha.dairisha"
      :edit-judge="editJudge"
      title="職務代理名"
      title2="職務代理者"
      content-title="職務代理者公印"
    />
    <Setting
      v-if="activeKey === ACTIVEKEYENUM.印字設定"
      v-model:kekkalist1="kekkalist1"
      v-model:dairiy-time="dairiyTime"
      :edit-judge="editJudge"
    />
    <Contact
      v-if="activeKey === ACTIVEKEYENUM.問い合わせ先設定"
      v-model:kekkalist2="kekkalist2"
      v-bind="{
        editJudge,
        kacdList,
        kakaricdList,
        toiawasesakicdList
      }"
    />
    <template #footer>
      <a-button style="float: left" type="warn" :disabled="loading" @click="onOk">登録</a-button>

      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watch, nextTick } from 'vue'
import { message } from 'ant-design-vue'
import Koin from './components/Koin.vue'
import Setting from './components/Setting.vue'
import Contact from './components/Contact.vue'
import { Init, Save } from './service'
import { KoinReportVM, ContactInfoReportVM, SonchoVM, DairishaVM } from './type'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { GlobalStore } from '@/store'

enum ACTIVEKEYENUM {
  '市区町村長名・公印設定' = 1,
  '職務代理者名・公印設定',
  印字設定,
  問い合わせ先設定
}

const props = defineProps<{
  visible: boolean
}>()
const editJudge = new Judgement()
const emit = defineEmits(['update:visible'])

const loading = ref(false)
const activeKey = ref(ACTIVEKEYENUM['市区町村長名・公印設定'])

const soncho = ref<SonchoVM>({
  sonchomei: ''
})
const sonchokoindata = ref<string>('')
const dairisha = ref<DairishaVM>({
  dairimei: '',
  dairisha: '',
  dairiymdf: '',
  dairiymdt: ''
})
const dairishakoindata = ref<string>('')
const dairiyTime = ref<{ start: string | Date; end: string | Date }>({ start: '', end: '' })
const kekkalist1 = ref<KoinReportVM[]>([])
const kekkalist2 = ref<ContactInfoReportVM[]>([])
const kacdList = ref<DaSelectorModel[]>([])
const kakaricdList = ref<DaSelectorModel[]>([])
const toiawasesakicdList = ref<DaSelectorModel[]>([])

// time
const intUpddttm = ref<Date | string>('')
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      init()
    }
  }
)

const init = () => {
  Init().then((res) => {
    soncho.value = res.soncho
    sonchokoindata.value = res.sonchokoindata
    dairisha.value = res.dairisha
    dairishakoindata.value = res.dairishakoindata
    dairiyTime.value.start = res.dairisha.dairiymdf ?? ''
    dairiyTime.value.end = res.dairisha.dairiymdt ?? ''
    intUpddttm.value = res.upddttm
    kekkalist1.value = res.kekkalist1
    kekkalist2.value = res.kekkalist2
    kacdList.value = res.kacdList
    kakaricdList.value = res.kakaricdList
    toiawasesakicdList.value = res.toiawasesakicdList
    nextTick(() => editJudge.reset())
  })
}

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function base64ToBlob(base64) {
  let str = base64.startsWith('data') ? base64 : `data:image/png;base64,${base64}`
  let binary = atob(str.split(',')[1])
  let array: number[] = []
  for (let i = 0; i < binary.length; i++) {
    array.push(binary.charCodeAt(i))
  }
  const imgBlob = new Blob([new Uint8Array(array)], { type: 'image/png' })
  return new File([imgBlob], `${Date.now()}.png`, { type: imgBlob.type })
}

const onOk = () => {
  showSaveModal({
    onOk: () => {
      loading.value = true
      Save({
        files: [base64ToBlob(sonchokoindata.value), base64ToBlob(dairishakoindata.value)],
        koinreportlist: kekkalist1.value,
        contactinforeportlist: kekkalist2.value,
        upddttm: intUpddttm.value,
        soncho: soncho.value,
        dairisha: {
          ...dairisha.value,
          dairiymdf: dairiyTime.value.start,
          dairiymdt: dairiyTime.value.end
        }
      })
        .then(() => {
          message.success(SAVE_OK_INFO.Msg)
          editJudge.reset()
          closeModal()
        })
        .finally(() => (loading.value = false))
    }
  })
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:visible', false)
    loading.value = false
    soncho.value.sonchomei = ''
    sonchokoindata.value = ''
    activeKey.value = ACTIVEKEYENUM['市区町村長名・公印設定']
  })
}
</script>

<style scoped lang="less"></style>
