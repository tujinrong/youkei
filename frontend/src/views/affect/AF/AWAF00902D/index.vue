<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 登録部署設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="80vw"
    title="登録部署設定"
    centered
    destroy-on-close
    :closable="false"
    :mask-closable="false"
  >
    <CloseModalBtn @click="closeModal" />
    <div class="self_adaption_table m-b-1">
      <a-row>
        <a-col :sm="24" :md="12" :xl="8" :xxl="6">
          <th class="w-26">メインコード</th>
          <TD>{{ mainCode }}</TD>
        </a-col>
        <a-col :sm="24" :md="12" :xl="8" :xxl="6">
          <th class="w-26">サブコード</th>
          <TD>{{ subCode }}</TD>
        </a-col>
        <a-col :sm="24" :md="24" :xl="8" :xxl="12">
          <th class="w-26">説明</th>
          <TD>{{ biko }}</TD>
        </a-col>
      </a-row>
    </div>
    <Table
      ref="tableRef"
      :main-code="mainCode"
      :sub-code="subCode"
      :tabledata="tableList"
      :editflgs="subEditFlgs"
      :keta="keta"
      @after-save="() => (modalVisible = false)"
    ></Table>
    <template #footer>
      <div class="float-left">
        <a-button class="warning-btn" @click="saveData">登録</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import Table from '@/views/affect/AF/AWAF00801G/components/Table.vue'
import { CLOSE_CONFIRM } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { Search } from './service'
import { Enum名称区分 } from '#/Enums'
import { HanyoVM, LockVM } from '../AWAF00801G/type'
import TD from '@/components/Common/TableTD/index.vue'

interface TableItem extends HanyoVM {
  oldFlg?: boolean
}
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tableRef = ref<InstanceType<typeof Table> | null>(null)
const biko = ref('')
const tableList = ref<TableItem[]>([])
const mainCode = ref('')
const subCode = ref('')
const keta = ref<number | null>(null)
let locklist: LockVM[] = []
//サブコード操作権限フラグ
const subEditFlgs = ref({
  updflg: true,
  addflg: true,
  delflg: true
})
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
watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      tableRef.value?.clear()
      const res = await Search({ kbn1: Enum名称区分.名称, kbn2: Enum名称区分.名称 })
      tableList.value = res.kekkalist.map((el) => ({ ...el, oldFlg: true }))
      biko.value = res.biko
      mainCode.value = res.hanyomaincd
      subCode.value = res.hanyosubcd
      keta.value = res.keta
      subEditFlgs.value = {
        updflg: res.uflg,
        addflg: res.iflg,
        delflg: res.dflg
      }
      locklist = res.locklist
    } else {
      tableList.value = []
    }
  }
)

//---------------------------------------------------------------------------
//メソッド
//------------------------------------------------------------------------
//保存処理
function saveData() {
  tableRef.value?.saveData(locklist)
}
//閉じるボタン(×を含む)
function closeModal() {
  if (tableRef.value?.editJudge.isPageEdited()) {
    showConfirmModal({
      content: CLOSE_CONFIRM.Msg,
      onOk: async () => {
        modalVisible.value = false
      }
    })
  } else {
    modalVisible.value = false
  }
}
</script>

<style scoped></style>
