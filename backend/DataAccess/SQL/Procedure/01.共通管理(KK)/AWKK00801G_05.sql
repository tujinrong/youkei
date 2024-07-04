/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 拡張事業・拡張運用情報保守
　　　　　　検診項目桁数チェック用
作成日　　: 2024.01.30
作成者　　: 劉
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_05(jigyocd_in character varying, itemcd_in character varying, inputtypekbn_in integer, keta1_in integer, keta2_in integer)
 returns boolean
 language plpgsql
as $function$              
begin
    return exists(
                select 1
                from (
                    select
                        length(t.strvalue) as strketa,
                        case
                            when position('.' in t.numvalue::text) > 0
                            then position('.' in t.numvalue::text) - 1
                            else length(t.numvalue::text)
                        end as numketa1,
                        case
                            when position('.' in t.numvalue::text) > 0
                            then length(substring(t.numvalue::text from position('.' in t.numvalue::text) + 1))
                            else 0
                        end as numketa2
                    from (
                        select
                            strvalue,  --文字項目
                            numvalue   --数値項目
                        from tt_shfree 
                        where 
                            jigyocd = jigyocd_in and
                            itemcd = itemcd_in ) as t
                    ) as tt
                where 
                    (inputtypekbn_in = 2 and tt.strketa > keta1_in) or                                                 --文字型
                    (inputtypekbn_in = 1 and tt.numketa1 > keta1_in and (keta2_in is null or tt.numketa2 > keta2_in))  --数値型
           ); 
end;
$function$