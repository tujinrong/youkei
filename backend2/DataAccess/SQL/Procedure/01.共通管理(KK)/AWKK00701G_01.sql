/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 取込実行
　　　　　　取込設定一覧検索
作成日　　: 2023.10.11
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00701g_01_head(gyoumukbn_in character varying, impkbn_in character varying, impnm_in character varying)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(*) total into total
	from
		tm_kktorinyuryoku t1	--一括取込入力マスタ
	where
		(gyoumukbn_in is null or t1.gyomukbn = gyoumukbn_in)	            --業務区分
	  	and
		(impkbn_in is null or t1.torinyuryokbn = impkbn_in)	            		--一括取込入力区分
	  	and
		(impnm_in is null or t1.torinyuryokunm like '%' || impnm_in || '%');			--一括取込入力名
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00701g_01_body(gyoumukbn_in character varying, impkbn_in character varying, impnm_in character varying, orderby_in integer, limit_in integer, offset_in integer)
	returns table
	(torinyuryokuno character varying                                  --一括取込入力No
	, torinyuryokunm character varying                        --一括取込入力名
	, torinyuryokbn character varying								 --一括取込入力区分
	, gyomukbn character varying							 --業務区分
	, comment character varying)                     --説明
	language plpgsql
as $function$
begin
	return query
	select
		t1.torinyuryokuno                                   --一括取込入力No
		, t1.torinyuryokunm                                   --一括取込入力名
		, t1.torinyuryokbn                                  --一括取込入力区分
		, t1.gyomukbn                                --業務区分
		, t1.comment                                 --説明
	from
		tm_kktorinyuryoku t1	--一括取込入力マスタ 
	where
		(gyoumukbn_in is null or t1.gyomukbn = gyoumukbn_in)		--業務区分
		and
		(impkbn_in is null or t1.torinyuryokbn = impkbn_in)				--一括取込入力区分
	  	and
		(impnm_in is null or t1.torinyuryokunm like '%' || impnm_in || '%')	--一括取込入力名
	order by
		case when orderby_in = 0 then t1.orderseq  end				--並び順シーケンス	昇順（デフォルト）
		,case when orderby_in = 1 then t1.torinyuryokuno end		--一括取込入力No	昇順
		,case when orderby_in = -1 then t1.torinyuryokuno end desc	--一括取込入力No	降順
		,case when orderby_in = 2 then t1.torinyuryokunm  end 		--一括取込入力名	昇順
		,case when orderby_in = -2 then t1.torinyuryokunm end desc 	--一括取込入力名	降順
		,case when orderby_in = 3 then t1.torinyuryokbn end 		--一括取込入力区分	昇順
		,case when orderby_in = -3 then t1.torinyuryokbn end desc   --一括取込入力区分	降順
		,case when orderby_in = 4 then t1.gyomukbn end				--業務区分	昇順
		,case when orderby_in = -4 then t1.gyomukbn end desc		--業務区分	降順
		,case when orderby_in = 5 then t1.comment end				--説明	    昇順
		,case when orderby_in = -5 then t1.comment end desc		    --説明  	降順
    limit limit_in offset offset_in;
end;
$function$