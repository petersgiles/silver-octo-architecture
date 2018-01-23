# User Defined Topics

## ER Diagram

![diagram](topic.svg)

[PNG](topic.png) | [SVG](topic.svg)

## Definition

Very often adhoc information stores to be added to a DataStore

This design allows for diverse data needs


## How to enter data

- Add a 'type of topic'
- Add a 'type of attribute' for each attribute a topic has
- If the topic has relationships Add a 'type of relationship'
    - it could describe a relationship to another topic
    - it could be a parent child relationship for a single topic
    - it could describe a relationship to an item in another system
- Assign a User (subject matter expert) to each of these types 
    - someone who can explain why the topic, attribute or relationship needs to exist
    - reason could also be captured as a topic with attributes & relationship etc.
- Enter data into the Topic, Attribute & Relationship tables

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
 /* */ SELECT 'Caption', 1
 UNION SELECT 'Description', 1
 UNION SELECT 'DateTime', 1
 
SELECT * from [ListAttributeTypes]


INSERT INTO [TopicTypes] ([Caption], [UserId])
  /* */ SELECT 'Cheese', 1
  UNION SELECT 'Animal', 1
  
SELECT * from [TopicTypes]



INSERT INTO [Topics] ([TopicTypeId]) Values (1) -- for Cheddar
INSERT INTO [Topics] ([TopicTypeId]) Values (1) -- for Gouda
INSERT INTO [Topics] ([TopicTypeId]) Values (2) -- for Persian
INSERT INTO [Topics] ([TopicTypeId]) Values (2) -- for Pomerainian
INSERT INTO [Topics] ([TopicTypeId]) Values (2) -- for Dumbo

SELECT * from [Topics]


INSERT INTO [ListAttributes]([Active],[LastUpdated] ,[TopicId], [ListAttributeTypeId] ,[Value])
 /* */ SELECT 1, GETDATE(), 1, 1, 'Cheddar'
 UNION SELECT 1, GETDATE(), 1, 2, 'A Tasty Cheese'
 UNION SELECT 1, GETDATE(), 1, 3, convert(varchar(10),getdate(),103)
 /* */
 UNION SELECT 1, GETDATE(), 2, 1, 'Gouda'
 UNION SELECT 1, GETDATE(), 2, 2, 'A Waxy Cheese'
 UNION SELECT 1, GETDATE(), 2, 3, convert(varchar(10),getdate(),103)
  /* */
 UNION SELECT 1, GETDATE(), 3, 1, 'Persian'
 UNION SELECT 1, GETDATE(), 3, 2, 'A Meowy thing'
 UNION SELECT 1, GETDATE(), 3, 3, convert(varchar(10),getdate(),103)
  /* */
 UNION SELECT 1, GETDATE(), 4, 1, 'Pomerainian'
 UNION SELECT 1, GETDATE(), 4, 2, 'A Woofy thing'
 UNION SELECT 1, GETDATE(), 4, 3, convert(varchar(10),getdate(),103)
  /* */
 UNION SELECT 1, GETDATE(), 5, 1, 'Dumbo'
 UNION SELECT 1, GETDATE(), 5, 2, 'A Heavy Thing'
 UNION SELECT 1, GETDATE(), 5, 3, convert(varchar(10),getdate(),103)


 DECLARE @TopicTypeId AS int
  SET @TopicTypeId  = 2

SELECT * from [ListAttributes]

-- Regular Pivot with Named Columns
SELECT * from (
	SELECT la.TopicId as topic, a.[Caption] as col, la.Value as v
	FROM ListAttributeTypes a
			INNER JOIN ListAttributes la
				ON a.Id = la.ListAttributeTypeId
			INNER JOIN Topics tp
				ON tp.TopicTypeId = @TopicTypeId

) src
PIVOT (  MAX(v) FOR col in ([Caption], [Description], [DateTime]) )
AS pvt

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
				ON tp.TopicTypeId = ' + convert(varchar(2), @TopicTypeId)  + '
	) src
	PIVOT (  MAX(v) FOR col in (' + @ColumnName + ') )
	AS pvt
	'
--Execute the Dynamic Pivot Query
EXEC sp_executesql @DynamicPivotQuery



```