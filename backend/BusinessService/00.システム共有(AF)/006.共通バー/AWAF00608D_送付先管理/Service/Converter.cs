// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 送付先管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.11.14
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00608D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tt_afsofusakiDto.atenano)}_in", req.atenano));    //宛名番号

            return paras;
        }

        /// <summary>
        /// 送付先管理テーブル
        /// </summary>
        public static tt_afsofusakiDto GetDto(tt_afsofusakiDto dto, MainInfoVM vm, tm_afsikutyosonDto dto2)
        {
            dto.atenano = vm.atenano;                      //宛名番号
            dto.riyomokuteki = vm.riyomokuteki;            //利用目的
            dto.torokujiyu = vm.torokujiyu;                //登録事由
            dto.adrs_yubin = vm.adrs_yubin;                //郵便番号
            dto.adrs_sikucd = vm.adrs_sikucd;              //住所_市区町村コード
            dto.adrs_todofuken = dto2.todofukennm;         //住所_都道府県
            dto.adrs_sikunm = dto2.sikunm;                 //住所_市区郡町村名
            dto.adrs_tyoazacd = vm.adrs_tyoazacd;          //住所_町字コード
            //町字コード='9999999'の場合
            if(dto.adrs_tyoazacd == AWAF00608D.Service.TYOAZACD_NULL)
            {
                dto.adrs_tyoaza = vm.adrs_tyoaza_in;       //住所_町字  町字(手入力)
            }
            else
            {
                dto.adrs_tyoaza = vm.adrs_tyoaza;          //住所_町字
            }
            dto.adrs_bantihyoki = vm.adrs_bantihyoki;      //番地号表記
            dto.adrs_katagaki = vm.adrs_katagaki;          //方書
            dto.sofusaki_simei = vm.sofusaki_simei;        //氏名

            return dto;
        }
    }
}
