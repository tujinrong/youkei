CREATE OR REPLACE FUNCTION public.euc_af_getage(bymd character varying, reference date)
 RETURNS int
 LANGUAGE plpgsql
AS $function$ 
declare sy char(4);
declare sm char(2);
declare sd char(2);
declare iy int;
declare im int; 
declare id int;
declare iy2 int;
declare im2 int;
declare id2 int;
BEGIN
    IF reference IS NULL THEN
        iy2=EXTRACT(YEAR FROM current_date);	
        im2=EXTRACT(MONTH FROM current_date);	
        id2=EXTRACT(DAY FROM current_date);	
    ELSE
        iy2=EXTRACT(YEAR FROM reference);	
        im2=EXTRACT(MONTH FROM reference);	
        id2=EXTRACT(DAY FROM reference);	
    END IF;
    
    IF bymd IS NULL THEN
       RETURN -1; 
    END IF;
    
    sy=LEFT(bymd, 4);
    if sy='0000' then
        RETURN -1;
    END IF;
    iy=CAST(sy AS integer);

    
    sm=SUBSTRING(bymd FROM 6 FOR 2);
    IF sm IN('A1','A2', 'A3', 'A4') THEN
        RETURN iy2-iy;
    END IF;
     
    im=CAST(sm AS integer);
    
    
    sd=RIGHT(bymd, 2);
    IF sd='A1' THEN
        IF im2>=im THEN
          return iy2-iy;
        ELSE
          return iy2-iy-1;
        END IF;
    END IF;
    
    id=CAST(sd AS integer);
    
    IF im2*id2>=im*id THEN
      return iy2-iy;
    ELSE
      return iy2-iy-1;
    END IF;

EXCEPTION WHEN others THEN
  RETURN -1;
END; 

$function$