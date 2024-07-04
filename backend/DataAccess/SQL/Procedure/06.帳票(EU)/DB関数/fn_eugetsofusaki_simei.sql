/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票使用
            宛名番号と送付先利用目的から宛名テーブル又は送付先
            テーブルの氏名を取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetsofusaki_simei(
      atenano_in character varying              -- 宛名番号
    , riyomokuteki_in character varying         -- 利用目的
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
    sofuna varchar;
BEGIN
    -- 「送付先住所を設定する」をチェックされない場合
    IF riyomokuteki_in IS NULL THEN
        -- 「宛名テーブル」から送付先氏名を取得する
        SELECT simei_yusen                      -- 氏名_優先
          INTO sofuna 
          FROM tt_afatena                       -- 宛名テーブル
         WHERE atenano = atenano_in             -- 宛名番号
        ;
    -- 「送付先住所を設定する」をチェックする場合
    ELSE
        -- 「送付先管理テーブル」から送付先氏名を取得する
        SELECT sofusaki_simei                   -- 送付先氏名
          INTO sofuna 
          FROM tt_afsofusaki                    -- 送付先管理テーブル
         WHERE atenano = atenano_in             -- 宛名番号
           AND riyomokuteki = riyomokuteki_in   -- 利用目的
        ;
        -- 送付先が登録されていない(空の場合)
        IF sofuna IS NULL THEN
            --「宛名テーブル」から氏名_優先を取得する
            SELECT simei_yusen                      -- 氏名_優先
              INTO sofuna 
              FROM tt_afatena                       -- 宛名テーブル
             WHERE atenano = atenano_in             -- 宛名番号
            ;
        END IF;
        
    END IF;

    RETURN sofuna;
END;

$function$