USE [master]
GO
/****** Object:  Database [QuanLyCuaHang]    Script Date: 6/24/2019 9:08:02 PM ******/
CREATE DATABASE [QuanLyCuaHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCuaHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyCuaHang.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyCuaHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyCuaHang_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyCuaHang] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCuaHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCuaHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCuaHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCuaHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCuaHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyCuaHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCuaHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyCuaHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCuaHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCuaHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCuaHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCuaHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyCuaHang]
GO
/****** Object:  Table [dbo].[CachThanhToan]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CachThanhToan](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CachThanhToan] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDongHang] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
	[Gia] [int] NOT NULL,
	[MaKhuyenMai] [varchar](30) NULL,
	[TinhTrang] [int] NOT NULL,
	[CachThanhToan] [int] NOT NULL,
	[isDelete] [int] NOT NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDongHang] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[SoDienThoai] [varchar](15) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKhuyenMai] [varchar](30) NOT NULL,
	[TenKhuyenMai] [nvarchar](50) NOT NULL,
	[MucKhuyenMai] [int] NOT NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](50) NOT NULL,
	[MaLoaiSanPham] [int] NOT NULL,
	[GiaGoc] [int] NOT NULL,
	[GiaBan] [int] NOT NULL,
	[SoLuongConLai] [int] NOT NULL,
	[HinhAnh] [nvarchar](200) NOT NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoan] [varchar](20) NOT NULL,
	[MatKhau] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 6/24/2019 9:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrang](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[TenTinhTrang] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CachThanhToan] ON 

INSERT [dbo].[CachThanhToan] ([Ma], [Ten]) VALUES (1, N'Tiền mặt')
INSERT [dbo].[CachThanhToan] ([Ma], [Ten]) VALUES (2, N'Ship')
SET IDENTITY_INSERT [dbo].[CachThanhToan] OFF
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (1, 5, 8, 1, CAST(0x0000AA6E01383AF1 AS DateTime), 3000000, NULL, 1, 1, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (2, 5, 8, 3, CAST(0x0000AA6E0139666A AS DateTime), 9000000, NULL, 3, 2, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (2, 6, 8, 1, CAST(0x0000AA6E01383AF1 AS DateTime), 3400000, NULL, 3, 1, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (3, 5, 10, 2, CAST(0x0000AA6E0139DA5D AS DateTime), 6000000, NULL, 1, 1, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (4, 5, 20, 1, CAST(0x0000AA76009FE142 AS DateTime), 4600000, NULL, 1, 1, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (5, 5, 21, 1, CAST(0x0000AA7600A23B75 AS DateTime), 1380000, N'HaHa', 1, 1, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (5, 6, 21, 1, CAST(0x0000AA7600A23B75 AS DateTime), 1050000, N'HaHa', 1, 1, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (7, 7, 22, 1, CAST(0x0000AA7600A291D3 AS DateTime), 4300000, NULL, 2, 2, 0)
INSERT [dbo].[DonHang] ([MaDongHang], [MaSanPham], [MaKhachHang], [SoLuong], [ThoiGian], [Gia], [MaKhuyenMai], [TinhTrang], [CachThanhToan], [isDelete]) VALUES (7, 12, 22, 4, CAST(0x0000AA7600A291D3 AS DateTime), 3200000, NULL, 2, 2, 0)
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (8, N'A Nam', N'333', N'321', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (10, N'Chị Lan', N'', N'', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (16, N'a hung', N'', N'', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (18, N'', N'', N'', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (19, N'a hung', N'', N'', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (20, N'A Minh', N'', N'', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (21, N'A Hung', N'', N'', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Email]) VALUES (22, N'Chi B', N'0385152718', N'100/53, Duong Ba Trac, p2, q8, HCM', NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [MucKhuyenMai]) VALUES (N'aa', N'Hung', 32)
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [MucKhuyenMai]) VALUES (N'HaHa', N'Ngay vui', 30)
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [MucKhuyenMai]) VALUES (N'Hihi', N'Sinh nhật shop', 20)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (1, N'Adidas')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (2, N'Nike')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (6, N'Jordan')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (7, N'Bitis''s')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (8, N'Thuong Dinh')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (5, N'Giày Alphabounce', 1, 4000000, 4600000, 2, N'D:\ISE_NMH_10\PTTKPM\source\Final-ManagementSystem\Image\ADD002.jpg', NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (6, N'Ubtraboost 3.0', 1, 3000000, 3500000, 4, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\ADD001.jpg', NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (7, N'Nike Air Max 97', 2, 3800000, 4300000, 10, N'D:\ISE_NMH_10\PTTKPM\source\Final-ManagementSystem\Image\NIK001.jpg', 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (8, N'Nike Air Max Plus', 2, 3900000, 4300000, 14, N'D:\ISE_NMH_10\PTTKPM\source\Final-ManagementSystem\Image\NikeP.jpg', 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (9, N'Jordan 10', 6, 2700000, 3300000, 6, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\jor10.jpg', NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (10, N'Air Jordan 32', 6, 2000000, 2500000, 10, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\jor32.jpg', 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (11, N'Bitis''s Hunter X', 7, 500000, 980000, 11, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\BitisX.jpg', NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (12, N'Bits''s Hunter', 7, 500000, 800000, 3, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\Bitis.jpg', 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (13, N'Nike Air Max Plus', 7, 2500000, 2900000, 18, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\NikeP.jpg', 1)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [GiaGoc], [GiaBan], [SoLuongConLai], [HinhAnh], [isDelete]) VALUES (14, N'Jordan 4', 6, 3000000, 3500000, 16, N'C:\Users\tranp\OneDrive\Desktop\1612225_FINAl\Source\source\Final-ManagementSystem\Image\jor4.jpg', 1)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau]) VALUES (N'admin', N'123')
SET IDENTITY_INSERT [dbo].[TinhTrang] ON 

INSERT [dbo].[TinhTrang] ([Ma], [TenTinhTrang]) VALUES (1, N'Đã thanh toán xong')
INSERT [dbo].[TinhTrang] ([Ma], [TenTinhTrang]) VALUES (2, N'Đang chờ ship')
INSERT [dbo].[TinhTrang] ([Ma], [TenTinhTrang]) VALUES (3, N'Đã hủy')
SET IDENTITY_INSERT [dbo].[TinhTrang] OFF
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_CachThanhToan] FOREIGN KEY([CachThanhToan])
REFERENCES [dbo].[CachThanhToan] ([Ma])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_CachThanhToan]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhuyenMai] FOREIGN KEY([MaKhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([MaKhuyenMai])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhuyenMai]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_SanPham]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_TinhTrang] FOREIGN KEY([TinhTrang])
REFERENCES [dbo].[TinhTrang] ([Ma])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_TinhTrang]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSanPham])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
USE [master]
GO
ALTER DATABASE [QuanLyCuaHang] SET  READ_WRITE 
GO
