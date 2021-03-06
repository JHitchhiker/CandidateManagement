USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_OutcomeYTD]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_REPORT_OutcomeYTD]
AS
declare @total numeric(10,2);
declare @startdate datetime;
declare @enddate datetime;

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);

set @total = cast((select count(id) from interviewees where interviewdate between @startdate and @enddate) as numeric(10,2))

--SELECT case when outcomes.Name = 'CONVERTED' then 'SIGNED UP' else outcomes.name end outcome, Count(interviewees.id) ctr
--	FROM Interviewees
--	INNER JOIN Outcomes on Outcomes.Id = OutcomeId

SELECT case when outcomes.Name = 'CONVERTED' then 'SIGNED UP' else outcomes.name end outcome, Count(interviewees.id) ctr, round(count(interviewees.id)/@total*100.00,2) [Percentage]
	FROM Interviewees
	INNER JOIN Outcomes on Outcomes.Id = OutcomeId
	where interviewdate between @startdate and @enddate
	group by case when outcomes.Name = 'CONVERTED' then 'SIGNED UP' else outcomes.name end
	



GO
