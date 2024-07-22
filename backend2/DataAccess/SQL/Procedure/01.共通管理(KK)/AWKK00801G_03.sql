/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 拡事業・拡運用情報保守
　　　　　　検診項目必須チェック用
作成日　　: 2024.01.30
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_03(jigyocd_in character varying, itemcd_in character varying)
 returns boolean
 language plpgsql
as $function$              
begin
    return exists(
                select 1
                from
                    tt_shfree
                where 
                    jigyocd = jigyocd_in and 
                    itemcd = itemcd_in   and
                    numvalue is null     and
                    coalesce(strvalue, '') = ''
                  ); 
end;
$function$