CREATE PROCEDURE [dbo].[GetOkladas]
	@ListicId BIGINT
AS
BEGIN
	SELECT Oklada.OkladaId, Oklada.Koeficient, Oklada.ListicId, Oklada.PonudaId,
	Susret.Domacin + ' - ' + Susret.Gost + ' (Tip : ' + Ponuda.Tip + ')' [Name]
	FROM Oklada
	INNER JOIN Ponuda ON Oklada.PonudaId = Ponuda.PonudaId
	INNER JOIN Susret ON Ponuda.SusretId = Susret.SusretId
	WHERE Oklada.ListicId = @ListicId
END
