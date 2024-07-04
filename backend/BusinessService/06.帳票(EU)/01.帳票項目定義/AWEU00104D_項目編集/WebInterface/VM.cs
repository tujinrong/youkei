// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目編集
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00104D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class TableVM
    {
        public string tablealias { get; set; }        //テーブル·別名
        public string tablenm { get; set; }           //テーブル物理名
        public string tablehyojinm { get; set; }      //テーブル名称
        public string kanrentablealias { get; set; } //関連テーブル別名
    }
}