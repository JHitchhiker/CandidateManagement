USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_OriginByMonth]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[usp_REPORT_OriginByMonth]
AS


declare @startdate datetime;
declare @enddate datetime;

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);

	select interviewees.* 
	into #interviewees
	from interviewees 
	--where outcomeid in (7,8)

	SELECT * 
	into #pvt
	from 
		(
			select Origins.name Origin, left(datename(month, interviewdate),3) Mth, 1 ctr 
			from #interviewees
			inner join Origins on Origins.id = OriginId
			where interviewdate between @startdate and @enddate
		) src
	pivot 
		(
			count(ctr) for Mth in (Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec, Jan, Feb, Mar)
		) piv

SELECT *,
Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec+Jan+Feb+Mar Total FROM #pvt

union all
SELECT 'Total',
Sum(Apr),
Sum(May),
Sum(Jun),
Sum(Jul),
Sum(Aug),
Sum(Sep),
Sum(Oct),
Sum(Nov),
Sum(Dec),
Sum(Jan),
Sum(Feb),
Sum(Mar),
sum(Apr)+sum(May)+sum(Jun)+sum(Jul)+sum(Aug)+sum(Sep)+sum(Oct)+sum(Nov)+sum(Dec)+sum(Jan)+sum(Feb)+sum(Mar)
 Total FROM 
#pvt

drop table #interviewees
drop table #pvt

GO
