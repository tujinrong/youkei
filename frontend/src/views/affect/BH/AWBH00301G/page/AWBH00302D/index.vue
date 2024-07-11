<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 費用助成一覧
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.05.22
 * 作成者　　: 張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    title="費用助成一覧"
    width="1200px"
    :closable="true"
    :mask-closable="false"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <div class="self_adaption_table">
        <a-row>
          <a-col span="6">
            <th>宛名番号</th>
            <TD>{{ $route.query.atenano }}</TD>
          </a-col>
          <a-col span="6">
            <th>氏名</th>
            <TD>{{ headerinfo?.name }}</TD>
          </a-col>
          <a-col span="6">
            <th>登録番号</th>
            <TD>{{ headerinfo?.torokuno }}</TD>
          </a-col>
          <a-col span="6">
            <th>申請日</th>
            <TD>{{ headerinfo?.sinseiymd }}</TD>
          </a-col>
        </a-row>
      </div>
      <a-card class="mt-4">
        <a-space>
          <a-button class="btn-round" type="primary" :disabled="!updFlg" @click="addRow"
            >行追加</a-button
          >
          <a-button class="btn-round" type="primary" :disabled="!canDelete" @click="deleteRow"
            >行削除</a-button
          >
        </a-space>
        <div class="mt-4" :style="{ height: '410px' }">
          <vxe-table
            ref="xTableRef"
            height="100%"
            :header-cell-style="{ backgroundColor: '#ffffe1' }"
            :mouse-config="{ selected: true }"
            :column-config="{ resizable: true }"
            :sort-config="{ trigger: 'cell' }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="tableList"
            :empty-render="{ name: 'NotData' }"
            :edit-config="{
              trigger: 'click',
              mode: 'cell',
              showStatus: false
            }"
          >
            <vxe-column field="no" title="No." width="120" min-width="80"> </vxe-column>
            <vxe-column
              field="joseikensyurui"
              title="助成券種類"
              :edit-render="{ name: '$select' }"
            >
              <template #edit="{ row }">
                <a-form-item>
                  <ai-select
                    v-model:value="row.joseikensyurui"
                    :options="joseikensyuruiOptions"
                    style="width: 100%"
                    @change="setMax(row)"
                  ></ai-select>
                </a-form-item>
              </template>
              <template #default="{ row }">
                {{ row.joseikensyurui }}
              </template>
            </vxe-column>
            <vxe-column
              field="jusinymd"
              title="受診年月日"
              :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            >
              <template #edit="{ row }">
                <DateJp v-model:value="row.jusinymd" format="YYYY-MM-DD" />
                ></template
              >
              <template #default="{ row }">
                {{ getDateJpText(new Date(row.jusinymd)) }}
              </template>
            </vxe-column>
            <vxe-column
              field="siharaikingaku"
              title="支払金額"
              :edit-render="{ autofocus: 'input', autoselect: true }"
              formatter="localeNum"
              ><template #edit="{ row }">
                <a-input-number
                  v-model:value="row.siharaikingaku"
                  class="w-full"
                  :precision="0"
                  :min="0"
                  :max="99999"
                />
              </template>
            </vxe-column>
            <vxe-column
              field="joseikingaku"
              title="助成金額"
              :edit-render="{ autofocus: 'input', autoselect: true }"
              formatter="localeNum"
              ><template #edit="{ row }"
                ><a-input-number
                  v-model:value="row.joseikingaku"
                  class="w-full"
                  :precision="0"
                  :min="0"
                  :max="row.joseikingakulimit"
              /></template>
            </vxe-column>
            <vxe-column field="joseikingakulimit" title="助成金額（限度額）" min-width="80" />
          </vxe-table>
        </div>
        <div style="width: 800px; margin-left: 835px">
          <div class="self_adaption_table" style="padding-top: 10px">
            <a-row>
              <a-col span="8">
                <th>助成金額（総額）</th>
                <TD>{{ joseikingakusogaku }}</TD>
              </a-col>
            </a-row>
          </div>
        </div>
      </a-card>
    </a-spin>
    <template #footer>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watch, computed, onMounted, nextTick, watchEffect } from 'vue'
import { message, Empty } from 'ant-design-vue'
import type { FormInstance } from 'ant-design-vue'
import { getDateJpText, judgeValidate, getLabelByValue } from '@/utils/util'
import { showSaveModal, showDeleteModal, showConfirmModal } from '@/utils/modal'
import { DELETE_OK_INFO, SAVE_OK_INFO, CLOSE_CONFIRM } from '@/constants/msg'
import { SearchJyoseiList, SaveJyosei, InitList } from './service'
import {
  JyoseiHeaderInfoVM,
  JyoseiListInfoVM,
  JyoseiFooterInfoVM,
  SearchJyoseiListRequest
} from './type'
import { VxeTableInstance, VxeTablePropTypes, VXETable } from 'vxe-table'
import TD from '@/components/Common/TableTD/index.vue'
import { Judgement } from '@/utils/judge-edited'
import { Rule } from 'ant-design-vue/lib/form'
import { useRoute, useRouter } from 'vue-router'
import DateJp from '@/components/Selector/DateJp/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const visible = ref(false)
const updFlg = route.meta.updflg as boolean
const delFlg = route.meta.delflg as boolean
const addFlg = route.meta.addflg as boolean
//ローディング
const loading = ref(true)
//画面データ編集判断
const editJudge = new Judgement()
//ビューモデル
const headerinfo = ref<JyoseiHeaderInfoVM>()
const tableList = ref<JyoseiListInfoVM[]>([])
const joseikingakusogaku = ref(0)
const joseikensyuruiOptions = ref<DaSelectorModel[]>([]) // 助成券種類Options
const maxjosei = ref(0)
const kingakulimitlist = ref<DaSelectorModel[]>([]) // 助成上限額リスト
const xTableRef = ref<VxeTableInstance>()
//ビューモデル
const currentRow = ref<JyoseiListInfoVM | null>(null)
const props = defineProps<{
  bhsyosaimenyucd: string
  bhsyosaitabcd: string
  atenano: string
  torokuno: string
  sinseiedano: number
}>()
//現在行
watchEffect(() => {
  currentRow.value = xTableRef.value?.getCurrentRecord()
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
// watch(tableList, () => editJudge.setEdited(), { deep: true })
watch(tableList, () => getTotal(), { deep: true })
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const openModal = async () => {
  visible.value = true
  try {
    await init()
    await getList()
  } catch (error) {}
}

//初期化処理
async function init() {
  InitList({
    bhsyosaimenyucd: props.bhsyosaimenyucd,
    bhsyosaitabcd: props.bhsyosaitabcd,
    sinseiedano: props.sinseiedano,
    pagesize: 0,
    pagenum: 0,
    bosikbn: '1'
  }).then((res) => {
    joseikensyuruiOptions.value = res.kensyuruilist
    kingakulimitlist.value = res.kingakulimitlist
  })
}

//検索処理
async function getList() {
  loading.value = true
  editJudge.addEvent()
  SearchJyoseiList({
    atenano: route.query.atenano as string,
    bhsyosaimenyucd: props.bhsyosaimenyucd,
    bhsyosaitabcd: props.bhsyosaitabcd,
    sinseiedano: props.sinseiedano,
    torokuno: parseInt(props.torokuno),
    pagesize: 0,
    pagenum: 0,
    bosikbn: '1'
  }).then((res) => {
    tableList.value = res.jyoseilist
    headerinfo.value = res.headerinfo
    joseikingakusogaku.value = res.footerinfo.joseikingakusogaku
    nextTick(() => editJudge.reset())
    loading.value = false
  })
}

async function deleteData() {
  try {
    showDeleteModal({
      onOk: async () => {
        // router.push({ name: route.name as string, query: { refresh: '1' } })
      }
    })
  } catch (err) {
  } finally {
  }
}

//行削除フラグ取得
const canDelete = computed(() => {
  //削除権限がある場合、行削除可能
  if (delFlg) return Boolean(currentRow.value)
  //削除権限がない場合、新規データのみ削除可能
  return Boolean(currentRow.value)
})

// 计算助成金額（総額）
const totalJoseikingaku = () => {
  return tableList.value.reduce((total, item) => {
    const amount =
      typeof item.joseikingaku === 'string' ? parseFloat(item.joseikingaku) : item.joseikingaku

    return total + (isNaN(amount) ? 0 : amount)
  }, 0)
}

const getTotal = () => {
  joseikingakusogaku.value = totalJoseikingaku()
}

const setMax = (val: JyoseiListInfoVM) => {
  let selt = splitValue(val.joseikensyurui)
  kingakulimitlist.value.forEach((item) => {
    if (item.value === selt) {
      val.joseikingaku = 0
      val.joseikingakulimit = Number(item.label)
    }
  })
}

//行追加
const addRow = () => {
  if (tableList.value.length >= 24) {
    return
  }
  let newNo
  if (tableList.value.length > 0) {
    newNo = parseInt(tableList.value[tableList.value.length - 1].no)
    newNo = newNo + 1
  } else {
    newNo = 1
  }
  tableList.value.push({
    no: newNo,
    joseikensyurui: '',
    jusinymd: '',
    siharaikingaku: 0,
    joseikingaku: 0,
    joseikingakulimit: 0
  })
}

//行削除
const deleteRow = () => {
  showDeleteModal({
    onOk() {
      const $table = xTableRef.value
      if ($table) {
        const currentIndex = $table.getRowIndex(currentRow.value)
        tableList.value.splice(currentIndex, 1)
        tableList.value.forEach((item, index) => {
          item.no = (index + 1).toString() // no を新しいインデックス値にリセットします
        })
      }
    }
  })
}

const show = (val) => {
  console.log(val)
}

function splitValue(val) {
  let temp = val
  temp = String(temp)
  if (temp.includes(' : ')) {
    return temp.split(' : ')[0].trim()
  } else {
    return val
  }
}
//リセット
function reset() {
  tableList.value = []
  nextTick(() => editJudge.reset())
}

const emit = defineEmits(['close', 'update'])
const close = () => {
  emit('close', joseikingakusogaku.value)
  emit('update', tableList.value)
}

//閉じるボタン(×を含む)
const closeModal = () => {
  close()
  reset()
  visible.value = false
}
defineExpose({
  open: openModal
})
</script>
<style src="./index.less" scoped>
._right {
  padding-top: 10px;
  /* display: flex; */
  border: 1px solid #ccc;
}

._right th {
  width: 130px;
}

._right td {
  width: 230px;
}

.jodiv {
  width: 800px;
  margin-left: 835px;
}
</style>
