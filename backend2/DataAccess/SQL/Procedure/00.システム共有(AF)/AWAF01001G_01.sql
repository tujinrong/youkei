/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: バッチスケジュール管理
　　　　　　　　　一覧抽出
作成日　　: 2024.03.07
作成者　　: 千秋
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION sp_awaf01001g_01_head(taskid_in character varying, syorikbn_in character varying, gyomukbn_in character varying, statuscd_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
	declare total integer;
begin
	select
		count(m1.taskid) total into total
    from
        tm_aftaskschedule m1																--バッチスケジュールマスタ
    where 
		(taskid_in is null or m1.taskid = taskid_in)					--タスクID
		and
		(syorikbn_in is null or m1.syorikbn = syorikbn_in)				--処理区分
		and
		(gyomukbn_in is null or m1.gyomukbn =  gyomukbn_in )			--処理区分
		and
		(statuscd_in is null or m1.statuscd = statuscd_in);		        --モジュールコード
    return total;
end;
$function$
/*==============================body==============================*/
CREATE OR REPLACE FUNCTION sp_awaf01001g_01_body(taskid_in character varying, syorikbn_in character varying, gyomukbn_in character varying, statuscd_in character varying, limit_in integer, offset_in integer)
 RETURNS TABLE
 (taskid character varying, 
 tasknm character varying, 
 renkeiid character varying, 
 zenjikkodttmf timestamp without time zone, 
 jikaijikkodttmt timestamp without time zone, 
 syorikbn character varying, 
 gyomukbn character varying, 
 yukoymdf character varying, 
 yukotmf character varying, 
 hindokbn character varying, 
 syukustopflg boolean, 
 yobi character varying, 
 maitukihiyobikbn character varying, 
 maitukituki character varying, 
 maitukihi character varying,
 maitukisyu character varying, 
 statuscd character varying, 
 kurikaesikanflg boolean, 
 kurikaesikankbn character varying, 
 jikantaif character varying, 
 jikantait character varying, 
 jikannaif character varying, 
 jikannait character varying, 
 stopflg boolean)
 LANGUAGE plpgsql
AS $function$
begin
	return query
	select
          m1.taskid                     --タスクID
        , m1.tasknm                     --タスク名
        , m1.renkeiid                   --HangFire連携ID
        , m1.zenjikkodttmf              --前回の実行日時（開始）
        , m1.jikaijikkodttmt            --次回実行日時
        , m1.syorikbn                   --処理区分
        , m1.gyomukbn                   --業務区分
        , m1.yukoymdf                   --有効年月日（開始）
        , m1.yukotmf                    --有効時間（開始）
        , m1.hindokbn                   --頻度区分
        , m1.syukustopflg               --祝日停止フラグ
        , m1.yobi                       --曜日
        , m1.maitukihiyobikbn           --毎月の日・曜日区分
        , m1.maitukituki                --毎月の月
        , m1.maitukihi                  --毎月の日
        , m1.maitukisyu                 --毎月の週
        , m1.statuscd                   --処理結果コード
        , m1.kurikaesikanflg            --繰り返し間隔フラグ
        , m1.kurikaesikankbn            --繰り返し間隔区分
        , m1.jikantaif                  --時間帯開始_時
        , m1.jikantait                  --時間帯終了_時
        , m1.jikannaif                  --時間内開始_分
        , m1.jikannait                  --時間内終了_分
        , m1.stopflg                    --使用停止フラグ
    from
        tm_aftaskschedule m1											--バッチスケジュールマスタ
    where 
		(taskid_in is null or m1.taskid = taskid_in)					--タスクID
		and
		(syorikbn_in is null or m1.syorikbn = syorikbn_in)				--処理区分
		and
		(gyomukbn_in is null or m1.gyomukbn =  gyomukbn_in )			--処理区分
		and
		(statuscd_in is null or m1.statuscd = statuscd_in)	            --モジュールコード
    order by
        m1.taskid														--タスクID		昇順
    limit limit_in offset offset_in;
end;
$function$