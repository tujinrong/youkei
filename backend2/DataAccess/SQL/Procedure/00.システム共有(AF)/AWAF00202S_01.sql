/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 使用履歴
　　　　　　一覧抽出
作成日　　: 2024.07.15
作成者　　: 蔣
変更履歴　:
*******************************************************************/
create or replace function sp_awaf00202s_01(userid_in character varying)
 returns table
 (kinoid character varying,
  hyojinm character varying)
 language plpgsql
as $function$
begin
    return query
		select
			t1.kinoid,						--機能ID
			t2.hyojinm                      --表示名称
		from
			tt_afsiyorireki t1              --使用履歴テーブル
		join tm_afkino t2                   --機能マスタ
		  on t1.kinoid = t2.kinoid
		where
			t1.userid = userid_in
		order by
			t1.syoridttm desc               --処理日時   降順
		limit 10;
end;
$function$