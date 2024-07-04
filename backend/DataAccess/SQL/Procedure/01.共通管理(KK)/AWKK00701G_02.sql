/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 取込実行
　　　　　　未処理一覧検索
作成日　　: 2023.10.11
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00701g_02_head(gyoumukbn_in character varying, impkbn_in character varying)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(t1.*) total into total
	from
		tt_kktorinyuryoku_misyori t1                             --一括取込入力未処理テーブル
		inner join tm_kktorinyuryoku t2                      --一括取込入力マスタ
			on t1.torinyuryokuno = t2.torinyuryokuno
	where
		(gyoumukbn_in is null or t2.gyomukbn = gyoumukbn_in)	--業務区分
		and (impkbn_in is null or t2.torinyuryokbn = impkbn_in);		--一括取込入力区分
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00701g_02_body(gyoumukbn_in character varying, impkbn_in character varying, orderby_in integer, limit_in integer, offset_in integer)
	returns table
	(impjikkoid integer                              --取込実行ID
	, torinyuryokuno character varying                                  --一括取込入力No
	, torinyuryokunm character varying                        --一括取込入力名
	, gyomukbn character varying							 --業務区分
	, filenm character varying						 --ファイル名
	, totalcnt integer								 --件数
	, errcnt integer								 --エラー件数
	, upduserid character varying					 --更新ユーザーID(前回更新者)
	, upddttm timestamp)							 --更新日時(前回更新時間)
	language plpgsql
as $function$
begin
	return query
	select
		t1.impjikkoid
		,t1.torinyuryokuno
		,t2.torinyuryokunm
		,t2.gyomukbn
		,t1.filenm
		,t1.totalcnt
		,t1.errcnt
		,t1.upduserid
		,t1.upddttm
	from
		tt_kktorinyuryoku_misyori t1                             --一括取込入力未処理テーブル
		inner join tm_kktorinyuryoku t2                      --一括取込入力マスタ
			on t1.torinyuryokuno = t2.torinyuryokuno
	where
		(gyoumukbn_in is null or t2.gyomukbn = gyoumukbn_in)	--業務区分
		and (impkbn_in is null or t2.torinyuryokbn = impkbn_in)		--一括取込入力区分
	order by
		case when orderby_in = 0 then t2.gyomukbn  end				--業務区分	昇順（デフォルト）
		,case when orderby_in = 0 then t2.torinyuryokuno  end				--一括取込入力No	昇順（デフォルト）
		,case when orderby_in = 1 then t2.torinyuryokuno end					--一括取込入力No	昇順
		,case when orderby_in = -1 then t2.torinyuryokuno end desc			--一括取込入力No	降順
		,case when orderby_in = 2 then t2.torinyuryokunm  end 				--一括取込入力名	昇順
		,case when orderby_in = -2 then t2.torinyuryokunm end desc 			--一括取込入力名	降順
		,case when orderby_in = 3 then t2.gyomukbn end				--業務区分	昇順
		,case when orderby_in = -3 then t2.gyomukbn end desc		--業務区分	降順
		,case when orderby_in = 4 then t1.filenm end				--ファイル名	昇順
		,case when orderby_in = -4 then t1.filenm end desc			--ファイル名	降順
		,case when orderby_in = 5 then t1.totalcnt end				--件数	昇順
		,case when orderby_in = -5 then t1.totalcnt end desc		--件数	降順
		,case when orderby_in = 6 then t1.errcnt end				--エラー件数	昇順
		,case when orderby_in = -6 then t1.errcnt end desc			--エラー件数	降順
		,case when orderby_in = 7 then t1.upduserid end				--更新ユーザーID(前回更新者)	昇順
		,case when orderby_in = -7 then t1.upduserid end desc		--更新ユーザーID(前回更新者)	降順
		,case when orderby_in = 8 then t1.upddttm end				--更新日時(前回更新時間)	昇順
		,case when orderby_in = -8 then t1.upddttm end desc			--更新日時(前回更新時間)	降順
    limit limit_in offset offset_in;
end;
$function$