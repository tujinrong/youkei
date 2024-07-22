// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 電子ファイル情報
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.09
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00602D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req, List<string> keyList)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SearchRequest.atenano)}_in", req.atenano),                                    //宛名番号
                new($"{nameof(SearchRequest.jigyocd)}_in", ToNStr(DaSelectorService.GetCd(req.jigyocd))),   //事業コード
                new($"{nameof(SearchRequest.title)}_in", ToLikeStr(req.title)),                             //タイトル
                new($"{nameof(tt_afkojindocDto.jigyocd)}s_in", string.Join(DaStrPool.C_COMMA,keyList))      //事業コード一覧(表示範囲)
            };
            return paras;
        }

        /// <summary>
        /// キーリスト取得
        /// </summary>
        public static List<object[]> GetKeyList(string atenano, List<int> docseqs)
        {
            return docseqs.Select(seq => new object[] { atenano, seq }).ToList();
        }

        /// <summary>
        /// キーリスト取得
        /// </summary>
        public static List<object[]> GetKeyList(string atenano, List<LockVM> locklist)
        {
            return locklist.Select(k => new object[] { atenano, k.docseq }).ToList();
        }

        /// <summary>
        /// 個人ドキュメントテーブル
        /// </summary>
        public static tt_afkojindocDto GetDto(SaveRequest req, tt_afkojindocDto dto)
        {
            dto.atenano = req.atenano;                                          //宛名番号
            dto.filenm = req.savevm.filenm;                                     //ファイル名
            dto.jigyocd = ToNStr(DaSelectorService.GetCd(req.savevm.jigyo));    //事業コード
            dto.juyoflg = req.savevm.juyoflg;                                   //重要フラグ
            dto.title = ToNStr(req.savevm.title);                               //タイトル
            if (req.files.Count != 0)
            {
                var file = req.files[0];
                dto.filetype = CmFileUtil.GetFileTypeKbn(file.filetype);        //ファイルタイプ
                dto.filesize = file.filesize;                                   //ファイルサイズ
                dto.filedata = file.filedata;                                   //ファイルデータ
            }
            return dto;
        }
    }
}