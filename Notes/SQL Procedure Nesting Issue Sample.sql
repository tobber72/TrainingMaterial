USE [NGDevl]
GO

/****** Object:  StoredProcedure [dbo].[IHC_Order_InProgress]    Script Date: 7/28/2014 10:00:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sample1]
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE #Sales ([Month] VARCHAR(20) ,SaleAmount INT)

	INSERT INTO #Sales VALUES ('January', 100)
	INSERT INTO #Sales VALUES ('February', 200)
	INSERT INTO #Sales VALUES ('March', 300)

	-- SELECT * FROM #Sales

	SELECT  [January]
		  , [February]
		  , [March]
	FROM    ( SELECT    [Month]
					  , SaleAmount
			  FROM      #Sales
			) p PIVOT ( SUM(SaleAmount)
						FOR [Month] 
						  IN ([January],[February],[March])
					  ) AS pvt

	DROP TABLE #Sales
	
SET NOCOUNT OFF;    
END

GO


CREATE PROCEDURE [dbo].[Sample2]
AS
BEGIN
	SET NOCOUNT ON;



	CREATE TABLE #Sales2 (January VARCHAR(100) , February VARCHAR(100) , March VARCHAR(100))

	INSERT INTO #Sales2 (January, February, March)
	EXEC Sample1

	SELECT * FROM #Sales2

	DROP TABLE #Sales2
	
SET NOCOUNT OFF;    
END

GO

CREATE PROCEDURE [dbo].[Sample3]
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE #Sales3 (January VARCHAR(100) , February VARCHAR(100) , March VARCHAR(100))

	INSERT INTO #Sales3 (January, February, March)
	EXEC Sample2

	SELECT * FROM #Sales3

	DROP TABLE #Sales3
	
SET NOCOUNT OFF;    
END

GO

exec [Sample1]
exec [Sample2]
exec [Sample3]

drop procedure [Sample1]
drop procedure [Sample2]
drop procedure [Sample3]
