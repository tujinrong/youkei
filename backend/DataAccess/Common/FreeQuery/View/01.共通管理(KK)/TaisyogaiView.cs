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
    public class TaisyogaiView : IFrView
    {
        public const string TABLE_NAME = "vw_kktaisyogaisya";

        //ビュー項目
        public const string atenano = nameof(tt_kkrpthakkotaisyogaisyaDto.atenano);                 //宛名番号
        public const string rptgroupid = nameof(tt_kkrpthakkotaisyogaisyaDto.rptgroupid);           //帳票グループID
        public const string uketukeymd = nameof(tt_kkrpthakkotaisyogaisyaDto.uketukeymd);           //受付日
        public const string taisyogairiyu = nameof(tt_kkrpthakkotaisyogaisyaDto.taisyogairiyu);     //対象外理由
        //汎用マスタの汎用区分1
        public const string gyomukbn = "gyomukbn";                                                  //業務区分

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public TaisyogaiView()
        {
            _SQL = @$"
                    select
                      t.atenano,            --宛名番号
                      t.rptgroupid,         --帳票グループID
                      t.uketukeymd,         --受付日
                      t.taisyogairiyu,      --対象外理由
                      m.hanyokbn1 gyomukbn  --業務区分
                    from {tt_kkrpthakkotaisyogaisyaDto.TABLE_NAME} t
                    left join {tm_afhanyoDto.TABLE_NAME} m
                        on t.rptgroupid = m.hanyocd 
                        and m.hanyomaincd = '1006' 
                        and m.hanyosubcd = 2 
                    ".Trim();
        }
    }
}