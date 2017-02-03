USE [CMContext]
GO
/****** Object:  StoredProcedure [dbo].[sp_DASHBOARD_InterviewCount_CurrentMonth]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DASHBOARD_InterviewCount_CurrentMonth]
as

select count(interviewdate) interviews
from interviewees

where datediff(month, interviewdate,getdate())=0
GO
