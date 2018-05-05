-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [lisansi_Baslat] 
   ON [dbo].[SeriNumaralari]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @personelId int;
	DECLARE @bitisZamani datetime;
	
	SELECT @personelId=i.atananPersonelId from inserted i;
	SELECT @bitisZamani=i.bitmeZamani from inserted i;
	IF UPDATE(atananPersonelId)
		SET @bitisZamani = (dateadd(year,(1),getdate()))
END
GO
