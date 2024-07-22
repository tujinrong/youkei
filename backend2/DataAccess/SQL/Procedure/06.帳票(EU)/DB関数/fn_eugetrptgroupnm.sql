/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票使用
            帳票グループIDから帳票グループマスタの帳票グループ名
            を取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetrptgroupnm(
rptgroupid_in character varying --帳票グループID
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
BEGIN 
    -- 帳票グループ名を戻す
    RETURN (SELECT rptgroupnm FROM tm_eurptgroup WHERE rptgroupid = rptgroupid_in LIMIT 1);
END;
$function$