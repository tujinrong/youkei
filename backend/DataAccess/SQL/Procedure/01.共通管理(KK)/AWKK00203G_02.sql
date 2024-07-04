/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 事業従事者（担当者）保守
　　　　　　詳細検索実施事業
作成日　　: 2023.12.3
作成者　　: 劉誠
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00203g_02(staffid_in character varying)
	returns table
	(hanyocdx character varying                     --汎用コード
	, nmx character varying                         --名称
	, hanyokbn1x character varying                  --汎用区分1
    , checkflg boolean )                            --チェックフラグ
	language plpgsql
as $function$
begin
return query
select
    m1.hanyocdx                                                                     --汎用コード            
    ,m1.nmx																			--名称																	
    ,m1.hanyokbn1x                                                                  --汎用区分1
    ,case when m2.jissijigyo IS NULL then false else true end as checkflg			--チェックフラグ																															
  from                                                        																																		
    (																																		
	select																												
        distinct X.hanyomaincd, X.hanyosubcd, X.hanyocd as hanyocdx, X.nm as nmx, X.hanyokbn1 as hanyokbn1x     -- 汎用メインコードなど																											
    from																												
        (select																												
                hanyomaincd, hanyosubcd, hanyocd, nm, hanyokbn1                                                 -- 汎用メインコードなど																				
            from tm_afhanyo																												
            where hanyomaincd = '3019'												                            -- 汎用メインコード																
            and hanyosubcd = 100003													                            -- 汎用サブコード															
        ) X																													
    ) m1																																		
  left join tm_afstaff_sub m2                                                                                   -- 事業従事者（担当者）サブマスタテーブル																				
    on m2.jissijigyo = m1.hanyocdx													                            -- 汎用コード（実施事業コード）																					
   and m2.staffid = staffid_in														                            -- 事業従事者ID																				
 order by																																		
       LPAD(m1.hanyocdx, 3, '0');					                                                            -- 汎用コード（実施事業コード）
end;
$function$	