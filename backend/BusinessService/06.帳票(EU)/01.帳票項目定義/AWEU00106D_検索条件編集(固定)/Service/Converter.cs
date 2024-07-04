// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(固定)
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using System.Globalization;
using System.Text.RegularExpressions;

namespace BCC.Affect.Service.AWEU00106D
{
    public class Converter : CmConerterBase
    {
        /**
         * DataType to コントロール
         */
        private static readonly Dictionary<EnumDataType, Enumコントロール> DATATYPE_TO_CONTROL_DIC = new()
        {
            { EnumDataType.整数, Enumコントロール.数値入力 },
            { EnumDataType.小数, Enumコントロール.数値入力 },
            { EnumDataType.文字列, Enumコントロール.文字入力 },
            { EnumDataType.日付, Enumコントロール.日付入力 },
            { EnumDataType.時間, Enumコントロール.時間入力 },
            { EnumDataType.フラグ, Enumコントロール.論理値 }
        };

        /// <summary>
        /// 新規処理
        /// </summary>
        public static tm_eudatasourcekensakuDto GetAddDto(SaveRequest req, tm_eutableitemDto tableItemDto, int nextJyokenid)
        {
            var dto = new tm_eudatasourcekensakuDto();
            dto.jyokenkbn = req.jyokenkbn;                                                               //検索条件区分
            dto.datasourceid = req.datasourceid;                                                         //データソースID
            dto.jyokenid = nextJyokenid;                                                                 //条件ID
            dto.sqlcolumn = tableItemDto.sqlcolumn;                                                      //項目ID
            dto.jyokenkbn = req.jyokenkbn;                                                               //検索条件区分
            dto.jyokenlabel = req.jyokenlabel;                                                           //ラベル
            dto.controlkbn = GetControlkbn(tableItemDto.datatype);                                       //コントロール区分
            dto.variables = GetVariables(tableItemDto, dto.controlkbn, req.sql);                                                                    //変数名
            dto.sql = string.IsNullOrEmpty(req.sql) ? GetConditionSql(tableItemDto, req.syokiti) : req.sql;//SQL
            dto.tablealias = tableItemDto.tablealias;                                                    //テーブル名
            dto.mastercd = null;                                                                         //名称マスタコード
            dto.masterpara = null;                                                                       //名称マスタパラメータ
            dto.datatype = tableItemDto.datatype;                                                        //データ型
            dto.syokiti = req.syokiti;                                                                   //初期値
            return dto;
        }

        /// <summary>
        /// 変数名取得
        /// </summary>
        private static string GetVariables(tm_eutableitemDto tableItemDto, Enumコントロール controlkbn, string? sql)
        {
            return controlkbn is Enumコントロール.数値範囲 or Enumコントロール.文字範囲 or Enumコントロール.日付範囲 or Enumコントロール.時間範囲
                    ? $"{tableItemDto.itemid}_f{DaStrPool.C_COMMA}{tableItemDto.itemid}_t"
                    : tableItemDto.itemid;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public static tm_eudatasourcekensakuDto GetUpdateDto(SaveRequest req, tm_eutableitemDto tableItemDto)
        {
            var dto = new tm_eudatasourcekensakuDto();
            dto.jyokenkbn = req.jyokenkbn;                                                              //検索条件区分
            dto.datasourceid = req.datasourceid;                                                        //データソースID
            dto.jyokenid = req.jyokenid;                                                                //条件ID
            dto.sqlcolumn = tableItemDto.sqlcolumn;                                                     //SQLカラム
            dto.jyokenkbn = req.jyokenkbn;                                                              //検索条件区分
            dto.jyokenlabel = req.jyokenlabel;                                                          //ラベル
            dto.controlkbn = GetControlkbn(tableItemDto.datatype);                                      //コントロール区分
            dto.variables = GetVariables(tableItemDto, dto.controlkbn, req.sql);
            dto.sql = string.IsNullOrEmpty(req.sql) ? GetConditionSql(tableItemDto, req.syokiti) : req.sql; //SQL
            dto.tablealias = tableItemDto.tablealias;                                                   //テーブル名
            dto.mastercd = null;                                                                        //名称マスタコード
            dto.masterpara = null;                                                                      //名称マスタパラメータ
            dto.datatype = tableItemDto.datatype;                                                       //データ型
            dto.syokiti = req.syokiti;                                                                  //初期値
            return dto;
        }

        /// <summary>
        /// コントロール
        /// </summary>
        private static Enumコントロール GetControlkbn(EnumDataType dataType)
        {
            return DATATYPE_TO_CONTROL_DIC.GetValueOrDefault(dataType, Enumコントロール.文字入力);
        }

        /// <summary>
        /// 条件SQL取得
        /// </summary>
        public static string GetConditionSql(tm_eutableitemDto tableItemDto, string value)
        {
            return $"{tableItemDto.sqlcolumn} {DaStrPool.C_EQ} {GetFormattedValue(tableItemDto.datatype, value)}";
        }

        /// <summary>
        /// フォーマット値の取得
        /// </summary>
        private static string GetFormattedValue(EnumDataType dataType, string value)
        {
            return dataType switch
            {
                EnumDataType.整数 => int.TryParse(value, out var num) ? num.ToString() : 0.ToString(),
                EnumDataType.小数 => decimal.TryParse(value, out var num) ? num.ToString(CultureInfo.InvariantCulture) : 0.ToString(),
                EnumDataType.文字列 => $"'{value}'",
                EnumDataType.日付 => DateTime.TryParse(value, out var date) ? $"'{date:yyyy-MM-dd}'" : $"'{DaUtil.Today:yyyy-MM-dd}'",
                EnumDataType.時間 => DateTime.TryParse(value, out var time) ? $"'{time:yyyy-MM-dd HH:mm:ss}'" : $"'{DaUtil.Now:yyyy-MM-dd HH:mm:ss}'",
                EnumDataType.フラグ => bool.TryParse(value, out var flag) ? flag.ToString().ToLower() : false.ToString().ToLower(),
                _ => $"'{value}'"
            };
        }
    }
}