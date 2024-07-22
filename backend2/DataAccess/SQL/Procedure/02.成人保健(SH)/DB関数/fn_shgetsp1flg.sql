/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 共通関数
　　　　　　特殊関数チェック1：前年度未受診者対象
作成日　　: 2024.02.12
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function fn_shgetsp1flg(jigyocd_in character varying, kensahohocd_in character varying, atenano_in character varying, nendo_in integer)
 returns boolean
 language plpgsql
as $function$
declare 
    nendo2 integer; --前年度年度
begin
    nendo2 = nendo_in - 1;
    return exists(
            select 1 
            from tt_shkensin                                --成人保健一次検診結果（固定項目）テーブル
            where 
                jigyocd = jigyocd_in and                    --事業コード
                atenano = atenano_in and                    --宛名番号
                nendo = nendo2 and                          --年度
                case 
                    when kensahohocd_in = '0' then 1 = 1
                    else kensahohocd = kensahohocd_in   
                end                                         --検査方法（検査方法設定しない事業の場合条件としない）
            );
end;
$function$