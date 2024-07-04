drop view if exists vw_bhnykensinkekka;

create view vw_bhnykensinkekka(
nykensincd,
atenano,
edano,
maxflg
)
as
SELECT
T1.nykensincd,
T1.atenano,
T1.edano,
CASE WHEN T1.edano = T2.edano THEN true ELSE false END maxflg
FROM tt_bhnykensinkekka T1
LEFT JOIN (SELECT nykensincd,atenano,MAX(edano) edano FROM tt_bhnykensinkekka GROUP BY nykensincd,atenano) T2
 ON T1.nykensincd = T2.nykensincd AND T1.atenano = T2.atenano; 
comment on view vw_bhnykensinkekka.nykensincd is '乳幼児健診コード';
comment on column vw_bhnykensinkekka.atenano is '宛名番号';
comment on column vw_bhnykensinkekka.edano is '枝番';
comment on column vw_bhnykensinkekka.maxflg is '最新フラグ';



/*
--1. 【成人保健】一次検診年度ビュー
drop view if exists vw_eukensin_nendo;

create view vw_eukensin_nendo(
    nendo,
    atenano
)
as
select DISTINCT
    nendo,
    atenano
from tt_shkensin; 
comment on view vw_eukensin_nendo is '【EUC】一次検診年度ビュー';
comment on column vw_eukensin_nendo.nendo is '実施年度';
comment on column vw_eukensin_nendo.atenano is '宛名番号';



--2. 【成人保健】一次検診年度事業ビュー
drop view if exists vw_eukensin_nendojigyo;

create view vw_eukensin_nendojigyo(
    nendo,
    jigyocd,
    atenano
)
as
select DISTINCT
    nendo,
    jigyocd,
    atenano
from tt_shkensin; 
comment on view vw_eukensin_nendojigyo is '【EUC】一次検診年度事業ビュー';
comment on column vw_eukensin_nendojigyo.nendo is '実施年度';
comment on column vw_eukensin_nendojigyo.jigyocd is '事業コード';
comment on column vw_eukensin_nendojigyo.atenano is '宛名番号';

--3. 【成人保健】一次検診年度最大回数ビュー
drop view if exists vw_eukensin_nendomaxkaisu;

create view vw_eukensin_nendomaxkaisu(
    nendo,
    atenano,
    jigyocd,
    kensinkaisu
)
as
select 
    nendo,
    atenano,
    jigyocd,
    max(kensinkaisu) kensinkaisu
from tt_shkensin
group by nendo,jigyocd,atenano;
comment on view vw_eukensin_nendomaxkaisu is '【EUC】一次検診年度最大回数ビュー';
comment on column vw_eukensin_nendomaxkaisu.nendo is '実施年度';
comment on column vw_eukensin_nendomaxkaisu.jigyocd is '事業コード';
comment on column vw_eukensin_nendomaxkaisu.atenano is '宛名番号';
comment on column vw_eukensin_nendomaxkaisu.kensinkaisu is '検診回数';

--4. 【成人保健】精密検査年度ビュー
drop view if exists vw_euseiken_nendo;

create view vw_euseiken_nendo(
    nendo,
    jigyocd,
    atenano
)
as
select DISTINCT
    nendo,
    jigyocd,
    atenano
from tt_shseiken; 
comment on view vw_euseiken_nendo is '【EUC】成人保健精密検査年度ビュー';
comment on column vw_euseiken_nendo.nendo is '実施年度';
comment on column vw_euseiken_nendo.jigyocd is '事業コード';
comment on column vw_euseiken_nendo.atenano is '宛名番号';

--4. 【成人保健】精密検査年度ビュー
drop view if exists vw_euseiken_nendo;

create view vw_euseiken_nendo(
    nendo,
    atenano
)
as
select DISTINCT
    nendo,
    atenano
from tt_shseiken; 
comment on view vw_euseiken_nendo is '【成人保健】精密検査年度ビュー';
comment on column vw_euseiken_nendo.nendo is '実施年度';
comment on column vw_euseiken_nendo.atenano is '宛名番号';

--5. 【成人保健】精密検査年度事業ビュー
drop view if exists vw_euseiken_nendojigyo;

create view vw_euseiken_nendojigyo(
    nendo,
    jigyocd,
    atenano
)
as
select DISTINCT
    nendo,
    jigyocd,
    atenano
from tt_shseiken; 
comment on view vw_euseiken_nendojigyo is '【成人保健】精密検査年度事業ビュー';
comment on column vw_euseiken_nendojigyo.nendo is '実施年度';
comment on column vw_euseiken_nendojigyo.jigyocd is '事業コード';
comment on column vw_euseiken_nendojigyo.atenano is '宛名番号';


--6.成人保健精密検査年度最大回数ビュー
drop view if exists vw_euseiken_nendomaxkaisu;

create view vw_euseiken_nendomaxkaisu(
    nendo,
    jigyocd,
    atenano,
    kensinkaisu
)
as
select 
    nendo,
    jigyocd,
    atenano,
    max(kensinkaisu) kensinkaisu
from tt_shseiken
group by nendo,jigyocd,atenano;
comment on view vw_euseiken_nendomaxkaisu is '【EUC】精密検査年度最大回数ビュー';
comment on column vw_euseiken_nendomaxkaisu.nendo is '実施年度';
comment on column vw_euseiken_nendomaxkaisu.jigyocd is '事業コード';
comment on column vw_euseiken_nendomaxkaisu.atenano is '宛名番号';
comment on column vw_euseiken_nendomaxkaisu.kensinkaisu is '検診回数';

*/