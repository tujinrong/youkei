/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 医療機関保守
　　　　　　詳細検索実施事業
作成日　　: 2023.12.6
作成者　　: CNC張加恒
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00201g_02(kikancd_in character varying)
	returns table
	(hanyocdx character varying                     --汎用コード
	, nmx character varying                         --名称
    , hanyokbn1x character varying                --汎用区分1
	, checkflg boolean )                            --チェックフラグ
	language plpgsql
as $function$
begin
	return query
	SELECT
		B.hanyocdx																	--汎用コード
		, B.nmx																		--名称																
        , B.hanyokbn1x		                                                                --汎用区分1
		, CASE WHEN A.jissijigyo IS NULL THEN false ELSE true END AS checkflg		--チェックフラグ			
	FROM
	    (	
        
        SELECT jissijigyo                                                           -- 実施事業
                FROM tm_afkikan_sub                                                 --医療機関サブマスタ
                WHERE kikancd = kikancd_in
        ) A	
    RIGHT JOIN 
    (   SELECT
            hanyocd as hanyocdx
            , nm as nmx
            , hanyokbn1 as hanyokbn1x
        FROM
            tm_afhanyo
        WHERE 
                hanyomaincd = '3019'																-- 汎用メインコード	
                 AND hanyosubcd = 100003	
            
    )B
    ON A.jissijigyo = B.hanyocdx
    ORDER BY 
      LPAD(B.hanyocdx, 3, '0');
end;
$function$
