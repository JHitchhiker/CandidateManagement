USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_OiginatorOutcomes]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[usp_REPORT_OiginatorOutcomes]
AS
declare @cols nvarchar(max);
declare @query nvarchar(max);

declare @startdate datetime;
declare @enddate datetime;

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);

set @cols = ''

select @cols = @cols + quotename(fld1) + ',' FROM (select distinct Outcomes.Name fld1 from outcomes) as tmp
select @cols = substring(@cols, 0, len(@cols)) 
print @cols

SELECT *
into #PVT
from
(
    select outcomes.description outcome, Originators.name Originator, 1 ctr 
	from interviewees
	inner join Originators on Originators.Id = OriginatorId
	inner join outcomes on outcomes.id = outcomeid
	where interviewdate between @startdate and @enddate
) src
pivot 
(
    count(ctr) for outcome in ([CONVERTED],[CXD],[Decline],[Experience Required],[NO SHOW],[NTU],[Pending],[Reschedule],[SIGNED UP],[T2 No],[T2 Potential],[T2 Yes]
)
) piv;

select 
Originator,
[CXD],
[Decline],
[CONVERTED],
[Experience Required] EXPREQ,
[NO SHOW] NOSHOW,
[NTU],
[Pending],
[Reschedule],
[SIGNED UP] SIGNEDUP,
[T2 No] T2NO,
[T2 Potential] T2POTENTIAL,
[T2 Yes] T2YES,
[CXD]+[Decline]+
converted+[Experience Required]+
[NO SHOW]+[NTU]+[Pending]+
[Reschedule]+[SIGNED UP] +
[T2 No] +[T2 Potential] +[T2 Yes] TOTAL
INTO #DATA
from #PVT

DECLARE @TOTAL INT;
SET @TOTAL = (SELECT SUM(TOTAL) FROM #DATA)

select 

Originator,
[CXD], 
[Decline],
[EXPREQ],
[NOSHOW],
[NTU],
[Pending],
[Reschedule],
[CONVERTED]+
[SIGNEDUP] SIGNEDUP,
[T2No],
T2POTENTIAL,
[T2Yes],
TOTAL, 
CAST((TOTAL*100/@TOTAL*100)/100 AS NUMERIC(10,2)) [PERCENTAGE],
cast((signedup+CONVERTED*100/total*100)/100 as numeric(10,2)) SIGNUPPERCENTAGE
from #DATA
union all

select 

'TOTAL',
sum([CXD]), 
sum([Decline]),
sum([EXPREQ]),
sum([NOSHOW]),
sum([NTU]),
sum([Pending]),
sum([Reschedule]),
sum([SIGNEDUP])+sum(Converted),
sum([T2No]),
sum(T2POTENTIAL),
sum([T2Yes]),
sum(TOTAL), 
0,
sum([SIGNEDUP]+CONVERTED*1.00)/SUM([TOTAL]*1.00)*100 
from #DATA


Drop table #PVT
DROP TABLE #DATA




GO
