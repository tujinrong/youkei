/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 年度切替
　　　　　　テーブル作成処理
作成日　　: 2024.02.05
作成者　　: 劉
変更履歴　:
*******************************************************************/
create or replace function sp_awsh00304g_02(nendo_in integer)
returns void
language plpgsql
as $function$    
begin
    execute format('
        --検診履歴管理テーブル
        drop table if exists tt_shkensinrirekikanri_%s;
        create table tt_shkensinrirekikanri_%s(
            nendo smallint not null,
            jigyocd varchar(2) not null,
            kensahohocd varchar(2) not null,
            atenano varchar(15) not null,
            taisyoflg varchar(1) not null default 0,
        primary key(nendo,jigyocd,kensahohocd,atenano)
        );
        comment on table tt_shkensinrirekikanri_%s is ''検診履歴管理テーブル（%s年度）'';
        comment on column tt_shkensinrirekikanri_%s.nendo is ''年度'';
        comment on column tt_shkensinrirekikanri_%s.jigyocd is ''検診種別'';
        comment on column tt_shkensinrirekikanri_%s.kensahohocd is ''検査方法コード'';
        comment on column tt_shkensinrirekikanri_%s.atenano is ''宛名番号'';
        comment on column tt_shkensinrirekikanri_%s.taisyoflg is ''一時対象サイン'';
    ', nendo_in, nendo_in, nendo_in, nendo_in, nendo_in, nendo_in, nendo_in, nendo_in, nendo_in);
end;
$function$