/*******************************************************************
業務名称　: 健康管理システム
機能概要　: メモ情報（世帯）
　　　　　　一覧抽出
作成日　　: 2023.07.13
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00604d_01_head(setaino_in character varying, jigyokbns_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
	jigyokbns text[];
begin
	jigyokbns = string_to_array(jigyokbns_in, ',');
	select
		count(1) total into total
    from
		tt_afmemosetai t1					--メモ情報（世帯）テーブル
    where 
		t1.setaino = setaino_in				--世帯番号
		and t1.jigyokbn = any(jigyokbns);	--登録事業(表示範囲)
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00604d_01_body(setaino_in character varying, jigyokbns_in character varying, limit_in integer, offset_in integer)
 returns table
 (memoseq integer, 
  jigyokbn character varying, 
  juyodo character varying, 
  title character varying, 
  memo character varying,
  kigenymd character varying,
  regsisyo character varying,
  regusernm character varying, 
  regdttm timestamp without time zone, 
  updusernm character varying, 
  upddttm timestamp without time zone)
 language plpgsql
as $function$
declare jigyokbns text[];
begin
	jigyokbns = string_to_array(jigyokbns_in, ',');
	return query
	select
		 t1.memoseq          --メモシーケンス
		,t1.jigyokbn         --登録事業（共通・各事業）
		,t1.juyodo           --重要度
		,t1.title            --件名（タイトル）
		,t1.memo             --メモ（フリーテキスト）
		,t1.kigenymd         --期限日
		,t1.regsisyo         --登録支所
		,t2.usernm regusernm --登録ユーザー名
		,t1.regdttm          --登録日時
		,t3.usernm updusernm --更新ユーザー名
		,t1.upddttm          --更新日時
    from
		tt_afmemosetai t1    --メモ情報（世帯）テーブル
	left join tm_afuser t2   --ユーザーマスタ
		on t1.reguserid = t2.userid
	left join tm_afuser t3   --ユーザーマスタ
		on t1.upduserid = t3.userid
    where 
		t1.setaino = setaino_in				--世帯番号
		and t1.jigyokbn = any(jigyokbns)	--登録事業(表示範囲)
    order by
		t1.memoseq desc						--メモシーケンス  降順
    limit limit_in offset offset_in;
end;
$function$