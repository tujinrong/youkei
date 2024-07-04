/*******************************************************************
業務名称　: 健康管理システム
機能概要　: フォロー管理
　　　　　　一覧抽出(結果画面)
作成日　　: 2023.11.27
作成者　　: cnc劉
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00401g_02(atenano_in character varying, 
                                                 follownaiyoedano_in integer)
 returns table(
             atenano_kekka character varying,
             follownaiyoedano_kekka integer,
             edano_kekka integer, 
             followjigyocd_kekka character varying, 
             followhoho_yotei_kekka character varying, 
             followyoteiymd_kekka character varying, 
             followtm_yotei_kekka character varying, 
             followkaijocd_yotei_kekka character varying, 
             followstaffid_yotei_kekka character varying, 
             followriyu_kekka character varying, 
             followhoho_kekka character varying, 
             followjissiymd_kekka character varying, 
             followtm_kekka character varying, 
             followkaijocd_kekka character varying, 
             followstaffid_kekka character varying,
             followkekka_kekka character varying)
 language plpgsql
as $function$
begin
	return query
	select 
       t1.atenano                            as atenano_kekka                       --宛名番号
      ,t1.follownaiyoedano                   as follownaiyoedano_kekka              --フォロー内容枝番
      ,t2.edano                              as edano_kekka                         --枝番
      ,t2.followjigyocd                      as followjigyocd_kekka                 --フォロー事業コード
      ,t2.followhoho                         as followhoho_yotei_kekka              --フォロー予定情報  フォロー方法
      ,t2.followyoteiymd                     as followyoteiymd_kekka                --フォロー予定情報  フォロー予定日
      ,t2.followtm                           as followtm_yotei_kekka                --フォロー結果情報  フォロー時間
      ,t4.kaijonm                            as followkaijocd_yotei_kekka           --フォロー予定情報  会場名
      ,t5.staffsimei                         as followstaffid_yotei_kekka           --フォロー予定情報  事業従事者氏名
      ,t2.followriyu                         as followriyu_kekka                    --フォロー予定情報  フォロー理由
      ,t3.followhoho                         as followhoho_kekka                    --フォロー結果情報  フォロー方法
      ,t3.followjissiymd                     as followjissiymd_kekka                --フォロー結果情報  フォロー実施日
      ,t3.followtm                           as followtm_kekka                      --フォロー結果情報  フォロー時間
      ,t6.kaijonm                            as followkaijocd_kekka                 --フォロー結果情報  会場名
      ,t7.staffsimei                         as followstaffid_kekka                 --フォロー結果情報  事業従事者氏名
      ,t3.followkekka                        as followkekka_kekka                   --フォロー結果情報  フォロー結果
    from tt_kkfollownaiyo t1
    left join tt_kkfollowyotei t2
           on t1.atenano = t2.atenano
           and t1.follownaiyoedano = t2.follownaiyoedano
    left join tt_kkfollowkekka t3
           on t1.atenano = t3.atenano
           and t1.follownaiyoedano = t3.follownaiyoedano
           and t2.edano = t3.edano
    left join tm_afkaijo t4
           on t2.followkaijocd = t4.kaijocd
    left join tm_afstaff t5
           on t2.followstaffid = t5.staffid
    left join tm_afkaijo t6
           on t3.followkaijocd = t6.kaijocd
    left join tm_afstaff t7
           on t3.followstaffid = t7.staffid
    where 
		t1.atenano = atenano_in				           --宛名番号
        and t1.follownaiyoedano = follownaiyoedano_in  --フォロー内容枝番
	order by
           t3.followjissiymd desc nulls first,
           case when coalesce(t3.followtm, '') = '' then '0000' else t3.followtm end desc,
           t2.followyoteiymd desc nulls first,
           case when coalesce(t2.followtm, '') = '' then '0000' else t2.followtm end desc,
           t2.edano desc;
end;
$function$