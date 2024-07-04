// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メモ情報（世帯）
//             ビューモデル定義
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00604D
{
    /// <summary>
    /// 世帯主基本情報
    /// </summary>
    public class HeaderVM : CommonBarHeaderBaseVM
    {
        public string setaino { get; set; } //世帯番号
    }
}