/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 取込実行
　　　　　　年度取得
作成日　　: 2024.03.27
作成者　　: 高智輝
変更履歴　:
*******************************************************************/
/*==============================年度取得==============================*/
CREATE OR REPLACE FUNCTION fn_kkgetnendo(value_in character varying, type_in integer)
 RETURNS smallint
 LANGUAGE plpgsql
AS $function$
DECLARE
    _YMD TIMESTAMP;
    _date TIMESTAMP;
BEGIN
    _date := TO_TIMESTAMP(value_in, 'YYYY-MM-DD');
    IF type_in = 0 THEN
        _YMD := TO_TIMESTAMP(EXTRACT(YEAR FROM _date)::VARCHAR || '/4/1', 'YYYY/MM/DD');
    END IF;
    IF type_in = 1 THEN
        _YMD := TO_TIMESTAMP(EXTRACT(YEAR FROM _date)::VARCHAR || '/4/2', 'YYYY/MM/DD');
    END IF;
    IF _date >= _YMD THEN
        RETURN EXTRACT(YEAR FROM _date)::SMALLINT;
    END IF;
    IF _date < _YMD THEN
        RETURN (EXTRACT(YEAR FROM _date) - 1)::SMALLINT;
    END IF;
    RETURN NULL;
END;
$function$
