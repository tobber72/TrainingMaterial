--// https://www.simple-talk.com/blogs/2007/09/14/pivots-with-dynamic-columns-in-sql-server-2005/

CREATE TABLE #Table1 (ColId INT,ColName VARCHAR(10))
INSERT INTO #Table1 VALUES(1, 'Country')
INSERT INTO #Table1 VALUES(2, 'Month')
INSERT INTO #Table1 VALUES(3, 'Day')

CREATE TABLE #Table2 (tID INT,ColID INT,Txt VARCHAR(10))

INSERT INTO #Table2 VALUES (1,1, 'US')
INSERT INTO #Table2 VALUES (1,2, 'July')
INSERT INTO #Table2 VALUES (1,3, '4')
INSERT INTO #Table2 VALUES (2,1, 'US')
INSERT INTO #Table2 VALUES (2,2, 'Sep')
INSERT INTO #Table2 VALUES (2,3, '11')
INSERT INTO #Table2 VALUES (3,1, 'US')
INSERT INTO #Table2 VALUES (3,2, 'Dec')
INSERT INTO #Table2 VALUES (3,3, '25')

----------------------------------------------

SELECT  tID
      , [Country]
      , [Day]
      , [Month]
FROM    ( SELECT    t2.tID
                  , t1.ColName
                  , t2.Txt
          FROM      #Table1 AS t1
                    JOIN #Table2 
                       AS t2 ON t1.ColId = t2.ColID
        ) p PIVOT ( MAX([Txt])
                    FOR ColName IN ( [Country], [Day],
                                     [Month] ) ) AS pvt
ORDER BY tID ;

----------------------------------------------

DECLARE @cols NVARCHAR(2000)
SELECT  @cols = COALESCE(@cols + ',[' + colName + ']',
                         '[' + colName + ']')
FROM    #Table1
ORDER BY colName

-- DECLARE @cols NVARCHAR(2000)
SELECT  @cols = STUFF(( SELECT DISTINCT TOP 100 PERCENT
                                '],[' + t2.ColName
                        FROM    #Table1 AS t2
                        ORDER BY '],[' + t2.ColName
                        FOR XML PATH('')
                      ), 1, 2, '') + ']'

DECLARE @query NVARCHAR(4000)
SET @query = N'SELECT tID, '+
@cols +'
FROM
(SELECT  t2.tID
      , t1.ColName
      , t2.Txt
FROM    #Table1 AS t1
        JOIN #Table2 AS t2 ON t1.ColId = t2.ColID) p
PIVOT
(
MAX([Txt])
FOR ColName IN
( '+
@cols +' )
) AS pvt
ORDER BY tID;'

EXECUTE(@query)

----------------------------------------------

Drop table #Table1
Drop table #Table2