/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 拡事業・拡運用情報保守
　　　　　　その他日程事業・保健指導事業一覧取得
作成日　　: 2024.03.11
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_08()
returns table
  (jigyocdkk character varying,
   jigyonm character varying,
   gyomukbn character varying,
   yoyakuriyoflg boolean,
   homonriyoflg boolean,
   sodanriyoflg boolean,
   syudanriyoflg boolean,
   stopflg boolean,
   upddttm timestamp without time zone,
   editflg boolean)
  language plpgsql
as $function$  
begin
    return query 
    select 
        m1.jigyocd as jigyocdkk,        --その他日程事業・保健指導事業コード
        m1.jigyonm,                     --その他日程事業・保健指導事業名
        m1.gyomukbn,                    --業務区分
        m1.yoyakuriyoflg,               --予約利用フラグ
        m1.homonriyoflg,                --訪問利用フラグ
        m1.sodanriyoflg,                --相談利用フラグ
        m1.syudanriyoflg,               --集団利用フラグ
        m1.stopflg,                     --使用停止フラグ
        m1.upddttm,                     --更新日時
        ((t1.jigyocd is not null) or 
            (t2.jigyocd is not null) or 
            (t3.jigyocd is not null) or 
            (t4.jigyocd is not null) or 
            (t5.jigyocd is not null)
        ) = false as editflg                --編集フラグ
    from tm_kksonotasidojigyo m1            --その他日程事業・保健指導事業マスタ
    left join 
        (select distinct(jigyocd)
        from tt_kkjigyoyotei) t1            --事業予定テーブル
    on m1.jigyocd = t1.jigyocd 
    left join 
        (select distinct(jigyocd)
        from tt_kkhokensido_mosikomi) t2    --保健指導申込情報（固定項目）テーブル
    on m1.jigyocd = t2.jigyocd
    left join 
        (select distinct(jigyocd)
        from tt_kkhokensido_kekka) t3       --保健指導結果情報（固定項目）テーブル
    on m1.jigyocd = t3.jigyocd 
    left join 
        (select distinct(jigyocd)
        from tt_kksyudansido_mosikomi) t4   --集団指導申込情報（固定項目）テーブル
    on m1.jigyocd = t4.jigyocd
    left join 
        (select distinct(jigyocd)
        from tt_kksyudansido_kekka) t5      --集団指導結果情報（固定項目）テーブル
    on m1.jigyocd = t5.jigyocd; 
end;
$function$