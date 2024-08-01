// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: システム共通(業務)
//             区分列挙型
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
namespace WebService.Common.Enums
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