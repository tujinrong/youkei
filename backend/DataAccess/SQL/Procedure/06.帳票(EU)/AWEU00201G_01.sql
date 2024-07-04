/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票管理(一覧)
　　　　　　一覧抽出
作成日　　: 2024.03.12
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_aweu00201g_01_head(gyoumucd_in character varying, rptgroupid_in character varying, rptnm_in character varying, yosikinm_in character varying, yoshikibunrui_in character varying,
                                                 yosikisyubetu_in character varying) returns integer
    language plpgsql
as
$$
declare
    total integer;
begin
    with rpts as (SELECT temp.rptid,
                         temp.yosikiid
                  FROM (SELECT te.rptid,
                               te.yosikiid,
                               ROW_NUMBER() OVER (PARTITION BY te.rptid ORDER BY te.orderseq, te.regdttm) AS rn
                        FROM tm_euyosiki te) AS temp
                  WHERE temp.rn = 1)
    select count(1)
    into total
    from tm_euyosikisyosai t1
             left join tm_eurpt t2 on t1.rptid = t2.rptid
             left join tm_eurptgroup t3 on t2.rptgroupid = t3.rptgroupid
             left join tm_eudatasource t4 on t1.datasourceid = t4.datasourceid
    where (gyoumucd_in is null or t3.gyomukbn = gyoumucd_in)
      and (rptgroupid_in is null or t2.rptgroupid = rptgroupid_in and t3.rptgroupid = rptgroupid_in)
      and (rptnm_in is null or t2.rptnm ilike rptnm_in)
      and (yosikinm_in is null or t1.yosikinm ilike yosikinm_in)
      and (case
               when yoshikibunrui_in = '1' then t1.yosikieda = 0 and exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid)
               when yoshikibunrui_in = '2' then t1.yosikieda = 0 and not exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid)
               when yoshikibunrui_in = '3' then t1.yosikieda > 0
               else true
        end)
      and (yosikisyubetu_in is null or t1.yosikisyubetu = yosikisyubetu_in);
    return total;
end;
$$;

/*==============================body==============================*/
create or replace function sp_aweu00201g_01_body(gyoumucd_in character varying, rptgroupid_in character varying, rptnm_in character varying, yosikinm_in character varying, yoshikibunrui_in character varying,
                                                 yosikisyubetu_in character varying, orderby_in integer, limit_in integer, offset_in integer)
    returns TABLE
            (
                gyomukbn        character varying,
                rptgroupnm      character varying,
                rptid           character varying,
                rptnm           character varying,
                rptdatasourceid   character varying,
                yosikiideda     character varying,
                yosikidenm      character varying,
                kbn             character varying,
                yosikisyubetu   character varying,
                yosikikbn       character varying,
                datasourcenm    character varying,
                yosikiid        character varying,
                yosikieda       smallint,
                yosikinm        character varying,
                datasourceid    character varying
            )
    language plpgsql
as
$$
begin
    return query
        with rpts as (SELECT temp.rptid,
                             temp.yosikiid
                      FROM (SELECT te.rptid,
                                   te.yosikiid,
                                   ROW_NUMBER() OVER (PARTITION BY te.rptid ORDER BY te.orderseq, te.regdttm) AS rn
                            FROM tm_euyosiki te) AS temp
                      WHERE temp.rn = 1)
        select t4.gyomukbn                                                                                                as gyomukbn,       --業務
               t4.rptgroupnm                                                                                              as rptgroupnm,     --帳票グループ名
               t3.rptid                                                                                                   as rptid,          --帳票id
               t3.rptnm                                                                                                   as rptnm,          --帳票名
               t1.datasourceid                                                                                            as rptdatasourceid,   --データソースID
               case when t1.yosikieda > 0 then concat(t1.yosikiid, '-', t1.yosikieda::text) else t1.yosikiid end::varchar as yosikiideda,    --様式id-枝番
               case when t1.yosikieda > 0 then concat(t3.rptnm, '/', t1.yosikinm) else t1.yosikinm end::varchar           as yosikidenm,     --様式名-サブ様式名
               case
                   when t1.yosikieda > 0 then '3' -- サブ様式
                   else case
                            when exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid) then '1' --帳票
                            else '2' -- 別様式　
                       end
                   end::varchar                                                                                           as kbn,            --様式分類
               t1.yosikisyubetu::varchar                                                                                  as yosikisyubetu,  --todo 様式種別
               t1.yosikikbn::varchar                                                                                      as yosikikbn,      --様式種別詳細
               case 
                when t1.yosikihouhou ='2'
                    then 'SQL'
               when t1.yosikihouhou ='3' 
                    then t3.procnm
                else t5.datasourceid || ':' || t5.datasourcenm
                end ::varchar                                                                                            as datasourcenm,    --データソース名称
               t1.yosikiid                                                                                                as yosikiid,       --様式id
               t1.yosikieda                                                                                               as yosikieda,      --様式枝番
               t1.yosikinm                                                                                                as yosikinm,       --様式名
               t3.datasourceid                                                                                            as datasourceid    --帳票データソースID
        from tm_euyosikisyosai t1
                 left join tm_euyosiki t2 on t1.rptid = t2.rptid and t1.yosikiid = t2.yosikiid
                 left join tm_eurpt t3 on t1.rptid = t3.rptid
                 left join tm_eurptgroup t4 on t3.rptgroupid = t4.rptgroupid
                 left join tm_eudatasource t5 on t3.datasourceid = t5.datasourceid
        where (gyoumucd_in is null or t4.gyomukbn = gyoumucd_in)
          and (rptgroupid_in is null or t3.rptgroupid = rptgroupid_in and t4.rptgroupid = rptgroupid_in)
          and (rptnm_in is null or t3.rptnm ilike rptnm_in)
          and (yosikinm_in is null or t1.yosikinm ilike yosikinm_in)
          and (case
                   when yoshikibunrui_in = '1' then t1.yosikieda = 0 and exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid)
                   when yoshikibunrui_in = '2' then t1.yosikieda = 0 and not exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid)
                   when yoshikibunrui_in = '3' then t1.yosikieda > 0
                   else true
            end)
          and (yosikisyubetu_in is null or t1.yosikisyubetu = yosikisyubetu_in)
        order by case when orderby_in = 1 then t4.gyomukbn end,                                                                                   --業務  昇順
                 case when orderby_in = -1 then t4.gyomukbn end desc,                                                                             --業務  降順
                 case when orderby_in = 2 then t4.rptgroupnm end,                                                                                 --帳票グループ名  昇順
                 case when orderby_in = -2 then t4.rptgroupnm end desc,                                                                           --帳票グループ名  降順
                 case when orderby_in = 3 then t3.rptid end,                                                                                      --帳票id  昇順
                 case when orderby_in = -3 then t3.rptid end desc,                                                                                --帳票id  降順
                 case when orderby_in = 4 then t3.rptnm end,                                                                                      --帳票名  昇順
                 case when orderby_in = -4 then t3.rptnm end desc,                                                                                --帳票名  降順
                 case when orderby_in = 5 or orderby_in = -5 then t3.rptid end,                                                                   --帳票id  昇順
                 case when orderby_in = 5 then case when t1.yosikieda > 0 then concat(t1.yosikiid, '-', t1.yosikieda) else t1.yosikiid end end,           --様式id-枝番  昇順
                 case when orderby_in = -5 then case when t1.yosikieda > 0 then concat(t1.yosikiid, '-', t1.yosikieda) else t1.yosikiid end end desc,     --様式id-枝番  降順
                 case when orderby_in = 6 then case when t1.yosikieda > 0 then concat(t3.rptnm, '/', t1.yosikinm) else t1.yosikinm end end,       --様式名  昇順
                 case when orderby_in = -6 then case when t1.yosikieda > 0 then concat(t3.rptnm, '/', t1.yosikinm) else t1.yosikinm end end desc, --様式名  降順
                 case when orderby_in = 7 then case
                   when t1.yosikieda > 0 then '3' -- サブ様式
                   else case
                            when exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid) then '1' --帳票
                            else '2' -- 別様式　
                       end end end,                                                                                                                   --様式分類  昇順
                 case when orderby_in = -7 then case
                   when t1.yosikieda > 0 then '3' -- サブ様式
                   else case
                            when exists (select 1 from rpts where rpts.rptid = t1.rptid and rpts.yosikiid = t1.yosikiid) then '1' --帳票
                            else '2' -- 別様式　
                       end end end desc,                                                                                                              --様式分類  降順
                 case when orderby_in = 8 then t1.yosikisyubetu end,                                                                              --様式種別  昇順
                 case when orderby_in = -8 then t1.yosikisyubetu end desc,                                                                        --様式種別  降順
                 case when orderby_in = 9 then t5.datasourcenm end,                                                                               --データソース名称  昇順
                 case when orderby_in = -9 then t5.datasourcenm end desc,                                                                         --データソース名称  降順
                 t3.orderseq, t3.rptid, t2.yosikiid, t1.yosikieda
        limit limit_in offset offset_in;
end;
$$;