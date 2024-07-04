/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ログ情報管理(連携ログ情報)
　　　　　　一覧抽出
作成日　　: 2023.09.07
作成者　　: 劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_04_head(sessionseq_in bigint)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.gaibulogseq) total into total
    from 
	    tt_afgaibulog t1	--外部連携処理結果履歴テーブル
	where
		t1.sessionseq = sessionseq_in;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_04_body(sessionseq_in bigint, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (gaibulogseq bigint,						--外部連携ログシーケンス
  syoridttmf timestamp without time zone,	--処理日時（開始）
  syoridttmt timestamp without time zone,	--処理日時（終了）
  msg character varying,					--メッセージ
  ipadrs character varying,					--操作者IP
  kbn character varying,							--連携区分
  kbn2 character varying,							--連携方式
  kbn3 character varying,							--処理区分
  apidata character varying,				--API連携データ
  filenm character varying,					--ファイル名
  filetype smallint)						--ファイルタイプ
 language plpgsql
as $function$
begin
	return query
	select 
		t1.gaibulogseq		--外部連携ログシーケンス
		,t1.syoridttmf		--処理日時（開始）
		,t1.syoridttmt		--処理日時（終了）
		,t1.msg				--メッセージ
		,t1.ipadrs			--操作者IP
		,t1.kbn				--連携区分
		,t1.kbn2			--連携方式
		,t1.kbn3			--処理区分
		,t1.apidata			--API連携データ
		,t1.filenm			--ファイル名
		,t1.filetype		--ファイルタイプ
	from 
	    tt_afgaibulog t1	--外部連携処理結果履歴テーブル
	where
		t1.sessionseq = sessionseq_in
	order by
		case when orderby_in = 0 then t1.gaibulogseq end		--外部連携ログシーケンス	昇順
		,case when orderby_in = 1 then t1.gaibulogseq end		--外部連携ログシーケンス	昇順
		,case when orderby_in = -1 then t1.gaibulogseq end desc	--外部連携ログシーケンス		降順
		,case when orderby_in = 2 then t1.syoridttmf end		--処理日時（開始）			昇順
		,case when orderby_in = 2 then t1.syoridttmt end		--処理日時（終了）			昇順
		,case when orderby_in = -2 then t1.syoridttmf end desc	--処理日時（開始）				降順
		,case when orderby_in = -2 then t1.syoridttmt end desc	--処理日時（終了）				降順
		,case when orderby_in = 3 then t1.ipadrs end			--操作者IP					昇順
		,case when orderby_in = -3 then t1.ipadrs end desc		--操作者IP						降順
		,case when orderby_in = 4 then t1.kbn end				--連携区分					昇順
		,case when orderby_in = -4 then t1.kbn end desc			--連携区分						降順
		,case when orderby_in = 5 then t1.kbn2 end				--連携方式					昇順
		,case when orderby_in = -5 then t1.kbn2 end desc		--連携方式						降順
		,case when orderby_in = 6 then t1.kbn3 end				--処理区分					昇順
		,case when orderby_in = -6 then t1.kbn3 end desc		--処理区分						降順
		,case when orderby_in = 7 then t1.apidata end			--API連携データ				昇順
		,case when orderby_in = -7 then t1.apidata end desc		--API連携データ					降順
		,case when orderby_in = 8 then t1.filenm end			--ファイル名				昇順
		,case when orderby_in = 8 then t1.filetype end			--ファイルタイプ			昇順
		,case when orderby_in = -8 then t1.filenm end desc		--ファイル名					降順
		,case when orderby_in = -8 then t1.filetype end desc	--ファイルタイプ				降順
		,case when orderby_in = 9 then t1.msg end				--メッセージ				昇順
		,case when orderby_in = -9 then t1.msg end desc			--メッセージ					降順
    limit limit_in offset offset_in;
end;
$function$