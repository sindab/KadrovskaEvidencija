USE [Kadrovska]
GO

/****** Object:  Table [dbo].[RadnikKurs]    Script Date: 11/7/17 6:14:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RadnikPovredaRO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RadID] [int] NOT NULL,
	[Datum] [smalldatetime] NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_RadnikPovredaRO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RadnikPovredaRO]  WITH CHECK ADD  CONSTRAINT [FK_RadnikPovredaRO_Radnik] FOREIGN KEY([RadID])
REFERENCES [dbo].[Radnik] ([ID])
GO

ALTER TABLE [dbo].[RadnikPovredaRO] CHECK CONSTRAINT [FK_RadnikPovredaRO_Radnik]
GO


