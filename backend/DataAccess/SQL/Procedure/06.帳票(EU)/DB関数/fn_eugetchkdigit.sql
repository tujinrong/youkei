/*******************************************************************
業務名称　: 健康管理システム
機能概要　: バーコードについて関数
			チェックデジットを計算
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetchkdigit(pdata_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
	i integer;
	i2 integer;
	iMax integer;
	iSum integer;
	iSumWK integer;
	s varchar;
	chkDgt varchar;
	chars varchar[][];	-- バーコード用キャラク
BEGIN
	chars := array[['-', '10'], ['CC1', '11'], ['CC2', '12'], ['CC3', '13'],
				 ['CC4', '14'], ['CC5', '15'], ['CC6', '16'], ['CC7', '17'], ['CC8', '18']];

	-- 変数の初期化
	iSum := 0;
	iSumWK := 0;
	i := 1;
	iMax := length(pdata_in);
	chkDgt := '0';

	WHILE i <= iMax LOOP
		-- 1桁ずつ切り出してそれが数値ならiSumに加算
		s := substr(pdata_in, i, 1);
		IF ascii(s) between 48 and 57 THEN
			iSum := iSum + CAST(s as integer);
			i := i + 1;

		-- 数値でない場合
		ELSE
			-- sCharのバーコード用キャラクタ
			FOR i2 IN 1..array_length(chars, 1) LOOP
				IF strpos(substr(pdata_in, i, 3), chars[i2][1]) <> 0 THEN
					-- バーコード用キャラクタに対応する、チェック用数字を取得
					iSumWK := CAST(chars[i2][2] as integer);
					EXIT;
				END IF;
			END LOOP;

			iSum := iSum + iSumWK;
			iSumWK := 0;

			IF s = chars[1][1] THEN
				i := i + 1;
			ELSE
				-- 次のチェック開始位置を変更
				i := i + 3;
			END IF;
		END IF;
	END LOOP;

	-- 合計数(iSum)に何か足して19の倍数になるようにする。
	-- このときの何か足した数がチェックデジットとなる。
	-- つまり、合計数＋何か足した数＝19の倍数
	-- になればいい。
	-- 例.合計数が105とした場合
	--    105+C/D=19の倍数
	--    C/Dは9となる。
	chkDgt := CAST(mod(iSum, 19) as varchar);
	IF chkDgt = '0' THEN
		-- 何もしない
	ELSE
		chkDgt := CAST(19 - CAST(chkDgt as integer) as varchar);
	END IF;

	-- チェックデジットが2桁の場合
	IF length(chkDgt) = 2 THEN
		-- バーコード用キャラクタに変換する。
		FOR i IN 1..array_length(chars, 1) LOOP
			IF strpos(chkDgt, chars[i][2]) <> 0 THEN
				chkDgt := chars[i][1];
				EXIT;
			END IF;
		END LOOP;
	END IF;

	RETURN chkDgt;
END; 

$function$