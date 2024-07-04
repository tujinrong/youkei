// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診予約希望者管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.19
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00402G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 固定検索条件取得(日程一覧画面)
        /// </summary>
        public static FrConditionModel GetFixedCondition(SearchListRequest req)
        {
            var fixedCondition = AWSH00401G.Converter.GetFixedCondition(req);
            //宛名番号
            if (!string.IsNullOrEmpty(req.atenano))
            {
                fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumValueOprator.EQ, req.atenano);
            }
            //個人番号
            if (!string.IsNullOrEmpty(req.personalno))
            {
                //検索のため暗号化
                fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.personalno), FrEnumValueOprator.EQ, CStr(CmLogicUtil.GetPersonalnoDB(req.personalno)));
            }

            return fixedCondition;
        }

        /// <summary>
        /// 固定検索条件取得(予約者一覧画面：予約情報)
        /// </summary>
        public static FrConditionModel GetFixedCondition(int nendo, int nitteino)
        {
            var fixedCondition = new FrConditionModel();
            //年度
            fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nendo), FrEnumValueOprator.EQ, nendo);
            //日程番号
            fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino), FrEnumValueOprator.EQ, nitteino);

            return fixedCondition;
        }

        /// <summary>
        /// 固定検索条件取得(予約者一覧画面：予約者情報)
        /// </summary>
        public static FrConditionModel GetFixedCondition2(InitPersonListRequest req)
        {
            var fixedCondition = new FrConditionModel();
            //年度
            fixedCondition.And(tt_shkensinyoyakukibosyaDto.TABLE_NAME, nameof(tt_shkensinyoyakukibosyaDto.nendo), FrEnumValueOprator.EQ, req.nendo);
            //日程番号
            fixedCondition.And(tt_shkensinyoyakukibosyaDto.TABLE_NAME, nameof(tt_shkensinyoyakukibosyaDto.nitteino), FrEnumValueOprator.EQ, req.nitteino);

            return fixedCondition;
        }

        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(int nendo, string atenano, string yoteiymd)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(InitDetailRequest.nendo)}_in", nendo),        //年度
                new($"{nameof(InitDetailRequest.atenano)}_in", atenano),    //宛名番号
                new($"{nameof(tt_shkensinyoteiDto.yoteiymd)}_in", yoteiymd) //実施予定日
            };
            return paras;
        }

        /// <summary>
        /// 健（検）診予定テーブル
        /// </summary>
        public static tt_shkensinyoyakukibosyaDto GetDto(tt_shkensinyoyakukibosyaDto dto, string biko, int nendo, int nitteino, string atenano, int yoyakuno)
        {
            dto.nendo = nendo;          //年度
            dto.nitteino = nitteino;    //日程番号
            dto.atenano = atenano;      //宛名番号
            dto.yoyakuno = yoyakuno;    //予約番号
            dto.biko = CNStr(biko);     //備考

            return dto;
        }
        /// <summary>
        /// 健（検）診予約希望者詳細テーブルリスト
        /// </summary>
        public static List<tt_shkensinkibosyasyosaiDto> GetDtl(int nendo, string atenano, List<DetailRowSaveVM> vmList, List<string> cdList)
        {
            var dtl = new List<tt_shkensinkibosyasyosaiDto>();
            foreach (var vm in vmList)
            {
                dtl.Add(GetDto(nendo, atenano, vm, cdList));
            }

            return dtl;
        }
        /// <summary>
        /// 健（検）診予約希望者詳細テーブル
        /// </summary>
        private static tt_shkensinkibosyasyosaiDto GetDto(int nendo, string atenano, DetailRowSaveVM vm, List<string> cdList)
        {
            var dto = new tt_shkensinkibosyasyosaiDto();
            dto.nendo = nendo;                                                                  //年度
            dto.nitteino = CInt(vm.nitteino);                                                   //日程番号
            dto.atenano = atenano;                                                              //宛名番号
            dto.jigyocd = vm.jigyocd;                                                           //検診種別
            if (cdList.Contains(vm.jigyocd))
            {
                dto.kensahohocd = DaSelectorService.GetCd(vm.kensahohocdnm);                    //検査方法コード
            }
            else
            {
                dto.kensahohocd = AWSH00301G.Service.KENSAHOHOCD;                               //検査方法コード
            }
            dto.cancelmatiflg = vm.taikiflg ? Enum待機フラグ.希望する : Enum待機フラグ.希望しない;   //待機フラグ
            dto.syokaiuketukeymd = CNStr(vm.syokaiuketukeymd);                                  //初回受付日
            dto.henkouketukeymd = CNStr(vm.henkouketukeymd);                                    //受付変更日

            return dto;
        }
    }
}