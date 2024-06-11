CREATE PROC DeletedProductCount
AS
SELECT COUNT(*) FROM BASE.BaseProducts WHERE IsDeleted = 1
GO