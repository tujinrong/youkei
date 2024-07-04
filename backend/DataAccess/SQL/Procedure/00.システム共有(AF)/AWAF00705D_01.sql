/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 個人検索
　　　　　　一覧抽出
作成日　　: 2024.04.01
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00705d_01_head(name_in character varying, kname_in character varying, bymd_in character varying, sex_in character varying, juminkbn_in character varying, hokenkbn_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
begin
	select
		count(1) total into total
    from
        tt_afatena t1  --宛名テーブル
    where 
		(name_in is null or t1.simei like name_in or t1.tusyo like name_in)             		--氏名
		and (kname_in is null or t1.simei_kana like kname_in or t1.tusyo_kana like kname_in)	--カナ氏名
        and (bymd_in is null or t1.bymd = bymd_in) 			    --生年月日
		and (sex_in is null or t1.sex = any(string_to_array(sex_in, ','))) 						--性別
		and (juminkbn_in is null or t1.juminkbn = any(string_to_array(juminkbn_in, ','))) 		--住民区分
		and (hokenkbn_in is null or t1.hokenkbn = hokenkbn_in); --保険区分
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00705d_01_body(name_in character varying, kname_in character varying, bymd_in character varying, sex_in character varying, juminkbn_in character varying, hokenkbn_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (atenano character varying,
  simei_yusen character varying,
  simei_kana_yusen character varying,
  sex character varying,
  bymd character varying,
  bymd_fusyoflg boolean,
  bymd_fusyohyoki character varying,
  adrs1 character varying,
  adrs2 character varying,
  jutokbn character varying,
  gyoseikucd character varying,
  juminkbn character varying)
 language plpgsql
as $function$
begin
	return query
	select
		 t1.atenano,                --宛名番号
		 t1.simei_yusen,			--氏名_優先
		 t1.simei_kana_yusen,		--氏名_フリガナ_優先
		 t1.sex,					--性別
		 t1.bymd,                   --生年月日
		 t1.bymd_fusyoflg,          --生年月日_不詳フラグ
		 t1.bymd_fusyohyoki,        --生年月日_不詳表記
		 t1.adrs1,                	--住所1
		 t1.adrs2,                	--住所2
         t1.jutokbn,                --住登区分
		 t1.gyoseikucd,             --行政区コード
		 t1.juminkbn                --住民区分
		 ,t1.hokenkbn               --保険区分
		 ,t1.siensotikbn            --支援措置区分
    from
        tt_afatena t1  --宛名テーブル
    where 
		(name_in is null or t1.simei like name_in or t1.tusyo like name_in)             		--氏名
		and (kname_in is null or t1.simei_kana like kname_in or t1.tusyo_kana like kname_in)	--カナ氏名
        and (bymd_in is null or t1.bymd = bymd_in) 												--生年月日
		and (sex_in is null or t1.sex = any(string_to_array(sex_in, ','))) 						--性別
		and (juminkbn_in is null or t1.juminkbn = any(string_to_array(juminkbn_in, ','))) 		--住民区分
		and (hokenkbn_in is null or t1.hokenkbn = hokenkbn_in) 	--保険区分
    order by
		case when orderby_in = 0 then t1.atenano  end               --宛名番号			昇順（デフォルト）
		,case when orderby_in = 1 then t1.atenano end               --宛名番号			昇順
        ,case when orderby_in = -1 then t1.atenano end desc         --宛名番号			降順
        ,case when orderby_in = 2 then t1.simei  end                --氏名				昇順
        ,case when orderby_in = 2 then t1.tusyo  end                --通称				昇順
        ,case when orderby_in = -2 then t1.simei end desc           --氏名				降順
        ,case when orderby_in = -2 then t1.tusyo end desc           --通称				降順
		,case when orderby_in = 3 then t1.simei  end                --カナ氏名			昇順
        ,case when orderby_in = 3 then t1.tusyo  end                --カナ通称			昇順
        ,case when orderby_in = -3 then t1.simei end desc           --カナ氏名			降順
        ,case when orderby_in = -3 then t1.tusyo end desc           --カナ通称			降順
        ,case when orderby_in = 4 then t1.sex end                   --性別				昇順
        ,case when orderby_in = -4 then t1.sex end desc             --性別				降順
        ,case when orderby_in = 5 then t1.bymd end                  --生年月日			昇順
        ,case when orderby_in = 5 then t1.bymd_fusyohyoki end       --生年月日_不詳表記	昇順
        ,case when orderby_in = -5 then t1.bymd end desc            --生年月日			降順
        ,case when orderby_in = -5 then t1.bymd_fusyohyoki end desc --生年月日_不詳表記	降順
		,case when orderby_in = 6 then t1.adrs1 end         		--住所1				昇順
        ,case when orderby_in = 6 then t1.adrs2 end                 --住所2				昇順
        ,case when orderby_in = -6 then t1.adrs1 end desc           --住所1				降順
        ,case when orderby_in = -6 then t1.adrs2 end desc           --住所2				降順
		,case when orderby_in = 7 then t1.gyoseikucd end            --行政区			昇順
        ,case when orderby_in = -7 then t1.gyoseikucd end desc      --行政区			降順
        ,case when orderby_in = 8 then t1.juminkbn end              --住民区分			昇順
        ,case when orderby_in = -8 then t1.juminkbn end desc        --住民区分			降順
		,case when orderby_in = 9 then t1.hokenkbn end              --保険区分			昇順
        ,case when orderby_in = -9 then t1.hokenkbn end desc        --保険区分			降順
		,case when orderby_in = 10 then t1.siensotikbn end          --支援措置区分		昇順
        ,case when orderby_in = -10 then t1.siensotikbn end desc    --支援措置区分		降順

    limit limit_in offset offset_in;
end;
$function$