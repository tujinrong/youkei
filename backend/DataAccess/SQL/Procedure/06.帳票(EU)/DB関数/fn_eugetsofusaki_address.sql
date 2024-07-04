/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票使用
            宛名番号と送付先利用目的から宛名テーブル又は送付先
            テーブルの住所を取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetsofusaki_address(
      atenano_in character varying              -- 宛名番号
    , riyomokuteki_in character varying         -- 利用目的
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
    jyusyo varchar;         -- 住所
BEGIN
    -- 「送付先住所を設定する」をチェックされない場合
    IF riyomokuteki_in IS NULL THEN
        --「宛名テーブル」から住所を取得する
        select fn_eugetaddress(atenano_in) INTO jyusyo;
     -- 「送付先住所を設定する」をチェックする場合
     ELSE
        --「送付先管理テーブル」から送付先住所を表示
        SELECT CONCAT(
                  adrs_todofuken                -- 住所_都道府県
                , adrs_sikunm                   -- 住所_市区郡町村名
                , adrs_tyoaza                   -- 住所_町字
                , adrs_bantihyoki               -- 住所_番地号表記
                , adrs_katagaki                 -- 住所_方書
               )
          INTO jyusyo
          FROM tt_afsofusaki                    -- 送付先管理テーブル
         WHERE atenano = atenano_in             -- 宛名番号
           AND riyomokuteki = riyomokuteki_in   -- 利用目的
        ;

        -- 送付先が登録されていない(空の場合)
        IF jyusyo IS NULL THEN
            --「宛名テーブル」から住所を取得する
            select fn_eugetaddress(atenano_in) INTO jyusyo;
        END IF;

    END IF;

    RETURN jyusyo;
END;

$function$