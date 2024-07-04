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
    <div :class="[_104, _107].includes(props.bhsyosaimenyucd) ? '' : 'info_detail'">
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
        </a-row>
        <a-row type="flex" justify="left" align="middle">
          <a-col :md="22" :xl="22" :xxl="22" :style="{ height: tableHeight }">
            <vxe-table
              class="mt-2"
              height="100%"
              :column-config="{ resizable: true }"
              :row-config="{ isCurrent: true, isHover: true }"
              :data="filterData"
              :sort-config="{ trigger: 'cell', remote: true }"
              :empty-render="{ name: 'NotData' }"
              :edit-rules="tableRules"
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
              <vxe-column field="syokiti" title="初期値" width="125" min-width="90"></vxe-column>
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
                v-if="[_101, _108, _109, _111].includes(props.bhsyosaimenyucd)"
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
                  <a-button
                    v-else-if="row.inputtypekbn === Enum入力タイプ.事業従事者"
                    :disabled="!updFlg"
                    type="primary"
                    @click="searchIshiNM(row.value)"
                    >検索</a-button
                  >
                </template>
              </vxe-column>
            </vxe-table>
          </a-col>
        </a-row>
      </div>
    </div>
    <OrganizeModal v-model:visible="organizeVisible" @select="selectOrganize"></OrganizeModal>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, reactive, watch, nextTick } from 'vue'
import { FreeItemDispInfoVM, SaveRequest, FreeItemInfoVM } from '../type'
import { getHeight } from '@/utils/height'
import { useRouter, useRoute } from 'vue-router'
import { VxeTablePropTypes } from 'vxe-table'
import { SearchSyosai, SearchKikanNM, SearchIshiNM } from '../service'
import { Enum入力タイプ, Enum画面項目入力, EnumRegex } from '#/Enums'
import { getDateJpText, replaceText, table2Opts } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { useTableFilter } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import {
  _107,
  _104,
  _108,
  _109,
  _111,
  _113,
  Itemnm,
  _101,
  登录编号连番_0,
  枝番_0
} from '../constant'
import OrganizeModal from '@/views/affect/AF/AWAF00702D/index.vue'

const router = useRouter()
const route = useRoute()
const loading = ref<boolean>(false)
const checkFlg = ref<boolean>(false)
const updFlg = route.meta.updflg
const editJudge = new Judgement(route.name as string)
const organizeVisible = ref(false)
let caseTorokuno
const props = defineProps<{
  grouplist1: DaSelectorModel[]
  grouplist2: DaSelectorModel[]
  bhsyosaimenyucd: string
  bhsyosaitabcd: string
  bosikbn: string
  kaisu: number
}>()
//受診者情報一覧
const tableList = ref<FreeItemDispInfoVM[]>([])
const tableList2 = ref<FreeItemDispInfoVM[]>([])

const saveData = ref<SaveRequest>({
  bosikbn: props.bosikbn,
  bhsyosaimenyucd: props.bhsyosaimenyucd,
  bhsyosaitabcd: props.bhsyosaitabcd,
  atenano: route.query.atenano as string,
  kaisu: props.kaisu,
  freeiteminfo: [],
  torokuno: caseTorokuno,
  checkflg: false,
  torokunorenban: 登录编号连番_0,
  edano: 枝番_0,
  fixiteminfo: [],
  jyoseilistinfo: []
})
//項目の設定
const tableRules = ref({
  // value: [{ required: true }]
} as VxeTablePropTypes.EditRules)
const filterParams = reactive({
  groupid: '',
  groupid2: ''
})
const { filterData } = useTableFilter(tableList, filterParams)
const groupidList = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
const groupid2List = ref<DaSelectorModel[]>([{ label: 'すべて', value: '' }])
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  groupidList.value = [...groupidList.value, ...props.grouplist1]
  groupid2List.value = [...groupid2List.value, ...props.grouplist2]
  getTableList()
  caseTorokuno = route.query.torokuno
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
    kaisu: props.kaisu,
    bosikbn: props.bosikbn,
    torokunorenban: 登录编号连番_0,
    edano: 枝番_0,
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

const getData = () => {
  if (!editJudge.isPageEdited()) {
    return
  }
  saveData.value.freeiteminfo = []
  saveData.value.fixiteminfo = []
  checkFlg.value = false
  let fixItemNm = extractNames(tableList2.value)
  tableList.value.forEach((item) => {
    if (item.hissuflg && !item.value) {
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

function sortListByOrderseq() {
  tableList.value.sort((a, b) => a.orderseq - b.orderseq)
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

const getCheck = () => {
  return checkFlg.value
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

const searchIshiNM = async (val) => {
  if (!val) {
    return
  }
  await SearchIshiNM({
    staffid: val,
    pagesize: 0,
    pagenum: 0
  }).then((res) => {
    const temp = tableList.value.find(
      (item) => item.inputtypekbn === Enum入力タイプ.事業従事者
    ) as FreeItemDispInfoVM
    temp.value = res.ishinm
  })
}

//せんたく医療機関
const selectOrganize = (val) => {
  const temp = tableList.value.find(
    (item) => item.itemnm === '医療機関コード'
  ) as FreeItemDispInfoVM
  temp.value = val.kikancd
  const temp2 = tableList.value.find((item) => item.itemnm === '医療機関名') as FreeItemDispInfoVM
  temp2.value = val.kikannm
  //   tableList.value[currentIndex.value][medicalId.value + ''] = val.kikannm
  const temp3 = tableList.value.find(
    (item) => item.itemnm === '医療機関名（その他）'
  ) as FreeItemDispInfoVM
  temp3.value = val.kanakikannm
  const temp4 = tableList.value.find((item) => item.itemnm === '医療機関住所') as FreeItemDispInfoVM
  temp4.value = val.adrsfull
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
