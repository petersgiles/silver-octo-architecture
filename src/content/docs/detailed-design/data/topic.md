# User Defined Topics

## ER Diagram

```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/typescript.iuml

hide methods
hide stereotypes

title ERD : Topic

' entities

Table(topic_owner, "topic_owner") {
    primary_key(id)  number
}

Table(topic, "topic") {
    primary_key(id)  number
    not_null(caption) string
    not_null(type_of_topic)  number
}

Table(type_of_topic, "type_of_topic") {
    primary_key(id)  number
    not_null(caption) string
    not_null(details) string
    
}

Table(attribute, "attribute") {
    unique(topic)  number
    unique(type_of_attribute)  number
    Value NVARCHAR[666]
    Text NVARCHAR[MAX]
    not_null(active)  number
    not_null(lastupdated) UTCDATETIME    
}

Table(type_of_attribute, "type_of_attribute") {
    primary_key(id)  number
    not_null(caption) string
    not_null(details) string
}

Table(display_hint, "display_hint") {
    primary_key(id)  number
    not_null(caption) string
    not_null(format) string
}


Table(relationship, "relationship") {
    primary_key(id)  number
    not_null(relationship_to_topic_1)  number
    not_null(relationship_to_topic_2)  number
    not_null(type_of_relationship)  number
    not_null(caption) string
}


Table(type_of_relationship, "type_of_relationship") {
    primary_key(id)  number
    not_null(caption) string
    not_null(details) string
}

' relationships

topic "*".."1" type_of_topic : "Is a"
attribute "*".."1" type_of_attribute :  "Is a"
type_of_attribute "1".."*" display_hint : "Has"

topic "1".."*" attribute : "Has many"
relationship "*".."1" type_of_relationship :  "Is a"

relationship "1" .. "1" topic :  "Relationship 1"
relationship "1" .. "1" topic :  "Relationship 2"

topic_owner "1".."*" type_of_topic : "Owns"
topic_owner "1".."*" type_of_relationship : "Owns"
topic_owner "1".."*" type_of_attribute : "Owns"
topic_owner "1".."*" display_hint : "Owns"

@enduml
```

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