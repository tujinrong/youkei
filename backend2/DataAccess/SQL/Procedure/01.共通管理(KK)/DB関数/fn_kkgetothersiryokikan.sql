/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 取込実行
　　　　　　医療機関取得
作成日　　: 2024.04.23
作成者　　: 高智輝
変更履歴　:
*******************************************************************/
/*==============================医療機関取得==============================*/
CREATE OR REPLACE FUNCTION fn_kkgetothersiryokikan()
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
    -- 変数の宣言
    code varchar := '9999999'; -- 医療機関コード
    name varchar := 'その他'; -- 名称
BEGIN
    RETURN code || ':' || name;
END;
$function$
