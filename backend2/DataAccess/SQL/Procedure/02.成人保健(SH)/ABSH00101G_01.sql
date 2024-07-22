/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 一時対象サインデータ作成
　　　　　　
作成日　　: 2024.02.12
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_absh00101g_01(nendo_in integer)
returns void
language plpgsql
as $function$    
declare
    column_list text;
begin
    select string_agg(column_name, ', ') 
    into column_list
    from (
        select distinct column_name 
        from information_schema.columns
        where table_name = 'tt_shkensinrirekikanri_' || nendo_in and ordinal_position not in (1, 5));

    execute format('
        delete from tt_shkensinrirekikanri_%s;
        insert into tt_shkensinrirekikanri_%s (nendo,%s,taisyoflg)
        select %s as nendo,%s,taisyoflg
        from (
            select 
                t1.atenano,
                m1.jigyocd,
                m1.kensahohocd,
                case 
                    --①性別条件「すべて」（※説明：性別条件「すべて」の時にtm_shnendoテーブルsexの値はNULL）
                    --②性別条件「1男」かつ対象者性別「1男」、性別条件「2女」かつ対象者性別「2女」
                    --上記①②の場合：一時対象サインを「1」(対象に設定)
                    when ((m1.sex is null) or (t1.sex = ''1'' or t1.sex = ''2'')) then ''1''
                    --性別条件「1男、2女」、対象者性別「1男2女以外」の場合：一時対象サインを「9」(対象に設定)
                    else ''9''
                end as taisyoflg
            from tt_afatena t1
            left join tm_shnendo m1
            on m1.nendo = %s
            where 
                cast(t1.juminkbn as integer) < 5                                      --除票、住登外除票は作成対象外
                and ((m1.sex is null) 
                      or (m1.sex = t1.sex)
                      or (t1.sex <> ''1'' and t1.sex <> ''2''))                       --性別判断（※説明：tm_shnendoテーブル、sexの値「1,2,NULL」のみ）
                --and fn_shgetageflg(t1.bymd, t1.bymd_fusyoflg, m1.kijunymd, m1.age)  --年齢判断（一旦削除）
                and ((m1.hokenkbn is null) or m1.hokenkbn = t1.hokenkbn)              --保険区分判断
                and (case                                                             --特殊判断
                        when m1.tokusyu = ''1'' 
                            then (fn_shgetsp1flg(m1.jigyocd, m1.kensahohocd, t1.atenano, %s) = false)
                        else true
                    end)
                and (case                                                             --SQL判断
                        when m1.sql is not null
                            then  t1.atenano in(select atenano from fn_shgetatenano(m1.sql))
                        else true
                    end)
        )', nendo_in, nendo_in, column_list, nendo_in, column_list, nendo_in, nendo_in);
end;
$function$