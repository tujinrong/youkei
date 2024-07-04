/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 地区保守
　　　　　　一覧抽出
作成日　　: 2023.09.22
作成者　　: 劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00204g_01_head(tikukbn_in character varying, tikucd_in character varying, staffid_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(m1.tikucd) total into total
    from
        tm_aftiku m1							--地区情報マスタ
    where 
		(m1.tikukbn = tikukbn_in or tikukbn_in is null)				--地区区分
		and
		(m1.tikucd = tikucd_in or tikucd_in is null)				--地区コード
		and  
		(exists(select staffid 
				from tm_aftiku_sub 
				where 
					m1.tikukbn = tikukbn and 
					m1.tikucd = tikucd and
					staffid = staffid_in ) 
			or (staffid_in is null));
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00204g_01_body(tikukbn_in character varying, tikucd_in character varying, staffid_in character varying, limit_in integer, offset_in integer)
 returns table
 (kbn character varying, 
  cd character varying,
  tikunm character varying,
  kanatikunm character varying,
  staffnm text,
  stopflg boolean)
 language plpgsql
as $function$
begin
	return query
	select
		 m1.tikukbn kbn		--地区区分
		,m1.tikucd cd		--地区コード
		,m1.tikunm			--地区名
		,m1.kanatikunm		--地区名（カナ）
		,(select 
				string_agg(m3.staffsimei, ',')
			from tm_aftiku_sub m2--地区情報サブマスタ
				left join tm_afstaff m3--事業従事者（担当者）情報マスタ
				on m2.staffid = m3.staffid
			where 
				m1.tikukbn = m2.tikukbn and
				m1.tikucd = m2.tikucd
		)
		,m1.stopflg			--使用停止フラグ
    from
        tm_aftiku m1							--地区情報マスタ
    where 
		(m1.tikukbn = tikukbn_in or tikukbn_in is null)				--地区区分
		and
		(m1.tikucd = tikucd_in or tikucd_in is null)				--地区コード
		and  
		(exists(select staffid 
				from tm_aftiku_sub 
				where 
					m1.tikukbn = tikukbn and 
					m1.tikucd = tikucd and
					staffid = staffid_in ) 
			or (staffid_in is null))
    order by
        m1.tikukbn,		--地区区分		昇順
		m1.tikucd		--地区コード	昇順
    limit limit_in offset offset_in;
end;
$function$