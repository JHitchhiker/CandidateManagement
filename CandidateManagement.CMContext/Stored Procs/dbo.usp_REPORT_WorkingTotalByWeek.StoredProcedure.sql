USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_WorkingTotalByWeek]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_REPORT_WorkingTotalByWeek]
AS
	declare @startdate datetime;
	declare @enddate datetime;

	set @startdate = (select max(startdate) from financialyears);
	set @enddate = (select max(enddate) from financialyears);

	select min(date) weekstart, max(date) weekend, 0 jobseekers, 0 working, 0 leavers, 0 contractsending, 0 newcontracts, 0 contractsextending into #dates 
	from dbo.CALENDAR (@startdate,@enddate)
	group by [year], weekofyear
	order by weekstart
	
	select 
		intervieweeid,
		contractstart,
		case when isnull(TerminationDate,'')!='' then TerminationDate else ContractEnd end ContractEnd
	into #workers
	from workers

	update #dates set working = (
					select count(intervieweeid) from #workers 
					where (contractstart <= weekend and contractend >= weekend)
					or (contractstart <= weekend and contractend between weekstart and weekend))

	update #dates set jobseekers = (
					select count(id) from jobseekers 
					where (datestart <= weekend and dateend >= weekend)
					or (datestart <= weekend and dateend between weekstart and weekend)
					or (datestart <= weekend and isnull(dateend,'')='')
					)
    
	update #dates set leavers = (
					select count(id) from leavers
					where (leavingdate between weekstart and weekend)
					)
	
	update #dates set contractsending = (
					select count(id) from workers
					where (contractend between weekstart and weekend)
					)
	
	update #dates set newcontracts = (
					select count(id) from workers
					where (contractstart between weekstart and weekend)
					and contractstatusid = 1
					)
	update #dates set contractsextending = (
					select count(id) from workers
					where (contractstart between weekstart and weekend)
					and contractstatusid != 1
					)

select weekend [WeekEnding], jobseekers, working, leavers, contractsending, newcontracts, contractsextending from #dates
order by weekstart
drop table #dates
drop table #workers

GO
