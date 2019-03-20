# SQL

How to do access and deny with SQL data

## Example data structure

```SQL

USE [AccessTest]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [UserGroups]
DROP TABLE [Groups]
DROP TABLE [Users]
DROP TABLE [Container]
DROP TABLE [AccessControl]
GO


CREATE TABLE [dbo].[Users]
(
	[Id] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,

	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Groups]
(
	[Id] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,

	CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AccessControl]
(
	[GroupId] [int] NOT NULL,
	[ContainerId] [int] NOT NULL,
	[Control] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[UserGroups]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL

		CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Container]
(
	[Id] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](40) NOT NULL,

	CONSTRAINT [PK_Container] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

DELETE UserGroups
DELETE Groups
DELETE Users
DELETE AccessControl

DBCC CHECKIDENT ('UserGroups', RESEED, 0)

INSERT INTO [dbo].[Groups]
	([Id], [Name])
/* */
	SELECT 1, 'Admin'
UNION
	SELECT 2, 'A Members'
UNION
	SELECT 3, 'B Members'
UNION
	SELECT 4, 'C Members'


INSERT INTO [dbo].[Users]
	([Id], [Name])
/* */
	SELECT 1, 'Pete'
UNION
	SELECT 2, 'Greg'
UNION
	SELECT 3, 'Simon'
UNION
	SELECT 4, 'Dave'
UNION
	SELECT 5, 'Valdis'
UNION
	SELECT 6, 'Tim'
UNION
	SELECT 7, 'Katie'
UNION
	SELECT 8, 'Torilee'
UNION
	SELECT 9, 'Nick'

INSERT INTO [dbo].[UserGroups]
	([UserId], [GroupId])
/* */
	SELECT 1, 1
UNION
	SELECT 2, 2
UNION
	SELECT 3, 3
UNION
	SELECT 4, 4
UNION
	SELECT 5, 3
UNION
	SELECT 6, 2
UNION
	SELECT 7, 1
UNION
	SELECT 8, 1
UNION
	SELECT 9, 4

INSERT INTO [dbo].[Container]
	([Id], [ParentId], [Name])
/* */
	SELECT 1, NULL, 'A'
UNION
	SELECT 2, 1, 'AA'
UNION
	SELECT 3, 1, 'AB'
UNION
	SELECT 4, 3, 'ABA'
UNION
	SELECT 5, 4, 'ABAA'
UNION
	SELECT 6, NULL, 'B'
UNION
	SELECT 7, 6, 'BA'
UNION
	SELECT 8, 6, 'BB'
UNION
	SELECT 9, 8, 'BBA'
UNION
	SELECT 10, 8, 'BBB'
UNION
	SELECT 11, 8, 'BBC'
UNION
	SELECT 12, 10, 'BBBA'
UNION
	SELECT 13, 10, 'BBBB'
UNION
	SELECT 14, NULL, 'C'
UNION
	SELECT 15, 14, 'CA'
UNION
	SELECT 16, 14, 'CB'
UNION
	SELECT 17, 15, 'CAA'
UNION
	SELECT 18, 16, 'CBA'
UNION
	SELECT 19, 16, 'CBB'
UNION
	SELECT 20, 19, 'CBBA'

INSERT INTO [dbo].[AccessControl]
	([GroupId], [ContainerId], [Control])
/* */
	SELECT 1, 1, 1
UNION
	SELECT 1, 6, 1
UNION
	SELECT 1, 14, 1
UNION
	SELECT 3, 6, 1
-- UNION SELECT 2, 8, 0


/*
SELECT * FROM [Users]
SELECT * FROM [Groups]
SELECT * FROM [UserGroups]
SELECT * FROM [Container]
SELECT * FROM [AccessControl]
*/
```

## Getting a tree of children

Using Container Id a set of child containers can be derived with this SQL Code

```SQL

DECLARE @container int;
SET @container = 13;

;WITH
	FullTree_CTE
	AS
	(
		SELECT Id, ParentId, [Name]
			FROM Container
			-- WHERE ParentId IS NULL
			WHERE ParentId = @container
		UNION ALL
			SELECT cc.Id, cc.ParentId, cc.[Name]
			FROM Container cc
				INNER JOIN FullTree_CTE ftcte ON ftcte.ID = cc.ParentId
	)
SELECT *
FROM FullTree_CTE cte
WHERE cte.Id = @container

```

## Getting a tree of parents

Using Container Id a set of parent containers can be derived with this SQL Code

```SQL 

DECLARE @container int;
SET @container = 13;

;WITH
	AncestorFullTree_CTE
	AS
	(
		SELECT Id, ParentId, [Name]
			FROM Container
			WHERE Id = @container
		UNION ALL
			SELECT cc.Id, cc.ParentId, cc.[Name]
			FROM Container cc
				INNER JOIN AncestorFullTree_CTE ftcte ON ftcte.ParentId = cc.Id
	)
--SELECT * FROM AncestorFullTree_CTE

SELECT *
FROM [UserGroups] ug
	INNER JOIN [Users] u
	ON ug.UserId = u.Id
	INNER JOIN Groups g
	ON ug.GroupId = g.Id
	INNER JOIN AccessControl ac
	ON ac.GroupId = g.Id
		AND ac.ContainerId in (SELECT Id
		FROM AncestorFullTree_CTE cte)

```
## Getting keys by user

Using a user name a set of child allowed containers can be derived with this SQL Code


```SQL

DECLARE @user varchar(30);
SET @user = 'Simon';


;WITH
	UserAccess_CTE
	AS
	
	(
		SELECT ac.[ContainerId], ac.[Control]
		FROM [UserGroups] ug
			INNER JOIN [Users] u
			ON ug.UserId = u.Id
				AND u.[Name] Like @user
			INNER JOIN Groups g
			ON ug.GroupId = g.Id
			INNER JOIN AccessControl ac
			ON ac.GroupId = g.Id
	),
	Allow_CTE
	AS
	(
		SELECT Id, ParentId, [Name]
			FROM Container
			WHERE Id IN (SELECT ContainerId
			from UserAccess_CTE
			where [Control] = 1)
			-- WHERE ParentId IS NULL
		UNION ALL
			SELECT cc.Id, cc.ParentId, cc.[Name]
			FROM Container cc
				INNER JOIN Allow_CTE acte ON acte.ID = cc.ParentId
	)
,
	Deny_CTE
	AS
	(
		SELECT Id, ParentId, [Name]
			FROM Container
			WHERE Id IN (SELECT ContainerId
			from UserAccess_CTE
			where [Control] = 0)
			-- WHERE ParentId IS NULL
		UNION ALL
			SELECT cc.Id, cc.ParentId, cc.[Name]
			FROM Container cc
				INNER JOIN Deny_CTE dcte ON dcte.ID = cc.ParentId
	)
SELECT *
FROM Allow_CTE
WHERE Id NOT IN (SELECT Id
from Deny_CTE)

GO

```