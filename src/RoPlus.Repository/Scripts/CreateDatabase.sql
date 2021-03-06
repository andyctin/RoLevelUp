USE [master]
GO

/****** Object:  Database [RoPlus]    Script Date: 15/01/2017 17:43:11 ******/
CREATE DATABASE [RoPlus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoPlus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LOCALHOST\MSSQL\DATA\RoPlus.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoPlus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LOCALHOST\MSSQL\DATA\RoPlus_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO


USE [RoPlus]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 15/01/2017 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Section]    Script Date: 15/01/2017 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](16) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Section] ADD  CONSTRAINT [DF_Sections_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
