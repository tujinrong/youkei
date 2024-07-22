CREATE OR REPLACE FUNCTION sp_aweu00401g_01_head(rptgroupid_in character varying) returns integer
    language plpgsql
AS $function$
    declare total integer;
begin

    select
        count(1) total into total
    from
        tm_eurptgroup t1
    where  (rptgroupid_in IS NULL OR t1.rptgroupid = rptgroupid_in);
    return total;
END;
$function$



CREATE OR REPLACE FUNCTION public.sp_aweu00401g_01_body(rptgroupid_in character varying, limit_in integer, offset_in integer)
 RETURNS TABLE(rptgroupid character varying, rptgroupnm character varying, kojinrenrakusakicd character varying, memocd character varying, electronfilecd character varying, followmanage character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
        SELECT a.rptgroupid,            --帳票グループID
               a.rptgroupnm,            --帳票グループ名
               a.kojinrenrakusakicd,    --個人連絡先
               a.memocd,                --メモ情報
               a.electronfilecd,        --電子ファイル情報
               a.followmanage           --フォロー管理
        FROM tm_eurptgroup a        --帳票グループマスタ
        WHERE (rptgroupid_in IS NULL OR a.rptgroupid = rptgroupid_in)
        ORDER BY a.orderseq
        limit limit_in offset offset_in;
END;
$function$