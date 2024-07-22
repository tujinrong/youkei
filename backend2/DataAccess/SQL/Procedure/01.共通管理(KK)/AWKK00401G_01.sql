/*******************************************************************
業務名称　: 互助防疫システム
機能概要　: フォロー管理
　　　　　　一覧抽出(内容画面)
作成日　　: 2023.11.27
作成者　　: cnc
変更履歴　:
*******************************************************************/
create or replace function sp_awkk00401g_01(atenano_in character varying, haakujigyocds_in character varying)
 returns table(
              follownaiyoedano_naiyo integer,
              haakukeiro_naiyo character varying, 
              haakujigyocd_naiyo character varying, 
              follownaiyo_naiyo character varying, 
              followstatus_naiyo character varying, 
              followjigyocd_naiyo character varying, 
              followyoteiymd_naiyo character varying, 
              followtm_yotei_naiyo character varying, 
              followkaijocd_yotei_naiyo character varying, 
              followstaffid_yotei_naiyo character varying, 
              followjissiymd_naiyo character varying, 
              followtm_naiyo character varying,
              followkaijocd_naiyo character varying, 
              followstaffid_naiyo character varying)
 language plpgsql
as $function$
declare haakujigyocds text[];  --フォロー把握事業コード

begin
    haakujigyocds = string_to_array(haakujigyocds_in, ',');
	return query
	select 
         tt.follownaiyoedano          as follownaiyoedano_naiyo        --フォロー内容枝番
        ,tt.haakukeiro                as haakukeiro_naiyo              --把握経路
        ,tt.haakujigyocd              as haakujigyocd_naiyo            --フォロー把握事業コード
        ,tt.follownaiyo               as follownaiyo_naiyo             --フォロー内容
        ,tt.followstatus              as followstatus_naiyo            --フォロー状況
        ,tt.followjigyocd             as followjigyocd_naiyo           --フォロー事業コード
        ,tt.followyoteiymd            as followyoteiymd_naiyo          --フォロー予定日
        ,tt.followtm_yotei            as followtm_yotei_naiyo          --フォロー時間
        ,tt.kaijonm_yotei             as followkaijocd_yotei_naiyo     --フォロー予定情報  会場名
        ,tt.staffsimei_yotei          as followstaffid_yotei_naiyo     --フォロー予定情報  事業従事者氏名
        ,tt.followjissiymd            as followjissiymd_naiyo          --実施日
        ,tt.followtm                  as followtm_naiyo                --時間
        ,tt.kaijonm                   as followkaijocd_naiyo           --フォロー結果情報  会場名
        ,tt.staffsimei                as followstaffid_naiyo           --フォロー結果情報  事業従事者氏名
 from (
      select
           t1.atenano,                                                                  --宛名番号
           t1.follownaiyoedano,                                                         --フォロー内容枝番
           t1.haakukeiro,                                                               --把握経路
           t1.haakujigyocd,                                                             --フォロー把握事業コード
           t1.follownaiyo,                                                              --フォロー内容
           t1.followstatus,                                                             --フォロー状況
           t2.followjigyocd,                                                            --フォロー事業コード
           t2.followyoteiymd,                                                           --フォロー予定日
           t2.followtm_yotei,                                                           --フォロー予定情報  時間  
           t4.kaijonm as kaijonm_yotei,                                                 --フォロー予定情報  会場名
           t5.staffsimei as staffsimei_yotei,                                           --フォロー予定情報  事業従事者氏名
           t2.followjissiymd,                                                           --実施日
           t2.followtm,                                                                 --時間
           t6.kaijonm,                                                                  --フォロー結果情報  会場名
           t7.staffsimei                                                                --フォロー結果情報  事業従事者氏名  
      from (
          select
               atenano,                                                                 --宛名番号
               follownaiyoedano,                                                        --フォロー内容枝番
               haakukeiro,                                                              --把握経路
               haakujigyocd,                                                            --フォロー把握事業コード
               follownaiyo,                                                             --フォロー内容
               followstatus,                                                            --フォロー状況
               row_number() over (partition by atenano order by follownaiyoedano desc) as row_num
          from
              tt_kkfollownaiyo                                                          --フォロー内容情報テーブル
          where haakujigyocds_in is null or haakujigyocd = any(haakujigyocds)           --フォロー把握事業コード  共通バーから制御がある
      ) as t1
      left join (
          select
               t.atenano,                                                               --宛名番号
               t.follownaiyoedano,                                                      --フォロー内容枝番
               t.followyoteiymd,                                                        --フォロー予定日
               t.followtm_yotei,                                                        --時間  フォロー予定
               t.followjigyocd,                                                         --フォロー事業コード
               t.followjissiymd,                                                        --実施日
               t.followtm,                                                              --時間
               t.followkaijocd_yotei,                                                   --フォロー予定情報  フォロー会場コード
               t.followstaffid_yotei,                                                   --フォロー予定情報  フォロー担当者
               t.followkaijocd,                                                         --フォロー会場コード
               t.followstaffid                                                          --フォロー担当者
          from (
              select
                  coalesce(a1.atenano, a2.atenano) atenano,                             --宛名番号
                  coalesce(a1.follownaiyoedano, a2.follownaiyoedano) follownaiyoedano,  --フォロー内容枝番
                  a1.followyoteiymd,                                                    --フォロー予定日
                  a1.followtm as followtm_yotei,                                        --時間  フォロー予定
                  a2.followjigyocd,                                                     --フォロー事業コード
                  a2.followjissiymd,                                                    --実施日
                  a2.followtm,                                                          --時間
                  a1.followkaijocd as followkaijocd_yotei,                              --フォロー会場コード  フォロー予定
                  a1.followstaffid as followstaffid_yotei,                              --フォロー担当者  フォロー予定
                  a2.followkaijocd,                                                     --フォロー会場コード
                  a2.followstaffid,                                                     --フォロー担当者
                  row_number() over (partition by a1.atenano, a1.follownaiyoedano order by greatest(a1.edano, a2.edano) desc) as row_num
              from (
                  select
                       atenano,                                                         --宛名番号
                       follownaiyoedano,                                                --フォロー内容枝番
                       edano,                                                           --枝番
                       followyoteiymd,                                                  --フォロー予定日
                       followtm,                                                        --時間
                       followkaijocd,                                                   --フォロー会場コード
                       followstaffid                                                    --フォロー担当者
                  from                                                                 
                     tt_kkfollowyotei                                                   --フォロー予定情報テーブル
              ) as a1
              full join (
                  select
                       atenano,                                                         --宛名番号
                       follownaiyoedano,                                                --フォロー内容枝番
                       edano,                                                           --枝番
                       followjigyocd,                                                   --フォロー事業コード
                       followjissiymd,                                                  --実施日
                       followtm,                                                        --時間
                       followkaijocd,                                                   --フォロー会場コード
                       followstaffid                                                    --フォロー担当者
                  from                                                               
                     tt_kkfollowkekka                                                   --フォロー結果情報テーブル
              ) as a2                                                                
              on a1.atenano = a2.atenano                                                --宛名番号
                 and a1.follownaiyoedano = a2.follownaiyoedano                          --フォロー内容枝番
                 and a1.edano = a2.edano                                                --枝番         
          ) as t                                                                     
          where t.row_num = 1                                                        
      ) t2                                                                           
      on t1.atenano = t2.atenano                                                        --宛名番号
         and t1.follownaiyoedano = t2.follownaiyoedano                                  --フォロー内容枝番
     left join tm_afkaijo t4
            on t2.followkaijocd_yotei = t4.kaijocd
     left join tm_afstaff t5
            on t2.followstaffid_yotei = t5.staffid
     left join tm_afkaijo t6
            on t2.followkaijocd = t6.kaijocd
     left join tm_afstaff t7
            on t2.followstaffid = t7.staffid
     ) tt
     where tt.atenano = atenano_in                                                      --宛名番号
     order by
           tt.follownaiyoedano;                                                         --フォロー内容枝番
end;
$function$