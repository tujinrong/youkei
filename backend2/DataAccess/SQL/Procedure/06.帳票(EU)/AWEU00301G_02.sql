/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票出力(出力画面)
　　　　　　一覧抽出
作成日　　: 2024.03.12
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_aweu00301g_02_head(workseq_in bigint, rptgroupid_in character varying, tikukbn_in character varying) returns integer
    language plpgsql
as
$$
declare
    total integer;
begin
    select count(1)
    into total
    from wk_euatena_sub t1
             inner join tt_afatena t2 on t1.atenano = t2.atenano
    where t1.workseq = workseq_in;
    return total;
end;
$$;

/*==============================body==============================*/
create or replace function sp_aweu00301g_02_body(workseq_in bigint, rptgroupid_in character varying, tikukbn_in character varying, orderby_in integer, limit_in integer, offset_in integer)
    returns TABLE
            (
                formflg       boolean,
                atenano       character varying,
                personalno    character varying,
                simei_yusen   character varying,
                sex           character varying,
                bymdhyoki     character varying,
                gyoseikunm    character varying,
                juminkbn      character varying,
                taisyogairiyu character varying,
                siensotikbn   character varying,
                bymd_fusyoflg boolean
            )
    language plpgsql
as
$$
begin
    return query
        select t1.formflg       as formflg,      --出力フラグ
               t1.atenano       as atenano,      --宛名番号
               t2.personalno    as personalno,   --個人番号
               t2.simei_yusen   as simei_yusen,  --氏名_優先
               t2.sex           as sex,          --性別表記
               case t2.bymd_fusyoflg
                   when true then t2.bymd_fusyohyoki
                   else t2.bymd
                   end::varchar as bymdhyoki,    --生年月日表記
               t4.tikunm        as gyoseikunm,   --行政区
               t2.juminkbn      as juminkbn,     --住民区分
               t3.taisyogairiyu as taisyogairiyu,--発行対象外者対象外理由
               t2.siensotikbn   as siensotikbn,  --支援措置区分
               t2.bymd_fusyoflg as bymd_fusyoflg --生年月日_不詳フラグ
        from wk_euatena_sub t1
                 inner join tt_afatena t2 on t1.atenano = t2.atenano
                 left join tt_kkrpthakkotaisyogaisya t3 on t1.atenano = t3.atenano and t3.rptgroupid = rptgroupid_in
                 left join tm_aftiku t4 on t2.gyoseikucd = t4.tikucd and t4.tikukbn = tikukbn_in
        where t1.workseq = workseq_in
        order by case when orderby_in not in (1, -1, 3, -3, 4, -4, 5, -5, 6, -6, 7, -7, 8, -8, 9, -9) then t1.atenano end, --宛名番号 昇順
                 case when orderby_in = 1 then t1.atenano end,                                                             --宛名番号 昇順
                 case when orderby_in = -1 then t1.atenano end desc,                                                       --宛名番号 降順
                 case when orderby_in = 3 then t2.simei_yusen end,                                                         --氏名_優先 昇順
                 case when orderby_in = -3 then t2.simei_yusen end desc,                                                   --氏名_優先 降順
                 case when orderby_in = 4 then t2.sex end,                                                                 --性別 昇順
                 case when orderby_in = -4 then t2.sex end desc,                                                           --性別 降順
                 case when orderby_in = 5 then bymdhyoki end,                                                              --生年月日表記 昇順
                 case when orderby_in = -5 then bymdhyoki end desc,                                                        --生年月日表記 降順
                 case when orderby_in = 6 then t4.tikunm end,                                                              --行政区 昇順
                 case when orderby_in = -6 then t4.tikunm end desc,                                                        --行政区 降順
                 case when orderby_in = 7 then t2.juminkbn end,                                                            --住民区分 昇順
                 case when orderby_in = -7 then t2.juminkbn end desc,                                                      --住民区分 降順
                 case when orderby_in = 8 then t3.taisyogairiyu end,                                                       --発行対象外者対象外理由 昇順
                 case when orderby_in = -8 then t3.taisyogairiyu end desc,                                                 --発行対象外者対象外理由 降順
                 case when orderby_in = 9 then t2.siensotikbn end,                                                         --支援措置区分 昇順
                 case when orderby_in = -9 then t2.siensotikbn end desc                                                    --支援措置区分 降順
        limit limit_in offset offset_in;
end;
$$;