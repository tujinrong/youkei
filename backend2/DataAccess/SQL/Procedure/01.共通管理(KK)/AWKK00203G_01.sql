/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業従事者（担当者）保守
　　　　　　一覧検索
作成日　　: 2023.11.30
作成者　　: 誠
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00203g_01_head(staffid_in character varying, kikancd_in character varying, syokusyu_in character varying, katudokbn_in character varying,staffsimei_in character varying, kanastaffsimei_in character varying)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(distinct m1.staffid) total into total
	from
		tm_afstaff m1							--事業従事者（担当者）														
		left join tm_afstaff_kikan m2			--事業従事者（担当者）所属機関														
				on m1.staffid = m2.staffid
	where
		(kikancd_in is null or m2.kikancd = kikancd_in)											--機関コード
		and
		(staffid_in is null or m1.staffid = staffid_in)											--事業従事者ID
		and
		(staffsimei_in is null or m1.staffsimei like '%' || staffsimei_in || '%')				--事業従事者氏名
		and
		(kanastaffsimei_in is null or m1.kanastaffsimei like '%' || kanastaffsimei_in || '%')	--事業従事者カナ氏名
		and
		(syokusyu_in is null or m1.syokusyu = syokusyu_in)										--職種
		and
		(katudokbn_in is null or m1.katudokbn = katudokbn_in);									--活動区分
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00203g_01_body(staffid_in character varying, kikancd_in character varying, syokusyu_in character varying, katudokbn_in character varying,staffsimei_in character varying, kanastaffsimei_in character varying, limit_in integer, offset_in integer)
	returns table
	(staffid character varying                      --事業従事者ID
	, staffsimei character varying                  --事業従事者氏名
	, kanastaffsimei character varying              --事業従事者カナ氏名
	, syokusyu character varying 					--職種
	, katudokbn character varying					--活動区分
	, stopflg boolean) 								--使用停止フラグ
	language plpgsql
as $function$
begin
	return query
	select distinct
		m1.staffid									--事業従事者ID	
		, m1.staffsimei								--事業従事者氏名
		, m1.kanastaffsimei							--事業従事者カナ氏名
		, m1.syokusyu								--職種
		, m1.katudokbn								--活動区分
		, m1.stopflg								--使用停止フラグ
	from
		tm_afstaff m1								--事業従事者（担当者）
		left join tm_afstaff_kikan m2				--事業従事者（担当者）所属機関
				on m1.staffid = m2.staffid
	where
		(kikancd_in is null or m2.kikancd = kikancd_in)											--機関コード							
		and
		(staffid_in is null or m1.staffid = staffid_in)											--事業従事者ID
		and
		(staffsimei_in is null or m1.staffsimei like '%' || staffsimei_in || '%')				--事業従事者氏名
		and
		(kanastaffsimei_in is null or m1.kanastaffsimei like '%' || kanastaffsimei_in || '%')	--事業従事者カナ氏名
		and
		(syokusyu_in is null or m1.syokusyu = syokusyu_in)										--職種
		and
		(katudokbn_in is null or m1.katudokbn = katudokbn_in)									--活動区分
	order by
		m1.staffid asc
    limit limit_in offset offset_in;
end;
$function$
