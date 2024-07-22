/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 取込実行
　　　　　　宛名番号取得
作成日　　: 2023.11.30
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================宛名番号取得==============================*/
CREATE OR REPLACE FUNCTION fn_kkgetatenano(simei_in character varying, sex_in character varying, bymd_in character varying)
RETURNS character varying
LANGUAGE plpgsql
AS $function$
DECLARE
    result character varying;
BEGIN
    SELECT
        CASE
            WHEN COUNT(*) = 1 THEN MAX(t1.atenano)
            ELSE ''
        END INTO result
    FROM tt_afatena t1   -- 宛名テーブル
    WHERE t1.simei_kana_seion LIKE simei_in   -- カナ氏名
      AND t1.sex = sex_in                     -- 性別
      AND t1.bymd = bymd_in;                  -- 生年月日

    RETURN result;
END;
$function$;

