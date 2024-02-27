USE[master]
GO
/****** Object:  Database [RollBook]    Script Date: 21-02-2024 23:19:51 ******/
CREATE DATABASE[RollBook]
 CONTAINMENT = NONE
 ON  PRIMARY
(NAME = N'RollBook', FILENAME = N'F:\SQL-2014\RollBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON
(NAME = N'RollBook_log', FILENAME = N'F:\SQL-2014\RollBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE[RollBook] SET COMPATIBILITY_LEVEL = 150
GO
IF(1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC[RollBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE[RollBook] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE[RollBook] SET ANSI_NULLS OFF
GO
ALTER DATABASE[RollBook] SET ANSI_PADDING OFF
GO
ALTER DATABASE[RollBook] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE[RollBook] SET ARITHABORT OFF
GO
ALTER DATABASE[RollBook] SET AUTO_CLOSE OFF
GO
ALTER DATABASE[RollBook] SET AUTO_SHRINK OFF
GO
ALTER DATABASE[RollBook] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE[RollBook] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE[RollBook] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE[RollBook] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE[RollBook] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE[RollBook] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE[RollBook] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE[RollBook] SET DISABLE_BROKER
GO
ALTER DATABASE[RollBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE[RollBook] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE[RollBook] SET TRUSTWORTHY OFF
GO
ALTER DATABASE[RollBook] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE[RollBook] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE[RollBook] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE[RollBook] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE[RollBook] SET RECOVERY SIMPLE
GO
ALTER DATABASE[RollBook] SET  MULTI_USER
GO
ALTER DATABASE[RollBook] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE[RollBook] SET DB_CHAINING OFF
GO
ALTER DATABASE[RollBook] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)
GO
ALTER DATABASE[RollBook] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO
ALTER DATABASE[RollBook] SET DELAYED_DURABILITY = DISABLED
GO
ALTER DATABASE[RollBook] SET ACCELERATED_DATABASE_RECOVERY = OFF
GO
ALTER DATABASE[RollBook] SET QUERY_STORE = OFF
GO
USE[RollBook]
GO
/****** Object:  Table [dbo].[DeactiveRecords]    Script Date: 21-02-2024 23:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[DeactiveRecords]
(

   [RollID][int] IDENTITY(1,1) NOT NULL,

  [RollNo] [nvarchar] (50) NULL,
	[OpMtr] [varchar] (50) NULL,
	[CbMtr] [varchar] (50) NULL,
	[SizeID] [int] NULL,
	[DNR] [varchar] (50) NULL,
	[QW] [varchar] (50) NULL,
	[NW] [varchar] (50) NULL,
	[CreatedDate] [datetime] NULL,
	[QualityID] [int] NULL,
	[LoomID] [int] NULL
) ON[PRIMARY]
GO
/****** Object:  Table [dbo].[LoomMaster]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[LoomMaster]
(

   [LoomID][int] IDENTITY(1,1) NOT NULL,

  [LoomNo] [int] NULL,
 CONSTRAINT[PK_LoomMaster] PRIMARY KEY CLUSTERED
(
   [LoomID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO
/****** Object:  Table [dbo].[QualityMaster]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[QualityMaster]
(

   [QualityID][int] IDENTITY(1,1) NOT NULL,

  [QualityName] [varchar] (50) NOT NULL,

   [CreatedDate] [datetime] NULL,
 CONSTRAINT[PK_QualityMaster] PRIMARY KEY CLUSTERED
(
   [QualityID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO
/****** Object:  Table [dbo].[RollMaster]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[RollMaster]
(

   [RollID][int] IDENTITY(1,1) NOT NULL,

  [RollNo] [nvarchar] (50) NULL,
	[OpMtr] [varchar] (50) NULL,
	[CbMtr] [varchar] (50) NULL,
	[SizeID] [int] NULL,
	[DNR] [varchar] (50) NULL,
	[QW] [varchar] (50) NULL,
	[NW] [varchar] (50) NULL,
	[CreatedDate] [datetime] NULL,
	[QualityID] [int] NULL,
	[LoomID] [int] NULL,
 CONSTRAINT[PK_RollMaster] PRIMARY KEY CLUSTERED
(
   [RollID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO
/****** Object:  Table [dbo].[SizeMaster]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[SizeMaster]
(

   [SizeID][int] IDENTITY(1,1) NOT NULL,

  [Size] [varchar] (50) NULL,
	[TW] [varchar] (50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT[PK_SizeMaster] PRIMARY KEY CLUSTERED
(
   [SizeID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO
ALTER TABLE[dbo].[DeactiveRecords] ADD CONSTRAINT[DF_DeactiveRecords_CreatedDate]  DEFAULT(getdate()) FOR[CreatedDate]
GO
ALTER TABLE[dbo].[QualityMaster] ADD CONSTRAINT[DF_QualityMaster_CreatedDate]  DEFAULT(getdate()) FOR[CreatedDate]
GO
ALTER TABLE[dbo].[RollMaster] ADD CONSTRAINT[DF_RollMaster_CreatedDate]  DEFAULT(getdate()) FOR[CreatedDate]
GO
ALTER TABLE[dbo].[SizeMaster] ADD CONSTRAINT[DF_SizeMaster_CreatedDate]  DEFAULT(getdate()) FOR[CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[DeactiveRecords_Insert]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[DeactiveRecords_Insert]
@RollID Varchar(200)
AS

SET IDENTITY_INSERT DeactiveRecords ON;

INSERT INTO DeactiveRecords(RollID, RollNo, OpMtr, CbMtr, SizeID, DNR, QW, NW, QualityID, LoomID)
  SELECT RollID, RollNo, OpMtr, CbMtr, SizeID, DNR, QW, NW, QualityID, LoomID
  FROM RollMaster
  WHERE RollID IN(SELECT value FROM STRING_SPLIT(@RollID, ','))

  DELETE FROM RollMaster
  WHERE RollID IN(SELECT value FROM STRING_SPLIT(@RollID, ','));

SET IDENTITY_INSERT DeactiveRecords OFF;
GO
/****** Object:  StoredProcedure [dbo].[LoomMaster_SelectAll]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[LoomMaster_SelectAll]
AS
BEGIN

    SELECT LoomID, LoomNo FROM LoomMaster
END
GO
/****** Object:  StoredProcedure [dbo].[QualityMaster_SelectAll]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[QualityMaster_SelectAll]
AS
BEGIN

    SELECT QualityID, QualityName FROM QualityMaster
END
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Delete]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[RollMaster_Delete]
@RollID Varchar(200)
AS
DELETE FROM RollMaster
WHERE RollID IN(SELECT value FROM STRING_SPLIT(@RollID, ','));
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Filter]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[RollMaster_Filter]
@QualityID Int,
   @EntryDate DateTime NULL
AS
IF(@QualityID= 0)
BEGIN
    SELECT

        RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
    FROM RollMaster
    INNER JOIN QualityMaster

    ON QualityMaster.QualityID=RollMaster.QualityID
    LEFT JOIN LoomMaster

    ON LoomMaster.LoomID= RollMaster.LoomID

    LEFT JOIN SizeMaster
    ON SizeMaster.SizeID= RollMaster.SizeID

    WHERE convert(varchar(10),RollMaster.CreatedDate, 120) = @EntryDate
END
ELSE
BEGIN

    SELECT
        RollNo
        , RollID
        , OpMtr
        , CbMtr
        , SizeID
        , DNR
        , QW
        , NW
        ,QualityMaster.QualityName
		,LoomMaster.LoomNo
    FROM RollMaster
    INNER JOIN QualityMaster

    ON QualityMaster.QualityID=RollMaster.QualityID
    LEFT JOIN LoomMaster

    ON LoomMaster.LoomID= RollMaster.LoomID

    WHERE RollMaster.QualityID= @QualityID

    OR convert(varchar(10),RollMaster.CreatedDate, 120) = @EntryDate
END

GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetByQuality]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[RollMaster_GetByQuality]
@QualityID Int
AS
IF(@QualityID= 0)
BEGIN
    SELECT

        RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,Size
		,DNR
		,QW
		,TW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
    FROM RollMaster
    INNER JOIN QualityMaster

    ON QualityMaster.QualityID=RollMaster.QualityID
    LEFT JOIN LoomMaster

    ON LoomMaster.LoomID= RollMaster.LoomID
END
ELSE
BEGIN
    SELECT

        RollNo

        , RollID

        , OpMtr

        , CbMtr

        , Size

        , DNR

        , QW

        , TW

        , NW

        , QualityMaster.QualityName

        , LoomMaster.LoomNo
    FROM RollMaster
    INNER JOIN QualityMaster

    ON QualityMaster.QualityID= RollMaster.QualityID

    LEFT JOIN LoomMaster
    ON LoomMaster.LoomID= RollMaster.LoomID

    WHERE RollMaster.QualityID= @QualityID
END

GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Insert_Update]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[RollMaster_Insert_Update] 1,'A-1001','65436','63735','26','3.25','138.2','1.5','136.7','3','1'
CREATE PROCEDURE [dbo].[RollMaster_Insert_Update]
    @RollID INT,
    @RollNo NVARCHAR(50),
	@OpMtr VARCHAR(50) NULL,
	@CbMtr VARCHAR(50),
	@SizeID INT,
    @DNR VARCHAR(50),
	@QW VARCHAR(50),
	@NW VARCHAR(50),
	@QualityID INT,
    @LoomID INT

	--@OUTVAL Int OUTPUT,
	--@OUTMESSAGE VARCHAR(50) OUTPUT
AS
BEGIN
    IF(@RollID = 0)

    BEGIN
        INSERT INTO RollMaster
           (RollNo
           , OpMtr
           , CbMtr
           , SizeID
           , DNR
           , QW
           , NW

           , QualityID

           , LoomID)

        VALUES
           (
                @RollNo ,
                @OpMtr ,
                @CbMtr ,
                @SizeID ,
                @DNR ,
                @QW ,
                @NW ,
                @QualityID ,
                @LoomID

           )
		--SET @OUTVAL = 1
        --SET @OUTMESSAGE = 'Record Saved Succefully.'
        --Update RollMaster set OpMtr = (select CbMtr from RollMaster
		--where DAY(CreatedDate)= DAY(GETDATE())-1 AND LoomID = @LoomID )
		--Where LoomID = @LoomID  AND DAY(CreatedDate)=DAY(GETDATE())

        Update RollMaster set OpMtr = (select CbMtr from RollMaster
          where CONVERT(DATE, CreatedDate)= CONVERT(date, DATEADD(DAY, -1, GETDATE())) AND LoomID = 3 )
		Where LoomID = 3  AND CONVERT(DATE, CreatedDate)=CONVERT(DATE, GETDATE())

    END
    ELSE

    BEGIN
        UPDATE RollMaster
        SET     RollNo = @RollNo ,
				OpMtr = @OpMtr ,
				CbMtr = @CbMtr ,
				SizeID = @SizeID ,
				DNR = @DNR ,
				QW = @QW ,
				NW = @NW ,
				QualityID = @QualityID ,
				LoomID = @LoomID
        WHERE RollID=@RollID
		--SET @OUTVAL = 1
        --SET @OUTMESSAGE = 'Record Updated Succefully.'

    END

END


--SELECT*
--		FROM RollMaster
--		WHERE
--		DATENAME(WEEKDAY, '2023-07-11') = 'Tuesday'
--		AND CAST(createddate AS DATE) = CAST(DATEADD(DAY, -1, '2023-07-11') AS DATE)
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_SelectByPK]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<monika detroja>
-- Create date: <19-07-2022>
-- Description:	<Select all the records by id>
-- =============================================
CREATE PROCEDURE[dbo].[RollMaster_SelectByPK] 
	-- Add the parameters for the stored procedure here

    @RollID Int
AS
BEGIN

    SELECT
        RollNo
        , RollID
        , OpMtr
        , CbMtr
        ,SizeMaster.TW
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,RollMaster.QualityID
		,LoomID
    FROM RollMaster
    LEFT JOIN SizeMaster

    ON SizeMaster.SizeID=RollMaster.SizeID
    Where RollID= @RollID
END

GO
/****** Object:  StoredProcedure [dbo].[SizeMaster_GetAll]    Script Date: 21-02-2024 23:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SizeMaster_GetAll]
AS
SELECT SizeID, Size, TW FROM SizeMaster ORDER BY Size ASC

GO
USE[master]
GO
ALTER DATABASE [RollBook] SET READ_WRITE
GO
