// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: フォロー管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.11.24
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00401G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得(内容画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchFollowNaiyoListRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.atenano)}_in", req.atenano));    //宛名番号
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.haakujigyocd)}s_in", null));     //事業コード一覧(表示範囲)

            return paras;
        }

        /// <summary>
        /// 検索パラメータ取得(結果画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchFollowNaiyoRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.atenano)}_in", req.atenano));                      //宛名番号
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.follownaiyoedano)}_in", req.follownaiyoedano));    //フォロー内容枝番

            return paras;
        }

        /// <summary>
        /// 検索パラメータ取得(詳細画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchFollowDetailRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.atenano)}_in", req.atenano));                      //宛名番号
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.follownaiyoedano)}_in", req.follownaiyoedano));    //フォロー内容枝番

            return paras;
        }

        /// <summary>
        /// フォロー内容情報
        /// </summary>
        public static tt_kkfollownaiyoDto GetDto(tt_kkfollownaiyoDto dto, RowFollowKekkaVM vm)
        {
            dto.atenano = vm.atenano;                                     //宛名番号
            dto.follownaiyoedano = vm.follownaiyoedano;                   //フォロー内容枝番
            dto.follownaiyo = vm.follownaiyo;                             //フォロー内容
            dto.haakukeiro = DaSelectorService.GetCd(vm.haakukeiro);      //把握経路
            dto.haakujigyocd = DaSelectorService.GetCd(vm.haakujigyocd);  //把握事業
            dto.followstatus = DaSelectorService.GetCd(vm.followstatus);  //フォロー状況

            return dto;
        }

        /// <summary>
        /// フォロー予定情報(詳細画面)
        /// </summary>
        public static tt_kkfollowyoteiDto GetYoteiDetailDto(tt_kkfollowyoteiDto dto, FollowDetailVM vm, bool yoteiinputflg)
        {
            dto.atenano = vm.atenano;                                                      //宛名番号
            dto.follownaiyoedano = vm.follownaiyoedano;                                    //フォロー内容枝番
            dto.edano = vm.edano;                                                          //枝番
            dto.followjigyocd = DaSelectorService.GetCd(vm.followjigyocd);                 //フォロー事業
            if (yoteiinputflg)
            {
                dto.followhoho = DaSelectorService.GetCd(vm.followhoho_yotei);                 //フォロー方法
                dto.followyoteiymd = vm.followyoteiymd;                                        //フォロー予定日
                dto.followtm = string.IsNullOrEmpty(vm.followtm_yotei) ?
                               "" : vm.followtm_yotei.Replace(DaStrPool.COLON, string.Empty);  //フォロー時間
                dto.followkaijocd = DaSelectorService.GetCd(vm.followkaijocd_yotei);           //フォロー会場コード
                dto.followriyu = vm.followriyu;                                                //フォロー理由
                dto.followstaffid = vm.followstaffid_yotei;                                    //フォロー担当者
            }

            return dto;
        }

        /// <summary>
        /// フォロー結果情報(詳細画面)
        /// </summary>
        public static tt_kkfollowkekkaDto GetKekkaDetailDto(tt_kkfollowkekkaDto dto, FollowDetailVM vm, bool kekkainputflg)
        {
            dto.atenano = vm.atenano;                                                       //宛名番号
            dto.follownaiyoedano = vm.follownaiyoedano;                                     //フォロー内容枝番
            dto.edano = vm.edano;                                                           //登録事枝番由
            dto.followjigyocd = DaSelectorService.GetCd(vm.followjigyocd);                  //フォロー事業
            if (kekkainputflg)
            {
                dto.followhoho = DaSelectorService.GetCd(vm.followhoho);                        //フォロー方法
                dto.followjissiymd = vm.followjissiymd;                                         //フォロー実施日
                dto.followtm = string.IsNullOrEmpty(vm.followtm) ?
                               "" : vm.followtm.Replace(DaStrPool.COLON, string.Empty);         //フォロー時間
                dto.followkaijocd = DaSelectorService.GetCd(vm.followkaijocd);                  //フォロー会場コード
                dto.followkekka = vm.followkekka;                                               //フォロー結果
                dto.followstaffid = vm.followstaffid;                                           //フォロー担当者
            }

            return dto;
        }
    }
}
