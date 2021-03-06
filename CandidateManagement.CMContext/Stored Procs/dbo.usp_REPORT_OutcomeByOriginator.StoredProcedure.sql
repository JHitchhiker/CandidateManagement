USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[usp_REPORT_OutcomeByOriginator]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_REPORT_OutcomeByOriginator]
AS
declare @cols nvarchar(max);
declare @query nvarchar(max);
declare @startdate datetime;
declare @enddate datetime;

set @startdate = (select max(startdate) from financialyears);
set @enddate = (select max(enddate) from financialyears);

set @cols = ''

select @cols = @cols + quotename(fld1) + ',' FROM (select distinct originators.Name fld1 from interviewees inner join originators on originators.id=originatorid) as tmp
select @cols = substring(@cols, 0, len(@cols)) 

set @query = 
'SELECT * 
from 
(
    select outcomes.description outcome, Originators.name originator, 1 ctr 
	from interviewees
	inner join Originators on originators.Id = OriginatorId
	inner join outcomes on outcomes.id = outcomeid
	where interviewdate between ''' + cast(@startdate as varchar) + ''' and ''' + cast(@enddate as varchar)+ '''
) src
pivot 
(
    count(ctr) for originator in ('+ @cols +')
) piv;
'
exec sp_executesql @query




GO
