/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 取込実行
　　　　　　取込データ行エラー情報リスト検索
作成日　　: 2023.10.11
作成者　　: 韋
変更履歴　:
*******************************************************************/
/*==============================取込データ行エラー情報リスト検索==============================*/
create or replace function sp_awkk00703d_01(impjikkoid_in integer, rowno_in integer)
	returns table
	(atenano character varying							--宛名番号
	, simei character varying						 	--氏名
	, itemnm character varying					 		--項目名
	, itemvalue character varying						--項目値
	, msg character varying                             --メッセージ
    , dataseq integer)							        --データID
	language plpgsql
as $function$
begin
	return query  
    select
        t1.atenano
        , t1.simei
        , t1.itemnm
        , t1.itemvalue
        , t1.msg 
        , t1.dataseq
    from
        tt_kktorinyuryoku_err t1                        --一括取込入力エラーテーブル
    where
        t1.impjikkoid = impjikkoid_in                   --取込実行ID
        and t1.rowno = rowno_in                         --行番号  
    order by
        dataseq asc;                                 	--データID	昇順（デフォルト）
end;
$function$