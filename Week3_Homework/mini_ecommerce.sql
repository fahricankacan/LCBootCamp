USE [master]
GO
/****** Object:  Database [Week3]    Script Date: 6.05.2022 00:57:06 ******/
CREATE DATABASE [Week3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Week3', FILENAME = N'C:\Users\Fahrican\Week3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Week3_log', FILENAME = N'C:\Users\Fahrican\Week3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Week3] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Week3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Week3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Week3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Week3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Week3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Week3] SET ARITHABORT OFF 
GO
ALTER DATABASE [Week3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Week3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Week3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Week3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Week3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Week3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Week3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Week3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Week3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Week3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Week3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Week3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Week3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Week3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Week3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Week3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Week3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Week3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Week3] SET  MULTI_USER 
GO
ALTER DATABASE [Week3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Week3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Week3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Week3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Week3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Week3] SET QUERY_STORE = OFF
GO
USE [Week3]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Week3]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[adress] [nvarchar](500) NULL,
	[created_At] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](500) NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[first_name] [nvarchar](250) NOT NULL,
	[last_name] [nvarchar](250) NOT NULL,
	[telephone] [nvarchar](100) NULL,
	[adress1] [nvarchar](500) NULL,
	[adress2] [nvarchar](500) NULL,
	[city] [nvarchar](100) NULL,
	[state] [nvarchar](50) NULL,
	[postal_code] [nvarchar](100) NULL,
	[created_at] [datetime] NULL,
	[modifeid_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](500) NULL,
	[discount_persentage] [decimal](18, 0) NOT NULL,
	[active] [bit] NOT NULL,
	[created_at] [datetime] NULL,
	[modifeid_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[order_number] [nvarchar](250) NULL,
	[payment_id] [int] NULL,
	[shipper_id] [int] NULL,
	[ship_date] [datetime] NULL,
	[order_date] [datetime] NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[product_id] [int] NULL,
	[order_detail_number] [nvarchar](250) NULL,
	[price] [decimal](18, 0) NULL,
	[quantity] [int] NULL,
	[discount_id] [int] NULL,
	[total] [decimal](18, 0) NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nchar](10) NOT NULL,
	[allowed] [bit] NOT NULL,
	[created_at] [datetime] NULL,
	[modifeid_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](250) NULL,
	[list_price] [decimal](18, 0) NOT NULL,
	[sale_price] [decimal](18, 0) NOT NULL,
	[tax_rate] [decimal](18, 0) NOT NULL,
	[stock_id] [int] NOT NULL,
	[brand_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[suplier_id] [int] NULL,
	[created_at] [datetime] NULL,
	[modifed_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
	[currencyType] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipper]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[adress] [nvarchar](500) NULL,
	[phone] [nvarchar](100) NULL,
	[created_at] [datetime] NULL,
	[modifeid_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_Shipper] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stock_code] [nvarchar](250) NOT NULL,
	[count] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[modifeid_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6.05.2022 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address1] [nvarchar](500) NULL,
	[adress2] [nvarchar](500) NULL,
	[city] [nvarchar](100) NULL,
	[state] [nvarchar](100) NULL,
	[postal_code] [nvarchar](100) NULL,
	[phone] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Payment] FOREIGN KEY([payment_id])
REFERENCES [dbo].[Payment] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Payment]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Shipper] FOREIGN KEY([shipper_id])
REFERENCES [dbo].[Shipper] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Shipper]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Discount] FOREIGN KEY([discount_id])
REFERENCES [dbo].[Discount] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Discount]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([brand_id])
REFERENCES [dbo].[Brand] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Stock] FOREIGN KEY([stock_id])
REFERENCES [dbo].[Stock] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Stock]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([suplier_id])
REFERENCES [dbo].[Supplier] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
USE [master]
GO
ALTER DATABASE [Week3] SET  READ_WRITE 
GO
