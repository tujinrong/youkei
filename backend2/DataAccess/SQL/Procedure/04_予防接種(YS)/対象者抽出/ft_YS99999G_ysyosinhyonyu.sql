/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 予防接種予診票（乳幼児）の対象者抽出チェック
　　　　　　
作成日　　: 2024.05.17
作成者　　: 陳
変更履歴　:
*******************************************************************/
CREATE OR REPLACE FUNCTION ft_YS99999G_ysyosinhyonyu(
	tyusyututaisyocd_in varchar,          --【ストアド固定】抽出対象コード
	tyusyutudatasyosaikbn_in varchar,     --【ストアド固定】抽出データ詳細区分（業務によって検診種別、月齢区分、接種種別など）
	atenano_in varchar,                   --【ストアド固定】宛名番号
	tyusyutunaiyo_in varchar,             --【ストアド固定】抽出内容
	continueflg_in boolean,               --【ストアド固定】継続希望フラグ
    nendo_in integer,                     --【ストアド固定】年度
	regsisyo_in varchar,                  --【ストアド固定】登録支所
	userid_in varchar,                    --【ストアド固定】ユーザーID
	bymdf_in varchar,                     --【検索条件】生年月日（FROM）
	bymdt_in varchar,                     --【検索条件】生年月日（TO）
	--agef_in integer,                      --【検索条件】年齢（FROM）
	--aget_in integer,                      --【検索条件】年齢（TO）  
    kijunymd_in varchar                   --【検索条件以外】年齢計算基準日
                                          --※成人保健の場合、発番順などのパラメータを引数に追加する必要がある
	)
RETURNS TABLE(
	actresultkbn integer,                 --実行結果区分(0:実行完了 1:エラー 2:アラート)
	messagetext varchar,                  --エラー・アラートメッセージの内容
    messageid varchar,                    --エラー・アラートメッセージのID
    tyusyutuseq bigint                    --抽出完了の場合、画面の抽出シーケンス
                                          --※成人保健の場合、券番号などのパラメータを戻り値に追加する必要がある
)
LANGUAGE plpgsql
AS $function$
DECLARE
    tmp_atenano RECORD;
	MESSAGESETTING CONSTANT INTEGER := 1;               --【設定】画面に表示するメッセージの種別（1:エラー、2:アラート）
	ERRORMESSAGEID CONSTANT VARCHAR := 'E014012';       --【設定】エラーの場合、画面に表示するメッセージID
	ALERTMESSAGEID CONSTANT VARCHAR := 'K013003';       --【設定】アラートの場合、画面に表示するメッセージID
    messagekbn_m integer := 0;                          --メッセージを表示するかどうかの戻り値
    v_messagetext VARCHAR := '';                        --画面に表示するメッセージテキストの戻り値
    messageid_m varchar := '';                          --画面に表示するメッセージIDの戻り値
    tyusyutuseq_m bigint;                               --発行画面に遷移するため必要なパラメータ、抽出シーケンスの戻り値
    f_m varchar(10);
    t_m varchar(10);
BEGIN
	-----------------------------------------------
    --個別抽出の場合、チェックをする（個別抽出の除外はプログラム上で実装する）
    -----------------------------------------------
	IF atenano_in IS NOT NULL AND continueflg_in IS TRUE THEN
        --チェックを無視する場合、続行する
	ELSIF atenano_in IS NOT NULL AND continueflg_in IS FALSE THEN
        
        --仮チェック①：宛名テーブルの住民区分＜５かどうか
        SELECT INTO tmp_atenano
            T1.atenano
        FROM tt_afatena T1
        WHERE T1.juminkbn < 5;

        IF NOT FOUND THEN
            messagekbn_m := MESSAGESETTING;
            v_messagetext := v_messagetext || '除票者です。\n';
        END IF;

        --仮チェック②: 1回でも未接種であるかどうか     
        SELECT INTO tmp_atenano
            '240', 1, T1.atenano, 'BCC', CURRENT_DATE, 
            ROW_NUMBER() OVER (ORDER BY T1.bymd, T1.simei_kana)
        FROM tt_afatena T1
        INNER JOIN VW_YSYOSINTAI240 V1 ON T1.atenano = V1.atenano             --未接種の対象者を抽出するビュー
        WHERE T1.atenano = atenano_in;

        IF NOT FOUND THEN
            messagekbn_m := MESSAGESETTING;
            v_messagetext := v_messagetext || '接種済です。\n';
        END IF;

        --仮チェック③: 年齢もしく生年月日が検索条件該当するかどうか
        --検索条件が年齢の場合、日付に変換する
        --IF agef_in IS NOT NULL THEN
        --    f_m := to_char(CAST(kijunymd_in AS DATE) - CAST(agef_in || ' years' AS INTERVAL), 'YYYY-MM-DD');   
        --END IF;

        --IF aget_in IS NOT NULL THEN
        --    t_m := to_char(CAST(kijunymd_in AS DATE) - CAST(aget_in || ' years' AS INTERVAL), 'YYYY-MM-DD');   
        --END IF;

        SELECT INTO tmp_atenano
            T1.atenano
        FROM tt_afatena T1
        WHERE T1.atenano = atenano_in
            AND T1.bymd_fusyoflg = FALSE
            --年齢で検索する場合（本システムで使わないので不要）
            --AND (agef_in IS NOT NULL OR T1.bymd >= f_m)
            --AND (aget_in IS NOT NULL OR T1.bymd <= t_m);
            --生年月日で検索する場合
            AND (bymdf_in IS NOT NULL OR T1.bymd >= bymdf_in)
            AND (bymdt_in IS NOT NULL OR T1.bymd <= bymdt_in);

        IF NOT FOUND THEN
            messagekbn_m := MESSAGESETTING;
            v_messagetext := v_messagetext || '接種可能な年齢ではありません。\n';
        END IF;

        --チェックが失敗した場合、処理を終了し、エラーのテキストを返す
        IF v_messagetext <> '' THEN

            --事前に準備したメッセージIDを設定
            IF MESSAGESETTING = 1 THEN
                messageid_m := ERRORMESSAGEID;
            ELSIF MESSAGESETTING = 2 THEN
                messageid_m := ALERTMESSAGEID;
            END IF;

            RETURN QUERY SELECT messagekbn_m, v_messagetext, messageid_m, NULL;
            RETURN;
        END IF;
	END IF;

	-----------------------------------------------
	--全体抽出もしくは個別チェックがエラーなしで終わる場合、ストアドプロシージャを呼び出す
	-----------------------------------------------
	CALL sp_YS99999G_ysyosinhyonyu(
        tyusyututaisyocd_in::varchar,
        tyusyutudatasyosaikbn_in::varchar,
        atenano_in::varchar, 
        tyusyutunaiyo_in::varchar, 
        nendo_in::integer, 
        regsisyo_in::varchar, 
        userid_in::varchar,
        tyusyutuseq_m::bigint,                        --OUT戻り値 
        bymdf_in::varchar, 
        bymdt_in::varchar, 
        --agef_in::integer, 
        --aget_in::integer,   
        kijunymd_in::varchar
    );
    RETURN QUERY SELECT messagekbn_m, v_messagetext, messageid_m, tyusyutuseq_m;
END;
$function$