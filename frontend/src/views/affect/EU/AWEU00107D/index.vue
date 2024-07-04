<template>
  <a-modal
    :visible="props.visible"
    :title="props.syukekbn === Enum使用区分.一覧項目 ? '項目ツリー' : '集計項目ツリー'"
    style="height: 720px; width: 1000px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    @cancel="emit('update:visible', false)"
  >
    <!--    <a-spin :spinning="loading">-->
    <a-tree :tree-data="treeData" :selectable="false" style="height: 500px; overflow-y: scroll">
    </a-tree>
    <!--    </a-spin>-->
    <template #footer>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//ツリー
//---------------------------------------------------------------------------
import { TreeProps } from 'ant-design-vue'
import { ref, watch } from 'vue'
import { Enum使用区分 } from '#/Enums'
import { SearchNormalTree, SearchStatisticTree } from './service'

import { TreeDataNode } from 'ant-design-vue/lib/vc-tree-select/interface'
import { GlobalStore } from '@/store'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  groupid: string
  syukekbn: Enum使用区分 | null
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
//ローディング
// const loading = ref(false)
//ビューモデル
const treeData = ref<TreeProps['treeData']>([])
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      // loading.value = true

      const params = { datasourceid: String(props.groupid) }
      const searchTree =
        props.syukekbn === Enum使用区分.一覧項目 ? SearchNormalTree : SearchStatisticTree

      searchTree(params).then((res) => {
        if (res.itemtree) {
          treeData.value = getTreeData(res.itemtree as unknown as any[])
        }
      })
      // .finally(() => (loading.value = false))
    } else {
      treeData.value = []
    }
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//閉じるボタン(×を含む)
const closeModal = () => {
  emit('update:visible', false)
}
//ツリーデータの取得
const getTreeData = (data: any[]) => {
  let arr: TreeProps['treeData'] = []
  if (data) {
    data.forEach((d: any) => {
      let obj: TreeDataNode = {
        key: JSON.stringify(d.value),
        title: `${d.value.itemid} : ${d.value.itemhyojinm}`
      }
      if (d.children) {
        obj.children = d.children.map((c) => {
          let childrenObj: TreeDataNode = {
            key: JSON.stringify(c.value),
            title: `${c.value.itemid} : ${c.value.itemhyojinm}`
          }
          childrenObj.children = getTreeData(c.children)
          return childrenObj
        })
        arr?.push(obj)
      }
    })
  }
  return arr
}
</script>
