/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ログ情報管理(宛名番号ログ情報)
　　　　　　一覧抽出
作成日　　: 2023.09.08
作成者　　: 劉
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_07_head(sessionseq_in bigint)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(t1.atenalogseq) total into total
    from 
	    tt_aflogatena t1	--宛名番号ログテーブル
	where
		t1.sessionseq = sessionseq_in;
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_07_body(sessionseq_in bigint, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (atenalogseq bigint,					--宛名番号ログシーケンス
  atenano character varying,			--宛名番号
  jutokbn character varying,			--住登区分
  juminkbn character varying,			--住民区分
  simei_yusen character varying,		--氏名_優先
  simei_kana_yusen character varying,	--氏名_フリガナ_優先
  sex character varying,				--性別
  bymd character varying,				--生年月日
  bymd_fusyoflg boolean,				--生年月日_不詳フラグ
  bymd_fusyohyoki character varying,	--生年月日_不詳表記
  adrs1 character varying,				--住所1
  adrs2 character varying,				--住所2
  gyoseikucd character varying,			--行政区コード
  pnoflg boolean,						--個人番号操作フラグ
  usekbn character varying)				--操作区分
 language plpgsql
as $function$
begin
	return query
	select 
		t1.atenalogseq			--宛名番号ログシーケンス
		,t1.atenano				--宛名番号
		,t2.jutokbn				--住登区分
		,t2.juminkbn			--住民区分
		,t2.simei_yusen			--氏名_優先
		,t2.simei_kana_yusen	--氏名_フリガナ_優先
		,t2.sex					--性別
		,t2.bymd				--生年月日
		,t2.bymd_fusyoflg		--生年月日_不詳フラグ
		,t2.bymd_fusyohyoki		--生年月日_不詳表記
		,t2.adrs1				--住所1
		,t2.adrs2				--住所2
		,t2.gyoseikucd			--行政区コード
		,t1.pnouseflg pnoflg	--個人番号操作フラグ
		,t1.usekbn				--操作区分
	from 
	    tt_aflogatena t1	--宛名番号ログテーブル
	left join tt_afatena t2	--宛名テーブル
		on t1.atenano = t2.atenano
	where
		t1.sessionseq = sessionseq_in 
	order by
		case when orderby_in = 0 then t1.atenalogseq end				--宛名番号ログシーケンス	昇順
		,case when orderby_in = 1 then t1.atenalogseq end				--宛名番号ログシーケンス	昇順
		,case when orderby_in = -1 then t1.atenalogseq end desc			--宛名番号ログシーケンス		降順
		,case when orderby_in = 2 then t1.atenano end					--宛名番号					昇順
		,case when orderby_in = -2 then t1.atenano end desc				--宛名番号						降順
		,case when orderby_in = 3 then t2.simei_yusen end				--氏名						昇順
		,case when orderby_in = -3 then t2.simei_yusen end desc			--氏名							降順
		,case when orderby_in = 4 then t2.simei_kana_yusen end			--カナ氏名					昇順
		,case when orderby_in = -4 then t2.simei_kana_yusen end desc	--カナ氏名						降順
		,case when orderby_in = 5 then t2.sex end						--性別						昇順
		,case when orderby_in = -5 then t2.sex end desc					--性別							降順
		,case when orderby_in = 6 then t2.bymd end						--生年月日					昇順
		,case when orderby_in = -6 then t2.bymd end desc				--生年月日						降順
		,case when orderby_in = 7 then t2.adrs1 end						--住所1						昇順
		,case when orderby_in = 7 then t2.adrs2 end						--住所2						昇順
		,case when orderby_in = -7 then t2.adrs1 end desc				--住所1							降順
		,case when orderby_in = -7 then t2.adrs2 end desc				--住所2							降順
		,case when orderby_in = 8 then t2.gyoseikucd end				--行政区					昇順
		,case when orderby_in = -8 then t2.gyoseikucd end desc			--行政区						降順
		,case when orderby_in = 9 then t2.juminkbn end					--住民区分					昇順
		,case when orderby_in = -9 then t2.juminkbn end desc			--住民区分						降順
		,case when orderby_in = 10 then t1.pnouseflg end				--個人番号操作状況			昇順
		,case when orderby_in = -10 then t1.pnouseflg end desc			--個人番号操作状況				降順
		,case when orderby_in = 11 then t1.usekbn end					--操作区分					昇順
		,case when orderby_in = -11 then t1.usekbn end desc				--操作区分						降順
    limit limit_in offset offset_in;
end;
$function$