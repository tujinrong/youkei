// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　編集項目定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using System.Globalization;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImEditorColumnDef
    {
        public int pageitemseq { get; set; }                      //画面項目ID
        public string itemnm { get; set; }                        //項目名
        public string inputkbn { get; set; }                      //入力区分
        public string inputtype { get; set; }                     //入力方法
        public int len { get; set; }                              //桁数
        public int? len2 { get; set; }                            //桁数（小数部）
        public string? format { get; set; }                       //フォーマット
        public string requiredflg { get; set; }                   //必須フラグ
        public bool uniqueflg { get; set; }                       //一意フラグ
        public string dispinputkbn { get; set; }                  //表示入力設定区分
        public int? fromitemseq { get; set; }                     //参照元項目ID
        public string? fromfieldid { get; set; }                  //参照元フィールド
        public string? targetfieldid { get; set; }                //取得先フィールド
        public bool? nendoflg { get; set; }                       //年度フラグ
        public string? yearchkflg { get; set; }                   //年度チェック
        public string? seiki { get; set; }                        //正規表現
        public string? minval { get; set; }                       //最小値
        public string? maxval { get; set; }                       //最大値
        public string? defaultval { get; set; }                   //初期値
        public string? fixedval { get; set; }                     //固定値
        public string? msttable { get; set; }                     //マスタチェックテーブル
        public string? mstjyoken { get; set; }                    //マスタチェック条件
        public string? mstfield { get; set; }                     //マスタチェック項目
        public string? jherrlelkbn { get; set; } = string.Empty;  //条件必須エラーレベル区分
        public int? jhitemseq { get; set; }                       //条件必須項目ID
        public string? jhenzan { get; set; }                      //条件必須演算子
        public string? jhval { get; set; }                        //条件必須値
        public string? jigyocd { get; set; }                      //事業コード
        public string? itemkbn { get; set; }                      //項目特定区分
        public string wktablecolnm { get; set; }             //ワークテーブルカラム名
        public string ColumnName { get; set; }                    //データテーブル列名(データ元画面項目)
        public string? Val { get; set; }                          //値

        /// <summary>
        /// テーブル,フィールド
        /// </summary>
        public List<string> TableFieldList { get; set; } = new List<string>();

        public bool Check(AiSessionContext session, DataRow dr, int rowNo, int dataseq, ImCheckOption option, Dictionary<string, AiTableInfo> impTtableInfoDic,
            Dictionary<string, List<string>> mstDic, Dictionary<string, List<SearchDataModel>> sansoDic, out List<ImEditErrorRow> errorList)
        {
            errorList = new List<ImEditErrorRow>();

            Val = CStr(dr[ColumnName]);
            string valueOld = "";
            string value = Val;

            //ファイル取込 && 入力区分が2（コード系）の場合
            if (inputkbn.Equals(EnumToStr(Enum入力区分.コード系))
                && option.impkbn.Equals(EnumToStr(Enum取込区分.ファイル取込))
                && !string.IsNullOrEmpty(Val))
            {
                var values = Val.Split(',');
                //変換前コード
                valueOld = values[0];
                //ファイル取込自動チェックFlg
                if (option.IsAutoCheckFlg)
                {
                    //変換後コードを取得する（ファイル取込)
                    var valueNew = GetCdChangeValue(valueOld, option.CdChangeDataList);
                    if (string.IsNullOrEmpty(valueNew))
                    {
                        errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.警告, itemnm, valueOld, EnumMessage.E004007, "コード変換処理"));
                    }
                    value = valueNew;
                }
                else
                {
                    //変換後コード
                    value = values.Length > 1 ? values[1] : "";
                }
            }

            //一括入力 && 入力区分が2（コード系）の場合
            if (inputkbn.Equals(EnumToStr(Enum入力区分.コード系))
                && option.impkbn.Equals(EnumToStr(Enum取込区分.一括入力))
                && !string.IsNullOrEmpty(Val))
            {
                value = Val.Split(':')[0].Trim();
            }

            //フォーマット
            if (option.IsAutoCheckFlg && !string.IsNullOrEmpty(format) && !string.IsNullOrEmpty(value)
                && (
                (inputkbn.Equals(EnumToStr(Enum入力区分.テキスト)) && (inputtype.Equals(EnumToStr(Enum入力方法.半角文字_半角数字)) || inputtype.Equals(EnumToStr(Enum入力方法.半角文字_半角英数字))))
                || (inputkbn.Equals(EnumToStr(Enum入力区分.画面検索)) && inputtype.Equals(EnumToStr(Enum入力方法.宛名番号)))
                )
                )
            {
                if (format.Equals(EnumToStr(Enumフォーマット_画面定義.左0埋め)))
                {
                    value = value.PadLeft(len, '0');//左0埋め
                }
                else if (format.Equals(EnumToStr(Enumフォーマット_画面定義.右0埋め)))
                {
                    value = value.PadRight(len, '0');//右0埋め
                }
            }

            //固定值
            if (option.IsAutoCheckFlg && string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(fixedval))
            {
                value = fixedval;
            }

            //ファイル取込 && 入力区分が2（コード系）の場合
            if (inputkbn.Equals(EnumToStr(Enum入力区分.コード系))
                && option.impkbn.Equals(EnumToStr(Enum取込区分.ファイル取込)))
            {
                if (string.IsNullOrEmpty(valueOld) && string.IsNullOrEmpty(value))
                {
                    Val = "";
                }
                else
                {
                    //コード変換前,コード変換後
                    Val = valueOld + "," + value;
                }
            }
            else
            {
                Val = value;
            }

            //入力区分が1（テキスト）
            if (inputkbn.Equals(EnumToStr(Enum入力区分.テキスト)) && !string.IsNullOrEmpty(value))
            {
                //入力方法_データ型チェック
                if (!CheckDataType(inputtype, value))
                {
                    var typenm = option.DataTypeDic.ContainsKey(inputtype) ? option.DataTypeDic[inputtype] : inputtype;
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.E001009, typenm));
                    return false;
                }

                //桁数チェック
                if (inputtype.Equals(EnumToStr(Enum入力方法.数値_小数点付き実数)))
                {
                    //データ型が数値（小数点付き実数）
                    var pattern = $@"^\d{{1,{len}}}(?:\.\d{{1,{len2}}})?$";
                    if (!Regex.IsMatch(value, pattern))
                    {
                        errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.E001010, len + "," + len2));
                        return false;
                    }
                }
                else if (value.Length > len)
                {
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.E001010, len));
                    return false;
                }

                //時刻の変換
                if (inputtype.Equals(EnumToStr(Enum入力方法.半角文字_時刻)) && value.IndexOf(":") > -1)
                {
                    value = value.Replace(":", "");
                    Val = value;
                }
            }

            //入力区分が4（マスタ参照）
            if (inputkbn.Equals(EnumToStr(Enum入力区分.マスタ参照)) && option.IsAutoCheckFlg)
            {
                if (fromitemseq == null || string.IsNullOrEmpty(CStr(dr["Column" + fromitemseq])))
                {
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.警告, itemnm, "", EnumMessage.E004007, "マスタ参照処理"));
                }
                else
                {
                    //参照項目値
                    var fromValue = CStr(dr["Column" + fromitemseq]);
                    fromValue = GetValue(option.impkbn, fromValue, option.CdChangeDataList);
                    //マスタ参照-取得先フィールドデータを取得する
                    var targetfield = !sansoDic.ContainsKey(ColumnName) ? null : sansoDic[ColumnName].Find(e => e.condictionvalue == fromValue);
                    if (targetfield == null)
                    {
                        errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.警告, itemnm, "", EnumMessage.E004007, "マスタ参照処理"));
                    }
                    else
                    {
                        value = targetfield.targetvalue;
                        Val = value;
                    }
                }
            }

            //項目特定区分が10(性別)
            if (!string.IsNullOrEmpty(itemkbn) && itemkbn.Equals(EnumToStr(Enum項目特定区分.性別)))
            {
                value = option.SexNameDic.ContainsKey(value) ? option.SexNameDic[value] : value;
                Val = value;
            }

            //必須(排除項目特定区分が「医療機関コード」)
            if (requiredflg != EnumToStr(Enumエラーレベル.無視) && itemkbn != EnumToStr(Enum項目特定区分.医療機関コード) && string.IsNullOrEmpty(value))
            {
                errorList.Add(new ImEditErrorRow(dataseq, rowNo, ParseEnum<Enumエラーレベル>(requiredflg), itemnm, value, EnumMessage.ITEM_REQUIRE_ERROR, itemnm));
                if (requiredflg == EnumToStr(Enumエラーレベル.エラー))
                {
                    return false;
                }
            }

            //条件必須-エラーレベル
            if (requiredflg == EnumToStr(Enumエラーレベル.無視)
                && jherrlelkbn != EnumToStr(Enumエラーレベル.無視) && string.IsNullOrEmpty(value))
            {
                //条件項目値
                var jhitemValue = CStr(dr["Column" + jhitemseq]);
                //変換後コードを取得する（ファイル取込)
                jhitemValue = GetValue(option.impkbn, jhitemValue, option.CdChangeDataList);
                //条件必須チェック
                var isCondition = OnCondition(jhitemValue);
                if (isCondition)
                {
                    //条件必須エラー
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, ParseEnum<Enumエラーレベル>(jherrlelkbn), itemnm, value, EnumMessage.ITEM_REQUIRE_ERROR, itemnm));
                    //条件必須-エラーレベル=エラーの場合
                    if (jherrlelkbn == EnumToStr(Enumエラーレベル.エラー))
                    {
                        return false;
                    }
                }
            }

            //項目値と正規表現の一致チェック
            if (!string.IsNullOrEmpty(seiki) && !Regex.IsMatch(value, $@"{seiki}"))
            {
                errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.ITEM_ILLEGAL_ERROR, itemnm));
                return false;
            }

            //最大値最小値チェック
            if (!string.IsNullOrEmpty(value) && !CheckMaxMin(value))
            {
                errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.E001009, $"{minval}～{maxval}の範囲"));
                return false;
            }

            //マスタ存在
            if (!string.IsNullOrEmpty(msttable))
            {
                //マスタ存在チェック
                if (!mstDic.ContainsKey(ColumnName) || !mstDic[ColumnName].Contains(value))
                {
                    //選択されたマスタテーブル名称
                    var tableName = option.TableNameDic.ContainsKey(msttable) ? option.TableNameDic[msttable] : msttable;
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.E004006, $"{itemnm}({value})", tableName));
                    return false;
                }
            }

            //年度チェック
            if (inputkbn == EnumToStr(Enum入力区分.テキスト) &&
                    (inputtype == EnumToStr(Enum入力方法.半角文字_年)
                        || inputtype == EnumToStr(Enum入力方法.半角文字_年_不詳あり)
                        || inputtype == EnumToStr(Enum入力方法.半角文字_年月)
                        || inputtype == EnumToStr(Enum入力方法.半角文字_時刻)
                        || inputtype == EnumToStr(Enum入力方法.日付_年月日)
                        || inputtype == EnumToStr(Enum入力方法.日付_年月日_不詳あり)
                        || inputtype == EnumToStr(Enum入力方法.日時_年月日時分秒)
                    ) && yearchkflg != EnumToStr(Enumエラーレベル.無視) && !string.IsNullOrEmpty(yearchkflg) && !string.IsNullOrEmpty(option.nendo) && !string.IsNullOrEmpty(value))
            {
                if (!CheckNenDo(value, option.nendo))
                {
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, ParseEnum<Enumエラーレベル>(yearchkflg), itemnm, value, EnumMessage.ITEM_NOTEQUAL_ERROR, option.nendo));
                    if (yearchkflg == EnumToStr(Enumエラーレベル.エラー))
                    {
                        return false;
                    }
                }
            }

            //実際桁数とDB桁数比較チェック
            if (!string.IsNullOrEmpty(value))
            {
                //実際桁数とDB桁数比較チェック
                var size = CheckDBLen(value, impTtableInfoDic);
                if (size != null)
                {
                    errorList.Add(new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, itemnm, value, EnumMessage.E001010, size));
                    return false;
                }
            }

            if (errorList.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 最大値最小値チェック
        /// </summary>
        private bool CheckMaxMin(string value)
        {
            //入力区分が1（テキスト）
            if (inputkbn.Equals(EnumToStr(Enum入力区分.テキスト)) &&
                (inputtype.Equals(EnumToStr(Enum入力方法.数値_整数))
                || inputtype.Equals(EnumToStr(Enum入力方法.数値_小数点付き実数))
                || inputtype.Equals(EnumToStr(Enum入力方法.数値_符号付き整数))))
            {
                if (!decimal.TryParse(value, out decimal decValue))
                {
                    return false;
                }

                //値<最小値、エラーとなる
                if (!string.IsNullOrEmpty(minval) &&
                    (!decimal.TryParse(minval, out decimal decMinValue) || decValue < decMinValue))
                {
                    return false;
                }

                //値>最大値、エラーとなる
                if (!string.IsNullOrEmpty(maxval) &&
                    (!decimal.TryParse(maxval, out decimal decMaxValue) || decValue > decMaxValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 文字列が数値であるかどうかを確認
        /// </summary>
        public bool IsNumber(string? value)
        {
            double number;
            return double.TryParse(value, out number);
        }

        /// <summary>
        /// 文字列が日付であるかどうかを確認
        /// </summary>
        public bool IsDate(string? value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }

        /// <summary>
        /// 処理後の値を取得する
        /// </summary>
        private string GetValue(string impkbn, string value, List<ImCdChangeDef> cdChangeDataList)
        {
            if (inputkbn.Equals(EnumToStr(Enum入力区分.コード系))
                && impkbn.Equals(EnumToStr(Enum取込区分.ファイル取込))
                && !string.IsNullOrEmpty(value))
            {
                var values = value.Split(',');
                //変換後コードを取得する（ファイル取込)
                value = values[1];
            }
            return value;
        }

        /// <summary>
        /// 変換後コードを取得する（ファイル取込)
        /// </summary>
        private string GetCdChangeValue(string valueOld, List<ImCdChangeDef> cdChangeDataList)
        {
            string value = string.Empty;
            //変換後コードを取得する
            var cdChange = cdChangeDataList.Find(e => e.cdchangekbn.ToString() == inputtype && e.oldcode.Equals(valueOld));
            if (cdChange != null)
            {
                //変換後コード
                value = cdChange.newcode;
            }
            return value;
        }

        /// <summary>
        /// マスタ参照-取得先フィールドを取得する
        /// </summary>
        private string GetTargetValue(object fromValue, AiSessionContext session)
        {
            var paraNames = new List<string>();
            var paraValues = new List<object>();
            string sql = $"SELECT {targetfieldid} FROM {inputtype} WHERE {fromfieldid}=@{fromfieldid}";
            paraNames.Add(fromfieldid!);
            paraValues.Add(fromValue);
            ImDBUtil.SetParam(session, inputtype, paraNames, ref paraValues);
            DataTable dt = AiDbUtil.GetDataTable(session, sql, paraNames.ToArray(), paraValues.ToArray());
            if (dt != null && dt.Rows.Count > 0)
            {
                return CStr(dt.Rows[0][0]);
            }
            return string.Empty;
        }

        /// <summary>
        /// 条件チェック
        /// </summary>
        private bool OnCondition(string? value)
        {
            try
            {
                //is null
                if (jhenzan == EnumToStr(Enum演算子.is_null))
                {
                    return string.IsNullOrEmpty(value);
                }
                //is not null
                if (jhenzan == EnumToStr(Enum演算子.is_not_null))
                {
                    return !string.IsNullOrEmpty(value);
                }

                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
                if (string.IsNullOrEmpty(jhval)) throw new ArgumentNullException(nameof(jhval));
                if (string.IsNullOrEmpty(jhenzan)) throw new ArgumentNullException(nameof(jhenzan));

                switch (ParseEnum<Enum演算子>(jhenzan))
                {
                    case Enum演算子.等しい://=
                        {
                            if (IsNumber(value))
                            {
                                return CDec(value) == CDec(jhval);
                            }
                            else if (IsDate(value))
                            {
                                return CDate(value) == CDate(jhval);
                            }
                            else
                            {
                                return value == jhval;
                            }
                        }
                    case Enum演算子.等しくない://<>
                        {
                            if (IsNumber(value))
                            {
                                return CDec(value) != CDec(jhval);
                            }
                            else if (IsDate(value))
                            {
                                return CDate(value) != CDate(jhval);
                            }
                            else
                            {
                                return value != jhval;
                            }
                        }
                    case Enum演算子.より大さい://>
                        {
                            if (IsNumber(value))
                            {
                                return CDec(value) > CDec(jhval);
                            }
                            else if (IsDate(value))
                            {
                                return CDate(value) > CDate(jhval);
                            }
                            else
                            {
                                throw new ArgumentNullException(nameof(value));
                            }
                        }
                    case Enum演算子.より小さい://<
                        if (IsNumber(value))
                        {
                            return CDec(value) < CDec(jhval);
                        }
                        else if (IsDate(value))
                        {
                            return CDate(value) < CDate(jhval);
                        }
                        else
                        {
                            throw new ArgumentNullException(nameof(value));
                        }
                    case Enum演算子.以上://>=
                        if (IsNumber(value))
                        {
                            return CDec(value) >= CDec(jhval);
                        }
                        else if (IsDate(value))
                        {
                            return CDate(value) >= CDate(jhval);
                        }
                        else
                        {
                            throw new ArgumentNullException(nameof(value));
                        }
                    case Enum演算子.以下://<=
                        if (IsNumber(value))
                        {
                            return CDec(value) <= CDec(jhval);
                        }
                        else if (IsDate(value))
                        {
                            return CDate(value) <= CDate(jhval);
                        }
                        else
                        {
                            throw new ArgumentNullException(nameof(value));
                        }
                    case Enum演算子.like://like

                        return value.Contains(jhval);
                    case Enum演算子.not_like://not like

                        return !value.Contains(jhval);

                    case Enum演算子.between://between
                        string[] values = jhval.Split(",");
                        if (IsNumber(value))
                        {
                            return CDec(values[0]) <= CDec(value) && CDec(values[1]) >= CDec(value);
                        }
                        else if (IsDate(value))
                        {
                            return CDate(values[0]) <= CDate(value) && CDate(values[1]) >= CDate(value);
                        }
                        else
                        {
                            throw new ArgumentNullException(nameof(value));
                        }
                    case Enum演算子.not_between://not between

                        string[] values2 = jhval.Split(",");
                        if (IsNumber(value))
                        {
                            return CDec(values2[0]) >= CDec(value) || CDec(values2[1]) <= CDec(value);
                        }
                        else if (IsDate(value))
                        {
                            return CDate(values2[0]) >= CDate(value) || CDate(values2[1]) <= CDate(value);
                        }
                        else
                        {
                            throw new ArgumentNullException(nameof(value));
                        }

                    default:
                        return true;
                }
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        /// <summary>
        /// 実際桁数とDB桁数比較チェック
        /// </summary>
        private int? CheckDBLen(string value, Dictionary<string, AiTableInfo> impTableInfoDic)
        {
            foreach (var tableField in TableFieldList)
            {
                string tableid = tableField.Split(',')[0];
                string fieldid = tableField.Split(',')[1];
                if (impTableInfoDic.ContainsKey(tableid))
                {
                    AiTableInfo tableInfo = impTableInfoDic[tableid];
                    AiFieldInfo? field = tableInfo.FieldList.Find(e => e.FieldName.Equals(fieldid));
                    if (field != null && field.Size != 0 && field.Size < value.Length)
                    {
                        //DB桁数超える場合
                        return field.Size;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 年度チェック
        /// </summary>
        private bool CheckNenDo(string value, string nendo)
        {
            //nendo=2020;
            string nendoNext = (CInt(nendo) + 1).ToString();

            bool isValidFormat;
            switch (ParseEnum<Enum入力方法>(inputtype))
            {
                case Enum入力方法.日付_年月日:
                    //日付（年月日）
                    if (CheckDateFormat(value, DaConst.DateFormat) == false)
                    {
                        return false;
                    }
                    //日付範囲チェック
                    return CheckDay(value, DaConst.DateFormat, nendo);
                case Enum入力方法.日付_年月日_不詳あり:
                    //日付（年月日）※不詳あり
                    string[] values = value.Split('-');
                    if (values.Length > 2)
                    {
                        var year = values[0];
                        var month = values[1];
                        //年月不詳または202004～202103の範囲外がエラー)
                        if (!Regex.IsMatch((year + month), $@"^({nendo})(A2|A3|A4|0[4-9]|1[0-2])$")
                            && !Regex.IsMatch((year + month), $@"^({nendoNext})(A1|0[1-3])$"))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                case Enum入力方法.半角文字_年月:
                    //半角文字（年月）
                    if (CheckDateFormat(value, "yyyyMM") == false)
                    {
                        return false;
                    }
                    else
                    {
                        var year = value.Substring(0, 4);
                        var month = value.Substring(4, 2);
                        //日付範囲チェック
                        return CheckDay($"{year}-{month}-01", DaConst.DateFormat, nendo);
                    }
                case Enum入力方法.半角文字_年月_不詳あり:
                    //半角文字（年月yyyyMM）※不詳あり
                    //年月不詳
                    if (!Regex.IsMatch(value, $@"^{nendo}(A2|A3|A4|0[4-9]|1[0-2])$")
                        && !Regex.IsMatch(value, $@"^{nendoNext}(A1|0[1-3])$"))
                    {
                        return false;
                    }
                    return true;

                case Enum入力方法.半角文字_年:
                    //半角文字（年）
                    isValidFormat = CheckDateFormat(value, "yyyy");
                    if (!isValidFormat)
                    {
                        return false;
                    }

                    //年度項目の場合、2020以外がエラー
                    if (CBool(nendoflg))
                    {
                        return value.Equals(nendo);
                    }
                    else
                    {
                        //年項目の場合、2020、2021以外がエラー
                        return value.Equals(nendo) || value.Equals(nendoNext);
                    }
                case Enum入力方法.半角文字_年_不詳あり:
                    //半角文字（年）※不詳あり
                    //年度項目の場合、2020以外がエラー
                    if (CBool(nendoflg))
                    {
                        return value.Equals(nendo);
                    }
                    else
                    {
                        //年項目の場合、2020、2021以外がエラー
                        return value.Equals(nendo) || value.Equals(nendoNext);
                    }
                case Enum入力方法.日時_年月日時分秒:
                    var isValid = DateTime.TryParseExact(value, DaConst.JapanTimeFormat3, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                    if (!isValid)
                    {
                        return false;
                    }
                    var date = parsedDate.Date.ToString(DaConst.DateFormat);
                    //日付範囲チェック
                    return CheckDay(date, DaConst.DateFormat, nendo);
                default:
                    return true;
            }
        }

        /// <summary>
        /// 日付範囲チェック
        /// </summary>
        private bool CheckDay(string value, string format, string nendo)
        {
            //例　2020-04-01～20210331の範囲外がエラー
            var nendoNext = (CInt(nendo) + 1).ToString();
            var sDate = nendo + "-04-01";
            var eDate = nendoNext + "-03-31";

            DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out DateTime date);
            DateTime.TryParseExact(sDate, format, null, DateTimeStyles.None, out DateTime startDate);
            DateTime.TryParseExact(eDate, format, null, DateTimeStyles.None, out DateTime endDate);
            return date >= startDate && date <= endDate;
        }

        /// <summary>
        /// 日付フォーマットチェック
        /// </summary>
        private bool CheckDateFormat(string value, string format)
        {
            var isValid = DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
            return isValid;
        }

        /// <summary>
        /// データ型チェック
        /// </summary>
        public bool CheckDataType(string inputtype, string value)
        {
            switch (ParseEnum<Enum入力方法>(inputtype))
            {
                case Enum入力方法.半角文字_年:
                    //半角文字（年）yyyy
                    return Regex.IsMatch(value, ImFormatUtil.DatePattern6);
                case Enum入力方法.半角文字_年_不詳あり:
                    //半角文字（年）※不詳ありyyyy|0000
                    return Regex.IsMatch(value, ImFormatUtil.FusyoDatePattern6);
                case Enum入力方法.半角文字_年月:
                    //半角文字（年月）yyyyMM
                    return Regex.IsMatch(value, ImFormatUtil.DatePattern17);
                case Enum入力方法.半角文字_年月_不詳あり:
                    //半角文字（年月）※不詳ありyyyyMM
                    return Regex.IsMatch(value, ImFormatUtil.FusyoDatePattern17);
                case Enum入力方法.日付_年月日:
                    //日付（年月日）yyyy-MM-dd
                    return CheckDateFormat(value, DaConst.DateFormat);
                case Enum入力方法.日付_年月日_不詳あり:
                    //日付（年月日）※不詳ありyyyy-MM-dd
                    return Regex.IsMatch(value, ImFormatUtil.FusyoDateFormat);
                case Enum入力方法.日時_年月日時分秒:
                    //日時（年月日時分秒）yyyy/MM/dd HH:mm:ss
                    return CheckDateFormat(value, DaConst.JapanTimeFormat3);
                default:
                    //データ型チェック
                    return ImDataTypeUtil.CheckDataType(inputtype, value);
            }
        }

    }
}
