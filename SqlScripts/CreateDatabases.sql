USE [master]

IF EXISTS (SELECT * FROM sysdatabases WHERE name='ProjectTemplate') 
BEGIN 
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'ProjectTemplate'
	ALTER DATABASE [ProjectTemplate] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [ProjectTemplate]
END
GO

CREATE DATABASE [ProjectTemplate] 
GO

USE [ProjectTemplate]

IF EXISTS(SELECT name FROM [master].[dbo].syslogins WHERE name = 'intranetuser')
BEGIN
	ALTER LOGIN [intranetuser] ENABLE
END
GO

IF NOT EXISTS (SELECT * FROM sys.sysusers WHERE name = N'intranetuser')
BEGIN
	CREATE USER [intranetuser] FOR LOGIN [intranetuser] WITH DEFAULT_SCHEMA=[dbo]	
END
GO

IF DATABASE_PRINCIPAL_ID('AllowSelectInsertUpdate') IS NULL
BEGIN
	CREATE ROLE [AllowSelectInsertUpdate] 	
END
EXEC sp_addrolemember 'AllowSelectInsertUpdate', 'intranetuser'
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Role')
BEGIN
	CREATE TABLE [dbo].[Role](
		[Id] [uniqueidentifier] NOT NULL,
		[RoleName] [nvarchar](20) NULL,
		[Description] [nvarchar](50) NULL,
		[CreatedBy] [uniqueidentifier] NOT NULL,
		[CreatedOn] [datetime] NOT NULL,
		[LastModifiedBy] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	GRANT SELECT, INSERT, UPDATE ON [Role] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [Role] ([Id], [RoleName], [Description], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('80fc2a10-d07e-4e06-9b91-4ba936e335ba', 'User', 'Standard User', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Role] ([Id], [RoleName], [Description], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('8dc59a62-a077-41cc-bac7-f8be505ae4a8', 'Admin', 'Admin User', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Permission')
BEGIN
	CREATE TABLE [dbo].[Permission](
		[Id] [uniqueidentifier] NOT NULL,
		[Description] [nvarchar](50) NULL,
		[CreatedBy] [uniqueidentifier] NOT NULL,
		[CreatedOn] [datetime] NOT NULL,
		[LastModifiedBy] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Permission] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()
	
	INSERT INTO [Permission] ([Id], [Description], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('f76e6b28-993f-410b-82b1-d1ce2baf34a6', 'Complete another user''s task', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'PermissionRole')
BEGIN
	CREATE TABLE [dbo].[PermissionRole](
		[Id] [uniqueidentifier] NOT NULL,
		[PermissionId] [uniqueidentifier] NULL,
		[RoleId] [uniqueidentifier] NULL,
		[CreatedBy] [uniqueidentifier] NOT NULL,
		[CreatedOn] [datetime] NOT NULL,
		[LastModifiedBy] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_PermissionRole] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [PermissionRole] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [PermissionRole] ([Id], [PermissionId], [RoleId], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('8dc59a62-a077-41cc-bac7-f8be505ae4a8', 'f76e6b28-993f-410b-82b1-d1ce2baf34a6', '80fc2a10-d07e-4e06-9b91-4ba936e335ba', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'User')
BEGIN
	CREATE TABLE [dbo].[User](
		[Id] [uniqueidentifier] NOT NULL,
		[Username] [nvarchar](50) NULL,
		[RoleId] [uniqueidentifier] NOT NULL,
		[CreatedBy] [uniqueidentifier] NOT NULL,
		[CreatedOn] [datetime] NOT NULL,
		[LastModifiedBy] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [User] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [User] ([Id], [Username], [RoleId], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('188403fb-3c5e-45a3-aa39-5908e86ea372', 'Sql Initialise', '80fc2a10-d07e-4e06-9b91-4ba936e335ba', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [User] ([Id], [Username], [RoleId], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('c8238876-47fc-42af-8a32-926061097f1c', 'Application', '80fc2a10-d07e-4e06-9b91-4ba936e335ba', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [User] ([Id], [Username], [RoleId], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('3b50e7c8-c6ce-4446-9d51-6cc7a7877343', 'A. User', '80fc2a10-d07e-4e06-9b91-4ba936e335ba', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'TaskType')
BEGIN
CREATE TABLE [dbo].[TaskType](
		[Id] [uniqueidentifier] NOT NULL,
		[Description] [nvarchar](1000) NULL,
		[ServiceLevelAgreementMinutes] [int] NOT NULL,
		[WarningWindowMinutes] [int] NOT NULL,
		[CreatedBy] [uniqueidentifier] NOT NULL,
		[CreatedOn] [datetime] NOT NULL,
		[LastModifiedBy] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_TaskType] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [TaskType] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [TaskType] ([Id], [Description], [ServiceLevelAgreementMinutes], [WarningWindowMinutes], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('911762e0-31ba-4c6c-83f8-3f2288904975', 'Standard Task', 120, 20, '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [TaskType] ([Id], [Description], [ServiceLevelAgreementMinutes], [WarningWindowMinutes], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('a50c62cd-b24a-4d0a-aada-9744fce7022c', 'Urgent Task', 60, 10, '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Task')
BEGIN
CREATE TABLE [dbo].[Task](
		[Id] [uniqueidentifier] NOT NULL,
		[Description] [nvarchar](1000) NULL,
		[AssignedToId] [uniqueidentifier] NOT NULL,
		[TypeId] [uniqueidentifier] NOT NULL,
		[DueDate] [datetime] NULL,
		[Status] [int] NULL,
		[CompletedOn] [datetime] NULL,
		[CompletedMessage] [datetime] NULL,
		[CreatedBy] [uniqueidentifier] NOT NULL,
		[CreatedOn] [datetime] NOT NULL,
		[LastModifiedBy] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Task] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()
	DECLARE @standardDueDate AS DATETIME
	SET @standardDueDate = DATEADD(n, 120, @now)
	DECLARE @urgentDueDate AS DATETIME
	SET @urgentDueDate = DATEADD(n, 60, @now)

	INSERT INTO [Task] ([Id], [Description], [AssignedToId], [TypeId], [DueDate], [Status], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('aa33673b-0904-49ee-b2e9-9117dbf0d82f', 'Task 1', '3b50e7c8-c6ce-4446-9d51-6cc7a7877343', '911762e0-31ba-4c6c-83f8-3f2288904975', @standardDueDate, 1, '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Task] ([Id], [Description], [AssignedToId], [TypeId], [DueDate], [Status], [CreatedBy], [CreatedOn], [LastModifiedBy], [LastModifiedOn], [Deleted]) VALUES ('2d492097-0121-4722-8fde-19c7bff79c67', 'Task 2', '3b50e7c8-c6ce-4446-9d51-6cc7a7877343', 'a50c62cd-b24a-4d0a-aada-9744fce7022c', @urgentDueDate, 1, '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Log')
BEGIN
	CREATE TABLE [dbo].[Log] (
		[Id] [bigint] IDENTITY (1, 1) NOT NULL,
		[Date] [datetime] NOT NULL,
		[Thread] [varchar] (255) NOT NULL,
		[Level] [varchar] (50) NOT NULL,
		[Logger] [varchar] (255) NOT NULL,
		[Message] [varchar] (max) NOT NULL,
		[Exception] [varchar] (max) NULL
	)

	GRANT SELECT, INSERT, UPDATE ON [Log] TO [AllowSelectInsertUpdate]
END

--IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
--	WHERE TABLE_NAME = 'LogEvent')
--BEGIN
--	CREATE TABLE [dbo].[LogEvent](
--		[LogEventId] [bigint] IDENTITY(1,1) NOT NULL,
--		[Date] [datetime] NOT NULL,
--		[Level] [int] NOT NULL,
--		[Message] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
--		[User] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
--		[Exception] [text] COLLATE Latin1_General_CI_AS NULL,
--		[Objects] [xml] NULL,
--		[ExecutingMachine] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
--		[CallingAssembly] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
--		[CallingClass] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
--		[CallingMethod] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
--		[ContextGuid] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
--	 CONSTRAINT [PK_SyncLogEvent] PRIMARY KEY CLUSTERED 
--	(
--		[LogEventId] ASC
--	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
--	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--END 
--GO