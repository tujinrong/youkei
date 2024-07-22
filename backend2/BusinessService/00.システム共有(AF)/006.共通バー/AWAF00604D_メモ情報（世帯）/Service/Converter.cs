// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報（世帯）
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00604D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(string setaino, List<string> keyList)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(tt_afmemosetaiDto.setaino)}_in", setaino),                                    //世帯番号
                new($"{nameof(tt_afmemosetaiDto.jigyokbn)}s_in", string.Join(DaStrPool.C_COMMA,keyList))    //事業コード一覧(表示範囲)
            };
            return paras;
        }

        /// <summary>
        /// キーリスト(編集前)
        /// </summary>
        public static List<object[]> GetKeyList(string setaino, List<AWAF00601D.LockVM> locklist)
        {
            return locklist.Select(k => new object[] { setaino, k.memoseq }).ToList();
        }

        /// <summary>
        /// メモ情報（世帯）テーブル(新規)
        /// </summary>
        public static List<tt_afmemosetaiDto> GetDtl(List<AWAF00601D.AddVM> addList, string setaino, int maxSeq)
        {
            return addList.Select(x => GetDto(x, new tt_afmemosetaiDto(), setaino, ++maxSeq)).ToList();
        }

        /// <summary>
        /// メモ情報（世帯）テーブル(更新)
        /// </summary>
        public static List<tt_afmemosetaiDto> GetDtl(List<AWAF00601D.UpdVM> updlist, List<tt_afmemosetaiDto> oldDtl)
        {
            var dtl = new List<tt_afmemosetaiDto>();
            foreach (var dto in oldDtl)
            {
                var vm = updlist.Find(x => x.memoseq == dto.memoseq);
                if (vm != null)
                {
                    dtl.Add(GetDto(vm, dto, dto.setaino, dto.memoseq));
                }
            }
            return dtl;
        }

        /// <summary>
        /// メモ情報（世帯）テーブル
        /// </summary>
        private static tt_afmemosetaiDto GetDto(AWAF00601D.AddVM vm, tt_afmemosetaiDto dto, string setaino, int memoseq)
        {
            dto.setaino = setaino;                                //世帯番号
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