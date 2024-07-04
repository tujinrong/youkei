// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業実施報告書（日報）管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.11.20
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00501G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            return new List<AiKeyValue>
            {
                new($"{nameof(SearchListRequest.jissiymdf)}_in", req.jissiymdf), // 実施日（開始）
                new($"{nameof(SearchListRequest.jissiymdt)}_in", req.jissiymdt), // 実施日（終了）
                new($"{nameof(tt_kkjissihokokusyoDto.kaijocd)}_in", CmLogicUtil.GetSearchPara(req.kaijo)), // 会場
                new($"{nameof(tt_kkjissihokokusyoDto.jigyocd)}_in", CmLogicUtil.GetSearchPara(req.jigyo)), // 事業
                new($"{nameof(tt_kkjissihokokusyo_subDto.staffid)}_in", CmLogicUtil.GetSearchPara(req.staff)) // 従事者
            };
        }

        /// <summary>
        /// 実施報告書（日報）情報
        /// </summary>
        public static tt_kkjissihokokusyoDto GetDto(tt_kkjissihokokusyoDto dto, JissihokokusyoVM vm)
        {
            dto.jigyocd = DaSelectorService.GetCd(vm.jigyo); //事業コード
            dto.jissiymd = vm.jissiymd; //実施日
            dto.kaijocd = DaSelectorService.GetCd(vm.kaijo); //会場コード
            dto.timef = CNStr(vm.timef);//開始時間
            dto.timet = CNStr(vm.timet);//終了時間
            dto.syussekisya = Math.Min(Service.MAX_SYUSSEKISYA, vm.syussekisya); //出席者数
            dto.jissinaiyo = string.IsNullOrEmpty(vm.jissinaiyo) ? null : vm.jissinaiyo; //実施内容
            dto.haifusiryo = string.IsNullOrEmpty(vm.haifusiryo) ? null : vm.haifusiryo; //配布資料
            dto.baitai = string.IsNullOrEmpty(vm.baitai) ? null : vm.baitai; //媒体
            dto.mantotalnum = vm.mantotalnum; //男性延べ人数
            dto.womantotalnum = vm.womantotalnum; //女性延べ人数
            dto.fumeitotalnum = vm.fumeitotalnum; //性別不明延べ人数
            dto.mannum = vm.mannum; //男性実人数
            dto.womannum = vm.womannum; //女性実人数
            dto.fumeinum = vm.fumeinum; //性別不明実人数
            dto.comment = string.IsNullOrEmpty(vm.comment) ? null : vm.comment; //コメント
            dto.hanseipoint = string.IsNullOrEmpty(vm.hanseipoint) ? null : vm.hanseipoint; //反省点
            dto.jigyomokuteki = string.IsNullOrEmpty(vm.jigyomokuteki) ? null : vm.jigyomokuteki; //事業目的
            return dto;
        }

        /// <summary>
        /// 実施報告書（日報）情報サブ
        /// </summary>
        public static List<tt_kkjissihokokusyo_subDto> GetSubDtlAndKeys(long hokokusyono, HashSet<string> staffids, out List<object[]> keyList)
        {
            var dtl = new List<tt_kkjissihokokusyo_subDto>(staffids.Count);
            keyList = new List<object[]>(staffids.Count);
            foreach (var staffid in staffids)
            {
                dtl.Add(new tt_kkjissihokokusyo_subDto { hokokusyono = hokokusyono, staffid = staffid });
                keyList.Add(new object[] { hokokusyono, staffid });
            }

            return dtl;
        }
    }
}