// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業予約希望者管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.03.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00902G
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
                new($"{nameof(SearchNitteiListRequest.gyomukbn)}_in", req.gyomukbn),                                    //業務区分
                new($"{nameof(SearchNitteiListRequest.jissiyoteiymdf)}_in", req.jissiyoteiymdf),                        //実施予定日(開始)
                new($"{nameof(SearchNitteiListRequest.jissiyoteiymdt)}_in", req.jissiyoteiymdt),                        //実施予定日(終了)
                new($"{nameof(SearchNitteiListRequest.jigyocd)}_in", req.jigyocd),                                      //その他日程事業・保健指導事業コード
                new($"{nameof(SearchNitteiListRequest.coursenm)}_in", ToLikeStr(req.coursenm)),                                    //コース番号
                new($"{nameof(SearchNitteiListRequest.kaisu)}_in", req.kaisu),                                          //回数
                new($"{nameof(SearchNitteiListRequest.kaijocd)}_in", req.kaijocd),                                      //会場コード
                new($"{nameof(SearchNitteiListRequest.kikancd)}_in", req.kikancd),                                      //医療機関コード
                new($"{nameof(SearchNitteiListRequest.staffid)}_in", req.staffid),                                      //担当者
                new($"{nameof(SearchNitteiListRequest.atenano)}_in", req.atenano),                                      //宛名番号
                new($"{nameof(SearchNitteiListRequest.personalno)}_in", CmLogicUtil.GetPersonalnoDB(req.personalno))    //個人番号
            };
            return paras;
        }

        /// <summary>
        /// パラメータ取得(コース一覧)
        /// </summary>
        public static List<AiKeyValue> GetParameters(int courseno)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SearchNitteiListRequest.courseno)}_in", courseno) //コース番号
            };
            return paras;
        }

        /// <summary>
        /// 事業予約希望者テーブルリスト
        /// </summary>
        public static List<tt_kkjigyoyoyakukibosyaDto> GetDtl(List<int> keyList, List<tt_kkjigyoyoyakukibosyaDto> dtl)
        {
            var list = new List<tt_kkjigyoyoyakukibosyaDto>();
            foreach (int key in keyList)
            {
                var dtl2 = new List<tt_kkjigyoyoyakukibosyaDto>().Concat(dtl);
                foreach (var dto in dtl2)
                {
                    dto.nitteino = key;                             //日程番号
                    dto.syokaiuketukeymd = FormatYMD(DaUtil.Today); //初回受付日
                }
                list.AddRange(dtl2);
            }
            return list;
        }

        /// <summary>
        /// 事業予約希望者テーブル
        /// </summary>
        public static tt_kkjigyoyoyakukibosyaDto GetDto(tt_kkjigyoyoyakukibosyaDto dto, DetailVM vm, int nitteino, string atenano, int yoyakuno)
        {
            dto.nitteino = nitteino;                                                                //日程番号
            dto.atenano = atenano;                                                                  //宛名番号
            dto.yoyakuno = yoyakuno;                                                                //予約番号
            dto.cancelmatiflg = vm.taikiflg ? Enum待機フラグ.希望する : Enum待機フラグ.希望しない;  //キャンセル待ち
            dto.jusinkingaku = vm.jusinkingaku;                                                     //受診金額
            dto.kingaku_sityosonhutan = vm.kingaku_sityosonhutan;                                   //金額（市区町村負担）
            dto.syokaiuketukeymd = CNStr(vm.syokaiuketukeymd);                                      //初回受付日
            dto.biko = CNStr(vm.biko);                                                              //備考

            return dto;
        }
    }
}