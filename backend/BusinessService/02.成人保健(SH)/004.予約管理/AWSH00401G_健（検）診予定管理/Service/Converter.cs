// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診予定管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.13
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00401G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 固定検索条件取得
        /// </summary>
        public static FrConditionModel GetFixedCondition(SearchListRequest req)
        {
            var fixedCondition = new FrConditionModel();
            //年度
            fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nendo), FrEnumValueOprator.EQ, req.nendo);

            //成人健（検）診予約日程事業コード
            if (!string.IsNullOrEmpty(req.jigyocd))
            {
                fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.jigyocd), FrEnumValueOprator.EQ, req.jigyocd);
            }

            //実施予定日(開始)
            if (!string.IsNullOrEmpty(req.yoteiymdf))
            {
                fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.yoteiymd), FrEnumValueOprator.GE, req.yoteiymdf);
            }

            //実施予定日(終了)
            if (!string.IsNullOrEmpty(req.yoteiymdt))
            {
                fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.yoteiymd), FrEnumValueOprator.LE, req.yoteiymdt);
            }

            //会場コード
            if (!string.IsNullOrEmpty(req.kaijocd))
            {
                fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.kaijocd), FrEnumValueOprator.EQ, req.kaijocd);
            }

            //医療機関コード
            if (!string.IsNullOrEmpty(req.kikancd))
            {
                fixedCondition.And(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.kikancd), FrEnumValueOprator.EQ, req.kikancd);
            }

            //従事者（担当者）
            if (!string.IsNullOrEmpty(req.staffid))
            {
                fixedCondition.And(tt_shkensinyotei_staffDto.TABLE_NAME, nameof(tt_shkensinyotei_staffDto.staffid), FrEnumValueOprator.EQ, req.staffid);
            }

            return fixedCondition;
        }
        /// <summary>
        /// 健（検）診予定テーブル
        /// </summary>
        public static tt_shkensinyoteiDto GetDto(tt_shkensinyoteiDto dto, int nendo, int nitteino, DetailSaveVM vm)
        {
            dto.nendo = nendo;                                          //年度
            dto.nitteino = nitteino;                                    //日程番号
            dto.jigyocd = DaSelectorService.GetCd(vm.jigyocdnm);        //成人健（検）診予約日程事業コード
            dto.yoteiymd = vm.yoteiymd;                                 //実施予定日
            dto.tmf = vm.timef;                                       //開始時間
            dto.tmt = vm.timet;                                       //終了時間
            dto.kaijocd = DaSelectorService.GetCd(vm.kaijocdnm);        //会場コード
            dto.kikancd = CNStr(DaSelectorService.GetCd(vm.kikancdnm)); //医療機関コード
            dto.teiin = CInt(vm.teiin);                                 //定員

            return dto;
        }
        /// <summary>
        /// 健（検）診予定詳細テーブルリスト
        /// </summary>
        public static List<tt_shkensinyoteisyosaiDto> GetDtl(int nendo, int nitteino, List<RowSaveVM> vmList)
        {
            var dtl = new List<tt_shkensinyoteisyosaiDto>();
            foreach (var vm in vmList)
            {
                dtl.Add(GetDto(nendo, nitteino, vm));
            }

            return dtl;
        }
        /// <summary>
        /// 健（検）診予定担当者テーブルリスト
        /// </summary>
        public static List<tt_shkensinyotei_staffDto> GetDtl(int nendo, int nitteino, List<string> staffids)
        {
            var dtl = new List<tt_shkensinyotei_staffDto>();
            foreach (var id in staffids)
            {
                dtl.Add(GetDto(nendo, nitteino, id));
            }

            return dtl;
        }
        /// <summary>
        /// 健（検）診予定詳細テーブル
        /// </summary>
        private static tt_shkensinyoteisyosaiDto GetDto(int nendo, int nitteino, RowSaveVM vm)
        {
            var dto = new tt_shkensinyoteisyosaiDto();
            dto.nendo = nendo;                          //年度
            dto.nitteino = nitteino;                    //日程番号
            dto.jigyocd = vm.jigyocd;                   //検診種別
            dto.yoyakubunruicd = vm.yoyakubunruicd;     //予約分類コード
            dto.teiin_kensin = CInt(vm.teiin_kensin);   //定員(検診)

            return dto;
        }
        /// <summary>
        /// 健（検）診予定担当者テーブル
        /// </summary>
        private static tt_shkensinyotei_staffDto GetDto(int nendo, int nitteino, string staffid)
        {
            var dto = new tt_shkensinyotei_staffDto();
            dto.nendo = nendo;          //年度
            dto.nitteino = nitteino;    //日程番号
            dto.staffid = staffid;      //担当者

            return dto;
        }
    }
}