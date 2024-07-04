/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 予防接種予診票（乳幼児）の対象者抽出（接種種別：三種混合）
　　　　　　
作成日　　: 2024.05.17
作成者　　: 陳
変更履歴　:
*******************************************************************/
CREATE OR REPLACE PROCEDURE sp_YS99999G_ysyosinhyonyu(
    tyusyututaisyocd_in varchar,          --【ストアド固定】抽出対象コード
    tyusyutudatasyosaikbn_in varchar,     --【ストアド固定】抽出データ詳細区分（業務によって検診種別、月齢区分、接種種別など）
    atenano_in varchar,                   --【ストアド固定】宛名番号
    tyusyutunaiyo_in varchar,             --【ストアド固定】抽出内容
    nendo_in integer,                     --【ストアド固定】年度
    regsisyo_in varchar,                  --【ストアド固定】登録支所
    userid_in varchar,                    --【ストアド固定】ユーザーID
    OUT tyusyutuseq_out bigint,           --【戻り値】抽出シーケンス
    bymdf_in varchar,                     --【抽出条件】生年月日（FROM）
    bymdt_in varchar,                     --【抽出条件】生年月日（TO）
    --agef_in integer,                      --【抽出条件】年齢（FROM）
    --aget_in integer,                      --【抽出条件】年齢（TO）  
    kijunymd_in varchar                   --【検索条件以外】年齢計算基準日
                                          --※成人保健の場合、発番順や券番号などのパラメータを追加する必要があるけど
)
LANGUAGE plpgsql AS $$
DECLARE
    tmp_atena RECORD;
    saityusyutujogaiflg_m boolean;
    nendo_m integer;
    tuticycle_m integer;
    f_m varchar(10);
    t_m varchar(10);
    KOBETU_NAIYO varchar := '個別抽出';            --個別抽出の場合、抽出内容は固定値「個別抽出」

    -----------------------------------------------
    --検索条件や検索条件以外など、抽出の条件に当たる
    --対象者抽出情報項目コントロールマスタで管理する項目の項目IDをすべて記載する
    -----------------------------------------------
    ITEMCD_KIJUNYMD varchar := '200400904001';    --検索条件以外：年齢計算基準日の項目IDを仮に採番
    ITEMCD_BYMDF varchar := '200400901001';        --検索条件：生年月日（FROM）の項目IDを仮に採番
    ITEMCD_BYMDT varchar := '200400902001';        --検索条件：生年月日（TO）の項目IDを仮に採番  
BEGIN
    BEGIN
        --抽出シーケンスを採番する
        tyusyutuseq_out := COALESCE((SELECT MAX(tyusyutuseq) FROM tt_kktaisyosya_tyusyutu), 0) + 1;

        --年度を取得する
        SELECT tuticycle INTO tuticycle_m
        FROM tm_kktyusyutu M1
        WHERE M1.tyusyututaisyocd = tyusyututaisyocd_in;

        IF tuticycle_m = 1 THEN                          
            nendo_m := nendo_in;                           --年度管理する場合、セットする
        ELSIF tuticycle_m = 2 THEN
            nendo_m = 9999;                                --年度管理しない場合は「(固定値)9999」を設定
        END IF;
        
        IF atenano_in IS NOT NULL THEN
            --個別抽出の場合
            --対象者抽出情報テーブルの情報をINSERT
            INSERT INTO tt_kktaisyosya_tyusyutu
            VALUES (
                tyusyutuseq_out,
                nendo_m,
                tyusyututaisyocd_in,
                2,                                      --個別抽出
                KOBETU_NAIYO,                           --固定の抽出内容「個別抽出」
                regsisyo_in,
                userid_in,
                CURRENT_TIMESTAMP,
                userid_in,
                CURRENT_TIMESTAMP
            );
            
            --対象者抽出情報項目テーブルの情報をINSERT
            INSERT INTO tt_kktaisyosya_tyusyutufree
            VALUES (
                tyusyutuseq_out,
                ITEMCD_KIJUNYMD,                        --個別抽出の場合、年齢計算基準日だけ
                FALSE,
                NULL,
                kijunymd_in
            );
            
            --対象者抽出情報サブテーブルの情報をINSERT
            INSERT INTO tt_kktaisyosya_tyusyutu_sub
            VALUES (
                tyusyutuseq_out,
                atenano_in,
                userid_in,
                CURRENT_TIMESTAMP,
                userid_in,
                CURRENT_TIMESTAMP
            );
        ELSE
            --全体抽出の場合
            --検索条件が年齢の場合、日付に変換する
            --IF agef_in IS NOT NULL THEN
            --    f_m := to_char(CAST(kijunymd_in AS DATE) - CAST(agef_in || ' years' AS INTERVAL), 'YYYY-MM-DD');   
            --END IF;

            --IF aget_in IS NOT NULL THEN
            --    t_m := to_char(CAST(kijunymd_in AS DATE) - CAST(aget_in || ' years' AS INTERVAL), 'YYYY-MM-DD');   
            --END IF;

            --対象者を抽出（除外を含め、該当する対象者を一時テーブルにINSERTする）
            SELECT saityusyutujogaiflg INTO saityusyutujogaiflg_m
            FROM tm_kktyusyutu M1
            WHERE M1.tyusyututaisyocd = tyusyututaisyocd_in;
            
            IF saityusyutujogaiflg_m = FALSE THEN
                IF tyusyutudatasyosaikbn_in = '10013' THEN
                    --三種混合の対象者を抽出する（再抽出除外はしない）
                    CREATE TEMP TABLE TMP AS
                    SELECT T1.atenano
                    FROM tt_afatena T1
                    INNER JOIN VW_YSYOSINTAI240 V1 ON T1.atenano = V1.atenano       --未接種の対象者を抽出するビュー
                    WHERE 
                        --除票者を除く
                        T1.juminkbn < '5'
                        --年齢もしくは生年月日が検索条件に該当する対象者を抽出
                        --＊年齢は本システムに使わないので不要
                        AND T1.bymd_fusyoflg = FALSE
                        --AND (agef_in IS NOT NULL OR T1.bymd >= f_m)
                        --AND (aget_in IS NOT NULL OR T1.bymd <= t_m);
                        AND (bymdf_in IS NULL OR T1.bymd >= bymdf_in)
                        AND (bymdt_in IS NULL OR T1.bymd <= bymdt_in);
                --ELSIF tyusyutudatasyosaikbn_in = '10014' THEN:
                    --ここに他のワクチン対象者を抽出するロジックを追加★
                END IF;
            ELSE
                IF tyusyutudatasyosaikbn_in = '10013' THEN
                    --三種混合の対象者を抽出する（再抽出除外はする）
                    CREATE TEMP TABLE TMP AS
                    SELECT T1.atenano
                    FROM tt_afatena T1
                        INNER JOIN VW_YSYOSINTAI240 V1 ON T1.atenano = V1.atenano       --未接種の対象者を抽出するビュー
                        LEFT JOIN (
                            --抽出済の対象者を取得
                            SELECT DISTINCT T3.atenano 
                            FROM tt_kktaisyosya_tyusyutu_sub T3
                            INNER JOIN tt_kktaisyosya_tyusyutu T4
                            ON tyusyututaisyocd_in = T4.tyusyututaisyocd
                            AND T3.tyusyutuseq = T4.tyusyutuseq
                        ) T2 ON T1.atenano = T2.atenano
                    WHERE 
                        --除票者を除く
                        T1.juminkbn < '5'
                        --抽出済みの対象者を除外
                        AND T2.atenano IS NULL
                        --年齢もしくは生年月日が検索条件に該当する対象者を抽出
                        AND T1.bymd_fusyoflg IS FALSE
                        --AND (agef_in IS NOT NULL OR T1.bymd >= f_in)
                        --AND (aget_in IS NOT NULL OR T1.bymd <= t_in);
                        AND (bymdf_in IS NULL OR T1.bymd >= bymdf_in)
                        AND (bymdt_in IS NULL OR T1.bymd <= bymdt_in);
                --ELSIF tyusyutudatasyosaikbn_in = '10014' THEN:
                    --ここに他のワクチン対象者を抽出するロジックを追加★
                END IF;
            END IF;
           
            --対象者抽出情報テーブルの情報をINSERT
            INSERT INTO tt_kktaisyosya_tyusyutu
            VALUES (
                tyusyutuseq_out,
                nendo_m,
                tyusyututaisyocd_in,
                1,                              --全体抽出
                tyusyutunaiyo_in,                        
                regsisyo_in,
                userid_in,
                CURRENT_TIMESTAMP,
                userid_in,
                CURRENT_TIMESTAMP
            );
            
            --対象者抽出情報項目テーブルの情報をINSERT
            --（検索条件や検索条件以外など、抽出の条件に当たる）
            --対象者抽出情報項目コントロールマスタで管理する項目の情報をすべてINSERTする
            --★フリー項目は設定により可変であるので、現在の引数は固定でされているけど、
            --　実装するときはLISTなどに修正する必要があるかもしれない。
            INSERT INTO tt_kktaisyosya_tyusyutufree
            VALUES 
                (tyusyutuseq_out, ITEMCD_KIJUNYMD, FALSE, NULL, kijunymd_in),
                (tyusyutuseq_out, ITEMCD_BYMDF, FALSE, NULL, bymdf_in),
                (tyusyutuseq_out, ITEMCD_BYMDT, FALSE, NULL, bymdt_in);
            
            --対象者抽出情報サブテーブルの情報をINSERT
            INSERT INTO tt_kktaisyosya_tyusyutu_sub
            SELECT 
                tyusyutuseq_out,
                TMP.atenano,
                userid_in,
                CURRENT_TIMESTAMP,
                userid_in,
                CURRENT_TIMESTAMP
            FROM TMP;  
        END IF;
    EXCEPTION
        WHEN OTHERS THEN
            RAISE;
    END;
END;
$$;