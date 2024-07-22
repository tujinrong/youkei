/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 事業従事者検索
　　　　　　一覧抽出
作成日　　: 2023.10.24
作成者　　: CNC
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00704d_01_head(staffsimei_in character varying, syokusyu_in character varying
																				,katudokbn_in character varying
																				,jissijigyos_in character varying, stopflg_in boolean)
 returns integer
 language plpgsql
as $function$
	declare total integer;
	jissijigyos text[];
begin
	jissijigyos = string_to_array(jissijigyos_in, ',');
	select
		count(distinct t1.staffid) total into total
    from
        tm_afstaff t1						--事業従事者（担当者）情報マスタ
	inner join
	(select distinct tt.staffid
    from							                 
        tm_afstaff tt                                --事業従事者（担当者）情報マスタ
	left join tm_afstaff_sub	t2			         --事業従事者（担当者）サブマスタ
		on tt.staffid = t2.staffid                   --事業従事者ID
    where 
		t2.jissijigyo = any(jissijigyos)								  --実施事業
		and (staffsimei_in is null or tt.staffsimei like staffsimei_in)   --事業従事者氏名
		and (syokusyu_in is null or tt.syokusyu = syokusyu_in)            --職種
		and (katudokbn_in is null or tt.katudokbn = katudokbn_in)         --活動区分
        and (stopflg_in or tt.stopflg = false)							  --使用停止フラグ
	) t3
	on t1.staffid = t3.staffid;
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00704d_01_body(staffsimei_in character varying, syokusyu_in character varying
												,katudokbn_in character varying
												,jissijigyos_in character varying, stopflg_in boolean
												,orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (staffid character varying, 
  staffsimei character varying, 
  kanastaffsimei character varying, 
  syokusyu character varying,
  katudokbn character varying)
 language plpgsql
as $function$
declare jissijigyos text[];
begin
	jissijigyos = string_to_array(jissijigyos_in, ',');
	return query
	select
		 t1.staffid,                --事業従事者ID
		 t1.staffsimei,			                     --事業従事者氏名
		 t1.kanastaffsimei,		                     --事業従事者カナ氏名
		 t1.syokusyu,                                --職種
		 t1.katudokbn                                --活動区分
	from							                 
        tm_afstaff t1                                --事業従事者（担当者）情報マスタ
	inner join
	(select distinct tt.staffid
    from							                 
        tm_afstaff tt                                --事業従事者（担当者）情報マスタ
	left join tm_afstaff_sub	t2			         --事業従事者（担当者）サブマスタ
		on tt.staffid = t2.staffid                   --事業従事者ID
    where 
		t2.jissijigyo = any(jissijigyos)								  --実施事業
		and (staffsimei_in is null or tt.staffsimei like staffsimei_in)   --事業従事者氏名
		and (syokusyu_in is null or tt.syokusyu = syokusyu_in)            --職種
		and (katudokbn_in is null or tt.katudokbn = katudokbn_in)         --活動区分
		and (stopflg_in or tt.stopflg = false)							  --使用停止フラグ
	) t3
	on t1.staffid = t3.staffid
    order by
		 case when orderby_in = 0 then t1.staffid  end				--事業従事者ID	    昇順（デフォルト）
		,case when orderby_in = 1 then t1.staffid end				--事業従事者ID	    昇順
		,case when orderby_in = -1 then t1.staffid end desc		    --事業従事者ID	    降順
		,case when orderby_in = 2 then t1.staffsimei end			--事業従事者氏名	昇順
		,case when orderby_in = -2 then t1.staffsimei end desc		--事業従事者氏名	降順
		,case when orderby_in = 3 then t1.kanastaffsimei  end 		--取込名	        昇順
		,case when orderby_in = -3 then t1.kanastaffsimei end desc 	--取込名	        降順
		,case when orderby_in = 4 then t1.syokusyu end 				--職種	            昇順
		,case when orderby_in = -4 then t1.syokusyu end desc   		--職種	            降順
		,case when orderby_in = 5 then t1.katudokbn end				--活動区分	        昇順
		,case when orderby_in = -5 then t1.katudokbn end desc		--活動区分	        降順
    limit limit_in offset offset_in;
end;
$function$