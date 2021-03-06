USE [VM]
GO
/****** Object:  StoredProcedure [dbo].[Get_WorkGroup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_WorkGroup]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'Select Work_Group_Id,Work_Group_Name from ' + @RateAnalDB + '.dbo.Work_Group'
	
	exec (@cmd)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_HireMachinery]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_HireMachinery]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'Select Resource_ID,Resource_Name from ' + @RateAnalDB + '.dbo.Resource
	Where TypeId=3 Order by Resource_Name'
	
	exec (@cmd)
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Activity]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Activity]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'Select Resource_Group_ID,Resource_Group_Name from ' + @RateAnalDB + '.dbo.Resource_Group
	Where TypeId=4 Order by Resource_Group_Name'
	
	exec (@cmd)
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Service]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Service]
	-- Add the parameters for the stored procedure here

@FADB sysname
AS
declare @cmd nvarchar(2000)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'Select ServiceId,ServiceDescription from ' + @FADB + '.dbo.Service'
	
	exec (@cmd)


END
GO
/****** Object:  StoredProcedure [dbo].[Get_Resource]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Resource]
	-- Add the parameters for the stored procedure here

@RateAnalDB sysname,
@TypeId nvarchar(1)


AS
declare @cmd nvarchar(2000)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    set @cmd = 'Select A.Resource_ID,A.Resource_Name,B.Unit_Name from ' + @RateAnalDB + '.dbo.Resource  A  
    Inner join ' + @RateAnalDB + '.dbo.UOM B on A.Unit_Id=B.Unit_ID
    Where TypeID= ' + @TypeId + '
    Order by Resource_Name'
	
	exec (@cmd)
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Grade]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Grade]
	-- Add the parameters for the stored procedure here
@GradeId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from cbo.GradeMaster Where GradeId=@GradeId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_MaterialGroup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_MaterialGroup]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'Select Resource_Group_ID,Resource_Group_Name from ' + @RateAnalDB + '.dbo.Resource_Group
	Where TypeId=2 Order by Resource_Group_Name'
	
	exec (@cmd)
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Material]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Material]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'Select Resource_ID,Resource_Name,Resource_Group_ID from ' + @RateAnalDB + '.dbo.Resource
	Where TypeId=2 Order by Resource_Name'
	
	exec (@cmd)
END
GO
/****** Object:  StoredProcedure [dbo].[Get_ManPower]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_ManPower]
	-- Add the parameters for the stored procedure here

@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'SELECT A.ManPowerTransId,A.Resource_ID,A.VendorId,B.Resource_Name,C.Unit_Name,A.Qty from ManPower A
			   Inner Join ' + @RateAnalDB + '.dbo.Resource B on A.Resource_ID=B.Resource_ID
	           Inner join ' + @RateAnalDB + '.dbo.UOM C on B.Unit_Id=C.Unit_ID'
	exec (@cmd)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Machinery]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Machinery]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @cmd = 'SELECT A.MachineryTransId,A.Resource_ID,A.VendorId,B.Resource_Name,C.Unit_Name,A.Qty,A.Capacity from Machinery A
			   Inner Join ' + @RateAnalDB + '.dbo.Resource B on A.Resource_ID=B.Resource_ID
	           Inner join ' + @RateAnalDB + '.dbo.UOM C on B.Unit_Id=C.Unit_ID'
	exec (@cmd)
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_TechPerson]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_TechPerson]
	-- Add the parameters for the stored procedure here
@TechPersonId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.TechPersonId Where TechPersonId=@TechPersonId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_StatusEntry]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_StatusEntry]

--@StatusId int,
@VendorId Int,
@StatusType Varchar(1),
@RegType Varchar(1),
@RegisterId int,
@RefNo Varchar(50),
@SDate DateTime,
@ValidFrom DateTime,
@ValidTo DateTime,
@LifTime bit,
@GradeId Int

AS
BEGIN
	
	SET NOCOUNT ON;

	Insert into dbo.StatusRegister (VendorId,StatusType,RegType,RegisterId,RefNo,SDate,ValidFrom,ValidTo,
			LifTime,GradeId) Values(@VendorId,@StatusType,@RegType,'',@RefNo,@SDate,@ValidFrom,
				@ValidTo,@LifTime,'')
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_StatusRegisterEdit]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_StatusRegisterEdit]

@StsId int
AS
BEGIN

Select StatusId,VendorId,StatusType,RegType,RegisterId,RefNo,SDate as SDate,convert(varchar(10),ValidFrom,103) as ValidFrom,convert(varchar(10),ValidTo,103) as ValidTo,LifTime,GradeId from StatusRegister where StatusId=@StsId

	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_StatusEntry]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_StatusEntry]

@StatusId int

AS
BEGIN
	
	SET NOCOUNT ON;

	Delete StatusRegister from StatusRegister where StatusId=@StatusId
	

	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_MaterialTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_MaterialTrans]
	-- Add the parameters for the stored procedure here
	
@VendorId int,
@Resource_ID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.MaterialGroup Where VendorId=@VendorId
	and Resource_Id =@Resource_ID
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_StatusEntry]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_StatusEntry]

@StatusId int,
@VendorId Int,
@StatusType Varchar(1),
@RegType Varchar(1),
@RegisterId int,
@RefNo Varchar(50),
@SDate DateTime,
@ValidFrom DateTime,
@ValidTo DateTime,
@LifTime bit,
@GradeId Int

AS
BEGIN
	
	SET NOCOUNT ON;

	Update dbo.StatusRegister Set VendorId=@VendorId,StatusType=@StatusType,RegType=@RegType,RefNo=@RefNo,SDate=@SDate,
			ValidFrom=@ValidFrom,ValidTo=@ValidTo,LifTime=@LifTime where StatusId=@StatusId

	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_UpdateStatusRegister]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_UpdateStatusRegister]
	-- Add the parameters for the stored procedure here
@StsId varchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select StatusId,VendorId,StatusType,RegType,RegisterId,RefNo,SDate,ValidFrom,ValidTo,LifTime,GradeId from dbo.StatusRegister where StatusId=@StsId 
    
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VendorDetails]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VendorDetails]

@VName nVarchar(Max)

AS

BEGIN
Declare @cmd as nvarchar(max)
IF @VName = ''
	Select V.RegNo,Convert(Varchar(10),V.RegDate,103)as Date,V.VendorName,V.RegAddress,C.CityName,V.Supply,V.Contract,V.Service,V.PinCode from VendorMaster V
		Inner join cityMaster C on C.CityId=V.CityId
ELSE

Set @cmd=N'Select V.RegNo,Convert(Varchar(10),V.RegDate,103)as Date,V.VendorName,V.RegAddress,C.CityName,V.Supply,V.Contract,V.Service,V.PinCode from VendorMaster V Inner join cityMaster C on C.CityId=V.CityId and VendorName IN ('+@VName+')'
Exec (@cmd)	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VendorContactInfo]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VendorContactInfo] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select VendorId,CAddress,Phone1,Phone2,Fax1,Fax2,Mobile1,Mobile2,CPerson1,CPerson2,
	CDesignation1,CDesignation2,ContactNo1,ContactNo2,Email1,Email2,WebName 
	From dbo.VendorContact
	
	SET NOCOUNT OFF;

END
GO
/****** Object:  StoredProcedure [dbo].[Get_Vendor_MasterInfo]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Vendor_MasterInfo]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select VendorId,VendorName,Supply,Contract,Service,RegAddress,CityId,PinCode From dbo.VendorMaster
	Order by VendorName
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VendoCheckListTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VendoCheckListTrans]
	-- Add the parameters for the stored procedure here
@VendorId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId, CheckListId,RegType,Points from dbo.VendoCheckListTrans
	where VendorId = @VendorId
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VCertificate]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VCertificate]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,CertificateId from dbo.CertificateTrans
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_TypeSetup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_TypeSetup]
	-- Add the parameters for the stored procedure here
@TypeID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Select TypeId,GenType,StartNo,Prefix,Suffix,Width,MaxNo from dbo.TypeSetup
	Where TypeId = @TypeID
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_TurnOver]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_TurnOver]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TurnOverId,VendorId,FYear,Value from dbo.VendorTurnOver
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_TransportMode]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_TransportMode]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Distinct TransportMode from dbo.Logistics
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Terms]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Terms]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,CreditDays,TermsAndCondition from VendorTerms
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_TechPersons]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_TechPersons]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select TechPersonId,VendorId,PersonName,Qualification,Experience,Designation from
	dbo.TechPersons
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Statutory]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Statutory]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,FirmType,EYear,PANNo,TANNo,CSTNo,TINNo,BankAccountNo,AccountType,BankName,BranchName,BranchCode from dbo.VendorStatutory
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_State]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_State]
	-- Add the parameters for the stored procedure here
@StateId int,
@StateName text,
@CountryId int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.StateMaster set StateName=@StateName,CountryId=@CountryId
	Where StateID = @StateId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_RegTransLatest]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_RegTransLatest]
	-- Add the parameters for the stored procedure here
	
@RegisterId int,
@VendorId int,
@Supply bit,
@Contract bit,
@Service bit,
@STDate datetime,
@CTDate datetime,
@HTDate datetime,
@SLifeTime bit,
@CLifeTime bit,
@HLifeTime bit,
@SSuspend bit,
@CSuspend bit,
@HSuspend bit,
@SBlackList bit,
@CBlackList bit,
@HBlackList bit,
@SGradeId int,
@CGradeId int,
@HGradeId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.RegTransLatest Where VendorId=@VendorId

	Insert into dbo.RegTransLatest(RegisterId,VendorId,Supply,
	Contract,Service,STDate,
	CTDate,HTDate,SLife,CLife,HLife,
	SSuspend,CSuspend,HSuspend,SBlackList,CBlackList,HBlackList,
	SGradeId,CGradeId,HGradeId)
	Values(@RegisterId,@VendorId,@Supply,@Contract,@Service,
	@STDate,@CTDate,@HTDate,@SLifeTime,@CLifeTime,@HLifeTime,
	@SSuspend,@CSuspend,@HSuspend,@SBlackList,@CBlackList,@HBlackList,
	@SGradeId,@CGradeId,@HGradeId)	
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_RegTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_RegTrans]
	-- Add the parameters for the stored procedure here


@RegTransId int,
@VendorId int,
@RegId int,
@RDate datetime,
@RefNo text,
@StatusType text,
@Supply bit,
@Contract bit,
@Service bit,
@SGradeId int,
@CGradeId int,
@HGradeId int,
@SFDate datetime,
@STDate datetime,
@CFDate datetime,
@CTDate datetime,
@HFDate datetime,
@HTDate datetime,
@SLifeTime bit,
@CLifeTime bit,
@HLifeTime bit,
@Remarks text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.RegTrans set VendorId=@VendorId,RegId=@RegId,RDate=@RDate,RefNo=@RefNo,StatusType=@StatusType,Supply=@Supply,
	Contract=@Contract,Service=@Service,SGradeId=@SGradeId,CGradeId=@CGradeId,HGradeId=@HGradeId,SFDate=@SFDate,STDate=@STDate,
	CFDate=@CFDate,CTDate=@CTDate,HFDate=@HFDate,HTDate=@HTDate,SLifeTime=@SLifeTime,CLifeTime=@CLifeTime,HLifeTime=@HLifeTime,Remarks=@Remarks
	Where RegTransId=@RegTransId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Registration]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Registration]
	-- Add the parameters for the stored procedure here
	
@RegisterId int,
@RegDate datetime,
@RegNo text,
@VendorId int,
@Supply bit,
@Contract bit,
@Service bit,
@SGradeId int,
@CGradeId int,
@HGradeId int,
@SFDate datetime,
@STDate datetime,
@CFDate datetime,
@CTDate datetime,
@HFDate datetime,
@HTDate datetime,
@SLifeTime bit,
@CLifeTime bit,
@HLifeTime bit,
@Remarks text


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.Registration set RegDate=@RegDate,RegNo=@RegNo,VendorId=@VendorId,Supply=@Supply,
	Contract=@Contract,Service=@Service,SGradeId=@SGradeId,CGradeId=@CGradeId,HGradeId=@HGradeId,SFDate=@SFDate,STDate=@STDate,
	CFDate=@CFDate,CTDate=@CTDate,HFDate=@HFDate,HTDate=@HTDate,SLifeTime=@SLifeTime,CLifeTime=@CLifeTime,HLifeTime=@HLifeTime,Remarks=@Remarks
	Where RegisterId=@RegisterId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_RegisterMaster]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_RegisterMaster]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Registered bit,
@RegDate datetime,
@RegNo text,
@FromDate datetime,
@ToDate datetime,
@LifeTime bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Update dbo.VendorMaster Set Register=@Registered,RegDate=@RegDate,
	RegNo=@RegNo,FromDate=@FromDate,ToDate=@ToDate,LifeTimeRegister=@LifeTime
	Where VendorId = @VendorId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_MaxNo]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_MaxNo]
	-- Add the parameters for the stored procedure here
@TypeId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.TypeSetup Set MaxNo=MaxNo+1 Where TypeId=@TypeId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_ManPower]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_ManPower]
	-- Add the parameters for the stored procedure here
@ManPowerTransId int,
@VendorId int,
@Resource_ID int,
@Qty float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.ManPower Set VendorId = @VendorId,Resource_Id=@Resource_ID,
	Qty=@Qty Where ManPowerTransId=@ManPowerTransId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Machinery]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Machinery]
	-- Add the parameters for the stored procedure here
@MachineryTransId int,
@VendorId int,
@Resource_ID int,
@Qty float,
@Capacity text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.Machinery Set VendorId = @VendorId,Resource_Id=@Resource_ID,
	Qty=@Qty,Capacity=@Capacity Where MachineryTransId=@MachineryTransId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_GradeTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_GradeTrans]
	-- Add the parameters for the stored procedure here
@VendorId int,
@SGradeId int,
@CGradeId int,
@HGradeId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.GradeTrans Where VendorId=@VendorId
	
	Insert into dbo.GradeTrans(VendorId,CGradeId,SGradeId,HGradeId)
	Values(@VendorId,@SGradeId,@CGradeId,@HGradeId)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Grade]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Grade]
	-- Add the parameters for the stored procedure here
	
@GradeId int,
@GradeName text,
@FValue float,
@TValue float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Update dbo.GradeMaster Set GradeName=@GradeName,
	FValue=@FValue,TValue=@TValue where GradeId= @GradeId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Experience]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Experience]
	-- Add the parameters for the stored procedure here
	
@ExperienceId int,
@VendorId int,
@WorkDescription text,
@ClientName text,
@Value float,
@Period text


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Update dbo.VendorExperience set VendorId=@VendorId,WorkDescription=@WorkDescription,
	ClientName=@ClientName,Value=@Value,Period=@Period Where ExperienceId=@ExperienceId
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Country]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Country]
	-- Add the parameters for the stored procedure here
	@CountryId int,
	@CountryName text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.CountryMaster set CountryName= @CountryName Where CountryId = @CountryId
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_City]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_City]
	-- Add the parameters for the stored procedure here

@CityId int,
@CityName text,	
@StateId int,
@CountryId int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.CityMaster set CityName=@CityName,StateId=@StateId,CountryId=@CountryId
	Where CityID = @CityId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CheckList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_CheckList]
	-- Add the parameters for the stored procedure here
	
@CheckListId int,
@Description text,
@Supply bit,
@Contract bit,
@Service bit,
@MaxPoint float


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.CheckListMaster Set Description=@Description,
	Supply=@Supply,Contract=@Contract,Service=@Service,MaxPoint=@MaxPoint
	Where CheckListId=@CheckListId

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Certificate]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Certificate]
	-- Add the parameters for the stored procedure here
@CertificateId int,
@CerDescription text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.CertificateMaster Set CerDescription=@CerDescription
	Where CertificateId=@CertificateId
	

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Branch]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Branch]
	-- Add the parameters for the stored procedure here
@BranchId int,
@VendorId int,
@BranchName text,
@Address text,
@CityId int,
@TINNo text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.Branch Set VendorId=@VendorId,BranchName=@BranchName,
	Address=@Address,CityId=@CityId,TINNo=@TINNo Where
	BranchId = @BranchId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_VendorType]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_VendorType]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Supply bit,
@Contract bit,
@Service bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.VendorMaster Set Supply=@Supply,
	Contract=@Contract,Service =@Service Where VendorId=@VendorId
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_VendorMaster]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_VendorMaster]
	-- Add the parameters for the stored procedure here
@VendorID int,
@VendorName text,
@Supply bit,
@Contract bit,
@Service bit,
@Address text,
@CityId int,
@Pin Text


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update  dbo.VendorMaster Set VendorName=@VendorName,
	Supply=@Supply,Contract=@Contract,Service=@Service,RegAddress=@Address,
	CityId=@CityId,PinCode=@Pin Where VendorId=@VendorId

	SET NOCOUNT OFF;

END
GO
/****** Object:  StoredProcedure [dbo].[Update_TypeSetup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_TypeSetup]
	-- Add the parameters for the stored procedure here

@TypeId int,
@GenType bit,
@StartNo int,
@Prefix text,
@Suffix text,
@Width int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.TypeSetup Set GenType = @GenType,StartNo=@StartNo,
	Prefix=@Prefix,Suffix=@Suffix,Width=@Width
	Where TypeId =@TypeId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_TurnOver]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_TurnOver]
	-- Add the parameters for the stored procedure here
@TurnOverID int,
@VendorId int,
@FYear text,
@Value float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.VendorTurnOver Set VendorId=@VendorId,
	FYear=@FYear,Value=@Value where TurnOverId= @TurnOverId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_TechPerson]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_TechPerson]
	-- Add the parameters for the stored procedure here

@TechPersonId int,
@VendorId int,
@PersonName text,
@Qualification text,
@Experience float,
@Designation text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.TechPersons Set VendorId=@VendorId,
	PersonName=@PersonName,Qualification=@Qualification,
	Experience=@Experience,Designation=@Designation
	Where TechPersonId = @TechPersonId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_WorkGroup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_WorkGroup]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Work_Group_ID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.WorkGroup(VendorId,Work_Group_ID)
	Values(@VendorId,@Work_Group_ID)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_VendorMaster]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_VendorMaster]

@VendorName text,
@Supply bit,
@Contract bit,
@Service bit,
@Address text,
@CityId int,
@Pin Text,
@VendorID int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.VendorMaster(VendorName,Supply,Contract,Service,RegAddress,CityId,PinCode) 
	Values(@VendorName,@Supply,@Contract,@Service,@Address,@CityId,@Pin)
	set @VendorID  = SCOPE_IDENTITY();
	
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Vendor_Contact]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Vendor_Contact]
	-- Add the parameters for the stored procedure here

@VendorId int,
@CAddress text,
@Phone1 text,
@Phone2 text,
@Fax1 text,
@Fax2 text,
@Mobile1 text,
@Mobile2 text,
@CPerson1 text,
@CPerson2 text,
@CDesignation1 text,
@CDesignation2 text,
@ContactNo1 text,
@ContactNo2 text,
@Email1 text,
@Email2 text,
@WebName text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    Delete from dbo.VendorContact Where VendorId = @VendorId
    
	Insert into dbo.VendorContact(VendorId,CAddress,Phone1,Phone2,Fax1,Fax2,Mobile1,Mobile2,CPerson1,CPerson2,
	CDesignation1,CDesignation2,ContactNo1,ContactNo2,Email1,Email2,WebName)
	values(@VendorId,@CAddress,@Phone1,@Phone2,@Fax1,@Fax2,@Mobile1,@Mobile2,
	@CPerson1,@CPerson2,@CDesignation1,@CDesignation2,@ContactNo1,@ContactNo2,
	@Email1,@Email2,@WebName)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_VendoCheckListTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_VendoCheckListTrans]
	-- Add the parameters for the stored procedure here
@VendorId int,
@CheckListId int,
@RegType text,
@Points float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.VendoCheckListTrans(VendorId,CheckListId,RegType,Points)
	Values(@VendorId,@CheckListId,@RegType,@Points)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_TypeSetup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_TypeSetup]
	-- Add the parameters for the stored procedure here

@TypeId int,
@GenType bit,
@StartNo int,
@Prefix text,
@Suffix text,
@Width int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.TypeSetup(TypeId,GenType,StartNo,Prefix,Suffix,Width)
	Values (@TypeId,@GenType,@StartNo,@Prefix,@Suffix,@Width)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_TurnOver]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_TurnOver]
	-- Add the parameters for the stored procedure here
@VendorId int,
@FYear text,
@Value float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.VendorTurnover(VendorId,FYear,Value)
	Values(@VendorId,@FYear,@Value)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Terms]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Terms]
	-- Add the parameters for the stored procedure here

@VendorId int,
@CreditDays int,
@Terms text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendorTerms Where VendorId = @VendorId
	
	Insert into dbo.VendorTerms(VendorId,CreditDays,TermsAndCondition)
	Values (@VendorId,@CreditDays,@Terms)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_TechPerson]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_TechPerson]
	-- Add the parameters for the stored procedure here

@VendorId int,
@PersonName text,
@Qualification text,
@Experience float,
@Designation text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.TechPersons(VendorID,PersonName,Qualification,Experience,Designation)
	Values (@VendorId,@PersonName,@Qualification,@Experience,@Designation)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Statutory]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Statutory]
	-- Add the parameters for the stored procedure here

@VendorId int,
@FirmType text,
@EYear int,
@PANNo text,
@TANNo text,
@CSTNo text,
@TINNo text,
@BankAccountNo text,
@AccountType text,
@BankName text,
@BranchName text,
@BranchCode text


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    Delete from dbo.VendorStatutory Where VendorId = @VendorId
    
    Insert into dbo.VendorStatutory(VendorID,FirmType,EYear,PANNo,TANNo,CSTNo,
    TINNo,BankAccountNo,AccountType,BankName,BranchName,BranchCode)
    Values(@VendorId,@FirmType,@EYear,@PANNo,@TANNo,@CSTNo,@TINNo,@BankAccountNo,
    @AccountType,@BankName,@BranchName,@BranchCode)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Logistics]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Logistics]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,TransportArrange,TransportMode,Delivery,Insurance,Unload
	from dbo.Logistics
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Location]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Location]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,CityId from dbo.VendorLocation
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_HireMachineryTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_HireMachineryTrans]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,Resource_Id from dbo.HireMachineryTrans
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Experience]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Experience]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select ExperienceId,VendorId,WorkDescription,ClientName,Value,Period
	from dbo.VendorExperience
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_CountryList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_CountryList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CountryId,CountryName from dbo.CountryMaster Order by CountryName
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_CityList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_CityList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select A.CityId,A.CityName,C.StateName,B.CountryName,A.CountryId,A.StateId from dbo.CityMaster A 
	Inner Join dbo.CountryMaster B on A.CountryId=B.CountryId
	Inner Join dbo.StateMaster C on A.StateId=C.StateID
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_CheckListMaster]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_CheckListMaster]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select CheckListId,Description,Supply,Contract,Service,MaxPoint from
	dbo.CheckListMaster Order by MaxPoint Desc
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_CertificateTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_CertificateTrans]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,CertificateId from dbo.CertificateTrans
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Certificate]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Certificate] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CertificateId,CerDescription from dbo.CertificateMaster
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_BranchList]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_BranchList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select A.BranchId,A.VendorId,A.BranchName,A.Address,B.CityName,A.TINNo,A.CityId from dbo.Branch A
	Inner Join dbo.CityMaster B on A.CityId=B.CityId 
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Alert]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Alert]
	-- Add the parameters for the stored procedure here
@UDate DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    Select B.RegNo,Convert(char(10),B.RegDate,103) as RegDate,
	C.VendorName,G.Status,Convert(char(10),G.UDate,103) as ValidUpto from
	(Select RegisterId,VendorId,STDate UDate,Case When SSuspend=0 then 'Supply Renewal' else 'Supply Suspend Renewal' End Status
	From RegTransLatest
	Where STDate <= @UDate and SBlackList=0 and SLife=0
	Union All
	Select RegisterId,VendorId,CTDate UDate,Case When CSuspend=0 then 'Contract Renewal' else 'Contract Suspend Renewal' End Status
	From RegTransLatest
	Where CTDate <= @UDate and CBlackList=0 and CLife=0
	Union All
	Select RegisterId,VendorId,HTDate UDate,Case When HSuspend=0 then 'Service Renewal' else 'Service Suspend Renewal' End Status
	From dbo.RegTransLatest
	Where HTDate <= @UDate and HBlackList=0 and HLife=0) G
	Inner Join dbo.Registration B on G.RegisterId = B.RegisterId
	Inner Join dbo.VendorMaster C on G.VendorId = C.VendorId
	Order by G.UDate desc
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_ActivityTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_ActivityTrans]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,Resource_Group_ID from dbo.ActivityTrans
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_MaterialGroupTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_MaterialGroupTrans]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Resource_Group_ID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.MaterialGroupTrans Where VendorId=@VendorId
	and Resource_Group_Id =@Resource_Group_ID
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_ManPower]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_ManPower]
	-- Add the parameters for the stored procedure here
@ManPowerTransId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.ManPower Where ManPowerTransId=@ManPowerTransId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Machinery]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Machinery]
	-- Add the parameters for the stored procedure here
@MachineryTransId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.Machinery Where MachineryTransId=@MachineryTransId
	
	SET NOCOUNT OFF;END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Location]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Location]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendorLocation Where  VendorID = @VendorId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_HireMachinery]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_HireMachinery]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.HireMachineryTrans where VendorId = @VendorId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Experience]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Experience]
	-- Add the parameters for the stored procedure here
@ExperienceId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendorExperience Where ExperienceId=@ExperienceId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Country]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Country] 
	-- Add the parameters for the stored procedure here
	@CountryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.CountryMaster Where CountryId = @CountryId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_CertificateTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_CertificateTrans]
	-- Add the parameters for the stored procedure here
@VendorId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.CertificateTrans
	Where VendorId=@VendorId

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Certificate]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Certificate]
	-- Add the parameters for the stored procedure here
@CertificateId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.CertificateMaster 
	Where CertificateId=@CertificateId
	

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Branch]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Branch] 
	-- Add the parameters for the stored procedure here
@BranchId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.Branch Where BranchId=@BranchId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Activity]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Activity]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.ActivityTrans where VendorId = @VendorId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Check_RegTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Check_RegTrans]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select RegTransId from dbo.RegTrans Where VendorId=@VendorId
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Check_RegNo]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Check_RegNo]
	-- Add the parameters for the stored procedure here
@RegisterId int,
@RegNo text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT RegisterId from dbo.Registration 
	Where RegisterId <>@RegisterId and RegNo='@RegNo'
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_RegVendorList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_RegVendorList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select A.VendorID,A.VendorName from dbo.VendorMaster A
	Inner Join dbo.Registration B on A.VendorId=B.VendorId
	Order by A.VendorName
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_RegUpdateDetails]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_RegUpdateDetails]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN 
	SET NOCOUNT ON;
	Select RegisterId,Supply,Contract,Service,STDate,SLifeTime,CTDate,CLifeTime,HTDate,HLifeTime,
	SGradeId,CGradeId,HGradeId 
	From Registration Where VendorId=@VendorId
	SET NOCOUNT OFF;
END

BEGIN 
	SET NOCOUNT ON;
	Select STDate,SLifeTime,StatusType,SGradeId From RegTrans Where VendorId=@VendorId and Supply=1 order by RegTransId Desc
	SET NOCOUNT OFF;
END
	
BEGIN 
	SET NOCOUNT ON;
	Select CTDate,CLifeTime,StatusType,CGradeId From RegTrans Where VendorId=@VendorId and Contract=1 order by RegTransId Desc
	SET NOCOUNT OFF;
END
	
BEGIN 
	SET NOCOUNT ON;
	Select HTDate,HLifeTime,StatusType,HGradeId From RegTrans Where Service=@VendorId and Contract=1 order by RegTransId Desc
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_RegTransLatest]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_RegTransLatest]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select A.RegisterId,A.VendorId,A.Supply,R.RegNo,Convert(Varchar(10),R.RegDate,103) RegDate, A.Contract,A.Service,Convert(Varchar(10),A.STDate,103) STDate,Convert(Varchar(10),A.CTDate,103) CTDate,Convert(Varchar(10),A.HTDate,103) HTDate,
	A.SLife,A.CLife,A.HLife,A.SSuspend,A.CSuspend,A.HSuspend,A.SBlackList,A.CBlackList,A.HBlackList,
	A.SGradeId,A.CGradeId,A.HGradeID,
	B.GradeName SGrade,C.GradeName CGrade,D.GradeName HGrade
	From dbo.RegTransLatest A
	Inner Join dbo.Registration R on A.RegisterId = R.RegisterId
	Left Join dbo.GradeMaster B on A.SGradeId = B.GradeID
	Left Join dbo.GradeMaster C on A.CGradeId = B.GradeID
	Left Join dbo.GradeMaster D on A.HGradeId = B.GradeID
	Where A.VendorId=@VendorId
	
	SET NOCOUNT ON;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_RegTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_RegTrans]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    Select A.RegTransId,A.VendorID,A.RegId,A.RDate,A.RefNo,V.VendorName,A.StatusType,A.Supply,A.Contract,A.Service,A.SGradeId,B.GradeName SGrade,
	A.CGradeId,C.GradeName CGrade,
	A.HGradeId,D.GradeName HGrade,A.SFDate,A.STDate,A.CFDate,A.CTDate,A.HFDate,A.HTDate,A.SLifeTime,A.CLifeTime,A.HLifeTime,A.Remarks
	from dbo.RegTrans A
	Inner Join VendorMaster V on A.VendorId=V.VendorId
	Left Join GradeMaster B on A.SGradeId =B.GradeID
	Left Join GradeMaster C on A.CGradeId =C.GradeID
	Left Join GradeMaster D on A.HGradeId =D.GradeID
	Where A.VendorId = @VendorId
	Order by RegTransId Desc
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_RegNo]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_RegNo]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.RegisterId,A.RegNo,A.VendorId,B.VendorName from dbo.Registration A
	Inner Join dbo.VendorMaster B on A.VendorId=B.VendorId
	Order by A.RegDate,A.RegNo
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Registration]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Registration]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Select A.RegisterId,A.RegDate,A.RegNo,V.VendorName,A.Supply,A.Contract,A.Service,A.SGradeId,B.GradeName SGrade,
	A.CGradeId,C.GradeName CGrade,
	A.HGradeId,D.GradeName HGrade,A.SFDate,A.STDate,A.CFDate,A.CTDate,A.HFDate,A.HTDate,A.SLifeTime,A.CLifeTime,A.HLifeTime,A.Remarks
	from dbo.Registration A
	Inner Join VendorMaster V on A.VendorId=V.VendorId
	Left Join GradeMaster B on A.SGradeId =B.GradeID
	Left Join GradeMaster C on A.CGradeId =C.GradeID
	Left Join GradeMaster D on A.HGradeId =D.GradeID
	Where A.VendorId = @VendorId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_MAXRegTransId]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_MAXRegTransId]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select MAX(RegTransID) MRegTransID from RegTrans Where VendorId=@VendorId;
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_MaterialTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_MaterialTrans]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,Resource_Id,Priority,SupplyType,LeadTime,CreditDays from dbo.MaterialTrans
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_Materials]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Materials]
	-- Add the parameters for the stored procedure here

@RateAnalDB sysname

AS
declare @cmd nvarchar(2000)

BEGIN
 exec Get_MaterialGroup @RateAnalDB
END

BEGIN
 exec Get_Material @RateAnalDB
END
GO
/****** Object:  StoredProcedure [dbo].[Get_MaterialGroupTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_MaterialGroupTrans]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,Resource_Group_Id,Priority,SupplyType,LeadTime,CreditDays from dbo.MaterialGroupTrans
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_WorkGroup]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_WorkGroup]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.WorkGroup Where VendorId=@VendorId
	
	SET NOCOUNT ON;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_VendoCheckListTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_VendoCheckListTrans]
	-- Add the parameters for the stored procedure here

@VendorId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendoCheckListTrans Where VendorId =@VendorId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_TurnOver]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_TurnOver]
	-- Add the parameters for the stored procedure here
	
@TurnOverId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendorTurnOver Where TurnOverId=@TurnOverId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Service]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Service]
	-- Add the parameters for the stored procedure here
@VendorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Delete from dbo.ServiceTrans Where VendorId=@VendorId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_RegTrans]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_RegTrans]
	-- Add the parameters for the stored procedure here
@RegTransId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.RegTrans Where RegTransId=@RegTransId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Registration]    Script Date: 08/11/2010 18:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Registration]
	-- Add the parameters for the stored procedure here
@RegId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.Registration Where RegisterId=@RegId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_StatusRegister]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_StatusRegister]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    Select G.RegTransID,G.VendorId,G.RDate,G.RefNo,
	G.RegNo,G.VendorName,G.Status,G.Supply,G.Contract,G.Service from
	(Select A.RegisterId RegTransID,A.VendorId,Convert(char(10),A.RegDate,103) as RDate,A.RegNo RefNo,
	A.RegNo,B.VendorName,'Register' Status,A.Supply,A.Contract,A.Service
	from dbo.Registration A Inner Join dbo.VendorMaster B on A.VendorId=B.VendorId
	Union All
	Select A.RegTransID,A.VendorId,Convert(char(10),A.RDate,103) as RDate,A.RefNo,C.RegNo,B.VendorName,
	Case When A.StatusType='R' then 
	'Renewal' else 
	Case When A.StatusType='S' then 
	'Suspend' else 
	Case When A.StatusType='B' then 
	'BlackList' 
	end end end Status,
	A.Supply,A.Contract,A.Service
	from dbo.RegTrans A
	Inner Join dbo.VendorMaster B on A.VendorId=B.VendorId
	Inner Join dbo.Registration C on A.RegId=C.RegisterId) G
    Order by G.RDate,G.RefNo
    
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_StateList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_StateList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select A.StateId,A.StateName,B.CountryName,A.CountryId from dbo.StateMaster A 
	Inner Join dbo.CountryMaster B on A.CountryId=B.CountryId
	
	SET NOCOUNT OFF;

END
GO
/****** Object:  StoredProcedure [dbo].[Get_StateData]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_StateData]
	-- Add the parameters for the stored procedure here

@StateId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT StateName,CountryId from dbo.StateMaster Where StateID = @StateId
	
END
GO
/****** Object:  StoredProcedure [dbo].[Get_ServiceTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_ServiceTrans]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorId,ServiceId from dbo.ServiceTrans
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_GradeTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_GradeTrans]
	-- Add the parameters for the stored procedure here
@VendorId int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select A.SGradeId,B.GradeName SGrade,
	A.CGradeId,C.GradeName CGrade,
	A.HGradeId,D.GradeName HGrade
	from dbo.GradeTrans A
	Left Join GradeMaster B on A.SGradeId =B.GradeID
	Left Join GradeMaster C on A.CGradeId =C.GradeID
	Left Join GradeMaster D on A.HGradeId =D.GradeID
	Where A.VendorId = @VendorId
END
GO
/****** Object:  StoredProcedure [dbo].[Get_GradeMaster]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_GradeMaster]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT GradeId,GradeName,FValue,TValue from dbo.GradeMaster
	Order by FValue
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_State]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_State]
	-- Add the parameters for the stored procedure here
@StateName text,
@CountryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.StateMaster(StateName,CountryID) 
	Values(@StateName,@CountryId)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Service]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Service]
	-- Add the parameters for the stored procedure here
@VendorId int,
@ServiceId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Insert into dbo.ServiceTrans(VendorId,ServiceID)
	Values(@VendorId,@ServiceId)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_RegTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_RegTrans]
	-- Add the parameters for the stored procedure here
@VendorId int,
@RegId int,
@RDate datetime,
@RefNo text,
@StatusType text,
@Supply bit,
@Contract bit,
@Service bit,
@SGradeId int,
@CGradeId int,
@HGradeId int,
@SFDate datetime,
@STDate datetime,
@CFDate datetime,
@CTDate datetime,
@HFDate datetime,
@HTDate datetime,
@SLifeTime bit,
@CLifeTime bit,
@HLifeTime bit,
@Remarks text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Insert into dbo.RegTrans(VendorId,RegId,RDate,RefNo,StatusType,Supply,
	Contract,Service,SGradeId,CGradeId,HGradeId,SFDate,STDate,
	CFDate,CTDate,HFDate,HTDate,SLifeTime,CLifeTime,HLifeTime,Remarks)
	Values(@VendorId,@RegId,@RDate,@RefNo,@StatusType,@Supply,@Contract,@Service,
	@SGradeId,@CGradeId,@HGradeId,@SFDate,@STDate,@CFDate,@CTDate,
	@HFDate,@HTDate,@SLifeTime,@CLifeTime,@HLifeTime,@Remarks)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Registration]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Registration]
	-- Add the parameters for the stored procedure here

@RegDate datetime,
@RegNo text,
@VendorId int,
@Supply bit,
@Contract bit,
@Service bit,
@SGradeId int,
@CGradeId int,
@HGradeId int,
@SFDate datetime,
@STDate datetime,
@CFDate datetime,
@CTDate datetime,
@HFDate datetime,
@HTDate datetime,
@SLifeTime bit,
@CLifeTime bit,
@HLifeTime bit,
@Remarks text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.Registration(RegDate,RegNo,VendorId,Supply,
	Contract,Service,SGradeId,CGradeId,HGradeId,SFDate,STDate,
	CFDate,CTDate,HFDate,HTDate,SLifeTime,CLifeTime,HLifeTime,Remarks)
	Values(@RegDate,@RegNo,@VendorId,@Supply,@Contract,@Service,
	@SGradeId,@CGradeId,@HGradeId,@SFDate,@STDate,@CFDate,@CTDate,
	@HFDate,@HTDate,@SLifeTime,@CLifeTime,@HLifeTime,@Remarks)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_MaterialTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_MaterialTrans]

@VendorId int,
@Resource_Id int,
@Periority text,
@SupplyType text,
@LeadTime int,
@CreditDays int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.MaterialTrans Where VendorID = @VendorId
	and Resource_ID =@Resource_Id
	
	
	Insert into dbo.MaterialTrans(VendorID,Resource_ID,Priority,SupplyType,LeadTime,CreditDays)
	Values(@VendorId,@Resource_Id,@Periority,@SupplyType,@LeadTime,@CreditDays)

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_MaterialGroupTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_MaterialGroupTrans]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Resource_Group_Id int,
@Periority text,
@SupplyType text,
@LeadTime int,
@CreditDays int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.MaterialGroupTrans Where VendorID = @VendorId
	and Resource_Group_ID =@Resource_Group_Id
	
	
	Insert into dbo.MaterialGroupTrans(VendorID,Resource_Group_ID,Priority,SupplyType,LeadTime,CreditDays)
	Values(@VendorId,@Resource_Group_Id,@Periority,@SupplyType,@LeadTime,@CreditDays)

	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_ManPower]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_ManPower]
	-- Add the parameters for the stored procedure here
@VendorID int,
@Resource_ID int,
@Qty float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Insert into dbo.ManPower(VendorId,Resource_ID,Qty)
	Values (@VendorID,@Resource_ID,@Qty)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Machinery]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Machinery]
	-- Add the parameters for the stored procedure here

@VendorID int,
@Resource_ID int,
@Qty float,
@Capacity text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Insert into dbo.Machinery(VendorId,Resource_ID,Qty,Capacity)
	Values (@VendorID,@Resource_ID,@Qty,@Capacity)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Logistics]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Logistics]
	-- Add the parameters for the stored procedure here
@VendorId int,
@TransportArrange text,
@TransportMode text,
@Delivery text,
@Insurance text,
@Unload text
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.Logistics Where VendorId=@VendorId
	
	Insert into dbo.Logistics(VendorId,TransportArrange,TransportMode,
	Delivery,Insurance,Unload)
	Values (@VendorId,@TransportArrange,@TransportMode,
	@Delivery,@Insurance,@Unload)
	
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Location]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Location]
	-- Add the parameters for the stored procedure here
@VendorId int,
@LocationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.VendorLocation(VendorId,CityId)
	Values(@VendorId,@LocationId)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_HireMachinery]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_HireMachinery]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Resource_Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Insert into dbo.HireMachineryTrans(VendorId,Resource_Id)
	Values(@VendorId,@Resource_Id)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Grade]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Grade]
	-- Add the parameters for the stored procedure here

@GradeName text,
@FValue float,
@TValue float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.GradeMaster(GradeName,FValue,TValue)
	Values (@GradeName,@FValue,@TValue)
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Experience]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Experience]
	-- Add the parameters for the stored procedure here
@VendorId int,
@WorkDescription text,
@ClientName text,
@Value float,
@Period text



AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.VendorExperience(VendorId,WorkDescription,ClientName,
	Value,Period) Values(@VendorId,@WorkDescription,@ClientName,@Value,@Period)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Country]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Country]
	-- Add the parameters for the stored procedure here
	@CountryName text,
	@CountryId int output 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.CountryMaster(CountryName) Values(@CountryName);
	set @CountryId = SCOPE_IDENTITY();
	
	SET NOCOUNT OFF;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_City]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_City]
@CityName text,
@StateId int,
@CountryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.CityMaster(CityName,StateId,CountryID) 
	Values(@CityName,@StateId,@CountryId)
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_CheckList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_CheckList]
	-- Add the parameters for the stored procedure here
@Description text,
@Supply bit,
@Contract bit,
@Service bit,
@MaxPoint float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
	Insert into dbo.CheckListMaster(Description,Supply,Contract,Service,MaxPoint)
	Values(@Description,@Supply,@Contract,@Service,@MaxPoint)
	
	SET NOCOUNT OFF;

END
GO
/****** Object:  StoredProcedure [dbo].[Insert_CertificateTrans]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_CertificateTrans]
	-- Add the parameters for the stored procedure here
@VendorId int,
@CertificateId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.CertificateTrans(VendorId,CertificateId)
	Values (@VendorId,@CertificateId)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Certificate]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Certificate]
	-- Add the parameters for the stored procedure here
@CerDescription text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.CertificateMaster(CerDescription)
	Values (@CerDescription)
	
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Branch]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Branch]
	-- Add the parameters for the stored procedure here
@VendorId int,
@BranchName text,
@Address text,
@CityId int,
@TINNo text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.Branch(VendorId,BranchName,Address,CityId,TINNo)
	Values (@VendorId ,@BranchName,@Address,@CityId,@TINNo)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Activity]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Activity]
	-- Add the parameters for the stored procedure here
@VendorId int,
@Resource_Group_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.ActivityTrans(VendorId,Resource_Group_ID)
	Values(@VendorId,@Resource_Group_ID)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VWorkGroup]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VWorkGroup]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendorID,Work_Group_ID from dbo.WorkGroup
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VendorName]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VendorName]
	
AS
BEGIN
	
	SET NOCOUNT ON;

		select VendorId,VendorName from VendorMaster
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VendorList]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VendorList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select VendorId,VendorName,Supply,Contract,Service from dbo.VendorMaster Order by VendorName
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Get_VendorInfo]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_VendorInfo]
@RateAnalDB sysname,
@FADB sysname
AS
BEGIN 
	exec Get_CityList
END

BEGIN
	exec Get_Vendor_MasterInfo
End

BEGIN
	exec Get_VendorContactInfo
End

BEGIN
	exec Get_Statutory
End

BEGIN
	exec Get_TurnOver
End

BEGIN
	exec Get_BranchList
End

BEGIN
	exec Get_Experience
End

BEGIN
	exec Get_TechPersons
End

BEGIN
	exec Get_Terms
End

BEGIN
	exec Get_WorkGroup @RateAnalDB
End

BEGIN
	exec Get_Service @FADB
End
BEGIN
	exec Get_ManPower @RateAnalDB
End
BEGIN
	exec Get_Machinery @RateAnalDB
End
BEGIN
	exec Get_Location
End
BEGIN
	exec Get_VWorkGroup
End
BEGIN
	exec Get_ServiceTrans
End

BEGIN
	exec Get_Certificate
End
BEGIN
	exec Get_CertificateTrans
End
BEGIN
	exec Get_Activity @RateAnalDB
End
BEGIN
	exec Get_ActivityTrans
End
BEGIN
	exec Get_HireMachinery @RateAnalDB
End
BEGIN
	exec Get_HireMachineryTrans
End
BEGIN
	exec Get_MaterialGroupTrans
End
BEGIN
	exec Get_MaterialTrans
End
BEGIN
	exec Get_Logistics
End
BEGIN
	exec Get_TransportMode
End
GO
/****** Object:  StoredProcedure [dbo].[Get_FilterInfo]    Script Date: 08/11/2010 18:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_FilterInfo]
	-- Add the parameters for the stored procedure here
@RateAnalDB sysname,
@FADB sysname
AS
BEGIN 
	exec Get_CityList
END
BEGIN
	exec Get_Certificate
End
BEGIN
	exec Get_Material @RateAnalDB
End
BEGIN
	exec Get_MaterialGroup @RateAnalDB
End
BEGIN
	exec Get_WorkGroup @RateAnalDB
End
BEGIN
	exec Get_Activity @RateAnalDB
End
BEGIN
	exec Get_Service @FADB
End
BEGIN
	exec Get_HireMachinery @RateAnalDB
End
BEGIN
	exec Get_GradeMaster
end
GO
