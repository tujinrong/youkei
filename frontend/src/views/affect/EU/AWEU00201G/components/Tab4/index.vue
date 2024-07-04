<template>
  <!--  <a-spin :spinning="loading" class="loading">-->
  <div class="flex panel-edit">
    <div class="leftbox">
      <a-tabs v-model:activeKey="activeKey" size="small" :tab-bar-style="{ height: '28px' }">
        <a-tab-pane :key="ACTIVEKEY_ENUMS.検索条件" tab="検索条件">
          <drag-list :list="leftConditionList" :on-end="onEnd"></drag-list>
        </a-tab-pane>
        <a-tab-pane :key="ACTIVEKEY_ENUMS.特別条件" tab="検索条件以外">
          <drag-list
            :list="specialConditions"
            :atenaflg="atenaflg"
            :on-end="onSpecialEnd"
          ></drag-list>
        </a-tab-pane>
      </a-tabs>
    </div>
    <div class="flex-1 m-l-1 flex-col">
      <div class="condition-header">
        <span class="font-bold mb-0 pt-4">検索条件</span>
        <div>
          <a-button class="btn-round ml-2" type="primary" @click="addJyoken(1)">条件追加</a-button>
          <a-button
            class="btn-round ml-2"
            type="primary"
            @click="
              () => {
                sortVisible = true
                kensakukbn = 1
              }
            "
            >並び替え</a-button
          >
        </div>
      </div>

      <div
        id="right-move"
        :style="{ height: 'calc((100% - 86px) / 2)', border: '1px solid #606266' }"
        class="w-full overflow-y-auto"
      >
        <div class="self_adaption_table form mt-[-1px]">
          <a-row>
            <a-dropdown
              v-for="(item, index) in topItemlist"
              :key="item?.jyokenid"
              :trigger="['contextmenu']"
            >
              <a-col :md="24" :lg="12" :xxl="8">
                <a-tooltip :align="{ offset: [0, 5] }">
                  <template #title>
                    <th>
                      {{ item.jyokenlabel }}
                      <span v-if="item.hissuflg" class="request-mark">＊</span>
                    </th>
                  </template>

                  <th
                    style="min-width: 100px; max-width: 200px; word-break: break-all"
                    :class="[
                      item.jyokenkbn == String(Enum検索条件区分.固定条件)
                        ? 'bg-readonly'
                        : 'bg-editable',
                      item.canEddit ? 'rect' : '',
                      item.jyokenid === Number(EUCStore['yosikihimonm']) ? 'rect2' : '',
                      'conditions-item'
                    ]"
                  >
                    <span>
                      {{ item.jyokenlabel }}
                    </span>

                    <span v-if="item.hissuflg" class="request-mark">＊</span>
                    <span v-else style="width: 14px; height: 32px"></span>
                  </th>
                </a-tooltip>

                <td>
                  <span v-if="item.jyokenkbn == String(Enum検索条件区分.固定条件)">{{
                    item.value
                  }}</span>
                  <Selector
                    v-else
                    v-model:value="item.value"
                    :type="item.controlkbn"
                    :max="item.nendomax"
                    :options="item.selectlist"
                  />
                </td>
              </a-col>
              <template #overlay>
                <a-menu @click="({ key }) => menuClick(key, item, index)">
                  <a-menu-item
                    v-if="item.jyokenid !== Number(EUCStore['yosikihimonm'])"
                    key="require"
                  >
                    {{ item.hissuflg ? '任意' : '必須' }}
                  </a-menu-item>
                  <a-menu-item key="delItem"> 削除 </a-menu-item>
                  <a-menu-item
                    v-if="item.canEddit"
                    @click="
                      () => {
                        edit(item, index)
                        kensakukbn = 1
                      }
                    "
                  >
                    編集
                  </a-menu-item>
                </a-menu>
              </template>
            </a-dropdown>
          </a-row>
        </div>
      </div>
      <div class="condition-header mt-3">
        <span class="font-bold mb-0 pt-4">検索条件以外項目</span>
        <div>
          <a-button class="btn-round ml-2" type="primary" @click="addJyoken(2)">条件追加</a-button>
          <a-button
            class="btn-round ml-2"
            type="primary"
            @click="
              () => {
                otherVisible = true
                kensakukbn = 2
              }
            "
            >並び替え</a-button
          >
        </div>
      </div>

      <div
        id="special-right-move"
        :style="{ height: 'calc((100% - 86px) / 2)', border: '1px solid #606266' }"
        class="w-full overflow-y-auto"
      >
        <div class="self_adaption_table form mt-[-1px]">
          <a-row>
            <a-dropdown
              v-for="(item, index) in bottomItemList"
              :key="item.jyokenid"
              :trigger="['contextmenu']"
            >
              <a-col :md="24" :lg="12" :xxl="8">
                <a-tooltip :align="{ offset: [0, 5] }">
                  <template #title>
                    <th>
                      {{ item.jyokenlabel }}
                      <span v-if="item.hissuflg" class="request-mark">＊</span>
                    </th>
                  </template>

                  <th
                    style="min-width: 100px; max-width: 200px; word-break: break-all"
                    :class="[
                      item.jyokenkbn == String(Enum検索条件区分.固定条件)
                        ? 'bg-readonly'
                        : 'bg-editable',
                      item.canEddit ? 'rect' : '',
                      'conditions-item'
                    ]"
                  >
                    <span>
                      {{ item.jyokenlabel }}
                    </span>
                    <span v-if="item.hissuflg" class="request-mark">＊</span>
                    <span v-else style="width: 14px; height: 32px"></span>
                  </th>
                </a-tooltip>

                <td>
                  <span v-if="item.jyokenkbn == String(Enum検索条件区分.固定条件)">{{
                    item.value
                  }}</span>
                  <Selector
                    v-else
                    v-model:value="item.value"
                    :type="item.controlkbn"
                    :options="item.selectlist"
                  />
                </td>
              </a-col>
              <template #overlay>
                <a-menu @click="({ key }) => specialMenuClick(key, index)">
                  <a-menu-item key="require">
                    {{ item.hissuflg ? '任意' : '必須' }}
                  </a-menu-item>
                  <a-menu-item key="delItem"> 削除 </a-menu-item>
                  <a-menu-item
                    v-if="item.canEddit"
                    @click="
                      () => {
                        edit(item, index)
                        kensakukbn = 2
                      }
                    "
                  >
                    編集
                  </a-menu-item>
                </a-menu>
              </template>
            </a-dropdown>
          </a-row>
        </div>
      </div>
    </div>

    <SortConditionModal
      v-model:visible="sortVisible"
      v-model:data="topItemlist"
      :kensakukbn="kensakukbn"
    />
    <SortConditionModal
      v-model:visible="otherVisible"
      v-model:data="bottomItemList"
      :kensakukbn="kensakukbn"
    />
    <!--          v-model:loading="editLoading"-->
    <SearchModal
      ref="searchModalRef"
      v-model:visible="editVisible"
      :groupid="datasourceid"
      :rptid="props.rptid"
      :is-sql="isSql"
      :is-edit="isEdit"
      :item-label="itemLabel"
      :kensakukbn="kensakukbn"
      :sql-add-jyoken="sqlAddJyoken"
      @emit-item="setItem"
    />
  </div>
  <!--  </a-spin>-->
</template>

<script setup lang="ts">
import { ref, computed, watch, onMounted, nextTick, watchEffect, Ref } from 'vue'
import { EUCStore } from '@/store'
import { Enum様式作成方法, Enumコントロール, Enum検索条件区分, Enum編集区分 } from '#/Enums'
import { Judgement } from '@/utils/judge-edited'
import emitter from '@/utils/event-bus'
import { SearchConditionVM } from '../../type'
import {
  SearchConditionTab,
  SearchConditionDetail,
  SearchJokenDetail,
  InitSpecialConditions
} from '../../service'
import { specialItems } from './constants'
import { Init } from '@/views/affect/EU/AWEU00105D/service'
import DragList from './components/DragList.vue'
import Selector from './components/Selector.vue'
import SortConditionModal from './components/SortCondition.vue'
import SearchModal from '@/views/affect/EU/AWEU00105D/index.vue'

import { MasterVM } from '../../../AWEU00105D/type'
import { useRoute } from 'vue-router'
import { ss } from '@/utils/storage'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
const props = defineProps<{
  rptid: string // 帳票ID
  yosikiid: string // 様式ID
  yosikieda: number // 様式枝番,
  yosikihouhou: Enum様式作成方法 //作成方法
  datasourceid: string
  datasourcenm: string
  procnm: string
  editJudge: Judgement
  selectorlist4: DaSelectorModel[]
  rptdatasourceid: string
  kbn: string
  sql: string
  tab1Ref: Ref
}>()

enum ACTIVEKEY_ENUMS {
  検索条件 = 1,
  特別条件
}
const masterlist = ref<MasterVM[]>([])
//ビューモデル
// const loading = ref(false)
const sortVisible = ref<boolean>(false)
const otherVisible = ref<boolean>(false)
const activeKey = ref(ACTIVEKEY_ENUMS.検索条件)
const leftConditionList = ref<SearchConditionVM[]>([]) //左検索条件リスト
const specialConditions = ref<SearchConditionVM[]>([...specialItems]) //検索条件以外リスト
const topItemlist = ref<(SearchConditionVM & { jyokenseq?: number; canEddit?: boolean })[]>([]) //検索条件リスト
const bottomItemList = ref<(SearchConditionVM & { jyokenseq?: number; canEddit?: boolean })[]>([]) // 検索条件以外項目リスト
const oldList = ref<SearchConditionVM[]>([])
const itemLabel = ref<any[]>([])
const route = useRoute()
const editVisible = ref(false)
// const editLoading = ref(false)
const isEdit = ref<boolean>(false)
const kensakukbn = ref<number>(0)
const itemList = ref<SearchConditionVM[]>([])
const searchModalRef = ref<InstanceType<typeof SearchModal> | null>(null)
const isSql = computed(() =>
  [Enum様式作成方法.SQL, Enum様式作成方法.プロシージャ].includes(Number(props.yosikihouhou))
)
const atenaflg = computed(() => {
  return props.tab1Ref.value.getFieldsValue().atenaflg
})
//procedure条件追加区分
enum Enum追加条件区分 {
  固定条件 = 1,
  追加条件
}
const sqlAddJyoken = ref(Enum追加条件区分.固定条件)
//編集完了ボタンをクリック
onMounted(() => {
  Init({ datasourceid: String(props.datasourceid) }).then((res) => {
    masterlist.value = res.masterlist ?? []
  })
  emitter.once('conditionlist', (data) => {
    leftConditionList.value = data.filter((item) => {
      return (
        bottomItemList.value.every((child) => child.variables !== item.variables) &&
        topItemlist.value.every((child) => child.variables !== item.variables)
      )
    })
    itemList.value = JSON.parse(JSON.stringify(data))
  })
  EUCStore['bottomItemList'] = bottomItemList.value
})

watch(
  () => [props.yosikieda, props.datasourceid, props.yosikihouhou],
  () => {
    if (props.yosikihouhou != null) {
      init()
    }
  }
)

watch(
  () => [...topItemlist.value, ...bottomItemList.value],
  () => {
    props.editJudge.setEdited(), { deep: true }
  }
)
watch(
  () => bottomItemList.value,
  (newValue) => {
    if (bottomItemList.value.length > 0) {
      const element = bottomItemList.value.find((el) => el.label === '発行日')
      if (element) {
        element.syokiti = 'today'
      }
      EUCStore['bottomItemList'] = newValue
    }
  },
  { deep: true }
)
watch(
  () => [EUCStore['yosikihimonm'], topItemlist.value],
  (newValue, oldValue) => {
    topItemlist.value.forEach((item) => {
      if (item.jyokenid === Number(newValue[0])) {
        item.hissuflg = true
      }
      if (item.jyokenid === Number(oldValue[0]) && Number(newValue[0]) !== Number(oldValue[0])) {
        item.hissuflg = false
      }
    })
  }
)
const init = () => {
  if (props.rptid) {
    const params = {
      rptid: props.rptid,
      yosikieda: props.yosikieda,
      yosikihouhou: props.yosikihouhou,
      datasourceid: props.datasourceid || props.rptdatasourceid,
      yosikiid: props.yosikiid,
      procnm: isSql.value ? props.procnm : '',
      kbn: Number(props.kbn),
      sql: props.sql,
      editkbn: route.query.isNew ? Enum編集区分.新規 : Enum編集区分.変更
    }
    SearchConditionTab(params).then((res) => {
      //topItemlist初期値
      const temp1: (SearchConditionVM & { canEddit: boolean })[] = []
      //データソースから検索条件
      res.selectedjokenlist.forEach((item, index) => {
        const result = [...res.itemlist, ...specialConditions.value].find(
          (child) => child.jyokenid === item.jyokenid
        )
        if (result && (item.datasourceid || props.yosikihouhou == Enum様式作成方法.プロシージャ)) {
          temp1.push({
            ...result,
            orderseq: item.orderseq,
            hissuflg: item.hissuflg,
            canEddit:
              String(item.jyokenid)?.startsWith('88') ||
              props.yosikihouhou == Enum様式作成方法.プロシージャ
          })
        }
      })
      //条件追加検索条件
      const list = res.conditionAddlist ?? []
      topItemlist.value = (
        props.yosikihouhou == Enum様式作成方法.プロシージャ
          ? res.selectedProcedjoklist.map((item) => ({ ...item, canEddit: true }))
          : temp1.concat(list.map((item) => ({ ...item, canEddit: true })))
      ).map((e) => {
        e.value = e.syokiti
        return e
      })
      topItemlist.value.sort((a, b) => {
        return a.orderseq - b.orderseq
      })

      //leftConditionList初期値
      itemList.value = JSON.parse(JSON.stringify(res.itemlist))
      leftConditionList.value = res.itemlist.filter((item) => {
        return (
          res.selectedjokenlist.every((child) => child.jyokenid !== item.jyokenid) &&
          res.selectedjokenOtherlist.every((child) => child.jyokenid !== item.jyokenid)
        )
      })
      oldList.value = [...leftConditionList.value, ...topItemlist.value]

      //bottomItemList初期値
      const result = res.selectedjokenOtherlist
      const otherList = [...itemList.value, ...specialConditions.value]
      result.forEach((item, index) => {
        const existingIndex = bottomItemList.value.findIndex(
          (existingItem) => existingItem.jyokenseq === item.jyokenseq
        )
        const newItem = {
          ...item,
          canEddit:
            (props.yosikihouhou == Enum様式作成方法.プロシージャ &&
              !specialItems.map((e) => e.jyokenid).includes(item.jyokenid)) ||
            !otherList.find((i) => i.jyokenid === item.jyokenid)
        }
        if (existingIndex !== -1) {
          bottomItemList.value[existingIndex] = newItem
        } else {
          bottomItemList.value.push(newItem)
        }
      })
      bottomItemList.value = bottomItemList.value.map((e) => {
        e.value = e.syokiti
        return e
      })
      bottomItemList.value.sort((a, b) => {
        return a.orderseq - b.orderseq
      })

      specialConditions.value = specialConditions.value.filter((item) => {
        return [...topItemlist.value, ...res.selectedjokenOtherlist].every(
          (child) => child.jyokenid !== item.jyokenid
        )
      })
      itemLabel.value = [
        ...topItemlist.value,
        ...bottomItemList.value,
        ...leftConditionList.value,
        ...specialConditions.value
      ].map((el) => ({
        jyokenid: el.jyokenid,
        jyokenlabel: el.jyokenlabel
      }))

      nextTick(() => props.editJudge.reset())
    })
  }
}
//編集処理
let currentIndex = -1
const edit = (
  val: SearchConditionVM & { jyokenseq?: number; canEddit?: boolean },
  index: number
) => {
  editVisible.value = true
  isEdit.value = true
  currentIndex = index
  if (val.jyokenseq && !isSql.value) {
    // editLoading.value = true
    SearchConditionDetail({ jyokenseq: val.jyokenseq }).then((res) => {
      const list =
        masterlist.value.find((item) => item.mastercd === res?.eurptkensaku.mastercd)?.cdlist ?? []
      const masterparaList = res?.eurptkensaku.masterpara?.split(',') ?? []
      const data = {}
      list.forEach((item, index) => (data[item.columnnm] = masterparaList[index]))
      searchModalRef.value?.setEddit({
        ...res.eurptkensaku,
        ...val,
        jyokenlabel: val.jyokenlabel,
        datatype: String(res.eurptkensaku.datatype),
        ...data,
        index,
        orderseq: val.orderseq
      })
    })
    // .finally(() => (editLoading.value = false))
  } else {
    const findItem = itemList.value.find((i) => i.jyokenid === val.jyokenid)
    if (!findItem) sqlAddJyoken.value = Enum追加条件区分.追加条件
    searchModalRef.value?.setEddit(val)
  }
}
//条件追加
const addJyoken = (val: number) => {
  editVisible.value = true
  searchModalRef.value?.setEddit()
  isEdit.value = false
  kensakukbn.value = val
  sqlAddJyoken.value = Enum追加条件区分.追加条件
  currentIndex = -1
}

function setItem(data: SearchConditionVM, kensakukbn: number) {
  const setFunc = () => {
    data.value = data.syokiti
    const value = data.controlkbn == Enumコントロール.年度 ? data.nendo : ''
    if (currentIndex >= 0) {
      if (data.orderseq >= 1000) bottomItemList.value[currentIndex] = { ...data, canEddit: true }
      else {
        topItemlist.value[currentIndex] = { ...data, canEddit: true, nendo: value }
      }
    } else {
      data.datasourceid = ''
      data.jyokenkbn = Enum検索条件区分.通常条件.toString()
      let list = [...leftConditionList.value, ...topItemlist.value, ...bottomItemList.value]
      const maxJyokenid = list.reduce((max, e) => Math.max(max, e.jyokenid), -Infinity)
      data.jyokenid = maxJyokenid !== -Infinity ? maxJyokenid + 1 : 1
      if (kensakukbn === 1) {
        const seq = getFirstMissingOrderSeq([...itemList.value, ...topItemlist.value]) ?? 0
        topItemlist.value.push({ ...data, canEddit: true, orderseq: seq, nendo: value })
      } else {
        const seq = getFirstMissingOrderSeq(bottomItemList.value) ?? 1000
        bottomItemList.value.push({ ...data, canEddit: true, orderseq: seq, nendo: value })
      }
      itemLabel.value = [
        ...topItemlist.value,
        ...bottomItemList.value,
        ...leftConditionList.value,
        ...specialConditions.value
      ].map((el) => ({
        jyokenid: el.jyokenid,
        jyokenlabel: el.jyokenlabel
      }))
    }
    if (!getJokenOptions().find((e) => e.value == Number(EUCStore['yosikihimonm'])))
      emitter.emit('cleanValue')
    currentIndex = -1
  }

  if ([Enumコントロール.年度, Enumコントロール.選択].includes(data.controlkbn)) {
    SearchJokenDetail({
      controlkbn: data.controlkbn,
      mastercd: data.mastercd,
      masterpara: data.masterpara,
      nendohanikbn: data.nendohanikbn
    }).then((res) => {
      if (data.controlkbn == Enumコントロール.年度) {
        data.nendo = res.nendo || ss.get(GLOBAL_YEAR)
        data.nendomax = res.nendomax
      }
      data.selectlist = res.selectlist ?? []
      setFunc()
    })
  } else {
    setFunc()
  }
}

watch(
  () => props.selectorlist4,
  (newValue) => {
    if (newValue.length > 0 && specialConditions.value.length > 0) {
      specialConditions.value[specialConditions.value.length - 1].selectlist =
        (props.selectorlist4 ?? []) as any
    }
  }
)

watch(
  () => [topItemlist.value, bottomItemList.value],
  ([newValue1, newValue2]) => {
    EUCStore.setConditionlist([...newValue1, ...newValue2])
  }
)
watch(
  () => editVisible.value,
  (newValue) => {
    if (!newValue) {
      sqlAddJyoken.value = Enum追加条件区分.固定条件
    }
  }
)
//ドラッグ処理
const onEnd = (e) => {
  //検索条件
  let dragItem = leftConditionList.value[e.oldIndex]
  if (e.originalEvent.toElement.closest('#right-move')) {
    leftConditionList.value.splice(e.oldIndex, 1)
    const seq = getFirstMissingOrderSeq([...topItemlist.value, ...itemList.value]) ?? 0
    topItemlist.value.push({
      ...dragItem,
      canEddit:
        String(dragItem.jyokenid)?.startsWith('88') ||
        (props.yosikihouhou == Enum様式作成方法.プロシージャ &&
          !specialItems.map((e) => e.jyokenid).includes(dragItem.jyokenid)),
      orderseq: seq
    } as unknown as SearchConditionVM)

    //検索条件以外項目
  } else if (e.originalEvent.toElement.closest('#special-right-move')) {
    leftConditionList.value.splice(e.oldIndex, 1)
    const seq = getFirstMissingOrderSeq(bottomItemList.value) ?? 1000
    bottomItemList.value.push({
      ...dragItem,
      canEddit:
        String(dragItem.jyokenid)?.startsWith('88') ||
        (props.yosikihouhou == Enum様式作成方法.プロシージャ &&
          !specialItems.map((e) => e.jyokenid).includes(dragItem.jyokenid)),
      orderseq: seq
    } as unknown as SearchConditionVM)
  }
}

const onSpecialEnd = (e) => {
  let dragItem = specialConditions.value[e.oldIndex]
  //検索条件
  if (e.originalEvent.toElement.closest('#right-move')) {
    specialConditions.value.splice(e.oldIndex, 1)
    topItemlist.value.push({
      ...dragItem,
      orderseq: getFirstMissingOrderSeq(topItemlist.value)
    } as unknown as SearchConditionVM)
  }
  //検索条件以外項目
  if (e.originalEvent.toElement.closest('#special-right-move')) {
    specialConditions.value.splice(e.oldIndex, 1)
    bottomItemList.value.push({ ...dragItem, hissuflg: true } as unknown as SearchConditionVM)
  }
}
const specialMenuClick = (key: 'delItem' | 'require', rightIndex) => {
  const item = bottomItemList.value[rightIndex]
  if (key === 'delItem') {
    if (item.jyokenid > 0) {
      const findItem = itemList.value.find((i) => i.jyokenid === item.jyokenid)
      if (findItem) leftConditionList.value.push(findItem)
    } else {
      item.hissuflg = false
      specialConditions.value.push(item)
    }
    bottomItemList.value.splice(rightIndex, 1)
  }
  if (key === 'require') {
    bottomItemList.value[rightIndex].hissuflg = !bottomItemList.value[rightIndex].hissuflg
    props.editJudge.setEdited()
  }
}

//右クリックメニュー処理
const menuClick = (key: 'delItem' | 'require', item, rightIndex) => {
  if (key === 'delItem') {
    if (item.jyokenid > 0) {
      const findItem = itemList.value.find((i) => i.jyokenid === item.jyokenid)
      if (findItem) leftConditionList.value.push(findItem)
    } else {
      specialConditions.value.push(item)
    }
    topItemlist.value.splice(rightIndex, 1)
    if (!getJokenOptions().find((e) => e.value == Number(EUCStore['yosikihimonm'])))
      emitter.emit('cleanValue')
    itemLabel.value = [
      ...topItemlist.value,
      ...bottomItemList.value,
      ...leftConditionList.value,
      ...specialConditions.value
    ].map((el) => ({
      jyokenid: el.jyokenid,
      jyokenlabel: el.jyokenlabel
    }))
  }
  if (key === 'require') {
    topItemlist.value[rightIndex].hissuflg = !topItemlist.value[rightIndex].hissuflg
    props.editJudge.setEdited()
  }
}

const getFieldsValue = () => {
  return [
    ...topItemlist.value.map((item) => ({ ...item, jyokenid: item.jyokenid || 0 })),
    ...bottomItemList.value?.map((item) => ({ ...item, datasourceid: props.datasourceid }))
  ]
}

const getJokenOptions = () => {
  return topItemlist.value
    .filter((e) => e.controlkbn == Enumコントロール.選択)
    .map((item) => ({ label: item.jyokenlabel, value: item.jyokenid }))
}

const getFirstMissingOrderSeq = (items: SearchConditionVM[]) => {
  if (!items || items.length === 0) {
    return null
  }
  const orderSeqs = items.map((item) => item.orderseq)
  const minOrderSeq = Math.min(...orderSeqs)
  const maxOrderSeq = Math.max(...orderSeqs)
  for (let i = minOrderSeq; i <= maxOrderSeq; i++) {
    if (!orderSeqs.includes(i)) {
      return i
    }
  }
  return maxOrderSeq + 1
}

defineExpose({
  getFieldsValue,
  getJokenOptions,
  bottomItemList
})
</script>

<style lang="less" scoped src="./index.less"></style>
