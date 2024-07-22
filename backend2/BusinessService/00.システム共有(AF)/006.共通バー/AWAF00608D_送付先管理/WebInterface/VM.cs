// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 送付先管理
//             ビューモデル定義
// 作成日　　: 2023.11.14
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00608D
{
    /// <summary>
    /// 初期化処理(一覧、詳細画面共用)
    /// </summary>
    public class PersonHeaderVM : CommonBarHeaderBaseVM
    {
        public string jutokbnnm { get; set; }             //住登区分
        public string juminsyubetunm { get; set; }        //住民種別
        public string juminjotainm { get; set; }          //住民状態
        public string adrs_yubin { get; set; }            //郵便番号
        public string adrs { get; set; }                  //住所
    }                                                     
                                                          
    /// <summary>                                         
    /// 初期化処理(一覧画面一覧)                          
    /// </summary>                                        
    public class RowVM                                    
    {                                                     
        public string riyomokutekicd { get; set; }        //利用目的コード
        public string riyomokutekinm { get; set; }        //利用目的名称
        public string torokujiyu { get; set; }            //登録事由
        public string sofusaki_yubin { get; set; }        //送付先郵便番号
        public string sofusaki_adrs { get; set; }         //送付先住所
        public string sofusaki_simei { get; set; }        //送付先氏名
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class MainInfoVM
    {
        public string atenano { get; set; }               //宛名番号
        public string riyomokuteki { get; set; }          //利用目的
        public string? torokujiyu { get; set; }           //登録事由
        public string adrs_yubin { get; set; }       　   //郵便番号
        public string adrs_sikucd { get; set; }           //市区町村リスト  コード
        public string adrs_tyoazacd { get; set; }         //町字リスト  コード
        public string adrs_tyoaza { get; set; }           //町字リスト  名称
        public string? adrs_tyoaza_in { get; set; }       //町字(手入力)
        public string? adrs_bantihyoki { get; set; }      //番地号表記
        public string? adrs_katagaki { get; set; }        //方書
        public string sofusaki_simei { get; set; }        //氏名
        public string regsisyo { get; set; }              //登録支所
        public DateTime? upddttm { get; set; }            //更新日時(排他用)
        public bool updflg { get; set; }                  //更新権限フラグ
    }

    /// <summary>
    /// 自動入力処理(詳細画面)
    /// </summary>
    public class AutoSetVM
    {
        public string adrs_sikucd { get; set; }           //市区町村（コード）
        public string adrs_yubin { get; set; }            //郵便番号
        public string adrs_tyoazacd { get; set; }         //町字（コード）
    }
}