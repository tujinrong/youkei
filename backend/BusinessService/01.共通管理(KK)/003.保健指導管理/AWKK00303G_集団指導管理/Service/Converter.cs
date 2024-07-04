// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 集団指導管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.27
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00303G
{
    public class Converter : CmConerterBase
    {
        private const string HANYO1_NUM = "1";                              //汎用区分1_数値項目
        private const string HANYO1_STR = "2";                              //汎用区分1_文字項目
        private const string FUSYOSTR = "不詳";                             //不詳フラグ判定用


        /// <summary>
        /// パラメータ取得（②③世帯構成員情報取得用）
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tt_kksyudansido_mosikomiDto.gyomukbn)}_in", GetCd(req.gyomu)),      //業務区分
                new AiKeyValue($"{nameof(tt_kksyudansido_mosikomiDto.jigyocd)}_in", GetCd(req.jigyo)),       //事業コード
                new AiKeyValue($"{nameof(tt_kksyudansido_staffDto.staffid)}_in", GetCd(req.tantosya)),       //予定者ID/実施者ID
                new AiKeyValue($"{nameof(tm_afkaijoDto.kaijocd)}_in", GetCd(req.jissibasyo)),                //実施場所（申込／結果両方）
                new AiKeyValue($"yoteiymdf_in", GetCd(req.yoteiymdf)),                                       //予定日(From) 
                new AiKeyValue($"yoteiymdt_in", GetCd(req.yoteiymdt)),                                       //予定日(To) 
                new AiKeyValue($"course_in", GetName(req.course)),                                           //コース（コード：名称から取得のコース名）
                new AiKeyValue($"jissiymdf_in", GetCd(req.jissiymdf)),                                       //実施日(From) 
                new AiKeyValue($"jissiymdt_in", GetCd(req.jissiymdt)),                                       //実施日(To) 
                new AiKeyValue($"{nameof(tt_kksyudansido_mosikomiDto.coursenm)}_in", GetCd(req.coursenm)),   //コース名（曖昧検索可能）
                new AiKeyValue($"{nameof(tt_kksyudansido_sankasyakekkaDto.atenano)}_in", GetCd(req.atenano)), //宛名番号
            };

            return paras;
        }

        /// <summary>
        /// パラメータ取得（④申込フリー項目情報取得用）
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano, string hokensidokbn, string? gyomukbn, string? jigyocd)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tt_kksyudansido_mosikomiDto.gyomukbn)}_in", gyomukbn),              //業務区分
                new AiKeyValue($"{nameof(tt_kksyudansido_mosikomiDto.jigyocd)}_in", jigyocd),                //事業コード
            };

            return paras;
        }

        /// <summary>
        /// パラメータ取得（⑥集団指導情報取得用）
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano, string hokensidokbn, string gyomukbn, int edano, string mosikomikekkakbn)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tm_kksidofreeitemDto.gyomukbn)}_in", gyomukbn),                    //業務区分
                new AiKeyValue($"{nameof(tt_kksyudansido_mosikomiDto.edano)}_in", edano),                            //枝番
                new AiKeyValue($"{nameof(tm_kksidofreeitemDto.mosikomikekkakbn)}_in", mosikomikekkakbn),    //申込結果区分
            };

            return paras;
        }

        //============================================= ⑧詳細画面保存処理 =============================================
        /// <summary>
        /// 集団指導申込情報（固定項目）テーブル
        /// </summary>
        public static tt_kksyudansido_mosikomiDto GetDto(tt_kksyudansido_mosikomiDto dto, SaveRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.gyomukbn = req.maininfo.gyomukbn;                       //業務区分		
                dto.edano = req.maininfo.edano;                             //枝番

                //ログイン時選択された支所を登録
                dto.regsisyo = req.regsisyo;                                //登録支所
            }
            else
            {
                //更新の場合
                dto.regsisyo = req.maininfo.mosikomiinfo.regsisyocd;        //登録支所
            }
            //共通項目
            dto.jigyocd = CStr(GetCd(req.maininfo.mosikomiinfo.jigyo));     //事業コード		
            dto.yoteiymd = req.maininfo.mosikomiinfo.yoteiymd;              //実施予定日
            dto.yoteitm = req.maininfo.mosikomiinfo.yoteitm;                //予定開始時間
            dto.kaijocd = CStr(GetCd(req.maininfo.mosikomiinfo.kaijo));     //会場コード

            return dto;
        }

        /// <summary>
        /// 集団指導結果情報（固定項目）テーブル
        /// </summary>
        public static tt_kksyudansido_kekkaDto GetDto(tt_kksyudansido_kekkaDto dto, SaveRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.gyomukbn = req.maininfo.gyomukbn;                       //業務区分		
                dto.edano = req.maininfo.edano;                             //枝番

                //ログイン時選択された支所を登録
                dto.regsisyo = req.regsisyo;                                //登録支所
            }
            else
            {
                //更新の場合
                dto.regsisyo = req.maininfo.kekkainfo.regsisyocd;           //登録支所
            }
            //共通項目
            dto.jigyocd = CStr(GetCd(req.maininfo.kekkainfo.jigyo));        //事業コード		
            dto.jissiymd = req.maininfo.kekkainfo.jissiymd;                 //実施日
            dto.tmf = req.maininfo.kekkainfo.tmf;                           //開始時間
            dto.tmt = req.maininfo.kekkainfo.tmt;                           //終了時間
            dto.kaijocd = CStr(GetCd(req.maininfo.kekkainfo.kaijo));        //会場コード
            dto.syukeikbn = CStr(GetCd(req.maininfo.kekkainfo.syukeikbn));  //地域保健集計区分

            return dto;
        }

        /// <summary>
        /// 集団指導参加者テーブル
        /// </summary>
        public static tt_kksyudansido_sankasyaDto GetDto(SankasyaListVM vm, SaveRequest req)
        {
            var dto = new tt_kksyudansido_sankasyaDto();

            dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分		
            dto.edano = req.maininfo.edano;                                 //枝番
            dto.atenano = vm.atenano;                                       //宛名番号
            dto.jigyocd = CStr(GetCd(req.maininfo.sankasyainfo.jigyo));     //事業コード
            dto.syukketukbn = vm.syukketukbn;                               //出欠区分

            return dto;
        }

        /// <summary>
        /// 集団指導担当者テーブル（予定者リスト／実施者リスト）
        /// </summary>
        public static tt_kksyudansido_staffDto GetDto(tt_kksyudansido_staffDto dto, StaffListVM vm, SaveRequest req, int newedano, string mosikomikekkakbn)
        {
            dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分
            dto.edano = newedano;                                           //枝番
            dto.mosikomikekkakbn = mosikomikekkakbn;                        //申込結果区分
            dto.staffid = vm.staffid;                                       //担当者ID

            return dto;
        }

        /// <summary>
        /// 集団指導事業（フリー項目）入力情報テーブル（新規の場合）
        /// </summary>
        public static tt_kksyudansidofreeDto GetDto(tt_kksyudansidofreeDto dto, SaveRequest req, FreeItemInfoVM vm, string hanyo1, int newedano, string mosikomikekkakbn)
        {
            dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分
            dto.mosikomikekkakbn = mosikomikekkakbn;                        //申込結果区分
            dto.itemcd = CStr(GetCd(vm.item));                              //項目コード
            dto.edano = newedano;                                           //枝番（申込・結果の最大枝番＋１）
            dto.fusyoflg = GetFusyoflg(vm.item);                            //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                             //数値項目
                dto.strvalue = null;                                        //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                             //文字項目
                dto.numvalue = null;                                        //数値項目
            }

            return dto;
        }

        /// <summary>
        /// 集団指導事業（フリー項目）入力情報テーブル（更新の場合）
        /// </summary>
        public static tt_kksyudansidofreeDto GetDto(tt_kksyudansidofreeDto dto, FreeItemInfoVM vm, string hanyo1)
        {
            dto.fusyoflg = GetFusyoflg(vm.item);                            //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                             //数値項目
                dto.strvalue = null;                                        //文字項目
            }
            else if (hanyo1.Equals(HANYO1_STR))
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                             //文字項目
                dto.numvalue = null;                                        //数値項目
            }

            return dto;
        }

        //============================================= ⑩参加者詳細画面保存処理 =============================================
        /// <summary>
        /// 集団指導参加者申込情報（固定項目）テーブル
        /// </summary>
        public static tt_kksyudansido_sankasyamosikomiDto GetSankasyaDto(tt_kksyudansido_sankasyamosikomiDto dto, SaveSankasyaRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分		
                dto.edano = req.maininfo.edano;                                 //枝番
                dto.atenano = CStr(req.maininfo.atenano);                       //宛名番号

                dto.regsisyo = req.regsisyo;                                    //登録支所
            }
            else
            {
                //更新の場合
                dto.regsisyo = req.maininfo.mosikomiinfo.regsisyocd;            //登録支所
            }

            return dto;
        }

        /// <summary>
        /// 集団指導参加者結果情報（固定項目）テーブル
        /// </summary>
        public static tt_kksyudansido_sankasyakekkaDto GetSankasyaDto(tt_kksyudansido_sankasyakekkaDto dto, SaveSankasyaRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分		
                dto.edano = req.maininfo.edano;                                 //枝番
                dto.atenano = CStr(req.maininfo.atenano);                       //宛名番号

                //新規作成の場合は、ログイン時選択された支所を表示
                dto.regsisyo = req.regsisyo;                                    //登録支所
            }
            else
            {
                //更新の場合
                dto.regsisyo = req.maininfo.kekkainfo.regsisyocd;               //登録支所
            }

            //共通項目
            dto.syukeikbn = CStr(GetCd(req.maininfo.kekkainfo.syukeikbn));      //地域保健集計区分

            return dto;
        }

        /// <summary>
        /// 集団指導参加者（フリー項目）入力情報テーブル（新規の場合）
        /// </summary>
        public static tt_kksyudansido_sankasyafreeDto GetDto(tt_kksyudansido_sankasyafreeDto dto, SaveSankasyaRequest req, FreeItemInfoVM vm, string hanyo1, string mosikomikekkakbn)
        {
            dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分
            dto.edano = req.maininfo.edano;                                 //枝番
            dto.mosikomikekkakbn = mosikomikekkakbn;                        //申込結果区分
            dto.itemcd = CStr(GetCd(vm.item));                              //項目コード
            dto.atenano = CStr(req.maininfo.atenano);                       //宛名番号

            dto.fusyoflg = GetFusyoflg(vm.item);                            //不詳フラグ
            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                             //数値項目
                dto.strvalue = null;                                        //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                             //文字項目
                dto.numvalue = null;                                        //数値項目
            }

            return dto;
        }

        /// <summary>
        /// 集団指導参加者（フリー項目）入力情報テーブル（（更新の場合）
        /// </summary>
        public static tt_kksyudansido_sankasyafreeDto GetDto(tt_kksyudansido_sankasyafreeDto dto, FreeItemInfoVM vm, string hanyo1)
        {
            dto.fusyoflg = GetFusyoflg(vm.item);                            //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                             //数値項目
                dto.strvalue = null;                                        //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                             //文字項目
                dto.numvalue = null;                                        //数値項目
            }

            return dto;
        }

        /// <summary>
        /// 不詳フラグを判定
        /// </summary>
        private static bool GetFusyoflg(string itemnm)
        {
            if (string.IsNullOrEmpty(itemnm)) { return false; }

            if (itemnm.Contains(FUSYOSTR)) { return true; }

            return false;
        }
    }
}