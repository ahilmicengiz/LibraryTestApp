USE [dbo.Library]
GO
/****** Object:  Table [dbo].[tbl_Book]    Script Date: 4.09.2022 01:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](50) NULL,
	[InLibrary] [bit] NULL,
	[AuthorName] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LoanedDate] [datetime] NULL,
	[TakeBackDate] [datetime] NULL,
	[TakenName] [varchar](50) NULL,
	[BookImage] [varchar](500) NULL,
	[BringBackTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddBookDetail]    Script Date: 4.09.2022 01:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddBookDetail]  
(  
   @BookId int,
   @BookName varchar (50),  
   @InLibrary bit,  
   @AuthorName varchar (50),
   @CreatedDate datetime,
   @LoanedDate datetime,
   @TakeBackDate datetime,
   @TakenName varchar (50),
   @BookImage varchar (500)
)  
as  
begin  
   Insert into tbl_Book values(@BookName,@InLibrary,@AuthorName,@CreatedDate,@LoanedDate,@TakeBackDate,@TakenName,@BookImage)  
End 
GO
/****** Object:  StoredProcedure [dbo].[GetBooks]    Script Date: 4.09.2022 01:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetBooks]    
as    
begin    
   select Id as BookId,BookName,InLibrary,AuthorName,CreatedDate,LoanedDate,TakeBackDate,TakenName,BookImage from tbl_Book order by BookName asc 
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateBookDetails]    Script Date: 4.09.2022 01:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateBookDetails]  
(  
   @BookId int,  
   @BookName varchar (50),  
   @InLibrary varchar (50),  
   @AuthorName varchar (50),
   @CreatedDate datetime,
   @LoanedDate	datetime,
   @TakeBackDate	datetime,  
   @TakenName varchar (50),
   @BookImage varchar (500)
)  
as  
begin  
   Update tbl_Book  
   set BookName=@BookName,  
   InLibrary=@InLibrary,  
   AuthorName=@AuthorName,
   CreatedDate=@CreatedDate,
   LoanedDate = @LoanedDate,
   TakeBackDate=@TakeBackDate,
   TakenName=@TakenName,
   BookImage = @BookImage
   where Id=@BookId  
End  
GO
