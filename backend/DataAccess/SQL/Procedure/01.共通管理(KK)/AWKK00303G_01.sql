/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 集団指導管理
　　　　　　一覧抽出
作成日　　: 2023.12.25
作成者　　: 張
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awkk00303g_01_head(gyomukbn_in character varying, jigyocd_in character varying, staffid_in character varying, kaijocd_in character varying, yoteiymdf_in character varying, yoteiymdt_in character varying, course_in character varying, jissiymdf_in character varying, jissiymdt_in character varying, coursenm_in character varying, atenano_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    SELECT
        count(1) total into total
      FROM tt_kksyudansido_mosikomi X
        FULl OUTER JOIN tt_kksyudansido_kekka Y
          ON Y.gyomukbn = X.gyomukbn
         AND Y.edano = X.edano
        LEFT JOIN tm_afkaijo K1
          ON K1.kaijocd = X.kaijocd
        LEFT JOIN tm_afkaijo K2
          ON K2.kaijocd = Y.kaijocd

        LEFT JOIN (
              SELECT
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
               ,STRING_AGG(E.staffsimei, ', ') AS yoteisya
                FROM tt_kksyudansido_staff D
                  LEFT JOIN tm_afstaff E
                    ON E.staffid = D.staffid
              GROUP BY
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
              ) TM
          ON TM.gyomukbn = X.gyomukbn
         AND TM.edano = X.edano
         AND TM.mosikomikekkakbn = '1'
    
        LEFT JOIN (
              SELECT
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
               ,STRING_AGG(E.staffsimei, ', ') AS jissisya
                FROM tt_kksyudansido_staff D
                  LEFT JOIN tm_afstaff E
                    ON E.staffid = D.staffid
              GROUP BY
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
              ) TK
          ON TK.gyomukbn = Y.gyomukbn
         AND TK.edano = Y.edano
         AND TK.mosikomikekkakbn = '2'

     WHERE
          1 = 1
       AND (atenano_in IS NULL OR 
              ( atenano_in IN (
                              SELECT A.atenano
                                FROM tt_kksyudansido_sankasyamosikomi A
                               WHERE A.gyomukbn = X.gyomukbn
                                 AND A.edano = X.edano
                              )
                OR
                atenano_in IN (
                               SELECT B.atenano
                                 FROM tt_kksyudansido_sankasyakekka B
                                WHERE B.gyomukbn = Y.gyomukbn
                                  AND B.edano = Y.edano
                              )
              )
           )
       AND (gyomukbn_in IS NULL OR ( X.gyomukbn = gyomukbn_in OR Y.gyomukbn = gyomukbn_in ) )
       AND (jigyocd_in IS NULL OR ( X.jigyocd = jigyocd_in OR Y.jigyocd = jigyocd_in ) )
       AND (staffid_in IS NULL OR 
              ( staffid_in IN (
                              SELECT S1.staffid
                                FROM tt_kksyudansido_staff S1
                               WHERE S1.gyomukbn = X.gyomukbn
                                 AND S1.edano = X.edano
                                 AND S1.mosikomikekkakbn = '1'
                              )
                OR
                staffid_in IN (
                              SELECT S2.staffid
                                FROM tt_kksyudansido_staff S2
                               WHERE S2.gyomukbn = Y.gyomukbn
                                 AND S2.edano = Y.edano
                                 AND S2.mosikomikekkakbn = '2'
                              )
              )
           )
       AND (kaijocd_in IS NULL OR ( X.kaijocd = kaijocd_in OR Y.kaijocd = kaijocd_in ) )
       AND (yoteiymdf_in IS NULL OR  X.yoteiymd >= yoteiymdf_in )
       AND (yoteiymdt_in IS NULL OR  X.yoteiymd <= yoteiymdt_in )
       AND (course_in IS NULL OR  X.coursenm = course_in )
       AND (jissiymdf_in IS NULL OR  Y.jissiymd >= jissiymdf_in )
       AND (jissiymdt_in IS NULL OR  Y.jissiymd <= jissiymdt_in )
       AND (coursenm_in IS NULL OR  X.coursenm LIKE '%' || coursenm_in || '%' );

    return total;
	
END$function$
/*==============================body==============================*/
CREATE OR REPLACE FUNCTION public.sp_awkk00303g_01_body(gyomukbn_in character varying, jigyocd_in character varying, staffid_in character varying, kaijocd_in character varying, yoteiymdf_in character varying, yoteiymdt_in character varying, course_in character varying, jissiymdf_in character varying, jissiymdt_in character varying, coursenm_in character varying, atenano_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(gyomukbn character varying, jigyocd character varying, yoteiymd character varying, yoteitm character varying, yotebasyo character varying, yoteisya text, nitteno integer, nittesyosaino integer, coursenm character varying, jissiymd character varying, tmf character varying, tmt character varying, jissibasyo character varying, jissisya text, edano integer)
 LANGUAGE plpgsql
AS $function$
BEGIN
    return query
    SELECT
          CASE WHEN X.gyomukbn IS NOT NULL THEN X.gyomukbn ELSE Y.gyomukbn END AS gyomukbn
         ,CASE WHEN X.jigyocd IS NOT NULL THEN X.jigyocd ELSE Y.jigyocd END AS jigyocd
         ,X.yoteiymd
         ,X.yoteitm
         ,K1.kaijonm AS yotebasyo
         ,TM.yoteisya
         ,X.nitteno
         ,X.nittesyosaino
         ,X.coursenm
         ,Y.jissiymd
         ,Y.tmf
         ,Y.tmt
         ,K2.kaijonm AS jissibasyo
         ,TK.jissisya
         ,CASE WHEN X.edano IS NOT NULL THEN X.edano ELSE Y.edano END AS edano
      FROM tt_kksyudansido_mosikomi X
        FULl OUTER JOIN tt_kksyudansido_kekka Y
          ON Y.gyomukbn = X.gyomukbn
         AND Y.edano = X.edano
        LEFT JOIN tm_afkaijo K1
          ON K1.kaijocd = X.kaijocd
        LEFT JOIN tm_afkaijo K2
          ON K2.kaijocd = Y.kaijocd

        LEFT JOIN (
              SELECT
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
               ,STRING_AGG(E.staffsimei, ', ') AS yoteisya
                FROM tt_kksyudansido_staff D
                  LEFT JOIN tm_afstaff E
                    ON E.staffid = D.staffid
              GROUP BY
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
              ) TM
          ON TM.gyomukbn = X.gyomukbn
         AND TM.edano = X.edano
         AND TM.mosikomikekkakbn = '1'
    
        LEFT JOIN (
              SELECT
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
               ,STRING_AGG(E.staffsimei, ', ') AS jissisya
                FROM tt_kksyudansido_staff D
                  LEFT JOIN tm_afstaff E
                    ON E.staffid = D.staffid
              GROUP BY
                D.gyomukbn
               ,D.edano
               ,D.mosikomikekkakbn
              ) TK
          ON TK.gyomukbn = Y.gyomukbn
         AND TK.edano = Y.edano
         AND TK.mosikomikekkakbn = '2'

     WHERE
          1 = 1
       AND (atenano_in IS NULL OR 
              ( atenano_in IN (
                              SELECT A.atenano
                                FROM tt_kksyudansido_sankasyamosikomi A
                               WHERE A.gyomukbn = X.gyomukbn
                                 AND A.edano = X.edano
                              )
                OR
                atenano_in IN (
                               SELECT B.atenano
                                 FROM tt_kksyudansido_sankasyakekka B
                                WHERE B.gyomukbn = Y.gyomukbn
                                  AND B.edano = Y.edano
                              )
              )
           )
       AND (gyomukbn_in IS NULL OR ( X.gyomukbn = gyomukbn_in OR Y.gyomukbn = gyomukbn_in ) )
       AND (jigyocd_in IS NULL OR ( X.jigyocd = jigyocd_in OR Y.jigyocd = jigyocd_in ) )
       AND (staffid_in IS NULL OR 
              ( staffid_in IN (
                              SELECT S1.staffid
                                FROM tt_kksyudansido_staff S1
                               WHERE S1.gyomukbn = X.gyomukbn
                                 AND S1.edano = X.edano
                                 AND S1.mosikomikekkakbn = '1'
                              )
                OR
                staffid_in IN (
                              SELECT S2.staffid
                                FROM tt_kksyudansido_staff S2
                               WHERE S2.gyomukbn = Y.gyomukbn
                                 AND S2.edano = Y.edano
                                 AND S2.mosikomikekkakbn = '2'
                              )
              )
           )
       AND (kaijocd_in IS NULL OR ( X.kaijocd = kaijocd_in OR Y.kaijocd = kaijocd_in ) )
       AND (yoteiymdf_in IS NULL OR  X.yoteiymd >= yoteiymdf_in )
       AND (yoteiymdt_in IS NULL OR  X.yoteiymd <= yoteiymdt_in )
       AND (course_in IS NULL OR  X.coursenm = course_in )
       AND (jissiymdf_in IS NULL OR  Y.jissiymd >= jissiymdf_in )
       AND (jissiymdt_in IS NULL OR  Y.jissiymd <= jissiymdt_in )
       AND (coursenm_in IS NULL OR  X.coursenm LIKE '%' || coursenm_in || '%' )

     ORDER BY
        case when orderby_in = 0 then X.yoteiymd  end desc          --実施予定日（降順）（デフォルト）
        ,case when orderby_in = 0 then X.yoteitm  end desc          --予定開始時間（降順）（デフォルト）
        ,case when orderby_in = 0 then Y.jissiymd  end desc         --実施日（降順）（デフォルト）
        ,case when orderby_in = 0 then Y.tmf  end desc              --開始時間 降順）（デフォルト）
        ,case when orderby_in = 0 then CASE WHEN X.gyomukbn IS NOT NULL THEN X.gyomukbn ELSE Y.gyomukbn END end --業務（昇順）（デフォルト）
        ,case when orderby_in = 0 then CASE WHEN X.edano IS NOT NULL THEN X.edano ELSE Y.edano END end desc     --枝番（降順）（デフォルト）
        ,case when orderby_in = 0 then X.jigyocd  end               --事業コード（昇順）（デフォルト）
        
        ,case when orderby_in = 1 then CASE WHEN X.gyomukbn IS NOT NULL THEN X.gyomukbn ELSE Y.gyomukbn END end --業務（昇順）
        ,case when orderby_in = -1 then CASE WHEN X.gyomukbn IS NOT NULL THEN X.gyomukbn ELSE Y.gyomukbn END end desc --業務（降順）
        ,case when orderby_in = 2 then X.jigyocd end                --事業コード 昇順
        ,case when orderby_in = -2 then X.jigyocd end desc          --事業コード 降順
        ,case when orderby_in = 3 then X.yoteiymd  end              --実施予定日 昇順
        ,case when orderby_in = -3 then X.yoteiymd end desc         --実施予定日 降順
        ,case when orderby_in = 4 then X.yoteitm end                --予定開始時間 昇順
        ,case when orderby_in = -4 then X.yoteitm end desc          --予定開始時間 降順
        ,case when orderby_in = 5 then K1.kaijocd end               --実施場所 昇順
        ,case when orderby_in = -5 then K1.kaijocd end desc         --実施場所 降順
        ,case when orderby_in = 6 then TM.yoteisya end              --予定者 昇順
        ,case when orderby_in = -6 then TM.yoteisya end desc        --予定者 降順
        
        ,case when orderby_in = 7 then X.nitteno end                --日程番号 昇順
        ,case when orderby_in = -7 then X.nitteno end desc          --日程番号 降順
        ,case when orderby_in = 8 then X.nittesyosaino end          --日程詳細番号 昇順
        ,case when orderby_in = -8 then X.nittesyosaino end desc    --日程詳細番号 降順
        ,case when orderby_in = 9 then X.coursenm end               --コース名 昇順
        ,case when orderby_in = -9 then X.coursenm end desc         --コース名 降順
        
        ,case when orderby_in = 10 then Y.jissiymd end              --実施日 昇順
        ,case when orderby_in = -10 then Y.jissiymd end desc        --実施日 降順
        ,case when orderby_in = 11 then Y.tmf end                   --実施時間 昇順
        ,case when orderby_in = 11 then Y.tmt end                   --実施時間 昇順
        ,case when orderby_in = -11 then Y.tmf end desc             --実施時間 降順
        ,case when orderby_in = -11 then Y.tmt end desc             --実施時間 降順
        ,case when orderby_in = 12 then K2.kaijocd end              --実施場所 昇順
        ,case when orderby_in = -12 then K2.kaijocd end desc        --実施場所 昇順
        ,case when orderby_in = 13 then TK.jissisya end             --実施者 昇順
        ,case when orderby_in = -13 then TK.jissisya end desc       --実施者 降順

    limit limit_in offset offset_in

    ;

END$function$