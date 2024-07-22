/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: ログ情報管理
　　　　　　一覧抽出
作成日　　: 2023.09.05
作成者　　: 
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00803g_01_head(logkbn_in integer, status_in character varying, 
												syoridttmf_in character varying, syoridttmt_in character varying, 
												service_in character varying, method_in character varying, 
												user_in character varying, atenano_in character varying, personalno_in character varying, 
												pnokbn_in boolean)
 returns integer
 language plpgsql
as $function$
	declare total integer;
	syoridttmf_in2 timestamp without time zone;
	syoridttmt_in2 timestamp without time zone;
begin
	syoridttmf_in2 := to_timestamp(syoridttmf_in, 'YYYY-MM-DD HH24:MI:SS');
	syoridttmt_in2 := to_timestamp(syoridttmt_in, 'YYYY-MM-DD HH24:MI:SS');
	select
		count(1) total into total
    from 
		tt_aflog t0									--メインログテーブル
        left join 
            (select sessionseq, true as existflg 
	    		from tt_aftusinlog					--通信ログテーブル
	    		group by sessionseq) t1 
	    		on t0.sessionseq = t1.sessionseq 
        left join 
            (select sessionseq, true as existflg 
	    		from tt_afbatchlog 
	    		group by sessionseq) t2				--バッチログテーブル
	    		on t0.sessionseq = t2.sessionseq
        left join 
            (select sessionseq, true as existflg 
	    		from tt_afgaibulog 
	    		group by sessionseq) t3				--外部連携処理結果履歴テーブル
	    		on t0.sessionseq = t3.sessionseq
        left join 
            (select sessionseq, true as existflg 
	    		from tt_aflogdb 
	    		group by sessionseq) t4				--DB操作ログテーブル
	    		on t0.sessionseq = t4.sessionseq
        left join 
            (select sessionseq, true as existflg 
	    		from tt_aflogcolumn 
	    		group by sessionseq) t5				--テーブル項目値変更ログテーブル
	    		on t0.sessionseq = t5.sessionseq
        left join 
            (select sessionseq, true as existflg
	    		from tt_aflogatena 
	    		group by sessionseq) t6				--宛名番号ログテーブル
	    		on t0.sessionseq = t6.sessionseq
        left join 
            (select sessionseq, atenano
			    from tt_aflogatena) t7				--宛名番号ログテーブル
			    on t0.sessionseq = t7.sessionseq
        left join
            (select atenano, personalno
			    from tt_afatena) t8                 --宛名テーブル
            on t7.atenano = t8.atenano
        where 
            (logkbn_in is null or
             (logkbn_in = 1 and t1.existflg = true) or
             (logkbn_in = 2 and t2.existflg = true) or
             (logkbn_in = 3 and t3.existflg = true) or
             (logkbn_in = 4 and t4.existflg = true) or
             (logkbn_in = 5 and t5.existflg = true) or
             (logkbn_in = 6 and t6.existflg = true))									    --ログ区分
            and (status_in is null or t0.statuscd = status_in)							    --処理結果
            and (syoridttmf_in is null or t0.syoridttmf >= syoridttmf_in2)				    --処理日時（開始）
            and (syoridttmt_in is null or t0.syoridttmt <= syoridttmt_in2)				    --処理日時（終了）
            and (service_in is null or t0.kinoid = service_in)								--機能
            and (method_in is null or t0.method = method_in)							    --処理
            and (user_in is null or t0.reguserid = user_in)								    --登録者
            and (atenano_in is null or (t6.existflg = true and t7.atenano = atenano_in))    --宛名番号
		    and (personalno_in is null or 
			    (t6.existflg = true and t8.personalno = personalno_in))                     --個人番号
            and (pnokbn_in = false or (pnokbn_in = true and t6.existflg = true))		    --個人番号操作区分
            and (t0.kinoid != 'AWAF00803G');
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00803g_01_body(logkbn_in integer, status_in character varying, 
												syoridttmf_in character varying, syoridttmt_in character varying, 
												service_in character varying, method_in character varying, 
												user_in character varying, atenano_in character varying, personalno_in character varying, 
												pnokbn_in boolean, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (seq bigint,								--ログシーケンス
  existflg1 boolean,						--通信ログ操作状況
  existflg2 boolean,						--バッチログ操作状況
  existflg3 boolean,						--外部連携ログ操作状況
  existflg4 boolean,						--DB操作ログ操作状況
  existflg5 boolean,						--項目値変更ログ操作状況
  existflg6 boolean,						--宛名番号ログ操作状況
  syoridttmf timestamp without time zone,	--処理日時（開始）
  syoridttmt timestamp without time zone,	--処理日時（終了）
  syoritime integer,						--処理時間
  kinoid character varying,							--機能ID
  servicenm character varying,				--機能名
  methodnm character varying,				--処理名
  usernm character varying,					--登録者
  pnoflg boolean,							--個人番号操作状況
  msgflg boolean,							--メッセージ操作状況
  statuscd character varying)						--処理結果コード
 language plpgsql
as $function$
declare 
  syoridttmf_in2 timestamp without time zone;
  syoridttmt_in2 timestamp without time zone;
begin
  syoridttmf_in2 := to_timestamp(syoridttmf_in, 'YYYY-MM-DD HH24:MI:SS');
  syoridttmt_in2 := to_timestamp(syoridttmt_in, 'YYYY-MM-DD HH24:MI:SS');
	return query
	select 
		t.seq				--セッションシーケンス
		,t.existflg1		--通信ログ操作状況
		,t.existflg2		--バッチログ操作状況
		,t.existflg3		--外部連携ログ操作状況
		,t.existflg4		--DB操作ログ操作状況
		,t.existflg5		--項目値変更ログ操作状況
		,t.existflg6		--宛名番号ログ操作状況
		,t.syoridttmf		--処理日時（開始）
		,t.syoridttmt		--処理日時（終了）
		,t.syoritime		--処理時間
		,t.kinoid			--機能ID
		,t.servicenm		--サービス名
		,t.methodnm			--メソッド名
		,t.usernm			--操作者名
		,t.pnoflg			--個人番号操作状況
		,t.msgflg			--メッセージ操作状況
		,t.statuscd			--処理結果コード
	from (
		select
            t0.sessionseq as seq        --セッションシーケンス
            ,t1.existflg as existflg1   --通信ログ操作状況
            ,t2.existflg as existflg2   --バッチログ操作状況
            ,t3.existflg as existflg3   --外部連携ログ操作状況
            ,t4.existflg as existflg4   --DB操作ログ操作状況
            ,t5.existflg as existflg5   --項目値変更ログ操作状況
            ,t6.existflg as existflg6   --宛名番号ログ操作状況
            ,t0.syoridttmf			    --処理日時（開始）
	    	,t0.syoridttmt				--処理日時（終了）
	    	,t0.milisec as syoritime	--処理時間
	    	,t0.kinoid					--機能ID
	    	,t0.service as servicenm	--サービス名
	    	,t0.method					--メソッド
	    	,t0.methodnm				--メソッド名
	    	,t0.reguserid				--登録ユーザーID
			,case when t0.reguserid = 'system'
				then 'system'
				else m1.usernm
			end as usernm				--操作者名
	    	,t9.existflg as pnoflg		--個人番号操作状況
	    	,case when 
				(t10.existflg or t11.existflg or t12.existflg or t13.existflg)
				then true
				else false
			end as msgflg				--メッセージ操作状況
	    	,t0.regdttm				    --登録日時
            ,t0.statuscd				--処理結果コード
        from 
            tt_aflog t0									--メインログテーブル
			left join 
			    (select sessionseq, true as existflg 
					from tt_aftusinlog					--通信ログテーブル
					group by sessionseq) t1 
					on t0.sessionseq = t1.sessionseq 
			left join 
			    (select sessionseq, true as existflg 
					from tt_afbatchlog 
					group by sessionseq) t2				--バッチログテーブル
					on t0.sessionseq = t2.sessionseq
			left join 
			    (select sessionseq, true as existflg 
					from tt_afgaibulog 
					group by sessionseq) t3				--外部連携処理結果履歴テーブル
					on t0.sessionseq = t3.sessionseq
			left join 
			    (select sessionseq, true as existflg 
					from tt_aflogdb 
					group by sessionseq) t4				--DB操作ログテーブル
					on t0.sessionseq = t4.sessionseq
			left join 
			    (select sessionseq, true as existflg 
					from tt_aflogcolumn 
					group by sessionseq) t5				--テーブル項目値変更ログテーブル
					on t0.sessionseq = t5.sessionseq
			left join 
			    (select sessionseq, true as existflg
					from tt_aflogatena 
					group by sessionseq) t6				--宛名番号ログテーブル
					on t0.sessionseq = t6.sessionseq
			left join 
			    (select sessionseq, atenano
				    from tt_aflogatena) t7				--宛名番号ログテーブル
				    on t0.sessionseq = t7.sessionseq
			left join
			    (select atenano, personalno
				    from tt_afatena) t8                 --宛名テーブル
			    on t7.atenano = t8.atenano
			left join 
			    (select sessionseq, true as existflg
					from tt_aflogatena 
					where pnouseflg = true
					group by sessionseq) t9				--宛名番号ログテーブル
					on t0.sessionseq = t9.sessionseq
			left join 
			    (select sessionseq, true as existflg 
					from tt_aftusinlog					--通信ログテーブル
					where msg is not null
					group by sessionseq) t10 
					on t0.sessionseq = t10.sessionseq 
			left join 
			    (select sessionseq, true as existflg 
					from tt_afbatchlog 
					where msg is not null
					group by sessionseq) t11			--バッチログテーブル
					on t0.sessionseq = t11.sessionseq
			left join 
			    (select sessionseq, true as existflg 
					from tt_afgaibulog 
					where msg is not null
					group by sessionseq) t12			--外部連携処理結果履歴テーブル
					on t0.sessionseq = t12.sessionseq
			left join 
			    (select sessionseq, true as existflg 
					from tt_aflogdb 
					where msg is not null
					group by sessionseq) t13			--DB操作ログテーブル
					on t0.sessionseq = t13.sessionseq
			left join tm_afuser m1						--ユーザーマスタ
				on t0.reguserid = m1.userid
        where 
            (logkbn_in is null or
             (logkbn_in = 1 and t1.existflg = true) or
             (logkbn_in = 2 and t2.existflg = true) or
             (logkbn_in = 3 and t3.existflg = true) or
             (logkbn_in = 4 and t4.existflg = true) or
             (logkbn_in = 5 and t5.existflg = true) or
             (logkbn_in = 6 and t6.existflg = true))									    --ログ区分
            and (status_in is null or t0.statuscd = status_in)							    --処理結果
            and (syoridttmf_in is null or t0.syoridttmf >= syoridttmf_in2)				    --処理日時（開始）
            and (syoridttmt_in is null or t0.syoridttmt <= syoridttmt_in2)				    --処理日時（終了）
            and (service_in is null or t0.kinoid = service_in)								--機能
            and (method_in is null or t0.method = method_in)							    --処理
            and (user_in is null or t0.reguserid = user_in)								    --登録者
            and (atenano_in is null or (t6.existflg = true and t7.atenano = atenano_in))    --宛名番号
		    and (personalno_in is null or 
			    (t6.existflg = true and t8.personalno = personalno_in))                     --個人番号
            and (pnokbn_in = false or (pnokbn_in = true and t6.existflg = true))		    --個人番号操作区分
            and (t0.kinoid != 'AWAF00803G')
		) as t
	order by
		case when orderby_in = 0 then t.seq end desc			--セッションシーケンス		降順
		,case when orderby_in = 1 then t.seq end				--セッションシーケンス	昇順
		,case when orderby_in = -1 then t.seq end desc			--セッションシーケンス		降順
		,case when orderby_in = 2 then t.syoridttmf end         --処理日時（開始）		昇順
		,case when orderby_in = -2 then t.syoridttmf end desc   --処理日時（開始）			降順
		,case when orderby_in = 3 then t.syoridttmt end         --処理日時（終了）		昇順
		,case when orderby_in = -3 then t.syoridttmt end desc   --処理日時（終了）			降順
		,case when orderby_in = 4 then t.syoritime end			--処理時間				昇順
		,case when orderby_in = -4 then t.syoritime end desc	--処理時間					降順
		,case when orderby_in = 5 then t.kinoid end				--機能ID				昇順
		,case when orderby_in = -5 then t.kinoid end desc		--機能ID					降順
		,case when orderby_in = 6 then t.servicenm end			--機能名				昇順
		,case when orderby_in = -6 then t.servicenm end desc	--機能名					降順
		,case when orderby_in = 7 then t.methodnm end			--処理名				昇順
		,case when orderby_in = -7 then t.methodnm end desc		--処理名					降順
		,case when orderby_in = 8 then t.usernm end				--操作者				昇順
		,case when orderby_in = -8 then t.usernm end desc		--操作者					降順
		,case when orderby_in = 9 then t.pnoflg end				--個人番号操作状況		昇順
		,case when orderby_in = -9 then t.pnoflg end desc		--個人番号操作状況			降順
		,case when orderby_in = 10 then t.msgflg end			--メッセージ操作状況	昇順
		,case when orderby_in = -10 then t.msgflg end desc		--メッセージ操作状況		降順
		,case when orderby_in = 11 then t.statuscd end			--処理結果コード		昇順
		,case when orderby_in = -11 then t.statuscd end desc	--処理結果コード			降順

    limit limit_in offset offset_in;
end;
$function$