USE [master]
GO
/****** Object:  Database [ParkingDB]    Script Date: 18/11/2021 1:32:35 ******/
CREATE DATABASE [ParkingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ParkingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\ParkingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ParkingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\ParkingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ParkingDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ParkingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ParkingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ParkingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ParkingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ParkingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ParkingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ParkingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ParkingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ParkingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ParkingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ParkingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ParkingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ParkingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ParkingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ParkingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ParkingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ParkingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ParkingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ParkingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ParkingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ParkingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ParkingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ParkingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ParkingDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ParkingDB] SET  MULTI_USER 
GO
ALTER DATABASE [ParkingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ParkingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ParkingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ParkingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ParkingDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ParkingDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ParkingDB', N'ON'
GO
ALTER DATABASE [ParkingDB] SET QUERY_STORE = OFF
GO
USE [ParkingDB]
GO
/****** Object:  Table [dbo].[UsersInfo]    Script Date: 18/11/2021 1:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInfo](
	[Name] [nchar](10) NOT NULL,
	[ID] [int] NOT NULL,
	[Phone] [int] NOT NULL,
	[Ticket] [nchar](10) NOT NULL,
	[Type] [nchar](10) NOT NULL,
	[Height] [float] NOT NULL,
	[Width] [float] NOT NULL,
	[Length] [float] NOT NULL,
	[Lot] [int] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UsersInfo] ([Name], [ID], [Phone], [Ticket], [Type], [Height], [Width], [Length], [Lot]) VALUES (N'Lucas     ', 2, 24525, N'VIP       ', N'Truck     ', 3353, 353, 353, 2)
INSERT [dbo].[UsersInfo] ([Name], [ID], [Phone], [Ticket], [Type], [Height], [Width], [Length], [Lot]) VALUES (N'Liam      ', 7, 53533, N'VIP       ', N'SUV       ', 4664, 464, 4364, 1)
INSERT [dbo].[UsersInfo] ([Name], [ID], [Phone], [Ticket], [Type], [Height], [Width], [Length], [Lot]) VALUES (N'Lily      ', 53, 4354, N'VIP       ', N'Crossover ', 3535, 53535, 3422, 3)
INSERT [dbo].[UsersInfo] ([Name], [ID], [Phone], [Ticket], [Type], [Height], [Width], [Length], [Lot]) VALUES (N'Mia       ', 435, 4646, N'Regular   ', N'Crossover ', 4351, 3545, 54352, NULL)
INSERT [dbo].[UsersInfo] ([Name], [ID], [Phone], [Ticket], [Type], [Height], [Width], [Length], [Lot]) VALUES (N'Oliver    ', 4242, 53535, N'VIP       ', N'Motorcycle', 535, 535446, 353, NULL)
INSERT [dbo].[UsersInfo] ([Name], [ID], [Phone], [Ticket], [Type], [Height], [Width], [Length], [Lot]) VALUES (N'Matthew   ', 5353, 2552, N'Regular   ', N'Private   ', 2000, 3999, 355, NULL)
GO
/****** Object:  StoredProcedure [dbo].[VehiclesByTicketType]    Script Date: 18/11/2021 1:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--

CREATE PROCEDURE [dbo].[VehiclesByTicketType]
	 @Ticket nchar(10)
AS
BEGIN
	
SELECT * FROM UsersInfo WHERE Ticket = @Ticket AND Lot>0
END
GO
USE [master]
GO
ALTER DATABASE [ParkingDB] SET  READ_WRITE 
GO
