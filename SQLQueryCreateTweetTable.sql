USE [master]
GO

/****** Object:  Table [dbo].[Tweet]    Script Date: 17.02.2016 10:51:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tweet](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[QueryKey] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Tweet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


