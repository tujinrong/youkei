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
      and (a.siensotikbn IS NOT NULL OR k.taisyogairiyu IS NOT NULL);
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
        select T1.formflg       as formflg,      --出力フラグ
               T1.atenano       as atenano,      --宛名番号
               T2.simei_yusen   as simei_yusen,  --氏名_優先
               T3.taisyogairiyu as taisyogairiyu,--発行対象外者対象外理由
               T2.siensotikbn   as siensotikbn   --支援措置区分
        from wk_euatena_sub T1
                 inner join tt_afatena T2 on T1.atenano = T2.atenano
                 left join tt_kkrpthakkotaisyogaisya T3 on T1.atenano = T3.atenano and T3.rptgroupid  = rptgroupid_in
        where T1.workseq = workseq_in
           AND (T2.siensotikbn IS NOT NULL OR T3.taisyogairiyu IS NOT NULL)
        order by case when orderby_in not in (1, -1, 2, -2, 3, -3, 4, -4) then T1.atenano end, --宛名番号 昇順
                 case when orderby_in = 1 then T1.atenano end,                                                      --宛名番号 昇順
                 case when orderby_in = -1 then T1.atenano end desc,                                                --宛名番号 降順
                 case when orderby_in = 2 then T2.simei_yusen end,                                                  --氏名_優先 昇順
                 case when orderby_in = -2 then T2.simei_yusen end desc,                                            --氏名_優先 降順
                 case when orderby_in = 3 then T3.taisyogairiyu end,                                                --発行対象外者対象外理由 昇順
                 case when orderby_in = -3 then T3.taisyogairiyu end desc,                                          --発行対象外者対象外理由 降順
                 case when orderby_in = 4 then T2.siensotikbn end,                                                  --支援措置区分 昇順
                 case when orderby_in = -4 then T2.siensotikbn end desc                                             --支援措置区分 降順
        limit limit_in offset offset_in;
end;

$$;

alter function sp_aweu00304g_01_body(bigint, varchar, integer, integer, integer) owner to postgres;

