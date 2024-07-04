// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業従事者（担当者）保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.4
// 作成者　　: 劉誠
// 変更履歴　:
// *******************************************************************


namespace BCC.Affect.Service.AWKK00203G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータを取得(一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchListRequest.staffid)}_in", CmLogicUtil.GetSearchPara(req.staffid)),                 //事業従業者ID
                new($"{nameof(SearchListRequest.kikancd)}_in", CmLogicUtil.GetSearchPara(req.kikancd)),                 //医療機関(コード)
                new($"{nameof(SearchListRequest.syokusyu)}_in",CmLogicUtil.GetSearchPara(req.syokusyu)),                //職種
                new($"{nameof(SearchListRequest.katudokbn)}_in", CmLogicUtil.GetSearchPara(req.katudokbn)),             //活動区分
                new($"{nameof(SearchListRequest.staffsimei)}_in", req.staffsimei),                                      //事業従事者氏名
                new($"{nameof(SearchListRequest.kanastaffsimei)}_in", req.kanastaffsimei)                               //事業従事者カナ氏名
            };

            return paras;
        }

        /// <summary>
        /// 検索パラメータを取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(string staffid)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof( tm_afstaff_subDto.staffid )}_in", staffid ) //事業従業者ID
            };

            return paras;
        }

        /// <summary>
        /// 事業従事者（担当者）マスタ
        /// </summary>
        public static tm_afstaffDto GetDto(tm_afstaffDto dtoOld, SaveDetailRequest req,DateTime dttm)
        {
            var vm = req.mainInfo;
            var dto = new tm_afstaffDto();
            dto.staffid = vm.staffid;                   //事業従業者ID
            dto.staffsimei = vm.staffsimei;             //事業従事者氏名
            dto.kanastaffsimei = vm.kanastaffsimei;     //事業従事者カナ氏名
            dto.syokusyu = vm.syokusyu;                 //職種
            dto.katudokbn = vm.katudokbn;               //活動区分
            dto.stopflg = vm.stopflg;                   //フラグ

            //新規の場合
            if(req.editkbn == Enum編集区分.新規)
            {
                dto.reguserid = req.userid;             //登録ユーザーID
                dto.regdttm = dttm;                     //登録日時
            }
            else
            {
                dto.reguserid = dtoOld.reguserid;       //登録ユーザーID
                dto.regdttm = dtoOld.regdttm;           //登録日時
            }
            dto.upduserid = req.userid;                 //更新ユーザーID
            dto.upddttm = dttm;                         //更新日時

            return dto;
        }

        /// <summary>
        /// 事業従事者（担当者）サブマスタ
        /// </summary>
        public static List<tm_afstaff_subDto> GetDtl(string staffid, SaveDetailRequest req)
        {
            var dtl = new List<tm_afstaff_subDto>();
            var jissijigyoList = req.jissijigyoSelectorList.Where(e => e.checkflg == true).Select(e => e.jissijigyo);
            foreach (string jissijigyo in jissijigyoList)
            {
                var dto = new tm_afstaff_subDto();
                dto.staffid = staffid;                  //事業従業者ID
                dto.jissijigyo = jissijigyo;            //実施事業コード         
                dtl.Add(dto);
            }

            return dtl;
        }
        /// <summary>
        /// 医療機関
        /// </summary>
        public static List<tm_afstaff_kikanDto> GetkikanDto(string staffid, SaveDetailRequest req)
        {
            var dtoList = new List<tm_afstaff_kikanDto>();
            if (req.kikanlist == null)
            {
                return dtoList;
            }
            foreach (string kikancd in req.kikanlist )
            {
                CmLogicUtil.GetSearchPara(kikancd);
                var dto = new tm_afstaff_kikanDto();
                dto.staffid = staffid;              //事業従業者ID 
                dto.kikancd = kikancd;              //医療機関コード               
                dtoList.Add(dto);
            }
            return dtoList;
        }

    }
}