// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: バッチスケジュール管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.06
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF01001G
{
    public class Converter : CmConerterBase
    {       
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();

            paras.Add(new AiKeyValue($"{nameof(tm_aftaskscheduleDto.taskid)}_in", CmLogicUtil.GetSearchPara(req.tasknm)));              //タスク名
            paras.Add(new AiKeyValue($"{nameof(tm_aftaskscheduleDto.syorikbn)}_in", CmLogicUtil.GetSearchPara(req.kbn)));               //処理区分
            paras.Add(new AiKeyValue($"{nameof(tm_aftaskscheduleDto.gyomukbn)}_in", CmLogicUtil.GetSearchPara(req.gyomukbn)));          //業務区分
            paras.Add(new AiKeyValue($"{nameof(tm_aftaskscheduleDto.statuscd)}_in", CmLogicUtil.GetSearchPara(req.statuscd)));          //前回処理結果
            return paras;
        }
        public static List<AiKeyValue> GetBatchParameters(ExeBatchDetailRequest req)
        {
            var paras = new List<AiKeyValue>();

            paras.Add(new AiKeyValue($"{nameof(tm_aftaskscheduleDto.taskid)}_in", CmLogicUtil.GetSearchPara(req.taskid)));              //タスクID
            return paras;
        }
        /// <summary>
        /// バッチスケジュール管理マスタ
        /// </summary>
        public static tm_aftaskscheduleDto GetDto(tm_aftaskscheduleDto dtoOld, SaveDetailRequest req, DateTime dttm)
        {
            var vm = req.maininfo;
            var dto = new tm_aftaskscheduleDto();
            dto.maitukituki = string.Empty;                                         //毎月の月
            dto.maitukihi = string.Empty;                                           //毎月の日
            dto.maitukisyu = string.Empty;                                          //毎月の週
            dto.yobi = string.Empty;                                                //毎月の曜日
            dto.taskid = vm.taskid;                                     　　　　　　//タスクID
            dto.tasknm = vm.tasknm;                                     　　　　　　//タスク名
            dto.renkeiid = vm.jotai == "3" ? null : dtoOld.renkeiid;            　  //HangFire連携ID TODOバッチサービス連携 
            dto.biko = vm.biko;                                                     //説明
                                                                                    //新規の場合
            if (req.editkbn == Enum編集区分.新規)
            {
                dto.zenjikkodttmf = null;                               　　　　　　//前回の実行日時（開始）
                dto.zenjikkodttmt = null;                               　　　　　　//前回の実行日時（終了）
                dto.reguserid = req.userid;                             　　　　　　//登録ユーザーID
                dto.regdttm = dttm;                                     　　　　　　//登録日時
            }
            else
            {
                dto.zenjikkodttmf = vm.zenjikkodttmf;                   　　　　　　//前回の実行日時（開始）
                dto.zenjikkodttmt = vm.zenjikkodttmt;                   　　　　　　//前回の実行日時（終了）
                dto.reguserid = dtoOld.reguserid;                       　　　　　　//登録ユーザーID
                dto.regdttm = dtoOld.regdttm;                           　　　　　　//登録日時
            }
            dto.syorikbn = DaSelectorService.GetCd(vm.syorikbn);        　　　　　　//処理区分
            dto.gyomukbn = vm.gyomukbn;                                 　　　　　　//業務区分
            dto.modulecd = DaSelectorService.GetCd(vm.modulecd);        　　　　　　//モジュール名
            dto.yukoymdf = vm.yukoymdf;                                 　　　　　　//有効年月日（開始）
            dto.yukotmf = vm.yukotmf.Replace(DaStrPool.COLON, string.Empty);        //有効時間（開始）
            dto.hindokbn = vm.hindokbn;                               　　　　　　  //頻度区分
            Sethindo(vm, dto);
            dto.syukustopflg = vm.syukustopflg;                                     //祝日停止フラグ
            dto.hikisu = vm.hikisu;                                                 //引数
            dto.stopflg = vm.jotai != "1";                                          //使用停止フラグ
            dto.statuscd = dtoOld.statuscd;                                         //処理結果コード
            dto.kurikaesikanflg = vm.kurikaesikanflg;                               //繰り返し間隔フラグ
            dto.kurikaesikankbn = DaSelectorService.GetCd(vm.kurikaesikankbn);      //繰り返し間隔区分
            dto.jikantaif = vm.jikantaif;                                           //時間帯開始_時
            dto.jikantait = vm.jikantait;                                           //時間帯終了_時
            dto.jikannaif = vm.jikannaif;                                           //時間内開始_分
            dto.jikannait = vm.jikannait;                                           //時間内終了_分

            dto.upduserid = req.userid;                                             //更新ユーザーID
            dto.upddttm = dttm;

            return dto;
        }

        /// <summary>
        /// 配列を指定された長さの文字列に変換します
        /// </summary>
        /// <param name="length">配列長さ</param>
        /// <param name="values">配列</param>
        /// <returns></returns>
        private static string GetYobi(MainInfoVM vm)
        {
            string yobi = string.Empty;
            yobi += BoolToStr(CBool(vm.sunday));
            yobi += BoolToStr(CBool(vm.monday));
            yobi += BoolToStr(CBool(vm.tuesday));
            yobi += BoolToStr(CBool(vm.wednesday));
            yobi += BoolToStr(CBool(vm.thursday));
            yobi += BoolToStr(CBool(vm.friday));
            yobi += BoolToStr(CBool(vm.saturday));
            return yobi;
        }

        /// <summary>
        /// 配列を指定された長さの文字列に変換します
        /// </summary>
        /// <param name="length">配列長さ</param>
        /// <param name="values">配列</param>
        /// <returns></returns>
        private static string ArrayConvertString(int length, string[] values)
        {
            string result = new('0', length);
            char[] charArray = result.ToCharArray();

            foreach (string value in values)
            {
                int idx = int.Parse(value) - 1;
                if (idx < length)
                {
                    //配列の指定桁数が1になる
                    charArray[idx] = '1';
                }
            }

            return string.Join("", charArray);
        }

        /// <summary>
        /// 頻度詳細につい、データを設定する。
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="dto"></param>
        private static void Sethindo(MainInfoVM vm, tm_aftaskscheduleDto dto)
        {
            switch (vm.hindokbn)
            {
                //0：一回のみ
                case "0":
                    break;
                //1：毎日
                case "1":
                    break;
                //2：毎週
                case "2":
                    dto.yobi = GetYobi(vm);                                          //曜日
                    break;
                //3：毎月                                                           
                case "3":
                    dto.maitukihiyobikbn = vm.maitukihiyobikbn;                      //毎月の日・曜日区分
                    dto.maitukituki = ArrayConvertString(12, vm.maitukituki);        //毎月の月
                    //毎月の日・曜日区分：日の場合                                  
                    if (vm.maitukihiyobikbn == "0")
                    {
                        dto.maitukihi = ArrayConvertString(32, vm.maitukihi);       //毎月の日
                    }
                    else
                    {
                        dto.maitukisyu = ArrayConvertString(5, vm.maitukisyu);      //毎月の週
                        dto.yobi = ArrayConvertString(7, vm.yobi);                  //曜日
                    }
                    break;
                //上記以外
                default:
                    break;
            }

        }
    }
}