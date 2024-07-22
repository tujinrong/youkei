/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 共通関数
　　　　　　年齢範囲チェック
作成日　　: 2024.02.12
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function fn_afgetagerangeflg(age integer, age_range character varying)
 returns boolean
 language plpgsql
as $function$
declare
    age_range_arr text[];
    age_range_min integer;
    age_range_max integer;
begin
    age_range_arr := string_to_array(age_range, ',');
    
    for i in 1..array_length(age_range_arr, 1) loop
        age_range := age_range_arr[i];
        --範囲の場合、最小値と最大値を取得
        if position('-' in age_range) > 0 then
            age_range_min := split_part(age_range, '-', 1)::integer;
            age_range_max := split_part(age_range, '-', 2)::integer;
            --範囲判断
            if age >= age_range_min and age <= age_range_max then
                return true;
            end if;
        --値の場合
        else
            if age = age_range::integer then
                return true;
            end if;
        end if;
    end loop;
    
    --設定年齢以外の場合
    return false;
end;
$function$