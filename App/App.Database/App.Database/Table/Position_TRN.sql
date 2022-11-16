CREATE TABLE [dbo].[Position_TRN]
(
	--Identifier
	[RequestID]			   VARCHAR(15)		 NOT NULL PRIMARY KEY,
	[InternalID]	       UNIQUEIDENTIFIER  NOT NULL,
	[PositionID]	       VARCHAR(15)		 NOT NULL,
	--Position Details
	[Name] 			       VARCHAR(20)		 NOT NULL,
	[DepartmentInternalID] UNIQUEIDENTIFIER  NOT NULL,
	--Common Columns
	[Status] 			   INT				 NOT NULL,
	[CreatedDate]		   DATETIME		     NOT NULL,
	[ModifiedDate]		   DATETIME		     NULL
)
