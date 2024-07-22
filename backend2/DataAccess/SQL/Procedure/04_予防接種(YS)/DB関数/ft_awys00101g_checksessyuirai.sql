/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 予防接種の入力チェック（接種依頼情報）
　　　　　　
作成日　　: 2024.06.14
作成者　　: MIC信時
変更履歴　:
*******************************************************************/
CREATE OR REPLACE FUNCTION ft_awys00101g_checksessyuirai(
	atenano_in		varchar,	--宛名番号
	sessyulist_in	varchar		--接種種類一覧
	)
RETURNS TABLE(
	actresultkbn	integer,	--実行結果区分(0:実行完了 1:エラー 2:アラート)
	messageid		varchar,	--メッセージID
	messagetext		varchar		--メッセージ内容
	)
LANGUAGE plpgsql
AS $function$
DECLARE
	ERRORMESSAGEID constant varchar := 'E044001';	--エラーの場合、画面に表示するメッセージID
	ALERTMESSAGEID constant varchar := 'A044001';	--アラートの場合、画面に表示するメッセージID
	errorkbn_nenreichk		varchar(1);	--接種済みチェック区分
	sessyusyosaicd			text;		--接種種類詳細コード
	sessyunm				text;		--接種種類名
	jissiymd_text			text;		--実施日
BEGIN
	--エラー区分取得
	select value1 into errorkbn_nenreichk from tm_afctrl where ctrlmaincd = '1004' and ctrlsubcd = 1 and ctrlcd = '7';

	if errorkbn_nenreichk = '1' or errorkbn_nenreichk = '2' then
		--入力された接種種類が接種済みの場合エラー
		foreach sessyusyosaicd in array string_to_array(sessyulist_in, ',') loop
			if exists(select * from wk_yssessyunyuryoku where atenano = atenano_in and sessyucd = left(sessyusyosaicd,5) and kaisu = right(sessyusyosaicd,2) and sessyukbn = '1') then
				select nm into sessyunm from tm_afhanyo where hanyomaincd = '1004' and hanyosubcd = 2 and hanyocd = sessyusyosaicd;
				--エラーが見つかり次第、結果を返す
				if errorkbn_nenreichk = '1' then
					actresultkbn := 1;
					messageid := ERRORMESSAGEID;
				else
					actresultkbn := 2;
					messageid := ALERTMESSAGEID;
				end if;
				messagetext := '入力された接種種類は接種済みです。（' || sessyunm || '）';
				return query select actresultkbn, messageid, messagetext;
				return;
			end if;
		end loop;
	end if;
	
	--エラーがなかった場合
	actresultkbn := 0;
	return query select actresultkbn, messageid, messagetext;
	
EXCEPTION
	when others then
		actresultkbn := 1;
		messageid := ERRORMESSAGEID;
		messagetext := SQLSTATE || SQLERRM;
		return query select actresultkbn, messageid, messagetext;
END;
$function$