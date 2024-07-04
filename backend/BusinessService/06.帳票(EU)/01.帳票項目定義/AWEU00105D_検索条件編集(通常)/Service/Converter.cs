// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(通常)
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using System.Text.RegularExpressions;
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00105D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 新規処理
        /// </summary>
        public static tm_eudatasourcekensakuDto GetAddDto(SaveRequest req, tm_eutableitemDto tableItemDto, int nextJyokenid)
        {
            var dto = new tm_eudatasourcekensakuDto();
            dto.datasourceid = req.datasourceid;                                                              //データソースID
            dto.jyokenid = nextJyokenid;                                                                      //条件ID
            dto.sqlcolumn = tableItemDto.sqlcolumn;                                                           //SQLカラム
            dto.jyokenkbn = Enum検索条件区分.通常条件;                                                          //検索条件区分
            dto.jyokenlabel = req.jyokenlabel;                                                                //ラベル
            dto.variables = GetVariables(tableItemDto, req.controlkbn, req.sql);                              //変数名
            dto.sql = string.IsNullOrEmpty(req.sql) ? GetConditionSql(tableItemDto, req.controlkbn) : req.sql; //SQL
            dto.controlkbn = req.controlkbn;                                                                  //コントロール区分
            dto.tablealias = tableItemDto.tablealias;                                                         //テーブル名
            dto.mastercd = GetRealMasterCd(req.controlkbn, req.mastercd);                                     //名称マスタコード
            dto.masterpara = GetRealMasterPara(req.controlkbn, req.masterpara);                               //名称マスタパラメータ
            dto.sansyomotosql = req.sansyomotosql;                                                            //参照元SQL
            dto.datatype = tableItemDto.datatype;                                                             //データ型
            dto.nendohanikbn = req.nendohanikbn;                                                              //年度範囲区分
            dto.syokiti = CStr(req.syokiti);                                                                  //初期値
            if (req.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(req.aimaikbn))
            {
            dto.aimaikbn = CStr(req.aimaikbn);                                                                //曖昧検索区分
            }
            return dto;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public static tm_eudatasourcekensakuDto GetUpdateDto(SaveRequest req, tm_eutableitemDto tableItemDto)
        {
            var dto = new tm_eudatasourcekensakuDto();
            dto.datasourceid = req.datasourceid;                                                              //データソースID
            dto.jyokenid = req.jyokenid;                                                                      //条件ID
            dto.sqlcolumn = tableItemDto.sqlcolumn;                                                           //SQLカラム
            dto.jyokenkbn = Enum検索条件区分.通常条件;                                                            //検索条件区分
            dto.jyokenlabel = req.jyokenlabel;                                                                //ラベル
            dto.variables = GetVariables(tableItemDto, req.controlkbn, req.sql);                              //変数名
            dto.sql = string.IsNullOrEmpty(req.sql) ? GetConditionSql(tableItemDto, req.controlkbn) : req.sql; //SQL
            dto.controlkbn = req.controlkbn;                                                                  //コントロール区分
            dto.tablealias = tableItemDto.tablealias;                                                         //テーブル名
            dto.mastercd = GetRealMasterCd(req.controlkbn, req.mastercd);                                     //名称マスタコード
            dto.masterpara = GetRealMasterPara(req.controlkbn, req.masterpara);                               //名称マスタパラメータ
            dto.sansyomotosql = req.sansyomotosql;                                                            //参照元SQL
            dto.datatype = tableItemDto.datatype;                                                             //データ型
            dto.nendohanikbn = req.nendohanikbn;                                                              //年度範囲区分
            dto.syokiti = CStr(req.syokiti);                                                                  //初期値
            if (req.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(req.aimaikbn))
            {
                dto.aimaikbn = CStr(req.aimaikbn);                                                            //曖昧検索区分
            }
            return dto;
        }

        /// <summary>
        /// 変数名取得
        /// </summary>
        private static string GetVariables(tm_eutableitemDto tableItemDto, Enumコントロール controlkbn, string? sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                return controlkbn is Enumコントロール.数値範囲 or Enumコントロール.文字範囲 or Enumコントロール.日付範囲 or Enumコントロール.時間範囲
                    ? $"{tableItemDto.itemid}_f{DaStrPool.C_COMMA}{tableItemDto.itemid}_t"
                    : tableItemDto.itemid;
            }

            return string.Join(DaStrPool.C_COMMA, Regex.Matches(sql, @"\@\w+(?:\.\w+)*").Select(x => x.Value[1..]));
        }

        /// <summary>
        /// 条件SQL取得
        /// </summary>
        public static string GetConditionSql(tm_eutableitemDto tableItemDto, Enumコントロール controlkbn)
        {
            return controlkbn is Enumコントロール.数値範囲 or Enumコントロール.文字範囲 or Enumコントロール.日付範囲 or Enumコントロール.時間範囲
                ? $"{tableItemDto.sqlcolumn}>=@{tableItemDto.itemid}_f;{tableItemDto.sqlcolumn}<=@{tableItemDto.itemid}_t"
                : $"{tableItemDto.sqlcolumn} {GetSymbol(controlkbn)} {GetVariableStr(controlkbn, tableItemDto)}";
        }

        /// <summary>
        /// シンボルを取得
        /// </summary>
        private static string GetSymbol(Enumコントロール controlkbn)
        {
            return EucConstant.CONTROL_SYMBOL_DIC.GetValueOrDefault(controlkbn, DaStrPool.EQ);
        }

        /// <summary>
        /// 変数文字の取得
        /// </summary>
        private static string GetVariableStr(Enumコントロール controlkbn, tm_eutableitemDto tableItemDto)
        {
            return controlkbn switch
            {
                Enumコントロール.複数選択 => $"ANY(@{tableItemDto.itemid})",
                _ => $"@{tableItemDto.itemid}"
            };
        }

        /// <summary>
        /// 名称マスタコード
        /// </summary>
        public static string? GetRealMasterCd(Enumコントロール controlkbn, string? mastercd)
        {
            return controlkbn is Enumコントロール.選択 or Enumコントロール.複数選択 or Enumコントロール.年度 && !string.IsNullOrEmpty(mastercd) ? mastercd : null;
        }

        /// <summary>
        /// 名称マスタパラメータ
        /// </summary>
        public static string? GetRealMasterPara(Enumコントロール controlkbn, string? masterpara)
        {
            return controlkbn is Enumコントロール.選択 or Enumコントロール.複数選択 or Enumコントロール.年度 && !string.IsNullOrEmpty(masterpara) ? masterpara : null;
        }

        /// <summary>
        /// 種類の判断します
        /// </summary>
        public static bool IsParameterValid(Enumコントロール? dataType, string parameterValue)
        {
            switch (dataType)
            {
                case Enumコントロール.数値入力 or Enumコントロール.数値範囲:
                    return int.TryParse(parameterValue, out _);
                case Enumコントロール.論理値:
                    return bool.TryParse(parameterValue, out _);
                case Enumコントロール.時間範囲 :
                    return DateTime.TryParse(parameterValue, out _);
                default:
                    return true;
            }
        }
    }
}