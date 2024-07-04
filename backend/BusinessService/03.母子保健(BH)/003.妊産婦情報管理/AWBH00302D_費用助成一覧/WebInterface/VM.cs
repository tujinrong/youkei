// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 妊産婦情報管理-費用助成一覧
//             ビューモデル定義
// 作成日　　: 2024.05.14
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00302D
{
    /// <summary>
    /// 費用助成ヘッダー部分情報
    /// </summary>
    public class JyoseiHeaderInfoVM
    {
        public string atenano { get; set; }             //宛名番号
        public string name { get; set; }                //氏名
        public long torokuno { get; set; } = 0;         //登録番号
        public string sinseiymd { get; set; }           //申請日
    }

    /// <summary>
    /// 費用助成一覧（表示用）
    /// </summary>
    public class JyoseiListInfoVM
    {
        public string no { get; set; }                  //No.
        public string joseikensyurui { get; set; }      //助成券種類
        public string jusinymd { get; set; }            //受診年月日
        public int siharaikingaku { get; set; }         //支払金額
        public int joseikingaku { get; set; }           //助成金額
        public int joseikingakulimit { get; set; }      //助成金額（上限額）
    }

    /// <summary>
    /// 費用助成フッター情報
    /// </summary>
    public class JyoseiFooterInfoVM
    {
        public double joseikingakusogaku { get; set; }  //助成金額（総額）
    }
}