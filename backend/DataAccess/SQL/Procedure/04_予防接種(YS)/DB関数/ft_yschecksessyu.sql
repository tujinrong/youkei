/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 予防接種の入力チェック（接種情報）
　　　　　　
作成日　　: 2024.05.29
作成者　　: MIC信時
変更履歴　:
*******************************************************************/
CREATE OR REPLACE FUNCTION ft_yschecksessyu(
	yotokbn_in			varchar,	--用途区分(1:予防接種情報管理 2:予防接種エラー一覧 3:一括入力/取込)
	atenano_in			varchar,	--宛名番号
	sessyucd_in			varchar,	--接種種類コード
	kaisu_in			varchar,	--回数
	jissiymd_in			varchar,	--実施日
	sessyukbn_in		varchar,	--接種区分
	vaccinenmcd_in		varchar,	--ワクチンコード
	vaccinemakercd_in	varchar,	--ワクチンメーカーコード
	hoteikbn_in			varchar		--法定区分
	)
RETURNS TABLE(
	actresultkbn		integer,	--実行結果区分(0:実行完了 1:エラー 2:アラート)
	messageid			varchar,	--メッセージID
	messagetext			varchar		--メッセージ内容
	)
LANGUAGE plpgsql
AS $function$
DECLARE
	--メッセージID
	ERRORMESSAGEID constant varchar := 'E044001';	--エラーの場合、画面に表示するメッセージID
	ALERTMESSAGEID constant varchar := 'A044001';	--アラートの場合、画面に表示するメッセージID
	
	--テーブル名
	tablenm_yssessyu				text;		--予防接種テーブル
	tablenm_ysrikan					text;		--罹患テーブル
	tablenm_yskojinfree				text;		--予防接種（フリー項目）個人テーブル
	tablenm_ysfusinkotai			text;		--風しん抗体検査テーブル
	
	--エラー区分
	errorkbn_nenreichk				varchar(1);	--接種年齢チェック区分
	errorkbn_kankakuchk				varchar(1);	--接種間隔チェック区分
	errorkbn_kanochk				varchar(1);	--接種可能時期チェック区分
	errorkbn_hyojunchk				varchar(1);	--標準的な接種可能時期チェック区分
	errorkbn_daisyochk				varchar(1);	--大小チェック区分
	errorkbn_kaisuchk				varchar(1);	--接種可能回数チェック区分
	
	--生年月日
	bymd_fusyo						bool;
	bymd_text						varchar(10);
	bymd_date						date;
	
	jissiymd_date					date;		--実施日
	jissi_nenrei					interval;	--実施年齢
	issyogaiikkai					boolean;	--生涯1回フラグ
	sessyunm						text;		--接種種類名
	vacnm							text;		--ワクチン名
	vacmakernm						text;		--ワクチンメーカー名
	is2kaisessyu					bool;		--2回接種対象かどうか（HPV用）
	tempmsg							text;		--一時メッセージ
	
	--実施年度
	jissinendo_st					varchar(10);
	jissinendo_ed					varchar(10);
	jissinendo_st_date				date;
	jissinendo_ed_date				date;
	
	--前回接種種類
	zensessyucd						varchar(7);
	zensessyunm						text;
	zenjissiymd_text				varchar(10);
	zenjissiymd_date				date;
	
	--接種開始年齢（Hib、小児用肺炎球菌、HPV用）
	syokai_jissiymd					varchar(10);
	syokai_sessyu_nenrei			interval;
	
	--テーブル型
	tmp_row							RECORD;		--一時テーブル
	atena_row						RECORD;		--宛名テーブル
	sessyu_row						RECORD;		--予防接種テーブル
	nyuryokucheck_row				RECORD;		--予防接種入力チェックマスタ
	ctrl_row						RECORD;		--コントロールマスタ
	
	--ワクチン価数
	vackasucd						text;
	vackasu							text;
	vackasu_sessyucd				text;
	vackasucd_target				text;
	vackasu_target					text;
	
	--入力チェックマスタ
	chkmaster_ischk					boolean;
	chkmaster_iserror				boolean;
	
	--システム固有チェック
	koyuchk_jissiymd				varchar(10);
	koyuchk_jissiymd_date			date;
	koyuchk_iserror					boolean;
	
	--罹患済みチェック
	rikanchk_exist					boolean;
	rikanchk_text					text;
	rikanchk_cd						text;
	rikanchk_nm						text;
	
	--接種済みチェック
	sessyuchk_jissiymd_date			date;
	sessyuchk_exist					boolean;
	sessyuchk_text					text;
	sessyuchk_cd					text;
	sessyuchk_nm					text;
	sessyuchk_count					int := 0;
	sessyuchk_iserror				bool;
	
	--接種間隔チェック
	kankakuchk_sessyunm				text;
	kankakuchk_min					interval;
	kankakuchk_max					interval;
	kankakuchk_issamevac			boolean;
	kankakuchk_target_jissiymd		varchar(10);
	kankakuchk_vacsyurui			text;
	kankakuchk_vacsyurui_valtext	text;
	kankakuchk_vacsyurui_valint		integer;
	kankakuchk_jissiymd_date		date;
	
	--接種可能時期チェック
	kanochk_noen_maxdate			date;
	kanochk_st						date;
	kanochk_ed						date;
	kanochk_st2						date;
	kanochk_st_nendo_text			varchar(10);
	kanochk_ed_nendo_text			varchar(10);
	kanochk_st_nendo_date			date;
	kanochk_ed_nendo_date			date;
	kanochk_hassyogai				boolean;
	kanochk_iserror					boolean;
	kanochk_sessyukaisi				text;
	kanochk_sessyujiki				text;
	
	--標準的な接種時期チェック
	hyojunchk_st					date;
	hyojunchk_ed					date;
	hyojunchk_st_nendo_text			varchar(10);
	hyojunchk_ed_nendo_text			varchar(10);
	hyojunchk_st_nendo_date			date;
	hyojunchk_ed_nendo_date			date;
	
	--大小チェック
	daisyochk_jissiymd_text			varchar(10);
	daisyochk_jissiymd_date			date;
	daisyochk_sessyunm				text;
	
	--接種可能回数チェック
	kaisuchk_iserror				boolean;
	
	--その他チェック
	sonotachk_exist					boolean;
BEGIN
	-----------------------------------------------
    --エラー、アラート一時テーブルを作成
    -----------------------------------------------
	
	create temp table tmp(
		errorkbn	varchar,	--エラー区分（1:エラー 2:アラート）
		messagetext	varchar		--メッセージ内容
	);
	
	-----------------------------------------------
    --データ取得
    -----------------------------------------------
	
	--テーブル名取得
	if yotokbn_in = '1' then
		tablenm_yssessyu = 'wk_yssessyunyuryoku';
		tablenm_ysrikan = 'wk_ysrikannyuryoku';
		tablenm_yskojinfree = 'wk_yskojinfreenyuryoku';
		tablenm_ysfusinkotai = 'wk_ysfusinkotainyuryoku';
	elseif yotokbn_in = '2' or yotokbn_in = '3' then
		tablenm_yssessyu = 'wk_yssessyunyuryoku';
		tablenm_ysrikan = 'tt_ysrikan';
		tablenm_yskojinfree = 'tt_yskojinfree';
		tablenm_ysfusinkotai = 'tt_ysfusinkotai';
	else
		return;
	end if;
	
	--エラー区分取得
	for ctrl_row in select * from tm_afctrl where ctrlmaincd = '1004' and ctrlsubcd = 1 loop
		case ctrl_row.ctrlcd
			when '1' then
				errorkbn_nenreichk := ctrl_row.value1;
			when '2' then
				errorkbn_kankakuchk := ctrl_row.value1;
			when '3' then
				errorkbn_kanochk := ctrl_row.value1;
			when '4' then
				errorkbn_hyojunchk := ctrl_row.value1;
			when '5' then
				errorkbn_daisyochk := ctrl_row.value1;
			when '6' then
				errorkbn_kaisuchk := ctrl_row.value1;
			else
		end case;
	end loop;
	
	--対象者情報取得
	select * into atena_row from tt_afatena where atenano = atenano_in;
	
	--生年月日取得
	if atena_row.bymd is not null
	and atena_row.bymd_fusyoflg = false then
		bymd_date := to_date(atena_row.bymd, 'YYYY-MM-DD');
		
		--誕生日の前日に1歳年をとる
		bymd_date := bymd_date - interval '1 day';
	end if;
	
	--実施日取得
	if jissiymd_in is not null and jissiymd_in <> '' then
		jissiymd_date := to_date(jissiymd_in, 'YYYY-MM-DD');
	end if;
	
	--実施年齢取得
	if jissiymd_date is not null
	and bymd_date is not null then
		jissi_nenrei := age(jissiymd_date, bymd_date);
	end if;

	--生涯1回フラグの取得
	issyogaiikkai := exists(select * from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = sessyucd_in || kaisu_in and hanyokbn1 like '1%');

	--実施年度取得
	if jissiymd_date is not null then
		jissinendo_st := extract(year from jissiymd_date - interval '3 month') || '-04-01';
		jissinendo_ed := extract(year from jissiymd_date + interval '9 month') || '-03-31';
		jissinendo_st_date := to_date(jissinendo_st, 'YYYY-MM-DD');
		jissinendo_ed_date := to_date(jissinendo_ed, 'YYYY-MM-DD');
	end if;
	
	--前回接種種類取得
	select zensessyu into zensessyucd from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
	select nm into zensessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = zensessyucd;
	execute format('select jissiymd from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''%s'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, left(zensessyucd, 5), right(zensessyucd, 2)) into zenjissiymd_text;
	if zenjissiymd_text is not null then
		zenjissiymd_date := to_date(zenjissiymd_text, 'YYYY-MM-DD');
	end if;
	
	--接種開始年齢取得（Hib、小児用肺炎球菌、HPV用）
	if sessyucd_in = '10009' or sessyucd_in = '10010' or sessyucd_in = '10011' then
		if kaisu_in = '01' then
			syokai_jissiymd := jissiymd_in;
		else
			execute format('select jissiymd from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''01'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) into syokai_jissiymd;
		end if;
		
		if syokai_jissiymd is not null
		and bymd_date is not null then
			syokai_sessyu_nenrei := age(to_timestamp(syokai_jissiymd, 'YYYY-MM-DD'), bymd_date);
		end if;
	end if;
	
	--2回接種対象者かどうか取得（HPV(3回目)用）
	if sessyucd_in = '10011' and kaisu_in = '03'
	and syokai_sessyu_nenrei is not null
	and zenjissiymd_date is not null then
		--9価ワクチンかつ、接種開始年齢が15歳未満かつ、1回目と2回目の間隔が5か月以上
		if vackasu = '9'
		and syokai_sessyu_nenrei < interval '15 year'
		and (to_date(syokai_jissiymd, 'YYYY-MM-DD') + interval '5 month') < zenjissiymd_date then
			is2kaisessyu := true;
		end if;
	end if;
	
	-----------------------------------------------
    --システム固有チェック（定期、任意共通）
    -----------------------------------------------
	
	--■住登外チェック
	if atena_row.jutokbn = '2' then
		insert into tmp values('2', '対象者は住登外です。');
	end if;
	
	--接種種類名取得
	select nm into sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = sessyucd_in || kaisu_in;

	--■接種種類存在チェック
	if sessyunm is null then
		insert into tmp values('1', '入力された接種種類は存在しません。');
	end if;
	
	--■未来日チェック
	if jissiymd_date is not null
	and jissiymd_date > current_date then
		insert into tmp values('1', '本日以前の日付を入力してください。');
	end if;
	
	--■ワクチン存在チェック
	if vaccinenmcd_in is not null and vaccinenmcd_in <> '' then
		select nm into vacnm from tm_afhanyo where hanyomaincd = '3019' and hanyosubcd = 400002 and hanyocd = vaccinenmcd_in;
		if vacnm is null then
			insert into tmp values('1', '入力されたワクチンは存在しません。');
		end if;
	end if;
	
	--■ワクチンメーカー存在チェック
	if vaccinemakercd_in is not null and vaccinemakercd_in <> '' then
		select nm into vacmakernm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 3 and hanyocd = vaccinemakercd_in;
		if vacmakernm is null then
			insert into tmp values('1', '入力されたワクチンメーカーは存在しません。');
		end if;
	end if;
	
	--ワクチン価数取得
	if vacnm is not null then
		select hanyokbn3 into vackasucd from tm_afhanyo where hanyomaincd = '3019' and hanyosubcd = 400002 and hanyocd = vaccinenmcd_in;
		select hanyokbn1 into vackasu from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 4 and hanyocd = vackasucd;
		select hanyokbn2 into vackasu_sessyucd from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 4 and hanyocd = vackasucd;
	end if;
	
	--■ワクチン登録チェック
	if vacnm is not null and vacmakernm is not null then
		if not exists(select * from tm_ysvaccine where sessyucd = sessyucd_in and vaccinemakercd = vaccinemakercd_in and vaccinenmcd = vaccinenmcd_in and stopflg is false) then
			insert into tmp values('1', '未登録のワクチン情報です。（ワクチン：' || vacnm || '、ワクチンメーカー：' || vacmakernm || '）');
		end if;
	end if;
	
	-----------------------------------------------
    --システム固有チェック（定期接種）
    -----------------------------------------------
	
	if hoteikbn_in = '1' then
		--■未来日データ存在チェック
		if jissiymd_date is not null and sessyukbn_in = '1' then
			koyuchk_iserror := false;
			--生涯1回の接種種類入力時
			if issyogaiikkai then
				execute format('select max(jissiymd) from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''%s''', tablenm_yssessyu, atenano_in, sessyucd_in, kaisu_in) into koyuchk_jissiymd;
				koyuchk_iserror := jissiymd_date < to_date(koyuchk_jissiymd, 'YYYY-MM-DD');

			--複数回の接種種類入力時
			else
				for sessyu_row in execute format('select * from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s''', tablenm_yssessyu, atenano_in, sessyucd_in) loop
					koyuchk_jissiymd_date := to_date(sessyu_row.jissiymd, 'YYYY-MM-DD');
					if koyuchk_jissiymd_date >= jissinendo_st_date
					and koyuchk_jissiymd_date <= jissinendo_ed_date
					and jissiymd_date < koyuchk_jissiymd_date then
						koyuchk_iserror := true;
						exit;
					end if;
				end loop;
			end if;

			if koyuchk_iserror then
				insert into tmp values('1', '入力された日付より未来のデータが存在します。');
			end if;
		end if;
	end if;
	
	-----------------------------------------------
    --システム固有チェック（任意接種）
    -----------------------------------------------
	
	if hoteikbn_in = '2' then
		/*
		--インフルエンザ入力時
		if sessyucd_in = '20001'
		and jissiymd_date is not null
		and sessyukbn_in = '1' then
			for sessyu_row in execute format('select * from %I where hoteikbn = ''2'' and atenano = ''%s'' and sessyucd = ''%s''', tablenm_yssessyu, atenano_in, sessyucd_in) loop
				koyuchk_jissiymd_date := to_date(sessyu_row.jissiymd, 'YYYY-MM-DD');
				if koyuchk_jissiymd_date >= jissinendo_st_date
				and koyuchk_jissiymd_date <= jissinendo_ed_date
				and jissiymd_date < to_date(sessyu_row.jissiymd, 'YYYY-MM-DD') then
					insert into tmp values('1', '入力された日付より未来のデータが存在します。');
					exit;
				end if;
			end loop;
		end if;
		*/
	end if;
	
	-----------------------------------------------
    --接種年齢チェック（定期、任意共通）
    -----------------------------------------------
	
	if errorkbn_nenreichk = '1' or errorkbn_nenreichk = '2'
	and jissiymd_date is not null
	and bymd_date is not null
	and jissiymd_date < bymd_date then
		insert into tmp values(errorkbn_nenreichk, '生年月日以降の日付を入力してください。');
	end if;
	
	-----------------------------------------------
    --罹患済みチェック（定期接種）
    -----------------------------------------------
	
	if hoteikbn_in = '1' then
		--■罹患済みチェック1、2
		for i in 1..2 loop
			if i = 1 then
				select rikanchk1 into rikanchk_text from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
			else
				select rikanchk2 into rikanchk_text from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
			end if;
			
			if rikanchk_text is not null then
				foreach rikanchk_cd in array string_to_array(rikanchk_text, ',') loop
					--母子感染対象
					if rikanchk_cd = '99' then
						execute format('select exists(select * from %I where atenano = ''%s'' and itemcd = ''200400005001'' and strvalue = ''1'')', tablenm_yskojinfree, atenano_in) into rikanchk_exist;
						if rikanchk_exist then
							insert into tmp values(i, '母子感染対象者です。');
							exit;
						end if;
					--母子感染対象以外
					else
						execute format('select exists(select * from %I where atenano = ''%s'' and rikancd = ''%s'')', tablenm_ysrikan, atenano_in, rikanchk_cd) into rikanchk_exist;
						if rikanchk_exist then
							select nm into rikanchk_nm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 5 and hanyocd = rikanchk_cd;
							insert into tmp values(i, rikanchk_nm || 'は罹患済みです。');
							exit;
						end if;
					end if;
				end loop;
			end if;
		end loop;
	end if;
	
	-----------------------------------------------
    --接種済みチェック（定期接種）
    -----------------------------------------------
	
	if hoteikbn_in = '1' then
		--■同一回数チェック
		--インフルエンザ、新型コロナ（複数回）入力時
		if sessyucd_in = '20001' or (sessyucd_in = '30001' and kaisu_in = '00') then
			for sessyu_row in execute format('select * from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) loop
				sessyuchk_jissiymd_date := to_date(sessyu_row.jissiymd, 'YYYY-MM-DD');
				--同一接種種類 かつ 同一年度 かつ 接種区分=接種 のデータが存在する
				if sessyuchk_jissiymd_date is not null
				and jissiymd_date is not null
				and sessyuchk_jissiymd_date >= jissinendo_st_date
				and sessyuchk_jissiymd_date <= jissinendo_ed_date then
					insert into tmp values('1', '同年度内において' || sessyunm || 'は接種済みです。');
					exit;
				end if;
			end loop;
			
		--インフルエンザ、新型コロナ（複数回）以外入力時
		else
			--定期接種 かつ 同一接種種類 かつ 同一回数 かつ 接種区分=接種 のデータが存在する
			execute format('select exists(select * from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''%s'' and sessyukbn = ''1'')', tablenm_yssessyu, atenano_in, sessyucd_in, kaisu_in) into sessyuchk_exist;
			if sessyuchk_exist then
				insert into tmp values('1', sessyunm || 'は接種済みです。');
			end if;
		end if;
		
		--■前回回数チェック
		chkmaster_ischk := false;
		--Hib入力時
		if sessyucd_in = '10009' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--入力チェックマスタに従う
				chkmaster_ischk := true;
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--追加以外入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in <> '09';
			--接種開始年齢が1歳以上
			else
				--チェックなし
			end if;

		--小児用肺炎球菌入力時
		elseif sessyucd_in = '10010' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--入力チェックマスタに従う
				chkmaster_ischk := true;
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--追加以外入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in <> '09';
			--接種開始年齢が1歳以上2歳未満
			elseif syokai_sessyu_nenrei >= interval '1 year' and syokai_sessyu_nenrei < interval '2 year' then
				--1回目または2回目入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in = '01' or kaisu_in = '02';
			--接種開始年齢が2歳以上
			else
				--チェックなし
			end if;
			
		--Hib、小児用肺炎球菌以外入力時
		else
			chkmaster_ischk := true;
		end if;
		
		if chkmaster_ischk then
			--入力チェックマスタに従う
			if zensessyucd is not null then
				execute format('select exists(select * from %I where hoteikbn = ''1'' atenano_in, and sessyucd = ''%s'' and kaisu = ''%s'' and sessyukbn = ''1'')', tablenm_yssessyu, atenano_in, left(zensessyucd, 5), right(zensessyucd, 2)) into sessyuchk_exist;
				if sessyuchk_exist = false then
					insert into tmp values('2', zensessyunm || 'は未接種です。');
				end if;
			end if;
		end if;
		
		--■接種済みチェック1、2
		for i in 1..2 loop
			if i = 1 then
				select sessyuchk1 into sessyuchk_text from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
			else
				select sessyuchk2 into sessyuchk_text from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
			end if;

			if sessyuchk_text is not null then
				foreach sessyuchk_cd in array string_to_array(sessyuchk_text, ',') loop
					execute format('select exists(select * from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''%s'' and sessyukbn = ''1'')', tablenm_yssessyu, atenano_in, left(sessyuchk_cd, 5), right(sessyuchk_cd, 2)) into sessyuchk_exist;
					if sessyuchk_exist then
						select nm into sessyuchk_nm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = sessyuchk_cd;
						insert into tmp values(i, sessyuchk_nm || 'は接種済みです。');
						exit;
					end if;
				end loop;
			end if;
		end loop;
	end if;
	
	-----------------------------------------------
    --接種済みチェック（任意接種）
    -----------------------------------------------
	
	if hoteikbn_in = '2' then
		/*
		--インフルエンザ入力時
		if sessyucd_in = '20001'
		and jissiymd_date is not null
		and bymd_date is not null then
			--同年度内の接種回数取得
			for sessyu_row in execute format('select * from %I where hoteikbn = ''2'' and atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) loop
				sessyuchk_jissiymd_date := to_date(sessyu_row.jissiymd, 'YYYY-MM-DD');
				if sessyuchk_jissiymd_date is not null
				and sessyuchk_jissiymd_date >= jissinendo_st_date
				and sessyuchk_jissiymd_date <= jissinendo_ed_date then
					sessyuchk_count := sessyuchk_count + 1;
				end if;
			end loop;
			
			--接種時年齢が13歳以上
			if jissi_nenrei >= interval '13 year' then
				--接種データが1件以上存在する
				sessyuchk_iserror := sessyuchk_count >= 1;
				
			--接種時年齢が12歳以上
			else
				--接種データが2件以上存在する
				sessyuchk_iserror := sessyuchk_count >= 2;
			end if;
			
			if sessyuchk_iserror then
				insert into tmp values('2', '同年度内において' || sessyunm || 'は接種済みです。');
			end if;
		end if;
		*/
	end if;
	
	-----------------------------------------------
    --接種間隔チェック（定期接種）
    -----------------------------------------------
	
	if errorkbn_kankakuchk = '1' or errorkbn_kankakuchk = '2'
	and hoteikbn_in = '1'
	and sessyukbn_in = '1'
	and jissiymd_date is not null then
		--■同一接種種類チェック
		chkmaster_ischk := false;
		--Hib入力時
		if sessyucd_in = '10009' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--入力チェックマスタに従う
				chkmaster_ischk := true;
				
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--1回目または2回目入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in = '01' or kaisu_in = '02';
				--3回目入力時
				if kaisu_in = '03' and zenjissiymd_date is not null then
					if (zenjissiymd_date + interval '7 month') > jissiymd_date then
						insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、７月以上である必要があります。');
					end if;
				end if;
				
			--接種開始年齢が1歳以上
			else
				--チェックなし
			end if;
			
		--小児用肺炎球菌入力時
		elseif sessyucd_in = '10010' then
			--ワクチン価数チェック
			if vaccinenmcd_in is not null
			and (vackasu = '13' or vackasu = '15')
			and vackasu_sessyucd = '10010' then
				kankakuchk_issamevac := true;
				for sessyu_row in execute format('select * from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) loop
					if sessyu_row.kaisu = kaisu_in then
						continue;
					end if;
					select hanyokbn3 into vackasucd_target from tm_afhanyo where hanyomaincd = '3019' and hanyosubcd = 400002 and hanyocd = sessyu_row.vaccinenmcd;
					select hanyokbn1 into vackasu_target from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 4 and hanyocd = vackasucd_target;
					if vackasu <> vackasu_target then
						kankakuchk_issamevac := false;
						select nm into kankakuchk_sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = sessyu_row.sessyucd || sessyu_row.kaisu;
						insert into tmp values('2', kankakuchk_sessyunm || 'とのワクチン価数が異なっています。');
					end if;
				end loop;
				
				--同一ワクチン価数の場合、間隔チェックを行う
				if kankakuchk_issamevac
				and zenjissiymd_date is not null
				and syokai_sessyu_nenrei is not null then
					--接種開始年齢が7か月未満
					if syokai_sessyu_nenrei < interval '7 month' then
						--入力チェックマスタに従う
						chkmaster_ischk := true;
					--接種開始年齢が7か月以上1歳未満
					elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
						--2回目入力時、入力チェックマスタに従う
						chkmaster_ischk := kaisu_in = '02';
						--3回目入力時
						if kaisu_in = '03' then
							if (zenjissiymd_date + interval '60 day') > jissiymd_date then
								insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、６０日以上である必要があります。');
							end if;
						end if;
					--接種開始年齢が1歳以上2歳未満
					elseif syokai_sessyu_nenrei >= interval '1 year' and syokai_sessyu_nenrei < interval '2 year' then
						--2回目入力時
						if kaisu_in = '02' then
							if (zenjissiymd_date + interval '60 day') > jissiymd_date then
								insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、６０日以上である必要があります。');
							end if;
						end if;
					--接種開始年齢が2歳以上
					else
						--チェックなし
					end if;
				end if;
			end if;
			
		--HPV入力時
		elseif sessyucd_in = '10011' then
			--ワクチン価数チェック
			if (vackasu = '2' or vackasu = '4' or vackasu = '9')
			and vackasu_sessyucd = '10011' then
				kankakuchk_issamevac := true;
				for sessyu_row in execute format('select * from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) loop
					if sessyu_row.kaisu = kaisu_in then
						continue;
					end if;
					select hanyokbn3 into vackasucd_target from tm_afhanyo where hanyomaincd = '3019' and hanyosubcd = 400002 and hanyocd = sessyu_row.vaccinenmcd;
					select hanyokbn1 into vackasu_target from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 4 and hanyocd = vackasucd_target;
					if vackasu <> vackasu_target then
						kankakuchk_issamevac := false;
						select nm into kankakuchk_sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = sessyu_row.sessyucd || sessyu_row.kaisu;
						insert into tmp values('2', kankakuchk_sessyunm || 'とのワクチン価数が異なっています。');
					end if;
				end loop;

				--同一ワクチン価数の場合、間隔チェックを行う
				if kankakuchk_issamevac
				and zenjissiymd_date is not null then
					--9価または4価ワクチン
					if vackasu = '9' or vackasu = '4' then
						--2回目入力時
						if kaisu_in = '02' then
							if (zenjissiymd_date + interval '1 month') > jissiymd_date then
								insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、１月以上である必要があります。');
							end if;
						end if;
						--3回目入力時
						if kaisu_in = '03' and is2kaisessyu = false then
							if (zenjissiymd_date + interval '3 month') > jissiymd_date then
								insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、３月以上である必要があります。');
							end if;
						end if;
					end if;

					--2価ワクチン
					if vackasu = '2' then
						--2回目入力時
						if kaisu_in = '02' then
							if (zenjissiymd_date + interval '1 month') > jissiymd_date then
								insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、１月以上である必要があります。');
							end if;
						end if;
						--3回目入力時
						if kaisu_in = '03' then
							--TODO:2回目との間隔チェック　2か月半を2か月と15日で計算しているが良いか？
							if (zenjissiymd_date + interval '2 month' + interval '15 day') > jissiymd_date then
								insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、２月半以上である必要があります。');
							end if;
							--1回目との間隔チェック
							execute format('select jissiymd from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''01'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) into kankakuchk_target_jissiymd;
							if kankakuchk_target_jissiymd is not null
							and (to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') + interval '5 month') > jissiymd_date then
								select nm into kankakuchk_sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = '1001101';
								insert into tmp values(errorkbn_kankakuchk, kankakuchk_sessyunm || 'との間隔は、５月以上である必要があります。');
							end if;
						end if;
					end if;
				end if;
			end if;
			
		--Hib、小児用肺炎球菌、HPV以外入力時
		else
			--入力チェックマスタに従う
			chkmaster_ischk := true;
		end if;
		
		if chkmaster_ischk then
			--入力チェックマスタに従う
			select * into nyuryokucheck_row from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
			if zenjissiymd_date is not null
			and(nyuryokucheck_row.kankakutani = '1' or nyuryokucheck_row.kankakutani = '2'
			or nyuryokucheck_row.kankakutani = '3' or nyuryokucheck_row.kankakutani = '4')
			and nyuryokucheck_row.kankakucomment is not null then
				chkmaster_iserror := false;
				--接種間隔下限チェック
				if nyuryokucheck_row.kankakumin is not null then
					case nyuryokucheck_row.kankakutani
						when '1' then
							kankakuchk_min := make_interval(days => nyuryokucheck_row.kankakumin);
						when '2' then
							kankakuchk_min := make_interval(weeks => nyuryokucheck_row.kankakumin);
						when '3' then
							kankakuchk_min := make_interval(months => nyuryokucheck_row.kankakumin);
						when '4' then
							kankakuchk_min := make_interval(years => nyuryokucheck_row.kankakumin);
					end case;
					if (zenjissiymd_date + kankakuchk_min) > jissiymd_date then
						chkmaster_iserror := true;
					end if;
				end if;
				
				--接種間隔上限チェック
				if nyuryokucheck_row.kankakumax is not null then
					case nyuryokucheck_row.kankakutani
						when '1' then
							kankakuchk_max := make_interval(days => nyuryokucheck_row.kankakumax);
						when '2' then
							kankakuchk_max := make_interval(weeks => nyuryokucheck_row.kankakumax);
						when '3' then
							kankakuchk_max := make_interval(months => nyuryokucheck_row.kankakumax);
						when '4' then
							kankakuchk_max := make_interval(years => nyuryokucheck_row.kankakumax);
					end case;
					if (zenjissiymd_date + kankakuchk_max) < jissiymd_date then
						chkmaster_iserror := true;
					end if;
				end if;
				
				if chkmaster_iserror then
					insert into tmp values(errorkbn_kankakuchk, zensessyunm || 'との間隔は、' || nyuryokucheck_row.kankakucomment || 'である必要があります。');
				end if;
			end if;
		end if;
		
		--B型肝炎(3回目)入力時
		if sessyucd_in = '10019' and kaisu_in = '03' then
			--1回目との間隔チェックを追加で行う
			execute format('select jissiymd from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''01'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, sessyucd_in) into kankakuchk_target_jissiymd;
			if kankakuchk_target_jissiymd is not null
			and (to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') + interval '139 day') > jissiymd_date then
				select nm into kankakuchk_sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = '1001901';
				insert into tmp values(errorkbn_kankakuchk, kankakuchk_sessyunm || 'との間隔は、１３９日以上である必要があります。');
			end if;
		end if;
		
		--■他接種種類チェック
		--ワクチン種類の間隔日数取得
		select vaccinesyu into kankakuchk_vacsyurui from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
		if kankakuchk_vacsyurui is not null then
			select hanyokbn1 into kankakuchk_vacsyurui_valtext from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 6 and hanyocd =kankakuchk_vacsyurui;
			if kankakuchk_vacsyurui_valtext is not null then
				kankakuchk_vacsyurui_valint := cast(REGEXP_REPLACE(kankakuchk_vacsyurui_valtext, '[^0-9]+', '', 'g') as integer);
				
				--同一ワクチン種類の接種日との間隔チェック
				for nyuryokucheck_row in select * from tm_ysnyuryokucheck where vaccinesyu = kankakuchk_vacsyurui loop
					execute format('select jissiymd from %I where sessyucd = ''%s'' and atenano = ''%s'' and kaisu = ''%s'' and sessyukbn = ''1''', tablenm_yssessyu, atenano_in, nyuryokucheck_row.sessyucd, nyuryokucheck_row.kaisu) into kankakuchk_target_jissiymd;
					if kankakuchk_target_jissiymd is not null then
						chkmaster_iserror := false;
						--比較接種日 >= 入力接種日の場合
						if to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') >= jissiymd_date then
							chkmaster_iserror := to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') < jissiymd_date + make_interval(days => kankakuchk_vacsyurui_valint);
						end if;
						--比較接種日 <= 入力接種日の場合
						if to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') <= jissiymd_date then
							chkmaster_iserror := to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') > jissiymd_date - make_interval(days => kankakuchk_vacsyurui_valint);
						end if;
						
						if chkmaster_iserror then
							select nm into kankakuchk_sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = nyuryokucheck_row.sessyucd || nyuryokucheck_row.kaisu;
							kankakuchk_vacsyurui_valtext := translate(kankakuchk_vacsyurui_valtext, '1234567890', '１２３４５６７８９０');
							insert into tmp values(errorkbn_kankakuchk, kankakuchk_sessyunm || 'との間隔は、' || kankakuchk_vacsyurui_valtext || '日以上である必要があります。');
						end if;
					end if;
				end loop;
			end if;
		end if;
	end if;
	
	-----------------------------------------------
    --接種間隔チェック（任意接種）
    -----------------------------------------------
	
	if errorkbn_kankakuchk = '1' or errorkbn_kankakuchk = '2'
	and hoteikbn_in = '2'
	and sessyukbn_in = '1'
	and jissiymd_date is not null then
		/*
		--インフルエンザ入力時
		if sessyucd_in = '20001'
		and jissiymd_date is not null
		and bymd_date is not null then
			--接種時年齢が12歳以下
			if jissi_nenrei <= interval '12 year' then
				for sessyu_row in execute format('select * from %I where hoteikbn = ''2'' and atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1'' order by edano desc', tablenm_yssessyu, atenano_in, sessyucd_in) loop
					kankakuchk_jissiymd_date := to_date(sessyu_row.jissiymd, 'YYYY-MM-DD');
					if kankakuchk_jissiymd_date is not null
					and kankakuchk_jissiymd_date >= jissinendo_st_date
					and kankakuchk_jissiymd_date <= jissinendo_ed_date
					and (koyuchk_jissiymd_date + interval '14 day') > jissiymd_date then
						insert into tmp values(errorkbn_kankakuchk, '同年度内の前回接種との間隔は、１４日以上である必要があります。');
						exit;
					end if;
				end loop;
			end if;
		end if;
		
		--成人用肺炎球菌入力時
		if sessyucd_in = '20002' then
			--前回接種との間隔チェック（定期接種分も含む）
			execute format('select jissiymd from %I where atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1'' order by jissiymd desc', tablenm_yssessyu, atenano_in, sessyucd_in) into kankakuchk_target_jissiymd;
			if kankakuchk_target_jissiymd is not null
			and (to_date(kankakuchk_target_jissiymd, 'YYYY-MM-DD') + interval '5 year') > jissiymd_date then
				insert into tmp values(errorkbn_kankakuchk, '前回接種との間隔は、５年以上である必要があります。');
			end if;
		end if;
		*/
	end if;
	
	-----------------------------------------------
    --接種可能時期チェック（定期接種）
    -----------------------------------------------
	
	if errorkbn_kanochk = '1' or errorkbn_kanochk = '2'
	and hoteikbn_in = '1'
	and sessyukbn_in = '1'
	and jissiymd_date is not null
	and bymd_date is not null then
		--生涯1回の場合
		if issyogaiikkai then
			chkmaster_ischk := false;
			--HPV入力時
			if sessyucd_in = '10011' then
				--キャッチアップ対象者の場合
				if bymd_date + interval '1 day' >= make_date(1997,4,2) and bymd_date + interval '1 day' <= make_date(2007,4,1) then
					if jissiymd_date < make_date(2022,4,1) or jissiymd_date > make_date(2025,3,31) then
						insert into tmp values(errorkbn_kanochk, 'キャッチアップ対象者（生年月日：平成9年度～平成18年度）の接種可能時期は令和4年4月から令和7年3月です。');
					end if;
				--キャッチアップ対象者でない場合
				else
					--入力チェックマスタに従う
					chkmaster_ischk := true;
				end if;
				
			--日本脳炎入力時
			elseif sessyucd_in = '10007' then
				--キャッチアップ対象者の場合
				if bymd_date + interval '1 day' >= make_date(1995,4,2) and bymd_date + interval '1 day' <= make_date(2007,4,1) then
					kanochk_noen_maxdate := cast(bymd_date + interval '20 year' as date);
					if kanochk_noen_maxdate <= jissiymd_date then
						insert into tmp values(errorkbn_kanochk, 'キャッチアップ対象者（生年月日：平成7年度～平成18年度）の接種可能時期は' || fn_euchangewareki(to_char(kanochk_noen_maxdate, 'YYYY-MM-DD')) || 'までです。');
					end if;
				--キャッチアップ対象者でない場合
				else
					--入力チェックマスタに従う
					chkmaster_ischk := true;
				end if;
				
			--HPV、日本脳炎以外入力時
			else
				--入力チェックマスタに従う
				chkmaster_ischk := true;
			end if;
			
			if chkmaster_ischk then
				--入力チェックマスタに従う
				select * into nyuryokucheck_row from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
				if (nyuryokucheck_row.kanohanikbn = '1' or nyuryokucheck_row.kanohanikbn = '2')
				and nyuryokucheck_row.kanocomment is not null then
					chkmaster_iserror := false;
					--接種可能開始チェック
					if nyuryokucheck_row.kanost is not null
					and (nyuryokucheck_row.kanosttani = '1' or nyuryokucheck_row.kanosttani = '2'
					or nyuryokucheck_row.kanosttani = '3' or nyuryokucheck_row.kanosttani = '4' or nyuryokucheck_row.kanosttani = '5') then
						--接種可能開始単位=年度以外の場合
						if nyuryokucheck_row.kanosttani <> '5' then
							case nyuryokucheck_row.kanosttani
								when '1' then
									kanochk_st := bymd_date + make_interval(days => nyuryokucheck_row.kanost);
								when '2' then
									kanochk_st := bymd_date + make_interval(weeks => nyuryokucheck_row.kanost);
								when '3' then
									kanochk_st := bymd_date + make_interval(months => nyuryokucheck_row.kanost);
								when '4' then
									kanochk_st := bymd_date + make_interval(years => nyuryokucheck_row.kanost);
							end case;
							chkmaster_iserror := chkmaster_iserror or (kanochk_st > jissiymd_date);
						
						--接種可能開始単位=年度の場合
						else
							kanochk_st_nendo_text := extract(year from bymd_date + make_interval(years => nyuryokucheck_row.kanost) - interval '3 month') || '-04-01';
							kanochk_st_nendo_date := to_date(kanochk_st_nendo_text, 'YYYY-MM-DD');
							chkmaster_iserror := chkmaster_iserror or (kanochk_st_nendo_date > jissiymd_date);
						end if;
					end if;
					
					--接種可能終了チェック
					if nyuryokucheck_row.kanoed is not null
					and (nyuryokucheck_row.kanoedtani = '1' or nyuryokucheck_row.kanoedtani = '2'
					or nyuryokucheck_row.kanoedtani = '3' or nyuryokucheck_row.kanoedtani = '4' or nyuryokucheck_row.kanoedtani = '5') then
						--接種可能終了単位=年度以外の場合
						if nyuryokucheck_row.kanoedtani <> '5' then
							case nyuryokucheck_row.kanoedtani
								when '1' then
									kanochk_ed := bymd_date + make_interval(days => nyuryokucheck_row.kanoed);
								when '2' then
									kanochk_ed := bymd_date + make_interval(weeks => nyuryokucheck_row.kanoed);
								when '3' then
									kanochk_ed := bymd_date + make_interval(months => nyuryokucheck_row.kanoed);
								when '4' then
									kanochk_ed := bymd_date + make_interval(years => nyuryokucheck_row.kanoed);
							end case;
							--接種可能範囲区分の考慮
							if nyuryokucheck_row.kanohanikbn = '2' then
								kanochk_ed := kanochk_ed - interval '1 day';
							end if;
							chkmaster_iserror := chkmaster_iserror or (kanochk_ed < jissiymd_date);
							
						--接種可能終了単位=年度の場合
						else
							kanochk_ed_nendo_text := extract(year from bymd_date + make_interval(years => nyuryokucheck_row.kanoed) + interval '9 month') || '-03-31';
							kanochk_ed_nendo_date := to_date(kanochk_ed_nendo_text, 'YYYY-MM-DD');
							--接種可能範囲区分の考慮
							if nyuryokucheck_row.kanohanikbn = '2' then
								kanochk_ed_nendo_date := kanochk_ed_nendo_date - interval '1 day';
							end if;
							chkmaster_iserror := chkmaster_iserror or (kanochk_ed_nendo_date < jissiymd_date);
						end if;
					end if;
					
					if chkmaster_iserror then
						tempmsg := sessyunm || 'の接種可能時期は、「';
						if nyuryokucheck_row.kanosttani <> '5' then
							tempmsg := tempmsg || fn_euchangewareki(to_char(kanochk_st, 'YYYY-MM-DD'));
						else
							tempmsg := tempmsg || fn_euchangewareki(kanochk_st_nendo_text);
						end if;
						tempmsg := tempmsg || '」～「';
						if nyuryokucheck_row.kanoedtani <> '5' then
							tempmsg := tempmsg || fn_euchangewareki(to_char(kanochk_ed, 'YYYY-MM-DD'));
						else
							tempmsg := tempmsg || fn_euchangewareki(kanochk_ed_nendo_text);
						end if;
						tempmsg := tempmsg || '」です。（' || nyuryokucheck_row.kanocomment || '）';
						insert into tmp values(errorkbn_kanochk, tempmsg);
					end if;
				end if;
			end if;
			
			kanochk_iserror := false;
		
			--Hib入力時
			if sessyucd_in = '10009'
			and syokai_sessyu_nenrei is not null then
				--接種開始年齢が7か月未満
				if syokai_sessyu_nenrei < interval '7 month' then
					--2回目または3回目入力時、生後13か月以上の場合
					if (kaisu_in = '02' or kaisu_in = '03')
					and jissi_nenrei >= interval '13 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月未満';
						kanochk_sessyujiki := '生後１３月以上';
					end if;

				--接種開始年齢が7か月以上1歳未満
				elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
					--2回目入力時、生後13か月以上の場合
					if kaisu_in = '02' and jissi_nenrei >= interval '13 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月以上１歳未満';
						kanochk_sessyujiki := '生後１３月以上';
					end if;

				--接種開始年齢が1歳以上
				else
					--チェックなし
				end if;
			end if;

			--小児用肺炎球菌入力時
			if sessyucd_in = '10010' and syokai_sessyu_nenrei is not null then
				--接種開始年齢が7か月未満
				if syokai_sessyu_nenrei < interval '7 month' then
					--2回目入力時、生後13か月以上の場合
					if kaisu_in = '02' and jissi_nenrei >= interval '13 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月未満';
						kanochk_sessyujiki := '生後１３月以上';
					--3回目入力時、生後25か月以上の場合
					elseif kaisu_in = '03' and jissi_nenrei >= interval '25 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月未満';
						kanochk_sessyujiki := '生後２５月以上';
					--追加入力時、生後12か月未満の場合
					elseif kaisu_in = '09' and jissi_nenrei < interval '12 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月未満';
						kanochk_sessyujiki := '生後１２月未満';
					end if;

				--接種開始年齢が7か月以上1歳未満
				elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
					--2回目入力時、生後25か月以上の場合
					if kaisu_in = '02' and jissi_nenrei >= interval '25 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月以上１歳未満';
						kanochk_sessyujiki := '生後２５月以上';
					--追加入力時、生後12か月未満の場合
					elseif kaisu_in = '09' and jissi_nenrei < interval '12 month' then
						kanochk_iserror := true;
						kanochk_sessyukaisi := '７か月以上１歳未満';
						kanochk_sessyujiki := '生後１２月未満';
					end if;

				--接種開始年齢が1歳以上2歳未満
				elseif syokai_sessyu_nenrei >= interval '1 year' and syokai_sessyu_nenrei < interval '2 year' then
					--チェックなし

				--接種開始年齢が2歳以上
				else
					--チェックなし
				end if;
			end if;

			if kanochk_iserror then
				insert into tmp values(errorkbn_kanochk, '接種開始が' || kanochk_sessyukaisi || 'ですが' || sessyunm || 'の接種時期が' || kanochk_sessyujiki || 'です。');
			end if;
			
		--複数回の場合（成人用肺炎球菌、インフルエンザ、コロナ共通）
		else
			--内部障害有無の取得
			execute format('select exists(select * from %I where atenano = ''%s'' and itemcd = ''200400005002'' and strvalue = ''1'')', tablenm_yskojinfree, atenano_in) into kanochk_hassyogai;
			chkmaster_iserror := false;
			if jissi_nenrei < interval '60 year' then
				chkmaster_iserror := true;
				tempmsg := '６０歳未満です。';
			elseif jissi_nenrei < interval '65 year' and kanochk_hassyogai = false then
				chkmaster_iserror := true;
				tempmsg := '６０歳以上、６５歳未満ですが、1級相当の内部障害を有していません。';
			end if;
			
			--成人用肺炎球菌のみ
			if sessyucd_in = '20002' then
				if jissi_nenrei >= interval '66 year' then
					chkmaster_iserror := true;
					tempmsg := '６６歳以上です。';
				end if;
			end if;
			
			if chkmaster_iserror then
				insert into tmp values(errorkbn_kanochk, tempmsg);
			end if;
		end if;
	end if;
	
	-----------------------------------------------
    --接種可能時期チェック（任意接種）
    -----------------------------------------------
	
	if errorkbn_kanochk = '1' or errorkbn_kanochk = '2'
	and hoteikbn_in = '2'
	and sessyukbn_in = '1'
	and jissiymd_date is not null
	and bymd_date is not null then
		/*
		--インフルエンザ入力時
		if sessyucd_in = '20001' then
			kanochk_st := bymd_date + interval '6 month';
			kanochk_ed := bymd_date + interval '18 year';
			kanochk_st2 := bymd_date + interval '60 year';
			if jissiymd_date < kanochk_st or (jissiymd_date > kanochk_ed and jissiymd_date < kanochk_st2) then
				insert into tmp values(errorkbn_kanochk, sessyunm || 'の接種可能時期は、「' || fn_euchangewareki(to_char(kanochk_st, 'YYYY-MM-DD')) || '」～「' || fn_euchangewareki(to_char(kanochk_ed, 'YYYY-MM-DD')) || '」、または「' || fn_euchangewareki(to_char(kanochk_st2, 'YYYY-MM-DD')) || '」以降です。(生後６月から１８歳に至るまでの間にある者、または６０歳以上の者)');
			end if;
		end if;
		*/
	end if;
	
	-----------------------------------------------
    --標準的な接種時期チェック（定期接種）
    -----------------------------------------------
	
	if errorkbn_hyojunchk = '1' or errorkbn_hyojunchk = '2'
	and hoteikbn_in = '1'
	and sessyukbn_in = '1'
	and jissiymd_date is not null
	and bymd_date is not null then
		--入力チェックマスタに従う
		select * into nyuryokucheck_row from tm_ysnyuryokucheck where sessyucd = sessyucd_in and kaisu = kaisu_in;
		if (nyuryokucheck_row.hyojunhanikbn = '1' or nyuryokucheck_row.hyojunhanikbn = '2')
		and nyuryokucheck_row.hyojuncomment is not null then
			chkmaster_iserror := false;
			--接種標準開始チェック
			if nyuryokucheck_row.hyojunst is not null
			and (nyuryokucheck_row.hyojunsttani = '1' or nyuryokucheck_row.hyojunsttani = '2'
			or nyuryokucheck_row.hyojunsttani = '3' or nyuryokucheck_row.hyojunsttani = '4' or nyuryokucheck_row.hyojunsttani = '5') then
				--接種標準開始単位=年度以外の場合
				if nyuryokucheck_row.hyojunsttani <> '5' then
					case nyuryokucheck_row.hyojunsttani
						when '1' then
							hyojunchk_st := bymd_date + make_interval(days => nyuryokucheck_row.hyojunst);
						when '2' then
							hyojunchk_st := bymd_date + make_interval(weeks => nyuryokucheck_row.hyojunst);
						when '3' then
							hyojunchk_st := bymd_date + make_interval(months => nyuryokucheck_row.hyojunst);
						when '4' then
							hyojunchk_st := bymd_date + make_interval(years => nyuryokucheck_row.hyojunst);
					end case;
					chkmaster_iserror := chkmaster_iserror or (hyojunchk_st > jissiymd_date);

				--接種標準開始単位=年度の場合
				else
					hyojunchk_st_nendo_text := extract(year from bymd_date + make_interval(years => nyuryokucheck_row.hyojunst) - interval '3 month') || '-04-01';
					hyojunchk_st_nendo_date := to_date(hyojunchk_st_nendo_text, 'YYYY-MM-DD');
					chkmaster_iserror := chkmaster_iserror or (hyojunchk_st_nendo_date > jissiymd_date);
				end if;
			end if;

			--接種標準終了チェック
			if nyuryokucheck_row.hyojuned is not null
			and (nyuryokucheck_row.hyojunedtani = '1' or nyuryokucheck_row.hyojunedtani = '2'
			or nyuryokucheck_row.hyojunedtani = '3' or nyuryokucheck_row.hyojunedtani = '4' or nyuryokucheck_row.hyojunedtani = '5') then
				--接種可能終了単位=年度以外の場合
				if nyuryokucheck_row.hyojunedtani <> '5' then
					case nyuryokucheck_row.hyojunedtani
						when '1' then
							hyojunchk_ed := bymd_date + make_interval(days => nyuryokucheck_row.hyojuned);
						when '2' then
							hyojunchk_ed := bymd_date + make_interval(weeks => nyuryokucheck_row.hyojuned);
						when '3' then
							hyojunchk_ed := bymd_date + make_interval(months => nyuryokucheck_row.hyojuned);
						when '4' then
							hyojunchk_ed := bymd_date + make_interval(years => nyuryokucheck_row.hyojuned);
					end case;
					--接種標準範囲区分の考慮
					if nyuryokucheck_row.hyojunhanikbn = '2' then
						hyojunchk_ed := hyojunchk_ed - interval '1 day';
					end if;
					chkmaster_iserror := chkmaster_iserror or (hyojunchk_ed < jissiymd_date);

				--接種標準終了単位=年度の場合
				else
					hyojunchk_ed_nendo_text := extract(year from bymd_date + make_interval(years => nyuryokucheck_row.hyojuned) + interval '9 month') || '-03-31';
					hyojunchk_ed_nendo_date := to_date(hyojunchk_ed_nendo_text, 'YYYY-MM-DD');
					--接種標準範囲区分の考慮
					if nyuryokucheck_row.hyojunhanikbn = '2' then
						hyojunchk_ed_nendo_date := hyojunchk_ed_nendo_date - interval '1 day';
					end if;
					chkmaster_iserror := chkmaster_iserror or (hyojunchk_ed_nendo_date < jissiymd_date);
				end if;
			end if;

			if chkmaster_iserror then
				tempmsg := sessyunm || 'の標準的な接種時期は、「';
				if nyuryokucheck_row.hyojunsttani <> '5' then
					tempmsg := tempmsg || fn_euchangewareki(to_char(hyojunchk_st, 'YYYY-MM-DD'));
				else
					tempmsg := tempmsg || fn_euchangewareki(hyojunchk_st_nendo_text);
				end if;
				tempmsg := tempmsg || '」～「';
				if nyuryokucheck_row.hyojunedtani <> '5' then
					tempmsg := tempmsg || fn_euchangewareki(to_char(hyojunchk_ed, 'YYYY-MM-DD'));
				else
					tempmsg := tempmsg || fn_euchangewareki(hyojunchk_ed_nendo_text);
				end if;
				tempmsg := tempmsg || '」です。（' || nyuryokucheck_row.hyojuncomment || '）';
				insert into tmp values(errorkbn_hyojunchk, tempmsg);
			end if;
		end if;
	end if;
	
	-----------------------------------------------
    --大小チェック（定期接種）
    -----------------------------------------------
	
	if errorkbn_daisyochk = '1' or errorkbn_daisyochk = '2'
	and hoteikbn_in = '1'
	and sessyukbn_in = '1'
	and jissiymd_date is not null then
		chkmaster_ischk := false;
		--Hib入力時
		if sessyucd_in = '10009' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--入力チェックマスタに従う
				chkmaster_ischk := true;
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--追加以外入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in <> '09';
			--接種開始年齢が1歳以上
			else
				--チェックなし
			end if;

		--小児用肺炎球菌入力時
		elseif sessyucd_in = '10010' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--入力チェックマスタに従う
				chkmaster_ischk := true;
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--追加以外入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in <> '09';
			--接種開始年齢が1歳以上2歳未満
			elseif syokai_sessyu_nenrei >= interval '1 year' and syokai_sessyu_nenrei < interval '2 year' then
				--2回目入力時、入力チェックマスタに従う
				chkmaster_ischk := kaisu_in = '02';
			--接種開始年齢が2歳以上
			else
				--チェックなし
			end if;
			
		--Hib、小児用肺炎球菌以外入力時
		else
			chkmaster_ischk := true;
		end if;
		
		if chkmaster_ischk then
			--入力チェックマスタに従う
			--前回接種とのチェック
			if zenjissiymd_date is not null then
				if jissiymd_date <= zenjissiymd_date then
					insert into tmp values(errorkbn_daisyochk, sessyunm || 'の接種日が' || zensessyunm || 'の接種日以前の日付となっています。（接種日：「' || fn_euchangewareki(zenjissiymd_text) || '」）');
				end if;
			end if;
			
			--次回接種とのチェック
			select * into nyuryokucheck_row from tm_ysnyuryokucheck where zensessyu = sessyucd_in || kaisu_in;
			if nyuryokucheck_row.sessyucd is not null and nyuryokucheck_row.kaisu is not null then
				execute format('select jissiymd from %I where hoteikbn = ''1'' and atenano = ''%s'' and sessyucd = ''%s'' and kaisu = ''%s'' and sessyukbn = ''1'' order by edano desc', tablenm_yssessyu, atenano_in, nyuryokucheck_row.sessyucd, nyuryokucheck_row.kaisu) into daisyochk_jissiymd_text;
				daisyochk_jissiymd_date := to_date(daisyochk_jissiymd_text, 'YYYY-MM-DD');
				if daisyochk_jissiymd_date is not null then
					if jissiymd_date >= daisyochk_jissiymd_date then
						select nm into daisyochk_sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = nyuryokucheck_row.sessyucd || nyuryokucheck_row.kaisu;
						insert into tmp values(errorkbn_daisyochk, sessyunm || 'の接種日が' || daisyochk_sessyunm || 'の接種日以後の日付となっています。（接種日：「' || fn_euchangewareki(daisyochk_jissiymd_text) || '」）');
					end if;
				end if;
			end if;
		end if;
	end if;
	
	-----------------------------------------------
    --大小チェック（任意接種）
    -----------------------------------------------
	
	if errorkbn_daisyochk = '1' or errorkbn_daisyochk = '2'
	and hoteikbn_in = '2'
	and sessyukbn_in = '1'
	and jissiymd_date is not null then
		/*
		--インフルエンザ入力時
		if sessyucd_in = '20001'
		and jissiymd_date is not null
		and bymd_date is not null then
			--接種時年齢が12歳以下
			if jissi_nenrei <= interval '12 year' then
				for sessyu_row in execute format('select * from %I where hoteikbn = ''2'' and atenano = ''%s'' and sessyucd = ''%s'' and sessyukbn = ''1'' order by edano desc', tablenm_yssessyu, atenano_in, sessyucd_in) loop
					daisyochk_jissiymd_date := to_date(sessyu_row.jissiymd, 'YYYY-MM-DD');
					if daisyochk_jissiymd_date is not null
					and daisyochk_jissiymd_date >= jissinendo_st_date
					and daisyochk_jissiymd_date <= jissinendo_ed_date then
						if daisyochk_jissiymd_date > jissiymd_date then
							insert into tmp values(errorkbn_daisyochk, '同年度内の前回の接種日以前の日付となっています。（接種日：「' || daisyochk_jissiymd_date || '」）');
						end if;
						exit;
					end if;
				end loop;
			end if;
		end if;
		*/
	end if;
	
	-----------------------------------------------
    --接種可能回数チェック（定期接種）
    -----------------------------------------------
	
	if errorkbn_kaisuchk = '1' or errorkbn_kaisuchk = '2'
	and hoteikbn_in = '1' then
		kaisuchk_iserror := false;
		tempmsg := '接種開始が';
		--Hib入力時
		if sessyucd_in = '10009' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--チェックなし
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--追加入力時エラー
				kaisuchk_iserror := kaisu_in = '09';
				tempmsg := tempmsg || '7か月以上1歳未満';
			--接種開始年齢が1歳以上
			else
				--1回目以外入力時エラー
				kaisuchk_iserror := kaisu_in <> '01';
				tempmsg := tempmsg || '1歳以上';
			end if;
		end if;
		
		--小児用肺炎球菌入力時
		if sessyucd_in = '10010' and syokai_sessyu_nenrei is not null then
			--接種開始年齢が7か月未満
			if syokai_sessyu_nenrei < interval '7 month' then
				--チェックなし
			--接種開始年齢が7か月以上1歳未満
			elseif syokai_sessyu_nenrei >= interval '7 month' and syokai_sessyu_nenrei < interval '1 year' then
				--追加入力時エラー
				kaisuchk_iserror := kaisu_in = '09';
				tempmsg := tempmsg || '7か月以上1歳未満';
			--接種開始年齢が1歳以上2歳未満
			elseif syokai_sessyu_nenrei >= interval '1 year' and syokai_sessyu_nenrei < interval '2 year' then
				--3回目または追加入力時エラー
				chkmaster_ischk := kaisu_in = '03' or kaisu_in = '09';
				tempmsg := tempmsg || '1歳以上2歳未満';
			--接種開始年齢が2歳以上
			else
				--1回目以外入力時エラー
				kaisuchk_iserror := kaisu_in <> '01';
				tempmsg := tempmsg || '2歳以上';
			end if;
		end if;
		
		--HPV(3回目)入力時
		if sessyucd_in = '10011' and kaisu_in = '03' then
			kaisuchk_iserror := is2kaisessyu;
			tempmsg := tempmsg || '15歳未満かつ、1回目と2回目の接種間隔が5月以上';
		end if;
		
		if kaisuchk_iserror then
			insert into tmp values(errorkbn_kaisuchk, tempmsg || 'ですが' || sessyunm || 'に入力されています。');
		end if;
	end if;
	
	-----------------------------------------------
    --その他チェック（定期接種）
    -----------------------------------------------
	
	if hoteikbn_in = '1' then
		--■風しん抗体検査結果チェック
		--MR5期または風しん5期入力時
		if (sessyucd_in = '10004' or sessyucd_in = '10006') and kaisu_in = '51' then
			execute format('select exists(select * from %I where atenano = ''%s'' and sessyuhanteicd = ''1'')', tablenm_ysfusinkotai, atenano_in) into sonotachk_exist;
			if sonotachk_exist = false then
				insert into tmp values('2', '風しん抗体検査結果が接種対象（陰性）ではありません。');
			end if;
		end if;
		
		--■性別チェック
		--HPV入力時
		if sessyucd_in = '10011' then
			--女性でない場合
			if atena_row.sex <> '2' then
				insert into tmp values('2', sessyunm || 'の接種対象は女性です。');
			end if;
		end if;
	end if;
	
	-----------------------------------------------
    --結果を返す
    -----------------------------------------------
	
	--エラー、アラートが存在しない場合
	if not exists(select * from tmp) then
		actresultkbn := 0;
		
	--エラーが存在する場合、エラーのみ返す
	elseif exists(select * from tmp where errorkbn = '1') then
		actresultkbn := 1;
		messageid := ERRORMESSAGEID;
		messagetext := '';
		for tmp_row in select * from tmp where errorkbn = '1' loop
			if messagetext <> '' and tmp_row is not null then
				messagetext := messagetext || '\n';
			end if;
			messagetext := messagetext || coalesce(tmp_row.messagetext, '');
		end loop;
		
	--エラーが存在しない場合、アラートのみ返す
	else
		actresultkbn := 2;
		messageid := ALERTMESSAGEID;
		messagetext := '';
		for tmp_row in select * from tmp loop
			if messagetext <> '' then
				messagetext := messagetext || '\n';
			end if;
			messagetext := messagetext || tmp_row.messagetext;
		end loop;
	end if;
	
	return query select actresultkbn, messageid, messagetext;
	drop table if exists tmp;
	
EXCEPTION
	when others then
		actresultkbn := 1;
		messageid := ERRORMESSAGEID;
		messagetext := SQLSTATE || SQLERRM;
		return query select actresultkbn, messageid, messagetext;
		drop table if exists tmp;
END;
$function$