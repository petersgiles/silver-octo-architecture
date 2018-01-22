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


select * from ListAttributeTypes
select * from TopicTypes
select * from Topics
select * from ListAttributes

SELECT * from (
	SELECT tpty.Caption as topic, a.[Caption] as col, la.Value as v
	FROM ListAttributeTypes a
			INNER JOIN ListAttributes la
				ON a.Id = la.ListAttributeTypeId
			INNER JOIN Topics tp
				ON tp.id = la.TopicId
			INNER JOIN TopicTypes tpty
				ON tp.TopicTypeId = tpty.Id
) src
PIVOT (  MAX(v) FOR col in ([Caption], [Description], [DateTime]) )
AS pvt
```
With Dynamic Columns

```SQL

DECLARE @DynamicPivotQuery AS NVARCHAR(MAX)
DECLARE @ColumnName AS NVARCHAR(MAX)
 
--Get distinct values of the PIVOT Column 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME([Caption])
FROM (SELECT DISTINCT [Caption] FROM ListAttributeTypes) AS Cols
 
--Prepare the PIVOT query using the dynamic 
SET @DynamicPivotQuery = 
  N'SELECT * from (
	SELECT tpty.Caption as topic, a.[Caption] as col, la.Value as v
	FROM ListAttributeTypes a
			INNER JOIN ListAttributes la
				ON a.Id = la.ListAttributeTypeId
			INNER JOIN Topics tp
				ON tp.id = la.TopicId
			INNER JOIN TopicTypes tpty
				ON tp.TopicTypeId = tpty.Id
	) src
	PIVOT (  MAX(v) FOR col in (' + @ColumnName + ') )
	AS pvt
	'
--Execute the Dynamic Pivot Query
EXEC sp_executesql @DynamicPivotQuery

```