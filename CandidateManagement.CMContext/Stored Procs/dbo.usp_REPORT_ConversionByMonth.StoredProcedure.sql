USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_ConversionByMonth]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_REPORT_ConversionByMonth]
AS
	declare @startdate datetime;
	declare @enddate datetime;
	declare @counter int;

	set @startdate = (select max(startdate) from financialyears);
	set @enddate = (select max(enddate) from financialyears);
	
	select min(date) weekstart, max(date) weekend, 0 Interviews, 0 JobSeekers, cast(0 as numeric(10,2)) JConvert, 0 Workers, cast(0 as numeric(10,2)) WConvert into #dates 
	from dbo.CALENDAR (@startdate,@enddate)
	group by [year], [monthname]
	order by weekstart
	
	update #dates set interviews = (
	select count(id) from interviewees where interviewdate between weekstart and weekend)
	
	update #dates set jobseekers = (
	select count(distinct intervieweeid) from jobseekers where intervieweeid in
	(select id from interviewees where interviewdate between weekstart and weekend)
	and datestart between weekstart and weekend )
	
	update #dates set jconvert = cast ((jobseekers*100/interviews*100)/100 as numeric(10,2)) where interviews > 0 and jobseekers > 0

	update #dates set workers = (
	select count(distinct intervieweeid) from workers where intervieweeid in
	(select id from interviewees where interviewdate between weekstart and weekend)
	and contractstart between weekstart and weekend )
	
	update #dates set wconvert = cast ((workers*100/interviews*100)/100 as numeric(10,2)) where interviews > 0 and workers > 0

	select convert(varchar(3), weekstart, 100) [Month], interviews, jobseekers, jconvert, workers, wconvert from #dates order by weekstart
	
drop table #dates

GO
