/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 文字項目を取得
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetkekkanm(jigyocd_in character varying, kekkacd_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
BEGIN

    RETURN(
        SELECT strvalue 
        FROM tt_shfree
        WHERE jigyocd = jigyocd_in
        AND strvalue = kekkacd_in   
        );

END;

$function$