/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: バーコードについて関数
			文字列内の漢数字を算用数字に変換
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eucngsanyosuji(pdata_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
	kansujiStart integer;	-- 漢数字の開始位置
	kansujiEnd integer;		-- 漢数字の終了位置
	cngChar varchar;		-- 置換対象の漢数字
	flg integer;			-- 0:漢数字がない  1:漢数字がある
	i integer;
	i2 integer;
	i3 integer;
	specificChar varchar[];	-- 特定文字
	kansuji varchar[][];	-- 漢数字
BEGIN
	specificChar := array['丁目', '丁', '番地', '番', '号', '地割', '線', 'の', 'ノ'];
	kansuji := array[['〇', '0'], ['一', '1'], ['二', '2'], ['三', '3'], ['四', '4'],
					['五', '5'], ['六', '6'], ['七', '7'], ['八', '8'], ['九', '9'],
					['十', '10'], ['百', '100'], ['千', '1000']];

	-- 9種類の特定文字が存在するかチェック
<<Line_NextSpecificChar>>
	FOR i IN 1..array_length(specificChar, 1) LOOP
		kansujiStart := 0;
		kansujiEnd := 0;

		-- 特定文字がある位置を保持
		kansujiEnd := strpos(pdata_in, specificChar[i]);

		-- 特定文字がなかったら、次の特定文字を検索
		CONTINUE WHEN kansujiEnd = 0;

		-- 特定文字の1つ前の文字を保持(漢数字のエンド位置)
		kansujiEnd := kansujiEnd - 1;

		-- 特定文字の1つ前から、1文字ずつ遡る
		FOR i2 IN REVERSE kansujiEnd..1 LOOP
			-- フラグの初期化
			flg := 0;

			-- 1つ遡った文字に13種類の漢数字が存在するかチェック
			FOR i3 IN 1..array_length(kansuji, 1) LOOP
				-- 1つ遡った文字に漢数字が存在するか
				IF strpos(substr(pdata_in, i2, 1), kansuji[i3][1]) <> 0 THEN
					-- 存在したら、その文字があった位置を保持(漢数字のスタート位置)
					kansujiStart := i2;
					-- フラグを立てる
					flg := 1;
					-- 存在したらループを抜ける
                    EXIT;
				END IF;
			END LOOP;

			-- 1つ遡った文字に13種類の漢数字がない
			IF flg = 0 THEN
				-- 遡る前の文字に13種類の漢字がない
				IF kansujiStart = 0 THEN
					-- 次の特定文字の存在チェックへ
					CONTINUE Line_NextSpecificChar;
				ELSE
					-- ループを抜けて、漢数字を算用数字に変換
					EXIT;
				END IF;
			END IF;
		END LOOP;

		IF kansujiStart > 0 THEN
			-- 特定文字の前にある置換対象の漢数字を抜き出す
			cngChar := substr(pdata_in, kansujiStart, kansujiEnd - kansujiStart + 1);
			-- 漢数字をGetSanyoSuujiに渡して、算用数字を取得する。
			-- そして漢数字を算用数字に置換する。
			pdata_in := substr(pdata_in, 1, kansujiStart - 1) || fn_euGetSanyoSuuji(pdata_in, kansujiStart, kansujiEnd, kansuji) || substr(pdata_in, kansujiEnd + 1);
		END IF;

	END LOOP;

	RETURN pdata_in;
END; 

$function$