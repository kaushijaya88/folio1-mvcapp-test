USE [master]
GO
/****** Object:  Database [StudentManagement]     ******/
CREATE DATABASE [StudentManagement]

GO
ALTER DATABASE [StudentManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StudentManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StudentManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StudentManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteclass]    Script Date: 2/24/2019 1:59:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteclass] @Id int
AS
delete from StudentManagement where [ClassId] = @Id;
delete from ClassManagement where Id = @Id;
GO
/****** Object:  Table [dbo].[ClassManagement]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassManagement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[TeacherName] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ClassManagement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentManagement]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentManagement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Age] [int] NOT NULL,
	[Gpa] [decimal](10, 1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_StudentManagement_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ClassManagement] ON 

INSERT [dbo].[ClassManagement] ([Id], [ClassName], [Location], [TeacherName], [CreatedDate], [LastUpdatedDate]) VALUES (1, N'History', N'Colombo', N'Ranil Perera', CAST(0x0000A9DB00000000 AS DateTime), NULL)
INSERT [dbo].[ClassManagement] ([Id], [ClassName], [Location], [TeacherName], [CreatedDate], [LastUpdatedDate]) VALUES (2, N'Maths', N'Mahawa', N'Sunil Perera', CAST(0x0000AB2100000000 AS DateTime), NULL)
INSERT [dbo].[ClassManagement] ([Id], [ClassName], [Location], [TeacherName], [CreatedDate], [LastUpdatedDate]) VALUES (4, N'Art', N'Mahawa', N'Jane Peiriss', CAST(0x0000A9FD0145C800 AS DateTime), CAST(0x0000A9FD0146B134 AS DateTime))
SET IDENTITY_INSERT [dbo].[ClassManagement] OFF
SET IDENTITY_INSERT [dbo].[StudentManagement] ON 

INSERT [dbo].[StudentManagement] ([Id], [FirstName], [LastName], [Age], [Gpa], [ClassId], [CreatedDate], [LastUpdatedDate]) VALUES (1, N'Kolitha', N'Katulanda', 31, CAST(3.2 AS Decimal(10, 1)), 1, CAST(0x0000AAC300000000 AS DateTime), CAST(0x0000AAC300000000 AS DateTime))
INSERT [dbo].[StudentManagement] ([Id], [FirstName], [LastName], [Age], [Gpa], [ClassId], [CreatedDate], [LastUpdatedDate]) VALUES (2, N'Kaushalya', N'Jayamini', 23, CAST(3.4 AS Decimal(10, 1)), 1, CAST(0x0000A95600000000 AS DateTime), CAST(0x0000AAA300000000 AS DateTime))
INSERT [dbo].[StudentManagement] ([Id], [FirstName], [LastName], [Age], [Gpa], [ClassId], [CreatedDate], [LastUpdatedDate]) VALUES (3, N'Vindya', N'Silva', 20, CAST(4.1 AS Decimal(10, 1)), 2, CAST(0x0000A93600000000 AS DateTime), CAST(0x0000A93600000000 AS DateTime))
INSERT [dbo].[StudentManagement] ([Id], [FirstName], [LastName], [Age], [Gpa], [ClassId], [CreatedDate], [LastUpdatedDate]) VALUES (4, N'Nihal', N'Silva', 21, CAST(2.3 AS Decimal(10, 1)), 2, CAST(0x0000A7E900000000 AS DateTime), CAST(0x0000A7E900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[StudentManagement] OFF
ALTER TABLE [dbo].[StudentManagement]  WITH CHECK ADD  CONSTRAINT [FK_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[ClassManagement] ([Id])
GO
ALTER TABLE [dbo].[StudentManagement] CHECK CONSTRAINT [FK_ClassId]
GO
USE [master]
GO
ALTER DATABASE [StudentManagement] SET  READ_WRITE 
GO
