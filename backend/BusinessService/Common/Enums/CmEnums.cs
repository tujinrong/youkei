// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: システム共通(業務)
//             区分列挙型
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public enum EnumRuntimeMode
    {
        NORMAL,
        DEBUG,
        STUB
    }

    public enum EnumDownloadType
    {
        File,
        Data
    }
}