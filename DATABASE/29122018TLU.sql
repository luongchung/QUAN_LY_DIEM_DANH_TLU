USE [master]
GO
/****** Object:  Database [dbtlu]    Script Date: 12/29/2018 2:18:19 AM ******/
CREATE DATABASE [dbtlu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbtlu', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\dbtlu.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbtlu_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\dbtlu_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbtlu] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbtlu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbtlu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbtlu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbtlu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbtlu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbtlu] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbtlu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbtlu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbtlu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbtlu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbtlu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbtlu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbtlu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbtlu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbtlu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbtlu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbtlu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbtlu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbtlu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbtlu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbtlu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbtlu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbtlu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbtlu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbtlu] SET  MULTI_USER 
GO
ALTER DATABASE [dbtlu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbtlu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbtlu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbtlu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [dbtlu]
GO
/****** Object:  User [viettel]    Script Date: 12/29/2018 2:18:19 AM ******/
CREATE USER [viettel] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [viettel]
GO
/****** Object:  UserDefinedFunction [dbo].[getTGTietBatDau]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getTGTietBatDau](@IDBuoiHoc INT)
RETURNS DATETIME
AS
BEGIN
	DECLARE @TG DATETIME
	DECLARE @Gio int
	DECLARE @Phut int
	SELECT @TG=bh.NgayHoc FROM dbo.BuoiHoc AS bh WHERE bh.ID=@IDBuoiHoc 
	SELECT @Gio=DATEPART(HOUR,g.ThoiGianBatDau) FROM dbo.ThoiGianTietHoc AS g WHERE g.ID= (SELECT bh.IDTietBatDau FROM dbo.BuoiHoc AS bh WHERE bh.ID=@IDBuoiHoc ) 
	SELECT @Phut=DATEPART(MINUTE,g.ThoiGianBatDau) FROM dbo.ThoiGianTietHoc AS g WHERE g.ID= (SELECT bh.IDTietBatDau FROM dbo.BuoiHoc AS bh WHERE bh.ID=@IDBuoiHoc ) 
	SELECT @TG = DATEADD(HOUR, @Gio, @TG)
	SELECT @TG = DATEADD(MINUTE, @Phut, @TG)
	RETURN @TG
END
GO
/****** Object:  UserDefinedFunction [dbo].[getTGTietKetThuc]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getTGTietKetThuc](@IDBuoiHoc INT)
RETURNS DATETIME
AS
BEGIN
	DECLARE @TG DATETIME
	DECLARE @Gio int
	DECLARE @Phut int
	SELECT @TG=bh.NgayHoc FROM dbo.BuoiHoc AS bh WHERE bh.ID=@IDBuoiHoc 
	SELECT @Gio=DATEPART(HOUR,g.ThoiGianKetThuc) FROM dbo.ThoiGianTietHoc AS g WHERE g.ID= (SELECT bh.IDTietKetThuc FROM dbo.BuoiHoc AS bh WHERE bh.ID=@IDBuoiHoc ) 
	SELECT @Phut=DATEPART(MINUTE,g.ThoiGianKetThuc) FROM dbo.ThoiGianTietHoc AS g WHERE g.ID= (SELECT bh.IDTietKetThuc FROM dbo.BuoiHoc AS bh WHERE bh.ID=@IDBuoiHoc ) 
	SELECT @TG = DATEADD(HOUR, @Gio, @TG)
	SELECT @TG = DATEADD(MINUTE, @Phut, @TG)
	RETURN @TG
END
GO
/****** Object:  UserDefinedFunction [dbo].[getTimeDiemDanhList]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[getTimeDiemDanhList] (@IDSinhVien INT,@IDBuoiHoc INT)
RETURNS DATETIME
AS 
BEGIN
	DECLARE @kq DATETIME
	SET @kq=NULL
	SELECT @kq=MAX(dd.TGDiemDanh) FROM dbo.DiemDanh AS dd WHERE dd.IDBuoiHoc=@IDBuoiHoc AND dd.IDSinhVien=@IDSinhVien AND dd.DenLop=1
	RETURN @kq
END
GO
/****** Object:  UserDefinedFunction [dbo].[kiemtralopdiemdanh]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[kiemtralopdiemdanh] (@IDSinhVien INT,@IDBuoiHoc INT)
RETURNS BIT
AS 
BEGIN
	DECLARE @kq bit
	DECLARE @sl int
	SELECT @sl=COUNT(dd.ID) FROM dbo.DiemDanh AS dd WHERE dd.IDBuoiHoc=@IDBuoiHoc AND dd.IDSinhVien=@IDSinhVien AND dd.DenLop=1
	IF(@sl>0) 
	BEGIN
		SET @kq=1
	END
	ELSE SET @kq=0
	RETURN @kq
END
GO
/****** Object:  UserDefinedFunction [dbo].[Kiemtrathuoclop]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Kiemtrathuoclop] (@IDSinhVien INT,@IDBuoiHoc INT)
RETURNS BIT
AS 
BEGIN
	DECLARE @IDLopMonHoc INT
	DECLARE @Sl INT
	DECLARE @K BIT
    SELECT @IDLopMonHoc=i.IDLopMonHoc from dbo.BuoiHoc i WHERE i.ID=@IDBuoiHoc;
	SELECT @Sl=COUNT(dd.ID) FROM dbo.SinhVien_LopMonHoc AS dd WHERE dd.IDSinhVien=@IDSinhVien AND dd.IDLopMonHoc=@IDLopMonHoc
	IF(@sl>0) 
	BEGIN
		SET @K=1
	END
	ELSE SET @K=0
	RETURN @K
END
GO
/****** Object:  Table [dbo].[BuoiHoc]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuoiHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenBuoiHoc] [nvarchar](50) NULL,
	[IDLopMonHoc] [int] NULL,
	[IDTietBatDau] [int] NULL,
	[IDTietKetThuc] [int] NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[IDDiaDiem] [int] NULL,
	[NgayHoc] [datetime] NULL,
 CONSTRAINT [PK_DiemDanh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiaDiemHoc]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaDiemHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDiaDiem] [nvarchar](50) NULL,
	[KhuNha] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_DiaDiemHoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemDanh]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDSinhVien] [int] NULL,
	[IDBuoiHoc] [int] NULL,
	[DenLop] [bit] NULL,
	[TGDiemDanh] [datetime] NULL,
 CONSTRAINT [PK_DiemDanh_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupID]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NULL,
	[DienGiai] [nvarchar](200) NULL,
 CONSTRAINT [PK_GroupID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoa] [nvarchar](200) NULL,
	[SDT] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopMonHoc]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopMonHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaLopMonHoc] [nvarchar](100) NULL,
	[TenLopMonHoc] [nvarchar](200) NULL,
	[SoTinChi] [int] NULL,
	[IDGiangVien] [int] NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[TongSoTiet] [int] NULL,
	[IsKT] [bit] NULL,
 CONSTRAINT [PK_LopMonHoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](100) NULL,
	[TenNV] [nvarchar](100) NULL,
	[GioiTinh] [bit] NULL,
	[Tuoi] [int] NULL,
	[SDT] [nvarchar](30) NULL,
	[IDKhoa] [int] NULL,
	[IsGV] [bit] NULL,
	[DiaChi] [nvarchar](500) NULL,
	[Password] [nvarchar](200) NULL,
	[IsLock] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pqAccessRight]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pqAccessRight](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NULL,
	[GroupID] [int] NULL,
	[IsAccessRight] [bit] NULL,
 CONSTRAINT [PK_pqAccessRight] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pqForm]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pqForm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](100) NULL,
	[DienGiai] [nchar](500) NULL,
 CONSTRAINT [PK_pqForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pqModule]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pqModule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[DienGiai] [nvarchar](500) NULL,
	[IDCha] [int] NULL,
 CONSTRAINT [PK_pqModule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pqModule_FormControl]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pqModule_FormControl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NULL,
	[FormID] [int] NULL,
	[ControlName] [nvarchar](500) NULL,
 CONSTRAINT [PK_pqModule_FormControl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pqNhomNhanVien]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pqNhomNhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NULL,
	[MaNV] [int] NULL,
 CONSTRAINT [PK_pqNhomNhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenSV] [nvarchar](100) NULL,
	[MSV] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[IDKhoa] [int] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](1000) NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien_LopMonHoc]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien_LopMonHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDSinhVien] [int] NULL,
	[IDLopMonHoc] [int] NULL,
 CONSTRAINT [PK_SinhVien_LopMonHoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThoiGianTietHoc]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiGianTietHoc](
	[N] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenTiet] [int] NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[ThoiGianKetThuc] [datetime] NULL,
 CONSTRAINT [PK_ThoiGianTietHoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[InforSinhVien]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InforSinhVien] 
AS SELECT sv.ID,sv.MSV,sv.TenSV,FORMAT(sv.NgaySinh,'dd/MM/yyyy', 'en-us') AS NgaySinh,sv.DiaChi,(SELECT k.TenKhoa FROM dbo.Khoa AS k WHERE sv.IDKhoa=k.ID) AS TenKhoa,(SELECT CASE WHEN sv.GioiTinh=1 THEN 'Nam' ELSE 'Nữ' END) AS GioiTinh FROM dbo.SinhVien AS sv
GO
SET IDENTITY_INSERT [dbo].[BuoiHoc] ON 

INSERT [dbo].[BuoiHoc] ([ID], [TenBuoiHoc], [IDLopMonHoc], [IDTietBatDau], [IDTietKetThuc], [GhiChu], [IDDiaDiem], [NgayHoc]) VALUES (1, N'Buổi 1', 1, 1, 4, N'', 1, CAST(N'2018-11-17T00:00:00.000' AS DateTime))
INSERT [dbo].[BuoiHoc] ([ID], [TenBuoiHoc], [IDLopMonHoc], [IDTietBatDau], [IDTietKetThuc], [GhiChu], [IDDiaDiem], [NgayHoc]) VALUES (2, N'Buổi 2', 1, 5, 7, N'', 1, CAST(N'2018-12-08T00:00:00.000' AS DateTime))
INSERT [dbo].[BuoiHoc] ([ID], [TenBuoiHoc], [IDLopMonHoc], [IDTietBatDau], [IDTietKetThuc], [GhiChu], [IDDiaDiem], [NgayHoc]) VALUES (8, N'Buổi 1', 2, 1, 5, N'', 3, CAST(N'2018-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[BuoiHoc] ([ID], [TenBuoiHoc], [IDLopMonHoc], [IDTietBatDau], [IDTietKetThuc], [GhiChu], [IDDiaDiem], [NgayHoc]) VALUES (9, N'Buổi 2', 2, 1, 13, N'', 1, CAST(N'2018-12-14T00:00:00.000' AS DateTime))
INSERT [dbo].[BuoiHoc] ([ID], [TenBuoiHoc], [IDLopMonHoc], [IDTietBatDau], [IDTietKetThuc], [GhiChu], [IDDiaDiem], [NgayHoc]) VALUES (10, N'Buôi cafe', 2, 1, 13, N'', 1, CAST(N'2018-12-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BuoiHoc] OFF
SET IDENTITY_INSERT [dbo].[DiaDiemHoc] ON 

INSERT [dbo].[DiaDiemHoc] ([ID], [TenDiaDiem], [KhuNha], [GhiChu]) VALUES (1, N'P103 - A2', N'A2', N'')
INSERT [dbo].[DiaDiemHoc] ([ID], [TenDiaDiem], [KhuNha], [GhiChu]) VALUES (2, N'P102 - A2', N'A2', N'')
INSERT [dbo].[DiaDiemHoc] ([ID], [TenDiaDiem], [KhuNha], [GhiChu]) VALUES (3, N'P101 - A2', N'A2', N'')
INSERT [dbo].[DiaDiemHoc] ([ID], [TenDiaDiem], [KhuNha], [GhiChu]) VALUES (4, N'P201 - A2', N'A2', N'')
SET IDENTITY_INSERT [dbo].[DiaDiemHoc] OFF
SET IDENTITY_INSERT [dbo].[DiemDanh] ON 

INSERT [dbo].[DiemDanh] ([ID], [IDSinhVien], [IDBuoiHoc], [DenLop], [TGDiemDanh]) VALUES (74, 1, 9, 1, CAST(N'2018-12-14T09:56:19.820' AS DateTime))
INSERT [dbo].[DiemDanh] ([ID], [IDSinhVien], [IDBuoiHoc], [DenLop], [TGDiemDanh]) VALUES (81, 13, 9, 1, CAST(N'2018-12-14T13:32:24.697' AS DateTime))
INSERT [dbo].[DiemDanh] ([ID], [IDSinhVien], [IDBuoiHoc], [DenLop], [TGDiemDanh]) VALUES (86, 1, 10, 1, CAST(N'2018-12-18T07:27:03.247' AS DateTime))
INSERT [dbo].[DiemDanh] ([ID], [IDSinhVien], [IDBuoiHoc], [DenLop], [TGDiemDanh]) VALUES (87, 1, 1, 1, CAST(N'2018-12-29T01:13:02.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[DiemDanh] OFF
SET IDENTITY_INSERT [dbo].[GroupID] ON 

INSERT [dbo].[GroupID] ([ID], [GroupName], [DienGiai]) VALUES (1, N'QTV', N'Người phá hệ thống')
INSERT [dbo].[GroupID] ([ID], [GroupName], [DienGiai]) VALUES (2, N'Sinh Viên', N'Người bỏ tiền đi học')
INSERT [dbo].[GroupID] ([ID], [GroupName], [DienGiai]) VALUES (3, N'Giảng viên', N'Người giảng dạy')
SET IDENTITY_INSERT [dbo].[GroupID] OFF
SET IDENTITY_INSERT [dbo].[Khoa] ON 

INSERT [dbo].[Khoa] ([ID], [TenKhoa], [SDT], [DiaChi]) VALUES (1, N'CÔNG NGHỆ THÔNG TIN', N'09111111111', N'Tầng 2 Tòa nhà C1')
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [SDT], [DiaChi]) VALUES (3, N'KINH TẾ VÀ QUẢN LÝ', N'09111111111', N'Tầng 2 Tòa nhà C1')
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [SDT], [DiaChi]) VALUES (4, N'CÔNG TRÌNH', N'09111111111', N'Tầng 2 Tòa nhà C1')
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [SDT], [DiaChi]) VALUES (5, N'THỦY VĂN', N'09111111111', N'Tầng 2 Tòa nhà C1')
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [SDT], [DiaChi]) VALUES (6, N'KỸ THUẬT BIỂN', N'09111111111', N'Tầng 2 Tòa nhà C1')
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [SDT], [DiaChi]) VALUES (7, N'KHOA MÔI TRƯỜNG', N'09111111111', N'Tầng 2 Tòa nhà C1')
SET IDENTITY_INSERT [dbo].[Khoa] OFF
SET IDENTITY_INSERT [dbo].[LopMonHoc] ON 

INSERT [dbo].[LopMonHoc] ([ID], [MaLopMonHoc], [TenLopMonHoc], [SoTinChi], [IDGiangVien], [GhiChu], [TongSoTiet], [IsKT]) VALUES (1, N'CSE-2018', N'An toàn bảo mật thông tin', 3, 4, N'Cho lớp này học lại hết', 15, 0)
INSERT [dbo].[LopMonHoc] ([ID], [MaLopMonHoc], [TenLopMonHoc], [SoTinChi], [IDGiangVien], [GhiChu], [TongSoTiet], [IsKT]) VALUES (2, N'CSE-2019', N'Lập trình phân tán', 4, 3, N'Note 1.Học bù
', 16, 0)
SET IDENTITY_INSERT [dbo].[LopMonHoc] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [MaNV], [TenNV], [GioiTinh], [Tuoi], [SDT], [IDKhoa], [IsGV], [DiaChi], [Password], [IsLock]) VALUES (1, N'luongchung', N'Lương Văn Chung', 1, 23, N'01234443401', NULL, 0, N'Hải Dương', N'EB18B0463340D4D9A139714B92E31A7F', 0)
INSERT [dbo].[NhanVien] ([ID], [MaNV], [TenNV], [GioiTinh], [Tuoi], [SDT], [IDKhoa], [IsGV], [DiaChi], [Password], [IsLock]) VALUES (2, N'student', N'student', 1, 18, N'0988888888', NULL, 0, N'175 Tây Sơn, Đống Đa, Hà Nội', N'E10ADC3949BA59ABBE56E057F20F883E', 0)
INSERT [dbo].[NhanVien] ([ID], [MaNV], [TenNV], [GioiTinh], [Tuoi], [SDT], [IDKhoa], [IsGV], [DiaChi], [Password], [IsLock]) VALUES (3, N'GV1026', N'Giảng viên A', 1, 23, N'0987654272', 4, 1, N'Ninh Bình', N'E10ADC3949BA59ABBE56E057F20F883E', 1)
INSERT [dbo].[NhanVien] ([ID], [MaNV], [TenNV], [GioiTinh], [Tuoi], [SDT], [IDKhoa], [IsGV], [DiaChi], [Password], [IsLock]) VALUES (4, N'GV1027', N'Giảng viên B', 1, 23, N'0987654321', 1, 1, N'Hải Dương', N'E10ADC3949BA59ABBE56E057F20F883E', 1)
INSERT [dbo].[NhanVien] ([ID], [MaNV], [TenNV], [GioiTinh], [Tuoi], [SDT], [IDKhoa], [IsGV], [DiaChi], [Password], [IsLock]) VALUES (12, N'GV1028', N'Giảng viên C', 1, 32, N'09876543', 6, 1, N'Hải phòng', N'E10ADC3949BA59ABBE56E057F20F883E', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[pqAccessRight] ON 

INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (1, 5, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (2, 6, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (3, 8, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (4, 9, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (5, 10, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (6, 11, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (7, 12, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (8, 13, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (9, 14, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (10, 15, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (11, 16, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (12, 17, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (13, 18, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (14, 19, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (15, 20, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (16, 21, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (17, 22, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (18, 23, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (19, 24, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (20, 25, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (21, 26, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (22, 27, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (23, 28, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (24, 29, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (25, 30, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (26, 31, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (27, 32, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (28, 5, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (29, 6, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (30, 8, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (31, 9, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (32, 10, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (33, 11, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (34, 12, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (35, 13, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (36, 14, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (37, 15, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (38, 16, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (39, 17, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (40, 18, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (41, 19, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (42, 20, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (43, 21, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (44, 22, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (45, 23, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (46, 24, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (47, 25, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (48, 26, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (49, 27, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (50, 28, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (51, 29, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (52, 30, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (53, 31, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (54, 32, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (55, 33, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (56, 33, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (57, 34, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (58, 35, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (59, 36, 1, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (60, 34, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (61, 35, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (62, 36, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (63, 37, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (64, 38, 2, 1)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (65, 37, 1, 0)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (66, 38, 1, 0)
SET IDENTITY_INSERT [dbo].[pqAccessRight] OFF
SET IDENTITY_INSERT [dbo].[pqForm] ON 

INSERT [dbo].[pqForm] ([ID], [FormName], [DienGiai]) VALUES (1, N'AppMain.frm_Main', N'MAIN                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                ')
INSERT [dbo].[pqForm] ([ID], [FormName], [DienGiai]) VALUES (2, N'STAFF.frmMain', N'Quản lý nhân viên                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ')
SET IDENTITY_INSERT [dbo].[pqForm] OFF
SET IDENTITY_INSERT [dbo].[pqModule] ON 

INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (5, N'MAIN', NULL, 0)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (6, N'Chức năng phụ', NULL, 0)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (8, N'Tab Hệ thống', NULL, 5)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (9, N'Group Hệ Thống', NULL, 8)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (10, N'Group Bảo mật', NULL, 8)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (11, N'Group Quản lý nhân viên', NULL, 8)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (12, N'Tab Quản lý Sinh Viên', NULL, 5)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (13, N'Group quản lý', NULL, 12)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (14, N'Group tra cứu', NULL, 12)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (15, N'Kích hoạt tài khoản', NULL, 12)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (16, N'Tab 3', NULL, 5)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (17, N'Bar', NULL, 16)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (18, N'Nạp', NULL, 17)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (19, N'Xem thông tin tài khoản', NULL, 6)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (20, N'Đăng xuất', NULL, 6)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (21, N'Đăng xuất hệ thống', NULL, 9)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (22, N'Thông tin tài khoản', NULL, 9)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (23, N'Đổi mật khẩu', NULL, 9)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (24, N'Khôi phục mật khẩu', NULL, 10)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (25, N'Phân quyền chức năng', NULL, 10)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (26, N'Kích hoạt tài khoản', NULL, 10)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (27, N'Quản lý nhân viên', NULL, 11)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (28, N'Nạp', NULL, 27)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (29, N'Thêm', NULL, 27)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (30, N'Sửa', NULL, 27)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (31, N'Xóa', NULL, 27)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (32, N'Export', NULL, 27)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (33, N'Đăng nhập hệ thống', NULL, 9)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (34, N'Quản lý sinh viên', NULL, 13)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (35, N'Nhập sinh viên', NULL, 13)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (36, N'Xuất sinh viên', NULL, 13)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (37, N'Tra cứu thông tin sinh viên', NULL, 14)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (38, N'Tra cứu điểm danh sinh viên', NULL, 14)
SET IDENTITY_INSERT [dbo].[pqModule] OFF
SET IDENTITY_INSERT [dbo].[pqModule_FormControl] ON 

INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (1, 8, 1, N'ribbonPageHeThong')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (3, 9, 1, N'ribbonPageGroup_HeThong')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (5, 17, 2, N'bar2')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (6, 18, 2, N'btnNap')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (7, 21, 1, N'btnDX')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (8, 22, 1, N'btnThongTin')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (9, 23, 1, N'btn_DoiMatKhau')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (10, 10, 1, N'ribbonPageGroup_BaoMat')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (11, 11, 2, N'btnRobonQLNV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (12, 24, 1, N'btnKhoiPhucPass')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (13, 25, 1, N'btnPhanQuyen')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (14, 26, 1, N'btnKichHoatTK')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (15, 27, 1, N'btnQLNV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (16, 28, 2, N'btnNap')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (17, 29, 2, N'btnThem')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (18, 30, 2, N'btnSua')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (19, 31, 2, N'btnXoa')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (20, 32, 2, N'btnExport')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (21, 19, 1, N'btnTT')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (22, 20, 1, N'btnDangXuat')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (23, 33, 1, N'btnShowFormLogin')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (24, 12, 1, N'ribbonPageQuanLySV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (25, 13, 1, N'ribbonPageGroupQL')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (26, 14, 1, N'ribbonPagetracuuSV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (27, 34, 1, N'btnQLSinhVien')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (28, 35, 1, N'btnNhapSV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (29, 36, 1, N'btnXuatSV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (30, 37, 1, N'btnTracuuTTSV')
INSERT [dbo].[pqModule_FormControl] ([ID], [ModuleID], [FormID], [ControlName]) VALUES (31, 38, 1, N'btnTraCuuDiemDanhSV')
SET IDENTITY_INSERT [dbo].[pqModule_FormControl] OFF
SET IDENTITY_INSERT [dbo].[pqNhomNhanVien] ON 

INSERT [dbo].[pqNhomNhanVien] ([ID], [GroupID], [MaNV]) VALUES (2, 1, 1)
INSERT [dbo].[pqNhomNhanVien] ([ID], [GroupID], [MaNV]) VALUES (3, 2, 2)
SET IDENTITY_INSERT [dbo].[pqNhomNhanVien] OFF
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([ID], [TenSV], [MSV], [GioiTinh], [IDKhoa], [NgaySinh], [DiaChi]) VALUES (1, N'Sinh viên 1', N'1451062102', 1, 3, CAST(N'1996-11-13' AS Date), N'Hải Dương')
INSERT [dbo].[SinhVien] ([ID], [TenSV], [MSV], [GioiTinh], [IDKhoa], [NgaySinh], [DiaChi]) VALUES (13, N'Sinh Viên 2', N'1451062103', 1, 1, CAST(N'1996-11-13' AS Date), N'')
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
SET IDENTITY_INSERT [dbo].[SinhVien_LopMonHoc] ON 

INSERT [dbo].[SinhVien_LopMonHoc] ([ID], [IDSinhVien], [IDLopMonHoc]) VALUES (8, 1, 1)
INSERT [dbo].[SinhVien_LopMonHoc] ([ID], [IDSinhVien], [IDLopMonHoc]) VALUES (10, 1, 2)
INSERT [dbo].[SinhVien_LopMonHoc] ([ID], [IDSinhVien], [IDLopMonHoc]) VALUES (11, 13, 2)
SET IDENTITY_INSERT [dbo].[SinhVien_LopMonHoc] OFF
SET IDENTITY_INSERT [dbo].[ThoiGianTietHoc] ON 

INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (1, 1, 1, CAST(N'2018-11-09T07:00:00.000' AS DateTime), CAST(N'2018-11-09T07:55:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (2, 3, 2, CAST(N'2018-11-09T07:55:00.000' AS DateTime), CAST(N'2018-11-09T08:45:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (3, 4, 3, CAST(N'2018-11-09T08:55:00.000' AS DateTime), CAST(N'2018-11-09T09:45:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (4, 5, 4, CAST(N'2018-11-09T09:50:00.000' AS DateTime), CAST(N'2018-11-09T10:40:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (5, 6, 5, CAST(N'2018-11-09T10:50:00.000' AS DateTime), CAST(N'2018-11-09T11:40:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (6, 7, 6, CAST(N'2018-11-09T11:45:00.000' AS DateTime), CAST(N'2018-11-09T00:05:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (7, 8, 7, CAST(N'2018-11-09T00:45:00.000' AS DateTime), CAST(N'2018-11-09T13:35:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (8, 9, 8, CAST(N'2018-11-09T13:40:00.000' AS DateTime), CAST(N'2018-11-09T14:30:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (9, 10, 9, CAST(N'2018-11-09T14:40:00.000' AS DateTime), CAST(N'2018-11-09T15:00:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (10, 11, 10, CAST(N'2018-11-09T15:35:00.000' AS DateTime), CAST(N'2018-11-09T16:25:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (11, 12, 11, CAST(N'2018-11-09T16:35:00.000' AS DateTime), CAST(N'2018-11-09T17:25:00.000' AS DateTime))
INSERT [dbo].[ThoiGianTietHoc] ([N], [ID], [TenTiet], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (12, 13, 12, CAST(N'2018-11-09T17:30:00.000' AS DateTime), CAST(N'2018-11-09T18:20:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ThoiGianTietHoc] OFF
ALTER TABLE [dbo].[BuoiHoc]  WITH CHECK ADD  CONSTRAINT [FK_BuoiHoc_DiaDiemHoc] FOREIGN KEY([IDDiaDiem])
REFERENCES [dbo].[DiaDiemHoc] ([ID])
GO
ALTER TABLE [dbo].[BuoiHoc] CHECK CONSTRAINT [FK_BuoiHoc_DiaDiemHoc]
GO
ALTER TABLE [dbo].[BuoiHoc]  WITH CHECK ADD  CONSTRAINT [FK_BuoiHoc_LopMonHoc] FOREIGN KEY([IDLopMonHoc])
REFERENCES [dbo].[LopMonHoc] ([ID])
GO
ALTER TABLE [dbo].[BuoiHoc] CHECK CONSTRAINT [FK_BuoiHoc_LopMonHoc]
GO
ALTER TABLE [dbo].[BuoiHoc]  WITH CHECK ADD  CONSTRAINT [FK_BuoiHoc_ThoiGianTietHoc] FOREIGN KEY([IDTietBatDau])
REFERENCES [dbo].[ThoiGianTietHoc] ([ID])
GO
ALTER TABLE [dbo].[BuoiHoc] CHECK CONSTRAINT [FK_BuoiHoc_ThoiGianTietHoc]
GO
ALTER TABLE [dbo].[BuoiHoc]  WITH CHECK ADD  CONSTRAINT [FK_BuoiHoc_ThoiGianTietHoc1] FOREIGN KEY([IDTietKetThuc])
REFERENCES [dbo].[ThoiGianTietHoc] ([ID])
GO
ALTER TABLE [dbo].[BuoiHoc] CHECK CONSTRAINT [FK_BuoiHoc_ThoiGianTietHoc1]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_BuoiHoc] FOREIGN KEY([IDBuoiHoc])
REFERENCES [dbo].[BuoiHoc] ([ID])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [FK_DiemDanh_BuoiHoc]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_SinhVien] FOREIGN KEY([IDSinhVien])
REFERENCES [dbo].[SinhVien] ([ID])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [FK_DiemDanh_SinhVien]
GO
ALTER TABLE [dbo].[LopMonHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopMonHoc_NhanVien] FOREIGN KEY([IDGiangVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[LopMonHoc] CHECK CONSTRAINT [FK_LopMonHoc_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Khoa] FOREIGN KEY([IDKhoa])
REFERENCES [dbo].[Khoa] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Khoa]
GO
ALTER TABLE [dbo].[pqAccessRight]  WITH CHECK ADD  CONSTRAINT [FK_pqAccessRight_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[GroupID] ([ID])
GO
ALTER TABLE [dbo].[pqAccessRight] CHECK CONSTRAINT [FK_pqAccessRight_GroupID]
GO
ALTER TABLE [dbo].[pqAccessRight]  WITH CHECK ADD  CONSTRAINT [FK_pqAccessRight_pqModule] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[pqModule] ([ID])
GO
ALTER TABLE [dbo].[pqAccessRight] CHECK CONSTRAINT [FK_pqAccessRight_pqModule]
GO
ALTER TABLE [dbo].[pqModule_FormControl]  WITH CHECK ADD  CONSTRAINT [FK_pqModule_FormControl_pqForm] FOREIGN KEY([FormID])
REFERENCES [dbo].[pqForm] ([ID])
GO
ALTER TABLE [dbo].[pqModule_FormControl] CHECK CONSTRAINT [FK_pqModule_FormControl_pqForm]
GO
ALTER TABLE [dbo].[pqModule_FormControl]  WITH CHECK ADD  CONSTRAINT [FK_pqModule_FormControl_pqModule] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[pqModule] ([ID])
GO
ALTER TABLE [dbo].[pqModule_FormControl] CHECK CONSTRAINT [FK_pqModule_FormControl_pqModule]
GO
ALTER TABLE [dbo].[pqNhomNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_pqNhomNhanVien_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[GroupID] ([ID])
GO
ALTER TABLE [dbo].[pqNhomNhanVien] CHECK CONSTRAINT [FK_pqNhomNhanVien_GroupID]
GO
ALTER TABLE [dbo].[pqNhomNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_pqNhomNhanVien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[pqNhomNhanVien] CHECK CONSTRAINT [FK_pqNhomNhanVien_NhanVien]
GO
ALTER TABLE [dbo].[SinhVien_LopMonHoc]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_LopMonHoc_LopMonHoc] FOREIGN KEY([IDLopMonHoc])
REFERENCES [dbo].[LopMonHoc] ([ID])
GO
ALTER TABLE [dbo].[SinhVien_LopMonHoc] CHECK CONSTRAINT [FK_SinhVien_LopMonHoc_LopMonHoc]
GO
ALTER TABLE [dbo].[SinhVien_LopMonHoc]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_LopMonHoc_SinhVien] FOREIGN KEY([IDSinhVien])
REFERENCES [dbo].[SinhVien] ([ID])
GO
ALTER TABLE [dbo].[SinhVien_LopMonHoc] CHECK CONSTRAINT [FK_SinhVien_LopMonHoc_SinhVien]
GO
/****** Object:  StoredProcedure [dbo].[AccessRightInsert]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[AccessRightInsert]
@GroupID int
AS
INSERT INTO pqAccessRight(ModuleID,GroupID,IsAccessRight)
SELECT F.ID,@GroupID,1
FROM pqModule AS F
WHERE F.ID NOT IN (SELECT ModuleID
									FROM pqAccessRight
									WHERE GroupID = @GroupID)
GO
/****** Object:  StoredProcedure [dbo].[getDSLopHocTheoNgay]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getDSLopHocTheoNgay]
@IDDiaDiem INT
AS
BEGIN
DECLARE @Ngay DATETIME
SET @Ngay=GETDATE()
SELECT lmh.ID,lmh.MaLopMonHoc,lmh.TenLopMonHoc FROM dbo.BuoiHoc AS b,dbo.LopMonHoc AS lmh WHERE YEAR(@Ngay)=YEAR(b.NgayHoc) AND
MONTH(@Ngay) = MONTH(b.NgayHoc) AND
DAY(@Ngay) = DAY(b.NgayHoc) AND b.IDDiaDiem=@IDDiaDiem AND lmh.ID=b.IDLopMonHoc
END
GO
/****** Object:  StoredProcedure [dbo].[GetLopMonHocTheoDiaDiem]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLopMonHocTheoDiaDiem]
@IDDiaDiem INT
AS 
BEGIN
SELECT bh.ID,bh.TenBuoiHoc,l.ID AS IDLopMonHoc,l.MaLopMonHoc,l.TenLopMonHoc,nv.TenNV FROM dbo.BuoiHoc AS bh,dbo.LopMonHoc AS l,dbo.NhanVien AS nv
WHERE bh.IDDiaDiem=@IDDiaDiem 
AND dbo.getTGTietBatDau(bh.ID) <= GETDATE() 
AND GETDATE() <= dbo.getTGTietKetThuc(bh.ID)
AND l.ID=bh.IDLopMonHoc
AND l.IDGiangVien=nv.ID
END
GO
/****** Object:  StoredProcedure [dbo].[getSVtheoIDBuoi]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getSVtheoIDBuoi]
@idBuoi INT
AS
BEGIN

SELECT sv.ID,sv.MSV,sv.TenSV,dd.DenLop,dd.TGDiemDanh,k.TenKhoa FROM dbo.DiemDanh AS dd, dbo.SinhVien AS sv, dbo.Khoa AS k WHERE dd.IDBuoiHoc=@idBuoi AND dd.IDSinhVien =sv.ID
AND sv.IDKhoa=k.ID
END
GO
/****** Object:  StoredProcedure [dbo].[getTTDiemDanh]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getTTDiemDanh]
@IDSinhVien NVARCHAR(100),
@IDLopMonHoc NVARCHAR(100)
AS
BEGIN
	SELECT bh.ID,bh.TenBuoiHoc,bh.NgayHoc,bh.GhiChu,ds.TenDiaDiem,
	 dbo.kiemtralopdiemdanh(@IDSinhVien,bh.ID) AS CoMat,
	 dbo.getTimeDiemDanhList(@IDSinhVien,bh.ID) AS TGDiemDanh
	FROM dbo.BuoiHoc AS bh,dbo.DiaDiemHoc AS ds WHERE bh.IDLopMonHoc=@IDLopMonHoc AND ds.ID=bh.IDDiaDiem
END
GO
/****** Object:  StoredProcedure [dbo].[pqResetNode]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pqResetNode]
@GroupID int,
@IsAccessRight bit
AS
BEGIN
	UPDATE pqAccessRight
	SET IsAccessRight = @IsAccessRight
	WHERE GroupID = @GroupID
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePqAccess]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[spUpdatePqAccess]
	@GroupID int,
	@ModuleID int,
	@IsAccessRight bit
AS
	declare @Valid int
	select @Valid = COUNT(*) from pqAccessRight where GroupID=@GroupID and ModuleID=@ModuleID
	if(@Valid>0)
		BEGIN
			update pqAccessRight set IsAccessRight=@IsAccessRight where GroupID=@GroupID and ModuleID=@ModuleID
		END
	ELSE
		BEGIN
			INSERT INTO pqAccessRight(GroupID,ModuleID,IsAccessRight) values (@GroupID,@ModuleID,@IsAccessRight)
		END
GO
/****** Object:  StoredProcedure [dbo].[tranhtrunglich]    Script Date: 12/29/2018 2:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tranhtrunglich]
@IDDiaDiem INT,
@IDTietBD INT,
@IDKetThuc INT,
@Ngay	DATETIME
AS
BEGIN
SELECT * FROM dbo.BuoiHoc AS b WHERE YEAR(@Ngay)=YEAR(b.NgayHoc) AND
MONTH(@Ngay) = MONTH(b.NgayHoc) AND
DAY(@Ngay) = DAY(b.NgayHoc) AND b.IDDiaDiem=@IDDiaDiem AND
( (@IDTietBD<=b.IDTietBatDau AND b.IDTietBatDau <= @IDKetThuc) 
OR (@IDTietBD<=b.IDTietKetThuc AND b.IDTietKetThuc <= @IDKetThuc))

END
GO
USE [master]
GO
ALTER DATABASE [dbtlu] SET  READ_WRITE 
GO
