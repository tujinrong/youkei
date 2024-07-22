/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 取込実行
　　　　　　取込データエラー情報リスト検索
作成日　　: 2023.10.11
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00704d_01_head(impjikkoid_in integer)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(*) total into total
	from
		tt_kktorinyuryoku_err t1                          --一括取込入力エラーテーブル
	where
		t1.impjikkoid = impjikkoid_in;	--取込実行ID
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00704d_01_body(impjikkoid_in integer, orderby_in integer, limit_in integer, offset_in integer)
	returns table
	(rowno integer                                		--行番号
	, atenano character varying							--宛名番号
	, simei character varying						 	--氏名
	, itemnm character varying					 		--項目名
	, itemvalue character varying						 		--項目値
	, msg character varying)							--メッセージ
	language plpgsql
as $function$
begin
	return query
	select
		t1.rowno
		, t1.atenano
		, t1.simei
		, t1.itemnm
		, t1.itemvalue
		, t1.msg 
	from
		tt_kktorinyuryoku_err t1 --一括取込入力エラーテーブル
	where
		t1.impjikkoid = impjikkoid_in	--取込実行ID
	order by
		case when orderby_in = 0 then t1.rowno  end					--行番号	昇順（デフォルト）
		,case when orderby_in = 1 then t1.rowno end					--行番号	昇順
		,case when orderby_in = -1 then t1.rowno end desc			--行番号	降順
		,case when orderby_in = 2 then t1.atenano  end 				--宛名番号	昇順
		,case when orderby_in = -2 then t1.atenano end desc 		--宛名番号	降順
		,case when orderby_in = 2 then t1.simei  end 		--氏名	昇順
		,case when orderby_in = -2 then t1.simei end desc 		--氏名	降順
		,case when orderby_in = 3 then t1.itemnm end				--項目名	昇順
		,case when orderby_in = -3 then t1.itemnm end desc			--項目名	降順
		,case when orderby_in = 4 then t1.itemvalue end					--項目値	昇順
		,case when orderby_in = -4 then t1.itemvalue end desc				--項目値	降順
		,case when orderby_in = 5 then t1.msg end					--メッセージ	昇順
		,case when orderby_in = -5 then t1.msg end desc				--メッセージ	降順
    limit limit_in offset offset_in;
end;
$function$