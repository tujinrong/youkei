/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 自己負担金保守
　　　　　　一覧抽出
作成日　　: 2024.03.05
作成者　　: CNC
変更履歴　:
*******************************************************************/
create or replace function sp_awsh00601g_01(nendo_in smallint, kensin_jigyocd_in character varying, ryokinpattern_in character varying)
 returns table(
              kensahohocd character varying,
              genmenkbn character varying, 
              sex character varying, 
              agehani character varying, 
              jusinkingaku integer, 
              kingaku_sityosonhutan integer,
              kensin_jigyocd character varying,
              ryokinpattern character varying,
              upddttm timestamp without time zone)
 language plpgsql
as $function$
begin
	return query
	select 
         t1.kensahohocd               as kensahohocd                               --検査方法
        ,t1.genmenkbn                 as genmenkbn                                 --減免区分
        ,t1.sex                       as sex                                       --性別
        ,t1.agehani                   as agehani                                   --年齢
        ,t1.jusinkingaku              as jusinkingaku                              --受診金額
        ,t1.kingaku_sityosonhutan     as kingaku_sityosonhutan                     --金額（市区町村負担）
        ,t1.kensin_jigyocd            as kensin_jigyocd                            --成人健（検）診事業コード
        ,t1.ryokinpattern             as ryokinpattern                             --料金パターン
        ,t1.upddttm                   as upddttm                                   --更新日時
     from
        tm_shjikofutankin t1
     where 
         (nendo_in is null or t1.nendo = nendo_in)                                 --年度
         and (kensin_jigyocd_in is null or t1.kensin_jigyocd = kensin_jigyocd_in)  --成人健(検)診事業名
         and (ryokinpattern_in is null or t1.ryokinpattern = ryokinpattern_in)     --料金パターン
     order by
           t1.kensahohocd                                                          --検査方法
          ,t1.genmenkbn                                                            --減免区分
          ,t1.sex                                                                  --性別
          ,t1.agehani;                                                             --年齢
end;
$function$