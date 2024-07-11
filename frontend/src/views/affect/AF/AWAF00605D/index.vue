<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 連絡先
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.05.22
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    title="連絡先"
    width="1200px"
    centered
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <a-spin :spinning="loading">
      <a-tabs :active-key="activeKey" @tab-click="clickTab">
        <a-tab-pane v-for="item in list" :key="item.tabnm" :tab="item.tabnm"> </a-tab-pane>
      </a-tabs>
      <Contact
        ref="contactRef"
        :detailinfo="current.detailinfo"
        :headerinfo="current.headerinfo"
        :item-updflg="current.updflg"
        :judge="editJudge"
      />
    </a-spin>
    <template #footer>
      <div class="flex justify-between">
        <div>
          <a-button type="warn" :disabled="!canSave" @click="submitData">登録</a-button>
          <a-button type="primary" danger :disabled="!canDelete" @click="onDelete">削除</a-button>
        </div>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { ref, nextTick, watch, computed } from 'vue'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import Contact from './components/Contact/index.vue'
import { Search, Save, Delete } from './service'
import { useRoute } from 'vue-router'
import { SearchVM } from './type'
import { message } from 'ant-design-vue'
import emitter from '@/utils/event-bus'
import { getBarKengen } from '@/utils/user'
import { Enum共通バー番号 } from '#/Enums'

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const modalVisible = ref(false)
const activeKey = ref('')
const editJudge = new Judgement()
const contactRef = ref<InstanceType<typeof Contact> | null>(null)
const loading = ref(false)
const list = ref<SearchVM[]>([])
const current = ref<any>({})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(activeKey, (val) => {
  current.value = list.value.find((item) => item.tabnm === val)
  nextTick(() => editJudge.reset())
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限取得
const kengen = computed(() => getBarKengen(Enum共通バー番号.連絡先))
const canDelete = computed(() => {
  return kengen.value.deleteflg && current.value.detailinfo?.upddttm
})
const canSave = computed(() => {
  return (
    ((kengen.value.updateflg && current.value.updflg) || kengen.value.addflg) &&
    contactRef.value?.canSave
  )
})

//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//初期化処理
function openModal() {
  modalVisible.value = true
  getData()
}
//検索処理
async function getData() {
  loading.value = true
  const res = await Search({
    atenano: route.query.atenano as string,
    patternno: route.query.patternno as string
  })
  if (list.value.length === 0) activeKey.value = res.kekkalist[0].tabnm
  list.value = res.kekkalist
  const cur = res.kekkalist.find((item) => item.tabnm === activeKey.value)
  if (cur) {
    current.value = cur
  }
  nextTick(() => editJudge.reset())
  loading.value = false
}

//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
    list.value = []
  })
}
//表示判断(本人以外、関連者の宛名番号が存在する場合のみ表示する)
function clickTab(val: string) {
  if (activeKey.value === val) return
  editJudge.judgeIsEdited(() => {
    activeKey.value = val
  })
}
//保存処理
function submitData() {
  contactRef.value?.validate().then((res) => {
    showSaveModal({
      onOk: async () => {
        await Save({ detailinfo: res })
        message.success(SAVE_OK_INFO.Msg)
        getData()
        emitter.emit('refreshBar', route.name)
      }
    })
  })
}
//削除処理
function onDelete() {
  const { jigyo, atenano, upddttm } = current.value?.detailinfo
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      await Delete({ jigyo, atenano, upddttm })
      message.success(DELETE_OK_INFO.Msg)
      getData()
    }
  })
}

defineExpose({
  open: openModal
})
</script>
<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
