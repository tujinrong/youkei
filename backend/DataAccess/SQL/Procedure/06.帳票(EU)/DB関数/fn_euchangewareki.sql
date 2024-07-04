/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票使用
            日付を和暦へ変更
　　　　　　
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_euchangewareki(
ymd_seireki_in character varying    --日付（西暦）
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
    wareki_year varchar;
    integer_year integer;
    gengo varchar;
    ymd_data varchar;
    ymd_month varchar;
    ymd_day varchar;
    ymd_wareki varchar;
BEGIN
    ymd_data = ymd_seireki_in;
     --年月日が不詳の場合、不詳を表示
    IF ymd_data >= '2019-05-01' THEN
        gengo := '令和';
        integer_year := cast(substr(ymd_data,1,4) as integer) - 2018; -- 令和元年は2019年
        IF integer_year<10 THEN
            wareki_year := '0' || cast(integer_year as varchar);
        ELSE
            wareki_year := cast(integer_year as varchar);
        END IF;
        ymd_month := substr(ymd_data,6,2) || '月';
        ymd_day := substr(ymd_data,9,2) || '日';
        ymd_wareki := gengo || wareki_year || '年' || ymd_month || ymd_day;
        RETURN ymd_wareki;
    -- 平成の判定（1989年1月8日から2019年4月30日まで）  
    ELSEIF ymd_data >= '1989-01-08' AND ymd_data < '2019-05-01' THEN
        gengo := '平成';
        integer_year := cast(substr(ymd_data,1,4) as integer) - 1988; -- 平成元年は1989年
        IF integer_year < 10 THEN
                wareki_year := '0' || cast(integer_year as varchar);
        ELSE
                wareki_year := cast(integer_year as varchar);
        END IF;
        ymd_month := substr(ymd_data,6,2) || '月';
        ymd_day := substr(ymd_data,9,2) || '日';
        ymd_wareki := gengo || wareki_year || '年' || ymd_month || ymd_day;
        RETURN ymd_wareki;
    -- 昭和の判定（1926年12月25日から1989年1月7日まで）
    ELSEIF ymd_data >= '1926-12-25' AND ymd_data < '1989-01-08' THEN
        gengo := '昭和';
        integer_year := cast(substr(ymd_data,1,4) as integer) - 1925; -- 昭和元年は1926年
        IF integer_year < 10 THEN
                wareki_year :='0' || cast(integer_year as varchar);
        ELSE
                wareki_year := cast(integer_year as varchar);
        END IF;
        ymd_month := substr(ymd_data,6,2) || '月';
        ymd_day := substr(ymd_data,9,2) || '日';
        ymd_wareki := gengo || wareki_year || '年' || ymd_month || ymd_day;
        RETURN ymd_wareki;
    -- 大正の判定（1912年7月30日から1926年12月24日まで）
    ELSEIF ymd_data >= '1912-07-30' AND ymd_data < '1926-12-25' THEN
        gengo := '大正';
        integer_year := cast(substr(ymd_data,1,4) as integer) - 1911; -- 大正元年は1912年
        IF integer_year<10 THEN
                wareki_year :='0' || cast(integer_year as varchar);
        ELSE
                wareki_year := cast(integer_year as varchar);
        END IF;
        ymd_month := substr(ymd_data,6,2) || '月';
        ymd_day := substr(ymd_data,9,2) || '日';
        ymd_wareki := gengo||wareki_year||'年'||ymd_month||ymd_day;
        RETURN ymd_wareki;
    -- 明治の判定（1868年1月25日から1912年7月29日まで）
    ELSEIF ymd_data >= '1868-01-25' AND ymd_data < '1912-07-30' THEN
        gengo := '明治';
        integer_year := cast(substr(ymd_data,1,4) as integer) - 1867; -- 明治元年は1868年
        IF integer_year<10 THEN
                wareki_year :='0' || cast(integer_year as varchar);
        ELSE
                wareki_year := cast(integer_year as varchar);
        END IF;
        ymd_month := substr(ymd_data,6,2) || '月';
        ymd_day := substr(ymd_data,9,2) || '日';
        ymd_wareki := gengo||wareki_year||'年'||ymd_month||ymd_day;
        RETURN ymd_wareki;
    ELSE
        -- それ以前の場合は「明治以前」とします
        RETURN '明治以前';
    END IF;
END;

$function$