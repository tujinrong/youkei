<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 登録部署別更新権限
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="600px"
    title="登録部署別更新権限"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <vxe-table
      height="450"
      :column-config="{ resizable: true }"
      :row-config="{ keyField: 'sisyocd', isHover: true }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="sisyonm" title="登録部署名"></vxe-column>
      <vxe-column field="authflgupd" title="更新可">
        <template #default="{ row }">
          <vxe-radio
            v-model="row.authflgupd"
            :label="true"
            @change="() => editJudge.setEdited()"
          ></vxe-radio>
        </template>
      </vxe-column>
      <vxe-column field="authflgupd" title="参照のみ">
        <template #default="{ row }">
          <vxe-radio
            v-model="row.authflgupd"
            :label="false"
            @change="() => editJudge.setEdited()"
          ></vxe-radio>
        </template>
      </vxe-column>
    </vxe-table>
    <template #footer>
      <div style="float: left">
        <a-button type="primary" @click="onOk">登録</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import { Judgement } from '@/utils/judge-edited'

interface VM extends CmSisyoVM {
  authflgupd: boolean
}
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  selectedData: CmSisyoVM[] | null
  sisyolist: CmSisyoVM[]
}>()
const emit = defineEmits(['update:visible', 'update:selectedData'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tableData = ref<VM[]>([])
const editJudge = new Judgement()

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
  async (val) => {
    if (val) {
      tableData.value = props.sisyolist.map((item) => {
        const authflgupd = props.selectedData?.find((el) => el.sisyocd === item.sisyocd)
        return { ...item, authflgupd: Boolean(authflgupd) }
      })
      editJudge.reset()
    }
  }
)

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//登録ボタン(画面データの連動更新処理)
const onOk = () => {
  emit(
    'update:selectedData',
    tableData.value.filter((item) => item.authflgupd)
  )
  modalVisible.value = false
}
//閉じるボタン(×を含む)
function closeModal() {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}
</script>
