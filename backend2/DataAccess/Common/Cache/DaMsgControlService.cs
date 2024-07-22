// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メッセージコントロールマスタ
//
// 作成日　　: 2024.07.28
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public static class DaMsgControlService
    {
        private const double CacheMinutes = 3d;
        private static readonly object LockObj = new();
        private static Dictionary<string, tm_afmsgctrlDto> _dic = new();
        private static DateTime _lastTime;

        public static tm_afmsgctrlDto GetMsgDto(DaDbContext db, string ctrlmsgid)
        {
            lock (LockObj)
            {
                InitCache(db);
                return _dic.TryGetValue(ctrlmsgid, out var dto) ? dto : new tm_afmsgctrlDto();
            }
        }

        private static void InitCache(DaDbContext db)
        {
            if (DaUtil.Now.Subtract(_lastTime).TotalMinutes < CacheMinutes) return;
            _dic = db.tm_afmsgctrl.SELECT.GetDtoList().ToDictionary(x => x.ctrlmsgid, x => x);
            _lastTime = DaUtil.Now;
        }

        public static TRes GetNotOkResponse<TRes>(DaDbContext db, string ctrlmsgid, params object[] param) where TRes : DaResponseBase, new()
        {
            var res = new TRes();
            //メッセージ切替区分を取得
            var msgDto = GetMsgDto(db, ctrlmsgid);

            switch (msgDto.msgkbn)
            {
                //エラーの場合
                case EnumMsgCtrlKbn.エラー:
                    res.SetServiceError(DaMessageService.GetMsg(msgDto.errormsgid, param));
                    break;
                //アラートの場合
                case EnumMsgCtrlKbn.アラート:
                    res.SetServiceAlert(DaMessageService.GetMsg(msgDto.alertmsgid, param));
                    break;
                //非表示の場合
                case EnumMsgCtrlKbn.非表示:
                default:
                    res.SetServiceHidden();
                    break;
            }
            return res;
        }
    }
}