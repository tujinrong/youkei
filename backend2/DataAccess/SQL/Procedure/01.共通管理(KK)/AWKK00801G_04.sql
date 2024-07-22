/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 拡事業・拡運用情報保守
　　　　　　指導項目必須チェック用
作成日　　: 2024.01.30
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_04(sidokbn_in character varying, gyomukbn_in character varying, 
                                            mosikomikekkakbn_in character varying, itemyotokbn_in character varying,
                                            itemcd_in character varying)
 returns boolean
 language plpgsql
as $function$          
begin
    return (case 
                when (sidokbn_in = '1' or sidokbn_in = '2')                                 --訪問・個人指導の場合
                    then (
                            exists(
                                select 1
                                from tt_kkhokensidofree tt2                                 --保健指導事業（フリー項目）入力情報テーブル
                                where
                                    tt2.hokensidokbn = sidokbn_in and                       --保健指導区分
                                    tt2.gyomukbn = gyomukbn_in and                          --業務区分
                                    tt2.mosikomikekkakbn = mosikomikekkakbn_in and          --申込結果区分
                                    tt2.itemcd = itemcd_in and                              --項目コード
                                    tt2.numvalue is null and                                --数値項目
                                    coalesce(tt2.strvalue, '') = ''                         --文字項目
                                  )
                            )
                when (sidokbn_in = '3' and itemyotokbn_in = '1')                            --集団指導(事業)の場合
                    then (
                            exists(
                                select 1
                                from tt_kksyudansidofree tt2                                --集団指導事業（フリー項目）入力情報テーブル
                                where 
                                    tt2.gyomukbn = gyomukbn_in and                          --業務区分
                                    tt2.mosikomikekkakbn = mosikomikekkakbn_in and          --申込結果区分
                                    tt2.itemcd = itemcd_in and                              --項目コード
                                    tt2.numvalue is null and                                --数値項目
                                    coalesce(tt2.strvalue, '') = ''                         --文字項目
                                   )
                            )
                when (sidokbn_in = '3' and itemyotokbn_in = '2')                            --集団指導(参加者)の場合
                    then (
                          exists(
                              select 1
                              from tt_kksyudansido_sankasyafree tt2               --集団指導参加者（フリー項目）入力情報テーブル
                              where 
                                  tt2.gyomukbn = gyomukbn_in and                  --業務区分
                                  tt2.mosikomikekkakbn = mosikomikekkakbn_in and  --申込結果区分
                                  tt2.itemcd = itemcd_in and                      --項目コード
                                  tt2.numvalue is null and                        --数値項目
                                  coalesce(tt2.strvalue, '') = ''                 --文字項目
                                 )
                          )
               else false
           end); 
end;
$function$