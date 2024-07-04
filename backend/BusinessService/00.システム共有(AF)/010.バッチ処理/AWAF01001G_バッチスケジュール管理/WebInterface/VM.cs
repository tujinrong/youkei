// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチスケジュール管理
//           ビューモデル定義
// 作成日　　: 2024.02.06
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF01001G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM
    {
        public string taskid { get; set; }                  //タスクID
        public string tasknm { get; set; }                  //タスク名
        public string syorikbn { get; set; }                //処理区分
        public string gyomukbn { get; set; }                //業務区分
        public string jikkohindo { get; set; }              //頻度
        public string hindosyosai { get; set; }             //頻度詳細
        public string? jikaijikkodttmt { get; set; }        //次回処理日時
        public string? syoridttmt { get; set; }             //処理日時（開始）
        public string statuscd { get; set; }                //処理結果コード
        public Enum表示色区分 colorkbn { get; set; }        //処理結果表示色区分
        public string jotai { get; set; }                   //状態
    }

    /// <summary>
    /// バッチスケジュール管理情報
    /// </summary>
    public class MainInfoVM
    {
        public string taskid { get; set; }                  //タスクID             
        public string tasknm { get; set; }                  //タスク名
        public string? biko { get; set; }                   //説明
        public DateTime? zenjikkodttmf { get; set; }        //前回の実行日時（開始）
        public DateTime? zenjikkodttmt { get; set; }        //前回の実行日時（終了）
        public DateTime? jikaijikkodttmt { get; set; }      //次回実行日時
        public string syorikbn { get; set; }                //処理区分
        public string jotai { get; set; }                   //状態
        public string gyomukbn { get; set; }                //業務区分
        public string modulecd { get; set; }                //モジュール名
        public string? hikisu { get; set; }                 //引数
        public string yukoymdf { get; set; }                //有効年月日（開始）
        public string yukotmf { get; set; }                 //有効時間（開始）
        public string hindokbn { get; set; }                //頻度区分
        public bool syukustopflg { get; set; }              //祝日停止フラグ
        public string[] yobi { get; set; }                  //曜日
        public string? maitukihiyobikbn { get; set; }       //毎月の日・曜日区分
        public string[] maitukituki { get; set; }           //毎月の月
        public string[] maitukihi { get; set; }             //毎月の日
        public string[] maitukisyu { get; set; }            //毎月の週
        public string statuscd { get; set; }                //処理結果コード
        public bool? kurikaesikanflg { get; set; }          //繰り返し間隔フラグ
        public string? kurikaesikankbn { get; set; }        //繰り返し間隔区分
        public string? jikantaif { get; set; }              //時間帯開始_時
        public string? jikantait { get; set; }              //時間帯終了_時
        public string? jikannaif { get; set; }              //時間内開始_分
        public string? jikannait { get; set; }              //時間内終了_分
        public bool? sunday { get; set; }                   //曜日(日)                                                     
        public bool? monday { get; set; }                   //曜日(月)
        public bool? tuesday { get; set; }                  //曜日(火)                                                     
        public bool? wednesday { get; set; }                //曜日(水)                                                     
        public bool? thursday { get; set; }                 //曜日(木)
        public bool? friday { get; set; }                   //曜日(金)
        public bool? saturday { get; set; }                 //曜日(土)
    }
}