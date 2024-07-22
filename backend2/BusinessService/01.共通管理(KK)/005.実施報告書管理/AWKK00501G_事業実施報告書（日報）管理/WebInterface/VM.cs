// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業実施報告書（日報）管理
//             ビューモデル定義
// 作成日　　: 2023.11.08
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK00501G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM
    {
        public int hokokusyono { get; set; }          //事業報告書番号
        public string jissiymd { get; set; }          //実施日
        public string jissitime { get; set; }         //時間
        public string kaijonm { get; set; }           //会場名
        public string jigyonm { get; set; }           //事業名
        public string staffnm { get; set; }           //従事者(「,」区切り)
        public string upddttm { get; set; }           //更新日時
        public string updusernm { get; set; }         //更新者
        public string regsisyo { get; set; }          //登録支所
    }

    /// <summary>
    /// 事業従事者（担当者）情報
    /// </summary>
    public class StaffVM
    {
        public string staffid { get; set; }            //事業従事者ID
        public string staffsimei { get; set; }         //事業従事者氏名
        public string kanastaffsimei { get; set; }     //事業従事者カナ氏名
        public string syokusyu { get; set; }           //職種
        public string katudokbn { get; set; }          //活動区分
        public string stopflg { get; set; }            //利用状態
    }

    /// <summary>
    /// 実施報告書（日報）情報
    /// </summary>
    public class JissihokokusyoVM
    {
        public string jigyo { get; set; }               //事業
        public string kaijo { get; set; }               //会場
        public string jissiymd { get; set; }            //実施日
        public string timef { get; set; }               //開始時間
        public string timet { get; set; }               //終了時間
        public int mantotalnum { get; set; }            //男性延べ人数
        public int womantotalnum { get; set; }          //女性延べ人数
        public int fumeitotalnum { get; set; }          //性別不明延べ人数
        public int mannum { get; set; }                 //男性実人数
        public int womannum { get; set; }               //女性実人数
        public int fumeinum { get; set; }               //性別不明実人数
        public int syussekisya { get; set; }            //出席者数
        public string? jigyomokuteki { get; set; }      //実施目的
        public string? jissinaiyo { get; set; }         //実施内容
        public string? baitai { get; set; }             //媒体
        public string? haifusiryo { get; set; }         //配布資料
        public string? comment { get; set; }            //コメント
        public string? hanseipoint { get; set; }        //反省点
    }
}