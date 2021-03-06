USE [CMContext]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IntervieweeId] [int] NOT NULL,
	[ContractStatusId] [int] NOT NULL,
	[ContractStart] [datetime] NOT NULL,
	[ContractEnd] [datetime] NOT NULL,
	[Agency] [bit] NOT NULL,
	[AgencyName] [nvarchar](max) NULL,
	[Client] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[DateChanged] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[Completed] [bit] NOT NULL,
	[TerminationDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Workers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_IntervieweeId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_IntervieweeId] ON [dbo].[Workers]
(
	[IntervieweeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [Completed]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Workers_dbo.Interviewees_IntervieweeId] FOREIGN KEY([IntervieweeId])
REFERENCES [dbo].[Interviewees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_dbo.Workers_dbo.Interviewees_IntervieweeId]
GO
