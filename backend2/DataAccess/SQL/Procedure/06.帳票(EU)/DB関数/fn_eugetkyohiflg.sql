/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票使用
            宛名番号と帳票IDより帳票発行対象外者に登録されている
            場合は〇を取得する
作成日　　: 2024.04.17
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetkyohiflg(
    atenano_in character varying, --宛名番号
    rptid_in character varying　　--帳票ID
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
BEGIN
    IF EXISTS (
            SELECT t2.atenano   --宛名番号
            FROM tm_eurpt t1        --EUC帳票マスタ
            LEFT JOIN tt_kkrpthakkotaisyogaisya t2  --帳票発行対象外者テーブル
                ON t1.rptgroupid = t2.rptgroupid     --帳票グループID
            WHERE t2.atenano = atenano_in         --宛名番号
                AND t1.rptid = rptid_in           --帳票ID
    )
    THEN
    --宛名番号が帳票発行対象外者の場合、「〇」を出力する
        RETURN '〇';
    ELSE
    --それ以外は、空白を出力する
        RETURN '';
    END IF;
END; 
$function$