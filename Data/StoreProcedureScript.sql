USE Neptuno

CREATE PROC USP_InsCategoria
@NombreCategoria VARCHAR(100),
@Descripcion TEXT
AS
BEGIN
DECLARE @IdCategoria INT
SET @IdCategoria = (SELECT MAX(IdCategoria) + 1 FROM Neptuno.dbo.categorias)
INSERT INTO Neptuno.dbo.categorias(idcategoria, nombrecategoria, descripcion)
VALUES (@IdCategoria, @NombreCategoria, @Descripcion)
END

CREATE PROC USP_UpdCategoria
@IdCategoria INT,
@NombreCategoria VARCHAR(100),
@Descripcion TEXT
AS
BEGIN
UPDATE Neptuno.dbo.categorias SET nombrecategoria=@NombreCategoria, descripcion=@Descripcion
WHERE idcategoria=@IdCategoria
END

CREATE PROC USP_DelCategoria
@IdCategoria INT
AS
BEGIN
DELETE FROM Neptuno.dbo.categorias WHERE idcategoria=@IdCategoria
END

CREATE PROC USP_GetCategoria02
@IdCategoria INT=0
AS
BEGIN
SELECT idcategoria, nombrecategoria, descripcion
FROM Neptuno.dbo.categorias
WHERE idcategoria=@IdCategoria or @IdCategoria=0
END
