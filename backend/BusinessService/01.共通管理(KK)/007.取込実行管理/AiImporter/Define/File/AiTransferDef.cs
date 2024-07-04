// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　マッピング処理
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter.Define.File
{
    public class AITransferDef
    {
        /// <summary>
        /// 画面項目ID
        /// </summary>
        public int pageitemseq { get; set; }

        /// <summary>
        /// 項目名
        /// </summary>
        public string itemnm { get; set; } 

        /// <summary>
        /// ファイル項目ID
        /// </summary>
        public string? fileitemseq { get; set; }

        /// <summary>
        /// マッピング区分
        /// </summary>
        public string mappingkbn { get; set; }

        /// <summary>
        /// マッピング方法
        /// </summary>
        public string? mappingmethod { get; set; }

        /// <summary>
        /// 指定桁数（開始）
        /// </summary>
        public int substrfrom { get; set; }

        /// <summary>
        /// 指定桁数（終了）
        /// </summary>
        public int substrto { get; set; }

        /// <summary>
        /// ColumnからDataTableを取得
        /// </summary>
        public static DataTable GetDataTable(List<AITransferDef> list)
        {
            var dt = new DataTable();
            dt.Columns.Add("RowNo");
            foreach (var item in list)
            {
                dt.Columns.Add("Column" + item.pageitemseq);
            }

            return dt;
        }

        /// <summary>
        /// マッピング処理
        /// </summary>
        public string Translate(DaDbContext db, DataRow row, int rowIndex, int dataseq, Dictionary<int, List<object?>> itemsResultDic, out ImEditErrorRow? error)
        {
            error = null;
            switch (ParseEnum<Enumマッピング区分>(mappingkbn))
            {
                case Enumマッピング区分.マッピングなし:
                    return "";

                case Enumマッピング区分.関数://関数
                    if (itemsResultDic.ContainsKey(pageitemseq) && itemsResultDic[pageitemseq].Count > rowIndex)
                    {
                        var itemValue = CStr(itemsResultDic[pageitemseq][rowIndex]);
                        if (!string.IsNullOrEmpty(itemValue))
                        {
                            return itemValue;
                        }
                    }
                    //関数名
                    var procName = DaNameService.GetKanaName(db, EnumNmKbn.マッピング方法, mappingmethod!);
                    error = new ImEditErrorRow(dataseq, rowIndex + 1, Enumエラーレベル.警告, itemnm, "", EnumMessage.E004007, procName);
                    return "";
                case Enumマッピング区分.単一項目移送://単一項目移送
                    string value = CStr(row[fileitemseq!]);

                    //桁数指定の場合
                    if (mappingmethod == EnumToStr(Enumマッピング方法.桁数指定) && value.Length > 0)
                    {
                        var startIndex = substrfrom - 1;
                        //開始インデックスが文字列の長さを超えないように調整
                        startIndex = Math.Min(startIndex, value.Length);
                        var len = substrto - substrfrom + 1;
                        // 切り取る長さが文字列の末尾を超えないように調整
                        len = Math.Min(len, value.Length - startIndex);
                        return value.Substring(startIndex, len);
                    }
                    return value;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
