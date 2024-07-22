// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 予防接種情報管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.06.18
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWYS00101G
{
    public class Converter : CmConerterBase
    {
        private const string HANYO1_NUM = "1";                              //汎用区分1_数値項目
        private const string HANYO1_STR = "2";                              //汎用区分1_文字項目
        private const string FUSYOSTR = "不詳";                             //不詳フラグ判定用

        //**************************************************** ストアドプロシージャパラメータ設定 ****************************************************
        /// <summary>
        /// パラメータ取得（接種情報）「sp_awys00101g_01」
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano, string hanyomaincd, int hanyosubcd, string sessyufilterkbn, bool rirekihyoji, int kbn)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tt_yssessyuDto.atenano)}_in", atenano),                //宛名番号
                new AiKeyValue($"{nameof(tm_afhanyoDto.hanyomaincd)}_in", hanyomaincd),         //汎用メインコード
                new AiKeyValue($"{nameof(tm_afhanyoDto.hanyosubcd)}_in", hanyosubcd),           //汎用サブコード
                new AiKeyValue($"{nameof(tt_yssessyuDto.sessyucd)}_in", GetCd(sessyufilterkbn)),//接種種類フィルター区分
                new AiKeyValue($"rirekihyoji_in", rirekihyoji),                                 //履歴表示フラグ　True：全枝番の情報を表示、False：最大枝番の情報を表示
                new AiKeyValue($"kbn_in", kbn),                                                 //処理区分（1：生涯１回、0：複数回）
            };

            return paras;
        }

        /// <summary>
        /// パラメータ取得（接種依頼情報）「sp_awys00101g_02」
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tt_yssessyuDto.atenano)}_in", atenano),            //宛名番号
            };

            return paras;
        }

        //************************************************************** 詳細画面保存処理 **************************************************************
        /// <summary>
        /// 予防接種テーブル
        /// </summary>
        public static tt_yssessyuDto GetDto(tt_yssessyuDto dto, SaveSessyuRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.atenano = req.atenano;                                      //宛名番号
                dto.sessyucd = req.fixiteminfo.sessyucd;                        //接種種類コード	
                dto.kaisu = req.fixiteminfo.kaisu;                              //回数		
                dto.edano = req.fixiteminfo.edano;                              //枝番
            }

            //共通項目
            dto.sessyukenno = CStr(req.fixiteminfo.sessyukenno);                //接種券番号
            dto.jissikbn = CStr(GetCd(req.fixiteminfo.jissikbn));               //実施区分		
            dto.sessyukbn = CStr(GetCd(req.fixiteminfo.sessyukbn));             //接種区分		
            dto.jissiymd = CStr(req.fixiteminfo.jissiymd);                      //実施日
            dto.hoteikbn = CStr(GetCd(req.fixiteminfo.hoteikbn));               //法定区分	
            dto.jissikikancd = CStr(GetCd(req.fixiteminfo.jissikikan));         //実施機関	
            dto.jissikikannm = CStr(req.fixiteminfo.jissikikannm);              //実施機関名
            dto.kaijocd = CStr(GetCd(req.fixiteminfo.kaijo));                   //会場	
            dto.kaijonm = CStr(req.fixiteminfo.kaijonm);                        //会場名
            dto.isicd = CStr(GetCd(req.fixiteminfo.isi));                       //医師	
            dto.isinm = CStr(req.fixiteminfo.isinm);                            //医師名
            dto.lotno = CStr(req.fixiteminfo.lotno);                            //ロット番号
            dto.sessyuryo = CDbl(req.fixiteminfo.sessyuryo);                    //接種量
            dto.vaccinemakercd = CStr(GetCd(req.fixiteminfo.vaccinemaker));     //ワクチンメーカー	
            dto.vaccinenmcd = CStr(GetCd(req.fixiteminfo.vaccinenm));           //ワクチン名
            dto.tokubetunojijyo = CStr(GetCd(req.fixiteminfo.tokubetunojijyo)); //特別の事情

            //ログイン時選択された支所を登録
            dto.regsisyo = CStr(req.regsisyo);                                  //登録支所

            return dto;
        }

        /// <summary>
        /// 予防接種（フリー項目）接種テーブル（新規の場合）
        /// </summary>
        public static tt_yssessyufreeDto GetDto(tt_yssessyufreeDto dto, SaveSessyuRequest req, FreeItemInfoVM vm, string hanyo1)
        {
            dto.atenano = req.atenano;                                          //宛名番号
            dto.sessyucd = req.fixiteminfo.sessyucd;                            //接種種類コード
            dto.kaisu = req.fixiteminfo.kaisu;                                  //回数
            dto.edano = req.fixiteminfo.edano;                                  //枝番（リクエスト.枝番=0の場合、最大枝番＋１）
            dto.itemcd = CStr(GetCd(vm.item));                                  //項目コード
            
            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 予防接種（フリー項目）接種テーブル（更新の場合）
        /// </summary>
        public static tt_yssessyufreeDto GetDto(tt_yssessyufreeDto dto, FreeItemInfoVM vm, string hanyo1)
        {
            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 予防接種依頼テーブル
        /// </summary>
        public static tt_yssessyuiraiDto GetDto(tt_yssessyuiraiDto dto, SaveSessyuIraiRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.atenano = req.atenano;                                      //宛名番号
                dto.edano = req.fixiteminfo.edano;                              //枝番
            }

            //共通項目
            dto.uketukeymd = CStr(req.fixiteminfo.uketukeymd);                  //受付日
            dto.iraisaki = CStr(req.fixiteminfo.iraisaki);                      //依頼先
            dto.irairiyu = CStr(req.fixiteminfo.irairiyu);                      //依頼理由
            dto.hogosya_atenano = CStr(req.fixiteminfo.hogosya_atenano);        //保護者_宛名番号
            dto.hogosya_simei = CStr(req.fixiteminfo.hogosya_simei);            //保護者_氏名

            //ログイン時選択された支所を登録
            dto.regsisyo = CStr(req.regsisyo);                                  //登録支所

            return dto;
        }

        /// <summary>
        /// 予防接種依頼（フリー項目）テーブル（新規の場合）
        /// </summary>
        public static tt_yssessyuiraifreeDto GetDto(tt_yssessyuiraifreeDto dto, SaveSessyuIraiRequest req, FreeItemInfoVM vm, string hanyo1)
        {
            dto.atenano = req.atenano;                                          //宛名番号
            dto.edano = req.fixiteminfo.edano;                                  //枝番（リクエスト.枝番=0の場合、最大枝番＋１）
            dto.itemcd = CStr(GetCd(vm.item));                                  //項目コード

            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 予防接種依頼（フリー項目）テーブル（更新の場合）
        /// </summary>
        public static tt_yssessyuiraifreeDto GetDto(tt_yssessyuiraifreeDto dto, FreeItemInfoVM vm, string hanyo1)
        {
            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 予防接種依頼サブテーブル
        /// </summary>
        public static tt_yssessyuirai_subDto GetDto(SaveSessyuIraiRequest req, SessyuVM vm)
        {
            var dto = new tt_yssessyuirai_subDto();

            dto.atenano = req.atenano;                                          //宛名番号
            dto.edano = req.fixiteminfo.edano;                                  //枝番	
            dto.sessyucd = vm.sessyucd;                                         //接種種類コード		
            dto.kaisu = vm.kaisu;                                               //回数

            return dto;
        }

        /// <summary>
        /// 予防接種（フリー項目）個人テーブル（新規の場合）
        /// </summary>
        public static tt_yskojinfreeDto GetDto(tt_yskojinfreeDto dto, SaveOtherRequest req, FreeItemInfoVM vm, string hanyo1)
        {
            dto.atenano = req.atenano;                                          //宛名番号
            dto.itemcd = CStr(GetCd(vm.item));                                  //項目コード

            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 予防接種（フリー項目）個人テーブル（更新の場合）
        /// </summary>
        public static tt_yskojinfreeDto GetDto(tt_yskojinfreeDto dto, FreeItemInfoVM vm, string hanyo1)
        {
            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 風疹抗体検査テーブル
        /// </summary>
        public static tt_ysfusinkotaiDto GetDto(tt_ysfusinkotaiDto dto, SaveFusinRequest req, EnumActionType? kbn)
        {
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                dto.atenano = req.atenano;                                      //宛名番号
            }

            //共通項目
            dto.sessyukenno = CStr(req.fixiteminfo.sessyukenno);                //接種券番号
            dto.jissiymd = CStr(req.fixiteminfo.jissiymd);                      //実施日
            dto.jissikikancd = CStr(GetCd(req.fixiteminfo.jissikikan));         //実施機関	
            dto.jissikikannm = CStr(req.fixiteminfo.jissikikannm);              //実施機関名
            dto.isicd = CStr(GetCd(req.fixiteminfo.isi));                       //医師	
            dto.isinm = CStr(req.fixiteminfo.isinm);                            //医師名
            dto.isicd = CStr(GetCd(req.fixiteminfo.isi));                       //医師	
            dto.sessyuhanteicd = CStr(GetCd(req.fixiteminfo.sessyuhantei));     //接種判定
            dto.kotaikensahohocd = CStr(GetCd(req.fixiteminfo.kotaikensahoho)); //抗体検査方法
            dto.kotaika = CStr(req.fixiteminfo.kotaika);                        //抗体価
            dto.tanicd = CStr(GetCd(req.fixiteminfo.tani));                     //単位
            dto.kotaikensanocd = CStr(GetCd(req.fixiteminfo.kotaikensano));     //抗体検査番号

            //ログイン時選択された支所を登録
            dto.regsisyo = CStr(req.regsisyo);                                  //登録支所

            return dto;
        }

        /// <summary>
        /// 風疹抗体検査（フリー項目）テーブル（新規の場合）
        /// </summary>
        public static tt_ysfusinkotaifreeDto GetDto(tt_ysfusinkotaifreeDto dto, SaveFusinRequest req, FreeItemInfoVM vm, string hanyo1)
        {
            dto.atenano = req.atenano;                                          //宛名番号
            dto.itemcd = CStr(GetCd(vm.item));                                  //項目コード

            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        /// <summary>
        /// 風疹抗体検査（フリー項目）テーブル（更新の場合）
        /// </summary>
        public static tt_ysfusinkotaifreeDto GetDto(tt_ysfusinkotaifreeDto dto, FreeItemInfoVM vm, string hanyo1)
        {
            dto.fusyoflg = GetFusyoflg(vm.item);                                //不詳フラグ

            if (hanyo1.Equals(HANYO1_NUM))
            {
                //汎用区分1_数値項目
                dto.numvalue = CNDbl(vm.value);                                 //数値項目
                dto.strvalue = null;                                            //文字項目
            }
            else
            {
                //汎用区分1_文字項目
                dto.strvalue = CNStr(vm.value);                                 //文字項目
                dto.numvalue = null;                                            //数値項目
            }
            return dto;
        }

        //************************************************************** 関数 **************************************************************
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