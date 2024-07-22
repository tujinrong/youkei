// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.Service.AWBH00301G
{
    public class Converter : CmConerterBase
    {
        public const string HANYO1_NUM = "1";                              //汎用区分1_数値項目
        public const string HANYO1_STR = "2";                              //汎用区分1_文字項目
        public const string FUSYOSTR = "不詳";                             //不詳フラグ判定用

        //================================= ⑦詳細画面保存処理 =================================
        /// <summary>
        /// 妊産婦（フリー）項目テーブル（新規の場合）
        /// </summary>
        public static tt_bhnsfreeDto GetDto(tt_bhnsfreeDto dto, SaveRequest req, FreeItemInfoVM vm, string hanyo1, string jigyocd)
        {
            var skaisu = jigyocd.Equals(Service.JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            dto.jigyocd = jigyocd;                                          //母子保健事業コード
            dto.atenano = req.atenano;                                      //宛名番号
            dto.torokuno = req.torokuno;                                    //登録番号
            dto.torokunorenban = req.torokunorenban;                        //登録番号連番（リクエスト.履歴回数=0の場合、最大登録番号連番＋１）
            dto.edano = req.edano;                                          //枝番（リクエスト.履歴回数=0の場合、最大枝番＋１）
            //TODO：zhang20240617
            //dto.kaisu = req.kaisu;                                        //履歴回数（リクエスト.履歴回数=0の場合、最大履歴回数＋１）
            dto.kaisu = skaisu;                                             //履歴回数（リクエスト.履歴回数=0の場合、最大履歴回数＋１）
            dto.itemcd = CStr(GetCd(vm.item));                              //項目コード
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
        /// 妊産婦（フリー）項目テーブル（更新の場合）
        /// </summary>
        public static tt_bhnsfreeDto GetDto(tt_bhnsfreeDto dto, FreeItemInfoVM vm, string hanyo1)
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

        //================================= 費用助成一覧画面保存処理 =================================
        /// <summary>
        /// 妊婦健診費用助成（固定）サブテーブル
        /// </summary>
        public static List<tt_bhnsninpukensinhiyojosei_subDto> GetDtl(List<tt_bhnsninpukensinhiyojosei_subDto> newdtl, SaveRequest req, string jigyocd)
        {
            var i = 1;
            //費用助成一覧
            foreach (var dt in req.jyoseilistinfo)
            {
                var newdto = new tt_bhnsninpukensinhiyojosei_subDto()
                {
                    jigyocd = jigyocd,                                      //母子保健事業コード
                    atenano = req.atenano,                                  //宛名番号
                    torokuno = req.torokuno,                                //登録番号
                    sinseiedano = req.edano,                                //申請枝番
                    edano = i,                                              //枝番
                    joseikensyurui = CStr(GetCd(dt.joseikensyurui)),        //助成券種類
                    jusinymd = dt.jusinymd,                                 //受診年月日
                    siharaikingaku = dt.siharaikingaku,                     //支払金額
                    joseikingaku = dt.joseikingaku                          //助成金額
                };
                newdtl.Add(newdto);
                i++;
            }

            return newdtl;
        }

        /// <summary>
        /// 産婦健診費用助成（固定）サブテーブル
        /// </summary>
        public static List<tt_bhnssanpukensinhiyojosei_subDto> GetDtl(List<tt_bhnssanpukensinhiyojosei_subDto> newdtl, SaveRequest req)
        {
            var i = 1;
            //費用助成一覧
            foreach (var dt in req.jyoseilistinfo)
            {
                var newdto = new tt_bhnssanpukensinhiyojosei_subDto()
                {
                    atenano = req.atenano,                                  //宛名番号
                    torokuno = req.torokuno,                                //登録番号
                    sinseiedano = req.edano,                                //申請枝番
                    edano = i,                                              //枝番
                    joseikensyurui = CStr(GetCd(dt.joseikensyurui)),        //助成券種類
                    jusinymd = dt.jusinymd,                                 //受診年月日
                    siharaikingaku = dt.siharaikingaku,                     //支払金額
                    joseikingaku = dt.joseikingaku                          //助成金額
                };
                newdtl.Add(newdto);
                i++;
            }

            return newdtl;
        }

        //================================= 共通メソッド =================================
        /// <summary>
        /// 妊産婦固定検索条件取得：妊産婦一覧を検索する場合
        /// </summary>
        //Todo：後でCommon--LogicService--Service--Converterに移動する予定
        public static FrConditionModel GetFixedCondition(SearchListRequest req)
        {
            var fixedCondition = new FrConditionModel();

            //宛名番号あるいは個人番号入力された場合、他の検索条件を無視する
            if (!string.IsNullOrEmpty(req.atenano) || !string.IsNullOrEmpty(req.personalno))
            {
                //宛名番号
                if (!string.IsNullOrEmpty(req.atenano))
                {
                    fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumValueOprator.EQ, req.atenano);
                }
                else
                {
                    //個人番号（検索のため暗号化）
                    if (!string.IsNullOrEmpty(req.personalno))
                    {
                        fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.personalno), FrEnumValueOprator.EQ, DaEncryptUtil.AesEncrypt(req.personalno));
                    }
                }
            }
            else
            //宛名番号または個人番号が入力していない場合
            {
                //氏名
                if (!string.IsNullOrEmpty(req.name))
                {
                    var name = req.name.Replace(SPACE_FULL, string.Empty);
                    name = name.Replace(SPACE, string.Empty);
                    var cond1 = $"" +
                        $"(REPLACE(REPLACE({tt_afatenaDto.TABLE_NAME}{C_DOT}{nameof(tt_afatenaDto.simei)},'{SPACE_FULL}','{string.Empty}'),'{SPACE}','{string.Empty}'){SPACE}LIKE{SPACE}'{ToLikeStr(name)}'{SPACE}OR{SPACE}" +
                        $"{tt_afatenaDto.TABLE_NAME}{C_DOT}{nameof(tt_afatenaDto.tusyo)}{SPACE}LIKE{SPACE}'{ToLikeStr(name)}')";
                    fixedCondition.And(cond1);
                }
                //カナ氏名
                if (!string.IsNullOrEmpty(req.kname))
                {
                    var cond1 = new FrConditionModel()
                        .Sub(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                        .Or(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.tusyo_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                        .EndSub();
                    fixedCondition.And(cond1);
                }
                //生年月日
                if (!string.IsNullOrEmpty(req.bymd))
                {
                    fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd), FrEnumValueOprator.EQ, req.bymd);
                }

                //母子手帳番号
                if (!string.IsNullOrEmpty(req.bhtetyono))
                {
                    fixedCondition.And(tt_bhnsbosikenkotetyokofuDto.TABLE_NAME, nameof(tt_bhnsbosikenkotetyokofuDto.bositetyokofuno), FrEnumValueOprator.EQ, req.bhtetyono);
                }
            }

            return fixedCondition;
        }

        /// <summary>
        /// 不詳フラグを判定
        /// </summary>
        public static bool GetFusyoflg(string itemnm)
        {
            if (string.IsNullOrEmpty(itemnm)) { return false; }

            if (itemnm.Contains(FUSYOSTR)) { return true; }

            return false;
        }
    }
}