/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 拡事業・拡運用情報保守
　　　　　　利用検査方法変更チェック用
作成日　　: 2024.01.19
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_01(jigyocd_in character varying, itemcd_in character varying, riyokensahohocds_in character varying)
 returns boolean
 language plpgsql
as $function$
declare riyokensahohocds text[];                 
begin
    riyokensahohocds = string_to_array(riyokensahohocds_in, ',');   --利用検査方法コード
      return exists(
                select 1
                from tt_shfree t1
                inner join tm_shfreeitem t2
                on t1.jigyocd = t2.jigyocd
                and t1.itemcd = t2.itemcd
                where 
                    t1.itemcd = itemcd_in and 
                    t1.jigyocd = jigyocd_in
           );
end;
$function$