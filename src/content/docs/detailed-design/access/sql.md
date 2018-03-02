# SQ

## how to do access and deny


```SQL


USE [Cheese]
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


CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,

 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Groups](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,

 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AccessControl](
	[GroupId] [int] NOT NULL,
	[ContainerId] [int] NOT NULL,
	[Control] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[UserGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL

 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Container](
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

INSERT INTO [dbo].[Groups] ([Id], [Name])
 /* */ SELECT 1, 'Admin'
 UNION SELECT 2, 'Owner'
 UNION SELECT 3, 'Reader'


INSERT INTO [dbo].[Users] ([Id], [Name])
 /* */ SELECT 1, 'Pete'
 UNION SELECT 2, 'Greg'
 UNION SELECT 3, 'Simon'
 UNION SELECT 4, 'Dave'
 UNION SELECT 5, 'Valdis'
 UNION SELECT 6, 'Tim'

 INSERT INTO [dbo].[UserGroups] ([UserId], [GroupId])
 /* */ SELECT 1, 1
 UNION SELECT 2, 2
 UNION SELECT 3, 3


 INSERT INTO [dbo].[Container] ([Id], [ParentId], [Name])
 /* */ SELECT 1, NULL, 'A'
 UNION SELECT 2, 1, 'AA'
 UNION SELECT 3, 1, 'AB'
 UNION SELECT 4, 3, 'ABA'
 UNION SELECT 5, 4, 'ABAA'
 UNION SELECT 6, NULL, 'B'
 UNION SELECT 7, 6, 'BA'
 UNION SELECT 8, 6, 'BB'
 UNION SELECT 9, 8, 'BBA'
 UNION SELECT 10, 8, 'BBB'
 UNION SELECT 11, NULL, 'C'
 UNION SELECT 12, 11, 'CA'


 INSERT INTO [dbo].[AccessControl] ([GroupId], [ContainerId], [Control])
 /* */ SELECT 1, 1, 1
 UNION SELECT 1, 6, 1
 UNION SELECT 1, 8, 0
  UNION SELECT 1, 11, 1



 /*
SELECT * from [Users]
SELECT * from [Groups]
SELECT * from [UserGroups]
SELECT * from [Container]
*/
;WITH Container_CTE AS (
SELECT Id, ParentId, [Name]
FROM Container
WHERE Id IN (SELECT ContainerId from AccessControl where [Control] = 1)
-- WHERE ParentId IS NULL
UNION ALL
SELECT cc.Id, cc.ParentId, cc.[Name]
FROM Container cc
INNER JOIN Container_CTE ccte ON ccte.ID = cc.ParentId
)
, DenyContainer_CTE AS (
SELECT Id, ParentId, [Name]
FROM Container
WHERE Id IN (SELECT ContainerId from AccessControl where [Control] = 0)
-- WHERE ParentId IS NULL
UNION ALL
SELECT cc.Id, cc.ParentId, cc.[Name]
FROM Container cc
INNER JOIN DenyContainer_CTE ccte ON ccte.ID = cc.ParentId
)
SELECT *
FROM Container_CTE 
WHERE Id NOT IN (SELECT Id from DenyContainer_CTE)

GO

```