/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 接種依頼情報一覧取得
　　　　　　一覧抽出
作成日　　: 2024.06.22
作成者　　: 張
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
CREATE OR REPLACE FUNCTION public.sp_awys00101g_02_head(atenano_in character varying)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
declare 
    total integer;
BEGIN
    SELECT
        count(1) total into total
      FROM
        tt_yssessyuirai A
     WHERE  1 = 1
       AND (atenano_in is null OR A.atenano = atenano_in);

    return total;
	
END$function$
/*==============================body==============================*/
CREATE OR REPLACE FUNCTION public.sp_awys00101g_02_body(atenano_in character varying, orderby_in integer, limit_in integer, offset_in integer)
 RETURNS TABLE(atenano character varying, edano integer, uketukeymd character varying, iraisaki character varying, irairiyu character varying, hogosya_atenano character varying, hogosya_simei character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    return query
    SELECT
       A.atenano
      ,A.edano
      ,A.uketukeymd
      ,A.iraisaki
      ,A.irairiyu
      ,A.hogosya_atenano
      ,A.hogosya_simei
      FROM
        tt_yssessyuirai A
     WHERE  1 = 1
       AND (atenano_in is null OR A.atenano = atenano_in)
     ORDER BY
         case when orderby_in = 0 then A.edano end desc             --枝番            昇順（デフォルト）
        ,case when orderby_in = 1 then A.uketukeymd end             --受付日          昇順
        ,case when orderby_in = -1 then A.uketukeymd end desc       --受付日          降順
        ,case when orderby_in = 2 then A.iraisaki  end              --依頼先          昇順
        ,case when orderby_in = -2 then A.iraisaki end desc         --依頼先          降順
        ,case when orderby_in = 3 then A.irairiyu end               --依頼理由        昇順
        ,case when orderby_in = -3 then A.irairiyu end desc         --依頼理由        降順
        ,case when orderby_in = 4 then A.hogosya_atenano end        --保護者_宛名番号 昇順
        ,case when orderby_in = -4 then A.hogosya_atenano end desc  --保護者_宛名番号 降順
        ,case when orderby_in = 5 then A.hogosya_simei end          --保護者_氏名     昇順
        ,case when orderby_in = -5 then A.hogosya_simei end desc    --保護者_氏名     降順
        
    limit limit_in offset offset_in;

END$function$