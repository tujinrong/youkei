/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: 帳票データグループ一覧
　　　　　　一覧抽出
作成日　　: 2024.03.12
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_aweu00101g_01_head(gyoumucd_in character varying, datasourcenm_in character varying, nmmaincd_in character varying, nmsubcd_in integer) returns integer
    language plpgsql
as
$$
declare
    total integer;
begin
    select count(t1.datasourceid)
    into total
    from tm_eudatasource t1 --EUCデータソースマスタ
    where (gyoumucd_in is null or t1.gyoumucd = gyoumucd_in) --業務コード
      and (datasourcenm_in is null or datasourcenm ilike datasourcenm_in); --データソース名称
    return total;
end;
$$;

/*==============================body==============================*/
create or replace function sp_aweu00101g_01_body(gyoumucd_in character varying, datasourcenm_in character varying, nmmaincd_in character varying, nmsubcd_in integer, orderby_in integer,
                                                 limit_in integer, offset_in integer)
    returns TABLE
            (
                datasourceid     character varying,
                datasourcenm     character varying,
                gyoumu           character varying,
                maintablehyojinm character varying,
                maintablenm      character varying
            )
    language plpgsql
as
$$
begin
    return query
        select t1.datasourceid as datasourceid,     --データソースID
               t1.datasourcenm as datasourcenm,     --データソース名称
               t3.nm           as gyoumu,           --業務
               t2.tablehyojinm as maintablehyojinm, --メインテーブル名称
               t2.tablenm      as maintablenm       --メインテーブル物理名
        from tm_eudatasource t1 --EUCデータソースマスタ
                 left join tm_eutable t2 --EUCテーブルマスタ
                           on t1.maintablealias = t2.tablealias
                 left join tm_afmeisyo t3
                           on t1.gyoumucd = t3.nmcd
        where t3.nmmaincd = nmmaincd_in
          and t3.nmsubcd = nmsubcd_in
          and (gyoumucd_in is null or t1.gyoumucd = gyoumucd_in)                 --業務コード
          and (datasourcenm_in is null or t1.datasourcenm ilike datasourcenm_in) --データソース名称
        order by 
                 case when orderby_in = 1 then t1.datasourceid end,                                         --データソースID  昇順
                 case when orderby_in = -1 then t1.datasourceid end desc,                                   --データソースID  降順
                 case when orderby_in = 2 then t1.datasourcenm end,                                         --データソース名称  昇順
                 case when orderby_in = -2 then t1.datasourcenm end desc,                                   --データソース名称  降順
                 case when orderby_in = 3 then t3.nm end,                                                   --業務  昇順
                 case when orderby_in = -3 then t3.nm end desc,                                             --業務  降順
                 case when orderby_in = 4 then t2.tablehyojinm end,                                         --メインテーブル名称  昇順
                 case when orderby_in = -4 then t2.tablehyojinm end desc,                                   --メインテーブル名称  降順
                 case when orderby_in = 5 then t2.tablenm end,                                              --メインテーブル物理名  昇順
                 case when orderby_in = -5 then t2.tablenm end desc,                                        --メインテーブル物理名  降順
                 t1.orderseq, t1.datasourceid                                                               --並び順  降順
        limit limit_in offset offset_in;
end;
$$;
