USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[sp_DASHBOARD_SourceSignup]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DASHBOARD_SourceSignup]
as
declare @startdate datetime;
declare @enddate datetime;

set @startdate = (select max(startdate) from FinancialYears)
set @enddate = (select max(EndDate) from FinancialYears)

select origins.name Source,count(*) SignedUp from interviewees
inner join origins on origins.id = originid
where InterviewDate between @startdate and @enddate
and outcomeid in(7,8)
group by origins.name


GO
