/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 共通関数
　　　　　　年齢チェック
作成日　　: 2024.02.12
作成者　　: 劉
変更履歴　:
*******************************************************************/
create or replace function fn_shgetageflg(bymd_in character varying, bymd_fusyoflg_in boolean, kijunymd_in character varying, age_in character varying)
 returns boolean
 language plpgsql
as $function$
declare age integer;
begin
    if bymd_fusyoflg_in then
        return false;
    else
        --年齢取得
        age = fn_afgetage(bymd_in, kijunymd_in);
        return fn_afgetagerangeflg(age, age_in);
    end if;
end;
$function$