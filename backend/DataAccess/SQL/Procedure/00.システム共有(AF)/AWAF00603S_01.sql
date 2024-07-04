/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 共通バー情報
　　　　　　一覧抽出
作成日　　: 2023.04.17
作成者　　: 蔣
変更履歴　:
*******************************************************************/
create or replace function sp_awaf00603s_01(atenano_in character varying,              --共通
                                            kigenymd_in character varying,             --共通
                                            jigyokbns_in character varying,            --AWAF00601D_メモ情報、AWAF00604D_メモ情報（世帯）
                                            jigyocds_in character varying,             --AWAF00602D_電子ファイル情報
                                            jigyocds_renrakusaki_in character varying, --AWAF00605D_連絡先
                                            jigyocds_follow_in character varying,      --AWAF00609D_フォロー管理
                                            setaino_in character varying               --AWAF00604D_メモ情報（世帯）
                                            )
 returns table
 (
  barno integer,    --共通バー番号
  attnflg boolean   --注意フラグ
 )
 language plpgsql
as $function$
declare jigyokbns text[];                 --AWAF00601D_メモ情報、AWAF00604D_メモ情報（世帯）
        jigyocds text[];                  --AWAF00602D_電子ファイル情報
        jigyocds_renrakusaki text[];      --AWAF00605D_連絡先
        jigyocds_follow text[];           --AWAF00609D_フォロー管理
begin
    jigyokbns = string_to_array(jigyokbns_in, ',');
    jigyocds = string_to_array(jigyocds_in, ',');
    jigyocds_renrakusaki = string_to_array(jigyocds_renrakusaki_in, ',');
    jigyocds_follow = string_to_array(jigyocds_follow_in, ',');
    return query
       --AWAF00601D_メモ情報：期限日が過ぎてないメモが存在する場合、注意モード　=>　メモテーブル
        select 1,exists(select 1 from tt_afmemo where atenano = atenano_in and kigenymd >= kigenymd_in and jigyokbn = any(jigyokbns) limit 1)
        union all
       --AWAF00602D_電子ファイル情報：重要フラグがtrueのファイルが存在する場合、注意モード　=>　個人ドキュメントテーブル
        select 2,exists(select 1 from tt_afkojindoc where atenano = atenano_in and juyoflg = true and jigyocd = any(jigyocds) limit 1) 
        union all
       --AWAF00604D_メモ情報（世帯）：期限日が過ぎてないメモが存在する場合、注意モード =>　メモ情報（世帯）テーブル
        select 3,exists(select 1 from tt_afmemosetai where setaino = setaino_in and kigenymd >= kigenymd_in and jigyokbn = any(jigyokbns) limit 1) 
        union all
        --AWAF00607D_警告情報照会：データが存在する場合、注意モード => 【住民基本台帳】支援措置対象者情報履歴テーブル
        select 6,exists(select 1 from tt_afsiensotitaisyosya_reki where atenano = atenano_in limit 1)
        --AWAF00605D_連絡先：データが存在する場合、注意モード => 連絡先テーブル
        union all
        select 4,exists(select 1 from tt_afrenrakusaki where atenano = atenano_in and jigyocd = any(jigyocds_renrakusaki) limit 1) 
        --AWAF00608D_送付先管理：データが存在する場合、注意モード => 送付先管理テーブル
        union all
        select 7,exists(select 1 from tt_afsofusaki where atenano = atenano_in limit 1) 
        --AWAF00609D_フォロー管理：データが存在する場合、注意モード => フォロー内容情報テーブル
        union all
        select 8,exists(select 1 from tt_kkfollownaiyo where atenano = atenano_in and haakujigyocd = any(jigyocds_follow) limit 1) 
        --AWAF00610D_健（検）診結果・保健指導履歴照会：データが存在する場合、注意モード 
        --=> 成人保健一次検診結果（固定項目）テーブル、成人保健精密検査結果（固定項目）テーブル、保健指導結果情報（固定項目）テーブル、集団指導参加者テーブル
        union all
        select 9,exists(select 1 from((select 1 from tt_shkensin where atenano = atenano_in)  
                                     union all (select 1 from tt_shseiken where atenano = atenano_in)
                                     union all (select 1 from tt_kkhokensido_kekka where atenano = atenano_in)
                                     union all (select 1 from tt_kksyudansido_sankasya where atenano = atenano_in))
                        limit 1);
end;
$function$