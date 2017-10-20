USE [Kadrovska]
GO
/****** Object:  UserDefinedFunction [dbo].[fnVratiRazlikuGMD]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnVratiRazlikuGMD](
	@datumOd datetime,
	@datumDo datetime
)

RETURNS @rd TABLE
(
	[AutoID] [int] IDENTITY (1, 1) NOT NULL ,
    [DatumOd] [datetime],
    [DatumDo] [datetime],
    [Godina] int NULL,
    [Mjeseci] int NULL,
    [Dana] int NULL
)

AS

BEGIN
	DECLARE @tmpdate datetime, @years int, @months int, @days int
	SELECT @tmpdate = @datumOd, @datumDo = ISNULL(@datumDo, GETDATE())

	SELECT @years = DATEDIFF(yy, @tmpdate, @datumDo) - CASE WHEN (MONTH(@datumOd) > MONTH(@datumDo)) OR (MONTH(@datumOd) = MONTH(@datumDo) AND DAY(@datumOd) > DAY(@datumDo)) THEN 1 ELSE 0 END
	SELECT @tmpdate = DATEADD(yy, @years, @tmpdate)
	SELECT @months = DATEDIFF(m, @tmpdate, @datumDo) - CASE WHEN DAY(@datumOd) > DAY(@datumDo) THEN 1 ELSE 0 END
	SELECT @tmpdate = DATEADD(m, @months, @tmpdate)
	SELECT @days = DATEDIFF(d, @tmpdate, @datumDo)

	INSERT @rd
		(DatumOd, DatumDo, Godina, Mjeseci, Dana)
	SELECT @datumOd DatumOd, @datumDo DatumDo, @years Godina, @months Mjeseci, @days Dana	
	
	RETURN
END


GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[AllDay] [bit] NULL,
	[Subject] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
	[ResourceID] [int] NULL,
	[ResourceIDs] [nvarchar](max) NULL,
	[ReminderInfo] [nvarchar](max) NULL,
	[RecurrenceInfo] [nvarchar](max) NULL,
	[TimeZoneId] [nvarchar](max) NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drzavljanstvo]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drzavljanstvo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Drzavljanstvo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Firma]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Firma](
	[ID] [int] NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[PuniNaziv] [nvarchar](200) NULL,
	[Mjesto] [int] NULL,
	[Adresa] [nvarchar](50) NULL,
	[Telefon] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Mobilni] [varchar](50) NULL,
	[Maticni] [varchar](50) NULL,
	[PIB] [varchar](50) NULL,
	[JIB] [varchar](50) NULL,
	[Ziro] [varchar](50) NULL,
	[Web] [varchar](50) NULL,
	[Mail] [varchar](50) NULL,
 CONSTRAINT [PK_Firma] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mjesto]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mjesto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OpstinaID] [int] NULL,
	[PostBr] [int] NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Mjesto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NacinPrestankaRO]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NacinPrestankaRO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_NacinPrestankaRO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nacionalnost]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nacionalnost](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Nacionalnost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Opstina]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opstina](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sifra] [nvarchar](5) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Opstina] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PorodicnoStanje]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PorodicnoStanje](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PorodicnoStanje] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PoslovnaJedinica]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PoslovnaJedinica](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[PuniNaziv] [nvarchar](200) NULL,
	[Mjesto] [int] NULL,
	[Adresa] [nvarchar](50) NULL,
	[Telefon] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Mobilni] [varchar](50) NULL,
	[Maticni] [varchar](50) NULL,
	[PIB] [varchar](50) NULL,
	[JIB] [varchar](50) NULL,
	[Ziro] [varchar](50) NULL,
	[Web] [varchar](50) NULL,
	[Mail] [varchar](50) NULL,
 CONSTRAINT [PK_PoslovnaJedinica] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Radnik]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Radnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JMBG] [varchar](13) NULL CONSTRAINT [DF_Radnik_JMBG]  DEFAULT (''),
	[Prezime] [nvarchar](50) NOT NULL CONSTRAINT [DF_Radnik_Prezime]  DEFAULT (''),
	[DjevPrezime] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_DjevPrezime]  DEFAULT (''),
	[Ime] [nvarchar](50) NOT NULL CONSTRAINT [DF_Radnik_Ime]  DEFAULT (''),
	[ImeOca] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_ImeOca]  DEFAULT (''),
	[Bitovi] [int] NOT NULL CONSTRAINT [DF_Radnik_Bitovi]  DEFAULT ((0)),
	[Titula] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_Titula]  DEFAULT (''),
	[Funkcija] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_Funkcija]  DEFAULT (''),
	[MjestoRodjenja] [int] NULL,
	[DatumRodjenja] [smalldatetime] NULL CONSTRAINT [DF_Radnik_DatumRodjenja]  DEFAULT (getdate()),
	[DrzavljanstvoID] [int] NULL,
	[NacionalnostID] [int] NULL,
	[PorodicnoStanjeID] [int] NULL,
	[MjestoStan] [int] NULL,
	[AdresaStan] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_AdresaStan]  DEFAULT (''),
	[TelefonStan] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_TelefonStan]  DEFAULT (''),
	[TelefonMob] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_TelefonMob]  DEFAULT (''),
	[TelefonPosao] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_TelefonPosao]  DEFAULT (''),
	[Zanimanje] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_Zanimanje]  DEFAULT (''),
	[StrucnaSpremaID] [int] NULL,
	[ZavrsenaSkola] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_ZavrsenaSkola]  DEFAULT (''),
	[RadnoMjestoID] [int] NULL,
	[BrLK] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_BrLK]  DEFAULT (''),
	[BrRadneKnj] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_BrRadneKnj]  DEFAULT (''),
	[OpstinaIzdavanjaRK] [int] NULL,
	[LicniBrOsiguranja] [nvarchar](50) NULL CONSTRAINT [DF_Radnik_LicniBrOsiguranja]  DEFAULT (''),
	[DatumPrvogZapos] [smalldatetime] NULL,
	[PrethodniStazMj] [int] NULL CONSTRAINT [DF_Radnik_PrethodniStazMj]  DEFAULT ((0)),
	[PrethodniStazDan] [int] NULL CONSTRAINT [DF_Radnik_PrethodniStazDan]  DEFAULT ((0)),
	[PrethodniStazUFirmiMj] [int] NULL CONSTRAINT [DF_Radnik_PrethodniStazMj1]  DEFAULT ((0)),
	[PrethodniStazUFirmiDan] [int] NULL CONSTRAINT [DF_Radnik_PrethodniStazUFirmiDan]  DEFAULT ((0)),
	[DatumZapos] [smalldatetime] NULL,
	[TipRadnogOdnosaID] [int] NULL,
	[NacinPrestankaRoID] [int] NULL,
	[DatumPrestankaRO] [smalldatetime] NULL,
	[Napomena] [nvarchar](4000) NULL CONSTRAINT [DF_Radnik_Napomena]  DEFAULT (''),
	[FindStr]  AS (((([Prezime]+' ')+[Ime])+' ')+[JMBG]),
	[Lozinka] [nvarchar](50) NULL,
	[Slika] [varbinary](max) NULL,
	[Naziv]  AS (([Prezime]+' ')+[Ime]),
	[eMail] [nvarchar](50) NULL,
	[PoslovnaJedinicaID] [int] NULL,
	[Pol] [nvarchar](10) NULL,
 CONSTRAINT [PK_Radnik] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RadnikBolovanje]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnikBolovanje](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RadID] [int] NOT NULL,
	[DatumOd] [smalldatetime] NULL,
	[DatumDo] [smalldatetime] NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_RadnikBolovanje] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RadnikDjeca]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnikDjeca](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RadID] [int] NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[DatumRodj] [smalldatetime] NULL,
	[JMBG] [nvarchar](13) NULL,
	[Bitovi] [int] NOT NULL CONSTRAINT [DF_RadnikDjeca_Bitovi]  DEFAULT ((0)),
	[Napomena] [nvarchar](500) NULL,
 CONSTRAINT [PK_RadnikDjeca] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RadnikGO]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnikGO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RadID] [int] NOT NULL,
	[DatumOd] [smalldatetime] NULL,
	[DatumDo] [smalldatetime] NULL,
	[Zaduzio] [int] NOT NULL CONSTRAINT [DF_RadnikGO_Zaduzio]  DEFAULT ((0)),
	[Razduzio] [int] NOT NULL CONSTRAINT [DF_RadnikGO_Razduzio]  DEFAULT ((0)),
	[Napomena] [nvarchar](500) NULL,
 CONSTRAINT [PK_RadnikGO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RadnikKurs]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnikKurs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RadID] [int] NOT NULL,
	[Datum] [smalldatetime] NULL,
	[DatumDo] [smalldatetime] NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_RadnikKurs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RadnoMjesto]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnoMjesto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_RadnoMjesto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resources]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceID] [int] NOT NULL,
	[ResourceName] [nvarchar](50) NULL,
	[Color] [int] NULL,
	[Image] [image] NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StrucnaSprema]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrucnaSprema](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](10) NOT NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_StrucnaSprema] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipRadnogOdnosa]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipRadnogOdnosa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](500) NULL,
	[Bitovi] [int] NULL,
 CONSTRAINT [PK_TipRadnogOdnosa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[RadnikStaz]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RadnikStaz]

AS

SELECT RadID,
		--UkupnoMjFirma, 
		Godina, Mjeseci, Dana, 
		--UkupnoMjPrethodni, 
		StazGPrethodni, StazMjPrethodni,StazDanaPrethodni,
		Godina+StazGPrethodni+CAST((Mjeseci+StazMjPrethodni)/12 as int) G, 
		CAST((Mjeseci+StazMjPrethodni)%12 as int) M,
		Dana+StazDanaPrethodni D
	FROM(
		SELECT ID RadID, --ISNULL(UkupnoMjFirma,0) UkupnoMjFirma, 
			ISNULL(Godina,0) Godina, ISNULL(Mjeseci,0) Mjeseci, ISNULL(Dana,0) Dana, 
			--ISNULL(UkupnoMjPrethodni,0) UkupnoMjPrethodni, 
			ISNULL(CAST(UkupnoMjPrethodni/12 as int),0) StazGPrethodni, ISNULL(CAST(UkupnoMjPrethodni%12 as int),0) StazMjPrethodni
			,UkupnoDanaPrethodni StazDanaPrethodni
		FROM(
			SELECT R.ID,
				--UkupnoMjFirma = (S.Godina*12)+S.Mjeseci,
				S.Godina
				,S.Mjeseci
				,S.Dana -- + CAST(ISNULL(R.[PrethodniStazDan]%30, 0) as int) Dana
				--prethodni
				,UkupnoMjPrethodni = ISNULL(R.[PrethodniStazMj], 0) + CAST(ISNULL(R.[PrethodniStazDan]/30, 0) as int)
				,UkupnoDanaPrethodni = CAST(ISNULL(R.[PrethodniStazDan]%30, 0) as int)
			FROM [Radnik] R
			CROSS APPLY [dbo].[fnVratiRazlikuGMD] (R.DatumZapos, CASE R.[Bitovi] & 8 WHEN 0 THEN GETDATE() ELSE R.[DatumPrestankaRO] END) S
			--WHERE R.ID = @radID
		) S
	) S
GO
/****** Object:  View [dbo].[vRadnik]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vRadnik]

AS

SELECT 
	R.[ID]
	,R.[JMBG]
	,R.[Prezime]
	,R.[DjevPrezime]
	,R.[Ime]
	,R.[ImeOca]
	,R.[Bitovi]
	,R.[Titula]
	,R.[Funkcija]
	,R.[MjestoRodjenja], MR.Naziv MjestoRodjenjaNaziv
	,R.[DatumRodjenja]
	,R.[DrzavljanstvoID], D.Naziv DrzavljanstvoNaziv
	,R.[NacionalnostID], N.Naziv NacionalnostNaziv
	,R.[PorodicnoStanjeID], PS.Naziv PorodicnoStanjeNaziv
	,R.[MjestoStan], MS.Naziv MjestoStanNaziv
	,R.[AdresaStan]
	,R.[TelefonStan]
	,R.[TelefonMob]
	,R.[TelefonPosao]
	,R.[Zanimanje]
	,R.[StrucnaSpremaID], SS.Naziv StrucnaSpremaNaziv
	,R.[ZavrsenaSkola]
	,R.[RadnoMjestoID], RM.Naziv RadnoMjestoNaziv
	,R.[BrLK]
	,R.[BrRadneKnj]
	,R.[OpstinaIzdavanjaRK], OI.Naziv OpstinaIzdavanjaNaziv
	,R.[LicniBrOsiguranja]
	,R.[DatumPrvogZapos]
	,R.[PrethodniStazMj]
	,R.[PrethodniStazDan]
	,R.[PrethodniStazUFirmiMj]
	,R.[PrethodniStazUFirmiDan]
	,R.[DatumZapos]
	,R.[TipRadnogOdnosaID], TRO.Naziv TipRadnogOdnosaNaziv
	,R.[NacinPrestankaRoID], NP.Naziv NacinPrestankaNaziv
	,R.[DatumPrestankaRO]
	,R.[Napomena]
	,R.[FindStr]
	,R.[Lozinka]
	,R.[Slika]
	,R.[Naziv]
	,R.[eMail]
	,R.[PoslovnaJedinicaID], PJ.Naziv PoslovnaJedinicaNaziv
	,R.[Pol]
	,RS.G, RS.M, RS.D
FROM [dbo].[Radnik] R
LEFT JOIN Mjesto MR ON R.MjestoRodjenja = MR.ID
LEFT JOIN Drzavljanstvo D ON R.DrzavljanstvoID = D.ID
LEFT JOIN Nacionalnost N ON R.NacionalnostID = N.ID
LEFT JOIN PorodicnoStanje PS ON R.PorodicnoStanjeID = PS.ID
LEFT JOIN Mjesto MS ON R.MjestoStan = MS.ID
LEFT JOIN StrucnaSprema SS ON R.StrucnaSpremaID = SS.ID
LEFT JOIN RadnoMjesto RM ON R.RadnoMjestoID = RM.ID
LEFT JOIN Opstina OI ON R.OpstinaIzdavanjaRK = OI.ID
LEFT JOIN TipRadnogOdnosa TRO ON R.TipRadnogOdnosaID = TRO.ID
LEFT JOIN NacinPrestankaRO NP ON R.NacinPrestankaRoID = NP.ID
LEFT JOIN PoslovnaJedinica PJ ON R.PoslovnaJedinicaID = PJ.ID
LEFT JOIN RadnikStaz RS ON R.ID = RS.RadID
GO
ALTER TABLE [dbo].[Firma]  WITH CHECK ADD  CONSTRAINT [FK_Firma_Mjesto] FOREIGN KEY([Mjesto])
REFERENCES [dbo].[Mjesto] ([ID])
GO
ALTER TABLE [dbo].[Firma] CHECK CONSTRAINT [FK_Firma_Mjesto]
GO
ALTER TABLE [dbo].[Mjesto]  WITH CHECK ADD  CONSTRAINT [FK_Mjesto_Opstina] FOREIGN KEY([OpstinaID])
REFERENCES [dbo].[Opstina] ([ID])
GO
ALTER TABLE [dbo].[Mjesto] CHECK CONSTRAINT [FK_Mjesto_Opstina]
GO
ALTER TABLE [dbo].[PoslovnaJedinica]  WITH CHECK ADD  CONSTRAINT [FK_PoslovnaJedinica_Mjesto] FOREIGN KEY([Mjesto])
REFERENCES [dbo].[Mjesto] ([ID])
GO
ALTER TABLE [dbo].[PoslovnaJedinica] CHECK CONSTRAINT [FK_PoslovnaJedinica_Mjesto]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_Drzavljanstvo] FOREIGN KEY([DrzavljanstvoID])
REFERENCES [dbo].[Drzavljanstvo] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_Drzavljanstvo]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_Mjesto] FOREIGN KEY([MjestoRodjenja])
REFERENCES [dbo].[Mjesto] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_Mjesto]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_Mjesto1] FOREIGN KEY([MjestoStan])
REFERENCES [dbo].[Mjesto] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_Mjesto1]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_NacinPrestankaRO] FOREIGN KEY([NacinPrestankaRoID])
REFERENCES [dbo].[NacinPrestankaRO] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_NacinPrestankaRO]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_Nacionalnost] FOREIGN KEY([NacionalnostID])
REFERENCES [dbo].[Nacionalnost] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_Nacionalnost]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_Opstina2] FOREIGN KEY([OpstinaIzdavanjaRK])
REFERENCES [dbo].[Opstina] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_Opstina2]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_PorodicnoStanje] FOREIGN KEY([PorodicnoStanjeID])
REFERENCES [dbo].[PorodicnoStanje] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_PorodicnoStanje]
GO
ALTER TABLE [dbo].[Radnik]  WITH CHECK ADD  CONSTRAINT [FK_Radnik_PoslovnaJedinica] FOREIGN KEY([PoslovnaJedinicaID])
REFERENCES [dbo].[PoslovnaJedinica] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_PoslovnaJedinica]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_RadnoMjesto] FOREIGN KEY([RadnoMjestoID])
REFERENCES [dbo].[RadnoMjesto] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_RadnoMjesto]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_StrucnaSprema] FOREIGN KEY([StrucnaSpremaID])
REFERENCES [dbo].[StrucnaSprema] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_StrucnaSprema]
GO
ALTER TABLE [dbo].[Radnik]  WITH NOCHECK ADD  CONSTRAINT [FK_Radnik_TipRadnogOdnosa] FOREIGN KEY([TipRadnogOdnosaID])
REFERENCES [dbo].[TipRadnogOdnosa] ([ID])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_TipRadnogOdnosa]
GO
ALTER TABLE [dbo].[RadnikBolovanje]  WITH CHECK ADD  CONSTRAINT [FK_RadnikBolovanje_Radnik] FOREIGN KEY([RadID])
REFERENCES [dbo].[Radnik] ([ID])
GO
ALTER TABLE [dbo].[RadnikBolovanje] CHECK CONSTRAINT [FK_RadnikBolovanje_Radnik]
GO
ALTER TABLE [dbo].[RadnikDjeca]  WITH CHECK ADD  CONSTRAINT [FK_RadnikDjeca_Radnik] FOREIGN KEY([RadID])
REFERENCES [dbo].[Radnik] ([ID])
GO
ALTER TABLE [dbo].[RadnikDjeca] CHECK CONSTRAINT [FK_RadnikDjeca_Radnik]
GO
ALTER TABLE [dbo].[RadnikGO]  WITH CHECK ADD  CONSTRAINT [FK_RadnikGO_Radnik] FOREIGN KEY([RadID])
REFERENCES [dbo].[Radnik] ([ID])
GO
ALTER TABLE [dbo].[RadnikGO] CHECK CONSTRAINT [FK_RadnikGO_Radnik]
GO
ALTER TABLE [dbo].[RadnikKurs]  WITH CHECK ADD  CONSTRAINT [FK_RadnikKurs_Radnik] FOREIGN KEY([RadID])
REFERENCES [dbo].[Radnik] ([ID])
GO
ALTER TABLE [dbo].[RadnikKurs] CHECK CONSTRAINT [FK_RadnikKurs_Radnik]
GO
/****** Object:  StoredProcedure [dbo].[DodajGodisnjiReminder]    Script Date: 10/9/17 6:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DodajGodisnjiReminder](
	@pType int,
	@pStartDate smalldatetime,
	@pEndDate smalldatetime,
	@pSubject nvarchar(100),
	@pLocation nvarchar(4000),
	@pDescription nvarchar(4000),
	@pStatus int,
	@pLabel int,
	@pResourceID int,
	@pResourceIDs nvarchar(4000),
	@pReminderAlertTime datetime,
	@pRecurrenceInfoStart datetime,
	@pRadID nvarchar(4000)
)

AS

/*
	@Type=NULL,
	@StartDate='2017-10-07 11:30:00',
	@EndDate='2017-10-07 12:00:00',
	@AllDay=0,
	@Subject=N'Rodjendan osobe',
	@Location=N'',
	@Description=N'',
	@Status=0,
	@Label=3,
	@ResourceID=1,
	@ResourceIDs=NULL,
	@ReminderInfo=N'<Reminders><Reminder AlertTime="10/07/2017 11:15:00" /></Reminders>',
	@RecurrenceInfo=N'<RecurrenceInfo Start="10/07/2017 11:30:00" DayNumber="7" WeekOfMonth="0" WeekDays="64" Id="daa83d63-53dc-4ce4-9ec0-fd8ae794b185" Month="10" Type="3" Version="1" />',
	@TimeZoneId=N'Central European Standard Time',
	@CustomField1=NULL
*/

DECLARE @SubjectR nvarchar(100)
DECLARE @radnik nvarchar(100)

--IF @pRadID > 0
--BEGIN
	SELECT @radnik = ' - ' + Prezime + ' ' + Ime FROM Radnik WHERE ID = CAST(@pRadID as int)
	SELECT @SubjectR = @pSubject + @radnik
--END
DECLARE @pReminderInfo nvarchar(100)
SET @pReminderInfo = N'<Reminders><Reminder AlertTime="' + CONVERT(nvarchar(30), @pReminderAlertTime, 121) + '" /></Reminders>'
DECLARE @id uniqueidentifier = NEWID()
DECLARE @pRecurrenceInfo nvarchar(200)
SET @pRecurrenceInfo = N'<RecurrenceInfo Start="' + CONVERT(nvarchar(30), @pRecurrenceInfoStart, 121) + '" DayNumber="' + CAST(DATEPART(DAY, @pRecurrenceInfoStart) as nvarchar(50)) + '" WeekOfMonth="0" WeekDays="64" Id="' + CAST(@id as nvarchar(50)) + '" Month="' + CAST(DATEPART(MONTH, @pRecurrenceInfoStart) as nvarchar(50)) + '" Type="3" Version="1" />'

exec sp_executesql 
	N'INSERT INTO [dbo].[Appointments] (
		[Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceID], [ResourceIDs], 
		[ReminderInfo], [RecurrenceInfo], [TimeZoneId], [CustomField1]) 
	VALUES (
		@Type, @StartDate, @EndDate, @AllDay, @Subject, @Location, @Description, @Status, @Label, @ResourceID, @ResourceIDs, 
		@ReminderInfo, @RecurrenceInfo, @TimeZoneId, @CustomField1);

SELECT UniqueID, Type, StartDate, EndDate, AllDay, Subject, Location, Description, Status, Label, ResourceID, ResourceIDs, 
	ReminderInfo, RecurrenceInfo, TimeZoneId, CustomField1 
FROM Appointments 
WHERE (UniqueID = SCOPE_IDENTITY())',
	N'@Type int,
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@AllDay bit,
	@Subject nvarchar(100),
	@Location nvarchar(4000),
	@Description nvarchar(4000),
	@Status int,
	@Label int,
	@ResourceID int,
	@ResourceIDs nvarchar(4000),
	@ReminderInfo nvarchar(71),
	@RecurrenceInfo nvarchar(164),
	@TimeZoneId nvarchar(30),
	@CustomField1 nvarchar(4000)',
	@Type=@pType,
	@StartDate=@pStartDate,
	@EndDate=@pEndDate,
	@AllDay=0,
	@Subject=@SubjectR,
	@Location=@pLocation,
	@Description=@pDescription,
	@Status=@pStatus,
	@Label=@pLabel,
	@ResourceID=@pResourceID,
	@ResourceIDs=@pResourceIDs,
	@ReminderInfo=@pReminderInfo,
	@RecurrenceInfo=@pRecurrenceInfo,
	@TimeZoneId=N'Central European Standard Time',
	@CustomField1=@pRadID



	
GO
