<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 妊産婦情報管理-届出情報
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.02
 * 作成者　　: gaof
 * 変更履歴　:
 * ---------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <div class="info_content">
      <a-row>
        <a-col :md="12" :xl="8" :xxl="6">
          <a-select
            v-model:value="filterParams.groupid"
            class="select_style"
            :options="groupidList"
          >
          </a-select>
        </a-col>
        <a-col :md="12" :xl="8" :xxl="6">
          <a-select
            v-model:value="filterParams.groupid2"
            class="select_style"
            :options="groupid2List"
          >
          </a-select>
        </a-col>
        <a-col
          v-if="[page_pat2].includes(props.bhsyosaitabcd)"
          :md="{ span: 12, offset: 12 }"
          :xl="{ span: 8, offset: 0 }"
          :xxl="{ span: 6, offset: 6 }"
          class="right_button"
        >
          <a-button
            v-if="bhsyosaimenyucd === _105 || bhsyosaimenyucd === _111 || bhsyosaimenyucd === _108"
            type="primary"
            @click="Ref_302?.open"
            >費用助成一覧</a-button
          >
        </a-col>
      </a-row>
      <a-row type="flex" justify="left" align="middle">
        <a-col :md="19" :xl="21" :xxl="22" :style="{ height: tableHeight }">
          <vxe-table
            class="mt-2"
            height="100%"
            :column-config="{ resizable: true }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="filterData"
            :sort-config="{ trigger: 'cell', remote: true }"
            :empty-render="{ name: 'NotData' }"
            :edit-config="{
              trigger: 'click',
              mode: 'cell',
              showStatus: false
            }"
            :valid-config="{ showMessage: false }"
          >
            <vxe-column
              field="itemnm"
              title="项目"
              width="250"
              min-width="90"
              class-name="bg-editable"
            >
              <template #default="{ row }">
                {{ row.itemnm }}
                <span v-if="row.hissuflg" class="request-mark"> ＊ </span>
              </template>
            </vxe-column>
            <vxe-column
              v-if="updFlg"
              field="value"
              title="值"
              width="205"
              min-width="110"
              header-class-name="bg-editable"
              :edit-render="{ name: '$select' }"
              :class-name="
                ({ row }) =>
                  row.hissuflg && editJudge.isPageEdited()
                    ? !row.value
                      ? 'bg-errorcell'
                      : ''
                    : checkVal(row)
                    ? 'bg-errorcell'
                    : ''
              "
            >
              <template #edit="{ row }"
                ><a-form-item>
                  <span v-if="Object.values(Itemnm).includes(row.itemnm)">{{ row.value }} </span>
                  <span v-else>
                    <span v-if="row.inputflg">
                      <span v-if="row.inputtypekbn === Enum入力タイプ.日付_年月日">
                        <DateJp v-model:value="row.value" format="YYYY-MM-DD" />
                      </span>
                      <span v-else-if="row.inputkbn === Enum画面項目入力.選択">
                        <ai-select v-model:value="row.value" :options="row.cdlist"></ai-select>
                      </span>
                      <span v-else-if="row.itemnm === '助成金額（総額）'">
                        {{ row.value }}
                      </span>
                      <span v-else>
                        <a-input
                          v-model:value="row.value"
                          :maxlength="row.keta1"
                          allow-clear
                          @change="
                            row.inputkbn === Enum画面項目入力.数値
                              ? (row.value = replaceText(row.value, EnumRegex.半角数字))
                              : ''
                          "
                        />
                      </span>
                    </span>
                    <span v-else>{{ row.value }}</span>
                  </span>
                </a-form-item></template
              >
              <template #default="{ row }">
                <span v-if="Object.values(Itemnm).includes(row.itemnm)"> {{ row.value }}</span>
                <span v-else>
                  <span v-if="row.inputtypekbn === Enum入力タイプ.日付_年月日">
                    {{ getDateJpText(new Date(row.value)) }}
                  </span>
                  <span v-else>
                    {{ row.value }}
                  </span></span
                >
              </template></vxe-column
            >
            <vxe-column
              v-else
              field="value"
              title="值"
              width="205"
              min-width="110"
              header-class-name="bg-editable"
              ><template #default="{ row }">
                <span v-if="Object.values(Itemnm).includes(row.itemnm)"> {{ row.value }}</span>
                <span v-else>
                  <span v-if="row.inputtypekbn === Enum入力タイプ.日付_年月日">
                    {{ getDateJpText(new Date(row.value)) }}
                  </span>
                  <span v-else>{{ row.value }}</span></span
                >
              </template></vxe-column
            >
            <vxe-column field="syokiti" title="初期値" width="140" min-width="90"></vxe-column>
            <vxe-column
              field="hanif"
              title="入力範囲（開始）"
              width="150"
              min-width="90"
            ></vxe-column>
            <vxe-column
              field="hanit"
              title="入力範囲（終了）"
              width="150"
              min-width="90"
            ></vxe-column>
            <vxe-column field="biko" title="備考"></vxe-column>
            <vxe-column
              v-if="[_105, _107, _108, _110, _112].includes(props.bhsyosaimenyucd)"
              field="tt"
              width="80"
              style="width: 30px"
            >
              <template #default="{ row }">
                <a-button
                  v-if="row.inputtypekbn === Enum入力タイプ.医療機関"
                  type="primary"
                  :disabled="!updFlg"
                  @click="searchKikanNM(row.value)"
                  >検索</a-button
                >
              </template>
            </vxe-column>
          </vxe-table>
        </a-col>
      </a-row>
    </div>
    <OrganizeModal v-model:visible="organizeVisible" @select="selectOrganize"></OrganizeModal>
    <AWBH00302D
      ref="Ref_302"
      :bhsyosaimenyucd="bhsyosaimenyucd"
      :bhsyosaitabcd="bhsyosaitabcd"
      :atenano="caseAtenano"
      :torokuno="caseTorokuno"
      :sinseiedano="kaisu"
      @close="getjosei"
      @update="getjoseiList"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, reactive, watch, nextTick } from 'vue'
import {
  FreeItemDispInfoVM,
  SaveRequest,
  FreeItemInfoVM,
  DeleteRequest,
  FixItemDispInfoVM
} from '../type'
import { getHeight } from '@/utils/height'
import { useRouter, useRoute } from 'vue-router'
import { VxeTablePropTypes } from 'vxe-table'
import { Form, message } from 'ant-design-vue'
import { SearchSyosai, SearchKikanNM, SearchIshiNM } from '../service'
import { Rule } from 'ant-design-vue/lib/form'
import { Enum入力タイプ, Enum画面項目入力, EnumRegex } from '#/Enums'
import { getDateJpText, replaceText, table2Opts } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { useTableFilter } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import OrganizeModal from '@/views/affect/AF/AWAF00702D/index.vue'
import AWBH00302D from '../page/AWBH00302D/index.vue'
import {
  Itemnm,
  _105,
  _103,
  _110,
  _112,
  _106,
  _107,
  _114,
  _104,
  _108,
  _111,
  page_pat2,
  枝番_0,
  履歴回数_0,
  登录编号连番_0
} from '../constant'

const useForm = Form.useForm
const router = useRouter()
const route = useRoute()
const loading = ref<boolean>(false)
const checkFlg = ref<boolean>(false)
const updFlg = route.meta.updflg
const editJudge = new Judgement(route.name as string)
const organizeVisible = ref(false)
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  bhsyosaimenyucd: string
  bhsyosaitabcd: string
  bosikbn: string
  kaisu: number
}>()
let caseAtenano
let caseTorokuno
const caseTorokunorenban = ref<number>(登录编号连番_0)
let caseEdano = ref<number>(枝番_0)
let caseKaisu = ref<number>(履歴回数_0)
//受診者情報一覧
const tableList = ref<FreeItemDispInfoVM[]>([])
const tableList2 = ref<FreeItemDispInfoVM[]>([])
const saveData = ref<SaveRequest>({
  bosikbn: props.bosikbn,
  bhsyosaimenyucd: props.bhsyosaimenyucd,
  bhsyosaitabcd: props.bhsyosaitabcd,
  atenano: route.query.atenano as string,
  kaisu: caseKaisu.value,
  freeiteminfo: [],
  torokunorenban: caseTorokunorenban.value,
  torokuno: caseTorokuno,
  edano: caseEdano.value,
  checkflg: true,
  fixiteminfo: [],
  jyoseilistinfo: []
})

const filterParams = reactive({
  groupid: '',
  groupid2: ''
})
const { filterData } = useTableFilter(tableList, filterParams)
const groupidList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const groupid2List = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const Ref_302 = ref<InstanceType<typeof AWBH00302D> | null>(null)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  caseAtenano = route.query.atenano as string
  caseTorokuno = route.query.torokuno
  initTorokunorenban()
  groupidList.value = [...groupidList.value, ...props.grouplist1]
  groupid2List.value = [...groupid2List.value, ...props.grouplist2]
  getTableList()
})

watch(tableList, () => editJudge.setEdited(), { deep: true })

// 検索処理
async function getTableList() {
  editJudge.addEvent()
  loading.value = true
  SearchSyosai({
    atenano: route.query.atenano as string,
    torokuno: route.query.torokuno as unknown as number,
    bhsyosaimenyucd: props.bhsyosaimenyucd,
    bhsyosaitabcd: props.bhsyosaitabcd,
    bosikbn: props.bosikbn,
    kaisu: caseKaisu.value,
    torokunorenban: caseTorokunorenban.value,
    edano: caseEdano.value,
    pagesize: 0,
    pagenum: 0
  }).then((res) => {
    tableList2.value = res.fixitemlist
    tableList.value.push(...res.fixitemlist)
    tableList.value.push(...res.freeitemlist)
    sortListByOrderseq()
    nextTick(() => editJudge.reset())
    loading.value = false
  })
}

function sortListByOrderseq() {
  tableList.value.sort((a, b) => a.orderseq - b.orderseq)
}

const getData = () => {
  if (!editJudge.isPageEdited()) {
    return
  }
  saveData.value.torokunorenban = caseTorokunorenban.value
  saveData.value.kaisu = caseKaisu.value
  saveData.value.edano = caseEdano.value
  saveData.value.freeiteminfo = []
  saveData.value.fixiteminfo = []
  //  reset checkFlg
  checkFlg.value = false
  let fixItemNm = extractNames(tableList2.value)
  tableList.value.forEach((item) => {
    if (item.hissuflg && !item.value) {
      //  set checkFlg
      checkFlg.value = true
    }
    const saveItem: FreeItemInfoVM = {
      inputtype: parseInt(String(item.inputtypekbn)),
      item: item.itemcd + ' : ' + item.itemnm,
      value: splitValue(item.value)
    }
    if (fixItemNm.includes(item.itemnm)) {
      saveData.value.fixiteminfo.push(saveItem)
    } else {
      saveData.value.freeiteminfo.push(saveItem)
    }
  })
  return saveData.value
}

function extractNames(list: any[]): string[] {
  return list.map((item) => item.itemnm)
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

const initTorokunorenban = () => {
  if ([_103, _104].includes(props.bhsyosaimenyucd)) {
    caseTorokunorenban.value = props.kaisu
  } else if ([_105, _106].includes(props.bhsyosaimenyucd)) {
    caseKaisu.value = props.kaisu
    if ([page_pat2].includes(props.bhsyosaitabcd)) {
      caseKaisu.value = 履歴回数_0
      caseEdano.value = props.kaisu
    }
  } else {
    caseEdano.value = props.kaisu
  }
}

const searchKikanNM = async (val) => {
  if (!val) {
    return
  }
  await SearchKikanNM({
    kikancd: val,
    pagesize: 0,
    pagenum: 0
  }).then((res) => {
    const temp = tableList.value.find(
      (item) => item.inputtypekbn === Enum入力タイプ.医療機関
    ) as FreeItemDispInfoVM
    temp.value = res.KikanNM
  })
}

//せんたく医療機関
const selectOrganize = (val) => {
  const temp = tableList.value.find(
    (item) => item.inputtypekbn === Enum入力タイプ.医療機関
  ) as FreeItemDispInfoVM
  temp.value = val.kikancd
}

const getCheck = () => {
  return checkFlg.value
}

const getjosei = (val) => {
  const temp = tableList.value.find(
    (item) => item.itemnm === '助成金額（総額）'
  ) as FreeItemDispInfoVM
  temp.value = val
}

const getjoseiList = (val) => {
  editJudge.setEdited()
  saveData.value.jyoseilistinfo = []
  saveData.value.jyoseilistinfo = val
}

const checkVal = (row: FreeItemDispInfoVM): boolean => {
  if (!(row.inputkbn === Enum画面項目入力.数値)) {
    return false
  }
  if (!row.value) {
    return false
  }
  checkFlg.value = false
  if (!(row.hanit && row.hanif)) {
    return false
  } else if (!(row.hanif || row.value >= row.hanif) && (row.hanit || row.value <= row.hanit)) {
    checkFlg.value = true
    return true
  } else {
    checkFlg.value = false
    return false
  }
}

defineExpose({
  getData,
  getCheck
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => {
  let screenHeight = window.innerHeight
  let computeHeight = 0
  if (screenHeight >= 800) {
    computeHeight = 430
  } else {
    computeHeight = 180
  }
  return getHeight(computeHeight)
})
</script>
<style src="../index.less" scoped></style>
