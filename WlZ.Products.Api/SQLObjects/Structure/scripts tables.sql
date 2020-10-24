USE [master]
GO
/****** Object:  Database [WLZ_Products]    Script Date: 8/5/2020 10:23:37 PM ******/
CREATE DATABASE [WLZ_Products]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WLZ_Products', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\WLZ_Products.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WLZ_Products_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\WLZ_Products_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WLZ_Products] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WLZ_Products].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WLZ_Products] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WLZ_Products] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WLZ_Products] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WLZ_Products] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WLZ_Products] SET ARITHABORT OFF 
GO
ALTER DATABASE [WLZ_Products] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WLZ_Products] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WLZ_Products] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WLZ_Products] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WLZ_Products] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WLZ_Products] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WLZ_Products] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WLZ_Products] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WLZ_Products] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WLZ_Products] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WLZ_Products] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WLZ_Products] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WLZ_Products] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WLZ_Products] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WLZ_Products] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WLZ_Products] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WLZ_Products] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WLZ_Products] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WLZ_Products] SET  MULTI_USER 
GO
ALTER DATABASE [WLZ_Products] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WLZ_Products] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WLZ_Products] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WLZ_Products] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WLZ_Products] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WLZ_Products]
GO
/****** Object:  Table [dbo].[category]    Script Date: 8/5/2020 10:23:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 8/5/2020 10:23:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client] [nvarchar](100) NOT NULL,
	[date] [datetime] NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderDetails]    Script Date: 8/5/2020 10:23:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idOrder] [int] NOT NULL,
	[idProduct] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_orderDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 8/5/2020 10:23:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[creationDate] [datetime] NOT NULL,
	[description] [nvarchar](150) NOT NULL,
	[idsubcategory] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[active] [bit] NOT NULL,
	[modifiedDate] [datetime] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subcategory]    Script Date: 8/5/2020 10:23:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subcategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[idcategory] [int] NOT NULL,
 CONSTRAINT [PK_subcategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[orderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderDetails_order] FOREIGN KEY([idOrder])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[orderDetails] CHECK CONSTRAINT [FK_orderDetails_order]
GO
ALTER TABLE [dbo].[orderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderDetails_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[orderDetails] CHECK CONSTRAINT [FK_orderDetails_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_product] FOREIGN KEY([idsubcategory])
REFERENCES [dbo].[subcategory] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_product]
GO
ALTER TABLE [dbo].[subcategory]  WITH CHECK ADD  CONSTRAINT [FK_subcategory_category] FOREIGN KEY([idcategory])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[subcategory] CHECK CONSTRAINT [FK_subcategory_category]
GO
USE [master]
GO
ALTER DATABASE [WLZ_Products] SET  READ_WRITE 
GO
