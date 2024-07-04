// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.03.08
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.Service.AWBH00301G.Converter;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.Service.AWBH00401G
{
    public class Converter : CmConerterBase
    {
        //================================= ⑥詳細画面保存処理 =================================
        /// <summary>
        /// 乳幼児（フリー）項目テーブル（新規の場合）
        /// </summary>
        public static tt_bhnyfreeDto GetDto(tt_bhnyfreeDto dto, SaveRequest req, FreeItemInfoVM vm, string hanyo1, string jigyocd)
        {
            dto.jigyocd = jigyocd;                                          //母子保健事業コード
            dto.atenano = req.atenano;                                      //宛名番号
            dto.edano = req.kaisu;                                          //枝番（リクエスト.回数=0の場合、最大枝番＋１）
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
        /// 乳幼児（フリー）項目テーブル（更新の場合）
        /// </summary>
        public static tt_bhnyfreeDto GetDto(tt_bhnyfreeDto dto, FreeItemInfoVM vm, string hanyo1)
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
            }

            return fixedCondition;
        }
    }
}