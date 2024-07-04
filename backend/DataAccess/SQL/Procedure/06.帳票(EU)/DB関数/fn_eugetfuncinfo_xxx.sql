/*******************************************************************
業務名称　: 健康管理システム
機能概要　: データベース内のすべての関数に関する情報を取得する
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetfuncinfo()
 RETURNS TABLE(name character varying, prorettype integer, proargtypes character varying, proallargtypes character varying, proargnames character varying, description character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
        SELECT p.proname::varchar AS name,
               p.prorettype::int       AS prorettype,
               p.proargtypes::varchar      AS proargtypes,
               p.proallargtypes::varchar   AS proallargtypes,
               p.proargnames::varchar      AS proargnames,
               d.description::varchar      AS description
        FROM pg_proc p
                 JOIN
             pg_namespace n ON p.pronamespace = n.oid
                 LEFT JOIN
             pg_description d ON p.oid = d.objoid
        WHERE p.prorettype > 0
          and n.nspname = 'public'
          and p.proname != 'fn_eugetfuncinfo'
        ORDER BY p.proname;
END;

$function$