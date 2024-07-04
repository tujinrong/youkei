/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 健（検）診予約希望者管理
　　　　　　対象検査方法一覧取得
作成日　　: 2024.02.27
作成者　　: 劉
変更履歴　:
*******************************************************************/
create or replace function sp_awsh00402g_01(nendo_in integer, atenano_in character varying, yoteiymd_in character varying)
returns table
  (jigyocd character varying,
   kensahohocd character varying,
   flg1 boolean,
   flg2 boolean,
   flg3 boolean)
  language plpgsql
as $function$  
#variable_conflict use_column
begin
    return query 
    select 
        m1.jigyocd,
        m1.kensahohocd, 
        (case 
            when m1.tokusyu = '1' 
                then (fn_shgetsp1flg(m1.jigyocd, m1.kensahohocd, t1.atenano, nendo_in) = false)
            else true
        end) flg1,                      --昨年受診フラグ(false:受診済)
        (t3.atenano is null) flg2,      --今年受診フラグ(false:受診済)
        (
            t2.atenano is null                                                  --受診拒否理由設定なし
            and t1.juminkbn != '5' and t1.juminkbn != '6'                       --除票、住登外除票は作成対象外
            and ((m1.sex is null) or m1.sex = t1.sex)                           --性別判断
            and fn_shgetageflg(t1.bymd, t1.bymd_fusyoflg, 
                                (case 
                                    when m1.kijunymd is null 
                                        then yoteiymd_in
                                    else m1.kijunymd
                                end), 
                                m1.age)  --年齢判断
            and ((m1.hokenkbn is null) or m1.hokenkbn = t1.hokenkbn)            --保険区分判断
            and (case                                                           --SQL判断
                    when m1.sql is not null
                        then  t1.atenano in(select atenano from fn_shgetatenano(m1.sql))
                    else true
                end)
        ) flg3                          --対象フラグ(true:対象)
    from tt_afatena t1
    left join tm_shnendo m1
    on m1.nendo = nendo_in
    left join tt_shjyusinkyohiriyu t2
    on 
        t1.atenano = t2.atenano and 
        m1.jigyocd = t2.jigyocd and
        t2.nendo = nendo_in and 
        t2.atenano = atenano_in 
    left join 
        (select 
            distinct(atenano), 
            jigyocd, 
            kensahohocd
        from tt_shkensin 
        where nendo = nendo_in and atenano = atenano_in 
        ) t3
    on 
        t1.atenano = t3.atenano and
        m1.jigyocd = t3.jigyocd and
        m1.kensahohocd = t3.kensahohocd
    where 
        t1.atenano = atenano_in;
end;
$function$