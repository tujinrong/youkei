// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログ情報管理
//             ビューモデル定義
// 作成日　　: 2023.09.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00803G
{
    /// <summary>
    /// メインログ情報(一覧画面)
    /// </summary>
    public class RowVM
    {
        public long sessionseq { get; set; }    //ログシーケンス
        public string existflg1 { get; set; }   //通信ログ操作状況
        public string existflg2 { get; set; }   //バッチログ操作状況
        public string existflg3 { get; set; }   //外部連携ログ操作状況
        public string existflg4 { get; set; }   //DB操作ログ操作状況
        public string existflg5 { get; set; }   //項目値変更ログ操作状況
        public string existflg6 { get; set; }   //宛名番号ログ操作状況
        public string syoridttmf { get; set; }  //処理日時（開始）
        public string syoridttmt { get; set; }  //処理日時（終了）
        public string syoritime { get; set; }   //処理時間
        public string kinoid { get; set; }      //機能ID
        public string servicenm { get; set; }   //機能名
        public string methodnm { get; set; }    //処理名
        public string usernm { get; set; }      //操作者
        public string pnoflg { get; set; }      //個人番号操作状況
        public string msgflg { get; set; }      //メッセージ操作状況
        public string status { get; set; }      //処理結果(名称)
    }

    /// <summary>
    /// ヘッダー情報(詳細画面)
    /// </summary>
    public class HeaderVM
    {
        public string status { get; set; }      //処理結果(名称)
        public string syoridttm { get; set; }   //処理日時（開始～終了）
        public string syoritime { get; set; }   //処理時間
        public string servicenm { get; set; }   //機能(名称)
        public string methodnm { get; set; }    //処理(名称)
        public string user { get; set; }        //操作者(名称)
        public string pnoflg { get; set; }      //個人番号操作状況
    }

    /// <summary>
    /// 通信ログ情報(詳細画面)
    /// </summary>
    public class TusinRowVM
    {
        public long tusinlogseq { get; set; }   //通信ログシーケンス
        public string ipadrs { get; set; }      //操作者IP
        public string os { get; set; }          //操作者OS
        public string browser { get; set; }     //操作者ブラウザー
        public string syoridttm { get; set; }   //処理日時（開始～終了）
        public string request { get; set; }     //リクエスト
        public string response { get; set; }    //レスポンス
        public string msg { get; set; }         //メッセージ
    }

    /// <summary>
    /// バッチログ情報(詳細画面)
    /// </summary>
    public class BatchRowVM
    {
        public long batchlogseq { get; set; }   //バッチログシーケンス
        public string syoridttm { get; set; }   //処理日時（開始～終了）
        public string pram { get; set; }        //パラメータ
        public string msg { get; set; }         //メッセージ
    }

    /// <summary>
    /// 連携ログ情報(詳細画面)
    /// </summary>
    public class GaibuRowVM
    {
        public long gaibulogseq { get; set; }   //外部連携ログシーケンス
        public string syoridttm { get; set; }   //処理日時（開始～終了）
        public string ipadrs { get; set; }      //操作者IP
        public string kbn { get; set; }         //連携区分
        public string kbn2 { get; set; }        //連携方式
        public string kbn3 { get; set; }        //処理区分
        public string apidata { get; set; }     //API連携データ
        public string filenm { get; set; }      //ファイル名
        public string msg { get; set; }         //メッセージ
    }

    /// <summary>
    /// DB操作ログ情報(詳細画面)
    /// </summary>
    public class DBRowVM
    {
        public long dblogseq { get; set; }   //DB操作ログシーケンス
        public string sql { get; set; }      //SQL
    }

    /// <summary>
    /// 項目値変更情報(詳細画面)
    /// </summary>
    public class ColumnRowVM
    {
        public long columnlogseq { get; set; }      //項目値変更ログシーケンス
        public string tablenm { get; set; }         //変更テーブル
        public string henkokbn { get; set; }        //変更区分
        public string keys { get; set; }            //主キー
        public string itemnm { get; set; }          //変更項目
        public string valuebefore { get; set; }     //変更前内容
        public string valueafter { get; set; }      //更新後内容
    }

    /// <summary>
    /// 宛名番号ログ情報(詳細画面)
    /// </summary>
    public class AtenaRowVM
    {
        public long atenalogseq { get; set; }   //宛名番号ログシーケンス
        public string atenano { get; set; }     //宛名番号
        public string name { get; set; }        //氏名
        public string kname { get; set; }       //カナ氏名
        public string sex { get; set; }         //性別
        public string bymd { get; set; }        //生年月日
        public string adrs { get; set; }        //住所
        public string gyoseiku { get; set; }    //行政区
        public string juminkbn { get; set; }    //住民区分
        public string pnoflg { get; set; }      //個人番号操作状況
        public string usekbn { get; set; }      //操作区分
    }

    public class CSVRowVM
    {
        public long sessionseq { get; set; }    //ログシーケンス
        public bool existflg1 { get; set; }     //通信ログフラグ
        public bool existflg2 { get; set; }     //バッチログフラグ
        public bool existflg3 { get; set; }     //外部連携ログフラグ
        public bool existflg4 { get; set; }     //DB操作ログフラグ
        public bool existflg5 { get; set; }     //項目値変更ログフラグ
        public bool existflg6 { get; set; }     //宛名番号ログフラグ
    }
}