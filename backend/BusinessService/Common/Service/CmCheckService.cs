// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: チェック処理
// 
// 作成日　　: 2023.01.10
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmCheckService
    {
        /// <summary>
        /// 存在チェック
        /// </summary>
        public static bool CheckExist(object? obj, DaResponseBase res, string msg)
        {
            if (obj is null)
            {
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存在チェック
        /// </summary>
        public static bool CheckExist(object? obj, DaResponseBase res, EnumMessage msgID, params string[] param)
        {
            if (obj is null)
            {
                res.SetServiceError(msgID, param);
                return false;
            }
            return true;
        }

        /// <summary>
        /// データ存在チェック
        /// </summary>
        public static bool CheckDeleted(DaResponseBase res, object? dto)
        {
            var msg = DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "更新対象", "更新");
            return CheckDeleted(res, dto, msg);
        }

        /// <summary>
        /// データ存在チェック
        /// </summary>
        public static bool CheckDeleted(DaResponseBase res, object? dto, EnumMessage msgID, params string[] param)
        {
            var msg = DaMessageService.GetMsg(msgID, param);
            return CheckDeleted(res, dto, msg);
        }

        /// <summary>
        /// データ存在チェック
        /// </summary>
        public static bool CheckDeleted(DaResponseBase res, object? dto, string msg)
        {
            if (dto is null)
            {
                res.SetServiceError(msg);
                return false;
            }
            else
            {
                var infos = dto.GetType().GetProperties().ToList();
                if (infos.Exists(x => x.Name == nameof(tm_afuserDto.stopflg)))
                {
                    bool stopflg = (bool)(dto.GetType().GetProperty(nameof(tm_afuserDto.stopflg))!.GetValue(dto)!);
                    if (stopflg)
                    {
                        res.SetServiceError(msg);
                        return false;
                    }
                }
            }
            return true;
        }

        ///// <summary>
        ///// キーの重複チェック
        ///// </summary>
        //public static bool CheckDuplicatKey(Exception ex, string keyName, CmResponseBase res)
        //{
        //    if (ex.GetType() == typeof(AiDbException))
        //    {
        //        AiDbException aiex = (AiDbException)ex;
        //        if (aiex.ExcetionType == EnumDbExcetionType.KeyDuplicate)
        //        {
        //            // 入力された{0}は既に登録されています。
        //            res.ReturnCode = EnumServiceResult.ServiceError;
        //            res.Message = DaMessageService.GetMsg(EnumMessage.CM_KEYDUPLICATE_ERROR, keyName);

        //            return false;
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //    else
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// メッセージボックス設定
        ///// </summary>
        //private static void SetMsgType(EnumMsgKBN kbn, CmSearchResponseBase res, string msg)
        //{
        //    switch (kbn)
        //    {
        //        case EnumMsgKBN.エラー:
        //            {
        //                res.ReturnCode = EnumServiceResult.ServiceError;
        //                break;
        //            }
        //        case EnumMsgKBN.確認:
        //            {
        //                res.ReturnCode = EnumServiceResult.OK;
        //                break;
        //            }
        //    }
        //    res.Message = msg;
        //}

        ///// <summary>
        ///// 存在チェック
        ///// </summary>
        //public static bool CheckItemExist<T>(DaDbContext db,string tableName, string itenName, string value, CmResponseBase res, string message) where T : notnull
        //{
        //    var selecthelper = DaDaoBase.GetSelectHelper<T>(db.Session,tableName);
        //    if (selecthelper.WHERE.ByItem(itenName, value).Exists())
        //    {
        //        res.ReturnCode = EnumServiceResult.ServiceError;
        //        res.Message = message;
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 最大行数チェック
        ///// </summary>
        //// Public Shared Function CheckSearchCount(cnt As Integer, maxConfirm As Integer, MaxError As Integer, res As CmSearchResponseBase) As Boolean
        //public static bool CheckSearchCount(int cnt, int MaxError, CmSearchResponseBase res)
        //{
        //    if (MaxError != 0 && cnt > MaxError)
        //    {
        //        // SetMsgType(EnumMsgKBN.エラー, res, DaMessageService.GetMsg(EnumMessage.E00001, MaxError))
        //        SetMsgType(EnumMsgKBN.エラー, res, $"{MaxError}件以上検索不可");
        //        return false;
        //    }
        //    // If maxConfirm <> 0 AndAlso cnt > maxConfirm Then
        //    // SetMsgType(EnumMsgKBN.確認, res, DaMessageService.GetMsg(EnumMessage.E00001, maxConfirm))
        //    // Return False
        //    // End If
        //    return true;
        //}
    }
}