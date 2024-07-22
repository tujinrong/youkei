// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             リレーション取得
// 作成日　　: 2023.07.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class DaFrRelationFactory
    {
        public static IFrRelation GetRelation(Enum特殊一覧検索機能 kinoid, object? objPara, params string[] paras)
        {
            switch (kinoid)
            {
                //検診の場合
                case Enum特殊一覧検索機能.AWSH001:
                    List<tm_shfreeitemDto> freeItemList = (List<tm_shfreeitemDto>)objPara!;
                    //精密項目Dic
                    Dictionary<string, bool> seikenDic = freeItemList.ToDictionary(k => k.itemcd, v => v.groupid == EnumKensinKbn.精密);
                    //履歴管理Dic(true:通常(非通年);false:通年)
                    Dictionary<string, bool> rirekiDic = freeItemList.ToDictionary(k => k.itemcd, v => v.rirekiflg);
                    return new KensinRelation(CStr(paras[0]), CStr(paras[1]), seikenDic, rirekiDic);
                //住民・住登外の場合
                case Enum特殊一覧検索機能.AWKK00101G:
                    return new AtenaRelation(CStr(paras[0]));
                //住登外者の場合
                case Enum特殊一覧検索機能.AWKK00111G:
                    return new JutogaiRelation(CStr(paras[0]));
                //保健指導の場合
                case Enum特殊一覧検索機能.AWKK00301G:
                    List<tm_kksidofreeitemDto> sidofreeItemList = (List<tm_kksidofreeitemDto>)objPara!;
                    return new SidoRelation(CStr(paras[0]));
                //母子保健の場合
                case Enum特殊一覧検索機能.Bosi:
                    return new BosiRelation(CStr(paras[0]));
                //フォロー管理の場合
                case Enum特殊一覧検索機能.AWKK00401G:
                    return new FollowRelation(CStr(paras[0]));
                //帳票発行対象外者管理の場合
                case Enum特殊一覧検索機能.AWKK01001G:
                    return new TaisyogaiRelation(CStr(paras[0]));
                //各種検診対象者保守の場合
                case Enum特殊一覧検索機能.AWSH00302G:
                    return new TaisyosignRelation(CStr(paras[0]), CInt(paras[1]));
                //健（検）診予定管理の場合
                case Enum特殊一覧検索機能.AWSH00401G:
                    return new KensinyoyakuRelation(CInt(paras[0]), CNStr(paras[1]), CStr(paras[2]), CStr(paras[3]));
                //健（検）診予約希望者管理の場合
                case Enum特殊一覧検索機能.AWSH00402G_1: //日程一覧画面
                    return new KensinyoyakukibosyaRelation(CInt(paras[0]), CNStr(paras[1]), CStr(paras[2]), CStr(paras[3]));
                case Enum特殊一覧検索機能.AWSH00402G_2: //予約者一覧画面：予約情報
                    return new KensinyoyakukibosyaRelation2(CInt(paras[0]), CStr(paras[1]), CStr(paras[2]));
                case Enum特殊一覧検索機能.AWSH00402G_3: //予約者一覧画面：予約者情報
                    return new KensinyoyakukibosyaRelation3(CInt(paras[0]), CInt(paras[1]), CStr(paras[2]), CStr(paras[3]));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}