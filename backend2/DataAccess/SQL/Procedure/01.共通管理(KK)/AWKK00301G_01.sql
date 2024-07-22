/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 保健指導管理
　　　　　　一覧抽出
作成日　　: 2023.12.13
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awkk00301g_01_head(setaino_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    SELECT
        count(1) total into total
      FROM
        tt_afatena A
        -- テーブルtt_afatenaとtt_kkhsmosikomi、tt_kkhskekkaを宛名番号でLEFT JOIN
        LEFT JOIN (
        -- 訪問指導予定日のサブクエリ
               SELECT atenano, Max(yoteiymd || CASE WHEN gyomukbn = '01' THEN '（成人）' WHEN gyomukbn = '02' THEN '（母子）' ELSE '' END) AS homonyoteiymd
                 FROM tt_kkhokensido_mosikomi
                WHERE hokensidokbn = '1'
                GROUP BY atenano
                ) MH
          ON MH.atenano = A.atenano
        -- 同様に個別指導予定日、訪問実施日、個別指導実施日のサブクエリを定義してLEFT JOIN
        LEFT JOIN (
               SELECT atenano, Max(yoteiymd || CASE WHEN gyomukbn = '01' THEN '（成人）' WHEN gyomukbn = '02' THEN '（母子）' ELSE '' END) AS kobetuyoteiymd
                 FROM tt_kkhokensido_mosikomi
                WHERE hokensidokbn = '2'
                GROUP BY atenano
                ) MK
          ON MK.atenano = A.atenano
        LEFT JOIN (
               SELECT atenano, Max(jissiymd || CASE WHEN gyomukbn = '01' THEN '（成人）' WHEN gyomukbn = '02' THEN '（母子）' ELSE '' END) AS homonjissiymd
                 FROM tt_kkhokensido_kekka
                WHERE hokensidokbn = '1'
                GROUP BY atenano
                ) KH
          ON KH.atenano = A.atenano
        LEFT JOIN (
               SELECT atenano, Max(jissiymd || CASE WHEN gyomukbn = '01' THEN '（成人）' WHEN gyomukbn = '02' THEN '（母子）' ELSE '' END) AS kobetujissiymd
                 FROM tt_kkhokensido_kekka
                WHERE hokensidokbn = '2'
                GROUP BY atenano
                ) KK
          ON KK.atenano = A.atenano
     -- 世帯番号によるフィルタリング
     WHERE
        A.setaino =  setaino_in;

    return total;
	
END$function$
/*==============================body==============================*/
--drop FUNCTION public.sp_awkk00301g_01_body(setaino_in character varying, orderby_in integer, limit_in integer, offset_in integer)
CREATE OR REPLACE FUNCTION public.sp_awkk00301g_01_body(setaino_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(atenano character varying, simei_yusen character varying, simei_kana_yusen character varying, sex character varying, bymd character varying, bymd_fusyoflg boolean, bymd_fusyohyoki character varying, juminkbn character varying, zokuhyoki character varying, homonyoteiymd text, homonjissiymd text, kobetuyoteiymd text, kobetujissiymd text, siensotikbn character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    return query
    SELECT
       A.atenano
      ,A.simei_yusen
      ,A.simei_kana_yusen
      ,A.sex
      ,A.bymd
      ,A.bymd_fusyoflg
      ,A.bymd_fusyohyoki
      ,A.juminkbn
      ,A.zokuhyoki
      ,MH.homonyoteiymd
      ,KH.homonjissiymd
      ,MK.kobetuyoteiymd
      ,KK.kobetujissiymd
      ,A.siensotikbn
      FROM
        tt_afatena A
        -- テーブルtt_afatenaとtt_kkhsmosikomi、tt_kkhskekkaを宛名番号でLEFT JOIN
        LEFT JOIN (
        -- 訪問指導予定日のサブクエリ
               SELECT A1.atenano, Max(A1.yoteiymd || CASE WHEN A1.gyomukbn = '01' THEN '（成人）' WHEN A1.gyomukbn = '02' THEN '（母子）' ELSE '' END) AS homonyoteiymd
                 FROM tt_kkhokensido_mosikomi A1
                WHERE A1.hokensidokbn = '1'
                GROUP BY A1.atenano
                ) MH
          ON MH.atenano = A.atenano
        -- 同様に個別指導予定日、訪問実施日、個別指導実施日のサブクエリを定義してLEFT JOIN

        LEFT JOIN (
               SELECT A2.atenano, Max(A2.yoteiymd || CASE WHEN A2.gyomukbn = '01' THEN '（成人）' WHEN A2.gyomukbn = '02' THEN '（母子）' ELSE '' END) AS kobetuyoteiymd
                 FROM tt_kkhokensido_mosikomi A2
                WHERE A2.hokensidokbn = '2'
                GROUP BY A2.atenano
                ) MK
          ON MK.atenano = A.atenano
        LEFT JOIN (
               SELECT A3.atenano, Max(A3.jissiymd || CASE WHEN A3.gyomukbn = '01' THEN '（成人）' WHEN A3.gyomukbn = '02' THEN '（母子）' ELSE '' END) AS homonjissiymd
                 FROM tt_kkhokensido_kekka A3
                WHERE A3.hokensidokbn = '1'
                GROUP BY A3.atenano
                ) KH
          ON KH.atenano = A.atenano
        LEFT JOIN (
               SELECT A4.atenano, Max(A4.jissiymd || CASE WHEN A4.gyomukbn = '01' THEN '（成人）' WHEN A4.gyomukbn = '02' THEN '（母子）' ELSE '' END) AS kobetujissiymd
                 FROM tt_kkhokensido_kekka A4
                WHERE A4.hokensidokbn = '2'
                GROUP BY A4.atenano
                ) KK
          ON KK.atenano = A.atenano
     -- 世帯番号によるフィルタリング

     WHERE
        A.setaino =  setaino_in

     ORDER BY
        case when orderby_in = 0 then A.atenano  end               --宛名番号  昇順（デフォルト）
        ,case when orderby_in = 1 then A.atenano end               --宛名番号  昇順
        ,case when orderby_in = -1 then A.atenano end desc         --宛名番号  降順
        ,case when orderby_in = 2 then A.simei_yusen end           --氏名      昇順
        ,case when orderby_in = -2 then A.simei_yusen end desc     --氏名      降順
        ,case when orderby_in = 3 then A.simei_kana_yusen  end     --氏名カナ  昇順
        ,case when orderby_in = -3 then A.simei_kana_yusen end desc--氏名カナ  降順
        ,case when orderby_in = 4 then A.sex end                   --性別      昇順
        ,case when orderby_in = -4 then A.sex end desc             --性別      降順
        ,case when orderby_in = 5 then A.bymd end                  --生年月日  昇順
        ,case when orderby_in = 5 then A.bymd_fusyohyoki end       --生年月日_不詳表記  昇順
        ,case when orderby_in = -5 then A.bymd end desc            --生年月日  降順
        ,case when orderby_in = -5 then A.bymd_fusyohyoki end desc --生年月日_不詳表記  降順
        ,case when orderby_in = 6 then A.juminkbn end              --住民区分  昇順
        ,case when orderby_in = -6 then A.juminkbn end desc        --住民区分  降順
        ,case when orderby_in = 7 then A.zokuhyoki end             --続柄      昇順
        ,case when orderby_in = -7 then A.zokuhyoki end desc       --続柄      降順
        ,case when orderby_in = 8 then MH.homonyoteiymd end        --訪問予定日 昇順
        ,case when orderby_in = -8 then MH.homonyoteiymd end desc  --訪問予定日 降順
        ,case when orderby_in = 9 then KH.homonjissiymd end        --訪問実施日 昇順
        ,case when orderby_in = -9 then KH.homonjissiymd end desc  --訪問実施日 降順
        ,case when orderby_in = 10 then MK.kobetuyoteiymd end      --個別指導予定日 昇順
        ,case when orderby_in = -10 then MK.kobetuyoteiymd end desc--個別指導予定日 降順
        ,case when orderby_in = 11 then KK.kobetujissiymd end      --個別指導実施日 昇順
        ,case when orderby_in = -11 then KK.kobetujissiymd end desc--個別指導実施日 降順
        ,case when orderby_in = 12 then A.siensotikbn end          --支援措置区分 昇順
        ,case when orderby_in = -12 then A.siensotikbn end desc    --支援措置区分 降順

    limit limit_in offset offset_in;

END$function$