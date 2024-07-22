create function sp_aweu00304g_01_head(workseq_in bigint, rptgroupid_in character varying) returns integer
    language plpgsql
as
$$
declare
    total integer;
begin
    select count(w.atenano)
    into total
    FROM wk_euatena_sub w
             INNER JOIN tt_afatena a ON w.atenano = a.atenano
             left join tt_kkrpthakkotaisyogaisya k on w.atenano = k.atenano and k.rptgroupid  = rptgroupid_in
    WHERE w.workseq = workseq_in
      and (a.siensotikbn <> '' or k.taisyogairiyu <> '') ;
    return total;
end;
$$;

alter function sp_aweu00304g_01_head(bigint, varchar) owner to postgres;




create function sp_aweu00304g_01_body(workseq_in bigint, rptgroupid_in character varying, orderby_in integer, limit_in integer, offset_in integer)
    returns TABLE(formflg boolean, atenano character varying, simei_yusen character varying, taisyogairiyu character varying, siensotikbn character varying)
    language plpgsql
as
$$
begin
    return query
        select t1.formflg       as formflg,      --出力フラグ
               t1.atenano       as atenano,      --宛名番号
               t2.simei_yusen   as simei_yusen,  --氏名_優先
               t3.taisyogairiyu as taisyogairiyu,--発行対象外者対象外理由
               t2.siensotikbn   as siensotikbn   --支援措置区分
        from wk_euatena_sub t1
                 inner join tt_afatena t2 on t1.atenano = t2.atenano
                 left join tt_kkrpthakkotaisyogaisya t3 on t1.atenano = t3.atenano and t3.rptgroupid  = rptgroupid_in
        where t1.workseq = workseq_in
          and (t2.siensotikbn <> '' or t3.taisyogairiyu <> '') 
        order by case when orderby_in not in (1, -1, 2, -2, 3, -3, 4, -4) then t1.atenano end, --宛名番号 昇順
                 case when orderby_in = 1 then t1.atenano end,                                                      --宛名番号 昇順
                 case when orderby_in = -1 then t1.atenano end desc,                                                --宛名番号 降順
                 case when orderby_in = 2 then t2.simei_yusen end,                                                  --氏名_優先 昇順
                 case when orderby_in = -2 then t2.simei_yusen end desc,                                            --氏名_優先 降順
                 case when orderby_in = 3 then t3.taisyogairiyu end,                                                --発行対象外者対象外理由 昇順
                 case when orderby_in = -3 then t3.taisyogairiyu end desc,                                          --発行対象外者対象外理由 降順
                 case when orderby_in = 4 then t2.siensotikbn end,                                                  --支援措置区分 昇順
                 case when orderby_in = -4 then t2.siensotikbn end desc                                             --支援措置区分 降順
        limit limit_in offset offset_in;
end;

$$;

alter function sp_aweu00304g_01_body(bigint, varchar, integer, integer, integer) owner to postgres;

