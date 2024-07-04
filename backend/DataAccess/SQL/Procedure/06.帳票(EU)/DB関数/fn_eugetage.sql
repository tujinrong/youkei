/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票使用
            年齢計算の結果を取得する
作成日　　: 2024.07.01
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetage(
bymd_in character varying, --生年月日
kijunymd_in date  --基準日　
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
DECLARE
    bymd_data varchar;   -- 生年月日
    bymd_flag boolean;   -- 生年月日_不詳フラグ
    kijyunbi date;       -- 基準日
BEGIN
    -- 基準日がNULLの場合、システムの日付を取得する
    IF kijunymd_in IS NULL THEN
        kijyunbi := current_date;
    ELSE
        kijyunbi := kijunymd_in;
    END IF;
    
    -- 生年月日と生年月日_不詳フラグを取得する
    SELECT bymd, bymd_fusyoflg
    INTO bymd_data, bymd_flag
    FROM tt_afatena
    WHERE bymd = bymd_in;
    
    -- 生年月日_不詳フラグをチェックする場合、文字列 '不詳' を返す
    IF bymd_flag = TRUE THEN
        RETURN '不詳';
    ELSE
        -- 生年月日_不詳フラグをチェックしない場合、年齢を計算して整数で返す
        RETURN EXTRACT(YEAR FROM age(kijyunbi, bymd_data::date));
    END IF;
END; 

$function$