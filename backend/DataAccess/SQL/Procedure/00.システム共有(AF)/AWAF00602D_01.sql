/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 電子ファイル情報
　　　　　　一覧抽出
作成日　　: 2023.03.17
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_awaf00602d_01_head(atenano_in character varying, jigyocd_in character varying, title_in character varying, jigyocds_in character varying)
 returns integer
 language plpgsql
as $function$
	declare total integer;
	jigyocds text[];
begin
	jigyocds = string_to_array(jigyocds_in, ',');
	select
		count(1) total into total
    from
        tt_afkojindoc t1         --個人ドキュメントテーブル
    where 
		t1.atenano = atenano_in								--宛名番号
		and (jigyocd_in is null or t1.jigyocd = jigyocd_in)	--事業コード  
		and (title_in is null or t1.title like title_in)	--タイトル
		and t1.jigyocd = any(jigyocds);						--登録事業(表示範囲)
    return total;
end;
$function$
/*==============================body==============================*/
create or replace function sp_awaf00602d_01_body(atenano_in character varying, jigyocd_in character varying, title_in character varying, jigyocds_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 returns table
 (docseq integer, 
  title character varying,
  juyoflg bool, 
  regdttm timestamp without time zone, 
  jigyocd character varying, 
  filenm character varying, 
  filetype smallint,
  regsisyo character varying,
  upddttm timestamp without time zone)
 language plpgsql
as $function$
declare jigyocds text[];
begin
	jigyocds = string_to_array(jigyocds_in, ',');
	return query
	select
		 t1.docseq,        --ドキュメントシーケンス
		 t1.title,         --タイトル
		 t1.juyoflg,       --重要フラグ
		 t1.regdttm,       --登録日時(アップロード日時)
		 t1.jigyocd,       --事業コード
		 t1.filenm,        --ファイル名
		 t1.filetype,      --ファイルタイプ
		 t1.regsisyo,      --登録支所
		 t1.upddttm        --更新日時
    from
        tt_afkojindoc t1   --個人ドキュメントテーブル
    where 
		t1.atenano = atenano_in								--宛名番号
		and (jigyocd_in is null or t1.jigyocd = jigyocd_in)	--事業コード  
		and (title_in is null or t1.title like title_in)	--タイトル
		and t1.jigyocd = any(jigyocds)						--登録事業(表示範囲)
    order by
		case when orderby_in = 0 then t1.docseq end desc,	--ドキュメントシーケンス		降順
		case when orderby_in = 1 then 
			case when t1.filetype in (3,4,5,7) then 0		--(3,4,5,7)==>(jpg,jpeg,png,tif)
				else 1 
			end
		end, 												--画像フラグ  昇順
		case when orderby_in = -1 then 
			case when t1.filetype in (3,4,5,7) then 0
				else 1 
			end
		end desc,											--画像フラグ  降順
		case when orderby_in = 2 then t1.title end,         --タイトル						昇順
		case when orderby_in = -2 then t1.title end desc,   --タイトル						降順
		case when orderby_in = 3 then t1.regdttm end,       --登録日時(アップロード日時)	昇順
		case when orderby_in = -3 then t1.regdttm end desc, --登録日時(アップロード日時)	降順
		case when orderby_in = 4 then t1.jigyocd end,       --事業コード					昇順
		case when orderby_in = -4 then t1.jigyocd end desc, --事業コード					降順
		case when orderby_in = 5 then t1.filenm end,		--ファイル名					昇順
		case when orderby_in = -5 then t1.filenm end desc	--ファイル名					降順
    limit limit_in offset offset_in;
end;
$function$