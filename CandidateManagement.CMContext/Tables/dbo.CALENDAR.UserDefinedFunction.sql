USE [CMContext]
GO
/****** Object:  UserDefinedFunction [dbo].[CALENDAR]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CALENDAR] 
(
    @StartDate DATETIME
,   @EndDate DATETIME
) 
RETURNS TABLE
AS
--====================================
-- Name: CALENDAR
-- Created: Chris Kutsch 12/29/2014
-- Usage: Returns a dynamic calendar for date manipulation
--====================================
RETURN  
(
    SELECT  tt.RID
        ,   DATEADD(DAY,tt.RID-1,@StartDate) AS [Date]
        ,   DATEPART(quarter,DATEADD(DAY,tt.RID-1,@StartDate)) AS [Quarter]
        ,   DATEPART(dayofyear,DATEADD(DAY,tt.RID-1,@StartDate)) AS [DayofYear]
        ,   DATEPART(WEEK,DATEADD(DAY,tt.RID-1,@StartDate)) AS [WeekofYear]
        ,   DATEPART(YEAR,DATEADD(DAY,tt.RID-1,@StartDate)) AS [Year]    
        ,   DATEPART(MONTH,DATEADD(DAY,tt.RID-1,@StartDate)) AS [Month]
        ,   DATEPART(DAY,DATEADD(DAY,tt.RID-1,@StartDate)) AS [Day]    
        ,   DATEPART(weekday,DATEADD(DAY,tt.RID-1,@StartDate)) AS [Weekday]
        ,   DATENAME(MONTH,DATEADD(DAY,tt.RID-1,@StartDate)) AS [MonthName]
        ,   DATENAME(weekday,DATEADD(DAY,tt.RID-1,@StartDate)) AS [WeekdayName]
        --,   CASE WHEN rh.[CALENDER_DATE] IS NULL THEN 1 ELSE 0 END AS [IsBusinessDay]
        ,   (RIGHT( 
                REPLICATE('0',(4)) +
                CONVERT([VARCHAR],DATEPART(YEAR,DATEADD(DAY,tt.RID-1,@StartDate)),0)
                ,(4)
             )+
             RIGHT(
                REPLICATE('0',(2)) +
                CONVERT([VARCHAR],DATEPART(MONTH,DATEADD(DAY,tt.RID-1,@StartDate)),0)
                ,(2)
             )
            ) AS [Vintage]
        
    FROM    ( SELECT ROW_NUMBER() OVER (ORDER BY [object_id]) AS [RID]
              FROM sys.all_objects WITH (NOLOCK)
            ) tt --LEFT OUTER JOIN
            --dbo.HOLIDAYS rh WITH (NOLOCK) ON DATEADD(DAY,tt.RID-1,@StartDate) = rh.[CALENDER_DATE]
            
    WHERE   DATEADD(DAY,tt.RID-1,@StartDate) <= @EndDate
    
)

GO
