/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業予定管理
　　　　　　一覧抽出(コース一覧)
作成日　　: 2024.03.04
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00901g_02_head(gyomukbn_in character varying, 
													jissiyoteiymdf_in character varying, 
													jissiyoteiymdt_in character varying, 
													jigyocd_in character varying, 
													kaijocd_in character varying, 
													kikancd_in character varying, 
													staffid_in character varying, 
													coursenm_in character varying, 
													kaisu_in integer)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(tt1.courseno) total into total
	from tt_kkjigyoyoteicourse tt1	--事業予定コーステーブル
	inner join
		(select 
			tt.courseno,
			tt.gyomukbn,
			max(tt.kaisu) as kaisu,
			min(tt.jissiyoteiymd) as jissiyoteiymdf,
			max(tt.jissiyoteiymd) as jissiyoteiymdt
		from
			(select 
				t1.courseno,					--コース番号
				t1.kaisu,						--回数
				m1.gyomukbn,					--業務区分
				t1.jissiyoteiymd				--実施予定日
			from tt_kkjigyoyotei t1				--事業予定テーブル
			left join tm_kksonotasidojigyo m1	--その他日程事業・保健指導事業マスタ
			on 
				t1.jigyocd = m1.jigyocd and 
				m1.yoyakuriyoflg = true 
			left join 
				(select 
					distinct(t.nitteino) 
				from tt_kkjigyoyotei_staff t	--事業予定担当者テーブル
				where 
					staffid_in is null or t.staffid = staffid_in
				) t2
			on 
				t1.nitteino = t2.nitteino
			where 
			    (gyomukbn_in is null or m1.gyomukbn = gyomukbn_in) and 
			    (jissiyoteiymdf_in is null or t1.jissiyoteiymd >= jissiyoteiymdf_in) and 
			    (jissiyoteiymdt_in is null or t1.jissiyoteiymd <= jissiyoteiymdt_in) and 
			    (jigyocd_in is null or t1.jigyocd = jigyocd_in) and 
			    (kaijocd_in is null or t1.kaijocd = kaijocd_in) and 
			    (kikancd_in is null or t1.kikancd = kikancd_in) and 
			    (staffid_in is null or t2.nitteino is not null) and 
			    t1.courseno is not null) tt 
		group by tt.courseno, tt.gyomukbn) tt2
	on tt1.courseno = tt2.courseno
	where 
		(coursenm_in is null or tt1.coursenm like coursenm_in) and 
		(kaisu_in is null or tt2.kaisu = kaisu_in);
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00901g_02_body(gyomukbn_in character varying, 
													jissiyoteiymdf_in character varying, 
													jissiyoteiymdt_in character varying, 
													jigyocd_in character varying, 
													kaijocd_in character varying, 
													kikancd_in character varying, 
													staffid_in character varying, 
													coursenm_in character varying, 
													kaisu_in integer, 
													limit_in integer, offset_in integer)
 returns table
 (courseno integer, 
  gyomukbn character varying,
  coursenm character varying,
  kaisu integer,
  jissiyoteiymdf text,
  jissiyoteiymdt text)
 language plpgsql
as $function$
begin
	return query
	select 
		tt1.courseno,				--コース番号
		tt2.gyomukbn,				--業務区分
		tt1.coursenm,				--コース名
		tt2.kaisu,					--回数
		tt2.jissiyoteiymdf,			--実施期間(開始予定日)
		tt2.jissiyoteiymdt			--実施期間(終了予定日)
	from tt_kkjigyoyoteicourse tt1	--事業予定コーステーブル
	inner join
		(select 
			tt.courseno,
			tt.gyomukbn,
			max(tt.kaisu) as kaisu,
			min(tt.jissiyoteiymd) as jissiyoteiymdf,
			max(tt.jissiyoteiymd) as jissiyoteiymdt
		from
			(select 
				t1.courseno,					--コース番号
				t1.kaisu,						--回数
				m1.gyomukbn,					--業務区分
				t1.jissiyoteiymd				--実施予定日
			from tt_kkjigyoyotei t1				--事業予定テーブル
			left join tm_kksonotasidojigyo m1	--その他日程事業・保健指導事業マスタ
			on 
				t1.jigyocd = m1.jigyocd and 
				m1.yoyakuriyoflg = true 
			left join 
				(select 
					distinct(t.nitteino) 
				from tt_kkjigyoyotei_staff t	--事業予定担当者テーブル
				where 
					staffid_in is null or t.staffid = staffid_in
				) t2
			on 
				t1.nitteino = t2.nitteino
			where 
			    (gyomukbn_in is null or m1.gyomukbn = gyomukbn_in) and 
			    (jissiyoteiymdf_in is null or t1.jissiyoteiymd >= jissiyoteiymdf_in) and 
			    (jissiyoteiymdt_in is null or t1.jissiyoteiymd <= jissiyoteiymdt_in) and 
			    (jigyocd_in is null or t1.jigyocd = jigyocd_in) and 
			    (kaijocd_in is null or t1.kaijocd = kaijocd_in) and 
			    (kikancd_in is null or t1.kikancd = kikancd_in) and 
			    (staffid_in is null or t2.nitteino is not null) and 
			    t1.courseno is not null) tt 
		group by tt.courseno, tt.gyomukbn) tt2
	on tt1.courseno = tt2.courseno
	where 
		(coursenm_in is null or tt1.coursenm like coursenm_in) and 
		(kaisu_in is null or tt2.kaisu = kaisu_in)
    order by
		tt1.courseno
    limit limit_in offset offset_in;
end;
$function$