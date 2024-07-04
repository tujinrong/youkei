<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 各種検診対象者保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.07
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="8" :xxl="6">
            <th>年度</th>
            <TD>{{ yearFormatter(Number($route.query.nendo)) }}</TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="8" :xxl="6">
            <th>宛名番号</th>
            <TD>{{ $route.query.atenano }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>氏名</th>
            <TD class="mincho">{{ header?.name }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>カナ氏名</th>
            <TD>{{ header?.kname }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>性別</th>
            <TD>{{ header?.sex }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>生年月日</th>
            <TD>{{ header?.bymd }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>住民区分</th>
            <TD>{{ header?.juminkbn }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>年齢</th>
            <TD>{{ header?.age }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>年齢計算基準日</th>
            <TD>{{ header?.agekijunymd }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="saveData">登録</a-button>
          <a-button type="primary" @click="forwardList(C001010.Msg)">一覧へ</a-button>
        </a-space>
        <a-space>
          <WarnAlert v-if="header?.keikoku" />
          <close-page />
        </a-space>
      </div>
    </a-card>

    <a-card class="my-2">
      <h4 class="font-bold">減免区分</h4>
      <div class="self_adaption_table max-w-150" :class="{ form: canEdit }">
        <a-row>
          <a-col span="24">
            <th>特定健診</th>
            <td v-if="canEdit">
              <ai-select v-model:value="genmenkbn.tokuteicdnm" :options="selectorlist1"></ai-select>
            </td>
            <TD v-else>{{ genmenkbn.tokuteicdnm }}</TD>
          </a-col>
          <a-col span="24">
            <th>がん検診</th>
            <td v-if="canEdit">
              <ai-select v-model:value="genmenkbn.gancdnm" :options="selectorlist2"></ai-select>
            </td>
            <TD v-else>{{ genmenkbn.gancdnm }}</TD>
          </a-col>
        </a-row>
      </div>
    </a-card>
    <a-card class="my-2" :style="{ marginBottom: height + 8 + 'px' }">
      <div class="flex justify-between items-end my-1">
        <span class="font-bold">対象サイン</span>
        <a-space>
          <a-button type="primary" @click="visible = true">受診拒否設定</a-button>
          <a-button type="primary" @click="searchData">対象サイン再表示</a-button>
        </a-space>
      </div>

      <vxe-table
        :height="Math.max(tableHeight, 400)"
        :loading="tableLoading"
        :column-config="{ resizable: true }"
        :data="tableData"
        :edit-config="{
          trigger: 'click',
          mode: 'row',
          beforeEditMethod({row}) {
            return row.kijunflg && canEdit as boolean
          }
        }"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column field="kensahoho" title="検診種別・検査方法" width="30%"> </vxe-column>
        <vxe-column field="sign1" title="一時対象サイン" width="20%"> </vxe-column>
        <vxe-colgroup title="対象サイン(年齢と受診拒否理由を適用)" align="center">
          <vxe-column
            field="kijunymd"
            title="年齢計算基準日"
            :header-class-name="canEdit ? 'bg-editable' : 'bg-readonly'"
            :class-name="({ row }) => (row.kijunflg ? '' : 'bg-disabled')"
            :edit-render="{ autofocus: 'input' }"
          >
            <template #edit="{ row }: { row: Row2VM }">
              <DateJp v-if="row.kijunflg" v-model:value="row.kijunymd" format="YYYY-MM-DD" />
            </template>
            <template #default="{ row }: { row: Row2VM }">
              {{ row.kijunymd && getDateJpText(new Date(row.kijunymd)) }}
            </template>
          </vxe-column>
          <vxe-column field="age" title="年齢"> </vxe-column>
          <vxe-column
            field="sign2"
            title="対象サイン"
            :class-name="setSignClass"
            :resizable="false"
          >
          </vxe-column>
        </vxe-colgroup>
      </vxe-table>
    </a-card>

    <OperationFooter ref="footerRef" />
    <SetModal v-model:visible="visible" @finish="searchData" />
  </a-spin>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'
import { A000003, C001010, SAVE_OK_INFO } from '@/constants/msg'
import { showInfoModal, showSaveModal } from '@/utils/modal'
import { getDateJpText, yearFormatter } from '@/utils/util'
import { onMounted, ref, reactive, watch, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Init, Save, SearchDetail } from '../service'
import { Row2VM } from '../type'
import { Judgement } from '@/utils/judge-edited'
import SetModal from '@/views/affect/SH/AWSH003/AWSH00303D/index.vue'
import { message } from 'ant-design-vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { useTableHeight } from '@/utils/hooks'
import { useElementSize } from '@vueuse/core'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import dayjs from 'dayjs'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const tableLoading = ref(false)
const visible = ref(false)
const editJudge = new Judgement(route.name as string)
const params = {
  nendo: Number(route.query.nendo),
  atenano: route.query.atenano as string
}

const header = ref<GamenHeaderBase2VM>()
const genmenkbn = reactive({
  tokuteicdnm: '', //特定健診
  gancdnm: '' //がん検診
})
const selectorlist1 = ref<DaSelectorModel[]>([]) //特定健診
const selectorlist2 = ref<DaSelectorModel[]>([]) //がん検診
const tableData = ref<Row2VM[]>([])
//秘密キー
const privkey = ref('')

const canEdit = route.meta.updflg
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
//警告処理
onMounted(async () => {
  await initData()
  //警告メッセージを表示
  if (header.value?.keikoku) {
    showInfoModal({
      type: 'warning',
      content: A000003.Msg.replace('{0}', header.value.keikoku)
    })
  }
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [genmenkbn, tableData.value.map((el) => el.kijunymd)],
  () => editJudge.setEdited(),
  { deep: true }
)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -102)

const footerRef = ref(null)
const { height } = useElementSize(footerRef)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
async function initData() {
  loading.value = true
  try {
    const res = await Init(params)
    if (res.rsaprivatekey) privkey.value = res.rsaprivatekey
    header.value = res.headerinfo
    genmenkbn.tokuteicdnm = res.genmenkbn_tokuteicdnm
    genmenkbn.gancdnm = res.genmenkbn_gancdnm
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
    tableData.value = res.kekkalist
    nextTick(() => editJudge.reset())
  } catch (error) {}
  loading.value = false
}

//検索処理(対象サイン再表示)
async function searchData() {
  tableLoading.value = true
  try {
    tableData.value.forEach((el) => {
      if (!el.kijunymd) {
        el.kijunymd = dayjs().format('YYYY-MM-DD')
      }
    })
    const res = await SearchDetail({
      ...params,
      kekkalist: tableData.value
    })
    tableData.value.forEach((el) => {
      const finditem = res.kekkalist.find(
        (item) => item.jigyocd === el.jigyocd && item.kensahohocd === el.kensahohocd
      )
      if (finditem) {
        el.age = finditem.age
        el.sign2 = finditem.sign2
      }
    })
    editJudge.setEdited()
  } catch (error) {}
  tableLoading.value = false
}

//保存処理
function saveData() {
  showSaveModal({
    onOk: async () => {
      try {
        await Save({
          atenano: route.query.atenano as string,
          genmenkbn_tokuteicdnm: genmenkbn.tokuteicdnm,
          genmenkbn_gancdnm: genmenkbn.gancdnm
        })
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        forwardList()
      } catch (error) {}
    }
  })
}

function setSignClass({ row }) {
  const signs = {
    対象外: 'c-red6',
    対象: 'c-blue6',
    不明: 'c-green6'
  }
  return signs[row.sign2]
}

//遷移処理(一覧へ)
function forwardList(msg?) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string
    })
  }, msg)
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
:deep(.vxe-body--column.col--actived) {
  .vxe-cell {
    padding: 0 2px;
  }
}
</style>
