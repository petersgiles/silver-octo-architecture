
## How to query data

```SQL 

DELETE [TopicTypes]
DELETE [ListAttributeTypes]
DELETE [ListAttributes]
DELETE [Topics]
DELETE [Users]

DBCC CHECKIDENT ('TopicTypes', RESEED, 0)
DBCC CHECKIDENT ('ListAttributeTypes', RESEED, 0)
DBCC CHECKIDENT ('ListAttributes', RESEED, 0)
DBCC CHECKIDENT ('Topics', RESEED, 0)
DBCC CHECKIDENT ('Users', RESEED, 0)

INSERT INTO [dbo].[Users] ([Description])
 /* */ SELECT 'Pete'
 UNION SELECT 'Greg'

SELECT * from [Users]


INSERT INTO [ListAttributeTypes]([Caption],[UserId])
 /* */ SELECT 'Description', 1
 UNION SELECT 'DateTime', 1

SELECT * from [ListAttributeTypes]


INSERT INTO [TopicTypes] ([Caption], [UserId])
  /* */ SELECT 'Cheese', 1
  UNION SELECT 'Animal', 1

SELECT * from [TopicTypes]



INSERT INTO [Topics] ([TopicTypeId], [Caption]) Values (1, 'Cheddar') -- for Cheddar
INSERT INTO [Topics] ([TopicTypeId], [Caption]) Values (1, 'Gouda')
INSERT INTO [Topics] ([TopicTypeId], [Caption]) Values (2, 'Persian')
INSERT INTO [Topics] ([TopicTypeId], [Caption]) Values (2, 'Pomerainian')
INSERT INTO [Topics] ([TopicTypeId], [Caption]) Values (2, 'Dumbo')

SELECT * from [Topics]


INSERT INTO [ListAttributes]([Active],[LastUpdated] ,[TopicId], [ListAttributeTypeId] ,[Value])
 /* */ SELECT 1, GETDATE(), 1, 1, 'A Tasty Cheese'
 UNION SELECT 1, GETDATE(), 1, 2, convert(varchar(10),getdate(),103)
 /* */
 UNION SELECT 1, GETDATE(), 2, 1, 'A Waxy Cheese'
 UNION SELECT 1, GETDATE(), 2, 2, convert(varchar(10),getdate(),103)
  /* */
 UNION SELECT 1, GETDATE(), 3, 1, 'A Meowy thing'
 UNION SELECT 1, GETDATE(), 3, 2, convert(varchar(10),getdate(),103)
  /* */
 UNION SELECT 1, GETDATE(), 4, 1, 'A Woofy thing'
 UNION SELECT 1, GETDATE(), 4, 2, convert(varchar(10),getdate(),103)
  /* */
 UNION SELECT 1, GETDATE(), 5, 1, 'A Heavy Thing'
 UNION SELECT 1, GETDATE(), 5, 2, convert(varchar(10),getdate(),103)


SELECT * from [ListAttributes]

-- Regular Pivot with Named Columns
SELECT * from (
    SELECT la.TopicId as topic, a.[Caption] as col, la.Value as v
    FROM ListAttributeTypes a
            INNER JOIN ListAttributes la
                ON a.Id = la.ListAttributeTypeId
            INNER JOIN Topics tp
                ON tp.Id = la.TopicId
            INNER JOIN TopicTypes tpty
                ON tp.TopicTypeId = tpty.Id
                AND tp.TopicTypeId = 2

) src
PIVOT (  MAX(v) FOR col in ([Description], [DateTime]) )
AS pvt
INNER JOIN Topics topics
	ON topics.Id = pvt.topic


-- Dynamic Pivot with Columns Derived
DECLARE @DynamicPivotQuery AS NVARCHAR(MAX)
DECLARE @ColumnName AS NVARCHAR(MAX)

--Get distinct values of the PIVOT Column 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME([Caption])
FROM (SELECT DISTINCT [Caption] FROM ListAttributeTypes) AS Cols

--Prepare the PIVOT query using the dynamic 
SET @DynamicPivotQuery = 
  N'SELECT * from (
    SELECT la.TopicId as topic, a.[Caption] as col, la.Value as v
    FROM ListAttributeTypes a
            INNER JOIN ListAttributes la
                ON a.Id = la.ListAttributeTypeId
            INNER JOIN Topics tp
                ON tp.id = la.TopicId
            INNER JOIN TopicTypes tpty
                ON tp.TopicTypeId = tpty.Id
                AND tp.TopicTypeId = 1
    ) src
    PIVOT (  MAX(v) FOR col in (' + @ColumnName + ') )
    AS pvt
    '
--Execute the Dynamic Pivot Query
EXEC sp_executesql @DynamicPivotQuery


```