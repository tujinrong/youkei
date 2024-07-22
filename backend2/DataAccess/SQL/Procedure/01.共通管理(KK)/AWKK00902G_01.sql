/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業予約希望者管理
　　　　　　一覧抽出(日程一覧)
作成日　　: 2024.03.07
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00902g_01_head(gyomukbn_in character varying, 
													jissiyoteiymdf_in character varying, 
													jissiyoteiymdt_in character varying, 
													jigyocd_in character varying, 
													coursenm_in character varying, 
													kaisu_in integer, 
													kaijocd_in character varying, 
													kikancd_in character varying, 
													staffid_in character varying, 
													atenano_in character varying, 
													personalno_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.nitteino) total into total
	from tt_kkjigyoyotei t1					--事業予定テーブル
	left join tt_kkjigyoyoteicourse t2		--事業予定コーステーブル
	on t1.courseno = t2.courseno
	left join tm_kksonotasidojigyo m1		--その他日程事業・保健指導事業マスタ
	on t1.jigyocd = m1.jigyocd
	left join
		(select 
			t.nitteino, 
			string_agg(t.staffsimei, '、') as staffidnms
		from 
			(select 
			    t3.nitteino, 
			    m2.staffsimei
			from tt_kkjigyoyotei_staff t3	--事業予定担当者テーブル
			left join tm_afstaff m2			--事業従事者（担当者）情報マスタ
			on t3.staffid = m2.staffid
			order by t3.staffid) t
		group by t.nitteino) t4
	on t1.nitteino = t4.nitteino
	left join
		(select 
			t5.nitteino, 
			t6.ct as ct1, 
			t7.ct as ct2
		from
			(select 
			    nitteino, 
			    count(atenano) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			group by nitteino) t5
		left join 
			(select 
				nitteino, 
				count(atenano) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			where cancelmatiflg = '1'	--予約済
			group by nitteino) t6
		on t5.nitteino = t6.nitteino
		left join 
			(select 
				nitteino, 
				count(distinct(atenano)) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			where cancelmatiflg = '2'	--キャンセル待ち
			group by nitteino) t7
		on t5.nitteino = t7.nitteino) t8
	on t1.nitteino = t8.nitteino
	left join 
		(select distinct(t9.nitteino) 
		from tt_kkjigyoyotei_staff t9		--事業予定担当者テーブル
		where (staffid_in is null or t9.staffid = staffid_in)) t10
	on t1.nitteino = t10.nitteino
	left join 
		(select distinct(t11.nitteino) 
		from tt_kkjigyoyoyakukibosya t11	--事業予約希望者テーブル
		left join tt_afatena t12			--宛名テーブル
		on t11.atenano = t12.atenano
		where 
			(atenano_in is null or t11.atenano = atenano_in) and 
			(personalno_in is null or t12.personalno = personalno_in)
		) t13
	on t1.nitteino = t13.nitteino
	where 
		(gyomukbn_in is null or m1.gyomukbn = gyomukbn_in) and 
		(jissiyoteiymdf_in is null or t1.jissiyoteiymd >= jissiyoteiymdf_in) and 
		(jissiyoteiymdt_in is null or t1.jissiyoteiymd <= jissiyoteiymdt_in) and 
		(jigyocd_in is null or t1.jigyocd = jigyocd_in) and 
		(coursenm_in is null or t2.coursenm like coursenm_in) and 
		(kaisu_in is null or t1.kaisu = kaisu_in) and 
		(kaijocd_in is null or t1.kaijocd = kaijocd_in) and 
		(kikancd_in is null or t1.kikancd = kikancd_in) and
		(staffid_in is null or t10.nitteino is not null) and 
		((atenano_in is null and personalno_in is null) or t13.nitteino is not null);
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00902g_01_body(gyomukbn_in character varying, 
													jissiyoteiymdf_in character varying, 
													jissiyoteiymdt_in character varying, 
													jigyocd_in character varying, 
													coursenm_in character varying, 
													kaisu_in integer, 
													kaijocd_in character varying, 
													kikancd_in character varying, 
													staffid_in character varying, 
													atenano_in character varying, 
													personalno_in character varying, 
													limit_in integer, offset_in integer)
 returns table
 (nitteino integer, 
  gyomukbn character varying,
  courseno integer,
  coursenm character varying,
  kaisu integer,
  jigyonm character varying,
  jissinaiyo character varying,
  jissiyoteiymd character varying,
  tmf character varying,
  tmt character varying,
  kaijocd character varying,
  kikancd character varying,
  staffidnms text,
  teiin smallint,
  ct1 bigint,
  ct2 bigint)
 language plpgsql
as $function$
#variable_conflict use_column
begin
	return query
	select 
		t1.nitteino             		    --日程番号
		,m1.gyomukbn		                --業務
		,t1.courseno		                --コース番号
		,t2.coursenm		                --コース名
		,t1.kaisu			                --回数
		,m1.jigyonm			                --事業名
		,t1.jissinaiyo		                --実施内容
		,t1.jissiyoteiymd	                --実施予定日
		,t1.tmf				                --開始時間
		,t1.tmt				                --終了時間
		,t1.kaijocd			                --会場コード
		,t1.kikancd			                --医療機関コード
		,t4.staffidnms		                --担当者
		,t1.teiin			                --定員
		,t8.ct1				                --申
		,t8.ct2				                --待機
	from tt_kkjigyoyotei t1					--事業予定テーブル
	left join tt_kkjigyoyoteicourse t2		--事業予定コーステーブル
	on t1.courseno = t2.courseno
	left join tm_kksonotasidojigyo m1		--その他日程事業・保健指導事業マスタ
	on t1.jigyocd = m1.jigyocd
	left join
		(select 
			t.nitteino, 
			string_agg(t.staffsimei, '、') as staffidnms
		from 
			(select 
			    t3.nitteino, 
			    m2.staffsimei
			from tt_kkjigyoyotei_staff t3	--事業予定担当者テーブル
			left join tm_afstaff m2			--事業従事者（担当者）情報マスタ
			on t3.staffid = m2.staffid
			order by t3.staffid) t
		group by t.nitteino) t4
	on t1.nitteino = t4.nitteino
	left join
		(select 
			t5.nitteino, 
			t6.ct as ct1, 
			t7.ct as ct2
		from
			(select 
			    nitteino, 
			    count(atenano) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			group by nitteino) t5
		left join 
			(select 
				nitteino, 
				count(atenano) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			where cancelmatiflg = '1'	--予約済
			group by nitteino) t6
		on t5.nitteino = t6.nitteino
		left join 
			(select 
				nitteino, 
				count(distinct(atenano)) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			where cancelmatiflg = '2'	--キャンセル待ち
			group by nitteino) t7
		on t5.nitteino = t7.nitteino) t8
	on t1.nitteino = t8.nitteino
	left join 
		(select distinct(t9.nitteino) 
		from tt_kkjigyoyotei_staff t9		--事業予定担当者テーブル
		where (staffid_in is null or t9.staffid = staffid_in)) t10
	on t1.nitteino = t10.nitteino
	left join 
		(select distinct(t11.nitteino) 
		from tt_kkjigyoyoyakukibosya t11	--事業予約希望者テーブル
		left join tt_afatena t12			--宛名テーブル
		on t11.atenano = t12.atenano
		where 
			(atenano_in is null or t11.atenano = atenano_in) and 
			(personalno_in is null or t12.personalno = personalno_in)
		) t13
	on t1.nitteino = t13.nitteino
	where 
		(gyomukbn_in is null or m1.gyomukbn = gyomukbn_in) and 
		(jissiyoteiymdf_in is null or t1.jissiyoteiymd >= jissiyoteiymdf_in) and 
		(jissiyoteiymdt_in is null or t1.jissiyoteiymd <= jissiyoteiymdt_in) and 
		(jigyocd_in is null or t1.jigyocd = jigyocd_in) and 
		(coursenm_in is null or t2.coursenm like coursenm_in) and 
		(kaisu_in is null or t1.kaisu = kaisu_in) and 
		(kaijocd_in is null or t1.kaijocd = kaijocd_in) and 
		(kikancd_in is null or t1.kikancd = kikancd_in) and
		(staffid_in is null or t10.nitteino is not null) and 
		((atenano_in is null and personalno_in is null) or t13.nitteino is not null)
    order by
		t1.nitteino
    limit limit_in offset offset_in;
end;
$function$