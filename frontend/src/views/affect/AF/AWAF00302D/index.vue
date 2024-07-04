<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: お知らせ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.02.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    title="お知らせ"
    width="80%"
    centered
    class="modal-with-left-tab-title"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <a-tabs
      v-model:activeKey="activeKey"
      type="card"
      class="fix-left-tab-title"
      tab-position="left"
      @change="changeActiveKey"
    >
      <a-tab-pane :key="EditSatatus.Update" tab="編集" :disabled="loading">
        <a-spin :spinning="loading">
          <div v-show="activeKey === EditSatatus.Update">
            <div class="flex m-b-1">
              <a-space>
                <a-button
                  class="btn-round"
                  type="primary"
                  :disabled="addList.length > 24"
                  @click="addRow"
                  >行追加</a-button
                >
                <a-button
                  class="btn-round"
                  type="primary"
                  :disabled="!selectedRow"
                  @click="deleteRow"
                  >行削除</a-button
                >
              </a-space>
              <a-select
                v-model:value="readParam"
                class="m-l-auto w-30"
                :options="readOptions"
                @change="changePage(1)"
              ></a-select>
              <a-select
                v-model:value="showParam"
                class="m-l-1 w-80"
                :options="showOptions"
                @change="changePage(1)"
              ></a-select>
              <a-pagination
                :current="currentPage"
                :total="totalCount"
                :page-size="25"
                :show-size-changer="false"
                class="m-l-1"
                @change="changePage"
              />
            </div>
          </div>

          <a-card id="list_card" class="overflow-auto h-xl">
            <div
              v-for="(item, index) in editList"
              :key="item.infoseq"
              :class="[currentIndex === index && 'bg-editable', 'p-2']"
              @click="selectRow(item, index)"
            >
              <div class="description-table">
                <!--START 編集可能 -->
                <a-form
                  v-if="item.editflg"
                  ref="editFormRef"
                  :rules="rules"
                  :model="item"
                  class="form_in_table"
                >
                  <table>
                    <tbody>
                      <tr>
                        <th colspan="2">伝言宛先</th>
                        <th width="100px">重要度 <span class="request-mark">＊</span></th>
                        <th width="178px">期限 <span class="request-mark">＊</span></th>
                        <th width="12%" class="bg-readonly">登録者</th>
                        <th width="190px" class="bg-readonly">登録日時</th>
                        <th width="190px" class="bg-readonly">更新日時</th>
                      </tr>
                      <tr>
                        <td width="200px" class="flex">
                          <a-radio-group
                            v-model:value="item.atesakiflg"
                            :options="[
                              { label: '全員', value: false },
                              { label: '宛先指定', value: true }
                            ]"
                            class="ml-1"
                            @change="onChangeAtesakiflg"
                          />
                          <span v-if="item.atesakiflg" class="request-mark">＊</span>
                        </td>
                        <td>
                          <a-form-item
                            name="userlist"
                            :rules="[
                              {
                                required: item.atesakiflg,
                                message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'ユーザー'),
                                type: 'array',
                                trigger: 'change'
                              }
                            ]"
                          >
                            <div class="flex">
                              <a-select
                                v-model:value="item.userlist"
                                class="flex-1"
                                mode="multiple"
                                max-tag-count="responsive"
                                :options="userList"
                                :field-names="{ label: 'usernm', value: 'userid' }"
                                :filter-option="filterOption"
                                :disabled="!item.atesakiflg"
                              >
                                <template #option="{ usernm, userid }">
                                  {{ userid + ' : ' + usernm }}
                                </template>
                              </a-select>
                              <a-button
                                type="primary"
                                class="ml-[2px]"
                                :disabled="!item.atesakiflg"
                                @click="openUserSetModal"
                                >設定</a-button
                              >
                            </div>
                          </a-form-item>
                        </td>
                        <td>
                          <a-form-item name="juyodo">
                            <ai-select v-model:value="item.juyodo" :options="juyodoOptions" />
                          </a-form-item>
                        </td>
                        <td>
                          <a-form-item name="kigenymd">
                            <date-jp v-model:value="item.kigenymd" class="w-full" />
                          </a-form-item>
                        </td>
                        <td>
                          {{ item.regusernm }}
                        </td>
                        <td>
                          {{ getDateHmsJpText(new Date(item.regdttm)) }}
                        </td>
                        <td>{{ getDateHmsJpText(new Date(item.upddttm)) }}</td>
                      </tr>
                      <tr>
                        <th>
                          伝言内容
                          <div class="show_count_box">
                            {{ `${item.syosai?.length} / 2000` }}
                          </div>
                        </th>
                        <td colspan="6">
                          <a-form-item>
                            <a-textarea
                              v-model:value="item.syosai"
                              class="w-full"
                              :auto-size="{ minRows: 2 }"
                              :maxlength="2000"
                            />
                          </a-form-item>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </a-form>
                <!--END 編集可能 -->

                <!--START 編集不可 -->
                <div v-else>
                  <table class="readonly">
                    <tbody>
                      <tr>
                        <th width="200px">重要度</th>
                        <th width="200px">期限</th>

                        <th>登録者</th>
                        <th width="190px">登録日時</th>
                        <th width="190px">更新日時</th>
                      </tr>
                      <tr>
                        <td>
                          {{ item.juyodo.split(' : ')[1] }}
                        </td>
                        <td>
                          {{ getDateJpText(new Date(item.kigenymd)) }}
                        </td>

                        <td>
                          {{ item.regusernm }}
                        </td>
                        <td>
                          {{ getDateHmsJpText(new Date(item.regdttm)) }}
                        </td>
                        <td>{{ getDateHmsJpText(new Date(item.upddttm)) }}</td>
                      </tr>
                      <tr>
                        <td class="text-center w-[80px]">
                          <a-button
                            type="primary"
                            shape="round"
                            :danger="!item.readflg"
                            @click="changeReadkbn(item)"
                            >{{ item.readflg ? '既読' : '未読' }}</a-button
                          >
                        </td>
                        <th class="bg-readonly w-[100px]">
                          伝言内容
                          <div class="show_count_box">
                            {{ `${item.syosai?.length} / 2000` }}
                          </div>
                        </th>
                        <td colspan="3">
                          {{ item.syosai }}
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <!--END 編集不可 -->
              </div>
            </div>
          </a-card>
        </a-spin>
      </a-tab-pane>
      <a-tab-pane :key="EditSatatus.Add" tab="新規" :disabled="loading">
        <a-spin :spinning="loading">
          <div class="flex m-b-1">
            <a-space>
              <a-button
                class="btn-round"
                type="primary"
                :disabled="addList.length > 24"
                @click="addRow"
                >行追加</a-button
              >
              <a-button class="btn-round" type="primary" :disabled="!selectedRow" @click="deleteRow"
                >行削除</a-button
              >
            </a-space>
          </div>
          <a-card class="overflow-auto h-xl">
            <div
              v-for="(item, index) in addList"
              :key="item.key"
              :class="[currentIndex == index && 'bg-editable', 'p-2']"
              @click="selectRow(item, index)"
            >
              <div class="description-table">
                <a-form ref="addFormRef" :rules="rules" :model="item" class="form_in_table">
                  <table>
                    <tbody>
                      <tr>
                        <th colspan="2">伝言宛先</th>
                        <th width="100px">重要度 <span class="request-mark">＊</span></th>
                        <th width="178px">期限 <span class="request-mark">＊</span></th>
                      </tr>
                      <tr>
                        <td width="200px" class="flex">
                          <a-radio-group
                            v-model:value="item.atesakiflg"
                            :options="[
                              { label: '全員', value: false },
                              { label: '宛先指定', value: true }
                            ]"
                            class="ml-1"
                            @change="onChangeAtesakiflg"
                          />
                          <span v-if="item.atesakiflg" class="request-mark">＊</span>
                        </td>
                        <td>
                          <a-form-item
                            name="userlist"
                            :rules="[
                              {
                                required: item.atesakiflg,
                                message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'ユーザー'),
                                type: 'array'
                              }
                            ]"
                          >
                            <div class="flex">
                              <a-select
                                v-model:value="item.userlist"
                                class="flex-1"
                                mode="multiple"
                                max-tag-count="responsive"
                                :options="userList"
                                :field-names="{ label: 'usernm', value: 'userid' }"
                                :filter-option="filterOption"
                                :disabled="!item.atesakiflg"
                              >
                                <template #option="{ usernm, userid }">
                                  {{ userid + ' : ' + usernm }}
                                </template>
                              </a-select>
                              <a-button
                                type="primary"
                                class="ml-[2px]"
                                :disabled="!item.atesakiflg"
                                @click="openUserSetModal"
                                >設定</a-button
                              >
                            </div>
                          </a-form-item>
                        </td>
                        <td>
                          <a-form-item name="juyodo">
                            <ai-select v-model:value="item.juyodo" :options="juyodoOptions" />
                          </a-form-item>
                        </td>
                        <td>
                          <a-form-item name="kigenymd">
                            <date-jp v-model:value="item.kigenymd" class="w-full" />
                          </a-form-item>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          伝言内容
                          <div class="show_count_box">
                            {{ `${item.syosai?.length} / 2000` }}
                          </div>
                        </th>
                        <td colspan="3">
                          <a-form-item>
                            <a-textarea
                              v-model:value="item.syosai"
                              class="w-full"
                              :auto-size="{ minRows: 2 }"
                              :maxlength="2000"
                            />
                          </a-form-item>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </a-form>
              </div>
            </div>
          </a-card>
        </a-spin>
      </a-tab-pane>
    </a-tabs>

    <UserSetModal
      v-model:visible="setVisible"
      :selected-data="selectedRow?.userlist ?? []"
      :userlist="userList"
      @select="selectUserList"
    />

    <template #footer>
      <div class="float-left">
        <a-button class="warning-btn" @click="saveData">登録</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, computed, watch, nextTick } from 'vue'
import { getDateHmsJpText, getDateJpText, judgeValidate } from '@/utils/util'
import { Search, Save, Init } from './service'
import dayjs from 'dayjs'
import { message, Modal } from 'ant-design-vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Judgement } from '@/utils/judge-edited'
import type { FormInstance } from 'ant-design-vue'
import { SearchRequest, InfoVM, SaveRequest, SearchVM, UpdVM, LockVM, UserVM } from './type'
import { useLoading } from '@/utils/hooks'
import { showOptions, readOptions } from '@/constants/constant'
import { EditSatatus, Enum未読区分, Enum表示区分, Enum名称区分 } from '#/Enums'
import { showConfirmModal, showDeleteModal, showSaveModal } from '@/utils/modal'
import {
  CLOSE_CONFIRM,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  RESEARCH_CONFIRM,
  SAVE_OK_INFO
} from '@/constants/msg'
import { Rule } from 'ant-design-vue/lib/form'
import UserSetModal from './components/UserSetModal.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
  (e: 'refresh'): void
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
//ローディング
const { loading, startLoading, endLoading } = useLoading(false)
//テンプレート参照
const addFormRef = ref<FormInstance[]>([])
const editFormRef = ref<FormInstance[]>([])
//画面データ編集判断
const editJudge = new Judgement()
const addJudge = new Judgement()
//ページャー
const totalCount = ref(0)
const currentPage = ref(1)
//画面区分
const showParam = ref(Enum表示区分.期限内)
const readParam = ref(Enum未読区分.未読)
//タブキー
const activeKey = ref(EditSatatus.Update) //編集1/新規2
//ビューモデル
const editList = ref<SearchVM[]>([])
const addList = ref<InfoVM[]>([])
const selectedRow = ref<SearchVM | InfoVM | null>(null)
const currentIndex = ref(-1)
//排他チェック用リスト
let lockList: LockVM[] = [] //編集用
let lockList2: LockVM[] = [] //既読用
const juyodoOptions = ref<DaSelectorModel[]>([])
//キャンセル用
let oldParam_show = Enum表示区分.期限内
let oldParam_read = Enum未読区分.未読
//項目の設定
const rules = ref<Record<string, Rule[]>>({
  juyodo: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '重要度'),
      trigger: ['change', 'blur']
    }
  ],
  kigenymd: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期限'),
      trigger: 'blur'
    }
  ]
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
//初期化
watch(
  () => props.visible,
  async (val) => {
    if (val) {
      Init({ kbn: Enum名称区分.名称 }).then((res) => {
        juyodoOptions.value = res.selectorlist
        userList.value = res.userlist
      })
      await getEditList()
    } else {
      reset()
      userList.value = []
    }
    resetJudgement()
  }
)
//画面データ編集判断
watch(editList, () => editJudge.setEdited(), { deep: true })
watch(addList, () => addJudge.setEdited(), { deep: true })

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
const getEditList = async () => {
  startLoading()
  let params: SearchRequest = {
    readkbn: readParam.value,
    showkbn: showParam.value,
    pagenum: currentPage.value,
    pagesize: 25
  }
  try {
    const res = await Search(params)
    editList.value = res.kekkalist
    lockList = []
    lockList2 = []
    for (const item of res.kekkalist) {
      if (item.editflg) {
        lockList.push({ infoseq: item.infoseq, upddttm: item.upddttm })
      } else {
        lockList2.push({ infoseq: item.infoseq, upddttm: item.upddttm })
      }
    }
    for (const item of editList.value) {
      item.userlist ??= [] //replace null
    }
    oldParam_show = params.showkbn
    oldParam_read = params.readkbn
    totalCount.value = res.totalrowcount
  } catch (error) {}
  endLoading()
  nextTick(() => {
    editJudge.reset()
    const wrapper = document.querySelector('#list_card')
    if (wrapper) wrapper.scrollTop = 0
  })
}
//保存処理
const saveData = () => {
  if (loading.value) return
  judgeValidate(editFormRef.value, addFormRef.value)
    .then(() => {
      showSaveModal({
        onOk: async () => {
          const saveParams: SaveRequest = {
            addlist: addList.value.map((item) => {
              return {
                ...item,
                kigenymd: dayjs(item.kigenymd).format('YYYY-MM-DD'),
                userlist: item.atesakiflg ? item.userlist : []
              }
            }),
            updlist: editList.value.map((item) => {
              return {
                ...item,
                kigenymd: dayjs(item.kigenymd).format('YYYY-MM-DD'),
                userlist: item.atesakiflg ? item.userlist : []
              }
            }),
            locklist: lockList,
            locklist2: lockList2
          }
          try {
            await Save(saveParams)
            reset()
            getEditList()
            currentIndex.value = -1
            selectedRow.value = null
            message.success(SAVE_OK_INFO.Msg)
            emit('refresh')
          } catch (error) {}
        }
      })
    })
    .catch((key) => (activeKey.value = key))
}

//画面モード変更
const changeActiveKey = (key: EditSatatus) => {
  activeKey.value = key
  selectedRow.value = null
  currentIndex.value = -1
}
//未読既読変更
const changeReadkbn = (item: UpdVM) => {
  item.readflg = !item.readflg
}
//ページ変更
const changePage = (newValue: number) => {
  if (editJudge.isPageEdited()) {
    showConfirmModal({
      content: RESEARCH_CONFIRM,
      async onOk() {
        startLoading()
        currentPage.value = newValue
        selectedRow.value = null
        currentIndex.value = -1
        await getEditList()
        editJudge.reset()
        endLoading()
        Modal.destroyAll()
      },
      onCancel() {
        showParam.value = oldParam_show
        readParam.value = oldParam_read
      }
    })
  } else {
    currentPage.value = newValue
    selectedRow.value = null
    currentIndex.value = -1
    getEditList().finally(() => {
      editJudge.reset()
      endLoading()
    })
  }
}
//行追加
const addRow = () => {
  addList.value.push({
    title: '',
    juyodo: null,
    kigenymd: dayjs(),
    syosai: '',
    atesakiflg: false,
    userlist: [],
    editflg: true,
    key: Symbol()
  } as unknown as SearchVM)
  activeKey.value = EditSatatus.Add
}
//行選択
const selectRow = (item, index) => {
  if (item.editflg) {
    currentIndex.value = index
    selectedRow.value = item
  }
}
//行削除
const deleteRow = () => {
  if (currentIndex.value > -1) {
    showDeleteModal({
      onOk() {
        if (activeKey.value === EditSatatus.Update) {
          editList.value.splice(currentIndex.value, 1)
        } else if (activeKey.value === EditSatatus.Add) {
          addList.value.splice(currentIndex.value, 1)
        }
        selectedRow.value = null
        currentIndex.value = -1
      }
    })
  }
}
//画面データ編集(リセット)
const resetJudgement = () => {
  addJudge.reset()
  editJudge.reset()
}
//リセット
function reset() {
  activeKey.value = EditSatatus.Update
  addList.value = []
  currentPage.value = 1
  nextTick(() => {
    resetJudgement()
  })
}
//閉じるボタン(×を含む)
const closeModal = () => {
  if (addJudge.isPageEdited() || editJudge.isPageEdited()) {
    showConfirmModal({
      content: CLOSE_CONFIRM,
      onOk() {
        modalVisible.value = false
      }
    })
  } else {
    modalVisible.value = false
  }
}
//----------------------------------------------------------------
//伝言宛先
const userList = ref<UserVM[]>([])
const setVisible = ref(false)
const idx = computed(() => {
  return activeKey.value === EditSatatus.Update
    ? editList.value.findIndex((el) => el.infoseq === selectedRow.value?.infoseq)
    : addList.value.findIndex((el) => el.key === selectedRow.value?.key)
})
function openUserSetModal() {
  nextTick(() => (setVisible.value = true))
}
function filterOption(input: string, option: UserVM) {
  return (
    option.userid.toLowerCase().includes(input.toLowerCase()) ||
    option.usernm.toLowerCase().includes(input.toLowerCase())
  )
}
function selectUserList(val) {
  if (selectedRow.value) {
    selectedRow.value.userlist = val
  }
  if (val.length > 0) {
    clearValidateUserList()
  }
}
function onChangeAtesakiflg(e) {
  if (!e.target.value) clearValidateUserList()
}
function clearValidateUserList() {
  activeKey.value === EditSatatus.Update
    ? editFormRef.value[idx.value].clearValidate(['userlist'])
    : addFormRef.value[idx.value].clearValidate(['userlist'])
}
//-----------------------------------------------------------------
</script>

<style lang="less" scoped>
.description-table .readonly {
  th {
    background-color: #ffffe1;
  }
  td {
    line-height: 32px;
    overflow-wrap: anywhere;
  }
}
</style>
