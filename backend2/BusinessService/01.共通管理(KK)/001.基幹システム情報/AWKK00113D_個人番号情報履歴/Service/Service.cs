// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人番号情報履歴
// 　　　　　　サービス処理
// 作成日　　: 2023.11.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00113D
{
    [DisplayName("個人番号情報履歴")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人番号管理テーブル
                var dtl = db.tt_afpersonalno.SELECT.WHERE.ByKey(req.atenano).GetDtoList().OrderByDescending(e => e.saisinflg).ThenByDescending(e => e.rirekino).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------

                //権限関連
                //Todo：（とりあえず権限フラグをtrueに設定する）
                //var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWKK00111G);
                var personalflg = true;

                //暗号化
                var publickey = string.Empty;   //公開キー(暗号化)
                var privatekey = string.Empty;  //秘密キー(復号化)
                                                //キー取得
                DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

                //履歴一覧
                res.kekkalist = new Wraper().GetVMList(db, dtl, personalflg, publickey);

                //rsaキー
                res.rsaprivatekey = privatekey;

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }
    }
}