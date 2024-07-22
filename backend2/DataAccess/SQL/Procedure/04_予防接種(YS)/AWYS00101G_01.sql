/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 接種情報（生涯1回／複数回）情報取得
　　　　　　一覧抽出
作成日　　: 2024.06.22
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awys00101g_01_head(atenano_in character varying, sessyucd_in character varying, rirekihyoji_in boolean, kbn_in integer)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    IF rirekihyoji_in = true THEN
        SELECT
            count(1) total into total
          FROM tt_yssessyu A
         WHERE  1 = 1
           AND (atenano_in is null OR A.atenano = atenano_in)
           AND (sessyucd_in is null OR A.sessyucd = sessyucd_in)
           AND ((kbn_in = 1 AND A.hoteikbn = '1') OR (kbn_in = 0 AND A.hoteikbn <> '1'));
    ELSE
        SELECT
            count(1) total into total
          FROM
            tt_yssessyu A
            INNER JOIN (
                       SELECT
                           atenano
                          ,sessyucd
                          ,MAX(edano) AS edano
                         FROM tt_yssessyu
                        GROUP BY atenano,sessyucd
                      ) B
              ON B.atenano = A.atenano
             AND B.sessyucd = A.sessyucd
             AND B.edano = A.edano
         WHERE  1 = 1
           AND (atenano_in is null OR A.atenano = atenano_in)
           AND (sessyucd_in is null OR A.sessyucd = sessyucd_in)
           AND ((kbn_in = 1 AND A.hoteikbn = '1') OR (kbn_in = 0 AND A.hoteikbn <> '1'));
    
    END IF;

    return total;
	
END$function$
/*==============================body==============================*/
--drop FUNCTION public.sp_awys00101g_01_body( character varying,  character varying,  integer,  character varying,  boolean,  integer,  integer,  integer,  integer)
CREATE OR REPLACE FUNCTION public.sp_awys00101g_01_body(atenano_in character varying, hanyomaincd_in character varying, hanyosubcd_in integer, sessyucd_in character varying, rirekihyoji_in boolean, kbn_in integer, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(atenano character varying, sessyucd character varying, kaisu character varying, edano integer, jissiymd character varying, sessyukbn character varying, lotno character varying, vaccinenmcd character varying, vaccinemakercd character varying, sessyuryo double precision, jissikbn character varying, hoteikbn character varying, tokubetunojijyo character varying, sessyufilter text, sortseq text)
 LANGUAGE plpgsql
AS $function$
BEGIN
    IF rirekihyoji_in = true THEN
        return query
        SELECT
           A.atenano
          ,A.sessyucd
          ,A.kaisu
          ,A.edano
          ,A.jissiymd
          ,A.sessyukbn
          ,A.lotno
          ,A.vaccinenmcd
          ,A.vaccinemakercd
          ,A.sessyuryo
          ,A.jissikbn
          ,A.hoteikbn
          ,A.tokubetunojijyo
          ,SUBSTRING(H.hanyokbn1,2,1) AS sessyufilter
          ,SUBSTRING(H.hanyokbn1,3,3) AS sortseq
          FROM
            tt_yssessyu A
            LEFT JOIN tm_afhanyo H
              ON H.hanyocd = A.sessyucd || A.kaisu
         WHERE  1 = 1
           AND (atenano_in is null OR A.atenano = atenano_in)
           AND (sessyucd_in is null OR Substring(H.hanyokbn1,2,1) = sessyucd_in)
           AND ((kbn_in = 1 AND Substring(H.hanyokbn1,1,1) = '1') OR (kbn_in = 0 AND Substring(H.hanyokbn1,1,1) = '2'))
           AND (H.hanyomaincd = hanyomaincd_in)
           AND (H.hanyosubcd = hanyosubcd_in)

         ORDER BY
             case when orderby_in = 0 then SUBSTRING(H.hanyokbn1,3,3) end --汎用区分1:3～5桁目 昇順（デフォルト）
            ,case when orderby_in = 1 then SUBSTRING(H.hanyokbn1,3,3) end --汎用区分1:3～5桁目 昇順
            ,case when orderby_in = -1 then SUBSTRING(H.hanyokbn1,3,3) end desc --汎用区分1:3～5桁目 降順
            ,case when orderby_in = 2 then A.edano  end                 --枝番        昇順
            ,case when orderby_in = -2 then A.edano end desc            --枝番        降順
            ,case when orderby_in = 3 then A.jissiymd end               --実施日      昇順
            ,case when orderby_in = -3 then A.jissiymd end desc         --実施日      降順
            ,case when orderby_in = 4 then A.sessyukbn end              --接種区分    昇順
            ,case when orderby_in = -4 then A.sessyukbn end desc        --接種区分    降順
            ,case when orderby_in = 5 then A.lotno end                  --ロット番号  昇順
            ,case when orderby_in = -5 then A.lotno end desc            --ロット番号  降順
            ,case when orderby_in = 6 then A.vaccinenmcd end            --ワクチン名コード 昇順
            ,case when orderby_in = -6 then A.vaccinenmcd end desc      --ワクチン名コード 降順
            ,case when orderby_in = 7 then A.vaccinemakercd end         --ワクチンメーカーコード 昇順
            ,case when orderby_in = -7 then A.vaccinemakercd end desc   --ワクチンメーカーコード 降順
            ,case when orderby_in = 8 then A.sessyuryo end              --接種量      昇順
            ,case when orderby_in = -8 then A.sessyuryo end desc        --接種量      降順
            ,case when orderby_in = 9 then A.jissikbn end               --実施区分    昇順
            ,case when orderby_in = -9 then A.jissikbn end desc         --実施区分    降順
            ,case when orderby_in = 10 then A.hoteikbn end              --法定区分    昇順
            ,case when orderby_in = -10 then A.hoteikbn end desc        --法定区分    降順
            ,case when orderby_in = 11 then A.tokubetunojijyo end       --特別の事情  昇順
            ,case when orderby_in = -11 then A.tokubetunojijyo end desc --特別の事情  降順
            
        limit limit_in offset offset_in;

    ELSE
        return query
        SELECT
           A.atenano
          ,A.sessyucd
          ,A.kaisu
          ,A.edano
          ,A.jissiymd
          ,A.sessyukbn
          ,A.lotno
          ,A.vaccinenmcd
          ,A.vaccinemakercd
          ,A.sessyuryo
          ,A.jissikbn
          ,A.hoteikbn
          ,A.tokubetunojijyo
          ,SUBSTRING(H.hanyokbn1,2,1) AS sessyufilter
          ,SUBSTRING(H.hanyokbn1,3,3) AS sortseq
          FROM
            tt_yssessyu A
            LEFT JOIN tm_afhanyo H
              ON H.hanyocd = A.sessyucd || A.kaisu
            INNER JOIN (
                       SELECT
                           C.atenano
                          ,C.sessyucd
                          ,MAX(C.edano) AS edano
                         FROM tt_yssessyu C
                        GROUP BY C.atenano,C.sessyucd
                      ) B
              ON B.atenano = A.atenano
             AND B.sessyucd = A.sessyucd
             AND B.edano = A.edano
         WHERE  1 = 1
           AND (atenano_in is null OR A.atenano = atenano_in)
           AND (sessyucd_in is null OR Substring(H.hanyokbn1,2,1) = sessyucd_in)
           AND ((kbn_in = 1 AND Substring(H.hanyokbn1,1,1) = '1') OR (kbn_in = 0 AND Substring(H.hanyokbn1,1,1) = '2'))
           AND (H.hanyomaincd = hanyomaincd_in)
           AND (H.hanyosubcd = hanyosubcd_in)

         ORDER BY
             case when orderby_in = 0 then SUBSTRING(H.hanyokbn1,3,3) end --汎用区分1:3～5桁目 昇順（デフォルト）
            ,case when orderby_in = 1 then SUBSTRING(H.hanyokbn1,3,3) end --汎用区分1:3～5桁目 昇順
            ,case when orderby_in = -1 then SUBSTRING(H.hanyokbn1,3,3) end desc --汎用区分1:3～5桁目 降順
            ,case when orderby_in = 2 then A.edano  end                 --枝番        昇順
            ,case when orderby_in = -2 then A.edano end desc            --枝番        降順
            ,case when orderby_in = 3 then A.jissiymd end               --実施日      昇順
            ,case when orderby_in = -3 then A.jissiymd end desc         --実施日      降順
            ,case when orderby_in = 4 then A.sessyukbn end              --接種区分    昇順
            ,case when orderby_in = -4 then A.sessyukbn end desc        --接種区分    降順
            ,case when orderby_in = 5 then A.lotno end                  --ロット番号  昇順
            ,case when orderby_in = -5 then A.lotno end desc            --ロット番号  降順
            ,case when orderby_in = 6 then A.vaccinenmcd end            --ワクチン名コード 昇順
            ,case when orderby_in = -6 then A.vaccinenmcd end desc      --ワクチン名コード 降順
            ,case when orderby_in = 7 then A.vaccinemakercd end         --ワクチンメーカーコード 昇順
            ,case when orderby_in = -7 then A.vaccinemakercd end desc   --ワクチンメーカーコード 降順
            ,case when orderby_in = 8 then A.sessyuryo end              --接種量      昇順
            ,case when orderby_in = -8 then A.sessyuryo end desc        --接種量      降順
            ,case when orderby_in = 9 then A.jissikbn end               --実施区分    昇順
            ,case when orderby_in = -9 then A.jissikbn end desc         --実施区分    降順
            ,case when orderby_in = 10 then A.hoteikbn end              --法定区分    昇順
            ,case when orderby_in = -10 then A.hoteikbn end desc        --法定区分    降順
            ,case when orderby_in = 11 then A.tokubetunojijyo end       --特別の事情  昇順
            ,case when orderby_in = -11 then A.tokubetunojijyo end desc --特別の事情  降順
            
        limit limit_in offset offset_in;

    END IF;



END$function$