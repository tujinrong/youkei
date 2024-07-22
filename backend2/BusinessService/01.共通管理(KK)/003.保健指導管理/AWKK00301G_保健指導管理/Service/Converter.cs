// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 保健指導管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.13
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWKK00301G
{
    public class Converter : CmConerterBase
    {
        private const string HANYO1_NUM = "1";                              //汎用区分1_数値項目
        private const string HANYO1_STR = "2";                              //汎用区分1_文字項目
        private const string FUSYOSTR = "不詳";                             //不詳フラグ判定用

        /// <summary>
        /// パラメータ取得（②③世帯構成員情報取得用）
        /// </summary>
        public static List<AiKeyValue> GetParameters(string setaino)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tt_afatenaDto.setaino)}_in", setaino),     //世帯番号
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
                new AiKeyValue($"{nameof(tt_kkhokensido_mosikomiDto.atenano)}_in", atenano),              //宛名番号
                new AiKeyValue($"{nameof(tt_kkhokensido_mosikomiDto.hokensidokbn)}_in", hokensidokbn),    //保健指導区分
                new AiKeyValue($"{nameof(tt_kkhokensido_mosikomiDto.gyomukbn)}_in", gyomukbn),            //業務区分
                new AiKeyValue($"{nameof(tt_kkhokensido_mosikomiDto.jigyocd)}_in", jigyocd),              //事業コード
            };

            return paras;
        }

        /// <summary>
        /// パラメータ取得（⑥保健指導情報取得用）
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano, string hokensidokbn, string gyomukbn, int edano, string mosikomikekkakbn)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tt_kkhokensido_mosikomiDto.atenano)}_in", atenano),              //宛名番号
                new AiKeyValue($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}_in", hokensidokbn),         //保健指導区分
                new AiKeyValue($"{nameof(tm_kksidofreeitemDto.gyomukbn)}_in", gyomukbn),                  //業務区分
                new AiKeyValue($"{nameof(tt_kkhokensido_mosikomiDto.edano)}_in", edano),                  //枝番
                new AiKeyValue($"{nameof(tm_kksidofreeitemDto.mosikomikekkakbn)}_in", mosikomikekkakbn),  //申込結果区分
            };

            return paras;
        }

        //================================= ⑧詳細画面保存処理 =================================
        /// <summary>
        /// 保健指導申込情報（固定項目）テーブル
        /// </summary>
        public static tt_kkhokensido_mosikomiDto GetDto(tt_kkhokensido_mosikomiDto dto, SaveRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.hokensidokbn = req.maininfo.hokensidokbn;               //保健指導区分
                dto.gyomukbn = req.maininfo.gyomukbn;                       //業務区分		
                dto.atenano = req.maininfo.atenano;                         //宛名番号		
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
        /// 保健指導結果情報（固定項目）テーブル
        /// </summary>
        public static tt_kkhokensido_kekkaDto GetDto(tt_kkhokensido_kekkaDto dto, SaveRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.hokensidokbn = req.maininfo.hokensidokbn;               //保健指導区分
                dto.gyomukbn = req.maininfo.gyomukbn;                       //業務区分	
                dto.atenano = req.maininfo.atenano;                         //宛名番号	
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
        /// 保健指導担当者テーブル（予定者リスト／実施者リスト）
        /// </summary>
        public static tt_kkhokensido_staffDto GetDto(tt_kkhokensido_staffDto dto, StaffListVM vm, SaveRequest req, string mosikomikekkakbn)
        {
            dto.hokensidokbn = req.maininfo.hokensidokbn;                   //保健指導区分
            dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分
            dto.atenano = req.maininfo.atenano;                             //宛名番号
            dto.edano = req.maininfo.edano; ;                               //枝番
            dto.mosikomikekkakbn = mosikomikekkakbn;                        //申込結果区分
            dto.staffid = vm.staffid;                                       //担当者ID

            return dto;
        }

        /// <summary>
        /// 保健指導事業（フリー項目）入力情報テーブル（新規の場合）
        /// </summary>
        public static tt_kkhokensidofreeDto GetDto(tt_kkhokensidofreeDto dto, SaveRequest req, FreeItemInfoVM vm, string hanyo1, string mosikomikekkakbn)
        {
            dto.hokensidokbn = req.maininfo.hokensidokbn;                   //保健指導区分
            dto.gyomukbn = req.maininfo.gyomukbn;                           //業務区分
            dto.mosikomikekkakbn = mosikomikekkakbn;                        //申込結果区分
            dto.itemcd = CStr(GetCd(vm.item));                              //項目コード
            dto.atenano = req.maininfo.atenano;                             //宛名番号
            dto.edano = req.maininfo.edano;                                 //枝番（リクエスト.枝番=0の場合、申込・結果の最大枝番＋１）
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
        /// 保健指導事業（フリー項目）入力情報テーブル（更新の場合）
        /// </summary>
        public static tt_kkhokensidofreeDto GetDto(tt_kkhokensidofreeDto dto, FreeItemInfoVM vm, string hanyo1)
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
        /// 住登外者固定検索条件取得：住登外者一覧を検索する場合場合
        /// </summary>
        //Todo：後でCommon--LogicService--Service--Converterに移動する予定
        public static FrConditionModel GetFixedCondition(SearchListRequest req)
        {
            var fixedCondition = new FrConditionModel();
            //宛名番号が入力された場合、住民を1人に絞り込めるため、他の検索条件を無して検索を行う
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名番号
                if (!string.IsNullOrEmpty(req.atenano))
                {
                    fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumValueOprator.EQ, req.atenano);
                }
            }
            else
            //宛名番号が入力していない場合
            {
                //氏名
                if (!string.IsNullOrEmpty(req.name))
                {
                    var name = req.name.Replace(SPACE_FULL, string.Empty);
                    name = name.Replace(SPACE, string.Empty);
                    var cond = $"" +
                        $"(REPLACE(REPLACE({tt_afatenaDto.TABLE_NAME}{C_DOT}{nameof(tt_afatenaDto.simei)},'{SPACE_FULL}','{string.Empty}'),'{SPACE}','{string.Empty}'){SPACE}LIKE{SPACE}'{ToLikeStr(name)}'{SPACE}OR{SPACE}" +
                        $"{tt_afatenaDto.TABLE_NAME}{C_DOT}{nameof(tt_afatenaDto.tusyo)}{SPACE}LIKE{SPACE}'{ToLikeStr(name)}')";
                    fixedCondition.And(cond);
                }
                //カナ氏名
                if (!string.IsNullOrEmpty(req.kname))
                {
                    var cond = new FrConditionModel()
                        .Sub(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                        .Or(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.tusyo_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                        .EndSub();
                    fixedCondition.And(cond);
                }
                //生年月日
                if (!string.IsNullOrEmpty(req.bymd))
                {
                    fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd), FrEnumValueOprator.EQ, req.bymd);
                }
            }

            return fixedCondition;
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