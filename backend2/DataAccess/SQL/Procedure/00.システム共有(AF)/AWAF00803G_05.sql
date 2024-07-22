/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: ログ情報管理(DB操作ログ情報)
　　　　　　一覧抽出
作成日　　: 2023.09.07
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_05_head(sessionseq_in bigint)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.dblogseq) total into total
    from 
	    tt_aflogdb t1	--DB操作ログテーブル
	where
		t1.sessionseq = sessionseq_in and
		t1.sql is not null;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_05_body(sessionseq_in bigint, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (dblogseq bigint,			--DB操作ログシーケンス
  sql character varying)	--SQL
 language plpgsql
as $function$
begin
	return query
	select 
		t1.dblogseq		--DB操作ログシーケンス
		,t1.sql			--SQL
	from 
	    tt_aflogdb t1	--DB操作ログテーブル
	where
		t1.sessionseq = sessionseq_in and
		t1.sql is not null
	order by
		case when orderby_in = 0 then t1.dblogseq end			--DB操作ログシーケンス	昇順
		,case when orderby_in = 1 then t1.dblogseq end			--DB操作ログシーケンス	昇順
		,case when orderby_in = -1 then t1.dblogseq end desc	--DB操作ログシーケンス		降順
		,case when orderby_in = 2 then t1.sql end				--SQL					昇順
		,case when orderby_in = -2 then t1.sql end desc			--SQL						降順
    limit limit_in offset offset_in;
end;
$function$