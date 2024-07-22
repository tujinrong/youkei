/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: ログ情報管理(バッチログ情報)
　　　　　　一覧抽出
作成日　　: 2023.09.07
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_03_head(sessionseq_in bigint)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.batchlogseq) total into total
    from 
	    tt_afbatchlog t1	--バッチログテーブル
	where
		t1.sessionseq = sessionseq_in;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_03_body(sessionseq_in bigint, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (batchlogseq bigint,						--バッチログシーケンス
  syoridttmf timestamp without time zone,	--処理日時（開始）
  syoridttmt timestamp without time zone,	--処理日時（終了）
  msg character varying,					--メッセージ
  pram character varying)					--パラメータ
 language plpgsql
as $function$
begin
	return query
	select 
		t1.batchlogseq		--バッチログシーケンス
		,t1.syoridttmf		--処理日時（開始）
		,t1.syoridttmt		--処理日時（終了）
		,t1.msg				--メッセージ
		,t1.pram			--パラメータ
	from 
	    tt_afbatchlog t1	--バッチログテーブル
	where
		t1.sessionseq = sessionseq_in
	order by
		case when orderby_in = 0 then t1.batchlogseq end		--バッチログシーケンス	昇順
		,case when orderby_in = 1 then t1.batchlogseq end		--バッチログシーケンス	昇順
		,case when orderby_in = -1 then t1.batchlogseq end desc	--バッチログシーケンス		降順
		,case when orderby_in = 2 then t1.syoridttmf end		--処理日時（開始）		昇順
		,case when orderby_in = 2 then t1.syoridttmt end		--処理日時（終了）		昇順
		,case when orderby_in = -2 then t1.syoridttmf end desc	--処理日時（開始）			降順
		,case when orderby_in = -2 then t1.syoridttmt end desc	--処理日時（終了）			降順
		,case when orderby_in = 3 then t1.pram end				--パラメータ			昇順
		,case when orderby_in = -3 then t1.pram end desc		--パラメータ				降順
		,case when orderby_in = 4 then t1.msg end				--メッセージ			昇順
		,case when orderby_in = -4 then t1.msg end desc			--メッセージ				降順
    limit limit_in offset offset_in;
end;
$function$