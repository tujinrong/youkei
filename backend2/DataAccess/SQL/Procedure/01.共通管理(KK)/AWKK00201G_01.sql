/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 医療機関保守
　　　　　　一覧抽出
作成日　　: 2023.12.6
作成者　　: CNC加恒
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00201g_01_head(kikancd_in character varying, hokenkikancd_in character varying, kikannm_in character varying, kanakikannm_in character varying, adrs_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(m1.kikancd) total into total
    from
        tm_afkikan m1																--医療機関マスタ
    where 
		(kikancd_in is null or m1.kikancd = kikancd_in)								--医療機関コード
		and
		(hokenkikancd_in is null or m1.hokenkikancd = hokenkikancd_in)				--保険医療機関コード
		and
		(kikannm_in is null or m1.kikannm like kikannm_in)			--医療機関名
		and
		(kanakikannm_in is null or m1.kanakikannm like kanakikannm_in)		--医療機関名カナ
		and
		(adrs_in is null or m1.adrs like adrs_in );					--住所
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00201g_01_body(kikancd_in character varying, hokenkikancd_in character varying, kikannm_in character varying, kanakikannm_in character varying, adrs_in character varying, limit_in integer, offset_in integer)
 returns table
 (kikancd character varying, 
  hokenkikancd character varying,
  kikannm character varying,
  kanakikannm character varying,
  tel character varying,
  yubin character varying,
  adrs character varying,
  stopflg boolean)
 language plpgsql
as $function$
begin
	return query
	select
		 m1.kikancd																	--医療機関コード
		,m1.hokenkikancd															--保険医療機関コード
		,m1.kikannm																	--医療機関名
		,m1.kanakikannm																--医療機関名カナ
		,m1.tel																		--電話番号
		,m1.yubin																	--郵便番号
		,m1.adrs																	--住所
		,m1.stopflg																	--使用停止フラグ
    from
        tm_afkikan m1																--医療機関マスタ
    where 
		(kikancd_in is null or m1.kikancd = kikancd_in)								--医療機関コード
		and
		(hokenkikancd_in is null or m1.hokenkikancd = hokenkikancd_in)				--保険医療機関コード
		and
		(kikannm_in is null or m1.kikannm like  kikannm_in )			--医療機関名
		and
		(kanakikannm_in is null or m1.kanakikannm like kanakikannm_in)		--医療機関名カナ
		and
		(adrs_in is null or m1.adrs like adrs_in )						--住所
    order by
        m1.kikancd																	--医療機関コード		昇順
    limit limit_in offset offset_in;
end;
$function$