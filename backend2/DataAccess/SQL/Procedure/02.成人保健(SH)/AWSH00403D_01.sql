/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 料金内訳
　　　　　　検索処理
作成日　　: 2024.02.26
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awsh00403d_01(nendo_in integer, atenano_in character varying)
returns table
  (jigyocd character varying,
   kensahohocd character varying,
   kijunymd character varying,
   genmenkbn character varying,
   ryokinpattern character varying)
  language plpgsql
as $function$  
begin
    return query 
    select 
        t1.jigyocd,
        t1.kensahohocd,
        case when (kijunkbn = '0') then     --受診日時点の場合、日程予定日にする
            t2.yoteiymd
        else 
            cast(m1.kijunymd as varchar)
        end as kijunymd, 
        cast(m2.genmenkbn as varchar),
        m3.ryokinpattern
    from tt_shkensinkibosyasyosai t1        --健（検）診予約希望者詳細テーブル
    left join tm_shnendo m1                 --年度マスタ
    on 
        t1.nendo = m1.nendo and 
        t1.jigyocd = m1.jigyocd and
        t1.kensahohocd = m1.kensahohocd
    left join tt_shkensinyotei t2           --健（検）診予定テーブル
    on 
        t1.nendo = t2.nendo and
        t1.nitteino = t2.nitteino
    left join tm_shkensinjigyo m2           --成人健（検）診事業マスタ
    on 
        t1.jigyocd = m2.jigyocd
    left join tm_shyoyakujigyo m3         --成人健（検）診予約日程事業マスタ
    on 
        t2.jigyocd = m3.jigyocd and 
        t2.nendo = m3.nendo
    where 
        t1.nendo = nendo_in and 
        t1.atenano = atenano_in
        and t1.cancelmatiflg = '1'               --予約済
    order by t1.jigyocd;
end;
$function$