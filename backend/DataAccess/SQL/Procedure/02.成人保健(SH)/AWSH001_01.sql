/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ロジック共通仕様(検診)
　　　　　　検索処理(各回目のベース情報)
作成日　　: 2023.06.28
作成者　　: 蔣
変更履歴　:
*******************************************************************/
create or replace function sp_awsh001_01(jigyocd_in character varying, atenano_in character varying, nendo_in integer)
  returns table
  (kensinkaisu_out smallint,
   jissiymd1 character varying,
   jissiymd2 character varying,
   jissiage1 smallint,
   jissiage2 smallint,
   kensahoho1 character varying,
   upddttm1 timestamp without time zone, 
   upddttm2 timestamp without time zone, 
   regsisyo1 character varying, 
   regsisyo2 character varying)
  language plpgsql
as $function$
begin
    return query
    select
        coalesce(t1.kensinkaisu,t2.kensinkaisu) kensinkaisu_out,    --検診回数
        t1.jissiymd jissiymd1,                          --実施日（一次）
        t2.jissiymd jissiymd2,                          --実施日（精密）
        t1.jissiage jissiage1,                          --実施年齢（一次）
        t2.jissiage jissiage2,                          --実施年齢（精密）
        t1.kensahohocd kensahoho1,                        --検査方法（一次）
        t1.upddttm upddttm1,                            --更新日時（一次）
        t2.upddttm upddttm2,                            --更新日時（精密）
        t1.regsisyo regsisyo1,                          --登録支所（一次）
        t2.regsisyo regsisyo2                           --登録支所（精密）
    from
        (select 
            kensinkaisu, 
            jissiymd, 
            jissiage, 
            kensahohocd, 
            upddttm, 
            regsisyo 
        from tt_shkensin 
        where 
            jigyocd = jigyocd_in and 
            atenano = atenano_in and 
            nendo = nendo_in
        ) t1
    full join 
        (select 
            kensinkaisu, 
            jissiymd, 
            jissiage, 
            upddttm, 
            regsisyo
        from tt_shseiken 
        where 
            jigyocd = jigyocd_in and 
            atenano = atenano_in and 
            nendo = nendo_in
        ) t2 
    on t1.kensinkaisu = t2.kensinkaisu
    order by 
        coalesce(t1.kensinkaisu,t2.kensinkaisu);
end;
$function$