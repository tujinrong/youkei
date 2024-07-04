/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票使用
            宛名番号から、宛名テーブル又は送付先テーブルの住所を
            取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetaddress(
atenano_in character varying    --宛名番号
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
    jt1 VARCHAR;
    jt2 VARCHAR;
    jutokbn_in VARCHAR;
    value_in VARCHAR;
BEGIN 
	-- 住登区分と住所を取得する
    SELECT jutokbn				-- 住登区分(1：住民；2：住登外)
         , adrs1				-- 住所1
         , adrs2 				-- 住所2
     INTO jutokbn_in,jt1,jt2 
     FROM tt_afatena 
     WHERE atenano = atenano_in;
    
    -- 自治体名を付けるかの判断値を取得する
    SELECT value1 				-- 住所表記(0:非表示、1:表示)
      INTO value_in 
      FROM tm_afctrl 
     WHERE ctrlmaincd = '1000' 
       AND ctrlsubcd  = '2' 
       AND ctrlcd     = '03';
    
    IF jutokbn_in = '1' THEN
        --住民で自治体名付与しないの場合は、住所２を表示
        IF value_in = '0' THEN
        	RETURN jt2;
        --住民で自治体名付与の場合は、住所1と住所2を結合して表示
        ELSEIF value_in = '1' THEN
            RETURN jt1 || jt2;
        END IF;
    ELSEIF jutokbn_in = '2' THEN
         --住登外の場合は、住所１と住所２を結合して表示
        RETURN jt1 || jt2;
    END IF;
    RETURN jt1 || jt2;
END;

$function$
