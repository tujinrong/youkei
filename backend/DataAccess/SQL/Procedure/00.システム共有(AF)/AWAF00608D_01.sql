/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 送付先管理
　　　　　　一覧抽出
作成日　　: 2023.11.14
作成者　　: CNC劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00608d_01_head(atenano_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(1) total into total
	from
    (select 
		     atenano                                         --宛名番号
			,riyomokuteki                                    --利用目的
		from 
		    tt_afsofusaki          --送付先管理テーブル
		where 
			atenano = atenano_in			   --宛名番号
		group by 
		       atenano        --宛名番号
			  ,riyomokuteki   --利用目的
		) t1
	left join tt_afsofusaki t2
		on t1.atenano = t2.atenano
		and t1.riyomokuteki = t2.riyomokuteki
    left join tm_afsikutyoson t3
		on t2.adrs_sikucd = t3.sikucd
	left join tm_aftyoaza t4
		on t2.adrs_sikucd = t4.sikucd
		and t2.adrs_tyoazacd = t4.tyoazaid;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00608d_01_body(atenano_in character varying, limit_in integer, offset_in integer)
 returns table(riyomokutekicd character varying, torokujiyu character varying, sofusaki_yubin character varying, sofusaki_adrs text, sofusaki_simei character varying)
 language plpgsql
as $function$
begin
	return query
	select
		 t2.riyomokuteki riyomokutekicd    --利用目的
		,t2.torokujiyu                     --登録事由
		,t2.adrs_yubin as sofusaki_yubin   --送付先郵便番号
		,case when t2.adrs_tyoazacd = '9999999' 
		           then coalesce(t3.todofukennm, '') || coalesce(t3.gunnm, '') || coalesce(t3.sikunm, '')
				        || coalesce(t2.adrs_tyoaza, '')
						|| coalesce(t2.adrs_bantihyoki, '') || coalesce(t2.adrs_katagaki, '')
			  else coalesce(t3.todofukennm, '') || coalesce(t3.gunnm, '') || coalesce(t3.sikunm, '')
			            || coalesce(t4.oazatyonm, '') || coalesce(t4.tyomeinm, '') || coalesce(t4.koazanm, '')
						|| coalesce(t2.adrs_bantihyoki, '') || coalesce(t2.adrs_katagaki, '')
		 end as sofusaki_adrs              --送付先住所
		,t2.sofusaki_simei                 --送付先氏名
    from
		(select 
		     atenano                                         --宛名番号
			,riyomokuteki                                    --利用目的
		from 
		    tt_afsofusaki          --送付先管理テーブル
		where 
			atenano = atenano_in			   --宛名番号
		group by 
		       atenano        --宛名番号
			  ,riyomokuteki   --利用目的
		) t1
	left join tt_afsofusaki t2
		on t1.atenano = t2.atenano
		and t1.riyomokuteki = t2.riyomokuteki
    left join tm_afsikutyoson t3
		on t2.adrs_sikucd = t3.sikucd
	left join tm_aftyoaza t4
		on t2.adrs_sikucd = t4.sikucd
		and t2.adrs_tyoazacd = t4.tyoazaid
    order by
		t2.riyomokuteki					   --利用目的
    limit limit_in offset offset_in;
end;
$function$