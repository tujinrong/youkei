// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: お知らせ
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00302D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            List<AiKeyValue> paras = new List<AiKeyValue>()
            {
                new AiKeyValue($"{nameof(req.userid)}_in", req.userid),         //ユーザーID
                new AiKeyValue($"{nameof(req.showkbn)}_in", (int)req.showkbn),  //表示区分
                new AiKeyValue($"{nameof(req.readkbn)}_in", (int)req.readkbn)   //未読区分
            };
            return paras;
        }

        /// <summary>
        /// キーリスト取得(内容変更=>既読リセットのため)
        /// </summary>
        public static List<long> GetKeyList(List<UpdVM> vmlist, List<tt_afinfoDto> oldDtl)
        {
            var list = new List<long>();
            foreach (var dto in oldDtl)
            {
                var info = vmlist.Find(v => v.infoseq == dto.infoseq);
                if (info == null || (info != null && info.syosai != dto.syosai))
                {
                    list.Add(dto.infoseq);
                }
            }
            return list;
        }

        /// <summary>
        /// お知らせテーブル(新規)
        /// </summary>
        public static List<tt_afinfoDto> GetDtl(List<InfoVM> list)
        {
            List<tt_afinfoDto> dtl = new List<tt_afinfoDto>();
            foreach (InfoVM info in list)
            {
                dtl.Add(GetDto(info, new tt_afinfoDto()));
            }
            return dtl;
        }

        /// <summary>
        /// お知らせテーブル(更新)
        /// </summary>
        public static List<tt_afinfoDto> GetDtl(List<UpdVM> vmlist, List<tt_afinfoDto> oldDtl)
        {
            var dtl = new List<tt_afinfoDto>();
            foreach (var dto in oldDtl)
            {
                var info = vmlist.Find(v => v.infoseq == dto.infoseq);
                if (info != null)
                {
                    dtl.Add(GetDto(info, dto));
                }
            }
            return dtl;
        }

        /// <summary>
        /// お知らせ確認状態テーブル(更新)
        /// </summary>
        public static List<tt_afinfo_userDto> GetDtl(List<UpdVM> list, string userid)
        {
            return list.Where(vm => vm.readflg).Select(info =>
            {
                var dto = new tt_afinfo_userDto();
                dto.infoseq = info.infoseq;     //お知らせシーケンス
                dto.userid = userid;            //ユーザーID
                return dto;
            }).ToList();
        }

        /// <summary>
        /// お知らせテーブル
        /// </summary>
        private static tt_afinfoDto GetDto(InfoVM info, tt_afinfoDto dto)
        {
            dto.juyodo = DaSelectorService.GetCd(info.juyodo);              //重要度
            dto.kigenymd = FormatYMD(info.kigenymd);                        //提示期限
            dto.syosai = ToNStr(info.syosai);                               //詳細
            dto.atesakiflg = info.atesakiflg;                               //宛先指定フラグ
            if (info.atesakiflg)
            {
                dto.atesaki = string.Join(DaStrPool.COMMA, info.userlist!); //宛先
            }
            else
            {
                dto.atesaki = null;                                         //宛先
            }

            return dto;
        }
    }
}