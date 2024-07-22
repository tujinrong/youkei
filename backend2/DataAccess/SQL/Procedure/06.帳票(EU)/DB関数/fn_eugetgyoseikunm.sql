/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票使用
            宛名番号から宛名テーブルの行政区コード取得し、
            行政区名を取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetgyoseikunm(
atenano_in character varying    --宛名番号  
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
BEGIN
　　--地区情報マスタから行政区名を取得する
    RETURN(
        SELECT M.tikunm              --地区名
        FROM tt_afatena T　　　　　　--宛名テーブル
        LEFT JOIN tm_aftiku M　　　　--地区情報マスタ
            ON T.gyoseikucd = M.tikucd
        WHERE T.atenano = atenano_in
        AND M.tikukbn =             --地区区分
        (
            SELECT nmcd  
            FROM   tm_afmeisyo      --名称マスタ
            WHERE  nmmaincd='1001' AND nmsubcd=37 AND hanyokbn2='1' 
            ORDER BY nmcd LIMIT 1
        )
    );
END; 

$function$