/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票出力(一覧画面)
　　　　　　一覧抽出
作成日　　: 2024.03.12
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_aweu00301g_01_head(gyomukbn_in character varying, rptgroupid_in character varying, rptnm_in character varying) returns integer
    language plpgsql
as
$$
declare
    total integer;
begin
    select count(1)
    into total
    from tm_eurpt t1
             left join tm_eurptgroup t2 on t1.rptgroupid = t2.rptgroupid
    where (gyomukbn_in is null or t2.gyomukbn = gyomukbn_in)
      and (rptgroupid_in is null or t1.rptgroupid = rptgroupid_in and t2.rptgroupid = rptgroupid_in)
      and (rptnm_in is null or t1.rptnm ilike rptnm_in);
    return total;
end;
$$;

/*==============================body==============================*/
create or replace function sp_aweu00301g_01_body(gyomukbn_in character varying, rptgroupid_in character varying, rptnm_in character varying, orderby_in integer, limit_in integer, offset_in integer)
    returns TABLE
            (
                rptid      character varying,
                rptnm      character varying,
                rptgroupnm character varying,
                rptbiko    character varying,
                regusernm  character varying,
                regdttm    timestamp without time zone,
                rptgroupid character varying
            )
    language plpgsql
as
$$
begin
    return query
        select t1.rptid      as rptid,      --帳票ID
               t1.rptnm      as rptnm,      --帳票名
               t2.rptgroupnm as rptgroupnm, --帳票グループ名
               t1.rptbiko    as rptbiko,    --帳票説明
               t3.usernm     as regusernm,  --作成者
               t1.regdttm    as regdttm,    --作成日時
               t1.rptgroupid as rptgroupid  --帳票グループID
        from tm_eurpt t1
                 left join tm_eurptgroup t2
                           on t1.rptgroupid = t2.rptgroupid
                 left join tm_afuser t3
                           on t1.reguserid = t3.userid
        where (gyomukbn_in is null or t2.gyomukbn = gyomukbn_in)
          and (rptgroupid_in is null or t1.rptgroupid = rptgroupid_in and t2.rptgroupid = rptgroupid_in)
          and (rptnm_in is null or t1.rptnm ilike rptnm_in)
        order by 
                 case when orderby_in = 1 then t1.rptid end,                                                       --帳票ID 昇順
                 case when orderby_in = -1 then t1.rptid end desc,                                                 --帳票ID 降順
                 case when orderby_in = 2 then t1.rptnm end,                                                       --帳票名 昇順
                 case when orderby_in = -2 then t1.rptnm end desc,                                                 --帳票名 降順
                 case when orderby_in = 3 then t2.rptgroupnm end,                                                  --帳票グループ名 昇順
                 case when orderby_in = -3 then t2.rptgroupnm end desc,                                            --帳票グループ名 降順
                 case when orderby_in = 4 then t1.rptbiko end,                                                     --帳票説明 昇順
                 case when orderby_in = -4 then t1.rptbiko end desc,                                               --帳票説明 降順
                 case when orderby_in = 5 then t3.usernm end,                                                      --作成者 昇順
                 case when orderby_in = -5 then t3.usernm end desc,                                                --作成者 降順
                 case when orderby_in = 6 then t1.regdttm end,                                                     --作成日時 昇順
                 case when orderby_in = -6 then t1.regdttm end desc,                                                --作成日時 降順
                 t1.orderseq, t1.rptid                                                                              --デフォルト 帳票ID 降順
        limit limit_in offset offset_in;
end;
$$;