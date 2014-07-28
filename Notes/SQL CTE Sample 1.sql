--// https://www.simple-talk.com/blogs/2007/09/14/pivots-with-dynamic-columns-in-sql-server-2005/

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
