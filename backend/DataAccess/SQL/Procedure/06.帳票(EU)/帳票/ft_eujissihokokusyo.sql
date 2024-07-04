/*******************************************************************
業務名称　: 健康管理システム
機能概要　: 事業実施報告書（日報）
　　　　　　
作成日　　: 2024.04.15
作成者　　: 屠
変更履歴　:
*******************************************************************/
CREATE OR REPLACE FUNCTION ft_eujissihokokusyo(
    hokokusyono_in bigint,  --事業報告書番号	
    jissiymdf_in varchar,   --実施日（開始）	
    jissiymdt_in varchar,   --実施日（終了）	
    jigyocd_in varchar,     --事業実施報告書（日報）事業ＣＤ
    kaijocd_in varchar,     --会場ＣＤ
    staffid_in varchar      --事業従事者ID
    )
 RETURNS TABLE(
hokokusyono     bigint,         --事業報告書番号
jigyocd         varchar,        --事業実施報告書（日報）事業ＣＤ
jigyonm         varchar,        --事業実施報告書（日報）事業
jigyoucdnm      varchar,        --事業実施報告書（日報）事業（ＣＤ：名称）
kaijocd         varchar,        --会場ＣＤ
kaijonm         varchar,        --会場
kaijocdnm       varchar,        --会場（ＣＤ：名称）
jissiymd        varchar,        --実施日
jissiym_wareki  varchar,        --実施日（和暦）
jissiymd_nengetsu varchar,      --実施年月（和暦）
timef           varchar,        --開始時間
timet           varchar,        --終了時間
syussekisya     integer,        --出席者数
jissinaiyo      varchar,        --実施内容
haifusiryo      varchar,        --配布資料
baitai          varchar,        --媒体
mantotalnum     integer,        --男性延べ人数
womantotalnum   integer,        --女性延べ人数
fumeitotalnum   integer,        --性別不明延べ人数
mannum          integer,        --男性実人数
womannum        integer,        --女性実人数
fumeinum        integer,        --性別不明実人数
comment         varchar,        --コメント
hanseipoint     varchar,        --反省点
jigyomokuteki   varchar,        --事業目的
staffsimei1     varchar,        --事業従事者氏名1
syokusyunm1     varchar,        --職種1
staffsimei2     varchar,        --事業従事者氏名2
syokusyunm2     varchar,        --職種2
staffsimei3     varchar,        --事業従事者氏名3
syokusyunm3     varchar,        --職種3
staffsimei4     varchar,        --事業従事者氏名4
syokusyunm4     varchar,        --職種4
staffsimei5     varchar,        --事業従事者氏名5
syokusyunm5     varchar,        --職種5
staffsimei6     varchar,        --事業従事者氏名6
syokusyunm6     varchar,        --職種6
staffsimei7     varchar,        --事業従事者氏名7
syokusyunm7     varchar,        --職種7
staffsimei8     varchar,        --事業従事者氏名8
syokusyunm8     varchar,        --職種8
staffsimei9     varchar,        --事業従事者氏名9
syokusyunm9     varchar,        --職種9
staffsimei10    varchar,        --事業従事者氏名10
syokusyunm10    varchar,        --職種10
staffcnt        integer         --従事者人数
)
LANGUAGE plpgsql
AS $function$
BEGIN
    -----------------------------------------------
    --Crosstabのインストール
    -----------------------------------------------
   CREATE EXTENSION IF NOT EXISTS tablefunc;
    
    -----------------------------------------------
    --抽出SQL
    -----------------------------------------------
   RETURN query
       SELECT
            T1.hokokusyono      hokokusyono,        --事業報告書番号
            T1.jigyocd          jigyocd,            --事業実施報告書（日報）事業ＣＤ
            M12.nm 		        jigyonm,            --事業実施報告書（日報）事業
            CAST((T1.jigyocd  || ' : ' || M12.nm)AS varchar)jigyoucdnm,  --事業実施報告書（日報）事業（ＣＤ：名称）
            T1.kaijocd          kaijocd,            --会場ＣＤ
            M11.kaijonm         kaijonm,            --会場
            CAST((T1.kaijocd || ' : ' ||M11.kaijonm)AS varchar)    kaijocdnm,  --会場（ＣＤ：名称）
            CAST(T1.jissiymd AS varchar) jissiymd,   --実施日
            fn_euchangewareki(T1.jissiymd) jissiymd_wareki,--実施日（和暦）
            CAST( SUBSTRING(fn_euchangewareki(T1.jissiymd) , 1 , POSITION('月' IN fn_euchangewareki(T1.jissiymd))) AS varchar) jissiym_wareki, --実施年月（和暦）	
            CAST(T1.timef AS varchar)timef,         --開始時間	
            CAST(T1.timet AS varchar)timet,         --終了時間			
            T1.syussekisya      syussekisya,        --出席者数			
            T1.jissinaiyo       jissinaiyo,         --実施内容			
            T1.haifusiryo       haifusiryo,         --配布資料			
            T1.baitai           baitai,             --媒体		
            T1.mantotalnum      mantotalnum,        --男性延べ人数	
            T1.womantotalnum    womantotalnum,      --女性延べ人数			
            T1.fumeitotalnum    fumeitotalnum,      --性別不明延べ人数		
            T1.mannum           mannum,             --男性実人数			
            T1.womannum         womannum,           --女性実人数		
            T1.fumeinum         fumeinum,           --性別不明実人数		
            T1.comment          comment,            --コメント			
            T1.hanseipoint      hanseipoint,        --反省点		
            T1.jigyomokuteki    jigyomokuteki,      --事業目的	
            		
            S1.staffsimei    staffsimei1, --事業従事者氏名1
            M1.nm            syokusyunm1, --職種1
            S2.staffsimei    staffsimei2, --事業従事者氏名2
            M2.nm            syokusyunm2, --職種2
            S3.staffsimei    staffsimei3, --事業従事者氏名3  
            M3.nm            syokusyunm3, --職種3
            S4.staffsimei    staffsimei4, --事業従事者氏名4 
            M4.nm            syokusyunm4, --職種4
            S5.staffsimei    staffsimei5, --事業従事者氏名5 
            M5.nm            syokusyunm5, --職種5
            S6.staffsimei    staffsimei6, --事業従事者氏名6 
            M6.nm            syokusyunm6, --職種6
            S7.staffsimei    staffsimei7, --事業従事者氏名7  
            M7.nm            syokusyunm7, --職種7
            S8.staffsimei    staffsimei8, --事業従事者氏名8  
            M8.nm            syokusyunm8, --職種8
            S9.staffsimei    staffsimei9, --事業従事者氏名9  
            M9.nm            syokusyunm9, --職種9
            S10.staffsimei   staffsimei10,--事業従事者氏名10  
            M10.nm           syokusyunm10,--職種10
            CAST(T3.staffcnt  AS integer) staffcnt  --従事者人数
           
        -----------------------------------------------
        --結合テーブル
        -----------------------------------------------
        FROM tt_kkjissihokokusyo T1
        --実施報告書（日報）情報サブテーブル（事業従事者氏名、職種を取得）
        --cross table 
        LEFT JOIN (SELECT * FROM crosstab(
            'SELECT t1.hokokusyono ,ROW_NUMBER() OVER (PARTITION BY t1.hokokusyono ORDER BY staffid) rowno,staffid
            FROM tt_kkjissihokokusyo_sub t1 ORDER BY 1,2') AS pvt(
          hokokusyono bigint,
          cd1 varchar(10),cd2 varchar(10),cd3 varchar(10),cd4 varchar(10),cd5 varchar(10),
          cd6 varchar(10),cd7 varchar(10),cd8 varchar(10),cd9 varchar(10),cd10 varchar(10))
          ) T2
        ON T1.hokokusyono = T2.hokokusyono
        LEFT JOIN tm_afstaff S1 ON T2.cd1 = S1.staffid	LEFT JOIN tm_afmeisyo M1 ON S1.syokusyu= M1.nmcd AND M1.nmmaincd='2019' AND M1.nmsubcd=2 				
        LEFT JOIN tm_afstaff S2 ON T2.cd2 = S2.staffid	LEFT JOIN tm_afmeisyo M2 ON S2.syokusyu= M2.nmcd AND M2.nmmaincd='2019' AND M2.nmsubcd=2 				
        LEFT JOIN tm_afstaff S3 ON T2.cd3 = S3.staffid	LEFT JOIN tm_afmeisyo M3 ON S3.syokusyu= M3.nmcd AND M3.nmmaincd='2019' AND M3.nmsubcd=2 				
        LEFT JOIN tm_afstaff S4 ON T2.cd4 = S4.staffid	LEFT JOIN tm_afmeisyo M4 ON S4.syokusyu= M4.nmcd AND M4.nmmaincd='2019' AND M4.nmsubcd=2 				
        LEFT JOIN tm_afstaff S5 ON T2.cd5 = S5.staffid	LEFT JOIN tm_afmeisyo M5 ON S5.syokusyu= M5.nmcd AND M5.nmmaincd='2019' AND M5.nmsubcd=2 				
        LEFT JOIN tm_afstaff S6 ON T2.cd6 = S6.staffid	LEFT JOIN tm_afmeisyo M6 ON S6.syokusyu= M6.nmcd AND M6.nmmaincd='2019' AND M6.nmsubcd=2 				
        LEFT JOIN tm_afstaff S7 ON T2.cd7 = S7.staffid	LEFT JOIN tm_afmeisyo M7 ON S7.syokusyu= M7.nmcd AND M7.nmmaincd='2019' AND M7.nmsubcd=2 				
        LEFT JOIN tm_afstaff S8 ON T2.cd8 = S8.staffid	LEFT JOIN tm_afmeisyo M8 ON S8.syokusyu= M8.nmcd AND M8.nmmaincd='2019' AND M8.nmsubcd=2 				
        LEFT JOIN tm_afstaff S9 ON T2.cd9 = S9.staffid	LEFT JOIN tm_afmeisyo M9 ON S9.syokusyu= M9.nmcd AND M9.nmmaincd='2019' AND M9.nmsubcd=2 				
        LEFT JOIN tm_afstaff S10 ON T2.cd10 = S10.staffid	LEFT JOIN tm_afmeisyo M10 ON S10.syokusyu= M10.nmcd AND M10.nmmaincd='2019' AND M10.nmsubcd=2
        --会場マスタ（会場名を取得）
        LEFT JOIN tm_afkaijo M11 ON T1.kaijocd = M11.kaijocd
        LEFT JOIN tm_afhanyo M12 ON T1.jigyocd = M12.hanyocd AND M12.hanyomaincd = '3019' AND M12.hanyosubcd=100004
        LEFT JOIN (SELECT t2.hokokusyono, COUNT(*) staffcnt FROM tt_kkjissihokokusyo_sub t2 GROUP BY t2.hokokusyono) T3 
        ON  T1.hokokusyono = T3.hokokusyono
    -----------------------------------------------
    --検索条件
    -----------------------------------------------
    WHERE (hokokusyono_in IS NULL OR T1.hokokusyono=hokokusyono_in)
      AND (jissiymdf_in IS NULL OR T1.jissiymd >= jissiymdf_in)	
      AND (jissiymdt_in IS NULL OR T1.jissiymd <= jissiymdt_in)
      AND (jigyocd_in IS NULL OR T1.jigyocd = jigyocd_in)
      AND (kaijocd_in IS NULL OR T1.kaijocd = kaijocd_in)
      AND (staffid_in IS NULL OR T1.hokokusyono IN (SELECT t3.hokokusyono FROM tt_kkjissihokokusyo_sub t3 WHERE staffid=staffid_in))
      
    -----------------------------------------------
    --並び替え
    -----------------------------------------------
    ORDER BY T1.hokokusyono, T1.jissiymd, T1.kaijocd;
END;
$function$

