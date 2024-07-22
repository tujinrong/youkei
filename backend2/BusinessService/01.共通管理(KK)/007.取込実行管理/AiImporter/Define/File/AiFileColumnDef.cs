// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　ファイル項目チェック処理
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter.Define.File
{
    public class AiFileColumnDef
    {
        /// <summary>
        /// 列名(ファイル項目ID)
        /// 
        public string ColumnName { get; set; }

        /// <summary>
        /// ファイル項目名
        /// 
        public string itemnm { get; set; }

        /// <summary>
        /// データ型
        /// 
        public string datatype { get; set; }

        /// <summary>
        /// 桁数
        /// 
        public int len { get; set; }

        /// <summary>
        /// 桁数（小数部）
        /// 
        public int? len2 { get; set; }

        /// <summary>
        /// フォーマット
        /// 
        public string? format { get; set; }

        /// <summary>
        /// フォーマットチェック
        /// 
        public string? fmtcheck { get; set; }

        /// <summary>
        /// フォーマット変換
        /// 
        public string? fmtchange { get; set; }

        /// <summary>
        /// ファイルに対して必要なチェック
        /// </summary>
        public bool Check(DaDbContext db, DataRow dr, int rowIndex, ImCheckOption option, Dictionary<string, List<FileFormatDataModel>> itemsFormatResultDic, out ImFileErrorRow? error)
        {
            error = null;
            //ファイル項目値
            string value = CStr(dr[ColumnName]);
            //行番号
            int rowNo = CInt(dr["RowNo"]);

            //桁数（データ型が数値（小数点付き実数）の場合）
            if (datatype == EnumToStr(Enum入力方法.数値_小数点付き実数))
            {
                //データ型が数値（小数点付き実数）
                var pattern = $@"^\d{{1,{len}}}(?:\.\d{{1,{len2}}})?$";
                if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value, pattern))
                {
                    error = new ImFileErrorRow(rowNo, itemnm, value, EnumMessage.E001010, len + "," + len2);
                    return false;
                }
            }
            else if (value.Length > len)
            {
                error = new ImFileErrorRow(rowNo, itemnm, value, EnumMessage.E001010, len);
                return false;
            }

            //データ型 日付
            if (!string.IsNullOrEmpty(value) &&
                (datatype == EnumToStr(Enum入力方法.日時_年月日時分秒)
                || datatype == EnumToStr(Enum入力方法.日付_年月日_不詳あり)
                || datatype == EnumToStr(Enum入力方法.日付_年月日)
                || datatype == EnumToStr(Enum入力方法.半角文字_年月_不詳あり)
                || datatype == EnumToStr(Enum入力方法.半角文字_年月)
                || datatype == EnumToStr(Enum入力方法.半角文字_年_不詳あり)
                || datatype == EnumToStr(Enum入力方法.半角文字_年)))
            {
                var strDate = string.Empty;
                //その他
                if (format == フォーマット_日付._99)
                {
                    //フォーマット_日付を取得する
                    var resultMsg = "フォーマット関数実行失敗しました。";
                    strDate = GetOtherDate(itemsFormatResultDic, rowIndex, ref resultMsg);
                    //チェックエラーまたは変換エラー時
                    if (string.IsNullOrEmpty(strDate))
                    {
                        error = new ImFileErrorRow(rowNo, itemnm, value, resultMsg);
                        return false;
                    }
                }
                //データ型 フォーマット日付
                else if (datatype == EnumToStr(Enum入力方法.日時_年月日時分秒) || datatype == EnumToStr(Enum入力方法.日付_年月日) || datatype == EnumToStr(Enum入力方法.半角文字_年月) || datatype == EnumToStr(Enum入力方法.半角文字_年))
                {
                    //フォーマット_日付を取得する
                    strDate = GetDate(value, option.FormatDateDic);
                }
                //データ型 フォーマット日付不詳
                else if (datatype == EnumToStr(Enum入力方法.日付_年月日_不詳あり) || datatype == EnumToStr(Enum入力方法.半角文字_年月_不詳あり) || datatype == EnumToStr(Enum入力方法.半角文字_年_不詳あり))
                {
                    //フォーマット_日付(不詳)を取得する
                    strDate = GetDateFusyo(value);
                }

                //日付変換取得不正の場合
                if (string.IsNullOrEmpty(strDate))
                {
                    //フォーマットエラーを作成
                    error = GetFormatErr(rowNo, value, format!, option);
                    return false;
                }
                else
                {
                    dr[ColumnName] = strDate;
                }
            }
            else
            {
                //入力方法_データ型チェック
                if (!string.IsNullOrEmpty(value) && !ImDataTypeUtil.CheckDataType(datatype, value))
                {
                    var typenm = option.DataTypeDic.ContainsKey(datatype) ? option.DataTypeDic[datatype] : datatype;
                    error = new ImFileErrorRow(rowNo, itemnm, value, EnumMessage.E001009, typenm);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// フォーマット_日付を取得する
        /// </summary>
        private string GetDate(string value, Dictionary<string, string> formatDateDic)
        {
            switch (format)
            {
                case フォーマット_日付._1:
                    //ggy年
                    return ImFormatUtil.GetWarekiDateY(value, ImFormatUtil.DatePattern1);
                case フォーマット_日付._2:
                    //ggyy年
                    return ImFormatUtil.GetWarekiDateY(value, ImFormatUtil.DatePattern2);
                case フォーマット_日付._3:
                    //gy
                    return ImFormatUtil.GetWarekiDateY(value, ImFormatUtil.DatePattern3);
                case フォーマット_日付._4:
                    //gyy
                    return ImFormatUtil.GetWarekiDateY(value, ImFormatUtil.DatePattern4);
                case フォーマット_日付._5:
                    //yy(505)
                    return ImFormatUtil.GetWarekiDateY(value, ImFormatUtil.DatePattern5);
                case フォーマット_日付._6:
                    //yyyy
                    return ImFormatUtil.GetDateY(value, ImFormatUtil.DatePattern6);
                case フォーマット_日付._7:
                    //yyyy年
                    return ImFormatUtil.GetDateY(value, ImFormatUtil.DatePattern7);
                case フォーマット_日付._8:
                    //ggy年M月
                    return ImFormatUtil.GetWarekiDateYM(value, ImFormatUtil.DatePattern8);
                case フォーマット_日付._9:
                    //ggyy年MM月
                    return ImFormatUtil.GetWarekiDateYM(value, ImFormatUtil.DatePattern9);
                case フォーマット_日付._10:
                    //gy.M
                    return ImFormatUtil.GetWarekiDateYM(value, ImFormatUtil.DatePattern10);
                case フォーマット_日付._11:
                    //gyy.MM
                    return ImFormatUtil.GetWarekiDateYM(value, ImFormatUtil.DatePattern11);
                case フォーマット_日付._12:
                    //yyMM(50505)
                    return ImFormatUtil.GetWarekiDateYM(value, ImFormatUtil.DatePattern12);
                case フォーマット_日付._13:
                    //yyyy年M月
                    return ImFormatUtil.GetDateYM(value, ImFormatUtil.DatePattern13);
                case フォーマット_日付._14:
                    //yyyy年MM月
                    return ImFormatUtil.GetDateYM(value, ImFormatUtil.DatePattern14);
                case フォーマット_日付._15:
                    //yyyy/M
                    return ImFormatUtil.GetDateYM(value, ImFormatUtil.DatePattern15);
                case フォーマット_日付._16:
                    //yyyy/MM
                    return ImFormatUtil.GetDateYM(value, ImFormatUtil.DatePattern16);
                case フォーマット_日付._17:
                    //yyyyMM
                    return ImFormatUtil.GetDateYM(value, ImFormatUtil.DatePattern17);
                case フォーマット_日付._18:
                    //ggy年M月d日
                    return ImFormatUtil.GetWarekiDateYMD(value, ImFormatUtil.DatePattern18);
                case フォーマット_日付._19:
                    //ggyy年MM月dd日
                    return ImFormatUtil.GetWarekiDateYMD(value, ImFormatUtil.DatePattern19);
                case フォーマット_日付._20:
                    //gy.M.d
                    return ImFormatUtil.GetWarekiDateYMD(value, ImFormatUtil.DatePattern20);
                case フォーマット_日付._21:
                    //gyy.MM.dd
                    return ImFormatUtil.GetWarekiDateYMD(value, ImFormatUtil.DatePattern21);
                case フォーマット_日付._22:
                    //yyMMdd(5050505)
                    return ImFormatUtil.GetWarekiDateYMD(value, ImFormatUtil.DatePattern22);
                case フォーマット_日付._23:
                    //yyyy年M月d日
                    return ImFormatUtil.GetDateYMD(value, ImFormatUtil.DatePattern23);
                case フォーマット_日付._24:
                    //yyyy年MM月dd日
                    return ImFormatUtil.GetDateYMD(value, ImFormatUtil.DatePattern24);
                case フォーマット_日付._25:
                    //yyyy/M/d
                    return ImFormatUtil.GetDateYMD(value, ImFormatUtil.DatePattern25);
                case フォーマット_日付._26:
                    //yyyy/MM/dd
                    return ImFormatUtil.GetDateYMD(value, ImFormatUtil.DatePattern26);
                case フォーマット_日付._27:
                    //yyyyMMdd
                    return ImFormatUtil.GetDateYMD(value, ImFormatUtil.DatePattern27);
                case フォーマット_日付._28:
                    //ggy年M月d日 H時m分s秒
                    return ImFormatUtil.GetWarekiDateYMDHMS(value, ImFormatUtil.DatePattern28);
                case フォーマット_日付._29:
                    //ggyy年MM月dd日 HH時mm分ss秒
                    return ImFormatUtil.GetWarekiDateYMDHMS(value, ImFormatUtil.DatePattern29);
                case フォーマット_日付._30:
                    //gy.M.d H:m:s
                    return ImFormatUtil.GetWarekiDateYMDHMS(value, ImFormatUtil.DatePattern30);
                case フォーマット_日付._31:
                    //gyy.MM.dd HH:mm:ss
                    return ImFormatUtil.GetWarekiDateYMDHMS(value, ImFormatUtil.DatePattern31);
                case フォーマット_日付._32:
                    //yyyy年M月d日 H時m分s秒
                    return ImFormatUtil.GetDateYMDHMS(value, ImFormatUtil.DatePattern32);
                case フォーマット_日付._33:
                    //yyyy年MM月dd日 HH時mm分ss秒
                    return ImFormatUtil.GetDateYMDHMS(value, ImFormatUtil.DatePattern33);
                case フォーマット_日付._34:
                    //yyyy/M/d H:m:s
                    return ImFormatUtil.GetDateYMDHMS(value, ImFormatUtil.DatePattern34);
                case フォーマット_日付._35:
                    //yyyy/MM/dd HH:mm:ss
                    return ImFormatUtil.GetDateYMDHMS(value, ImFormatUtil.DatePattern35);
                case フォーマット_日付._36:
                    //yyyyMMddHHmmss
                    return ImFormatUtil.GetDateYMDHMS(value, ImFormatUtil.DatePattern36);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// フォーマット_日付を取得する(不詳)
        /// </summary>
        private string GetDateFusyo(string value)
        {
            switch (format)
            {
                case フォーマット_日付._1:
                    //ggy年
                    return ImFormatUtil.GetFusyoWarekiDateY(value, ImFormatUtil.FusyoDatePattern1);
                case フォーマット_日付._2:
                    //ggyy年
                    return ImFormatUtil.GetFusyoWarekiDateY(value, ImFormatUtil.FusyoDatePattern2);
                case フォーマット_日付._6:
                    //yyyy
                    return ImFormatUtil.GetFusyoDateY(value, ImFormatUtil.FusyoDatePattern6);
                case フォーマット_日付._7:
                    //yyyy年
                    return ImFormatUtil.GetFusyoDateY(value, ImFormatUtil.FusyoDatePattern7);
                case フォーマット_日付._8:
                    //ggy年M月
                    return ImFormatUtil.GetFusyoWarekiDateYM(value, ImFormatUtil.FusyoDatePattern8);
                case フォーマット_日付._9:
                    //ggyy年MM月
                    return ImFormatUtil.GetFusyoWarekiDateYM(value, ImFormatUtil.FusyoDatePattern9);
                case フォーマット_日付._13:
                    //yyyy年M月
                    return ImFormatUtil.GetFusyoDateYM(value, ImFormatUtil.FusyoDatePattern13);
                case フォーマット_日付._14:
                    //yyyy年MM月
                    return ImFormatUtil.GetFusyoDateYM(value, ImFormatUtil.FusyoDatePattern14);
                case フォーマット_日付._15:
                    //yyyy/M
                    return ImFormatUtil.GetFusyoDateYM(value, ImFormatUtil.FusyoDatePattern15);
                case フォーマット_日付._16:
                    //yyyy/MM
                    return ImFormatUtil.GetFusyoDateYM(value, ImFormatUtil.FusyoDatePattern16);
                case フォーマット_日付._17:
                    //yyyyMM
                    return ImFormatUtil.GetFusyoDateYM(value, ImFormatUtil.FusyoDatePattern17);
                case フォーマット_日付._18:
                    //ggy年M月d日
                    return ImFormatUtil.GetFusyoWarekiDateYMD(value, ImFormatUtil.FusyoDatePattern18);
                case フォーマット_日付._19:
                    //ggyy年MM月dd日
                    return ImFormatUtil.GetFusyoWarekiDateYMD(value, ImFormatUtil.FusyoDatePattern19);
                case フォーマット_日付._23:
                    //yyyy年M月d日
                    return ImFormatUtil.GetFusyoDateYMD(value, ImFormatUtil.FusyoDatePattern23);
                case フォーマット_日付._24:
                    //yyyy年MM月dd日
                    return ImFormatUtil.GetFusyoDateYMD(value, ImFormatUtil.FusyoDatePattern24);
                case フォーマット_日付._25:
                    //yyyy/M/d
                    return ImFormatUtil.GetFusyoDateYMD(value, ImFormatUtil.FusyoDatePattern25);
                case フォーマット_日付._26:
                    //yyyy/MM/dd
                    return ImFormatUtil.GetFusyoDateYMD(value, ImFormatUtil.FusyoDatePattern26);
                case フォーマット_日付._27:
                    //yyyyMMdd
                    return ImFormatUtil.GetFusyoDateYMD(value, ImFormatUtil.FusyoDatePattern27);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// フォーマットチェック（その他）
        /// </summary>
        private string GetOtherDate(Dictionary<string, List<FileFormatDataModel>> itemsFormatResultDic, int rowIndex, ref string resultMsg)
        {
            var strDate = string.Empty;

            if (!itemsFormatResultDic.ContainsKey(ColumnName))
            {
                return strDate;
            }
            //フォーマット結果
            var resultList = itemsFormatResultDic[ColumnName];
            //チェック実施して、
            var result = resultList.Find(e => e.FormatKbn == "1" && e.RowIndex == rowIndex);
            if (result == null)
            {
                return strDate;
            }

            //チェック成功時「00,」で返す、エラー時「10,MSG」で返す
            var results = result.Value.Split(',');
            //エラーがない時に設定した関数で変換をして後処理継続
            if (results.Length > 1 && results[0].Equals("00"))
            {
                //設定した関数で変換実施して、
                result = resultList.Find(e => e.FormatKbn == "2" && e.RowIndex == rowIndex);
                if (result != null)
                {
                    results = result.Value.Split(',');
                    //成功時「00,」で返す、エラー時「10,MSG」で返す
                    if (results.Length > 1 && results[0].Equals("00"))
                    {
                        //変換した値
                        strDate = results[1];
                    }
                    else if (results.Length > 1)
                    {
                        //エラーメッセージを取得する
                        resultMsg = results[1];
                    }
                }
            }
            else if (results.Length > 1)
            {
                //エラーメッセージを取得する
                resultMsg = results[1];
            }

            return strDate;
        }

        /// <summary>
        /// フォーマットエラーを作成
        /// </summary>
        private ImFileErrorRow GetFormatErr(int rowNo, string value, string format, ImCheckOption option)
        {
            var typenm = option.DataTypeDic.ContainsKey(datatype) ? option.DataTypeDic[datatype] : datatype;
            var formatnm = option.FormatDateDic.ContainsKey(format) ? option.FormatDateDic[format] : format;
            return new ImFileErrorRow(rowNo, itemnm, value, EnumMessage.E001009, typenm + "(" + formatnm + ")");
        }
    }

    public class FileFormatDataModel
    {
        public string FormatKbn { get; set; }
        public int RowIndex { get; set; }
        public string Value { get; set; }

        public FileFormatDataModel(string formatKbn, int rowIndex, string value)
        {
            FormatKbn = formatKbn;
            RowIndex = rowIndex;
            Value = value;
        }

    }
}
