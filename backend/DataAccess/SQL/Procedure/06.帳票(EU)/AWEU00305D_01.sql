/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 帳票出力履歴画面
　　　　　　一覧抽出
作成日　　: 2024.03.12
作成者　　: 蔣
変更履歴　:
*******************************************************************/
/*==============================head==============================*/
create or replace function sp_aweu00305d_01_head(rptid_in character varying, yosikiid_in character varying, jyotaikbn_in character varying) returns integer
    language plpgsql
as
$$
declare
    total integer;
begin
    select count(t1.rirekiseq)
    into total
    from tt_eurireki t1
    where t1.rptid = rptid_in
      and t1.yosikiid = yosikiid_in;
    return total;
end;
$$;

/*==============================body==============================*/
create or replace function sp_aweu00305d_01_body(rptid_in character varying, yosikiid_in character varying, jyotaikbn_in character varying, orderby_in integer, limit_in integer, offset_in integer)
    returns table
            (
                regdttm    timestamp without time zone,
                regusernm  character varying,
                jyotaikbn  character varying,
                syoridttmf timestamp without time zone,
                outputkbn  smallint,
                num        integer,
                jyoken     character varying,
                memo       character varying,
                fileflg    boolean,
                rirekiseq  bigint
            )
    language plpgsql
as
$$
begin
    return query
        with jyoken_sorted as (select te.rirekiseq                                                                          as rirekiseq,
                                      (select string_agg(concat(tj.jyokenlabel, '=', tj.value), E'\n' order by tj.jyokenseq)
                                       from tt_eurirekijyoken tj
                                       where tj.rirekiseq = te.rirekiseq
                                       limit 1) :: varchar                                                                  as jyoken,
                                      (te.jyotaikbn = jyotaikbn_in and te.filedata is not null and length(te.filedata) > 0) as fileflg
                               from tt_eurireki te
                               where te.rptid = rptid_in
                                 and te.yosikiid = yosikiid_in)
        select t1.regdttm    as regdttm,   --登録日時
               t2.usernm     as regusernm, --ユーザー名
               t1.jyotaikbn  as jyotaikbn, --状態区分
               t1.syoridttmf as syoridttmf,--処理日時（開始）
               t1.outputkbn  as outputkbn, --出力方式
               t1.num        as num,       --結果件数
               t3.jyoken     as jyoken,    --条件
               t1.memo       as memo,      --検索条件メモ
               t3.fileflg    as fileflg,   --ファイルフラグ
               t1.rirekiseq  as rirekiseq  --履歴シーケンス
        from tt_eurireki t1
                 left join tm_afuser t2 on t1.reguserid = t2.userid
                 join jyoken_sorted t3 on t1.rirekiseq = t3.rirekiseq
        where t1.rptid = rptid_in
          and t1.yosikiid = yosikiid_in
        order by case when orderby_in not in (1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6, 7, -7, 8, -8, 9, -9) then t1.rirekiseq end desc, --履歴シーケンス 降順
                 case when orderby_in = 1 then t1.regdttm end,                                                                           --登録日時 昇順
                 case when orderby_in = -1 then t1.regdttm end desc,                                                                     --登録日時 降順
                 case when orderby_in = 2 then t2.usernm end,                                                                            --ユーザー名 昇順
                 case when orderby_in = -2 then t2.usernm end desc,                                                                      --ユーザー名 降順
                 case when orderby_in = 3 then t1.jyotaikbn end,                                                                         --状態区分 昇順
                 case when orderby_in = -3 then t1.jyotaikbn end desc,                                                                   --状態区分 降順
                 case when orderby_in = 4 then t1.syoridttmf end,                                                                        --処理日時（開始） 昇順
                 case when orderby_in = -4 then t1.syoridttmf end desc,                                                                  --処理日時（開始） 降順
                 case when orderby_in = 5 then t1.outputkbn end,                                                                         --出力方式 昇順
                 case when orderby_in = -5 then t1.outputkbn end desc,                                                                   --出力方式 降順
                 case when orderby_in = 6 then t1.num end,                                                                               --結果件数 昇順
                 case when orderby_in = -6 then t1.num end desc,                                                                         --結果件数 降順
                 case when orderby_in = 7 then t3.jyoken end,                                                                            --条件 昇順
                 case when orderby_in = -7 then t3.jyoken end desc,                                                                      --条件 降順
                 case when orderby_in = 8 then t1.memo end,                                                                              --検索条件メモ 昇順
                 case when orderby_in = -8 then t1.memo end desc,                                                                        --検索条件メモ 降順
                 case when orderby_in = 9 then t3.fileflg end desc,                                                                      --ファイルフラグ 昇順
                 case when orderby_in = -9 then t3.fileflg end                                                                           --ファイルフラグ 降順
        limit limit_in offset offset_in;
end;
$$;
