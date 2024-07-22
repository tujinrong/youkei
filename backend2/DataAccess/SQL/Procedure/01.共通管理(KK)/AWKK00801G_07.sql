/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 拡事業・拡運用情報保守
　　　　　　検診予約引継ぎ用
作成日　　: 2024.01.31
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_07(nendo_in integer,
                                            reguserid_in character varying, 
                                            upduserid_in character varying)
returns void
language plpgsql
as $function$
declare
    column_list text;
    column_list2 text;
    regdttm_in2 timestamp without time zone := to_char(NOW(), 'YYYY-MM-DD HH24:MI:SS.MS');
    upddttm_in2 timestamp without time zone := to_char(NOW(), 'YYYY-MM-DD HH24:MI:SS.MS');
begin
    select string_agg(distinct quote_ident(column_name), ', ') 
    into column_list
    from information_schema.columns
    where table_name = 'tm_shyoyakujigyo' and ordinal_position != 1
                                          and column_name not in ('reguserid', 'regdttm', 'upduserid', 'upddttm');
    select string_agg(distinct quote_ident(column_name), ', ') 
    into column_list2
    from information_schema.columns
    where table_name = 'tm_shyoyakujigyo_sub' and ordinal_position != 1;

    execute format('
        insert into tm_shyoyakujigyo (nendo, %s, reguserid, regdttm, upduserid, upddttm)
        select %L as nendo, %s, %L, %L, %L, %L
        from tm_shyoyakujigyo
        where nendo = %L', 
        column_list, 
        nendo_in, 
        column_list, 
        reguserid_in, 
        regdttm_in2, 
        upduserid_in, 
        upddttm_in2, 
        nendo_in - 1);

    execute format('
        insert into tm_shyoyakujigyo_sub (nendo, %s)
        select %L as nendo, %s
        from tm_shyoyakujigyo_sub
        where nendo = %L
        and kensin_jigyocd in (select jigyocd from tm_shnendo where nendo = %L)
        and kensahohocd in (select kensahohocd from tm_shnendo where nendo = %L)', 
        column_list2, 
        nendo_in, 
        column_list2, 
        nendo_in - 1,
        nendo_in,
        nendo_in);
end;
$function$;