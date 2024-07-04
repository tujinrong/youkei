/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ログ情報管理(通信ログ情報)
　　　　　　一覧抽出
作成日　　: 2023.09.07
作成者　　: 劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_02_head(sessionseq_in bigint)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.tusinlogseq) total into total
    from 
	    tt_aftusinlog t1	--通信ログテーブル
	where
		t1.sessionseq = sessionseq_in;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_02_body(sessionseq_in bigint, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (tusinlogseq bigint,						--通信ログシーケンス
  ipadrs character varying,					--操作者IP
  os character varying,						--操作者OS
  browser character varying,				--操作者ブラウザー
  syoridttmf timestamp without time zone,	--処理日時（開始）
  syoridttmt timestamp without time zone,	--処理日時（終了）
  msg character varying,					--メッセージ
  request character varying,				--リクエスト
  response character varying)				--リスポンス
 language plpgsql
as $function$
begin
	return query
	select 
		t1.tusinlogseq		--通信ログシーケンス
		,t1.ipadrs			--IPアドレス
		,t1.os				--OS
		,t1.browser			--ブラウザー情報
		,t1.syoridttmf		--処理日時（開始）
		,t1.syoridttmt		--処理日時（終了）
		,t1.msg				--メッセージ
		,t1.request			--リクエスト
		,t1.response		--レスポンス
	from 
	    tt_aftusinlog t1	--通信ログテーブル
	where
		t1.sessionseq = sessionseq_in
	order by
		case when orderby_in = 0 then t1.tusinlogseq end		--通信ログシーケンス	昇順
		,case when orderby_in = 1 then t1.tusinlogseq end		--通信ログシーケンス	昇順
		,case when orderby_in = -1 then t1.tusinlogseq end desc	--通信ログシーケンス		降順
		,case when orderby_in = 2 then t1.ipadrs end			--操作者IP				昇順
		,case when orderby_in = -2 then t1.ipadrs end desc		--操作者IP					降順
		,case when orderby_in = 3 then t1.os end				--操作者OS				昇順
		,case when orderby_in = -3 then t1.os end desc			--操作者OS					降順
		,case when orderby_in = 4 then t1.browser end			--操作者ブラウザー		昇順
		,case when orderby_in = -4 then t1.browser end desc		--操作者ブラウザー			降順
		,case when orderby_in = 5 then t1.syoridttmf end		--処理日時（開始）		昇順
		,case when orderby_in = 5 then t1.syoridttmt end		--処理日時（終了）		昇順
		,case when orderby_in = -5 then t1.syoridttmf end desc	--処理日時（開始）			降順
		,case when orderby_in = -5 then t1.syoridttmt end desc	--処理日時（終了）			降順
		,case when orderby_in = 6 then t1.request end			--リクエスト			昇順
		,case when orderby_in = -6 then t1.request end desc		--リクエスト				降順
		,case when orderby_in = 7 then t1.response end			--レスポンス			昇順
		,case when orderby_in = -7 then t1.response end desc	--レスポンス				降順
		,case when orderby_in = 8 then t1.msg end				--メッセージ			昇順
		,case when orderby_in = -8 then t1.msg end desc			--メッセージ				降順
    limit limit_in offset offset_in;
end;
$function$