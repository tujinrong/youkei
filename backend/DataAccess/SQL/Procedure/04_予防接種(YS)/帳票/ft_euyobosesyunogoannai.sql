/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 予防接種のご案内
　　　　　　
作成日　　: 2024.05.15
作成者　　: 屠
変更履歴　:
*******************************************************************/
CREATE OR REPLACE FUNCTION ft_euyobosesyunogoannai(
    P_TYUSYUTU_SEQ bigint,                          --【固定条件】抽出シーケンス
    P_TYUSYUTU_KBN character varying,               --【紐付け条件】紐付け一覧のコード
    P_KIJYUNBI character varying,                   --【画面検索条件以外】基準日
    jyohyo_in character varying,                    --【画面検索条件以外】除票【9：含む、5：含まない】
    P_WORK_SEQ bigint,                              --【システム固定パラメータ】ワークシーケンス
    P_YOSIKI_SYUBETU character varying              --【システム固定パラメータ】様式種別
)
RETURNS TABLE(
atenano         varchar,                            --宛名番号
kaisu           int,                                --回数
simei           varchar,                            --氏名
simei_kana      varchar,                            --氏名_フリガナ
age             varchar,                            --年齢
sexnm           varchar,                            --性別
adrs            varchar,                            --住所
jissiymd1       varchar,                            --4混1期初1
jissiymd2       varchar,                            --4混1期初2
jissiymd3       varchar,                            --4混1期初3
jissiymdtuika   varchar,                            --4混1期初追加
johyoflg character varying                          --除票
)
LANGUAGE plpgsql AS $function$
DECLARE
    row_m RECORD; 
    secnt_m int; -- ワクチン接種総回数
    cnt_m int; -- 接種回数
BEGIN

    -- ワクチン接種総回数を取得
    SELECT COUNT(*)
    INTO secnt_m
    FROM tm_afhanyo
    WHERE hanyomaincd = '3019'
        AND hanyosubcd = 400001
        AND hanyocd LIKE SUBSTRING(P_TYUSYUTU_KBN FROM 1 FOR 5) || '%';
        
    -----------------------------------------------
    -- 対象者検索一時テーブルを作成
    -----------------------------------------------
    CREATE TEMP TABLE TMP( 
        atenano varchar                             --宛名番号
        , kaisu int                                 --回数
        , simei varchar                             --氏名
        , simei_kana varchar                        --氏名_フリガナ
        , age varchar                               --年齢
        , sexnm varchar                             --性別
        , adrs varchar                              --住所
        , jissiymd1 varchar                         --4混1期初1
        , jissiymd2 varchar                         --4混1期初2
        , jissiymd3 varchar                         --4混1期初3
        , jissiymdtuika varchar                     --4混1期初追加
        , jyohyoflg varchar                         --除票フラグ
        , cnt int                                   --接種回数合計
    ); 

    INSERT INTO TMP
    SELECT
        T2.atenano,                                 -- 宛名番号
        1,                                          --回数
        T2.simei,                                   -- 氏名
        T2.simei_kana,                              -- 氏名_フリガナ
        fn_eugetage(T2.bymd, P_KIJYUNBI::DATE),    -- 年齢
        M1.nm AS sexnm,                             -- 性別
        T2.adrs1 || T2.adrs2 AS adrs,               -- 住所
        '' AS jissiymd1,                            --予診票の場合、接種日を出力しない
        '' AS jissiymd2,
        '' AS jissiymd3,
        '' AS jissiymdtuika,
        CASE
            WHEN jyohyo_in = '9'
                AND ((P_YOSIKI_SYUBETU = '1' AND T2.juminkbn >= '5')
                OR (P_YOSIKI_SYUBETU = '2' AND (COALESCE(YS.cnt, 0) = secnt_m OR T2.juminkbn >= '5')))
                THEN '〇'
            ELSE ''
        END AS jyohyoflg,                           --除票フラグ
        COALESCE(YS.cnt, 0) AS cnt                  -- 接種回数合計
    FROM tt_kktaisyosya_tyusyutu_sub T1             --対象者抽出情報サブテーブル
        INNER JOIN tt_afatena T2                    --宛名テーブル
            ON T1.atenano = T2.atenano
        LEFT JOIN tm_afmeisyo M1                    --名称マスタ(性別)
            ON T2.sex = M1.nmcd
            AND M1.nmmaincd = '1000'
            AND M1.nmsubcd = 72
        LEFT JOIN (
            SELECT
                T3.atenano AS ys_atenano,
                COUNT(T3.atenano) AS cnt            -- 接種回数合計
            FROM tt_yssessyu T3                     --予防接種テーブル
            WHERE T3.sessyucd = SUBSTRING(P_TYUSYUTU_KBN FROM 1 FOR 5)
            GROUP BY T3.atenano
        ) YS 
            ON T1.atenano = YS.ys_atenano
    WHERE T1.tyusyutuseq = P_TYUSYUTU_SEQ           --抽出シーケンス
        AND ((P_YOSIKI_SYUBETU = '1' AND COALESCE(YS.cnt, 0) < secnt_m AND ((jyohyo_in = '9') OR (jyohyo_in = '5' AND T2.juminkbn < '5')))
        OR (P_YOSIKI_SYUBETU = '2' AND ((jyohyo_in = '9') OR (jyohyo_in = '5' AND COALESCE(YS.cnt, 0) < secnt_m AND T2.juminkbn < '5'))));

    -----------------------------------------------
    -- 対象者回数一時テーブルを作成
    -----------------------------------------------
    CREATE TEMP TABLE TMP2(
        atenano varchar,                        -- 宛名番号
        kaisu int,                              -- 回数
        simei varchar,                          -- 氏名
        simei_kana varchar,                     -- 氏名_フリガナ
        age varchar,                            -- 年齢
        sexnm varchar,                          -- 性別
        adrs varchar,                           -- 住所
        jissiymd1 varchar,                      -- 4混1期初1
        jissiymd2 varchar,                      -- 4混1期初2
        jissiymd3 varchar,                      -- 4混1期初3
        jissiymdtuika varchar,                  -- 4混1期初追加
        jyohyoflg varchar                       -- 除票フラグ
    );

    -----------------------------------------------
    -- 接種回数処理
    -- 様式種別が「1:予診票」の場合、残り接種回数分の宛名データを作成
    -- 様式種別が「2:予診票以外」の場合、人数分の宛名データを作成
    -----------------------------------------------

    -- 様式種別が「1:予診票」の場合、ワクチンの予診票の紐づけコードを判断条件に入れる
    IF P_YOSIKI_SYUBETU = '1' THEN
        FOR row_m IN
            SELECT TMP.atenano, TMP.cnt AS cnt
            FROM TMP
        LOOP
            cnt_m := secnt_m - row_m.cnt - 1;

            FOR i IN 0..cnt_m LOOP
                INSERT INTO TMP2
                SELECT
                    T1.atenano,
                    i + 1,                      -- 回数
                    T1.simei,
                    T1.simei_kana,
                    T1.age,
                    T1.sexnm,
                    T1.adrs,
                    '' AS jissiymd1,            -- 予診票の場合、接種日を出力しない
                    '' AS jissiymd2,
                    '' AS jissiymd3,
                    '' AS jissiymdtuika,
                    T1.jyohyoflg
                FROM TMP T1
                WHERE T1.atenano = row_m.atenano;
            END LOOP;
        END LOOP;
    END IF;

    -- 様式種別が「2:予診票以外」の場合
    IF P_YOSIKI_SYUBETU = '2' THEN
        INSERT INTO TMP2
        SELECT
            T1.atenano,
            1,                                  -- 回数が固定の１
            T1.simei,
            T1.simei_kana,
            T1.age,
            T1.sexnm,
            T1.adrs,
            YS.jissiymd1,                       -- 予診票以外の場合、接種日を出力
            YS.jissiymd2,
            YS.jissiymd3,
            YS.jissiymdtuika,
            T1.jyohyoflg
        FROM TMP T1
        LEFT JOIN (
            SELECT
                T2.atenano AS ys_atenano,
                MAX(CASE WHEN T2.kaisu = '11' THEN jissiymd END) AS jissiymd1,
                MAX(CASE WHEN T2.kaisu = '12' THEN jissiymd END) AS jissiymd2,
                MAX(CASE WHEN T2.kaisu = '13' THEN jissiymd END) AS jissiymd3,
                MAX(CASE WHEN T2.kaisu = '19' THEN jissiymd END) AS jissiymdtuika
            FROM tt_yssessyu T2
            WHERE T2.sessyucd = SUBSTRING(P_TYUSYUTU_KBN FROM 1 FOR 5)
            GROUP BY T2.atenano
        ) YS ON T1.atenano = YS.ys_atenano;
    END IF;

    -----------------------------------------------
    -- 結果を返す
    -----------------------------------------------
    RETURN QUERY
    SELECT *
    FROM TMP2;

    DROP TABLE IF EXISTS TMP;
    DROP TABLE IF EXISTS TMP2;

END;
$function$;