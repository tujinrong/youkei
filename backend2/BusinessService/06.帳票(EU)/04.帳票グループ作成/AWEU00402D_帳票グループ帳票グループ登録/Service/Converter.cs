// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ帳票グループ登録
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00402D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 帳票グループマスタ情報を取得
        /// </summary>
        public static tm_eurptgroupDto GetDto(SaveRequest req, DateTime dttm)
        {
            var dto = new tm_eurptgroupDto();
            dto.rptgroupnm = req.rptgroupnm;                    //帳票グループ
            dto.gyomukbn = req.gyomukbn;                        //業務区分
            dto.kojinrenrakusakicd = req.kojinrenrakusakicd;    //個人連絡先
            dto.memocd = req.memocd;                            //メモ情報
            dto.electronfilecd = req.electronfilecd;            //電子ファイル情報
            dto.followmanage = req.followmanage;                //フォロー管理  
            dto.orderseq = req.orderseq;                        //並び順
            dto.upduserid = req.userid;                         //更新ユーザーID
            dto.upddttm = dttm;                                 //更新日時
            return dto;
        }
    }
}