<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 項目選択及び並び替え
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.11.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <Transfer
    v-model:target-keys="targetKeys"
    :data-source="source"
    :titles="titles"
    show-search
    :filter-option="filterOption"
    :render="(item) => item.title"
    :locale="{
      selectAll: '全選択',
      selectInvert: '全反転',
      itemsUnit: ' ',
      itemUnit: ' '
    }"
    :style="{ width: '100%', height: '500px' }"
  >
    <template #children="{ direction, filteredItems, selectedKeys, onItemSelect }">
      <a-checkbox-group v-if="direction === 'right'" :value="selectedKeys" class="transfer-right">
        <a-empty v-if="!filteredItems.length" :image="Empty.PRESENTED_IMAGE_SIMPLE" />
        <draggable v-else :list="filteredItems" item-key="key" @end="draggableEnd(filteredItems)">
          <template #item="{ element }">
            <div class="transfer-right-item">
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
</template>

<script setup lang="ts">
import { computed } from 'vue'
import draggable from 'vuedraggable'
import { Empty, Transfer } from 'ant-design-vue'
import type { TransferItem } from 'ant-design-vue/lib/transfer'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  /**オプションデータ */
  source: TransferItem[]
  /**両サイド タイトル */
  titles?: [string, string]
  /**現在の項目key */
  keys: string[]
}>()
const emit = defineEmits(['update:keys'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const targetKeys = computed({
  get() {
    return props.keys
  },
  set(value) {
    emit('update:keys', value)
  }
})

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索
function filterOption(inputValue: string, option: TransferItem) {
  return (option.title ?? '').indexOf(inputValue) > -1
}

function draggableEnd(filteredItems) {
  targetKeys.value = filteredItems.map((el) => el.key)
}
</script>

<style lang="less" scoped>
.transfer-right {
  width: 100%;
  height: 400px;
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
