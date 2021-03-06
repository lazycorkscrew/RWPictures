USE [master]
GO
/****** Object:  Database [RewritePictures]    Script Date: 09.03.2020 21:13:11 ******/
CREATE DATABASE [RewritePictures] ON  PRIMARY 
( NAME = N'RewritePictures', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\RewritePictures.mdf' , SIZE = 25600KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RewritePictures_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\RewritePictures_log.ldf' , SIZE = 15040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RewritePictures] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RewritePictures].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RewritePictures] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RewritePictures] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RewritePictures] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RewritePictures] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RewritePictures] SET ARITHABORT OFF 
GO
ALTER DATABASE [RewritePictures] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RewritePictures] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RewritePictures] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RewritePictures] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RewritePictures] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RewritePictures] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RewritePictures] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RewritePictures] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RewritePictures] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RewritePictures] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RewritePictures] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RewritePictures] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RewritePictures] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RewritePictures] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RewritePictures] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RewritePictures] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RewritePictures] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RewritePictures] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RewritePictures] SET  MULTI_USER 
GO
ALTER DATABASE [RewritePictures] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RewritePictures] SET DB_CHAINING OFF 
GO
USE [RewritePictures]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Project] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](200) NULL,
	[who_filled] [int] NULL,
	[Status] [nvarchar](20) NULL,
	[Pattern] [nvarchar](50) NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fields]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[image_id] [int] NOT NULL,
	[field_name] [nvarchar](20) NOT NULL,
	[field_value] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
	[user_id] [int] NULL,
	[checker_id] [int] NULL,
	[doc_id] [int] NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patterns]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patterns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatternName] [nvarchar](50) NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Patterns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rights]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Power] [int] NOT NULL CONSTRAINT [DF_Rights_Value]  DEFAULT ((0)),
 CONSTRAINT [PK_Rights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[Fname] [nvarchar](50) NOT NULL,
	[Lname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Description] [nvarchar](2000) NULL,
	[Rights] [int] NULL CONSTRAINT [DF_Users_Rights]  DEFAULT ((1)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users]    Script Date: 09.03.2020 21:13:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_Status]  DEFAULT (N'created') FOR [Status]
GO
ALTER TABLE [dbo].[Images] ADD  CONSTRAINT [DF_Images_Status]  DEFAULT (N'Не в работе') FOR [Status]
GO
ALTER TABLE [dbo].[Fields]  WITH CHECK ADD  CONSTRAINT [FK_Fields_Images] FOREIGN KEY([image_id])
REFERENCES [dbo].[Images] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fields] CHECK CONSTRAINT [FK_Fields_Images]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Documents] FOREIGN KEY([doc_id])
REFERENCES [dbo].[Documents] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Documents]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Rights1] FOREIGN KEY([Rights])
REFERENCES [dbo].[Rights] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Rights1]
GO
/****** Object:  StoredProcedure [dbo].[AddFieldToPattern]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[AddFieldToPattern]
@pattern_name varchar(50),
@field_name varchar(50)

AS
BEGIN
	
	insert into Patterns (PatternName, FieldName) values (@pattern_name, @field_name)

END






GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[AddUser]
@login nvarchar(50),
@password nvarchar(50),
@fname nvarchar(50),
@lname nvarchar(50),
@patronymic nvarchar(50)


AS
BEGIN
	
	insert into Users (login, password, Fname, Lname, Patronymic) values (@login, @password, @fname, @lname, @patronymic)

END







GO
/****** Object:  StoredProcedure [dbo].[ApplyImageToPattern]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ApplyImageToPattern]
@image_id int,
@pattern nvarchar(50)

AS
BEGIN
	
	
  

  if (select count(*) from Fields f inner join Images i on f.image_id = i.Id where i.Id = 4) = 0
  insert into Fields (image_id, field_name, field_value) select @image_id, FieldName, null from Patterns where PatternName = @pattern

END


GO
/****** Object:  StoredProcedure [dbo].[AttachFieldToDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[AttachFieldToDocument]
@doc_id int,
@field_name varchar(20)

AS
BEGIN
	
	if (select top(1) count(*) from Documents where Id = @doc_id) > 0 
		insert into Fields (doc_id, field_name) values (@doc_id, @field_name)
	else 
		raiserror('Такого документа не существует.', 16, 0)

	

END




GO
/****** Object:  StoredProcedure [dbo].[AttachFieldToImage]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[AttachFieldToImage]
@image_id int,
@field_name nvarchar(20),
@field_value nvarchar(4000)

AS
BEGIN
	
	if (select top(1) count(*) from Images where Id = @image_id) > 0 
		insert into Fields (image_id, field_name, field_value) values (@image_id, @field_name, @field_value)
	else 
		raiserror('Такого изображения не существует.', 16, 0)

	

END





GO
/****** Object:  StoredProcedure [dbo].[AttachImageToDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AttachImageToDocument]
@doc_id int,
@image varbinary(MAX)

AS
BEGIN
	
	if (select top(1) count(*) from Documents where Id = @doc_id) > 0 
		insert into Images (Image, doc_id) values (@image, @doc_id)
	else 
		raiserror('Такого документа не существует.', 16, 0)

	

END



GO
/****** Object:  StoredProcedure [dbo].[CompleteDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompleteDocument]
@user_id int,
@doc_id int

AS
BEGIN
	
	update Documents set Status = 'completed' where Id = @doc_id and who_filled = @user_id and Status = 'inwork'

END


GO
/****** Object:  StoredProcedure [dbo].[CreateDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[CreateDocument]
@name nvarchar(50),
@project nvarchar(50),
@comment nvarchar(200),
@pattern nvarchar(50)

AS
BEGIN
	
	insert into Documents (Name, Project, Comment, Pattern) output inserted.Id values (@name, @project, @comment, @pattern)

END




GO
/****** Object:  StoredProcedure [dbo].[DetachFieldFromDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DetachFieldFromDocument]
@field_id int,
@doc_id int

AS
BEGIN
	
	delete top(1) from Fields where Id = @field_id and doc_id = @doc_id

END





GO
/****** Object:  StoredProcedure [dbo].[DetachImageFromDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[DetachImageFromDocument]
@image_id int,
@doc_id int

AS
BEGIN
	
	delete top(1) from Images where Id = @image_id and doc_id = @doc_id

END




GO
/****** Object:  StoredProcedure [dbo].[GetAllPatterns]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[GetAllPatterns]

AS
BEGIN
	
	select PatternName from Patterns
	group by PatternName

END







GO
/****** Object:  StoredProcedure [dbo].[GetAllProjects]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetAllProjects]

AS
BEGIN
	
	select Project from Documents 
	group by Project

END






GO
/****** Object:  StoredProcedure [dbo].[GetDocumentById]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetDocumentById]
@doc_id int

AS
BEGIN
	
	select Name, Project, Comment, who_filled, Status from Documents where Id = @doc_id

END






GO
/****** Object:  StoredProcedure [dbo].[GetDocumentsInfo]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetDocumentsInfo]

AS
BEGIN
	
	select Id, Name, Project, Status from Documents 

END





GO
/****** Object:  StoredProcedure [dbo].[GetFirstImageFieldsForCheck]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[GetFirstImageFieldsForCheck]
@checker_id int

AS
BEGIN

  if (select count(*) from Images where Status = 'Проверяется' and checker_id = @checker_id) < 1
  begin
	update top(1) Images set Status = 'Проверяется', checker_id = @checker_id where Status = 'На проверке'
  end
  select f.field_name, f.field_value from Fields f inner join Images i on i.Id = f.image_id where f.image_id = (select top(1) Id from Images where Status = 'Проверяется' and checker_id = @checker_id)

END








GO
/****** Object:  StoredProcedure [dbo].[GetImageById]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetImageById]
@image_id int

AS
BEGIN
	
select top(1) Image from Images where Id = @image_id

END





GO
/****** Object:  StoredProcedure [dbo].[GetImageFields]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[GetImageFields]
@doc_id int

AS
BEGIN
	
	select p.FieldName from Documents d inner join Patterns p on d.Pattern = p.PatternName
	where d.id = @doc_id

END








GO
/****** Object:  StoredProcedure [dbo].[GetImageIdForCheck]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[GetImageIdForCheck]
@checker_id int

AS
BEGIN

  select top(1) Id from Images where Id = (select top(1) Id from Images where Status = 'Проверяется' and checker_id = @checker_id)

END









GO
/****** Object:  StoredProcedure [dbo].[GetImageIdForWork]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetImageIdForWork]
@user_id int

AS
BEGIN
	
if  (select count(*) from Images where user_id = @user_id and Status = 'В работе') > 0
	select top(1) Id, doc_id from Images where user_id = @user_id and Status = 'В работе'
else 
begin
	if (select count(*) from Images where (user_id is null or user_id = @user_id) and Status =  'Не в работе') > 0
	begin
		update top(1) Images set user_id = @user_id, Status = 'В работе' OUTPUT INSERTED.Id, INSERTED.doc_id where (user_id is null or user_id = @user_id) and Status = 'Не в работе'
	end
end

END





GO
/****** Object:  StoredProcedure [dbo].[GetPatternFields]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[GetPatternFields]
@pattern_name varchar(50)

AS
BEGIN
	
	select Id, FieldName from Patterns where PatternName = @pattern_name

END







GO
/****** Object:  StoredProcedure [dbo].[GetUserByLoginAndPass]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[GetUserByLoginAndPass]
@login nvarchar(50),
@password nvarchar(50)

AS
BEGIN
	
select top(1) u.Id, u.Fname, u.Lname, u.Patronymic, u.Description, r.Power Rights from Users u
inner join Rights r on r.Id = u.Rights
 where login = @login and password = @password

END








GO
/****** Object:  StoredProcedure [dbo].[MoveImageToCheck]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[MoveImageToCheck]
@image_id int

AS
BEGIN
	
	update top(1) Images set Status = 'На проверке' where Id = @image_id

END







GO
/****** Object:  StoredProcedure [dbo].[NextDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NextDocument]
@user_id int

AS
BEGIN
	
	if object_id('tempdb..#Temp') is not null drop table #Temp
    create TABLE #Temp (Id int)
    update top (1) d set d.Status = 'inwork', d.who_filled = @user_id OUTPUT inserted.Id  INTO #Temp  from Documents d  where d.Status = 'created'
    select Id from #Temp

END

GO
/****** Object:  StoredProcedure [dbo].[RemoveDocument]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[RemoveDocument]
@doc_id int

AS
BEGIN
	
	delete from Documents where Id = @doc_id

END










GO
/****** Object:  StoredProcedure [dbo].[RemovePattern]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[RemovePattern]
@pattern_name varchar(50)

AS
BEGIN
	
	delete from Patterns where PatternName = @pattern_name 

END









GO
/****** Object:  StoredProcedure [dbo].[RemovePatternField]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[RemovePatternField]
@pattern_name varchar(50),
@field_id int

AS
BEGIN
	
	delete top(1) from Patterns where Id = @field_id and PatternName = @pattern_name 

END








GO
/****** Object:  StoredProcedure [dbo].[SetVerdictForImage]    Script Date: 09.03.2020 21:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[SetVerdictForImage]
@image_id int,
@checker_id int,
@verdict int

AS
BEGIN
	
	if @verdict = 1
	begin
		update top(1) Images set Status = 'Готово' where Id = @image_id and checker_id = @checker_id
	end
	else if @verdict = 0
	begin
		delete from Fields where image_id = @image_id
		update top(1) Images set Status = 'Не в работе' where Id = @image_id and checker_id = @checker_id
	end

END








GO
USE [master]
GO
ALTER DATABASE [RewritePictures] SET  READ_WRITE 
GO
