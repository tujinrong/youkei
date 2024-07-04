<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 成人検診事業項目並び順設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="1000px"
    title="拡張事業·拡張運用管理"
    :destroy-on-close="true"
    :closable="false"
    :mask-closable="false"
  >
    <CloseModalBtn @click="closeModal" />

    <div class="self_adaption_table mb-4">
      <a-row>
        <a-col span="8">
          <th>検診種別コード</th>
          <TD>{{ props.jigyocd }}</TD>
        </a-col>
        <a-col span="10">
          <th>検診種別名</th>
          <TD>{{ header?.jigyonm }}</TD>
        </a-col>
        <a-col span="6">
          <th>略称</th>
          <TD>{{ header?.jigyoshortnm }}</TD>
        </a-col>
      </a-row>
    </div>
    <h4 class="font-bold">健（検）診項目並び順設定</h4>
    <Transfer
      :target-keys="rightKeys"
      :data-source="dataSource"
      :titles="['左側配置健（検）診項目', '右側配置健（検）診項目']"
      :locale="{
        selectAll: '全選択',
        selectInvert: '全反転',
        itemsUnit: ' ',
        itemUnit: ' '
      }"
      :style="{ width: '100%', height: '500px' }"
      @change="onChangeTransfer"
    >
      <template #children="{ direction, filteredItems, selectedKeys, onItemSelect }">
        <a-checkbox-group :value="selectedKeys" class="transfer-body">
          <a-empty v-if="!filteredItems.length" :image="Empty.PRESENTED_IMAGE_SIMPLE" />
          <draggable
            v-else
            :list="filteredItems"
            item-key="key"
            @end="
              direction === 'right'
                ? draggableEnd_Right(filteredItems)
                : draggableEnd_Left(filteredItems)
            "
          >
            <template #item="{ element }">
              <div class="transfer-body-item">
                <a-checkbox
                  :value="element.key"
                  @change="(e) => onItemSelect(e.target.value, e.target.checked)"
                  >{{ element.title }}</a-checkbox
                >
              </div>
            </template>
          </draggable>
        </a-checkbox-group>
      </template>
    </Transfer>

    <template #footer>
      <a-button style="float: left" type="warn" @click="handleSortOk">登録</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, ref, watch } from 'vue'
import draggable from 'vuedraggable'
import { Save, Search } from './service'
import { message } from 'ant-design-vue'
import { Empty, Transfer } from 'ant-design-vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { showSaveModal } from '@/utils/modal'
import TD from '@/components/Common/TableTD/index.vue'
import { KensinCommonHeaderVM } from '../AWKK00801G/type'
import { Judgement } from '@/utils/judge-edited'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  jigyocd: string
  visible: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
  (e: 'afterSave'): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
const dataSource = ref<{ key: string; title: string }[]>([])
const rightKeys = ref<string[]>([])
const loading = ref(false)
const header = ref<KensinCommonHeaderVM>()
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    dataSource.value = []
    rightKeys.value = []
    if (newValue) {
      loading.value = true
      const res = await Search({ jigyocd: props.jigyocd })
      header.value = res.headerinfo
      dataSource.value = [...res.kekkalist1, ...res.kekkalist2].map((el) => ({
        key: el.itemcd,
        title: el.itemnm
      }))
      rightKeys.value = res.kekkalist2.map((el) => el.itemcd)
      loading.value = false
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
//メソッド
//--------------------------------------------------------------------------
function onChangeTransfer(targetKeys, direction, moveKeys) {
  if (direction === 'right') {
    rightKeys.value = rightKeys.value.concat(moveKeys)
  } else {
    let remainingItems = dataSource.value.filter((item) => !moveKeys.includes(item.key))
    let movedItems = dataSource.value.filter((item) => moveKeys.includes(item.key))
    dataSource.value = remainingItems.concat(movedItems)

    rightKeys.value = rightKeys.value.filter((el) => !moveKeys.includes(el))
  }

  editJudge.setEdited()
}

function draggableEnd_Right(filteredItems) {
  rightKeys.value = filteredItems.map((el) => el.key)
  editJudge.setEdited()
}
function draggableEnd_Left(filteredItems) {
  const others = dataSource.value.filter((el) => rightKeys.value.includes(el.key))
  dataSource.value = [...filteredItems, ...others]
  editJudge.setEdited()
}

//保存処理
const handleSortOk = () => {
  showSaveModal({
    onOk: async () => {
      try {
        await Save({
          kekkalist1: dataSource.value
            .filter((el) => !rightKeys.value.includes(el.key))
            .map((el) => ({ itemcd: el.key })),
          kekkalist2: rightKeys.value.map((el) => ({ itemcd: el })),
          jigyocd: props.jigyocd
        })
        editJudge.reset()
        closeModal()
        message.success(SAVE_OK_INFO.Msg)
        emit('afterSave')
      } catch (error) {}
    }
  })
}
//取消処理
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
.transfer-body {
  width: 100%;
  height: 455px;
  overflow-y: auto;
  &-item {
    padding-left: 12px;
    width: 100%;
    min-height: 33px;
    display: flex;
    align-items: center;
    .ant-checkbox-wrapper {
      width: 100%;
    }
  }
  &-item:hover {
    background: #f5f5f5;
  }

  .ant-empty.ant-empty-normal {
    margin-top: 165px;
  }
  :deep(.ant-empty-image) {
    height: 35px;
  }
}

:deep(.ant-transfer-operation .ant-btn-primary) {
  padding: 10px;
  box-sizing: content-box;
}
</style>
