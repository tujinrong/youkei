// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ベースロジック
//             レスポンスインターフェースベース
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json;

namespace BCC.Affect.DataAccess
{
    public class DaResponseBase
    {
        public EnumServiceResult returncode { get; set; } = EnumServiceResult.OK;   //レスポンス状態区別
        public string message { get; set; }                                         //メッセージ
        [JsonIgnore]
        public string? rsaprivatekey { get; set; }                                  //秘密キー(復号化用)
        /// <summary>
        /// エラーメッセージ設定
        /// </summary>
        public void SetServiceError(string msg)
        {
            message = msg;
            returncode = EnumServiceResult.ServiceError;
        }
        /// <summary>
        /// エラーメッセージ設定
        /// </summary>
        public void SetServiceError(EnumMessage msgID, params string[] param)
        {
            message = DaMessageService.GetMsg(msgID, param);
            returncode = EnumServiceResult.ServiceError;
        }
        /// <summary>
        /// アラートメッセージ設定
        /// </summary>
        public void SetServiceAlert(string msg)
        {
            message = msg;
            returncode = EnumServiceResult.ServiceAlert;
        }
        /// <summary>
        /// アラートメッセージ設定
        /// </summary>
        public void SetServiceAlert(EnumMessage msgID, params string[] param)
        {
            message = DaMessageService.GetMsg(msgID, param);
            returncode = EnumServiceResult.ServiceAlert;
        }

        /// <summary>
        /// アラート2メッセージ設定
        /// </summary>
        public void SetServiceAlert2(string msg)
        {
            message = msg;
            returncode = EnumServiceResult.ServiceAlert2;
        }
        /// <summary>
        /// アラート2メッセージ設定
        /// </summary>
        public void SetServiceAlert2(EnumMessage msgID, params string[] param)
        {
            message = DaMessageService.GetMsg(msgID, param);
            returncode = EnumServiceResult.ServiceAlert2;
        }
        /// <summary>
        /// メッセージ非表示設定
        /// </summary>
        public void SetServiceHidden()
        {
            returncode = EnumServiceResult.Hidden;
        }
    }
}