/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 共通関数
　　　　　　年齢取得
作成日　　: 2024.02.12
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function fn_afgetage(bymd_in character varying, kijunymd_in character varying)
 returns integer
 language plpgsql
as $function$
declare 
    age integer;
    kijunymd date;
    bymd date;
begin
    if kijunymd_in is null then
        kijunymd = current_date;
    else
        kijunymd = cast(kijunymd_in as date);
    end if;
    bymd = cast(bymd_in as date);
    --年の差
    age := extract(year from kijunymd) - extract(year from bymd);
    
    --基準日前：-1
    if extract(month from kijunymd) < extract(month from bymd) or
       (extract(month from kijunymd) = extract(month from bymd) and
        extract(day from kijunymd) < extract(day from bymd)) then
        age := age - 1;
    end if;
    
    return age;

end;
$function$