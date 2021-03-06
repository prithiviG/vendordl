/****** Object:  Table [dbo].[WorkGroup]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkGroup](
	[VendorId] [int] NOT NULL,
	[Work_Group_ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorTurnOver]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorTurnOver](
	[TurnOverId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[FYear] [varchar](50) NOT NULL,
	[Value] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorTerms]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorTerms](
	[VendorId] [int] NOT NULL,
	[CreditDays] [int] NOT NULL,
	[TermsAndCondition] [varchar](8000) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorStatutory]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorStatutory](
	[VendorID] [int] NOT NULL,
	[FirmType] [varchar](50) NOT NULL,
	[EYear] [int] NOT NULL,
	[PANNo] [varchar](50) NOT NULL,
	[TANNo] [varchar](50) NOT NULL,
	[CSTNo] [varchar](50) NOT NULL,
	[TINNo] [varchar](50) NOT NULL,
	[BankAccountNo] [varchar](50) NOT NULL,
	[AccountType] [char](1) NOT NULL,
	[BankName] [varchar](100) NOT NULL,
	[BranchName] [varchar](50) NOT NULL,
	[BranchCode] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorMaster](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](200) NOT NULL,
	[Supply] [bit] NOT NULL,
	[Contract] [bit] NOT NULL,
	[Service] [bit] NOT NULL,
	[RegAddress] [varchar](255) NOT NULL,
	[CityId] [int] NOT NULL,
	[PinCode] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorLocation]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorLocation](
	[VendorId] [int] NOT NULL,
	[CityId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorExperience]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorExperience](
	[ExperienceId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[WorkDescription] [varchar](255) NOT NULL,
	[ClientName] [varchar](200) NOT NULL,
	[Value] [float] NOT NULL,
	[Period] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorContact]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorContact](
	[VendorID] [int] NOT NULL,
	[CAddress] [varchar](255) NOT NULL,
	[Phone1] [varchar](100) NOT NULL,
	[Phone2] [varchar](100) NOT NULL,
	[Fax1] [varchar](100) NOT NULL,
	[Fax2] [varchar](100) NOT NULL,
	[Mobile1] [varchar](100) NOT NULL,
	[Mobile2] [varchar](100) NOT NULL,
	[CPerson1] [varchar](100) NOT NULL,
	[CPerson2] [varchar](100) NOT NULL,
	[CDesignation1] [varchar](100) NOT NULL,
	[CDesignation2] [varchar](100) NOT NULL,
	[ContactNo1] [varchar](100) NOT NULL,
	[ContactNo2] [varchar](100) NOT NULL,
	[Email1] [varchar](100) NOT NULL,
	[Email2] [varchar](100) NOT NULL,
	[WebName] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendoCheckListTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendoCheckListTrans](
	[VendorId] [int] NOT NULL,
	[CheckListId] [int] NOT NULL,
	[RegType] [char](1) NOT NULL,
	[Points] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeSetup]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeSetup](
	[TypeId] [int] NOT NULL,
	[GenType] [bit] NOT NULL,
	[StartNo] [int] NOT NULL,
	[Prefix] [varchar](10) NOT NULL,
	[Suffix] [varchar](10) NOT NULL,
	[Width] [int] NOT NULL,
	[MaxNo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TechPersons]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TechPersons](
	[TechPersonId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[PersonName] [varchar](100) NOT NULL,
	[Qualification] [varchar](50) NOT NULL,
	[Experience] [float] NOT NULL,
	[Designation] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateMaster](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](100) NOT NULL,
	[CountryID] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTrans](
	[VendorId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegTransLatest]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegTransLatest](
	[RegisterId] [int] NOT NULL,
	[VendorId] [int] NOT NULL,
	[Supply] [bit] NOT NULL,
	[Contract] [bit] NOT NULL,
	[Service] [bit] NOT NULL,
	[STDate] [datetime] NULL,
	[CTDate] [datetime] NULL,
	[HTDate] [datetime] NULL,
	[SLife] [bit] NOT NULL,
	[CLife] [bit] NOT NULL,
	[HLife] [bit] NOT NULL,
	[SSuspend] [bit] NOT NULL,
	[CSuspend] [bit] NOT NULL,
	[HSuspend] [bit] NOT NULL,
	[SBlackList] [bit] NOT NULL,
	[CBlackList] [bit] NOT NULL,
	[HBlackList] [bit] NOT NULL,
	[SGradeId] [int] NOT NULL,
	[CGradeId] [int] NOT NULL,
	[HGradeID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegTrans](
	[RegTransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[RegId] [int] NOT NULL,
	[RDate] [datetime] NOT NULL,
	[RefNo] [varchar](100) NOT NULL,
	[StatusType] [char](1) NOT NULL,
	[Supply] [bit] NOT NULL,
	[Contract] [bit] NOT NULL,
	[Service] [bit] NOT NULL,
	[SGradeId] [int] NOT NULL,
	[CGradeId] [int] NOT NULL,
	[HGradeId] [int] NOT NULL,
	[SFDate] [datetime] NULL,
	[STDate] [datetime] NULL,
	[CFDate] [datetime] NULL,
	[CTDate] [datetime] NULL,
	[HFDate] [datetime] NULL,
	[HTDate] [datetime] NULL,
	[SLifeTime] [bit] NOT NULL,
	[CLifeTime] [bit] NOT NULL,
	[HLifeTime] [bit] NOT NULL,
	[Remarks] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[RegisterId] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [datetime] NULL,
	[RegNo] [varchar](100) NOT NULL,
	[VendorId] [int] NOT NULL,
	[Supply] [bit] NOT NULL,
	[Contract] [bit] NOT NULL,
	[Service] [bit] NOT NULL,
	[SGradeId] [int] NOT NULL,
	[CGradeId] [int] NOT NULL,
	[HGradeId] [int] NOT NULL,
	[SFDate] [datetime] NULL,
	[STDate] [datetime] NULL,
	[CFDate] [datetime] NULL,
	[CTDate] [datetime] NULL,
	[HFDate] [datetime] NULL,
	[HTDate] [datetime] NULL,
	[SLifeTime] [bit] NOT NULL,
	[CLifeTime] [bit] NOT NULL,
	[HLifeTime] [bit] NOT NULL,
	[Remarks] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaterialTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaterialTrans](
	[VendorId] [int] NOT NULL,
	[Resource_Id] [int] NOT NULL,
	[Priority] [char](1) NOT NULL,
	[SupplyType] [char](1) NOT NULL,
	[LeadTime] [int] NOT NULL,
	[CreditDays] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaterialGroupTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaterialGroupTrans](
	[VendorID] [int] NOT NULL,
	[Resource_Group_ID] [int] NOT NULL,
	[Priority] [char](1) NOT NULL,
	[SupplyType] [char](1) NOT NULL,
	[LeadTime] [int] NOT NULL,
	[CreditDays] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ManPower]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManPower](
	[ManPowerTransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[Resource_ID] [int] NOT NULL,
	[Qty] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machinery]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Machinery](
	[MachineryTransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[Resource_ID] [int] NOT NULL,
	[Qty] [float] NOT NULL,
	[Capacity] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logistics]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logistics](
	[VendorId] [int] NOT NULL,
	[TransportArrange] [char](1) NOT NULL,
	[TransportMode] [varchar](50) NOT NULL,
	[Delivery] [char](1) NOT NULL,
	[Insurance] [char](1) NOT NULL,
	[Unload] [char](1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HireMachineryTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HireMachineryTrans](
	[VendorId] [int] NOT NULL,
	[Resource_ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeTrans](
	[VendorId] [int] NOT NULL,
	[CGradeId] [int] NOT NULL,
	[SGradeId] [int] NOT NULL,
	[HGradeId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradeMaster](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [varchar](50) NOT NULL,
	[FValue] [float] NOT NULL,
	[TValue] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CountryMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CountryMaster](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CityMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CityMaster](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](100) NOT NULL,
	[StateId] [int] NOT NULL,
	[CountryId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CheckListMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CheckListMaster](
	[CheckListId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[Supply] [bit] NOT NULL,
	[Contract] [bit] NOT NULL,
	[Service] [bit] NOT NULL,
	[MaxPoint] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CertificateTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CertificateTrans](
	[VendorId] [int] NOT NULL,
	[CertificateId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CertificateMaster]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CertificateMaster](
	[CertificateId] [int] IDENTITY(1,1) NOT NULL,
	[CerDescription] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[BranchName] [varchar](100) NOT NULL,
	[CityId] [int] NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[TINNo] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActivityTrans]    Script Date: 08/12/2010 12:37:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityTrans](
	[VendorId] [int] NOT NULL,
	[Resource_Group_ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Activity_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ActivityTrans] ADD  CONSTRAINT [DF_Activity_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_Activity_Resource_ID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ActivityTrans] ADD  CONSTRAINT [DF_Activity_Resource_ID]  DEFAULT ((0)) FOR [Resource_Group_ID]
GO
/****** Object:  Default [DF_Branch_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_Branch_BranchName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_BranchName]  DEFAULT ('') FOR [BranchName]
GO
/****** Object:  Default [DF_Branch_CityId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_CityId]  DEFAULT ((0)) FOR [CityId]
GO
/****** Object:  Default [DF_Branch_Address]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_Address]  DEFAULT ('') FOR [Address]
GO
/****** Object:  Default [DF_Branch_TINNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_TINNo]  DEFAULT ('') FOR [TINNo]
GO
/****** Object:  Default [DF_CertificateMaster_CerDescription]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CertificateMaster] ADD  CONSTRAINT [DF_CertificateMaster_CerDescription]  DEFAULT ('') FOR [CerDescription]
GO
/****** Object:  Default [DF_CertificateTrans_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CertificateTrans] ADD  CONSTRAINT [DF_CertificateTrans_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_CertificateTrans_CertificateId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CertificateTrans] ADD  CONSTRAINT [DF_CertificateTrans_CertificateId]  DEFAULT ((0)) FOR [CertificateId]
GO
/****** Object:  Default [DF_CheckListMaster_Description]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CheckListMaster] ADD  CONSTRAINT [DF_CheckListMaster_Description]  DEFAULT ('') FOR [Description]
GO
/****** Object:  Default [DF_CheckListMaster_Supply]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CheckListMaster] ADD  CONSTRAINT [DF_CheckListMaster_Supply]  DEFAULT ((0)) FOR [Supply]
GO
/****** Object:  Default [DF_CheckListMaster_Contract]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CheckListMaster] ADD  CONSTRAINT [DF_CheckListMaster_Contract]  DEFAULT ((0)) FOR [Contract]
GO
/****** Object:  Default [DF_CheckListMaster_Service]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CheckListMaster] ADD  CONSTRAINT [DF_CheckListMaster_Service]  DEFAULT ((0)) FOR [Service]
GO
/****** Object:  Default [DF_CheckListMaster_MaxPoint]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CheckListMaster] ADD  CONSTRAINT [DF_CheckListMaster_MaxPoint]  DEFAULT ((0)) FOR [MaxPoint]
GO
/****** Object:  Default [DF_CityMaster_CityName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CityMaster] ADD  CONSTRAINT [DF_CityMaster_CityName]  DEFAULT ('') FOR [CityName]
GO
/****** Object:  Default [DF_CityMaster_StateId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CityMaster] ADD  CONSTRAINT [DF_CityMaster_StateId]  DEFAULT ((0)) FOR [StateId]
GO
/****** Object:  Default [DF_CityMaster_CountryId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CityMaster] ADD  CONSTRAINT [DF_CityMaster_CountryId]  DEFAULT ((0)) FOR [CountryId]
GO
/****** Object:  Default [DF_CountryMaster_CountryName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[CountryMaster] ADD  CONSTRAINT [DF_CountryMaster_CountryName]  DEFAULT ('') FOR [CountryName]
GO
/****** Object:  Default [DF_GradeMaster_GradeName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeMaster] ADD  CONSTRAINT [DF_GradeMaster_GradeName]  DEFAULT ('') FOR [GradeName]
GO
/****** Object:  Default [DF_GradeMaster_FromValue]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeMaster] ADD  CONSTRAINT [DF_GradeMaster_FromValue]  DEFAULT ((0)) FOR [FValue]
GO
/****** Object:  Default [DF_GradeMaster_ToValue]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeMaster] ADD  CONSTRAINT [DF_GradeMaster_ToValue]  DEFAULT ((0)) FOR [TValue]
GO
/****** Object:  Default [DF_GradeTrans_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeTrans] ADD  CONSTRAINT [DF_GradeTrans_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_GradeTrans_CGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeTrans] ADD  CONSTRAINT [DF_GradeTrans_CGradeId]  DEFAULT ((0)) FOR [CGradeId]
GO
/****** Object:  Default [DF_GradeTrans_SGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeTrans] ADD  CONSTRAINT [DF_GradeTrans_SGradeId]  DEFAULT ((0)) FOR [SGradeId]
GO
/****** Object:  Default [DF_GradeTrans_HGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[GradeTrans] ADD  CONSTRAINT [DF_GradeTrans_HGradeId]  DEFAULT ((0)) FOR [HGradeId]
GO
/****** Object:  Default [DF_HireMachineryTrans_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[HireMachineryTrans] ADD  CONSTRAINT [DF_HireMachineryTrans_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_HireMachineryTrans_Resource_ID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[HireMachineryTrans] ADD  CONSTRAINT [DF_HireMachineryTrans_Resource_ID]  DEFAULT ((0)) FOR [Resource_ID]
GO
/****** Object:  Default [DF_Logistics_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Logistics] ADD  CONSTRAINT [DF_Logistics_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_Logistics_TransportArrange]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Logistics] ADD  CONSTRAINT [DF_Logistics_TransportArrange]  DEFAULT ('') FOR [TransportArrange]
GO
/****** Object:  Default [DF_Logistics_TransportMode]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Logistics] ADD  CONSTRAINT [DF_Logistics_TransportMode]  DEFAULT ('') FOR [TransportMode]
GO
/****** Object:  Default [DF_Logistics_Delivery]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Logistics] ADD  CONSTRAINT [DF_Logistics_Delivery]  DEFAULT ('') FOR [Delivery]
GO
/****** Object:  Default [DF_Logistics_Insurance]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Logistics] ADD  CONSTRAINT [DF_Logistics_Insurance]  DEFAULT ('') FOR [Insurance]
GO
/****** Object:  Default [DF_Logistics_Unload]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Logistics] ADD  CONSTRAINT [DF_Logistics_Unload]  DEFAULT ('') FOR [Unload]
GO
/****** Object:  Default [DF_Machinery_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Machinery] ADD  CONSTRAINT [DF_Machinery_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_Machinery_Resource_ID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Machinery] ADD  CONSTRAINT [DF_Machinery_Resource_ID]  DEFAULT ((0)) FOR [Resource_ID]
GO
/****** Object:  Default [DF_Machinery_Qty]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Machinery] ADD  CONSTRAINT [DF_Machinery_Qty]  DEFAULT ((0)) FOR [Qty]
GO
/****** Object:  Default [DF_Machinery_Capacity]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Machinery] ADD  CONSTRAINT [DF_Machinery_Capacity]  DEFAULT ('') FOR [Capacity]
GO
/****** Object:  Default [DF_ManPower_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ManPower] ADD  CONSTRAINT [DF_ManPower_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_ManPower_Resource_ID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ManPower] ADD  CONSTRAINT [DF_ManPower_Resource_ID]  DEFAULT ((0)) FOR [Resource_ID]
GO
/****** Object:  Default [DF_ManPower_Qty]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ManPower] ADD  CONSTRAINT [DF_ManPower_Qty]  DEFAULT ((0)) FOR [Qty]
GO
/****** Object:  Default [DF_MaterialGroupTrans_VendorID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialGroupTrans] ADD  CONSTRAINT [DF_MaterialGroupTrans_VendorID]  DEFAULT ((0)) FOR [VendorID]
GO
/****** Object:  Default [DF_MaterialGroupTrans_Resource_Group_ID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialGroupTrans] ADD  CONSTRAINT [DF_MaterialGroupTrans_Resource_Group_ID]  DEFAULT ((0)) FOR [Resource_Group_ID]
GO
/****** Object:  Default [DF_MaterialGroupTrans_Priority]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialGroupTrans] ADD  CONSTRAINT [DF_MaterialGroupTrans_Priority]  DEFAULT ('') FOR [Priority]
GO
/****** Object:  Default [DF_MaterialGroupTrans_SupplyType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialGroupTrans] ADD  CONSTRAINT [DF_MaterialGroupTrans_SupplyType]  DEFAULT ('') FOR [SupplyType]
GO
/****** Object:  Default [DF_MaterialGroupTrans_LeadTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialGroupTrans] ADD  CONSTRAINT [DF_MaterialGroupTrans_LeadTime]  DEFAULT ((0)) FOR [LeadTime]
GO
/****** Object:  Default [DF_MaterialGroupTrans_CreditDays]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialGroupTrans] ADD  CONSTRAINT [DF_MaterialGroupTrans_CreditDays]  DEFAULT ((0)) FOR [CreditDays]
GO
/****** Object:  Default [DF_MaterialTrans_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialTrans] ADD  CONSTRAINT [DF_MaterialTrans_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_MaterialTrans_Resource_Id]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialTrans] ADD  CONSTRAINT [DF_MaterialTrans_Resource_Id]  DEFAULT ((0)) FOR [Resource_Id]
GO
/****** Object:  Default [DF_MaterialTrans_Priority]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialTrans] ADD  CONSTRAINT [DF_MaterialTrans_Priority]  DEFAULT ('') FOR [Priority]
GO
/****** Object:  Default [DF_MaterialTrans_SupplyType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialTrans] ADD  CONSTRAINT [DF_MaterialTrans_SupplyType]  DEFAULT ('') FOR [SupplyType]
GO
/****** Object:  Default [DF_MaterialTrans_LeadTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialTrans] ADD  CONSTRAINT [DF_MaterialTrans_LeadTime]  DEFAULT ((0)) FOR [LeadTime]
GO
/****** Object:  Default [DF_MaterialTrans_CreditDays]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[MaterialTrans] ADD  CONSTRAINT [DF_MaterialTrans_CreditDays]  DEFAULT ((0)) FOR [CreditDays]
GO
/****** Object:  Default [DF_Registration_RegNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_RegNo]  DEFAULT ('') FOR [RegNo]
GO
/****** Object:  Default [DF_Registration_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_Registration_Supply]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Supply]  DEFAULT ((0)) FOR [Supply]
GO
/****** Object:  Default [DF_Registration_Contract]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Contract]  DEFAULT ((0)) FOR [Contract]
GO
/****** Object:  Default [DF_Registration_Service]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Service]  DEFAULT ((0)) FOR [Service]
GO
/****** Object:  Default [DF_Registration_SGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_SGradeId]  DEFAULT ((0)) FOR [SGradeId]
GO
/****** Object:  Default [DF_Registration_CGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_CGradeId]  DEFAULT ((0)) FOR [CGradeId]
GO
/****** Object:  Default [DF_Registration_HGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_HGradeId]  DEFAULT ((0)) FOR [HGradeId]
GO
/****** Object:  Default [DF_Registration_SLifeTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_SLifeTime]  DEFAULT ((0)) FOR [SLifeTime]
GO
/****** Object:  Default [DF_Registration_CLifeTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_CLifeTime]  DEFAULT ((0)) FOR [CLifeTime]
GO
/****** Object:  Default [DF_Registration_HLifeTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_HLifeTime]  DEFAULT ((0)) FOR [HLifeTime]
GO
/****** Object:  Default [DF_Registration_Remarks]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Remarks]  DEFAULT ('') FOR [Remarks]
GO
/****** Object:  Default [DF_RegMaster_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_RegTrans_RegId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegTrans_RegId]  DEFAULT ((0)) FOR [RegId]
GO
/****** Object:  Default [DF_RegMaster_RegNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_RegNo]  DEFAULT ('') FOR [RDate]
GO
/****** Object:  Default [DF_RegTrans_RefNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegTrans_RefNo]  DEFAULT ('') FOR [RefNo]
GO
/****** Object:  Default [DF_RegTrans_StatusType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegTrans_StatusType]  DEFAULT ('') FOR [StatusType]
GO
/****** Object:  Default [DF_RegMaster_Supply]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_Supply]  DEFAULT ((0)) FOR [Supply]
GO
/****** Object:  Default [DF_RegMaster_Contract]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_Contract]  DEFAULT ((0)) FOR [Contract]
GO
/****** Object:  Default [DF_RegMaster_Service]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_Service]  DEFAULT ((0)) FOR [Service]
GO
/****** Object:  Default [DF_RegMaster_SGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_SGradeId]  DEFAULT ((0)) FOR [SGradeId]
GO
/****** Object:  Default [DF_RegMaster_CGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_CGradeId]  DEFAULT ((0)) FOR [CGradeId]
GO
/****** Object:  Default [DF_RegMaster_HGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_HGradeId]  DEFAULT ((0)) FOR [HGradeId]
GO
/****** Object:  Default [DF_RegMaster_SLifeTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_SLifeTime]  DEFAULT ((0)) FOR [SLifeTime]
GO
/****** Object:  Default [DF_RegMaster_CLifeTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_CLifeTime]  DEFAULT ((0)) FOR [CLifeTime]
GO
/****** Object:  Default [DF_RegMaster_HLifeTime]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegMaster_HLifeTime]  DEFAULT ((0)) FOR [HLifeTime]
GO
/****** Object:  Default [DF_RegTrans_Remarks]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTrans] ADD  CONSTRAINT [DF_RegTrans_Remarks]  DEFAULT ('') FOR [Remarks]
GO
/****** Object:  Default [DF_RegTransTemp_RegisterId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_RegisterId]  DEFAULT ((0)) FOR [RegisterId]
GO
/****** Object:  Default [DF_RegTransTemp_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_RegTransTemp_Supply]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_Supply]  DEFAULT ((0)) FOR [Supply]
GO
/****** Object:  Default [DF_RegTransTemp_Contract]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_Contract]  DEFAULT ((0)) FOR [Contract]
GO
/****** Object:  Default [DF_RegTransTemp_Service]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_Service]  DEFAULT ((0)) FOR [Service]
GO
/****** Object:  Default [DF_RegTransTemp_SLife]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_SLife]  DEFAULT ((0)) FOR [SLife]
GO
/****** Object:  Default [DF_RegTransTemp_CLift]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_CLift]  DEFAULT ((0)) FOR [CLife]
GO
/****** Object:  Default [DF_RegTransTemp_HLife]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_HLife]  DEFAULT ((0)) FOR [HLife]
GO
/****** Object:  Default [DF_RegTransTemp_SSuspend]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_SSuspend]  DEFAULT ((0)) FOR [SSuspend]
GO
/****** Object:  Default [DF_RegTransTemp_CSuspend]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_CSuspend]  DEFAULT ((0)) FOR [CSuspend]
GO
/****** Object:  Default [DF_RegTransTemp_HSuspend]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_HSuspend]  DEFAULT ((0)) FOR [HSuspend]
GO
/****** Object:  Default [DF_RegTransTemp_SBlackList]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_SBlackList]  DEFAULT ((0)) FOR [SBlackList]
GO
/****** Object:  Default [DF_RegTransTemp_CBlackList]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_CBlackList]  DEFAULT ((0)) FOR [CBlackList]
GO
/****** Object:  Default [DF_RegTransTemp_HBlackList]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_HBlackList]  DEFAULT ((0)) FOR [HBlackList]
GO
/****** Object:  Default [DF_RegTransTemp_SGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_SGradeId]  DEFAULT ((0)) FOR [SGradeId]
GO
/****** Object:  Default [DF_RegTransTemp_CGradeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_CGradeId]  DEFAULT ((0)) FOR [CGradeId]
GO
/****** Object:  Default [DF_RegTransTemp_HGradeID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[RegTransLatest] ADD  CONSTRAINT [DF_RegTransTemp_HGradeID]  DEFAULT ((0)) FOR [HGradeID]
GO
/****** Object:  Default [DF_Service_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ServiceTrans] ADD  CONSTRAINT [DF_Service_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_Service_ServiceId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[ServiceTrans] ADD  CONSTRAINT [DF_Service_ServiceId]  DEFAULT ((0)) FOR [ServiceId]
GO
/****** Object:  Default [DF_Table1_CountryName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[StateMaster] ADD  CONSTRAINT [DF_Table1_CountryName]  DEFAULT ('') FOR [StateName]
GO
/****** Object:  Default [DF_Table1_Country]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[StateMaster] ADD  CONSTRAINT [DF_Table1_Country]  DEFAULT ((0)) FOR [CountryID]
GO
/****** Object:  Default [DF_TechPersons_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TechPersons] ADD  CONSTRAINT [DF_TechPersons_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_TechPersons_PersonName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TechPersons] ADD  CONSTRAINT [DF_TechPersons_PersonName]  DEFAULT ('') FOR [PersonName]
GO
/****** Object:  Default [DF_TechPersons_Qualification]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TechPersons] ADD  CONSTRAINT [DF_TechPersons_Qualification]  DEFAULT ('') FOR [Qualification]
GO
/****** Object:  Default [DF_TechPersons_Experience]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TechPersons] ADD  CONSTRAINT [DF_TechPersons_Experience]  DEFAULT ((0)) FOR [Experience]
GO
/****** Object:  Default [DF_TechPersons_Designation]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TechPersons] ADD  CONSTRAINT [DF_TechPersons_Designation]  DEFAULT ('') FOR [Designation]
GO
/****** Object:  Default [DF_TypeSetup_TypeId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_TypeId]  DEFAULT ((0)) FOR [TypeId]
GO
/****** Object:  Default [DF_TypeSetup_GenType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_GenType]  DEFAULT ((1)) FOR [GenType]
GO
/****** Object:  Default [DF_TypeSetup_StartNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_StartNo]  DEFAULT ((0)) FOR [StartNo]
GO
/****** Object:  Default [DF_TypeSetup_Prefix]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_Prefix]  DEFAULT ('') FOR [Prefix]
GO
/****** Object:  Default [DF_TypeSetup_Suffix]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_Suffix]  DEFAULT ('') FOR [Suffix]
GO
/****** Object:  Default [DF_TypeSetup_Width]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_Width]  DEFAULT ((0)) FOR [Width]
GO
/****** Object:  Default [DF_TypeSetup_MaxNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[TypeSetup] ADD  CONSTRAINT [DF_TypeSetup_MaxNo]  DEFAULT ((0)) FOR [MaxNo]
GO
/****** Object:  Default [DF_VendoCheckListTrans_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendoCheckListTrans] ADD  CONSTRAINT [DF_VendoCheckListTrans_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_VendoCheckListTrans_CheckListId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendoCheckListTrans] ADD  CONSTRAINT [DF_VendoCheckListTrans_CheckListId]  DEFAULT ((0)) FOR [CheckListId]
GO
/****** Object:  Default [DF_VendoCheckListTrans_RegType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendoCheckListTrans] ADD  CONSTRAINT [DF_VendoCheckListTrans_RegType]  DEFAULT ('') FOR [RegType]
GO
/****** Object:  Default [DF_VendoCheckListTrans_Points]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendoCheckListTrans] ADD  CONSTRAINT [DF_VendoCheckListTrans_Points]  DEFAULT ((0)) FOR [Points]
GO
/****** Object:  Default [DF_VendorContact_VendorID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_VendorID]  DEFAULT ((0)) FOR [VendorID]
GO
/****** Object:  Default [DF_VendorContact_CAddress]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_CAddress]  DEFAULT ('') FOR [CAddress]
GO
/****** Object:  Default [DF_VendorContact_Phone1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Phone1]  DEFAULT ('') FOR [Phone1]
GO
/****** Object:  Default [DF_VendorContact_Phone2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Phone2]  DEFAULT ('') FOR [Phone2]
GO
/****** Object:  Default [DF_VendorContact_Fax1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Fax1]  DEFAULT ('') FOR [Fax1]
GO
/****** Object:  Default [DF_VendorContact_Fax2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Fax2]  DEFAULT ('') FOR [Fax2]
GO
/****** Object:  Default [DF_VendorContact_Mobile1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Mobile1]  DEFAULT ('') FOR [Mobile1]
GO
/****** Object:  Default [DF_VendorContact_Mobile2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Mobile2]  DEFAULT ('') FOR [Mobile2]
GO
/****** Object:  Default [DF_VendorContact_CPerson1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_CPerson1]  DEFAULT ('') FOR [CPerson1]
GO
/****** Object:  Default [DF_VendorContact_CPerson2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_CPerson2]  DEFAULT ('') FOR [CPerson2]
GO
/****** Object:  Default [DF_VendorContact_CDesignation1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_CDesignation1]  DEFAULT ('') FOR [CDesignation1]
GO
/****** Object:  Default [DF_VendorContact_CDesignation2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_CDesignation2]  DEFAULT ('') FOR [CDesignation2]
GO
/****** Object:  Default [DF_VendorContact_ContactNo1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_ContactNo1]  DEFAULT ('') FOR [ContactNo1]
GO
/****** Object:  Default [DF_VendorContact_ContactNo2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_ContactNo2]  DEFAULT ('') FOR [ContactNo2]
GO
/****** Object:  Default [DF_VendorContact_Email1]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Email1]  DEFAULT ('') FOR [Email1]
GO
/****** Object:  Default [DF_VendorContact_Email2]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_Email2]  DEFAULT ('') FOR [Email2]
GO
/****** Object:  Default [DF_VendorContact_WebName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorContact] ADD  CONSTRAINT [DF_VendorContact_WebName]  DEFAULT ('') FOR [WebName]
GO
/****** Object:  Default [DF_VendorExperience_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorExperience] ADD  CONSTRAINT [DF_VendorExperience_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_VendorExperience_WorkDescription]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorExperience] ADD  CONSTRAINT [DF_VendorExperience_WorkDescription]  DEFAULT ('') FOR [WorkDescription]
GO
/****** Object:  Default [DF_VendorExperience_ClientName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorExperience] ADD  CONSTRAINT [DF_VendorExperience_ClientName]  DEFAULT ('') FOR [ClientName]
GO
/****** Object:  Default [DF_VendorExperience_Value]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorExperience] ADD  CONSTRAINT [DF_VendorExperience_Value]  DEFAULT ((0)) FOR [Value]
GO
/****** Object:  Default [DF_VendorExperience_Period]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorExperience] ADD  CONSTRAINT [DF_VendorExperience_Period]  DEFAULT ('') FOR [Period]
GO
/****** Object:  Default [DF_VendorLocation_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorLocation] ADD  CONSTRAINT [DF_VendorLocation_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_VendorLocation_CityId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorLocation] ADD  CONSTRAINT [DF_VendorLocation_CityId]  DEFAULT ((0)) FOR [CityId]
GO
/****** Object:  Default [DF_VendorMaster_VendorName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_VendorName]  DEFAULT ('') FOR [VendorName]
GO
/****** Object:  Default [DF_VendorMaster_Supplier]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_Supplier]  DEFAULT ((0)) FOR [Supply]
GO
/****** Object:  Default [DF_VendorMaster_Contractor]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_Contractor]  DEFAULT ((0)) FOR [Contract]
GO
/****** Object:  Default [DF_VendorMaster_ServiceProvider]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_ServiceProvider]  DEFAULT ((0)) FOR [Service]
GO
/****** Object:  Default [DF_VendorMaster_RegAddress]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_RegAddress]  DEFAULT ('') FOR [RegAddress]
GO
/****** Object:  Default [DF_VendorMaster_CityId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_CityId]  DEFAULT ((0)) FOR [CityId]
GO
/****** Object:  Default [DF_VendorMaster_PinCode]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_PinCode]  DEFAULT ('') FOR [PinCode]
GO
/****** Object:  Default [DF_VendorStatutory_VendorID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_VendorID]  DEFAULT ((0)) FOR [VendorID]
GO
/****** Object:  Default [DF_VendorStatutory_FirmType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_FirmType]  DEFAULT ('') FOR [FirmType]
GO
/****** Object:  Default [DF_VendorStatutory_EYear]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_EYear]  DEFAULT ((0)) FOR [EYear]
GO
/****** Object:  Default [DF_Table_1_PanNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_Table_1_PanNo]  DEFAULT ('') FOR [PANNo]
GO
/****** Object:  Default [DF_VendorStatutory_TANNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_TANNo]  DEFAULT ('') FOR [TANNo]
GO
/****** Object:  Default [DF_VendorStatutory_CSTNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_CSTNo]  DEFAULT ('') FOR [CSTNo]
GO
/****** Object:  Default [DF_VendorStatutory_TINNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_TINNo]  DEFAULT ('') FOR [TINNo]
GO
/****** Object:  Default [DF_VendorStatutory_BankAccountNo]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_BankAccountNo]  DEFAULT ('') FOR [BankAccountNo]
GO
/****** Object:  Default [DF_VendorStatutory_AccountType]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_AccountType]  DEFAULT ('') FOR [AccountType]
GO
/****** Object:  Default [DF_VendorStatutory_BankName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_BankName]  DEFAULT ('') FOR [BankName]
GO
/****** Object:  Default [DF_VendorStatutory_BranchName]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_BranchName]  DEFAULT ('') FOR [BranchName]
GO
/****** Object:  Default [DF_VendorStatutory_BranchCode]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorStatutory] ADD  CONSTRAINT [DF_VendorStatutory_BranchCode]  DEFAULT ('') FOR [BranchCode]
GO
/****** Object:  Default [DF_VendorTerms_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorTerms] ADD  CONSTRAINT [DF_VendorTerms_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_VendorTerms_CreditDays]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorTerms] ADD  CONSTRAINT [DF_VendorTerms_CreditDays]  DEFAULT ((0)) FOR [CreditDays]
GO
/****** Object:  Default [DF_VendorTerms_TermsAndCondition]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorTerms] ADD  CONSTRAINT [DF_VendorTerms_TermsAndCondition]  DEFAULT ('') FOR [TermsAndCondition]
GO
/****** Object:  Default [DF_VendorTurnOver_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorTurnOver] ADD  CONSTRAINT [DF_VendorTurnOver_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_VendorTurnOver_FYear]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorTurnOver] ADD  CONSTRAINT [DF_VendorTurnOver_FYear]  DEFAULT ('') FOR [FYear]
GO
/****** Object:  Default [DF_VendorTurnOver_Value]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[VendorTurnOver] ADD  CONSTRAINT [DF_VendorTurnOver_Value]  DEFAULT ((0)) FOR [Value]
GO
/****** Object:  Default [DF_WorkGroup_VendorId]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[WorkGroup] ADD  CONSTRAINT [DF_WorkGroup_VendorId]  DEFAULT ((0)) FOR [VendorId]
GO
/****** Object:  Default [DF_WorkGroup_Work_Group_ID]    Script Date: 08/12/2010 12:37:27 ******/
ALTER TABLE [dbo].[WorkGroup] ADD  CONSTRAINT [DF_WorkGroup_Work_Group_ID]  DEFAULT ((0)) FOR [Work_Group_ID]
GO
