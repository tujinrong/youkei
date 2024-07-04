/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 会場保守
　　　　　　一覧抽出
作成日　　: 2023.11.02
作成者　　: CNC劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00202g_01_head(kaijocd_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(m1.kaijocd) total into total
    from
        tm_afkaijo m1						                 --会場情報マスタ
    where 
		(kaijocd_in is null or m1.kaijocd = kaijocd_in);	 --会場コード
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00202g_01_body(kaijocd_in character varying, limit_in integer, offset_in integer)
 returns table
 (kaijocd character varying, 
  kaijonm character varying,
  kanakaijonm character varying,
  kaijorenrakusaki character varying,
  gyoseikucd character varying,
  adrs character varying,
  katagaki character varying,
  stopflg boolean)
 language plpgsql
as $function$
begin
	return query
	select
		 m1.kaijocd                                     --会場コード
		,m1.kaijonm		                                --会場名
		,m1.kanakaijonm                                 --会場名（カナ）
		,m1.kaijorenrakusaki		                    --会場連絡先
		,m1.gyoseikucd		                            --行政区
		,m1.adrs	                                    --住所
		,m1.katagaki		                            --方書
		,m1.stopflg		                                --利用状態
    from
        tm_afkaijo m1				                    --会場情報マスタ
    where 
		(kaijocd_in is null or m1.kaijocd = kaijocd_in)  --会場コード
    order by
        m1.kaijocd		                                 --会場コード  昇順
    limit limit_in offset offset_in;
end;
$function$