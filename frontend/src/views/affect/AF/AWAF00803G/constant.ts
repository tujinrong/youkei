/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ログ情報管理
 * 　　　　　  共通定数
 * 作成日　　: 2023.09.14
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { VxeColumnProps } from 'vxe-table/types/column'

/** ログ情報タブ */
enum EnumLogTab {
  通信,
  バッチ,
  連携,
  DB,
  項目値,
  宛名
}

const columns: Record<EnumLogTab, VxeColumnProps[]> = {
  [EnumLogTab.通信]: [
    { field: 'tusinlogseq', title: '通信ログシーケンス', minWidth: '100' },
    { field: 'ipadrs', title: '操作者IP', minWidth: '100' },
    { field: 'os', title: '操作者OS', minWidth: '100' },
    { field: 'browser', title: '操作者ブラウザー', minWidth: '150' },
    { field: 'syoridttm', title: '処理日時', minWidth: '110' },
    { field: 'request', title: 'リクエスト', minWidth: '110' },
    { field: 'response', title: 'レスポンス', minWidth: '110' },
    { field: 'msg', title: 'メッセージ', minWidth: '110' }
  ],
  [EnumLogTab.バッチ]: [
    { field: 'batchlogseq', title: 'バッチログシーケンス', minWidth: '110', width: '200' },
    { field: 'syoridttm', title: '処理日時', minWidth: '110', width: '240' },
    { field: 'pram', title: 'パラメータ', minWidth: '110' },
    { field: 'msg', title: 'メッセージ', minWidth: '110' }
  ],
  [EnumLogTab.連携]: [
    { field: 'gaibulogseq', title: '外部連携ログシーケンス', minWidth: '130' },
    { field: 'syoridttm', title: '処理日時', minWidth: '110' },
    { field: 'ipadrs', title: '操作者IP', minWidth: '110' },
    { field: 'kbn', title: '連携区分', minWidth: '110' },
    { field: 'kbn2', title: '連携方式', minWidth: '110' },
    { field: 'kbn3', title: '処理区分', minWidth: '110' },
    { field: 'apidata', title: 'API連携データ', minWidth: '110' },
    { field: 'filenm', title: 'ファイル名', minWidth: '110' },
    { field: 'msg', title: 'メッセージ', minWidth: '110' }
  ],
  [EnumLogTab.DB]: [
    { field: 'dblogseq', title: 'DB操作ログシーケンス', minWidth: '110', width: '200' },
    { field: 'sql', title: 'SQL' }
  ],
  [EnumLogTab.項目値]: [
    { field: 'columnlogseq', title: '項目値変更ログシーケンス', minWidth: '110' },
    { field: 'tablenm', title: '変更テーブル', minWidth: '120' },
    { field: 'henkokbn', title: '変更区分', minWidth: '90', width: '100' },
    { field: 'keys', title: '主キー', minWidth: '110' },
    { field: 'itemnm', title: '変更項目', minWidth: '110' },
    { field: 'valuebefore', title: '変更前内容', minWidth: '110' },
    { field: 'valueafter', title: '更新後内容', minWidth: '110' }
  ],
  [EnumLogTab.宛名]: [
    { field: 'atenalogseq', title: '宛名番号ログシーケンス', minWidth: '110', width: '200' },
    { field: 'atenano', title: '宛名番号', minWidth: '110' },
    { field: 'name', title: '氏名', minWidth: '110' },
    { field: 'kname', title: 'カナ氏名', minWidth: '110' },
    { field: 'sex', title: '性別', minWidth: '60' },
    { field: 'bymd', title: '生年月日', minWidth: '110' },
    { field: 'adrs', title: '住所', minWidth: '110' },
    { field: 'gyoseiku', title: '行政区', minWidth: '110' },
    { field: 'juminkbn', title: '住民区分', minWidth: '110' },
    { field: 'pnoflg', title: '個人番号操作状況', minWidth: '150', width: '150' },
    { field: 'usekbn', title: '操作区分', minWidth: '110' }
  ]
}

export { EnumLogTab, columns }
