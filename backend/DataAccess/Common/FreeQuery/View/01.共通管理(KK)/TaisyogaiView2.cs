// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             帳票発行対象外者ビュー
// 作成日　　: 2023.12.21
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 帳票発行対象外者テーブル
    /// </summary>
    public class TaisyogaiView2 : IFrView
    {
        public const string TABLE_NAME = "vw_kktaisyogaisya2";

        //ビュー項目
        public const string atenano = nameof(tt_kkrpthakkotaisyogaisyaDto.atenano); //宛名番号
        public const string taisyogaikbn = "taisyogaikbn";                          //対象外者区分

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public TaisyogaiView2()
        {
            _SQL = @$"
                    select
                      distinct t.atenano,           --宛名番号
                      true as taisyogaikbn          --対象外者区分
                    from {tt_kkrpthakkotaisyogaisyaDto.TABLE_NAME} t
                    ".Trim();
        }
    }
}