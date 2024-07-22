// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(帳票出力設定)バッチ処理
//             パラメータモデル
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.BatchService.AWEU00303D
{
    public class ParameterModel
    {
        public long? workseq { get; set; }                              //ワークシーケンス 
        public string rptid { get; set; }                               //帳票ID
        public string yosikiid { get; set; }                            //様式ID
        public string memo;                                             //検索条件メモ
        public EnumReportType reporttype { get; set; }                  //出力方式
        public Dictionary<string, object> searchdic { get; set; }       //検索条件
        public Dictionary<string, object> detaildearchdic { get; set; } //詳細検索条件
        public List<string> orderbylist { get; set; }                   //ソート順
        public string sessionseq { get; set; }                          //セッションシーケンス
        public string reguserid { get; set; }                           //登録ユーザID
        public string? regsisyo { get; set; }                           //登録支所
        public bool hasupdatesql { get; set; }                          //更新SQL
        public bool isblank { get; set; }                               //白纸
        public bool hasconditionsheet { get; set; }                     //条件シートを出力
        public bool hasupdhassorireki { get; set; }                     //発送履歴テーブル更新
        public string filenm { get; set; }                             //ファイル名

        public　Dictionary<string, object> outputInfoDic { get; set; }  //出力情報
    }
}