/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ユーザー管理
　　　　　　所属グループ検索
作成日　　: 2023.07.04
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00901g_02_head(syozokucd_in character varying)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(1) total into total
	from
		tm_afsyozoku t1  --所属グループマスタ
	where
		syozokucd_in is null or t1.syozokucd = syozokucd_in;
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00901g_02_body(syozokucd_in character varying, orderby_in integer, limit_in integer, offset_in integer)
	returns table
	    (syozokucd character varying, 
	     syozokunm character varying)
	language plpgsql
as $function$
begin
	return query
		select
			t1.syozokucd,    --所属グループコード
			t1.syozokunm     --所属グループ名
		from
			tm_afsyozoku t1  --所属グループマスタ
		where
			syozokucd_in is null or t1.syozokucd = syozokucd_in
		order by
			case when orderby_in = 0 then t1.syozokucd end,	      --所属グループコード  昇順(デフォルト順)
			case when orderby_in = 1 then t1.syozokucd end,	      --所属グループコード  昇順
			case when orderby_in = -1 then t1.syozokucd end desc, --所属グループコード  降順
			case when orderby_in = 2 then t1.syozokunm end,	      --所属グループ名      昇順
			case when orderby_in = -2 then t1.syozokunm end desc  --所属グループ名      降順
		limit limit_in offset offset_in;
end;
$function$