USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_InterviewOutcomeByOriginator]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[usp_REPORT_InterviewOutcomeByOriginator]
AS

declare @startdate datetime;
declare @enddate datetime;

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);

select
	Originator, Outcome,
	sum(apr) Apr,
	sum(may) May,
	sum(jun) Jun,
	sum(jul) Jul,
	sum(aug) Aug,
	sum(sep) Sep,
	sum(oct) Oct,
	sum(nov) Nov,
	sum([dec]) [Dec],
	sum(jan) Jan,
	sum(feb) Feb,
	sum(mar) Mar,
	sum(total) Total
	from
	(
select 
	Originators.name Originator,
	case when outcomes.Name = 'CONVERTED' then 'SIGNED UP' else outcomes.name end outcome,
	case when month(interviewdate) = 4 then 1 else 0 end apr,
	case when month(interviewdate) = 5 then 1 else 0 end may,
	case when month(interviewdate) = 6 then 1 else 0 end jun,
	case when month(interviewdate) = 7 then 1 else 0 end jul,
	case when month(interviewdate) = 8 then 1 else 0 end aug,
	case when month(interviewdate) = 9 then 1 else 0 end sep,
	case when month(interviewdate) = 10 then 1 else 0 end oct,
	case when month(interviewdate) = 11 then 1 else 0 end nov,
	case when month(interviewdate) = 12 then 1 else 0 end [dec],
	case when month(interviewdate) = 1 then 1 else 0 end jan,
	case when month(interviewdate) = 2 then 1 else 0 end feb,
	case when month(interviewdate) = 3 then 1 else 0 end mar,
	1 total
from interviewees
inner join Originators on Originators.id = OriginatorId
inner join outcomes on outcomes.id = outcomeid
where interviewdate between @startdate and @enddate
) a
group by Originator, outcome
order by Originator, outcome


GO
