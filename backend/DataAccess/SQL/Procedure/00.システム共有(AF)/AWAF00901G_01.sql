/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ユーザー管理
　　　　　　ユーザー検索
作成日　　: 2023.07.04
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00901g_01_head(userid_in character varying, syozokucd_in character varying)
	returns integer
	language plpgsql
as $function$
declare total integer;
begin
	select
		count(1) total into total
	from
		tm_afuser t1  --ユーザーマスタ
	where
		(userid_in is null or t1.userid = userid_in)
	  	and
		(syozokucd_in is null or t1.syozokucd = syozokucd_in);
	return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00901g_01_body(userid_in character varying, syozokucd_in character varying, orderby_in integer, limit_in integer, offset_in integer)
	returns table
	    (userid character varying, 
	     usernm character varying, 
	     syozokucd character varying, 
	     syozokunm character varying, 
	     yukoymdf character varying, 
	     yukoymdt character varying, 
	     stopflg boolean, 
	     errorkaisu smallint, 
	     pwordhenkoymd character varying)
	language plpgsql
as $function$
begin
	return query
		select
			t1.userid,			--ユーザーid
			t1.usernm,			--ユーザー名
			t1.syozokucd,		--所属グループコード
			t2.syozokunm,		--所属グループ名
			t1.yukoymdf,		--有効年月日（開始）
			t1.yukoymdt,		--有効年月日（終了）
			t1.stopflg,			--使用停止フラグ
			t1.errorkaisu,		--ログインエラー回数
			t1.pwordhenkoymd	--パスワード変更年月日
		from
			tm_afuser t1          --ユーザーマスタ
		left join tm_afsyozoku t2 --所属グループマスタ
			on t1.syozokucd = t2.syozokucd
		where
			(userid_in is null or t1.userid = userid_in)
		  	and
			(syozokucd_in is null or t1.syozokucd = syozokucd_in)
		order by
			case when orderby_in = 0 then t1.userid end,	      --ユーザーid         昇順(デフォルト順)
			case when orderby_in = 1 then t1.userid end,	      --ユーザーid         昇順
			case when orderby_in = -1 then t1.userid end desc,	  --ユーザーid         降順
			case when orderby_in = 2 then t1.usernm end,	      --ユーザー名         昇順
			case when orderby_in = -2 then t1.usernm end desc,	  --ユーザー名         降順
			case when orderby_in = 3 then t2.syozokunm end,	      --所属グループ名     昇順
			case when orderby_in = -3 then t2.syozokunm end desc, --所属グループ名     降順
			case when orderby_in = 4 then t1.yukoymdf end,	      --有効年月日（開始） 昇順
			case when orderby_in = -4 then t1.yukoymdf end desc,  --有効年月日（開始） 降順
			case when orderby_in = 5 then t1.yukoymdt end,	      --有効年月日（終了） 昇順
			case when orderby_in = -5 then t1.yukoymdt end desc	  --有効年月日（終了） 降順
		limit limit_in offset offset_in;
end;
$function$