/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業実施報告書（日報）管理
　　　　　　一覧抽出
作成日　　: 2023.11.20
作成者　　: 陳
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function public.sp_awkk00501g_01_head(jissiymdf_in character varying, jissiymdt_in character varying, kaijocd_in character varying, jigyocd_in character varying, staffid_in character varying)
    returns integer
    language plpgsql
as $function$
declare total integer;
begin
    select count(1) total into total
    from(
    select t1.hokokusyono
    from tt_kkjissihokokusyo t1
        left join tm_afkaijo t2 on t1.kaijocd = t2.kaijocd and t2.stopflg = false
        left join tm_afhanyo t3 on t1.jigyocd = t3.hanyocd
            and t3.stopflg = false
            and t3.hanyomaincd = '3019'                     --実施報告事業コード
            and t3.hanyosubcd = 100004                      --実施報告事業コード
        left join tt_kkjissihokokusyo_sub t4 on t4.hokokusyono = t1.hokokusyono
        left join tm_afstaff t5 on t4.staffid = t5.staffid and t5.stopflg = false
        left join tm_afuser t6 on t1.upduserid = t6.userid and t6.stopflg = false
        left join tm_afhanyo t7 on t1.regsisyo = t7.hanyocd
            and t7.stopflg = false
            and t7.hanyomaincd = '3019'
            and t7.hanyosubcd = 1
        where
          (jissiymdf_in is null or jissiymdf_in = '' or t1.jissiymd >= jissiymdf_in)
          and (jissiymdt_in is null or jissiymdt_in = '' or t1.jissiymd <= jissiymdt_in)
          and (kaijocd_in is null or kaijocd_in = '' or t1.kaijocd = kaijocd_in)
          and (jigyocd_in is null or jigyocd_in = '' or t1.jigyocd = jigyocd_in)
        group by
            t1.hokokusyono,
            t1.jissiymd,
            t1.timef,
            t1.timet,
            t2.kaijonm,
            t3.nm,
            t1.upddttm,
            t6.usernm,
            t7.nm
        having
            staffid_in is null or staffid_in = '' or staffid_in = any(string_to_array(string_agg(t4.staffid, ','),','))
        )T;
    return total;
end;
$function$;
/*==============================body==============================*/
create or replace function public.sp_awkk00501g_01_body(jissiymdf_in character varying, jissiymdt_in character varying, kaijocd_in character varying, jigyocd_in character varying, staffid_in character varying, orderby_in integer, limit_in integer, offset_in integer)
    returns table
        (hokokusyono bigint, 
         jissiymd character varying, 
         timef character varying, 
         timet character varying, 
         kaijonm character varying, 
         jigyonm character varying, 
         upddttm timestamp without time zone, 
         updusernm character varying, 
         regsisyo character varying, 
         staffnm text)
    language plpgsql
as $function$
begin
    return query
        select
            t1.hokokusyono                  as hokokusyono, --事業報告書番号
            t1.jissiymd                     as jissiymd,    --実施日
            t1.timef                        as timef,       --開始時間
            t1.timet                        as timet,       --終了時間
            t2.kaijonm                      as kaijonm,     --会場名
            t3.nm                           as jigyonm,     --事業名
            t1.upddttm                      as upddttm,     --更新日時
            t6.usernm                       as updusernm,   --更新者
            t7.nm                           as regsisyo,    --登録支所
            string_agg(t5.staffsimei, ',')  as staffnm      --従事者
        from tt_kkjissihokokusyo t1
        left join tm_afkaijo t2 on t1.kaijocd = t2.kaijocd and t2.stopflg = false
        left join tm_afhanyo t3 on t1.jigyocd = t3.hanyocd
            and t3.stopflg = false
            and t3.hanyomaincd = '3019'                     --実施報告事業コード
            and t3.hanyosubcd = 100004                      --実施報告事業コード
        left join tt_kkjissihokokusyo_sub t4 on t4.hokokusyono = t1.hokokusyono
        left join tm_afstaff t5 on t4.staffid = t5.staffid and t5.stopflg = false
        left join tm_afuser t6 on t1.upduserid = t6.userid and t6.stopflg = false
        left join tm_afhanyo t7 on t1.regsisyo = t7.hanyocd
            and t7.stopflg = false
            and t7.hanyomaincd = '3019'
            and t7.hanyosubcd = 1
        where
          (jissiymdf_in is null or jissiymdf_in = '' or t1.jissiymd >= jissiymdf_in)
          and (jissiymdt_in is null or jissiymdt_in = '' or t1.jissiymd <= jissiymdt_in)
          and (kaijocd_in is null or kaijocd_in = '' or t1.kaijocd = kaijocd_in)
          and (jigyocd_in is null or jigyocd_in = '' or t1.jigyocd = jigyocd_in)
        group by
            t1.hokokusyono,
            t1.jissiymd,
            t1.timef,
            t1.timet,
            t2.kaijonm,
            t3.nm,
            t1.upddttm,
            t6.usernm,
            t7.nm
        having
            staffid_in is null or staffid_in = '' or staffid_in = any(string_to_array(string_agg(t4.staffid, ','),','))
        order by
            case when orderby_in = 0 then t1.hokokusyono end desc                   --事業報告書番号    降順（ディフォルト順）
               ,case when orderby_in = 1 then t1.hokokusyono  end			        --事業報告書番号	昇順
               ,case when orderby_in = -1 then t1.hokokusyono  end desc	            --事業報告書番号	降順
               ,case when orderby_in = 2 then t1.jissiymd end 		                --実施日	        昇順
               ,case when orderby_in = -2 then t1.jissiymd end desc                 --実施日	        降順
               ,case when orderby_in = 3 then concat(t1.timef, t1.timet) end		--時間	            昇順
               ,case when orderby_in = -3 then concat(t1.timef, t1.timet) end desc	--時間	            降順
               ,case when orderby_in = 4 then t2.kaijonm end				        --会場名	        昇順
               ,case when orderby_in = -4 then t2.kaijonm end desc		            --会場名	        降順
               ,case when orderby_in = 5 then t3.nm end				                --事業名	        昇順
               ,case when orderby_in = -5 then t3.nm end desc		                --事業名	        降順
               ,case when orderby_in = 6 then staffnm end				            --従事者	        昇順
               ,case when orderby_in = -6 then staffnm end desc			            --従事者	        降順
               ,case when orderby_in = 7 then t1.upddttm end				        --更新日時	        昇順
               ,case when orderby_in = -7 then t1.upddttm end desc		            --更新日時	        降順
               ,case when orderby_in = 8 then t6.usernm end				            --更新者            昇順
               ,case when orderby_in = -8 then t6.usernm end desc			        --更新者	        降順
               ,case when orderby_in = 9 then t7.nm end				                --登録支所	        昇順
               ,case when orderby_in = -9 then t7.nm end desc			            --登録支所	        降順
        limit limit_in offset offset_in;
end;
$function$;