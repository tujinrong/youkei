// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診履歴管理ビュー
// 作成日　　: 2024.02.05
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 検診履歴管理テーブル
    /// </summary>
    public class TaisyosginView : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinrirekikanri";

        //ビュー項目
        public const string atenano = nameof(tt_shkensinrirekikanriDto.atenano); //宛名番号

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public TaisyosginView(int nendo)
        {
            _SQL = @$"
                    select
                      distinct t.atenano    --宛名番号
                    from {tt_shkensinrirekikanriDto.TABLE_NAME}_{nendo} t
                    ".Trim();
        }
    }
}