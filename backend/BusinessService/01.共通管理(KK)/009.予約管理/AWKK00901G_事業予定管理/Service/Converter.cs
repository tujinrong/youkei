// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予定管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.03.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00901G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得(日程一覧)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchNitteiListRequest req)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SearchNitteiListRequest.gyomukbn)}_in", req.gyomukbn),                //業務区分
                new($"{nameof(SearchNitteiListRequest.jissiyoteiymdf)}_in", req.jissiyoteiymdf),    //実施予定日(開始)
                new($"{nameof(SearchNitteiListRequest.jissiyoteiymdt)}_in", req.jissiyoteiymdt),    //実施予定日(終了)
                new($"{nameof(SearchNitteiListRequest.jigyocd)}_in", req.jigyocd),                  //その他日程事業・保健指導事業コード
                new($"{nameof(SearchNitteiListRequest.kaijocd)}_in", req.kaijocd),                  //会場コード
                new($"{nameof(SearchNitteiListRequest.kikancd)}_in", req.kikancd),                  //医療機関コード
                new($"{nameof(SearchNitteiListRequest.staffid)}_in", req.staffid)                   //担当者
            };
            return paras;
        }

        /// <summary>
        /// パラメータ取得(コース一覧)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchCourseListRequest req)
        {
            var paras = GetParameters((SearchNitteiListRequest)req);
            paras.Add(new AiKeyValue($"{nameof(SearchCourseListRequest.coursenm)}_in", ToLikeStr(req.coursenm)));   //コース名
            paras.Add(new AiKeyValue($"{nameof(SearchCourseListRequest.kaisu)}_in", req.kaisu));                    //回数

            return paras;
        }

        /// <summary>
        /// 事業予定テーブル
        /// </summary>
        public static tt_kkjigyoyoteiDto GetDto(NitteiDetailVM vm, int nitteino, int? courseno = null, int? kaisu = null)
        {
            var dto = new tt_kkjigyoyoteiDto();
            dto.nitteino = nitteino;                                    //日程番号
            dto.jigyocd = DaSelectorService.GetCd(vm.jigyocdnm);        //その他日程事業・保健指導事業コード
            dto.jissinaiyo = CNStr(vm.jissinaiyo);                      //実施内容
            dto.jissiyoteiymd = vm.jissiyoteiymd;                       //実施予定日
            dto.tmf = vm.tmf;                                           //開始時間
            dto.tmt = CNStr(vm.tmt);                                    //終了時間
            dto.kaijocd = DaSelectorService.GetCd(vm.kaijocdnm);        //会場コード
            dto.kikancd = CNStr(DaSelectorService.GetCd(vm.kikancdnm)); //医療機関コード
            dto.teiin = CInt(vm.teiin);                                 //定員
            dto.courseno = courseno;                                    //コース番号
            dto.kaisu = kaisu;                                          //回数

            return dto;
        }
        /// <summary>
        /// 事業予定担当者テーブルリスト
        /// </summary>
        public static List<tt_kkjigyoyotei_staffDto> GetDtl(int nitteino, List<string> staffids)
        {
            return staffids.Select(e => new tt_kkjigyoyotei_staffDto() { nitteino = nitteino, staffid = e }).ToList();
        }
        /// <summary>
        /// 事業予定コーステーブル
        /// </summary>
        public static tt_kkjigyoyoteicourseDto GetDto(int courseno, string coursenm)
        {
            var dto = new tt_kkjigyoyoteicourseDto();
            dto.courseno = courseno;    //コース番号
            dto.coursenm = coursenm;    //コース名

            return dto;
        }
        /// <summary>
        /// 事業予定テーブルリスト
        /// </summary>
        public static List<tt_kkjigyoyoteiDto> GetDtl(int courseno, List<CourseDetailVM> vmList)
        {
            var list = new List<tt_kkjigyoyoteiDto>();
            foreach (var vm in vmList)
            {
                list.Add(GetDto(vm, CInt(vm.nitteino), courseno, vm.kaisu));
            }
            return list;
        }
        /// <summary>
        /// 事業予定担当者テーブルリスト
        /// </summary>
        public static List<tt_kkjigyoyotei_staffDto> GetDtl(List<CourseDetailVM> vmList)
        {
            var list = new List<tt_kkjigyoyotei_staffDto>();
            foreach (var vm in vmList)
            {
                list.AddRange(GetDtl(CInt(vm.nitteino), vm.staffids));
            }
            return list;
        }
    }
}