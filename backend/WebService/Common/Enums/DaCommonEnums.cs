// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: システム共通
//             区分列挙型
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
namespace JBD.GJS.Common
{
    /// <summary>
    /// レスポンス状態区分
    /// </summary>
    public enum EnumServiceResult
    {
        OK,             //正常
        ServiceError,   //エラー
        ServiceAlert,   //アラート
        Hidden,         //非表示
        Exception,      //例外
        Forbidden,      //利用不可
        AuthError,      //権限認証失敗
        ServiceAlert2,  //アラート2(はいだけ)
    }

    public enum EnumLogStatus
    {
        正常終了 = 0,
        異常終了 = 1,
        要確認 = 3,
        処理停止 = 4,
    }

    /// <summary>
    /// 操作区分
    /// </summary>
    public enum EnumAtenaActionType
    {
        追加 = 1,
        更新 = 2,
        削除 = 3,
        検索
    }

    /// <summary>
    /// 連携区分
    /// </summary>
    public enum EnumGaibuKbn
    {
        FromGaibu = 1,  //他システムから取得;
        ToGaibu         //他システムへ出力
    }

    /// <summary>
    /// 連携方式		
    /// </summary>
    public enum EnumGaibuDataType
    {
        CSV = 1,
        API
    }

    /// <summary>
    /// ファイル種類
    /// </summary>
    public enum EnumFileTypeKbn
    {
        Empty = -1,
        csv = 1,
        doc,
        jpg,
        jpeg,
        png,
        pdf,
        tif,
        txt,
        xml,
        xls,
        xlsm,
        xlsx,
        zip
    }
}