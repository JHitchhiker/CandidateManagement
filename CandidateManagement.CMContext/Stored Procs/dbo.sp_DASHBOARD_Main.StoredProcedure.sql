USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[sp_DASHBOARD_Main]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DASHBOARD_Main]
as

declare @MonthlyAverage decimal(10,2);
declare @MonthlyCount int;
declare @SignUps int;
declare @Workers int;
declare @NewContracts int;
declare @OutOfContract int;
declare @ContractEnding int;
declare @startdate datetime;
declare @enddate datetime;
declare @daystojob decimal(10,2);
declare @allworking int;
declare @successrate decimal(10,2);
declare @jobseekers int;

set @startdate = (select max(startdate) from FinancialYears)
set @enddate = (select max(EndDate) from FinancialYears)

set @MonthlyAverage = (
						select (sum(interviews)*1.00/count(financialyear)*1.00)*1.00
						from(
							select year(interviewdate) financialyear,count(month(interviewdate)) interviews
							from interviewees
							group by year(interviewdate),month(interviewdate)
							having month(interviewdate)=month(getdate())) a)

set @MonthlyCount = (select count(interviewdate) interviews
					from interviewees
					where datediff(month, interviewdate,getdate())=0)


set @SignUps = (select count(id) from interviewees
				where OutcomeId in (7,8)
				and datediff(year,@enddate,interviewdate)<=0)

set @Workers = (
				select count(id) from workers
				where ContractEnd>=getdate()
				and isnull(terminationdate,0)=0
				and Completed!=1)

set @NewContracts = (
					select count(id)
					from workers
					where datediff(month,getdate(),ContractStart)>=0
					AND ISNULL(TERMINATIONDATE,0)=0
					AND Completed=0)

set @OutOfContract = (
					select count(id) from workers
					where completed =0
					and datediff(month,contractend,getdate())>0
					)

set @ContractEnding = (
						select count(*) from workers
						where completed =0
						and datediff(month,contractend,getdate())=0
						)

set @daystojob = (
					select round(
							(select 
									sum(datediff(day,InterviewDate,startingdate)) 
							 from 
								(select intervieweeid, min(contractstart) startingdate 
								 from workers
								 group by intervieweeid) a
							inner join interviewees 
								on a.intervieweeid=interviewees.id
							where interviewdate between @startdate and @enddate

					)*1.00
					/
					(select count(*) 
					 from 
						(select intervieweeid, min(contractstart) startingdate 
						 from workers
						 group by intervieweeid
						 having min(contractstart)>(select interviewdate from interviewees where id=intervieweeid)) a
					 inner join interviewees 
						on a.intervieweeid=interviewees.id
					 where interviewdate between @startdate and @enddate
					)*1.00
				,2))

set @successrate = (select
((
select count(distinct intervieweeid)
from workers
where intervieweeid in 
(select (id) from interviewees
where outcomeid in (8)
and InterviewDate between @startdate and @enddate
))*1.00
/
(select count(id) from interviewees
where outcomeid in (7,8)
and InterviewDate between @startdate and @enddate
))*100)

set @jobseekers = (select count(id) from JobSeekers where isnull(dateend,0)=0)

select @MonthlyAverage Average, 
	   @MonthlyCount Interviews, 
	   @SignUps SignUps, 
	   @Workers OnContract, 
	   @NewContracts NewContracts,
	   @ContractEnding EndingSoon,
	   @daystojob DaysToJob,
	   @successrate SuccessRate,
	   @jobseekers JobSeekers



GO
