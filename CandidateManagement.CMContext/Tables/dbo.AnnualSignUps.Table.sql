USE [CMContext]
GO
/****** Object:  Table [dbo].[AnnualSignUps]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnnualSignUps](
	[FinYear] [varchar](20) NOT NULL,
	[Apr] [int] NOT NULL,
	[May] [int] NOT NULL,
	[Jun] [int] NOT NULL,
	[Jul] [int] NOT NULL,
	[Aug] [int] NOT NULL,
	[Sep] [int] NOT NULL,
	[HalfYear] [int] NOT NULL,
	[Oct] [int] NOT NULL,
	[Nov] [int] NOT NULL,
	[Dec] [int] NOT NULL,
	[Jan] [int] NOT NULL,
	[Feb] [int] NOT NULL,
	[Mar] [int] NOT NULL,
	[Total] [int] NOT NULL,
	[Percentage] [numeric](10, 2) NOT NULL
) ON [PRIMARY]

GO
