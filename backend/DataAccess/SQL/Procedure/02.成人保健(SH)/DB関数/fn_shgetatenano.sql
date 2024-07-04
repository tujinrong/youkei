/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 共通関数
　　　　　　sqlから宛名番号取得
作成日　　: 2024.02.12
作成者　　: 劉
変更履歴　:
*******************************************************************/
create or replace function fn_shgetatenano(sql_in character varying)
 returns table
 (atenano character varying)
 language plpgsql
as $function$
begin
    return query execute format('select atenano from (%s) as sub_query', sql_in);
end;
$function$