/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 取込実行
　　　　　　医療機関コード取得
作成日　　: 2023.11.30
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================医療機関コード取得==============================*/
create or replace function fn_kkgetiryokikancd(kikannm_in character varying)
	returns table
	(kikancd character varying)					--医療機関コード					       
	language plpgsql
as $function$
begin
	return query
	select
        t1.kikancd
    from
        tm_afkikan t1                          	--医療機関マスタ
    where
        t1.kikannm = kikannm_in;				--医療機関名
                                    	
end;
$function$