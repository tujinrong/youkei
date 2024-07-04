/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 指定された事業コードと宛名番号が現在の年度に存在するかを確認する
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetcurrentyear_check(jigyocd_in character varying, atenano_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
declare hasCheck varchar;
BEGIN
	SELECT * from fn_eugetcurrentcheck(jigyocd_in, atenano_in, EXTRACT(YEAR FROM CURRENT_DATE)::INTEGER) INTO hasCheck;
RETURN hasCheck;
END;

$function$