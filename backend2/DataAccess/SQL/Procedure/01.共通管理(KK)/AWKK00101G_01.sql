/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 基幹系他システム情報照会
　　　　　　一覧抽出
作成日　　: 2023.10.10
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00101g_01_head(atenano_in character varying, kazeinendo_in integer, kojorirekino_in integer)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.kojocd) total into total
    from
        tt_afkojinzeikojo_reki t1				--【個人住民税】個人住民税税額控除情報履歴テーブル
    where 
		t1.atenano = atenano_in					--宛名番号
		and
		t1.kazeinendo = kazeinendo_in			--課税年度
		and  
		t1.kojorirekino = kojorirekino_in;		--税額控除情報履歴番号
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00101g_01_body(atenano_in character varying, kazeinendo_in integer, kojorirekino_in integer,orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (kojocd character varying, 
  tosi_gyoseikucd character varying,
  kojokingaku bigint)
 language plpgsql
as $function$
begin
	return query
	select
		 t1.kojocd								--税額・税額控除コード
		,t1.tosi_gyoseikucd						--指定都市_行政区等コード
		,t1.kojokingaku							--税額控除金額
    from
        tt_afkojinzeikojo_reki t1				--【個人住民税】個人住民税税額控除情報履歴テーブル
    where 
		t1.atenano = atenano_in					--宛名番号
		and
		t1.kazeinendo = kazeinendo_in			--課税年度
		and  
		t1.kojorirekino = kojorirekino_in		--税額控除情報履歴番号
    order by
		case when orderby_in = 0 then t1.kojocd end					--税額・税額控除コード		昇順
		,case when orderby_in = 1 then t1.kojocd end				--税額・税額控除コード		昇順
		,case when orderby_in = -1 then t1.kojocd end desc			--税額・税額控除コード			降順
		,case when orderby_in = 2 then t1.tosi_gyoseikucd end		--指定都市_行政区等コード	昇順
		,case when orderby_in = -2 then t1.tosi_gyoseikucd end desc	--指定都市_行政区等コード		降順
		,case when orderby_in = 3 then t1.kojokingaku end			--税額控除金額				昇順
		,case when orderby_in = -3 then t1.kojokingaku end desc		--税額控除金額					降順
    limit limit_in offset offset_in;
end;
$function$