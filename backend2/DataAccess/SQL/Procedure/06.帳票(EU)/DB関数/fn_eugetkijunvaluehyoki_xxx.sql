/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 使用される基準値を取得する
　　　　　　
作成日　　: 2024.04.23
作成者　　: 呉
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION fn_eugetkijunvaluehyoki(jigyocd_in character varying, itemcd_in character varying, bymd_fusyoflg_in boolean, bymd_in character varying, jissiymd1_in character varying, jissiymd2_in character varying, sex_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
	declare jissiymd varchar; kijunvalue varchar;
begin
--取得したデータのグループID＝'1'の場合、実施年月日１を「実施年月日」に設定する
select
	case when groupid = '1'
	then jissiymd1_in
	else jissiymd2_in
	end into jissiymd
from tm_shfreeitem 
where jigyocd = jigyocd_in 
	and itemcd = itemcd_in 
limit 1;
--上記以外の場合、実施年月日２を「実施年月日」に設定する
select 
	kijunvaluehyoki into kijunvalue
from tm_kkkijun
where
    --生年月日_不詳フラグがTrueの場合、999を設定
	kijunjigyocd = jigyocd_in and itemcd = itemcd_in
	and 
		COALESCE(agef, 0) <=
		case when bymd_fusyoflg_in
		then 999
		else 
			EXTRACT(YEAR from (age(jissiymd::DATE,bymd_in::DATE)))
		end
	and 
    --生年月日_不詳フラグがFalseの場合、「実施年月日」より算出した年齢を設定
		COALESCE(aget, 9999) >=
		case when bymd_fusyoflg_in
		then 999
		else 
			EXTRACT(YEAR from (age(jissiymd::DATE,bymd_in::DATE)))
		end
	and yukoymdf <= jissiymd and yukoymdt >= jissiymd and (sex is null or sex = sex_in)
limit 1;

	return kijunvalue;
end;
$function$