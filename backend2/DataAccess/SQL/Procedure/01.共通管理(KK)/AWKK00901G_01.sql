/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業予定管理
　　　　　　一覧抽出(日程一覧)
作成日　　: 2024.03.04
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awkk00901g_01_head(gyomukbn_in character varying, 
													jissiyoteiymdf_in character varying, 
													jissiyoteiymdt_in character varying, 
													jigyocd_in character varying, 
													kaijocd_in character varying, 
													kikancd_in character varying, 
													staffid_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.nitteino) total into total
    from tt_kkjigyoyotei t1 --事業予定テーブル
	left join
		(select 
			t.nitteino, 
			string_agg(t.staffid, ',') as staffids
        from tt_kkjigyoyotei_staff t	--事業予定担当者テーブル
        group by t.nitteino) t2
	on
		t1.nitteino = t2.nitteino
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
		) t3
	on 
		t1.nitteino = t3.nitteino
	where 
		(gyomukbn_in is null or m1.gyomukbn = gyomukbn_in) and 
		(jissiyoteiymdf_in is null or t1.jissiyoteiymd >= jissiyoteiymdf_in) and 
		(jissiyoteiymdt_in is null or t1.jissiyoteiymd <= jissiyoteiymdt_in) and 
		(jigyocd_in is null or t1.jigyocd = jigyocd_in) and 
		(kaijocd_in is null or t1.kaijocd = kaijocd_in) and 
		(kikancd_in is null or t1.kikancd = kikancd_in) and 
		(staffid_in is null or t3.nitteino is not null) and
		t1.courseno is null;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awkk00901g_01_body(gyomukbn_in character varying, 
													jissiyoteiymdf_in character varying, 
													jissiyoteiymdt_in character varying, 
													jigyocd_in character varying, 
													kaijocd_in character varying, 
													kikancd_in character varying, 
													staffid_in character varying, 
													limit_in integer, offset_in integer)
 returns table
 (nitteino integer, 
  gyomukbn character varying,
  jigyonm character varying,
  jissinaiyo character varying,
  jissiyoteiymd character varying,
  tmf character varying,
  tmt character varying,
  kaijocd character varying,
  kikancd character varying,
  staffids text,
  teiin smallint)
 language plpgsql
as $function$
begin
	return query
	select 
		t1.nitteino,		--日程番号
		m1.gyomukbn,		--業務区分
		m1.jigyonm,			--その他日程事業・保健指導事業名
		t1.jissinaiyo,		--実施内容
		t1.jissiyoteiymd,	--実施予定日
		t1.tmf,				--開始時間
		t1.tmt,				--終了時間
		t1.kaijocd,			--会場コード
		t1.kikancd,			--医療機関コード
		t2.staffids,		--担当者
		t1.teiin			--定員
	from tt_kkjigyoyotei t1 --事業予定テーブル
	left join
		(select 
			t.nitteino, 
			string_agg(t.staffid, ',') as staffids
        from tt_kkjigyoyotei_staff t	--事業予定担当者テーブル
        group by t.nitteino) t2
	on
		t1.nitteino = t2.nitteino
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
		) t3
	on 
		t1.nitteino = t3.nitteino
	where 
		(gyomukbn_in is null or m1.gyomukbn = gyomukbn_in) and 
		(jissiyoteiymdf_in is null or t1.jissiyoteiymd >= jissiyoteiymdf_in) and 
		(jissiyoteiymdt_in is null or t1.jissiyoteiymd <= jissiyoteiymdt_in) and 
		(jigyocd_in is null or t1.jigyocd = jigyocd_in) and 
		(kaijocd_in is null or t1.kaijocd = kaijocd_in) and 
		(kikancd_in is null or t1.kikancd = kikancd_in) and 
		(staffid_in is null or t3.nitteino is not null) and
		t1.courseno is null
    order by
		t1.nitteino
    limit limit_in offset offset_in;
end;
$function$