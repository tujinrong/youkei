/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: ホーム
　　　　　　お知らせ一覧抽出
作成日　　: 2024.07.20
作成者　　: 蔣
変更履歴　:
*******************************************************************/
create or replace function sp_awaf00301g_01(userid_in character varying, readkbn_in integer)
 returns table
 (infoseq bigint,
  juyodo character varying,
  regdttm timestamp without time zone,
  syosai character varying, 
  userid character varying,
  readflg boolean)
 language plpgsql
as $function$
	declare today character varying;
begin
	today = to_char(current_date,'yyyy-MM-dd');
    return query
		select
			t1.infoseq,												--お知らせシーケンス
			t1.juyodo,												--重要度
			t1.regdttm,												--登録日時
			t1.syosai,												--詳細
			t2.userid,												--ユーザーID
			case when t2.userid is not null then 
				true else false end	as readflg						--既読フラグ
		from
			tt_afinfo t1											--お知らせテーブル
		left join tt_afinfo_user t2									--お知らせ確認状態テーブル
			on t1.infoseq = t2.infoseq and t2.userid = userid_in	
		where
			t1.kigenymd >= today									--掲示期限内
			and (((readkbn_in = 1 and t2.userid is null)			--未読
				or readkbn_in != 1) and t1.reguserid != userid_in)	--すべて
			and (t1.atesakiflg = false or 
				(userid_in = any(string_to_array(t1.atesaki, ','))))
		order by
			t1.regdttm desc,									--登録日時        降順
			t1.infoseq desc;									--シーケンス番号  降順
end;
$function$