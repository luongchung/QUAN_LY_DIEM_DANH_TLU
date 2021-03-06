USE [master]
GO
/****** Object:  Database [dbtlu]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  Table [dbo].[GroupID]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/30/2018 2:19:04 AM ******/
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
	[IDLoaiNV] [int] NULL,
	[DiaChi] [nvarchar](500) NULL,
	[Password] [nvarchar](200) NULL,
	[IsLock] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pqAccessRight]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  Table [dbo].[pqForm]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  Table [dbo].[pqModule]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  Table [dbo].[pqModule_FormControl]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  Table [dbo].[pqNhomNhanVien]    Script Date: 10/30/2018 2:19:04 AM ******/
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
SET IDENTITY_INSERT [dbo].[GroupID] ON 

INSERT [dbo].[GroupID] ([ID], [GroupName], [DienGiai]) VALUES (1, N'QTV', N'Quản trị hệ thống')
SET IDENTITY_INSERT [dbo].[GroupID] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [MaNV], [TenNV], [GioiTinh], [Tuoi], [SDT], [IDLoaiNV], [DiaChi], [Password], [IsLock]) VALUES (1, N'luongchung', N'Lương Văn Chung', 1, 23, N'01234443401', 1, N'Hải Dương', N'EB18B0463340D4D9A139714B92E31A7F', 0)
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
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (11, 16, 1, 0)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (12, 17, 1, 0)
INSERT [dbo].[pqAccessRight] ([ID], [ModuleID], [GroupID], [IsAccessRight]) VALUES (13, 18, 1, 0)
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
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (12, N'Tab 2', NULL, 5)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (13, N'Khôi phục mật khẩu', NULL, 12)
INSERT [dbo].[pqModule] ([ID], [Name], [DienGiai], [IDCha]) VALUES (14, N'Phân quyền chức năng', NULL, 12)
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
SET IDENTITY_INSERT [dbo].[pqModule_FormControl] OFF
SET IDENTITY_INSERT [dbo].[pqNhomNhanVien] ON 

INSERT [dbo].[pqNhomNhanVien] ([ID], [GroupID], [MaNV]) VALUES (2, 1, 1)
SET IDENTITY_INSERT [dbo].[pqNhomNhanVien] OFF
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
/****** Object:  StoredProcedure [dbo].[AccessRightInsert]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[pqResetNode]    Script Date: 10/30/2018 2:19:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdatePqAccess]    Script Date: 10/30/2018 2:19:04 AM ******/
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
USE [master]
GO
ALTER DATABASE [dbtlu] SET  READ_WRITE 
GO
