// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 妊産婦情報管理-乳幼児情報一覧
//             ビューモデル定義
// 作成日　　: 2024.05.28
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00303D
{
    /// <summary>
    /// 乳幼児情報一覧_(メイン：ベース)
    /// </summary>
    public class BaseInfoVM
    {
        public string atenano { get; set; }	            //宛名番号		
        public string name { get; set; }	            //氏名			
        public string kname { get; set; }	            //カナ氏名		
        public string sexhyoki { get; set; }	        //性別表記
        public string bymd { get; set; }	            //生年月日		
    }

    /// <summary>
    /// 乳幼児情報一覧_ヘッダー部
    /// </summary>
    public class HeaderInfoVM : BaseInfoVM
    {
        public string juminkbnnm { get; set; }	        //住民区分（内容）
        public string age { get; set; }	                //年齢			
        public string agekijunymd { get; set; }	        //年齡計算基準日		
    }


    /// <summary>
    /// 乳幼児情報一覧（表示用）
    /// </summary>
    public class ListInfoVM : BaseInfoVM
    {
        public string no { get; set; }                  //No.
        public string torokuno { get; set; }            //登録番号
        public string torokunorenban { get; set; }      //登録番号連番
        public string bositetyokofuno { get; set; }     //母子健康手帳交付番号
    }
}