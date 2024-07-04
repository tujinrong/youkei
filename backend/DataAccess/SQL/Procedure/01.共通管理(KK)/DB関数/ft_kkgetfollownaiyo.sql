/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 取込実行
　　　　　　フォロー内容情報
作成日　　: 2024.07.02
作成者　　: 高
変更履歴　:
*******************************************************************/
create or replace function ft_kkgetfollownaiyo(atenano_in character varying, haakukeiro_in character varying, haakujigyocd_in character varying,　hakuymd_in character varying)
 returns table
 (follownaiyoedano integer, 
  follownaiyo character varying,
  followstatus character varying)
 language plpgsql
as $function$
begin
	return query
	select
		 t1.follownaiyoedano					--フォロー内容枝番
		,t1.follownaiyo							--フォロー内容
		,t1.followstatus						--フォロー状況
    from
        tt_kkfollownaiyo t1						--フォロー内容情報テーブル
    where 
		t1.atenano = atenano_in					--宛名番号
		and
		t1.haakukeiro = haakukeiro_in			--把握経路
		and  
		t1.haakujigyocd = haakujigyocd_in		--把握事業
		and  
		t1.hakuymd = hakuymd_in;				--把握日

end;
$function$