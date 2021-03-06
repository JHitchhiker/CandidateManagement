USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_AnnualConversions]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[usp_REPORT_AnnualConversions]
AS

declare @query nvarchar(max);
declare @startdate datetime;
declare @enddate datetime;
declare @finyear varchar(20);

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);
set @finyear = (select max([year]) from financialyears)

select * into #conversions from
(SELECT @finyear FinYear,
Sum(Apr) Apr,
Sum(May) May,
Sum(Jun) Jun,
Sum(Jul) Jul,
Sum(Aug) Aug,
Sum(Sep) Sep,
sum(apr)+sum(may)+sum(jun)+sum(jul)+sum(aug)+sum(sep) HalfYear,
Sum(Oct) Oct,
Sum(Nov) Nov,
Sum(Dec) [Dec],
Sum(Jan) Jan,
Sum(Feb) Feb,
Sum(Mar) Mar,
sum(Apr)+sum(May)+sum(Jun)+sum(Jul)+sum(Aug)+sum(Sep)+sum(Oct)+sum(Nov)+sum(Dec)+sum(Jan)+sum(Feb)+sum(Mar)
 Total, cast(0. as numeric(10,2)) Conversion FROM 
(
SELECT * 
from 
(
    select Outcomes.name outcome, left(datename(month, interviewdate),3) Mth, 1 ctr 
	from interviewees
	inner join Outcomes on Outcomes.id = OutcomeId
	where interviewdate between @startdate and @enddate
) src
pivot 
(
    count(ctr) for Mth in (Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec, Jan, Feb, Mar)
) piv
) a
union all

SELECT 'Sign Ups',
Sum(Apr) Apr,
Sum(May) May,
Sum(Jun) Jun,
Sum(Jul) Jul,
Sum(Aug) Aug,
Sum(Sep) Sep,
sum(apr)+sum(may)+sum(jun)+sum(jul)+sum(aug)+sum(sep) HalfYear,
Sum(Oct) Oct,
Sum(Nov) Nov,
Sum(Dec) [Dec],
Sum(Jan) Jan,
Sum(Feb) Feb,
Sum(Mar) Mar,
sum(Apr)+sum(May)+sum(Jun)+sum(Jul)+sum(Aug)+sum(Sep)+sum(Oct)+sum(Nov)+sum(Dec)+sum(Jan)+sum(Feb)+sum(Mar)
 Total,0.00 FROM 
(
SELECT * 
from 
(
    select Outcomes.name outcome, left(datename(month, interviewdate),3) Mth, 1 ctr 
	from interviewees
	inner join Outcomes on Outcomes.id = OutcomeId
	where interviewdate between @startdate and @enddate
	and outcomes.name in ('CONVERTED', 'Signed Up')
) src
pivot 
(
    count(ctr) for Mth in (Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec, Jan, Feb, Mar)
) piv
) a) c

declare @total int;
declare @sign int;
set @total = (select total from #conversions where finyear != 'Sign Ups')
set @sign = (select total from #conversions where finyear = 'Sign Ups')

update #conversions set conversion = cast((@sign*100/@total*100)/100 as numeric(10,2)) where finyear = 'Sign Ups'
select * from annualsignups
union all
select * from #conversions 

drop table #conversions

GO
