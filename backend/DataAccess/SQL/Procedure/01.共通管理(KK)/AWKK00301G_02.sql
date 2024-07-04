/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 保健指導管理
　　　　　　一覧抽出
作成日　　: 2023.12.13
作成者　　: 張
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awkk00301g_02_head(atenano_in character varying, hokensidokbn_in character varying, gyomukbn_in character varying, jigyocd_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    SELECT
        count(1) total into total
      FROM tt_kkhokensido_mosikomi X
        FULl OUTER JOIN tt_kkhokensido_kekka Y
          ON Y.hokensidokbn = X.hokensidokbn
         AND Y.gyomukbn = X.gyomukbn
         AND Y.atenano = X.atenano
         AND Y.edano = X.edano
     
        LEFT JOIN tm_afkaijo K1
          ON K1.kaijocd = X.kaijocd
     
        LEFT JOIN tm_afkaijo K2
          ON K2.kaijocd = Y.kaijocd
        
        LEFT JOIN tt_afatena C
          ON C.atenano = X.atenano
     
        LEFT JOIN (
               SELECT
                     D.hokensidokbn
                    ,D.gyomukbn
                    ,D.atenano
                    ,D.edano
                    ,D.mosikomikekkakbn
                    ,STRING_AGG(E.staffsimei, ', ') AS yoteisya
                 FROM tt_kkhokensido_staff D
                   LEFT JOIN tm_afstaff E
                     ON E.staffid = D.staffid
                GROUP BY
                     D.hokensidokbn
                    ,D.gyomukbn
                    ,D.atenano
                    ,D.edano
                    ,D.mosikomikekkakbn
                  ) TM
          ON TM.hokensidokbn = X.hokensidokbn
         AND TM.gyomukbn = X.gyomukbn
         AND TM.atenano = X.atenano
         AND TM.edano = X.edano
         AND TM.mosikomikekkakbn = '1'
    
        LEFT JOIN (
               SELECT
                     D.hokensidokbn
                    ,D.gyomukbn
                    ,D.atenano
                    ,D.edano
                    ,D.mosikomikekkakbn
                    ,STRING_AGG(E.staffsimei, ', ') AS jissisya
                 FROM tt_kkhokensido_staff D
                   LEFT JOIN tm_afstaff E
                     ON E.staffid = D.staffid
                GROUP BY
                     D.hokensidokbn
                    ,D.gyomukbn
                    ,D.atenano
                    ,D.edano
                    ,D.mosikomikekkakbn
                  ) TK
          ON TK.hokensidokbn = Y.hokensidokbn
         AND TK.gyomukbn = Y.gyomukbn
         AND TM.atenano = X.atenano
         AND TK.edano = Y.edano
         AND TK.mosikomikekkakbn = '2'
     WHERE
          1 = 1
       AND (atenano_in is null or (X.atenano = atenano_in OR Y.atenano = atenano_in))
       AND (hokensidokbn_in is null or (X.hokensidokbn = hokensidokbn_in or Y.hokensidokbn = hokensidokbn_in))
       AND (gyomukbn_in is null or (X.gyomukbn = gyomukbn_in or Y.gyomukbn = gyomukbn_in))
       AND (jigyocd_in is null or (X.jigyocd = jigyocd_in or Y.jigyocd = jigyocd_in));


    return total;
	
END$function$
/*==============================body==============================*/
CREATE OR REPLACE FUNCTION public.sp_awkk00301g_02_body(atenano_in character varying, hokensidokbn_in character varying, gyomukbn_in character varying, jigyocd_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(atenano character varying, gyomukbn character varying, jigyocd character varying, edano integer, yoteiymd character varying, yoteitm character varying, yoteikaijo character varying, yoteisya text, jissiymd character varying, jissitm text, bymd character varying, bymd_fusyoflg boolean, bymd_fusyohyoki character varying, jissikaijo character varying, jissisya text)
 LANGUAGE plpgsql
AS $function$
BEGIN
    return query
    SELECT
       Z.atenano
      ,Z.gyomukbn
      ,Z.jigyocd
      ,Z.edano
      ,Z.yoteiymd
      ,Z.yoteitm
      ,Z.yoteikaijo
      ,Z.yoteisya
      ,Z.jissiymd
      ,CASE WHEN Z.jissitm = '～' THEN '' ELSE Z.jissitm END AS jissitm
      ,Z.bymd
      ,Z.bymd_fusyoflg
      ,Z.bymd_fusyohyoki
      ,Z.jissikaijo
      ,Z.jissisya
      FROM (
        SELECT
              CASE WHEN X.atenano IS NOT NULL THEN X.atenano ELSE Y.atenano END AS atenano
             ,CASE WHEN X.gyomukbn IS NOT NULL THEN X.gyomukbn ELSE Y.gyomukbn END AS gyomukbn
             ,CASE WHEN X.jigyocd IS NOT NULL THEN X.jigyocd ELSE Y.jigyocd END AS jigyocd
             ,CASE WHEN X.edano IS NOT NULL THEN X.edano ELSE Y.edano END AS edano
             ,X.yoteiymd
             ,X.yoteitm
             ,K1.kaijonm AS yoteikaijo
             ,TM.yoteisya
             ,Y.jissiymd
             ,COALESCE(Y.tmf,'') || '～' || COALESCE(Y.tmt,'') AS jissitm
             ,C.bymd
             ,C.bymd_fusyoflg
             ,C.bymd_fusyohyoki
             ,K2.kaijonm AS jissikaijo
             ,TK.jissisya
          FROM tt_kkhokensido_mosikomi X
            FULl OUTER JOIN tt_kkhokensido_kekka Y
              ON Y.hokensidokbn = X.hokensidokbn
             AND Y.gyomukbn = X.gyomukbn
             AND Y.atenano = X.atenano
             AND Y.edano = X.edano
         
            LEFT JOIN tm_afkaijo K1
              ON K1.kaijocd = X.kaijocd
         
            LEFT JOIN tm_afkaijo K2
              ON K2.kaijocd = Y.kaijocd
            
            LEFT JOIN tt_afatena C
              ON C.atenano = X.atenano
         
            LEFT JOIN (
                   SELECT
                         D.hokensidokbn
                        ,D.gyomukbn
                        ,D.atenano
                        ,D.edano
                        ,D.mosikomikekkakbn
                        ,STRING_AGG(E.staffsimei, ', ') AS yoteisya
                     FROM tt_kkhokensido_staff D
                       LEFT JOIN tm_afstaff E
                         ON E.staffid = D.staffid
                    GROUP BY
                         D.hokensidokbn
                        ,D.gyomukbn
                        ,D.atenano
                        ,D.edano
                        ,D.mosikomikekkakbn
                      ) TM
              ON TM.hokensidokbn = X.hokensidokbn
             AND TM.gyomukbn = X.gyomukbn
             AND TM.atenano = X.atenano
             AND TM.edano = X.edano
             AND TM.mosikomikekkakbn = '1'
        
            LEFT JOIN (
                   SELECT
                         D.hokensidokbn
                        ,D.gyomukbn
                        ,D.atenano
                        ,D.edano
                        ,D.mosikomikekkakbn
                        ,STRING_AGG(E.staffsimei, ', ') AS jissisya
                     FROM tt_kkhokensido_staff D
                       LEFT JOIN tm_afstaff E
                         ON E.staffid = D.staffid
                    GROUP BY
                         D.hokensidokbn
                        ,D.gyomukbn
                        ,D.atenano
                        ,D.edano
                        ,D.mosikomikekkakbn
                      ) TK
              ON TK.hokensidokbn = Y.hokensidokbn
             AND TK.gyomukbn = Y.gyomukbn
             AND TM.atenano = X.atenano
             AND TK.edano = Y.edano
             AND TK.mosikomikekkakbn = '2'
         WHERE
              1 = 1
           AND (atenano_in is null or (X.atenano = atenano_in OR Y.atenano = atenano_in))
           AND (hokensidokbn_in is null or (X.hokensidokbn = hokensidokbn_in or Y.hokensidokbn = hokensidokbn_in))
           AND (gyomukbn_in is null or (X.gyomukbn = gyomukbn_in or Y.gyomukbn = gyomukbn_in))
           AND (jigyocd_in is null or (X.jigyocd = jigyocd_in or Y.jigyocd = jigyocd_in))
           ) Z

     ORDER BY
         case when orderby_in = 0 then Z.yoteiymd end desc          --実施予定日   降順（デフォルト）
        ,case when orderby_in = 0 then Z.yoteitm end desc           --予定開始時間 降順（デフォルト）
        ,case when orderby_in = 0 then Z.jissiymd end desc          --実施日       降順（デフォルト）
        ,case when orderby_in = 0 then Z.jissitm end desc           --実施時間     降順（デフォルト）
        ,case when orderby_in = 0 then Z.gyomukbn end               --事業コード   昇順（デフォルト）
        ,case when orderby_in = 0 then Z.jigyocd end                --事業コード   昇順（デフォルト）
        ,case when orderby_in = 0 then Z.edano end desc             --枝番         降順（デフォルト）
        
        ,case when orderby_in = 1 then Z.gyomukbn end               --業務         昇順
        ,case when orderby_in = -1 then Z.gyomukbn end desc         --業務         降順
        ,case when orderby_in = 2 then Z.jigyocd  end               --事業コード   昇順
        ,case when orderby_in = -2 then Z.jigyocd end desc          --事業コード   降順
        ,case when orderby_in = 3 then Z.yoteiymd end               --実施予定日   昇順
        ,case when orderby_in = -3 then Z.yoteiymd end desc         --実施予定日   降順
        ,case when orderby_in = 4 then Z.yoteitm end                --予定開始時間 昇順
        ,case when orderby_in = -4 then Z.yoteitm end desc          --予定開始時間 降順
        ,case when orderby_in = 5 then Z.yoteikaijo end             --予定場所     昇順
        ,case when orderby_in = -5 then Z.yoteikaijo end desc       --予定場所     降順
        ,case when orderby_in = 6 then Z.yoteisya end               --予定者       昇順
        ,case when orderby_in = -6 then Z.yoteisya end desc         --予定者       降順
        
        ,case when orderby_in = 7 then Z.jissiymd end               --実施日       昇順
        ,case when orderby_in = -7 then Z.jissiymd end desc         --実施日       降順
        ,case when orderby_in = 8 then Z.jissitm end                --実施時間     昇順
        ,case when orderby_in = -8 then Z.jissitm end desc          --実施時間     降順
        ,case when orderby_in = 9 then Z.jissikaijo end             --実施場所     昇順
        ,case when orderby_in = -9 then Z.jissikaijo end desc       --実施場所     降順
        ,case when orderby_in = 10 then Z.bymd end                  --生年月日     昇順
        ,case when orderby_in = 10 then Z.bymd_fusyohyoki end       --不詳表記     昇順
        ,case when orderby_in = -10 then Z.bymd end desc            --生年月日     降順
        ,case when orderby_in = -10 then Z.bymd_fusyohyoki end desc --不詳表記     降順
        ,case when orderby_in = 11 then Z.jissisya end              --実施者       昇順
        ,case when orderby_in = -11 then Z.jissisya end desc        --実施者       降順

    limit limit_in offset offset_in;

END$function$