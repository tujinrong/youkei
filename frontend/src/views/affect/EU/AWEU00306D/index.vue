<template>
  <a-modal
    :visible="visible"
    width="800px"
    title="出力順登録"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    centered
  >
    <div class="self_adaption_table form">
      <a-row class="items-center">
        <a-col :span="18" class="mr-2">
          <th>出力順</th>
          <td v-if="!isSearchPage">
            <a-form-item v-bind="validateInfos.sortName">
              <a-input v-model:value="form.sortName" />
            </a-form-item>
          </td>
          <td v-else>
            <ai-select
              v-model:value="initData.sortptnno"
              :options="initData.selectorlist1"
              split-val
            />
          </td>
        </a-col>
        <a-button
          v-show="isSearchPage"
          type="primary"
          :disabled="!initData.sortptnno"
          @click="handleSearch"
          >検索</a-button
        >
        <a-button v-show="isSearchPage" type="primary" class="ml-2" @click="handleAdd"
          >新規</a-button
        >
        <a-button v-show="!isSearchPage && !isAdding" type="primary" @click="back2Search"
          >再検索</a-button
        >
      </a-row>
      <a-row class="my-3">
        <a-space>
          <a-button class="btn-round" type="primary" :disabled="isSearchPage" @click="addDomain"
            >行追加</a-button
          >
          <a-button class="btn-round" :disabled="!selectedRow" type="primary" @click="delRow"
            >行削除</a-button
          >
        </a-space>
      </a-row>

      <a-form
        ref="formRef"
        :model="initData"
        class="w-full"
        style="height: 400px; border: 1px solid #606266; overflow: auto"
      >
        <div class="self_adaption_table">
          <a-row class="w-full">
            <a-col
              v-for="(row, index) in initData.sortsublist"
              :key="row.reportitemid"
              span="24"
              :class="[currentIndex === index && 'bg-editable', 'p-0']"
              @click="() => handleSelectRow(row, index)"
            >
              <th>{{ `第 ${index + 1} キー` }}</th>
              <td class="flex">
                <a-form-item
                  :name="['sortsublist', index, 'reportitemid']"
                  :rules="{
                    required: true,
                    message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '帳票項目')
                  }"
                >
                  <a-select
                    v-model:value="row.reportitemid"
                    style="width: 320px"
                    :options="getOptions(row.reportitemid)"
                  />
                </a-form-item>
                <a-form-item :name="['sortsublist', index, 'descflg']" class="ml-6">
                  <a-radio-group v-model:value="row.descflg" :name="`descflg${index}`">
                    <a-radio :value="false">昇順</a-radio>
                    <a-radio :value="true">降順</a-radio>
                  </a-radio-group>
                </a-form-item>
                <a-form-item :name="['sortsublist', index, 'pageflg']">
                  <a-checkbox v-model:checked="row.pageflg" :disabled="disableCheckbox(index)"
                    >改ページ</a-checkbox
                  >
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
      </a-form>
    </div>

    <template #footer>
      <a-button style="float: left" type="warn" :disabled="isSearchPage" @click="onSave"
        >登録</a-button
      >
      <a-button
        style="float: left"
        type="primary"
        danger
        :disabled="isSearchPage || isAdding"
        @click="handleDelete"
        >削除</a-button
      >
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, watch, nextTick, computed } from 'vue'
import { SortSubVM } from './type'
import { Init, Add, Update, Delete, Search } from './service'
import {
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  LOGIC_DELETE_CONFIRM,
  RESEARCH_CONFIRM,
  SAVE_OK_INFO
} from '@/constants/msg'
import { showConfirmModal, showDeleteModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { Judgement } from '@/utils/judge-edited'
import { GlobalStore } from '@/store'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  rptid: string
  yosikiid: string
}>()

const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formRef = ref()
const isSearchPage = ref(true) //検索
const isAdding = ref(false) //新規
const editJudge = new Judgement()

const initData = reactive({
  selectorlist1: [] as DaSelectorModel[],
  selectorlist2: [] as DaSelectorModel[],
  sortptnno: '',
  sortupddttm: '',
  yosikiupddttm: '',
  sortsublist: [] as SortSubVM[]
})

const form = reactive({ sortName: '' })
//項目の設定
const rules = reactive({
  sortName: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '出力順パターン名') }]
})
const { validate, clearValidate, validateInfos } = Form.useForm(form, rules)

const currentIndex = ref<number>(-1)
const selectedRow = ref<SortSubVM | null>(null)

const selectedCheckboxIndex = computed(() => initData.sortsublist.findIndex((e) => e.pageflg))
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      init()
    }
  }
)
watch(
  () => initData.sortsublist,
  () => editJudge.setEdited(),
  { deep: true }
)

// 初期化処理
function init() {
  Init({
    rptid: props.rptid,
    yosikiid: props.yosikiid
  })
    .then((res) => {
      initData.selectorlist1 = res.selectorlist1
      initData.selectorlist2 = res.selectorlist2
      initData.yosikiupddttm = res.yosikiupddttm
      initData.sortptnno = res.sortptnno as string
    })
    .then(async () => {
      if (initData.sortptnno) await handleSearch()
      nextTick(() => editJudge.reset())
    })
}
// 検索処理
async function handleSearch() {
  try {
    const res = await Search({
      rptid: props.rptid,
      yosikiid: props.yosikiid,
      sortptnno: initData.sortptnno
    })
    isSearchPage.value = false
    initData.sortsublist = res.sortsublist
    initData.sortupddttm = res.sortupddttm
    nextTick(() => editJudge.reset())
  } catch (error) {}
  form.sortName = initData.selectorlist1.find((el) => el.value == initData.sortptnno)?.label ?? ''
}
// 再検索処理
function back2Search() {
  editJudge.judgeIsEdited(() => {
    isSearchPage.value = true
    isAdding.value = false
    initData.sortsublist = []
    selectedRow.value = null
    nextTick(() => editJudge.reset())
  }, RESEARCH_CONFIRM.Msg)
}

function getOptions(id) {
  let ids: string[] = []
  initData.sortsublist.forEach((el) => {
    if (el.reportitemid !== id) {
      ids.push(el.reportitemid)
    }
  })
  return initData.selectorlist2.filter((el) => !ids.includes(el.value))
}

// 削除処理
const handleDelete = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({
          rptid: props.rptid,
          yosikiid: props.yosikiid,
          sortptnno: initData.sortptnno,
          sortupddttm: initData.sortupddttm,
          yosikiupddttm: initData.yosikiupddttm
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        closeModal()
      } catch (error) {}
    }
  })
}

const handleSelectRow = (item: any, index: number) => {
  if (!isSearchPage.value) {
    currentIndex.value = index
    selectedRow.value = item
  }
}
//行削除
const delRow = () => {
  showConfirmModal({
    content: LOGIC_DELETE_CONFIRM.Msg.replace('{0}', '選択テータ'),
    onOk: () => {
      initData.sortsublist.splice(currentIndex.value, 1)
      selectedRow.value = null
      currentIndex.value = -1
    }
  })
}
//行追加
const addDomain = () => {
  initData.sortsublist.push({
    reportitemid: '',
    descflg: false,
    pageflg: false
  })
}

//新規
const handleAdd = () => {
  isSearchPage.value = false
  isAdding.value = true
  initData.sortptnno = ''
  form.sortName = ''
  nextTick(() => clearValidate())
}

const onSave = async () => {
  await validate()
  await formRef.value.validate()
  showSaveModal({
    onOk: async () => {
      try {
        if (initData.sortptnno) {
          await Update({
            rptid: props.rptid,
            yosikiid: props.yosikiid,
            sortptnnm: form.sortName,
            sortsublist: initData.sortsublist,
            sortptnno: initData.sortptnno,
            sortupddttm: initData.sortupddttm,
            yosikiupddttm: initData.yosikiupddttm
          })
          editJudge.reset()
          closeModal()
        } else {
          await Add({
            rptid: props.rptid,
            yosikiid: props.yosikiid,
            sortptnnm: form.sortName,
            sortsublist: initData.sortsublist,
            yosikiupddttm: initData.yosikiupddttm
          })
          editJudge.reset()
          closeModal()
        }
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {}
    }
  })
}

const reset = () => {
  isSearchPage.value = true
  isAdding.value = false
  initData.sortsublist = []
  currentIndex.value = -1
  selectedRow.value = null
  form.sortName = ''
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:visible', false)
    reset()
  })
}

const disableCheckbox = (index) => {
  return selectedCheckboxIndex.value !== -1 && selectedCheckboxIndex.value !== index
}
</script>

<style scoped lang="less">
th {
  width: 100px;
}

.ant-form-item {
  width: 100%;
  margin-bottom: 0px;
}
</style>
