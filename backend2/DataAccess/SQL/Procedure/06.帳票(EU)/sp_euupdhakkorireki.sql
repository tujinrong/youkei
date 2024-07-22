/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票発行履歴更新
　　　　　　
作成日　　: 2024.06.06
作成者　　: 呉
変更履歴　:
*******************************************************************/
CREATE OR REPLACE PROCEDURE sp_euupdhakkorireki(
    P_TYUSYUTU_SEQ bigint,                          -- 抽出シーケンス
    P_HAKKODATASYOSAI_KBN varchar,                  -- 発行データ詳細区分
    P_WORK_SEQ bigint,                              -- ワークシーケンス
    P_NENDO integer,                                -- 年度
    hassoymd_in varchar,                            -- 発送日
    hakkokbn_in varchar,                            -- 発行区分
    hakkobasyo_in varchar,                          -- 発行場所
    P_SHUTU_KBN integer,                            -- 出力区分
    P_RPT_ID varchar,                               -- 帳票ID
    P_YOSIKI_ID varchar,                            -- 様式ID
    P_USER_ID varchar,                              -- ユーザID
    P_SISYO varchar,                                -- 登録支所
    P_RIREKI_UPD_FLG boolean,                       -- 発行履歴更新フラグ
    P_NINSANPU_FLG boolean                          -- 妊産婦フラグ
) 
LANGUAGE plpgsql AS $procedure$
 DECLARE 
 -- 発行シーケンス
 hakkoseq_m bigint; 
 --対象数
cnt_t int;

BEGIN          

IF P_RIREKI_UPD_FLG THEN                                  

    SELECT COUNT(*) INTO cnt_t FROM 
        wk_euatena_sub W1 
    WHERE
        W1.workseq = P_WORK_SEQ 
        AND formflg;
    
    IF cnt_t > 0 THEN        
    
        -- 採番する
        hakkoseq_m := COALESCE( (SELECT MAX(hakkoseq) FROM tt_kkrpthakkorireki), 0) + 1; 
        
        -----------------------------------------------
        --帳票発行履歴テーブルの作成
        -----------------------------------------------     
        
        INSERT 
        INTO tt_kkrpthakkorireki 
        VALUES ( 
            hakkoseq_m,                                 -- 発行シーケンス
            P_RPT_ID,                                   -- 帳票ID
            P_YOSIKI_ID,                                -- 様式ID
            P_SHUTU_KBN,                                -- 出力方式
            P_HAKKODATASYOSAI_KBN,                      -- 発行データ詳細区分(紐付けコードをセット）
            P_TYUSYUTU_SEQ,                             -- 抽出シーケンス
            P_NENDO,                                    -- 年度
            hassoymd_in,                                -- 発送日
            hakkokbn_in,                                -- 発行区分
            hakkobasyo_in,                              -- 発行場所
            P_SISYO,                                    -- 登録支所
            P_USER_ID,                                  -- 登録ユーザーID
            CURRENT_TIMESTAMP,                          -- 登録日時
            P_USER_ID,                                  -- 更新ユーザーID
            CURRENT_TIMESTAMP                           -- 更新日時
        ); 
        
        -----------------------------------------------
        --帳票発行履歴サブテーブルの作成
        -----------------------------------------------
        -- 妊産婦場合
        IF P_NINSANPU_FLG THEN   
            INSERT 
            INTO tt_kkrpthakkorireki_sub 
            SELECT
                hakkoseq_m,                                 --発行シーケンス
                W1.atenano,                                 --宛名番号
                W1.torokuno,                                --妊産婦登録番号
                P_USER_ID,                                  --登録ユーザーID
                CURRENT_TIMESTAMP,                          --登録日時
                P_USER_ID,                                  --更新ユーザーID
                CURRENT_TIMESTAMP                           --更新日時
            FROM
                wk_euninsanpu_sub W1   --妊産婦WKテーブル
                INNER JOIN wk_euatena_sub W2  --宛名WKテーブル
                ON W2.workseq=W1.workseq
                AND W2.atenano=W1.atenano
                AND W2.formflg
            WHERE
                W1.workseq = P_WORK_SEQ 
                AND formflg; 
        ELSE
            INSERT 
            INTO tt_kkrpthakkorireki_sub 
            SELECT
                hakkoseq_m,                                 --発行シーケンス
                W1.atenano,                                 --宛名番号
                0,                                          --妊産婦登録番号
                P_USER_ID,                                  --登録ユーザーID
                CURRENT_TIMESTAMP,                          --登録日時
                P_USER_ID,                                  --更新ユーザーID
                CURRENT_TIMESTAMP                           --更新日時
            FROM
                wk_euatena_sub W1   --宛名WKテーブル
            WHERE
                W1.workseq = P_WORK_SEQ 
                AND formflg; 
        END IF;
    
    END IF;

END IF;
    
END; 

$procedure$

