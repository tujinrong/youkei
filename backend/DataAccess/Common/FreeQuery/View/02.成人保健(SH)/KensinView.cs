// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             検診ビュー
// 作成日　　: 2023.07.07
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    public class KensinView : IFrView
    {
        public const string TABLE_NAME = "vw_shkensin";
        //ビュー項目
        public const string atenano = nameof(tt_shkensinDto.atenano);                   //宛名番号
        public const string jigyocd = nameof(tt_shkensinDto.jigyocd);                   //事業コード
        public const string nendo = nameof(tt_shkensinDto.nendo);                       //実施年度
        public const string kensinkaisu = nameof(tt_shkensinDto.kensinkaisu);           //検診回数

        //一次項目
        public const string kensinkaisu1 = $"{nameof(tt_shkensinDto.kensinkaisu)}1";    //検診回数
        public const string nendo1 = $"{nameof(tt_shkensinDto.nendo)}1";                //実施年度
        public const string jissiymd1 = $"{nameof(tt_shkensinDto.jissiymd)}1";          //実施日
        public const string kensahoho1 = $"{nameof(tt_shkensinDto.kensahohocd)}1";      //検査方法
        public const string regsisyo1 = $"{nameof(tt_shkensinDto.regsisyo)}1";          //登録支所
        public const string upddttm1 = $"{nameof(tt_shkensinDto.upddttm)}1";            //更新日時

        //精密項目
        public const string kensinkaisu2 = $"{nameof(tt_shseikenDto.kensinkaisu)}2";    //検診回数
        public const string nendo2 = $"{nameof(tt_shseikenDto.nendo)}2";                //実施年度
        public const string jissiymd2 = $"{nameof(tt_shseikenDto.jissiymd)}2";          //実施日
        public const string regsisyo2 = $"{nameof(tt_shseikenDto.regsisyo)}2";          //登録支所
        public const string upddttm2 = $"{nameof(tt_shseikenDto.upddttm)}2";            //更新日時

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinView(FrCondition condition, string jigyocd)
        {
            _SQL = @$"
                    select
                        --ビュー項目
                        coalesce(t1.atenano,t2.atenano) atenano,                --宛名番号
                        t1.jigyocd jigyocd,                                     --事業コード
                        coalesce(t1.nendo,t2.nendo) nendo,                      --実施年度
                        coalesce(t1.kensinkaisu,t2.kensinkaisu) kensinkaisu,    --検診回数
                        --一次項目
                        t1.kensinkaisu kensinkaisu1,                            --検診回数
                        t1.nendo nendo1,                                        --実施年度
                        t1.jissiymd jissiymd1,                                  --実施日
                        t1.kensahohocd kensahohocd1,                            --検査方法
                        t1.regsisyo regsisyo1,                                  --登録支所
                        t1.upddttm upddttm1,                                    --更新日時
                        --精密項目
                        t2.kensinkaisu kensinkaisu2,                            --検診回数
                        t2.nendo nendo2,                                        --実施年度
                        t2.jissiymd jissiymd2,                                  --実施日
                        t2.regsisyo regsisyo2,                                  --登録支所
                        t2.upddttm upddttm2                                     --更新日時
                    from
                        (select 
                            atenano,
                            jigyocd,
                            nendo, 
                            kensinkaisu, 
                            jissiymd,
                            kensahohocd,
                            upddttm, 
                            regsisyo 
                        from {tt_shkensinDto.TABLE_NAME} 
                        where jigyocd = '{jigyocd}'
                        ) t1
                    full join 
                        (select 
                            atenano,
                            jigyocd,
                            nendo, 
                            kensinkaisu, 
                            jissiymd,
                            upddttm, 
                            regsisyo
                        from {tt_shseikenDto.TABLE_NAME} 
                        where jigyocd = '{jigyocd}'
                        ) t2 
                    on 
                        t1.atenano = t2.atenano and 
                        t1.jigyocd = t2.jigyocd and 
                        t1.nendo = t2.nendo and 
                        t1.kensinkaisu = t2.kensinkaisu".Trim();
        }
    }
}