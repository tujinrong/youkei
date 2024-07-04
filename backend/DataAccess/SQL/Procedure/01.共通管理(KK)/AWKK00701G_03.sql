/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 取込実行
　　　　　　取込履歴一覧検索
作成日　　: 2023.10.11
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00701g_03_head(gyoumukbn_in character varying, impkbn_in character varying)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(*) total into total
	from
		tt_kktorinyuryoku_rireki t1                          --一括取込入力履歴テーブル
	where
		(gyoumukbn_in is null or t1.gyomukbn = gyoumukbn_in)	--業務区分
		and (impkbn_in is null or t1.torinyuryokbn = impkbn_in);		--一括取込入力区分
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00701g_03_body(gyoumukbn_in character varying, impkbn_in character varying, orderby_in integer, limit_in integer, offset_in integer)
	returns table
	(imprirekino integer                                		--履歴番号
	, regdttm timestamp										--登録日時(実行日時)
	, reguserid character varying							--登録ユーザーID(担当者)
	, gyomukbn character varying							 		--業務
	, torinyuryokunm character varying					 			--一括取込入力名
	, torinyuryokbn character varying							 			--一括取込入力区分
	, filenm character varying								--ファイル名
	, torokucnt integer								 		--登録件数(処理件数)
	, errcnt integer)							 			--エラー件数
	language plpgsql
as $function$
begin
	return query
	select
		t1.imprirekino
		, t1.regdttm
		, m1.usernm as reguserid
		, t1.gyomukbn
		, t1.torinyuryokunm
		, t1.torinyuryokbn
		, t1.filenm
		, t1.torokucnt
		, t1.errcnt 
	from
		tt_kktorinyuryoku_rireki t1                          --一括取込入力履歴テーブル
		left join tm_afuser m1 
			on t1.reguserid = m1.userid				--ユーザーマスタ
	where
		(gyoumukbn_in is null or t1.gyomukbn = gyoumukbn_in)	--業務区分
		and (impkbn_in is null or t1.torinyuryokbn = impkbn_in)		--一括取込入力区分
	order by
		case when orderby_in = 0 then t1.imprirekino  end desc				--履歴番号	昇順（デフォルト）
		,case when orderby_in = 1 then t1.imprirekino end					--履歴番号	昇順
		,case when orderby_in = -1 then t1.imprirekino end desc			--履歴番号	降順
		,case when orderby_in = 2 then t1.regdttm  end 					--登録日時(実行日時)	昇順
		,case when orderby_in = -2 then t1.regdttm end desc 			--登録日時(実行日時)	降順
		,case when orderby_in = 3 then t1.reguserid end					--登録ユーザーID(担当者)	昇順
		,case when orderby_in = -3 then t1.reguserid end desc			--登録ユーザーID(担当者)	降順
		,case when orderby_in = 4 then t1.gyomukbn end					--業務	昇順
		,case when orderby_in = -4 then t1.gyomukbn end desc			--業務	降順
		,case when orderby_in = 5 then t1.torinyuryokunm end						--一括取込入力名	昇順
		,case when orderby_in = -5 then t1.torinyuryokunm end desc				--一括取込入力名	降順
		,case when orderby_in = 6 then t1.torinyuryokbn end					--一括取込入力区分	昇順
		,case when orderby_in = -6 then t1.torinyuryokbn end desc				--一括取込入力区分	降順
		,case when orderby_in = 7 then t1.filenm end					--ファイル名	昇順
		,case when orderby_in = -7 then t1.filenm end desc				--ファイル名	降順
		,case when orderby_in = 8 then t1.torokucnt end					--登録件数(処理件数)	昇順
		,case when orderby_in = -8 then t1.torokucnt end desc			--登録件数(処理件数)	降順
		,case when orderby_in = 9 then t1.errcnt end					--エラー件数	昇順
		,case when orderby_in = -9 then t1.errcnt end desc				--エラー件数	降順
    limit limit_in offset offset_in;
end;
$function$