// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ帳票グループ登録
// 　　　  　　DB項目から画面項目に変換 
// 作成日　　: 2023.10.31
// 作成者　　:  
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00402D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 詳細情報をセット
        /// </summary>
        public static void SetDetailVM(DaDbContext db, InitResponse res, tm_eurptgroupDto dto)
        {
            res.rptgroupnm = dto.rptgroupnm;                                //帳票グループ名
            res.gyomukbn = dto.gyomukbn;                                    //業務区分
            res.kojinrenrakusakicd = CStr(dto.kojinrenrakusakicd);          //個人連絡先
            res.memocd = CStr(dto.memocd);                                  //メモ情報（複数）
            res.electronfilecd = CStr(dto.electronfilecd);                  //電子ファイル（複数）
            res.followmanage = CStr(dto.followmanage);                      //フォロー管理（複数）
            res.orderseq = dto.orderseq;                                    //並び順
        }
    }
}