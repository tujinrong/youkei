/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業予約希望者管理
　　　　　　一覧抽出(コース日程一覧)
作成日　　: 
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00902g_02(courseno_in integer)
 returns table
 (nitteino integer, 
  gyomukbn character varying,
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
		t1.nitteino			--日程番号
		,m1.gyomukbn		--業務
		,t1.kaisu			--回数
		,m1.jigyonm			--事業名
		,t1.jissinaiyo		--実施内容
		,t1.jissiyoteiymd	--実施予定日
		,t1.tmf				--開始時間
		,t1.tmt				--終了時間
		,t1.kaijocd			--会場コード
		,t1.kikancd			--医療機関コード
		,t3.staffidnms		--担当者
		,t1.teiin			--定員
		,t7.ct1				--申込
		,t7.ct2				--待機
	from tt_kkjigyoyotei t1					--事業予定テーブル
	left join tm_kksonotasidojigyo m1		--その他日程事業・保健指導事業マスタ
	on t1.jigyocd = m1.jigyocd
	left join
		(select 
			t.nitteino, 
			string_agg(t.staffsimei, '、') as staffidnms
		from 
			(select 
			    t2.nitteino, 
			    m2.staffsimei
			from tt_kkjigyoyotei_staff t2	--事業予定担当者テーブル
			left join tm_afstaff m2			--事業従事者（担当者）情報マスタ
			on t2.staffid = m2.staffid
			order by t2.staffid) t
		group by t.nitteino) t3
	on t1.nitteino = t3.nitteino
	left join
		(select 
			t4.nitteino, 
			t5.ct as ct1, 
			t6.ct as ct2
		from
			(select 
			    nitteino, 
			    count(atenano) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			group by nitteino) t4
		left join 
			(select 
				nitteino, 
				count(atenano) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			where cancelmatiflg = '1'	--予約済
			group by nitteino) t5
		on t4.nitteino = t5.nitteino
		left join 
			(select 
				nitteino, 
				count(distinct(atenano)) as ct
			from tt_kkjigyoyoyakukibosya	--事業予約希望者テーブル
			where cancelmatiflg = '2'	--キャンセル待ち
			group by nitteino) t6
		on t4.nitteino = t6.nitteino) t7
	on t1.nitteino = t7.nitteino
	where 
		t1.courseno = courseno_in
    order by
		t1.kaisu;	--回数	昇順
end;
$function$