// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象者抽出情報管理（専用）
//             ビューモデル定義
// 作成日　　: 2024.05.27
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK01301G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM : TyusyutuMainVM
    {
        public string tyusyututaisyocd { get; set; }                            //抽出対象コード
        public long? tyusyutuseq { get; set; }                                  //抽出シーケンス
    }

    /// <summary>
    /// 抽出メイン情報
    /// </summary>
    public class TyusyutuMainVM
    {

        public int? nendo { get; set; }                                         //年度
        public string tyusyututaisyonm { get; set; }                            //抽出対象名
        public string rptid { get; set; }                                       //帳票ID
        public string tyusyutunaiyo { get; set; }                               //抽出内容
        public string tyusyutunum { get; set; }                                 //抽出人数
        public string regdttm { get; set; }                                     //登録日時
    }
    /// <summary>
    /// フリー項目情報
    /// </summary>
    public class FreeItemTyusyutuVM : FreeItemBaseVM
    {
        public bool isageflg { get; set; }                                      //年齢項目かどうか
    }

    /// <summary>
    /// 抽出パラメータ
    /// </summary>
    public class ParameterVM
    {
        public string itemcd { get; set; }                                      //アイテムコード
        public object value { get; set; }                                       //画面の入力値
    }

    /// <summary>
    /// 抽出結果
    /// </summary>
    public class ExtractVM
    {
        public int actresultkbn { get; set; }                                   //実行結果区分(0:実行完了 1:エラー 2:アラート)
        public string? messageid { get; set; }                                  //画面に表示するメッセージID
        public string? messagetext { get; set; }                                //チェックが失敗した場合、エラー・アラートメッセージの内容
        public long? tyusyutuseq { get; set; }                                  //抽出した場合、tt_kktaisyosya_tyusyutuの最大抽出シーケンス＋１
    }
    /// <summary>
    /// 宛名情報
    /// </summary>
    public class AtenaVM
    {
        public string name { get; set; }                                        //氏名
        public string kname { get; set; }                                       //カナ氏名
        public string sex { get; set; }                                         //性別
        public string bymd { get; set; }                                        //生年月日
        public string juminkbn { get; set; }                                    //住民区分
        public string age { get; set; }                                         //年齢(本日時点)
    }
    /// <summary>
    /// 発券情報
    /// </summary>
    public class HakkenVM
    {
        public string label { get; set; }                                       //ラベル
        public string hakkenno { get; set; }                                    //発券番号
    }
}