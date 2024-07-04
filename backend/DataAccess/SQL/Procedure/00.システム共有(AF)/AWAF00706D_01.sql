/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 世帯検索
　　　　　　一覧抽出
作成日　　: 2023.11.24
作成者　　: 張
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awaf00706d_01_head(kname_in character varying, name_in character varying, adrs_yubin_in character varying, adrs_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    select
        count(1) total into total
      from (
        -- 世帯主ある世帯番号
        select
             t1.setaino  AS setaino                     --世帯番号
            ,t1.atenano                                 --宛名番号
            ,t1.simei                                   --氏名
            ,t1.tusyo                                   --通称
            ,t1.sex                                     --性別
            ,t1.bymd                                    --生年月日
            ,t1.bymd_fusyoflg                           --生年月日_不詳フラグ
            ,t1.bymd_fusyohyoki                         --生年月日_不詳表記
            ,t1.juminkbn                                --住民区分
            ,t1.adrs_yubin                              --郵便番号
            ,t1.adrs1                                   --住所1
            ,t1.adrs2                                   --住所2

            ,t1.sex                                     --性別（ソート用)
        from
            tt_afatena t1                --宛名テーブル
           ,(
             select Y.setaino AS setaino                -- 世帯番号
                   ,min(Y.juminkbn || Y.atenano) as juminkbn_atenano  -- 世帯区分＋宛名番号
               from tt_afatena Y         -- 宛名テーブル
              where ((coalesce(Y.zokucd1, '') = '02') OR (coalesce(Y.zokucd2, '') = '02') OR (coalesce(Y.zokucd3, '') = '02') OR (coalesce(Y.zokucd4, '') = '02')) -- 続柄コード1～4
              group by Y.setaino                        -- 世帯番号
            ) x
       where
             x.setaino = t1.setaino
         and substring(x.juminkbn_atenano, 2, 15) = t1.atenano
         and (kname_in is null or (t1.simei_kana_seion like kname_in) or (t1.tusyo_kana_seion like kname_in)) -- 世帯主カナ氏名
         and (name_in is null or (t1.simei like name_in) or (t1.tusyo like name_in))          -- 世帯主氏名
         and (adrs_yubin_in is null or t1.adrs_yubin = adrs_yubin_in)                                       -- 世帯郵便番号
         and (adrs_in is null or (t1.adrs1 || coalesce(t1.adrs2, '')) like adrs_in)            -- 世帯住所
    
      union
    
        -- 世帯主が未設定の世帯番号
        select
             t1.setaino AS setaino                      --世帯番号
            ,t1.atenano                                 --宛名番号
            ,t1.simei                                   --氏名
            ,t1.tusyo                                   --通称
            ,t1.sex                                     --性別
            ,t1.bymd                                    --生年月日
            ,t1.bymd_fusyoflg                           --生年月日_不詳フラグ
            ,t1.bymd_fusyohyoki                         --生年月日_不詳表記
            ,t1.juminkbn                                --住民区分
            ,t1.adrs_yubin                              --郵便番号
            ,t1.adrs1                                   --住所1
            ,t1.adrs2                                   --住所2
            
            ,t1.sex                                     --性別（ソート用)
        from
            tt_afatena t1                   --宛名テーブル
           ,(
             select A.setaino AS setaino                -- 世帯番号
                   ,max(to_char(B.upddttm, 'yyyymmddhhss') || A.atenano) as upddttm_atenano   -- 更新日時||宛名番号
               from tt_afatena A            -- 宛名テーブル
                 left join tt_afjutogai B   -- 住登外者情報テーブル
                   on B.atenano = A.atenano             -- 宛名番号
              where A.setaino not in 
                -- 世帯主が未設定の世帯番号
                  (
                   select Y.setaino AS setaino          -- 世帯番号、宛名番号
                     from tt_afatena Y      -- 宛名テーブル
                    where ((coalesce(Y.zokucd1, '') = '02') OR (coalesce(Y.zokucd2, '') = '02') OR (coalesce(Y.zokucd3, '') = '02') OR (coalesce(Y.zokucd4, '') = '02')) -- 続柄コード1～4
                  )
              group by a.setaino-- 世帯番号
            ) X
       where 
             X.setaino = t1.setaino
         and substring(x.upddttm_atenano, 13, 15) = t1.atenano
         and (kname_in is null or (t1.simei_kana_seion like kname_in) or (t1.tusyo_kana_seion like kname_in)) -- 世帯主カナ氏名
         and (name_in is null or (t1.simei like name_in) or (t1.tusyo like name_in))          -- 世帯主氏名
         and (adrs_yubin_in is null or t1.adrs_yubin = adrs_yubin_in)                         -- 世帯郵便番号
         and (adrs_in is null or (t1.adrs1 || coalesce(t1.adrs2, '')) like adrs_in)            -- 世帯住所
           ) t;

    return total;
	
END$function$
/*==============================body==============================*/
--drop FUNCTION public.sp_awaf00706d_01_body( character varying,  character varying,  character varying,  character varying,  integer,  integer,  integer)
CREATE OR REPLACE FUNCTION public.sp_awaf00706d_01_body(kname_in character varying, name_in character varying, adrs_yubin_in character varying, adrs_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(setaino character varying, atenano character varying, name text, sex character varying, bymd character varying, bymd_fusyoflg boolean, bymd_fusyohyoki character varying, juminkbn character varying, adrs_yubin character varying, adrs text)
 LANGUAGE plpgsql
AS $function$
BEGIN
    return query
    select
         t.setaino                                      --世帯番号
        ,t.atenano                                      --宛名番号
        ,t.simei || coalesce(t.tusyo, '') as name       --氏名
        ,t.sex                                          --性別
        ,t.bymd                                         --生年月日
        ,t.bymd_fusyoflg                                --生年月日_不詳フラグ
        ,t.bymd_fusyohyoki                              --生年月日_不詳表記
        ,t.juminkbn                                     --住民区分
        ,t.adrs_yubin                                   --郵便番号
        ,t.adrs1 || coalesce(t.adrs2, '') as adrs       --住所
      from (
        -- 世帯主ある世帯番号
        select
             t1.setaino  AS setaino                     --世帯番号
            ,t1.atenano                                 --宛名番号
            ,t1.simei                                   --氏名
            ,t1.tusyo                                   --通称
            ,t1.sex                                     --性別
            ,t1.bymd                                    --生年月日
            ,t1.bymd_fusyoflg                           --生年月日_不詳フラグ
            ,t1.bymd_fusyohyoki                         --生年月日_不詳表記
            ,t1.juminkbn                                --住民区分
            ,t1.adrs_yubin                              --郵便番号
            ,t1.adrs1                                   --住所1
            ,t1.adrs2                                   --住所2
        from
            tt_afatena t1                --宛名テーブル
           ,(
             select Y.setaino AS setaino                -- 世帯番号
                   ,min(Y.juminkbn || Y.atenano) as juminkbn_atenano  -- 世帯区分＋宛名番号
               from tt_afatena Y         -- 宛名テーブル
              where ((coalesce(Y.zokucd1, '') = '02') OR (coalesce(Y.zokucd2, '') = '02') OR (coalesce(Y.zokucd3, '') = '02') OR (coalesce(Y.zokucd4, '') = '02')) -- 続柄コード1～4
              group by Y.setaino                        -- 世帯番号
            ) x
       where
             x.setaino = t1.setaino
         and substring(x.juminkbn_atenano, 2, 15) = t1.atenano
         and (kname_in is null or (t1.simei_kana_seion like kname_in) or (t1.tusyo_kana_seion like kname_in)) -- 世帯主カナ氏名
         and (name_in is null or (t1.simei like name_in) or (t1.tusyo like name_in))          -- 世帯主氏名
         and (adrs_yubin_in is null or t1.adrs_yubin = adrs_yubin_in)                                       -- 世帯郵便番号
         and (adrs_in is null or (t1.adrs1 || coalesce(t1.adrs2, '')) like adrs_in)            -- 世帯住所
    
      union
    
        -- 世帯主が未設定の世帯番号
        select
             t1.setaino AS setaino                      --世帯番号
            ,t1.atenano                                 --宛名番号
            ,t1.simei                                   --氏名
            ,t1.tusyo                                   --通称
            ,t1.sex                                     --性別
            ,t1.bymd                                    --生年月日
            ,t1.bymd_fusyoflg                           --生年月日_不詳フラグ
            ,t1.bymd_fusyohyoki                         --生年月日_不詳表記
            ,t1.juminkbn                                --住民区分
            ,t1.adrs_yubin                              --郵便番号
            ,t1.adrs1                                   --住所1
            ,t1.adrs2                                   --住所2
        from
            tt_afatena t1                   --宛名テーブル
           ,(
             select A.setaino AS setaino                -- 世帯番号
                   ,max(to_char(B.upddttm, 'yyyymmddhhss') || A.atenano) as upddttm_atenano   -- 更新日時||宛名番号
               from tt_afatena A            -- 宛名テーブル
                 left join tt_afjutogai B   -- 住登外者情報テーブル
                   on B.atenano = A.atenano             -- 宛名番号
              where A.setaino not in 
                -- 世帯主が未設定の世帯番号
                  (
                   select Y.setaino AS setaino          -- 世帯番号、宛名番号
                     from tt_afatena Y      -- 宛名テーブル
                    where ((coalesce(Y.zokucd1, '') = '02') OR (coalesce(Y.zokucd2, '') = '02') OR (coalesce(Y.zokucd3, '') = '02') OR (coalesce(Y.zokucd4, '') = '02')) -- 続柄コード1～4
                  )
              group by a.setaino-- 世帯番号
            ) X
       where 
             X.setaino = t1.setaino
         and substring(x.upddttm_atenano, 13, 15) = t1.atenano
         and (kname_in is null or (t1.simei_kana_seion like kname_in) or (t1.tusyo_kana_seion like kname_in)) -- 世帯主カナ氏名
         and (name_in is null or (t1.simei like name_in) or (t1.tusyo like name_in))          -- 世帯主氏名
         and (adrs_yubin_in is null or t1.adrs_yubin = adrs_yubin_in)                         -- 世帯郵便番号
         and (adrs_in is null or (t1.adrs1 || coalesce(t1.adrs2, '')) like adrs_in)            -- 世帯住所
           ) t
    order by
        case when orderby_in = 0 then t.setaino  end               --世帯番号  昇順（デフォルト）
        ,case when orderby_in = 1 then t.setaino end               --世帯番号  昇順
        ,case when orderby_in = -1 then t.setaino end desc         --世帯番号  降順
        ,case when orderby_in = 2 then t.atenano end               --宛名番号  昇順
        ,case when orderby_in = -2 then t.atenano end desc         --宛名番号  降順
        ,case when orderby_in = 3 then t.simei  end                --氏名      昇順
        ,case when orderby_in = 3 then t.tusyo  end                --通称      昇順
        ,case when orderby_in = -3 then t.simei end desc           --氏名      降順
        ,case when orderby_in = -3 then t.tusyo end desc           --通称      降順
        ,case when orderby_in = 4 then t.sex end                   --性別      昇順
        ,case when orderby_in = -4 then t.sex end desc             --性別      降順
        ,case when orderby_in = 5 then t.bymd end                  --生年月日  昇順
        ,case when orderby_in = 5 then t.bymd_fusyohyoki end       --生年月日_不詳表記  昇順
        ,case when orderby_in = -5 then t.bymd end desc            --生年月日  降順
        ,case when orderby_in = -5 then t.bymd_fusyohyoki end desc --生年月日_不詳表記  降順
        ,case when orderby_in = 6 then t.juminkbn end              --住民区分  昇順
        ,case when orderby_in = -6 then t.juminkbn end desc        --住民区分  降順
        ,case when orderby_in = 7 then t.adrs_yubin end            --郵便番号  昇順
        ,case when orderby_in = -7 then t.adrs_yubin end desc      --郵便番号  降順
        ,case when orderby_in = 8 then t.adrs1 end                 --住所1     昇順
        ,case when orderby_in = 8 then t.adrs2 end                 --住所2     昇順
        ,case when orderby_in = -8 then t.adrs1 end desc           --住所1     降順
        ,case when orderby_in = -8 then t.adrs2 end desc           --住所2     降順
    limit limit_in offset offset_in;

END$function$