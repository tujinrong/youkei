<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: お気に入り
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="favoriteVisible"
    width="900px"
    title="お気に入り設定"
    :confirm-loading="confirmLoading"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <a-spin :spinning="loading">
      <a-transfer
        :target-keys="targetKeys"
        :style="{ width: '100%', height: '500px' }"
        :data-source="drawerData.mockData"
        :titles="['メニュー項目', 'お気に入り項目']"
        :filter-option="filterOption"
        show-search
        :render="(item) => item.title"
        :show-select-all="true"
        :locale="{
          selectAll: '全選択',
          selectInvert: '全反転',
          itemsUnit: ' ',
          itemUnit: ' '
        }"
        @change="handleFavoriteChange"
        @search="searchPage"
      >
        <template #children="{ direction, filteredItems, onItemSelect, selectedKeys }">
          <div class="transfer">
            <a-checkbox-group
              v-if="direction === 'right'"
              :value="selectedKeys"
              class="transfer-right"
            >
              <draggable
                :list="filteredItems"
                item-key="key"
                @end="(e) => draggableEnd(e, filteredItems)"
              >
                <template #item="{ element }">
                  <div class="transfer-right-item">
                    <a-checkbox
                      :value="element.key"
                      @change="(e) => onItemSelect(e.target.value, e.target.checked)"
                    >
                      <span
                        v-if="
                          searchFavorValueRight !== '' &&
                          element.title.indexOf(searchFavorValueRight) > -1
                        "
                      >
                        <div
                          v-html="
                            element.title.replaceAll(
                              searchFavorValueRight,
                              `<span style='color:red;padding:0 3px'>${searchFavorValueRight}</span>`
                            )
                          "
                        ></div>
                      </span>
                      <span v-else>{{ element.title }}</span>
                    </a-checkbox>
                  </div>
                </template>
              </draggable>
            </a-checkbox-group>
            <a-tree
              v-if="direction === TargetType.Left"
              :key="refreshTreeOver"
              block-node
              checkable
              default-expand-all
              :auto-expand-parent="true"
              :expanded-keys="expandedKeys"
              :tree-data="treeData"
              :checked-keys="[...selectedKeys, ...targetKeys]"
              @expand="onExpand"
              @check="
                (_, props) => {
                  onChecked(
                    props,
                    [...drawerData.transfer.selectedKeys, ...targetKeys],
                    onItemSelect
                  )
                }
              "
              @select="
                (_, props) => {
                  onChecked(
                    props,
                    [...drawerData.transfer.selectedKeys, ...targetKeys],
                    onItemSelect
                  )
                }
              "
            >
              <template #title="{ title }">
                <span
                  v-if="searchFavorValueLeft !== '' && title.indexOf(searchFavorValueLeft) > -1"
                >
                  <div
                    v-html="
                      title.replaceAll(
                        searchFavorValueLeft,
                        `<span style='color:red;padding:0 3px'>${searchFavorValueLeft}</span>`
                      )
                    "
                  ></div>
                </span>
                <span v-else>{{ title }}</span>
              </template>
            </a-tree>
          </div>
        </template>
      </a-transfer>
    </a-spin>
    <template #footer>
      <div style="float: left">
        <a-button class="warning-btn" @click="saveData">登録</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { ref, watch, reactive, computed } from 'vue'
import { TransferProps, TreeProps, message } from 'ant-design-vue'
import { useLoading } from '@/utils/hooks'
import generateAsyncRoutes, { listToTree } from '@/router/generate-async-routes'
import { Search, Save } from './service'
import { showConfirmModal, showSaveModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { MENU_NAV } from '@/constants/mutation-types'
import { CLOSE_CONFIRM, SAVE_OK_INFO } from '@/constants/msg'
import { TargetType } from '#/Enums'
import draggable from 'vuedraggable'
import { Judgement } from '@/utils/judge-edited'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
}>()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const favoriteVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
//ローディング
const { loading, startLoading, endLoading } = useLoading(false)
const {
  loading: confirmLoading,
  startLoading: startConfirmLoading,
  endLoading: endConfirmLoading
} = useLoading(false)
//ビューモデル
const drawerData = reactive(createDefaultDrawerData())
const treeData = ref()
const refreshTreeOver = ref(1)
const searchFavorValueLeft = ref('')
const searchFavorValueRight = ref('')
const expandedKeys = ref<(string | number)[]>([])
const targetKeys = ref<string[]>([])
let menuList: TransferProps['dataSource'] = []
const editJudge = new Judgement()

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      Object.assign(drawerData, createDefaultDrawerData())
      getMenuList()
    }
  }
)
watch(
  () => targetKeys.value.length,
  (val) => {
    treeData.value = handleTreeData(menuList, targetKeys.value)
    refreshTreeOver.value = new Date().getTime()
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化
const getMenuList = async () => {
  startLoading()
  const menu_nav = ss.get(MENU_NAV) as MenuModel[]
  const menu = menu_nav
    .filter((el) => !(!el.enabled && !el.isfolder))
    .map((el) => {
      return {
        key: el.menuid,
        title: el.menuname,
        parentId: el.parentid || 0,
        id: el.menuid,
        isfolder: el.isfolder,
        enabled: el.enabled,
        disabled: !el.children && el.isfolder //フォルダー内画面なしの場合、使用不可
      }
    })
  const childrenNav = []
  listToTree(menu, childrenNav, menu[0].parentId || 0)
  menuList = childrenNav
  const result = await Search()
  targetKeys.value = result.kekkalist
  flatten(JSON.parse(JSON.stringify(menuList)))
  treeData.value = handleTreeData(menuList, targetKeys.value)
  endLoading()
}
//保存処理
const saveData = () => {
  showSaveModal({
    onOk: async () => {
      startConfirmLoading()
      const { kekkalist } = await Save({ kinoids: targetKeys.value })
      await generateAsyncRoutes(kekkalist)
      editJudge.reset()
      endConfirmLoading()
      closeModal()
      message.success(SAVE_OK_INFO.Msg)
    }
  })
}

//画面データモデル初期化
function createDefaultDrawerData() {
  return {
    mockData: [],
    transfer: {
      selectedKeys: []
    },
    oldItemIndex: 0,
    newItemIndex: 0
  }
}
//項目選択変換処理:追加(>)削除(<)
const handleFavoriteChange = (nextTargetKeys, direction, moveKeys) => {
  moveKeys.forEach((item) => {
    drawerData.mockData.forEach((items, index) => {
      if (item === items.key) drawerData.mockData[index].checked = false
    })
  })

  if (direction === 'right') {
    targetKeys.value.push(...moveKeys)
  } else {
    targetKeys.value = nextTargetKeys
  }

  editJudge.setEdited()
}

//ソート順変換処理:ドラッグ&ドロップ
function draggableEnd(e, filteredItems) {
  targetKeys.value = filteredItems.map((el) => el.key)
  editJudge.setEdited()
}

//お気に入り項目リストモデルへ変換
function flatten(list: TransferProps['dataSource'] = []) {
  list.forEach((item) => {
    if (item.children && item.children.length > 0) {
      flatten(item.children)
    } else {
      drawerData.mockData.push(item)
    }
  })
}

//メニュー項目を選択
const onChecked = (
  e: Parameters<TreeProps['onCheck']>[1] | Parameters<TreeProps['onSelect']>[1],
  checkedKeys: string[],
  onItemSelect: (n: any, c: boolean) => void
) => {
  const { checked, selected } = e
  const { eventKey, children } = e.node
  if (children && children.length > 0) {
    const func = (val) => {
      onItemSelect(val.key, isChecked(checkedKeys, [val.key], checked || selected))
    }
    let tempKeys: string[] = flattenKeys(children, func)
    console.log('tempKeys: ', tempKeys)
  } else {
    onItemSelect(eventKey, isChecked(checkedKeys, [eventKey as string], checked || selected))
  }
}
//選択チェック
function isChecked(
  selectedKeys: (string | number)[],
  eventKey: (string | number)[],
  checked: boolean
) {
  if (!checked) return false
  //もし移動されているキーの中にイベントキーが含まれていたらfalseを返す
  if (selectedKeys.some((item) => eventKey.includes(item))) return false
  return true
}
//メニュー項目ツリーモデルへ変換
function flattenKeys(children, func) {
  let tempKeys: string[] = []
  children.forEach((el) => {
    if (el.children) {
      tempKeys = tempKeys.concat(flattenKeys(el.children, func))
    } else {
      if (el.isfolder) return
      tempKeys.push(el.key)
      func(el)
    }
  })
  return tempKeys
}

//メニュー項目属性の変更
function handleTreeData(data: TransferProps['dataSource'], targetKeys: string[] = []) {
  data.forEach((item) => {
    if (targetKeys.indexOf(item.key) !== -1) {
      item.disabled = true
      item.checkable = false
      item.disableCheckbox = true
    } else {
      item.disabled = false
      item.checkable = true
      item.disableCheckbox = false
    }
    if (item.children) {
      handleTreeData(item.children, targetKeys)
      const allChildrenDisabled = item.children.every((child) => child.disabled)
      item.disabled = allChildrenDisabled
      item.checkable = !allChildrenDisabled
      item.disableCheckbox = allChildrenDisabled
    }
    if (!item.children && item.isfolder) {
      item.disabled = true
      item.checkable = false
      item.disableCheckbox = true
    }
  })
  return data as TreeProps['treeData']
}
//画面検索
const searchPage = (dir: TargetType.Left | TargetType.Right, value: string) => {
  if (dir === TargetType.Left) {
    searchFavorValueLeft.value = value
    const expanded = drawerData.mockData
      .map((item: TreeProps['treeData'][number]) => {
        if (item.title.indexOf(value) > -1) {
          return getParentKey(item.key, treeData.value)
        }
        return null
      })
      .filter((item, i, self) => item && self.indexOf(item) === i)
    expandedKeys.value = expanded
  } else {
    searchFavorValueRight.value = value
  }
}
const filterOption = (inputValue: string, option) => {
  return option.title.indexOf(inputValue) > -1
}
//親フォルダー取得
const getParentKey = (
  key: string | number,
  tree: TreeProps['treeData']
): string | number | undefined => {
  let parentKey
  if (!tree) return
  for (let i = 0; i < tree.length; i++) {
    const node = tree[i]
    if (node.children) {
      if (node.children.some((item) => item.key === key)) {
        parentKey = node.key
      } else if (getParentKey(key, node.children)) {
        parentKey = getParentKey(key, node.children)
      }
    }
  }
  return parentKey
}
//フォルダー展開
const onExpand = (Keys: string[], info) => {
  if (!info.expanded) {
    let _keys = Keys.filter((el) => el.indexOf(info.node.key) < 0)
    expandedKeys.value = _keys
  } else {
    expandedKeys.value = Keys
  }
}
//閉じるボタン(×を含む)
const closeModal = () => {
  if (editJudge.isPageEdited()) {
    showConfirmModal({
      content: CLOSE_CONFIRM,
      onOk() {
        editJudge.reset()
        favoriteVisible.value = false
      }
    })
  } else {
    favoriteVisible.value = false
  }
}
</script>

<style src="./index.less" scoped></style>
