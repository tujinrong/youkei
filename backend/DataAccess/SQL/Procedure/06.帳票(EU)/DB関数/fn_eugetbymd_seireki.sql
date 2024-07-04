/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 宛名番号より宛名テーブルの生年月日(西暦)を取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetbymd_seireki(
atenano_in character varying    --宛名番号
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
    bith_data varchar;
    bith_flag boolean;
BEGIN

    SELECT bymd                     -- 生年月日
         , bymd_fusyoflg            -- 生年月日_不詳フラグ
      INTO bith_data, bith_flag  
      FROM tt_afatena 
     WHERE atenano = atenano_in;
     
    -- 生年月日が不詳の場合、不詳を表示
    IF bith_flag OR bith_flag IS NULL OR bith_data IS NULL THEN
        RETURN replace(bith_data,'-','/');
    ELSE
        --ハイフンをスラッシュに置換
        RETURN replace(bith_data,'-','/');
    END IF;
END;

$function$