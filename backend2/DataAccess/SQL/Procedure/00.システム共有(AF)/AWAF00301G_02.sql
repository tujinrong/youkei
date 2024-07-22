/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: ホーム
　　　　　　処理状況一覧抽出
作成日　　: 2024.07.20
作成者　　: 蔣
変更履歴　:
*******************************************************************/
create or replace function sp_awaf00301g_02()
returns table
    (gaibulogseq bigint, 
     syoridttmf timestamp without time zone, 
     syoridttmt timestamp without time zone, 
     syorikbn character varying, 
     syorinm character varying, 
     usernm character varying, 
     statuscd character varying, 
     filenm character varying)
language plpgsql
as $function$
begin
	return query
		select
			t1.gaibulogseq gaibulogseq, --外部連携ログシーケンス
			t1.syoridttmf syoridttmf,   --処理日時（開始）
			t1.syoridttmt syoridttmt,   --処理日時（終了）
			t1.kbn3 syorikbn,           --処理区分
			t2.methodnm syorinm,        --処理内容コード
			m1.usernm usernm,           --ユーザー名
			t2.statuscd statuscd,	    --処理結果コード
			t1.filenm filenm		    --ファイル名
		from
			tt_afgaibulog t1            --処理結果履歴テーブル
				join tt_aflog t2 on t1.sessionseq = t2.sessionseq	    --メインログテーブル
				left join tm_afuser m1 on t1.reguserid = m1.userid		--ユーザーマスタ
		order by
			t1.syoridttmf desc,				--処理日時（開始） 降順
			t2.statuscd						--処理結果コード   昇順
		limit 100;							--トップ100
end;
$function$