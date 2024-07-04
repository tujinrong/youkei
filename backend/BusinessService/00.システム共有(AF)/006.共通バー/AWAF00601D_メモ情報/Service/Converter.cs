// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メモ情報
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.03.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00601D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano, List<string> keyList)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SearchRequest.atenano)}_in", atenano),                                    //宛名番号
                new($"{nameof(tt_afmemoDto.jigyokbn)}s_in", string.Join(DaStrPool.C_COMMA,keyList))     //事業コード一覧(表示範囲)
            };
            return paras;
        }

        /// <summary>
        /// キーリスト(編集前)
        /// </summary>
        public static List<object[]> GetKeyList(string atenano, List<LockVM> locklist)
        {
            return locklist.Select(k => new object[] { atenano, k.memoseq }).ToList();
        }

        /// <summary>
        /// メモテーブル(新規)
        /// </summary>
        public static List<tt_afmemoDto> GetDtl(List<AddVM> addList, string atenano, int maxSeq)
        {
            return addList.Select(x => GetDto(x, new tt_afmemoDto(), atenano, ++maxSeq)).ToList();
        }

        /// <summary>
        /// メモテーブル(更新)
        /// </summary>
        public static List<tt_afmemoDto> GetDtl(List<UpdVM> updlist, List<tt_afmemoDto> oldDtl)
        {
            var dtl = new List<tt_afmemoDto>();
            foreach (var dto in oldDtl)
            {
                var vm = updlist.Find(x => x.memoseq == dto.memoseq);
                if (vm != null)
                {
                    dtl.Add(GetDto(vm, dto, dto.atenano, dto.memoseq));
                }
            }
            return dtl;
        }

        /// <summary>
        /// メモテーブル
        /// </summary>
        private static tt_afmemoDto GetDto(AddVM vm, tt_afmemoDto dto, string atenano, int memoseq)
        {
            dto.atenano = atenano;                                //宛名番号
            dto.memoseq = memoseq;                                //メモシーケンス
            dto.jigyokbn = DaSelectorService.GetCd(vm.jigyokbn);  //登録事業（共通・各事業）
            dto.juyodo = DaSelectorService.GetCd(vm.juyodo);      //重要度
            dto.kigenymd = ToNStr(vm.kigenymd);                   //期限日
            dto.title = ToNStr(vm.title);                         //件名（タイトル）
            dto.memo = vm.memo;                                   //メモ（フリーテキスト）

            return dto;
        }
    }
}