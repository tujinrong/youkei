/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票使用
			事業従事者IDの所属する医療機関マスタの医療機関名
			を「、」区切りで結合し取得する
作成日　　: 2024.04.17
作成者　　: 鄭
変更履歴　:
*******************************************************************/	

CREATE OR REPLACE FUNCTION fn_eugetstaffsyozokukikannm(
staffid_in character varying	--事業従事者（担当者）ID
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
DECLARE
	vcursor CURSOR(staff_id varchar)
			FOR SELECT T2.kikannm
				FROM tm_afstaff_kikan T1 
                INNER JOIN tm_afkikan T2 
                ON T1.kikancd = T2.kikancd
				WHERE T1.staffid =  staffid_in
				ORDER BY T1.kikancd;
	kikannms varchar := '';	-- 所属機関（複数の機関に所属している場合、カンマ区切りで出力）
BEGIN
	FOR rec IN vcursor(staff_id:=staffid_in) LOOP
		kikannms := kikannms || '、' || rec.kikannm;
    END LOOP;
	RETURN substr(kikannms, 2);
END;

$function$