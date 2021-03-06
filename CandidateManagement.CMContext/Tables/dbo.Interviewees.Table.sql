USE [CMContext]
GO
/****** Object:  Table [dbo].[Interviewees]    Script Date: 03/02/2017 10:31:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interviewees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[VisaTypeId] [int] NOT NULL,
	[EthnicityId] [int] NOT NULL,
	[ServiceId] [int] NULL,
	[OriginId] [int] NOT NULL,
	[OriginatorId] [int] NOT NULL,
	[ProfessionId] [int] NOT NULL,
	[SkillId] [int] NULL,
	[InterviewerId] [int] NOT NULL,
	[InterviewDate] [datetime] NOT NULL,
	[OutcomeId] [int] NOT NULL,
	[SignUpDate] [datetime] NULL,
	[Comments] [nvarchar](250) NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[DateChanged] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Interviewees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_InterviewerId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_InterviewerId] ON [dbo].[Interviewees]
(
	[InterviewerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OriginatorId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_OriginatorId] ON [dbo].[Interviewees]
(
	[OriginatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OriginId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_OriginId] ON [dbo].[Interviewees]
(
	[OriginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OutcomeId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_OutcomeId] ON [dbo].[Interviewees]
(
	[OutcomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProfessionId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_ProfessionId] ON [dbo].[Interviewees]
(
	[ProfessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ServiceId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_ServiceId] ON [dbo].[Interviewees]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SkillId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_SkillId] ON [dbo].[Interviewees]
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VisaTypeId]    Script Date: 03/02/2017 10:31:13 ******/
CREATE NONCLUSTERED INDEX [IX_VisaTypeId] ON [dbo].[Interviewees]
(
	[VisaTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.BiteServices_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[BiteServices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.BiteServices_ServiceId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.Interviewers_InterviewerId] FOREIGN KEY([InterviewerId])
REFERENCES [dbo].[Interviewers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.Interviewers_InterviewerId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.Originators_OriginatorId] FOREIGN KEY([OriginatorId])
REFERENCES [dbo].[Originators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.Originators_OriginatorId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.Origins_OriginId] FOREIGN KEY([OriginId])
REFERENCES [dbo].[Origins] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.Origins_OriginId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.Outcomes_OutcomeId] FOREIGN KEY([OutcomeId])
REFERENCES [dbo].[Outcomes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.Outcomes_OutcomeId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.Professions_ProfessionId] FOREIGN KEY([ProfessionId])
REFERENCES [dbo].[Professions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.Professions_ProfessionId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.Skills_SkillId] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.Skills_SkillId]
GO
ALTER TABLE [dbo].[Interviewees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interviewees_dbo.VisaTypes_VisaTypeId] FOREIGN KEY([VisaTypeId])
REFERENCES [dbo].[VisaTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviewees] CHECK CONSTRAINT [FK_dbo.Interviewees_dbo.VisaTypes_VisaTypeId]
GO
