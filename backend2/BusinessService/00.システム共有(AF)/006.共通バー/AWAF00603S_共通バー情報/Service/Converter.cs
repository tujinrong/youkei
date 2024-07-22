// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 共通バー情報
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00603S
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(InitRequest req, List<string> jigyokbns,
                                                                      List<string> jigyocds,
                                                                      List<string> jigyocds_renrakusaki,
                                                                      List<string> jigyocds_follow,
                                                                      string setaino)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(InitRequest.atenano)}_in", req.atenano),                                                  //宛名番号
                new($"{nameof(tt_afmemoDto.kigenymd)}_in", FormatYMD(DaUtil.Now)),                                      //今日
                new($"{nameof(tt_afmemoDto.jigyokbn)}s_in", ListToCommaStr(jigyokbns)),                                 //登録事業（共通・各事業）
                new($"{nameof(tt_afkojindocDto.jigyocd)}s_in", ListToCommaStr(jigyocds)),                               //利用事業コード 電子ファイル
                new($"{nameof(tt_afrenrakusakiDto.jigyocd)}s_renrakusaki_in", ListToCommaStr(jigyocds_renrakusaki)),    //利用事業コード 連絡先
                new($"jigyocds_follow_in", ListToCommaStr(jigyocds_follow)),                                            //利用事業コード フォロー管理
                new($"{nameof(tt_afmemosetaiDto.setaino)}_in", setaino),                                                //世帯番号
            };
            return paras;
        }
    }
}