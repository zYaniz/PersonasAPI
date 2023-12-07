//using Microsoft.AspNetCore.Http.HttpResults;
//using System.Runtime.Intrinsics.X86;

//CREATE DATABASE Personas;
//USE Personas;

//CREATE TABLE Personas(
//	Id INT PRIMARY KEY IDENTITY(1,1),
//    Nombre VARCHAR(50),
//    Apellido VARCHAR(50),
//    Cedula VARCHAR(12)
//)

//CREATE PROCEDURE InsertarPersona
//	@Nombre VARCHAR(50),
//    @Apellido VARCHAR(50),
//    @Cedula VARCHAR(12)
//AS
//BEGIN
//	INSERT INTO Personas(Nombre, Apellido, Cedula)
//	VALUES (@Nombre, @Apellido, @Cedula);
//END;

//EXEC InsertarPersona 'Yani', 'Solano','12345678'
//EXEC InsertarPersona 'Alex', 'Leiva','321'
//EXEC InsertarPersona 'María', 'Veneira','512'
//EXEC InsertarPersona 'Marco', 'Gutierrez','123'


//CREATE PROCEDURE ObtenerInformacionPorCedula
//	@Cedula VARCHAR(12)
//AS
//BEGIN
//	IF EXISTS (SELECT*FROM Personas WHERE Cedula = @Cedula)
//	BEGIN
//		SELECT Id, Nombre, Apellido, Cedula
//		FROM Personas
//		WHERE Cedula = @Cedula;
//END
//ELSE
//	BEGIN
//		SELECT 'No se encontró información para la cédula '+@Cedula AS Mensaje
//	END
//END;

//EXEC ObtenerInformacionPorCedula '12345678'

//CREATE PROCEDURE ActualizarInformacionPersona
//	@CedulaAnterior VARCHAR(12),
//    @NuevoNombre VARCHAR(50),
//    @NuevoApellido VARCHAR(50),
//    @NuevaCedula VARCHAR(12)
//AS
//BEGIN
//	IF EXISTS (SELECT*FROM Personas WHERE Cedula = @CedulaAnterior)
//	BEGIN
//		UPDATE Personas
//		SET 
//			Nombre = @NuevoNombre,
//            Apellido = @NuevoApellido,
//            Cedula = @NuevaCedula
//		WHERE Cedula = @CedulaAnterior;

//SELECT 'Información actualizada correctamente. ' AS Mensaje;
//END
//ELSE
//	BEGIN
//		SELECT 'No se encontró información para la cédula. '  +@CedulaAnterior AS Mensaje;
//END
//END;

//EXEC ActualizarInformacionPersona '123','Marcelo','Valverde','223'

//CREATE PROCEDURE EliminarInformacionPorCedula
//	@Cedula VARCHAR(12)
//AS
//BEGIN
//	IF EXISTS (SELECT*FROM Personas WHERE Cedula = @Cedula)
//	BEGIN
//		DELETE FROM Personas WHERE Cedula = @Cedula;
//END
//ELSE
//	BEGIN
//		SELECT 'No se encontró información para la cédula '+@Cedula AS Mensaje
//	END
//END;

//EXEC EliminarInformacionPorCedula '223'