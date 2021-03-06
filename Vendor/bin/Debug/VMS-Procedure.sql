/****** Object:  StoredProcedure [dbo].[Delete_TechPerson]    Script Date: 08/01/2013 17:27:07 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_StatusEntry]    Script Date: 08/01/2013 17:27:18 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_StatusEntry]    Script Date: 08/01/2013 17:27:07 ******/
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
/****** Object:  StoredProcedure [dbo].[RequestRegRpt]    Script Date: 08/01/2013 17:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RequestRegRpt]
@VMDB sysname,
@MMSDB sysname,
@CCId varchar(50),
@WFDB sysname
AS
declare @cmd nvarchar(4000)
declare @cmd2 nvarchar(4000)

BEGIN

IF (@CCId=0)
BEGIN
SET @cmd=N'Select A.RequestDate,A.RequestNo,A.RequestId,A.CCReqNo,B.ReqDate,C.Resource_Code,C.Resource_Name,C.Unit_Name,B.Quantity
,A.CostCentreId,G.CostCentreName,B.RequestTransId from ['+@VMDB+'].dbo.RequestRegister A
Inner Join ['+@VMDB+'].dbo.RequestTrans B on A.RequestId=B.RequestId
Left Join ['+@MMSDB+'].dbo.Resource_View C on B.ResourceId=C.Resource_Id
Left Join ['+@WFDB+'].dbo.OperationalCostCentre G on A.CostCentreId=G.CostCentreId'
Exec sp_Executesql @cmd
END
IF (@CCId>0)
BEGIN
SET @cmd2=N'Select A.RequestDate,A.RequestNo,A.RequestId,A.CCReqNo,B.ReqDate,C.Resource_Code,C.Resource_Name,C.Unit_Name,B.Quantity
,A.CostCentreId,G.CostCentreName,B.RequestTransId from ['+@VMDB+'].dbo.RequestRegister A
Inner Join ['+@VMDB+'].dbo.RequestTrans B on A.RequestId=B.RequestId
Left Join ['+@MMSDB+'].dbo.Resource_View C on B.ResourceId=C.Resource_Id
Left Join ['+@WFDB+'].dbo.OperationalCostCentre G on A.CostCentreId=G.CostCentreId
Where A.CostCentreId='+@CCId+' '
Exec sp_Executesql @cmd2
END
END
GO
/****** Object:  StoredProcedure [dbo].[Update_StatusEntry]    Script Date: 08/01/2013 17:27:33 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Country]    Script Date: 08/01/2013 17:27:04 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_VendorType]    Script Date: 08/01/2013 17:27:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_CheckList]    Script Date: 08/01/2013 17:27:10 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_CheckList]    Script Date: 08/01/2013 17:27:26 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Machinery]    Script Date: 08/01/2013 17:27:28 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Machinery]    Script Date: 08/01/2013 17:27:05 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Machinery]    Script Date: 08/01/2013 17:27:13 ******/
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
	
	Delete From dbo.Machinery Where VendorId=@VendorID And Resource_ID=@Resource_ID
	
	Insert into dbo.Machinery(VendorId,Resource_ID,Qty,Capacity)
	Values (@VendorID,@Resource_ID,@Qty,@Capacity)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Grade]    Script Date: 08/01/2013 17:27:11 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Grade]    Script Date: 08/01/2013 17:27:04 ******/
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
	Delete from dbo.GradeMaster Where GradeId=@GradeId
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Grade]    Script Date: 08/01/2013 17:27:27 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_VendorMaster]    Script Date: 08/01/2013 17:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_VendorMaster]    

 -- Add the parameters for the stored procedure here    

@VendorID int,    

@VendorName text,    

@Supply bit,    

@Contract bit,    

@Service bit,    

@Address text,    

@CityId int,    

@Pin Text,    

@STypeId int,    

@Company bit,  

@SuppTypeId Text,

@ChequeNo Text,

@Code Text    

    

    

AS    

BEGIN    

 -- SET NOCOUNT ON added to prevent extra result sets from    

 -- interfering with SELECT statements.    

 SET NOCOUNT ON;    

    

    -- Insert statements for procedure here    

 Update  dbo.VendorMaster Set VendorName=@VendorName,    

 Supply=@Supply,Contract=@Contract,Service=@Service,RegAddress=@Address,    

 CityId=@CityId,PinCode=@Pin,ServiceTypeId=@STypeId,Company=@Company,SupplyType=@SuppTypeId,ChequeNo=@ChequeNo,Code=@Code Where VendorId=@VendorId    

    

 SET NOCOUNT OFF;    

    

END
GO
/****** Object:  StoredProcedure [dbo].[Insert_VendorMaster]    Script Date: 08/01/2013 17:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    

-- Author:  <Author,,Name>    

-- Create date: <Create Date,,>    

-- Description: <Description,,>    

-- =============================================    

CREATE PROCEDURE [dbo].[Insert_VendorMaster]    

    

@VendorName text,    

@Supply bit,    

@Contract bit,    

@Service bit,    

@Address text,    

@CityId int,    

@Pin Text,    

@STypeId int,    

@Company bit,   

@SuppTypeId Text,  

@ChequeNo Text,

@code Text,

@VendorID int output    

    

AS    

BEGIN    

 -- SET NOCOUNT ON added to prevent extra result sets from    

 -- interfering with SELECT statements.    

 SET NOCOUNT ON;    

    

    -- Insert statements for procedure here    

 Insert into dbo.VendorMaster(VendorName,Supply,Contract,Service,RegAddress,CityId,PinCode,ServiceTypeId,Company,SupplyType,ChequeNo,Code)     

 Values(@VendorName,@Supply,@Contract,@Service,@Address,@CityId,@Pin,@STypeId,@Company,@SuppTypeId,@ChequeNo,@code)    

 set @VendorID  = SCOPE_IDENTITY();    

     

     

 SET NOCOUNT OFF;    

     

     

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Location]    Script Date: 08/01/2013 17:27:05 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Location]    Script Date: 08/01/2013 17:27:12 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_WorkGroup]    Script Date: 08/01/2013 17:27:24 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_WorkGroup]    Script Date: 08/01/2013 17:27:08 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Service]    Script Date: 08/01/2013 17:27:07 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Service]    Script Date: 08/01/2013 17:27:17 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Registration]    Script Date: 08/01/2013 17:27:16 ******/
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
	
	Insert Into dbo.GradeTrans (VendorId,CGradeId,SGradeId,HGradeId) Values (@VendorId,@CGradeId,@SGradeId,@HGradeId)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_GradeTrans]    Script Date: 08/01/2013 17:27:27 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Registration]    Script Date: 08/01/2013 17:27:29 ******/
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
	CFDate=@CFDate,CTDate=@CTDate,HFDate=@HFDate,HTDate=@HTDate,SLifeTime=@SLifeTime,CLifeTime=@CLifeTime,HLifeTime=@HLifeTime,Remarks=@Remarks,Alert=0
	Where RegisterId=@RegisterId
	
	Update dbo.GradeTrans Set CGradeId=@CGradeId ,SGradeId=@SGradeId,HGradeId=@HGradeId Where VendorId=@VendorId 
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Certificate]    Script Date: 08/01/2013 17:27:03 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Certificate]    Script Date: 08/01/2013 17:27:25 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Certificate]    Script Date: 08/01/2013 17:27:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Registration]    Script Date: 08/01/2013 17:27:06 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_CertificateTrans]    Script Date: 08/01/2013 17:27:04 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_CertificateTrans]    Script Date: 08/01/2013 17:27:10 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_RegTransLatest]    Script Date: 08/01/2013 17:27:33 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Activity]    Script Date: 08/01/2013 17:27:03 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Activity]    Script Date: 08/01/2013 17:27:08 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_HireMachinery]    Script Date: 08/01/2013 17:27:05 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_HireMachinery]    Script Date: 08/01/2013 17:27:11 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_MaterialGroupTrans]    Script Date: 08/01/2013 17:27:14 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_MaterialGroupTrans]    Script Date: 08/01/2013 17:27:06 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_TurnOver]    Script Date: 08/01/2013 17:27:08 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_TurnOver]    Script Date: 08/01/2013 17:27:21 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_TurnOver]    Script Date: 08/01/2013 17:27:34 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_MaterialTrans]    Script Date: 08/01/2013 17:27:06 ******/
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
	Delete from dbo.MaterialTrans Where VendorId=@VendorId and Resource_Id =@Resource_ID
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_MaterialTrans]    Script Date: 08/01/2013 17:27:14 ******/
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
@CreditDays int,
@ContactPerson Varchar(100),
@ContactNo Varchar(13),
@Email Varchar(50)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.MaterialTrans Where VendorID = @VendorId
	and Resource_ID =@Resource_Id
	
	
	Insert into dbo.MaterialTrans(VendorID,Resource_ID,Priority,SupplyType,LeadTime,CreditDays,ContactPerson,ContactNo,Email)
	Values(@VendorId,@Resource_Id,@Periority,@SupplyType,@LeadTime,@CreditDays,@ContactPerson,@ContactNo,@Email)

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Statutory]    Script Date: 08/01/2013 17:27:19 ******/
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

@BranchCode text,

@ServiceTaxNo text,

@TNGSTNo text,

@MICRCode text,

@IFSCCode text,

@SSIREGDNo text,

@ServiceTaxCir text,

@EPFNo text,

@ESINo text,

@ExciseVendor int,

@ExciseRegNo text,

@Excisedivision text,

@ExciseRange text,

@ECCno text

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;



    -- Insert statements for procedure here

    

    Delete from dbo.VendorStatutory Where VendorId = @VendorId

 
    Insert into dbo.VendorStatutory(VendorID,FirmType,EYear,PANNo,TANNo,CSTNo,

    TINNo,BankAccountNo,AccountType,BankName,BranchName,BranchCode,ServiceTaxNo,TNGSTNo,MICRCode,IFSCCode,SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno)

    Values(@VendorId,@FirmType,@EYear,@PANNo,@TANNo,@CSTNo,@TINNo,@BankAccountNo,

    @AccountType,@BankName,@BranchName,@BranchCode,@ServiceTaxNo,@TNGSTNo,@MICRCode,@IFSCCode,@SSIREGDNo,@ServiceTaxCir,@EPFNo,@ESINo,@ExciseVendor,@ExciseRegNo,@Excisedivision,@ExciseRange,@ECCno)

	

END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Experience]    Script Date: 08/01/2013 17:27:11 ******/
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
@Period text,
@Type text



AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.VendorExperience(VendorId,WorkDescription,ClientName,
	Value,Period,Type) Values(@VendorId,@WorkDescription,@ClientName,@Value,@Period,@Type)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Experience]    Script Date: 08/01/2013 17:27:04 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Experience]    Script Date: 08/01/2013 17:27:26 ******/
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
@Period text,
@Type text


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Update dbo.VendorExperience set VendorId=@VendorId,WorkDescription=@WorkDescription,
	ClientName=@ClientName,Value=@Value,Period=@Period,Type=@Type Where ExperienceId=@ExperienceId
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Logistics]    Script Date: 08/01/2013 17:27:12 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Branch]    Script Date: 08/01/2013 17:27:03 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Branch]    Script Date: 08/01/2013 17:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[Update_Branch]  
 -- Add the parameters for the stored procedure here  
@BranchId int,  
@VendorId int,  
@BranchName text,  
@Address text,  
@CityId int,  
@TINNo text,  
@Phone varchar(100),
@ChequeNo text  
 
  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 Update dbo.Branch Set VendorId=@VendorId,BranchName=@BranchName,  
 Address=@Address,CityId=@CityId,TINNo=@TINNo,Phone=@Phone,ChequeNo=@ChequeNo Where  
 BranchId = @BranchId  
   
 SET NOCOUNT OFF;  
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Branch]    Script Date: 08/01/2013 17:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[Insert_Branch]  
 -- Add the parameters for the stored procedure here  
@VendorId int,  
@BranchName text,  
@Address text,  
@CityId int,  
@TINNo text,  
@Phone varchar(100),  
@ChequeNo text,
@BranchId int OutPut  
  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 Insert into dbo.Branch(VendorId,BranchName,Address,CityId,TINNo,Phone,ChequeNo)  
 Values (@VendorId ,@BranchName,@Address,@CityId,@TINNo,@Phone,@ChequeNo)  
 Set @BranchId=SCOPE_IDENTITY();  
 SET NOCOUNT OFF;  
   
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_TechPerson]    Script Date: 08/01/2013 17:27:20 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_TechPerson]    Script Date: 08/01/2013 17:27:34 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_VendorAssesment]    Script Date: 08/01/2013 17:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_VendorAssesment]
	-- Add the parameters for the stored procedure here
@VendorId int,
@SupplyMaxPoint int,
@SupplyPoints int,
@ContractMaxPoint int,
@ContractPoints int,
@ServiceMaxPoint int,
@ServicePoints int

AS
BEGIN
	
	SET NOCOUNT ON;

   Insert into VendorAssesment (VendorId,SupplyMaxPoint,SupplyPoints,ContractMaxPoint,ContractPoints,ServiceMaxPoint,ServicePoints)
   Values (@VendorId,@SupplyMaxPoint,@SupplyPoints,@ContractMaxPoint,@ContractPoints,@ServiceMaxPoint,@ServicePoints)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_VendorCheckListTrans]    Script Date: 08/01/2013 17:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_VendorCheckListTrans]
	-- Add the parameters for the stored procedure here

@VendorId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendorCheckListTrans Where VendorId =@VendorId
    Delete from dbo.VendorAssesment Where VendorId=@VendorId
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_RegTrans]    Script Date: 08/01/2013 17:27:31 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_RegTrans]    Script Date: 08/01/2013 17:27:07 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_RegTrans]    Script Date: 08/01/2013 17:27:17 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Terms]    Script Date: 08/01/2013 17:27:20 ******/
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
@MaxLeadTime int,
@Terms text

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from dbo.VendorTerms Where VendorId = @VendorId
	
	Insert into dbo.VendorTerms(VendorId,CreditDays,MaxLeadTime,TermsAndCondition)
	Values (@VendorId,@CreditDays,@MaxLeadTime,@Terms)
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_VendorCheckListTrans]    Script Date: 08/01/2013 17:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_VendorCheckListTrans]
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
	Insert into dbo.VendorCheckListTrans(VendorId,CheckListId,RegType,Points)
	Values(@VendorId,@CheckListId,@RegType,@Points)
	
	SET NOCOUNT OFF;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Vendor_Contact]    Script Date: 08/01/2013 17:27:22 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_ManPower]    Script Date: 08/01/2013 17:27:28 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_ManPower]    Script Date: 08/01/2013 17:27:05 ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_ManPower]    Script Date: 08/01/2013 17:27:13 ******/
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
    
    Delete From dbo.ManPower Where VendorId=@VendorID And Resource_ID=@Resource_ID
    
	
	Insert into dbo.ManPower(VendorId,Resource_ID,Qty)
	Values (@VendorID,@Resource_ID,@Qty)
	
	SET NOCOUNT OFF;
	
END
GO
