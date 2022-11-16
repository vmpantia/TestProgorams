CREATE TABLE [dbo].[Department_TRN]
(
	--Identifier
	[RequestID]			VARCHAR(15)		 NOT NULL PRIMARY KEY,
	[InternalID]	    UNIQUEIDENTIFIER NOT NULL,
	[DepartmentID]	    VARCHAR(15)		 NOT NULL,
	--Department Details
	[Name] 			    VARCHAR(20)		 NOT NULL,
	[ManagerInternalID] UNIQUEIDENTIFIER NOT NULL,
	--Common Columns
	[Status] 			INT				 NOT NULL,
	[CreatedDate]		DATETIME		 NOT NULL,
	[ModifiedDate]		DATETIME		 NULL
)
