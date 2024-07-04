/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票使用
            帳票IDの属する帳票グループから指定の区分の事業コードを
            EUC帳票マスタより取得する
作成日　　: 2024.04.10
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetrptgroupjigyocd(
rptid_in character varying, --帳票ID
kubun_in integer            --区分 
)
 RETURNS VARCHAR ARRAY
 LANGUAGE plpgsql
AS $function$
DECLARE
    jigyocd         VARCHAR;          -- 事業コード
    jigyocd_array   VARCHAR ARRAY;    -- 事業コード
BEGIN 
    -- 事業コードの取得
    SELECT 
        CASE kubun_in
            WHEN 1 THEN tm_eurptgroup.kojinrenrakusakicd       -- 個人連絡先
            WHEN 2 THEN tm_eurptgroup.memocd                   -- メモ情報（複数）
            WHEN 3 THEN tm_eurptgroup.electronfilecd           -- 電子ファイル（複数）
            WHEN 4 THEN tm_eurptgroup.followmanage             -- フォロー管理（複数）
            ELSE tm_eurptgroup.kojinrenrakusakicd              -- 個人連絡先
        END 
    INTO jigyocd                                               -- 事業コード
    FROM tm_eurpt                                              -- EUC帳票マスタ
    LEFT JOIN tm_eurptgroup                                    -- 帳票グループマスタ
           ON tm_eurpt.rptgroupid = tm_eurptgroup.rptgroupid   -- 帳票グループID
    WHERE tm_eurpt.rptid = rptid_in                            -- 帳票ID
    ;

    -- 事業コードを配列型へ変換
    jigyocd_array := string_to_array(jigyocd, ',');

    RETURN jigyocd_array;

END;

$function$