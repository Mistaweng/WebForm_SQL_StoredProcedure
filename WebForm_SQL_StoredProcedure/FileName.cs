//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WebForm_SQL_StoredProcedure
//{
//	public class FileName
//	{



//		ALTER PROCEDURE sp_InsertRecord
//	@ID_BL INT,
//    @Consignee NVARCHAR(MAX),
//    @Bl_Number NVARCHAR(MAX),
//    @Type_Bl NVARCHAR(MAX)
//AS
//BEGIN

//	BEGIN TRY

//		INSERT INTO FormTable(ID_BL, CONSIGNEE, BL_NUMBER, TYPE_BL)

//		VALUES(@ID_BL, @Consignee, @Bl_Number, @Type_Bl);
//		END TRY

//	BEGIN CATCH
//        -- Handle the exception here
//        -- You can log the error, raise a custom error, or take other actions
//        -- Example: Raising a custom error

//		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
//		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
//		END CATCH
//END



//ALTER PROCEDURE sp_GetRecords
//AS
//BEGIN

//	BEGIN TRY

//		SELECT ID_BL, CONSIGNEE, BL_NUMBER, TYPE_BL

//		FROM FormTable;
//		END TRY

//	BEGIN CATCH
//        -- Handle the exception here
//        -- You can log the error, raise a custom error, or take other actions
//        -- Example: Raising a custom error

//		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
//		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
//		END CATCH
//END



//ALTER PROCEDURE sp_UpdateRecord

//	@ID_Bl INT,
//	@Consignee NVARCHAR(MAX),
//    @Bl_Number NVARCHAR(MAX),
//    @Type_Bl NVARCHAR(MAX)
//AS
//BEGIN

//	BEGIN TRY

//		UPDATE FormTable

//		SET CONSIGNEE = @Consignee, BL_NUMBER = @Bl_Number, TYPE_BL = @Type_Bl

//		WHERE ID_BL = @ID_Bl;
//		END TRY

//	BEGIN CATCH
//        -- Handle the exception here
//        -- You can log the error, raise a custom error, or take other actions
//        -- Example: Raising a custom error

//		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
//		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
//		END CATCH
//END


//ALTER PROCEDURE sp_DeleteRecord

//	@ID_Bl INT
//AS
//BEGIN

//	BEGIN TRY

//		DELETE FROM FormTable
//		WHERE ID_BL = @ID_Bl;
//    END TRY

//	BEGIN CATCH
//        -- Handle the exception here
//        -- You can log the error, raise a custom error, or take other actions
//        -- Example: Raising a custom error

//		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
//		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
//		END CATCH
//END




//	}
//}