/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ホーム
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.21
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, download } from '@/utils/http/common-service'
import {
  InitResponse,
  InitRequest,
  SearchInfoResponse,
  SearchInfoRequest,
  SearchLogResponse,
  DownloadRequest,
  GetMenuResponse
} from './type'
const servicename = 'AWAF00301G'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  if(params.kbn == 1){
    return new Promise((resolve) => {
      resolve({
        nendo: 2035,
        atenanolen: 15,
        kikancdlen: 10,
        selectorlist: [
            {
                value: "1",
                label: "基幹システム連携"
            },
            {
                value: "2",
                label: "中間サーバ連携"
            }
        ],
        kekkalist1: [],
        kekkalist2: [],
        returncode: 0,
        message: null,
        rsaprivatekey: null
    });
  });
}
  return api(servicename, methodname, params)
}

/** 検索処理(お知らせ) */
export const SearchInfo = (params: SearchInfoRequest): Promise<SearchInfoResponse> => {
  const methodname = 'SearchInfo'
  return api(servicename, methodname, params)
}

/** 検索処理(連携処理) */
export const SearchLog = (): Promise<SearchLogResponse> => {
  const methodname = 'SearchLog'
  return api(servicename, methodname, {})
}

/** ダウンロード処理 */
export const Download = (params: DownloadRequest): Promise<void> => {
  const methodname = 'Download'
  return download(servicename, methodname, params)
}

/** メニュー取得処理 */
export const GetMenu = (): Promise<GetMenuResponse> => {
  return new Promise((resolve) => {
    resolve({
      menulist: [
        {
          path: "/AWAF",
          parentid: "",
          isfolder: true,
          menuseq: 1,
          menuname: "日本養鶏協会",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 1,
          menuname: "参加申込",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF008",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ1010) 契約者マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ1020)契約者羽数移動入力(移動)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ1030)契約者一覧表(連絡用)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 4,
          menuname: "(GJ1040) 契約者別契約情報入力確認チエックリスト(B4サイズ)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 5,
          menuname: "(GJ1050)事務委託先別· 契約者別生產者積立金等一覧表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 6,
          menuname: "(GJ1060)家畜防疫互助基金事業加入状沉表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF008/AWAF00801G",
          parentid: "AWAF008",
          isfolder: true,
          menuseq: 7,
          menuname: "(GJ1070)事業加入状況表(農場別リスト)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 2,
          menuname: "積立金の算定·請求·納付",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF009",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ2010)契約者積立金・互助金単価マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ2020)生産者積立金計算",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ2030)生産者積立金等請求・返還一覧表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 4,
          menuname: "(GJ2040)積立金等請求書兼返還金通知書",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 5,
          menuname: "(GJ2050)積立金等請求書兼返還金通知書（一部返還）",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 6,
          menuname: "(GJ2060)積立金等返還通知書（全額返還）",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 7,
          menuname: "(GJ2070)積立金等請求通知書（新規加入者）",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 8,
          menuname: "(GJ2080)生産者積立金請求・返還一覧表（確定処理・未処理）",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 9,
          menuname: "(GJ2090)生産者積立金等入金・返還入力",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 10,
          menuname: "(GJ2100)生産者積立金等集計表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 11,
          menuname: "(GJ2110)請求書兼返還金督促通知書(一部徴収)(督促状)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF009/AWAF00901G",
          parentid: "AWAF009",
          isfolder: true,
          menuseq: 12,
          menuname: "(GJ2120)積立金等請求督促通知書(新規加入者)(督促状)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00901G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF010",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 3,
          menuname: "契約変更、增羽、讓渡",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF010",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF010/AWAF00801G",
          parentid: "AWAF010",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ3010)契約羽数增加入力&請求書作成(增羽)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF010/AWAF00801G",
          parentid: "AWAF010",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ3020)契約区分変更の入力&請求書·返還通知書作成(契約区分変更)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF010/AWAF00801G",
          parentid: "AWAF010",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ3030)契約讓渡の入力&請求書作成(讓渡)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 4,
          menuname: "互助金交付額算定",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF011",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ4010) 経営支援互助金/焼却·埋却互助金の申請情報入力",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ4020) 互助金申請情報入力チェックリスト(農場別)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ4030) 互助交付金計算処理",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 4,
          menuname: "(GJ4040) 互助金交付一覧表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 5,
          menuname: "(GJ4050) 家畜防疫互助金交付通知書(振込)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 6,
          menuname: "(GJ4060) 互助金交付金融機関別振込明細表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF011/AWAF00801G",
          parentid: "AWAF011",
          isfolder: true,
          menuseq: 7,
          menuname: "(GJ4070) 互助金交付集計表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF012",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 5,
          menuname: "互助金交付額確定",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF012",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF012/AWAF00801G",
          parentid: "AWAF012",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ5010) 互助基金納付·互助金交付·基金残高管理表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF013",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 6,
          menuname: "積立金返還処理",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF013",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF013/AWAF00801G",
          parentid: "AWAF013",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ6010) 生産者積立金返還金計算処理",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF013/AWAF00801G",
          parentid: "AWAF013",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ6020) 生產者積立金繰越額及び返還額算定一覧表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF013/AWAF00801G",
          parentid: "AWAF013",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ6030) 各種マスタの次年度コピー処理",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF013/AWAF00801G",
          parentid: "AWAF013",
          isfolder: true,
          menuseq: 4,
          menuname: "(GJ6040) 積立金返還金振込データ作成(全銀手順)",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF013/AWAF00801G",
          parentid: "AWAF013",
          isfolder: true,
          menuseq: 5,
          menuname: "(GJ6021) (相殺対応)生產者積立金繰越額及び返還算定一覧表",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF014",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 7,
          menuname: "CSVデータ作成",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF014",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF014/AWAF00801G",
          parentid: "AWAF014",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ7010) 契約者別基本情報·農場登録情報のCSVデータ作成",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF014/AWAF00801G",
          parentid: "AWAF014",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ7020) 契約者别生产者積立金等のCSVデ一タ作成",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF014/AWAF00801G",
          parentid: "AWAF014",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ7030) 契約者别互助金交付等のCSVデ一タ作成",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015",
          parentid: "AWAF",
          isfolder: true,
          menuseq: 8,
          menuname: "マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF015",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 1,
          menuname: "(GJ8010) コ一ドマスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 2,
          menuname: "(GJ8020) 処理年度マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 3,
          menuname: "(GJ8030) 日本養鶏協会マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 4,
          menuname: "(GJ8040) 使用者マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 5,
          menuname: "(GJ8050) 金融機関マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 6,
          menuname: "(GJ8060) 事務委託先マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 7,
          menuname: "(GJ8070) 互助金の発生·終了要件登録",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 8,
          menuname: "(GJ8080) 経営支援互助金交付単価算定基礎指標マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 9,
          menuname: "(GJ8090) 契約者農場マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        },
        {
          path: "/AWAF/AWAF015/AWAF00801G",
          parentid: "AWAF015",
          isfolder: true,
          menuseq: 10,
          menuname: "(GJ8100) 消費税率マスタメンテナンス",
          paramkeisyoflg: false,
          enabled: true,
          menuid: "AWAF00801G",
          addflg: false,
          updateflg: false,
          deleteflg: false,
          personalnoflg: false
        }
      ],
      programlist: [
        {
          kinoid: "AWKK00701G",
          menuids: [
            "AWKK01101G",
            "AWBH00101G",
            "AWKK01201G",
            "AWSH00201G",
            "AWSH00501G",
            "AWYS00401G",
            "AWYS00501G"
          ]
        }
      ]
    } as GetMenuResponse);
  });
}
