/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ログ情報管理(項目値変更情報)
　　　　　　一覧抽出
作成日　　: 2023.09.08
作成者　　: 劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_06_head(sessionseq_in bigint, tablenm_in character varying, itemnm_in character varying, henkokbn_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.columnlogseq) total into total
    from 
	    tt_aflogcolumn t1	--テーブル項目値変更ログテーブル
	where
		t1.sessionseq = sessionseq_in and
		(tablenm_in is null or t1.tablenm = tablenm_in) and
		(itemnm_in is null or t1.itemnm = itemnm_in) and
		(henkokbn_in is null or t1.henkokbn = henkokbn_in);
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_06_body(sessionseq_in bigint, tablenm_in character varying, itemnm_in character varying, henkokbn_in character varying,
													orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (columnlogseq bigint,				--項目値変更ログシーケンス
  tablenm character varying,		--テーブル名
  henkokbn character varying,				--変更区分
  keys character varying,			--キー
  itemnm character varying,			--項目名
  valuebefore character varying,	--変更前内容
  valueafter character varying)		--更新後内容
 language plpgsql
as $function$
begin
	return query
	select 
		t1.columnlogseq		--項目値変更ログシーケンス
		,t1.tablenm			--テーブル名
		,t1.henkokbn		--変更区分
		,t1.keys			--キー
		,t1.itemnm			--項目名
		,t1.valuebefore		--変更前内容
		,t1.valueafter		--更新後内容
	from 
	    tt_aflogcolumn t1	--テーブル項目値変更ログテーブル
	where
		t1.sessionseq = sessionseq_in and
		(tablenm_in is null or t1.tablenm = tablenm_in) and
		(itemnm_in is null or t1.itemnm = itemnm_in) and
		(henkokbn_in is null or t1.henkokbn = henkokbn_in) 
	order by
		case when orderby_in = 0 then t1.columnlogseq end			--項目値変更ログシーケンス	昇順
		,case when orderby_in = 1 then t1.columnlogseq end			--項目値変更ログシーケンス	昇順
		,case when orderby_in = -1 then t1.columnlogseq end desc	--項目値変更ログシーケンス		降順
		,case when orderby_in = 2 then t1.tablenm end				--変更テーブル				昇順
		,case when orderby_in = -2 then t1.tablenm end desc			--変更テーブル					降順
		,case when orderby_in = 3 then t1.henkokbn end				--変更区分					昇順
		,case when orderby_in = -3 then t1.henkokbn end desc		--変更区分						降順
		,case when orderby_in = 4 then t1.keys end					--主キー					昇順
		,case when orderby_in = -4 then t1.keys end desc			--主キー						降順
		,case when orderby_in = 5 then t1.itemnm end				--変更項目					昇順
		,case when orderby_in = -5 then t1.itemnm end desc			--変更項目						降順
		,case when orderby_in = 6 then t1.valuebefore end			--変更前内容				昇順
		,case when orderby_in = -6 then t1.valuebefore end desc		--変更前内容					降順
		,case when orderby_in = 7 then t1.valueafter end			--更新後内容				昇順
		,case when orderby_in = -7 then t1.valueafter end desc		--更新後内容					降順
    limit limit_in offset offset_in;
end;
$function$