/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 医療機関検索
　　　　　　一覧抽出
作成日　　: 2023.03.17
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00702d_01_head(kikannm_in character varying, kanakikannm_in character varying, hokenkikancd_in character varying, jissijigyos_in character varying, stopflg_in boolean)
 returns integer
 language plpgsql
as $function$
	declare total integer;
	jissijigyos text[];
begin
	jissijigyos = string_to_array(jissijigyos_in, ',');
	select
		count(1) total into total
    from
		tm_afkikan t1  --医療機関マスタ
	inner join ( 
		select
			distinct t1.kikancd					--医療機関コード（自治体独自）
		from
			tm_afkikan t1                       --医療機関サブマスタ
			join tm_afkikan_sub t2              --医療機関マスタ
				on t2.kikancd = t1.kikancd      --医療機関コード（自治体独自）
		where 
		t2.jissijigyo = any(jissijigyos)										--実施事業
		and (hokenkikancd_in is null or t1.hokenkikancd like hokenkikancd_in)	--保険医療機関コード
		and (kikannm_in is null or t1.kikannm like kikannm_in)					--医療機関名
		and (kanakikannm_in is null or t1.kanakikannm like kanakikannm_in)		--医療機関名カナ
		and (stopflg_in or t1.stopflg = false)									--使用停止フラグ
	) t3 
	on t1.kikancd = t3.kikancd;					--医療機関コード（自治体独自）
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00702d_01_body(kikannm_in character varying, kanakikannm_in character varying, hokenkikancd_in character varying, jissijigyos_in character varying, stopflg_in boolean, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (kikancd character varying, 
  hokenkikancd character varying,
  kikannm character varying, 
  kanakikannm character varying, 
  adrs character varying,
  katagaki character varying)
 language plpgsql
as $function$
declare jissijigyos text[];
begin
	jissijigyos = string_to_array(jissijigyos_in, ',');
	return query
	select 
		 t1.kikancd,       --医療機関コード（自治体独自）
		 t1.hokenkikancd,  --保険医療機関コード
		 t1.kikannm,       --医療機関名
		 t1.kanakikannm,   --医療機関名カナ
		 t1.adrs,          --住所
		 t1.katagaki
    from
		tm_afkikan t1  --医療機関マスタ
	inner join ( 
		select
			distinct t1.kikancd					--医療機関コード（自治体独自）
		from
			tm_afkikan t1                       --医療機関サブマスタ
			join tm_afkikan_sub t2              --医療機関マスタ
				on t2.kikancd = t1.kikancd      --医療機関コード（自治体独自）
		where 
		t2.jissijigyo = any(jissijigyos)										--実施事業
		and (hokenkikancd_in is null or t1.hokenkikancd like hokenkikancd_in)	--保険医療機関コード
		and (kikannm_in is null or t1.kikannm like kikannm_in)					--医療機関名
		and (kanakikannm_in is null or t1.kanakikannm like kanakikannm_in)		--医療機関名カナ
		and (stopflg_in or t1.stopflg = false)									--使用停止フラグ
	) t3 
	on t1.kikancd = t3.kikancd					--医療機関コード（自治体独自）
	order by
		case when orderby_in = 0 then t1.kikancd end,				--医療機関コード（自治体独自）  昇順
		case when orderby_in = 1 then t1.kikancd end,				--医療機関コード（自治体独自）  昇順
		case when orderby_in = -1 then t1.kikancd end desc,			--医療機関コード（自治体独自）  降順
		case when orderby_in = 2 then t1.hokenkikancd end,			--保険医療機関コード			昇順
		case when orderby_in = -2 then t1.hokenkikancd end desc,	--保険医療機関コード			降順
		case when orderby_in = 3 then t1.kikannm end,        		--医療機関名					昇順
		case when orderby_in = -3 then t1.kikannm end desc,			--医療機関名					降順
		case when orderby_in = 4 then t1.kanakikannm end,    		--医療機関名カナ				昇順
		case when orderby_in = -4 then t1.kanakikannm end desc,		--医療機関名カナ				降順
		case when orderby_in = 5 then t1.adrs end,           		--住所							昇順
		case when orderby_in = -5 then t1.adrs end desc				--住所							降順
    limit limit_in offset offset_in;
end;
$function$