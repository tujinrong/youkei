/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票発行履歴管理
　　　　　　　　　一覧抽出
作成日　　: 2024.03.07
作成者　　: 千秋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awaf01101g_01_head(rptid_in character varying, yosikiid_in character varying, nendo_in character varying, taisyocd_in character varying, hakkodttmf_in character varying, hakkodttmt_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$ declare total integer; 
    hakkodttmf_in2 timestamp without time zone;
    hakkodttmt_in2 timestamp without time zone;
begin 

    hakkodttmf_in2 := to_timestamp(hakkodttmf_in, 'YYYY-MM-DD HH24:MI:SS');
    hakkodttmt_in2 := to_timestamp(hakkodttmt_in, 'YYYY-MM-DD HH24:MI:SS');
select
    count(t1.rptyosikihakkocd) total 
into total 
from
    tt_kkrpthakkorireki t1                      --帳票発行履歴テーブル
    left join tt_kkrptyosikihakko t2            --帳票様式発行テーブル
        ON t1.rptyosikihakkocd = t2.rptyosikihakkocd 
where
    ( 
        rptid_in IS NULL 
        OR t2.rptid = rptid_in
    )                                           --帳票コード
    and ( 
        yosikiid_in IS NULL 
        OR t2.yosikiid = yosikiid_in
    )                                           --様式コード
    and (nendo_in IS NULL OR t1.nendo = nendo_in) --年度
    and ( 
        taisyocd_in IS NULL 
        OR t1.tyusyututaisyocd = taisyocd_in
    )                                           --抽出対象
    
       AND (hakkodttmf_in IS NULL OR  t1.hakkodttm >= hakkodttmf_in2 )
       AND (hakkodttmt_in IS NULL OR  t1.hakkodttm <= hakkodttmt_in2 )
; 

return total; 

end; 

$function$




/*==============================body==============================*/
CREATE OR REPLACE FUNCTION public.sp_awaf01101g_01_body(rptid_in character varying, yosikiid_in character varying, nendo_in character varying, taisyocd_in character varying, hakkodttmf_in character varying, hakkodttmt_in character varying, limit_in integer, offset_in integer)
 RETURNS TABLE(rptid character varying
 , yosikiid character varying
 , nendo character varying
 , hakkodttm timestamp without time zone
 , hakkoninsu character varying
 , taisyocd character varying)
 LANGUAGE plpgsql
AS $function$ 

declare
    hakkodttmf_in2 timestamp without time zone;
    hakkodttmt_in2 timestamp without time zone;
begin 

    hakkodttmf_in2 := to_timestamp(hakkodttmf_in, 'YYYY-MM-DD HH24:MI:SS');
    hakkodttmt_in2 := to_timestamp(hakkodttmt_in, 'YYYY-MM-DD HH24:MI:SS');
return query 
select
    t2.rptid as rptid                           --帳票名
    , t2.yosikiid as yosikiid                   --様式名
    , t1.nendo as nendo                         --年度
    , t1.hakkodttm as hakkodttm                 --発行日時
    ,  t1.nendo as hakkoninsu                   --発行人数 TODO
    , t1.tyusyututaisyocd as taisyocd           --抽出対象
from
    tt_kkrpthakkorireki t1                      --帳票発行履歴テーブル
    left join tt_kkrptyosikihakko t2            --帳票様式発行テーブル
        ON t1.rptyosikihakkocd = t2.rptyosikihakkocd 
WHERE
   ( 
        rptid_in IS NULL 
        OR t2.rptid = rptid_in
    )                                           --帳票コード
    and ( 
        yosikiid_in IS NULL 
        OR t2.yosikiid = yosikiid_in
    )                                           --様式コード
    and (nendo_in IS NULL OR t1.nendo = nendo_in) --年度
    and ( 
        taisyocd_in IS NULL 
        OR t1.tyusyututaisyocd = taisyocd_in
    )                                           --抽出対象

       AND (hakkodttmf_in IS NULL OR  t1.hakkodttm >= hakkodttmf_in2 )
       AND (hakkodttmt_in IS NULL OR  t1.hakkodttm <= hakkodttmt_in2 )
    ORDER BY
    t1.nendo DESC                 --年度降順
limit    limit_in offset offset_in; 

end; 

$function$