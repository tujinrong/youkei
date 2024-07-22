/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 指定した事業コード、宛名番号及び実施年度が存在するかを検索
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetcurrentcheck(jigyocd_in character varying, atenano_in character varying, nendo_in integer)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
declare hasCheck varchar;
BEGIN
    --指定した事業コード、宛名番号及び実施年度が存在するかを検索する
	SELECT 
		CASE 
			WHEN EXISTS (
				SELECT 1
				FROM tt_shkensin
				WHERE nendo = nendo_in and atenano = atenano_in and jigyocd = jigyocd_in limit 1
			) OR EXISTS (
				SELECT 1
				FROM tt_shseiken
				WHERE nendo = nendo_in and atenano = atenano_in and jigyocd = jigyocd_in limit 1
                --存在する場合は”〇”を戻す
			) THEN '〇'
            --存在しない場合は”×”を戻す
			ELSE '✕'
		END INTO hasCheck;
RETURN hasCheck;
END; 

$function$