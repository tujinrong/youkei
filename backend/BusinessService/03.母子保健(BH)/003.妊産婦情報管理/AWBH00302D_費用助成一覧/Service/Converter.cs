// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 妊産婦情報管理-費用助成一覧
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.05.14
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00302D
{
    public class Converter : CmConerterBase
    {
        //================================= ⑨費用助成一覧画面保存処理 =================================
        /// <summary>
        /// 妊婦健診費用助成（固定）サブテーブル
        /// </summary>
        public static List<tt_bhnsninpukensinhiyojosei_subDto> GetDtl(List<tt_bhnsninpukensinhiyojosei_subDto> newdtl, SaveJyoseiRequest req, string jigyocd)
        {
            var i = 1;
            //費用助成一覧
            foreach (var dt in req.jyoseilistinfo)
            {
                var newdto = new tt_bhnsninpukensinhiyojosei_subDto()
                {
                    jigyocd = jigyocd,                                      //母子保健事業コード
                    atenano = req.atenano,                                  //宛名番号
                    torokuno = req.torokuno,                                //登録番号
                    sinseiedano = req.sinseiedano,                          //申請枝番
                    edano = i,                                              //枝番
                    joseikensyurui = CStr(GetCd(dt.joseikensyurui)),        //助成券種類
                    jusinymd = dt.jusinymd,                                 //受診年月日
                    siharaikingaku = dt.siharaikingaku,                     //支払金額
                    joseikingaku = dt.joseikingaku                          //助成金額
                };
                newdtl.Add(newdto);
                i++;
            }

            return newdtl;
        }

        /// <summary>
        /// 産婦健診費用助成（固定）サブテーブル
        /// </summary>
        public static List<tt_bhnssanpukensinhiyojosei_subDto> GetDtl(List<tt_bhnssanpukensinhiyojosei_subDto> newdtl, SaveJyoseiRequest req)
        {
            var i = 1;
            //費用助成一覧
            foreach (var dt in req.jyoseilistinfo)
            {
                var newdto = new tt_bhnssanpukensinhiyojosei_subDto()
                {
                    atenano = req.atenano,                                  //宛名番号
                    torokuno = req.torokuno,                                //登録番号
                    sinseiedano = req.sinseiedano,                          //申請枝番
                    edano = i,                                              //枝番
                    joseikensyurui = CStr(GetCd(dt.joseikensyurui)),        //助成券種類
                    jusinymd = dt.jusinymd,                                 //受診年月日
                    siharaikingaku = dt.siharaikingaku,                     //支払金額
                    joseikingaku = dt.joseikingaku                          //助成金額
                };
                newdtl.Add(newdto);
                i++;
            }

            return newdtl;
        }

        /// <summary>
        /// 妊産婦（フリー）項目テーブル
        /// </summary>
        public static List<tt_bhnsfreeDto> GetDtl(SaveJyoseiRequest req, string jigyocd, string keyitemcd)
        {
            var newfreedtl = new List<tt_bhnsfreeDto>();

            var joseikingakusogaku = req.jyoseilistinfo.Select(e => e.joseikingaku).Sum();

            var newfreedto = new tt_bhnsfreeDto()
            {

                jigyocd = jigyocd,                                          //母子保健事業コード
                atenano = req.atenano,                                      //宛名番号
                torokuno = req.torokuno,                                    //登録番号
                torokunorenban = 0,                                         //登録番号連番（多胎管理でない場合は0）
                edano = req.sinseiedano,                                    //枝番（申請枝番）
                //TODO：zhang20240617
                //kaisu = 0,                                                  //回数（履歴回数管理でない場合は0）
                kaisu = "0",                                                //回数（履歴回数管理でない場合は"0"）
                itemcd = keyitemcd,                                         //項目コード
                fusyoflg = false,                                           //不詳フラグ
                numvalue = joseikingakusogaku                               //数値項目
            };
            newfreedtl.Add(newfreedto);

            return newfreedtl;
        }
    }
}