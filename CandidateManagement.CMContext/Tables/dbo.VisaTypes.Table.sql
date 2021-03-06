USE [CMContext]
GO
/****** Object:  Table [dbo].[VisaTypes]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisaTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[DateChanged] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.VisaTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
