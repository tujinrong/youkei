<template>
  <div ref="headRef">
    <a-card v-if="!isHiddenCondition" :bordered="false">
      <div class="rptbiko">帳票説明</div>
      <div class="mt-2">
        <span class="ml-5">{{ form.rptbiko }}</span>
        <span v-if="permissionsInfo.updateflg" style="color: #8400ff">(更新あり)</span>
      </div>
    </a-card>

    <a-card :bordered="false" style="margin-top: 8px">
      <div
        v-if="!isHiddenCondition && form.tyusyutupanelflg"
        class="self_adaption_table mb-5"
        :class="!hasOuterTyusyutu && isSearch && 'form'"
      >
        <div style="font-weight: bold" class="pl-4">抽出条件</div>
        <a-row>
          <a-col span="12">
            <th class="required">抽出対象</th>
            <TD v-if="hasOuterTyusyutu || !isSearch">
              {{ getLabelByValue(tyusyutuinfo.tyusyututaisyocd, form.tyusyututaisyolist) }}</TD
            >
            <td v-else>
              <ai-select
                v-model:value="tyusyutuinfo.tyusyututaisyocd"
                :options="form.tyusyututaisyolist"
                split-val
                @change="onChangeTyusyutaisyocd"
              />
            </td>
          </a-col>
          <a-col v-if="form.tyusyutukbnlist.length > 0" span="12">
            <th class="required">帳票出力区分</th>
            <td v-if="isSearch">
              <ai-select
                v-model:value="tyusyutuinfo.tyusyutukbn"
                :options="computed_list2"
                split-val
                @change="getYosikiInfo"
              />
            </td>
            <TD v-else> {{ getLabelByValue(tyusyutuinfo.tyusyutukbn, computed_list2) }}</TD>
          </a-col>
          <a-col v-if="showNendo" span="12">
            <th class="required">年度</th>
            <TD v-if="hasOuterTyusyutu || !isSearch"> {{ yearFormatter(+tyusyutuinfo.nendo) }}</TD>
            <td v-else>
              <YearJp
                v-model:value="tyusyutuinfo.nendo"
                :disabled="disabled_nendo"
                @change="tyusyutuinfo.tyusyutunaiyo = ''"
              />
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">抽出内容</th>
            <TD v-if="hasOuterTyusyutu"> {{ route.query.tyusyutunaiyonm }}</TD>
            <TD v-else-if="!isSearch">
              {{ getLabelByValue(tyusyutuinfo.tyusyutunaiyo, computed_list1) }}</TD
            >
            <td v-else>
              <ai-select
                v-model:value="tyusyutuinfo.tyusyutunaiyo"
                :options="computed_list1"
                split-val
              />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :xl="6">
            <th class="bg-readonly">抽出人数</th>
            <TD> {{ atenanocnt }}</TD>
          </a-col>
          <a-col :md="12" :xl="6">
            <th class="bg-readonly">登録日時</th>
            <TD> {{ regdttm }}</TD>
          </a-col>
        </a-row>
      </div>

      <div v-if="!isHiddenCondition" style="font-weight: bold" class="pl-4">検索条件</div>
      <div v-if="isSearch && !isHiddenCondition" class="self_adaption_table form">
        <a-row v-if="form.kensakujyokenlist1.length > 0">
          <template v-for="item in form.kensakujyokenlist1" :key="item.jyokenid">
            <a-col v-show="Number(item.jyokenkbn) !== Enum検索条件区分.固定条件" v-bind="layout">
              <th
                style="min-width: 120px"
                :title="item.jyokenlabel"
                :class="[String(item.jyokenid) === yosikihimonm ? 'rect2' : '', 'conditions-item']"
              >
                <span>{{ item.jyokenlabel }}</span>
                <span v-if="item.hissuflg" class="request-mark">＊</span>
              </th>
              <td>
                <Selector
                  v-model:value="item.value"
                  :type="item.controlkbn!"
                  :max="item.nendomax"
                  :options="item.selectorlist"
                  :ids="{
                    rptid,
                    jyokenlabel: item.jyokenlabel,
                    targetitemseq: item.targetitemseq
                  }"
                  :disabled="item.disabled"
                  @set-options="(val) => setOtherOptions(val, toRef(form, 'kensakujyokenlist1'))"
                />
              </td>
            </a-col>
          </template>
        </a-row>
      </div>
      <div v-if="!isSearch && !isHiddenCondition" class="self_adaption_table">
        <a-row v-if="form.kensakujyokenlist1.length > 0">
          <template v-for="item in form.kensakujyokenlist1" :key="item.jyokenlabel">
            <a-col v-show="Number(item.jyokenkbn) !== Enum検索条件区分.固定条件" v-bind="layout">
              <th style="width: 150px" :title="item.jyokenlabel" class="conditions-item">
                {{ item.jyokenlabel }}
              </th>
              <TD>
                <span v-if="item.controlkbn === Enumコントロール.複数選択">
                  {{ getMultipleLabel(item.value ?? [], item.selectorlist) }}
                </span>
                <span v-else-if="item.controlkbn === Enumコントロール.選択">
                  {{ getLabelByValue(item.value, item.selectorlist) }}
                </span>
                <span
                  v-else-if="
                    [
                      Enumコントロール.数値範囲,
                      Enumコントロール.文字範囲,
                      Enumコントロール.日付範囲,
                      Enumコントロール.時間範囲
                    ].includes(Number(item.controlkbn))
                  "
                  >{{ getValue(item.value) }}</span
                >
                <span v-else-if="item.controlkbn === Enumコントロール.論理値">
                  {{ item.value === true ? '該当' : item.value === false ? '非該当' : '' }}
                </span>
                <span v-else-if="item.controlkbn === Enumコントロール.年度">{{
                  yearFormatter(item.value)
                }}</span>
                <span v-else>{{ item.value }}</span>
              </TD>
            </a-col></template
          >
        </a-row>
      </div>
      <div v-if="!isHiddenCondition" class="self_adaption_table form my-5">
        <div style="font-weight: bold" class="pl-4">検索条件以外</div>
        <a-row>
          <a-col v-for="(item, index) in form.kensakujyokenlist2" :key="index" v-bind="layout">
            <th style="min-width: 120px" :title="item.jyokenlabel" class="conditions-item">
              <span>{{ item.jyokenlabel }}</span>
              <span v-if="item.hissuflg" class="request-mark">＊</span>
            </th>
            <td>
              <Selector
                v-model:value="item.value"
                :type="item.controlkbn!"
                :options="item.selectorlist"
                :ids="{ rptid, jyokenlabel: item.jyokenlabel, targetitemseq: item.targetitemseq }"
                :disabled="item.disabled"
                @set-options="(val) => setOtherOptions(val, toRef(form, 'kensakujyokenlist2'))"
              />
            </td>
          </a-col>
        </a-row>
      </div>

      <div class="m-t-1 header_operation btn-group">
        <a-space>
          <a-button v-if="isSearch" type="primary" :disabled="!form.atenaflg" @click="handleSearch"
            >検索</a-button
          >
          <a-button v-else type="primary" @click="getTableListAgain">再検索</a-button>
          <a-button
            type="primary"
            :disabled="!(form.atenaflg && RequiredIsAllSet)"
            :style="searchDrawerRef?.hasCondition && { filter: 'hue-rotate(60deg)' }"
            @click="searchDrawerRef?.showDrawer"
            >詳細検索
            <span v-if="searchDrawerRef?.hasCondition">☆</span>
          </a-button>
          <a-button type="primary" @click="() => (resumeVisible = true)">出力履歴</a-button>
          <a-button type="primary" @click="goListPpage">一覧へ</a-button>
          <a-button type="primary" :disabled="isSearch" @click="() => (visible = true)"
            >警告・発行対象外</a-button
          >
        </a-space>
        <a-button
          style="margin-left: auto; margin-right: 10px"
          type="primary"
          @click="isHiddenCondition = !isHiddenCondition"
        >
          <template #icon>
            <ArrowUpOutlined v-if="!isHiddenCondition" />
            <ArrowDownOutlined v-else />
          </template>
        </a-button>
        <close-page></close-page>
      </div>
    </a-card>
  </div>
  <a-card class="my-2">
    <div>
      <div class="setting-text">出力内容設定</div>
      <div class="self_adaption_table form" :class="isSearch">
        <a-row :gutter="[10, 10]">
          <a-col :sm="24" :md="12" :xl="9" :xxl="7">
            <th class="required">出力様式</th>
            <td>
              <ai-select
                v-model:value="form.style"
                split-val
                :options="styleList"
                @change="onChangeStyle"
              ></ai-select>
            </td>
          </a-col>

          <a-col :md="24" :xl="15" :xxl="9" push="1">
            <a-space>
              <a-checkbox
                v-model:checked="form.hakusiflg"
                :disabled="hakusiDisable"
                class="min-w-16"
                >白紙</a-checkbox
              >
              <a-button
                type="primary"
                :disabled="!isEnabledCSV || csvDisable"
                @click="openOutput(ExportType.CSV)"
                >CSV</a-button
              >
              <a-button
                type="primary"
                :disabled="!isEnabledExcel"
                @click="openOutput(ExportType.EXCEL)"
                >EXCEL</a-button
              >
              <a-button type="primary" :disabled="!isEnabledPDF" @click="openOutput(ExportType.PDF)"
                >PDF</a-button
              >
              <a-button
                type="primary"
                class="ml-9"
                :disabled="!isEnabledCSV && !isEnabledExcel && !isEnabledPDF"
                @click="memoVisible = true"
                >条件メモ</a-button
              >
              <a-button
                type="primary"
                :disabled="!(Number(form.yosikisyubetsu) == Enum様式種別.一覧表) || !form.style"
                @click="outVisible = true"
                >出力順登録</a-button
              >
            </a-space>
          </a-col>
          <a-col :md="24" :xl="24" :xxl="8" style="display: flex; justify-content: flex-end">
            <a-pagination
              v-model:current="pageParams.pagenum"
              v-model:page-size="pageParams.pagesize"
              :total="totalCount"
              :page-size-options="$pagesizes"
              show-less-items
              show-size-changer
              class="text-end"
            />
          </a-col>
        </a-row>
      </div>

      <div class="m-t-1 header_operation"></div>
    </div>
    <vxe-table
      v-if="form.atenaflg"
      ref="xTableRef"
      :height="Math.max(bodyHeight, 400)"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :sort-config="{ trigger: 'cell' }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column width="50">
        <template #default="{ row }">
          <a-checkbox v-model:checked="row.formflg" @change="handleSelectflg"></a-checkbox>
        </template>
      </vxe-column>
      <vxe-column
        key="workseq"
        field="workseq"
        title="workId"
        :visible="false"
        min-width="50"
      ></vxe-column>
      <vxe-column key="atenano" field="atenano" title="宛名番号" min-width="130"></vxe-column>
      <vxe-column
        key="simei_yusen"
        field="simei_yusen"
        title="氏名"
        min-width="200"
        class-name="mincho"
        header-class-name="mincho"
      ></vxe-column>
      <vxe-column key="sex" field="sex" title="性別" min-width="50"></vxe-column>
      <vxe-column key="bymdhyoki" field="bymdhyoki" title="生年月日" min-width="130"></vxe-column>
      <vxe-column key="gyoseikunm" field="gyoseikunm" title="行政区" min-width="200"></vxe-column>
      <vxe-column key="juminkbn" field="juminkbn" title="住民区分" min-width="50"></vxe-column>
      <vxe-column
        key="taisyogairiyu"
        field="taisyogairiyu"
        title="帳票発行対象外者"
        min-width="150"
      ></vxe-column>
      <vxe-column
        key="warningtext"
        field="warningtext"
        title="警告内容"
        min-width="200"
        :resizable="false"
      ></vxe-column>
    </vxe-table>
  </a-card>
  <PreviewModal v-model:visible="previewVisible" :params="previewParams" />

  <DetailSearchDrawer ref="searchDrawerRef" :data="form.detailjyokenlist" />

  <ExportHistory
    v-model:visible="resumeVisible"
    v-model:kensakujyokenlist1="form.kensakujyokenlist1"
    v-bind="{ rptid, yosikiid: form.style, isSearch }"
  />
  <WarningModal
    v-model:visible="visible"
    v-bind="{
      tyusyutuinfo,
      searchDrawerRef,
      rptid,
      yosikiid: form.style,
      kensakujyokenlist1: form.kensakujyokenlist1,
      workseq
    }"
    @get-table-list="getTableList"
  />
  <ExportCSVModal
    v-model:visible="csvVisible"
    v-bind="{
      tyusyutuinfo,
      searchDrawerRef,
      rptid,
      yosikiid: form.style,
      jyokenlist: [
        ...(Array.isArray(form.kensakujyokenlist1) ? form.kensakujyokenlist1 : []),
        ...(Array.isArray(form.kensakujyokenlist2) ? form.kensakujyokenlist2 : [])
      ] as unknown as KensakuJyokenVM[],
      workseq,
      selecteddatalist: tableList?.filter((item) => item.formflg) ?? [],
      name: form.styleName,
      memo: form.memo,
      permissionsInfo
    }"
  />

  <PdfExcelModal
    v-model:visible="excelPDfVisible"
    v-bind="{
      tyusyutuinfo,
      searchDrawerRef,
      exportMethod,
      workseq,
      rptid,
      yosikiid: form.style,
      hakusiflg: form.hakusiflg,
      name: form.styleName,
      memo: form.memo,
      jyokenlist: [
        ...(Array.isArray(form.kensakujyokenlist1) ? form.kensakujyokenlist1 : []),
        ...(Array.isArray(form.kensakujyokenlist2) ? form.kensakujyokenlist2 : [])
      ]as unknown as KensakuJyokenVM[],
      outputtype: EnumReportType[`${exportMethod}`],
      permissionsInfo,
      atenaflg: form.atenaflg,
      selectedatenanolist: selectedatenanolist
    }"
    @on-preview="onPreview"
  />
  <MemoModal v-model:visible="memoVisible" v-model:memo="form.memo" />
  <OutModal
    v-model:visible="outVisible"
    v-bind="{ rptid, yosikiid: form.style }"
    :edit-judge="editJudge"
  />
</template>

<script setup lang="ts">
import { ref, reactive, onMounted, watch, computed, watchEffect, Ref, toRef } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { ArrowUpOutlined, ArrowDownOutlined } from '@ant-design/icons-vue'
import { VxeTableInstance } from 'vxe-table'
import dayjs from 'dayjs'
import { useTableHeight } from '@/utils/hooks'
import {
  InitDetailResponse,
  AtenaVM,
  YosikiInfo,
  YosikiInfoRequest,
  TargetItemValueVM,
  KensakuJyokenInitVM
} from '../../type'
import { InitDetail, SearchDetail, GetYosikiInfo, ChangeTyusyutunaiyo } from '../../service'
import { SearchWarnings, UpdateWarnCheckbox } from '@/views/affect/EU/AWEU00304D/service'
import { Download } from '@/views/affect/EU/AWEU00303D/service'
import {
  Enum検索条件区分,
  EnumReportType,
  Enumコントロール,
  Enum様式種別,
  Enum通知サイクル
} from '#/Enums'
import { A000008, ITEM_REQUIRE_ERROR, ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { koteiyoshiki, layout } from './constants'
import { GlobalStore } from '@/store'
import TD from '@/components/Common/TableTD/index.vue'
import Selector from '@/views/affect/EU/AWEU00201G/components/Tab4/components/Selector.vue'
import DetailSearchDrawer from './components/DetailSearch.vue'
import ExportHistory from '@/views/affect/EU/AWEU00305D/index.vue'
import WarningModal from '@/views/affect/EU/AWEU00304D/index.vue'
import ExportCSVModal from '@/views/affect/EU/AWEU00302D/index.vue'
import PdfExcelModal from '@/views/affect/EU/AWEU00303D/index.vue'
import MemoModal from './components/MemoModal.vue'
import OutModal from '@/views/affect/EU/AWEU00306D/index.vue'
import { getLabelByValue, getMultipleLabel, yearFormatter } from '@/utils/util'
import { showInfoModal } from '@/utils/modal'
import PreviewModal from './components/PreviewModal.vue'
import { PreviewRequest } from '../../../AWEU00303D/type'
import { Judgement } from '@/utils/judge-edited'
import YearJp from '@/components/Selector/YearJp/index.vue'
enum ExportType {
  CSV = 'CSV',
  EXCEL = 'EXCEL',
  PDF = 'PDF'
}

type formType = InitDetailResponse & {
  style: string
  hakusiflg: boolean
  styleName: string
  memo: string
  yosikisyubetsu: string
}

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight: bodyHeight } = useTableHeight(headRef, -40)
const route = useRoute()
const router = useRouter()
const rptid = route.query.rptid as string
const rptnm = route.query.rptnm as string
const xTableRef = ref<VxeTableInstance>()
const yosikihimonm = ref('')
//ローディング
const isSearch = ref(true)
const isHiddenCondition = ref(false)
const resumeVisible = ref(false)
const visible = ref(false)
//テンプレート参照
const searchDrawerRef = ref<InstanceType<typeof DetailSearchDrawer> | null>(null)
const tableList = ref<AtenaVM[]>([])
const previewVisible = ref(false)
const csvVisible = ref(false)
const csvDisable = ref(false)
const excelPDfVisible = ref(false)
const memoVisible = ref(false)
const outVisible = ref(false)
const exportMethod = ref<ExportType>(ExportType.CSV)
const workseq = ref<number>(-1)
const defaultPermissionsInfo: YosikiInfo = {
  updateflg: false, // 更新フラグ
  pdfflg: false, // PDF出力フラグ
  excelflg: false, // EXCEL出力フラグ
  otherflg: false, // その他出力フラグ
  hakoflg: false, // 帳票発行履歴管理
  tutisyooutflg: false, //通知書出力フラグ
  yosikiid: '', //様式ID
  yosikinm: '', //様式名
  yosikisyubetu: Enum様式種別.一覧表 //様式種別
}
const permissionsInfo = reactive<YosikiInfo>({
  ...defaultPermissionsInfo
})
const editJudge = new Judgement()
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1
})
//出力様式プルダウンリスト
const selectorlist = ref<YosikiInfo[]>([])

const form = reactive<Omit<formType, keyof DaResponseBase>>({
  rptbiko: '', // 帳票説明
  atenaflg: false, // 宛名フラグ
  kensakujyokenlist1: [], // 検索条件
  kensakujyokenlist2: [], // 検索条件以外
  selectorlist: [], // ドロップダウンリスト(様式紐づけ)
  detailjyokenlist: [],
  style: '', // 出力様式
  hakusiflg: false, // 白紙
  styleName: '', // 出力様式名
  memo: '',
  yosikisyubetsu: '',
  tyusyutupanelflg: false, // 抽出パネル表示フラグ
  tyusyututaisyolist: [], // ドロップダウンリスト(抽出対象:抽出対象コード,抽出対象名,通知サイクル)
  tyusyutunaiyolist: [], // ドロップダウンリスト(抽出内容:抽出シーケンス,抽出内容,抽出対象コード_年度)
  tyusyutukbnlist: [] // ドロップダウンリスト(帳票出力区分:区分コード,区分名称,抽出対象コード)
})

const RequiredIsAllSet = computed(() => {
  return [...form.kensakujyokenlist1, ...form.kensakujyokenlist2].every((item) => {
    return (item.hissuflg && (item.value || item.value === 0)) || !item.hissuflg
  })
})

const isEnabledCSV = computed(() =>
  form.atenaflg
    ? !isSearch.value && permissionsInfo.otherflg && !form.hakusiflg
    : permissionsInfo.otherflg && !form.hakusiflg
)
const isEnabledPDF = computed(() =>
  form.atenaflg ? !isSearch.value && permissionsInfo.pdfflg : permissionsInfo.pdfflg
)
const isEnabledExcel = computed(() =>
  form.atenaflg ? !isSearch.value && permissionsInfo.excelflg : permissionsInfo.excelflg
)
const hakusiDisable = computed(() => !isEnabledExcel.value && !isEnabledPDF.value)
const selectedatenanolist = computed(() => {
  let atenanolist: string[] = []
  tableList.value.forEach((e) => {
    if (e.formflg) atenanolist.push(e.atenano)
  })
  return atenanolist
})

//出力様式ドロップリスト
const styleList = computed<DaSelectorModel[]>(
  () =>
    selectorlist.value.map((item) => ({
      label: item.yosikinm,
      value: item.yosikiid
    })) ?? []
)

const hasOuterTyusyutu = Boolean(route.query.tyusyututaisyocd)
const hasOuterSearch = Boolean(route.query.outerSearch)
//--------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  InitDetail({ rptid })
    .then((res) => {
      if (!res.kensakujyokenlist1) {
        Object.assign(form, {
          ...res,
          style: res.selectorlist[0]?.yosikiid ?? '', //出力様式
          styleName: res.selectorlist[0]?.yosikinm ?? '',
          detailjyokenlist: res.detailjyokenlist ?? [],
          yosikisyubetsu: res.selectorlist[0]?.yosikisyubetu ?? ''
        })
        selectorlist.value = res.selectorlist ?? []
        Object.assign(permissionsInfo, res.selectorlist[0])
        form.kensakujyokenlist1 = []
        if (!res.tyusyutukbnlist) form.tyusyutukbnlist = []
        if (res.kensakujyokenlist2) res.kensakujyokenlist2.forEach(processElement)
        else form.kensakujyokenlist2 = []
        return
      }
      //検索条件初期値
      ;[...(res.kensakujyokenlist1 ?? []), ...(res.kensakujyokenlist2 ?? [])].forEach(
        processElement
      )

      //検索条件
      form.kensakujyokenlist1 = res.kensakujyokenlist1
      form.kensakujyokenlist1.forEach((item) => {
        if (item.controlkbn == Enumコントロール.年度) {
          item.value = +item.nendo //初期年度
        }
        watch(
          () => item.value,
          () => {
            onChangeHimoJyoken(String(item.jyokenid), item.value)
          }
        )
      })

      yosikihimonm.value = res.yosikihimonm ?? ''
      //様式紐づけ検索条件
      const foundElement = form.kensakujyokenlist1.find(
        (el) => String(el.jyokenid) == yosikihimonm.value
      )
      Object.assign(form, {
        ...res,
        style: foundElement ? '' : res.selectorlist[0]?.yosikiid ?? '', //出力様式
        styleName: foundElement ? '' : res.selectorlist[0]?.yosikinm ?? '',
        detailjyokenlist: res.detailjyokenlist ?? [],
        yosikisyubetsu: res.selectorlist[0]?.yosikisyubetu ?? ''
      })
      //出力様式プルダウンリスト
      if (!foundElement) {
        selectorlist.value = res.selectorlist ?? []
      }
      //出力バッター
      if (!form.atenaflg) Object.assign(permissionsInfo, res.selectorlist[0])
    })
    .finally(() => {
      if (hasOuterTyusyutu) {
        //抽出パネル
        atenanocnt.value = route.query.atenanocnt as string
        regdttm.value = route.query.regdttm as string
        Object.assign(tyusyutuinfo, route.query)
        getYosikiInfo()
      } else if (hasOuterSearch) {
        //検索条件
        form.kensakujyokenlist1.forEach((item) => {
          if (Object.hasOwn(route.query, item.jyokenlabel)) {
            item.value = route.query[item.jyokenlabel]
            item.disabled = true
          }
        })
      }
    })
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => form.style,
  (newValue) => {
    if (!newValue) {
      Object.assign(permissionsInfo, defaultPermissionsInfo)
      form.styleName = ''
    }
  }
)
function onChangeStyle(val) {
  //出力バッター
  if (val) {
    Object.assign(
      permissionsInfo,
      selectorlist.value.find((el) => el.yosikiid == val)
    )
    //出力様式名
    form.styleName = selectorlist.value?.find((item) => item.yosikiid === val)?.yosikinm ?? ''
    form.yosikisyubetsu =
      selectorlist.value?.find((item) => item.yosikiid === val)?.yosikisyubetu.toString() ?? ''
  }
}

watch(
  () => isSearch.value,
  () => {
    if (form.atenaflg && isSearch.value) {
      Object.assign(permissionsInfo, defaultPermissionsInfo)
    } else if (form.atenaflg && !isSearch.value) {
      Object.assign(
        permissionsInfo,
        selectorlist.value.find((el) => el.yosikiid == form.style)
      )
    }
  }
)

watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) getTableList()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const handleSearch = async () => {
  await getTableList()
  isSearch.value = false
}

const openOutput = (type: ExportType) => {
  if (!RequiredIsAllSet.value) {
    message.warning(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須検索条件'))
    return
  }
  exportMethod.value = type
  const checkedData = tableList.value.filter((el) => el.formflg)
  if (type === ExportType.CSV) {
    // if (tableList.value.length > 0 && checkedData.length === 0) {
    //   showInfoModal({
    //     type: 'warning',
    //     content: A000008.Msg
    //   })
    //   return
    // }
    csvVisible.value = true
  } else if ([ExportType.PDF, ExportType.EXCEL].includes(type)) {
    // if (tableList.value.length > 0 && checkedData.length === 0) {
    //   showInfoModal({
    //     type: 'warning',
    //     content: A000008.Msg
    //   })
    //   return
    // }
    if (form.hakusiflg) downLoadPdf(EnumReportType[`${type}`])
    else {
      excelPDfVisible.value = true
    }
  }
}

const downLoadPdf = (type) => {
  Download({
    outputtype: type,
    workseq: workseq.value,
    rptid,
    yosikiid: form.style,
    outputfilenm: `${rptnm}${dayjs().format(
      'MM-DD HH:mm'
    )}.${exportMethod.value.toLocaleLowerCase()}`,
    rirekiupdflg: false,
    sqljikkoflg: permissionsInfo.updateflg,
    hakusiflg: form.hakusiflg,
    memo: form.memo,
    jyokenlist: [
      ...(form.kensakujyokenlist1 as unknown as KensakuJyokenVM[]),
      ...(form.kensakujyokenlist2 as unknown as KensakuJyokenVM[])
    ],
    tyusyutuinfo
  }).then((res) => {
    console.log('res', res)
  })
}

async function getTableList() {
  if (form.tyusyutupanelflg) {
    try {
      await validate()
    } catch (error) {
      message.warning(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須項目'))
      return Promise.reject()
    }
  }
  const detailjyokenlist = await searchDrawerRef.value?.validateDrawer()
  //検索条件必須
  if (
    form.kensakujyokenlist1.some(
      (item) => item.hissuflg && typeof item.value !== 'boolean' && !item.value
    )
  ) {
    message.warning(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須項目'))
    return Promise.reject()
  }

  if (form.kensakujyokenlist2.some((item) => item.hissuflg && !item.value)) {
    message.warning(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '必須項目'))
    return Promise.reject()
  }
  // 画面検索チェック取り消し　2024-06-21
  // if (Object.values(koteiyoshiki).includes(form.style)) {
  //   message.warning(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '帳票の出力様式（固定様式以外）'))
  //   return Promise.reject()
  // }
  // 画面検索チェック取り消し　2024-06-21
  //出力様式必須
  if (!form.style) {
    message.warning(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '出力様式'))
    return Promise.reject()
  }

  try {
    if (workseq.value < 0) {
      const res = await SearchWarnings(
        {
          ...pageParams,
          rptid,
          yosikiid: form.style,
          jyokenlist: form.kensakujyokenlist1,
          detailjyokenlist,
          tyusyutuinfo
        },
        () => getTableListAgain()
      )
      workseq.value = res.workseq
      if (res.kekkalist.length > 0) visible.value = true
    }

    SearchDetail({
      rptid,
      workseq: workseq.value,
      ...pageParams
    }).then((res) => {
      tableList.value = res.kekkalist.map((el) => ({
        ...el
      }))
      totalCount.value = res.totalrowcount
    })
  } catch (error) {
    return Promise.reject()
  }
  return Promise.resolve()
}

//再検索処理
const getTableListAgain = () => {
  tableList.value = []
  isSearch.value = true
  pageParams.pagenum = 1
  pageParams.pagesize = 25
  totalCount.value = 0

  workseq.value = -1
}

//プレビュー
const previewParams = ref<PreviewRequest>()
async function onPreview(data) {
  previewParams.value = {
    workseq: workseq.value,
    rptid,
    yosikiid: form.style,
    memo: form.memo,
    jyokenlist: [
      ...(form.kensakujyokenlist1 as unknown as KensakuJyokenVM[]),
      ...(form.kensakujyokenlist2 as unknown as KensakuJyokenVM[])
    ],
    hakusiflg: form.hakusiflg,
    selectedatenanolist: selectedatenanolist.value,
    tyusyutuinfo,
    ...data
  }
  previewVisible.value = true
}

const handleSelectflg = () => {
  UpdateWarnCheckbox({
    ...pageParams,
    workseq: workseq.value,
    ...xTableRef?.value?.getCurrentRecord(),
    status: 'update'
  }).then((res) => {
    console.log('res', res)
  })
}
//様式紐づけ検索条件
const onChangeHimoJyoken = (jyokenid: string, value: string) => {
  if (!value && jyokenid == yosikihimonm.value) {
    form.style = '' //出力様式
    selectorlist.value = [] //出力様式プルダウンリスト
    return
  }
  if (jyokenid == yosikihimonm.value) {
    getYosiki({ himozukejyokenid: jyokenid, himozukevalue: value })
  }
}
//検索条件初期値
const dateStr = (date) => dayjs(date).format('YYYY-MM-DD')
const getDays = (year, month) => {
  return new Date(year, month + 1, 0).getDate()
}
const processElement = (el) => {
  const syokiti = el.syokiti?.toLowerCase()
  const today = new Date()
  const currentMonth = today.getMonth()
  const currentYear = today.getFullYear()

  switch (syokiti) {
    case 'today':
      el.value = dateStr(today)
      break
    case 'nendof':
      el.value = dateStr(new Date(currentYear, 3, 1)) // 今年初め
      break
    case 'nendot':
      el.value = dateStr(new Date(currentYear + 1, 2, getDays(currentYear + 1, 2))) // 今年終わり
      break
    case 'monthf':
      el.value = dateStr(new Date(currentYear, currentMonth, 1)) // 今月初め
      break
    case 'lastyear':
      el.value =
        dateStr(new Date(currentYear - 1, 3, 1)) +
        ',' +
        dateStr(new Date(currentYear, 2, getDays(currentYear, 2))) // 去年初め～去年終わり
      break
    case 'year':
      el.value =
        dateStr(new Date(currentYear, 3, 1)) +
        ',' +
        dateStr(new Date(currentYear + 1, 2, getDays(currentYear + 1, 2))) // 今年初め～今年終わり
      break
    case 'lastmonth':
      el.value =
        dateStr(new Date(currentYear, currentMonth - 1, 1)) +
        ',' +
        dateStr(new Date(currentYear, currentMonth, 0)) // 先月初め～先月終わり
      break
    case 'month':
      el.value =
        dateStr(new Date(currentYear, currentMonth, 1)) +
        ',' +
        dateStr(new Date(currentYear, currentMonth + 1, 0)) // 今月初め～今月終わり
      break
    default:
      el.value = el.syokiti
      break
  }
}

//一覧へ処理
const goListPpage = () => {
  router.push({ path: 'AWEU00301G' })
}

//様式情報の取得
function getYosiki(params?: Partial<YosikiInfoRequest>) {
  GetYosikiInfo({
    rptid,
    tyusyutukbn: tyusyutuinfo.tyusyutukbn,
    tyusyututaisyocd: tyusyutuinfo.tyusyututaisyocd,
    ...params
  }).then((res) => {
    //出力様式プルダウンリスト
    selectorlist.value = res.selectorlist
    //出力様式
    form.style = res.selectorlist[0]?.yosikiid ?? ''
    //出力様式名
    form.styleName = res.selectorlist[0]?.yosikinm ?? ''
    //出力バッター
    Object.assign(permissionsInfo, res.selectorlist[0])
  })
}

//抽出パネル--------------------------------------------------------------------------------------
const tyusyutuinfo = reactive<TyusyutuVM>({
  tyusyututaisyocd: '',
  nendo: '',
  tyusyutunaiyo: '',
  tyusyutukbn: '',
  yosikisyubetu: ''
})
// 様式種別 = 帳票出力区分.key
watchEffect(() => {
  tyusyutuinfo.yosikisyubetu =
    form.tyusyutukbnlist?.find((el) => el.value === tyusyutuinfo.tyusyutukbn)?.key ?? ''
})

const atenanocnt = ref('') //抽出人数
const regdttm = ref('') //登録日時
watchEffect(async () => {
  if (tyusyutuinfo.tyusyutunaiyo) {
    const res = await ChangeTyusyutunaiyo({
      tyusyutunaiyo: tyusyutuinfo.tyusyutunaiyo
    })
    atenanocnt.value = res.atenanocnt
    regdttm.value = res.regdttm
  } else {
    atenanocnt.value = ''
    regdttm.value = ''
  }
})

//項目の設定
const rules = computed(() => ({
  tyusyututaisyocd: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '抽出対象') }
  ],
  tyusyutunaiyo: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '抽出内容') }
  ],
  tyusyutukbn: [
    {
      required: form.tyusyutukbnlist && form.tyusyutukbnlist.length > 0,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '帳票出力区分')
    }
  ]
}))
const { validate, validateInfos } = Form.useForm(tyusyutuinfo, rules)

const showNendo = computed(() => {
  return form.tyusyututaisyolist.some((el) => el.key === String(Enum通知サイクル.毎年))
})
const disabled_nendo = computed(() => {
  return Boolean(
    !tyusyutuinfo.tyusyututaisyocd ||
      form.tyusyututaisyolist.find((el) => el.value === tyusyutuinfo.tyusyututaisyocd)?.key ===
        String(Enum通知サイクル.生涯一回)
  )
})
//抽出内容リスト
const computed_list1 = computed(() => {
  return form.tyusyutunaiyolist.filter(
    (el) =>
      el.key ===
      tyusyutuinfo.tyusyututaisyocd + '_' + (disabled_nendo.value ? '9999' : tyusyutuinfo.nendo)
  )
})
//帳票出力区分リスト
const computed_list2 = computed(() => {
  //抽出对象
  const currentTaisyocd = form.tyusyututaisyolist.find(
    (el) => el.value === tyusyutuinfo.tyusyututaisyocd
  )
  //抽出对象key2: 抽出データ詳細区分
  if (currentTaisyocd?.key2) {
    return form.tyusyutukbnlist.filter((el) => el.key2 === currentTaisyocd?.key2)
  }
  return form.tyusyutukbnlist
})

//抽出対象change
function onChangeTyusyutaisyocd() {
  tyusyutuinfo.tyusyutunaiyo = tyusyutuinfo.tyusyutukbn = ''
  getYosikiInfo()
}
//様式情報
function getYosikiInfo() {
  if (form.tyusyutukbnlist.length > 0) {
    if (tyusyutuinfo.tyusyutukbn && tyusyutuinfo.tyusyututaisyocd) {
      getYosiki()
    } else {
      form.style = '' //出力様式
      selectorlist.value = []
    }
  } else {
    if (tyusyutuinfo.tyusyututaisyocd) {
      getYosiki()
    } else {
      form.style = '' //出力様式
      selectorlist.value = []
    }
  }
}
const getValue = (val) => {
  if (!val) return
  const [min, max] = val.split(',')
  if (min && !max) return `${min}以上`
  if (!min && max) return `${max}以下`
  if (min && max) return `${min} ～ ${max}`
  return ''
}

//-------------------------------------------------------------------------------------------------

//参照元項目入力後参照先項目の選択リストを取得する処理
function setOtherOptions(optslist: TargetItemValueVM[], formlist: Ref<KensakuJyokenInitVM[]>) {
  optslist.forEach((el) => {
    const findItem = formlist.value.find((item) => item.jyokenid === el.jyokenid)
    if (findItem) {
      findItem.value = ''
      findItem.selectorlist = el.selectorlist
    }
  })
}
</script>
<style scoped lang="less" src="./index.less"></style>
