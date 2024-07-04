/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 健（検）診結果・保健指導履歴照会
　　　　　　一覧抽出
作成日　　: 2024.02.20
作成者　　: CNC劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00610d_01_head(atenano_in character varying)
 returns integer
 language plpgsql
as $function$
declare total integer;
begin
   select
        count(1) total into total
    from
   (
   (
   select
            t1.jissiymd as ksymd,                                                       --健（検）診年月日
            '1' as kskbn,                                                               --一次
            t1.kensahohocd,                                                             --検査方法
            null as hokensidokbn,                                                       --保健指導区分
            null as gyomukbn,                                                           --業務区分
            t1.jigyocd,                                                                 --事業コード
            null as jissiymd,                                                           --実施日
            null as tmf,                                                                --開始時間
            null as tmt,                                                                --終了時間
            null as jissistaffid,                                                       --実施者
            t1.kensinkaisu,                                                             --検診回数
            0 as edano,                                                                 --枝番
            1 as sortid,                                                                --ソート分類
            nendo                                                                       --年度
            from (
                select
                      jigyocd,                                                          --事業コード
                      jissiymd,                                                         --健（検）診年月日
                      atenano,                                                          --宛名番号
                      kensahohocd,                                                      --検査方法
                      kensinkaisu,                                                      --検診回数
                      nendo                                                             --年度
                from tt_shkensin                                                        --成人保健一次検診結果（固定項目）テーブル
                where tt_shkensin.atenano = atenano_in
                 ) t1                            
   )
   union all
   (
   select
          t1.jissiymd as ksymd,                                                         --健（検）診年月日
          '2' as kskbn,                                                                 --精密
          t1.kensahohocd,                                                               --検査方法
          null as hokensidokbn,                                                         --保健指導区分
          null as gyomukbn,                                                             --業務区分
          t1.jigyocd,                                                                   --事業コード
          null as jissiymd,                                                             --実施日
          null as tmf,                                                                  --開始時間
          null as tmt,                                                                  --終了時間
          null as jissistaffid,                                                         --実施者
          t1.kensinkaisu,                                                               --検診回数
          0 as edano,                                                                   --枝番
          2 as sortid,                                                                  --ソート分類
          nendo                                                                         --年度
          from (
                select
                      jigyocd,                                                          --事業コード
                      jissiymd,                                                         --健（検）診年月日
                      atenano,                                                          --宛名番号
                      null as kensahohocd,                                              --検査方法
                      kensinkaisu,                                                      --検診回数
                      nendo                                                             --年度
                from tt_shseiken                                                        --成人保健精密検査結果（固定項目）テーブル
                where tt_shseiken.atenano = atenano_in
                 ) t1                            
   )
   union all
   (
   select
          null as ksymd,                                                                --健（検）診年月日
          null as kskbn,                                                                --一次 / 精密
          null as kensahohocd,                                                          --検査方法
          t1.hokensidokbn as hokensidokbn,                                              --保健指導区分
          t1.gyomukbn as gyomukbn,                                                      --業務区分
          t1.jigyocd,                                                                   --事業コード
          t1.jissiymd as jissiymd,                                                      --実施日
          t1.tmf as tmf,                                                                --開始時間
          t1.tmt as tmt,                                                                --終了時間
          staff.jissistaffid as jissistaffid,                                           --実施者
          0 as kensinkaisu,                                                             --検診回数
          t1.edano,                                                                     --枝番
          3 as sortid,                                                                  --ソート分類
          0 as nendo                                                                    --年度
          from (
                select
                      atenano,                                                          --宛名番号
                      edano,                                                            --枝番
                      jigyocd,                                                          --事業コード
                      hokensidokbn,                                                     --保健指導区分
                      gyomukbn,                                                         --業務区分
                      jissiymd,                                                         --実施日
                      tmf,                                                              --開始時間
                      tmt                                                               --終了時間
                from tt_kkhokensido_kekka                                               --保健指導結果情報（固定項目）テーブル
                where tt_kkhokensido_kekka.atenano = atenano_in
                 ) t1  
   left join
          (select
                 hokensidokbn,                                                          --保健指導区分
                 gyomukbn,                                                              --業務区分
                 atenano,                                                               --宛名番号
                 edano,                                                                 --枝番
                 string_agg(tt_kkhokensido_staff.staffid, ',') as jissistaffid          --担当者
           from
                 tt_kkhokensido_staff                                                   --保健指導担当者テーブル
           group by
                   hokensidokbn,                                                        --保健指導区分
                   gyomukbn,                                                            --業務区分
                   atenano,                                                             --宛名番号
                   edano                                                                --枝番
           ) staff
          on t1.hokensidokbn = staff.hokensidokbn                                       --保健指導区分
          and t1.gyomukbn = staff.gyomukbn                                              --業務区分
          and t1.atenano = staff.atenano                                                --宛名番号
          and t1.edano = staff.edano                                                    --枝番
   )
   union all
   (
   select
          null as ksymd,                                                                --健（検）診年月日
          null as kskbn,                                                                --一次 / 精密
          null as kensahohocd,                                                          --検査方法
          '3' as hokensidokbn,                                                          --保健指導区分
          tt_kksyudansido_kekka.gyomukbn as gyomukbn,                                   --業務区分
          tt_kksyudansido_kekka.jigyocd,                                                --事業コード
          tt_kksyudansido_kekka.jissiymd as jissiymd,                                   --実施日
          tt_kksyudansido_kekka.tmf as tmf,                                             --開始時間
          tt_kksyudansido_kekka.tmt as tmt,                                             --終了時間
          staff.jissistaffid as jissistaffid,                                           --実施者
          0 as kensinkaisu,                                                             --検診回数
          t1.edano,                                                                     --枝番
          4 as sortid,                                                                  --ソート分類
          0 as nendo                                                                    --年度
          from(
                select
                      atenano,                                                          --宛名番号
                      gyomukbn,                                                         --業務区分
                      edano                                                             --枝番
                from
                    tt_kksyudansido_sankasya                                            --集団指導参加者テーブル
                where tt_kksyudansido_sankasya.atenano = atenano_in
               ) t1
   left join tt_kksyudansido_kekka                                                      --集団指導結果情報（固定項目）テーブル
          on t1.gyomukbn = tt_kksyudansido_kekka.gyomukbn                               --業務区分
          and t1.edano = tt_kksyudansido_kekka.edano                                    --枝番
   left join
          (select
                 gyomukbn,                                                              --業務区分
                 edano,                                                                 --枝番
                 string_agg(tt_kksyudansido_staff.staffid, ',') as jissistaffid         --担当者
           from
                 tt_kksyudansido_staff                                                  --集団指導担当者テーブル
           group by
                  gyomukbn,                                                             --業務区分
                  edano                                                                 --枝番
           ) staff
          on tt_kksyudansido_kekka.gyomukbn = staff.gyomukbn                            --業務区分
          and tt_kksyudansido_kekka.edano = staff.edano                                 --枝番
   )
) as subquery;                                                                          --四つのテーブルのクエリ結果セット                                                                  --四つのテーブルのクエリ結果セット
return total;
end;
$function$

/*==============================body==============================*/
create or replace function sp_awaf00610d_01_body(atenano_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 returns table(
         ksymd character varying,                                                              --健（検）診年月日
         kskbn text,                                                                   --一次 / 精密
         kensahohocd character varying,                                                --検査方法
         hokensidokbn text,                                                            --保健指導区分
         gyomukbn text,                                                                --業務区分
         jigyocd character varying,                                                    --事業コード
         jissiymd text,                                                                --実施日
         tmf text,                                                                     --開始時間
         tmt text,                                                                     --終了時間
         jissistaffid text,                                                            --実施者
         kensinkaisu integer,                                                          --検診回数
         edano integer,                                                                --枝番
         sortid integer,
         nendo integer)                                                                --年度
 language plpgsql
as $function$
#variable_conflict use_column
begin
    return query
    select
        ksymd as ksymd,                                                                --健（検）診年月日
        kskbn as kskbn,                                                                --一次 / 精密
        kensahohocd as kensahohocd,                                                    --検査方法
        hokensidokbn as hokensidokbn,                                                  --保健指導区分
        gyomukbn as gyomukbn,                                                          --業務区分
        jigyocd as jigyocd,                                                            --事業コード
        jissiymd as jissiymd,                                                          --実施日
        tmf as tmf,                                                                    --開始時間
        tmt as tmt,                                                                    --終了時間
        jissistaffid as jissistaffid,                                                  --実施者
        kensinkaisu as kensinkaisu,                                                    --検診回数
        edano as edano,                                                                --枝番
        sortid,                                                                        --ソート分類
        nendo                                                                          --年度
   from
   (
   (
   select
            t1.jissiymd as ksymd,                                                       --健（検）診年月日
            '1' as kskbn,                                                               --一次
            t1.kensahohocd,                                                             --検査方法
            null as hokensidokbn,                                                       --保健指導区分
            null as gyomukbn,                                                           --業務区分
            t1.jigyocd,                                                                 --事業コード
            null as jissiymd,                                                           --実施日
            null as tmf,                                                                --開始時間
            null as tmt,                                                                --終了時間
            null as jissistaffid,                                                       --実施者
            t1.kensinkaisu,                                                             --検診回数
            0 as edano,                                                                 --枝番
            1 as sortid,                                                                --ソート分類
            nendo                                                                       --年度
            from (
                select
                      jigyocd,                                                          --事業コード
                      jissiymd,                                                         --健（検）診年月日
                      atenano,                                                          --宛名番号
                      kensahohocd,                                                      --検査方法
                      kensinkaisu,                                                      --検診回数
                      nendo                                                             --年度
                from tt_shkensin                                                        --成人保健一次検診結果（固定項目）テーブル
                where tt_shkensin.atenano = atenano_in
                 ) t1                            
   )
   union all
   (
   select
          t1.jissiymd as ksymd,                                                         --健（検）診年月日
          '2' as kskbn,                                                                 --精密
          t1.kensahohocd,                                                               --検査方法
          null as hokensidokbn,                                                         --保健指導区分
          null as gyomukbn,                                                             --業務区分
          t1.jigyocd,                                                                   --事業コード
          null as jissiymd,                                                             --実施日
          null as tmf,                                                                  --開始時間
          null as tmt,                                                                  --終了時間
          null as jissistaffid,                                                         --実施者
          t1.kensinkaisu,                                                               --検診回数
          0 as edano,                                                                   --枝番
          2 as sortid,                                                                  --ソート分類
          nendo                                                                         --年度
          from (
                select
                      jigyocd,                                                          --事業コード
                      jissiymd,                                                         --健（検）診年月日
                      atenano,                                                          --宛名番号
                      null as kensahohocd,                                              --検査方法
                      kensinkaisu,                                                      --検診回数
                      nendo                                                             --年度
                from tt_shseiken                                                        --成人保健精密検査結果（固定項目）テーブル
                where tt_shseiken.atenano = atenano_in
                 ) t1                            
   )
   union all
   (
   select
          null as ksymd,                                                                --健（検）診年月日
          null as kskbn,                                                                --一次 / 精密
          null as kensahohocd,                                                          --検査方法
          t1.hokensidokbn as hokensidokbn,                                              --保健指導区分
          t1.gyomukbn as gyomukbn,                                                      --業務区分
          t1.jigyocd,                                                                   --事業コード
          t1.jissiymd as jissiymd,                                                      --実施日
          t1.tmf as tmf,                                                                --開始時間
          t1.tmt as tmt,                                                                --終了時間
          staff.jissistaffid as jissistaffid,                                           --実施者
          0 as kensinkaisu,                                                             --検診回数
          t1.edano,                                                                     --枝番
          3 as sortid,                                                                  --ソート分類
          0 as nendo                                                                    --年度
          from (
                select
                      atenano,                                                          --宛名番号
                      edano,                                                            --枝番
                      jigyocd,                                                          --事業コード
                      hokensidokbn,                                                     --保健指導区分
                      gyomukbn,                                                         --業務区分
                      jissiymd,                                                         --実施日
                      tmf,                                                              --開始時間
                      tmt                                                               --終了時間
                from tt_kkhokensido_kekka                                               --保健指導結果情報（固定項目）テーブル
                where tt_kkhokensido_kekka.atenano = atenano_in
                 ) t1  
   left join
          (select
                 hokensidokbn,                                                          --保健指導区分
                 gyomukbn,                                                              --業務区分
                 atenano,                                                               --宛名番号
                 edano,                                                                 --枝番
                 string_agg(tt_kkhokensido_staff.staffid, ',') as jissistaffid          --担当者
           from
                 tt_kkhokensido_staff                                                   --保健指導担当者テーブル
           group by
                   hokensidokbn,                                                        --保健指導区分
                   gyomukbn,                                                            --業務区分
                   atenano,                                                             --宛名番号
                   edano                                                                --枝番
           ) staff
          on t1.hokensidokbn = staff.hokensidokbn                                       --保健指導区分
          and t1.gyomukbn = staff.gyomukbn                                              --業務区分
          and t1.atenano = staff.atenano                                                --宛名番号
          and t1.edano = staff.edano                                                    --枝番
   )
   union all
   (
   select
          null as ksymd,                                                                --健（検）診年月日
          null as kskbn,                                                                --一次 / 精密
          null as kensahohocd,                                                          --検査方法
          '3' as hokensidokbn,                                                          --保健指導区分
          tt_kksyudansido_kekka.gyomukbn as gyomukbn,                                   --業務区分
          tt_kksyudansido_kekka.jigyocd,                                                --事業コード
          tt_kksyudansido_kekka.jissiymd as jissiymd,                                   --実施日
          tt_kksyudansido_kekka.tmf as tmf,                                             --開始時間
          tt_kksyudansido_kekka.tmt as tmt,                                             --終了時間
          staff.jissistaffid as jissistaffid,                                           --実施者
          0 as kensinkaisu,                                                             --検診回数
          t1.edano,                                                                     --枝番
          4 as sortid,                                                                  --ソート分類
          0 as nendo                                                                    --年度
          from(
                select
                      atenano,                                                          --宛名番号
                      gyomukbn,                                                         --業務区分
                      edano                                                             --枝番
                from
                    tt_kksyudansido_sankasya                                            --集団指導参加者テーブル
                where tt_kksyudansido_sankasya.atenano = atenano_in
               ) t1
   left join tt_kksyudansido_kekka                                                      --集団指導結果情報（固定項目）テーブル
          on t1.gyomukbn = tt_kksyudansido_kekka.gyomukbn                               --業務区分
          and t1.edano = tt_kksyudansido_kekka.edano                                    --枝番
   left join
          (select
                 gyomukbn,                                                              --業務区分
                 edano,                                                                 --枝番
                 string_agg(tt_kksyudansido_staff.staffid, ',') as jissistaffid         --担当者
           from
                 tt_kksyudansido_staff                                                  --集団指導担当者テーブル
           group by
                  gyomukbn,                                                             --業務区分
                  edano                                                                 --枝番
           ) staff
          on tt_kksyudansido_kekka.gyomukbn = staff.gyomukbn                            --業務区分
          and tt_kksyudansido_kekka.edano = staff.edano                                 --枝番
   )
) as subquery                                                                           --四つのテーブルのクエリ結果セット
    order by
         case when orderby_in = 0 then sortid end                                       --ソート分類         昇順
        ,case when orderby_in = 0 then ksymd end desc                                   --実施時年齢         昇順
        ,case when orderby_in = 0 then jigyocd end                                      --事業コード         昇順
        ,case when orderby_in = 0 then kensinkaisu end                                  --検診回数           昇順
        ,case when orderby_in = 0 then jissiymd end desc                                --実施日             降順
        ,case when orderby_in = 0 then tmf end desc                                     --開始時間           降順
        ,case when orderby_in = 0 then tmt end desc                                     --終了時間           降順
        ,case when orderby_in = 0 then hokensidokbn end                                 --保健指導区分       昇順
        ,case when orderby_in = 0 then gyomukbn end                                     --業務区分           昇順
        ,case when orderby_in = 0 then edano end                                        --枝番               昇順
        ,case when orderby_in = 1 then ksymd end                                        --実施時年齢         昇順
        ,case when orderby_in = -1 then ksymd end desc                                  --実施時年齢         降順
        ,case when orderby_in = 2 then jigyocd end                                      --健（検）診種別     昇順
        ,case when orderby_in = -2 then jigyocd end desc                                --健（検）診種別     降順
        ,case when orderby_in = 3 then ksymd end                                        --健（検）診年月日   昇順
        ,case when orderby_in = -3 then ksymd end desc                                  --健（検）診年月日   降順
        ,case when orderby_in = 4 then kskbn end                                        --一次 / 精密        昇順
        ,case when orderby_in = -4 then kskbn end desc                                  --一次 / 精密        降順
        ,case when orderby_in = 5 then kensahohocd end                                  --検査方法           昇順
        ,case when orderby_in = -5 then kensahohocd end desc                            --検査方法           降順
        ,case when orderby_in = 6 then hokensidokbn || gyomukbn end                    --保健指導区分       昇順
        ,case when orderby_in = -6 then hokensidokbn || gyomukbn end desc              --保健指導区分       降順
        ,case when orderby_in = 7 then jigyocd end                                      --事業名             昇順
        ,case when orderby_in = -7 then jigyocd end desc                                --事業名             降順
        ,case when orderby_in = 8 then jissistaffid end                                 --実施者             昇順
        ,case when orderby_in = -8 then jissistaffid end desc                           --実施者             降順
    limit limit_in offset offset_in;
end;
$function$