    /*******************************************************************
    業務名称　: 互助防疫システム
    機能概要　: 指定された宛名番号に対応する送付先氏名の状態を取得する
　　　　　　
    作成日　　: 2024.04.23
    作成者　　: 呉
    変更履歴　:
    *******************************************************************/

    CREATE OR REPLACE FUNCTION fn_eugetjuminbiko(atenano_in character varying)
     RETURNS character varying
     LANGUAGE plpgsql
    AS $function$
    DECLARE
        --sien boolean;
       sien varchar; 
    BEGIN
         SELECT siensotikbn INTO sien FROM tt_afatena WHERE atenano = atenano_in;
         IF sien is null or sien='' THEN
            --送付先氏名が存在する場合は送付先氏名を表示
            RETURN '';
        ELSE
           RETURN '拒';
        END IF;
    END;

    $function$