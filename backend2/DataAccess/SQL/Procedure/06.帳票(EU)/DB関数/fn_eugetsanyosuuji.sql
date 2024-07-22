/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: バーコードについて関数
			漢数字が含まれる文字列を受け取り、それらを算用数字に変換
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetsanyosuuji(pdata_in character varying, kansujistart_in integer, kansujiend_in integer, kansuji_in character varying[])
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
	tmp1000 integer;
	tmp100 integer;
	tmp10 integer;
	tmp integer;
	s varchar;	-- 現在の文字
	sBk varchar;	-- 前回(ループ前)の文字
	i integer;
	i2 integer;
	i3 integer;
	flg integer;
BEGIN
    -- 変数の初期化
	sBk := '';
	tmp1000 := 0;
	tmp100 := 0;
	tmp10 := 0;
	tmp := 0;
	flg := 1;

	-- 漢数字の開始位置～終了位置まで1文字ずつ切り出してループ
	FOR i IN kansujistart_in..kansujiend_in LOOP
		s := substr(pdata_in, i, 1);

		-- 切り出した文字に13種類の漢数字があるかチェック
		FOR i2 IN 1..array_length(kansuji_in, 1) LOOP
			IF s = kansuji_in[i2][1] THEN
				-- 切り出した文字
				CASE s
					-- 「千」の場合
					WHEN kansuji_in[13][1] THEN
						-- tmp=0 なら「千」から始まっているので、tmpを1とする。
						-- tmp<>0なら1文字前に数字があったので、その数字を使用する。
						-- tmp×1000を行う。
						-- 「百」「十」の場合も同様
						tmp1000 := (CASE tmp = 0 WHEN true THEN 1 else tmp END) * CAST(kansuji_in[13][2] AS integer);
						tmp := 0;
						EXIT;
					-- 「百」の場合
					WHEN kansuji_in[12][1] THEN
						tmp100 := (CASE tmp = 0 WHEN true THEN 1 else tmp END) * CAST(kansuji_in[12][2] AS integer);
						tmp := 0;
						EXIT;
					-- 「十」の場合
					WHEN kansuji_in[11][1] THEN
						tmp10 := (CASE tmp = 0 WHEN true THEN 1 else tmp END) * CAST(kansuji_in[11][2] AS integer);
						tmp := 0;
						EXIT;
					-- 「〇」～「九」までの場合
					WHEN kansuji_in[i2][1] THEN
						-- 前回の文字が空白＝１回目のループの場合
						IF sBk = '' THEN
							flg := 1;
						ELSE
							FOR i3 IN 1..10 LOOP
								-- 前回の文字が「〇」～「九」に該当する場合
								IF sBk = kansuji_in[i3][1] THEN
									flg := 2;
									EXIT;
								END IF;
							END LOOP;
						END IF;

						CASE flg
							WHEN 1 THEN     -- 前回の文字がない or 前回の文字が「千」「百」「十」なら数値として加算
								tmp := tmp + CAST(kansuji_in[i2][2] AS integer);
							WHEN 2 THEN     -- 前回の文字が「〇」～「九」の場合（二三のように数字の羅列の場合）は、文字列として連結
								tmp := CAST(CAST(tmp as varchar) || kansuji_in[i2][2] as integer);
						END CASE;
						EXIT;
				END CASE;
			END IF;
		END LOOP;

		-- 現在の文字をバックアップ
		sBk := s;
	END LOOP;

	RETURN CAST(tmp1000 + tmp100 + tmp10 + tmp as varchar);
END; 

$function$