/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票発行対象者抽出情報管理（専用）
			個別抽出情報一覧抽出
作成日　　: 2024.06.07
作成者　　: 陳
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION sp_awkk01301g_02_head(
    nendo_in integer,
    tyusyututaisyocd_in character varying,
    tyusyutunaiyo_in character varying,
    regdttmf_in character varying,
    regdttmt_in character varying,
    tyusyutukinoid_in character varying
)
RETURNS INTEGER
LANGUAGE plpgsql
AS $FUNCTION$
DECLARE
    total integer;
	tyusyutunaiyo_m character varying := '';
    regdttmf_in2 timestamp without time zone;
	regdttmt_in2 timestamp without time zone;
BEGIN
    tyusyutunaiyo_m := '%' || tyusyutunaiyo_in || '%' ;
    regdttmf_in2 := to_timestamp(regdttmf_in, 'YYYY-MM-DD HH24:MI:SS');
	regdttmt_in2 := to_timestamp(regdttmt_in, 'YYYY-MM-DD HH24:MI:SS');
    
    WITH filtered_data AS (
        SELECT
            t1.tyusyutuseq,
            t1.tyusyututaisyocd,
            m1.tyusyututaisyonm,
            t1.nendo,
            t1.tyusyutunaiyo,
            t1.regdttm,
            t2.atenano
        FROM
            tt_kktaisyosya_tyusyutu t1
        JOIN tt_kktaisyosya_tyusyutu_sub t2
            ON t1.tyusyutuseq = t2.tyusyutuseq
        LEFT JOIN tm_kktyusyutu m1
            ON t1.tyusyututaisyocd = m1.tyusyututaisyocd
        WHERE
            m1.sinkidatatenyuryokuflg = false
            AND t1.zentaikobetukbn = '2'                                                             --個別抽出のみ
            AND (tyusyututaisyocd_in IS NULL OR m1.tyusyututaisyocd = tyusyututaisyocd_in)
            AND (tyusyutukinoid_in IS NULL OR m1.tyusyutukinoid = tyusyutukinoid_in)
            AND (tyusyutunaiyo_in IS NULL OR t1.tyusyutunaiyo LIKE tyusyutunaiyo_m)
            AND (regdttmf_in IS NULL OR t1.regdttm >= to_timestamp(regdttmf_in, 'YYYY-MM-DD'))
            AND (regdttmt_in IS NULL OR t1.regdttm <= to_timestamp(regdttmt_in, 'YYYY-MM-DD'))
            AND (nendo_in IS NULL OR t1.nendo = nendo_in)
    )
    SELECT
        COUNT(1) total INTO total
    FROM
    (
        SELECT
            f1.tyusyututaisyocd,
            f1.tyusyututaisyonm,
            f1.nendo,
            MAX(f1.regdttm) AS regdttm,
            f1.tyusyutunaiyo,
            COUNT(DISTINCT f1.atenano) AS tyusyutunum
        FROM
            filtered_data f1
        GROUP BY
            f1.tyusyututaisyocd,
            f1.tyusyututaisyonm,
            f1.nendo,
            f1.tyusyutunaiyo
    ) t4;
    RETURN total;
END;
$FUNCTION$
/*==============================body==============================*/
CREATE OR REPLACE FUNCTION sp_awkk01301g_02_body(
    nendo_in integer,
    tyusyututaisyocd_in character varying,
    tyusyutunaiyo_in character varying,
    regdttmf_in character varying,
    regdttmt_in character varying,
    tyusyutukinoid_in character varying,
    orderby_in integer,
    limit_in integer,
    offset_in integer
)
RETURNS TABLE (
    tyusyutuseq bigint,                                         --抽出シーケンス
    tyusyututaisyocd character varying,                         --抽出対象コード
    tyusyututaisyonm character varying,                         --抽出対象名
    nendo integer,                                              --年度
    tyusyutunaiyo character varying,                            --抽出内容
    tyusyutunum integer,                                        --抽出人数
    regdttm timestamp without time zone                         --登録日時
)
LANGUAGE plpgsql
AS $FUNCTION$
DECLARE
	tyusyutunaiyo_m character varying := '';
    regdttmf_in2 timestamp without time zone;
	regdttmt_in2 timestamp without time zone;
BEGIN
    tyusyutunaiyo_m := '%' || tyusyutunaiyo_in || '%' ;
    regdttmf_in2 := to_timestamp(regdttmf_in, 'YYYY-MM-DD HH24:MI:SS');
	regdttmt_in2 := to_timestamp(regdttmt_in, 'YYYY-MM-DD HH24:MI:SS');
    
    RETURN QUERY
    WITH filtered_data AS (
        SELECT
            t1.tyusyutuseq,
            t1.tyusyututaisyocd,
            m1.tyusyututaisyonm,
            t1.nendo,
            t1.tyusyutunaiyo,
            t1.regdttm,
            t2.atenano
        FROM
            tt_kktaisyosya_tyusyutu t1
        JOIN tt_kktaisyosya_tyusyutu_sub t2
            ON t1.tyusyutuseq = t2.tyusyutuseq
        LEFT JOIN tm_kktyusyutu m1
            ON t1.tyusyututaisyocd = m1.tyusyututaisyocd
        WHERE
            m1.sinkidatatenyuryokuflg = FALSE
            AND t1.zentaikobetukbn = '2'                                                            --個別抽出のみ
            AND (tyusyututaisyocd_in IS NULL OR m1.tyusyututaisyocd = tyusyututaisyocd_in)
            AND (tyusyutukinoid_in IS NULL OR m1.tyusyutukinoid = tyusyutukinoid_in)
            AND (tyusyutunaiyo_in IS NULL OR t1.tyusyutunaiyo LIKE tyusyutunaiyo_m)
            AND (regdttmf_in IS NULL OR t1.regdttm >= to_timestamp(regdttmf_in, 'YYYY-MM-DD'))
            AND (regdttmt_in IS NULL OR t1.regdttm <= to_timestamp(regdttmt_in, 'YYYY-MM-DD'))
            AND (nendo_in IS NULL OR t1.nendo = nendo_in)
    )
    SELECT
        NULL::bigint AS tyusyutuseq,                            --抽出シーケンス
        t4.tyusyututaisyocd::character varying,                 --抽出対象コード
        t4.tyusyututaisyonm::character varying,                 --抽出対象名
        t4.nendo::integer,                                      --年度
        t4.tyusyutunaiyo::character varying,                    --抽出内容
        t4.tyusyutunum::integer,                                --抽出人数
        t4.regdttm::timestamp without time zone                 --抽出日
    FROM
    (
        SELECT
            f1.tyusyututaisyocd,
            f1.tyusyututaisyonm,
            f1.nendo,
            MAX(f1.regdttm) AS regdttm,
            f1.tyusyutunaiyo,
            COUNT(DISTINCT f1.atenano) AS tyusyutunum
        FROM
            filtered_data f1
        GROUP BY
            f1.tyusyututaisyocd,
            f1.tyusyututaisyonm,
            f1.nendo,
            f1.tyusyutunaiyo
    ) t4
    ORDER BY
         case when orderby_in = 0 then t4.regdttm end desc                          --登録日時　　　　　　      降順（デフォルト）
		
        ,case when orderby_in = 1 then t4.nendo end                                 --年度		            昇順
		,case when orderby_in = -1 then t4.nendo end desc                           --年度			            降順
		
        ,case when orderby_in = 2 then t4.tyusyututaisyonm end				        --抽出対象名	        昇順
		,case when orderby_in = -2 then t4.tyusyututaisyonm end desc			    --抽出対象名		        降順
		
        ,case when orderby_in = 3 then t4.tyusyutunaiyo end			                --抽出内容				昇順
		,case when orderby_in = -3 then t4.tyusyutunaiyo end desc	                --抽出内容					降順
		
        ,case when orderby_in = 4 then t4.tyusyutunum end				            --抽出人数				昇順
		,case when orderby_in = -4 then t4.tyusyutunum end desc		                --抽出人数					降順
		
        ,case when orderby_in = 5 then t4.regdttm end			                    --登録日時				昇順
		,case when orderby_in = -5 then t4.regdttm end desc	                        --登録日時					降順
    
    LIMIT limit_in OFFSET offset_in;

END;
$FUNCTION$