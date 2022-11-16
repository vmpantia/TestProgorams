CREATE TABLE [dbo].[Position]
(
	--Identifier
	[InternalID]	       UNIQUEIDENTIFIER  NOT NULL PRIMARY KEY,
	[PositionID]	       VARCHAR(15)		 NOT NULL,
	--Position Details	   
	[Name] 			       VARCHAR(20)		 NOT NULL,
	[DepartmentInternalID] UNIQUEIDENTIFIER  NOT NULL,
	--Common Columns
	[Status] 			   INT				 NOT NULL,
	[CreatedDate]		   DATETIME		     NOT NULL,
	[ModifiedDate]		   DATETIME		     NULL
)
