/****** Object:  Table [dbo].[CheckListMaster]    Script Date: 08/01/2013 17:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CheckListMaster](
	[CheckListId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NOT NULL CONSTRAINT [DF_CheckListMaster_Description]  DEFAULT (''),
	[Supply] [bit] NOT NULL CONSTRAINT [DF_CheckListMaster_Supply]  DEFAULT ((0)),
	[Contract] [bit] NOT NULL CONSTRAINT [DF_CheckListMaster_Contract]  DEFAULT ((0)),
	[Service] [bit] NOT NULL CONSTRAINT [DF_CheckListMaster_Service]  DEFAULT ((0)),
	[MaxPoint] [float] NOT NULL CONSTRAINT [DF_CheckListMaster_MaxPoint]  DEFAULT ((0)),
	[Approve] [bit] NOT NULL CONSTRAINT [DF_CheckListMaster_Approve]  DEFAULT ((0)),
 CONSTRAINT [PK_CheckListMaster] PRIMARY KEY CLUSTERED 
(
	[CheckListId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleMaster]    Script Date: 08/01/2013 17:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleMaster](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VehicleMaster_VendorId]  DEFAULT ((0)),
	[VehicleRegNo] [varchar](50) NOT NULL CONSTRAINT [DF_VehicleMaster_VehicleRegNo]  DEFAULT (''),
	[VehicleName] [varchar](200) NOT NULL CONSTRAINT [DF_VehicleMaster_VehicleName]  DEFAULT (''),
	[BLLen] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_BLLen]  DEFAULT ((0)),
	[BLBreadth] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_BLBredth]  DEFAULT ((0)),
	[BLHeight] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_BLHeight]  DEFAULT ((0)),
	[BLQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_BLQty]  DEFAULT ((0)),
	[TSMAXLen] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMAXLen]  DEFAULT ((0)),
	[TSMAXBreadth] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMAXBredth]  DEFAULT ((0)),
	[TSMAXHeight] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMAXHeight]  DEFAULT ((0)),
	[TSMAXQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMAXQty]  DEFAULT ((0)),
	[TSMinLen] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMinLen]  DEFAULT ((0)),
	[TSMinBreadth] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMinBredth]  DEFAULT ((0)),
	[TSMinHeight] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMinHeight]  DEFAULT ((0)),
	[TSMinQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_TSMinQty]  DEFAULT ((0)),
	[Total1] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_Total1]  DEFAULT ((0)),
	[Total2] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_Total2]  DEFAULT ((0)),
	[NetTotal] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VehicleMaster_NetTotal]  DEFAULT ((0)),
	[Remarks] [varchar](255) NOT NULL CONSTRAINT [DF_VehicleMaster_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_VehicleMaster] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Machinery]    Script Date: 08/01/2013 17:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Machinery](
	[MachineryTransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Machinery_VendorId]  DEFAULT ((0)),
	[Resource_ID] [int] NOT NULL CONSTRAINT [DF_Machinery_Resource_ID]  DEFAULT ((0)),
	[Qty] [float] NOT NULL CONSTRAINT [DF_Machinery_Qty]  DEFAULT ((0)),
	[Capacity] [varchar](100) NOT NULL CONSTRAINT [DF_Machinery_Capacity]  DEFAULT (''),
 CONSTRAINT [PK_Machinery] PRIMARY KEY CLUSTERED 
(
	[MachineryTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReqAnalTrans]    Script Date: 08/01/2013 17:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqAnalTrans](
	[RequestAHTransId] [int] IDENTITY(1,1) NOT NULL,
	[ReqTransId] [int] NOT NULL CONSTRAINT [DF_ReqAnalTrans_ReqTransId]  DEFAULT ((0)),
	[AnalysisId] [int] NOT NULL CONSTRAINT [DF_ReqAnalTrans_AnalysisId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_ReqAnalTrans_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_ReqAnalTrans_ItemId]  DEFAULT ((0)),
	[ReqQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_ReqQty]  DEFAULT ((0)),
	[IndentApproveQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_IndentApproveQty]  DEFAULT ((0)),
	[TransferApproveQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_TransferApproveQty]  DEFAULT ((0)),
	[BalQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_BalQty]  DEFAULT ((0)),
	[UnitId] [int] NOT NULL CONSTRAINT [DF_ReqAnalTrans_UnitId]  DEFAULT ((0)),
	[IndentQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_IndentQty]  DEFAULT ((0)),
	[TransferQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_TransferQty]  DEFAULT ((0)),
	[CancelQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_CancelQty]  DEFAULT ((0)),
	[TUnitId] [int] NOT NULL CONSTRAINT [DF_ReqAnalTrans_TUnitId]  DEFAULT ((0)),
	[TQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_TQty]  DEFAULT ((0)),
	[FFactor] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_FFactor]  DEFAULT ((0)),
	[TFactor] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_TFactor]  DEFAULT ((0)),
	[HireApproveQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_ReqAnalTrans_HireApproveQty]  DEFAULT ((0)),
 CONSTRAINT [PK_ReqAnalTrans] PRIMARY KEY CLUSTERED 
(
	[RequestAHTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestRegister]    Script Date: 08/01/2013 17:21:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestRegister](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestNo] [varchar](50) NOT NULL CONSTRAINT [DF_RequestRegister_RequestNo]  DEFAULT (''),
	[RequestDate] [datetime] NOT NULL CONSTRAINT [DF_Table_1_ReqDate]  DEFAULT (getdate()),
	[RequestType] [varchar](50) NOT NULL CONSTRAINT [DF_RequestRegister_RequestType]  DEFAULT (''),
	[CostCentreId] [int] NOT NULL CONSTRAINT [DF_RequestRegister_CostCentreId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_RequestRegister_VendorId]  DEFAULT ((0)),
	[CCReqNo] [varchar](20) NOT NULL CONSTRAINT [DF_RequestRegister_CCReqNo]  DEFAULT (''),
	[CReqNo] [varchar](20) NOT NULL CONSTRAINT [DF_RequestRegister_CReqNo]  DEFAULT (''),
	[RefNo] [varchar](20) NOT NULL CONSTRAINT [DF_RequestRegister_RefNo]  DEFAULT (''),
	[Narration] [varchar](8000) NOT NULL CONSTRAINT [DF_RequestRegister_Narration]  DEFAULT (''),
	[Freeze] [varchar](1) NOT NULL CONSTRAINT [DF_RequestRegister_Freeze]  DEFAULT (''),
	[Approve] [char](1) NOT NULL CONSTRAINT [DF_RequestRegister_Approve]  DEFAULT ('N'),
	[CreatedUserId] [int] NOT NULL CONSTRAINT [DF_RequestRegister_CreatedUserId]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_RequestRegister_CreatedDate]  DEFAULT (getdate()),
	[ModifiedUserId] [int] NOT NULL CONSTRAINT [DF_RequestRegister_ModifiedUserId]  DEFAULT ((0)),
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_RequestRegister_ModifiedDate]  DEFAULT (getdate()),
	[LSWithOutIOW] [bit] NOT NULL CONSTRAINT [DF_RequestRegister_LSWithOutIOW]  DEFAULT ((0)),
	[Ready] [bit] NOT NULL CONSTRAINT [DF_RequestRegister_Ready]  DEFAULT ((0)),
	[Urgent] [bit] NOT NULL CONSTRAINT [DF_RequestRegister_Urgent]  DEFAULT ((0)),
 CONSTRAINT [PK_RequestRegister] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorCodeType]    Script Date: 08/01/2013 17:22:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorCodeType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[CodePrefix] [varchar](5) NOT NULL CONSTRAINT [DF_VendorCodeType_CodePrefix]  DEFAULT (''),
	[CodeType] [bit] NOT NULL CONSTRAINT [DF_VendorCodeType_CodeType]  DEFAULT ((1)),
	[Suffix] [varchar](5) NOT NULL CONSTRAINT [DF_VendorCodeType_Suffix]  DEFAULT (''),
	[Width] [smallint] NOT NULL CONSTRAINT [DF_VendorCodeType_Width]  DEFAULT ((0)),
	[MaxNo] [int] NOT NULL CONSTRAINT [DF_VendorCodeType_MaxNo]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradeMaster]    Script Date: 08/01/2013 17:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradeMaster](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [varchar](50) NOT NULL CONSTRAINT [DF_GradeMaster_GradeName]  DEFAULT (''),
	[FValue] [float] NOT NULL CONSTRAINT [DF_GradeMaster_FromValue]  DEFAULT ((0)),
	[TValue] [float] NOT NULL CONSTRAINT [DF_GradeMaster_ToValue]  DEFAULT ((0)),
	[Approve] [bit] NOT NULL CONSTRAINT [DF_GradeMaster_Approve]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorMaster]    Script Date: 08/01/2013 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorMaster](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](200) NOT NULL CONSTRAINT [DF_VendorMaster_VendorName]  DEFAULT (''),
	[UserName] [varchar](50) NOT NULL CONSTRAINT [DF_VendorMaster_UserName]  DEFAULT (''),
	[Password] [varchar](50) NOT NULL CONSTRAINT [DF_VendorMaster_Password]  DEFAULT (''),
	[Supply] [bit] NOT NULL CONSTRAINT [DF_VendorMaster_Supplier]  DEFAULT ((0)),
	[Contract] [bit] NOT NULL CONSTRAINT [DF_VendorMaster_Contractor]  DEFAULT ((0)),
	[Service] [bit] NOT NULL CONSTRAINT [DF_VendorMaster_ServiceProvider]  DEFAULT ((0)),
	[ServiceTypeId] [int] NOT NULL CONSTRAINT [DF_VendorMaster_ServiceTypeId]  DEFAULT ((0)),
	[RegAddress] [varchar](255) NOT NULL CONSTRAINT [DF_VendorMaster_RegAddress]  DEFAULT (''),
	[CityId] [int] NOT NULL CONSTRAINT [DF_VendorMaster_CityId]  DEFAULT ((0)),
	[PinCode] [varchar](10) NOT NULL CONSTRAINT [DF_VendorMaster_PinCode]  DEFAULT (''),
	[SupplyType] [char](1) NOT NULL CONSTRAINT [DF_VendorMaster_SupplyType]  DEFAULT (''),
	[Company] [bit] NOT NULL CONSTRAINT [DF_VendorMaster_Company]  DEFAULT ((0)),
	[WebUpdate] [bit] NOT NULL CONSTRAINT [DF_VendorMaster_WebUpdate]  DEFAULT ((0)),
	[Approve] [char](1) NOT NULL CONSTRAINT [DF_VendorMaster_Approve_1]  DEFAULT ('N'),
	[ChequeNo] [varchar](255) NOT NULL CONSTRAINT [DF_VendorMaster_ChequeNo]  DEFAULT (''),
	[Code] [nvarchar](12) NOT NULL CONSTRAINT [DF_VendorMaster_Code]  DEFAULT (''),
 CONSTRAINT [PK_VendorMaster] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorLocation]    Script Date: 08/01/2013 17:22:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorLocation](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorLocation_VendorId]  DEFAULT ((0)),
	[CityId] [int] NOT NULL CONSTRAINT [DF_VendorLocation_CityId]  DEFAULT ((0)),
 CONSTRAINT [PK_VendorLocation] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkGroup]    Script Date: 08/01/2013 17:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkGroup](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_WorkGroup_VendorId]  DEFAULT ((0)),
	[Work_Group_ID] [int] NOT NULL CONSTRAINT [DF_WorkGroup_Work_Group_ID]  DEFAULT ((0)),
 CONSTRAINT [PK_WorkGroup] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC,
	[Work_Group_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REQWBSTrans]    Script Date: 08/01/2013 17:21:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REQWBSTrans](
	[ReqTransId] [int] NOT NULL CONSTRAINT [DF_REQWBSTrans_WOTransId]  DEFAULT ((0)),
	[AnalysisId] [int] NOT NULL CONSTRAINT [DF_REQWBSTrans_AnalysisId]  DEFAULT ((0)),
	[Qty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQWBSTrans_Qty]  DEFAULT ((0)),
	[BalQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQWBSTrans_BalQty]  DEFAULT ((0)),
	[WOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQWBSTrans_WOQty]  DEFAULT ((0)),
	[AssetResourceId] [int] NOT NULL CONSTRAINT [DF_REQWBSTrans_AssetResourceId]  DEFAULT ((0)),
	[SOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQWBSTrans_SOQty]  DEFAULT ((0)),
	[HOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQWBSTrans_HOQty]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReqSchedule]    Script Date: 08/01/2013 17:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqSchedule](
	[RequestTransId] [int] NOT NULL CONSTRAINT [DF_RequirmentSchedule_RequestTransId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_RequirmentSchedule_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_ReqSchedule_ItemId]  DEFAULT ((0)),
	[Qty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequirmentSchedule_Qty]  DEFAULT ((0)),
	[ReqDate] [datetime] NOT NULL CONSTRAINT [DF_RequirmentSchedule_ReqDate]  DEFAULT (getdate())
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorQuotationRemark]    Script Date: 08/01/2013 17:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorQuotationRemark](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationRemark_QuotationId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationRemark_VendorId]  DEFAULT ((0)),
	[Remarks] [varchar](8000) NOT NULL CONSTRAINT [DF_VendorQuotationRemark_Remarks]  DEFAULT ('')
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceTrans]    Script Date: 08/01/2013 17:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Service_VendorId]  DEFAULT ((0)),
	[ServiceId] [int] NOT NULL CONSTRAINT [DF_Service_ServiceId]  DEFAULT ((0)),
 CONSTRAINT [PK_ServiceTrans] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorSupplierDet]    Script Date: 08/01/2013 17:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorSupplierDet](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorSupplierDet_VendorId]  DEFAULT ((0)),
	[SupplierType] [char](1) NOT NULL CONSTRAINT [DF_VendorSupplierDet_SupplierType]  DEFAULT (''),
	[SupplierVendorId] [int] NOT NULL CONSTRAINT [DF_VendorSupplierDet_SupplierVendorId]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradeTrans]    Script Date: 08/01/2013 17:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_GradeTrans_VendorId]  DEFAULT ((0)),
	[CGradeId] [int] NOT NULL CONSTRAINT [DF_GradeTrans_CGradeId]  DEFAULT ((0)),
	[SGradeId] [int] NOT NULL CONSTRAINT [DF_GradeTrans_SGradeId]  DEFAULT ((0)),
	[HGradeId] [int] NOT NULL CONSTRAINT [DF_GradeTrans_HGradeId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotOMultiVendor]    Script Date: 08/01/2013 17:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotOMultiVendor](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotOMultiVendor_QuotationId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotOMultiVendor_VendorId]  DEFAULT ((0)),
	[PRank] [int] NOT NULL CONSTRAINT [DF_QuotOMultiVendor_PRank]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompQual]    Script Date: 08/01/2013 17:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompQual](
	[CompQualId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_IPDCompQual_RegisterId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_IPDCompQual_IPDTransId]  DEFAULT ((0)),
	[QualifierId] [int] NOT NULL CONSTRAINT [DF_IPDCompQual_QualifierId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_IPDCompQual_ComponentId]  DEFAULT ((0)),
	[BrandId] [int] NOT NULL CONSTRAINT [DF_IPDCompQual_BrandId]  DEFAULT ((0)),
	[AddLessFlag] [varchar](1) NOT NULL CONSTRAINT [DF_IPDCompQual_AddLessFlag]  DEFAULT (''),
	[Expression] [varchar](100) NOT NULL CONSTRAINT [DF_IPDCompQual_Expression]  DEFAULT (''),
	[Amount] [decimal](18, 5) NOT NULL CONSTRAINT [DF_IPDCompQual_Amount]  DEFAULT ((0)),
	[Type] [varchar](1) NOT NULL CONSTRAINT [DF_IPDCompQual_Type]  DEFAULT (''),
 CONSTRAINT [PK_IPDCompQual] PRIMARY KEY CLUSTERED 
(
	[CompQualId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CertificateMaster]    Script Date: 08/01/2013 17:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CertificateMaster](
	[CertificateId] [int] IDENTITY(1,1) NOT NULL,
	[CerDescription] [varchar](100) NOT NULL CONSTRAINT [DF_CertificateMaster_CerDescription]  DEFAULT (''),
	[Date] [datetime] NOT NULL CONSTRAINT [DF_CertificateMaster_Date]  DEFAULT (getdate()),
	[Type] [varchar](100) NOT NULL CONSTRAINT [DF_CertificateMaster_Type]  DEFAULT (''),
	[UpLoad] [varchar](255) NOT NULL CONSTRAINT [DF_CertificateMaster_UpLoad]  DEFAULT (''),
 CONSTRAINT [PK_CertificateMaster] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Login]    Script Date: 08/01/2013 17:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Login](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](255) NULL,
	[pwd] [varchar](50) NULL,
	[VendorId] [int] NULL,
	[email] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 08/01/2013 17:20:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[RegisterId] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [datetime] NULL,
	[RegNo] [varchar](100) NOT NULL CONSTRAINT [DF_Registration_RegNo]  DEFAULT (''),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Registration_VendorId]  DEFAULT ((0)),
	[Supply] [bit] NOT NULL CONSTRAINT [DF_Registration_Supply]  DEFAULT ((0)),
	[Contract] [bit] NOT NULL CONSTRAINT [DF_Registration_Contract]  DEFAULT ((0)),
	[Service] [bit] NOT NULL CONSTRAINT [DF_Registration_Service]  DEFAULT ((0)),
	[SGradeId] [int] NOT NULL CONSTRAINT [DF_Registration_SGradeId]  DEFAULT ((0)),
	[CGradeId] [int] NOT NULL CONSTRAINT [DF_Registration_CGradeId]  DEFAULT ((0)),
	[HGradeId] [int] NOT NULL CONSTRAINT [DF_Registration_HGradeId]  DEFAULT ((0)),
	[SFDate] [datetime] NULL,
	[STDate] [datetime] NULL,
	[CFDate] [datetime] NULL,
	[CTDate] [datetime] NULL,
	[HFDate] [datetime] NULL,
	[HTDate] [datetime] NULL,
	[SLifeTime] [bit] NOT NULL CONSTRAINT [DF_Registration_SLifeTime]  DEFAULT ((0)),
	[CLifeTime] [bit] NOT NULL CONSTRAINT [DF_Registration_CLifeTime]  DEFAULT ((0)),
	[HLifeTime] [bit] NOT NULL CONSTRAINT [DF_Registration_HLifeTime]  DEFAULT ((0)),
	[Remarks] [varchar](255) NOT NULL CONSTRAINT [DF_Registration_Remarks]  DEFAULT (''),
	[Approve] [bit] NOT NULL CONSTRAINT [DF_Registration_Approve]  DEFAULT ((0)),
	[AlertDate] [datetime] NULL,
	[AlertReminder] [int] NOT NULL CONSTRAINT [DF_Registration_AlertReminder]  DEFAULT ((0)),
	[Alert] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegisterId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 08/01/2013 17:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceType](
	[ServiceType] [varchar](100) NOT NULL CONSTRAINT [DF_ServiceType_ServiceType]  DEFAULT (''),
	[ServiceTypeId] [int] NOT NULL CONSTRAINT [DF_ServiceType_ServiceTypeId]  DEFAULT ((0)),
	[SectionId] [int] NOT NULL CONSTRAINT [DF_ServiceType_TDSSection]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CertificateTrans]    Script Date: 08/01/2013 17:19:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CertificateTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_CertificateTrans_VendorId]  DEFAULT ((0)),
	[CertificateId] [int] NOT NULL CONSTRAINT [DF_CertificateTrans_CertificateId]  DEFAULT ((0)),
 CONSTRAINT [PK_CertificateTrans] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotLogistic]    Script Date: 08/01/2013 17:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotLogistic](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotLogistic_PORegisterId]  DEFAULT ((0)),
	[IsLogistics] [bit] NOT NULL CONSTRAINT [DF_Table_1_ISLogistics]  DEFAULT ((0)),
	[ProviderId] [int] NOT NULL CONSTRAINT [DF_QuotLogistic_ProviderId]  DEFAULT ((0)),
	[VehicleId] [int] NOT NULL CONSTRAINT [DF_QuotLogistic_VehicleId]  DEFAULT ((0)),
	[HandlingCost] [decimal](18, 3) NOT NULL CONSTRAINT [DF_QuotLogistic_HandlingCost]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotLogistic_1] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegTransLatest]    Script Date: 08/01/2013 17:20:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegTransLatest](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[RegisterId] [int] NOT NULL CONSTRAINT [DF_RegTransTemp_RegisterId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_RegTransTemp_VendorId]  DEFAULT ((0)),
	[Supply] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_Supply]  DEFAULT ((0)),
	[Contract] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_Contract]  DEFAULT ((0)),
	[Service] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_Service]  DEFAULT ((0)),
	[STDate] [datetime] NULL,
	[CTDate] [datetime] NULL,
	[HTDate] [datetime] NULL,
	[SLife] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_SLife]  DEFAULT ((0)),
	[CLife] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_CLift]  DEFAULT ((0)),
	[HLife] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_HLife]  DEFAULT ((0)),
	[SSuspend] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_SSuspend]  DEFAULT ((0)),
	[CSuspend] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_CSuspend]  DEFAULT ((0)),
	[HSuspend] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_HSuspend]  DEFAULT ((0)),
	[SBlackList] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_SBlackList]  DEFAULT ((0)),
	[CBlackList] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_CBlackList]  DEFAULT ((0)),
	[HBlackList] [bit] NOT NULL CONSTRAINT [DF_RegTransTemp_HBlackList]  DEFAULT ((0)),
	[SGradeId] [int] NOT NULL CONSTRAINT [DF_RegTransTemp_SGradeId]  DEFAULT ((0)),
	[CGradeId] [int] NOT NULL CONSTRAINT [DF_RegTransTemp_CGradeId]  DEFAULT ((0)),
	[HGradeID] [int] NOT NULL CONSTRAINT [DF_RegTransTemp_HGradeID]  DEFAULT ((0)),
 CONSTRAINT [PK_RegTransLatest] PRIMARY KEY CLUSTERED 
(
	[TransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTerms]    Script Date: 08/01/2013 17:20:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentTerms](
	[PaymentTermsId] [int] IDENTITY(1,1) NOT NULL,
	[Registerid] [int] NOT NULL CONSTRAINT [DF_PaymentTerms_Registerid]  DEFAULT ((0)),
	[Advance] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_Advance]  DEFAULT ((0)),
	[AdvRate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_AdvRate]  DEFAULT ((0)),
	[AdvAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_AdvAmount]  DEFAULT ((0)),
	[AdjustAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_AdjustAmount]  DEFAULT ((0)),
	[AdvNOD] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_AdvNOD]  DEFAULT ((0)),
	[AgainstDel] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_AgainstDel]  DEFAULT ((0)),
	[ADelRate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ADelRate]  DEFAULT ((0)),
	[ADelAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ADelAmount]  DEFAULT ((0)),
	[ADelNOD] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ADelNOD]  DEFAULT ((0)),
	[AgainstCertify] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_AgainstCertify]  DEFAULT ((0)),
	[ACertifyRate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ACertifyRate]  DEFAULT ((0)),
	[ACertifyAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ACertifyAmount]  DEFAULT ((0)),
	[ACertifyNOD] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ACertifyNOD]  DEFAULT ((0)),
	[AgainstBill] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_AgainstBill]  DEFAULT ((0)),
	[ABillRate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ABillRate]  DEFAULT ((0)),
	[ABillAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ABillAmount]  DEFAULT ((0)),
	[ABillNOD] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ABillNOD]  DEFAULT ((0)),
	[PaymentMode] [varchar](50) NOT NULL CONSTRAINT [DF_PaymentTerms_PaymentMode]  DEFAULT (''),
	[WOUptoDate] [datetime] NOT NULL CONSTRAINT [DF_PaymentTerms_WOUptoDate]  DEFAULT (getdate()),
	[DeliveryUptoDate] [datetime] NOT NULL CONSTRAINT [DF_PaymentTerms_DeliveryUptoDate]  DEFAULT (getdate()),
	[NOD] [int] NOT NULL CONSTRAINT [DF_PaymentTerms_NOD]  DEFAULT ((0)),
	[TimeDelay] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_TimeDelay]  DEFAULT ((0)),
	[QualityPenalty] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_QualityPenalty]  DEFAULT ((0)),
	[TestCertifyRqd] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_TestCertifyRqd]  DEFAULT ((0)),
	[IncludeTransport] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_IncludeTransport]  DEFAULT ((0)),
	[Loading] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_Loading]  DEFAULT ((0)),
	[Unloading] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_Unloading]  DEFAULT ((0)),
	[Payment] [bit] NOT NULL CONSTRAINT [DF_WOWOPaymentTerms_Payment]  DEFAULT ((0)),
	[DeliveryUpto] [bit] NOT NULL DEFAULT ((0)),
	[TDPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_WOWOPaymentTerms_TDPer]  DEFAULT ((0)),
	[TDVal] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_TDVal]  DEFAULT ((0)),
	[TDDays] [int] NOT NULL CONSTRAINT [DF_PaymentTerms_TDDays]  DEFAULT ((0)),
	[QPPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_QPPer]  DEFAULT ((0)),
	[QPVal] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_QPVal]  DEFAULT ((0)),
	[LPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_LPer]  DEFAULT ((0)),
	[LVal] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_LVal]  DEFAULT ((0)),
	[ULPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ULPer]  DEFAULT ((0)),
	[ULVal] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_ULVal]  DEFAULT ((0)),
	[TRPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_TRPer]  DEFAULT ((0)),
	[TRVal] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PaymentTerms_TRVal]  DEFAULT ((0)),
	[TermsAndCondition] [varchar](8000) NOT NULL CONSTRAINT [DF_PaymentTerms_TermsAndCondition]  DEFAULT (''),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_PaymentTerms_VendorId]  DEFAULT ((0)),
	[IsDefault] [bit] NOT NULL CONSTRAINT [DF_PaymentTerms_IsDefault]  DEFAULT ((0)),
 CONSTRAINT [PK_PaymentTerms] PRIMARY KEY CLUSTERED 
(
	[PaymentTermsId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VMRate_Q]    Script Date: 08/01/2013 17:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VMRate_Q](
	[QTransId] [int] IDENTITY(1,1) NOT NULL,
	[QualifierId] [int] NOT NULL CONSTRAINT [DF_VMRate_Q_QualifierId]  DEFAULT ((0)),
	[Add_Less_Flag] [varchar](1) NOT NULL CONSTRAINT [DF_VMRate_Q_Add_Less_Flag]  DEFAULT ('N'),
	[ExpPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_ExpPer]  DEFAULT ((0)),
	[SurCharge] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_SurCharge]  DEFAULT ((0)),
	[Amount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_Amount]  DEFAULT ((0)),
	[EDCess] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_EDCess]  DEFAULT ((0)),
	[Expression] [varchar](100) NOT NULL CONSTRAINT [DF_VMRate_Q_Expression]  DEFAULT (''),
	[ExpValue] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_ExpValue]  DEFAULT ((0)),
	[ExpPerValue] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_ExpPerValue]  DEFAULT ((0)),
	[SurValue] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_SurValue]  DEFAULT ((0)),
	[EDValue] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_EDValue]  DEFAULT ((0)),
	[HEDPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_HEDPer]  DEFAULT ((0)),
	[HEDValue] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_HEDValue]  DEFAULT ((0)),
	[NetPer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_NetPer]  DEFAULT ((0)),
	[TaxablePer] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_TaxablePer]  DEFAULT ((0)),
	[TaxableValue] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VMRate_Q_TaxableValue]  DEFAULT ((0)),
	[QRegisterID] [int] NOT NULL CONSTRAINT [DF_VMRate_Q_QRegisterID]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_VMRate_Q_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_VMRate_Q_ItemId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VMRate_Q_VendorId]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorAnalysisRegister]    Script Date: 08/01/2013 17:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorAnalysisRegister](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_VendorAnalysisRegister_QuotationId]  DEFAULT ((0)),
	[Approve] [char](1) NOT NULL CONSTRAINT [DF_VendorAnalysisRegister_Approve]  DEFAULT ('N'),
	[Ready] [bit] NOT NULL CONSTRAINT [DF_VendorAnalysisRegister_Ready]  DEFAULT ((0)),
 CONSTRAINT [PK_VendorAnalysisRegister] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotLogisticService]    Script Date: 08/01/2013 17:20:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotLogisticService](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_Table_1_LogisticsId]  DEFAULT ((0)),
	[ServiceId] [int] NOT NULL CONSTRAINT [DF_QuotLogisticsService_ServiceId]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotLogisticsService] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC,
	[ServiceId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotTempTerms]    Script Date: 08/01/2013 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotTempTerms](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotTempTerms_QuotationId]  DEFAULT ((0)),
	[Title] [varchar](max) NOT NULL CONSTRAINT [DF_QuotTempTerms_Title]  DEFAULT (''),
	[Value] [varchar](max) NOT NULL CONSTRAINT [DF_QuotTempTerms_Value]  DEFAULT ('')
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequestTrans]    Script Date: 08/01/2013 17:21:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestTrans](
	[RequestTransId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_RequestId]  DEFAULT ((0)),
	[IowId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_IowId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_ResourceId]  DEFAULT ((0)),
	[Quantity] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_Quantity]  DEFAULT ((0)),
	[IndentApproveQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_IndentApproveQty]  DEFAULT ((0)),
	[TransferApproveQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_TransferApproveQty]  DEFAULT ((0)),
	[IndentQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_IndentQty]  DEFAULT ((0)),
	[TransferQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_TransferQty]  DEFAULT ((0)),
	[WOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_RequestTrans_WOQty]  DEFAULT ((0)),
	[BalQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_BalQty]  DEFAULT ((0)),
	[CancelQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_CancelQty]  DEFAULT ((0)),
	[AssetQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_AssetQty]  DEFAULT ((0)),
	[UnitId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_UnitId]  DEFAULT ((0)),
	[ReqDate] [datetime] NOT NULL CONSTRAINT [DF_RequestTrans_ReqDate]  DEFAULT (getdate()),
	[Remarks] [varchar](200) NOT NULL CONSTRAINT [DF_RequestTrans_Remarks]  DEFAULT (''),
	[AnalysisHeadId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_AnalysisHeadId]  DEFAULT ((0)),
	[CancelRemarks] [varchar](max) NOT NULL CONSTRAINT [DF_RequestTrans_CancelRemarks]  DEFAULT (''),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_ItemId]  DEFAULT ((0)),
	[TUnitId] [int] NOT NULL CONSTRAINT [DF_RequestTrans_FUnitId]  DEFAULT ((0)),
	[TQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_FQty]  DEFAULT ((0)),
	[FFactor] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_FFactor]  DEFAULT ((0)),
	[TFactor] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_TFactor]  DEFAULT ((0)),
	[SOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_RequestTrans_SOQty]  DEFAULT ((0)),
	[HOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_RequestTrans_HOQty]  DEFAULT ((0)),
	[HireApproveQty] [decimal](18, 5) NOT NULL CONSTRAINT [DF_RequestTrans_HireApproveQty]  DEFAULT ((0)),
	[RateType] [char](1) NOT NULL CONSTRAINT [DF_RequestTrans_RateType]  DEFAULT ('L'),
	[Specification] [varchar](8000) NOT NULL CONSTRAINT [DF_RequestTrans_Description]  DEFAULT (''),
 CONSTRAINT [PK_RequestTrans] PRIMARY KEY CLUSTERED 
(
	[RequestTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotTransCertificate]    Script Date: 08/01/2013 17:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotTransCertificate](
	[QuotTransId] [int] NOT NULL CONSTRAINT [DF_QuotTransCertificate_QuotTransId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_QuotTransCertificate_ResourceId]  DEFAULT ((0)),
	[CertificateId] [int] NOT NULL CONSTRAINT [DF_QuotTransCertificate_CertificateId]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotTransCertificate] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC,
	[QuotTransId] ASC,
	[ResourceId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityTrans]    Script Date: 08/01/2013 17:19:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Activity_VendorId]  DEFAULT ((0)),
	[Resource_Group_ID] [int] NOT NULL CONSTRAINT [DF_Activity_Resource_ID]  DEFAULT ((0)),
 CONSTRAINT [PK_ActivityTrans] PRIMARY KEY CLUSTERED 
(
	[Resource_Group_ID] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorQuotationTrans]    Script Date: 08/01/2013 17:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorQuotationTrans](
	[VendorQuotationId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationTrans_QuotationId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationTrans_VendorId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationTrans_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationTrans_ItemId]  DEFAULT ((0)),
	[IOWId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationTrans_RIOWId]  DEFAULT ((0)),
	[Quantity] [decimal](18, 5) NOT NULL CONSTRAINT [DF_VendorQuotationTrans_Quantity]  DEFAULT ((0)),
	[Rate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VendorQuotationTrans_Rate]  DEFAULT ((0)),
	[QRate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VendorQuotationTrans_QRate]  DEFAULT ((0)),
	[Amount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VendorQuotationTrans_Amount]  DEFAULT ((0)),
	[UnitId] [int] NOT NULL CONSTRAINT [DF_VendorQuotationTrans_UnitId]  DEFAULT ((0)),
 CONSTRAINT [PK_VendorQuotationTrans] PRIMARY KEY CLUSTERED 
(
	[VendorQuotationId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportMaster]    Script Date: 08/01/2013 17:21:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransportMaster](
	[TransportId] [int] IDENTITY(1,1) NOT NULL,
	[TransportName] [varchar](200) NOT NULL CONSTRAINT [DF_TransportMaster_TransportName]  DEFAULT (''),
 CONSTRAINT [PK_TransportMaster] PRIMARY KEY CLUSTERED 
(
	[TransportId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HireMachineryTrans]    Script Date: 08/01/2013 17:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HireMachineryTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_HireMachineryTrans_VendorId]  DEFAULT ((0)),
	[Resource_ID] [int] NOT NULL CONSTRAINT [DF_HireMachineryTrans_Resource_ID]  DEFAULT ((0)),
 CONSTRAINT [PK_HireMachineryTrans] PRIMARY KEY CLUSTERED 
(
	[Resource_ID] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorTransport]    Script Date: 08/01/2013 17:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorTransport](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorTransport_VendorId]  DEFAULT ((0)),
	[TransportId] [int] NOT NULL CONSTRAINT [DF_VendorTransport_TransportId]  DEFAULT ((0)),
 CONSTRAINT [PK_VendorTransport] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC,
	[TransportId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotationRegister]    Script Date: 08/01/2013 17:20:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationRegister](
	[QuotationId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationNo] [varchar](50) NOT NULL CONSTRAINT [DF_QuotationRegister_QuotationNo]  DEFAULT (''),
	[QuotationDate] [datetime] NOT NULL CONSTRAINT [DF_QuotationRegister_QuotationDate]  DEFAULT (getdate()),
	[QuotationType] [varchar](50) NOT NULL CONSTRAINT [DF_QuotationRegister_QType]  DEFAULT (''),
	[TermsAndCondition] [varchar](8000) NOT NULL CONSTRAINT [DF_QuotationRegister_TermsAndCondition]  DEFAULT (''),
	[CostCentreId] [int] NOT NULL CONSTRAINT [DF_QuotationRegister_CostCentreID]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotationRegister_VendorId]  DEFAULT ((0)),
	[Narration] [varchar](8000) NOT NULL CONSTRAINT [DF_QuotationRegister_Narration]  DEFAULT (''),
	[WebUpdate] [bit] NOT NULL CONSTRAINT [DF_QuotationRegister_WebUpdate]  DEFAULT ((0)),
	[Approve] [char](1) NOT NULL CONSTRAINT [DF_QuotationRegister_Approve]  DEFAULT ('N'),
	[Ready] [bit] NOT NULL CONSTRAINT [DF_QuotationRegister_Ready]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotationRegister] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[REQIOWTrans]    Script Date: 08/01/2013 17:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REQIOWTrans](
	[ReqTransID] [int] NOT NULL CONSTRAINT [DF_REQIOWTrans_ReqTransID]  DEFAULT ((0)),
	[IOW_ID] [int] NOT NULL CONSTRAINT [DF_REQIOWTrans_IOW_ID]  DEFAULT ((0)),
	[Qty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQIOWTrans_Qty]  DEFAULT ((0)),
	[AnalysisHeadId] [int] NOT NULL CONSTRAINT [DF_REQIOWTrans_AnalysisHeadId]  DEFAULT ((0)),
	[BalQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQIOWTrans_BalQty]  DEFAULT ((0)),
	[WOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQIOWTrans_WOQty]  DEFAULT ((0)),
	[AssetResourceId] [int] NOT NULL CONSTRAINT [DF_REQIOWTrans_AssetResId]  DEFAULT ((0)),
	[LbrResTransId] [int] NOT NULL CONSTRAINT [DF_REQIOWTrans_LbrResTransId]  DEFAULT ((0)),
	[SOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQIOWTrans_SOQty]  DEFAULT ((0)),
	[HOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_REQIOWTrans_HOQty]  DEFAULT ((0)),
	[SubIOWId] [int] NOT NULL CONSTRAINT [DF_REQIOWTrans_SubIOWId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VAResourceRate]    Script Date: 08/01/2013 17:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VAResourceRate](
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_VAResourceRate_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_VAResourceRate_ItemId]  DEFAULT ((0)),
	[CostCentreId] [int] NOT NULL CONSTRAINT [DF_VAResourceRate_CostCentreId]  DEFAULT ((0)),
	[Rate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VAResourceRate_Rate]  DEFAULT ((0)),
	[QRate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_VAResourceRate_QRate]  DEFAULT ((0)),
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_VAResourceRate_QuotationId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VAResourceRate_VendorId]  DEFAULT ((0)),
	[UnitId] [int] NOT NULL CONSTRAINT [DF_VAResourceRate_UnitId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialGroupTrans]    Script Date: 08/01/2013 17:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaterialGroupTrans](
	[VendorID] [int] NOT NULL CONSTRAINT [DF_MaterialGroupTrans_VendorID]  DEFAULT ((0)),
	[Resource_Group_ID] [int] NOT NULL CONSTRAINT [DF_MaterialGroupTrans_Resource_Group_ID]  DEFAULT ((0)),
	[Priority] [char](1) NOT NULL CONSTRAINT [DF_MaterialGroupTrans_Priority]  DEFAULT (''),
	[SupplyType] [char](1) NOT NULL CONSTRAINT [DF_MaterialGroupTrans_SupplyType]  DEFAULT (''),
	[LeadTime] [int] NOT NULL CONSTRAINT [DF_MaterialGroupTrans_LeadTime]  DEFAULT ((0)),
	[CreditDays] [int] NOT NULL CONSTRAINT [DF_MaterialGroupTrans_CreditDays]  DEFAULT ((0)),
 CONSTRAINT [PK_MaterialGroupTrans] PRIMARY KEY CLUSTERED 
(
	[Resource_Group_ID] ASC,
	[VendorID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotPaymentTerms]    Script Date: 08/01/2013 17:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotPaymentTerms](
	[TermsTransId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotPaymentTerms_TermsId]  DEFAULT ((0)),
	[TermsId] [int] NOT NULL CONSTRAINT [DF_QuotPaymentTerms_QuotationId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotPaymentTerms_VendorId]  DEFAULT ((0)),
	[ValueFromNet] [int] NOT NULL CONSTRAINT [DF_QuotPaymentTerms_ValueFrom]  DEFAULT ((0)),
	[Per] [decimal](18, 3) NOT NULL CONSTRAINT [DF__QuotPayment__Per__359DCDD0]  DEFAULT ((0)),
	[Value] [decimal](18, 3) NOT NULL CONSTRAINT [DF__QuotPayme__Value__3691F209]  DEFAULT ((0)),
	[Period] [decimal](18, 3) NOT NULL CONSTRAINT [DF_QuotPaymentTerms_Period]  DEFAULT ((0)),
	[TDate] [datetime] NULL,
	[TString] [varchar](255) NOT NULL CONSTRAINT [DF_QuotPaymentTerms_TString]  DEFAULT (''),
	[AdjustAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_QuotPaymentTerms_AdjustAmount]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorTurnOver]    Script Date: 08/01/2013 17:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorTurnOver](
	[TurnOverId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorTurnOver_VendorId]  DEFAULT ((0)),
	[FYear] [varchar](50) NOT NULL CONSTRAINT [DF_VendorTurnOver_FYear]  DEFAULT (''),
	[Value] [float] NOT NULL CONSTRAINT [DF_VendorTurnOver_Value]  DEFAULT ((0)),
 CONSTRAINT [PK_VendorTurnOver] PRIMARY KEY CLUSTERED 
(
	[TurnOverId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaterialTrans]    Script Date: 08/01/2013 17:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaterialTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_MaterialTrans_VendorId]  DEFAULT ((0)),
	[Resource_Id] [int] NOT NULL CONSTRAINT [DF_MaterialTrans_Resource_Id]  DEFAULT ((0)),
	[Priority] [char](1) NOT NULL CONSTRAINT [DF_MaterialTrans_Priority]  DEFAULT (''),
	[SupplyType] [char](1) NOT NULL CONSTRAINT [DF_MaterialTrans_SupplyType]  DEFAULT (''),
	[LeadTime] [int] NOT NULL CONSTRAINT [DF_MaterialTrans_LeadTime]  DEFAULT ((0)),
	[CreditDays] [int] NOT NULL CONSTRAINT [DF_MaterialTrans_CreditDays]  DEFAULT ((0)),
	[ContactPerson] [varchar](100) NOT NULL CONSTRAINT [DF_MaterialTrans_ContactPerson]  DEFAULT (''),
	[ContactNo] [varchar](13) NOT NULL CONSTRAINT [DF_MaterialTrans_ContactNo]  DEFAULT (''),
	[Email] [varchar](50) NOT NULL CONSTRAINT [DF_MaterialTrans_Email]  DEFAULT (''),
 CONSTRAINT [PK_MaterialTrans] PRIMARY KEY CLUSTERED 
(
	[Resource_Id] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorResGroupTrans]    Script Date: 08/01/2013 17:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorResGroupTrans](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorResGroupTrans_VendorId]  DEFAULT ((0)),
	[Resource_Group_ID] [int] NOT NULL CONSTRAINT [DF_VendorResGroupTrans_VendorGroupId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorStatutory]    Script Date: 08/01/2013 17:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorStatutory](
	[VendorID] [int] NOT NULL CONSTRAINT [DF_VendorStatutory_VendorID]  DEFAULT ((0)),
	[FirmType] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_FirmType]  DEFAULT (''),
	[EYear] [int] NOT NULL CONSTRAINT [DF_VendorStatutory_EYear]  DEFAULT ((0)),
	[PANNo] [varchar](50) NOT NULL CONSTRAINT [DF_Table_1_PanNo]  DEFAULT (''),
	[TANNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_TANNo]  DEFAULT (''),
	[CSTNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_CSTNo]  DEFAULT (''),
	[TINNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_TINNo]  DEFAULT (''),
	[ServiceTaxNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_ServiceTaxNo]  DEFAULT (''),
	[TNGSTNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_TNGSTNo]  DEFAULT (''),
	[BankAccountNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_BankAccountNo]  DEFAULT (''),
	[AccountType] [char](1) NOT NULL CONSTRAINT [DF_VendorStatutory_AccountType]  DEFAULT (''),
	[BankName] [varchar](100) NOT NULL CONSTRAINT [DF_VendorStatutory_BankName]  DEFAULT (''),
	[BranchName] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_BranchName]  DEFAULT (''),
	[BranchCode] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_BranchCode]  DEFAULT (''),
	[MICRCode] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_MICRCode]  DEFAULT (''),
	[IFSCCode] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_IFSCCode]  DEFAULT (''),
	[SSIREGDNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_SSIREGDNo]  DEFAULT (''),
	[ServiceTaxCir] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_ServiceTaxCir]  DEFAULT (''),
	[EPFNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_EPFNo]  DEFAULT (''),
	[ESINo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_ESINo]  DEFAULT (''),
	[ExciseVendor] [bit] NOT NULL CONSTRAINT [DF_VendorStatutory_ExciseVendor]  DEFAULT ((0)),
	[ExciseRegNo] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_ExciseRegNo]  DEFAULT (''),
	[Excisedivision] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_Excisedivision]  DEFAULT (''),
	[ExciseRange] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_ExciseRange]  DEFAULT (''),
	[ECCno] [varchar](50) NOT NULL CONSTRAINT [DF_VendorStatutory_ECCno]  DEFAULT (''),
 CONSTRAINT [PK_VendorStatutory] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReqLSWBSTrans]    Script Date: 08/01/2013 17:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqLSWBSTrans](
	[ReqLSWBSTransId] [int] IDENTITY(1,1) NOT NULL,
	[ReqTransId] [int] NOT NULL CONSTRAINT [DF_ReqLSWBSTrans_ReqTransId]  DEFAULT ((0)),
	[AnalysisId] [int] NOT NULL CONSTRAINT [DF_ReqLSWBSTrans_AnalysisId]  DEFAULT ((0)),
	[Qty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLSWBSTrans_Qty]  DEFAULT ((0)),
	[BalQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLSWBSTrans_BalQty]  DEFAULT ((0)),
	[WOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLSWBSTrans_WOQty]  DEFAULT ((0)),
 CONSTRAINT [PK_WOLSWBSTrans] PRIMARY KEY CLUSTERED 
(
	[ReqTransId] ASC,
	[AnalysisId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorExperience]    Script Date: 08/01/2013 17:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorExperience](
	[ExperienceId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorExperience_VendorId]  DEFAULT ((0)),
	[WorkDescription] [varchar](255) NOT NULL CONSTRAINT [DF_VendorExperience_WorkDescription]  DEFAULT (''),
	[ClientName] [varchar](200) NOT NULL CONSTRAINT [DF_VendorExperience_ClientName]  DEFAULT (''),
	[Value] [float] NOT NULL CONSTRAINT [DF_VendorExperience_Value]  DEFAULT ((0)),
	[Period] [varchar](50) NOT NULL CONSTRAINT [DF_VendorExperience_Period]  DEFAULT (''),
	[Type] [varchar](255) NOT NULL CONSTRAINT [DF_VendorExperience_Type]  DEFAULT (''),
 CONSTRAINT [PK_VendorExperience] PRIMARY KEY CLUSTERED 
(
	[ExperienceId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceGroup]    Script Date: 08/01/2013 17:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceGroup](
	[ServiceGroupId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceGroupName] [varchar](8000) NOT NULL CONSTRAINT [DF_ServiceGroup_ServiceGroupName]  DEFAULT (''),
 CONSTRAINT [PK_ServiceGroup] PRIMARY KEY CLUSTERED 
(
	[ServiceGroupId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReqLbrResourceTrans]    Script Date: 08/01/2013 17:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReqLbrResourceTrans](
	[ReqLbrResTransId] [int] IDENTITY(1,1) NOT NULL,
	[ReqTransId] [int] NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_ReqTransId]  DEFAULT ((0)),
	[CompId] [int] NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_CompId]  DEFAULT ((0)),
	[LbrResourceId] [int] NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_LbrResourceId]  DEFAULT ((0)),
	[Qty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_Qty]  DEFAULT ((0)),
	[Rate] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_Rate]  DEFAULT ((0)),
	[AnalysisType] [char](1) NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_AnalysisType]  DEFAULT (''),
	[Amount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_Amount]  DEFAULT ((0)),
	[BalQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_BalQty]  DEFAULT ((0)),
	[WOQty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_ReqLbrResourceTrans_WOQty]  DEFAULT ((0))
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logistics]    Script Date: 08/01/2013 17:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logistics](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Logistics_VendorId]  DEFAULT ((0)),
	[TransportArrange] [char](1) NOT NULL CONSTRAINT [DF_Logistics_TransportArrange]  DEFAULT (''),
	[TransportMode] [varchar](50) NOT NULL CONSTRAINT [DF_Logistics_TransportMode]  DEFAULT (''),
	[Delivery] [char](1) NOT NULL CONSTRAINT [DF_Logistics_Delivery]  DEFAULT (''),
	[Insurance] [char](1) NOT NULL CONSTRAINT [DF_Logistics_Insurance]  DEFAULT (''),
	[Unload] [char](1) NOT NULL CONSTRAINT [DF_Logistics_Unload]  DEFAULT (''),
 CONSTRAINT [PK_Logistics] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceMaster]    Script Date: 08/01/2013 17:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceMaster](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceCode] [varchar](50) NOT NULL CONSTRAINT [DF_ServiceMaster_ServiceCode]  DEFAULT (''),
	[ServiceName] [varchar](8000) NOT NULL CONSTRAINT [DF_ServiceMaster_ServiceName]  DEFAULT (''),
	[ServiceGroupId] [int] NOT NULL CONSTRAINT [DF_ServiceMaster_ServiceGroupId]  DEFAULT ((0)),
	[UnitId] [int] NOT NULL CONSTRAINT [DF_ServiceMaster_UnitId]  DEFAULT ((0)),
 CONSTRAINT [PK_ServiceMaster] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 08/01/2013 17:19:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Branch_VendorId]  DEFAULT ((0)),
	[BranchName] [varchar](100) NOT NULL CONSTRAINT [DF_Branch_BranchName]  DEFAULT (''),
	[CityId] [int] NOT NULL CONSTRAINT [DF_Branch_CityId]  DEFAULT ((0)),
	[Address] [varchar](255) NOT NULL CONSTRAINT [DF_Branch_Address]  DEFAULT (''),
	[TINNo] [varchar](50) NOT NULL CONSTRAINT [DF_Branch_TINNo]  DEFAULT (''),
	[Phone] [varchar](100) NOT NULL CONSTRAINT [DF_Branch_Phone]  DEFAULT (''),
	[ChequeNo] [varchar](255) NOT NULL CONSTRAINT [DF_Branch_ChequeNo]  DEFAULT (''),
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TechPersons]    Script Date: 08/01/2013 17:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TechPersons](
	[TechPersonId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_TechPersons_VendorId]  DEFAULT ((0)),
	[PersonName] [varchar](100) NOT NULL CONSTRAINT [DF_TechPersons_PersonName]  DEFAULT (''),
	[Qualification] [varchar](50) NOT NULL CONSTRAINT [DF_TechPersons_Qualification]  DEFAULT (''),
	[Experience] [float] NOT NULL CONSTRAINT [DF_TechPersons_Experience]  DEFAULT ((0)),
	[Designation] [varchar](50) NOT NULL CONSTRAINT [DF_TechPersons_Designation]  DEFAULT (''),
 CONSTRAINT [PK_TechPersons] PRIMARY KEY CLUSTERED 
(
	[TechPersonId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorAssesment]    Script Date: 08/01/2013 17:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorAssesment](
	[AssessmentId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorAssesment_VendorId]  DEFAULT ((0)),
	[SupplyMaxPoint] [decimal](18, 0) NOT NULL CONSTRAINT [DF_VendorAssesment_SupplyMaxPoint]  DEFAULT ((0)),
	[ContractMaxPoint] [decimal](18, 0) NOT NULL CONSTRAINT [DF_VendorAssesment_SupplyMaxPoints]  DEFAULT ((0)),
	[ServiceMaxPoint] [decimal](18, 0) NOT NULL CONSTRAINT [DF_VendorAssesment_ServiceMaxPoint]  DEFAULT ((0)),
	[SupplyPoints] [decimal](18, 0) NOT NULL CONSTRAINT [DF_VendorAssesment_SupplyPoints]  DEFAULT ((0)),
	[ContractPoints] [decimal](18, 0) NOT NULL CONSTRAINT [DF_VendorAssesment_ContractPoints]  DEFAULT ((0)),
	[ServicePoints] [decimal](18, 0) NOT NULL CONSTRAINT [DF_VendorAssesment_ServicePoints]  DEFAULT ((0)),
	[Approve] [char](1) NOT NULL CONSTRAINT [DF_VendorAssesment_Approve_1]  DEFAULT ('N'),
 CONSTRAINT [PK_VendorAssesment] PRIMARY KEY CLUSTERED 
(
	[AssessmentId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enclosure]    Script Date: 08/01/2013 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enclosure](
	[EnclosureId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_Enclosure_VendorId]  DEFAULT ((0)),
	[Location] [varchar](255) NOT NULL CONSTRAINT [DF_Enclosure_Location]  DEFAULT (''),
	[Date] [datetime] NOT NULL CONSTRAINT [DF_Enclosure_Date]  DEFAULT (getdate()),
	[Name] [varchar](100) NOT NULL CONSTRAINT [DF_Enclosure_Name]  DEFAULT (''),
	[Type] [varchar](100) NOT NULL CONSTRAINT [DF_Enclosure_Type]  DEFAULT (''),
 CONSTRAINT [PK_Enclosure] PRIMARY KEY CLUSTERED 
(
	[EnclosureId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotVendorCerTrans]    Script Date: 08/01/2013 17:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotVendorCerTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotVendorCerTrans_VendorId]  DEFAULT ((0)),
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotVendorCerTrans_QuotationId]  DEFAULT ((0)),
	[CertificateId] [int] NOT NULL CONSTRAINT [DF_QuotVendorCerTrans_CertificateId]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotVendorCerTrans] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC,
	[QuotationId] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TmpVendor]    Script Date: 08/01/2013 17:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TmpVendor](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_TmpVendor_VendorId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotationTrans]    Script Date: 08/01/2013 17:20:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationTrans](
	[QuotationTransId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_QuotationID]  DEFAULT ((0)),
	[IowId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_IOW_Trans_ID]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_Resource_ID]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_ItemId]  DEFAULT ((0)),
	[Quantity] [decimal](18, 5) NOT NULL CONSTRAINT [DF_QuotationTrans_Qty]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_VendorId]  DEFAULT ((0)),
	[AnalysisHeadId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_AnalysisHeadId]  DEFAULT ((0)),
	[UnitId] [int] NOT NULL CONSTRAINT [DF_QuotationTrans_UnitId]  DEFAULT ((0)),
	[Specification] [varchar](max) NOT NULL CONSTRAINT [DF_QuotationTrans_Specification]  DEFAULT (''),
 CONSTRAINT [PK_QuotationTrans] PRIMARY KEY CLUSTERED 
(
	[QuotationTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegTrans]    Script Date: 08/01/2013 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegTrans](
	[RegTransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_RegMaster_VendorId]  DEFAULT ((0)),
	[RegId] [int] NOT NULL CONSTRAINT [DF_RegTrans_RegId]  DEFAULT ((0)),
	[RDate] [datetime] NOT NULL CONSTRAINT [DF_RegMaster_RegNo]  DEFAULT (''),
	[RefNo] [varchar](100) NOT NULL CONSTRAINT [DF_RegTrans_RefNo]  DEFAULT (''),
	[StatusType] [char](1) NOT NULL CONSTRAINT [DF_RegTrans_StatusType]  DEFAULT (''),
	[Supply] [bit] NOT NULL CONSTRAINT [DF_RegMaster_Supply]  DEFAULT ((0)),
	[Contract] [bit] NOT NULL CONSTRAINT [DF_RegMaster_Contract]  DEFAULT ((0)),
	[Service] [bit] NOT NULL CONSTRAINT [DF_RegMaster_Service]  DEFAULT ((0)),
	[SGradeId] [int] NOT NULL CONSTRAINT [DF_RegMaster_SGradeId]  DEFAULT ((0)),
	[CGradeId] [int] NOT NULL CONSTRAINT [DF_RegMaster_CGradeId]  DEFAULT ((0)),
	[HGradeId] [int] NOT NULL CONSTRAINT [DF_RegMaster_HGradeId]  DEFAULT ((0)),
	[SFDate] [datetime] NULL,
	[STDate] [datetime] NULL,
	[CFDate] [datetime] NULL,
	[CTDate] [datetime] NULL,
	[HFDate] [datetime] NULL,
	[HTDate] [datetime] NULL,
	[SLifeTime] [bit] NOT NULL CONSTRAINT [DF_RegMaster_SLifeTime]  DEFAULT ((0)),
	[CLifeTime] [bit] NOT NULL CONSTRAINT [DF_RegMaster_CLifeTime]  DEFAULT ((0)),
	[HLifeTime] [bit] NOT NULL CONSTRAINT [DF_RegMaster_HLifeTime]  DEFAULT ((0)),
	[Remarks] [varchar](255) NOT NULL CONSTRAINT [DF_RegTrans_Remarks]  DEFAULT (''),
	[Approve] [bit] NOT NULL CONSTRAINT [DF_RegTrans_Approve]  DEFAULT ((0)),
 CONSTRAINT [PK_RegTrans] PRIMARY KEY CLUSTERED 
(
	[RegTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BranchTrans]    Script Date: 08/01/2013 17:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BranchTrans](
	[BranchTransId] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL CONSTRAINT [DF_BranchTrans_BranchId]  DEFAULT ((0)),
	[ContactPerson] [varchar](100) NOT NULL CONSTRAINT [DF_BranchTrans_ContactPerson]  DEFAULT (''),
	[Designation] [varchar](100) NOT NULL CONSTRAINT [DF_BranchTrans_Designation]  DEFAULT (''),
	[ContactNo] [varchar](100) NOT NULL CONSTRAINT [DF_BranchTrans_ContactNo]  DEFAULT (''),
	[Email] [varchar](100) NOT NULL CONSTRAINT [DF_BranchTrans_Email]  DEFAULT (''),
	[Fax] [varchar](100) NOT NULL CONSTRAINT [DF_BranchTrans_Fax]  DEFAULT (''),
 CONSTRAINT [PK_BranchTrans] PRIMARY KEY CLUSTERED 
(
	[BranchTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorTerms]    Script Date: 08/01/2013 17:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorTerms](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendorTerms_VendorId]  DEFAULT ((0)),
	[CreditDays] [int] NOT NULL CONSTRAINT [DF_VendorTerms_CreditDays]  DEFAULT ((0)),
	[MaxLeadTime] [int] NOT NULL CONSTRAINT [DF_VendorTerms_MaxLeadTime]  DEFAULT ((0)),
	[TermsAndCondition] [varchar](8000) NOT NULL CONSTRAINT [DF_VendorTerms_TermsAndCondition]  DEFAULT (''),
 CONSTRAINT [PK_VendorTerms] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReqDecMultiCCTrans]    Script Date: 08/01/2013 17:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqDecMultiCCTrans](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[DecisionId] [int] NOT NULL CONSTRAINT [DF_ReqDecMultiCCTrans_DecTransId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_ReqDecMultiCCTrans_ResourceId]  DEFAULT ((0)),
	[CostCentreId] [int] NOT NULL CONSTRAINT [DF_ReqDecMultiCCTrans_CostCentreId]  DEFAULT ((0)),
	[ToCostCentreId] [int] NOT NULL CONSTRAINT [DF_ReqDecMultiCCTrans_ToCostCentreId]  DEFAULT ((0)),
	[Quantity] [decimal](18, 6) NOT NULL CONSTRAINT [DF_ReqDecMultiCCTrans_Quantity]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_ReqDecMultiCCTrans_ItemId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeSetup]    Script Date: 08/01/2013 17:21:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeSetup](
	[GenType] [bit] NOT NULL CONSTRAINT [DF_TypeSetup_GenType]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestPlantSchTrans]    Script Date: 08/01/2013 17:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestPlantSchTrans](
	[RequestSchId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL CONSTRAINT [DF_RequestPlantSchTrans_RequestId]  DEFAULT ((0)),
	[RequestTransId] [int] NOT NULL CONSTRAINT [DF_RequestPlantSchTrans_RequestTransId]  DEFAULT ((0)),
	[RDate] [datetime] NULL,
	[Quantity] [decimal](18, 6) NOT NULL CONSTRAINT [DF_RequestPlantSchTrans_Quantity]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotIndTrans]    Script Date: 08/01/2013 17:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotIndTrans](
	[QuotationTransId] [int] NOT NULL CONSTRAINT [DF__QuotIndTr__Quota__2156DE01]  DEFAULT ((0)),
	[IndentTransId] [int] NOT NULL CONSTRAINT [DF__QuotIndTr__Inden__224B023A]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF__QuotIndTr__Resou__233F2673]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_QuotIndTrans_ItemId]  DEFAULT ((0)),
	[Type] [char](1) NOT NULL CONSTRAINT [DF_QuotIndTrans_Type]  DEFAULT ('')
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReqDecTrans]    Script Date: 08/01/2013 17:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqDecTrans](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[DecisionId] [int] NOT NULL CONSTRAINT [DF_ReqDecTrans_DecisionId]  DEFAULT ((0)),
	[RequestId] [int] NOT NULL CONSTRAINT [DF_ReqDecTrans_RequestId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorCheckListTrans]    Script Date: 08/01/2013 17:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorCheckListTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_VendoCheckListTrans_VendorId]  DEFAULT ((0)),
	[CheckListId] [int] NOT NULL CONSTRAINT [DF_VendoCheckListTrans_CheckListId]  DEFAULT ((0)),
	[RegType] [char](1) NOT NULL CONSTRAINT [DF_VendoCheckListTrans_RegType]  DEFAULT (''),
	[Points] [float] NOT NULL CONSTRAINT [DF_VendoCheckListTrans_Points]  DEFAULT ((0)),
 CONSTRAINT [PK_VendorCheckListTrans] PRIMARY KEY CLUSTERED 
(
	[CheckListId] ASC,
	[RegType] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorContact]    Script Date: 08/01/2013 17:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorContact](
	[VendorID] [int] NOT NULL CONSTRAINT [DF_VendorContact_VendorID]  DEFAULT ((0)),
	[CAddress] [varchar](255) NOT NULL CONSTRAINT [DF_VendorContact_CAddress]  DEFAULT (''),
	[Phone1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Phone1]  DEFAULT (''),
	[Phone2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Phone2]  DEFAULT (''),
	[Fax1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Fax1]  DEFAULT (''),
	[Fax2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Fax2]  DEFAULT (''),
	[Mobile1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Mobile1]  DEFAULT (''),
	[Mobile2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Mobile2]  DEFAULT (''),
	[CPerson1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_CPerson1]  DEFAULT (''),
	[CPerson2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_CPerson2]  DEFAULT (''),
	[CDesignation1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_CDesignation1]  DEFAULT (''),
	[CDesignation2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_CDesignation2]  DEFAULT (''),
	[ContactNo1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_ContactNo1]  DEFAULT (''),
	[ContactNo2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_ContactNo2]  DEFAULT (''),
	[Email1] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Email1]  DEFAULT (''),
	[Email2] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_Email2]  DEFAULT (''),
	[WebName] [varchar](100) NOT NULL CONSTRAINT [DF_VendorContact_WebName]  DEFAULT (''),
 CONSTRAINT [PK_VendorContact] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotMultiVendor]    Script Date: 08/01/2013 17:20:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotMultiVendor](
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotMultiVendor_QuotationId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_QuotMultiVendor_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_QuotMultiVendor_ItemId]  DEFAULT ((0)),
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotMultiVendor_VendorId]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestDecision]    Script Date: 08/01/2013 17:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestDecision](
	[DecisionId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL CONSTRAINT [DF_RequestDecision_RequestId]  DEFAULT ((0)),
	[RDecisionNo] [varchar](50) NOT NULL CONSTRAINT [DF_RequestDecision_RDecNo]  DEFAULT (''),
	[Approve] [char](1) NOT NULL CONSTRAINT [DF_RequestDecision_Approve]  DEFAULT (''),
	[DecDate] [datetime] NOT NULL CONSTRAINT [DF_RequestDecision_DecDate]  DEFAULT (getdate()),
	[RequestType] [varchar](50) NOT NULL CONSTRAINT [DF_RequestDecision_RequestType]  DEFAULT ('')
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotationMultiCCTrans]    Script Date: 08/01/2013 17:20:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotationMultiCCTrans](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationTransId] [int] NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_QuotationId]  DEFAULT ((0)),
	[IowId] [int] NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_IowId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_ResourceId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_ItemId]  DEFAULT ((0)),
	[CostcentreId] [int] NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_CostcentreId]  DEFAULT ((0)),
	[Quantity] [decimal](18, 6) NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_Quantity]  DEFAULT ((0)),
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotationMultiCCTrans_QuotationId_1]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotationMultiCCTrans] PRIMARY KEY CLUSTERED 
(
	[TransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialCertificate]    Script Date: 08/01/2013 17:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaterialCertificate](
	[CertificateId] [int] NOT NULL DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_MaterialCertificate_ResourceId]  DEFAULT ((0)),
	[Remarks] [varchar](255) NOT NULL CONSTRAINT [DF_MaterialCertificate_Remarks]  DEFAULT (''),
 CONSTRAINT [PK_MaterialCertificate] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC,
	[ResourceId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotationProjTrans]    Script Date: 08/01/2013 17:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotationProjTrans](
	[QuotationProjTransId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationTransId] [int] NOT NULL CONSTRAINT [DF_QuotationProjTrans_QuotationTransId]  DEFAULT ((0)),
	[CostCentreId] [int] NOT NULL CONSTRAINT [DF_QuotationProjTrans_CostCentreId]  DEFAULT ((0)),
	[ResourceId] [int] NOT NULL CONSTRAINT [DF_QuotationProjTrans_ResourceId]  DEFAULT ((0)),
	[IowId] [int] NOT NULL CONSTRAINT [DF_QuotationProjTrans_IowId]  DEFAULT ((0)),
	[Quantity] [decimal](18, 5) NOT NULL CONSTRAINT [DF_QuotationProjTrans_Quantity]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotationProjTrans] PRIMARY KEY CLUSTERED 
(
	[QuotationProjTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotationVendorTrans]    Script Date: 08/01/2013 17:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationVendorTrans](
	[VendorId] [int] NOT NULL CONSTRAINT [DF_QuotationSupplierTrans_SupplierID]  DEFAULT ((0)),
	[QuotationId] [int] NOT NULL CONSTRAINT [DF_QuotationSupplierTrans_QuotationID]  DEFAULT ((0)),
	[Status] [bit] NOT NULL CONSTRAINT [DF_QuotationVendorTrans_Status]  DEFAULT ((0)),
	[RefNo] [varchar](100) NOT NULL CONSTRAINT [DF_QuotationVendorTrans_RefNo]  DEFAULT (''),
	[RefDate] [datetime] NOT NULL CONSTRAINT [DF_QuotationVendorTrans_RefDate]  DEFAULT (getdate()),
	[BranchId] [int] NOT NULL CONSTRAINT [DF_QuotationVendorTrans_BranchId]  DEFAULT ((0)),
	[BranchTransId] [int] NOT NULL CONSTRAINT [DF_QuotationVendorTrans_BranchTransId]  DEFAULT ((0)),
 CONSTRAINT [PK_QuotationVendorTrans] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC,
	[VendorId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ManPower]    Script Date: 08/01/2013 17:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManPower](
	[ManPowerTransId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL CONSTRAINT [DF_ManPower_VendorId]  DEFAULT ((0)),
	[Resource_ID] [int] NOT NULL CONSTRAINT [DF_ManPower_Resource_ID]  DEFAULT ((0)),
	[Qty] [float] NOT NULL CONSTRAINT [DF_ManPower_Qty]  DEFAULT ((0)),
 CONSTRAINT [PK_ManPower] PRIMARY KEY CLUSTERED 
(
	[ManPowerTransId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
