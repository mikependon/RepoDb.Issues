USE [TestDB]
GO

CREATE TABLE [survey].[Companies](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL
) ON [PRIMARY]

CREATE TABLE [directory].[Companies](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL
) ON [PRIMARY]
