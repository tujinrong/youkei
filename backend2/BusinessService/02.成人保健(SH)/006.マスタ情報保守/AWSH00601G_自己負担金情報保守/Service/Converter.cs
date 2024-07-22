// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 自己負担金情報保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.03.05
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00601G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tm_shjikofutankinDto.nendo)}_in", req.nendo));                                                  //年度
            paras.Add(new AiKeyValue($"{nameof(tm_shjikofutankinDto.kensin_jigyocd)}_in", CmLogicUtil.GetSearchPara(req.kensin_jigyocd)));     //成人健(検)診事業名
            paras.Add(new AiKeyValue($"{nameof(tm_shjikofutankinDto.ryokinpattern)}_in", CmLogicUtil.GetSearchPara(req.ryokinpattern)));       //料金パターン

            return paras;
        }

        /// <summary>
        /// 自己負担金リスト(排他用)
        /// </summary>
        public static List<object[]> GetKeyList(int nendo, string kensin_jigyocd, string ryokinpattern, List<LockVM> locklist)
        {
            return locklist.Select(cd => new object[]
            {
                nendo,                          //年度
                kensin_jigyocd,                 //成人健(検)診事業名
                ryokinpattern,                  //料金パターン
                cd.kensahohocd,                 //検査方法コード
                cd.sex,                         //性別
                cd.agehani,                     //年齢範囲
                cd.genmenkbncd                  //減免区分
            }).ToList();
        }

        /// <summary>
        /// 自己負担金マスタリスト
        /// </summary>
        public static List<tm_shjikofutankinDto> GetDtl(int nendo, List<RowVM> vmList)
        {
            var dtl = new List<tm_shjikofutankinDto>();
            {
                foreach (var vm in vmList)
                {
                    var dto = new tm_shjikofutankinDto();
                    dto.nendo = nendo;                                      //年度  
                    dto.kensin_jigyocd = vm.kensin_jigyocd;                 //成人健（検）診事業コード  
                    dto.ryokinpattern = vm.ryokinpattern;                   //料金パターン
                    dto.kensahohocd = vm.kensahohocd;                       //検査方法コード
                    dto.sex = vm.sex.Trim(',').Trim('-');                   //性別  
                    dto.agehani = vm.agehani;                               //年齢範囲 
                    dto.genmenkbn = vm.genmenkbncd;                         //減免区分  
                    dto.jusinkingaku = vm.jusinkingaku;                     //受診金額
                    dto.kingaku_sityosonhutan = vm.kingaku_sityosonhutan;   //金額（市区町村負担） 

                    dtl.Add(dto);
                }
            }

            return dtl;
        }
    }
}