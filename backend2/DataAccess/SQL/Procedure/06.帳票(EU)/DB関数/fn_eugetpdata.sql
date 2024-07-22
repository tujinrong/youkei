/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: バーコードについて関数
			文字列を特定の形式に変換
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/    

CREATE OR REPLACE FUNCTION fn_eugetpdata(pdata_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
	i integer;
    i2 integer;
    s varchar;
    ctrlCD varchar;
    alphabets varchar[][];
BEGIN
    alphabets := array[['A', 'CC10'], ['B', 'CC11'], ['C', 'CC12'], ['D', 'CC13'], ['E', 'CC14'],
                    ['F', 'CC15'], ['G', 'CC16'], ['H', 'CC17'], ['I', 'CC18'], ['J', 'CC19'],
                    ['K', 'CC20'], ['L', 'CC21'], ['M', 'CC22'], ['N', 'CC23'], ['O', 'CC24'],
                    ['P', 'CC25'], ['Q', 'CC26'], ['R', 'CC27'], ['S', 'CC28'], ['T', 'CC29'],
                    ['U', 'CC30'], ['V', 'CC31'], ['W', 'CC32'], ['X', 'CC33'], ['Y', 'CC34'],
                    ['Z', 'CC35']];

    -- 正規表現でを使って文字列を置換
    -- 正規表現にマッチするすべての部分を対象とする。
    -- A～Zの範囲にある文字が2回以上100回以下繰り返すものを消す
    pdata_in := regexp_replace(pdata_in, '[A-Z]{2,100}', '', 'g');

    -- 0～9、A～Z、-(ハイフン)以外を、-(ハイフン)に置換
    pdata_in := regexp_replace(pdata_in, '[^0-9A-Z-]', '-', 'g');

    -- 算用数字＋アルファベット1文字"F"の場合、"F"は-(ハイフン)に置換する。
    i := 1;
    LOOP
        i := regexp_instr(pdata_in, '([0-9])F', i);
        EXIT WHEN i = 0;
        pdata_in := substr(pdata_in, 1, i) || '-' || substr(pdata_in, i + 2);
        i := i + 2;
    END LOOP;

    -- -(ハイフン)が2回以上繰り返していれば、-(ハイフン)1つに置換する。
    pdata_in := regexp_replace(pdata_in, '-{2,}', '-', 'g');

    -- アルファベットの前後の-(ハイフン)は消す
    -- "$1"は、Patternで定義した文字列の"()"の中の正規表現を表します。
    pdata_in := regexp_replace(pdata_in, '-([A-Z])', '\1', 'g');
    pdata_in := regexp_replace(pdata_in, '([A-Z])-', '\1', 'g');

    -- 文字列の最初と最後の-(ハイフン)は消す。
    -- ^-：先頭にあるハイフン
    -- | ：または
    -- -$：末尾にあるハイフン
    pdata_in := regexp_replace(pdata_in, '^-|-$', '', 'g');

    -- 桁数編集を行う。ただし、アルファベットの有無で処理が異なる。
    -- アルファベットがあるかチェック
    i := 1;
    LOOP
        i := regexp_instr(pdata_in, '[A-Z]', i);
        EXIT WHEN i = 0;
        -- あった場合
        s := substr(pdata_in, i, 1);
        -- A～Zの26文字を検索して、対応するCC10～CC35に変換する。
        FOR i2 IN 1..array_length(alphabets, 1) LOOP
            IF s = alphabets[i2][1] THEN
                pdata_in := substr(pdata_in, 1, i - 1) || alphabets[i2][2] || substr(pdata_in, i + 1);
                i := i - 1 + length(alphabets[i2][2]);
                EXIT;
            END IF;
        END LOOP;
        i := i + 1;
    END LOOP;

    -- A～Zの変換した文字列(つまりCCx　xは数字1桁)を1文字とみなして
    -- 処理をしやすくするために、#、$、%に置換
    -- CC1、CC2、CC3を、#、$、%に置換
    pdata_in := replace(replace(replace(pdata_in, 'CC1', '#'), 'CC2', '$'), 'CC3', '%');

    -- 13桁にする
    pdata_in := substr(pdata_in, 1, 13);

    -- 13桁に満たない場合は、CC4(これが1文字という扱いになる)で補充する。
    --IF length(pdata_in) < 13 THEN
        -- 制御コードを初期化
       -- ctrlCD := '';

        -- 不足桁分のCC4を作成
        --FOR i IN 1..(13 - length(pdata_in)) LOOP
        --    ctrlCD := ctrlCD || 'CC4';
       -- END LOOP;

        -- 作成した制御コードと連結
        --pdata_in := pdata_in || ctrlCD;
    --END IF;

    -- #、$、%を、CC1、CC2、CC3に置換(もとに戻す)
    --pdata_in := replace(replace(replace(pdata_in, '#', 'CC1'), '$', 'CC2'), '%', 'CC3');

    RETURN pdata_in;
END;

$function$