/*******************************************************************
業務名称　: 健康管理システム
機能概要　: フォロー記録票
　　　　　　
作成日　　: 2024.04.17
作成者　　: 呉
変更履歴　:
*******************************************************************/
CREATE OR REPLACE FUNCTION ft_euforokirokuhyo(
    haakukeiro_in       varchar,    --把握経路  
    haakujigyocd_in     varchar,    --フォロー把握事業  
    followjigyocd_in    varchar,    --フォロー事業  
    followstatus_in     varchar,    --フォロー状況  
    juminkbn_in         varchar     --除票者除外区分
    )
 RETURNS TABLE(
atenano             varchar,        --宛名番号
simei_kana_yusen    varchar,        --フリガナ
simei_yusen         varchar,        --氏名
sex                 varchar,        --性別
bymd_wareki         varchar,        --生年月日（和暦）
tel                 varchar,        --電話番号
keitaitel           varchar,        --携帯番号          
jusho               varchar,        --住所
simei_yusen1        varchar,        --家族氏名1
age1                varchar,        --年齢1
zokuhyoki1          varchar,        --続柄表記1
juminkbn1           varchar,        --住民区分1
simei_yusen2        varchar,        --家族氏名2
age2                varchar,        --年齢2
zokuhyoki2          varchar,        --続柄表記2
juminkbn2           varchar,        --住民区分2
simei_yusen3        varchar,        --家族氏名3
age3                varchar,        --年齢3
zokuhyoki3          varchar,        --続柄表記3
juminkbn3           varchar,        --住民区分3
simei_yusen4        varchar,        --家族氏名4
age4                varchar,        --年齢4
zokuhyoki4          varchar,        --続柄表記4
juminkbn4           varchar,        --住民区分4
simei_yusen5        varchar,        --家族氏名5
age5                varchar,        --年齢5
zokuhyoki5          varchar,        --続柄表記5 
juminkbn5           varchar,        --住民区分5
simei_yusen6        varchar,        --家族氏名6
age6                varchar,        --年齢6
zokuhyoki6          varchar,        --続柄表記6
juminkbn6           varchar,        --住民区分6
simei_yusen7        varchar,        --家族氏名7
age7                varchar,        --年齢7 
zokuhyoki7          varchar,        --続柄表記7
juminkbn7           varchar,        --住民区分7
follownaiyoedano    integer,        --フォロー内容枝番
haakujigyocd_nm     varchar,        --フォロー把握事業
haakukeiro_nm       varchar,        --把握経路
follownaiyo         varchar,        --フォロー内容
followjigyocd_nm    varchar,        --フォロー事業
followstatus        varchar,        --フォロー状況
followyoteiymd_wareki varchar,      --フォロー予定日（和暦）
followtm_yotei      varchar,        --フォロー予定時間
followstaffid_yotei varchar,        --フォロー予定担当者
followhoho_yotei    varchar,        --フォロー予定方法
followkaijo_yotei   varchar,        --フォロー予定会場 
followriyu          varchar,        --フォロー理由
followjissiymd_wareki varchar,      --フォロー実施日（和暦）
followtm_kekka      varchar,        --フォロー結果時間
followstaffid_kekka varchar,        --フォロー結果担当者
followhoho_kekka    varchar,        --フォロー結果方法
followkaijo_kekka   varchar,        --フォロー結果会場 
followkekka         varchar,        --フォロー結果
gyoseikunm          varchar,        --行政区名
rowno               integer,        --行番号
kyohiflg            varchar,        --拒否
keikokuflg          varchar,        --警告
jyohyouflg          varchar         --除票
)
LANGUAGE plpgsql
AS $function$
BEGIN
    -----------------------------------------------
    --Crosstabのインストール
    -----------------------------------------------
   CREATE EXTENSION IF NOT EXISTS tablefunc;
    
    -----------------------------------------------
    --抽出SQL
    -----------------------------------------------
   RETURN query
SELECT
    T1.atenano              atenano,                --宛名番号
    T3.simei_kana_yusen     simei_kana_yusen,       --フリガナ
    T3.simei_yusen          simei_yusen,            --氏名
    M1.nm                   sex,                    -- 性別
    fn_eugetbymd_wareki(T3.atenano) bymd_wareki,    -- 生年月日（和暦）
    T6.tel tel,                                     -- 電話番号
    T6.keitaitel keitaitel,                         -- 携帯番号
    fn_eugetaddress(T3.atenano) jusho,              --住所

    T41.simei_yusen         simei_yusen1,           --家族氏名1
    fn_eugetage(T41.bymd, current_date) age1,       --年齢1
    T41.zokuhyoki           zokuhyoki1,             --続柄表記1
    M41.nm juminkbn1,                               --住民区分1
    
    T42.simei_yusen         simei_yusen2,           --家族氏名2
    fn_eugetage(T42.bymd, current_date) age2,       --年齢2
    T42.zokuhyoki           zokuhyoki2,             --続柄表記2
    M42.nm                  juminkbn2,              --住民区分2
    
    T43.simei_yusen         simei_yusen3,           --家族氏名3
    fn_eugetage(T43.bymd, current_date) age3,       --年齢3
    T43.zokuhyoki           zokuhyoki3,             --続柄表記3
    M43.nm                  juminkbn3,              --住民区分3
    
    T44.simei_yusen         simei_yusen4,           --家族氏名4
    fn_eugetage(T44.bymd, current_date) age4,       --年齢4
    T44.zokuhyoki           zokuhyoki4,             --続柄表記4
    M44.nm                  juminkbn4,              --住民区分4
    
    T45.simei_yusen         simei_yusen5,           --家族氏名5
    fn_eugetage(T45.bymd, current_date) age5,       --年齢5
    T45.zokuhyoki           zokuhyoki5,             --続柄表記5
    M45.nm                  juminkbn5,              --住民区分5
    
    T46.simei_yusen         simei_yusen6,           --家族氏名6
    fn_eugetage(T46.bymd, current_date) age6,       --年齢6
    T46.zokuhyoki           zokuhyoki6,             --続柄表記6
    M46.nm                  juminkbn6,              --住民区分6
    
    T47.simei_yusen         simei_yusen7,           --家族氏名7
    fn_eugetage(T47.bymd, current_date) age7,       --年齢7
    T47.zokuhyoki           zokuhyoki7,             --続柄表記7
    M47.nm                  juminkbn7,              --住民区分7
    
    T1.follownaiyoedano     follownaiyoedano,       --フォロー内容枝番
    M2.nm                   haakujigyocd_nm,        -- フォロー把握事業
    M3.nm                   haakukeiro_nm,          --把握経路
    T5.follownaiyo          follownaiyo,            --フォロー内容   
    M4.nm                   followjigyocd_nm,       -- フォロー事業
    M5.nm                   followstatus,           -- フォロー状況
    fn_euchangewareki(T1.followyoteiymd)  followyoteiymd_wareki, -- フォロー予定日（和暦）
    CAST(T1.followtm AS varchar)            followtm_yotei,      -- フォロー予定時間
    S1.staffsimei           followkaijo_yotei,      -- フォロー予定担当者
    M6.nm                   followhoho_yotei,       -- フォロー予定方法
    M8.kaijonm              followkaijo_yotei,      -- フォロー予定会場
    T1.followriyu           followriyu,             -- フォロー理由
    fn_euchangewareki(T2.followjissiymd)  followjissiymd_wareki, -- フォロー実施日（和暦）
    CAST(T2.followtm AS varchar)            followtm_kekka,      -- フォロー結果時間
    S2.staffsimei           followstaffid_kekka,    -- フォロー結果担当者
    M7.nm                   followhoho_kekka,       -- フォロー結果方法
    M9.kaijonm              followkaijo_kekka,      -- フォロー結果会場
    T2.followkekka          followkekka,            -- フォロー結果
    fn_eugetgyoseikunm(T1.atenano ) gyoseikunm,     -- 行政区名
    CAST(ROW_NUMBER() OVER (PARTITION BY T1.atenano ORDER BY T1.followyoteiymd) AS integer) rowno, --行番号
    fn_eugetkyohiflg(T1.atenano,'0020') kyohiflg,   --拒否
    fn_eugetkeikokuflg(T1.atenano) keikokuflg,      --警告
    fn_eugetjyohyouflg(T1.atenano) jyohyouflg       --除票
    
    FROM tt_kkfollowyotei T1    --フォロー予定情報テーブル
    LEFT JOIN tt_kkfollowkekka T2 ON T1.atenano = T2.atenano AND T1.follownaiyoedano = T2.follownaiyoedano AND T1.edano = T2.edano  
    LEFT JOIN tt_afatena T3 ON T1.atenano = T3.atenano      
    LEFT JOIN (
        --家族（宛名番号を取得）
        --cross table
         SELECT * FROM
            crosstab( 
                'SELECT t1.atenano atenano,
                  ROW_NUMBER() OVER (PARTITION BY t1.atenano ORDER BY t2.zokucd1) rowno ,
                  t2.atenano atenano_sub
                 FROM tt_afatena t1
                 JOIN tt_afatena t2 ON t1.setaino = t2.setaino 
                 WHERE t1.atenano<>t2.atenano
                 ORDER BY 1,2'
            ) AS pvt( 
                atenano varchar (15)
                ,atenano_sub1 varchar(15)
                ,atenano_sub2 varchar(15)
                ,atenano_sub3 varchar(15)
                ,atenano_sub4 varchar(15)
                ,atenano_sub5 varchar(15)
                ,atenano_sub6 varchar(15)
                ,atenano_sub7 varchar(15)
            ))T4 ON T1.atenano = T4.atenano 
    LEFT JOIN tt_afatena T41 ON T4.atenano_sub1=T41.atenano LEFT JOIN tm_afmeisyo M41 ON T41.juminkbn=M41.nmcd AND M41.nmmaincd='1000' AND M41.nmsubcd=41
    LEFT JOIN tt_afatena T42 ON T4.atenano_sub2=T42.atenano LEFT JOIN tm_afmeisyo M42 ON T42.juminkbn=M42.nmcd AND M42.nmmaincd='1000' AND M42.nmsubcd=41
    LEFT JOIN tt_afatena T43 ON T4.atenano_sub3=T43.atenano LEFT JOIN tm_afmeisyo M43 ON T43.juminkbn=M43.nmcd AND M43.nmmaincd='1000' AND M43.nmsubcd=41
    LEFT JOIN tt_afatena T44 ON T4.atenano_sub4=T44.atenano LEFT JOIN tm_afmeisyo M44 ON T44.juminkbn=M44.nmcd AND M44.nmmaincd='1000' AND M44.nmsubcd=41
    LEFT JOIN tt_afatena T45 ON T4.atenano_sub5=T45.atenano LEFT JOIN tm_afmeisyo M45 ON T45.juminkbn=M45.nmcd AND M45.nmmaincd='1000' AND M45.nmsubcd=41
    LEFT JOIN tt_afatena T46 ON T4.atenano_sub6=T46.atenano LEFT JOIN tm_afmeisyo M46 ON T46.juminkbn=M46.nmcd AND M46.nmmaincd='1000' AND M46.nmsubcd=41
    LEFT JOIN tt_afatena T47 ON T4.atenano_sub7=T47.atenano LEFT JOIN tm_afmeisyo M47 ON T47.juminkbn=M47.nmcd AND M47.nmmaincd='1000' AND M47.nmsubcd=41
    LEFT JOIN tm_afmeisyo M1 ON T3.sex = M1.nmcd AND  M1.nmmaincd='1000'AND M1.nmsubcd= 72
    LEFT JOIN tt_kkfollownaiyo T5 ON T1.atenano=T5.atenano AND T1.follownaiyoedano=T5.follownaiyoedano
    LEFT JOIN tm_afhanyo M2 ON T5.haakujigyocd = M2.hanyocd AND  M2.hanyomaincd='3019'AND M2.hanyosubcd= 100006
    LEFT JOIN tm_afmeisyo M3 ON T5.haakukeiro = M3.nmcd AND M3.nmmaincd='2019'AND M3.nmsubcd= 32 
    LEFT JOIN tm_afhanyo M4 ON T1.followjigyocd = M4.hanyocd AND  M4.hanyomaincd='3019' AND M4.hanyosubcd= 100007
    LEFT JOIN tm_afmeisyo M5 ON T5.followstatus = M5.nmcd AND M5.nmmaincd='2019'AND M5.nmsubcd= 34 
    LEFT JOIN tt_afrenrakusaki T6 ON T5.atenano = T6.atenano  AND T6.jigyocd = '000'
    LEFT JOIN tm_afstaff S1 ON  T1.followstaffid = S1.staffid 
    LEFT JOIN tm_afstaff S2 ON  T2.followstaffid = S2.staffid
    LEFT JOIN tm_afmeisyo M6 ON T1.followhoho = M6.nmcd AND M6.nmmaincd='2019'AND M6.nmsubcd= 33
    LEFT JOIN tm_afmeisyo M7 ON T2.followhoho = M7.nmcd AND M7.nmmaincd='2019'AND M7.nmsubcd= 33
    LEFT JOIN tm_afkaijo M8 ON T1.followkaijocd = M8.kaijocd
    LEFT JOIN tm_afkaijo M9 ON T2.followkaijocd = M9.kaijocd
    -----------------------------------------------
    --検索条件
    -----------------------------------------------
    WHERE 
        (haakukeiro_in IS NULL OR T5.haakukeiro = haakukeiro_in)
        AND (haakujigyocd_in IS NULL OR T5.haakujigyocd = haakujigyocd_in)  
        AND (followjigyocd_in IS NULL OR T1.followjigyocd = followjigyocd_in)
        AND(followstatus_in IS NULL OR T5.followstatus = followstatus_in)
        AND (juminkbn_in IS NULL OR T3.juminkbn < juminkbn_in)
    -----------------------------------------------
    --並び替え
    -----------------------------------------------
    ORDER BY simei_kana_yusen, bymd_wareki, atenano,rowno;
END;
$function$

