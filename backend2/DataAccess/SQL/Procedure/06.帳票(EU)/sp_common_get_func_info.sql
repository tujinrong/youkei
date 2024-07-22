/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 指定された関数の情報を取得
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION sp_common_get_func_info(proname_in character varying)
 RETURNS TABLE(name character varying, src character varying, prorettype integer, proargtypes character varying, proallargtypes character varying, proargnames character varying, description character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
        SELECT p.proname::varchar                 AS name,
               pg_get_functiondef(p.oid)::varchar AS src,
               p.prorettype::int                  AS prorettype,
               p.proargtypes::varchar             AS proargtypes,
               p.proallargtypes::varchar          AS proallargtypes,
               p.proargnames::varchar             AS proargnames,
               d.description::varchar             AS description
        FROM pg_proc p
                 JOIN
             pg_namespace n ON p.pronamespace = n.oid
                 LEFT JOIN
             pg_description d ON p.oid = d.objoid
        WHERE p.prorettype > 0
          --AND p.prorettype != (SELECT oid FROM pg_type WHERE typname = 'void')
          AND n.nspname = 'public'
          AND p.proname != 'sp_common_get_func_info'
          AND (proname_in IS NULL OR p.proname like proname_in)
        ORDER BY p.proname;
END;

$function$