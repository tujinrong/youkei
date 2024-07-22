// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: パスワード変更
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.22
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWAF00201D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// ユーザーマスタDto
        /// </summary>
        public static tm_afuserDto GetDto(SaveRequest req, tm_afuserDto dto)
        {
            dto.pword = req.newpword;                       //パスワードを変更
            dto.pwordhenkoymd = FormatYMD(DaUtil.Today);    //パスワード変更年月日(今日)
            return dto;
        }
    }
}