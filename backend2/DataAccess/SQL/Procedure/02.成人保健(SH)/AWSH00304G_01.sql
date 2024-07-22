/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 年度切替
　　　　　　引継ぎ処理
作成日　　: 2024.01.31
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awsh00304g_01(nendo_in integer, jigyocds_in character varying, kyohiriyus_in character varying)
returns void
language plpgsql
as $function$    
declare
    column_list text;
    jigyocds text[];
    kyohiriyus text[];
begin
    jigyocds := string_to_array(jigyocds_in, ',');
    kyohiriyus := string_to_array(kyohiriyus_in, ',');
    select string_agg(column_name, ', ') 
    into column_list
    from (
        select distinct column_name 
        from information_schema.columns
        where table_name = 'tt_shjyusinkyohiriyu' and ordinal_position != 1);

    execute format('
        insert into tt_shjyusinkyohiriyu (nendo, %s)
        select %s as nendo, %s
        from tt_shjyusinkyohiriyu
        where nendo = %s 
        and jigyocd = any(%L)
        and kyohiriyu = any(%L)', column_list, nendo_in, column_list, nendo_in - 1, jigyocds, kyohiriyus);
end;
$function$