/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票使用
            宛名番号より宛名テーブルの支援措置区分に入っている場合は〇を取得する
　　　　　　
作成日　　: 2024.05.21
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetkeikokuflg(atenano_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
BEGIN
    IF EXISTS (
            SELECT atenano              --宛名番号
            FROM tt_afatena         --宛名テーブル
            WHERE atenano = atenano_in  --宛名番号   
                AND siensotikbn IS NOT NULL   --支援措置区分
    )
    THEN
        --支援措置区分対象者の場合、「〇」を出力する
        RETURN '〇';
    ELSE
        --それ以外は、空白を出力する
        RETURN '';
    END IF;
END; 
$function$