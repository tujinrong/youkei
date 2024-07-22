/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 拡事業・拡運用情報保守
　　　　　　指導項目桁数チェック用
作成日　　: 2024.01.30
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00801g_06(sidokbn_in character varying, gyomukbn_in character varying, 
                                            mosikomikekkakbn_in character varying, itemyotokbn_in character varying,
                                            itemcd_in character varying, inputtypekbn_in integer, keta1_in integer, keta2_in integer)
 returns boolean
 language plpgsql
as $function$          
begin
    return (case 
                when (sidokbn_in = '1' or sidokbn_in = '2')                                 --保健指導の場合
                    then (
                        exists(
                            select 1
                            from (
                                select
                                    length(t.strvalue) as strketa,
                                    case
                                        when position('.' in t.numvalue::text) > 0
                                        then position('.' in t.numvalue::text) - 1
                                        else length(t.numvalue::text)
                                    end as numketa1,
                                    case
                                        when position('.' in t.numvalue::text) > 0
                                        then length(substring(t.numvalue::text from position('.' in t.numvalue::text) + 1))
                                        else 0
                                    end as numketa2
                                from (
                                    select
                                        strvalue,           --文字項目
                                        numvalue            --数値項目
                                    from tt_kkhokensidofree --保健指導事業（フリー項目）入力情報テーブル 
                                    where 
                                        hokensidokbn = sidokbn_in and
                                        gyomukbn = gyomukbn_in and
                                        mosikomikekkakbn = mosikomikekkakbn_in and
                                        itemcd = itemcd_in ) as t
                                ) as tt
                            where 
                                (inputtypekbn_in = 2 and tt.strketa > keta1_in) or                                                 --文字型
                                (inputtypekbn_in = 1 and tt.numketa1 > keta1_in and (keta2_in is null or tt.numketa2 > keta2_in)) --数値型
                        )
                )
                when (sidokbn_in = '3' and itemyotokbn_in = '1')                            --集団指導(事業)の場合
                    then (
                        exists(
                            select 1
                            from (
                                select
                                    length(t.strvalue) as strketa,
                                    case
                                        when position('.' in t.numvalue::text) > 0
                                        then position('.' in t.numvalue::text) - 1
                                        else length(t.numvalue::text)
                                    end as numketa1,
                                    case
                                        when position('.' in t.numvalue::text) > 0
                                        then length(substring(t.numvalue::text from position('.' in t.numvalue::text) + 1))
                                        else 0
                                    end as numketa2
                                from (
                                    select
                                        strvalue,               --文字項目
                                        numvalue                --数値項目
                                    from tt_kksyudansidofree    --集団指導事業（フリー項目）入力情報テーブル
                                    where 
                                        gyomukbn = gyomukbn_in and
                                        mosikomikekkakbn = mosikomikekkakbn_in and
                                        itemcd = itemcd_in ) as t
                                ) as tt
                            where 
                                (inputtypekbn_in = 2 and tt.strketa > keta1_in) or                                                 --文字型
                                (inputtypekbn_in = 1 and tt.numketa1 > keta1_in and (keta2_in is null or tt.numketa2 > keta2_in)) --数値型
                        )
                )
                when (sidokbn_in = '3' and itemyotokbn_in = '2')                            --集団指導(参加者)の場合
                    then (
                        exists(
                            select 1
                            from (
                                select
                                    length(t.strvalue) as strketa,
                                    case
                                        when position('.' in t.numvalue::text) > 0
                                        then position('.' in t.numvalue::text) - 1
                                        else length(t.numvalue::text)
                                    end as numketa1,
                                    case
                                        when position('.' in t.numvalue::text) > 0
                                        then length(substring(t.numvalue::text from position('.' in t.numvalue::text) + 1))
                                        else 0
                                    end as numketa2
                                from (
                                    select
                                        strvalue,                       --文字項目
                                        numvalue                        --数値項目
                                    from tt_kksyudansido_sankasyafree   --集団指導参加者（フリー項目）入力情報テーブル
                                    where 
                                        gyomukbn = gyomukbn_in and
                                        mosikomikekkakbn = mosikomikekkakbn_in and
                                        itemcd = itemcd_in ) as t
                                ) as tt
                            where 
                                (inputtypekbn_in = 2 and tt.strketa > keta1_in) or                                                 --文字型
                                (inputtypekbn_in = 1 and tt.numketa1 > keta1_in and (keta2_in is null or tt.numketa2 > keta2_in)) --数値型
                        )
                )
                else false
            end); 
end;
$function$