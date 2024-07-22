/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: お知らせ
　　　　　　一覧抽出
作成日　　: 2024.07.26
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00302d_01_head(userid_in character varying, showkbn_in integer, readkbn_in integer)
 returns integer
 language plpgsql
as $function$
	declare total integer;
	today character varying;
begin
	today = to_char(current_date,'yyyy-MM-dd');
	select
		count(t1.infoseq) total into total
    from
        tt_afinfo t1							--お知らせ情報管理マスタ
    left join tt_afinfo_user t2					--お知らせ確認状態情報管理マスタ
		on t1.infoseq = t2.infoseq 
		and t2.userid = userid_in
    left join tm_afuser m1						--ユーザーマスタ
		on t1.reguserid = m1.userid
    where 
		((readkbn_in = 1 and t2.userid is null and t1.reguserid != userid_in)	--未読
			or readkbn_in != 1)													--すべて
		and
			((t1.kigenymd >= today and showkbn_in = 1)							--期限内
			 or showkbn_in != 1)												--すべて
		and  
			(t1.atesakiflg = false or 
			(userid_in = any(string_to_array(t1.atesaki, ','))) or 
			t1.reguserid = userid_in);
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00302d_01_body(userid_in character varying, showkbn_in integer, readkbn_in integer, limit_in integer, offset_in integer)
 returns table
 (infoseq bigint, 
  juyodo character varying,
  kigenymd character varying,
  syosai character varying,
  atesakiflg boolean,
  atesaki character varying,
  reguserid character varying,
  regusernm character varying,
  regdttm timestamp without time zone,
  upddttm timestamp without time zone,
  readflg boolean)
 language plpgsql
as $function$
	declare today character varying;
begin
	today = to_char(current_date,'yyyy-MM-dd');
	return query
	select
		 t1.infoseq								--シーケンス番号
		,t1.juyodo								--重要度
		,t1.kigenymd							--提示期限
		,t1.syosai								--詳細
		,t1.atesakiflg							--宛先指定フラグ
		,t1.atesaki								--宛先
		,t1.reguserid as reguserid				--登録操作者ID
		,m1.usernm as regusernm					--登録操作者名
		,t1.regdttm as regdttm					--登録日時
		,t1.upddttm as upddttm					--更新日時
		,case when t2.userid is not null then 
			true else false end	as readflg		--既読フラグ
    from
        tt_afinfo t1							--お知らせ情報管理マスタ
    left join tt_afinfo_user t2					--お知らせ確認状態情報管理マスタ
		on t1.infoseq = t2.infoseq 
		and t2.userid = userid_in
    left join tm_afuser m1						--ユーザーマスタ
		on t1.reguserid = m1.userid
    where 
		((readkbn_in = 1 and t2.userid is null and t1.reguserid != userid_in)	--未読
			or readkbn_in != 1)													--すべて
		and
			((t1.kigenymd >= today and showkbn_in = 1)							--期限内
			 or showkbn_in != 1)												--すべて
		and  
			(t1.atesakiflg = false or 
			(userid_in = any(string_to_array(t1.atesaki, ','))) or 
			t1.reguserid = userid_in)
    order by
        t1.regdttm desc,									--登録日時        降順
		t1.infoseq desc										--シーケンス番号  降順
    limit limit_in offset offset_in;
end;
$function$