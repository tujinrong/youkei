// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象者抽出情報管理（専用）
//             リクエストインターフェース
// 作成日　　: 2024.05.27
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK01301G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得(一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req, string nendoSetting)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchListRequest.nendo)}_in", (nendoSetting == 名称マスタ.システム.通知サイクル._1 ? CNInt(req.nendo) : 9999)),         //年度
                new($"{nameof(SearchListRequest.tyusyututaisyo)}cd_in", CStr(DaSelectorService.GetCd(req.tyusyututaisyo))),                            //抽出対象
                new($"{nameof(SearchListRequest.tyusyutunaiyo)}_in", req.tyusyutunaiyo),                                                               //抽出内容
                new($"{nameof(SearchListRequest.regdttmf)}_in", req.regdttmf),                                                                         //抽出日（開始）
                new($"{nameof(SearchListRequest.regdttmt)}_in", req.regdttmt),                                                                         //抽出日（終了）
                new($"{nameof(tm_kktyusyutuDto.tyusyutukinoid)}_in", req.kinoid!)                                                                      //機能ID
            };

            return paras;
        }
        /// <summary>
        /// 抽出パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetExtractParameters(ExtractRequest req, string nendoSetting, tm_kktyusyutuDto mstDto,
                                                        List<tm_kktaisyosya_tyusyutufreeitemDto> itemDtl)
        {
            //抽出ストアドの固定パラメータ
            var paras = new List<AiKeyValue> {
                new($"{nameof(ExtractRequest.tyusyututaisyocd)}_in", mstDto.tyusyututaisyocd),                                                      //抽出対象コード
                new($"{nameof(tm_kktyusyutuDto.tyusyutudatasyosaikbn)}_in", mstDto.tyusyutudatasyosaikbn),                                          //抽出データ詳細区分
                new($"{nameof(ExtractRequest.atenano)}_in", req.atenano),                                                                           //宛名番号（個別抽出の場合）
                new($"{nameof(ExtractRequest.tyusyutunaiyo)}_in", req.tyusyutunaiyo),                                                               //抽出内容
                new($"{nameof(ExtractRequest.continueflg)}_in", req.continueflg),                                                                   //継続希望フラグ
                new($"{nameof(ExtractRequest.nendo)}_in", (nendoSetting == 名称マスタ.システム.通知サイクル._1 ? CNInt(req.nendo) : 9999)),         //年度
                new($"{nameof(ExtractRequest.regsisyo)}_in", req.regsisyo),                                                                         //登録支所
                new($"{nameof(ExtractRequest.userid)}_in", req.userid)                                                                              //ユーザーID
            };

            //画面に入力有りのパラメータ
            var jyokencds = new List<string>();
            if (req.parameters != null)
            { 
                jyokencds = req.parameters.Select(e => e.itemcd).ToList();
            }
            //すべてのパラメータ
            var allitemcds = itemDtl.Select(e => e.itemcd).ToList();

            if (jyokencds.Count > 0)
            {
                //画面に入力なしのパラメータ
                var blankitemcds = allitemcds.Where(x => !jyokencds.Any(y => y == x)).ToList();

                //抽出ストアドの可変パラメータ（画面入力有りの場合）
                foreach (var p in req.parameters)
                {
                    var itemDto = itemDtl.Where(e => e.itemcd == p.itemcd).FirstOrDefault();
                    var inputvalue = p.value;
                    //todochen 配列変換ロジックを削除
                    //if (itemDto!.inputtype == (int)Enum入力タイプ.年齢範囲＿抽出専用画面のみ使用可)
                    //{
                    //    //入力タイプが年齢範囲（抽出専用画面のみ使用可）の場合、配列に変換
                    //    inputvalue = ConvertToPostgresArrayString(GetAgeArray(inputvalue));
                    //}
                    paras.Add(new($"item_{p.itemcd}_in", inputvalue));
                }
                //抽出ストアドの可変パラメータ（画面入力無しの場合）
                foreach (var blankitemcd in blankitemcds)
                {
                    paras.Add(new($"item_{blankitemcd}_in", null));
                }
            } else
            {
                //抽出ストアドの可変パラメータ（画面入力無しの場合）
                foreach (var itemcd in allitemcds)
                {
                    paras.Add(new($"item_{itemcd}_in", null));
                }
            }

            return paras;
        }

        /// <summary>
        /// 年齢入力を文字列から配列に変換 todochen 配列変換ロジックを削除
        /// </summary>
        //private static List<int[]> GetAgeArray(object age)
        //{
        //    var ageRanges = new List<int[]>();
        //    var ranges = CStr(age).Split(',');

        //    foreach (var range in ranges)
        //    {
        //        if (range.Contains('-'))
        //        {
        //            var bounds = range.Split('-');
        //            ageRanges.Add(new int[] { int.Parse(bounds[0]), int.Parse(bounds[1]) });
        //        }
        //        else
        //        {
        //            int value = int.Parse(range);
        //            ageRanges.Add(new int[] { value, value });
        //        }
        //    }

        //    return ageRanges;
        //}
        /// <summary>
        /// 年齢入力を文字列から配列に変換 todochen 配列変換ロジックを削除
        /// </summary>
        //private static string ConvertToPostgresArrayString(List<int[]> list)
        //{
        //    var list2 = list.Select(e => string.Join(",", e));
        //    return $"{{{string.Join("},{", list2)}}}";
        //}
    }
}