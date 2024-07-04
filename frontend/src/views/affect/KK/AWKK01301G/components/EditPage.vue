<!-- eslint-disable vue/no-parsing-error -->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <a-row>
        <a-col :span="12">
          <div class="self_adaption_table">
            <a-row>
              <a-col v-if="nendoflg" :sm="20" :xl="20" :xxl="20">
                <th>年度</th>
                <TD>{{ yearFormatter_unknown(headerInfo?.nendo) }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :sm="20" :xl="20" :xxl="20">
                <th>抽出対象</th>
                <TD>{{ headerInfo?.tyusyututaisyonm }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :sm="20" :xl="20" :xxl="20">
                <th>抽出内容</th>
                <TD>{{ headerInfo?.tyusyutunaiyo }}</TD>
              </a-col>
            </a-row>
          </div>
        </a-col>
        <a-col :span="12">
          <div class="self_adaption_table">
            <a-row>
              <a-col :sm="20" :xl="20" :xxl="20">
                <th>抽出人数</th>
                <TD>{{ headerInfo?.tyusyutunum }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :sm="20" :xl="20" :xxl="20">
                <th>登録日時</th>
                <TD>{{ headerInfo?.regdttm }}</TD>
              </a-col>
            </a-row>
          </div>
        </a-col>
      </a-row>
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button v-if="isNew" type="primary" @click="extract">抽出</a-button>
          <a-button type="primary" :disabled="!tyusyutuseq" @click="handleExcel">発行</a-button>
          <a-button type="primary" @click="goList">一覧へ</a-button>
        </a-space>
        <a-space>
          <ClosePage />
        </a-space>
      </div>
    </a-card>
    <a-card :bordered="false" class="mt-3 overflow-y-auto" :style="{ height: tableHeight + 'px' }">
      <div>
        <a-row>
          <a-col v-if="tyusyukbn == Enum抽出モード.全体抽出" :sm="10" :xl="10" :xxl="10">
            <h1>抽出条件</h1>
            <vxe-table
              :show-header="false"
              :data="jokenlist1"
              :row-config="{ height: 44 }"
              :empty-render="{ name: 'NotData' }"
              :edit-config="{
                trigger: 'click',
                mode: 'row',
                beforeEditMethod({ row }: { row: FreeItemTyusyutuVM }){
                  return isNew && row.inputflg
                }
              }"
            >
              <vxe-column
                field="itemnm"
                width="45%"
                title="項目"
                :class-name="({ row }) => setCellColor(row)"
              >
                <template #default="{ row }">
                  {{ row.itemnm }}
                  <span v-if="row.hissuflg" class="request-mark"> ＊ </span>
                </template>
              </vxe-column>
              <vxe-column
                field="value"
                title="値"
                :class-name="getInputColClass"
                :show-overflow="false"
                :edit-render="{
                  name: 'CustomEdit',
                  props: { optionsDefaultOpen: true },
                  events: { onChange: () => {} }
                }"
              >
                <template #default="{ row }: { row: FreeItemTyusyutuVM }">
                  <span v-if="row.inputtypekbn === Enum入力タイプ.日付_年月日">
                    {{ row.value && getDateJpText(new Date(row.value)) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日付_年月日_不詳あり">
                    {{ row.value && getUnKnownDateJpText(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日時_年月日時分秒">
                    {{ row.value && getDateHmsJpText(new Date(row.value)) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年">
                    {{ row.value && yearFormatter(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年_不詳あり">
                    {{ row.value && yearFormatter_unknown(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年月">
                    {{ row.value && yearMonthFormatter(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年月_不詳あり">
                    {{ row.value && yearMonthFormatter_unknown(row.value) }}
                  </span>
                  <span v-else-if="!row.inputflg && [Enum画面項目入力.選択].includes(row.inputkbn)">
                    {{ row.value?.split(' : ')[1] }}
                  </span>
                  <span v-else> {{ row.value }}</span>
                </template>
              </vxe-column>
            </vxe-table>
          </a-col>
          <a-col v-if="tyusyukbn == Enum抽出モード.個別抽出" :sm="10" :xl="10" :xxl="10">
            <h1>宛名情報</h1>
            <div class="self_adaption_table">
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>宛名番号</th>
                  <TD>{{ atenano }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>氏名</th>
                  <TD>{{ kobetuInfo.name }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>カナ氏名</th>
                  <TD>{{ kobetuInfo.kname }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>性別</th>
                  <TD>{{ kobetuInfo.sex }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>生年月日</th>
                  <TD>{{ kobetuInfo.bymd }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>住民区分</th>
                  <TD>{{ kobetuInfo.juminkbn }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>年齢(本日時点)</th>
                  <TD>{{ kobetuInfo.age }}</TD>
                </a-col>
              </a-row>
            </div>
            <div v-if="hakkenhyojiflg" class="self_adaption_table">
              <h1 class="m-t-2">発券情報</h1>
              <a-row v-for="(hakken, index) in hakkenList" :key="index">
                <a-col :sm="24" :xl="24" :xxl="24">
                  <th>{{ hakken.label }}</th>
                  <TD>{{ hakken.hakkenno }}</TD>
                </a-col>
              </a-row>
            </div>
          </a-col>
          <a-col :sm="10" :xl="10" :xxl="10" offset="2">
            <h1>抽出条件以外</h1>
            <vxe-table
              :class="['m-b-1']"
              :show-header="false"
              :data="jokenlist2"
              :row-config="{ height: 44 }"
              :empty-render="{ name: 'NotData' }"
              :edit-config="{
                trigger: 'click',
                mode: 'row',
                beforeEditMethod({ row }: { row: FreeItemTyusyutuVM }){
                  return isNew && row.inputflg
                }
              }"
            >
              <vxe-column
                field="itemnm"
                width="45%"
                title="項目"
                :class-name="({ row }) => setCellColor(row)"
              >
                <template #default="{ row }">
                  {{ row.itemnm }}
                  <span v-if="row.hissuflg" class="request-mark"> ＊ </span>
                </template>
              </vxe-column>
              <vxe-column
                field="value"
                title="値"
                :class-name="getInputColClass"
                :show-overflow="false"
                :edit-render="{
                  name: 'CustomEdit',
                  props: { optionsDefaultOpen: true },
                  events: { onChange: () => {} }
                }"
              >
                <template #default="{ row }: { row: FreeItemTyusyutuVM }">
                  <span v-if="row.inputtypekbn === Enum入力タイプ.日付_年月日">
                    {{ row.value && getDateJpText(new Date(row.value)) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日付_年月日_不詳あり">
                    {{ row.value && getUnKnownDateJpText(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.日時_年月日時分秒">
                    {{ row.value && getDateHmsJpText(new Date(row.value)) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年">
                    {{ row.value && yearFormatter(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年_不詳あり">
                    {{ row.value && yearFormatter_unknown(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年月">
                    {{ row.value && yearMonthFormatter(row.value) }}
                  </span>
                  <span v-else-if="row.inputtypekbn === Enum入力タイプ.半角文字_年月_不詳あり">
                    {{ row.value && yearMonthFormatter_unknown(row.value) }}
                  </span>
                  <span v-else-if="!row.inputflg && [Enum画面項目入力.選択].includes(row.inputkbn)">
                    {{ row.value?.split(' : ')[1] }}
                  </span>
                  <span v-else> {{ row.value }}</span>
                </template>
              </vxe-column>
            </vxe-table>
          </a-col>
        </a-row>
      </div>
    </a-card>
  </a-spin>
</template>
<script setup lang="ts">
import { ref, computed, reactive, onMounted, watchEffect, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useTableHeight } from '@/utils/hooks'
import { PageSatatus } from '#/Enums/BaseEnums'
import { Enum抽出モード } from '#/Enums/CmBusinessEnums'
import {
  ExtractRequest,
  ExtractResponse,
  FreeItemTyusyutuVM,
  HakkenVM,
  InitDetailRequest,
  TyusyutuMainVM
} from '../type'
import { Extract, InitDetail } from '../service'
import { showConfirmModal } from '@/utils/modal'
import { OUTPUT_EXCEL_CONFIRM } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { EnumServiceResult } from '#/Enums/DaCommonEnums'
import { validateByInputtype } from '@/utils/validate'
import { EnumMsgCtrlKbn, Enum入力タイプ, Enum画面項目入力 } from '#/Enums'
import {
  getDateHmsJpText,
  getDateJpText,
  getUnKnownDateJpText,
  yearMonthFormatter_unknown,
  yearFormatter_unknown,
  yearFormatter,
  yearMonthFormatter
} from '@/utils/util'
import { Judgement } from '@/utils/judge-edited'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
}>()

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref<boolean>(false)
const editJudge = new Judgement(route.name as string)
const atenano = route.query.atenano as string
const tyusyututaisyocd = route.query.tyusyututaisyocd as string
const tyusyukbn = route.query.tyusyukbn as unknown as Enum抽出モード
const tyusyutunaiyo = route.query.tyusyutunaiyo as string
const tyusyutuseq = ref(route.query.tyusyutuseq as string)
const isNew = ref(props.status === PageSatatus.New)
const nendo = route.query.nendo as string
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 60)

//ヘーダ情報
const headerInfo = reactive<TyusyutuMainVM>({
  nendo: null,
  tyusyututaisyonm: '',
  tyusyutunaiyo: '',
  tyusyutunum: '',
  regdttm: '',
  rptid: ''
})

//個別情報
const kobetuInfo = reactive({
  name: '', //氏名
  kname: '', //カナ氏名
  sex: '', //性別
  bymd: '', //生年月日
  juminkbn: '', //住民区分
  age: '' //年齢(本日時点)
})
//発券情報
const hakkenList = ref<HakkenVM[]>([])
const hakkenhyojiflg = ref(false)
const nendoflg = ref(false)
//検索条件
const jokenlist1 = ref<FreeItemTyusyutuVM[]>([])
//検索条件以外
const jokenlist2 = ref<FreeItemTyusyutuVM[]>([])

//固定項目チェックモード
const model1 = reactive<{ [key: string]: unknown }>({})
const model2 = reactive<{ [key: string]: unknown }>({})
const rules1 = reactive<{ [key: string]: unknown }>({})
const rules2 = reactive<{ [key: string]: unknown }>({})
const {
  clearValidate: clearValidate1,
  validate: validate1,
  validateInfos: validateInfos1
} = Form.useForm(model1, rules1)
const {
  clearValidate: clearValidate2,
  validate: validate2,
  validateInfos: validateInfos2
} = Form.useForm(model2, rules2)

//項目値変更処理
watchEffect(() => {
  for (const el of jokenlist1.value) {
    model1[el.itemcd] = el.value
    editJudge.setEdited()
  }
  for (const el of jokenlist2.value) {
    model2[el.itemcd] = el.value
    editJudge.setEdited()
  }
})

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  //詳細画面初期化
  loading.value = true
  Init()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const Init = async () => {
  let params: InitDetailRequest = {
    tyusyututaisyocd: tyusyututaisyocd,
    tyusyutuseq: !isNew.value ? +tyusyutuseq.value : null,
    atenano: tyusyukbn == Enum抽出モード.個別抽出 ? atenano : null,
    nendo: tyusyukbn == Enum抽出モード.個別抽出 ? +nendo : null,
    tyusyutunaiyo: tyusyukbn == Enum抽出モード.全体抽出 ? tyusyutunaiyo : '個別抽出',
    zentaikobetukbn: tyusyukbn.toString()
  }
  try {
    const res = await InitDetail(params)
    Object.assign(headerInfo, res.tyusyutuinfo)
    Object.assign(kobetuInfo, res.atenainfo)
    jokenlist1.value = res.jokenlist1
    jokenlist2.value = res.jokenlist2
    hakkenList.value = res.hakkeninfo
    nendoflg.value = res.nendoflg
    hakkenhyojiflg.value = res.hakkenhyojiflg
    headerInfo.nendo = headerInfo.nendo == null ? +nendo : headerInfo.nendo
    //チェック設定(固定項目)
    for (const el of jokenlist1.value) {
      rules1[el.itemcd] = [{ validator: (_, value) => validateByInputtype(value, el, 'E001001') }]
    }
    for (const el of jokenlist2.value) {
      rules2[el.itemcd] = [{ validator: (_, value) => validateByInputtype(value, el, 'E001001') }]
    }
    loading.value = false
    nextTick(() => editJudge.reset())
  } catch (error) {
    loading.value = false
  }
}
//発行
const handleExcel = () => {
  showConfirmModal({
    content: OUTPUT_EXCEL_CONFIRM,
    onOk: async () => {
      await router.push({
        name: 'AWEU00301G',
        query: { status: PageSatatus.List }
      })
      router.push({
        name: 'AWEU00301G',
        query: {
          status: PageSatatus.Detail,
          rptid: headerInfo.rptid,
          nendo: headerInfo?.nendo,
          tyusyutunaiyo: +tyusyutuseq.value,
          tyusyutunaiyonm: headerInfo?.tyusyutunaiyo,
          tyusyututaisyocd: tyusyututaisyocd
        }
      })
    }
  })
}
//一覧
const goList = () => {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.List
    }
  })
}

//抽出
const extract = async () => {
  try {
    await validate1()
    await validate2()
    loading.value = true
    //抽出条件
    let parameter1 = jokenlist1.value.map((el) => {
      return { itemcd: el.itemcd, value: el.value }
    })
    //抽出条件以外
    let parameter2 = jokenlist2.value.map((el) => {
      return { itemcd: el.itemcd, value: el.value }
    })
    let params: ExtractRequest = {
      tyusyututaisyocd: tyusyututaisyocd,
      atenano: tyusyukbn == Enum抽出モード.個別抽出 ? atenano : null,
      tyusyutunaiyo: headerInfo?.tyusyutunaiyo,
      nendo: +nendo,
      continueflg: false,
      zentaikobetukbn: tyusyukbn.toString(),
      parameters: [...parameter1, ...parameter2]
    }
    const res = await Extract(params, async (response: ExtractResponse) => {
      //アラートの場合は
      if (response.returncode == EnumServiceResult.ServiceAlert) {
        const res1 = await Extract({ ...params, continueflg: true })
        if (res1.tyusyutuseq) {
          isNew.value = false
          tyusyutuseq.value = res1.tyusyutuseq?.toString()
          Init()
        }
        Init()
      }
    })
    if (res.tyusyutuseq) {
      isNew.value = false
      tyusyutuseq.value = res.tyusyutuseq?.toString()
      Init()
    }
    if (tyusyukbn == Enum抽出モード.個別抽出) headerInfo.tyusyutunum = '1'
    loading.value = false
  } catch (error) {
    loading.value = false
  }
}

//チェック処理
function isErrorValue(item: FreeItemTyusyutuVM) {
  return item.msgkbn === EnumMsgCtrlKbn.エラー && item.hissuflg && !item.value && item.value !== 0
}
function isWarnValue(item: FreeItemTyusyutuVM) {
  return item.msgkbn === EnumMsgCtrlKbn.アラート && item.hissuflg && !item.value && item.value !== 0
}
function getInputColClass({ row }: { row: FreeItemTyusyutuVM }) {
  //if (!props.canEdit) return ''
  return isErrorValue(row) ? 'bg-errorcell' : isWarnValue(row) ? 'bg-warncell' : ''
}
//行の背景色
function setCellColor(row) {
  return (!isNew.value && tyusyukbn == Enum抽出モード.全体抽出) || !row.inputflg
    ? 'bg-readonly'
    : 'bg-editable'
}
</script>

<style lang="less" scoped>
th {
  width: 180px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
:deep(.vxe-body--column) {
  .vxe-cell {
    padding: 0 6px;
  }
}
.vxe-table {
  border: none;
}
</style>
