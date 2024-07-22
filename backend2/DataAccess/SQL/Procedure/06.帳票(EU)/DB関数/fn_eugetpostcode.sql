/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: バーコードについて関数
			郵便番号と住所情報から、特定の形式でデータを取得
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/    


CREATE OR REPLACE FUNCTION fn_eugetpostcode(yubin_in character varying, jusyo_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
	i integer;
	s varchar;
	ac integer;
	pdata varchar := '';
BEGIN
	yubin_in := coalesce(yubin_in, '');
	jusyo_in := coalesce(jusyo_in, '');
	-- 郵便番号、住所がNULLなら終了
	IF yubin_in || jusyo_in = '' THEN
		RETURN pdata;
	END IF;

	-- 郵便番号のハイフンを取る
	yubin_in := replace(yubin_in, '-', '');

	-- アルファベットの小文字を大文字に置換
	jusyo_in := upper(jusyo_in);

	-- 全角文字を半角文字に置換
	FOR i IN 1..length(jusyo_in) LOOP
		s := substr(jusyo_in, i, 1);
        ac := ascii(s);
        IF (ac >= 65296 AND ac <= 65305) OR
            (ac >= 65313 AND ac <= 65338) OR
            (ac >= 65345 AND ac <= 65370) THEN
            -- 英数字
            pdata := pdata || chr(ac - 65248);
        ELSE
            pdata := pdata || translate(s, '＆－．・／', '&-.･/');
        END IF;
    END LOOP;

    -- 住所、方書から対象の4つの文字列を取り除く
    pdata := replace(replace(replace(replace(pdata, '&', ''), '/', ''), '･', ''), '.', '');

    -- 住所、方書から特定文字(「丁目」など）の前にある漢数字を算用数字に置換
    pdata := fn_eugetkansuji(pdata);

    -- 正規表現を使って、算用数字、ハイフン、1文字のアルファベット(連続していないアルファベット)を抜き出す
    pdata := yubin_in || fn_eugetpdata(pdata);

    -- チェックデジットを付加する。
    --pdata := pdata || fn_euGetChkDigit(pdata);

    -- STC(スタートコード)、SPC(ストップコード)を付加する。
    --pdata := 'STC' || pdata || 'SPC';

    RETURN pdata;
END;

$function$