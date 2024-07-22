// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診予定希望者管理(日程予約分類)ビュー
// 作成日　　: 2024.02.21
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 健（検）診予約希望者詳細テーブル
    /// </summary>
    public class KensinyoyakuView5 : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinkibosyasyosai2";

        //ビュー項目
        public const string atenano = nameof(tt_shkensinkibosyasyosaiDto.atenano);      //宛名番号
        public const string taikiflg = nameof(tt_shkensinkibosyasyosaiDto.cancelmatiflg);    //待機フラグ

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinyoyakuView5(int nendo, int nitteino, string jigyocd, string yoyakubunruicd, string? kensahohocds)
        {
            _SQL = @$"
                    select
                        t1.atenano,         --宛名番号
                        t1.cancelmatiflg    --キャンセル待ち
                    from {tt_shkensinkibosyasyosaiDto.TABLE_NAME} t1
                    where 
                        t1.nendo = {nendo} and 
                        t1.nitteino = {nitteino} and 
                        t1.jigyocd = '{jigyocd}' and 
                        t1.kensahohocd = any(string_to_array('{kensahohocds}', ','))
                    ".Trim();
        }
    }
}