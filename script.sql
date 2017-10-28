/*
Run this script on:

        DABANOVI\EC2016.kadrOld    -  This database will be modified

to synchronize it with:

        DABANOVI\EC2016.kadr

You are recommended to back up your database before running this script

Script created by SQL Compare version 9.0.0 from Red Gate Software Ltd at 24/10/2017 11:59:20

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Altering [dbo].[Radnik]'
GO
ALTER TABLE [dbo].[Radnik] ADD
[DatumIstekaUgovora] [smalldatetime] NULL
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[vRadnik]'
GO
ALTER VIEW [dbo].[vRadnik]

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
	--,R.[PrethodniStazMj]
	--,R.[PrethodniStazDan]
	--,R.[PrethodniStazUFirmiMj]
	--,R.[PrethodniStazUFirmiDan]
	,R.[DatumZapos]
	,R.[TipRadnogOdnosaID], TRO.Naziv TipRadnogOdnosaNaziv
	,R.DatumIstekaUgovora
	,DATEDIFF(DAY, GETDATE(), R.DatumIstekaUgovora) DoIstekaUg
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
	,RS.StazGPrethodni, RS.StazMjPrethodni, RS.StazDanaPrethodni
	,RS.Godina, RS.Mjeseci, RS.Dana
	,RS.G, RS.M, RS.D
	,RGO.GOZaduzio, RGO.GORazduzio, RGO.GOZaduzio-RGO.GORazduzio as GOOstalo
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
LEFT JOIN (SELECT [RadID],SUM([Zaduzio]) GOZaduzio,SUM([Razduzio]) GORazduzio FROM [dbo].[RadnikGO] GROUP BY RadID) RGO ON R.ID = RGO.RadID
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[vRadnikGO]'
GO
CREATE VIEW vRadnikGO

AS

SELECT 
	RG.[ID]
	,RG.[RadID], R.Prezime + ' ' + R.Ime Radnik
	,DATEPART(YEAR, RG.[DatumOd]) Godina
	,RG.[DatumOd]
	,RG.[DatumDo]
	,RG.[Zaduzio]
	,RG.[Razduzio]
	,RG.[Napomena]
FROM [dbo].[RadnikGO] RG
LEFT JOIN Radnik R ON RG.RadID = R.ID

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

PRINT N'Creating [dbo].[DodajGodisnjiOdmor]'
GO
CREATE PROCEDURE [dbo].[DodajGodisnjiOdmor](
	@Dana int, --koliko dana dodaje svakom radniku
	@Zatvori int --da li zatvara neiskoristene dane
)

AS

DECLARE @nezatvorenihDana as int

DECLARE crsRadnik CURSOR
READ_ONLY
FOR SELECT [ID] FROM Radnik

DECLARE @id int

OPEN crsRadnik
FETCH NEXT FROM crsRadnik INTO @id
WHILE (@@fetch_status <> -1)
BEGIN
	IF (@@fetch_status <> -2)
	BEGIN
		SET @nezatvorenihDana = 0
		--ZATVORI
		IF @Zatvori > 0
		BEGIN
			SELECT @nezatvorenihDana = SUM(Zaduzio - Razduzio) FROM [RadnikGO] WHERE RadID = @id

			IF ISNULL(@nezatvorenihDana,0) > 0
			BEGIN
				INSERT INTO [dbo].[RadnikGO]
					([RadID]
					,[DatumOd]
					,[DatumDo]
					,[Zaduzio]
					,[Razduzio]
					,[Napomena])
				 VALUES
					(@id
					,GETDATE()
					,GETDATE()
					,0
					,ISNULL(@nezatvorenihDana,0)
					,N'Automatsko zatvaranje neiskorištenih dana.')
			END
		END

		--OTVORI
		DECLARE @dodatnihDana as int
		SELECT @dodatnihDana = CAST([G]/4 as int)
		FROM [dbo].[vRadnik] WHERE ID = @id

		INSERT INTO [dbo].[RadnikGO]
			([RadID]
			,[DatumOd]
			,[DatumDo]
			,[Zaduzio]
			,[Razduzio]
			,[Napomena])
		VALUES
			(@id
			,GETDATE()
			,GETDATE()
			,@Dana + @dodatnihDana
			,0
			,N'Automatsko dodjeljivanje dana godišnjeg odmora.')
	END
	FETCH NEXT FROM crsRadnik INTO @id
END

CLOSE crsRadnik
DEALLOCATE crsRadnik
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO
