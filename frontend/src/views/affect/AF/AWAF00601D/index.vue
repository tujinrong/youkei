<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: メモ情報
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    width="1200px"
    title="メモ"
    centered
    class="modal-with-left-tab-title"
    :mask-closable="false"
    :closable="false"
    destroy-on-close
  >
    <CloseModalBtn @click="closeModal" />
    <div class="self_adaption_table">
      <a-row>
        <a-col span="6">
          <th>宛名番号</th>
          <TD>{{ atenano }}</TD>
        </a-col>
        <a-col span="6">
          <th>氏名</th>
          <TD>{{ userInfo?.name }}</TD>
        </a-col>
        <a-col span="6">
          <th>カナ氏名</th>
          <TD>{{ userInfo?.kname }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">性別</th>
          <TD>{{ userInfo?.sex }}</TD>
        </a-col>
        <a-col span="6">
          <th>住民区分</th>
          <TD>{{ userInfo?.juminkbn }}</TD>
        </a-col>
        <a-col span="6">
          <th>生年月日</th>
          <TD>{{ userInfo?.bymd }}</TD>
        </a-col>
        <a-col span="6">
          <th>年齢</th>
          <TD>{{ userInfo?.age }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">年齢計算基準日</th>
          <TD>{{ userInfo?.agekijunymd }}</TD>
        </a-col>
      </a-row>
    </div>
    <a-tabs
      v-model:activeKey="activeKey_status"
      type="card"
      class="fix-left-tab-title mt-3"
      tab-position="left"
      @change="changeActiveKey_status"
    >
      <a-tab-pane :key="EditSatatus.Update" tab="編集">
        <a-spin :spinning="loading">
          <div class="flex">
            <a-space>
              <a-button
                class="btn-round"
                type="primary"
                :disabled="!kengen.addflg || addList.length >= 25"
                @click="addRow"
                >行追加</a-button
              >
              <a-button type="primary" class="btn-round" :disabled="!canDelete" @click="deleteRow"
                >行削除</a-button
              >
            </a-space>
            <a-pagination
              class="ml-auto"
              :current="currentPage"
              :total="totalCount"
              :page-size="25"
              :show-size-changer="false"
              @change="changePage"
            ></a-pagination>
          </div>
          <a-collapse active-key="1" accordion class="m-t-1">
            <a-collapse-panel
              id="memo_panel"
              key="1"
              header="メモ情報"
              class="h-120 overflow-auto"
              :show-arrow="false"
            >
              <template v-if="editList.length > 0">
                <div
                  v-for="(item, index) in editList"
                  :key="item.memoseq"
                  :class="['p-2', { 'bg-editable': currentIndex === index }]"
                  @click="item.updflg && selectRow(index)"
                >
                  <div class="description-table">
                    <!--START 編集可能 -->
                    <a-form
                      v-if="kengen.updateflg && item.updflg"
                      ref="editFormRef"
                      :rules="rules"
                      :model="item"
                    >
                      <table>
                        <tbody>
                          <tr>
                            <th width="100">
                              <div class="flex w-full">
                                件名
                                <div class="m-l-auto c-gray-3">
                                  {{ `${item.title.length} / 50` }}
                                </div>
                              </div>
                            </th>
                            <td>
                              <a-form-item name="title">
                                <a-input v-model:value="item.title" :maxlength="50" />
                              </a-form-item>
                            </td>
                            <th width="80">重要度 <span class="request-mark">＊</span></th>
                            <td width="100">
                              <a-form-item name="juyodo">
                                <ai-select v-model:value="item.juyodo" :options="optionList1" />
                              </a-form-item>
                            </td>
                            <th width="60">期限日</th>
                            <td width="170">
                              <a-form-item name="kigenymd">
                                <date-jp
                                  :value="item.kigenymd"
                                  @change="
                                    (v) => (item.kigenymd = v ? dayjs(v).format('YYYY-MM-DD') : '')
                                  "
                                />
                              </a-form-item>
                            </td>
                            <th width="60" class="bg-readonly">登録者</th>
                            <td width="140">
                              {{ item.regusernm }}
                            </td>
                            <th width="80" class="bg-readonly">登録日時</th>
                            <td width="160">
                              {{ getSimpleDateHmsJpText(new Date(item.regdttm)) }}
                            </td>
                          </tr>
                          <tr>
                            <th>登録事業 <span class="request-mark">＊</span></th>
                            <td :colspan="showSisyo ? 1 : 5">
                              <a-form-item name="jigyokbn">
                                <ai-select v-model:value="item.jigyokbn" :options="optionList2" />
                              </a-form-item>
                            </td>
                            <th v-if="showSisyo" class="bg-readonly">登録支所</th>
                            <td v-if="showSisyo" colspan="3">
                              {{ item.regsisyo?.split(' : ')[1] }}
                            </td>
                            <th class="bg-readonly">更新者</th>
                            <td>{{ item.updusernm }}</td>
                            <th class="bg-readonly">更新日時</th>
                            <td>
                              {{ getSimpleDateHmsJpText(new Date(item.upddttm)) }}
                            </td>
                          </tr>
                          <tr>
                            <th>
                              メモ <span class="request-mark">＊</span>
                              <div class="show_count_box">
                                {{ `${item.memo.length} / 2000` }}
                              </div>
                            </th>
                            <td colspan="9">
                              <a-form-item name="memo">
                                <a-textarea
                                  v-model:value="item.memo"
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
                            <th width="100">
                              <div class="flex w-full">
                                件名
                                <div class="m-l-auto c-gray-3">
                                  {{ `${item.title.length} / 50` }}
                                </div>
                              </div>
                            </th>
                            <td>
                              {{ item.title }}
                            </td>
                            <th width="70">重要度</th>
                            <td width="100">{{ item.juyodo.split(' : ')[1] }}</td>
                            <th width="60">期限日</th>
                            <td width="140">{{ item.kigenymd }}</td>
                            <th width="60">登録者</th>
                            <td width="140">{{ item.regusernm }}</td>
                            <th width="80">登録日時</th>
                            <td width="160">
                              {{ getSimpleDateHmsJpText(new Date(item.regdttm)) }}
                            </td>
                          </tr>
                          <tr>
                            <th>登録事業</th>
                            <td :colspan="showSisyo ? 1 : 5">
                              {{ item.jigyokbn.split(' : ')[1] }}
                            </td>
                            <th v-if="showSisyo">登録支所</th>
                            <td v-if="showSisyo" colspan="3">
                              {{ item.regsisyo?.split(' : ')[1] }}
                            </td>
                            <th>更新者</th>
                            <td>{{ item.updusernm }}</td>
                            <th>更新日時</th>
                            <td>
                              {{ getSimpleDateHmsJpText(new Date(item.upddttm)) }}
                            </td>
                          </tr>
                          <tr>
                            <th>
                              メモ
                              <div class="show_count_box">
                                {{ `${item.memo.length} / 2000` }}
                              </div>
                            </th>
                            <td colspan="9">{{ item.memo }}</td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                    <!--END 編集不可 -->
                  </div>
                </div>
              </template>
              <a-empty v-else :image="Empty.PRESENTED_IMAGE_SIMPLE" class="pt-40 h-108" />
            </a-collapse-panel>
          </a-collapse>
        </a-spin>
      </a-tab-pane>
      <a-tab-pane :key="EditSatatus.Add" tab="新規">
        <div class="flex">
          <a-space>
            <a-button
              type="primary"
              class="btn-round"
              :disabled="!kengen.addflg || addList.length >= 25"
              @click="addRow"
              >行追加</a-button
            >
            <a-button type="primary" class="btn-round" :disabled="!canDelete" @click="deleteRow"
              >行削除</a-button
            >
          </a-space>
        </div>
        <a-collapse active-key="1" accordion class="m-t-1">
          <a-collapse-panel
            key="1"
            header="メモ情報"
            class="h-120 overflow-auto"
            :show-arrow="false"
          >
            <div
              v-for="(item, index) in addList"
              :key="item.key"
              :class="['p-2', { 'bg-editable': currentIndex === index }]"
              @click="selectRow(index)"
            >
              <div class="description-table">
                <a-form ref="addFormRef" :rules="rules" :model="item">
                  <table>
                    <tbody>
                      <tr>
                        <th width="9%">
                          <div class="flex w-full">
                            件名
                            <div class="m-l-auto c-gray-3">
                              {{ `${item.title.length} / 100` }}
                            </div>
                          </div>
                        </th>
                        <td>
                          <a-form-item name="title">
                            <a-input v-model:value="item.title" :maxlength="100" />
                          </a-form-item>
                        </td>
                        <th width="9%">重要度 <span class="request-mark">＊</span></th>
                        <td width="16%">
                          <a-form-item name="juyodo">
                            <ai-select v-model:value="item.juyodo" :options="optionList1" />
                          </a-form-item>
                        </td>
                        <th width="9%">期限日</th>
                        <td width="16%">
                          <a-form-item name="kigenymd">
                            <date-jp
                              :value="item.kigenymd"
                              @change="
                                (v) => (item.kigenymd = v ? dayjs(v).format('YYYY-MM-DD') : '')
                              "
                            />
                          </a-form-item>
                        </td>
                      </tr>
                      <tr>
                        <th>登録事業 <span class="request-mark">＊</span></th>
                        <td :colspan="showSisyo ? 1 : 5">
                          <a-form-item name="jigyokbn">
                            <ai-select v-model:value="item.jigyokbn" :options="optionList2" />
                          </a-form-item>
                        </td>
                        <th v-if="showSisyo" width="9%" class="bg-readonly">登録支所</th>
                        <td v-if="showSisyo" colspan="3">{{ regsisyo }}</td>
                      </tr>
                      <tr>
                        <th style="width: 100px">
                          メモ <span class="request-mark">＊</span>
                          <div class="show_count_box">
                            {{ `${item.memo.length} / 2000` }}
                          </div>
                        </th>
                        <td colspan="8">
                          <a-form-item name="memo">
                            <a-textarea
                              v-model:value="item.memo"
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
          </a-collapse-panel>
        </a-collapse>
      </a-tab-pane>
    </a-tabs>
    <template #footer>
      <div style="float: left">
        <a-button
          type="primary"
          :disabled="editList.length === 0 || !csvoutflg"
          @click="handleExcel"
          >CSV出力</a-button
        >
        <a-button key="submit" class="warning-btn" :disabled="!canSubmit" @click="saveData"
          >登録</a-button
        >
      </div>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watch, computed, nextTick } from 'vue'
import { message, Empty } from 'ant-design-vue'
import type { FormInstance, SelectProps } from 'ant-design-vue'
import { getSimpleDateHmsJpText, judgeValidate } from '@/utils/util'
import { showConfirmModal, showDeleteModal, showSaveModal } from '@/utils/modal'
import {
  C003003,
  CLOSE_CONFIRM,
  ITEM_REQUIRE_ERROR,
  RESEARCH_CONFIRM,
  SAVE_OK_INFO
} from '@/constants/msg'
import { Search, Init, Save } from './service'
import { InitRequest, SearchRequest, AddVM, SearchVM, SaveRequest, LockVM } from './type'
import TD from '@/components/Common/TableTD/index.vue'
import { Judgement } from '@/utils/judge-edited'
import { Rule } from 'ant-design-vue/lib/form'
import { useRoute, useRouter } from 'vue-router'
import { EditSatatus, Enum共通バー番号, Enum名称区分 } from '#/Enums'
import dayjs from 'dayjs'
import emitter from '@/utils/event-bus'
import { getBarKengen } from '@/utils/user'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const atenano = route.query.atenano as string
const visible = ref(false)
//ローディング
const loading = ref(true)
//テンプレート参照
const addFormRef = ref<FormInstance[]>([])
const editFormRef = ref<FormInstance[]>([])
//画面データ編集判断
const editJudge = new Judgement()
const addJudge = new Judgement()
//ページャー
const totalCount = ref(0)
const currentPage = ref(1)
//タブキー
const activeKey_status = ref(EditSatatus.Update) //編集 / 新規
//ビューモデル
const userInfo = ref<CommonBarHeaderBaseVM | null>(null)
const editList = ref<SearchVM[]>([])
const addList = ref<AddVM[]>([])
const currentIndex = ref(-1)
let lockList: LockVM[] = []
const optionList1 = ref<SelectProps['options']>([])
const optionList2 = ref<SelectProps['options']>([])
const regsisyo = ref('')
const showSisyo = ref(false)
let jigyokbns: string[] = []
//項目の設定
const rules = ref<Record<string, Rule[]>>({
  juyodo: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '重要度')
    }
  ],
  jigyokbn: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '登録事業')
    }
  ],
  memo: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'メモ'),
      trigger: ['change', 'blur']
    }
  ]
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限取得
const kengen = computed(() => getBarKengen(Enum共通バー番号.メモ情報))
const canDelete = computed(() => {
  return (
    currentIndex.value >= 0 &&
    (kengen.value.deleteflg || activeKey_status.value === EditSatatus.Add)
  )
})

const canSubmit = computed(() => {
  return kengen.value.deleteflg || kengen.value.updateflg || kengen.value.addflg
})
const csvoutflg = ref(false)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(editList, () => editJudge.setEdited(), { deep: true })
watch(addList, () => addJudge.setEdited(), { deep: true })
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const openModal = async () => {
  visible.value = true
  try {
    await getOptions()
    await getEditlist()
    resetJudgement()
  } catch (error) {
    resetJudgement()
  }
}
const getOptions = async () => {
  const params: InitRequest = {
    kbn1: Enum名称区分.名称,
    kbn2: Enum名称区分.名称,
    kbn3: Enum名称区分.名称,
    patternno: route.query.patternno as string
  }
  const res = await Init(params)
  optionList1.value = res.selectorlist1
  optionList2.value = res.selectorlist2
  showSisyo.value = res.showflg
  regsisyo.value = res.regsisyo
  csvoutflg.value = res.csvoutflg
}
//検索処理
const getEditlist = async () => {
  const wrapper = document.querySelector('#memo_panel')
  loading.value = true
  const params: SearchRequest = {
    atenano,
    pagenum: currentPage.value,
    pagesize: 25,
    patternno: route.query.patternno as string
  }
  const res = await Search(params)
  jigyokbns = res.jigyokbns

  userInfo.value = res.headerinfo
  editList.value = res.kekkalist
  lockList = res.kekkalist.map((item) => {
    return { memoseq: item.memoseq, upddttm: item.upddttm }
  })
  totalCount.value = res.totalrowcount
  loading.value = false
  nextTick(() => {
    editJudge.reset()
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
          loading.value = true
          let saveParams: SaveRequest = {
            atenano,
            addlist: addList.value,
            updlist: editList.value,
            locklist: lockList
          }
          try {
            await Save(saveParams)
            message.success(SAVE_OK_INFO.Msg)
            reset()
            emitter.emit('refreshBar', route.name)
            getEditlist()
          } catch (error) {}
          loading.value = false
        }
      })
    })
    .catch((key) => (activeKey_status.value = key))
}
//画面モード変更
const changeActiveKey_status = (key: EditSatatus) => {
  currentIndex.value = -1
  activeKey_status.value = key
}
//ページ変更
const changePage = async (newPage) => {
  editJudge.judgeIsEdited(async () => {
    currentPage.value = newPage
    await getEditlist()
    editJudge.reset()
  }, RESEARCH_CONFIRM.Msg)
}
//行追加
const addRow = () => {
  activeKey_status.value = EditSatatus.Add
  addList.value.push({
    title: '',
    juyodo: '',
    jigyokbn: '',
    memo: '',
    kigenymd: '',
    key: Symbol()
  })
}
//行選択
const selectRow = (index: number) => {
  currentIndex.value = index
}
//行削除
const deleteRow = () => {
  if (editList.value.length > 0 || addList.value.length > 0) {
    showDeleteModal({
      onOk() {
        if (activeKey_status.value == EditSatatus.Update) {
          editList.value.splice(currentIndex.value, 1)
        } else if (activeKey_status.value == EditSatatus.Add) {
          addList.value.splice(currentIndex.value, 1)
        }
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
  activeKey_status.value = EditSatatus.Update
  addList.value = []
  currentIndex.value = -1
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
        visible.value = false
        reset()
      }
    })
  } else {
    visible.value = false
    reset()
  }
}

//CSV出力
function handleExcel() {
  showConfirmModal({
    content: C003003.Msg.replace('{0}', '帳票出力'),
    onOk: async () => {
      await router.push({ name: 'AWEU00301G' })
      router.push({
        name: 'AWEU00301G',
        query: {
          rptid: '0106',
          outerSearch: 'true',
          宛名番号: atenano,
          メモ事業コード: jigyokbns
        }
      })
      visible.value = false
    }
  })
}

defineExpose({
  open: openModal
})
</script>
<style src="./index.less" scoped></style>
