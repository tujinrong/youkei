/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 各種検診対象者保守
　　　　　　初期化処理
作成日　　: 2024.02.06
作成者　　: 
変更履歴　:
*******************************************************************/
create or replace function sp_awsh00302g_01(nendo_in integer, atenano_in character varying)
returns table
  (nendo smallint,
   jigyocd character varying,
   kensahohocd character varying,
   atenano character varying,
   taisyoflg character varying)
  language plpgsql
as $function$  
begin
    return query execute format('
        select 
            nendo::smallint, 
            jigyocd::character varying,
            kensahohocd::character varying,
            atenano::character varying,
            taisyoflg::character varying
        from tt_shkensinrirekikanri_%s
        where nendo = %s 
        and atenano = ''%s''', nendo_in, nendo_in, atenano_in);
end;
$function$