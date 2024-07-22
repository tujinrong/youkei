/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: パーセンタイル値保守
　　　　　　一覧抽出
作成日　　: 2024.06.01
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awbh00501g_01_head(buicd_in character varying, sex_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    SELECT
        count(1) total into total
  FROM ( 
    SELECT Y.buicd
      FROM ( 
        SELECT X.buicd
               , X.sex
               , X.month
               , X.date
               , X.p AS pasentairucd
               , COALESCE(C.pasentairuti, 0) AS pasentairuti 
           FROM ( 
             SELECT A.buicd
                    , A.sex
                    , A.month
                    , A.date
                    , B.p 
               FROM ( 
                 SELECT DISTINCT buicd
                               , sex
                               , month
                               , date 
                   FROM
                        tm_bhpasentairu
                    ) A
                  , ( 
                 SELECT
                        UNNEST (string_to_array('1,2,3,4,5,6,7,8', ',')) AS P
                    ) B
                ) X 
             LEFT JOIN ( 
               SELECT buicd
                      , sex
                      , month
                      , date
                      , pasentairucd
                      , pasentairuti 
                 FROM tm_bhpasentairu
                       ) C
                   ON X.buicd = C.buicd 
                  AND X.sex = C.sex 
                  AND X.month = C.month 
                  AND X.date = C.date 
                  AND X.p = C.pasentairucd 
                ORDER BY X.buicd
                       , X.sex
                       , X.month
                       , X.date
                       , X.p
           ) Y 
         WHERE (buicd_in IS NULL OR Y.buicd = buicd_in)
           AND (sex_in IS NULL OR Y.sex = sex_in)
     GROUP BY Y.buicd
            , Y.sex
            , Y.month
            , Y.date
       ) T;
       
    return total;
	
END$function$
/*==============================body==============================*/
CREATE OR REPLACE FUNCTION public.sp_awbh00501g_01_body(buicd_in character varying, sex_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(buicode character varying, sexcode character varying, tuki smallint, bi smallint, pasentairustd integer, pasentairu3p integer, pasentairu10p integer, pasentairu25p integer, pasentairu50p integer, pasentairu75p integer, pasentairu90p integer, pasentairu97p integer, prockbn integer)
 LANGUAGE plpgsql
AS $function$
BEGIN
    return query
    SELECT T.buicd AS buicode
           , T.sex AS sexcode
           , T.month AS tuki
           , T.date AS bi
           , SPLIT_PART(T.pasentairucd_agg, ',', 2) ::integer AS pasentairustd
           , SPLIT_PART(T.pasentairucd_agg, ',', 4) ::integer AS pasentairu3p
           , SPLIT_PART(T.pasentairucd_agg, ',', 6) ::integer AS pasentairu10p
           , SPLIT_PART(T.pasentairucd_agg, ',', 8) ::integer AS pasentairu25p
           , SPLIT_PART(T.pasentairucd_agg, ',', 10) ::integer AS pasentairu50p
           , SPLIT_PART(T.pasentairucd_agg, ',', 12) ::integer AS pasentairu75p
           , SPLIT_PART(T.pasentairucd_agg, ',', 14) ::integer AS pasentairu90p
           , SPLIT_PART(T.pasentairucd_agg, ',', 16) ::integer AS pasentairu97p
           ,3 AS prockbn
      FROM ( 
        SELECT Y.buicd
               , Y.sex
               , Y.month
               , Y.date
               , string_agg(Y.pasentairucd ::text || ',' || Y.pasentairuti ::text, ',') AS pasentairucd_agg 
          FROM ( 
            SELECT X.buicd
                   , X.sex
                   , X.month
                   , X.date
                   , X.p AS pasentairucd
                   , COALESCE(C.pasentairuti, 0) AS pasentairuti 
               FROM ( 
                 SELECT A.buicd
                        , A.sex
                        , A.month
                        , A.date
                        , B.p 
                   FROM ( 
                     SELECT DISTINCT buicd
                                   , sex
                                   , month
                                   , date 
                       FROM
                            tm_bhpasentairu
                        ) A
                      , ( 
                     SELECT
                            UNNEST (string_to_array('1,2,3,4,5,6,7,8', ',')) AS P
                        ) B
                    ) X 
                 LEFT JOIN ( 
                   SELECT buicd
                          , sex
                          , month
                          , date
                          , pasentairucd
                          , pasentairuti 
                     FROM tm_bhpasentairu
                           ) C
                       ON X.buicd = C.buicd 
                      AND X.sex = C.sex 
                      AND X.month = C.month 
                      AND X.date = C.date 
                      AND X.p = C.pasentairucd 
                    ORDER BY X.buicd
                           , X.sex
                           , X.month
                           , X.date
                           , X.p
               ) Y 
         WHERE (buicd_in IS NULL OR Y.buicd = buicd_in)
           AND (sex_in IS NULL OR Y.sex = sex_in)
         GROUP BY Y.buicd
                , Y.sex
                , Y.month
                , Y.date
           ) T 

     ORDER BY
         case when orderby_in = 0 then T.month end                    --月  昇順（デフォルト）
        ,case when orderby_in = 0 then T.date end                     --日  昇順（デフォルト）
        ,case when orderby_in = 1 then T.month end                    --月  昇順
        ,case when orderby_in = -1 then T.month end desc              --月  降順
        ,case when orderby_in = 2 then T.date end                     --日 昇順
        ,case when orderby_in = -2 then T.date end desc               --日 降順
        ,case when orderby_in = 3 then SPLIT_PART(T.pasentairucd_agg, ',', 2) ::integer  end          --パーセンタイル標準  昇順
        ,case when orderby_in = -3 then SPLIT_PART(T.pasentairucd_agg, ',', 2) ::integer end desc     --パーセンタイル標準  降順
        ,case when orderby_in = 4 then SPLIT_PART(T.pasentairucd_agg, ',', 4) ::integer  end          --パーセンタイル3P    昇順
        ,case when orderby_in = -4 then SPLIT_PART(T.pasentairucd_agg, ',', 4) ::integer end desc     --パーセンタイル3P    降順
        ,case when orderby_in = 5 then SPLIT_PART(T.pasentairucd_agg, ',', 6) ::integer  end          --パーセンタイル10P   昇順
        ,case when orderby_in = -5 then SPLIT_PART(T.pasentairucd_agg, ',', 6) ::integer end desc     --パーセンタイル10P   降順
        ,case when orderby_in = 6 then SPLIT_PART(T.pasentairucd_agg, ',', 8) ::integer  end          --パーセンタイル25P   昇順
        ,case when orderby_in = -6 then SPLIT_PART(T.pasentairucd_agg, ',', 8) ::integer end desc     --パーセンタイル25P   降順
        ,case when orderby_in = 7 then SPLIT_PART(T.pasentairucd_agg, ',', 10) ::integer  end         --パーセンタイル50P   昇順
        ,case when orderby_in = -7 then SPLIT_PART(T.pasentairucd_agg, ',', 10) ::integer end desc    --パーセンタイル50P   降順
        ,case when orderby_in = 8 then SPLIT_PART(T.pasentairucd_agg, ',', 12) ::integer  end         --パーセンタイル75P   昇順
        ,case when orderby_in = -8 then SPLIT_PART(T.pasentairucd_agg, ',', 12) ::integer end desc    --パーセンタイル75P   降順
        ,case when orderby_in = 9 then SPLIT_PART(T.pasentairucd_agg, ',', 14) ::integer  end         --パーセンタイル90P   昇順
        ,case when orderby_in = -9 then SPLIT_PART(T.pasentairucd_agg, ',', 14) ::integer end desc    --パーセンタイル90P   降順
        ,case when orderby_in = 10 then SPLIT_PART(T.pasentairucd_agg, ',', 16) ::integer  end        --パーセンタイル97P   昇順
        ,case when orderby_in = -10 then SPLIT_PART(T.pasentairucd_agg, ',', 16) ::integer end desc   --パーセンタイル97P   降順

    limit limit_in offset offset_in

    ;

END$function$