/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 計算定義(共通フレーム)
 * 　　　　　  データストア設定
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { createStore } from 'vuex'
import modules from './modules'
import { reactive } from 'vue'
import { Judgement } from '@/utils/judge-edited'
import { InfoVM } from '@/views/affect/AF/AWAF00603S/type'
import { Enum共通バー番号, Enum集計区分 } from '#/Enums'
import { UploadData } from '@/views/affect/KK/AWKK00601G/type'
import { ReportItemDetailVM } from '@/views/affect/EU/AWEU00201G/type'

const store = createStore({
  state() {
    return {}
  },
  mutations: {},
  modules
})

export const judgeStore = reactive<{
  [prop: string]: boolean | undefined
}>({})

//EUC帳票ストア
export const EUCStore = reactive<{
  excel: File | null
  defineItems: ReportItemDetailVM[]
  setExcel: (data: File) => void
  setDefineItems: (data: ReportItemDetailVM[]) => void
  conditionlist: any[]
  setConditionlist: (data: any[]) => void
  clear: () => void
}>({
  excel: null,
  defineItems: [],
  conditionlist: [],
  setExcel(data) {
    this.excel = data
  },
  setDefineItems(data) {
    this.defineItems = data
  },
  setConditionlist(data) {
    this.conditionlist = data
  },
  clear() {
    this.excel = null
    this.defineItems = []
    this.conditionlist = []
  }
})

//権限ストア
export const KengenStore = reactive({
  editJudge: new Judgement('AWAF00901G'),
  pnoeditflg: false,
  setPnoeditflg(val: boolean) {
    this.pnoeditflg = val
  }
})

//共通バーストア 権限
interface BarKengen {
  barno: Enum共通バー番号
  updateflg: boolean
  addflg: boolean
  deleteflg: boolean
  personalnoflg: boolean
}
export const BarStore = reactive({
  barKengenList: [] as BarKengen[],
  setBarKengenList(val: InfoVM[]) {
    const list = val.map((item) => {
      return {
        barno: item.barno,
        updateflg: item.updateflg,
        addflg: item.addflg,
        deleteflg: item.deleteflg,
        personalnoflg: item.personalnoflg
      }
    })
    //るいか
    list.forEach((el) => {
      if (this.barKengenList.every((item) => item.barno !== el.barno)) {
        this.barKengenList.push(el)
      }
    })
  }
})

export const ProgramStore = reactive({
  /** 現在のページのkinoid(menuid) */
  id: '',
  setId(val: string) {
    this.id = val
  }
})

//グローバル
export const GlobalStore = reactive({
  loading: false,
  setLoading(val: boolean) {
    this.loading = val
  },
  getLoadingContainer() {
    return document.getElementsByClassName('ant-spin-container')[0] as HTMLElement
  }
})

/**拡張事業編集判断 */
export const editStore1 = reactive({
  editJudge: new Judgement('AWKK00801G')
})

/**取込データ */
export const ImporterStore = reactive<{
  uploadData: UploadData | null
  setUploadData: (data: UploadData | null) => void
}>({
  uploadData: null,
  setUploadData(val) {
    this.uploadData = val
  }
})

export default store
