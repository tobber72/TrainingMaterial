----------------------------------------------------
-- Create Pivoted Tables in 3 Steps - http://sqlmag.com/t-sql/create-pivoted-tables-3-steps
-- Pivoting the Dynamic Way - http://sqlmag.com/t-sql/pivoting-dynamic-way
----------------------------------------------------

CREATE Table #Temp(FirstName varchar(100), LastName varchar(100), Position varchar(100), Age int, Height varchar(10), Weight int)

INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight ) Values ('Jimmy', 'Butler', 'SG', 24, '6-7', 220)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Mike', 'Dunleavy', 'SF', 33, '6-9', 230)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Pau', 'Gasol', 'PF', 34, '7-0', 250)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Taj', 'Gibson', 'PF', 29, '6-9', 225)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Kirk', 'Hinrich', 'SG', 33, '6-4', 190)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Doug', 'McDermott', 'SF', 22, '6-8', 225)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Nikola', 'Mirotic', 'PF', 23, '6-10', 220)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Joakim', 'Noah', 'C', 29, '6-11', 232)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Derrick', 'Rose', 'G', 25, '6-3', 190)
INSERT INTO #Temp(FirstName , LastName , Position, Age , Height , Weight  ) Values ('Tony', 'Snell', 'SG', 22, '6-7', 200)

--// Table Data
SELECT * FROM #Temp

----------------------------------------------------------------------------------
--// PIVOT BY NAME

DECLARE @SQL as VARCHAR(MAX)
DECLARE @Columns AS VARCHAR(MAX)

SELECT @Columns = 
		COALESCE(@Columns + ', ','') + QUOTENAME(FullName)
FROM
(
	Select distinct FirstName + ' ' + LastName as FullName from #Temp
) AS B
ORDER BY B.FullName


SET @SQL = '
WITH PivotData AS
(
	Select FirstName , LastName , Position , FirstName + '' '' + LastName as FullName, Age 
	from #Temp
)

SELECT 
	Position, 
	' + @Columns + '
FROM PivotData
PIVOT
(
	Count(FullName)
	FOR FullName
	IN (' + @Columns + ')
) AS PivotResult
'

EXEC (@SQL)

--------------------------------------------------------------------------------
--// Pivot on Age and Position
DECLARE @SQL2 as VARCHAR(MAX)
DECLARE @Columns2 AS VARCHAR(MAX)

SELECT @Columns2 = COALESCE(@Columns2 + ', ','') + QUOTENAME(Age)
FROM ( Select distinct Age from #Temp ) AS B
ORDER BY B.Age

SET @SQL2 = '
WITH PivotData AS
(
	Select Position , Age 
	from #Temp
)

SELECT 
	Position, 
	' + @Columns2 + '
FROM PivotData
PIVOT
(
	Count(Age)
	FOR Age
	IN (' + @Columns2 + ')
) AS PivotResult
'

EXEC (@SQL2)
----------------------------------------------------------------------------------

-- Select @SQL

-- Select * from #Temp

-- EXEC (@SQL)

DROP TABLE #Temp
