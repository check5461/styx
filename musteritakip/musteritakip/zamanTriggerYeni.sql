USE [musteritakip]
GO
/****** Object:  Trigger [dbo].[lisansi_Baslat]    Script Date: 04/15/2018 22:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[lisansi_Baslat] 
   ON [dbo].[SeriNumaralari]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @personelId int;
	DECLARE @seriNumarasi int;
	
	SELECT @seriNumarasi = i.seriNo from inserted i;
	SELECT @personelId=i.atananPersonelId from inserted i;
	IF UPDATE(atananPersonelId)
		UPDATE SeriNumaralari SET bitmeZamani = dateadd(year,(1),getdate()) WHERE seriNo=@seriNumarasi;

END
