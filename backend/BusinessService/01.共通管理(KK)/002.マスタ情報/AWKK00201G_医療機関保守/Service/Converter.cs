// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 医療機関保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.6
// 作成者　　: CNC張加恒
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00201G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得(一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();

            paras.Add(new AiKeyValue($"{nameof(tm_afkikanDto.kikancd)}_in", CmLogicUtil.GetSearchPara(req.kikancd)));               //医療機関コード（自治体独自）
            paras.Add(new AiKeyValue($"{nameof(tm_afkikanDto.hokenkikancd)}_in", CmLogicUtil.GetSearchPara(req.hokenkikancd)));     //保険医療機関コード
            paras.Add(new AiKeyValue($"{nameof(tm_afkikanDto.kikannm)}_in", ToLikeStr(req.kikannm)));                                          //医療機関名
            paras.Add(new AiKeyValue($"{nameof(tm_afkikanDto.kanakikannm)}_in", ToLikeStr(req.kanakikannm)));                                  //医療機関名カナ
            paras.Add(new AiKeyValue($"{nameof(tm_afkikanDto.adrs)}_in", ToLikeStr(req.adrs)));                                                //住所

            return paras;
        }

        /// <summary>
        /// 検索パラメータを取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(string kikancd)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof( tm_afkikan_subDto.kikancd )}_in", kikancd ) //医療機関コード
            };

            return paras;
        }

        /// <summary>
        /// 医療機関情報マスタ
        /// </summary>
        public static tm_afkikanDto GetDto(tm_afkikanDto dtoOld, SaveDetailRequest req, DateTime dttm)
        {
            var vm = req.maininfo;
            var dto = new tm_afkikanDto();
            dto.kikancd = vm.kikancd;                                   //医療機関コード
            dto.hokenkikancd = vm.hokenkikancd;                         //保険医療機関コード
            dto.kikannm = vm.kikannm;                                   //医療機関名
            dto.kanakikannm = CStr(ToNSeionKana(vm.kanakikannm));       //医療機関名(カナ)
            dto.tel = vm.tel;                                           //電話番号
            dto.yubin = vm.yubin;                                       //郵便番号
            dto.adrs = vm.adrs;                                         //住所
            dto.katagaki = vm.katagaki;                                 //方書
            dto.fax = vm.fax;                                           //FAX番号
            dto.syozokuisikai = vm.syozokuisikai;                       //所属医師会
            dto.stopflg = vm.stopflg;                                   //使用停止フラグ

            //新規の場合
            if (req.editkbn == Enum編集区分.新規)
            {
                dto.reguserid = req.userid;                             //登録ユーザーID
                dto.regdttm = dttm;                                     //登録日時
            }
            else
            {
                dto.reguserid = dtoOld.reguserid;                       //登録ユーザーID
                dto.regdttm = dtoOld.regdttm;                           //登録日時
            }
            dto.upduserid = req.userid;                                 //更新ユーザーID
            dto.upddttm = dttm;

            return dto;
        }

        /// <summary>
        /// 医療機関サブマスタ
        /// </summary>
        public static List<tm_afkikan_subDto> GetDtl(string kikancd, SaveDetailRequest req)
        {
            var dtl = new List<tm_afkikan_subDto>();
            var jissijigyoList = req.jissijigyoSelectorList.Where(e => e.checkflg).Select(e => e.jissijigyo);
            foreach (string jissijigyo in jissijigyoList)
            {
                var dto = new tm_afkikan_subDto();
                dto.kikancd = kikancd;                  //医療機関コード
                dto.jissijigyo = jissijigyo;            //実施事業コード         
                
                dtl.Add(dto);
            }

            return dtl;
        }

    }
}
