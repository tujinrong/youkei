/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ロジック共通仕様処理(検診)
 * 　　　　　  共通内容
 * 作成日　　: 2023.07.12
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { EnumMsgCtrlKbn, Enum入力タイプ, Enum画面項目入力 } from '#/Enums'
import { KsFixItemVM } from './type'

//一次固定項目
const fixItemlist1: Partial<KsFixItemVM>[] = [
  //実施日
  {
    inputtypekbn: Enum入力タイプ.日付_年月日,
    inputkbn: Enum画面項目入力.日付,
    itemcd: 'jissiymd1',
    itemnm: '実施日',
    hissuflg: true,
    syokiti: null,
    value: null,
    msgkbn: EnumMsgCtrlKbn.エラー
  },
  //実施年齢
  {
    itemcd: 'jissiage1',
    itemnm: '実施年齢'
  },
  //検査方法
  {
    inputtypekbn: Enum入力タイプ.コード_名称マスタ,
    inputkbn: Enum画面項目入力.選択,
    itemcd: 'kensahoho1',
    itemnm: '検査方法',
    hissuflg: true,
    syokiti: null,
    value: null,
    msgkbn: EnumMsgCtrlKbn.エラー,
    cdlist: []
  }
]

//精密固定項目
const fixItemlist2: Partial<KsFixItemVM>[] = [
  //実施日
  {
    inputtypekbn: Enum入力タイプ.日付_年月日,
    inputkbn: Enum画面項目入力.日付,
    itemcd: 'jissiymd2',
    itemnm: '実施日',
    hissuflg: false,
    syokiti: null,
    value: null,
    msgkbn: EnumMsgCtrlKbn.エラー
  },
  //実施年齢
  {
    itemcd: 'jissiage2',
    itemnm: '実施年齢'
  }
]

export { fixItemlist1, fixItemlist2 }
