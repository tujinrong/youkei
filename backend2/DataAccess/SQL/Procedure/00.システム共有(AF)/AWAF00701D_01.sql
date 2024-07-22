/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 宛名番号検索
　　　　　　一覧抽出
作成日　　: 2024.07.17
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00701d_01_head(userid_in character varying, kinoid_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(1) total into total
    from
        tt_afatenalog t1  --宛名番号検索履歴テーブル
	join tt_afatena t2    --宛名マスタ（個人）
		on t1.atenano = t2.atenano
    where 
		t1.userid = userid_in            --ユーザーID
		and t1.kinoid = kinoid_in; --機能ID
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00701d_01_body(userid_in character varying, kinoid_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (atenano character varying,
  simei_yusen character varying,
  simei_kana_yusen character varying,
  bymd character varying,
  bymd_fusyoflg boolean,
  bymd_fusyohyoki character varying,
  sex character varying)
 language plpgsql
as $function$
begin
	return query
	select
		 t2.atenano,                --宛名番号
		 t2.simei_yusen,			--氏名_優先
		 t2.simei_kana_yusen,		--氏名_フリガナ_優先
		 t2.bymd,                   --生年月日
		 t2.bymd_fusyoflg,          --生年月日_不詳フラグ
		 t2.bymd_fusyohyoki,        --生年月日_不詳表記
		 t2.sex		                --性別
    from
        tt_afatenalog t1  --宛名番号検索履歴テーブル
	join tt_afatena t2    --宛名マスタ（個人）
		on t1.atenano = t2.atenano
    where 
		t1.userid = userid_in            --ユーザーID
		and t1.kinoid = kinoid_in  --機能ID
    order by
		case when orderby_in = 0 then t1.syoridttm end desc,	     --処理日時  降順
		case when orderby_in = 1 then t2.atenano end,			     --宛名番号  昇順
		case when orderby_in = -1 then t2.atenano end desc,		     --宛名番号  降順
		case when orderby_in = 2 then t2.simei_yusen end,			 --氏名		 昇順
		case when orderby_in = -2 then t2.simei_yusen end desc,		 --氏名		 降順
		case when orderby_in = 3 then t2.simei_kana_yusen end,    	 --カナ氏名  昇順
		case when orderby_in = -3 then t2.simei_kana_yusen end desc, --カナ氏名  降順
		case when orderby_in = 4 then t2.bymd end,				     --生年月日  昇順
		case when orderby_in = -4 then t2.bymd end desc,		     --生年月日  降順
		case when orderby_in = 5 then t2.sex end,					 --性別		 昇順
		case when orderby_in = -5 then t2.sex end desc			     --性別		 降順
    limit limit_in offset offset_in;
end;
$function$