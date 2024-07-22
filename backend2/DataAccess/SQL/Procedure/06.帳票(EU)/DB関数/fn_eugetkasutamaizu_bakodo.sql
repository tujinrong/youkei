/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: カスタマーバーコードの郵便番号と住所を取得する
　　　　　　
作成日　　: 2024.06.25
作成者　　: 鄭
変更履歴　:
*******************************************************************/

CREATE OR REPLACE FUNCTION public.fn_eugetkasutamaizu_bakodo(
    atenano_in character varying          --宛名番号
    ,riyomokuteki_in character varying    --送付先利用目的
)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$
BEGIN 
    --カスタマーバーコードの郵便番号と住所を取得する
    RETURN (
        SELECT 
            fn_eugetsofusaki_yubin(atenano_in, riyomokuteki_in) || ',' || fn_eugetsofusaki_address(atenano_in, riyomokuteki_in)
    );
END;
$function$;
